using Dapper;
using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace MBColumn.Infrastructure.Persistence;

public sealed class ProjectService : IProjectService, IDisposable
{
    private string? connectionString;
    private string? resultConnectionString;
    private SqliteConnection? _keepAliveConnection; // holds named in-memory DB alive
    private bool isModified;

    public string? CurrentFilePath { get; private set; }
    public string ProjectName { get; private set; } = "New Project";
    public bool IsModified => isModified;

    public event EventHandler? ProjectChanged;
    public event EventHandler? ColumnsChanged;
    public event EventHandler<ColumnInputChangedEventArgs>? ColumnInputChanged;

    public void Dispose()
    {
        _keepAliveConnection?.Dispose();
        _keepAliveConnection = null;
    }

    public void NewProject(string name)
    {
        _keepAliveConnection?.Dispose();
        _keepAliveConnection = null;
        CurrentFilePath = null;
        ProjectName = name;
        connectionString = null;
        resultConnectionString = null;
        isModified = false;
        ProjectChanged?.Invoke(this, EventArgs.Empty);
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RenameProject(string name)
    {
        ProjectName = name;
        MarkModified();
        ProjectChanged?.Invoke(this, EventArgs.Empty);
    }

    public void OpenProject(string filePath)
    {
        connectionString = BuildConnectionString(filePath);
        resultConnectionString = BuildConnectionString(filePath + "r");
        
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        
        using var rConn = new SqliteConnection(resultConnectionString);
        DatabaseSchema.OpenResultDb(rConn);

        var project = conn.QuerySingleOrDefault<ProjectRow>(
            "SELECT Name FROM Project LIMIT 1");

        CurrentFilePath = filePath;
        ProjectName = project?.Name ?? System.IO.Path.GetFileNameWithoutExtension(filePath);
        isModified = false;
        ProjectChanged?.Invoke(this, EventArgs.Empty);
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SaveProject()
    {
        if (CurrentFilePath is null)
            throw new InvalidOperationException("No file path — use SaveAs first.");
        SaveToFile(CurrentFilePath);
    }

    public void SaveProjectAs(string filePath)
    {
        SaveToFile(filePath);
        CurrentFilePath = filePath;
        isModified = false;
        ProjectChanged?.Invoke(this, EventArgs.Empty);
    }

    public IReadOnlyList<GroupRecord> GetGroups()
    {
        if (connectionString is null) return [];
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var rows = conn.Query<GroupRow>(
            "SELECT Id, Name, SortOrder FROM SectionGroup ORDER BY SortOrder, Id");
        return rows.Select(r => new GroupRecord(r.Id, r.Name, r.SortOrder)).ToList();
    }

    public GroupRecord AddGroup(string name)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Group name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueGroupName(conn, projectId, normalizedName);

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM SectionGroup WHERE ProjectId = @pid",
            new { pid = projectId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO SectionGroup (ProjectId, Name, SortOrder, CreatedAt, ModifiedAt)
            VALUES (@pid, @name, @sort, @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, name = normalizedName, sort = sortOrder, now });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new GroupRecord(id, normalizedName, sortOrder);
    }

    public void RenameGroup(int groupId, string newName)
    {
        var normalizedName = newName.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Group name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueGroupName(conn, projectId, normalizedName, groupId);

        conn.Execute(
            "UPDATE SectionGroup SET Name = @name, ModifiedAt = @now WHERE Id = @id",
            new { name = normalizedName, now = DateTime.UtcNow.ToString("O"), id = groupId });
        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void DeleteGroup(int groupId)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        conn.Execute("DELETE FROM SectionGroup WHERE Id = @id", new { id = groupId });
        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ReorderGroups(IEnumerable<(int Id, int SortOrder)> orders)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var now = DateTime.UtcNow.ToString("O");
        foreach (var (id, sortOrder) in orders)
        {
            conn.Execute(
                "UPDATE SectionGroup SET SortOrder = @sort, ModifiedAt = @now WHERE Id = @id",
                new { sort = sortOrder, now, id });
        }
        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public IReadOnlyList<ColumnRecord> GetColumns()
    {
        if (connectionString is null) return [];
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var rows = conn.Query<ColumnRow>(
            "SELECT Id, GroupId, Name, SortOrder FROM Column ORDER BY SortOrder, Id");
        return rows.Select(r => new ColumnRecord(r.Id, r.GroupId, r.Name, r.SortOrder)).ToList();
    }

    public ColumnRecord AddColumn(string name, int? groupId = null)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Section name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName);

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid AND COALESCE(GroupId, 0) = COALESCE(@gid, 0)",
            new { pid = projectId, gid = groupId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, GroupId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @gid, @name, @sort, '{}', @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, gid = groupId, name = normalizedName, sort = sortOrder, now });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new ColumnRecord(id, groupId, normalizedName, sortOrder);
    }

    public ColumnRecord DuplicateColumn(int sourceColumnId, string name, int? groupId = null)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Section name cannot be empty.");

        var snapshot = LoadColumnInput(sourceColumnId);
        if (snapshot is null) throw new InvalidOperationException("Source section no longer exists.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName);

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid AND COALESCE(GroupId, 0) = COALESCE(@gid, 0)",
            new { pid = projectId, gid = groupId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, GroupId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @gid, @name, @sort, '{}', @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, gid = groupId, name = normalizedName, sort = sortOrder, now });
            
        SaveColumnInput(id, snapshot);

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new ColumnRecord(id, groupId, normalizedName, sortOrder);
    }

    public void RenameColumn(int columnId, string newName)
    {
        var normalizedName = newName.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Section name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName, columnId);

        conn.Execute(
            "UPDATE Column SET Name = @name, ModifiedAt = @now WHERE Id = @id",
            new { name = normalizedName, now = DateTime.UtcNow.ToString("O"), id = columnId });
        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void DeleteColumn(int columnId)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

        using var tx = conn.BeginTransaction();
        conn.Execute("DELETE FROM DemandCase WHERE ColumnId = @id", new { id = columnId }, tx);
        conn.Execute("DELETE FROM Column WHERE Id = @id", new { id = columnId }, tx);
        tx.Commit();

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void MoveColumn(int columnId, int? newGroupId)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

        var now = DateTime.UtcNow.ToString("O");
        conn.Execute("UPDATE Column SET GroupId = @gid, ModifiedAt = @now WHERE Id = @id",
            new { gid = newGroupId, now, id = columnId });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void MoveColumns(IEnumerable<int> columnIds, int? newGroupId)
    {
        if (!columnIds.Any()) return;

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

        var now = DateTime.UtcNow.ToString("O");
        using var tx = conn.BeginTransaction();
        
        foreach (var id in columnIds)
        {
            conn.Execute("UPDATE Column SET GroupId = @gid, ModifiedAt = @now WHERE Id = @id",
                new { gid = newGroupId, now, id });
        }
        
        tx.Commit();
        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ReorderColumns(IEnumerable<(int Id, int? GroupId, int SortOrder)> orders)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var now = DateTime.UtcNow.ToString("O");
        foreach (var (id, groupId, sortOrder) in orders)
        {
            conn.Execute(
                "UPDATE Column SET GroupId = @gid, SortOrder = @sort, ModifiedAt = @now WHERE Id = @id",
                new { gid = groupId, sort = sortOrder, now, id });
        }

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SaveColumnInput(int columnId, ColumnInputSnapshot snapshot)
    {
        EnsureConnection();
        var previousSnapshot = LoadColumnInput(columnId);
        var previousHash = previousSnapshot is null ? null : ComputeHash(previousSnapshot);
        var currentHash = ComputeHash(snapshot);
        if (string.Equals(previousHash, currentHash, StringComparison.Ordinal))
        {
            return;
        }

        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

        var persistedSnapshot = CloneSnapshot(snapshot);
        var loadCases = persistedSnapshot.LoadCases.ToList();
        persistedSnapshot.LoadCases.Clear();
        var json = JsonSerializer.Serialize(persistedSnapshot, ResultJsonOptions);

        using var tx = conn.BeginTransaction();

        conn.Execute(
            "UPDATE Column SET InputJson = @json, ModifiedAt = @now WHERE Id = @id",
            new { json, now = DateTime.UtcNow.ToString("O"), id = columnId }, tx);

        conn.Execute("DELETE FROM DemandCase WHERE ColumnId = @id", new { id = columnId }, tx);

        foreach (var lc in loadCases)
        {
            conn.Execute(@"
                INSERT INTO DemandCase (ColumnId, IdString, Label, OriginalLoadCaseName, SourceObjectName, SourceObjectLabel, Story, Station, Source, Pu, Mux, Muy, IsActive, MxTop, MxBottom, MyTop, MyBottom, MxUsed, MyUsed, Vux, Vuy, MemberLengthOverride)
                VALUES (@cid, @idstr, @label, @orig, @son, @sol, @story, @station, @source, @pu, @mux, @muy, @active, @mxTop, @mxBottom, @myTop, @myBottom, @mxUsed, @myUsed, @vux, @vuy, @lenOverride)",
                new {
                    cid = columnId, idstr = lc.Id, label = lc.Label, orig = lc.OriginalLoadCaseName,
                    son = lc.SourceObjectName, sol = lc.SourceObjectLabel, story = lc.Story,
                    station = lc.Station, source = lc.Source, pu = lc.Pu, mux = lc.Mux, muy = lc.Muy, active = lc.IsActive ? 1 : 0,
                    mxTop = lc.MxTop, mxBottom = lc.MxBottom, myTop = lc.MyTop, myBottom = lc.MyBottom,
                    mxUsed = lc.MxUsed, myUsed = lc.MyUsed, vux = lc.Vux, vuy = lc.Vuy,
                    lenOverride = lc.MemberLengthOverride
                }, tx);
        }

        tx.Commit();
        MarkModified();
        ColumnInputChanged?.Invoke(this, new ColumnInputChangedEventArgs(columnId, previousHash, currentHash));
    }

    public ColumnInputSnapshot? LoadColumnInput(int columnId)
    {
        if (connectionString is null) return null;
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var json = conn.ExecuteScalar<string>(
            "SELECT InputJson FROM Column WHERE Id = @id", new { id = columnId });
        if (string.IsNullOrWhiteSpace(json) || json == "{}") return null;
        var snapshot = JsonSerializer.Deserialize<ColumnInputSnapshot>(json, ResultJsonOptions);
        if (snapshot == null) return null;

        if (snapshot.LoadCases.Count == 0)
        {
            var cases = conn.Query<SnapshotLoadCase>(@"
                SELECT IdString as Id, Label, OriginalLoadCaseName, SourceObjectName, SourceObjectLabel, Story, Station, Source, Pu, Mux, Muy, IsActive, MxTop, MxBottom, MyTop, MyBottom, MxUsed, MyUsed, Vux, Vuy, MemberLengthOverride
                FROM DemandCase WHERE ColumnId = @id", new { id = columnId });
            snapshot.LoadCases.AddRange(cases);
        }
        return snapshot;
    }

    public string ComputeColumnInputHash(ColumnInputSnapshot snapshot)
        => ComputeHash(snapshot);

    private static string ComputeHash(ColumnInputSnapshot snapshot)
    {
        var freshnessSnapshot = CreateFreshnessSnapshot(snapshot);
        var json = JsonSerializer.Serialize(freshnessSnapshot, ResultJsonOptions);
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    private static string ComputeLegacyHash(ColumnInputSnapshot snapshot)
    {
        var json = JsonSerializer.Serialize(snapshot, ResultJsonOptions);
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    private static ColumnInputSnapshot CreateFreshnessSnapshot(ColumnInputSnapshot source)
    {
        var snapshot = CloneSnapshot(source);

        var shape = Enum.TryParse<SectionShapeType>(snapshot.SectionShape, out var parsedShape)
            ? parsedShape
            : SectionShapeType.Rectangular;
        var layoutType = Enum.TryParse<RebarLayoutType>(snapshot.RebarLayoutType, out var parsedLayoutType)
            ? parsedLayoutType
            : RebarLayoutType.AllSidesEqual;

        bool usesCustomCoordinates = layoutType == RebarLayoutType.CustomCoordinates;
        if (shape != SectionShapeType.Irregular)
        {
            snapshot.BoundaryPoints = [];
            snapshot.OpeningPoints = [];
            snapshot.IrregularBarSize = "";
            snapshot.IrregularSpacing = 0;
            snapshot.IrregularRebarMode = "";

            if (!usesCustomCoordinates)
                snapshot.Rebars = [];

            return snapshot;
        }

        snapshot.OpeningPoints ??= [];
        if (!usesCustomCoordinates)
            snapshot.Rebars = [];

        return snapshot;
    }

    private static ColumnInputSnapshot CloneSnapshot(ColumnInputSnapshot source)
    {
        var json = JsonSerializer.Serialize(source, ResultJsonOptions);
        return JsonSerializer.Deserialize<ColumnInputSnapshot>(json, ResultJsonOptions)
            ?? new ColumnInputSnapshot();
    }

    public void SaveColumnResult(int columnId, CalculationResultDto result)
    {
        if (resultConnectionString is null) return;
        EnsureConnection();
        var snapshot = LoadColumnInput(columnId);
        if (snapshot is null) return;
        var hash = ComputeHash(snapshot);

        var json = JsonSerializer.Serialize(result, ResultJsonOptions);
        var compressedJson = CompressBase64(json);
        
        using var rConn = new SqliteConnection(resultConnectionString);
        DatabaseSchema.OpenResultDb(rConn);
        rConn.Execute("DELETE FROM ColumnResult WHERE ColumnId = @id", new { id = columnId });
        rConn.Execute(
            "INSERT INTO ColumnResult (ColumnId, InputHash, ResultJson) VALUES (@id, @hash, @json)",
            new { id = columnId, hash, json = compressedJson });
    }

    public CalculationResultDto? LoadColumnResult(int columnId)
    {
        if (connectionString is null || resultConnectionString is null) return null;
        var snapshot = LoadColumnInput(columnId);
        if (snapshot is null) return null;
        var hash = ComputeHash(snapshot);

        using var rConn = new SqliteConnection(resultConnectionString);
        DatabaseSchema.OpenResultDb(rConn);
        
        var row = rConn.QuerySingleOrDefault<ResultCacheRow>(
            "SELECT InputHash, ResultJson FROM ColumnResult WHERE ColumnId = @id", new { id = columnId });

        string? json = null;
        if (row is not null && (row.InputHash == hash || row.InputHash == ComputeLegacyHash(snapshot)))
        {
            json = row.ResultJson;
        }
        else if (row is null)
        {
            // Fallback for older projects: check ResultJson in Column table
            using var conn = new SqliteConnection(connectionString);
            json = conn.ExecuteScalar<string>(
                "SELECT ResultJson FROM Column WHERE Id = @id", new { id = columnId });
        }

        if (string.IsNullOrWhiteSpace(json)) return null;
        try 
        { 
            var decompressedJson = DecompressBase64(json);
            return JsonSerializer.Deserialize<CalculationResultDto>(decompressedJson, ResultJsonOptions); 
        }
        catch { return null; }
    }

    public bool HasColumnResult(int columnId)
    {
        if (connectionString is null || resultConnectionString is null) return false;

        using var rConn = new SqliteConnection(resultConnectionString);
        DatabaseSchema.OpenResultDb(rConn);

        var hasCached = rConn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM ColumnResult WHERE ColumnId = @id", new { id = columnId }) > 0;
        if (hasCached) return true;

        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var legacyJson = conn.ExecuteScalar<string>(
            "SELECT ResultJson FROM Column WHERE Id = @id", new { id = columnId });
        return !string.IsNullOrWhiteSpace(legacyJson);
    }

    private static string CompressBase64(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        using var msi = new System.IO.MemoryStream(bytes);
        using var mso = new System.IO.MemoryStream();
        using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
        {
            msi.CopyTo(gs);
        }
        return Convert.ToBase64String(mso.ToArray());
    }

    private static string DecompressBase64(string compressed)
    {
        if (string.IsNullOrWhiteSpace(compressed)) return compressed;
        if (compressed.StartsWith("{") || compressed.StartsWith("[")) return compressed; // Uncompressed JSON fallback

        try
        {
            var bytes = Convert.FromBase64String(compressed);
            using var msi = new System.IO.MemoryStream(bytes);
            using var mso = new System.IO.MemoryStream();
            using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }
            return System.Text.Encoding.UTF8.GetString(mso.ToArray());
        }
        catch
        {
            return compressed;
        }
    }

    private static readonly System.Text.Json.JsonSerializerOptions ResultJsonOptions = new()
    {
        IncludeFields = false,
        WriteIndented = false,
        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
    };

    public void MarkModified()
    {
        if (!isModified)
        {
            isModified = true;
            ProjectChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SaveToFile(string filePath)
    {
        var newCs = BuildConnectionString(filePath);
        var newResultCs = BuildConnectionString(filePath + "r");

        if (connectionString is null)
        {
            // New project, nothing in memory yet — wipe target file so old data can't survive
            DeleteFileAndCompanion(filePath);
            using var conn = new SqliteConnection(newCs);
            DatabaseSchema.EnsureCreated(conn, ProjectName);
            using var rConn = new SqliteConnection(newResultCs);
            DatabaseSchema.OpenResultDb(rConn);
            connectionString = newCs;
            resultConnectionString = newResultCs;
        }
        else if (_keepAliveConnection is not null && CurrentFilePath is null)
        {
            // New project with in-memory data — wipe target file before backup so no stale pages remain
            DeleteFileAndCompanion(filePath);
            using var conn = new SqliteConnection(newCs);
            conn.Open();
            _keepAliveConnection.BackupDatabase(conn);
            using var rConn = new SqliteConnection(newResultCs);
            DatabaseSchema.OpenResultDb(rConn);
            _keepAliveConnection.Dispose();
            _keepAliveConnection = null;
            connectionString = newCs;
            resultConnectionString = newResultCs;
        }
        else if (CurrentFilePath is null || !string.Equals(CurrentFilePath, filePath, StringComparison.OrdinalIgnoreCase))
        {
            if (CurrentFilePath is not null && System.IO.File.Exists(CurrentFilePath))
            {
                System.IO.File.Copy(CurrentFilePath, filePath, overwrite: true);
                if (System.IO.File.Exists(CurrentFilePath + "r"))
                    System.IO.File.Copy(CurrentFilePath + "r", filePath + "r", overwrite: true);
                else if (System.IO.File.Exists(filePath + "r"))
                    System.IO.File.Delete(filePath + "r");
            }
            else
            {
                DeleteFileAndCompanion(filePath);
                using var conn = new SqliteConnection(newCs);
                DatabaseSchema.EnsureCreated(conn, ProjectName);
                using var rConn = new SqliteConnection(newResultCs);
                DatabaseSchema.OpenResultDb(rConn);
            }
            connectionString = newCs;
            resultConnectionString = newResultCs;
        }

        if (_keepAliveConnection is null)
        {
            using var conn = new SqliteConnection(connectionString);
            DatabaseSchema.Open(conn);
            conn.Execute(
                "UPDATE Project SET Name = @name, ModifiedAt = @now WHERE Id = (SELECT Id FROM Project LIMIT 1)",
                new { name = ProjectName, now = DateTime.UtcNow.ToString("O") });
        }
    }

    private void EnsureConnection()
    {
        if (connectionString is not null) return;
        var inMemoryName = $"mbc_{Guid.NewGuid():N}";
        connectionString = $"Data Source={inMemoryName};Mode=Memory;Cache=Shared";
        _keepAliveConnection = new SqliteConnection(connectionString);
        _keepAliveConnection.Open();
        DatabaseSchema.EnsureCreated(_keepAliveConnection, ProjectName);
    }

    private static void DeleteFileAndCompanion(string filePath)
    {
        if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
        if (System.IO.File.Exists(filePath + "r")) System.IO.File.Delete(filePath + "r");
    }

    private static string BuildConnectionString(string filePath)
    {
        return new SqliteConnectionStringBuilder
        {
            DataSource = filePath,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();
    }

    private static void EnsureUniqueGroupName(SqliteConnection conn, int projectId, string name, int? excludingGroupId = null)
    {
        var count = conn.ExecuteScalar<int>(
            "SELECT COUNT(*) FROM SectionGroup WHERE ProjectId = @pid AND Name = @name AND (@excludeId IS NULL OR Id != @excludeId)",
            new { pid = projectId, name, excludeId = excludingGroupId });
        if (count > 0)
            throw new InvalidOperationException($"Group name '{name}' already exists.");
    }

    private void EnsureUniqueColumnName(SqliteConnection conn, int projectId, string name, int? excludeId = null)
    {
        var count = conn.ExecuteScalar<int>(
            "SELECT COUNT(*) FROM Column WHERE ProjectId = @pid AND Name = @name AND (@excludeId IS NULL OR Id != @excludeId)",
            new { pid = projectId, name, excludeId });
        if (count > 0)
            throw new InvalidOperationException($"Section name '{name}' already exists.");
    }

    public void SaveEtabsModelInfo(string modelName, string modelPath, string units, int storyCount, int pierCount, int frameCount)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        conn.Execute(
            """
            UPDATE Project
            SET EtabsModelName  = @modelName,
                EtabsModelPath  = @modelPath,
                EtabsUnits      = @units,
                EtabsStoryCount = @storyCount,
                EtabsPierCount  = @pierCount,
                EtabsFrameCount = @frameCount,
                ModifiedAt      = @now
            WHERE Id = (SELECT Id FROM Project LIMIT 1)
            """,
            new { modelName, modelPath, units, storyCount, pierCount, frameCount, now = DateTime.UtcNow.ToString("O") });
        MarkModified();
    }

    private sealed class GroupRow { public int Id { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
    private sealed class ColumnRow { public int Id { get; set; } public int? GroupId { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
    private sealed class ProjectRow { public string Name { get; set; } = ""; }
    private sealed class ColumnInputRow { public string InputJson { get; set; } = ""; }
    private sealed class ResultCacheRow { public string? InputHash { get; set; } public string? ResultJson { get; set; } }
}

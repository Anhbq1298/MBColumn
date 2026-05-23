using Dapper;
using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace MBColumn.Infrastructure.Persistence;

public sealed class ProjectService : IProjectService, IDisposable
{
    private string? connectionString;
    private SqliteConnection? _keepAliveConnection; // holds named in-memory DB alive
    private bool isModified;

    public string? CurrentFilePath { get; private set; }
    public string ProjectName { get; private set; } = "New Project";
    public bool IsModified => isModified;

    public event EventHandler? ProjectChanged;
    public event EventHandler? ColumnsChanged;

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
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

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

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName);

        var source = conn.QuerySingleOrDefault<ColumnInputRow>(
            "SELECT InputJson FROM Column WHERE Id = @id AND ProjectId = @pid",
            new { id = sourceColumnId, pid = projectId });
        if (source is null)
            throw new InvalidOperationException("Source section no longer exists.");

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid AND COALESCE(GroupId, 0) = COALESCE(@gid, 0)",
            new { pid = projectId, gid = groupId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, GroupId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @gid, @name, @sort, @json, @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, gid = groupId, name = normalizedName, sort = sortOrder, json = source.InputJson, now });

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

        conn.Execute("DELETE FROM Column WHERE Id = @id", new { id = columnId });
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
        var json = JsonSerializer.Serialize(snapshot);
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        conn.Execute(
            "UPDATE Column SET InputJson = @json, ModifiedAt = @now WHERE Id = @id",
            new { json, now = DateTime.UtcNow.ToString("O"), id = columnId });
        MarkModified();
    }

    public ColumnInputSnapshot? LoadColumnInput(int columnId)
    {
        if (connectionString is null) return null;
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var json = conn.ExecuteScalar<string>(
            "SELECT InputJson FROM Column WHERE Id = @id", new { id = columnId });
        if (string.IsNullOrWhiteSpace(json) || json == "{}") return null;
        return JsonSerializer.Deserialize<ColumnInputSnapshot>(json);
    }

    public void SaveColumnResult(int columnId, CalculationResultDto result)
    {
        EnsureConnection();
        var json = JsonSerializer.Serialize(result, ResultJsonOptions);
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        conn.Execute(
            "UPDATE Column SET ResultJson = @json WHERE Id = @id",
            new { json, id = columnId });
    }

    public CalculationResultDto? LoadColumnResult(int columnId)
    {
        if (connectionString is null) return null;
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var json = conn.ExecuteScalar<string>(
            "SELECT ResultJson FROM Column WHERE Id = @id", new { id = columnId });
        if (string.IsNullOrWhiteSpace(json)) return null;
        try { return JsonSerializer.Deserialize<CalculationResultDto>(json, ResultJsonOptions); }
        catch { return null; }
    }

    private static readonly System.Text.Json.JsonSerializerOptions ResultJsonOptions = new()
    {
        IncludeFields = false,
        WriteIndented = false
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
        if (connectionString is null)
        {
            var newCs = BuildConnectionString(filePath);
            using var conn = new SqliteConnection(newCs);
            DatabaseSchema.EnsureCreated(conn, ProjectName);
            connectionString = newCs;
        }
        else if (_keepAliveConnection is not null && CurrentFilePath is null)
        {
            var newCs = BuildConnectionString(filePath);
            using var conn = new SqliteConnection(newCs);
            DatabaseSchema.EnsureCreated(conn, ProjectName);
            _keepAliveConnection.Dispose();
            _keepAliveConnection = null;
            connectionString = newCs;
        }
        else if (CurrentFilePath is null || !string.Equals(CurrentFilePath, filePath, StringComparison.OrdinalIgnoreCase))
        {
            if (CurrentFilePath is not null && System.IO.File.Exists(CurrentFilePath))
            {
                System.IO.File.Copy(CurrentFilePath, filePath, overwrite: true);
            }
            else
            {
                var newCs = BuildConnectionString(filePath);
                using var conn = new SqliteConnection(newCs);
                DatabaseSchema.EnsureCreated(conn, ProjectName);
            }
            connectionString = BuildConnectionString(filePath);
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

    private sealed class GroupRow { public int Id { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
    private sealed class ColumnRow { public int Id { get; set; } public int? GroupId { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
    private sealed class ProjectRow { public string Name { get; set; } = ""; }
    private sealed class ColumnInputRow { public string InputJson { get; set; } = ""; }
}

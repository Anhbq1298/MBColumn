using Dapper;
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

    public IReadOnlyList<ColumnRecord> GetColumns()
    {
        if (connectionString is null) return [];
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var rows = conn.Query<ColumnRow>(
            "SELECT Id, Name, SortOrder FROM Column ORDER BY SortOrder, Id");
        return rows.Select(r => new ColumnRecord(r.Id, r.Name, r.SortOrder)).ToList();
    }

    public ColumnRecord AddColumn(string name)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Column name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName);

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid",
            new { pid = projectId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @name, @sort, '{}', @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, name = normalizedName, sort = sortOrder, now });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new ColumnRecord(id, normalizedName, sortOrder);
    }

    public ColumnRecord DuplicateColumn(int sourceColumnId, string name)
    {
        var normalizedName = name.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Column name cannot be empty.");

        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");

        EnsureUniqueColumnName(conn, projectId, normalizedName);

        var source = conn.QuerySingleOrDefault<ColumnInputRow>(
            "SELECT InputJson FROM Column WHERE Id = @id AND ProjectId = @pid",
            new { id = sourceColumnId, pid = projectId });
        if (source is null)
            throw new InvalidOperationException("Source column no longer exists.");

        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid",
            new { pid = projectId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @name, @sort, @json, @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, name = normalizedName, sort = sortOrder, json = source.InputJson, now });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new ColumnRecord(id, normalizedName, sortOrder);
    }

    public void RenameColumn(int columnId, string newName)
    {
        var normalizedName = newName.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName))
            throw new InvalidOperationException("Column name cannot be empty.");

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

    public void ReorderColumns(IEnumerable<(int Id, int SortOrder)> orders)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        var now = DateTime.UtcNow.ToString("O");
        foreach (var (id, sortOrder) in orders)
        {
            conn.Execute(
                "UPDATE Column SET SortOrder = @sort, ModifiedAt = @now WHERE Id = @id",
                new { sort = sortOrder, now, id });
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
        // If saving to a different file, copy the in-memory/current DB
        if (connectionString is null)
        {
            // New project that was never opened — create database at target path
            var newCs = BuildConnectionString(filePath);
            using var conn = new SqliteConnection(newCs);
            DatabaseSchema.EnsureCreated(conn, ProjectName);
            connectionString = newCs;
        }
        else if (_keepAliveConnection is not null && CurrentFilePath is null)
        {
            // Was using in-memory DB — write schema/data to the file instead
            var newCs = BuildConnectionString(filePath);
            using var conn = new SqliteConnection(newCs);
            DatabaseSchema.EnsureCreated(conn, ProjectName);
            _keepAliveConnection.Dispose();
            _keepAliveConnection = null;
            connectionString = newCs;
        }
        else if (CurrentFilePath is null || !string.Equals(CurrentFilePath, filePath, StringComparison.OrdinalIgnoreCase))
        {
            // Save As: copy current file to new path
            if (CurrentFilePath is not null && System.IO.File.Exists(CurrentFilePath))
            {
                System.IO.File.Copy(CurrentFilePath, filePath, overwrite: true);
            }
            else
            {
                // No existing file — create a new DB at destination
                var newCs = BuildConnectionString(filePath);
                using var conn = new SqliteConnection(newCs);
                DatabaseSchema.EnsureCreated(conn, ProjectName);
            }

            connectionString = BuildConnectionString(filePath);
        }

        // Update project name and ModifiedAt in the file
        using var updateConn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(updateConn);
        updateConn.Execute(
            "UPDATE Project SET Name = @name, ModifiedAt = @now WHERE Id = (SELECT MIN(Id) FROM Project)",
            new { name = ProjectName, now = DateTime.UtcNow.ToString("O") });

        isModified = false;
    }

    private void EnsureConnection()
    {
        if (connectionString is not null) return;

        // New unsaved project — use an in-memory db with a named cache so
        // multiple connections share the same data within this process.
        // The keep-alive connection must stay open; closing all connections
        // destroys a named in-memory database.
        connectionString = "Data Source=mbcolumn_new;Mode=Memory;Cache=Shared";
        _keepAliveConnection = new SqliteConnection(connectionString);
        DatabaseSchema.EnsureCreated(_keepAliveConnection, ProjectName);
    }

    private static void EnsureUniqueColumnName(SqliteConnection conn, int projectId, string name, int? excludingColumnId = null)
    {
        var lowerName = name.ToLowerInvariant();
        var count = conn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM Column WHERE ProjectId = @projectId AND LOWER(Name) = @name " +
            "AND (@exclude IS NULL OR Id != @exclude)",
            new { projectId, name = lowerName, exclude = excludingColumnId });
        if (count > 0)
            throw new InvalidOperationException($"A column named '{name}' already exists. Column names must be unique.");
    }

    private static string BuildConnectionString(string filePath)
        => $"Data Source={filePath};";

    private sealed class ProjectRow { public string Name { get; set; } = ""; }
    private sealed class ColumnRow { public int Id { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
    private sealed class ColumnInputRow { public string InputJson { get; set; } = "{}"; }
}

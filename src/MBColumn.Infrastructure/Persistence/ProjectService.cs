using Dapper;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace MBColumn.Infrastructure.Persistence;

public sealed class ProjectService : IProjectService
{
    private string? connectionString;
    private bool isModified;

    public string? CurrentFilePath { get; private set; }
    public string ProjectName { get; private set; } = "New Project";
    public bool IsModified => isModified;

    public event EventHandler? ProjectChanged;
    public event EventHandler? ColumnsChanged;

    public void NewProject(string name)
    {
        CurrentFilePath = null;
        ProjectName = name;
        connectionString = null;
        isModified = false;
        ProjectChanged?.Invoke(this, EventArgs.Empty);
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
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
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);

        var projectId = conn.ExecuteScalar<int>("SELECT Id FROM Project LIMIT 1");
        var now = DateTime.UtcNow.ToString("O");
        var sortOrder = conn.ExecuteScalar<int>(
            "SELECT COALESCE(MAX(SortOrder), -1) + 1 FROM Column WHERE ProjectId = @pid",
            new { pid = projectId });

        var id = conn.ExecuteScalar<int>("""
            INSERT INTO Column (ProjectId, Name, SortOrder, InputJson, CreatedAt, ModifiedAt)
            VALUES (@pid, @name, @sort, '{}', @now, @now);
            SELECT last_insert_rowid();
            """,
            new { pid = projectId, name, sort = sortOrder, now });

        MarkModified();
        ColumnsChanged?.Invoke(this, EventArgs.Empty);
        return new ColumnRecord(id, name, sortOrder);
    }

    public void RenameColumn(int columnId, string newName)
    {
        EnsureConnection();
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.Open(conn);
        conn.Execute(
            "UPDATE Column SET Name = @name, ModifiedAt = @now WHERE Id = @id",
            new { name = newName, now = DateTime.UtcNow.ToString("O"), id = columnId });
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
        connectionString = "Data Source=mbcolumn_new;Mode=Memory;Cache=Shared";
        using var conn = new SqliteConnection(connectionString);
        DatabaseSchema.EnsureCreated(conn, ProjectName);
    }

    private static string BuildConnectionString(string filePath)
        => $"Data Source={filePath};";

    private sealed class ProjectRow { public string Name { get; set; } = ""; }
    private sealed class ColumnRow { public int Id { get; set; } public string Name { get; set; } = ""; public int SortOrder { get; set; } }
}

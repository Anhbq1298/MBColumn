using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Application.Services;

public sealed record ColumnRecord(int Id, string Name, int SortOrder);

public interface IProjectService
{
    string? CurrentFilePath { get; }
    string ProjectName { get; }
    bool IsModified { get; }

    void NewProject(string name);
    void RenameProject(string name);
    void OpenProject(string filePath);
    void SaveProject();
    void SaveProjectAs(string filePath);

    IReadOnlyList<ColumnRecord> GetColumns();
    ColumnRecord AddColumn(string name);
    void RenameColumn(int columnId, string newName);
    void DeleteColumn(int columnId);
    void ReorderColumns(IEnumerable<(int Id, int SortOrder)> orders);

    void SaveColumnInput(int columnId, ColumnInputSnapshot snapshot);
    ColumnInputSnapshot? LoadColumnInput(int columnId);

    void MarkModified();

    event EventHandler? ProjectChanged;
    event EventHandler? ColumnsChanged;
}

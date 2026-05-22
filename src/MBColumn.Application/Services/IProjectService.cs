using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Application.Services;

public sealed record ColumnRecord(int Id, int? GroupId, string Name, int SortOrder);
public sealed record GroupRecord(int Id, string Name, int SortOrder);

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

    IReadOnlyList<GroupRecord> GetGroups();
    GroupRecord AddGroup(string name);
    void RenameGroup(int groupId, string newName);
    void DeleteGroup(int groupId);
    void ReorderGroups(IEnumerable<(int Id, int SortOrder)> orders);

    IReadOnlyList<ColumnRecord> GetColumns();
    ColumnRecord AddColumn(string name, int? groupId = null);
    ColumnRecord DuplicateColumn(int sourceColumnId, string name, int? groupId = null);
    void RenameColumn(int columnId, string newName);
    void DeleteColumn(int columnId);
    void MoveColumn(int columnId, int? newGroupId);
    void MoveColumns(IEnumerable<int> columnIds, int? newGroupId);
    void ReorderColumns(IEnumerable<(int Id, int? GroupId, int SortOrder)> orders);

    void SaveColumnInput(int columnId, ColumnInputSnapshot snapshot);
    ColumnInputSnapshot? LoadColumnInput(int columnId);

    void MarkModified();

    event EventHandler? ProjectChanged;
    event EventHandler? ColumnsChanged;
}

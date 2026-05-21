using MBColumn.Application.DTOs;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class ProjectSession
{
    private readonly Dictionary<int, CalculationResultDto> columnResults = [];
    private readonly HashSet<int> outdatedColumnIds = [];

    public int? CurrentColumnId { get; private set; }

    public void SelectColumn(int? columnId)
    {
        CurrentColumnId = columnId;
    }

    public void StoreCurrentColumnResult(CalculationResultDto result)
    {
        if (CurrentColumnId is null) return;
        StoreColumnResult(CurrentColumnId.Value, result);
    }

    public void StoreColumnResult(int columnId, CalculationResultDto result)
    {
        columnResults[columnId] = result;
        outdatedColumnIds.Remove(columnId);
    }

    public bool TryGetCurrentColumnResult(out CalculationResultDto? result)
    {
        if (CurrentColumnId is not null && columnResults.TryGetValue(CurrentColumnId.Value, out var cachedResult))
        {
            result = cachedResult;
            return true;
        }

        result = null;
        return false;
    }

    public bool CurrentColumnHasResult()
        => CurrentColumnId is not null && columnResults.ContainsKey(CurrentColumnId.Value);

    public void MarkCurrentColumnOutdated()
    {
        if (CurrentColumnId is not null && columnResults.ContainsKey(CurrentColumnId.Value))
            outdatedColumnIds.Add(CurrentColumnId.Value);
    }

    public bool IsCurrentColumnOutdated()
        => CurrentColumnId is not null && outdatedColumnIds.Contains(CurrentColumnId.Value);

    public void ClearColumnResult(int columnId)
    {
        columnResults.Remove(columnId);
        outdatedColumnIds.Remove(columnId);
    }

    public void ClearResults()
    {
        columnResults.Clear();
        outdatedColumnIds.Clear();
    }
}

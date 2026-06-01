using MBColumn.Application.DTOs;
using MBColumn.Application.RebarSuggestion;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public interface IAutoDesignRebarDialogService
{
    RebarSuggestionOption? ShowDialog(ColumnInputDto currentInput, Window? owner);
}

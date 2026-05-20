using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public interface IProjectNameDialogService
{
    string? PromptProjectName(string defaultName);
    string? PromptColumnName(string defaultName);
}

public sealed class ProjectNameDialogService : IProjectNameDialogService
{
    public string? PromptProjectName(string defaultName)
        => Prompt(defaultName, "New Project");

    public string? PromptColumnName(string defaultName)
        => Prompt(defaultName, "New Column");

    private static string? Prompt(string defaultName, string title)
    {
        var dialog = new ProjectNameDialog(defaultName, title);
        return dialog.ShowDialog() == true ? dialog.ProjectName : null;
    }
}

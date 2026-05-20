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
        => Prompt(defaultName, "New Project", "Project name:");

    public string? PromptColumnName(string defaultName)
        => Prompt(defaultName, "New Section", "Section name:");

    private static string? Prompt(string defaultName, string title, string label)
    {
        var dialog = new ProjectNameDialog(defaultName, title, label);
        return dialog.ShowDialog() == true ? dialog.ProjectName : null;
    }
}

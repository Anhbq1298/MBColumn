namespace MBColumn.Presentation.Wpf.Services;

public interface IProjectFileDialogService
{
    string? ShowOpenProjectDialog();
    string? ShowSaveProjectAsDialog(string defaultFileName);
}

public sealed class ProjectFileDialogService : IProjectFileDialogService
{
    private const string ProjectFilter = "MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*";

    public string? ShowOpenProjectDialog()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Title = "Open MBColumn Project",
            Filter = ProjectFilter,
            DefaultExt = ".msd"
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string? ShowSaveProjectAsDialog(string defaultFileName)
    {
        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Save MBColumn Project As",
            Filter = ProjectFilter,
            DefaultExt = ".msd",
            FileName = defaultFileName
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }
}

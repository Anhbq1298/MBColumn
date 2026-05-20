namespace MBColumn.Presentation.Wpf.Services;

public interface IProjectFileDialogService
{
    string? ShowOpenProjectDialog();
    string? ShowSaveProjectAsDialog(string defaultFileName);
}

public sealed class ProjectFileDialogService : IProjectFileDialogService
{
    private const string OpenProjectFilter = "MBColumn Project (*.mbc;*.msd)|*.mbc;*.msd|Legacy MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*";
    private const string SaveProjectFilter = "MBColumn Project (*.mbc)|*.mbc|Legacy MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*";

    public string? ShowOpenProjectDialog()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Title = "Open MBColumn Project",
            Filter = OpenProjectFilter,
            DefaultExt = ".mbc"
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string? ShowSaveProjectAsDialog(string defaultFileName)
    {
        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Save MBColumn Project As",
            Filter = SaveProjectFilter,
            DefaultExt = ".mbc",
            AddExtension = true,
            FileName = defaultFileName
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }
}

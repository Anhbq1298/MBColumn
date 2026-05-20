using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public interface IMessageService
{
    void ShowError(string message, string title = "Error");
    void ShowWarning(string message, string title = "Warning");
    bool ConfirmWarning(string message, string title);
}

public sealed class MessageBoxService : IMessageService
{
    public void ShowError(string message, string title = "Error")
        => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

    public void ShowWarning(string message, string title = "Warning")
        => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);

    public bool ConfirmWarning(string message, string title)
        => MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;
}

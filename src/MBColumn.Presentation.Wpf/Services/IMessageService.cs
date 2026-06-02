using System.Windows;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public interface IMessageService
{
    void ShowError(string message, string title = "Error");
    void ShowInformation(string message, string title = "Information");
    void ShowWarning(string message, string title = "Warning");
    bool ConfirmWarning(string message, string title);
}

public sealed class MessageBoxService : IMessageService
{
    public void ShowError(string message, string title = "Error")
        => AppNotificationDialog.Show(message, title, MessageBoxImage.Error);

    public void ShowInformation(string message, string title = "Information")
        => AppNotificationDialog.Show(message, title, MessageBoxImage.Information);

    public void ShowWarning(string message, string title = "Warning")
        => AppNotificationDialog.Show(message, title, MessageBoxImage.Warning);

    public bool ConfirmWarning(string message, string title)
        => AppNotificationDialog.Show(message, title, MessageBoxImage.Warning, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
}

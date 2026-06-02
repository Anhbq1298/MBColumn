using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Views;

public partial class AppNotificationDialog : Window
{
    private MessageBoxResult result = MessageBoxResult.Cancel;

    public AppNotificationDialog(
        string message,
        string title,
        MessageBoxImage image = MessageBoxImage.Information,
        MessageBoxButton buttons = MessageBoxButton.OK)
    {
        InitializeComponent();

        Title = title;
        TitleTextBlock.Text = title;
        MessageTextBlock.Text = message;
        ConfigureIcon(image);
        ConfigureButtons(buttons);
    }

    public static MessageBoxResult Show(
        string message,
        string title = "Information",
        MessageBoxImage image = MessageBoxImage.Information,
        MessageBoxButton buttons = MessageBoxButton.OK,
        Window? owner = null)
    {
        var dialog = new AppNotificationDialog(message, title, image, buttons);
        owner ??= System.Windows.Application.Current?.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)
                  ?? System.Windows.Application.Current?.MainWindow;

        if (owner is not null && owner != dialog)
            dialog.Owner = owner;

        dialog.ShowDialog();
        return dialog.result;
    }

    private void ConfigureIcon(MessageBoxImage image)
    {
        var (glyph, background, foreground) = image switch
        {
            MessageBoxImage.Error => ("\uE783", Color.FromRgb(255, 232, 232), Color.FromRgb(198, 40, 40)),
            MessageBoxImage.Warning => ("\uE7BA", Color.FromRgb(255, 247, 230), Color.FromRgb(198, 134, 0)),
            _ => ("\uE73E", Color.FromRgb(224, 247, 235), Color.FromRgb(27, 138, 78))
        };

        IconTextBlock.Text = glyph;
        IconCircle.Background = new SolidColorBrush(background);
        IconTextBlock.Foreground = new SolidColorBrush(foreground);
    }

    private void ConfigureButtons(MessageBoxButton buttons)
    {
        bool yesNo = buttons == MessageBoxButton.YesNo || buttons == MessageBoxButton.YesNoCancel;
        OkButton.Visibility = yesNo ? Visibility.Collapsed : Visibility.Visible;
        YesButton.Visibility = yesNo ? Visibility.Visible : Visibility.Collapsed;
        NoButton.Visibility = yesNo ? Visibility.Visible : Visibility.Collapsed;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        result = MessageBoxResult.OK;
        DialogResult = true;
    }

    private void YesButton_Click(object sender, RoutedEventArgs e)
    {
        result = MessageBoxResult.Yes;
        DialogResult = true;
    }

    private void NoButton_Click(object sender, RoutedEventArgs e)
    {
        result = MessageBoxResult.No;
        DialogResult = false;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        result = MessageBoxResult.Cancel;
        DialogResult = false;
    }
}

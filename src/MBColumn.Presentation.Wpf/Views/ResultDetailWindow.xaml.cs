using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ResultDetailWindow : Window
{
    public ResultDetailWindow(string title, FrameworkElement content, object dataContext)
    {
        InitializeComponent();

        Title = title;
        content.DataContext = dataContext;
        DetailHost.Content = content;
    }
}

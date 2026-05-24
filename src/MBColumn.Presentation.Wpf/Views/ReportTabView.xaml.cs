using System.Windows;
using System.Windows.Controls;
using MBColumn.Presentation.Wpf.Controls;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ReportTabView : UserControl
{
    public ReportTabView() => InitializeComponent();

    private void PrintButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new PrintDialog();
        if (!dialog.ShowDialog().GetValueOrDefault()) return;

        var paginator = new ReportPaginator(
            ReportContent,
            new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));

        dialog.PrintDocument(paginator, "MBColumn Design Report");
    }
}

using System.Windows;
using System.Windows.Controls;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class SectionPreviewInputView : UserControl
{
    public SectionPreviewInputView()
    {
        InitializeComponent();
    }

    private void OpenCadEditor_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dialog = new SectionCadEditorWindow(vm)
        {
            Owner = Window.GetWindow(this)
        };
        dialog.ShowDialog();
    }
}

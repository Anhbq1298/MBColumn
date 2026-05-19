using System.Windows;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ProjectNameDialog : Window
{
    public string ProjectName { get; private set; } = "";

    public ProjectNameDialog(string defaultName, string title = "New Project")
    {
        InitializeComponent();
        Title = title;
        NameBox.Text = defaultName;
        Loaded += (_, _) =>
        {
            NameBox.Focus();
            NameBox.SelectAll();
        };
    }

    private void OK_Click(object sender, RoutedEventArgs e) => Commit();
    private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;

    private void NameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) Commit();
    }

    private void Commit()
    {
        var name = NameBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Project name cannot be empty.", "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        ProjectName = name;
        DialogResult = true;
    }
}

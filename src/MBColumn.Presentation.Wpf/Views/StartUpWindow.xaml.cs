using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Services;

namespace MBColumn.Presentation.Wpf.Views;

public partial class StartUpWindow : Window
{
    private readonly IProjectService projectService;
    private readonly RecentProjectsService recentService = new();

    public StartUpWindow(IProjectService projectService)
    {
        InitializeComponent();
        this.projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));

        BtnNew.Click += BtnNew_Click;
        BtnOpen.Click += BtnOpen_Click;
        BtnCancel.Click += (_, _) => { DialogResult = false; };
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        LoadRecents();
        RecentList.MouseDoubleClick += RecentList_MouseDoubleClick;
    }

    private void LoadRecents()
    {
        var items = recentService.GetRecent().Where(File.Exists).ToList();
        RecentList.ItemsSource = items;
    }

    private void BtnNew_Click(object? sender, RoutedEventArgs e)
    {
        var dlg = new ProjectNameDialog("New Project", "New Project");
        if (dlg.ShowDialog() != true) return;
        var name = dlg.ProjectName?.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Project name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            projectService.NewProject(name);
            DialogResult = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to create project:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnOpen_Click(object? sender, RoutedEventArgs e)
    {
        var dlg = new Microsoft.Win32.OpenFileDialog
        {
            Title = "Open MBColumn Project",
            Filter = "MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*",
            DefaultExt = ".msd"
        };

        if (dlg.ShowDialog() != true) return;

        try
        {
            projectService.OpenProject(dlg.FileName);
            recentService.AddRecent(dlg.FileName);
            DialogResult = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open project:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void RecentList_MouseDoubleClick(object? sender, MouseButtonEventArgs e)
    {
        if (RecentList.SelectedItem is not string path) return;
        try
        {
            projectService.OpenProject(path);
            recentService.AddRecent(path);
            DialogResult = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open project:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

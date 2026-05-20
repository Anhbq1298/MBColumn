using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dapper;
using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Services;
using Microsoft.Data.Sqlite;

namespace MBColumn.Presentation.Wpf.Views;

public class RecentFileItem
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName => Path.GetFileName(FilePath);
    public string FolderPath => Path.GetDirectoryName(FilePath) ?? string.Empty;
}

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
        var items = recentService.GetRecent()
            .Where(File.Exists)
            .Select(p => new RecentFileItem { FilePath = p })
            .ToList();
        RecentList.ItemsSource = items;

        if (items.Any())
        {
            RecentList.SelectedIndex = 0;
        }
    }

    private void RecentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (RecentList.SelectedItem is RecentFileItem selectedItem)
        {
            ShowProjectPreview(selectedItem.FilePath);
        }
        else
        {
            ClearProjectPreview();
        }
    }

    private void ShowProjectPreview(string filePath)
    {
        if (!File.Exists(filePath))
        {
            ClearProjectPreview();
            return;
        }

        try
        {
            var fileInfo = new FileInfo(filePath);
            var sizeInKb = fileInfo.Length / 1024;
            var lastWrite = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm");

            var connectionString = $"Data Source={filePath};Mode=ReadOnly;";
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var projectName = conn.QuerySingleOrDefault<string>(
                "SELECT Name FROM Project LIMIT 1") ?? Path.GetFileNameWithoutExtension(filePath);

            var columns = conn.Query<string>(
                "SELECT Name FROM Column ORDER BY SortOrder, Id").ToList();

            PreviewPanel.Visibility = Visibility.Visible;
            NoSelectionText.Visibility = Visibility.Collapsed;

            TxtPreviewProjName.Text = projectName;
            TxtPreviewFileName.Text = Path.GetFileName(filePath);
            TxtPreviewLastModified.Text = lastWrite;
            TxtPreviewFileSize.Text = $"{sizeInKb} KB";

            PreviewColumnsList.ItemsSource = columns;
            TxtPreviewColCount.Text = $"Columns ({columns.Count})";
        }
        catch (Exception ex)
        {
            PreviewPanel.Visibility = Visibility.Collapsed;
            NoSelectionText.Visibility = Visibility.Visible;
            NoSelectionText.Text = $"Failed to load preview:\n{ex.Message}";
        }
    }

    private void ClearProjectPreview()
    {
        PreviewPanel.Visibility = Visibility.Collapsed;
        NoSelectionText.Visibility = Visibility.Visible;
        NoSelectionText.Text = "Select a recent project to preview its details and columns.";
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
        if (RecentList.SelectedItem is not RecentFileItem item) return;
        var path = item.FilePath;
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

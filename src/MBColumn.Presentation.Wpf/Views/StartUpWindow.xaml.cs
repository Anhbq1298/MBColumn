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
    public string LastModified { get; set; } = string.Empty;
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
        BtnInfo.Click += BtnInfo_Click;
        BtnCancel.Click += (_, _) => { DialogResult = false; };
        BtnClearRecent.Click += (_, _) => { recentService.ClearRecent(); LoadRecents(); ClearProjectPreview(); };
        RecentList.MouseDoubleClick += RecentList_MouseDoubleClick;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        LoadRecents();
    }

    private void LoadRecents()
    {
        var items = recentService.GetRecent()
            .Where(p => File.Exists(p) && p.EndsWith(".mbc", StringComparison.OrdinalIgnoreCase))
            .Select(p =>
            {
                var fi = new FileInfo(p);
                return new RecentFileItem
                {
                    FilePath = p,
                    LastModified = FormatLastModified(fi.LastWriteTime)
                };
            })
            .ToList();
        RecentList.ItemsSource = items;

        if (items.Any())
        {
            RecentList.SelectedIndex = 0;
        }
    }

    private static string FormatLastModified(DateTime lastWrite)
    {
        var elapsed = DateTime.Now - lastWrite;
        if (elapsed.TotalMinutes < 1) return "Just now";
        if (elapsed.TotalMinutes < 60) return $"{(int)elapsed.TotalMinutes} min ago";
        if (elapsed.TotalHours < 24) return $"{(int)elapsed.TotalHours}h ago";
        if (elapsed.TotalDays < 7) return $"{(int)elapsed.TotalDays}d ago";
        return lastWrite.ToString("dd MMM yyyy, HH:mm");
    }

    private void BtnInfo_Click(object? sender, RoutedEventArgs e)
    {
        MessageBox.Show(
            "Developer: Mark Bui",
            "Information",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
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
            TxtPreviewFileName.Text = filePath;
            TxtPreviewFileName.ToolTip = filePath;
            TxtPreviewLastModified.Text = lastWrite;
            TxtPreviewFileSize.Text = $"{sizeInKb} KB";

            PreviewColumnsList.ItemsSource = columns;
            TxtPreviewColCount.Text = $"Sections ({columns.Count})";
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
        NoSelectionText.Text = "Select a recent project to preview its details and sections.";
    }

    private void BtnNew_Click(object? sender, RoutedEventArgs e)
    {
        var dlg = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Create New Project",
            Filter = "MBColumn Project (*.mbc)|*.mbc",
            DefaultExt = ".mbc",
            FileName = "New Project.mbc"
        };
        
        if (dlg.ShowDialog() != true) return;

        try
        {
            var name = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
            projectService.NewProject(name);
            projectService.SaveProjectAs(dlg.FileName);
            recentService.AddRecent(dlg.FileName);
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
            Filter = "MBColumn Project (*.mbc)|*.mbc",
            DefaultExt = ".mbc"
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

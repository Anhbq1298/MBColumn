using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ReportTabView : UserControl
{
    private bool webViewInitialized;

    public ReportTabView()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue is ReportTabViewModel old)
        {
            old.PropertyChanged -= OnViewModelPropertyChanged;
            old.WebViewPrintToPdfAsync = null;
            old.WebViewScrollToAnchor = null;
        }
        if (e.NewValue is ReportTabViewModel vm)
        {
            vm.PropertyChanged += OnViewModelPropertyChanged;
            vm.WebViewPrintToPdfAsync = PrintToPdfAsync;
            vm.WebViewScrollToAnchor = ScrollToAnchor;
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ReportTabViewModel.ReportHtmlContent))
            _ = NavigateAsync();
    }

    private async Task EnsureWebViewAsync()
    {
        if (webViewInitialized) return;
        await ReportWebView.EnsureCoreWebView2Async();
        ReportWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
        ReportWebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        webViewInitialized = true;
    }

    private async Task NavigateAsync()
    {
        if (DataContext is not ReportTabViewModel vm) return;
        var html = vm.ReportHtmlContent;
        if (string.IsNullOrEmpty(html)) return;
        try
        {
            await EnsureWebViewAsync();
            ReportWebView.NavigateToString(html);
        }
        catch { }
    }

    private async Task PrintToPdfAsync(string filePath)
    {
        await EnsureWebViewAsync();
        await ReportWebView.CoreWebView2.PrintToPdfAsync(filePath);
    }

    private void ScrollToAnchor(string anchorId)
    {
        if (!webViewInitialized) return;
        _ = ReportWebView.ExecuteScriptAsync(
            $"document.getElementById('{anchorId}')?.scrollIntoView({{behavior:'smooth',block:'start'}})");
    }
}

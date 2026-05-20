using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Presentation.Wpf.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.ViewModels;

public record PreviewRebarVm(double Left, double Top, double Size);

public sealed class DxfImportViewModel : ViewModelBase
{
    private const double PreviewCanvasW = 580;
    private const double PreviewCanvasH = 160;
    private const double PreviewPadding = 16;

    private readonly IDxfImportService importService;
    private string filePath = "";
    private string selectedBoundaryLayerName = "";
    private string selectedRebarLayerName = "";
    private double scaleFactor = 1.0;
    private bool overrideRebarDiameter = false;
    private double rebarDiameterMm = 25.0;
    private string summaryText = "Select a DXF file to load available layers.";
    private string message = "";
    private bool hasErrors;
    private PointCollection previewBoundaryPoints = [];
    private bool hasPreview = false;

    public DxfImportViewModel(IDxfImportService importService)
    {
        this.importService = importService;
        LayerNames = [];
        PreviewRebars = [];
        BrowseFileCommand = new RelayCommand(BrowseFile);
        RefreshLayersCommand = new RelayCommand(RefreshLayers);
        ImportCommand = new RelayCommand(Import);
    }

    public event EventHandler<bool>? RequestClose;

    public ObservableCollection<string> LayerNames { get; }
    public ObservableCollection<PreviewRebarVm> PreviewRebars { get; }
    public ICommand BrowseFileCommand { get; }
    public ICommand RefreshLayersCommand { get; }
    public ICommand ImportCommand { get; }

    public DxfSectionImportResult? ImportResult { get; private set; }

    public string FilePath
    {
        get => filePath;
        set
        {
            Set(ref filePath, value);
            LoadLayers();
        }
    }

    public string SelectedBoundaryLayerName
    {
        get => selectedBoundaryLayerName;
        set
        {
            Set(ref selectedBoundaryLayerName, value);
            UpdateSummary();
        }
    }

    public string SelectedRebarLayerName
    {
        get => selectedRebarLayerName;
        set
        {
            Set(ref selectedRebarLayerName, value);
            UpdateSummary();
        }
    }

    public double ScaleFactor
    {
        get => scaleFactor;
        set
        {
            Set(ref scaleFactor, value);
            UpdateSummary();
        }
    }

    public bool OverrideRebarDiameter
    {
        get => overrideRebarDiameter;
        set
        {
            Set(ref overrideRebarDiameter, value);
            Raise(nameof(IsRebarDiameterInputEnabled));
            UpdateSummary();
        }
    }

    public double RebarDiameterMm
    {
        get => rebarDiameterMm;
        set
        {
            Set(ref rebarDiameterMm, value);
            UpdateSummary();
        }
    }

    public bool IsRebarDiameterInputEnabled => overrideRebarDiameter;

    public PointCollection PreviewBoundaryPoints { get => previewBoundaryPoints; private set => Set(ref previewBoundaryPoints, value); }
    public bool HasPreview { get => hasPreview; private set => Set(ref hasPreview, value); }

    public string SummaryText { get => summaryText; private set => Set(ref summaryText, value); }
    public string Message { get => message; private set { Set(ref message, value); Raise(nameof(HasMessage)); } }
    public bool HasMessage => !string.IsNullOrEmpty(message);
    public bool HasErrors { get => hasErrors; private set => Set(ref hasErrors, value); }

    private void BrowseFile()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "DXF Files (*.dxf)|*.dxf|All Files (*.*)|*.*",
            CheckFileExists = true
        };

        if (dialog.ShowDialog() == true)
        {
            FilePath = dialog.FileName;
        }
    }

    private void RefreshLayers() => LoadLayers();

    private void LoadLayers()
    {
        LayerNames.Clear();
        ImportResult = null;
        Message = "";
        HasErrors = false;
        ClearPreview();

        if (string.IsNullOrWhiteSpace(FilePath))
        {
            SummaryText = "Select a DXF file to load available layers.";
            return;
        }

        try
        {
            foreach (var layer in importService.GetLayerNames(FilePath))
            {
                LayerNames.Add(layer);
            }

            if (!LayerNames.Contains(SelectedBoundaryLayerName))
            {
                SelectedBoundaryLayerName = LayerNames.FirstOrDefault() ?? "";
            }

            if (!LayerNames.Contains(SelectedRebarLayerName))
            {
                SelectedRebarLayerName = LayerNames.Skip(1).FirstOrDefault() ?? "";
            }

            UpdateSummary();
        }
        catch (Exception ex)
        {
            HasErrors = true;
            Message = ex.Message;
            SummaryText = "Unable to read DXF layers.";
        }
    }

    private void UpdateSummary()
    {
        if (string.IsNullOrWhiteSpace(FilePath) ||
            string.IsNullOrWhiteSpace(SelectedBoundaryLayerName) ||
            string.IsNullOrWhiteSpace(SelectedRebarLayerName) ||
            ScaleFactor <= 0.0)
        {
            SummaryText = "Choose a file, boundary layer, rebar layer, and positive scale factor.";
            ClearPreview();
            return;
        }

        var result = importService.ImportSection(new DxfSectionImportRequest(
            FilePath,
            SelectedBoundaryLayerName,
            SelectedRebarLayerName,
            ScaleFactor,
            overrideRebarDiameter ? rebarDiameterMm : null));

        SummaryText =
            $"Boundary polylines found: {result.BoundaryPolylineCount}\n" +
            $"Boundary vertices found: {result.BoundaryVertexCount}\n" +
            $"Rebar circles found: {result.RebarCircleCount}";

        UpdatePreview(result);

        if (result.Errors.Count > 0)
        {
            HasErrors = true;
            Message = string.Join(Environment.NewLine, result.Errors);
        }
        else
        {
            HasErrors = false;
            Message = result.Warnings.Count == 0
                ? "Ready to import."
                : string.Join(Environment.NewLine, result.Warnings);
        }
    }

    private void Import()
    {
        var result = importService.ImportSection(new DxfSectionImportRequest(
            FilePath,
            SelectedBoundaryLayerName,
            SelectedRebarLayerName,
            ScaleFactor,
            overrideRebarDiameter ? rebarDiameterMm : null));

        ImportResult = result;
        if (!result.IsSuccess)
        {
            HasErrors = true;
            Message = string.Join(Environment.NewLine, result.Errors);
            UpdateSummary();
            return;
        }

        HasErrors = false;
        Message = result.Warnings.Count == 0
            ? "Import succeeded."
            : string.Join(Environment.NewLine, result.Warnings);
        RequestClose?.Invoke(this, true);
    }

    private void ClearPreview()
    {
        PreviewBoundaryPoints = [];
        PreviewRebars.Clear();
        HasPreview = false;
    }

    private void UpdatePreview(DxfSectionImportResult result)
    {
        PreviewRebars.Clear();

        bool hasBoundary = result.BoundaryVertices.Count > 0;
        bool hasRebars = result.Rebars.Count > 0;

        if (!hasBoundary && !hasRebars)
        {
            PreviewBoundaryPoints = [];
            HasPreview = false;
            return;
        }

        // Bounding box from whatever data is available
        var allX = new List<double>();
        var allY = new List<double>();
        if (hasBoundary)
        {
            allX.AddRange(result.BoundaryVertices.Select(p => p.X));
            allY.AddRange(result.BoundaryVertices.Select(p => p.Y));
        }
        if (hasRebars)
        {
            allX.AddRange(result.Rebars.Select(r => r.Center.X));
            allY.AddRange(result.Rebars.Select(r => r.Center.Y));
        }

        double minX = allX.Min(), maxX = allX.Max();
        double minY = allY.Min(), maxY = allY.Max();
        double usableW = PreviewCanvasW - 2 * PreviewPadding;
        double usableH = PreviewCanvasH - 2 * PreviewPadding;
        double scale = Math.Min(usableW / Math.Max(maxX - minX, 1e-9), usableH / Math.Max(maxY - minY, 1e-9));
        double originX = PreviewPadding + (usableW - (maxX - minX) * scale) / 2.0 - minX * scale;
        double originY = PreviewPadding + (usableH - (maxY - minY) * scale) / 2.0 + maxY * scale;

        if (hasBoundary)
        {
            var pts = new PointCollection(result.BoundaryVertices.Count);
            foreach (var pt in result.BoundaryVertices)
                pts.Add(new Point(originX + pt.X * scale, originY - pt.Y * scale));
            PreviewBoundaryPoints = pts;
        }
        else
        {
            PreviewBoundaryPoints = [];
        }

        if (hasRebars)
        {
            double rebarR = Math.Max(result.Rebars[0].Radius * scale, 3.0);
            foreach (var rebar in result.Rebars)
            {
                double cx = originX + rebar.Center.X * scale;
                double cy = originY - rebar.Center.Y * scale;
                PreviewRebars.Add(new PreviewRebarVm(cx - rebarR, cy - rebarR, rebarR * 2));
            }
        }

        HasPreview = true;
    }
}

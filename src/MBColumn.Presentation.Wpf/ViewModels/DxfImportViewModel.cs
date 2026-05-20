using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Presentation.Wpf.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class DxfImportViewModel : ViewModelBase
{
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

    public DxfImportViewModel(IDxfImportService importService)
    {
        this.importService = importService;
        LayerNames = [];
        BrowseFileCommand = new RelayCommand(BrowseFile);
        RefreshLayersCommand = new RelayCommand(RefreshLayers);
        ImportCommand = new RelayCommand(Import);
    }

    public event EventHandler<bool>? RequestClose;

    public ObservableCollection<string> LayerNames { get; }
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
}

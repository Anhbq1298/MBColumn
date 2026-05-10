using System.Windows.Input;
using MBColumn.Application.DTOs;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MM3DViewModel : ViewModelBase
{
    private bool showGrid = true;
    private bool showWireframe = true;
    private bool showSurface = true;
    private bool showLabels = true;
    private int resetVersion;
    public MM3DViewModel()
    {
        ToggleGridCommand = new RelayCommand(() => ShowGrid = !ShowGrid);
        ToggleWireframeCommand = new RelayCommand(() => ShowWireframe = !ShowWireframe);
        ToggleSurfaceCommand = new RelayCommand(() => ShowSurface = !ShowSurface);
        ResetCameraCommand = new RelayCommand(() => { ResetVersion++; ResetRequested?.Invoke(this, EventArgs.Empty); });
    }

    public event EventHandler? ResetRequested;
    public IReadOnlyList<ControlPointDto> MmSliceContours { get; private set; } = [];
    public IReadOnlyList<ControlPointDto> SurfaceMesh => MmSliceContours;
    public ControlPointDto? DemandPoint { get; private set; }
    public ControlPointDto? GoverningPoint { get; private set; }
    public double SelectedPuPlane { get; private set; }
    public string AxisLabels { get; private set; } = "Mx, My, P";
    public string UnitLabels { get; private set; } = "";
    public int ResetVersion { get => resetVersion; private set => Set(ref resetVersion, value); }
    public bool ShowGrid { get => showGrid; set => Set(ref showGrid, value); }
    public bool ShowWireframe { get => showWireframe; set => Set(ref showWireframe, value); }
    public bool ShowSurface { get => showSurface; set => Set(ref showSurface, value); }
    public bool ShowLabels { get => showLabels; set => Set(ref showLabels, value); }
    public ICommand ResetCameraCommand { get; }
    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleWireframeCommand { get; }
    public ICommand ToggleSurfaceCommand { get; }

    public void Load(CalculationResultDto? result)
    {
        UnitLabels = result?.MmSlice is null ? "" : $"{result.MmSlice.MomentUnit}, {result.MmSlice.ForceUnit}";
        SelectedPuPlane = result?.PuDisplay ?? 0;
        var points = result?.MmSlice.Points ?? [];
        MmSliceContours = points.Where(p => !p.IsDemand && !p.IsGoverning).ToList();
        DemandPoint = points.FirstOrDefault(p => p.IsDemand);
        GoverningPoint = points.FirstOrDefault(p => p.IsGoverning);
        Raise(nameof(MmSliceContours)); Raise(nameof(SurfaceMesh)); Raise(nameof(DemandPoint)); Raise(nameof(GoverningPoint)); Raise(nameof(UnitLabels)); Raise(nameof(SelectedPuPlane));
    }
}


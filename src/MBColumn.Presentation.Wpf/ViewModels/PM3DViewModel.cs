using System.Windows.Input;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class PM3DViewModel : ViewModelBase
{
    private bool showGrid = true;
    private bool showWireframe = true;
    private bool showSurface = true;
    private bool showLabels = true;
    private bool showSlicePlane = true;
    private bool showAxialLoadSlice = true;
    private int resetVersion;
    private double selectedPmAngle;
    private double selectedAxialLoad;
    private string forceUnit = "";

    public PM3DViewModel()
    {
        ToggleGridCommand = new RelayCommand(() => ShowGrid = !ShowGrid);
        ToggleWireframeCommand = new RelayCommand(() => ShowWireframe = !ShowWireframe);
        ToggleSurfaceCommand = new RelayCommand(() => ShowSurface = !ShowSurface);
        ToggleSlicePlaneCommand = new RelayCommand(() => ShowSlicePlane = !ShowSlicePlane);
        ToggleAxialLoadSliceCommand = new RelayCommand(() => ShowAxialLoadSlice = !ShowAxialLoadSlice);
        UpdatePmAngleSliceCommand = new RelayCommand(() => RaiseSliceLabels());
        UpdateAxialLoadSliceCommand = new RelayCommand(() => RaiseSliceLabels());
        ResetCameraCommand = new RelayCommand(() => { ResetVersion++; ResetRequested?.Invoke(this, EventArgs.Empty); });
    }

    public event EventHandler? ResetRequested;
    public IReadOnlyList<ControlPointDto> SurfacePoints { get; private set; } = [];
    public IReadOnlyList<ControlPointDto> SpecialCapacityPoints { get; private set; } = [];
    public IReadOnlyList<ControlPointDto> SurfaceMesh => SurfacePoints;
    public IReadOnlyList<ControlPointDto> WireframeLines => SurfacePoints;
    public ControlPointDto? DemandPoint { get; private set; }
    private IReadOnlyList<ControlPointDto> demandPoints = [];
    public IReadOnlyList<ControlPointDto> DemandPoints
    {
        get => demandPoints;
        set
        {
            Set(ref demandPoints, value);
            DemandPoint = demandPoints.FirstOrDefault();
            Raise(nameof(DemandPoint));
        }
    }
    public IReadOnlyList<ControlPointDto> CapacityIntersectionPoints { get; private set; } = [];
    public ControlPointDto? GoverningPoint { get; private set; }
    public string AxisLabels { get; private set; } = "Mx, My, P";
    public string UnitLabels { get; private set; } = "";
    public double SelectedPmAngle { get => selectedPmAngle; set { Set(ref selectedPmAngle, value); RaiseSliceLabels(); } }
    public double SelectedPmAngleDegrees { get => SelectedPmAngle; set => SelectedPmAngle = value; }
    public double SelectedAxialLoad { get => selectedAxialLoad; set { Set(ref selectedAxialLoad, value); RaiseSliceLabels(); } }
    public string SelectedPmAngleLabel => $"PM at \u03b8 = {SelectedPmAngle:F1}\u00b0";
    public string SelectedAxialLoadLabel => $"Mx-My at P = {SelectedAxialLoad:F1} {forceUnit}";
    public int ResetVersion { get => resetVersion; private set => Set(ref resetVersion, value); }
    public bool ShowGrid { get => showGrid; set => Set(ref showGrid, value); }
    public bool ShowWireframe { get => showWireframe; set => Set(ref showWireframe, value); }
    public bool ShowSurface { get => showSurface; set => Set(ref showSurface, value); }
    public bool ShowLabels { get => showLabels; set => Set(ref showLabels, value); }
    public bool ShowSlicePlane { get => showSlicePlane; set => Set(ref showSlicePlane, value); }
    public bool ShowPmAngleSlice { get => ShowSlicePlane; set => ShowSlicePlane = value; }
    public bool ShowAxialLoadSlice { get => showAxialLoadSlice; set => Set(ref showAxialLoadSlice, value); }
    public ICommand ResetCameraCommand { get; }
    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleWireframeCommand { get; }
    public ICommand ToggleSurfaceCommand { get; }
    public ICommand ToggleSlicePlaneCommand { get; }
    public ICommand ToggleAxialLoadSliceCommand { get; }
    public ICommand UpdatePmAngleSliceCommand { get; }
    public ICommand UpdateAxialLoadSliceCommand { get; }

    public void Load(CalculationResultDto? result)
    {
        UnitLabels = result?.PmmSurface is null ? "" : $"{result.PmmSurface.MomentUnit}, {result.PmmSurface.ForceUnit}";
        forceUnit = result?.PmmSurface.ForceUnit ?? "";
        var points = result?.PmmSurface.Points ?? [];
        SurfacePoints = points.Where(p => !p.IsDemand && !p.IsGoverning).ToList();
        SpecialCapacityPoints = result?.PmmSurface.SpecialCapacityPoints ?? [];
        DemandPoints = points.Where(p => p.IsDemand).ToList();
        
        if (result?.LoadCaseResults != null)
        {
            CapacityIntersectionPoints = result.LoadCaseResults
                .Select((lc, i) => new ControlPointDto(
                    DiagramType.Pm3D,
                    lc.CapacityMxDisplay, lc.CapacityMyDisplay, lc.CapacityPDisplay,
                    lc.CapacityPDisplay, lc.CapacityMxDisplay, lc.CapacityMyDisplay,
                    lc.Phi, lc.GoverningThetaDegrees, lc.GoverningNeutralAxisDepth,
                    lc.LoadCaseName + " Capacity", "CapacityIntersection", false, false, false, false, i, lc.LoadCaseId))
                .ToList();
        }
        else
        {
            CapacityIntersectionPoints = [];
        }

        GoverningPoint = null;
        SelectedPmAngle = result?.GoverningThetaDegrees ?? 0;
        SelectedAxialLoad = result?.PuDisplay ?? 0;
        Raise(nameof(SurfacePoints)); Raise(nameof(SurfaceMesh)); Raise(nameof(WireframeLines));
        Raise(nameof(SpecialCapacityPoints));
        Raise(nameof(DemandPoints)); Raise(nameof(DemandPoint)); Raise(nameof(GoverningPoint)); Raise(nameof(UnitLabels));
        Raise(nameof(CapacityIntersectionPoints));
        RaiseSliceLabels();
    }

    private void RaiseSliceLabels()
    {
        Raise(nameof(SelectedPmAngleLabel));
        Raise(nameof(SelectedAxialLoadLabel));
        Raise(nameof(SelectedPmAngleDegrees));
    }
}


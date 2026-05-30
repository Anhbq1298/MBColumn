using System.Windows.Input;
using MBColumn.Application.DTOs;
using MBColumn.Infrastructure.Reports.Graphics;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class PMDiagramViewModel : ViewModelBase
{
    private bool showGrid = true;
    private bool showLabels = true;
    private int resetVersion;
    public PMDiagramViewModel()
    {
        ToggleGridCommand = new RelayCommand(() => ShowGrid = !ShowGrid);
        ToggleLabelsCommand = new RelayCommand(() => ShowLabels = !ShowLabels);
        ResetViewCommand = new RelayCommand(() => { ResetVersion++; ResetRequested?.Invoke(this, EventArgs.Empty); });
    }

    public event EventHandler? ResetRequested;
    public string DiagramTitle { get; private set; } = "PM Diagram";
    public string XAxisLabel { get; private set; } = "M";
    public string YAxisLabel { get; private set; } = "P";
    public IReadOnlyList<ControlPointDto> CapacityPoints { get; private set; } = [];
    public ControlPointDto? DemandPoint { get; private set; }
    public ControlPointDto? GoverningPoint { get; private set; }
    public IReadOnlyList<ControlPointDto> ReferenceLines { get; private set; } = [];
    public double SelectedAngle { get; private set; }
    public string UnitLabels { get; private set; } = "";
    public double Ratio { get; private set; }
    public string DiagramSvg { get; private set; } = "";
    public int ResetVersion { get => resetVersion; private set => Set(ref resetVersion, value); }
    public bool ShowGrid { get => showGrid; set => Set(ref showGrid, value); }
    public bool ShowLabels { get => showLabels; set => Set(ref showLabels, value); }
    public ICommand ResetViewCommand { get; }
    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleLabelsCommand { get; }

    public void LoadPmAngle(PmAngleDiagramDto? diagram, double ratio)
    {
        DiagramTitle = diagram is null ? "PM Diagram" : $"PM at \u03b8 = {diagram.AngleDegrees:F1}\u00b0";
        XAxisLabel = diagram is null ? "M\u03b8" : $"M\u03b8 ({diagram.MUnit})";
        YAxisLabel = diagram is null ? "P" : $"P ({diagram.PUnit})";
        UnitLabels = diagram is null ? "" : $"{diagram.PUnit}, {diagram.MUnit}";
        Ratio = ratio;
        SelectedAngle = diagram?.AngleDegrees ?? 0;
        var points = diagram?.Points ?? [];
        CapacityPoints = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        DemandPoint = points.FirstOrDefault(p => p.IsDemand);
        GoverningPoint = points.FirstOrDefault(p => p.IsGoverning);
        ReferenceLines = points.Where(p => p.IsReference).ToList();
        RaiseAll();
    }

    private void RaiseAll()
    {
        var allPoints = CapacityPoints
            .Concat(ReferenceLines)
            .Concat(DemandPoint is not null ? [DemandPoint] : Array.Empty<ControlPointDto>())
            .Concat(GoverningPoint is not null ? [GoverningPoint] : Array.Empty<ControlPointDto>())
            .ToList();
        DiagramSvg = allPoints.Count > 0
            ? InteractionDiagramSvgRenderer.RenderPmDiagram(allPoints, XAxisLabel, YAxisLabel, Ratio)
            : "";
        Raise(nameof(DiagramTitle)); Raise(nameof(XAxisLabel)); Raise(nameof(YAxisLabel)); Raise(nameof(UnitLabels)); Raise(nameof(CapacityPoints));
        Raise(nameof(DemandPoint)); Raise(nameof(GoverningPoint)); Raise(nameof(ReferenceLines)); Raise(nameof(SelectedAngle)); Raise(nameof(Ratio));
        Raise(nameof(DiagramSvg));
    }
}


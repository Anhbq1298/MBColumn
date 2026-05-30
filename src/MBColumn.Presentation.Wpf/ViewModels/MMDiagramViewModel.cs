using System.Windows.Input;
using MBColumn.Application.DTOs;
using MBColumn.Infrastructure.Reports.Graphics;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MMDiagramViewModel : ViewModelBase
{
    private bool showGrid = true;
    private bool showLabels = true;
    private int resetVersion;
    public MMDiagramViewModel()
    {
        ToggleGridCommand = new RelayCommand(() => ShowGrid = !ShowGrid);
        ToggleLabelsCommand = new RelayCommand(() => ShowLabels = !ShowLabels);
        ResetViewCommand = new RelayCommand(() => { ResetVersion++; ResetRequested?.Invoke(this, EventArgs.Empty); });
    }

    public event EventHandler? ResetRequested;
    public string DiagramTitle => "Mx-My Diagram";
    public string XAxisLabel { get; private set; } = "Mx";
    public string YAxisLabel { get; private set; } = "My";
    public IReadOnlyList<ControlPointDto> BoundaryPoints { get; private set; } = [];
    public ControlPointDto? DemandPoint { get; private set; }
    public ControlPointDto? GoverningPoint { get; private set; }
    public double SelectedPu { get; private set; }
    public string UnitLabels { get; private set; } = "";
    public double Ratio { get; private set; }
    public string DiagramSvg { get; private set; } = "";
    public int ResetVersion { get => resetVersion; private set => Set(ref resetVersion, value); }
    public bool ShowGrid { get => showGrid; set => Set(ref showGrid, value); }
    public bool ShowLabels { get => showLabels; set => Set(ref showLabels, value); }
    public ICommand ResetViewCommand { get; }
    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleLabelsCommand { get; }

    public void Load(CalculationResultDto? result)
    {
        var diagram = result?.MxMyDiagram;
        Load(diagram, result?.Ratio ?? 0);
    }

    public void Load(MxMyDiagramDto? diagram, double ratio)
    {
        XAxisLabel = diagram is null ? "Mx" : $"Mx ({diagram.MUnit})";
        YAxisLabel = diagram is null ? "My" : $"My ({diagram.MUnit})";
        UnitLabels = diagram?.MUnit ?? "";
        SelectedPu = diagram?.SelectedP ?? 0;
        Ratio = ratio;
        var points = diagram?.Points ?? [];
        BoundaryPoints = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        DemandPoint = points.FirstOrDefault(p => p.IsDemand);
        GoverningPoint = points.FirstOrDefault(p => p.IsGoverning);
        RaiseAll();
    }

    private void RaiseAll()
    {
        var allPoints = BoundaryPoints
            .Concat(DemandPoint is not null ? [DemandPoint] : Array.Empty<ControlPointDto>())
            .Concat(GoverningPoint is not null ? [GoverningPoint] : Array.Empty<ControlPointDto>())
            .ToList();
        DiagramSvg = allPoints.Count > 0
            ? InteractionDiagramSvgRenderer.RenderMmDiagram(allPoints, XAxisLabel, YAxisLabel, Ratio)
            : "";
        Raise(nameof(XAxisLabel)); Raise(nameof(YAxisLabel)); Raise(nameof(UnitLabels)); Raise(nameof(BoundaryPoints));
        Raise(nameof(DemandPoint)); Raise(nameof(GoverningPoint)); Raise(nameof(SelectedPu)); Raise(nameof(Ratio));
        Raise(nameof(DiagramSvg));
    }
}


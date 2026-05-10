using System.Windows.Input;
using MBColumn.Application.DTOs;
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
    public string DiagramTitle { get; private set; } = "PMx Diagram";
    public string XAxisLabel { get; private set; } = "M";
    public string YAxisLabel { get; private set; } = "P";
    public IReadOnlyList<ControlPointDto> CapacityPoints { get; private set; } = [];
    public ControlPointDto? DemandPoint { get; private set; }
    public ControlPointDto? GoverningPoint { get; private set; }
    public IReadOnlyList<ControlPointDto> ReferenceLines { get; private set; } = [];
    public double SelectedAngle { get; private set; }
    public string UnitLabels { get; private set; } = "";
    public double Ratio { get; private set; }
    public int ResetVersion { get => resetVersion; private set => Set(ref resetVersion, value); }
    public bool ShowGrid { get => showGrid; set => Set(ref showGrid, value); }
    public bool ShowLabels { get => showLabels; set => Set(ref showLabels, value); }
    public ICommand ResetViewCommand { get; }
    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleLabelsCommand { get; }

    public void Load(CalculationResultDto? result)
        => LoadPmX(result);

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

    public void LoadPmX(CalculationResultDto? result)
    {
        DiagramTitle = "PMx Diagram";
        var diagram = result?.PmXDiagram;
        XAxisLabel = diagram is null ? "Mx" : $"Mx ({diagram.MUnit})";
        YAxisLabel = diagram is null ? "P" : $"P ({diagram.PUnit})";
        UnitLabels = diagram is null ? "" : $"{diagram.PUnit}, {diagram.MUnit}";
        Ratio = result?.Ratio ?? 0;
        SelectedAngle = result?.GoverningThetaDegrees ?? 0;
        var points = diagram?.Points ?? [];
        CapacityPoints = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        DemandPoint = points.FirstOrDefault(p => p.IsDemand);
        GoverningPoint = points.FirstOrDefault(p => p.IsGoverning);
        ReferenceLines = points.Where(p => p.IsReference).ToList();
        RaiseAll();
    }

    public void LoadPmY(CalculationResultDto? result)
    {
        DiagramTitle = "PMy Diagram";
        var diagram = result?.PmYDiagram;
        XAxisLabel = diagram is null ? "My" : $"My ({diagram.MUnit})";
        YAxisLabel = diagram is null ? "P" : $"P ({diagram.PUnit})";
        UnitLabels = diagram is null ? "" : $"{diagram.PUnit}, {diagram.MUnit}";
        Ratio = result?.Ratio ?? 0;
        SelectedAngle = result?.GoverningThetaDegrees ?? 0;
        var points = diagram?.Points ?? [];
        CapacityPoints = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        DemandPoint = points.FirstOrDefault(p => p.IsDemand);
        GoverningPoint = points.FirstOrDefault(p => p.IsGoverning);
        ReferenceLines = points.Where(p => p.IsReference).ToList();
        RaiseAll();
    }

    public void OverrideTitleAndXAxis(string title, string xAxisLabel)
    {
        DiagramTitle = title;
        XAxisLabel = xAxisLabel;
        Raise(nameof(DiagramTitle));
        Raise(nameof(XAxisLabel));
    }

    private void RaiseAll()
    {
        Raise(nameof(DiagramTitle)); Raise(nameof(XAxisLabel)); Raise(nameof(YAxisLabel)); Raise(nameof(UnitLabels)); Raise(nameof(CapacityPoints));
        Raise(nameof(DemandPoint)); Raise(nameof(GoverningPoint)); Raise(nameof(ReferenceLines)); Raise(nameof(SelectedAngle)); Raise(nameof(Ratio));
    }
}


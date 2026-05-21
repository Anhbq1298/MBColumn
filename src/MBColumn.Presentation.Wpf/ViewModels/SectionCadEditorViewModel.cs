using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class SectionCadEditorViewModel : ViewModelBase
{
    private readonly InputViewModel source;
    private CadToolMode toolMode;
    private string statusText = "Select or drag points. Apply writes changes back to the coordinate tables.";

    public SectionCadEditorViewModel(InputViewModel source)
    {
        this.source = source;
        source.UpdateSectionPreview();

        foreach (var p in source.IrregularInput.BoundaryPoints)
            BoundaryPoints.Add(new CadPointViewModel(p.X, p.Y));

        if (BoundaryPoints.Count < 3)
        {
            foreach (var p in source.PreviewBoundaryPoints)
                BoundaryPoints.Add(new CadPointViewModel(p.X, p.Y));
        }

        foreach (var r in source.IrregularInput.Rebars)
            Rebars.Add(new CadRebarViewModel(r.X, r.Y, string.IsNullOrWhiteSpace(r.BarSize) ? source.BarSize : r.BarSize, r.AreaMm2));

        if (Rebars.Count == 0)
        {
            var area = CurrentBarArea();
            foreach (var r in source.PreviewRebars)
                Rebars.Add(new CadRebarViewModel(r.X, r.Y, source.BarSize, area));
        }

        SelectCommand = new RelayCommand(() => ToolMode = CadToolMode.Select);
        AddBoundaryPointCommand = new RelayCommand(() => ToolMode = CadToolMode.AddBoundaryPoint);
        AddRebarCommand = new RelayCommand(() => ToolMode = CadToolMode.AddRebar);
        DeleteCommand = new RelayCommand(() => ToolMode = CadToolMode.Delete);
        RectangleCommand = new RelayCommand(UseRectangleTemplate);
        CircleCommand = new RelayCommand(UseCircleTemplate);
        LShapeCommand = new RelayCommand(UseLShapeTemplate);
        PerimeterRebarsCommand = new RelayCommand(GeneratePerimeterRebars);
        ClearRebarsCommand = new RelayCommand(() => { Rebars.Clear(); StatusText = "Rebars cleared."; });
    }

    public ObservableCollection<CadPointViewModel> BoundaryPoints { get; } = [];
    public ObservableCollection<CadRebarViewModel> Rebars { get; } = [];

    public CadToolMode ToolMode
    {
        get => toolMode;
        set
        {
            if (toolMode == value) return;
            toolMode = value;
            Raise();
            StatusText = value switch
            {
                CadToolMode.AddBoundaryPoint => "Click canvas to append boundary points.",
                CadToolMode.AddRebar => "Click canvas to place rebars.",
                CadToolMode.Delete => "Click a boundary point or rebar to delete it.",
                _ => "Select or drag points."
            };
        }
    }

    public string StatusText { get => statusText; set => Set(ref statusText, value); }
    public string UnitLabel => source.LengthLabel;
    public ICommand SelectCommand { get; }
    public ICommand AddBoundaryPointCommand { get; }
    public ICommand AddRebarCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand RectangleCommand { get; }
    public ICommand CircleCommand { get; }
    public ICommand LShapeCommand { get; }
    public ICommand PerimeterRebarsCommand { get; }
    public ICommand ClearRebarsCommand { get; }

    public void AddBoundaryPoint(double x, double y)
    {
        BoundaryPoints.Add(new CadPointViewModel(Round(x), Round(y)));
        StatusText = $"Boundary point {BoundaryPoints.Count} added.";
    }

    public void AddRebar(double x, double y)
    {
        Rebars.Add(new CadRebarViewModel(Round(x), Round(y), source.BarSize, CurrentBarArea()));
        StatusText = $"Rebar {Rebars.Count} added.";
    }

    public string? Validate()
    {
        if (BoundaryPoints.Count < 3)
            return "Boundary needs at least 3 points.";
        if (Math.Abs(SignedArea(BoundaryPoints)) < 1e-6)
            return "Boundary area is zero. Check point order and coordinates.";
        return null;
    }

    public void ApplyToSource()
    {
        var validation = Validate();
        if (validation is not null)
            throw new InvalidOperationException(validation);

        source.SelectedSectionShape = SectionShapeType.Irregular;
        source.SelectedRebarLayoutType = RebarLayoutType.CustomCoordinates;
        source.IrregularInput.RebarMode = IrregularRebarModeType.CustomCoordinates;
        source.IrregularInput.IsCustomCoordinatesOverride = true;

        source.IrregularInput.BoundaryPoints.Clear();
        for (var i = 0; i < BoundaryPoints.Count; i++)
        {
            var p = BoundaryPoints[i];
            source.IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel
            {
                PtIndex = i + 1,
                X = Round(p.X),
                Y = Round(p.Y)
            });
        }

        source.IrregularInput.Rebars.Clear();
        for (var i = 0; i < Rebars.Count; i++)
        {
            var r = Rebars[i];
            source.IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
            {
                RebarIndex = (i + 1).ToString(),
                X = Round(r.X),
                Y = Round(r.Y),
                BarSize = string.IsNullOrWhiteSpace(r.BarSize) ? source.BarSize : r.BarSize,
                AreaMm2 = r.AreaMm2 ?? CurrentBarArea()
            });
        }

        source.UpdateSectionPreview();
    }

    private void UseRectangleTemplate()
    {
        var w = source.SectionWidth > 0 ? source.SectionWidth : 700;
        var h = source.SectionHeight > 0 ? source.SectionHeight : w;
        BoundaryPoints.Clear();
        BoundaryPoints.Add(new(-w / 2, h / 2));
        BoundaryPoints.Add(new(w / 2, h / 2));
        BoundaryPoints.Add(new(w / 2, -h / 2));
        BoundaryPoints.Add(new(-w / 2, -h / 2));
        StatusText = "Rectangle boundary template applied.";
    }

    private void UseCircleTemplate()
    {
        var diameter = source.IsCircularSection && source.Diameter > 0 ? source.Diameter : Math.Max(source.SectionWidth, source.SectionHeight);
        if (diameter <= 0) diameter = 700;
        var r = diameter / 2;
        BoundaryPoints.Clear();
        const int count = 32;
        for (var i = 0; i < count; i++)
        {
            var angle = Math.PI / 2.0 - 2.0 * Math.PI * i / count;
            BoundaryPoints.Add(new(Round(r * Math.Cos(angle)), Round(r * Math.Sin(angle))));
        }
        StatusText = "Circular boundary template applied.";
    }

    private void UseLShapeTemplate()
    {
        var scale = source.UnitSystem == UnitSystem.Metric ? 1.0 : 1.0 / 25.4;
        var points = new[]
        {
            (-340.0 * scale, 340.0 * scale),
            (-340.0 * scale, -660.0 * scale),
            (-90.0 * scale, -660.0 * scale),
            (-90.0 * scale, 90.0 * scale),
            (660.0 * scale, 90.0 * scale),
            (660.0 * scale, 340.0 * scale)
        };

        BoundaryPoints.Clear();
        foreach (var (x, y) in points)
            BoundaryPoints.Add(new(Round(x), Round(y)));
        StatusText = "L-shape boundary template applied.";
    }

    private void GeneratePerimeterRebars()
    {
        Rebars.Clear();
        if (BoundaryPoints.Count < 2) return;

        var spacing = source.Spacing > 0 ? source.Spacing : source.IrregularInput.Spacing > 0 ? source.IrregularInput.Spacing : 150.0;
        var area = CurrentBarArea();
        for (var i = 0; i < BoundaryPoints.Count; i++)
        {
            var a = BoundaryPoints[i];
            var b = BoundaryPoints[(i + 1) % BoundaryPoints.Count];
            var dx = b.X - a.X;
            var dy = b.Y - a.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);
            var segments = Math.Max(1, (int)Math.Round(length / spacing));
            for (var j = 0; j < segments; j++)
            {
                var t = j / (double)segments;
                Rebars.Add(new CadRebarViewModel(Round(a.X + dx * t), Round(a.Y + dy * t), source.BarSize, area));
            }
        }
        StatusText = $"{Rebars.Count} perimeter rebars generated.";
    }

    private double? CurrentBarArea()
        => source.AvailableBars.FirstOrDefault(b => string.Equals(b.Name, source.BarSize, StringComparison.OrdinalIgnoreCase))?.AreaMm2;

    private static double Round(double value) => Math.Round(value, 3);

    private static double SignedArea(IEnumerable<CadPointViewModel> points)
    {
        var list = points.ToList();
        var area = 0.0;
        for (var i = 0; i < list.Count; i++)
        {
            var a = list[i];
            var b = list[(i + 1) % list.Count];
            area += a.X * b.Y - b.X * a.Y;
        }
        return area / 2.0;
    }
}

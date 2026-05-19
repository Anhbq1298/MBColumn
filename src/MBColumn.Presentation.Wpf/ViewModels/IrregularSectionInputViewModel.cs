using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class IrregularSectionInputViewModel : ViewModelBase
{
    private readonly IIrregularSectionCsvService csv;
    private IrregularRebarModeType rebarMode = IrregularRebarModeType.EqualSpacing;
    private string boundaryValidationMessage = "";
    private string rebarValidationMessage = "";
    private string barSize = "T25";
    private double spacing = 150.0;

    public IrregularSectionInputViewModel(IIrregularSectionCsvService csv)
    {
        this.csv = csv;
        BoundaryPoints = new ObservableCollection<IrregularBoundaryPointViewModel>();
        Rebars = new ObservableCollection<IrregularRebarRowViewModel>();
        ClearBoundaryCommand = new RelayCommand(() => BoundaryPoints.Clear());
        ClearRebarsCommand = new RelayCommand(() => Rebars.Clear());
        ReverseBoundaryCommand = new RelayCommand(ReverseBoundary);
        AddBoundaryRowCommand = new RelayCommand(AddBoundaryRow);
        DeleteBoundaryRowsCommand = new RelayCommand<object>(DeleteBoundaryRows);
        AddRebarRowCommand = new RelayCommand(AddRebarRow);
        DeleteRebarRowsCommand = new RelayCommand<object>(DeleteRebarRows);

        LoadDefaultLShape();
    }

    public void LoadDefaultLShape()
    {
        BoundaryPoints.Clear();
        Rebars.Clear();

        var points = new[]
        {
            (-339.2857, 339.2857),
            (-339.2857, -660.7143),
            (-89.28571, -660.7143),
            (-89.28571,  89.28571),
            ( 660.7143,  89.28571),
            ( 660.7143, 339.2857)
        };

        for (int i = 0; i < points.Length; i++)
        {
            BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = i + 1, X = points[i].Item1, Y = points[i].Item2 });
        }

        var rebars = new[]
        {
            (-284.2857, -605.7143),
            (-144.2857, -605.7143),
            ( 605.7143,  284.2857),
            ( 605.7143,  144.2857),
            (-144.2857,  144.2857),
            (-284.2857,  284.2857),
            (-106.2857,  284.2857),
            (  71.71429, 284.2857),
            ( 249.7143,  284.2857),
            ( 427.7143,  284.2857),
            (  43.21429, 144.2857),
            ( 230.7143,  144.2857),
            ( 418.2143,  144.2857),
            (-144.2857, -418.2143),
            (-144.2857, -230.7143),
            (-144.2857,  -43.21429),
            (-284.2857,  106.2857),
            (-284.2857,  -71.71429),
            (-284.2857, -249.7143),
            (-284.2857, -427.7143)
        };

        for (int i = 0; i < rebars.Length; i++)
        {
            Rebars.Add(new IrregularRebarRowViewModel
            {
                RebarIndex = (i + 1).ToString(),
                X = rebars[i].Item1,
                Y = rebars[i].Item2,
                AreaMm2 = 314.1593,
                BarSize = "T20"
            });
        }
    }

    public ObservableCollection<IrregularBoundaryPointViewModel> BoundaryPoints { get; }
    public ObservableCollection<IrregularRebarRowViewModel> Rebars { get; }

    public IrregularRebarModeType RebarMode
    {
        get => rebarMode;
        set
        {
            if (System.Collections.Generic.EqualityComparer<IrregularRebarModeType>.Default.Equals(rebarMode, value)) return;
            rebarMode = value;
            Raise();
            Raise(nameof(IsEqualSpacing));
            Raise(nameof(IsCustomCoordinates));
            Raise(nameof(IsAlgorithmicCoordinates));
        }
    }

    public string BoundaryValidationMessage
    {
        get => boundaryValidationMessage;
        set => Set(ref boundaryValidationMessage, value);
    }

    public string RebarValidationMessage
    {
        get => rebarValidationMessage;
        set => Set(ref rebarValidationMessage, value);
    }

    public string BarSize
    {
        get => barSize;
        set => Set(ref barSize, value);
    }

    public double Spacing
    {
        get => spacing;
        set => Set(ref spacing, value);
    }

    private bool isCustomCoordinatesOverride = false;
    public bool IsCustomCoordinatesOverride
    {
        get => isCustomCoordinatesOverride;
        set
        {
            if (isCustomCoordinatesOverride == value) return;
            isCustomCoordinatesOverride = value;
            Raise();
            Raise(nameof(IsCustomCoordinates));
            Raise(nameof(IsAlgorithmicCoordinates));
        }
    }

    public bool IsEqualSpacing => RebarMode == IrregularRebarModeType.EqualSpacing;
    public bool IsCustomCoordinates => IsCustomCoordinatesOverride || (RebarMode == IrregularRebarModeType.CustomCoordinates);
    public bool IsAlgorithmicCoordinates => !IsCustomCoordinates;

    public ICommand ClearBoundaryCommand { get; }
    public ICommand ClearRebarsCommand { get; }
    public ICommand ReverseBoundaryCommand { get; }
    public ICommand AddBoundaryRowCommand { get; }
    public ICommand DeleteBoundaryRowsCommand { get; }
    public ICommand AddRebarRowCommand { get; }
    public ICommand DeleteRebarRowsCommand { get; }

    public void ImportBoundaryFile(string filePath)
    {
        var rows = csv.ImportBoundary(filePath);
        BoundaryPoints.Clear();
        foreach (var r in rows)
        {
            BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = r.PtIndex, X = r.X, Y = r.Y });
        }
    }

    public void ImportRebarFile(string filePath)
    {
        var rows = csv.ImportRebars(filePath);
        Rebars.Clear();
        foreach (var r in rows)
        {
            Rebars.Add(new IrregularRebarRowViewModel
            {
                RebarIndex = r.RebarIndex,
                X = r.X,
                Y = r.Y,
                BarSize = r.BarSize ?? "",
                AreaMm2 = r.AreaMm2
            });
        }
    }

    public void ExportBoundaryFile(string filePath)
        => csv.ExportBoundary(filePath, BoundaryPoints
            .Select(b => new IrregularBoundaryPointCsvDto(b.PtIndex, b.X, b.Y))
            .ToList());

    public void ExportRebarFile(string filePath)
        => csv.ExportRebars(filePath, Rebars
            .Select(r => new IrregularRebarCsvDto(
                r.RebarIndex,
                r.X,
                r.Y,
                string.IsNullOrWhiteSpace(r.BarSize) ? null : r.BarSize,
                r.AreaMm2))
            .ToList());

    public IrregularSectionInputDto ToDto(double coverMm)
        => new(
            BoundaryPoints
                .Select(b => new IrregularBoundaryPointDto(b.PtIndex, b.X, b.Y))
                .ToList(),
            Rebars
                .Select(r => new IrregularRebarInputDto(
                    r.RebarIndex,
                    r.X,
                    r.Y,
                    string.IsNullOrWhiteSpace(r.BarSize) ? null : r.BarSize,
                    r.AreaMm2))
                .ToList(),
            coverMm,
            RebarMode);

    private void ReverseBoundary()
    {
        var copy = BoundaryPoints.ToList();
        copy.Reverse();
        BoundaryPoints.Clear();
        for (int i = 0; i < copy.Count; i++)
        {
            var p = copy[i];
            p.PtIndex = i + 1;
            BoundaryPoints.Add(p);
        }
    }

    private void AddBoundaryRow()
    {
        var last = BoundaryPoints.LastOrDefault();
        var previous = BoundaryPoints.Count >= 2 ? BoundaryPoints[^2] : null;
        double step = Spacing > 0 ? Spacing : 100.0;
        BoundaryPoints.Add(new IrregularBoundaryPointViewModel
        {
            PtIndex = BoundaryPoints.Count + 1,
            X = last is null ? 0.0 : previous is null ? last.X + step : last.X + (last.X - previous.X),
            Y = last is null ? 0.0 : previous is null ? last.Y : last.Y + (last.Y - previous.Y)
        });
    }

    private void DeleteBoundaryRows(object selectedItems)
    {
        var selected = GetSelectedRows<IrregularBoundaryPointViewModel>(selectedItems);
        if (selected.Count == 0 && BoundaryPoints.Count > 0)
        {
            selected.Add(BoundaryPoints[^1]);
        }

        foreach (var row in selected)
        {
            BoundaryPoints.Remove(row);
        }

        ReindexBoundaryPoints();
    }

    private void AddRebarRow()
    {
        var last = Rebars.LastOrDefault();
        var previous = Rebars.Count >= 2 ? Rebars[^2] : null;
        double step = Spacing > 0 ? Spacing : 100.0;
        Rebars.Add(new IrregularRebarRowViewModel
        {
            RebarIndex = (Rebars.Count + 1).ToString(),
            X = last is null ? 0.0 : previous is null ? last.X + step : last.X + (last.X - previous.X),
            Y = last is null ? 0.0 : previous is null ? last.Y : last.Y + (last.Y - previous.Y),
            BarSize = last?.BarSize ?? BarSize,
            AreaMm2 = last?.AreaMm2
        });
    }

    private void DeleteRebarRows(object selectedItems)
    {
        var selected = GetSelectedRows<IrregularRebarRowViewModel>(selectedItems);
        if (selected.Count == 0 && Rebars.Count > 0)
        {
            selected.Add(Rebars[^1]);
        }

        foreach (var row in selected)
        {
            Rebars.Remove(row);
        }

        ReindexRebars();
    }

    private static List<T> GetSelectedRows<T>(object selectedItems)
        where T : class
    {
        if (selectedItems is IList list)
        {
            return list.OfType<T>().ToList();
        }

        return selectedItems is T row ? [row] : [];
    }

    private void ReindexBoundaryPoints()
    {
        for (int i = 0; i < BoundaryPoints.Count; i++)
        {
            BoundaryPoints[i].PtIndex = i + 1;
        }
    }

    private void ReindexRebars()
    {
        for (int i = 0; i < Rebars.Count; i++)
        {
            Rebars[i].RebarIndex = (i + 1).ToString();
        }
    }

    public System.Collections.Generic.IReadOnlyList<IrregularRebarModeOption> RebarModeOptions { get; } =
    [
        new(IrregularRebarModeType.EqualSpacing, "Equal Spacing"),
        new(IrregularRebarModeType.CustomCoordinates, "Custom Coordinates")
    ];
}

public sealed record IrregularRebarModeOption(IrregularRebarModeType Type, string DisplayName);

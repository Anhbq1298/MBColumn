using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class IrregularSectionInputViewModel : ViewModelBase
{
    private readonly IIrregularSectionCsvService csv;
    private IrregularRebarModeType rebarMode = IrregularRebarModeType.CustomCoordinates;
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

        LoadDefaultUShape();
    }

    private void LoadDefaultUShape()
    {
        // 600x600 U-Shape, 200mm thick
        var points = new[]
        {
            (-300.0, -300.0), (-300.0, 300.0), (-100.0, 300.0), (-100.0, -100.0),
            (100.0, -100.0), (100.0, 300.0), (300.0, 300.0), (300.0, -300.0)
        };

        for (int i = 0; i < points.Length; i++)
        {
            BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = i + 1, X = points[i].Item1, Y = points[i].Item2 });
        }

        // T20 rebars, Area = 314.16, 40mm cover -> inset by 40mm
        var rebars = new[]
        {
            (-260.0, -260.0), (0.0, -260.0), (260.0, -260.0),
            (260.0, 0.0), (260.0, 260.0), (140.0, 260.0),
            (140.0, -60.0), (0.0, -60.0), (-140.0, -60.0),
            (-140.0, 260.0), (-260.0, 260.0), (-260.0, 0.0)
        };

        for (int i = 0; i < rebars.Length; i++)
        {
            Rebars.Add(new IrregularRebarRowViewModel
            {
                RebarIndex = (i + 1).ToString(),
                X = rebars[i].Item1,
                Y = rebars[i].Item2,
                AreaMm2 = 314.16,
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

    public bool IsEqualSpacing => RebarMode == IrregularRebarModeType.EqualSpacing;

    public ICommand ClearBoundaryCommand { get; }
    public ICommand ClearRebarsCommand { get; }
    public ICommand ReverseBoundaryCommand { get; }

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
        foreach (var p in copy)
        {
            BoundaryPoints.Add(p);
        }
    }

    public System.Collections.Generic.IReadOnlyList<IrregularRebarModeOption> RebarModeOptions { get; } =
    [
        new(IrregularRebarModeType.CustomCoordinates, "Custom Coordinates"),
        new(IrregularRebarModeType.EqualSpacing, "Equal Spacing")
    ];
}

public sealed record IrregularRebarModeOption(IrregularRebarModeType Type, string DisplayName);

using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsSectionMappingViewModel : ViewModelBase
{
    private readonly Action mappingChanged;
    private SectionShapeType sectionType;
    private double width;
    private double height;
    private double diameter;
    private string material;
    private string barSize;
    private int barsAlongWidth;
    private int barsAlongHeight;
    private int totalBars;
    private double cover;
    private double tieDiameter;
    private double tieSpacing;

    public EtabsSectionMappingViewModel(
        Action mappingChanged,
        string etabsSectionName,
        string uniqueSection,
        SectionShapeType sectionType,
        double width,
        double height,
        double diameter,
        string material,
        string barSize,
        double cover,
        double tieSpacing)
    {
        this.mappingChanged = mappingChanged;
        EtabsSectionName = etabsSectionName;
        UniqueSection = uniqueSection;
        this.sectionType = sectionType;
        this.width = width;
        this.height = height;
        this.diameter = diameter;
        this.material = material;
        this.barSize = barSize;
        barsAlongWidth = 4;
        barsAlongHeight = 4;
        totalBars = 12;
        this.cover = cover;
        tieDiameter = 10;
        this.tieSpacing = tieSpacing;
    }

    public IReadOnlyList<SectionShapeType> SectionTypes { get; } = [SectionShapeType.Rectangular, SectionShapeType.Circular];
    public string EtabsSectionName { get; }
    public string UniqueSection { get; }

    public SectionShapeType SectionType
    {
        get => sectionType;
        set
        {
            if (sectionType == value) return;
            sectionType = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double Width
    {
        get => width;
        set
        {
            if (Math.Abs(width - value) < 0.0001) return;
            width = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double Height
    {
        get => height;
        set
        {
            if (Math.Abs(height - value) < 0.0001) return;
            height = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double Diameter
    {
        get => diameter;
        set
        {
            if (Math.Abs(diameter - value) < 0.0001) return;
            diameter = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public string Material
    {
        get => material;
        set
        {
            if (material == value) return;
            material = value;
            Raise();
            mappingChanged();
        }
    }

    public string BarSize
    {
        get => barSize;
        set
        {
            if (barSize == value) return;
            barSize = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public int BarsAlongWidth
    {
        get => barsAlongWidth;
        set
        {
            if (barsAlongWidth == value) return;
            barsAlongWidth = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public int BarsAlongHeight
    {
        get => barsAlongHeight;
        set
        {
            if (barsAlongHeight == value) return;
            barsAlongHeight = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public int TotalBars
    {
        get => totalBars;
        set
        {
            if (totalBars == value) return;
            totalBars = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double Cover
    {
        get => cover;
        set
        {
            if (Math.Abs(cover - value) < 0.0001) return;
            cover = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double TieDiameter
    {
        get => tieDiameter;
        set
        {
            if (Math.Abs(tieDiameter - value) < 0.0001) return;
            tieDiameter = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public double TieSpacing
    {
        get => tieSpacing;
        set
        {
            if (Math.Abs(tieSpacing - value) < 0.0001) return;
            tieSpacing = value;
            Raise();
            RaiseComputed();
            mappingChanged();
        }
    }

    public bool IsRectangular => SectionType == SectionShapeType.Rectangular;
    public bool IsCircular => SectionType == SectionShapeType.Circular;
    public int RectangularBarCount => Math.Max(0, (BarsAlongWidth * 2) + (BarsAlongHeight * 2) - 4);
    public int EffectiveBarCount => IsCircular ? TotalBars : RectangularBarCount;
    public string RebarTemplate => $"Equal spacing {BarSize} @ {TieSpacing:0.#}, cover {Cover:0.#} (custom coordinates)";
    public string Dimensions => IsCircular ? $"D{Diameter:0.#}" : $"{Width:0.#} x {Height:0.#}";
    public string BoundarySummary => IsCircular ? $"Circular boundary D{Diameter:0.#}" : $"Rectangular boundary {Width:0.#} x {Height:0.#}";
    public string Status => HasValidDefinition ? "Ready" : "Needs review";
    public bool HasValidDefinition => IsCircular
        ? Diameter > 0 && Cover > 0 && TieSpacing > 0
        : Width > 0 && Height > 0 && Cover > 0 && TieSpacing > 0;

    private void RaiseComputed()
    {
        Raise(nameof(IsRectangular));
        Raise(nameof(IsCircular));
        Raise(nameof(RectangularBarCount));
        Raise(nameof(EffectiveBarCount));
        Raise(nameof(RebarTemplate));
        Raise(nameof(Dimensions));
        Raise(nameof(BoundarySummary));
        Raise(nameof(Status));
        Raise(nameof(HasValidDefinition));
    }
}

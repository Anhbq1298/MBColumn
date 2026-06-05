using MBColumn.Domain.Enums;
using MBColumn.Domain.Units;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsColumnImportRowViewModel : ViewModelBase
{
    private readonly Action<EtabsColumnImportRowViewModel> selectionChanged;
    private readonly UnitProfile unitProfile;
    private bool isSelected;
    private string importGroupName = "";

    public EtabsColumnImportRowViewModel(
        Action<EtabsColumnImportRowViewModel> selectionChanged,
        string objectName,
        string pier,
        string story,
        string label,
        string uniqueSection,
        string etabsSectionName,
        string material,
        SectionShapeType sectionType,
        double width,
        double height,
        double diameter,
        double lengthMm,
        string linkedSection,
        string status,
        UnitSystem unitSystem)
    {
        this.selectionChanged = selectionChanged;
        unitProfile = UnitProfile.For(unitSystem);
        ObjectName = objectName;
        Pier = pier;
        Story = story;
        Label = label;
        UniqueSection = uniqueSection;
        EtabsSectionName = etabsSectionName;
        Material = material;
        SectionType = sectionType;
        Width = width;
        Height = height;
        Diameter = diameter;
        LengthMm = lengthMm;
        LinkedSection = linkedSection;
        Status = status;
    }

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected == value) return;
            isSelected = value;
            Raise();
            selectionChanged(this);
        }
    }

    public string ObjectName { get; }
    public string Pier { get; }
    public string Story { get; }
    public string Label { get; }
    public string UniqueSection { get; }
    public string EtabsSectionName { get; }
    public string Material { get; }
    public SectionShapeType SectionType { get; }
    public double Width { get; }
    public double Height { get; }
    public double Diameter { get; }
    public double LengthMm { get; }
    public string LengthDisplay => unitProfile.UnitSystem == UnitSystem.Metric
        ? $"{LengthMm:N0} {unitProfile.SectionSizeLabel}"
        : $"{LengthMm / 25.4:N2} {unitProfile.SectionSizeLabel}";
    public string LinkedSection { get; }
    public string Status { get; }
    public bool IsRectangular => SectionType == SectionShapeType.Rectangular;
    public bool IsCircular => SectionType == SectionShapeType.Circular;
    public bool IsIrregular => SectionType == SectionShapeType.Irregular;
    public string SectionTypeDisplay => SectionType switch
    {
        SectionShapeType.Rectangular => "Rectangular",
        SectionShapeType.Circular => "Circular",
        SectionShapeType.Irregular => "Pier",
        _ => SectionType.ToString()
    };
    public string SectionKey => $"{EtabsSectionName}|{UniqueSection}|{SectionType}";

    public string ImportGroupName
    {
        get => importGroupName;
        set => Set(ref importGroupName, value);
    }

    public bool IsAssigned => !string.IsNullOrEmpty(importGroupName);
}

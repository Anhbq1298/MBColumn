namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsForceImportRowViewModel : ViewModelBase
{
    private readonly Action selectionChanged;
    private bool isSelected = true;

    public EtabsForceImportRowViewModel(
        Action selectionChanged,
        string objectName,
        string pier,
        string story,
        string label,
        string etabsSection,
        string loadCombination,
        double p,
        double m2,
        double m3,
        double v2,
        double v3,
        string station,
        string status)
    {
        this.selectionChanged = selectionChanged;
        ObjectName = objectName;
        Pier = pier;
        Story = story;
        Label = label;
        EtabsSection = etabsSection;
        LoadCombination = loadCombination;
        P = p;
        M2 = m2;
        M3 = m3;
        V2 = v2;
        V3 = v3;
        Station = station;
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
            selectionChanged();
        }
    }

    public string ObjectName { get; }
    public string Pier { get; }
    public string Story { get; }
    public string Label { get; }
    public string EtabsSection { get; }
    public string LoadCombination { get; }
    public double P { get; }
    public double M2 { get; }
    public double M3 { get; }
    public double V2 { get; }
    public double V3 { get; }
    public string Station { get; }
    public string Status { get; }
}

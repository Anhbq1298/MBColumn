using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MbColumnMappedForceRowViewModel
{
    public MbColumnMappedForceRowViewModel(MbColumnMappedForceRow row)
    {
        MbColumnSectionName = row.MbColumnSectionName;
        LoadCaseName        = row.LoadCaseName;
        ObjectType          = row.ObjectType == EtabsImportedObjectType.Column ? "Column" : "Pier";
        Story               = row.Story;
        Label               = row.Label;
        LoadCombo           = row.LoadCombo;
        Location            = row.Location;
        P                   = row.P;
        Mx                  = row.Mx;
        My                  = row.My;
    }

    public string MbColumnSectionName { get; }
    public string LoadCaseName { get; }
    public string ObjectType { get; }
    public string Story { get; }
    public string Label { get; }
    public string LoadCombo { get; }
    public string Location { get; }
    public double P { get; }
    public double Mx { get; }
    public double My { get; }
}

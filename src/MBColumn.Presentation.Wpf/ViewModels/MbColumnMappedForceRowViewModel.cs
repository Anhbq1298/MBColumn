using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MbColumnMappedForceRowViewModel
{
    public MbColumnMappedForceRowViewModel(MbColumnMappedForceRow row)
    {
        MbColumnSectionName = row.MbColumnSectionName;
        CaseName            = row.CaseName;
        ObjectType          = row.ObjectType == EtabsImportedObjectType.Column ? "Column" : "Pier";
        Story               = row.Story;
        Label               = row.Label;
        NEd                 = row.NEd;
        Vx                  = row.Vx;
        Vy                  = row.Vy;
        MxTop               = row.MxTop;
        MxBottom            = row.MxBottom;
        MyTop               = row.MyTop;
        MyBottom            = row.MyBottom;
        MxUsed              = row.MxUsed;
        MyUsed              = row.MyUsed;
    }

    public string MbColumnSectionName { get; }
    public string CaseName   { get; }
    public string ObjectType { get; }
    public string Story      { get; }
    public string Label      { get; }
    public double NEd        { get; }
    public double Vx         { get; }
    public double Vy         { get; }
    public double MxTop      { get; }
    public double MxBottom   { get; }
    public double MyTop      { get; }
    public double MyBottom   { get; }
    public double MxUsed     { get; }
    public double MyUsed     { get; }
}

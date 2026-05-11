using MBColumn.Application.DTOs;
using System.Windows;

namespace MBColumn.Presentation.Wpf;

public partial class ControlPointsWindow : Window
{
    public ControlPointsWindow(ControlPointTableDto table)
    {
        InitializeComponent();

        ColP.Header       = $"P ({table.ForceUnitLabel})";
        ColMx.Header      = $"Mx ({table.MomentUnitLabel})";
        ColMy.Header      = $"My ({table.MomentUnitLabel})";
        ColNaDepth.Header = $"NA Depth ({table.LengthUnitLabel})";
        ColDtDepth.Header = $"dt Depth ({table.LengthUnitLabel})";

        ControlPointsGrid.ItemsSource = BuildRows(table);
    }

    private static List<ControlPointRow> BuildRows(ControlPointTableDto table)
    {
        var rows = new List<ControlPointRow>();
        string? lastAxis = null;

        foreach (var r in table.Rows)
        {
            if (r.Axis != lastAxis)
            {
                rows.Add(new ControlPointRow(true, $"── {r.Axis}-Axis ──", "", "", "", "", "", "", ""));
                lastAxis = r.Axis;
            }

            rows.Add(new ControlPointRow(
                false,
                r.PointLabel,
                $"{r.P:F2}",
                $"{r.Mx:F2}",
                $"{r.My:F2}",
                $"{r.NaDepth:F1}",
                $"{r.DtDepth:F1}",
                $"{r.EpsilonT:F5}",
                $"{r.Phi:F3}"));
        }

        return rows;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
}

public sealed record ControlPointRow(
    bool   IsAxisHeader,
    string AboutPoint,
    string P,
    string Mx,
    string My,
    string NaDepth,
    string DtDepth,
    string EpsilonT,
    string Phi);

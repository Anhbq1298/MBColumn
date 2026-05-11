using MBColumn.Application.DTOs;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace MBColumn.Presentation.Wpf;

public partial class ControlPointsWindow : Window
{
    private readonly ControlPointTableDto _table;

    public ControlPointsWindow(ControlPointTableDto table)
    {
        InitializeComponent();

        _table = table;

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

    private void ExportButton_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new SaveFileDialog
        {
            Title = "Export Control Points",
            Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt",
            FilterIndex = 1,
            DefaultExt = "csv",
            FileName = "ControlPoints"
        };

        if (dlg.ShowDialog(this) != true)
            return;

        bool isCsv = Path.GetExtension(dlg.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase);
        string delimiter = isCsv ? "," : "\t";

        var sb = new StringBuilder();

        // Header row with units embedded in column labels
        string[] headers =
        [
            "theTa",
            $"P ({_table.ForceUnitLabel})",
            $"Mx ({_table.MomentUnitLabel})",
            $"My ({_table.MomentUnitLabel})",
            $"NA Depth ({_table.LengthUnitLabel})",
            $"dt Depth ({_table.LengthUnitLabel})",
            "st",
            "phi"
        ];

        sb.AppendLine(string.Join(delimiter, headers.Select(h => QuoteIfCsv(h, isCsv))));

        string? lastAxis = null;
        foreach (var r in _table.Rows)
        {
            if (r.Axis != lastAxis)
            {
                sb.AppendLine(string.Join(delimiter,
                    new[] { $"-- {r.Axis}-Axis --", "", "", "", "", "", "", "" }
                    .Select(v => QuoteIfCsv(v, isCsv))));
                lastAxis = r.Axis;
            }

            string[] values =
            [
                r.PointLabel,
                $"{r.P:F2}",
                $"{r.Mx:F2}",
                $"{r.My:F2}",
                $"{r.NaDepth:F1}",
                $"{r.DtDepth:F1}",
                $"{r.EpsilonT:F5}",
                $"{r.Phi:F3}"
            ];

            sb.AppendLine(string.Join(delimiter, values.Select(v => QuoteIfCsv(v, isCsv))));
        }

        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

        MessageBox.Show(this,
            $"Exported to:\n{dlg.FileName}",
            "Export Complete",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    private static string QuoteIfCsv(string value, bool isCsv)
    {
        if (!isCsv)
            return value;
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            return $"\"{value.Replace("\"", "\"\"")}\"";
        return value;
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

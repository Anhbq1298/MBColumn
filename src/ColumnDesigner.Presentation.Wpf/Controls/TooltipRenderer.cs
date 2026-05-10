using ColumnDesigner.Application.DTOs;

namespace ColumnDesigner.Presentation.Wpf.Controls;

public static class TooltipRenderer
{
    public static string Build(ControlPointDto p, double ratio)
    {
        if (p.IsDemand)
        {
            var ratioValue = p.Utilization > 0 ? p.Utilization : ratio;
            var status = string.IsNullOrWhiteSpace(p.StatusText) ? "" : $"\nStatus: {p.StatusText}";
            var name = string.IsNullOrWhiteSpace(p.Label) ? "Demand" : p.Label;
            return $"{name}\nPu: {p.P:0.###}\nMux: {p.Mx:0.###}\nMuy: {p.My:0.###}\nPMM ratio: {ratioValue:0.###}{status}";
        }

        string curveType = p.IsNominal ? "Nominal Capacity" : "Design Capacity";
        string pLabel = p.IsNominal ? "Pn" : "phi Pn";
        string mxLabel = p.IsNominal ? "Mnx" : "phi Mnx";
        string myLabel = p.IsNominal ? "Mny" : "phi Mny";
        return $"{curveType}\n{pLabel}: {p.P:0.###}\n{mxLabel}: {p.Mx:0.###}\n{myLabel}: {p.My:0.###}\nPhi: {p.Phi:0.###}\nTheta: {p.ThetaDegrees:0.#} deg\nc: {p.NeutralAxisDepth:0.###}";
    }
}

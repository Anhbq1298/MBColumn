using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WpfMath.Controls;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Renders a LaTeX formula using WpfMath.
/// Normalizes double-backslash (produced by raw string literals) to single-backslash before rendering.
/// Falls back to readable plain text if WpfMath cannot parse the formula.
/// </summary>
public sealed class SafeFormulaControl : ContentControl
{
    public static readonly DependencyProperty FormulaProperty = DependencyProperty.Register(
        nameof(Formula), typeof(string), typeof(SafeFormulaControl),
        new PropertyMetadata("", OnChanged));

    public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
        nameof(Scale), typeof(double), typeof(SafeFormulaControl),
        new PropertyMetadata(16.0, OnChanged));

    public static readonly DependencyProperty FormulaForegroundProperty = DependencyProperty.Register(
        nameof(FormulaForeground), typeof(Brush), typeof(SafeFormulaControl),
        new PropertyMetadata(Brushes.Black, OnChanged));

    public string Formula
    {
        get => (string)GetValue(FormulaProperty);
        set => SetValue(FormulaProperty, value);
    }

    public double Scale
    {
        get => (double)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    public Brush FormulaForeground
    {
        get => (Brush)GetValue(FormulaForegroundProperty);
        set => SetValue(FormulaForegroundProperty, value);
    }

    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((SafeFormulaControl)d).Refresh();

    private void Refresh()
    {
        var raw = Formula ?? "";
        if (string.IsNullOrWhiteSpace(raw)) { Content = null; return; }

        // Raw string literals in C# ($$"""...""") produce \\frac instead of \frac.
        // Normalize to single backslash so WpfMath receives valid LaTeX.
        var normalized = raw.Replace(@"\\", @"\")
                            .Replace(@"\quad", @"\;\;\;")
                            .Replace(@"\ ", @"\;");

        // Show readable plain text immediately so the UI is never blocked.
        Content = MakeFallbackText(normalized);

        // Defer expensive WpfMath parse+render to background so initial load stays responsive.
        Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
        {
            if ((Formula ?? "").Replace(@"\\", @"\").Replace(@"\quad", @"\;\;\;").Replace(@"\ ", @"\;") != normalized) return;
            try
            {
                var control = new FormulaControl
                {
                    Formula = normalized,
                    Scale = Scale,
                    Foreground = FormulaForeground,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };
                
                // Force a measure to trigger parsing
                control.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                if (control.Errors.Count == 0)
                {
                    Content = control;
                }
            }
            catch { /* fallback text already shown */ }
        });
    }

    private TextBlock MakeFallbackText(string normalized) => new()
    {
        Text = ToReadableText(normalized),
        FontStyle = FontStyles.Italic,
        FontSize = Scale * 0.65,
        Foreground = FormulaForeground,
        TextWrapping = TextWrapping.Wrap,
        VerticalAlignment = VerticalAlignment.Center,
    };

    /// <summary>Converts a LaTeX string to a readable plain-text approximation.</summary>
    internal static string ToReadableText(string latex)
    {
        if (string.IsNullOrEmpty(latex)) return "";

        return latex
            .Replace(@"\mathrm{", "").Replace(@"\text{", "").Replace(@"\mathbf{", "")
            .Replace(@"\left(", "(").Replace(@"\right)", ")")
            .Replace(@"\left[", "[").Replace(@"\right]", "]")
            .Replace(@"\left\{", "{").Replace(@"\right\}", "}")
            .Replace(@"\varepsilon", "ε").Replace(@"\epsilon", "ε")
            .Replace(@"\phi", "φ").Replace(@"\Phi", "Φ")
            .Replace(@"\theta", "θ").Replace(@"\Theta", "Θ")
            .Replace(@"\alpha", "α").Replace(@"\beta", "β")
            .Replace(@"\gamma", "γ").Replace(@"\delta", "δ")
            .Replace(@"\eta", "η").Replace(@"\lambda", "λ")
            .Replace(@"\sigma", "σ").Replace(@"\pi", "π")
            .Replace(@"\mu", "μ").Replace(@"\nu", "ν")
            .Replace(@"\rho", "ρ").Replace(@"\tau", "τ")
            .Replace(@"\bar{", "").Replace(@"\hat{", "").Replace(@"\tilde{", "")
            .Replace(@"\_{", "_").Replace(@"\^{", "^")
            .Replace(@"_{", "_").Replace(@"^{", "^")
            .Replace("}", "").Replace("{", "")
            .Replace(@"\times", "×").Replace(@"\cdot", "·")
            .Replace(@"\leq", "≤").Replace(@"\geq", "≥")
            .Replace(@"\neq", "≠").Replace(@"\approx", "≈")
            .Replace(@"\pm", "±").Replace(@"\sqrt", "√")
            .Replace(@"\sum", "Σ").Replace(@"\frac", " / ")
            .Replace(@"\cos", "cos").Replace(@"\sin", "sin").Replace(@"\tan", "tan")
            .Replace(@"\Acos", "arccos").Replace(@"\arccos", "arccos")
            .Replace(@"\ ", " ").Replace(@"\quad", "  ").Replace(@"\,", " ")
            .Replace("\\", "")
            .Trim();
    }
}

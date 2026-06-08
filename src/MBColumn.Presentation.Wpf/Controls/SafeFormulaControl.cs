using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Renders a LaTeX formula through the enhanced math view while preserving the old simple API.
/// Falls back to readable plain text if WebView2 or KaTeX cannot render the formula.
/// </summary>
public sealed class SafeFormulaControl : ContentControl
{
    public static readonly DependencyProperty FormulaProperty = DependencyProperty.Register(
        nameof(Formula), typeof(string), typeof(SafeFormulaControl),
        new PropertyMetadata("", OnChanged));

    public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
        nameof(Scale), typeof(double), typeof(SafeFormulaControl),
        new PropertyMetadata(12.0, OnChanged));

    public static readonly DependencyProperty FormulaForegroundProperty = DependencyProperty.Register(
        nameof(FormulaForeground), typeof(Brush), typeof(SafeFormulaControl),
        new PropertyMetadata(Brushes.Black, OnChanged));

    public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register(
        nameof(DisplayMode), typeof(bool), typeof(SafeFormulaControl),
        new PropertyMetadata(false, OnChanged));

    public static readonly DependencyProperty UseEnhancedMathProperty = DependencyProperty.Register(
        nameof(UseEnhancedMath), typeof(bool), typeof(SafeFormulaControl),
        new PropertyMetadata(true, OnChanged));

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

    public bool DisplayMode
    {
        get => (bool)GetValue(DisplayModeProperty);
        set => SetValue(DisplayModeProperty, value);
    }

    public bool UseEnhancedMath
    {
        get => (bool)GetValue(UseEnhancedMathProperty);
        set => SetValue(UseEnhancedMathProperty, value);
    }

    private MathRendering.MathEquationView? _view;

    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((SafeFormulaControl)d).Refresh();

    private void Refresh()
    {
        var raw = Formula ?? "";
        if (string.IsNullOrWhiteSpace(raw))
        {
            Content = null;
            _view = null;
            return;
        }

        // Raw string literals in C# ($$"""...""") can produce \\frac instead of \frac.
        // Normalize to single backslash so KaTeX receives valid LaTeX.
        var normalized = raw.Replace(@"\\", @"\")
                            .Replace(@"\quad", @"\;\;\;")
                            .Replace(@"\ ", @"\;");

        if (_view is null)
        {
            _view = new MathRendering.MathEquationView
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Content = _view;
        }

        _view.Latex = normalized;
        _view.FallbackText = ToReadableText(normalized);
        _view.EquationFontSize = Scale;
        _view.DisplayMode = DisplayMode;
        _view.UseEnhancedMath = UseEnhancedMath;
        _view.Foreground = FormulaForeground;
        _view.MinHeight = System.Math.Max(28.0, Scale * 2.0);
        _view.MaxHeight = DisplayMode ? 120.0 : 80.0;
    }

    /// <summary>Converts a LaTeX string to a readable plain-text approximation.</summary>
    internal static string ToReadableText(string latex)
    {
        if (string.IsNullOrEmpty(latex)) return "";

        return latex
            .Replace(@"\mathrm{", "").Replace(@"\text{", "").Replace(@"\mathbf{", "")
            .Replace(@"\left(", "(").Replace(@"\right)", ")")
            .Replace(@"\left[", "[").Replace(@"\right]", "]")
            .Replace(@"\left\{", "{").Replace(@"\right\}", "}")
            .Replace(@"\varepsilon", "epsilon").Replace(@"\epsilon", "epsilon")
            .Replace(@"\phi", "phi").Replace(@"\Phi", "Phi")
            .Replace(@"\theta", "theta").Replace(@"\Theta", "Theta")
            .Replace(@"\alpha", "alpha").Replace(@"\beta", "beta")
            .Replace(@"\gamma", "gamma").Replace(@"\delta", "delta")
            .Replace(@"\eta", "eta").Replace(@"\lambda", "lambda")
            .Replace(@"\sigma", "sigma").Replace(@"\pi", "pi")
            .Replace(@"\mu", "mu").Replace(@"\nu", "nu")
            .Replace(@"\rho", "rho").Replace(@"\tau", "tau")
            .Replace(@"\bar{", "").Replace(@"\hat{", "").Replace(@"\tilde{", "")
            .Replace(@"\_{", "_").Replace(@"\^{", "^")
            .Replace(@"_{", "_").Replace(@"^{", "^")
            .Replace("}", "").Replace("{", "")
            .Replace(@"\times", "x").Replace(@"\cdot", "*")
            .Replace(@"\leq", "<=").Replace(@"\geq", ">=")
            .Replace(@"\neq", "!=").Replace(@"\approx", "~=")
            .Replace(@"\pm", "+/-").Replace(@"\sqrt", "sqrt")
            .Replace(@"\sum", "sum").Replace(@"\frac", " / ")
            .Replace(@"\cos", "cos").Replace(@"\sin", "sin").Replace(@"\tan", "tan")
            .Replace(@"\Acos", "arccos").Replace(@"\arccos", "arccos")
            .Replace(@"\ ", " ").Replace(@"\quad", "  ").Replace(@"\,", " ")
            .Replace("\\", "")
            .Trim();
    }
}

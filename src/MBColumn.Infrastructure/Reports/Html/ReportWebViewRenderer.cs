using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using System.Globalization;
using System.IO;
using System.Text;
using SystemMath = System.Math;

namespace MBColumn.Infrastructure.Reports.Html;

/// <summary>
/// Builds a self-contained HTML string for the WebView2 report preview.
/// Inter font, KaTeX and all SVGs are embedded inline.
/// </summary>
public sealed class ReportWebViewRenderer
{
    private static readonly object Lock = new();
    private static string? _katexCss, _katexJs, _fontFaceCss;
    private static bool _assetsChecked, _hasAssets;

    public bool CanRender()
    {
        if (_assetsChecked) return _hasAssets;
        lock (Lock)
        {
            if (_assetsChecked) return _hasAssets;
            _assetsChecked = true;
            try
            {
                string katexRoot = KatexRoot();
                _hasAssets = File.Exists(Path.Combine(katexRoot, "katex.min.css"))
                          && File.Exists(Path.Combine(katexRoot, "katex.min.js"));
            }
            catch { _hasAssets = false; }
            return _hasAssets;
        }
    }

    public string BuildHtml(ReportData data)
        => BuildHtml(data, data.Sections);

    public string BuildHtml(ReportData data, IEnumerable<ReportSection> visibleSections)
    {
        LoadAssets();
        var sb = new StringBuilder(131072);

        sb.Append("<!DOCTYPE html><html lang='en'><head><meta charset='utf-8'/>");
        sb.Append("<meta name='viewport' content='width=device-width,initial-scale=1'/>");

        if (!string.IsNullOrEmpty(_fontFaceCss))
        {
            sb.Append("<style>");
            sb.Append(_fontFaceCss);
            sb.Append("</style>");
        }

        if (!string.IsNullOrEmpty(_katexCss))
        {
            sb.Append("<style>");
            sb.Append(_katexCss);
            sb.Append("</style>");
        }

        sb.Append("<style>");
        sb.Append(PageStyles());
        sb.Append("</style></head><body>");

        // Cover header
        sb.Append("<div class='cover'>");
        sb.Append("<div class='cover-title'>MB Column — Calculation Report</div>");
        if (!string.IsNullOrEmpty(data.ProjectName))
            sb.Append($"<div class='cover-meta'><span class='cover-label'>Project</span>{H(data.ProjectName)}</div>");
        if (!string.IsNullOrEmpty(data.GroupName))
            sb.Append($"<div class='cover-meta'><span class='cover-label'>Group</span>{H(data.GroupName)}</div>");
        if (!string.IsNullOrEmpty(data.DesignTierName))
            sb.Append($"<div class='cover-meta'><span class='cover-label'>Section</span>{H(data.DesignTierName)}</div>");
        sb.Append($"<div class='cover-generated'>Generated: {H(data.GeneratedAt.ToString("yyyy-MM-dd HH:mm"))}</div>");
        sb.Append("</div>");

        foreach (var section in visibleSections)
        {
            string anchorId = $"sec-{section.Number.Replace(".", "-")}";
            sb.Append($"<section id='{anchorId}'>");
            sb.Append($"<div class='sec-header'><span class='sec-num'>{H(section.Number)}</span>&ensp;{H(section.Title)}</div>");
            sb.Append("<div class='sec-body'>");
            foreach (var block in section.Blocks)
                RenderBlock(sb, block);
            sb.Append("</div></section>");
        }

        if (!string.IsNullOrEmpty(_katexJs))
        {
            sb.Append("<script>");
            sb.Append(_katexJs);
            sb.Append("</script>");
        }

        // Auto-render all .kf spans after DOM load
        sb.Append("""
<script>
document.addEventListener('DOMContentLoaded',function(){
  document.querySelectorAll('.kf').forEach(function(el){
    var latex=el.getAttribute('data-latex')||'';
    var disp=el.getAttribute('data-display')==='true';
    if(!latex.trim())return;
    if(typeof katex!=='undefined'){
      try{ katex.render(latex,el,{throwOnError:false,displayMode:disp,strict:'ignore'}); }
      catch(e){ el.textContent=latex; }
    } else { el.textContent=latex; }
  });
});
</script>
""");
        sb.Append("</body></html>");
        return sb.ToString();
    }

    // ── Block dispatch ────────────────────────────────────────────────────────

    private static void RenderBlock(StringBuilder sb, ReportBlock block)
    {
        switch (block)
        {
            case HeadingBlock h:
                int lvl = SystemMath.Clamp(h.Level + 1, 2, 6);
                sb.Append($"<h{lvl} class='sub-heading'>{H(h.Text)}</h{lvl}>");
                break;

            case ParagraphBlock p:
                sb.Append($"<p class='body-text'>{H(p.Text)}</p>");
                break;

            case NoteBlock n:
                sb.Append($"<div class='note'>{H(n.Text)}</div>");
                break;

            case FormulaBlock fb:
                RenderFormulaBlock(sb, fb.Title, fb.LatexFormula, fb.SubstitutionText, fb.ResultText);
                break;

            case TableBlock t:
                RenderTable(sb, null, t.Headers, t.Rows);
                break;

            case SteelTableBlock st:
                RenderSteelTable(sb, st);
                break;

            case ImageBlock img:
                sb.Append("<div class='svg-wrap'>");
                sb.Append(img.SvgContent);
                if (!string.IsNullOrWhiteSpace(img.Caption))
                    sb.Append($"<p class='fig-caption'>{H(img.Caption)}</p>");
                sb.Append("</div>");
                break;

            case DiagramBlock diag:
                try
                {
                    if (!string.IsNullOrWhiteSpace(diag.PngDataUri))
                    {
                        sb.Append("<div class='diagram-wrap'>");
                        sb.Append($"<img class='diagram-img' src='{XA(diag.PngDataUri)}' alt='{XA(diag.Caption)}' style='width:{diag.WidthPct.ToString(CultureInfo.InvariantCulture)}%;'/>");
                        if (!string.IsNullOrWhiteSpace(diag.Caption))
                            sb.Append($"<p class='fig-caption'>{H(diag.Caption)}</p>");
                        sb.Append("</div>");
                    }
                    else
                    {
                        sb.Append($"<div class='diagram-placeholder'>{H(diag.Caption)}</div>");
                    }
                }
                catch
                {
                    sb.Append($"<div class='diagram-placeholder'>{H(diag.Caption)}</div>");
                }
                break;

            case SummaryBoxBlock sum:
                RenderSummaryBox(sb, sum);
                break;

            case DividerBlock:
                sb.Append("<hr class='divider'/>");
                break;

            case PageBreakBlock:
                sb.Append("<div style='page-break-after:always'></div>");
                break;

            case SectionPreviewBlock sp:
                if (!string.IsNullOrWhiteSpace(sp.SvgFallback))
                {
                    sb.Append("<div class='svg-wrap'>");
                    sb.Append(sp.SvgFallback);
                    sb.Append("</div>");
                }
                break;

            case Ec2ShearDetailBlock shear:
                foreach (var b in Ec2ShearLatexBuilder.BuildShearBlocks(shear.Shear, shear.ForceUnit))
                    RenderBlock(sb, b);
                break;

            case Ec2SlendernessDetailBlock sl:
                foreach (var b in BuildSlendernessBlocks(sl))
                    RenderBlock(sb, b);
                break;
        }
    }

    // ── Slenderness step-by-step blocks (inline, no separate class needed) ───

    private static IEnumerable<ReportBlock> BuildSlendernessBlocks(Ec2SlendernessDetailBlock sl)
    {
        var lc    = sl.LoadCase;
        var batch = sl.Batch;
        double mScale = sl.IsMetric ? 1e-6 : 1e-6 / 1.356;

        // Properties table
        if (batch.SectionValues is { } sv)
            yield return new TableBlock(
                ["Property", "Symbol", "Value"],
                [
                    ["Gross concrete area",  "Ac",  $"{sv.AcMm2:0.#} mm²"],
                    ["2nd moment  (X)",      "Ixx", $"{sv.IxxMm4:0.3e} mm⁴"],
                    ["2nd moment  (Y)",      "Iyy", $"{sv.IyyMm4:0.3e} mm⁴"],
                    ["Total steel area",     "As",  $"{sv.AsTotalMm2:0.#} mm²"],
                    ["Mech. reinf. ratio",   "ω",   $"{sv.Omega:F4}"],
                    ["Ecm",                  "MPa", $"{sv.EcmMpa:0.#}"],
                    ["fcd",                  "MPa", $"{sv.FcdMpa:0.##}"],
                ]);

        foreach (var (axis, ax) in new[] { ("X", lc.X), ("Y", lc.Y) })
        {
            if (ax is null) continue;
            double l0 = axis == "X" ? (batch.L0xMm ?? 0) : (batch.L0yMm ?? 0);
            bool slender = ax.IsSlender;

            yield return new HeadingBlock($"{axis}-axis bending", 3);

            // Slenderness check formula
            yield return new FormulaBlock(
                "Slenderness limit  (EC2 §5.8.3.1)",
                @"\lambda_{lim} = \frac{20 \cdot A \cdot B \cdot C}{\sqrt{n}}",
                $@"n=\frac{{N_{{Ed}}}}{{A_c f_{{cd}}}}={F(ax.FactorN,4)},\quad A={F(ax.FactorA,4)},\quad B={F(ax.FactorB,4)},\quad C={F(ax.FactorC,4)}",
                $@"\lambda_{{lim}}={F(ax.LambdaLimit,1)},\quad \lambda={F(ax.Lambda,1)}\;\Rightarrow\;{(slender ? @"\lambda>\lambda_{lim}\;\text{— 2nd-order applied}" : @"\lambda\leq\lambda_{lim}\;\text{— 1st-order sufficient}")}");

            if (!slender) continue;

            // Nominal curvature
            yield return new FormulaBlock(
                "Nominal curvature  (EC2 §5.8.8.3)",
                @"\frac{1}{r} = K_r K_\varphi \frac{\varepsilon_{yd}}{0.45\,d}",
                $@"1/r = {ax.NominalCurvature1PerMm:F4e+0}\;\mathrm{{mm}}^{{-1}}",
                "");

            // Deflection
            yield return new FormulaBlock(
                "Deflection  e₂",
                @"e_2 = \frac{1}{r} \cdot \frac{L_0^2}{c}",
                $@"e_2 = {ax.NominalCurvature1PerMm:F4e+0} \times \frac{{{F(l0,0)}^2}}{{10}} = {F(ax.E2Mm,1)}\;\mathrm{{mm}}",
                "");

            // Moments
            yield return new FormulaBlock(
                "Design moments",
                @"M_{Ed,used} = \max\!\left(M_{0e} + N_{Ed}\,e_2,\;M_{02},\;N_{Ed}\cdot e_0\right)",
                $@"M_{{01}}={F(ax.M01Nmm*mScale,2)}\;{sl.MomentUnit},\quad M_{{02}}={F(ax.M02Nmm*mScale,2)}\;{sl.MomentUnit},\quad M_{{0e}}={F(ax.M0eNmm*mScale,2)}\;{sl.MomentUnit}",
                $@"M_2=N_{{Ed}}\cdot e_2={F(ax.M2Nmm*mScale,2)}\;{sl.MomentUnit},\quad M_{{Ed,used}}={F(ax.MUsedNmm*mScale,2)}\;{sl.MomentUnit}");
        }

        foreach (var w in lc.Warnings)
            yield return new NoteBlock(w);
    }

    // ── Formula block ─────────────────────────────────────────────────────────

    private static void RenderFormulaBlock(
        StringBuilder sb,
        string title, string main, string sub, string result)
    {
        bool hasMain   = !string.IsNullOrWhiteSpace(main);
        bool hasSub    = !string.IsNullOrWhiteSpace(sub);
        bool hasResult = !string.IsNullOrWhiteSpace(result);
        if (!hasMain && !hasSub && !hasResult && string.IsNullOrWhiteSpace(title)) return;

        sb.Append("<div class='formula-panel'>");
        if (!string.IsNullOrWhiteSpace(title))
            sb.Append($"<div class='formula-title'>{H(title)}</div>");
        if (hasMain)
            sb.Append($"<div class='formula-main'><span class='kf' data-latex='{XA(Norm(main))}' data-display='true'></span></div>");
        if (hasSub)
            sb.Append($"<div class='formula-sub'><span class='kf' data-latex='{XA(Norm(sub))}' data-display='false'></span></div>");
        if (hasResult)
            sb.Append($"<div class='formula-result'><span class='kf' data-latex='{XA(Norm(result))}' data-display='false'></span></div>");
        sb.Append("</div>");
    }

    // ── Summary box ───────────────────────────────────────────────────────────

    private static void RenderSummaryBox(StringBuilder sb, SummaryBoxBlock sum)
    {
        string cls = sum.IsPass ? "summary-box pass" : "summary-box fail";
        sb.Append($"<div class='{cls}'>");
        sb.Append($"<div class='summary-title'>{H(sum.Label)}</div>");
        if (!string.IsNullOrWhiteSpace(sum.Value))
        {
            sb.Append("<div class='summary-entries'>");
            sb.Append($"<div class='summary-row'><span class='s-val'>{H(sum.Value)}</span></div>");
            sb.Append("</div>");
        }
        sb.Append("</div>");
    }

    // ── Steel table ───────────────────────────────────────────────────────────

    private static void RenderSteelTable(StringBuilder sb, SteelTableBlock st)
    {
        string[] headers = ["#", "x (mm)", "y (mm)", "d (mm)", "εs", "fs (MPa)", "As (mm²)", "Fs (kN)", "Fs·y (kN·m)", "Fs·x (kN·m)"];
        var rows = st.Rows.Select(r => new[] { r.Index.ToString(), r.XMm, r.YMm, r.DMm, r.EpsilonS, r.FsMpa, r.AsMm2, r.FsKn, r.FsYKnm, r.FsXKnm }).ToArray();
        RenderTable(sb, null, headers, rows);
        if (!string.IsNullOrEmpty(st.SumFs))
        {
            sb.Append($"<p class='tbl-caption'>ΣFs = {H(st.SumFs)} kN&emsp; ΣFs·y = {H(st.SumFsY)} kN·m&emsp; ΣFs·x = {H(st.SumFsX)} kN·m</p>");
        }
    }

    // ── Table ─────────────────────────────────────────────────────────────────

    private static void RenderTable(StringBuilder sb, string? caption, string[] headers, string[][] rows)
    {
        if (!string.IsNullOrWhiteSpace(caption))
            sb.Append($"<p class='tbl-caption'>{H(caption)}</p>");
        sb.Append("<div class='tbl-wrap'><table><thead><tr>");
        foreach (var h in headers) sb.Append($"<th>{H(h)}</th>");
        sb.Append("</tr></thead><tbody>");
        int idx = 0;
        foreach (var row in rows)
        {
            sb.Append($"<tr class='{(idx++ % 2 == 0 ? "even" : "odd")}'>");
            foreach (var cell in row) sb.Append($"<td>{H(cell)}</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody></table></div>");
    }

    // ── Asset loading ─────────────────────────────────────────────────────────

    private static void LoadAssets()
    {
        if (_katexCss is not null) return;
        lock (Lock)
        {
            if (_katexCss is not null) return;
            try
            {
                string kRoot = KatexRoot();
                string fontsUri = new Uri(Path.Combine(kRoot, "fonts") + Path.DirectorySeparatorChar).AbsoluteUri;
                _katexCss = File.ReadAllText(Path.Combine(kRoot, "katex.min.css"))
                    .Replace("url(fonts/", "url(" + fontsUri, StringComparison.Ordinal);
                _katexJs = File.ReadAllText(Path.Combine(kRoot, "katex.min.js"))
                    .Replace("</script", "<\\/script", StringComparison.OrdinalIgnoreCase);
            }
            catch { _katexCss = ""; _katexJs = ""; }

            _fontFaceCss = BuildFontFaceCss();
        }
    }

    private static string BuildFontFaceCss()
    {
        string fontsDir = Path.Combine(AppContext.BaseDirectory, "Resources", "Fonts");
        var sb = new StringBuilder();
        foreach (var (weight, file) in new[]
        {
            ("400", "Inter-Regular.ttf"),
            ("500", "Inter-Medium.ttf"),
            ("600", "Inter-SemiBold.ttf"),
            ("700", "Inter-Bold.ttf"),
        })
        {
            string path = Path.Combine(fontsDir, file);
            if (!File.Exists(path)) continue;
            string uri = new Uri(path).AbsoluteUri;
            sb.Append($"@font-face{{font-family:'Inter';font-weight:{weight};src:url('{uri}') format('truetype');}}");
        }
        return sb.ToString();
    }

    private static string KatexRoot()
        => Path.Combine(AppContext.BaseDirectory, "Resources", "Math", "KaTeX");

    // ── Utility ───────────────────────────────────────────────────────────────

    private static string H(string? s)
        => s is null ? "" : System.Net.WebUtility.HtmlEncode(s);

    private static string XA(string? s)
        => s is null ? "" : s.Replace("&", "&amp;").Replace("'", "&#39;").Replace("\"", "&quot;");

    private static string Norm(string s)
        => (s ?? "").Replace(@"\\", @"\", StringComparison.Ordinal);

    private static string F(double v, int d)
        => v.ToString($"F{d}", CultureInfo.InvariantCulture);

    // ── CSS ───────────────────────────────────────────────────────────────────

    private static string PageStyles() => """
        :root{
          --navy:#1A3A5C; --navy-lt:#2E5F8A;
          --pass:#1E8449; --pass-bg:#EAFAF1; --pass-border:#27AE60;
          --fail:#C0392B; --fail-bg:#FDEDEC; --fail-border:#E74C3C;
          --border:#DDE6EF; --alt:#F5F7FA; --muted:#6B7A8D;
          --formula-bg:#F8FAFC; --formula-border:#DDE6EF;
          --note-bg:#EBF5FB; --note-border:#AED6F1;
        }
        *{box-sizing:border-box;margin:0;padding:0;}
        body{
          font-family:'Inter','Segoe UI',Arial,sans-serif;
          font-size:11pt;line-height:1.55;color:#1A1A2E;
          background:#EAECF0;padding:20px 28px 40px;
        }

        /* Cover */
        .cover{
          background:var(--navy);color:#fff;
          border-radius:6px;padding:20px 24px 16px;margin-bottom:20px;
        }
        .cover-title{font-size:16pt;font-weight:700;margin-bottom:10px;}
        .cover-meta{font-size:10pt;margin:3px 0;display:flex;gap:8px;}
        .cover-label{font-weight:600;opacity:.65;min-width:70px;}
        .cover-generated{font-size:9pt;opacity:.55;margin-top:10px;}

        /* Sections */
        section{
          background:#fff;border-radius:5px;margin-bottom:14px;
          box-shadow:0 1px 4px rgba(0,0,0,.10);overflow:hidden;
        }
        .sec-header{
          background:var(--navy);color:#fff;padding:9px 16px;
          font-size:12pt;font-weight:600;
        }
        .sec-num{opacity:.75;}
        .sec-body{padding:14px 16px 16px;}

        /* Typography */
        h2.sub-heading{font-size:11.5pt;color:var(--navy);font-weight:600;
          border-bottom:1px solid var(--border);padding-bottom:3px;margin:12px 0 6px;}
        h3.sub-heading{font-size:10.5pt;color:var(--navy);font-weight:600;margin:10px 0 4px;}
        h4.sub-heading,h5.sub-heading,h6.sub-heading{font-size:10pt;color:var(--navy-lt);font-weight:600;margin:8px 0 3px;}
        .body-text{margin:4px 0;font-size:10.5pt;}

        /* Note */
        .note{
          background:var(--note-bg);border-left:3px solid var(--note-border);
          padding:6px 10px;margin:8px 0;font-size:10pt;
          color:#1A5276;font-style:italic;border-radius:0 3px 3px 0;
        }

        /* Tables */
        .tbl-wrap{overflow-x:auto;margin:8px 0;}
        table{border-collapse:collapse;width:100%;font-size:9.5pt;}
        th{background:var(--navy);color:#fff;padding:5px 8px;text-align:left;font-weight:600;}
        td{padding:4px 8px;border-bottom:1px solid var(--border);font-size:9.5pt;}
        tr.odd td{background:var(--alt);}
        tr.even td{background:#fff;}
        .tbl-caption{font-size:9pt;color:var(--muted);margin:4px 0 2px;font-style:italic;}

        /* Formula panel — matches FormulaPanelStyle in ShearDetailView.xaml */
        .formula-panel{
          background:var(--formula-bg);border:1px solid var(--formula-border);
          border-radius:5px;padding:10px 14px;margin:8px 0;
        }
        .formula-title{
          font-size:9.5pt;color:var(--muted);font-weight:600;
          margin-bottom:7px;
        }
        .formula-main{margin:4px 0 4px 0;font-size:13pt;}
        .formula-sub{margin:3px 0 3px 10px;font-size:11pt;color:#333;}
        .formula-result{margin:3px 0 0 10px;font-size:11pt;font-weight:600;color:var(--navy-lt);}

        /* Summary box */
        .summary-box{border:2px solid;border-radius:5px;padding:12px 16px;margin:10px 0;}
        .summary-box.pass{background:var(--pass-bg);border-color:var(--pass-border);}
        .summary-box.fail{background:var(--fail-bg);border-color:var(--fail-border);}
        .summary-title{font-size:13pt;font-weight:700;margin-bottom:8px;}
        .summary-box.pass .summary-title{color:var(--pass);}
        .summary-box.fail .summary-title{color:var(--fail);}
        .summary-entries{display:flex;flex-direction:column;gap:3px;}
        .summary-row{display:flex;gap:10px;font-size:10pt;}
        .s-lbl{color:var(--muted);min-width:160px;flex-shrink:0;}
        .s-val{font-weight:600;}

        /* SVG / figures */
        .svg-wrap{text-align:center;margin:10px 0;}
        .svg-wrap svg{max-width:100%;height:auto;}
        .diagram-wrap{text-align:center;margin:10px 0;}
        .diagram-wrap svg{max-width:100%;height:auto;}
        .diagram-img{max-width:100%;height:auto;display:block;margin:0 auto;}
        .fig-caption{font-size:9pt;color:var(--muted);font-style:italic;margin:4px 0 0;text-align:center;}
        .diagram-placeholder{border:1px dashed #AAA;padding:20px;text-align:center;
          color:#888;margin:8px 0;font-size:9.5pt;font-style:italic;}

        hr.divider{border:none;border-top:1px solid var(--border);margin:10px 0;}
        @media print{body{background:#fff;padding:0;}section{box-shadow:none;}}
        """;
}

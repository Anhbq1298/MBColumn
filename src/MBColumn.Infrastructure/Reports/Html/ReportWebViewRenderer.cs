using MBColumn.Application.Reports.Models;
using MBColumn.Infrastructure.Reports.Graphics;
using System.IO;
using System.Text;
using SystemMath = System.Math;

namespace MBColumn.Infrastructure.Reports.Html;

/// <summary>
/// Builds a self-contained HTML string for the WebView2 report preview.
/// KaTeX CSS and JS are embedded inline so the page works without network access.
/// </summary>
public sealed class ReportWebViewRenderer
{
    private static readonly object KatexLock  = new();
    private static string?         _katexCss;
    private static string?         _katexJs;
    private static bool            _assetsChecked;
    private static bool            _hasAssets;

    public bool CanRender()
    {
        if (_assetsChecked) return _hasAssets;
        lock (KatexLock)
        {
            if (_assetsChecked) return _hasAssets;
            _assetsChecked = true;
            try
            {
                string root = KatexRoot();
                _hasAssets = File.Exists(Path.Combine(root, "katex.min.css"))
                          && File.Exists(Path.Combine(root, "katex.min.js"));
            }
            catch { _hasAssets = false; }
            return _hasAssets;
        }
    }

    public string BuildHtml(ReportData data)
        => BuildHtml(data, data.Sections);

    public string BuildHtml(ReportData data, IEnumerable<ReportSection> visibleSections)
    {
        (string css, string js) = LoadKatex();

        var sb = new StringBuilder(65536);
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html lang='en'><head><meta charset='utf-8'/>");
        sb.AppendLine("<meta name='viewport' content='width=device-width,initial-scale=1'/>");

        // KaTeX CSS (inline)
        if (!string.IsNullOrEmpty(css))
        {
            sb.AppendLine("<style>");
            sb.AppendLine(css);
            sb.AppendLine("</style>");
        }

        sb.AppendLine("<style>");
        sb.AppendLine(PageStyles());
        sb.AppendLine("</style>");
        sb.AppendLine("</head><body>");

        // Cover header
        sb.AppendLine("<div class='cover'>");
        sb.AppendLine("<h1>MB Column — Calculation Report</h1>");
        if (!string.IsNullOrEmpty(data.ProjectName))
            sb.AppendLine($"<p><strong>Project:</strong> {H(data.ProjectName)}</p>");
        if (!string.IsNullOrEmpty(data.GroupName))
            sb.AppendLine($"<p><strong>Group:</strong> {H(data.GroupName)}</p>");
        if (!string.IsNullOrEmpty(data.DesignTierName))
            sb.AppendLine($"<p><strong>Section:</strong> {H(data.DesignTierName)}</p>");
        sb.AppendLine($"<p class='generated'>Generated: {H(data.GeneratedAt)}</p>");
        sb.AppendLine("</div>");

        foreach (var section in visibleSections)
        {
            string anchorId = $"sec-{section.Number.Replace(".", "-")}";
            sb.AppendLine($"<section id='{anchorId}'>");
            sb.AppendLine($"<div class='section-header'><span class='sec-num'>{H(section.Number)}</span>&ensp;{H(section.Title)}</div>");
            foreach (var block in section.Blocks)
                RenderBlock(sb, block);
            sb.AppendLine("</section>");
        }

        // KaTeX auto-render script (inline)
        if (!string.IsNullOrEmpty(js))
        {
            sb.AppendLine("<script>");
            sb.AppendLine(js);
            sb.AppendLine("</script>");
        }

        // Trigger auto-rendering of all .katex-formula spans after DOM load
        sb.AppendLine("<script>");
        sb.AppendLine("""
document.addEventListener('DOMContentLoaded', function() {
  document.querySelectorAll('.katex-formula').forEach(function(el) {
    var latex  = el.getAttribute('data-latex') || '';
    var disp   = el.getAttribute('data-display') === 'true';
    if (typeof katex !== 'undefined') {
      try {
        katex.render(latex, el, { throwOnError: false, displayMode: disp, strict: 'ignore' });
      } catch(e) {
        el.textContent = latex;
      }
    } else {
      el.textContent = latex;
    }
  });
});
""");
        sb.AppendLine("</script>");
        sb.AppendLine("</body></html>");
        return sb.ToString();
    }

    // ── Block rendering ───────────────────────────────────────────────────────

    private static void RenderBlock(StringBuilder sb, ReportBlock block)
    {
        switch (block)
        {
            case HeadingBlock h:
                int lvl = SystemMath.Clamp(h.Level + 1, 2, 6);
                sb.AppendLine($"<h{lvl} class='sub-heading'>{H(h.Text)}</h{lvl}>");
                break;

            case ParagraphBlock p:
                sb.AppendLine($"<p class='body-text'>{H(p.Text)}</p>");
                break;

            case NoteBlock n:
                sb.AppendLine($"<div class='note'>{H(n.Text)}</div>");
                break;

            case FormulaBlock fb:
                RenderFormulaBlock(sb, fb);
                break;

            case TableBlock t:
                RenderTable(sb, t.Caption, t.Headers, t.Rows);
                break;

            case SteelTableBlock st:
                RenderTable(sb, st.Caption, st.Headers, st.Rows);
                break;

            case ImageBlock img:
                sb.AppendLine("<div class='svg-wrap'>");
                sb.AppendLine(img.SvgContent);
                if (!string.IsNullOrEmpty(img.Caption))
                    sb.AppendLine($"<p class='fig-caption'>{H(img.Caption)}</p>");
                sb.AppendLine("</div>");
                break;

            case DiagramBlock diag:
                try
                {
                    string diagSvg = InteractionDiagramSvgRenderer.RenderDiagram(diag, 600, 420);
                    sb.AppendLine("<div class='svg-wrap'>");
                    sb.AppendLine(diagSvg);
                    if (!string.IsNullOrEmpty(diag.Caption))
                        sb.AppendLine($"<p class='fig-caption'>{H(diag.Caption)}</p>");
                    sb.AppendLine("</div>");
                }
                catch
                {
                    sb.AppendLine($"<div class='diagram-placeholder'>[Diagram unavailable — {H(diag.Caption)}]</div>");
                }
                break;

            case SummaryBoxBlock sum:
                bool fail = sum.Ratio > 1.0;
                sb.AppendLine($"<div class='summary-box {(fail ? "fail" : "pass")}'>");
                sb.AppendLine($"<div class='summary-title'>{H(sum.Title)}</div>");
                sb.AppendLine("<div class='summary-entries'>");
                foreach (var (label, value) in sum.Entries)
                    sb.AppendLine($"<div class='summary-row'><span class='s-label'>{H(label)}</span><span class='s-value'>{H(value)}</span></div>");
                sb.AppendLine("</div></div>");
                break;

            case DividerBlock:
                sb.AppendLine("<hr class='divider'/>");
                break;

            case PageBreakBlock:
                sb.AppendLine("<div style='page-break-after:always'></div>");
                break;

            case SectionPreviewBlock sp:
                sb.AppendLine("<div class='svg-wrap'>");
                sb.AppendLine(sp.SvgContent);
                sb.AppendLine("</div>");
                break;
        }
    }

    private static void RenderFormulaBlock(StringBuilder sb, FormulaBlock fb)
    {
        sb.AppendLine("<div class='formula-block'>");
        if (!string.IsNullOrWhiteSpace(fb.Title))
            sb.AppendLine($"<div class='formula-title'>{H(fb.Title)}</div>");

        if (!string.IsNullOrWhiteSpace(fb.LatexFormula))
        {
            sb.AppendLine("<div class='formula-row formula-main'>");
            sb.AppendLine($"<span class='katex-formula' data-latex='{XmlAttr(NormLatex(fb.LatexFormula))}' data-display='true'></span>");
            sb.AppendLine("</div>");
        }

        if (!string.IsNullOrWhiteSpace(fb.SubstitutionLatex))
        {
            sb.AppendLine("<div class='formula-row formula-sub'>");
            sb.AppendLine($"<span class='katex-formula' data-latex='{XmlAttr(NormLatex(fb.SubstitutionLatex))}' data-display='false'></span>");
            sb.AppendLine("</div>");
        }

        if (!string.IsNullOrWhiteSpace(fb.ResultLatex))
        {
            sb.AppendLine("<div class='formula-row formula-result'>");
            sb.AppendLine($"<span class='katex-formula' data-latex='{XmlAttr(NormLatex(fb.ResultLatex))}' data-display='false'></span>");
            sb.AppendLine("</div>");
        }

        sb.AppendLine("</div>");
    }

    private static void RenderTable(StringBuilder sb, string caption, string[] headers, string[][] rows)
    {
        if (!string.IsNullOrEmpty(caption))
            sb.AppendLine($"<p class='tbl-caption'>{H(caption)}</p>");
        sb.AppendLine("<div class='tbl-wrap'><table>");
        sb.AppendLine("<thead><tr>");
        foreach (var h in headers)
            sb.AppendLine($"<th>{H(h)}</th>");
        sb.AppendLine("</tr></thead><tbody>");
        int rowIdx = 0;
        foreach (var row in rows)
        {
            sb.AppendLine($"<tr class='{(rowIdx % 2 == 0 ? "even" : "odd")}'>");
            foreach (var cell in row) sb.AppendLine($"<td>{H(cell)}</td>");
            sb.AppendLine("</tr>");
            rowIdx++;
        }
        sb.AppendLine("</tbody></table></div>");
    }

    // ── KaTeX loading ─────────────────────────────────────────────────────────

    private static (string css, string js) LoadKatex()
    {
        if (_katexCss is not null) return (_katexCss, _katexJs ?? "");

        lock (KatexLock)
        {
            if (_katexCss is not null) return (_katexCss, _katexJs ?? "");
            try
            {
                string root = KatexRoot();
                string fontsUri = new Uri(Path.Combine(root, "fonts") + Path.DirectorySeparatorChar).AbsoluteUri;

                _katexCss = File.ReadAllText(Path.Combine(root, "katex.min.css"))
                    .Replace("url(fonts/", "url(" + fontsUri, StringComparison.Ordinal);
                _katexJs = File.ReadAllText(Path.Combine(root, "katex.min.js"))
                    .Replace("</script", "<\\/script", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                _katexCss = "";
                _katexJs  = "";
            }
        }
        return (_katexCss, _katexJs ?? "");
    }

    private static string KatexRoot()
        => Path.Combine(AppContext.BaseDirectory, "Resources", "Math", "KaTeX");

    // ── Utility ───────────────────────────────────────────────────────────────

    private static string H(string? s)
        => s is null ? "" : System.Net.WebUtility.HtmlEncode(s);

    private static string XmlAttr(string? s)
        => s is null ? "" : s.Replace("&", "&amp;").Replace("'", "&#39;").Replace("\"", "&quot;");

    private static string NormLatex(string s)
        => (s ?? "").Replace(@"\\", @"\", StringComparison.Ordinal);

    private static int SystemMath_Clamp(int v, int lo, int hi)
        => v < lo ? lo : v > hi ? hi : v;

    // ── CSS ───────────────────────────────────────────────────────────────────

    private static string PageStyles() => """
        :root {
          --navy: #1A3A5C;
          --navy-light: #2E5F8A;
          --pass: #1E8449;
          --fail: #C0392B;
          --bg-alt: #F5F7FA;
          --border: #DDDDDD;
          --note-bg: #EBF5FB;
          --note-border: #AED6F1;
          --formula-bg: #FAFAFA;
        }
        * { box-sizing: border-box; }
        body {
          font-family: 'Segoe UI', Arial, sans-serif;
          font-size: 11pt;
          color: #222;
          margin: 0;
          padding: 16px 32px 32px;
          background: #F0F0F0;
        }
        .cover {
          background: var(--navy);
          color: white;
          padding: 20px 24px 16px;
          margin-bottom: 20px;
          border-radius: 4px;
        }
        .cover h1 { margin: 0 0 8px; font-size: 16pt; }
        .cover p  { margin: 3px 0; font-size: 10pt; }
        .cover .generated { margin-top: 10px; font-size: 9pt; opacity: 0.7; }

        section {
          background: white;
          margin-bottom: 16px;
          border-radius: 3px;
          box-shadow: 0 1px 3px rgba(0,0,0,.12);
          padding: 0 0 16px;
        }
        .section-header {
          background: var(--navy);
          color: white;
          padding: 8px 16px;
          font-size: 12pt;
          font-weight: 600;
          border-radius: 3px 3px 0 0;
          margin-bottom: 14px;
        }
        .sec-num { opacity: 0.8; }

        section > *:not(.section-header) { padding-left: 16px; padding-right: 16px; }
        section > .tbl-wrap,
        section > .svg-wrap    { padding-left: 16px; padding-right: 16px; }

        h2, h3, h4, h5, h6 {
          color: var(--navy);
          margin: 12px 0 4px;
        }
        .sub-heading { font-size: 10.5pt; border-bottom: 1px solid #DDE6F0; padding-bottom: 2px; }

        .body-text { margin: 4px 0; line-height: 1.55; }

        .note {
          background: var(--note-bg);
          border-left: 3px solid var(--note-border);
          padding: 6px 10px;
          margin: 8px 0;
          font-size: 10pt;
          color: #1A5276;
          font-style: italic;
          border-radius: 0 2px 2px 0;
        }

        /* Tables */
        .tbl-wrap { overflow-x: auto; margin: 8px 0; }
        table { border-collapse: collapse; width: 100%; font-size: 9.5pt; }
        th {
          background: var(--navy);
          color: white;
          padding: 5px 8px;
          text-align: left;
          font-weight: 600;
        }
        td { padding: 4px 8px; border-bottom: 1px solid var(--border); }
        tr.odd  td { background: var(--bg-alt); }
        tr.even td { background: white; }
        .tbl-caption {
          font-size: 9pt; color: #555; margin: 4px 0 2px;
          font-style: italic;
        }

        /* Formula blocks */
        .formula-block {
          background: var(--formula-bg);
          border: 1px solid var(--border);
          border-radius: 3px;
          padding: 8px 12px;
          margin: 8px 0;
        }
        .formula-title { font-size: 9.5pt; color: #555; font-weight: 600; margin-bottom: 6px; }
        .formula-row   { margin: 4px 0; }
        .formula-main  .katex-formula { font-size: 14pt; color: var(--navy); }
        .formula-sub   .katex-formula { font-size: 11pt; color: #444; }
        .formula-result .katex-formula { font-size: 11pt; color: var(--navy-light); font-weight: 600; }

        /* Summary box */
        .summary-box {
          border: 2px solid;
          border-radius: 4px;
          padding: 12px 16px;
          margin: 10px 0;
        }
        .summary-box.pass { background: #EAFAF1; border-color: #27AE60; }
        .summary-box.fail { background: #FDEDEC; border-color: #E74C3C; }
        .summary-title {
          font-size: 13pt;
          font-weight: 700;
          margin-bottom: 8px;
        }
        .summary-box.pass .summary-title { color: var(--pass); }
        .summary-box.fail .summary-title { color: var(--fail); }
        .summary-row { display: flex; gap: 12px; font-size: 10pt; margin: 2px 0; }
        .s-label { color: #555; min-width: 140px; }
        .s-value { font-weight: 600; }

        /* SVG / figures */
        .svg-wrap { text-align: center; margin: 10px 0; }
        .svg-wrap svg { max-width: 100%; height: auto; }
        .fig-caption { font-size: 9pt; color: #555; font-style: italic; margin: 4px 0 0; text-align: center; }

        .diagram-placeholder {
          border: 1px dashed #AAA;
          padding: 20px;
          text-align: center;
          color: #888;
          margin: 8px 0;
          font-size: 9.5pt;
          font-style: italic;
        }

        hr.divider { border: none; border-top: 1px solid var(--border); margin: 10px 0; }

        @media print {
          body { background: white; padding: 0; }
          section { box-shadow: none; }
        }
        """;
}

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace MBColumn.Presentation.Wpf.Controls.MathRendering;

public sealed class MathRenderService
{
    private static readonly Dictionary<string, string> HtmlCache = new(StringComparer.Ordinal);
    private static readonly object CacheGate = new();

    public string BuildHtml(string latex, bool displayMode, double fontSize, string textColor)
    {
        string normalizedLatex = NormalizeLatex(latex);
        string key = string.Create(CultureInfo.InvariantCulture, $"{normalizedLatex}|{displayMode}|{fontSize:0.###}|{textColor}");

        lock (CacheGate)
        {
            if (HtmlCache.TryGetValue(key, out var cached))
            {
                return cached;
            }
        }

        string template = LoadTemplate();
        string resourcesRoot = Path.Combine(AppContext.BaseDirectory, "Resources", "Math", "KaTeX");
        string css = LoadKatexCss(resourcesRoot);
        string js = LoadKatexJs(resourcesRoot);

        string html = template
            .Replace("{{KATEX_CSS}}", css, StringComparison.Ordinal)
            .Replace("{{KATEX_JS}}", js, StringComparison.Ordinal)
            .Replace("{{TEXT_COLOR}}", textColor, StringComparison.Ordinal)
            .Replace("{{FONT_SIZE}}", fontSize.ToString("0.###", CultureInfo.InvariantCulture), StringComparison.Ordinal)
            .Replace("{{MIN_HEIGHT}}", System.Math.Max(24.0, fontSize * 1.8).ToString("0.###", CultureInfo.InvariantCulture), StringComparison.Ordinal)
            .Replace("{{LATEX_JSON}}", JsonSerializer.Serialize(normalizedLatex), StringComparison.Ordinal)
            .Replace("{{DISPLAY_MODE}}", displayMode ? "true" : "false", StringComparison.Ordinal);

        lock (CacheGate)
        {
            if (HtmlCache.Count > 256)
            {
                HtmlCache.Clear();
            }
            HtmlCache[key] = html;
        }

        return html;
    }

    public bool HasLocalAssets()
    {
        string resourcesRoot = Path.Combine(AppContext.BaseDirectory, "Resources", "Math", "KaTeX");
        return File.Exists(Path.Combine(resourcesRoot, "katex.min.css"))
            && File.Exists(Path.Combine(resourcesRoot, "katex.min.js"));
    }

    public static string NormalizeLatex(string latex)
        => (latex ?? "")
            .Replace(@"\\", @"\", StringComparison.Ordinal)
            .Replace(@"\ ", @"\;", StringComparison.Ordinal);

    private static string LoadTemplate()
    {
        string templatePath = Path.Combine(AppContext.BaseDirectory, "Resources", "Math", "katex-template.html");
        if (File.Exists(templatePath))
        {
            return File.ReadAllText(templatePath);
        }

        Debug.WriteLine("KaTeX template is missing. Using inline fallback template.");
        return """
<!DOCTYPE html><html><head><meta charset="utf-8" />
<style>{{KATEX_CSS}}</style>
<style>html,body{margin:0;padding:0;background:transparent;overflow:hidden;color:{{TEXT_COLOR}};font-family:"Arial","Segoe UI",sans-serif}.math-container{display:flex;align-items:center;min-height:{{MIN_HEIGHT}}px;font-size:{{FONT_SIZE}}px;line-height:1.35}.katex{color:{{TEXT_COLOR}};font-size:1em}.katex .katex-mathit,.katex .mathdefault{font-family:"Arial","Segoe UI",sans-serif;font-style:italic}.katex .mord,.katex .mop,.katex .mbin,.katex .mrel,.katex .mpunct,.katex .mopen,.katex .mclose,.katex .minner{font-family:"Arial","Segoe UI",sans-serif}.katex .mtext,.katex .text{font-family:"Arial","Segoe UI",sans-serif;font-style:normal}</style>
</head><body><div id="math" class="math-container"></div><script>{{KATEX_JS}}</script><script>
function report(t,p){if(window.chrome&&window.chrome.webview){window.chrome.webview.postMessage(Object.assign({type:t},p||{}));}}
window.addEventListener('wheel',function(e){report("wheel",{deltaY:e.deltaY,deltaX:e.deltaX});},{passive:true});
try{katex.render({{LATEX_JSON}},document.getElementById("math"),{throwOnError:false,displayMode:{{DISPLAY_MODE}},strict:"ignore"});document.fonts.ready.then(function(){report("rendered",{width:Math.ceil(document.body.scrollWidth),height:Math.ceil(document.body.scrollHeight)});});}catch(e){report("error",{message:e&&e.message?e.message:"KaTeX render failed"});}
</script></body></html>
""";
    }

    private static string LoadKatexCss(string resourcesRoot)
    {
        string cssPath = Path.Combine(resourcesRoot, "katex.min.css");
        string fontsUri = new Uri(Path.Combine(resourcesRoot, "fonts") + Path.DirectorySeparatorChar).AbsoluteUri;
        return File.ReadAllText(cssPath)
            .Replace("url(fonts/", "url(" + fontsUri, StringComparison.Ordinal);
    }

    private static string LoadKatexJs(string resourcesRoot)
    {
        string jsPath = Path.Combine(resourcesRoot, "katex.min.js");
        return File.ReadAllText(jsPath)
            .Replace("</script", "<\\/script", StringComparison.OrdinalIgnoreCase);
    }
}

using MBColumn.Domain.Enums;
using MBColumn.Infrastructure.Etabs;
using System.Text;

// ── Connect ───────────────────────────────────────────────────────────────────
var connection = new EtabsConnectionService();
var result = connection.ConnectToRunningEtabs();

if (!result.IsConnected)
{
    Console.WriteLine($"[FAIL] {result.Message}");
    return;
}

var info = result.ModelInfo!;
Console.WriteLine($"[OK] Connected: {info.ModelName}");
Console.WriteLine($"     Units : {info.PresentUnits}");
Console.WriteLine($"     Stories: {info.StoryCount}  Piers: {info.PierCount}");
Console.WriteLine();

// ── Dump all CW1 pier+story groups ───────────────────────────────────────────
var pierService = new EtabsPierShellImportService(connection);
var builder     = new IrregularPierGeometryBuilder();

var allGroups = pierService.GetPierGroups(UnitSystem.Metric);
Console.WriteLine("All groups containing 'CW1':");
foreach (var (pl, sn, sp) in allGroups.Where(g => g.PierLabel.Contains("CW1", StringComparison.OrdinalIgnoreCase)))
    Console.WriteLine($"  Pier={pl,-20}  Story={sn,-15}  Prop={sp}  " +
                      $"Shells={pierService.GetSegments(pl, sn, UnitSystem.Metric).Count}");
Console.WriteLine();

string pierLabel = "CW99";
string storyName = "L01";

var segments = pierService.GetSegments(pierLabel, storyName, UnitSystem.Metric);

if (segments.Count == 0)
{
    // Try case-insensitive variants – ETABS labels are sometimes upper/lower mixed
    var groups = pierService.GetPierGroups(UnitSystem.Metric);
    Console.WriteLine("No segments found for CW1 / LL01.");
    Console.WriteLine($"Available pier+story groups ({groups.Count} total):");
    foreach (var (pl, sn, sp) in groups.Take(30))
        Console.WriteLine($"  Pier={pl,-20}  Story={sn,-15}  Prop={sp}");
    return;
}

Console.WriteLine($"[OK] {segments.Count} shell segment(s) for {pierLabel} / {storyName}:");
foreach (var s in segments)
    Console.WriteLine($"  Shell={s.ShellName,-12}  T={s.ThicknessMm,6:F1} mm" +
                      $"  ({s.Start.X,8:F1}, {s.Start.Y,8:F1})→({s.End.X,8:F1}, {s.End.Y,8:F1})");
Console.WriteLine();

// ── Build boundary ────────────────────────────────────────────────────────────
var boundary = builder.BuildBoundary(segments);

if (boundary.IsEmpty)
{
    Console.WriteLine($"[WARN] Geometry builder returned empty: {boundary.WarningMessage}");
    return;
}

if (!string.IsNullOrEmpty(boundary.WarningMessage))
    Console.WriteLine($"[WARN] {boundary.WarningMessage}");

var poly = boundary.ClockwisePolylines[0];
Console.WriteLine($"Boundary: {poly.Count} vertices  " +
                  $"(x: {poly.Min(p => p.X):F1}…{poly.Max(p => p.X):F1} mm, " +
                  $"y: {poly.Min(p => p.Y):F1}…{poly.Max(p => p.Y):F1} mm)");

if (boundary.HasOpenings)
{
    Console.WriteLine($"Openings: {boundary.OpeningPolylines.Count} void(s) detected");
    for (int i = 0; i < boundary.OpeningPolylines.Count; i++)
    {
        var op = boundary.OpeningPolylines[i];
        Console.WriteLine($"  Opening [{i+1}]: {op.Count} vertices  " +
                          $"(x: {op.Min(p => p.X):F1}…{op.Max(p => p.X):F1}, " +
                          $"y: {op.Min(p => p.Y):F1}…{op.Max(p => p.Y):F1})");
        for (int j = 0; j < op.Count; j++)
            Console.WriteLine($"    [{j+1}]  x={op[j].X,9:F2}  y={op[j].Y,9:F2}");
    }
}
Console.WriteLine();

// ── ASCII art render ──────────────────────────────────────────────────────────
const int W = 72;
const int H = 36;

double minX = poly.Min(p => p.X);
double maxX = poly.Max(p => p.X);
double minY = poly.Min(p => p.Y);
double maxY = poly.Max(p => p.Y);

double spanX = maxX - minX;
double spanY = maxY - minY;

// Add 5 % margin
double padX = spanX * 0.05 + 1;
double padY = spanY * 0.05 + 1;
minX -= padX; maxX += padX;
minY -= padY; maxY += padY;
spanX = maxX - minX;
spanY = maxY - minY;

// Map world → grid
int ToCol(double x) => (int)Math.Round((x - minX) / spanX * (W - 1));
int ToRow(double y) => H - 1 - (int)Math.Round((y - minY) / spanY * (H - 1));

var grid = new char[H, W];
for (var r = 0; r < H; r++)
    for (var c = 0; c < W; c++)
        grid[r, c] = ' ';

// Draw axes (zero lines if in range)
if (minX <= 0 && maxX >= 0)
{
    int c0 = ToCol(0);
    for (var r = 0; r < H; r++) grid[r, c0] = '|';
}
if (minY <= 0 && maxY >= 0)
{
    int r0 = ToRow(0);
    for (var c = 0; c < W; c++) grid[r0, c] = '-';
}

// Draw polygon edges via line rasterisation
void DrawLine(int x0, int y0, int x1, int y1, char ch)
{
    int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
    int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
    int err = dx + dy;
    while (true)
    {
        if (x0 >= 0 && x0 < W && y0 >= 0 && y0 < H)
            grid[y0, x0] = ch;
        if (x0 == x1 && y0 == y1) break;
        int e2 = 2 * err;
        if (e2 >= dy) { err += dy; x0 += sx; }
        if (e2 <= dx) { err += dx; y0 += sy; }
    }
}

for (var i = 0; i < poly.Count; i++)
{
    var a = poly[i];
    var b = poly[(i + 1) % poly.Count];
    DrawLine(ToCol(a.X), ToRow(a.Y), ToCol(b.X), ToRow(b.Y), '*');
}

// Mark vertices
foreach (var p in poly)
{
    int r = ToRow(p.Y), c = ToCol(p.X);
    if (r >= 0 && r < H && c >= 0 && c < W)
        grid[r, c] = 'o';
}

// Print
var sb = new StringBuilder();
sb.AppendLine($"  Pier {pierLabel}  /  Story {storyName}  —  {poly.Count} pts, centroid origin");
sb.AppendLine(new string('─', W + 4));
for (var r = 0; r < H; r++)
{
    sb.Append("  |");
    for (var c = 0; c < W; c++)
        sb.Append(grid[r, c]);
    sb.AppendLine("|");
}
sb.AppendLine(new string('─', W + 4));
Console.WriteLine(sb);

// Print vertex table
Console.WriteLine("  Vertices (centroid-origin mm):");
for (var i = 0; i < poly.Count; i++)
    Console.WriteLine($"  [{i + 1,3}]  x={poly[i].X,9:F2}  y={poly[i].Y,9:F2}");

// ── PNG render ────────────────────────────────────────────────────────────────
{
    const int ImgW = 1000, ImgH = 800, Margin = 70;

    double wMinX = poly.Min(p => p.X), wMaxX = poly.Max(p => p.X);
    double wMinY = poly.Min(p => p.Y), wMaxY = poly.Max(p => p.Y);

    double pngPadX = (wMaxX - wMinX) * 0.08 + 1;
    double pngPadY = (wMaxY - wMinY) * 0.08 + 1;
    double vMinX = wMinX - pngPadX, vMaxX = wMaxX + pngPadX;
    double vMinY = wMinY - pngPadY, vMaxY = wMaxY + pngPadY;

    double scale = Math.Min((ImgW - 2 * Margin) / (vMaxX - vMinX),
                            (ImgH - 2 * Margin) / (vMaxY - vMinY));
    double cx = (vMinX + vMaxX) / 2, cy = (vMinY + vMaxY) / 2;
    int icx = ImgW / 2, icy = ImgH / 2;

    int Ix(double x) => (int)Math.Round(icx + (x - cx) * scale);
    int Iy(double y) => (int)Math.Round(icy - (y - cy) * scale);

    using var bmp = new System.Drawing.Bitmap(ImgW, ImgH);
    using var g = System.Drawing.Graphics.FromImage(bmp);
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    g.Clear(System.Drawing.Color.White);

    using var axisPen  = new System.Drawing.Pen(System.Drawing.Color.LightGray, 1);
    using var gridPen  = new System.Drawing.Pen(System.Drawing.Color.FromArgb(230, 230, 230), 1);
    using var borderPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(200, 200, 200), 1);

    // Grid every 2 000 mm
    for (double gx = Math.Ceiling(vMinX / 2000) * 2000; gx <= vMaxX; gx += 2000)
        g.DrawLine(gridPen, Ix(gx), Margin, Ix(gx), ImgH - Margin);
    for (double gy = Math.Ceiling(vMinY / 2000) * 2000; gy <= vMaxY; gy += 2000)
        g.DrawLine(gridPen, Margin, Iy(gy), ImgW - Margin, Iy(gy));

    // Axes
    if (vMinX <= 0 && vMaxX >= 0) g.DrawLine(axisPen, Ix(0), Margin, Ix(0), ImgH - Margin);
    if (vMinY <= 0 && vMaxY >= 0) g.DrawLine(axisPen, Margin, Iy(0), ImgW - Margin, Iy(0));

    // Border
    g.DrawRectangle(borderPen, Margin, Margin, ImgW - 2 * Margin, ImgH - 2 * Margin);

    // Filled polygon
    var pts = poly.Select(p => new System.Drawing.PointF(Ix(p.X), Iy(p.Y))).ToArray();
    using var fill = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(60, 65, 105, 225));
    g.FillPolygon(fill, pts);
    using var edgePen = new System.Drawing.Pen(System.Drawing.Color.RoyalBlue, 2.5f);
    g.DrawPolygon(edgePen, pts);

    // Vertices
    foreach (var p in pts)
        using (var vb = new System.Drawing.SolidBrush(System.Drawing.Color.DarkBlue))
            g.FillEllipse(vb, p.X - 3, p.Y - 3, 6, 6);

    // Title
    using var titleFont = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold);
    using var subFont   = new System.Drawing.Font("Arial", 9);
    g.DrawString($"Pier {pierLabel}  /  Story {storyName}  —  {poly.Count} vertices  (centroid origin, mm)",
        titleFont, System.Drawing.Brushes.Black, Margin, 14);
    g.DrawString($"x: {wMinX:F0}…{wMaxX:F0}  |  y: {wMinY:F0}…{wMaxY:F0}  |  T = 650 mm",
        subFont, System.Drawing.Brushes.Gray, Margin, 34);

    // Axis labels
    if (vMinX <= 0 && vMaxX >= 0)
        g.DrawString("0", subFont, System.Drawing.Brushes.Gray, Ix(0) + 3, ImgH - Margin + 3);
    if (vMinY <= 0 && vMaxY >= 0)
        g.DrawString("0", subFont, System.Drawing.Brushes.Gray, Margin - 20, Iy(0) - 7);

    string pngPath = Path.Combine(Path.GetTempPath(), "pier_cw1_l01.png");
    bmp.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);
    Console.WriteLine($"[PNG] {pngPath}");
}

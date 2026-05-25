using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Infrastructure.Etabs;

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
Console.WriteLine();

// ── Get columns filtered to C198 and C200 ────────────────────────────────────
var columnService = new EtabsColumnImportService(connection);
var designImport  = new EtabsDesignForceImportService(connection);

var allColumns = columnService.GetCandidateColumns(UnitSystem.Metric);
var targetLabels = new HashSet<string>(["C3"], StringComparer.OrdinalIgnoreCase);
var selectedColumns = allColumns.Where(c => targetLabels.Contains(c.Label)).ToList();

Console.WriteLine($"Found {selectedColumns.Count} column object(s) matching C198/C200:");
foreach (var c in selectedColumns)
    Console.WriteLine($"  Object={c.ObjectName,-14}  Story={c.StoryName,-12}  Label={c.Label,-8}  Section={c.EtabsSectionName}");
Console.WriteLine();

if (selectedColumns.Count == 0)
{
    Console.WriteLine("No C198/C200 columns found. Available labels:");
    foreach (var lbl in allColumns.Select(c => c.Label).Distinct().OrderBy(x => x).Take(40))
        Console.WriteLine($"  {lbl}");
    return;
}

// ── Preload raw design force table ──────────────────────────────────────────
Console.WriteLine("Preloading raw design force tables from ETABS...");
var db = designImport.ImportDesignForces(info.ModelPath, info.ModelName, MBColumn.Domain.Enums.UnitSystem.Metric);

var colTable = db.ColumnForces;
Console.WriteLine($"Column design table: '{colTable.TableKey}'  records={colTable.Records.Count}  fields=[{string.Join(", ", colTable.FieldKeys)}]");
Console.WriteLine();

var elemTable = db.ColumnElementForces;
Console.WriteLine($"Column element table: '{elemTable.TableKey}'  records={elemTable.Records.Count}  fields=[{string.Join(", ", elemTable.FieldKeys)}]");
Console.WriteLine();

if (!colTable.HasRecords)
{
    Console.WriteLine("No column design force records found. Has the model been designed in ETABS?");
    return;
}

// Find which combos appear for C198 / C200
var comboField  = colTable.FieldKeys.FirstOrDefault(f => f.Contains("Combo", StringComparison.OrdinalIgnoreCase) || f.Contains("Design", StringComparison.OrdinalIgnoreCase)) ?? "";
var labelField  = colTable.FieldKeys.FirstOrDefault(f => f.Equals("Label", StringComparison.OrdinalIgnoreCase) || f.Equals("Column", StringComparison.OrdinalIgnoreCase) || f.Equals("UniqueName", StringComparison.OrdinalIgnoreCase)) ?? "";
var storyField  = colTable.FieldKeys.FirstOrDefault(f => f.Equals("Story", StringComparison.OrdinalIgnoreCase)) ?? "";

Console.WriteLine($"Key fields → Story='{storyField}'  Label='{labelField}'  Combo='{comboField}'");
Console.WriteLine();

// Collect all combos that appear in rows for C198 or C200
var combosInDesign = colTable.Records
    .Where(r => !string.IsNullOrEmpty(labelField) && targetLabels.Contains(r.Fields.GetValueOrDefault(labelField, "")))
    .Select(r => r.Fields.GetValueOrDefault(comboField, "").Trim())
    .Where(c => !string.IsNullOrEmpty(c))
    .Distinct(StringComparer.OrdinalIgnoreCase)
    .OrderBy(x => x)
    .ToList();

Console.WriteLine($"Combos available in design table for C198/C200 ({combosInDesign.Count} total):");
foreach (var c in combosInDesign.Take(20))
    Console.WriteLine($"  {c}");
if (combosInDesign.Count > 20) Console.WriteLine($"  ... and {combosInDesign.Count - 20} more");
Console.WriteLine();

// Pick first 5 combos that are actually in design results
var selectedCombos = combosInDesign.Take(5).ToList();
if (selectedCombos.Count == 0)
{
    Console.WriteLine("No design combos found for C198/C200. Showing first 5 raw records:");
    foreach (var r in colTable.Records.Take(5))
        Console.WriteLine("  " + string.Join("  |  ", r.Fields.Select(kv => $"{kv.Key}={kv.Value}")));
    return;
}

Console.WriteLine($"Using combos: {string.Join(", ", selectedCombos)}");
Console.WriteLine();

// ── Parse forces from cached raw table ──────────────────────────────────────
var forces = designImport.ParseColumnElementForces(db, selectedColumns, selectedCombos, UnitSystem.Metric);

Console.WriteLine($"Returned {forces.Count} force row(s).");
Console.WriteLine();

if (forces.Count == 0)
{
    Console.WriteLine("Still 0 forces. Dumping first 10 raw records to diagnose:");
    foreach (var r in colTable.Records.Take(10))
        Console.WriteLine("  " + string.Join("  |  ", r.Fields.Select(kv => $"{kv.Key}={kv.Value}")));
    return;
}

// ── Print table ───────────────────────────────────────────────────────────────
var colW = new[] { 42, 22, 12, 10, 10, 10, 10 };
string Pad(string s, int w)  => s.Length >= w ? s[..w] : s.PadRight(w);
string PadR(string s, int w) => s.Length >= w ? s[..w] : s.PadLeft(w);

var header = Pad("LoadcaseMBname", colW[0]) +
             Pad("LOADCASE",       colW[1]) +
             Pad("STORY",          colW[2]) +
             Pad("Col Label",      colW[3]) +
             PadR("P",             colW[4]) +
             PadR("mx",            colW[5]) +
             PadR("my",            colW[6]);

Console.WriteLine(header);
Console.WriteLine(new string('-', colW.Sum()));

foreach (var f in forces
    .OrderBy(f => f.LoadCombination)
    .ThenBy(f => f.StoryName)
    .ThenBy(f => f.Label)
    .ThenBy(f => f.Station))
{
    var mbName = $"{f.LoadCombination}_{f.StoryName}_{f.Label}_{f.Station}";
    var row = Pad(mbName,            colW[0]) +
              Pad(f.LoadCombination, colW[1]) +
              Pad(f.StoryName,       colW[2]) +
              Pad(f.Label,           colW[3]) +
              PadR($"{f.P:F2}",      colW[4]) +
              PadR($"{f.M2:F2}",     colW[5]) +
              PadR($"{f.M3:F2}",     colW[6]);
    Console.WriteLine(row);
}

Console.WriteLine();
Console.WriteLine($"Total: {forces.Count} rows  ({selectedColumns.Count} objects × {selectedCombos.Count} combos × stations)");

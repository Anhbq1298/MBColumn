# MBColumn PMM Apple-to-Apple Verification Test

## Overview

The MBColumn PMM apple-to-apple verification test compares calculated PMM (Pressure-Moment-Moment) interaction curves against reference data using strict engineering tolerances.

**Purpose:** Validate that MBColumn produces accurate PMM capacity curves within acceptable numerical tolerances.

**Output:** Generates a comprehensive PDF report with statistical comparison tables and engineering analysis.

## Test Framework Architecture

The verification framework consists of specialized services, each with a single responsibility:

### 1. **PmmComparisonRunner** (`PmmComparisonRunner.cs`)
**Role:** Orchestrates the entire comparison pipeline

**Responsibilities:**
- Loads reference PMM data from CSV
- Runs MBColumn PMM solver
- Converts solver output to comparison format
- Delegates to matcher and report writer
- Returns final report object

**Input:**
- `ColumnCalculationService`: The PMM solver
- `ColumnInputDto`: Section geometry, material, reinforcement
- `referenceCsvPath`: Path to reference data (Theta,PointIndex,RefP,RefMx,RefMy)
- `pdfOutputPath`: Where to save the report PDF

**Output:**
- `PmmComparisonReport`: Complete report with all statistics

### 2. **PmmPointMatcher** (`PmmPointMatcher.cs`)
**Role:** Matches calculated points with reference points

**Matching Strategy:**
1. Group points by theta angle (load case direction)
2. For each theta:
   - If point counts match: Use index-based matching (fast, direct)
   - If point counts differ: Use nearest-neighbor matching (robust, normalized P-M distance)

**Normalized Distance Formula:**
```
distance = sqrt((ΔP/pScale)² + (ΔM/mScale)²)
```
Where `pScale` and `mScale` normalize by the reference data range.

**Output:** List of matched comparisons by theta

### 3. **PmmDifferenceCalculator** (`PmmDifferenceCalculator.cs`)
**Role:** Calculates differences and applies acceptance logic

**Difference Calculation:**
```
DiffP = CalcP - RefP
DiffM = CalcM - RefM
PercentDiffP = (CalcP - RefP) / RefP × 100
PercentDiffM = (CalcM - RefM) / RefM × 100
```

**Dual Tolerance Acceptance Logic** (per point):
```
P_PASS = (abs(%DiffP) ≤ 5%) OR (abs(DiffP) ≤ 25 kN)
M_PASS = (abs(%DiffM) ≤ 5%) OR (abs(DiffM) ≤ 25 kNm)
POINT_PASS = P_PASS AND M_PASS
```

**Near-Zero Handling:**
- If `abs(RefP) < 1e-6`: Skip percent diff, use absolute only
- If `abs(RefM) < 1e-6`: Skip percent diff, use absolute only
- Prevents false failures on low-magnitude reference values

### 4. **PmmStatisticsCalculator** (`PmmStatisticsCalculator.cs`)
**Role:** Computes statistical measures for each theta

**Calculated per theta:**
```
Mean %DiffP = average(all valid %DiffP values)
Variance %DiffP = average((value - mean)²)
StdDev %DiffP = sqrt(variance)
MaxAbsPercentDiffP = maximum absolute % difference
MaxAbsDiffP = maximum absolute difference (in units)
PassCount = number of points that passed
FailCount = number of points that failed
```

Same calculations repeated for M values.

### 5. **PdfReportWriter** (`PdfReportWriter.cs`)
**Role:** Generates PDF report with all sections

**Report Sections:**
1. **Cover Page** – Metadata (date, section, materials, reinforcement, units)
2. **Summary Page** – Overall statistics and conclusions
3. **Detailed Theta Tables** – One table per theta angle with:
   - Point Index, Theta, RefP, CalcP, DiffP, %DiffP
   - RefM, CalcM, DiffM, %DiffM
   - P/M/Overall status (PASS/FAIL)
   - Theta statistics (mean, variance, stddev, max, pass count)
4. **Final Analysis** – Engineering interpretation

**PDF Format:** Low-level PDF 1.4 generation (no external library), text-based tables

## Data Format

### Reference CSV Format
Required columns (in order):
```
Theta, PointIndex, RefP, RefMx, RefMy
```

**Units:** Internal units (N, N-mm, N-mm)
- **Theta**: Integer degrees (0-359)
- **PointIndex**: Integer starting at 0
- **RefP**: Axial force in Newtons (positive = compression)
- **RefMx**: Moment about X in N-mm (Mx = force × y)
- **RefMy**: Moment about Y in N-mm (My = force × x)

**Example:**
```csv
Theta,PointIndex,RefP,RefMx,RefMy
0,0,1000000.0000,0.0000,50000000.0000
0,1,500000.0000,100000000.0000,0.0000
90,0,900000.0000,0.0000,45000000.0000
```

### Calculated Points (from solver)
MBColumn `InteractionSurface.Points`:
- `ThetaDegrees`: Angle
- `DepthIndex`: Point sequence (becomes PointIndex)
- `Pn`: Axial force (internal units)
- `Mnx`: Moment X component (internal units)
- `Mny`: Moment Y component (internal units)

## Acceptance Criteria

### Point-Level
A point **PASSES** if:
- P difference passes threshold (5% OR 25 kN absolute)
- **AND** M difference passes threshold (5% OR 25 kNm absolute)

A point **FAILS** if:
- Either P or M exceeds both thresholds
- Indicates systematic error or calculation bug

### Test-Level (Program.cs TestPmmAppleToAppleComparison)
Test **PASSES** if:
- ✓ Report has at least one theta
- ✓ Report has at least one matched point
- ✓ PDF file is generated successfully

Note: Individual point failures do NOT fail the test; they're recorded in the report for engineering review.

## Running the Test

### From Command Line
```bash
# Run full test suite (includes PMM comparison)
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj

# Run only PMM comparison test
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj --filter "PMM apple-to-apple"

# Generate report interactively
dotnet run --project tests\MBColumn.Tests\MBColumn.Tests.csproj -- --run-pmm-comparison
```

### From C# (Programmatic)
```csharp
var runner = new PmmComparisonRunner();
var report = runner.Run(
    calculationService,
    columnInput,
    "path/to/reference.csv",
    "path/to/output.pdf",
    options: new PmmComparisonOptions(
        PercentTolerance: 5.0,
        AbsoluteAxialTolerance: 25.0,
        AbsoluteMomentTolerance: 25.0,
        ZeroReferenceThreshold: 1e-6));
```

## Output Interpretation

### Overall Conclusion
- **PASS**: Zero failed points AND zero missing points
- **FAIL**: Any failed points OR missing points

### Systematic Errors
Check for patterns:
- **Constant offset**: Systematic bias in one calculation
- **Proportional error**: Scale factor difference (unit conversion, design code)
- **Sign flip**: Convention mismatch (compression/tension, moment direction)
- **Regional error**: Fails only at high/low load or specific angles

### PDF Report Path
Default location: `tests/MBColumn.Tests/Reports/PmmComparisonReport.pdf`

## Test Case Definition

### Default Test Section (MetricInput)
- **Geometry**: 700 mm × 700 mm square
- **Cover**: 55 mm
- **Reinforcement**: 28 × T25 bars in perimeter layout
- **Concrete**: 420 MPa (nominal, internal)
- **Steel**: 200,000 MPa elastic modulus
- **Units**: Metric (kN, mm, MPa, kNm)
- **Load Case**: Pu = 2500 kN, Mux = 250 kNm, Muy = 180 kNm

### Reference Data (EC2)
- Source: `docs/validation/ec2-fiber-pmm-sconcrete-generated-curves.csv` (full format)
- Converted to: `docs/validation/ec2-fiber-pmm-reference-simple.csv` (5-column format)
- Covers: All 360 degrees (1° steps), multiple neutral axis depths
- Design Code: Eurocode 2 (EC2) simplified stress block

## Known Limitations

1. **Point Ordering**: If calculated depth/mesh differs from reference, nearest-neighbor matching is used and clearly marked in report.
2. **Moment Convention**: Sign conventions must align exactly; systematic sign error would appear immediately in report.
3. **Unit Conversion**: Reference CSV is converted at load time; if source uses different units, conversion must be updated.
4. **PMM Surface Topology**: Test only validates already-computed points; does not detect interpolation errors between points.

## Future Enhancements

- [ ] Support for multi-load case scenarios
- [ ] Confidence intervals around tolerance bands
- [ ] Comparative surface visualization (reference vs calculated)
- [ ] Automated Gemini reference extraction from .docx
- [ ] Historical trend tracking across versions

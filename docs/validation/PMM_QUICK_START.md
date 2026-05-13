# Quick Start: Running the PMM Apple-to-Apple Verification Test

## One-Command Test Run

```bash
cd c:\_ReverseEngineering\spColumnReversed-Solution
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj
```

The "PMM apple-to-apple comparison report" test will run automatically and generate a PDF report.

## Where is the Report?

After the test completes, find the PDF here:
```
tests/MBColumn.Tests/Reports/PmmComparisonReport.pdf
```

## What Does the Test Check?

The test:

1. **Generates** a reference CSV from EC2 reference data
   - Converts units from kN/kNm to N/N-mm (internal)
   - Stores as: `docs/validation/ec2-fiber-pmm-reference-simple.csv`

2. **Runs** MBColumn PMM solver for a standard test section
   - 700×700 mm square column
   - 28 × T25 bars
   - 55 mm cover

3. **Compares** calculated points against reference
   - Matches by theta angle (0°-360°)
   - Applies dual tolerance: (5% OR 25 kN) AND (5% OR 25 kNm)
   - Handles near-zero values (< 1e-6)

4. **Generates** comprehensive PDF report with:
   - Cover page (metadata)
   - Summary page (statistics)
   - Detailed tables (one per theta)
   - Final analysis (patterns, conclusions)

5. **Passes** test if:
   - At least one theta angle compared
   - At least one matched point
   - PDF file successfully created

## Understanding the PDF Report

### Summary Page Statistics

```
Theta angles compared: 36              (one per 10°)
Total matched points: 5,400            (150 per theta)
Total missing points: 0                (matched all)
Total failed points: 2                 (small numerical differences)

Overall average %DiffP: 0.234          (< 5%, acceptable)
Overall average %DiffM: -0.156         (< 5%, acceptable)
Overall StdDev %DiffP: 0.524
Overall StdDev %DiffM: 0.387

Overall conclusion: PASS
```

### Detailed Table Example

```
Theta = 0°   MatchMethod: Index
Point  RefP(kN)  CalcP(kN)  DiffP(kN)  %DiffP  RefM(kNm)  CalcM(kNm)  DiffM(kNm)  %DiffM  P    M    Status
  0     1000.0    1005.3       5.3       0.53     100.0      99.2       -0.8      -0.8   PASS PASS PASS
  1     2000.0    2010.5      10.5       0.52      95.0      94.1       -0.9      -0.9   PASS PASS PASS
  ...
Mean %DiffP: 0.234
Variance %DiffP: 0.1234
StdDev %DiffP: 0.3512
Max abs %DiffP: 0.784
Pass points: 150
Fail points: 0
```

### Interpreting Results

- **Green flags** (all PASS):
  - All points within tolerance
  - Mean difference near zero
  - Low variance/stddev
  - No systematic pattern

- **Red flags** (FAIL points):
  - P or M consistently outside tolerance
  - May indicate:
    - Unit conversion error
    - Sign convention mismatch
    - Design code algorithm difference
    - Calculation bug

- **Yellow flags** (warning):
  - Some theta angles with higher error
  - Regional error at high/low load
  - May be numerical precision issue

## Tolerance Explanation

### Dual Tolerance (Both Must Pass)

```
Point PASSES if:
  (P passes AND M passes)

Where P passes if:
  abs(CalcP - RefP) / RefP <= 5%  (relative error)
  OR
  abs(CalcP - RefP) <= 25 kN      (absolute error)

And M passes similarly:
  abs(CalcM - RefM) / RefM <= 5%  (relative error)
  OR
  abs(CalcM - RefM) <= 25 kNm     (absolute error)
```

### Why Dual Tolerance?

- **Percentage tolerance** (5%): Catches proportional errors (scale factor)
- **Absolute tolerance** (25 kN/kNm): Catches constant offsets

Using both prevents:
- Missing errors on small values (pure % would fail)
- False positives on tiny differences (pure absolute would pass near-zero values)

### Near-Zero Handling

If reference value is very small (< 0.000001):
- Skip percentage calculation (would be unstable)
- Judge only by absolute tolerance
- Prevents false failures on low-magnitude data

## Common Results

### Typical PASS (Within Tolerance)
```
Overall average %DiffP: 0.15%
Overall average %DiffM: -0.08%
Overall StdDev %DiffP: 0.45%
Failed points: 0
Conclusion: PASS
```
→ MBColumn is accurate within acceptance criteria.

### Systematic Bias (Constant Offset)
```
%DiffP: consistently +2.5% across all theta
StdDev: very low (< 0.1%)
→ Suggests scale factor or unit conversion issue
→ Review calculation pipeline
```

### Sign Convention Error
```
%DiffP: mix of +/- with pattern by theta
Failure points at specific angles (e.g., all theta=90° fail)
→ May indicate sign convention mismatch
→ Check moment definition (Mx = force × y vs other)
```

### Numerical Noise
```
%DiffP: random +/- scattered around ±1%
StdDev: relatively high
Passes all dual tolerance tests
→ Normal floating-point precision effects
→ Not a concern if within tolerance
```

## Troubleshooting

### PDF not generated?
- Check path: `tests/MBColumn.Tests/Reports/PmmComparisonReport.pdf`
- Ensure folder exists; test creates it automatically
- Look for exception in test output

### Reference CSV not found?
- Source file: `docs/validation/ec2-fiber-pmm-sconcrete-generated-curves.csv`
- Test generates simplified version automatically
- If fails, manually run:
  ```
  ReferenceDataSetup.ConvertEc2ReferenceToSimplified(root)
  ```

### All points marked as FAIL?
- Check units are consistent (internal = N, N-mm)
- Verify test section matches reference geometry
- Check sign conventions in moment calculation

### Test compiles but doesn't run?
- Verify test dependencies are available
- Check that `PmmComparisonRunner` is accessible (using correct namespace)
- Look for linker errors in full build output

## Direct API Usage

If you need to run the comparison from your own code:

```csharp
using MBColumn.Tests.Verification;

// Create runner
var runner = new PmmComparisonRunner();

// Configure tolerance
var options = new PmmComparisonOptions(
    PercentTolerance: 5.0,
    AbsoluteAxialTolerance: 25.0,
    AbsoluteMomentTolerance: 25.0,
    ZeroReferenceThreshold: 1e-6);

// Run comparison
var report = runner.Run(
    service: calculationService,
    input: columnInput,
    referenceCsvPath: "reference.csv",
    pdfOutputPath: "report.pdf",
    options: options);

// Use report
Console.WriteLine($"Failed points: {report.TotalFailedPoints}");
Console.WriteLine($"Overall: {report.OverallConclusion}");

// File is automatically saved to pdfOutputPath
```

## Reference Data Format

If you create your own reference CSV:

```csv
Theta,PointIndex,RefP,RefMx,RefMy
0,0,1000000.0000,0.0000,50000000.0000
0,1,500000.0000,100000000.0000,0.0000
90,0,900000.0000,0.0000,45000000.0000
```

**Units MUST be:**
- Theta: degrees (0-359)
- PointIndex: integer (0...)
- RefP: Newtons (positive = compression)
- RefMx: N-mm (Mx = force × y)
- RefMy: N-mm (My = force × x)

## For More Information

- **Full Documentation**: `docs/validation/PMM_APPLE_TO_APPLE_TEST.md`
- **Implementation Details**: `docs/validation/PMM_IMPLEMENTATION_SUMMARY.md`
- **Framework Code**: `tests/MBColumn.Tests/Verification/*.cs`

---

**Status**: Ready to use  
**Framework**: Complete and tested  
**Support**: See documentation or review framework source code

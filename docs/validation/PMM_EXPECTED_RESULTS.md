# PMM Verification Test - Expected Results & Validation Guide

## What to Expect When You Run the Test

### Console Output

When you run the test, you should see output like this:

```
PMM apple-to-apple comparison report ... PASS

=== PMM Apple-to-Apple Comparison Report ===
Theta angles: 36
Matched points: 5400
Missing points: 0
Failed points: 0 to 5 (depends on numerical precision)
Overall: PASS
PDF Report: c:\...\MBColumn\tests\MBColumn.Tests\Reports\PmmComparisonReport.pdf
```

**Key indicators of success:**
- ✅ Test completes without exception
- ✅ Theta angles > 0 (at least one angle compared)
- ✅ Matched points > 0 (at least one point matched)
- ✅ PDF file is created
- ✅ Console output prints summary

---

## PDF Report Structure

### Example Report Contents

**File**: `tests/MBColumn.Tests/Reports/PmmComparisonReport.pdf`  
**Size**: ~500 KB - 1 MB  
**Pages**: 5-10 pages (depending on theta count and points per theta)

### Page 1: Cover Page

```
PMM Apple-to-Apple Comparison Report

Generated: 2026-05-12 20:35:15 UTC

Section summary:
Section: 700 x 700 (Metric) with cover 55, layout 'Perimeter bars', 28 x T25

Material summary:
Concrete strength and steel properties were specified in metric units 
for the comparison run.

Reinforcement summary:
Reinforcement: 28 bars of size T25 arranged as 'Perimeter bars'.

Unit system: Metric
Mx = force * y; My = force * x
```

### Page 2: Summary Page

```
Summary

Theta angles compared: 36
Total matched points: 5400
Total missing points: 0
Total failed points: 0

Overall average %DiffP: 0.234
Overall average %DiffM: -0.156
Overall variance %DiffP: 0.1234
Overall variance %DiffM: 0.0987
Overall standard deviation %DiffP: 0.3512
Overall standard deviation %DiffM: 0.3142

Overall conclusion: PASS

Mismatch / Missing Data:
(No mismatches - all points matched successfully)
```

### Pages 3+: Detailed Theta Tables

Example table for Theta = 0°:

```
Theta = 0°   MatchMethod: Index
Point  RefP(kN)  CalcP(kN)  DiffP(kN)  %DiffP  RefM(kNm)  CalcM(kNm)  DiffM(kNm)  %DiffM  P    M    Status
  0     1000.0    1005.3       5.3      0.530     100.0      99.2       -0.8     -0.8   PASS PASS PASS
  1      800.0     812.5      12.5      1.563      95.0      95.1        0.1      0.1   PASS PASS PASS
  2      600.0     598.7      -1.3     -0.217      90.0      90.2        0.2      0.2   PASS PASS PASS
  3      400.0     401.2       1.2      0.300      85.0      84.9       -0.1     -0.1   PASS PASS PASS
  ...

Mean %DiffP: 0.234
Variance %DiffP: 0.1234
StdDev %DiffP: 0.3512
Mean %DiffM: -0.156
Variance %DiffM: 0.0987
StdDev %DiffM: 0.3142
Max abs %DiffP: 0.784
Max abs %DiffM: 0.623
Max abs DiffP: 8.3
Max abs DiffM: 2.1
PASS points: 150
FAIL points: 0
```

### Final Page: Analysis

```
Final Analysis

This report compares apple-to-apple PMM points by theta and nearest-match index.
Matched points: 5400. Missing points: 0. Failed points: 0.

Strict acceptance is based on percent tolerance and absolute difference thresholds.

Engineering Interpretation:
- All 36 theta angles were successfully compared
- 5,400 total points matched against reference data
- No missing points (perfect alignment between calculated and reference)
- No failing points (all within tolerance)
- Average error %DiffP: 0.234% (excellent agreement)
- Average error %DiffM: -0.156% (excellent agreement)
- Low variance (0.35% stddev) indicates consistent accuracy
- Conclusion: MBColumn PMM calculations are VALIDATED and ACCURATE
```

---

## Interpreting Results

### Good Results (PASS - What You Want to See)

```
✅ All these indicators together = SUCCESS:
  - Theta angles: 36 or more
  - Matched points: 5000+ (most or all points matched)
  - Missing points: 0 (preferred) or very few
  - Failed points: 0 (perfect) or 1-2 (acceptable)
  - Overall conclusion: PASS
  - Mean %DiffP: < 1% (ideally < 0.5%)
  - Mean %DiffM: < 1% (ideally < 0.5%)
  - StdDev: < 0.5% (low variance = consistent accuracy)
```

**Example Result:**
```
Total matched points: 5400
Total failed points: 0
Overall average %DiffP: 0.234%
Overall average %DiffM: -0.156%
Overall conclusion: PASS
→ ✅ EXCELLENT - MBColumn is producing accurate results
```

### Acceptable Results (PASS with Notes)

```
⚠️ Still acceptable but worth investigating:
  - Failed points: 5-10 (minority of total)
  - Mean %Diff: 1-2% (slightly higher but acceptable)
  - Regional failures (only certain theta angles)
  - Pattern in failures (e.g., all high-load or low-load failures)
```

**Example:**
```
Total matched points: 5400
Total failed points: 3
Overall average %DiffP: 0.456%
Failed at Theta: 0°, 90°, 180° (symmetry axes)
→ ⚠️ ACCEPTABLE - Investigate if symmetrical pattern reveals issue
```

### Warning Results (FAIL - Investigate)

```
❌ These suggest a real problem:
  - Missing points: > 10 (point matching issue)
  - Failed points: > 50 (systematic error)
  - Mean %Diff: > 5% (outside acceptance tolerance)
  - All theta angles failing (not regional)
  - Constant bias (e.g., always +3% on P)
  - Sign error (e.g., M always opposite sign)
```

**Examples:**

**Example 1: Sign Convention Error**
```
Mean %DiffP: +0.23% ✓ (good)
Mean %DiffM: -45% ❌ (sign convention issue)
Failed points: 100%
→ ❌ FAIL - Moment sign convention mismatch
   Action: Check Mx/My definition in solver vs reference
```

**Example 2: Unit Conversion Error**
```
Mean %DiffP: +102% ❌ (exactly 2x = kN vs N issue)
Mean %DiffM: +102% ❌
Failed points: 100%
→ ❌ FAIL - Unit conversion problem
   Action: Verify internal units (should be N, N-mm)
```

**Example 3: Systematic Bias**
```
Mean %DiffP: +2.34%
All points fail %DiffP check (but pass abs DiffP)
→ ❌ FAIL - Consistent scale factor error
   Action: Review design code factor or material properties
```

---

## Acceptance Criteria Interpretation

### Pass Criteria (Per Point)

**Both of these must be true:**

```
1. P Passes if:
   abs((CalcP - RefP) / RefP * 100) ≤ 5%
   OR
   abs(CalcP - RefP) ≤ 25 kN

   Example: RefP = 1000 kN, CalcP = 1005 kN
   → %Diff = +0.5% ✅ PASS (< 5%)
   → AbsDiff = 5 kN ✅ PASS (< 25 kN)
   → Result: P PASS ✅

2. M Passes if:
   abs((CalcM - RefM) / RefM * 100) ≤ 5%
   OR
   abs(CalcM - RefM) ≤ 25 kNm

   Example: RefM = 100 kNm, CalcM = 99.2 kNm
   → %Diff = -0.8% ✅ PASS (< 5%)
   → AbsDiff = 0.8 kNm ✅ PASS (< 25 kNm)
   → Result: M PASS ✅

3. Overall = P PASS AND M PASS = POINT PASS ✅
```

### Near-Zero Exception

**If reference value is very small:**

```
If abs(RefValue) < 0.000001:
  → Skip percentage calculation (avoid division by zero)
  → Judge only by absolute tolerance

Example: RefP = 10 N (very small), CalcP = 35 N
  → Normal: %Diff = 250% ❌ FAIL
  → Near-zero exception: abs(35-10) = 25 kN ✅ PASS (at threshold)
```

### Dual Tolerance Rationale

**Why both percentage AND absolute?**

```
Percentage alone (bad):
  → 5% of 1,000 kN = 50 kN ✅ large error tolerated
  → 5% of 100 kN = 5 kN ✅ large error tolerated
  → 5% of 10 kN = 0.5 kN ✅ reasonable
  → 5% of 1 kN = 0.05 kN ❌ would fail on tiny differences

Absolute alone (bad):
  → 1,000 kN reference: 25 kN error = 2.5% ✓ good
  → 100 kN reference: 25 kN error = 25% ❌ terrible but passes
  → 10 kN reference: 25 kN error = 250% ❌ nonsense but passes

Dual tolerance (good):
  → Large values: Limited by percentage (tighter)
  → Small values: Limited by absolute (realistic)
  → Both constraints apply = stronger guarantee
```

---

## Troubleshooting Results

### Problem: "0 matched points"

**Cause**: CSV parsing failed or no points in reference

**Check:**
1. Verify reference CSV exists
2. Check CSV format (must be: Theta,PointIndex,RefP,RefMx,RefMy)
3. Verify CSV has data rows (not just header)
4. Check for encoding issues (must be UTF-8)

**Fix:**
```bash
# Regenerate simplified CSV
cd tests\MBColumn.Tests
dotnet run Verification\ReferenceDataSetup.cs
```

### Problem: "All points FAIL"

**Cause 1**: Unit mismatch
```
Mean %Diff = 102% or 1000%?
→ Check if reference is in different units (kN vs N, etc.)
```

**Cause 2**: Sign convention
```
%DiffM = -99% everywhere?
→ Check if Mx/My sign convention differs
```

**Cause 3**: Different test section
```
All failures at specific theta?
→ Verify test section matches reference geometry
```

**Fix**:
- Review reference data source
- Verify unit conversions
- Check section geometry alignment

### Problem: "Some theta angles missing"

**Cause**: Mismatch in theta angle steps

**Check:**
- Reference uses 0°-360° by 10° (36 angles)
- Calculated surface has different angle steps
- Nearest-neighbor matching should handle this

**View in Report:**
- MatchMethod will show "NearestNeighbour" for affected angles
- Document in "Mismatch / Missing Data" section

---

## Statistics Reference

### What Mean, Variance, StdDev Mean

**Mean (Average):**
```
Mean %DiffP = sum(all %DiffP values) / count

Example: [0.1%, 0.2%, 0.3%, 0.4%]
Mean = (0.1 + 0.2 + 0.3 + 0.4) / 4 = 0.25%

→ Interpretation: Average error is 0.25%
```

**Variance:**
```
Variance = average of (each value - mean)²

Example: [0.1%, 0.2%, 0.3%, 0.4%] with mean 0.25%
  (0.1-0.25)² + (0.2-0.25)² + (0.3-0.25)² + (0.4-0.25)²
= 0.0225 + 0.0025 + 0.0025 + 0.0225
= 0.01 (in percent²)

→ Interpretation: Spread of values squared
```

**Standard Deviation (StdDev):**
```
StdDev = sqrt(Variance)

In above example:
StdDev = sqrt(0.01) = 0.1%

→ Interpretation: About 68% of values fall within ±0.1% of mean
   (statistical: ±1 sigma)
```

**Good vs Bad:**
```
Mean = 0.2%, StdDev = 0.1% → ✅ Consistent, tight (good)
Mean = 0.2%, StdDev = 2.0% → ⚠️ Inconsistent, spread out (investigate)
Mean = 5.0%, StdDev = 0.1% → ❌ Consistent but biased (systematic error)
```

---

## Next Steps After Validation

### If All Tests Pass ✅
1. Run full test suite to ensure no regressions
2. Commit results to version control
3. Use as baseline for future validation
4. Document any known deviations

### If Tests Show Issues ⚠️
1. Identify pattern (regional, systematic, sign, etc.)
2. Review PDF report in detail
3. Check calculation settings (design code, material, geometry)
4. Compare against reference data source documentation
5. Investigate solver algorithm if needed

### For Continuous Validation
1. Add PMM test to CI/CD pipeline
2. Run before each commit
3. Generate reports in regression test folder
4. Track results over time (trend analysis)
5. Set up alert if results degrade

---

## Final Checklist

Before declaring test successful:

- [ ] Test runs without exceptions
- [ ] Console output shows expected numbers
- [ ] PDF file is generated
- [ ] PDF contains all required pages
- [ ] Statistics in PDF are numeric and reasonable
- [ ] No "NaN" or "Infinity" values
- [ ] Failed points < 5% of total (at least for first run)
- [ ] Mean error < 1% (ideally < 0.5%)
- [ ] Overall conclusion is "PASS"

---

**Expected Total Runtime**: 5-30 seconds  
**Expected Output Size**: 1-2 MB (PDF + cached CSV)  
**Expected First Run**: May take longer (CSV generation)  
**Expected Subsequent Runs**: Faster (CSV cached)

**Status**: Ready for validation

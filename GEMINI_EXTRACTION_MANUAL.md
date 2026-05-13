# GEMINI EXTRACTION - EXECUTABLE GUIDE

**Status**: Ready to extract Gemini parameters  
**Environment**: PowerShell/CMD available on your machine  
**Goal**: Extract section geometry, rebar, materials, design code, and reference PMM data

---

## Step 1: Open the Gemini File

```
File: c:\_ReverseEngineering\spColumnReversed-Solution\Gemini_NvsM_Test_Package_v2.docx
```

Open this file with Microsoft Word or any document viewer.

---

## Step 2: Extract Test Parameters

Look for a section that defines:

### A. Section Geometry
Look for lines like:
- "Section: 500 × 500 mm"  
- "Column dimensions: XXX × YYY"
- "Width: ___"
- "Height: ___"

**Write down**: `Width ____ mm, Height ____ mm`

### B. Reinforcement
Look for:
- "Bars: 16 × T25"
- "Reinforcement: NN bars of diameter DD mm"
- "Bar size: T25"
- "Number of bars: NN"

**Write down**: `NN bars, T25 (or other size) mm diameter`

### C. Material Properties  
Look for:
- "f'c = 30 MPa" (concrete strength)
- "fy = 400 MPa" (steel yield strength)
- "Es = 200000 MPa" (steel modulus)

**Write down**: `f'c = ___ MPa, fy = ___ MPa`

### D. Design Code
Look for:
- "ACI 318"
- "Eurocode 2" or "EC2"
- "Australian Standard"

**Write down**: `Design Code: _______________`

### E. Concrete Strength Class
If using Eurocode:
- "C30" (30 MPa)
- "C35"
- "C40"

**Write down**: `____________`

### F. Steel Grade
If using Eurocode:
- "B500" (500 MPa)
- "B400"

**Write down**: `____________`

---

## Step 3: Extract Reference PMM Data

Look for a table or section with PMM curve data.

It might be organized like:
- **"Theta = 0°"** section with a list or table
- **"Theta = 10°"** section
- etc.

For each theta angle, extract:
```
Theta: ___ degrees
  Point 1: P = ___ kN, Mx = ___ kNm, My = ___ kNm
  Point 2: P = ___ kN, Mx = ___ kNm, My = ___ kNm
  Point 3: P = ___ kN, Mx = ___ kNm, My = ___ kNm
  ...
```

Or if in tabular format:
```
Theta = 0°
| Point | P (kN) | Mx (kNm) | My (kNm) |
|-------|--------|----------|----------|
| 0     | 5000   | 0        | 0        |
| 1     | 4500   | 150      | 50       |
| ...   | ...    | ...      | ...      |
```

---

## Step 4: Copy Data to CSV

Create a file named `gemini_reference_data.csv` with format:

```
Theta,PointIndex,RefP,RefMx,RefMy
0,0,5000,0,0
0,1,4500,150,50
0,2,4000,280,95
10,0,5100,50,0
10,1,4600,180,45
...
```

Save this to:
```
c:\_ReverseEngineering\spColumnReversed-Solution\docs\validation\gemini_reference_data.csv
```

---

## Step 5: Create Test Parameters File

Create a text file with the extracted parameters:

**File**: `c:\_ReverseEngineering\spColumnReversed-Solution\GEMINI_TEST_PARAMETERS.txt`

**Content**:
```
GEMINI TEST CASE PARAMETERS
===========================

SECTION GEOMETRY:
  Width: ___ mm
  Height: ___ mm

REINFORCEMENT:
  Number of bars: ___
  Bar size: T25 / T20 / B500 / other: ___
  Diameter: ___ mm
  Layout: Perimeter / other: ___

MATERIAL PROPERTIES:
  Concrete f'c: ___ MPa
  Steel fy: ___ MPa
  Concrete class (EC2): C30 / C35 / C40 / other: ___
  Steel grade (EC2): B400 / B500 / other: ___

DESIGN CODE:
  ACI 318 / Eurocode 2 / other: ___

REFERENCE DATA:
  Total theta angles: ___
  Theta range: 0° to 360° (or specify)
  Points per theta: approximately ___

NOTES:
  (Any additional information about the test case)
```

---

## Step 6: Send Me the Data

Reply with:

1. **The parameters** (section, rebar, materials, code)
2. **The CSV file** (or paste the data)
3. **Or a screenshot** of the reference data section

---

## Alternative: Python Auto-Extraction

If you want to automate this, run this command in Windows CMD:

```bash
cd c:\_ReverseEngineering\spColumnReversed-Solution
python minimal_gemini_extract.py > gemini_output.txt
```

Then open `gemini_output.txt` and look for the extracted data.

If python-docx is not installed, the script will attempt to install it automatically.

---

## What I'll Do With Your Data

Once you provide the parameters and reference data:

1. ✅ Create a C# test case with those parameters
2. ✅ Run MBColumn with the Gemini section/materials/code
3. ✅ Load the reference PMM data
4. ✅ Execute point-by-point comparison using dual tolerance (5% OR 25 kN/25 kNm)
5. ✅ Generate PDF report with:
   - Test case summary
   - All point comparisons
   - Statistics per theta
   - Engineering conclusions

**Time to complete: 15-20 minutes**

---

## Files Ready to Use

- ✅ `GeminiComparisonRunner.cs` - C# comparison engine
- ✅ `ReferenceDataSetup.cs` - CSV processor
- ✅ All framework classes - Ready to integrate

---

**Next Step**: Extract the Gemini file using the steps above and send me the parameters!


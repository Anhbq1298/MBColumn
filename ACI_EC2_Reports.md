# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 2055.3 | 69.0 | 2049.2 | 69.5 | 2030.9 | 81.2 | 0.30 | -0.75 | 1.20 | -15.06 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1581.0 | 113.8 | 1574.8 | 113.9 | 1562.3 | 120.2 | 0.39 | -0.10 | 1.20 | -5.30 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1284.8 | 123.3 | 1278.6 | 123.1 | 1269.3 | 126.9 | 0.48 | 0.11 | 1.22 | -2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 836.4 | 110.6 | 830.2 | 110.1 | 826.5 | 111.5 | 0.75 | 0.48 | 1.19 | -0.78 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 151.6 | 28.4 | 143.2 | 26.9 | 146.6 | 27.6 | 5.82 | 5.58 | 3.43 | 2.88 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 1904.0 | 84.6 | 1896.1 | 85.1 | 2030.9 | 81.2 | 0.42 | -0.62 | -6.25 | 4.10 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1464.8 | 117.6 | 1456.5 | 117.7 | 1562.3 | 120.2 | 0.57 | -0.02 | -6.24 | -2.11 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1190.6 | 122.3 | 1182.1 | 122.0 | 1269.3 | 126.9 | 0.73 | 0.26 | -6.20 | -3.65 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 774.7 | 105.9 | 766.5 | 105.1 | 826.5 | 111.5 | 1.07 | 0.72 | -6.28 | -5.04 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 141.4 | 26.6 | 127.9 | 24.2 | 146.6 | 27.6 | 10.56 | 10.22 | -3.49 | -3.58 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 1904.0 | 84.6 | 1896.1 | 85.1 | 2030.9 | 81.2 | 0.42 | -0.62 | -6.25 | 4.10 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1464.8 | 117.6 | 1456.5 | 117.7 | 1562.3 | 120.2 | 0.57 | -0.02 | -6.24 | -2.11 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1190.6 | 122.3 | 1182.1 | 122.0 | 1269.3 | 126.9 | 0.73 | 0.26 | -6.20 | -3.65 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 774.7 | 105.9 | 766.5 | 105.1 | 826.5 | 111.5 | 1.07 | 0.72 | -6.28 | -5.04 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 141.4 | 26.6 | 127.9 | 24.2 | 146.6 | 27.6 | 10.56 | 10.22 | -3.49 | -3.58 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 3046.4 | 0.0 | 3808.0 | 0.0 | 3808.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 400.00 | 2962.1 | 112.7 | 2951.4 | 113.4 | 3225.2 | 98.7 | 0.36 | -0.62 | -8.16 | 14.19 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 296.30 | 2193.7 | 175.7 | 2182.9 | 175.6 | 2389.0 | 178.0 | 0.49 | 0.02 | -8.18 | -1.34 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 235.29 | 1741.4 | 182.5 | 1730.6 | 182.0 | 1897.2 | 190.4 | 0.62 | 0.26 | -8.21 | -4.14 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 148.15 | 1097.4 | 153.6 | 1086.5 | 152.5 | 1194.5 | 164.0 | 1.01 | 0.73 | -8.13 | -6.32 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 14.46 | 95.2 | 18.6 | 83.0 | 16.2 | 116.6 | 22.6 | 14.67 | 14.67 | -18.36 | -17.89 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.


# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Ec2
- **Section Shape**: Rectangular
- **Concrete**: C30 (fc' = 28.0 MPa)
- **Steel**: B500 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 0 bars, Sides different

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 4000.00 | 2538.7 | 0.0 | 2538.7 | 0.0 | 2538.7 | 0.0 | 0.00 | -100.00 | 0.00 | 0.00 | PASS |  |
| es = 0 | es = 0.00000 | 400.00 | 1904.0 | 84.6 | 1896.1 | 85.1 | 2030.9 | 81.2 | 0.42 | -0.62 | -6.25 | 4.10 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 307.69 | 1464.8 | 117.6 | 1456.5 | 117.7 | 1562.3 | 120.2 | 0.57 | -0.02 | -6.24 | -2.11 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 250.00 | 1190.6 | 122.3 | 1182.1 | 122.0 | 1269.3 | 126.9 | 0.73 | 0.26 | -6.20 | -3.65 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 162.79 | 774.7 | 105.9 | 766.5 | 105.1 | 826.5 | 111.5 | 1.07 | 0.72 | -6.28 | -5.04 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.04500 | 28.87 | 141.4 | 26.6 | 127.9 | 24.2 | 146.6 | 27.6 | 10.56 | 10.22 | -3.49 | -3.58 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.04500 | 0.00 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.0 | 0.00 | 0.00 | 0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.



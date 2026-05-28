# Code-Strict 7-Point P–M Strain Validation Report

## Input Data
- **Design Code**: Aci318Style
- **Section Shape**: Rectangular
- **Concrete**: fc 28.0 (fc' = 28.0 MPa)
- **Steel**: fy 420.0 (fy = 420.0 MPa, Es = 200000.0 MPa)
- **Rebar Layout**: 28 bars, Perimeter bars

## 7-Point Comparison Table

| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Pure Compression | es = 0.00000 | 7000.00 | 13687.2 | 0.0 | 17109.0 | 0.0 | 17109.0 | 0.0 | -20.00 | 0.00 | -20.00 | 0.00 | PASS | Deviation due to analytic pure compression vs finite C sweep |
| es = 0 | es = 0.00000 | 632.50 | 11182.6 | 1303.7 | 11134.7 | 1305.7 | 11888.8 | 1266.3 | 0.43 | -0.16 | -5.94 | 2.95 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = 0.5ey | es = 0.00105 | 468.52 | 7623.7 | 1781.6 | 7589.9 | 1773.3 | 8141.8 | 1803.6 | 0.45 | 0.47 | -6.36 | -1.22 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = ey (Balanced) | es = 0.00210 | 372.06 | 4884.8 | 2040.0 | 4886.1 | 2021.4 | 5329.7 | 2072.8 | -0.03 | 0.92 | -8.35 | -1.59 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Transition | es = 0.00510 | 234.26 | 1742.3 | 1862.5 | 1687.7 | 1844.3 | 1989.8 | 1904.8 | 3.24 | 0.99 | -12.44 | -2.22 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| es = Strain Cap | es = 0.08000 | 22.86 | -5484.2 | 98.9 | -5536.1 | 81.2 | -5451.6 | 109.8 | -0.94 | 21.82 | 0.60 | -9.87 | FAIL | Deviation exceeds tolerance. Check stress block interpretation. |
| Pure Tension | es = 0.08000 | 0.00 | -5774.2 | 0.0 | -5774.2 | 0.0 | -5774.2 | 0.0 | -0.00 | 0.00 | -0.00 | 0.00 | PASS |  |

## Output Formats
- Forces are in kN, Moments are in kNm.
- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.

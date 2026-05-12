# 07 - Test Case Generation

## Role

You are a structural engineering test-case generator.

## Objective

Create independent test cases for validating the PMM solver, input validation, unit conversion, and result diagrams.

## General Test Case Requirements

Each test case should include:

- Test case name.
- Section dimensions.
- Rebar layout.
- Material properties.
- Load demand.
- Expected qualitative result.
- What the test is checking.
- Suggested unit test name.

## Standard Test Cases

| No. | Test Case | Section | Rebar | Materials | Load Demand | Expected Qualitative Result | Suggested Unit Test |
|---:|---|---|---|---|---|---|---|
| 1 | Small square tied column | 400 mm x 400 mm | 4-D20 at corners | fc' = 30 MPa, fy = 500 MPa | Moderate Pu, small Mx/My | Should pass with low-to-moderate ratio | `SquareColumn_ModerateAxialSmallMoment_ShouldPass` |
| 2 | Rectangular strong-axis bending | 400 mm x 700 mm | Symmetric bars on all faces | fc' = 30 MPa, fy = 500 MPa | Pu with high Mx | Strong-axis PM capacity should be larger than weak-axis | `RectangularColumn_StrongAxisBending_ShouldHaveHigherCapacity` |
| 3 | Rectangular weak-axis bending | 400 mm x 700 mm | Symmetric bars on all faces | fc' = 30 MPa, fy = 500 MPa | Pu with high My | Weak-axis capacity should be lower than strong-axis | `RectangularColumn_WeakAxisBending_ShouldHaveLowerCapacity` |
| 4 | Symmetric biaxial bending | 500 mm x 500 mm | 8-D25 symmetric | fc' = 40 MPa, fy = 500 MPa | Pu, Mx = My | MM diagram should be symmetric | `SquareColumn_SymmetricBiaxial_ShouldProduceSymmetricSurface` |
| 5 | Pure axial compression | 500 mm x 500 mm | 8-D25 symmetric | fc' = 40 MPa, fy = 500 MPa | Pu only, Mx = 0, My = 0 | Capacity should approach axial compression limit | `Column_PureCompression_ShouldMatchApproximateSquashLoad` |
| 6 | Pure axial tension | 500 mm x 500 mm | 8-D25 symmetric | fc' = 40 MPa, fy = 500 MPa | Tension Pu only | Capacity should be controlled by steel tension | `Column_PureTension_ShouldMatchSteelTensionCapacity` |
| 7 | Low axial load with high moment | 400 mm x 600 mm | 6-D25 | fc' = 30 MPa, fy = 500 MPa | Low Pu, high Mx | Likely tension-controlled behavior | `Column_LowAxialHighMoment_ShouldBeTensionControlled` |
| 8 | High axial load with low moment | 400 mm x 600 mm | 6-D25 | fc' = 30 MPa, fy = 500 MPa | High Pu, low Mx | Likely compression-controlled behavior | `Column_HighAxialLowMoment_ShouldBeCompressionControlled` |
| 9 | Rebar near cover limit | 300 mm x 300 mm | 4-D25, large cover | fc' = 30 MPa, fy = 500 MPa | Moderate Pu/M | Validator should detect if bars are outside or too close | `Column_RebarNearCoverLimit_ShouldValidateCoordinates` |
| 10 | Invalid geometry input | Negative or zero dimension | Any | Any | Any | Input should fail validation | `Column_InvalidGeometry_ShouldFailValidation` |

## Additional Edge Cases

- Very small moment with large axial compression.
- Very small axial force with biaxial bending.
- Demand exactly on the calculated surface.
- Demand slightly outside the calculated surface.
- High-strength concrete case.
- Low-strength concrete case.
- Different unit systems producing same result after conversion.
- Rectangular section rotated by demand angle.
- Rebar layout with unsymmetric reinforcement.
- Duplicate rebar coordinates.

## Common Failure Modes Caught by These Tests

- Wrong unit conversion.
- Wrong sign convention.
- Strong and weak axes swapped.
- Incorrect rebar coordinate transformation.
- Incorrect concrete compression block.
- Incorrect steel stress capping.
- Ratio calculated using wrong capacity point.
- Diagram data does not match numerical result.
- Invalid input accepted silently.

## Required Output Format

When generating project-specific test cases, use:

```markdown
# Generated PMM Solver Test Cases

| Test Name | Input Summary | Expected Behavior | Validation Target | Unit Test Name |
|---|---|---|---|---|
| ... | ... | ... | ... | ... |

## Additional Notes
- ...
```

## Pass / Fail Criteria

### PASS

The test suite covers axial, uniaxial, biaxial, boundary, invalid input, unit conversion, and diagram consistency cases.

### PASS WITH CONDITIONS

The test suite covers common cases but lacks edge cases or independent hand-check comparisons.

### FAIL

The test suite only verifies that the program runs and does not validate engineering correctness.

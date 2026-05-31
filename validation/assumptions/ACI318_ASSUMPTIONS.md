# ACI 318 Design Code Assumptions

Documents the assumptions, formulas, and limitations of the ACI 318-19 implementation in MBColumn.

## Scope

Biaxial bending and axial force capacity (P-M-M interaction) of tied and spirally reinforced concrete columns under ACI 318-19.

## Internal Units

All solver-internal calculations use SI base units:

| Quantity | Unit |
|---|---|
| Length | mm |
| Force | N |
| Moment | N·mm |
| Stress | MPa (= N/mm²) |
| Strain | dimensionless |

Display units are applied only at the DTO boundary via `UnitConversionService`.

## Material Models

### Concrete

- Rectangular equivalent stress block per ACI 318-19 §22.2.
- Depth factor: `β1 = 0.85` for `fc' ≤ 28 MPa`, decreasing at 0.05 per 7 MPa above 28 MPa, minimum 0.65.
- Uniform stress: `0.85 × fc'`.
- Maximum usable strain: `εcu = 0.003`.
- No material partial factors (capacity factors applied separately via φ).

### Reinforcement Steel

- Elastic-perfectly plastic model.
- `Es = 200 000 MPa` (default).
- Tension and compression equally assumed.

## Capacity Reduction Factors (φ)

ACI 318-19 §21.2.1, Table 21.2.1:

| Region | Condition | φ |
|---|---|---|
| Compression-controlled | `εt ≤ εy` | 0.65 (tied) |
| Tension-controlled | `εt ≥ 0.005` | 0.90 |
| Transition | `εy < εt < 0.005` | Linear interpolation |

where `εt` is the net tensile strain in the extreme tension steel at nominal strength.

## Maximum Compression Limits

Per ACI 318-19 §22.4.2:

- Tied columns: `φPn,max = φ × 0.80 × Pn,0`
- Spiral columns: `φPn,max = φ × 0.85 × Pn,0`

The 0.80/0.85 cap is applied to the **design** curve only (not the nominal curve).

## Strain Limits

| Condition | Value |
|---|---|
| Maximum concrete compressive strain | −3.0 ‰ (εcu = 0.003) |
| Compression-controlled boundary | −2.0 ‰ (εy for Grade 60 steel = 420/200 000) |
| Tension-controlled boundary | +5.0 ‰ |

## Sign Convention

| Quantity | Positive direction |
|---|---|
| Axial force P | Compression |
| Moment Mx | Bending about x-axis (right-hand rule) |
| Moment My | Bending about y-axis (right-hand rule) |
| Strain ε | Compression negative, tension positive |

## PMM Sampling

- Neutral-axis sweep: 36 angular steps × 100 depth steps per angle.
- Each point represents one (angle, depth) combination.

## Unsupported Cases

- Spiral column φ = 0.75 path (currently only tied-column φ = 0.65 path is implemented).
- Bilinear steel model.
- Confined concrete.
- Prestressed reinforcement.
- High-strength concrete above 100 MPa.

## Related Files

- `src/MBColumn.Infrastructure/DesignCodes/Aci318DesignCodeService.cs`
- `src/MBColumn.Infrastructure/Solvers/PmmSolver.cs`
- `src/MBColumn.Infrastructure/Solvers/StrainPoints/Aci318StrainLimitAdapter.cs`

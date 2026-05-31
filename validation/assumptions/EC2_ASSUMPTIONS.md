# EC2 Design Code Assumptions

Documents the assumptions, formulas, and limitations of the EC2 (EN 1992-1-1) implementation in MBColumn.

## Scope

Biaxial bending and axial force capacity (P-M-M interaction) of reinforced concrete columns under EN 1992-1-1 (Eurocode 2).

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

- **Stress-block (Boundary solver):** Rectangular equivalent stress block with depth factor λ and effective strength factor η per EN 1992-1-1 §3.1.7.
  - `fck ≤ 50 MPa`: λ = 0.8, η = 1.0
  - `50 < fck ≤ 90 MPa`: λ and η reduce linearly per §3.1.7 (3) and (4)
- **Fiber solver:** Parabolic-rectangular stress-strain model per EN 1992-1-1 §3.1.5.
  - `εc2` and `εcu2` taken from Table 3.1.
- **Analytic fiber solver:** Full parabolic-rectangular integration for each fiber column.

### Reinforcement Steel

- Elastic-perfectly plastic model.
- `Es = 200 000 MPa` (default).
- Tension and compression equally assumed.

## Capacity Reduction Factor

EN 1992-1-1 does not use a phi factor. All capacity factors are set to:
- `φ = 1.0` throughout.

Material partial factors (`γC`, `γS`) are applied to material strengths before integration, not as post-multipliers on capacity.

### Concrete design strength

`fcd = αcc × fck / γC`

where:
- `αcc = 0.85` by default (long-term effects, per §3.1.6 (1)P) — configurable per input.
- `γC = 1.50` by default (persistent/transient) — configurable per input.

### Steel design strength

`fyd = fyk / γS`

`γS = 1.15` (default, persistent/transient design situation).

## Strain Limits

| Condition | Value |
|---|---|
| Maximum concrete compressive strain (`εcu2`) | −3.5 ‰ (fck ≤ 50 MPa) |
| Maximum concrete strain at pure bending | −3.5 ‰ |
| Reinforcement yield strain (tension) | +εyd = fyd / Es |
| Maximum reinforcement strain | +25 ‰ (practical upper limit) |

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
- Covers full rotation from pure compression through pure tension.

## Unsupported Cases

- Slenderness effects (second-order moments) — use EC2 slenderness module separately.
- Creep effects on material stiffness.
- Confined concrete models (Mander, etc.).
- Prestressed reinforcement.
- Non-rectangular irregular sections with the Fiber integrator (use Polygon integrator for those).

## Related Files

- `src/MBColumn.Infrastructure/DesignCodes/Ec2DesignCodeService.cs`
- `src/MBColumn.Infrastructure/Solvers/PmmSolver.cs`
- `docs/engineering/eurocode/ec2-stress-block.md`
- `docs/engineering/eurocode/ec2-strain-limits.md`

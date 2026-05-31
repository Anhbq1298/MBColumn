# Unit and Sign Convention

Single source of truth for units and sign conventions used throughout MBColumn.

## Internal Solver Units

All structural calculations use SI base units internally:

| Quantity | Internal Unit | Notes |
|---|---|---|
| Length | mm | Section geometry, rebar positions |
| Force | N | Axial force Pn, PhiPn |
| Moment | N·mm | Mnx, Mny, PhiMnx, PhiMny |
| Stress | MPa = N/mm² | fc', fy, fyd, fcd |
| Strain | dimensionless | εcu, εy, εt |
| Area | mm² | Section area, rebar area |

**Never pass kN or kN·m to solver methods.** Unit conversion is the responsibility of the DTO boundary (`UnitConversionService`).

## Display Unit Conversions

`UnitConversionService` converts between internal (N, mm, MPa, N·mm) and user-selected display units. Applied at the DTO boundary only — never inside the solver.

| Display Unit | To Internal | Notes |
|---|---|---|
| kN | × 1 000 | Forces |
| kip | × 4 448.22 | Forces |
| kN·m | × 1 000 000 | Moments |
| kip·ft | × 1 355 817.9 | Moments |
| inch | × 25.4 | Lengths |
| ksi | × 6.894 757 | Stresses |

## Sign Conventions

### Axial Force (P)

- **Positive = Compression** (consistent with structural engineering convention for columns).
- `Pn > 0` → compressive axial capacity.
- `Pn < 0` → tensile axial capacity (pure tension failure).

### Moments (Mx, My)

- Right-hand rule.
- `Mx > 0` → sagging about the x-axis (bottom in tension).
- `My > 0` → sagging about the y-axis.
- The PMM surface is symmetric about the P-axis for symmetric sections.

### Neutral Axis Depth

- Measured from the **compression face**.
- Increases from 0 (pure bending) toward infinity (pure compression).
- Negative depth not physically meaningful; pure tension handled by setting depth = 0 and no compression zone.

### Strain

- **Compression negative**: `ε = −εcu` at the extreme compression fibre (e.g., −0.003 for ACI).
- **Tension positive**: `ε > 0` at extreme tension steel.

## Coordinate System for Section Geometry

- Origin at the **centroid** of the section.
- `x` positive to the right; `y` positive upward.
- `Mx` is the moment about the x-axis (produces y-direction bending).
- `My` is the moment about the y-axis (produces x-direction bending).
- Rebar positions `(rx, ry)` are in mm relative to the centroid.

## Common Pitfalls

| Mistake | Consequence |
|---|---|
| Passing kN to solver instead of N | 1000× error in forces |
| Passing kN·m to solver instead of N·mm | 10⁶× error in moments |
| Confusing Mx/My axis assignment | Moment-direction error in charts |
| Using tension-positive for axial | Sign flip in compression-controlled region |

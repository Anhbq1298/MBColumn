# MBColumn Control Points and 3D PMM Theory

This note explains how MBColumn creates named PMM control points and how it constructs the 3D PMM chart for both ACI-style and Eurocode paths.

The key rule is that control points and charts are derived from the existing solved interaction surface. The chart and report layers do not solve strain compatibility again.

## Scope

MBColumn currently models rectangular reinforced-concrete column sections. The core PMM workflow is:

1. Build the concrete section and reinforcement layout.
2. Select the design-code service.
3. Run the selected interaction solver.
4. Store the result as an `InteractionSurface`.
5. Convert the surface into table control points and diagram control points.
6. Convert diagram control points into chart DTOs for 2D and 3D rendering.

The main implementation path is:

```text
ColumnCalculationService
-> InteractionSolverFactory
-> IInteractionSolver.Solve(...)
-> InteractionSurface
-> ControlPointTableBuilderService
-> ControlPointBuilderService
-> DiagramDataService
-> WPF chart controls
```

## Shared Internal Conventions

Internal solver units are:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa

Display values are converted at the application boundary to kN, kN-m, kip, or kip-ft.

Axial compression is positive. Axial tension is negative.

The current solver implementation accumulates moments about the section centroid as:

```text
Mx = -sum(force * y)
My =  sum(force * x)
```

The sign of a reported control point therefore follows the selected neutral-axis direction and the current solver convention. The validation comparers must compare the matching signed axis value:

- X and -X rows compare `Mx`.
- Y and -Y rows compare `My`.

## Interaction Surface Theory

An interaction surface is a structured grid of points:

```text
InteractionSurface
  DepthCount = number of neutral-axis or strain-state samples
  AngleCount = number of neutral-axis directions
  Points     = DepthCount x AngleCount interaction points
```

Each `InteractionPoint` stores:

- `Pn`: nominal or already-design axial force, depending on design-code path.
- `Mnx`, `Mny`: corresponding centroidal moments.
- `Phi`: strength-reduction factor or 1.0.
- `PhiPn`, `PhiMnx`, `PhiMny`: `Pn`, `Mnx`, `Mny` multiplied by `Phi`.
- `ThetaDegrees`: neutral-axis direction.
- `NeutralAxisDepthMm`: neutral-axis depth or equivalent strain-state depth.
- strain and force-component diagnostics where available.

The grid is organized so each depth row forms a closed Mx-My ring around the axial axis. Connecting adjacent rings creates the 3D PMM surface.

## ACI Surface Creation

The current ACI-style conventional solver is `StrainCompatibilityInteractionSolver`.

For each neutral-axis direction and depth sample, it:

1. Defines a neutral-axis normal from `theta`.
2. Places the neutral axis at depth `c` from the extreme compression projection.
3. Uses a rectangular compression block with depth `beta1 * c`.
4. Clips the concrete rectangle to the compression block polygon.
5. Computes concrete compression force and centroid.
6. Computes each bar strain from plane sections.
7. Caps steel stress at `+/- fy`.
8. Subtracts displaced concrete stress where a bar lies inside the compression block.
9. Sums axial force and moments.
10. Computes ACI tied-column `phi` from the tensile steel strain.

ACI design-code values are supplied by `Aci318DesignCodeService`:

- ultimate concrete strain: `0.003`
- concrete stress factor: `0.85`
- `beta1` per ACI-style rules, with exact values for existing validation cases
- steel design strength: `fy`
- `phi` transition from 0.65 to 0.90
- compression design limit: `0.80 * max(PhiPn)`

For ACI, `Pn`, `Mnx`, and `Mny` are nominal strengths. Design strengths are `PhiPn`, `PhiMnx`, and `PhiMny`.

## Eurocode Surface Creation

Eurocode behavior is separated behind `Ec2DesignCodeService` and Eurocode solver implementations.

The Eurocode service supplies:

- ultimate concrete strain: `0.0035`
- concrete stress factor: `AlphaCc / 1.5`
- steel design strength: `fyk / 1.15`
- `Phi = 1.0`
- compression limit equal to the maximum calculated compression capacity
- letter-style control points

Because Eurocode applies material partial factors directly, the solver output is already in design-strength terms. `Phi` remains 1.0, so `PhiPn == Pn` and `PhiMnx == Mnx`.

The analytic Eurocode fiber solver `EcPmmFiberAnalyticSolver` samples strain states rather than an ACI rectangular stress block. For each direction and strain-state sample, it:

1. Projects the rectangular section onto the neutral-axis direction.
2. Defines a linear strain profile through the projected section depth.
3. Integrates concrete stress using a parabolic-rectangular stress-strain model.
4. Ignores concrete tension.
5. Computes steel strain at each bar.
6. Caps steel stress at `+/- fyd`.
7. Subtracts displaced concrete stress at bar locations.
8. Sums axial force and centroidal moments.
9. Stores the point with `Phi = 1.0`.

Other EC2 solvers can be selected through the solver factory, but the downstream control-point and chart theory is the same: consume the resulting `InteractionSurface`.

## Named Control Point Table

`ControlPointTableBuilderService` creates the report-style control point table from the solved surface. It does not run a new solver.

It builds rows for four principal directions:

```text
X   -> theta 270 deg, reported moment Mx
Y   -> theta   0 deg, reported moment My
-X  -> theta  90 deg, reported moment Mx
-Y  -> theta 180 deg, reported moment My
```

For each direction, it selects the nearest surface angle row and orders the row from compression toward tension.

It then computes:

```text
dt = distance from compression face to extreme tension bar
```

This is computed from the section geometry and bar projections along the neutral-axis direction. It is not inferred from chart coordinates.

### ACI Named Points

ACI creates eight named rows per direction:

1. Max compression
2. Allowable comp.
3. fs = 0.0
4. fs = 0.5 fy
5. Balanced point
6. Tension control
7. Pure bending
8. Max tension

The theoretical meaning is:

- Max compression: the high-compression end of the surface row.
- Allowable compression: point where `PhiPn` equals the ACI compression design limit.
- fs = 0.0: neutral axis depth equals `dt`.
- fs = 0.5 fy: tensile steel strain equals half yield strain.
- Balanced point: tensile steel strain equals yield strain.
- Tension control: tensile steel strain equals yield strain plus 0.003.
- Pure bending: axial force equals zero.
- Max tension: steel-only tensile capacity.

For strain-defined points, MBColumn computes the target neutral-axis depth analytically:

```text
c = ecu * dt / (ecu + et_target)
```

Then it interpolates along the existing surface row by neutral-axis depth. This avoids selecting a nearby sampled point when the desired strain state lies between samples.

For pure bending, MBColumn interpolates by `Pn = 0`, not by `PhiPn = 0`. This keeps the pure-bending row tied to axial equilibrium before the `phi` factor is applied.

For the max-tension row, MBColumn reports:

```text
P = -phi * sum(As * fy)
```

and uses a sentinel tensile strain value of `9.99999`, matching the report-style convention for `c -> 0`.

### Eurocode Named Points

Eurocode uses seven letter rows per direction:

1. A: Max compression
2. B: fs = 0.0
3. C: fs = 0.5 fyd
4. D: Balanced
5. E: Tension control
6. F: Pure bending
7. G: Max tension

There is no ACI-style "Allowable compression" row because EC2 does not use the tied-column 0.80 compression cap in this implementation.

Since `Phi = 1.0` for Eurocode, table rows are reported directly from design-strength values generated by the EC material model and partial factors.

## Diagram Control Points

`ControlPointBuilderService` creates diagram-ready `ControlPoint` objects. These are a richer form than the named table rows. They include:

- design display values
- nominal display values
- original force and moment values
- theta and neutral-axis depth
- group labels for design, nominal, demand, governing, and reference points

The four generated collections are:

- `PmPoints`: selected PM angle loop plus Pmax, Pmin, demand, and governing markers.
- `MmPoints`: Mx-My boundary at selected axial load.
- `PmmSurfacePoints`: complete 3D PMM surface points.
- `MmSlicePoints`: Mx-My slice points for the selected axial load.

Design values are generally displayed from:

```text
DisplayP  = unit_convert(PhiPn)
DisplayMx = unit_convert(PhiMnx)
DisplayMy = unit_convert(PhiMny)
```

Nominal values are preserved separately from:

```text
NominalDisplayP  = unit_convert(Pn)
NominalDisplayMx = unit_convert(Mnx)
NominalDisplayMy = unit_convert(Mny)
```

For Eurocode, design and nominal values coincide because `Phi = 1.0`, but both sets still flow through the same DTO contract.

## PM Curves from the 3D Surface

PMx, PMy, and angle-based PM diagrams are not drawn by simply connecting raw neutral-axis samples. Raw samples can include interior points and nonuniform axial spacing.

`PmCurveBuilderService` builds PM curves from the 3D PMM surface using constant-axial rings:

1. Group surface points by theta row.
2. Sort each theta row by axial force.
3. Sample 70 constant axial-load levels from `Pmin` to `Pmax`.
4. At each axial level, interpolate one point from each theta row.
5. The interpolated points form a closed Mx-My ring.
6. Intersect that ring with the requested PM plane.
7. Keep the positive and negative moment intersections.
8. Merge positive and negative branches into one envelope loop.

For PMx:

```text
intersect Mx-My ring with My = 0
plot X = Mx, Y = P
```

For PMy:

```text
intersect Mx-My ring with Mx = 0
plot X = My, Y = P
```

For a general angle:

```text
Mtheta = Mx * cos(theta) + My * sin(theta)
cross  = -Mx * sin(theta) + My * cos(theta)
intersect where cross = 0
plot X = Mtheta, Y = P
```

This produces cleaner engineering envelopes than connecting raw sampled points directly.

## ACI Compression Cap in PM Charts

ACI uses a compression design limit:

```text
Pmax_design = 0.80 * max(PhiPn)
```

For design PM curves, MBColumn trims the top of the curve at that axial value. The curve can still have moment capacity at the cap level, so the top of the design curve is a horizontal trim segment between the negative and positive moment intersections at `Pmax_design`.

Nominal PM curves are not capped:

```text
Pmax_nominal = max(Pn)
```

The chart can therefore show both:

- design capacity: factored, ACI-capped
- nominal capacity: unfactored, uncapped

For Eurocode, `CompressionDesignLimit(maxP)` returns `maxP`, so there is no special 0.80 trim.

## 3D PMM Surface Construction

The 3D chart starts from `PmmSurfacePoints`.

`ControlPointBuilderService.BuildSurface` emits both:

- design surface points
- nominal surface points

For each solved interaction point:

```text
3D X = DisplayMx
3D Y = DisplayMy
3D Z = DisplayP
```

This maps:

- horizontal X screen-space data axis to Mx
- horizontal/depth Y data axis to My
- vertical Z data axis to P

The design surface uses `PhiPn`, `PhiMnx`, and `PhiMny`, with positive compression optionally limited by the design-code compression limit. The nominal surface uses raw `Pn`, `Mnx`, and `Mny`.

At the first and last depth rows, MBColumn applies a tiny moment perturbation to each theta point. The purpose is to turn pure axial poles into tiny closed rings rather than many exactly coincident points. This helps the 3D mesh avoid degenerate faces while leaving engineering values visually unchanged.

## 3D Mesh and Wireframe

`DiagramDataService.BuildPmmSurfaceRenderData` converts surface control points into chart DTOs and then builds:

- mesh triangles
- wireframe lines

The mesh process is:

1. Remove invalid points.
2. Group points into depth rows.
3. Sort each row by theta.
4. Connect each row to the next row.
5. For each adjacent pair of theta points, create two triangles.
6. Wrap the row end back to the row beginning.

Conceptually:

```text
row i, theta j       -> row i, theta j+1
      |                         |
row i+1, theta j     -> row i+1, theta j+1
```

becomes two triangular faces.

The wireframe follows the same topology:

- circumferential lines around each theta ring
- longitudinal lines along constant theta between depth rows

The WPF `InteractionViewport3D` also builds quads from structured rows for painter-style rendering and closes the perturbed pole rings visually.

## Slice Planes in the 3D Chart

The 3D view is not only a surface. It also renders two navigational slices.

The PM angle slice is a vertical plane through the origin:

```text
direction = (cos(theta), sin(theta))
```

Changing the selected PM angle rotates this plane without rerunning the solver.

The axial-load slice is a horizontal plane at:

```text
Z = selected axial load display value
```

Changing the selected axial load moves this plane without rerunning the solver.

These slice planes are visual aids. They do not modify the interaction surface or recalculate capacities.

## Demand and Governing Points

Demand points and governing points are markers added after the surface is built.

The PMM ratio calculation uses design-strength values only:

```text
PhiPn, PhiMnx, PhiMny
```

The governing point returned by the ratio check is inserted into the diagram data as a marker. It is not inserted into the capacity envelope polyline or mesh topology.

## ACI vs Eurocode Summary

| Topic | ACI-style path | Eurocode path |
| --- | --- | --- |
| Concrete ultimate strain | 0.003 | 0.0035 |
| Concrete model | rectangular block in conventional solver | EC2 parabolic-rectangular/fiber or selected EC2 solver |
| Steel strength | fy | fyk / 1.15 |
| Member factor | phi varies 0.65 to 0.90 | phi = 1.0 |
| Compression cap | 0.80 * max(PhiPn) | no extra cap |
| Named control points | 8 rows with allowable compression | 7 letter rows A-G |
| PM chart source | interaction surface | interaction surface |
| 3D chart source | design and nominal surface points | design and nominal surface points, effectively equal when phi = 1.0 |

## Practical Validation Rules

When validating MBColumn against reference software:

1. Compare the same quantity: nominal vs nominal, or design vs design.
2. Confirm axis mapping before comparing signs.
3. Confirm whether the reference applies an ACI compression cap.
4. Confirm bar cover means cover to bar surface or bar centroid.
5. Confirm whether the reference uses `fy` or reduced `fyd`.
6. Compare named table control points separately from dense curve samples.
7. Use the same selected PM angle or axial-load slice when comparing chart data.

The ACI ref validation compares the named control point table. The Eurocode ref validation compares generated PMM/PM curve data. Both are downstream validations of the same MBColumn principle: solve once, then derive tables and charts from the solved surface.

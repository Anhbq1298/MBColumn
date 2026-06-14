# Engineering Skill Set

Use this file before changing solver behavior, result mapping, diagrams, or reports.

## Engineering Scope

MBColumn checks reinforced-concrete column PMM interaction for rectangular, circular, and irregular polygon sections. It supports ACI-style and Eurocode 2 paths, multiple load cases, PM/Mx-My/3D PMM diagrams, shear checks where available, EC2 slenderness workflows, and report generation.

The software is a preliminary validation and study tool. All engineering output must be independently verified by a qualified structural engineer before use in design or construction.

## Internal Units

Solver internals use:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa

Display units:

- Metric: kN, kN-m, mm, MPa
- Imperial: kip, kip-ft, inch, ksi

All solver inputs must be converted before reaching solver logic.

## Sign and Axis Conventions

- Axial compression is positive.
- Axial tension is negative.
- Coordinates are measured from the section centroid.
- Current solver moment accumulation is:
  - `Mx = -force * y`
  - `My = force * x`
- ETABS mapping is axis-based:
  - MBColumn X = ETABS local 2
  - MBColumn Y = ETABS local 3
  - Mx = ETABS M2
  - My = ETABS M3
  - Vx = ETABS V2
  - Vy = ETABS V3
  - ETABS P is converted to MBColumn compression-positive P/NEd

## Theta Convention

MBColumn has two theta values:

1. User-facing moment theta, theta_M:
   - Direction of the bending moment vector in the Mx-My plane.
   - 0 deg points toward +Mx.
   - 90 deg points toward +My.
   - 180 deg points toward -Mx.
   - 270 deg points toward -My.
   - This is the only theta shown in UI and reports.

2. Internal compression-normal theta, theta_c:
   - Direction perpendicular to the neutral axis toward compression.
   - Used by strain compatibility, section-state drawings, and solver integration.

Conversion:

```text
theta_M = Normalize(theta_c + 90)
theta_c = Normalize(theta_M - 90)
```

Use `PmmAngleConvention` for conversion and formatting. Do not hard-code theta offsets or format strings in UI/report code.

## PMM Calculation Method

The general PMM workflow is:

```text
ColumnInputDto
  -> validation and unit conversion
  -> section/rebar model
  -> design-code service
  -> interaction solver
  -> InteractionSurface
  -> RatioCheckService
  -> CalculationResultDto
  -> diagrams and reports
```

The solver samples neutral-axis angle and neutral-axis depth or strain state. Concrete tension is ignored. Steel is elastic-perfectly plastic and capped according to the active code path.

## Section Integration

Fiber integration:

- Rectangular sections use a rectangular concrete fiber grid.
- Circular sections use radial/angular concrete fibers.
- Rebars are discrete.
- Concrete compression stress follows the selected code service.

Polygon integration:

- Rectangular and circular boundaries are clipped to the compression zone.
- Circular polygon accuracy depends on `CirclePolygonSegmentCount`.
- Rebar force is still integrated discretely.

Irregular sections:

- Boundary points are user-entered or imported.
- Boundary should be clockwise and is treated as closed.
- Fiber integration is the active irregular-section path in this milestone.

## ACI-Style Path

- Plane sections remain plane.
- Maximum concrete compression strain is 0.003.
- Concrete stress block factor is 0.85.
- `beta1` comes from `Aci318DesignCodeService`.
- Steel strength uses `fy`.
- Phi varies by tensile steel strain.
- ACI tied-column compression design cap is applied through the design-code and PM curve services.
- Nominal and phi-reduced design values must remain separate.

## Eurocode 2 Path

- EC2 material factors, concrete strain limits, steel design strength, and stress block assumptions are separated from ACI logic.
- EC2 output generally uses `phi = 1.0`.
- Material partial factors are applied through EC2 services/adapters.
- Report and chart generation should reuse the common PMM pipeline.

## PMM Ratio and Capacity

- PMM ratio uses design-strength values.
- Demand/capacity comparison is directional in P-Mx-My space.
- `RatioCheckService.CriticalThetaDegrees` is a user-facing moment direction.
- `ColumnCalculationService` stores internal and display theta through `GoverningThetaDegrees` and `GoverningMomentThetaDegrees`.
- Do not change PMM calculation logic for report/UI formatting issues.

## Diagram and Report Engineering Rules

- PM diagrams are derived from the solved interaction surface, not from a new solve.
- Mx-My diagrams are generated at a selected axial load from the surface.
- 3D PMM surfaces are rendered from resampled constant-P levels.
- Demand and governing points are markers, not capacity mesh vertices.
- Reports must show the same theta as PMM Details for the same section, load case, and PMM result.
- ACI and EC2 report builders should format theta through `PmmAngleConvention.FormatMomentTheta`.

## Validation Checklist

- Pure axial compression and pure tension are physically reasonable.
- Uniaxial major/minor bending signs and capacities are reasonable.
- Symmetric sections produce symmetric Mx-My and PMM surfaces.
- Nominal capacity is not mixed with design capacity.
- PMM Details, chart markers, and report rows agree on demand, capacity, ratio, theta, and units.
- No NaN or Infinity appears in surface points.
- Unit changes do not alter internal solver behavior.
- Any solver change receives independent engineering review.

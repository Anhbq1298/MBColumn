# EC2 Fiber PMM Validation Skill

Purpose: guide agents to build, review, and validate Eurocode 2 PMM interaction surfaces using fiber-section strain compatibility for MBColumn.

This file is a validation and implementation guide. It is not a certified design procedure. All outputs must be independently checked by a qualified structural engineer before use in design.

## Non-Interference Rule

This skill must not interfere with the existing spColumn-like / ACI-style PMM logic already implemented in MBColumn.

Agents must follow these rules:

- Do not mutate, rename, or simplify the existing ACI/spColumn-style solver path unless the task explicitly asks for ACI changes.
- Do not replace existing control-point generation used by the ACI/spColumn-style charts.
- Do not introduce Eurocode material factors, EC2 strain limits, or EC2 labels into the existing ACI path.
- Do not change existing chart controls in a way that breaks current ACI/spColumn-style outputs.
- Implement Eurocode behavior as a separate design-code path behind clear service boundaries.
- Reuse common geometry, fiber, chart DTOs, and rendering pipelines only when they remain solver-agnostic.
- If shared code must be touched, add regression tests proving existing ACI/spColumn-style results remain unchanged within the current project tolerance.

Recommended separation:

```text
Common section geometry / fiber utilities
    -> ACI design-code service / existing spColumn-style path
    -> EC2 design-code service / new Eurocode path
    -> shared chart DTOs and WPF rendering controls
```

## When To Use This Skill

Use this skill when the task touches any of the following:

- Eurocode 2 PMM interaction surface generation.
- Fiber-section strain compatibility.
- EC2 concrete or reinforcement material models.
- PMM ratio calculation for EC2 mode.
- Concrete compression/tension zone visualization.
- OpenSeesPy or independent numerical validation of MBColumn PMM results.
- Comparison between ACI-style control points and Eurocode-style strain states.

Do not use this skill to modify ACI logic directly. Eurocode behavior must remain isolated behind a separate design-code path.

## Required Reading Before Editing

Read these files first:

1. `README.md`
2. `AGENTS.md`
3. `docs/engineering/eurocode/eurocode-pmm-overview.md`
4. `docs/engineering/eurocode/ec2-material-model.md`
5. `docs/engineering/eurocode/ec2-strain-limits.md`
6. `docs/engineering/eurocode/ec2-stress-block.md`
7. `docs/engineering/eurocode/ec2-pmm-ratio.md`
8. `docs/engineering/eurocode/eurocode-chart-reuse-contract.md`
9. `docs/engineering/eurocode/worked-example.md`
10. This file

## Core Engineering Position

Eurocode PMM logic should be based on:

- Plane sections remain plane.
- Concrete tension stress is ignored.
- Concrete compression is calculated only from concrete fibers or concrete regions with compressive strain.
- Reinforcement is modeled as discrete steel bars or fibers and can carry both tension and compression.
- EC2 design strengths are used directly for design resistance.
- ACI phi-factor logic must not be used in Eurocode mode.
- ACI control-point labels must not be reused as Eurocode labels.

## Internal Units And Sign Convention

Use the repository convention:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa = N/mm2
- Axial compression: positive
- Axial tension: negative
- Section origin: centroid
- `Mx = force * y`
- `My = force * x` or the current repository convention if the implementation has already standardized the sign in the active solver. Confirm before editing.

Do not introduce display units into solver logic.

## EC2 Material Assumptions

### Concrete Design Strength

Use:

```text
fcd = alpha_cc * fck / gamma_c
```

Default values unless project settings override them:

```text
alpha_cc = 0.85
gamma_c = 1.50
```

### Concrete Tension

Concrete tensile stress is ignored:

```text
if concrete strain is tensile:
    sigma_c = 0
```

Do not remove the concrete compression block solely because the total axial force is negative.

Correct rule:

```text
if no concrete fiber has compressive strain:
    concrete compression contribution = 0
else:
    compute concrete compression from the compressed concrete fibers/region
```

### Concrete Compression Stress-Strain

Preferred EC2 fiber benchmark model: parabola-rectangle.

For normal strength concrete:

```text
0 <= ec <= ec2:
    sigma_c = fcd * (1 - (1 - ec / ec2)^n)

ec2 < ec <= ecu2:
    sigma_c = fcd
```

Suggested defaults:

```text
ec2 = 0.002
ecu2 = 0.0035
n = 2.0
```

Equivalent rectangular stress block may be implemented as a separate simplified comparison mode, but it must not replace the main fiber benchmark unless the task explicitly requests it.

### Reinforcement Design Strength

Use:

```text
fyd = fyk / gamma_s
gamma_s = 1.15
Es = 200000 MPa
eyd = fyd / Es
```

Elastic-perfectly plastic model:

```text
if abs(es) <= eyd:
    sigma_s = Es * es
else:
    sigma_s = sign(es) * fyd
```

## Fiber Section Model

Concrete fibers should store:

```text
x, y, area, strain, stress, force, Mx contribution, My contribution, zone
```

Rebar fibers should store:

```text
x, y, area, strain, stress, force, Mx contribution, My contribution, yielding state
```

The first implementation may focus on rectangular sections only. Do not hard-code this assumption into public interfaces if the existing architecture already allows future extension.

## Strain Compatibility

For each analysis state:

```text
strain(x, y) = epsilon0 + curvature * projected_distance(theta, x, y)
```

The exact sign convention must match the existing MBColumn solver convention. Before changing code, confirm how the current solver defines:

- positive compression strain
- positive Mx
- positive My
- neutral axis angle theta
- chart orientation

All of these must remain consistent:

- strain field
- stress calculation
- PMM point calculation
- neutral axis drawing
- compression/tension hatch regions
- tooltip/result labels

## PMM Surface Generation

Generate the EC2 PMM surface by sweeping:

- neutral axis angle theta
- neutral axis depth or strain state
- curvature / extreme compression strain state

Recommended first approach:

1. Sweep theta from 0 to 360 degrees.
2. For each theta, sweep neutral axis depth c over a range that covers:
   - high compression
   - neutral axis inside the section
   - neutral axis outside the section
   - tension-dominant states
3. Compute strain for every concrete fiber and steel bar.
4. Apply EC2 material laws.
5. Integrate forces and moments.
6. Store N, Mx, My, concrete contribution, steel contribution, strain limits, and state label.

## Eurocode State Labels

Do not use ACI labels such as:

- balanced point
- tension controlled
- compression controlled
- fs = 0
- fs = 0.5fy
- phi-controlled labels

Use Eurocode-style engineering labels:

- Maximum compression resistance
- Compression with bending
- Steel yielding boundary
- Strain transition state
- Pure bending, N approximately 0
- Tension with bending
- Maximum tension resistance

If a balanced-like point is needed for debugging, call it:

```text
steel yielding boundary / strain transition
```

## PMM Ratio Logic

For Eurocode mode:

- Use EC2 design strengths directly.
- Do not apply ACI phi factors.
- Compute demand/capacity ratio through directional capacity search or another documented solver-agnostic method.
- Keep the ratio method isolated so ACI mode can continue using its existing path.

Recommended ratio definition:

```text
Demand D = (NEd, MxEd, MyEd)
Capacity C = intersection of the ray/direction through D with the EC2 design PMM surface
PMM ratio = |D| / |C|
```

Document the reference point and interpolation method used for the ray/directional search.

## Visualization Requirements

For selected EC2 PMM states, the section viewer should show:

- section outline
- rebar locations
- neutral axis
- concrete compression region/fibers
- concrete tension region/fibers
- rebar tension/compression/yield state
- optional resultant arrows for concrete compression and steel forces

Hatch annotation:

- concrete compression region: shaded or hatched
- concrete tension region: different hatch
- labels:
  - `Concrete in compression`
  - `Concrete in tension - ignored`

Important:

- If total axial load is negative, do not automatically hide concrete compression.
- Concrete compression exists whenever at least one concrete fiber has compressive strain.
- Concrete compression disappears only when the entire concrete section is tensile.
- Hatch and neutral axis orientation must update with the selected theta/load case.

## Validation Test Cases

Add or preserve tests for:

1. Existing ACI/spColumn-style baseline remains unchanged.
2. EC2 concrete tensile stress is zero.
3. EC2 steel carries both tension and compression.
4. Symmetric square section gives symmetric PMM response.
5. Rectangular section gives different strong-axis and weak-axis bending resistance.
6. Negative axial load with bending may still produce a concrete compression zone.
7. Full-section tension produces zero concrete compression contribution.
8. EC2 mode does not use ACI phi factors.
9. EC2 charts do not show ACI-specific control-point labels.
10. Shared chart controls still render existing ACI/spColumn-style data.

## Suggested Validation Exports

When building a validation runner, export:

```text
section_definition.json
material_definition.json
pmm_surface.csv
pmm_surface.json
selected_state_debug.csv
comparison_report.md
```

`pmm_surface.csv` columns:

```text
theta_deg,state_id,N,Mx,My,concrete_N,steel_N,concrete_Mx,concrete_My,steel_Mx,steel_My,max_concrete_strain,min_concrete_strain,max_steel_strain,min_steel_strain,label
```

`selected_state_debug.csv` columns:

```text
fiber_id,type,x,y,area,strain,stress,force,Mx_contribution,My_contribution,zone
```

## OpenSeesPy Validation Position

OpenSeesPy can be used as an independent numerical fiber-section validation engine, but it is not a ready-made Eurocode PMM design module.

If used, agents must explicitly map EC2 assumptions into the model:

- fcd
- fyd
- EC2 concrete stress-strain model
- concrete tension ignored
- steel elastic-perfectly plastic or selected EC2-compatible model
- strain limits
- design-strength basis

Do not claim OpenSeesPy has built-in EC2 PMM code-check logic unless a specific implementation is added and reviewed.

## Acceptance Criteria

A change using this skill is acceptable only if:

- Eurocode logic is isolated from the existing ACI/spColumn-style path.
- Existing ACI/spColumn-style tests still pass or are explicitly shown unchanged by regression checks.
- Concrete tension is ignored in EC2 mode.
- Concrete compression is based on compressive strain region/fibers, not on axial load sign.
- Steel tension and compression are included.
- EC2 material partial factors are not applied to ACI mode.
- ACI phi factors are not applied to EC2 mode.
- Charts remain solver-agnostic where possible.
- Engineering assumptions touched are listed in the change summary.
- Limitations and required manual validation are documented.

## Required Agent Change Summary

Every implementation response must include:

1. Files changed.
2. Whether any shared ACI/spColumn-style code was touched.
3. Regression tests run for existing ACI/spColumn-style behavior.
4. EC2 engineering assumptions touched.
5. Known limitations.
6. Follow-up validation required.

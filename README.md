# MBColumn

MBColumn is a clean-room .NET 8 WPF desktop application for reinforced-concrete column PMM interaction checks.

It is designed for learning, validation, and preliminary engineering review workflows. It is not a certified design-code engine.

> [!TIP]
> **For AI Coding Agents / Developers:**
> 1. To quickly understand the application architecture, domain entities, DTOs, services, and solvers, please read the comprehensive class diagram in [src/class_diagram.md](file:///c:/repo/MBColumn/MBColumn/src/class_diagram.md) first. This will save token context space and speed up your workflow.
> 2. Whenever you modify C# source files (`.cs`), you **MUST** regenerate the class diagram by running `python tools/update_class_diagram.py` (or configure Git to use local hooks via `git config core.hooksPath .githooks`).

## Current Scope

- Rectangular reinforced-concrete column sections.
- Circular reinforced-concrete column sections.
- Irregular (polygon) reinforced-concrete column sections via user-entered boundary points and rebar coordinates. Polygon integration only in this milestone; boundary/rebar can be edited or imported/exported through the stable CSV contract (`# MBColumnCsvVersion=1`). Boundary points must be entered clockwise; the polygon is implicitly closed.
- Live section preview with cover line, rebars, centroid, local axes, dimensions, and sign-convention reference image.
- PM angle diagram, PMx/PMy-style slices, Mx-My diagram, and 3D PMM interaction surface.
- PMM demand/capacity ratio using directional capacity search against the design capacity surface.
- Multiple load-case workflow with governing-ratio selection.
- Metric and Imperial input workflows.
- Singapore metric rebar notation and US imperial rebar notation.
- ACI 318-style calculation path.
- Eurocode 2 calculation path with separated EC2 material, stress-block, strain-limit, and ratio assumptions.
- Section integration method selection:
  - Fiber integration.
  - Polygon stress-block integration.

## How To Run

```powershell
dotnet build MBColumn.sln
dotnet run --project src\MBColumn.Presentation.Wpf\MBColumn.Presentation.Wpf.csproj
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj
```

Build artifacts are redirected to the `built/` directory. The final binaries can be found in `built/bin/`.

### Auto-Updating Class Diagram (Recommended)

To automatically keep the architecture and class diagram in [src/class_diagram.md](file:///c:/repo/MBColumn/MBColumn/src/class_diagram.md) perfectly synchronized with C# source file changes:

1. **Configure Git Hooks** (Run once after cloning to automatically regenerate the diagram on every commit):
   ```powershell
   git config core.hooksPath .githooks
   ```

2. **Run Live File Watcher** (Optional, to automatically update the diagram in real-time as you edit and save code in your IDE):
   ```powershell
   python tools/watch_class_diagram.py
   ```

## Repository Guide

```text
docs/        Engineering assumptions, architecture contracts, UI notes, validation workflow, and review checklists.
src/         Application source code.
tests/       Unit tests.
tools/       Validation tools and scripts.
scratch/     Temporary scripts and extracts.
reports/     Validation reports, logs, and output files.
_ref/        Reference materials (offline binaries and source).
built/       Build artifacts (bin and obj).
AGENTS.md   Coding-agent instruction router.
CLAUDE.md   Claude Code workflow notes.
```

Use `docs/` as the single source of truth for project documentation.

## Internal Unit Convention

The calculation engine uses one internal unit system:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa = N/mm2

All UI values are converted at the application boundary through `IUnitConversionService`. The solver should not receive display units or rebar notation.

## Sign Convention

Axial compression is positive. Axial tension is negative.

The internal coordinate origin is the section centroid.

The current solver sums moments about the section centroid using:

- `Mx = -force * y`
- `My =  force * x`

This applies consistently to concrete and steel force resultants in the current integration code.

## Solver Architecture

The active PMM solver is organized as:

```text
PmmInteractionSolver
-> PmmSolver
   -> ISweepStrategy
   -> ISectionIntegrator
   -> IDesignCodeAdapter
```

Main responsibilities:

- `NeutralAxisSweepStrategy` generates neutral-axis states by angle and neutral-axis depth.
- `FiberSectionIntegrator` integrates concrete fibers and discrete rebars.
- `PolygonSectionIntegrator` clips the compressed concrete polygon and adds discrete rebar forces.
- `Aci318DesignAdapter` and `Eurocode2DesignAdapter` convert nominal integration output into design capacity points.
- `DiagramDataService` and `PmCurveBuilderService` convert solver points into PM, Mx-My, and 3D PMM chart datasets.

The UI/chart engine should stay solver-agnostic. Adding or changing a design code should change calculated data and labels, not duplicate chart controls.

## Neutral-Axis Sweep Logic

The current sweep samples:

- Angle: `AngleStepDegrees`, default 10 degrees.
- Depth: `NeutralAxisSamples`, default 100 samples.
- Maximum sampled neutral-axis depth: `10 * max(section width, section height)`.

For each neutral-axis state:

1. The compression normal is generated from the angle.
2. The extreme compression projection of the section is found.
3. Neutral-axis offset is calculated as `maxProjection - c`.
4. Concrete and steel strains are calculated from the plane-section assumption.
5. Invalid integration states are skipped.

## Integration Methods

### Fiber Integration

Fiber integration uses discrete concrete fibers and discrete rebars.

- Rectangular sections use a rectangular fiber grid.
- Circular sections use radial/angular concrete fibers.
- Concrete tension is ignored.
- Concrete compression stress follows the active design-code service.
- Steel is elastic-perfectly plastic and capped by the active design-code steel strength.
- Compression steel subtracts displaced concrete stress at the bar location.

### Polygon Integration

Polygon integration uses compressed-zone clipping.

- Rectangular sections use the rectangular boundary.
- Circular sections use a polygonal circular boundary controlled by `CirclePolygonSegmentCount`.
- The compression polygon is clipped by the stress-block projection.
- Concrete force is stress block stress multiplied by clipped area.
- Concrete moment is calculated from the clipped polygon centroid.
- Rebar force is still integrated discretely.

## Design-Code Paths

Design-code assumptions are isolated behind `IDesignCodeService` and `IDesignCodeAdapter`.

### ACI 318-Style Path

The ACI-style path currently includes:

- Plane sections remain plane.
- Maximum concrete compression strain is `0.003`.
- Concrete tension is ignored.
- Concrete stress block factor is `0.85`.
- ACI `beta1` is provided by `Aci318DesignCodeService`.
- Steel strength uses `fy` directly.
- Phi factor is based on maximum tensile steel strain.
- Tied-column compression design cap is handled through the ACI design-code service and PM curve/data services.
- Slenderness and second-order effects are excluded.

### Eurocode 2 Path

The EC2 path is implemented as a separate design-code route.

- EC2 material factors, concrete strain limits, steel design strength, and stress-block assumptions are separated from ACI logic.
- EC2 design points use the common solver and chart pipeline.
- EC2 phi is treated through the active EC2 design-code service/adaptor route rather than by mutating ACI logic.

See:

- `docs/engineering/eurocode/eurocode-pmm-overview.md`
- `docs/engineering/eurocode/eurocode-chart-reuse-contract.md`
- `docs/engineering/eurocode/ec2-material-model.md`
- `docs/engineering/eurocode/ec2-stress-block.md`
- `docs/engineering/eurocode/ec2-strain-limits.md`
- `docs/engineering/eurocode/ec2-pmm-ratio.md`

## Nominal vs Design Capacity Data

The solver and diagram pipeline keep nominal and design capacity data separated.

- Nominal points store `Pn`, `Mnx`, and `Mny`.
- Design points store `PhiPn`, `PhiMnx`, and `PhiMny` or the equivalent design-reduced values for the active code.
- PM, Mx-My, and 3D PMM diagrams can render both nominal and design capacity datasets.
- Demand points and governing points are kept separate from capacity polylines.
- ACI PM charts expose nominal reference curves and phi-reduced design curves separately.

## 2D and 3D Diagram Logic

### PM Angle Diagram

The PM angle diagram projects 3D capacity points to a selected bending direction:

- `Mtheta = Mx * cos(theta) + My * sin(theta)` for demand/report projection.
- Capacity envelopes are built from constant-P rings and projected to the selected PM angle.
- Nominal and design curves are built separately.
- Reference lines such as `Pmax` and `Pmin` are stored as reference datasets, not capacity points.

### Mx-My Diagram

The Mx-My diagram is generated at a selected axial load level.

- Boundary points are interpolated from the PMM surface at the selected display `P`.
- Nominal and design boundaries are kept as separate groups.
- Demand and governing markers are added after capacity boundary generation.

### 3D PMM Surface

The 3D PMM surface is rendered from resampled constant-P levels.

- The surface is rebuilt into P-level rings for cleaner visual topology.
- Wireframe lines connect horizontal P-level rings and vertical theta meridians.
- Mesh triangles are generated between adjacent rings.
- Demand and governing markers are added separately from the capacity mesh.

## Rebar Tables

Singapore metric bars:

| Bar | Diameter |
| --- | --- |
| T10 | 10 mm |
| T13 | 13 mm |
| T16 | 16 mm |
| T20 | 20 mm |
| T25 | 25 mm |
| T32 | 32 mm |
| T40 | 40 mm |

Area is calculated as `pi d^2 / 4`, except where database values are intentionally set to match common bar table conventions.

US bars:

`#3`, `#4`, `#5`, `#6`, `#7`, `#8`, `#9`, `#10`, `#11`.

US diameter and area are stored in inch-based source values and converted to mm and mm2 before solving.

## Engineering UI

- Input tab includes a live `SectionPreviewCanvas` without running the PMM solver.
- Load-case inputs can be edited through the UI and evaluated in batch.
- Result tab uses a dashboard for PM, Mx-My, and 3D PMM results.
- 2D charts support visible axes, engineering tick labels, grid control, wheel zoom, pan, reset, point tooltips, and optional legend/reference-line display.
- 3D charts support orbit, zoom, pan, reset, grid toggle, wireframe toggle, axial slice, and theta slice controls.
- Display scaling is isolated in chart controls/helpers; tooltips and labels keep true engineering display units.
- Result views should be recalculated after input changes before being treated as current.

See:

- `docs/SECTION_PREVIEW.md`
- `docs/CHART_INTERACTION.md`
- `docs/engineering/eurocode/eurocode-chart-reuse-contract.md`

## Validation Workflow

Run tests after changes:

```powershell
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj
```

Recommended validation documents:

- `docs/validation/validation-workflow.md`
- `docs/validation/regression-tests.md` if present
- `docs/engineering/eurocode/worked-example.md`

The test project currently covers unit conversion, input validation, section preview behavior, PMM ratio checks, nominal/design split, diagram mapping, 3D PMM topology, integration method propagation, circular section support, ACI fiber checks, EC2 simplified stress-block checks, and regression guards.

All engineering outputs must be independently verified by a qualified structural engineer before design or construction use.

## Known Limitations

- This is a preliminary checking and validation tool, not a certified design-code engine.
- Neutral-axis sweep is sample-based, not an exact closed-form interaction solution.
- Fiber integration is approximate and depends on fiber density.
- Circular polygon integration accuracy depends on polygon segment count.
- Slenderness, minimum eccentricity, confinement, bar development, fire design, seismic detailing, and second-order effects are excluded.
- 3D WPF view is a lightweight custom projected surface/contour renderer.
- Ratio interpolation is conservative but simplified for MVP use.
- Design-code implementation should be validated against independent hand calculations and trusted reference software before production use.

## Disclaimer

MBColumn is for study, validation, and preliminary checking only. It must not be used as the sole basis for engineering design or construction decisions.

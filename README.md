# MBColumn

MBColumn is a clean-room .NET 8 WPF desktop application for reinforced-concrete rectangular column PMM interaction checks.

It is designed for learning, validation, and preliminary engineering review workflows. It is not a certified design-code engine.

## Current Scope

- Rectangular reinforced-concrete column sections.
- Live section preview with cover line, rebars, centroid, local axes, and dimensions.
- PMx diagram, PMy diagram, Mx-My diagram, and 3D PMM interaction surface.
- PMM demand/capacity ratio using directional capacity search.
- Metric and Imperial input workflows.
- Singapore metric rebar notation and US imperial rebar notation.
- ACI-style calculation path currently implemented.
- Eurocode documentation and implementation guidance prepared for future design-code expansion.

## How To Run

```powershell
dotnet build MBColumn.sln
dotnet run --project src\MBColumn.Presentation.Wpf\MBColumn.Presentation.Wpf.csproj
dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj
```

Build artifacts are redirected to the `built/` directory. The final binaries can be found in `built/bin/`.

## Repository Guide

```text
docs/        Engineering assumptions, architecture contracts, UI notes, and validation workflow.
src/         Application source code.
tests/       Unit tests.
_ref/        Reference materials (spColumn binaries and source).
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
- Stress: MPa

All UI values are converted at the application boundary through `IUnitConversionService`. The solver should never receive display units or rebar notation.

## Sign Convention

Axial compression is positive. Axial tension is negative.

Moments are summed about the section centroid using:

- `Mx = force * y`
- `My = -force * x`

The internal coordinate origin is the section centroid.

## Design-Code Architecture

Design-code assumptions should be isolated behind dedicated services.

Expected direction:

```text
DesignCodeService
-> Common PMM Solver / Interaction Surface Model
-> Diagram Data Services
-> ViewModels
-> WPF Chart Controls
```

The UI/chart engine should stay solver-agnostic. Adding a new design code should change the calculated data and labels, not duplicate the chart controls.

## ACI-Style Assumptions

The current implemented calculation path follows these simplified ACI-style assumptions:

- Plane sections remain plane.
- Maximum concrete compression strain is 0.003.
- Concrete tension is ignored.
- Concrete compression is represented by fiber integration using `0.85 fc`.
- Steel is elastic-perfectly plastic and capped at `+/- fy`.
- Phi factor is implemented in `Aci318DesignCodeService`.
- Slenderness and second-order effects are excluded.

## Eurocode Direction

Eurocode support should be implemented as a separate design-code path.

Key rules:

- Do not mutate ACI logic directly to implement Eurocode behavior.
- Reuse the common solver, diagram data, ViewModel, and chart pipeline where appropriate.
- Keep EC2 material model, strain limits, stress block, and ratio logic separated from ACI assumptions.
- Reuse existing 2D/3D chart controls for Eurocode PMM charts.

See:

- `docs/engineering/eurocode/eurocode-pmm-overview.md`
- `docs/engineering/eurocode/eurocode-chart-reuse-contract.md`
- `docs/engineering/eurocode/ec2-material-model.md`
- `docs/engineering/eurocode/ec2-stress-block.md`
- `docs/engineering/eurocode/ec2-strain-limits.md`
- `docs/engineering/eurocode/ec2-pmm-ratio.md`

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

Area is calculated as `pi d^2 / 4`.

US bars:

`#3`, `#4`, `#5`, `#6`, `#7`, `#8`, `#9`, `#10`, `#11`.

US diameter and area are stored in inch units and converted to mm and mm2 before solving.

## Engineering UI

- Input tab includes a live `SectionPreviewCanvas` without running the PMM solver.
- Result tab uses a 2x2 dashboard: PMx, PMy, 3D PMM, and Mx-My.
- 2D charts support visible axes, engineering tick labels, grid toggle, wheel zoom, pan, reset, and point tooltips.
- 3D charts support orbit, zoom, pan, reset, grid toggle, and wireframe toggle.
- Display scaling is isolated in chart controls/helpers; tooltips and labels keep true engineering display units.

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

All engineering outputs must be independently verified by a qualified structural engineer before design or construction use.

## Known Limitations

- Rectangular sections only.
- Fiber concrete approximation rather than exact stress-block polygon clipping.
- No slenderness, minimum eccentricity, confinement, bar development, or second-order effects.
- 3D WPF view is a lightweight custom projected surface/contour renderer.
- Ratio interpolation is conservative but simplified for MVP use.

## Disclaimer

MBColumn is for study, validation, and preliminary checking only. It must not be used as the sole basis for engineering design or construction decisions.


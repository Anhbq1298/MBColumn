# MBColumn

Mini WPF desktop application for rectangular reinforced concrete column PMM interaction checks.

## How To Run

```powershell
dotnet build MBColumn.sln
dotnet run --project src\ColumnDesigner.Presentation.Wpf\ColumnDesigner.Presentation.Wpf.csproj
dotnet run --project tests\ColumnDesigner.Tests\ColumnDesigner.Tests.csproj --no-build
```

## Scope

- Rectangular reinforced concrete sections.
- Live section preview, PMx diagram, PMy diagram, Mx-My diagram, and 3D PMM surface view.
- PMM demand/capacity ratio using a directional capacity search.
- Metric and Imperial input workflows.
- Singapore metric rebar notation and US imperial rebar notation.

## Internal Unit Convention

The calculation engine uses one internal unit system:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa

All UI values are converted at the application boundary through `IUnitConversionService`. The solver never receives display units or rebar notation.

## Sign Convention

Axial compression is positive. Tension is negative. Moments are summed about the section centroid using:

- `Mx = force * y`
- `My = -force * x`

The internal coordinate origin is the section centroid.

## ACI-Style Assumptions

- Plane sections remain plane.
- Maximum concrete compression strain is 0.003.
- Concrete tension is ignored.
- Concrete compression is represented by fiber integration using `0.85 fc`.
- Steel is elastic-perfectly plastic and capped at `+/- fy`.
- Phi factor is implemented in `Aci318DesignCodeService`.
- Slenderness and second-order effects are excluded.

This is an ACI-style educational implementation, not a certified design-code engine.

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

## Validation Workflow

The implementation was reviewed against the local `developing-skills` checklists:

- Senior software architecture review.
- Senior structural engineering review.
- PMM calculation validation.
- ACI-style design assumption review.
- Unit and sign convention validation.
- Diagram validation.
- Numerical stability review.

Run the test runner after changes. All engineering outputs must be independently verified by a qualified structural engineer before design or construction use.

## Engineering UI

- The input tab includes a live `SectionPreviewCanvas` that draws the rectangular section, cover line, generated rebars, centroid, local axes, and dimension labels without running the PMM solver.
- The result tab is a 2x2 dashboard: PMx, PMy, 3D PMM, and Mx-My.
- 2D charts support visible axes, engineering tick labels, grid toggle, wheel zoom, left-drag pan, double-click reset, and point tooltips.
- 3D charts support Shift + left-drag orbit, wheel zoom, Ctrl/middle-drag pan, double-click reset, grid toggle, and wireframe toggle.
- Display scaling is isolated in chart controls/helpers; tooltips and labels keep true engineering display units.

See `docs/SECTION_PREVIEW.md` and `docs/CHART_INTERACTION.md`.

## Known Limitations

- Rectangular sections only.
- Fiber concrete approximation rather than exact stress-block polygon clipping.
- No slenderness, minimum eccentricity, confinement, bar development, or second-order effects.
- 3D WPF view is a lightweight custom projected surface/contour renderer, not a HelixToolkit mesh renderer.
- Ratio interpolation is conservative but simplified for MVP use.

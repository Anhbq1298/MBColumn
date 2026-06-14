# Programming Skill Set

Use this file before changing implementation code in MBColumn.

## Product Context

MBColumn is a .NET 8 WPF/MVVM desktop application for reinforced-concrete column PMM interaction checks. It supports rectangular, circular, and irregular polygon column sections, metric and imperial display units, multiple load cases, ACI-style and Eurocode 2 calculation paths, PM/Mx-My/3D PMM diagrams, PDF/HTML reporting, ETABS import workflows, and automated rebar suggestions.

The application is for study, validation, and preliminary checking only. It is not a certified design-code engine.

## Repository Map

- `src/MBColumn.Domain`: entities, enums, interfaces, and solver-neutral domain contracts.
- `src/MBColumn.Application`: DTOs, validators, orchestration services, diagram/report data builders, and app-level conventions.
- `src/MBColumn.Infrastructure`: solvers, integration engines, design-code services, rebar databases, ETABS import services, report renderers, persistence, and math utilities.
- `src/MBColumn.Presentation.Wpf`: WPF views, view models, custom chart/section controls, commands, services, themes, and UI resources.
- `tests/MBColumn.Tests`: console-style regression harness plus targeted regression entry points.
- `tools`: local utilities such as class-diagram generation scripts.
- `built`: redirected build outputs.

## Daily Commands

```powershell
dotnet build MBColumn.sln
dotnet build tests\MBColumn.Tests\MBColumn.Tests.csproj
dotnet run --project src\MBColumn.Presentation.Wpf\MBColumn.Presentation.Wpf.csproj
dotnet run --project tests\MBColumn.Tests\MBColumn.Tests.csproj -- --run-pmm-theta-regressions
```

`dotnet test tests\MBColumn.Tests\MBColumn.Tests.csproj` only verifies project/test-host compatibility because the test project is an executable harness. Use targeted `dotnet run --project ... -- --run-*` modes or the full harness when validating behavior.

If a C# file is changed, run:

```powershell
python tools\update_class_diagram.py
```

## Coding Rules

- Keep solver and design-code math out of WPF view models and controls.
- Convert units at application boundaries through `IUnitConversionService` / `UnitConversionService`.
- Do not pass display units into the solver.
- Preserve nominal/design capacity separation.
- Keep demand, governing, reference, nominal, and design points as distinct data groups.
- Prefer existing DTOs and services over new parallel models.
- Avoid duplicated engineering calculations in chart/report/UI layers.
- Keep comments short and useful, especially around convention mappings.
- When changing report output, update both ACI and EC2 report builders unless the change is code-specific.

## Current Theta Rule

The current source of truth for user-facing PMM theta is:

- `CalculationResultDto.GoverningMomentThetaDegrees`
- `LoadCaseResultDto.GoverningMomentThetaDegrees`
- `PmmAngleConvention`

Internal solver points may store compression-normal theta. UI and reports must display only moment-vector theta. Use `PmmAngleConvention.MomentFromCompressionNormal`, `CompressionNormalFromMoment`, and `FormatMomentTheta` instead of ad hoc conversion or formatting.

PMM Details, chart demand DTOs, PMM report tables, and report captions must use the same moment-theta source for the same section, load case, and PMM result.

## Verification Checklist

- `dotnet build MBColumn.sln` passes with no new warnings.
- `dotnet build tests\MBColumn.Tests\MBColumn.Tests.csproj` passes.
- Run targeted regression modes relevant to the change.
- For theta/report work, run `--run-pmm-theta-regressions`.
- For ETABS import changes, run `--run-etabs-import-regressions`.
- For EC2 shear changes, run `--run-ec2-shear-regressions`.
- For rebar compliance changes, run `--run-rebar-compliance-regressions`.
- For project persistence changes, run `--run-project-save-regressions`.

## Known Caution Points

- The full console harness may hit unrelated UI-state regressions before later tests. Prefer targeted modes for focused work.
- Generated report files and benchmark outputs may change during validation runs.
- Keep unrelated dirty worktree changes intact.
- Do not treat report formatting fixes as solver validation.

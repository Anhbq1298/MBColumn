# AGENTS.md

Repository-level instructions for AI coding agents working on MBColumn.

## Project Summary

MBColumn is a clean-room .NET 8 WPF/MVVM desktop application for rectangular reinforced-concrete column PMM interaction checks.

The application is intended for study, validation, and preliminary checking only. It is not a certified structural design program.

## Agent Entry Point

This file is the primary instruction router for Codex and other coding agents. Keep it short, stable, and focused on what to read before editing.

## Required Context Order

Before making code changes, read these files in order:

1. `README.md`
2. `BUILD_NOTES.md`
3. `docs/architecture/system-overview.md` if present
4. `docs/ui/global-style-guide.md` if UI is touched
5. The task-specific engineering or validation file listed below
6. The minimum source files needed for the task

Legacy skill files under `developing-skills/_skills/` may still exist. Use them as supporting review checklists, but prefer the organized `docs/` tree as the main source of truth once the equivalent file exists there.

Do not load unrelated source files unless required.

## Architecture Rules

- Keep engineering entities and solver primitives outside WPF.
- WPF controls render already-computed diagram/control-point data only.
- ViewModels coordinate UI state, commands, and service calls; they must not contain PMM capacity algorithms.
- Application layer coordinates use cases and validation.
- Infrastructure may contain design-code services, unit conversion, and numerical helpers.
- Domain should stay independent from WPF and UI frameworks.
- Tests must target calculation logic independently from UI rendering.

## Engineering Rules

- Internal solver units are always N, mm, N-mm, and MPa.
- Convert display units only at the application boundary.
- Axial compression is positive; axial tension is negative.
- Moment convention is about section centroid:
  - `Mx = force * y`
  - `My = -force * x`
- Concrete tension stress is ignored.
- Steel may carry compression and tension according to the selected material model.
- Do not silently change ACI-style assumptions.
- Do not introduce Eurocode assumptions into ACI logic unless the task explicitly asks for it.
- Eurocode logic must be implemented as a separate design-code path, not by mutating ACI logic in place.

## Clean-Room Rule

A decompiled reference folder may exist for behavioral comparison only. Do not copy, translate, port, or structurally mirror proprietary source code. Implement from public engineering theory, public code provisions, and independently written architecture.

## Task Routing

### PMM / solver / strain compatibility tasks

Read:

- `docs/engineering/pmm/solver-overview.md` if present
- `docs/engineering/validation/numerical-stability.md` if present
- `developing-skills/_skills/04_PMMCalculationValidation.md` if present
- `developing-skills/_skills/09_NumericalStabilityReview.md` if present

### ACI-style design-code tasks

Read:

- `docs/engineering/aci/pmm-logic.md` if present
- `developing-skills/_skills/05_CodeDesignValidation_ACI318.md` if present

### Eurocode design-code tasks

Read all of these before editing Eurocode behavior:

- `docs/engineering/eurocode/eurocode-pmm-overview.md`
- `docs/engineering/eurocode/ec2-material-model.md`
- `docs/engineering/eurocode/ec2-strain-limits.md`
- `docs/engineering/eurocode/ec2-stress-block.md`
- `docs/engineering/eurocode/ec2-pmm-ratio.md`
- `docs/engineering/eurocode/eurocode-chart-reuse-contract.md`
- `docs/engineering/eurocode/worked-example.md`

### UI / chart / rendering tasks

Read:

- `docs/ui/global-style-guide.md` if present
- `docs/ui/chart-style.md` if present
- `docs/CHART_INTERACTION.md` if present
- `docs/SECTION_PREVIEW.md` if section preview is touched
- `developing-skills/_skills/08_ResultDiagramValidation.md` if present

### Architecture / refactor tasks

Read:

- `docs/architecture/system-overview.md` if present
- `docs/architecture/mvvm-pattern.md` if present
- `developing-skills/_skills/02_SeniorSoftwareArchitectReview.md` if present

### Release / review tasks

Read:

- `docs/validation/engineering-validation-checklist.md` if present
- `docs/validation/regression-tests.md` if present
- `developing-skills/_skills/10_FinalReleaseChecklist.md` if present
- `developing-skills/docs/VALIDATION_WORKFLOW.md` if present

## Required Agent Output

Every change response must include:

1. Files changed.
2. Engineering assumptions touched.
3. Tests added, updated, or not run.
4. Known limitations.
5. Any follow-up validation required.

## Build and Test

Use:

```powershell
dotnet build MBColumn.sln
dotnet test tests\ColumnDesigner.Tests\ColumnDesigner.Tests.csproj
```

If tests cannot be run, state why.

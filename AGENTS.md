# AGENTS.md

Repository-level instructions for AI coding agents working on MBColumn.

## Project Summary

MBColumn is a clean-room .NET 8 WPF/MVVM desktop application for rectangular reinforced-concrete column PMM interaction checks.

The application is intended for study, validation, and preliminary checking only. It is not a certified structural design program.

## Required Context Order

Before making code changes, read these files in order:

1. `README.md`
2. `developing-skills/_skills/00_ProjectTruth.md`
3. The task-specific skill file from `developing-skills/_skills/`
4. Any relevant file in `docs/`
5. The minimum source files needed for the task

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

## Clean-Room Rule

A decompiled reference folder may exist for behavioral comparison only. Do not copy, translate, port, or structurally mirror proprietary source code. Implement from public engineering theory and independently written architecture.

## Task Routing

### PMM / solver / strain compatibility tasks

Read:

- `developing-skills/_skills/00_ProjectTruth.md`
- `developing-skills/_skills/04_PMMCalculationValidation.md`
- `developing-skills/_skills/09_NumericalStabilityReview.md`

### ACI-style design-code tasks

Read:

- `developing-skills/_skills/00_ProjectTruth.md`
- `developing-skills/_skills/05_CodeDesignValidation_ACI318.md`

### UI / chart / rendering tasks

Read:

- `developing-skills/_skills/00_ProjectTruth.md`
- `developing-skills/_skills/08_ResultDiagramValidation.md`
- `docs/CHART_INTERACTION.md`
- `docs/SECTION_PREVIEW.md` when section preview is touched

### Architecture / refactor tasks

Read:

- `developing-skills/_skills/00_ProjectTruth.md`
- `developing-skills/_skills/02_SeniorSoftwareArchitectReview.md`

### Release / review tasks

Read:

- `developing-skills/_skills/10_FinalReleaseChecklist.md`
- `developing-skills/docs/VALIDATION_WORKFLOW.md`

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

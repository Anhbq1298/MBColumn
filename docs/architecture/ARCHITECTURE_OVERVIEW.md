# Architecture Overview

MBColumn follows a strict clean-architecture layering. Each layer may only depend on layers further inward (toward Domain).

```
Presentation.Wpf
      │
      ▼
 Application
      │
      ▼
Infrastructure
      │
      ▼
   Domain
```

## Layer Responsibilities

### Domain (`src/MBColumn.Domain/`)

- Pure entities, enumerations, and interfaces.
- No WPF references. No file IO. No UI state.
- Examples: `DesignCodeType`, `SectionShapeType`, `InteractionSurface`, `IRebarDatabase`.

### Application (`src/MBColumn.Application/`)

- DTOs (input/output contracts), validators, and orchestration services.
- Builds chart data, control-point tables, and report structures.
- No `DrawingContext`, no `MessageBox`, no rendering logic.
- Key services: `ColumnCalculationService`, `DiagramDataService`, `ControlPointBuilderService`, `PmCurveBuilderService`.

### Infrastructure (`src/MBColumn.Infrastructure/`)

- Solver engine, design-code adapters, rebar databases, math utilities.
- All structural capacity calculations live here.
- No ViewModels. No XAML. No UI state.
- Key components: `PmmSolver`, `FiberSectionIntegrator`, `PolygonSectionIntegrator`, `Aci318DesignCodeService`, `Ec2DesignCodeService`.

### Presentation.Wpf (`src/MBColumn.Presentation.Wpf/`)

- WPF views, view models, custom controls, converters, commands.
- Binds to Application DTOs and services only.
- **Must never contain structural formulas or design-code calculations.**

## Critical Rule

```
UI must never directly calculate structural capacity.
Formulas belong in Infrastructure only.
```

## Related Docs

- [SOLVER_PIPELINE.md](SOLVER_PIPELINE.md) — detailed solver data flow
- [PROJECT_BOUNDARIES.md](PROJECT_BOUNDARIES.md) — enforced layer constraints
- [UI_STATE_FLOW.md](UI_STATE_FLOW.md) — input → calculation → result state machine

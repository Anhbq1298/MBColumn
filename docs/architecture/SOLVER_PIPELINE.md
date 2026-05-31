# Solver Pipeline

Documents the complete data flow from user input to rendered chart data.

## Pipeline Stages

```
User Input (UI)
       │
       ▼
  ColumnInputDto
       │
       ▼
  InputValidationService
       │ (throws on invalid geometry or rebar placement)
       ▼
  RebarCoordinateBuilderService
       │ (generates rebar (x, y, area) coordinates in mm)
       ▼
  DesignCodeServiceFactory
       │ (selects ACI 318 or EC2 rule set)
       ▼
  InteractionSolverFactory
       │ (selects solver: PmmSolver / CircularFiberInteractionSolver)
       ▼
  PmmSolver
    ├── NeutralAxisSweepStrategy
    │     (samples neutral-axis depth × angle → strain profiles)
    ├── FiberSectionIntegrator  OR  PolygonSectionIntegrator
    │     (integrates concrete + rebar forces and moments for each profile)
    └── IDesignCodeAdapter
          (applies phi factors and code-specific capacity limits)
       │
       ▼
  InteractionSurface (raw capacity points: Pn, Mnx, Mny, PhiPn, PhiMnx, PhiMny)
       │
       ▼
  ControlPointBuilderService
       │ (extracts key control points: Pmax, Pmin, balanced point, pure bending)
       ▼
  DiagramDataService
    ├── PmCurveBuilderService  → PmAngleDiagramDto
    ├── MxMyDiagramBuilder     → MxMyDiagramDto
    └── PmmSurfaceBuilder      → PmmSurfaceDto (3D mesh + wireframe)
       │
       ▼
  CalculationResultDto
       │
       ▼
  ResultViewModel  →  WPF Charts
```

## Key Invariants

| Rule | Where enforced |
|---|---|
| Rebar coordinates in mm (internal SI) | `RebarCoordinateBuilderService` |
| Forces in N, moments in N·mm (solver internal) | `PmmSolver` / `FiberSectionIntegrator` |
| Display units applied only at DTO boundary | `UnitConversionService` |
| Phi always ≤ 1.0; design capacity ≤ nominal | `IDesignCodeAdapter` implementations |
| No NaN or Infinity allowed in surface points | Validated by regression tests |
| Chart generation must not modify solver outputs | `DiagramDataService` is read-only |

## Protected Files

Do not modify formulas in these files without running regression tests first:

```
src/MBColumn.Infrastructure/Solvers/PmmSolver.cs
src/MBColumn.Infrastructure/Solvers/NeutralAxisSweepStrategy.cs
src/MBColumn.Infrastructure/Solvers/Integration/FiberSectionIntegrator.cs
src/MBColumn.Infrastructure/Solvers/Integration/PolygonSectionIntegrator.cs
src/MBColumn.Infrastructure/DesignCodes/Aci318DesignCodeService.cs
src/MBColumn.Infrastructure/DesignCodes/Ec2DesignCodeService.cs
src/MBColumn.Application/Services/ControlPointBuilderService.cs
src/MBColumn.Application/Services/DiagramDataService.cs
src/MBColumn.Application/Services/PmCurveBuilderService.cs
```

# Programming Architecture Skill Set

Use this file before making structural or cross-layer changes.

## Architecture Principle

MBColumn follows clean architecture with inward dependency flow:

```text
Presentation.Wpf
  -> Application
      -> Infrastructure
          -> Domain
```

Domain remains pure. Infrastructure implements calculation and external details. Application orchestrates workflows and builds DTOs. Presentation renders and coordinates UI state.

## Layer Responsibilities

### Domain

- Owns entities, enums, and interfaces.
- Must not reference WPF, view models, persistence, file IO, report renderers, or concrete UI services.
- Important concepts include `InteractionSurface`, `InteractionPoint`, `LoadDemand`, section shapes, unit/design-code enums, and solver/service interfaces.

### Application

- Owns DTOs, validation, orchestration, chart/report data mapping, and shared app conventions.
- Key services include `ColumnCalculationService`, `DiagramDataService`, `ControlPointBuilderService`, `PmCurveBuilderService`, `ControlPointTableBuilderService`, `PmChartInsetStateResolverService`, and `PmmAngleConvention`.
- Must not contain WPF drawing logic.
- May transform solver results into display/report DTOs, but must not duplicate solver math.

### Infrastructure

- Owns solvers, integration engines, code services, databases, ETABS services, report rendering back ends, and persistence details.
- Key calculation components include `PmmSolver`, `NeutralAxisSweepStrategy`, `FiberSectionIntegrator`, `PolygonSectionIntegrator`, `Aci318DesignCodeService`, and `Ec2DesignCodeService`.
- Must not depend on WPF view models or XAML.

### Presentation.Wpf

- Owns WPF views, view models, controls, commands, converters, theme resources, and user interaction.
- View models bind to Application DTOs and services.
- WPF controls render points and state; they must not calculate capacity.

## Solver Pipeline

```text
InputViewModel
  -> ColumnInputDto
  -> InputValidationService
  -> RebarCoordinateBuilderService
  -> DesignCodeServiceFactory
  -> InteractionSolverFactory
  -> PmmSolver / circular or irregular solver
  -> InteractionSurface
  -> RatioCheckService
  -> ControlPointBuilderService
  -> DiagramDataService
  -> CalculationResultDto
  -> ResultViewModel / report builders / chart controls
```

The solver uses N, mm, N-mm, and MPa internally. Display conversion happens at the service/DTO boundary.

## Design-Code Architecture

- ACI-style and Eurocode paths share the common solver/chart/report pipeline where possible.
- Design-code behavior is isolated behind `IDesignCodeService`, `IDesignCodeAdapter`, and factory services.
- ACI-style output tracks nominal capacity and phi-reduced design capacity.
- EC2 output applies material partial factors directly and generally has `phi = 1.0`.
- Do not mutate ACI logic to support EC2, or EC2 logic to support ACI.

## Diagram and Report Architecture

- Solvers produce interaction surfaces.
- Application services derive chart DTOs and report model blocks.
- WPF chart controls render DTOs only.
- Current report entry point is `CalculationReportBuilder`, which routes to `AciReportBuilder` or `Ec2ReportBuilder`.
- Report output should use the same DTO properties as PMM Details. Avoid recalculating display values in report builders unless projection is genuinely report-specific.

## Theta Architecture

There are two theta conventions:

- Solver compression-normal theta: internal neutral-axis/compression direction.
- User-facing moment theta: bending moment vector direction in the Mx-My plane.

Only user-facing moment theta belongs in UI and reports. Shared conversion and formatting live in `PmmAngleConvention`.

The current PMM result source of truth is:

```text
RatioCheckService.CriticalThetaDegrees
  -> ColumnCalculationService
  -> LoadCaseResultDto.GoverningMomentThetaDegrees
  -> CalculationResultDto.GoverningMomentThetaDegrees
  -> ResultViewModel / DiagramDataService / report builders
```

## Architecture Review Checklist

- No WPF references in Domain or Infrastructure solver code.
- No structural formulas in view models.
- No unit conversion inside solver loops except where input has already been normalized.
- No duplicated theta conversion logic outside `PmmAngleConvention`.
- No chart code that changes solver points.
- No report code using internal compression-normal theta for user text.
- Design/nominal capacity groups remain separate.
- Demand and governing markers remain outside capacity polylines/meshes.
- New design-code behavior is added through services/adapters/factories, not scattered conditionals.

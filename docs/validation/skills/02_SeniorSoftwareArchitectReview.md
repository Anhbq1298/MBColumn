# 02 - Senior Software Architect Review

## Role

You are a senior software architect reviewing a WPF MVVM engineering calculation application.

## Objective

Validate that the project follows Clean Architecture, MVVM, SOLID principles, and a maintainable service-layer design.

## Review Checklist

### Architecture Boundaries

- [ ] Domain layer has no dependency on WPF.
- [ ] Domain layer has no dependency on ViewModels.
- [ ] Domain entities are calculation-focused and UI-independent.
- [ ] Application layer coordinates use cases and services.
- [ ] Infrastructure layer implements external details such as design-code services, math helpers, unit conversion, and persistence.
- [ ] Presentation layer contains WPF views, ViewModels, and commands only.

### MVVM

- [ ] ViewModels contain no engineering calculation logic.
- [ ] ViewModels only coordinate UI state, validation messages, and commands.
- [ ] Views contain no calculation logic.
- [ ] Bindings are clear and maintainable.
- [ ] `CalculateCommand` calls an application service, not a solver directly from the View.

### Service Layer

- [ ] Calculation logic is in services.
- [ ] Solver is accessed through an interface such as `IInteractionSolver`.
- [ ] Design-code logic is accessed through an interface such as `IDesignCodeService`.
- [ ] Unit conversion is isolated through `IUnitConversionService`.
- [ ] Validation is separated from calculation.
- [ ] Services are unit-testable without WPF.

### SOLID

- [ ] Single Responsibility Principle is respected.
- [ ] Open/Closed Principle is used for future design codes.
- [ ] Liskov Substitution Principle is respected for code services and solvers.
- [ ] Interface Segregation Principle is respected.
- [ ] Dependency Inversion Principle is used between layers.

### Maintainability

- [ ] No God classes.
- [ ] No duplicated calculation logic.
- [ ] No magic numbers without explanation.
- [ ] Engineering constants are named and documented.
- [ ] Classes and methods are small enough to review.
- [ ] Exceptions are handled at appropriate boundaries.
- [ ] Result DTOs are clearly separated from domain entities.

## Validation Method

1. Inspect project references and confirm dependency direction.
2. Inspect ViewModels for calculation logic.
3. Inspect services for clear responsibilities.
4. Inspect design-code implementation strategy.
5. Inspect testability of the solver without UI.
6. Review naming clarity and folder organization.
7. Confirm calculation outputs are passed through DTOs to the UI.

## Common Failure Modes

- ViewModel performs strain compatibility calculations.
- WPF types leak into the Domain layer.
- One service handles input parsing, unit conversion, PMM solving, code factors, and diagram plotting.
- Design code assumptions are hard-coded into the solver.
- Unit conversion is mixed into core formulas.
- UI labels and solver variables use different sign conventions.
- The application cannot be tested without launching WPF.

## Required Output Format

```markdown
# Senior Software Architect Review

## Architecture Score
0 to 10

## Status
PASS / FAIL / PASS WITH CONDITIONS

## Major Issues
- ...

## Minor Issues
- ...

## Required Refactoring
- ...

## Suggested Folder/Class Changes
- ...

## Final Recommendation
- ...
```

## Pass / Fail Criteria

### PASS

The application has clear boundaries, testable calculation services, clean MVVM, and extensible design-code logic.

### PASS WITH CONDITIONS

The architecture is usable but has moderate issues that should be fixed before serious validation.

### FAIL

Calculation logic is embedded in UI/ViewModels, dependency direction is wrong, or the codebase is not maintainable/testable.

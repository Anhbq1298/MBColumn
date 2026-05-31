# Project Boundaries

Enforced constraints for each project in the solution. Violations indicate architectural drift and must be corrected before merging.

## MBColumn.Domain

**Allowed:**
- Pure entities, enums, interfaces, value objects.
- No external dependencies.

**Forbidden:**
- WPF references (`PresentationCore`, `WindowsBase`, `PresentationFramework`).
- File IO (`System.IO`).
- UI state of any kind.
- References to Application, Infrastructure, or Presentation layers.

---

## MBColumn.Application

**Allowed:**
- DTOs, validators, orchestration services, chart builders, report mappers.
- References to Domain only.

**Forbidden:**
- `DrawingContext`, `Visual`, `Geometry` (WPF rendering primitives).
- `MessageBox`, dialog services.
- Structural formulas (stress blocks, strain limits, phi factors).
- References to Infrastructure or Presentation layers.

---

## MBColumn.Infrastructure

**Allowed:**
- Solvers, design-code adapters, rebar databases, numerical utilities.
- All structural capacity calculations.
- References to Domain and Application.

**Forbidden:**
- ViewModels.
- XAML files.
- WPF UI state.
- References to Presentation layer.

---

## MBColumn.Presentation.Wpf

**Allowed:**
- Views (XAML + code-behind), ViewModels, custom controls, converters, commands.
- References to Application layer services and DTOs.
- References to Domain enums for binding.

**Forbidden:**
- Structural capacity formulas.
- Design-code calculations.
- Direct solver calls (must go through Application services).

---

## Dependency Graph Summary

```
Domain  ←  Application  ←  Infrastructure  ←  Presentation.Wpf
```

Arrows point in the direction of allowed dependency.  
No reverse dependencies are permitted.

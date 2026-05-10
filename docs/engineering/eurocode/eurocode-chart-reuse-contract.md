# Eurocode Chart Reuse Contract

## Purpose

This document confirms how Eurocode PMM charts should be integrated into MBColumn.

Eurocode chart generation must reuse the existing chart, rendering, interaction, scaling, and ViewModel infrastructure that already supports the ACI-style PMM diagrams.

Do not create a separate Eurocode-only UI engine unless the existing chart pipeline is proven insufficient.

## Core Rule

Eurocode changes belong behind the existing diagram data boundary.

The expected flow is:

```text
Eurocode Design-Code Service
-> Common PMM Solver / Interaction Surface Model
-> ControlPointBuilderService
-> DiagramDataService
-> Existing ViewModel
-> Existing WPF Chart Controls
```

The UI should not know whether the surface came from ACI or Eurocode except through labels, legends, selected design code, and optional annotations.

## What Should Be Reused

Reuse the existing infrastructure for:

- 2D PMx chart rendering
- 2D PMy chart rendering
- Mx-My chart rendering
- 3D PMM surface rendering
- grid toggle
- wireframe toggle
- zoom, pan, orbit, reset interactions
- engineering unit display
- tooltip formatting
- axis scaling
- control-point CSV export
- section preview canvas where applicable

## What May Differ by Design Code

Eurocode-specific logic may affect:

- material stress-strain assumptions
- concrete compression block
- design strength reduction / partial safety factors
- strain limits
- nominal vs design capacity curves
- PMM ratio evaluation
- chart labels and legends
- optional region annotations

These differences should be represented in the data passed to the existing chart pipeline, not by duplicating chart controls.

## Implementation Guidance

Prefer this pattern:

```text
IDesignCodeService
  Aci318DesignCodeService
  Eurocode2DesignCodeService

Common solver and diagram services consume IDesignCodeService outputs.
Existing UI binds to the same diagram models regardless of design code.
```

If additional Eurocode annotations are required, extend shared diagram DTOs carefully instead of creating Eurocode-only chart DTOs.

## Agent Checklist

Before implementing Eurocode chart work, confirm:

- existing ACI chart behavior remains unchanged
- existing chart controls are reused
- no duplicate PMM chart control is introduced unnecessarily
- design-code selection happens before diagram data generation
- Eurocode labels are clear in the chart title, legend, and tooltip
- unit conversion remains at the application boundary
- UI remains solver-agnostic
- regression tests cover both ACI and Eurocode data paths where possible

## Validation

A successful Eurocode chart implementation should prove that:

- ACI charts still render as before
- Eurocode charts render through the same chart controls
- switching design code changes the calculated data, not the UI engine
- 2D and 3D interactions still work
- tooltips and exported values remain in correct engineering units

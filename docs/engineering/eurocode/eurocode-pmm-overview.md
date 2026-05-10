# Eurocode PMM Overview

## Purpose

This document defines the intended high-level behavior for Eurocode-based PMM interaction calculations inside MBColumn.

The Eurocode implementation must remain separated from the ACI implementation while still reusing the common solver infrastructure where appropriate.

## Key Design Goals

- Preserve clean architecture boundaries.
- Keep the core numerical solver reusable.
- Isolate design-code assumptions into dedicated services.
- Prevent accidental mixing of ACI and Eurocode assumptions.
- Support future EC2 and EC8 expansion.

## General Assumptions

- Plane sections remain plane.
- Strain compatibility governs section behavior.
- Concrete tension is ignored.
- Steel may carry compression and tension.
- Internal units remain N, mm, N-mm, and MPa.

## Important Separation Rule

Do not mutate existing ACI logic directly.

Eurocode implementation should use:

- dedicated material model services
- dedicated stress-block logic
- dedicated reduction-factor logic
- dedicated ratio evaluation logic

while reusing shared geometry, meshing, visualization, and numerical infrastructure where appropriate.

## Expected Future Features

- EC2 PMM ratio checks
- EC8 seismic considerations
- second-order effects
- minimum eccentricity handling
- slenderness handling
- confinement behavior
- nonlinear material enhancement

## Validation Requirement

All Eurocode PMM outputs must be validated against:

- hand calculations
- worked examples
- independent engineering references
- benchmark software where legally appropriate

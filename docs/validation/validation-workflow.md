# Validation Workflow

This document defines the recommended validation workflow for the MBColumn reinforced concrete column PMM capacity application.

## Purpose

The `docs/` folder is the single source of truth for engineering assumptions, architecture rules, UI contracts, validation checklists, and AI coding-agent guidance.

Validation documents guide manual and AI-assisted review. They do not replace independent engineering judgment.

## Recommended Workflow

### 1. Implement or Update a Feature

Before review, ensure the feature is implemented in the correct layer:

- Domain: engineering entities and interfaces.
- Application: use cases, validation, calculation coordination.
- Infrastructure: design-code services, math helpers, unit conversion.
- Presentation: WPF views, ViewModels, commands, and visual controls.

### 2. Run Unit Tests

Run all available unit tests before manual review.

Minimum recommended test categories:

- input validation
- unit conversion
- pure axial compression
- pure axial tension
- uniaxial bending
- biaxial bending
- PMM ratio boundary checks
- diagram data consistency

### 3. Review Architecture

Confirm:

- MVVM is clean.
- ViewModels contain no calculation logic.
- Domain layer has no WPF dependency.
- Solver is unit-testable.
- Design-code logic is replaceable.

### 4. Review Engineering Logic

Confirm:

- Section geometry is correct.
- Rebar layout is correct.
- Material assumptions are documented.
- Strain compatibility logic is reasonable.
- PMM results are physically reasonable.

### 5. Validate PMM Solver

Confirm:

- Neutral-axis sweep is adequate.
- Concrete compression is calculated correctly.
- Steel strain and stress are calculated correctly.
- Interaction surface is smooth and symmetric where expected.
- PMM ratio is based on matching capacity direction.

### 6. Validate Design-Code Assumptions

For ACI and Eurocode paths, confirm:

- material assumptions are documented
- concrete stress block or stress-strain model is documented
- design strength or reduction factors are applied consistently
- axial limits are documented where applicable
- design-code paths remain separated

### 7. Validate Unit and Sign Convention

Confirm:

- internal base units are stated
- UI unit conversion is isolated from solver
- axial force sign convention is stated
- Mx and My sign convention is stated
- diagram axis labels match result values

### 8. Validate Result Diagrams

Confirm:

- PM diagram matches PM data
- MM diagram matches MM data
- 3D PMM views use consistent axes
- demand point is plotted correctly
- PASS/FAIL status matches PMM ratio
- Eurocode charts reuse the existing chart engine

### 9. Review Numerical Stability

Confirm:

- no NaN or Infinity values
- pure axial cases are handled
- near-zero moment cases are handled
- interpolation is stable
- boundary tolerance is conservative

### 10. Check Independence and Originality

Confirm:

- no directly copied or translated proprietary code
- no proprietary resources reused
- implementation is based on public engineering theory
- documentation clearly states independent implementation

### 11. Complete Final Release Review

Confirm:

- all blocking issues are resolved
- warnings are visible
- README is complete
- the tool does not claim certified design status

## Required Warning

This project is not a certified design tool. All outputs must be independently checked by a qualified structural engineer before use in engineering design or construction.

## Suggested Development Loop

```text
Implement feature
-> Run unit tests
-> Run architecture review
-> Run engineering review
-> Run PMM validation
-> Fix issues
-> Re-run tests
-> Update documentation
-> Final release checklist
```

## Notes for AI-Assisted Review

When using AI coding agents:

- Provide the relevant `docs/` file as context.
- Provide only the required `src/` project files, not the decompiled reference source.
- Ask for findings in the required output format.
- Treat review output as advisory.
- Require final judgment by a qualified engineer.

# Validation Workflow

This document defines the recommended validation workflow for the MBColumn reinforced concrete column PMM capacity application.

## Purpose

The `_skills` folder contains internal review prompts and checklists for validating:

- Implementation independence and originality.
- Software architecture.
- Structural engineering assumptions.
- PMM solver logic.
- ACI-style design assumptions.
- Unit and sign convention.
- Test coverage.
- Result diagrams.
- Numerical stability.
- Final release readiness.

These files are intended to guide manual and AI-assisted review. They do not replace independent engineering judgment.

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

- Input validation.
- Unit conversion.
- Pure axial compression.
- Pure axial tension.
- Uniaxial bending.
- Biaxial bending.
- PMM ratio boundary checks.
- Diagram data consistency.

### 3. Review Architecture

Use:

```text
_skills/02_SeniorSoftwareArchitectReview.md
```

Confirm:

- MVVM is clean.
- ViewModels contain no calculation logic.
- Domain layer has no WPF dependency.
- Solver is unit-testable.
- Design-code logic is replaceable.

### 4. Review Engineering Logic

Use:

```text
_skills/03_SeniorStructuralEngineerReview.md
```

Confirm:

- Section geometry is correct.
- Rebar layout is correct.
- Material assumptions are documented.
- Strain compatibility logic is reasonable.
- PMM results are physically reasonable.

### 5. Validate PMM Solver

Use:

```text
_skills/04_PMMCalculationValidation.md
```

Confirm:

- Neutral axis sweep is adequate.
- Concrete compression is calculated correctly.
- Steel strain and stress are calculated correctly.
- Interaction surface is smooth and symmetric where expected.
- PMM ratio is based on matching capacity direction.

### 6. Validate ACI-Style Design Assumptions

Use:

```text
_skills/05_CodeDesignValidation_ACI318.md
```

Confirm:

- Maximum concrete strain is documented.
- Concrete stress block is documented.
- Beta1 logic is implemented if applicable.
- Phi factor logic is documented and applied consistently.
- Axial limits are documented.

### 7. Validate Unit and Sign Convention

Use:

```text
_skills/06_UnitAndSignConventionValidation.md
```

Confirm:

- Internal base units are stated.
- UI unit conversion is isolated from solver.
- Axial force sign convention is stated.
- Mx and My sign convention is stated.
- Diagram axis labels match result values.

### 8. Validate Result Diagrams

Use:

```text
_skills/08_ResultDiagramValidation.md
```

Confirm:

- PM diagram matches PM data.
- MM diagram matches MM data.
- 3D-PM and 3D-MM views use consistent axes.
- Demand point is plotted correctly.
- PASS/FAIL status matches PMM ratio.

### 9. Review Numerical Stability

Use:

```text
_skills/09_NumericalStabilityReview.md
```

Confirm:

- No NaN or Infinity values.
- Pure axial cases are handled.
- Near-zero moment cases are handled.
- Interpolation is stable.
- Boundary tolerance is conservative.

### 10. Check Independence and Originality

Use:

```text
_skills/01_IndependenceReview.md
```

Confirm:

- No directly copied or translated proprietary code.
- No proprietary resources reused.
- Implementation is based on public engineering theory.
- Documentation clearly states independent implementation.

### 11. Complete Final Release Review

Use:

```text
_skills/10_FinalReleaseChecklist.md
```

Confirm:

- All blocking issues are resolved.
- Warnings are visible.
- README is complete.
- The tool does not claim certified design status.

## Required Warning

This project is not a certified design tool. All outputs must be independently checked by a qualified structural engineer before use in engineering design or construction.

## Suggested Development Loop

```text
Implement feature
→ Run unit tests
→ Run architecture review
→ Run engineering review
→ Run PMM validation
→ Fix issues
→ Re-run tests
→ Update documentation
→ Final release checklist
```

## Notes for AI-Assisted Review

When using AI or Codex with these skills:

- Provide the relevant skill file as context.
- Provide only the `src/` project files, not the decompiled reference source.
- Ask for findings in the required output format.
- Treat review output as advisory.
- Require final judgment by a qualified engineer.

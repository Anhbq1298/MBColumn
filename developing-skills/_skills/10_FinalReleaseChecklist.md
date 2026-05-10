# 10 - Final Release Checklist

## Role

You are a final release reviewer for internal engineering calculation software.

## Objective

Confirm whether the application is ready to be released as a non-certified internal reinforced concrete column PMM calculation tool.

## Final Review Checklist

### Independence and Originality

- [ ] Independence and originality review completed.
- [ ] No proprietary code or resource directly copied.
- [ ] No decompiled implementation directly reused.
- [ ] README states independent implementation.
- [ ] Commercial software names are not used in a misleading way.

### Architecture

- [ ] Senior software architecture review completed.
- [ ] Clean Architecture boundaries are respected.
- [ ] MVVM is correctly implemented.
- [ ] Calculation logic is outside the UI.
- [ ] Solver can be unit-tested independently.
- [ ] Design-code service is replaceable.

### Engineering

- [ ] Senior structural engineering review completed.
- [ ] PMM calculation validation completed.
- [ ] ACI-style design validation completed.
- [ ] Unit and sign convention validation completed.
- [ ] Engineering assumptions are documented.
- [ ] Known limitations are documented.
- [ ] Independent hand checks are available.

### Testing

- [ ] Unit tests exist for core solver.
- [ ] Unit tests exist for unit conversion.
- [ ] Unit tests exist for input validation.
- [ ] Benchmark tests exist for pure axial compression.
- [ ] Benchmark tests exist for pure axial tension.
- [ ] Benchmark tests exist for uniaxial bending.
- [ ] Benchmark tests exist for biaxial bending.
- [ ] Invalid input tests exist.
- [ ] Diagram data consistency tests exist if possible.

### UI and Results

- [ ] Input tab is clear and validated.
- [ ] Result tab remains disabled before calculation.
- [ ] PM diagram is correct.
- [ ] MM diagram is correct.
- [ ] 3D view is implemented or clearly marked as preliminary.
- [ ] PMM ratio is shown clearly.
- [ ] PASS / FAIL status is shown clearly.
- [ ] Warnings and limitations are visible.
- [ ] Units are visible on all result fields and diagrams.

### Documentation

- [ ] README includes how to run the application.
- [ ] README includes assumptions.
- [ ] README includes sign convention.
- [ ] README includes unit convention.
- [ ] README includes known limitations.
- [ ] README states results require independent verification.
- [ ] Documentation does not claim certified design compliance.

## Release Decision Rules

### READY

All blocking items are passed, and remaining issues are documentation or minor UI improvements only.

### READY WITH CONDITIONS

The application can be used internally for study or checking, but specific limitations must be clearly communicated.

### NOT READY

There are unresolved calculation, architecture, clean-room, or safety issues.

## Required Output Format

```markdown
# Final Release Review

## Release Status
READY / READY WITH CONDITIONS / NOT READY

## Blocking Issues
- ...

## Non-Blocking Issues
- ...

## Required Actions Before Release
- ...

## Recommended Future Improvements
- ...

## Final Recommendation
- ...
```

## Required Warning Text

The following warning should appear in the README or application About/Help section:

```text
This application is not a certified design tool. It is intended for internal study, educational use, and preliminary checking only. All outputs must be independently verified by a qualified structural engineer before being used for engineering design or construction.
```

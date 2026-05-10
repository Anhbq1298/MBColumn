# Column PMM Application Validation Skills

This package contains markdown review skills/checklists for validating the MBColumn reinforced concrete column PMM capacity application.

## Context

The workspace may contain a folder named `spColumn.exe`, which holds a decompiled export used as a behavioral reference. The MBColumn application in `src/` is independently implemented using public structural engineering theory and an independently designed software architecture.

## Folder Structure

```text
_skills/
  01_IndependenceReview.md
  02_SeniorSoftwareArchitectReview.md
  03_SeniorStructuralEngineerReview.md
  04_PMMCalculationValidation.md
  05_CodeDesignValidation_ACI318.md
  06_UnitAndSignConventionValidation.md
  07_TestCaseGeneration.md
  08_ResultDiagramValidation.md
  09_NumericalStabilityReview.md
  10_FinalReleaseChecklist.md

docs/
  VALIDATION_WORKFLOW.md
```

## Validation Skills

The `_skills` folder contains internal review prompts and checklists used to validate:

- Implementation independence and originality.
- Clean Architecture and MVVM structure.
- Service-layer design.
- Reinforced concrete section capacity assumptions.
- PMM interaction solver logic.
- ACI-style design assumptions.
- Unit and sign convention.
- Diagram correctness.
- Numerical stability.
- Final release readiness.

## Recommended Use

1. Implement or update the application.
2. Run unit tests.
3. Use the relevant skill file as a review prompt.
4. Record findings in the required output format.
5. Fix blocking issues.
6. Repeat until the project passes architecture, engineering, and independence checks.

## Safety Warning

This project is not a certified design tool. It is intended for internal study, educational use, and preliminary checking only. All outputs must be independently verified by a qualified structural engineer before being used for engineering design or construction.

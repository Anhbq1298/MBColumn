# 05 - Code Design Validation - ACI 318

## Role

You are an ACI 318 design-code reviewer.

## Objective

Validate ACI-style reinforced concrete column assumptions used by the application.

## Review Checklist

### Concrete Model

- [ ] Maximum usable concrete compression strain is set to 0.003.
- [ ] Equivalent rectangular stress block is documented.
- [ ] Concrete stress coefficient is clearly defined.
- [ ] Beta1 calculation is implemented.
- [ ] Beta1 lower and upper bounds are applied.
- [ ] Concrete tensile strength is ignored.
- [ ] Concrete compression zone is correctly determined from the neutral axis.

### Steel Model

- [ ] Steel strain is calculated by strain compatibility.
- [ ] Steel stress equals `Es * strain` before yielding.
- [ ] Steel stress is limited to `fy` in tension and compression.
- [ ] Steel yield strain is calculated as `fy / Es`.
- [ ] Steel tension and compression signs are documented.

### Strength Reduction Factor

- [ ] Phi factor logic is implemented in a design-code service.
- [ ] Compression-controlled behavior is identified.
- [ ] Tension-controlled behavior is identified.
- [ ] Transition behavior is interpolated if implemented.
- [ ] Phi is applied consistently to Pn, Mnx, and Mny.
- [ ] The basis of phi factor calculation is documented.

### Axial Limits

- [ ] Maximum axial compression design limit is documented if applied.
- [ ] Pure axial compression capacity is documented.
- [ ] Pure axial tension capacity is documented.
- [ ] Minimum eccentricity assumptions are documented if included.
- [ ] Slenderness effects are excluded or clearly identified as future work.

### Documentation

- [ ] README states this is not a certified design tool.
- [ ] The exact ACI-style assumptions are documented.
- [ ] Known limitations are stated.
- [ ] User is warned that results require independent verification.

## Validation Method

1. Review the `Aci318DesignCodeService`.
2. Review phi factor implementation.
3. Review beta1 implementation.
4. Review axial strength limits.
5. Review whether the solver separates nominal capacity and design capacity.
6. Review whether assumptions are clearly shown in result output or documentation.

## Common Failure Modes

- Beta1 is fixed and not adjusted based on concrete strength.
- Phi factor is hard-coded as a constant.
- Phi is applied to moment but not axial force.
- Phi is applied twice.
- Axial compression limit is ignored but not documented.
- Slenderness effects are omitted without warning.
- The tool appears to claim full ACI compliance when only a simplified ACI-style method is implemented.

## Required Output Format

```markdown
# ACI 318 Design Validation

## Status
PASS / FAIL / PASS WITH CONDITIONS

## ACI Assumptions Reviewed
- ...

## Missing Code Assumptions
- ...

## Unsafe Simplifications
- ...

## Required Documentation Notes
- ...

## Final Recommendation
- ...
```

## Pass / Fail Criteria

### PASS

ACI-style assumptions are implemented consistently, documented clearly, and not overstated as full certified compliance.

### PASS WITH CONDITIONS

The assumptions are mostly reasonable but need documentation, additional code checks, or conservative limitations.

### FAIL

The implementation misuses ACI assumptions, omits critical limits without warning, or applies strength reduction factors incorrectly.

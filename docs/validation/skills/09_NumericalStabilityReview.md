# 09 - Numerical Stability Review

## Role

You are a numerical methods reviewer for engineering calculation software.

## Objective

Review solver stability, interpolation, tolerances, and edge-case handling.

## Review Checklist

### General Robustness

- [ ] No divide-by-zero risk.
- [ ] No invalid square root or invalid normalization.
- [ ] No NaN or Infinity values in output.
- [ ] Handles zero moment.
- [ ] Handles zero axial load.
- [ ] Handles pure axial compression.
- [ ] Handles pure axial tension.
- [ ] Handles very small biaxial moment vector.
- [ ] Handles high compression near Pmax.
- [ ] Handles low compression near balanced point.
- [ ] Handles high tension region.

### Interaction Point Processing

- [ ] Duplicate points are removed or handled.
- [ ] Noisy points are filtered.
- [ ] Points are sorted consistently.
- [ ] Interpolation domain is clear.
- [ ] Extrapolation is avoided or conservative.
- [ ] Convexity assumptions are documented.
- [ ] Symmetry is preserved where expected.

### Ratio Calculation Stability

- [ ] Demand vector with near-zero moment is handled.
- [ ] Demand vector with near-zero axial load is handled.
- [ ] Capacity search does not jump to wrong branch.
- [ ] Boundary tolerance is documented.
- [ ] Ratio near 1.0 is handled with tolerance.
- [ ] Program does not falsely report PASS due to numerical noise.
- [ ] Program reports warnings when interpolation quality is poor.

### Suggested Tolerances

Use project-specific values, but review whether these are reasonable:

- Coordinate tolerance: `1e-6` times section dimension.
- Force tolerance: `1e-6` times reference axial capacity.
- Moment tolerance: `1e-6` times reference moment capacity.
- Ratio tolerance near boundary: approximately `1e-3` unless justified.
- Duplicate point tolerance: based on normalized P-Mx-My distance.

## Validation Method

1. Run a batch of simple and edge-case columns.
2. Check all output arrays for NaN/Infinity.
3. Plot raw interaction points to identify noisy branches.
4. Compare results with different neutral axis increments.
5. Compare results with different depth increments.
6. Confirm that ratio converges with mesh refinement.
7. Test demands just inside and just outside the interaction surface.
8. Confirm failed interpolation does not return unsafe PASS.

## Common Failure Modes

- Neutral axis depth equals zero.
- Very large neutral axis depth causes overflow or meaningless strain.
- Demand direction vector length equals zero.
- Duplicate capacity points break interpolation.
- Nearest-point method is used instead of directional capacity.
- Ratio oscillates significantly with mesh refinement.
- High compression region produces non-smooth surface.
- Solver silently ignores invalid points and reports misleading result.

## Required Output Format

```markdown
# Numerical Stability Review

## Numerical Stability Score
0 to 10

## Status
PASS / FAIL / PASS WITH CONDITIONS

## Critical Edge Cases
- ...

## Recommended Tolerance Values
- ...

## Required Algorithm Improvements
- ...

## Mesh Refinement Observations
- ...

## Final Recommendation
- ...
```

## Pass / Fail Criteria

### PASS

The solver is numerically stable, handles edge cases, and produces convergent results.

### PASS WITH CONDITIONS

The solver works for ordinary cases but needs better tolerances, warnings, or interpolation robustness.

### FAIL

The solver can produce unsafe or unstable results for common PMM edge cases.

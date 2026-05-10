# EC2 Stress Block Guidance

## Purpose

This document defines implementation expectations for Eurocode concrete compression-block behavior.

## Important Rule

Do not directly reuse ACI stress-block parameters inside Eurocode calculations.

Eurocode stress-block assumptions must be isolated behind Eurocode-specific services.

## Expectations

The implementation should explicitly define:

- stress-block shape
- stress-block depth parameters
- equivalent stress assumptions
- design-strength application
- compression-region integration behavior

## Numerical Behavior

The compression block should:

- rotate consistently with the neutral axis
- remain stable during directional capacity searches
- avoid discontinuities during interpolation
- remain compatible with future nonlinear concrete models

## Rendering Expectations

Any displayed compression region should:

- follow the current neutral-axis orientation
- remain visually consistent with the calculated compression block
- avoid showing concrete compression regions during full-tension states

## Validation

Validate against:

- EC2 worked examples
- hand calculations
- independently derived reference results
- visual inspection of compression-region rendering

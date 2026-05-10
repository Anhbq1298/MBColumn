# EC2 PMM Ratio Guidance

## Purpose

This document defines high-level expectations for Eurocode PMM ratio evaluation.

## Important Behavioral Rules

- Compression and tension behavior must remain physically reasonable.
- Concrete compression region must respond consistently with neutral-axis orientation.
- Concrete tension contribution should remain zero unless explicitly modeled.
- Interaction surfaces should remain smooth and numerically stable.

## Directional Capacity Search

Directional capacity search should:

- remain deterministic
- avoid unstable interpolation spikes
- preserve monotonic behavior where physically expected
- avoid sign inversion artifacts

## Visualization Expectations

Charts should visually distinguish:

- nominal capacity
- design capacity
- compression-controlled regions
- tension-controlled regions where applicable

## Validation

Validate against:

- hand calculations
- published references
- independent software comparisons
- worked examples stored in this repository

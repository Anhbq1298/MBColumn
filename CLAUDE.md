# CLAUDE.md

Claude Code operating instructions for MBColumn.

## Primary Objective

Maintain a stable, independently implemented reinforced-concrete PMM application with clean architecture boundaries and predictable engineering behavior.

## First Files To Read

Always read in this order:

1. `AGENTS.md`
2. `developing-skills/_skills/00_ProjectTruth.md`
3. Relevant validation skill files
4. Relevant engineering/rendering docs
5. Only the required source files

## Important Constraints

### Do Not

- Mix WPF rendering logic with PMM calculations.
- Introduce hidden unit conversions inside the solver.
- Change sign conventions silently.
- Invent structural-engineering equations or code clauses.
- Copy proprietary code from any decompiled reference.
- Refactor unrelated files without strong justification.

### Always

- Preserve solver/UI separation.
- Keep changes localized.
- Prefer deterministic numerical behavior.
- Preserve backward-compatible engineering assumptions unless explicitly requested.
- State assumptions clearly.
- Keep PMM surface generation numerically stable.

## PMM Expectations

The PMM implementation should preserve:

- strain compatibility
- plane sections remain plane
- ignored concrete tension
- physically reasonable compression region behavior
- stable interpolation
- smooth interaction surfaces
- correct directional capacity search behavior

## Rendering Expectations

Charts and rendering layers are visual consumers only.

Pipeline boundary:

```text
Solver
-> InteractionSurface
-> ControlPointBuilderService
-> DiagramDataService
-> ViewModel
-> WPF chart/rendering control
```

Do not move engineering calculations into rendering layers.

## Numerical Stability Priorities

Protect against:

- NaN propagation
- unstable interpolation
- near-zero vector normalization
- PMM spikes
- invalid neutral-axis sweeps
- tension/compression sign inversion

## Recommended Workflow

```text
Read truth files
-> read relevant skill files
-> inspect minimal source set
-> implement
-> run tests
-> validate engineering assumptions
-> summarize impact
```

## Required Final Summary

After changes, summarize:

- changed files
- engineering impact
- architecture impact
- validation status
- remaining risks or TODO items

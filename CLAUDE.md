# CLAUDE.md

Claude Code operating instructions for MBColumn.

## Primary Objective

Maintain a stable, independently implemented reinforced-concrete PMM application with clean architecture boundaries and predictable engineering behavior.

## First Files To Read

Always read in this order:

1. `AGENTS.md`
2. `README.md`
3. `BUILD_NOTES.md`
4. Relevant engineering/rendering docs
5. Only the required source files

## Workflow Expectations

```text
Read AGENTS.md
-> read the minimum required docs
-> inspect the minimum required source files
-> implement incrementally
-> build
-> run tests
-> validate engineering assumptions
-> summarize impact and risks
```

## Important Constraints

### Do Not

- Mix WPF rendering logic with PMM calculations.
- Introduce hidden unit conversions inside the solver.
- Change sign conventions silently.
- Invent structural-engineering equations or code clauses.
- Copy proprietary code from any decompiled reference.
- Refactor unrelated files without strong justification.
- Mutate ACI PMM logic directly to implement Eurocode behavior.

### Always

- Preserve solver/UI separation.
- Keep changes localized.
- Prefer deterministic numerical behavior.
- Preserve backward-compatible engineering assumptions unless explicitly requested.
- State assumptions clearly.
- Keep PMM surface generation numerically stable.
- Prefer modular design-code services.
- Compile after changes.

## PMM Expectations

The PMM implementation should preserve:

- strain compatibility
- plane sections remain plane
- ignored concrete tension
- physically reasonable compression region behavior
- stable interpolation
- smooth interaction surfaces
- correct directional capacity search behavior

## Eurocode Expectations

Eurocode implementation should:

- remain separated from ACI design-code behavior
- preserve the same core solver architecture when possible
- use independent material/stress-block assumptions
- support future EC2/EC8 expansion
- support future second-order effects without major refactor
- clearly separate nominal and design capacities

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

## UI Expectations

- Use Segoe UI.
- Prevent overlapping controls.
- Prefer modern clean dashboard-style layouts.
- Keep engineering readability higher priority than visual effects.
- Maintain current primary color identity unless explicitly changed.

## Required Final Summary

After changes, summarize:

- changed files
- engineering impact
- architecture impact
- validation status
- remaining risks or TODO items

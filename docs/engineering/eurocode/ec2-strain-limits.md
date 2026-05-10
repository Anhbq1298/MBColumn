# EC2 Strain Limits Guidance

## Purpose

This document records the strain-limit assumptions that must be confirmed before implementing Eurocode PMM behavior.

## Core Expectations

- Use a dedicated Eurocode strain-limit model.
- Do not reuse ACI maximum concrete strain or tension-control assumptions without explicit engineering justification.
- Keep strain limits configurable where national annex or material-model variation may affect behavior.
- Keep strain compatibility inside the solver layer, not the UI layer.

## Concrete

The Eurocode concrete compression strain limits must be defined explicitly by the selected material model.

Agent tasks must confirm:

- ultimate concrete compression strain
- strain at peak stress where applicable
- whether a rectangular, parabolic-rectangular, or other model is being used
- whether simplifications are acceptable for the current MVP

## Reinforcement

Steel strain behavior must define:

- elastic strain range
- yield strain
- design yield behavior
- any imposed strain limit
- whether hardening is ignored or modeled

## Validation Checklist

Before accepting an implementation, verify:

- compression-only concrete behavior is preserved
- neutral-axis rotation produces consistent compression regions
- tensile concrete does not contribute to axial or moment capacity
- steel stress signs follow the internal convention
- extreme strain states do not generate NaN or unstable PMM spikes

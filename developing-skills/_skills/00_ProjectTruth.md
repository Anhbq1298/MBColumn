# 00 - MBColumn Project Truth

Use this file before any coding or review task.

## Product Scope

MBColumn is a clean-room .NET 8 WPF/MVVM desktop application for rectangular reinforced-concrete column PMM interaction checks.

The tool is educational/preliminary only. It is not a certified design-code engine.

## Hard Engineering Truths

- Internal solver units are always N, mm, N-mm, and MPa.
- UI units must be converted at application boundaries before reaching the solver.
- Axial compression is positive.
- Axial tension is negative.
- Moment convention is about the section centroid:
  - `Mx = force * y`
  - `My = -force * x`
- Concrete tension stress is ignored.
- Steel may carry compression and tension according to the material model.
- Plane sections remain plane.
- Slenderness, second-order effects, confinement, detailing, fire, and development length are outside the MVP unless explicitly requested.

## Architecture Truths

- Keep engineering entities and solver primitives outside WPF.
- WPF controls may render data but must not calculate PMM capacity.
- ViewModels coordinate state and commands but must not contain section-capacity algorithms.
- Design-code services must be replaceable so ACI-style and Eurocode-style logic can coexist.
- Tests must target calculation logic independently from the UI.

## Reference Boundary

A decompiled reference folder may exist for behavioral comparison only. Do not copy, translate, or structurally mirror proprietary source code. Implement only from public engineering theory and independently written architecture.

## Output Rule for Agents

When making changes, always report:

1. Files changed.
2. Engineering assumptions touched.
3. Tests added or updated.
4. Known limitations.
5. Whether independent engineering verification is still required.

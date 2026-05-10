# 12 - Previous Failures and Regression Memory

Use this file to avoid reintroducing previously observed problems.

## Engineering Failures

- Concrete tension was accidentally included under axial tension states.
- PMM spikes occurred near near-zero bending regions due to unstable interpolation.
- Neutral-axis sweep density was too coarse, producing jagged interaction surfaces.
- Directional capacity matching selected the wrong governing point under biaxial loading.
- Surface continuity broke after inconsistent angle ordering.

## Numerical Failures

- Near-zero vectors caused unstable normalization.
- NaN propagation occurred after invalid interpolation states.
- Pure axial cases produced divide-by-zero behavior.
- Sign inversion appeared during coordinate transformations.

## Rendering Failures

- Hidden-line rendering broke after mesh simplification.
- Section preview aspect ratio became distorted after resize.
- 3D axes drifted from the true engineering origin.
- Tooltip values accidentally displayed scaled rendering values instead of engineering values.

## UI Failures

- Fixed Width/Height caused overlapping controls.
- Deep nested StackPanels created unstable layouts.
- Chart labels overlapped during zoom.

## Architecture Failures

- Engineering logic leaked into WPF controls.
- Unit conversion logic leaked into solver layers.
- ViewModels accumulated calculation responsibilities.
- Rendering classes became coupled to engineering services.

## Rule

Before large refactors or rendering changes, review this file and confirm the change does not reintroduce known failures.

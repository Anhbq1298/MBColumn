# Section Preview

`SectionPreviewCanvas` is a live WPF preview of the input geometry. It is intentionally separate from the PMM solver and only visualizes input geometry.

## Coordinate Convention

- Preview rebar coordinates use the section centroid as origin.
- Positive X is to the right.
- Positive Y is upward in engineering coordinates.
- Canvas Y is downward, so conversion to screen coordinates happens only inside `SectionPreviewCanvas`.

## Geometry

The preview draws:

- Concrete section outline with preserved aspect ratio.
- Inner cover rectangle offset by the selected cover.
- Rebar circles using converted diameter in mm.
- Width and height dimensions with Metric or Imperial labels.
- Local x/y axes and section centroid.

## Rebar Layouts

`InputViewModel.UpdateSectionPreview()` generates preview-only rebar coordinates.

- `4 corner bars`: one bar near each covered corner.
- `Perimeter bars`: bars distributed around the inner cover perimeter, avoiding duplicated corners.

Metric mode uses Singapore notation (`T10` through `T40`). Imperial mode uses US notation (`#3` through `#11`). The preview displays the selected notation but draws from converted internal mm dimensions.

## Live Updates

The preview updates when width, height, cover, unit system, bar size, number of bars, or layout preset changes. It does not require pressing Calculate.

## Invalid State

Invalid geometry or bar inputs do not crash the UI. The preview displays `Invalid section input` and uses the warning border style.

# UI Skill Set

Use this file before changing WPF views, view models, custom controls, or theme resources.

## UI Product Shape

MBColumn is an engineering work app. The UI should be dense, legible, calm, and predictable. It should prioritize repeated engineering workflows: entering geometry/material/rebar/load data, running checks, inspecting PMM charts, reviewing detailed results, and exporting reports.

Avoid marketing-style layouts, oversized decorative sections, or visual effects that make numeric review slower.

## Theme and Styling

- Use existing theme resources from `Themes/Theme.Colors.xaml`, `Themes/Theme.Typography.xaml`, `Themes/Theme.Controls.xaml`, `Themes/Theme.DataGrid.xaml`, and `Themes/Theme.Cards.xaml`.
- Use `PrimaryButtonStyle` or `CompactButtonStyle` for primary actions.
- Use `SecondaryButtonStyle` for neutral actions.
- Use shared text styles such as `SectionTitleTextStyle`, `GroupTitleTextStyle`, `FieldLabelTextStyle`, `HelperTextStyle`, `CaptionTextStyle`, and `MetricValueTextStyle`.
- Avoid new hard-coded colors and font sizes in ordinary UI.
- One-off visualization colors are acceptable inside drawing/chart controls.

## Layout Rules

- Use `Grid` for aligned engineering forms.
- Keep labels close to inputs and unit labels close to numeric values.
- Put primary actions at the far right of footers; secondary actions immediately to their left.
- Keep tables compact, readable, and sortable only when sorting is meaningful.
- Do not put nested cards inside cards.
- Ensure text fits at the minimum supported window size.

## Dialogs and Notifications

- Prefer shared dialog styles and `AppNotificationDialog` / `IMessageService` over raw `MessageBox`.
- Notification titles should be short, such as `Export Complete`, `Export Error`, `Import Error`, or `Warning`.
- File paths and detailed errors should appear on a new line after a concise sentence.

## Current Main UI Areas

- Input tab: project/context, section shape, geometry, material, rebar, load cases, EC2 slenderness options, live section preview, ETABS import handoff.
- Result tab: PMM ratio summary, PM angle diagram, Mx-My diagram, 3D PMM surface, selected PM theta/P slice controls, section-state inset, demand/capacity summary, control-point table, shear and rebar compliance details.
- Report tab: report section toggles, preview, chart snapshots, PDF/HTML export.
- Batch print: group/column report generation.
- ETABS import: candidate selection, force import, grouping, and MBColumn section creation.

## PMM Details Rules

- The PMM Details view must use user-facing moment theta.
- Load-case rows display theta from `LoadCaseResultDto.GoverningMomentThetaDegrees`.
- PMM Details selected chart-point theta is resolved through `ResultViewModel.SelectedPointMomentThetaDegrees`.
- Demand chart points should map back to their load case by `SliceKey`.
- Capacity chart points may carry internal compression-normal theta and must be converted with `PmmAngleConvention`.
- Do not compute PMM Details theta directly with `atan2` unless there is no load-case PMM result.

## Chart Rules

- Chart controls render DTOs; they do not calculate PMM capacity.
- PM angle diagrams project Mx/My onto `Mtheta = Mx*cos(theta) + My*sin(theta)`.
- Mx-My diagrams render capacity at the selected axial load.
- 3D PMM renders Mx, My, and P in display units.
- Demand, governing, nominal, design, special, and reference points must remain visually distinguishable.
- Axis labels and units must match the DTOs.
- Selected theta and selected axial load controls should update 2D and 3D views together.

## Report Preview UI Rules

- Report preview should use the same data model as generated reports.
- Do not show a theta in preview that differs from the generated PDF/HTML output.
- Captions and summary text should use shared result DTO properties, not recomputed UI-only values.

## UI Review Checklist

- No structural capacity calculation in a view, converter, or view model.
- No duplicated theta convention logic.
- PMM Details theta and report theta match for the same load case.
- Theme resources are used for normal UI styles.
- Units are visible beside all engineering values.
- Tables and charts update after result recalculation.
- Notification and export messages use existing app patterns.

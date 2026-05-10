# Chart Interaction

## 2D Charts

Applies to PMx, PMy, and Mx-My diagrams.

- Static auto-fit view.
- No mouse wheel zoom.
- No mouse drag pan.
- Fit/reset commands redraw the auto-fit view only.
- Hover over demand, governing, or capacity points: show an engineering tooltip.
- Grid toggle: shows or hides chart gridlines only; it does not change calculation data.
- Labels and legend can be toggled.

The active PM chart is angle-based. It uses `Mθ` on the horizontal axis and axial force `P` on the vertical axis, where `Mθ = Mx cosθ + My sinθ` and θ is measured in the Mx-My plane from +Mx toward +My. Mx-My uses Mx on the horizontal axis and My on the vertical axis. Axis labels and tooltips use display units from the selected workflow.

## 3D Charts

Applies to the 3D PMM surface view.

- Navigation panel:
  - Angle (Mx, My): updates the 2D PM chart and vertical PM slice plane without rerunning the solver.
  - Axial Load: updates the horizontal Mx-My slice plane at the selected P level without rerunning the solver.
- Shift + left mouse drag: rotate/orbit.
- Mouse wheel: zoom.
- Ctrl + left mouse drag: pan.
- Middle mouse drag: pan.
- Double click: reset camera.

The 3D renderer applies display scaling so P, Mx, and My remain readable together. The viewport is anchored to the true engineering origin (0,0,0). The Mx and My axes, along with the horizontal reference grid, are fixed at the P=0 plane. The axial load slice is a separate, dynamic plane that moves independently to show the Mx-My capacity at the selected P level. Labels and tooltips remain in true engineering display values; scaling is visual only. The small orientation cube in the bottom-right corner follows the camera yaw/pitch and labels Mx, My, and P.

## Rendering Boundary

Chart controls consume diagram DTO/control-point data produced by:

`Solver -> InteractionSurface -> ControlPointBuilderService -> DiagramDataService -> Chart ViewModel -> Chart Control`

No PMM engineering calculation logic is placed in WPF chart controls.

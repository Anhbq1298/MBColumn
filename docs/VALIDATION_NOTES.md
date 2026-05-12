# Validation Notes

The `docs/validation/skills/` files are used as internal review checklists.

## Software Architecture

Status: PASS WITH CONDITIONS. Domain has no WPF dependency, ViewModels do not contain engineering calculations, and solver/design-code/unit conversion services are interface-driven. Manual DI is used in the WPF shell for MVP simplicity.

## Structural Engineering

Status: PASS WITH CONDITIONS. The solver implements a documented strain-compatibility method and produces expected compression, tension, uniaxial, biaxial, and symmetry behavior in tests. More hand checks are required before engineering use.

## PMM Calculation

Status: PASS WITH CONDITIONS. The neutral axis sweep uses 36 angles and 70 depth samples, matching the observed reference grid convention. The ratio check uses directional moment capacity at the selected axial level.

## Unit And Sign Convention

Status: PASS. Internal units are N, mm, N-mm, MPa. Compression-positive convention is documented and tested across Metric and Imperial inputs.

## Diagram Validation

Status: PASS WITH CONDITIONS. PM/MM/control-point data are generated consistently. PM chart DTOs are tested to render P on the vertical axis. MM boundaries are sorted by polar angle. The WPF 3D views now render projected surface patches and stacked contour data, but they remain a custom lightweight renderer rather than a full finite-element-style mesh viewer.

## Numerical Stability

Status: PASS WITH CONDITIONS. Tests check no NaN/Infinity, pure axial cases, large outside demand, duplicate filtering, equivalent unit workflows, section-preview layout behavior, PM axis mapping, and chart bounds. Further mesh-convergence studies are recommended.

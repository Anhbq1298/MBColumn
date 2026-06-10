# Unit Convention

Internal units:

- Force: N
- Length: mm
- Moment: N-mm
- Stress: MPa

Display units:

- Metric force: kN
- Metric moment: kN-m
- Metric length: mm
- Metric stress: MPa
- Imperial force: kip
- Imperial moment: kip-ft
- Imperial length: inch
- Imperial stress: ksi

All conversions are isolated in `UnitConversionService`.

The solver receives only internal units:

- Bar diameter in mm.
- Bar area in mm2.
- Bar coordinates in mm.
- Demand force in N.
- Demand moments in N-mm.
- Material stresses in MPa.

## ETABS Import Convention

For ETABS frame force import, MBColumn aligns local section axes directly to
ETABS frame local axes:

- MBColumn X = ETABS local 2.
- MBColumn Y = ETABS local 3.
- Mx = ETABS M2.
- My = ETABS M3.
- Vx = ETABS V2.
- Vy = ETABS V3.
- ETABS P is converted to MBColumn compression-positive P/NEd.

Do not map ETABS M3 to MBColumn Mx, and do not map ETABS M2 to MBColumn My.
Moment mapping is axis-based. Shear pairing remains Vx-My for ETABS V2-M3 and
Vy-Mx for ETABS V3-M2.

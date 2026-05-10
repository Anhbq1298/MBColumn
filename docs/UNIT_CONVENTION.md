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

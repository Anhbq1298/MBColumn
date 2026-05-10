# EC2 Material Model Notes

## Concrete

Eurocode concrete implementation should clearly define:

- characteristic strength
- design strength
- partial safety factors
- stress-strain assumptions
- compression-only behavior

Concrete tension should remain ignored for PMM interaction calculations unless explicitly implementing tension stiffening.

## Reinforcement Steel

The implementation should define:

- yield strength
- design yield strength
- elastic modulus
- strain limits
- elastic-plastic transition behavior

## Important Rule

Do not reuse ACI reduction factors or assumptions inside Eurocode material logic.

## Future Expansion

The architecture should allow:

- different national annexes
- ductility classes
- confinement models
- nonlinear stress-strain curves

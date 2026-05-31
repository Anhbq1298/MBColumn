## Summary

- 
- 

## Solver Safety

- [ ] Regression tests pass
- [ ] Golden results unchanged or change is justified and documented
- [ ] No formula changes (or change is intentional and reviewed)
- [ ] No sign convention changes (or change is intentional and reviewed)
- [ ] No unit conversion changes (or change is intentional and reviewed)

## Validation

- [ ] Added or updated tests
- [ ] Added or updated docs if behaviour changed
- [ ] Manual smoke test completed (build, run, spot-check result)

## Checklist

- [ ] `dotnet build` passes (Release)
- [ ] All tests pass (`dotnet run --project tests/MBColumn.Tests`)
- [ ] No `NaN` or `Infinity` introduced in capacity outputs
- [ ] UI formulas remain in Application/Infrastructure only — not in ViewModels or Views

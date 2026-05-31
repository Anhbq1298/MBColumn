# Golden Results Changelog

Documents every change to the approved solver baselines in `validation/golden-results/`.

Each entry must include: version tag, date, case names changed, reason, and who approved the change.

---

## v1 — Initial baselines (pending)

- **Date:** TBD (generate with `dotnet run --project tests/MBColumn.Tests -- --generate-baselines`)
- **Cases:** EC2_Rectangular_650x650_20T25, ACI_Rectangular_700x700_28T25, EC2_Circular_D600_16T25
- **Reason:** First baseline capture after solver regression test infrastructure was put in place.
- **Approved by:** TBD

---

## Versioning Policy

- Never silently overwrite approved results.
- Any change to a golden result requires an entry in this file.
- Version folders use `v1/`, `v2/` etc. — older versions are preserved.
- Automated CI uses the latest version folder for comparison.

# UI State Flow

Documents how calculation state moves through the WPF presentation layer.

## Calculation States

```csharp
// Target state model (Phase 8 target)
public enum CalculationState
{
    CleanResult,         // Result matches current inputs
    DirtyInput,          // Inputs changed since last calculation
    Calculating,         // Solver is running
    CalculationFailed,   // Last run threw an error
    CalculationSucceeded // Last run completed successfully
}
```

## State Transition Rules

| From | Event | To |
|---|---|---|
| CleanResult | Any input changes | DirtyInput |
| DirtyInput | User clicks Calculate | Calculating |
| Calculating | Solver completes | CalculationSucceeded → CleanResult |
| Calculating | Solver throws | CalculationFailed |
| CalculationFailed | User clicks Calculate | Calculating |
| CalculationSucceeded | Any input changes | DirtyInput |

## UI Behaviour per State

| State | Calculate button | Result tab | Warning shown |
|---|---|---|---|
| CleanResult | Enabled | Enabled | None |
| DirtyInput | Enabled | Disabled | "Recalculation required" |
| Calculating | Disabled | Disabled | "Calculating…" |
| CalculationFailed | Enabled | Disabled | Error message |
| CalculationSucceeded | Enabled | Enabled | None |

## Current Implementation Notes

- `InputViewModel` is the primary state holder.
- Any property change on `InputViewModel` must mark the result stale.
- `ResultViewModel` receives a `CalculationResultDto` after a successful run.
- The Result tab must be locked (`IsEnabled = false`) when the result is stale.

## Related Docs

- [ARCHITECTURE_OVERVIEW.md](ARCHITECTURE_OVERVIEW.md)

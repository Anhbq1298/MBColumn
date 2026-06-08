namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public enum AutoGroupingValidationSeverity
{
    Info,
    Warning,
    Error
}

public sealed class AutoGroupingValidationMessage
{
    public AutoGroupingValidationMessage(
        AutoGroupingValidationSeverity severity,
        string messageKey,
        params object[] messageArguments)
    {
        Severity = severity;
        MessageKey = messageKey;
        MessageArguments = messageArguments;
    }

    public AutoGroupingValidationSeverity Severity { get; }
    public string MessageKey { get; }
    public object[] MessageArguments { get; }
}

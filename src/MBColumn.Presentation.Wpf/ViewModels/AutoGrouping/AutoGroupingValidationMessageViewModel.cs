using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Presentation.Wpf.Services;

namespace MBColumn.Presentation.Wpf.ViewModels.AutoGrouping;

public sealed class AutoGroupingValidationMessageViewModel
{
    public AutoGroupingValidationMessageViewModel(AutoGroupingValidationMessage source)
    {
        Severity = source.Severity;
        SeverityDisplayText = WpfResourceText.Get(source.Severity switch
        {
            AutoGroupingValidationSeverity.Error => "AutoGrouping_Severity_Error",
            AutoGroupingValidationSeverity.Warning => "AutoGrouping_Severity_Warning",
            _ => "AutoGrouping_Severity_Info"
        });
        Message = WpfResourceText.Format(source.MessageKey, source.MessageArguments);
    }

    public AutoGroupingValidationSeverity Severity { get; }
    public string SeverityDisplayText { get; }
    public string Message { get; }
}

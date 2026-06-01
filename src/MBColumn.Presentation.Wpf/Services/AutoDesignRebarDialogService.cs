using MBColumn.Application.DTOs;
using MBColumn.Application.RebarSuggestion;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;
using MBColumn.Presentation.Wpf.Views;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class AutoDesignRebarDialogService(
    ColumnCalculationService calculationService,
    IRebarDatabase metricBars,
    IRebarDatabase imperialBars) : IAutoDesignRebarDialogService
{
    public RebarSuggestionOption? ShowDialog(ColumnInputDto currentInput, Window? owner)
    {
        var barDb = currentInput.RebarSetLibrary == RebarSetLibraryType.UnitedStatesImperial
            ? imperialBars
            : metricBars;

        // Longitudinal bars: diameter >= 16 mm (T6–T13 reserved for shear links/stirrups)
        var longitudinalBars = barDb.GetBars()
            .Where(b => b.DiameterMm >= 16.0)
            .ToList();

        // Shear link bars: diameter 10–16 mm (informational — not changed by auto-design)
        var shearLinkBars = barDb.GetBars()
            .Where(b => b.DiameterMm is >= 10.0 and <= 16.0)
            .ToList();

        // Compute "before" state so the dialog can show existing check results
        CalculationResultDto? beforeResult = null;
        try { beforeResult = calculationService.Calculate(currentInput); }
        catch { /* before result unavailable — dialog shows "—" */ }

        var engine = BuildEngine(calculationService);
        var snapshot = NormaliseToMm(currentInput);

        var baseInput = new RebarSuggestionInput
        {
            BaseInput   = snapshot,
            Constraints = BuildDefaultConstraints(longitudinalBars),
            AllowedBars = longitudinalBars
        };

        var vm = new AutomatedRebarDesignViewModel(
            engine, baseInput, longitudinalBars, shearLinkBars, beforeResult);

        var dialog = new AutomatedRebarDesignDialog(vm);
        if (owner is not null) dialog.Owner = owner;

        dialog.ShowDialog();
        return vm.AppliedOption;
    }

    private static RebarSuggestionEngine BuildEngine(ColumnCalculationService calc)
    {
        var generator = new RectangularPerimeterCandidateGenerator();
        IReadOnlyList<IRebarCandidateValidator> validators =
        [
            new RebarGeometryValidator(),
            new RebarCodeValidator()
        ];
        return new RebarSuggestionEngine(generator, validators,
            new ExistingSolverRebarCandidateEvaluator(calc),
            new DefaultRebarSuggestionScorer());
    }

    private static ColumnInputDto NormaliseToMm(ColumnInputDto input)
    {
        if (input.LengthUnit == LengthUnit.Millimeter)
            return input;
        return input;
    }

    private static RebarSuggestionConstraintSet BuildDefaultConstraints(IReadOnlyList<RebarDefinition> bars)
    {
        var barNames = bars
            .Where(b => b.DiameterMm is >= 16 and <= 40)
            .Select(b => b.Name)
            .ToList();

        return new RebarSuggestionConstraintSet
        {
            AllowedBarSizeNames      = barNames,
            AllowedBarCounts         = [8, 12, 16, 20, 24, 28, 32],
            AllowAllSidesEqualLayout  = true,
            AllowSidesDifferentLayout = true
        };
    }
}

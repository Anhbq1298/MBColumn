using MBColumn.Application.DTOs;
using MBColumn.Application.RebarSuggestion;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;
using MBColumn.Presentation.Wpf.Views;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class AutoDesignRebarDialogService(
    ColumnCalculationService calculationService,
    IRebarDatabase metricBars,
    IRebarDatabase imperialBars) : IAutoDesignRebarDialogService
{
    private static readonly UnitConversionService Units = new();

    public RebarSuggestionOption? ShowDialog(ColumnInputDto currentInput, Window? owner)
    {
        var barDb = currentInput.RebarSetLibrary == RebarSetLibraryType.UnitedStatesImperial
            ? imperialBars
            : metricBars;

        var allBars = barDb.GetBars().ToList();

        // Longitudinal bars: diameter >= 16 mm
        var longitudinalBars = allBars
            .Where(b => b.DiameterMm >= 16.0)
            .ToList();

        // Shear link bars: T10–T16 (practical minimum 10 mm for Singapore set)
        var shearLinkBars = allBars
            .Where(b => b.DiameterMm is >= 10.0 and <= 16.0)
            .OrderBy(b => b.DiameterMm)
            .ToList();

        CalculationResultDto? beforeResult = null;
        try { beforeResult = calculationService.Calculate(currentInput); }
        catch { /* before result unavailable */ }

        var engine   = BuildEngine(calculationService);
        var snapshot = NormaliseToMm(currentInput);

        var baseInput = new RebarSuggestionInput
        {
            BaseInput    = snapshot,
            Constraints  = BuildDefaultConstraints(longitudinalBars, shearLinkBars),
            AllowedBars  = longitudinalBars,
            AllowedLinkBars = shearLinkBars
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
            new ExistingSolverRebarCandidateEvaluator(calc));
    }

    private static ColumnInputDto NormaliseToMm(ColumnInputDto input)
    {
        RebarSideInputDto? ConvertSide(RebarSideInputDto? side)
            => side is null
                ? null
                : side with { Cover = Units.LengthToMm(side.Cover, input.LengthUnit) };

        double? memberLengthMm = input.MemberLengthL.HasValue
            ? Units.LengthToMm(input.MemberLengthL.Value, input.LengthUnit)
            : null;

        return input with
        {
            Width = Units.LengthToMm(input.Width, input.LengthUnit),
            Height = Units.LengthToMm(input.Height, input.LengthUnit),
            Cover = Units.LengthToMm(input.Cover, input.LengthUnit),
            Diameter = Units.LengthToMm(input.Diameter, input.LengthUnit),
            Fc = Units.StressToMpa(input.Fc, input.StressUnit),
            Fy = Units.StressToMpa(input.Fy, input.StressUnit),
            Es = Units.StressToMpa(input.Es, input.StressUnit),
            LengthUnit = LengthUnit.Millimeter,
            StressUnit = StressUnit.MPa,
            MemberLengthL = memberLengthMm,
            TopRebarSide = ConvertSide(input.TopRebarSide),
            BottomRebarSide = ConvertSide(input.BottomRebarSide),
            LeftRebarSide = ConvertSide(input.LeftRebarSide),
            RightRebarSide = ConvertSide(input.RightRebarSide)
        };
    }

    private static RebarSuggestionConstraintSet BuildDefaultConstraints(
        IReadOnlyList<RebarDefinition> longitudinalBars,
        IReadOnlyList<RebarDefinition> shearLinkBars)
    {
        var longNames = longitudinalBars
            .Where(b => b.DiameterMm >= 20.0)
            .Select(b => b.Name)
            .ToList();

        var linkNames = shearLinkBars
            .Select(b => b.Name)
            .ToList();

        return new RebarSuggestionConstraintSet
        {
            AllowedBarSizeNames          = longNames,
            AllowedLinkBarSizeNames      = linkNames,
            MinimumBarDiameterMm         = 20.0,
            InitialTargetSpacingMm       = 150.0,
            SpacingReductionStepMm       = 10.0,
            MinimumSpacingSearchLimitMm  = 50.0,
            MaximumBarSpacingMm          = 300.0,
            UserTargetPmmRatio           = 1.00,
            MinLinkDiameterMm            = 10.0,    // practical minimum for Singapore (T10)
            MaxLinkSpacingMm             = 0,       // EC2 auto
            CrossTieThresholdMm          = 150.0,
            AllowAllSidesEqualLayout     = true,
            AllowSidesDifferentLayout    = true
        };
    }
}

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class Ec2SlendernessInputView : UserControl
{
    private readonly DispatcherTimer calcRefreshTimer;
    private InputViewModel? subscribedInputVm;
    private LoadCaseViewModel? subscribedLoadCase;

    public Ec2SlendernessInputView()
    {
        InitializeComponent();
        calcRefreshTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
        calcRefreshTimer.Tick += (_, _) =>
        {
            calcRefreshTimer.Stop();
            RefreshCalculationFormulas();
        };
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        UnsubscribeVm();
        if (e.NewValue is not InputViewModel vm) return;

        subscribedInputVm = vm;
        vm.PropertyChanged += OnVmOrLcPropertyChanged;
        ResubscribeLoadCase(vm.SelectedLoadCase);
        RefreshCalculationFormulas();
    }

    private void ResubscribeLoadCase(LoadCaseViewModel? lc)
    {
        if (subscribedLoadCase != null)
            subscribedLoadCase.PropertyChanged -= OnVmOrLcPropertyChanged;

        subscribedLoadCase = lc;

        if (lc != null)
            lc.PropertyChanged += OnVmOrLcPropertyChanged;
    }

    private void UnsubscribeVm()
    {
        if (subscribedInputVm != null)
        {
            subscribedInputVm.PropertyChanged -= OnVmOrLcPropertyChanged;
            subscribedInputVm = null;
        }

        ResubscribeLoadCase(null);
    }

    private void OnVmOrLcPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is InputViewModel vm && e.PropertyName == nameof(InputViewModel.SelectedLoadCase))
            ResubscribeLoadCase(vm.SelectedLoadCase);

        calcRefreshTimer.Stop();
        calcRefreshTimer.Start();
    }

    private void RefreshCalculationFormulas()
    {
        if (DataContext is not InputViewModel vm) return;
        var lc = vm.SelectedLoadCase;

        CalcL0x.Formula = vm.L0xLatex;
        CalcL0y.Formula = vm.L0yLatex;
        CalcLambdaFormula.Formula = lc?.LambdaFormulaLatex ?? string.Empty;
        CalcLambdaX.Formula = lc?.LambdaXResultLatex ?? string.Empty;
        CalcLambdaY.Formula = lc?.LambdaYResultLatex ?? string.Empty;
        CalcLimitFormula.Formula = lc?.LambdaLimitFormulaLatex ?? string.Empty;
        CalcLimitX.Formula = lc?.LambdaLimitXResultLatex ?? string.Empty;
        CalcLimitY.Formula = lc?.LambdaLimitYResultLatex ?? string.Empty;
        CalcRmFormula.Formula = lc?.MomentRatioFormulaLatex ?? string.Empty;
        CalcRmX.Formula = lc?.MomentRatioXResultLatex ?? string.Empty;
        CalcRmY.Formula = lc?.MomentRatioYResultLatex ?? string.Empty;
        CalcBranchFormula.Formula = lc?.BranchFormulaLatex ?? string.Empty;
        CalcCurvFormula.Formula = lc?.NominalCurvatureFormulaLatex ?? string.Empty;
        CalcCurvX.Formula = lc?.NominalCurvatureXResultLatex ?? string.Empty;
        CalcCurvY.Formula = lc?.NominalCurvatureYResultLatex ?? string.Empty;
        CalcMomentUsedFormula.Formula = lc?.MomentUsedFormulaLatex ?? string.Empty;
        CalcMxUsed.Formula = lc?.MxUsedResultLatex ?? string.Empty;
        CalcMyUsed.Formula = lc?.MyUsedResultLatex ?? string.Empty;
        SumRmX.Formula = lc?.MomentRatioXResultLatex ?? string.Empty;
        SumLambdaX.Formula = lc?.LambdaXResultLatex ?? string.Empty;
        SumLimitX.Formula = lc?.LambdaLimitXResultLatex ?? string.Empty;
        SumBranchX.Formula = lc?.Ec2BranchXLatex ?? string.Empty;
        SumCurvX.Formula = lc?.NominalCurvatureXResultLatex ?? string.Empty;
        SumMxUsed.Formula = lc?.MxUsedResultLatex ?? string.Empty;
        SumRmY.Formula = lc?.MomentRatioYResultLatex ?? string.Empty;
        SumLambdaY.Formula = lc?.LambdaYResultLatex ?? string.Empty;
        SumLimitY.Formula = lc?.LambdaLimitYResultLatex ?? string.Empty;
        SumBranchY.Formula = lc?.Ec2BranchYLatex ?? string.Empty;
        SumCurvY.Formula = lc?.NominalCurvatureYResultLatex ?? string.Empty;
        SumMyUsed.Formula = lc?.MyUsedResultLatex ?? string.Empty;
    }
}

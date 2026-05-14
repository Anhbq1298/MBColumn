using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ColumnCalculationService calculationService;
    private string validationMessage = "";
    private bool isCalculationOutdated;
    private bool hasSuccessfulCalculation;

    public MainWindowViewModel(ColumnCalculationService calculationService, InputViewModel input)
    {
        this.calculationService = calculationService;
        Input = input;
        Result = new ResultViewModel();
        CalculateCommand = new RelayCommand(Calculate);
        SubscribeToInputChanges();
    }

    public InputViewModel Input { get; }
    public ResultViewModel Result { get; }
    public ICommand CalculateCommand { get; }
    public string ValidationMessage { get => validationMessage; set => Set(ref validationMessage, value); }
    public bool IsCalculationOutdated
    {
        get => isCalculationOutdated;
        private set
        {
            Set(ref isCalculationOutdated, value);
            Raise(nameof(IsResultsTabAvailable));
        }
    }

    public bool IsResultsTabAvailable => Result.HasResult && !IsCalculationOutdated;

    private void Calculate()
    {
        try
        {
            ValidationMessage = "";
            Result.Result = calculationService.Calculate(Input.ToDto());
            hasSuccessfulCalculation = true;
            IsCalculationOutdated = false;
            Raise(nameof(IsResultsTabAvailable));
        }
        catch (Exception ex)
        {
            ValidationMessage = ex.Message;
            MessageBox.Show(ex.Message, "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void SubscribeToInputChanges()
    {
        Input.PropertyChanged += OnInputChanged;
        Input.LoadCases.CollectionChanged += OnLoadCasesChanged;
        foreach (var loadCase in Input.LoadCases)
        {
            loadCase.PropertyChanged += OnInputChanged;
        }

        Input.RebarLayout.Top.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Bottom.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Left.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Right.PropertyChanged += OnInputChanged;
    }

    private void OnLoadCasesChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is not null)
        {
            foreach (LoadCaseViewModel loadCase in e.OldItems)
            {
                loadCase.PropertyChanged -= OnInputChanged;
            }
        }

        if (e.NewItems is not null)
        {
            foreach (LoadCaseViewModel loadCase in e.NewItems)
            {
                loadCase.PropertyChanged += OnInputChanged;
            }
        }

        MarkCalculationOutdated();
    }

    private void OnInputChanged(object? sender, PropertyChangedEventArgs e)
        => MarkCalculationOutdated();

    private void MarkCalculationOutdated()
    {
        if (!hasSuccessfulCalculation)
        {
            return;
        }

        IsCalculationOutdated = true;
    }
}

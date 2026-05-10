using System.Windows;
using System.Windows.Input;
using ColumnDesigner.Application.Services;
using ColumnDesigner.Presentation.Wpf.Commands;

namespace ColumnDesigner.Presentation.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ColumnCalculationService calculationService;
    private string validationMessage = "";

    public MainWindowViewModel(ColumnCalculationService calculationService, InputViewModel input)
    {
        this.calculationService = calculationService;
        Input = input;
        Result = new ResultViewModel();
        CalculateCommand = new RelayCommand(Calculate);
    }

    public InputViewModel Input { get; }
    public ResultViewModel Result { get; }
    public ICommand CalculateCommand { get; }
    public string ValidationMessage { get => validationMessage; set => Set(ref validationMessage, value); }

    private void Calculate()
    {
        try
        {
            ValidationMessage = "";
            Result.Result = calculationService.Calculate(Input.ToDto());
        }
        catch (Exception ex)
        {
            ValidationMessage = ex.Message;
            MessageBox.Show(ex.Message, "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

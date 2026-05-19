using System.Windows;
using System.Windows.Input;
using MBColumn.Application.Services;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Persistence;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = BuildViewModel();
        DataContext = vm;

        // Keyboard shortcuts
        InputBindings.Add(new KeyBinding(vm.NewProjectCommand, Key.N, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.OpenProjectCommand, Key.O, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.SaveProjectCommand, Key.S, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.CalculateCommand, Key.F5, ModifierKeys.None));
    }

    private static MainWindowViewModel BuildViewModel()
    {
        IDesignCodeService aciCode = new Aci318DesignCodeService();
        IDesignCodeService ec2Code = new Ec2DesignCodeService();
        IDesignCodeServiceFactory codeFactory = new DesignCodeServiceFactory(aciCode, ec2Code);
        IInteractionSolverFactory solverFactory = new InteractionSolverFactory(aciCode, ec2Code);
        IUnitConversionService units = new UnitConversionService();
        IRebarDatabase metricBars = new SingaporeRebarDatabase();
        IRebarDatabase imperialBars = new ImperialRebarDatabase();
        IRatioCheckService ratio = new RatioCheckService();
        IControlPointBuilder control = new ControlPointBuilderService(units);
        var diagrams = new DiagramDataService();
        var validation = new InputValidationService();
        IRebarCoordinateBuilderService rebarCoordinates = new RebarCoordinateBuilderService(units, metricBars, imperialBars);
        var calculation = new ColumnCalculationService(solverFactory, codeFactory, units, ratio, control, diagrams, validation, rebarCoordinates);

        IProjectService projectService = new ProjectService();

        var input = new InputViewModel(metricBars, imperialBars, rebarCoordinates);
        return new MainWindowViewModel(calculation, projectService, input);
    }
}

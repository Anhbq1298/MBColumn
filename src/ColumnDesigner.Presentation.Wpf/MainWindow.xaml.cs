using System.Windows;
using ColumnDesigner.Application.Services;
using ColumnDesigner.Domain.Interfaces;
using ColumnDesigner.Infrastructure.DesignCodes;
using ColumnDesigner.Infrastructure.Math;
using ColumnDesigner.Infrastructure.Rebar;
using ColumnDesigner.Infrastructure.Solvers;
using ColumnDesigner.Presentation.Wpf.ViewModels;

namespace ColumnDesigner.Presentation.Wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = BuildViewModel();
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
        return new MainWindowViewModel(calculation, new InputViewModel(metricBars, imperialBars, rebarCoordinates));
    }
}

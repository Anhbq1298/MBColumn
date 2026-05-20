using System.Windows;
using System.Windows.Controls;
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
        // Create a project service early so the startup dialog can
        // create or open a project on the same service instance.
        IProjectService projectService = new ProjectService();

        var startup = new Views.StartUpWindow(projectService) { Owner = this };
        if (startup.ShowDialog() != true)
        {
            Close();
            return;
        }

        var vm = BuildViewModel(projectService);
        DataContext = vm;

        // Keyboard shortcuts
        InputBindings.Add(new KeyBinding(vm.NewProjectCommand, Key.N, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.OpenProjectCommand, Key.O, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.SaveProjectCommand, Key.S, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.CalculateCommand, Key.F5, ModifierKeys.None));
    }

    // Auto-focus and select-all when a rename TextBox becomes visible
    private void RenameBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is TextBox tb && tb.IsVisible)
        {
            tb.Focus();
            tb.SelectAll();
        }
    }

    // Column rename handlers
    private void ColumnRenameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (sender is not TextBox tb || tb.DataContext is not ColumnItemViewModel item) return;
        if (e.Key == Key.Enter) { Explorer().CommitRename(item); e.Handled = true; }
        else if (e.Key == Key.Escape) { Explorer().CancelRename(item); e.Handled = true; }
    }

    private void ColumnRenameBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox tb && tb.DataContext is ColumnItemViewModel item)
            Explorer().CommitRename(item);
    }

    // Project rename handlers
    private void ProjectRenameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) { Explorer().CommitRenameProject(); e.Handled = true; }
        else if (e.Key == Key.Escape) { Explorer().CancelRenameProject(); e.Handled = true; }
    }

    private void ProjectRenameBox_LostFocus(object sender, RoutedEventArgs e)
        => Explorer().CommitRenameProject();

    private ProjectExplorerViewModel Explorer()
        => ((MainWindowViewModel)DataContext).Explorer;

    private static MainWindowViewModel BuildViewModel(IProjectService projectService)
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

        var input = new InputViewModel(metricBars, imperialBars, rebarCoordinates);
        return new MainWindowViewModel(calculation, projectService, input);
    }
}

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class InputTabView : UserControl
{
    private Window? slendernessDetailsWindow;
    private InputViewModel? subscribedInputVm;

    public InputTabView()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.Key == Key.Enter && Keyboard.FocusedElement is TextBox textBox)
        {
            var binding = textBox.GetBindingExpression(TextBox.TextProperty);
            binding?.UpdateSource();
            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            e.Handled = true;
        }
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (subscribedInputVm != null)
            subscribedInputVm.PropertyChanged -= OnVmPropertyChanged;

        subscribedInputVm = e.NewValue as InputViewModel;

        if (subscribedInputVm != null)
            subscribedInputVm.PropertyChanged += OnVmPropertyChanged;
    }

    private void OnVmPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not InputViewModel vm) return;

        if ((e.PropertyName == nameof(InputViewModel.IsSlendernessCalculationDetailsOpen)
                || e.PropertyName == nameof(InputViewModel.SlendernessCalculationLoadCase))
            && vm.IsSlendernessCalculationDetailsOpen)
        {
            OpenSlendernessDetailsWindow(vm);
        }
    }

    private void OpenSlendernessDetailsWindow(InputViewModel vm)
    {
        if (vm.SlendernessCalculationLoadCase is not LoadCaseViewModel loadCase)
            return;

        if (slendernessDetailsWindow is not null)
        {
            slendernessDetailsWindow.Title = BuildSlendernessDetailsTitle(loadCase);
            slendernessDetailsWindow.Activate();
            return;
        }

        SlendernessDetailsPanel.DataContext = vm;
        SlendernessDetailsOverlay.Child = null;

        var window = new Window
        {
            Title = BuildSlendernessDetailsTitle(loadCase),
            Owner = Window.GetWindow(this),
            Content = SlendernessDetailsPanel,
            DataContext = vm,
            Width = 1500,
            Height = 920,
            MinWidth = 1100,
            MinHeight = 720,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            ResizeMode = ResizeMode.CanResize
        };

        window.Closed += (_, _) =>
        {
            window.Content = null;
            if (SlendernessDetailsOverlay.Child is null)
                SlendernessDetailsOverlay.Child = SlendernessDetailsPanel;

            SlendernessDetailsPanel.DataContext = null;
            slendernessDetailsWindow = null;
            if (vm.CloseSlendernessCalculationDetailsCommand.CanExecute(null))
                vm.CloseSlendernessCalculationDetailsCommand.Execute(null);
        };

        slendernessDetailsWindow = window;
        window.Show();
    }

    private static string BuildSlendernessDetailsTitle(LoadCaseViewModel loadCase)
        => "EC2 Moment Determination";
}

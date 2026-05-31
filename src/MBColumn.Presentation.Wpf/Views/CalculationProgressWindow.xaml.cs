using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class CalculationProgressWindow : Window, INotifyPropertyChanged
{
    private string statusText = "Calculating: [0/0] calculated";
    private double progressValue = 0;
    private double progressMax = 100;

    public CalculationProgressWindow()
    {
        InitializeComponent();
    }

    public string StatusText
    {
        get => statusText;
        set
        {
            if (statusText == value) return;
            statusText = value;
            OnPropertyChanged();
        }
    }

    public double ProgressValue
    {
        get => progressValue;
        set
        {
            if (progressValue == value) return;
            progressValue = value;
            OnPropertyChanged();
        }
    }

    public double ProgressMax
    {
        get => progressMax;
        set
        {
            if (progressMax == value) return;
            progressMax = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

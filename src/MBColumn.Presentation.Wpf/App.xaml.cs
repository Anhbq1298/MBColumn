using MBColumn.Presentation.Wpf.Composition;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf;

public partial class App : System.Windows.Application
{
    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {
        base.OnStartup(e);
        DispatcherUnhandledException += OnUnhandledException;
        ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;

        RunShell();
    }

    private static void RunShell()
    {
        while (true)
        {
            using var composition = AppComposition.Create();
            var startup = new StartUpWindow(composition.ProjectService);
            if (startup.ShowDialog() != true)
                break;

            var mainWindow = new MainWindow(composition.CreateMainWindowViewModel());
            Current.MainWindow = mainWindow;
            mainWindow.ShowDialog();
        }

        Current.Shutdown();
    }

    private static void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        System.Windows.MessageBox.Show(
            $"Unhandled error:\n\n{e.Exception.GetType().Name}: {e.Exception.Message}\n\n{e.Exception.StackTrace}",
            "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        e.Handled = true;
    }
}

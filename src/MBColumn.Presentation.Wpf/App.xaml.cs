using MBColumn.Presentation.Wpf.Composition;
using MBColumn.Presentation.Wpf.Controls.MathRendering;
using MBColumn.Presentation.Wpf.Views;
using System;
using System.Windows;

namespace MBColumn.Presentation.Wpf;

public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            System.IO.File.WriteAllText("crash.log", args.ExceptionObject.ToString());
        };
        DispatcherUnhandledException += (s, args) =>
        {
            System.IO.File.WriteAllText("crash.log", args.Exception.ToString());
            args.Handled = true; // prevent immediate exit if possible
        };

        DispatcherUnhandledException += OnUnhandledException;
        ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;

        // Pre-initialize the shared WebView2 environment so KaTeX renders instantly on first open.
        MathEquationView.PreWarm();

        RunShell(e.Args);
    }

    private static void RunShell(string[] args)
    {
        string? initialFilePath = null;
        if (args.Length > 0)
        {
            var potentialPath = args[0];
            if (System.IO.File.Exists(potentialPath))
            {
                initialFilePath = System.IO.Path.GetFullPath(potentialPath);
            }
        }

        bool isFirstRun = true;

        while (true)
        {
            using var composition = AppComposition.Create();

            if (isFirstRun && !string.IsNullOrEmpty(initialFilePath))
            {
                try
                {
                    composition.ProjectService.OpenProject(initialFilePath);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(
                        $"Failed to open project file:\n\n{ex.Message}",
                        "Error Loading Project",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Error);
                    initialFilePath = null; // Fallback to normal flow
                }
            }

            if (string.IsNullOrEmpty(initialFilePath))
            {
                var startup = new StartUpWindow(composition.ProjectService);
                if (startup.ShowDialog() != true)
                    break;
            }

            var mainWindow = new MainWindow(composition.CreateMainWindowViewModel());
            Current.MainWindow = mainWindow;

            // Clear initial path so subsequent loops (if closed and went back) show the startup screen
            initialFilePath = null;
            isFirstRun = false;

            mainWindow.ShowDialog();

            // If started with command line arguments (e.g. via double-clicking a file),
            // shut down immediately when the main window closes rather than going back to startup.
            if (args.Length > 0)
            {
                break;
            }
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

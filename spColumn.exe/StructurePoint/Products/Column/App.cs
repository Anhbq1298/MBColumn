using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using #7hc;
using #cYd;
using #f5d;
using #LQc;
using #pXd;
using #UYd;
using #Z;
using #ZPb;
using Ab2d.Licensing.ReaderSvg;
using Ab2d.Licensing.ZoomPanel;
using Ab3d.Licensing.PowerToys;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Core.Application;
using StructurePoint.Products.Column.CommandLine;
using Telerik.Windows.Automation.Peers;

namespace StructurePoint.Products.Column
{
	// Token: 0x0200001B RID: 27
	internal sealed class App : System.Windows.Application
	{
		// Token: 0x06000094 RID: 148 RVA: 0x0008574C File Offset: 0x0008394C
		public App()
		{
			LastChanceLogger.LogsPath = #YPb.LogsPath;
			base.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
			base.DispatcherUnhandledException += this.Dispatcher_UnhandledException;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00085798 File Offset: 0x00083998
		protected override void OnStartup(StartupEventArgs e)
		{
			#uzc #uzc = new #uzc(#Phc.#3hc(107395507));
			try
			{
				App.Configure();
				#uzc.#szc(#Phc.#3hc(107395486));
				base.OnStartup(e);
				this.startupHandler = new ColumnApplicationStartupHandler();
				this.startupHandler.#UQb((e.Args.Length == 1) ? e.Args.FirstOrDefault<string>() : null);
			}
			catch (Exception exception)
			{
				this.HandleException(exception);
			}
			finally
			{
				#uzc.#szc(#Phc.#3hc(107395437));
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00085854 File Offset: 0x00083A54
		private static void Configure()
		{
			CoreCompatibilityPreferences.EnableMultiMonitorDisplayClipping = new bool?(true);
			Ab3d.Licensing.PowerToys.LicenseHelper.EmbeddedLicenseAssembly = typeof(App).Assembly;
			Ab2d.Licensing.ZoomPanel.LicenseHelper.EmbeddedLicenseAssembly = typeof(App).Assembly;
			Ab2d.Licensing.ReaderSvg.LicenseHelper.EmbeddedLicenseAssembly = typeof(App).Assembly;
			#CXd.StackTraceInfoProvider = new #u5d();
			ColumnApplicationStartupHandler.#TQb();
			#Y.#P();
			EyeshotInitializer.Instance.StartInitialize(Logger.Instance);
			#KQc.#JQc();
			System.Windows.Forms.Application.EnableVisualStyles();
			AutomationManager.AutomationMode = AutomationMode.Disabled;
			App.SetAlignment();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003682 File Offset: 0x00001882
		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			Ignore.#14d<Exception>(delegate()
			{
				ColumnApplicationStartupHandler columnApplicationStartupHandler = this.startupHandler;
				if (columnApplicationStartupHandler == null)
				{
					return;
				}
				columnApplicationStartupHandler.#1();
			}, null);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000036AA File Offset: 0x000018AA
		private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			this.HandleException(e.Exception);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000036C4 File Offset: 0x000018C4
		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			this.HandleException(e.ExceptionObject as Exception);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000858F8 File Offset: 0x00083AF8
		private static void MyShowMessageBox(Exception exception)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(Strings.StringAnUnknownErrorOccrued.#z2d());
			stringBuilder.AppendLine(#sYd.#oYd(exception));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(Strings.StringErrorDetailsHaveBeenLogged.#z2d());
			stringBuilder.AppendLine(#Phc.#3hc(107395424));
			if (Interlocked.Increment(ref App.messageBoxShown) == 1)
			{
				System.Windows.MessageBox.Show(stringBuilder.ToString().Trim(), Strings.StringUnexpectedError, MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00085990 File Offset: 0x00083B90
		private static void SetAlignment()
		{
			bool menuDropAlignment = SystemParameters.MenuDropAlignment;
			if (menuDropAlignment)
			{
				Type typeFromHandle = typeof(SystemParameters);
				FieldInfo field = typeFromHandle.GetField(#Phc.#3hc(107395379), BindingFlags.Static | BindingFlags.NonPublic);
				if (field != null)
				{
					field.SetValue(null, false);
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000036E3 File Offset: 0x000018E3
		private void HandleException(Exception exception)
		{
			if (exception == null)
			{
				return;
			}
			Logger.Error(#Phc.#3hc(107395354), exception);
			App.MyShowMessageBox(exception);
			base.Shutdown(-1);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000859E0 File Offset: 0x00083BE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107394813), UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00085A24 File Offset: 0x00083C24
		[STAThread]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public static void Main(string[] args)
		{
			try
			{
				if (args.Length > 1 || CommandlineParametersParser.#4Sb(args))
				{
					System.Windows.MessageBox.Show(Strings.StringCommandlineIsNotSupportedPleaseUseSpMatsCLIExe.#z2d(), ColumnGlobalInfo.ShortName, MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					App app = new App();
					app.InitializeComponent();
					#Llf.#eb(false);
					app.Run();
				}
			}
			finally
			{
				#Llf.#db();
			}
		}

		// Token: 0x04000037 RID: 55
		private static int messageBoxShown;

		// Token: 0x04000038 RID: 56
		private ColumnApplicationStartupHandler startupHandler;

		// Token: 0x04000039 RID: 57
		private bool _contentLoaded;
	}
}

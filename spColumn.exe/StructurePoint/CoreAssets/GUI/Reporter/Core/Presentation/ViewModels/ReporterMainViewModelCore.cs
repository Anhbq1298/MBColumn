using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using #3Rd;
using #5Kd;
using #6Pd;
using #7hc;
using #BTd;
using #cYd;
using #ERd;
using #ezc;
using #FTd;
using #hId;
using #LQc;
using #mKd;
using #o1d;
using #qPd;
using #sUd;
using #UYd;
using #v1c;
using #VQd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed;
using Telerik.Windows.Documents.Fixed.UI;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels
{
	// Token: 0x020001A3 RID: 419
	public abstract class ReporterMainViewModelCore<TExplorer> : #CBc<#4Kd>, INotifyPropertyChanged, #RBc<#4Kd>, IViewModel, #pPd where TExplorer : ReportExplorerViewModelBase
	{
		// Token: 0x06000DAF RID: 3503 RVA: 0x0009F628 File Offset: 0x0009D828
		protected ReporterMainViewModelCore(#GBc dependencyResolver, #4Kd view, ILogger logger, #v2c fileSystemService, #uUd featuresDescriptor, #8Sc dialogService, #wUd settingsManager, #uPd reporterSettingsWindowViewModel, #vUd reporterCommands, #rUd applicationContext, #xPd optionsPanelViewModel, #tUd exceptionHandler, #ATd reportFontSizeInfoProvider, bool subscribeLeftPanel = true) : base(dependencyResolver, view, logger)
		{
			this.#y = fileSystemService;
			this.#x = featuresDescriptor;
			this.#z = dialogService;
			this.#A = settingsManager;
			this.#B = reporterSettingsWindowViewModel;
			this.#p = optionsPanelViewModel;
			this.#q = exceptionHandler;
			this.#r = reportFontSizeInfoProvider;
			this.#s = reporterCommands;
			this.#t = applicationContext;
			reporterCommands.ExportCommand.SetCommand(new Action(this.#v5c), new Func<bool>(this.#iMd));
			reporterCommands.PrintCommand.SetCommand(new Action(this.#UMd), new Func<bool>(this.#VMd));
			reporterCommands.ExitCommand.SetCommand(new Action(this.#cMd));
			this.#v = new DelegateCommand(new Action<object>(this.#oMd), new Predicate<object>(this.#mMd));
			this.#u = new DelegateCommand(new Action<object>(this.#bMd), new Predicate<object>(this.#aMd));
			this.#H = new DelegateCommand(new Action<object>(this.#Hxb), new Predicate<object>(this.#Ixb));
			this.#n = new DelegateCommand(new Action<object>(this.#6Ld));
			base.View.WordAndPdfViewer.DocumentChanged += this.#fLd;
			base.View.WordAndPdfViewer.ScaleModeChanged += this.#eLd;
			base.View.TextViewer.DocumentChanged += this.#fLd;
			base.View.TextViewer.ScaleModeChanged += this.#eLd;
			this.OptionsPanelViewModel.View.PageSetupChanged += this.#4Ld;
			ICommandFactory commandFactory = dependencyResolver.#vy<ICommandFactory>();
			this.#w = commandFactory.Create(new Action<object>(this.#mk), new Predicate<object>(this.#9Ld));
			this.SettingsManager.PropertyChanged += this.#jz;
			if (subscribeLeftPanel)
			{
				this.#kbb();
			}
			this.#i = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringGeneratingReport.#B2d();
			this.IsAutoRegenerationEnabled = true;
			this.#c = OutdatedModelDisplayMode.Message;
			base.View.Closing += this.#Dh;
			base.View.Loaded += new RoutedEventHandler(this.#Ih);
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000DB0 RID: 3504 RVA: 0x0009F8C0 File Offset: 0x0009DAC0
		// (remove) Token: 0x06000DB1 RID: 3505 RVA: 0x0009F908 File Offset: 0x0009DB08
		public event EventHandler OutdatedReportRebuildRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#l;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#l;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x000108BD File Offset: 0x0000EABD
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x000108C9 File Offset: 0x0000EAC9
		public Uri WindowIconUri { get; set; }

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x000108DA File Offset: 0x0000EADA
		public DelegateCommand RebuildOutdatedReportCommand { get; }

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x000108E6 File Offset: 0x0000EAE6
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x000108F2 File Offset: 0x0000EAF2
		public OutdatedModelDisplayMode OutdatedModelDisplayMode
		{
			get
			{
				return this.#c;
			}
			protected set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107278437));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278437));
				}
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00010930 File Offset: 0x0000EB30
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x0001093C File Offset: 0x0000EB3C
		public string BusyMessage
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#i, value))
				{
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381157));
				}
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00010974 File Offset: 0x0000EB74
		public virtual string ReportIsUnavailableOrOutdatedMessaage { get; }

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06000DBA RID: 3514
		public abstract DocumentContentOptionsCore OptionsCore { get; }

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00010980 File Offset: 0x0000EB80
		public #xPd OptionsPanelViewModel { get; }

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x0001098C File Offset: 0x0000EB8C
		public #tUd ExceptionHandler { get; }

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x00010998 File Offset: 0x0000EB98
		public #ATd ReportFontSizeInfoProvider { get; }

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000109A4 File Offset: 0x0000EBA4
		public #vUd ReporterCommands { get; }

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x000109B0 File Offset: 0x0000EBB0
		public #rUd ApplicationContext { get; }

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x000109BC File Offset: 0x0000EBBC
		public DelegateCommand RebuildDocumentCommand { get; }

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x000109C8 File Offset: 0x0000EBC8
		public DelegateCommand PrintCommand { get; }

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06000DC2 RID: 3522
		public abstract TExplorer Explorer { get; }

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x000109D4 File Offset: 0x0000EBD4
		public IDelegateCommand OpenSettingsCommand { get; }

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x000109E0 File Offset: 0x0000EBE0
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x000109EC File Offset: 0x0000EBEC
		public bool IsBusy
		{
			get
			{
				return this.#d;
			}
			protected set
			{
				if (this.#d != value)
				{
					this.#d = value;
					this.#vh(false);
					base.RaisePropertyChanged(#Phc.#3hc(107413161));
				}
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00010A21 File Offset: 0x0000EC21
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x00010A2D File Offset: 0x0000EC2D
		public string Title
		{
			get
			{
				return this.#h;
			}
			protected set
			{
				if (\u0093.\u0015\u0003(this.#h, value))
				{
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408142));
				}
			}
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x0009F950 File Offset: 0x0009DB50
		public bool AreNavigationFeaturesEnabled
		{
			get
			{
				ReportFileFormat reportFileFormat = this.ApplicationContext.Options.SelectedFileFormat;
				return this.#hy() && (reportFileFormat == ReportFileFormat.Word || reportFileFormat == ReportFileFormat.Pdf || reportFileFormat == ReportFileFormat.Text);
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00010A65 File Offset: 0x0000EC65
		// (set) Token: 0x06000DCA RID: 3530 RVA: 0x00010A71 File Offset: 0x0000EC71
		public RadPdfViewer ActivePdfViewer
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278404));
				}
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00010A9F File Offset: 0x0000EC9F
		public #uUd FeaturesDescriptor { get; }

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00010AAB File Offset: 0x0000ECAB
		public bool CanOpenSettings
		{
			get
			{
				return this.#hy();
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00010ABB File Offset: 0x0000ECBB
		protected #v2c FileSystemService { get; }

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06000DCE RID: 3534 RVA: 0x00010AC7 File Offset: 0x0000ECC7
		protected #8Sc DialogService { get; }

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00010AD3 File Offset: 0x0000ECD3
		protected #wUd SettingsManager { get; }

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00010ADF File Offset: 0x0000ECDF
		protected #uPd ReporterSettingsWindowViewModel { get; }

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06000DD1 RID: 3537
		protected abstract #JRd Reports { get; }

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x0009F994 File Offset: 0x0009DB94
		protected #wKd ActiveSettings
		{
			get
			{
				if (this.ApplicationContext.Options.SelectedFileFormat.#OSd())
				{
					return this.#a;
				}
				if (this.ApplicationContext.Options.SelectedFileFormat.#Lcd())
				{
					return this.#b;
				}
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool #OLd()
		{
			return true;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00003375 File Offset: 0x00001575
		public virtual bool #PLd()
		{
			return true;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0009F9F0 File Offset: 0x0009DBF0
		public virtual void #od(IGenericLoaderWindow #by)
		{
			try
			{
				this.#k = true;
				if (#by != null)
				{
					this.#j = #by;
				}
				bool flag = this.#f;
				if (!this.#f)
				{
					this.ApplicationContext.Options.PropertyChanged -= this.#kz;
					this.ApplicationContext.Options.PropertyChanged += this.#kz;
					this.#f = true;
					this.Explorer.#5Nd();
					this.#AMd(new Action(this.#WMd));
					this.#8Ld();
				}
				this.#gy();
				this.ApplicationContext.#YRd();
				this.Reports.#9Qd();
				this.#NMd();
				base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#HLd()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), new ParameterExpression[0]));
				base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#LLd()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), new ParameterExpression[0]));
				this.#vh(true);
				if (this.#iy())
				{
					if (flag)
					{
						LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#XMd));
					}
					base.View.BringToFront();
					if (this.#XLd(this.ApplicationContext.Options.SelectedFileFormat))
					{
						LayoutHelper.DelayOperation(1.0, new Action(this.#YMd));
					}
					else
					{
						LayoutHelper.DelayOperation(1.0, new Action(this.#CBf));
					}
				}
				else
				{
					this.Reports.#9Qd();
					this.ApplicationContext.Options.IsReportFileFormatChangeAllowed = true;
					this.#k = false;
				}
			}
			catch
			{
				this.#k = false;
				throw;
			}
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00010AEB File Offset: 0x0000ECEB
		public void #QLd()
		{
			base.View.BringToFront();
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00010B04 File Offset: 0x0000ED04
		public void #RLd()
		{
			this.Explorer.#4Nd();
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00010B22 File Offset: 0x0000ED22
		public virtual bool #SLd()
		{
			return this.IsBusy || this.ApplicationContext.IsCurrentlyReadingData || this.ApplicationContext.IsCurrentlyGeneratingReport || this.#k;
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00010B5C File Offset: 0x0000ED5C
		public bool #TLd()
		{
			return this.#hy() && !this.ApplicationContext.IsDirty;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x0009FC30 File Offset: 0x0009DE30
		public virtual bool #ULd(bool #VLd)
		{
			Thread thread = this.#D;
			if (thread == null)
			{
				return true;
			}
			if (this.#Ixb(null))
			{
				this.#Hxb(null);
			}
			if (#VLd)
			{
				while (\u0010\u0002.~\u0081\u0004(thread) && !\u007F\u0006.~\u0080\u0010(thread).HasFlag(ThreadState.Aborted) && !\u007F\u0006.~\u0080\u0010(thread).HasFlag(ThreadState.Stopped) && !\u007F\u0006.~\u0080\u0010(thread).HasFlag(ThreadState.Unstarted) && !\u007F\u0006.~\u0080\u0010(thread).HasFlag(ThreadState.Suspended))
				{
				}
			}
			return false;
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x0009FD08 File Offset: 0x0009DF08
		public virtual bool #WLd()
		{
			if (this.#SLd())
			{
				base.View.BringToFront();
				this.DialogService.#od(\u0019.\u0002\u0002(\u008E.\u0004\u0003().#z2d(true), \u008E.\u0005\u0003().#z2d()), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringSpReporter, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
				return true;
			}
			return false;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00010B82 File Offset: 0x0000ED82
		protected virtual bool #XLd(ReportFileFormat #cA)
		{
			return #cA.#OSd() || #cA.#Lcd();
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x0009FD78 File Offset: 0x0009DF78
		protected virtual void #YLd(object #Ge, #rQd #He)
		{
			ReporterMainViewModelCore<TExplorer>.#Ybc #Ybc = new ReporterMainViewModelCore<!0>.#Ybc();
			#Ybc.#a = #He;
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			if (#cA.#OSd() || #cA.#Lcd())
			{
				this.#7Ld(#Ybc.#a);
				return;
			}
			if (#cA.#Icd())
			{
				try
				{
					if (this.Reports.ExcelReport.DocumentMap != null)
					{
						#zSd #zSd = this.Reports.ExcelReport.DocumentMap.Map.FirstOrDefault(new Func<#zSd, bool>(#Ybc.#LVd));
						if (#zSd != null)
						{
							base.View.NavigateSpreadsheet(#zSd.Header);
						}
					}
				}
				catch (Exception #ob)
				{
					this.#1Pb(#ob);
				}
			}
		}

		// Token: 0x06000DDE RID: 3550
		protected abstract #jJd #ey();

		// Token: 0x06000DDF RID: 3551
		protected abstract void #fy();

		// Token: 0x06000DE0 RID: 3552
		protected abstract void #gy();

		// Token: 0x06000DE1 RID: 3553
		protected abstract bool #hy();

		// Token: 0x06000DE2 RID: 3554
		protected abstract bool #iy();

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0009FE50 File Offset: 0x0009E050
		protected virtual void #ZLd()
		{
			try
			{
				ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
				this.Reports.#oRd(#cA);
				if (#cA.#OSd() && base.View.WordAndPdfViewer != null)
				{
					this.#hLd(base.View.WordAndPdfViewer);
				}
				if (#cA.#Lcd() && base.View.TextViewer != null)
				{
					this.#hLd(base.View.TextViewer);
				}
			}
			catch (Exception exception)
			{
				base.Logger.Log(LoggingLevel.Warning, exception);
			}
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x0009FEFC File Offset: 0x0009E0FC
		protected virtual void #vh(bool #0Ld = true)
		{
			ReporterMainViewModelCore<TExplorer>.#EVd #EVd = new ReporterMainViewModelCore<!0>.#EVd();
			#EVd.#a = this;
			#EVd.#b = #0Ld;
			\u0086\u0005.~\u001F\u000F(\u0084\u0005.~\u001E\u000F((Window)base.View), DispatcherPriority.Normal, new Action(#EVd.#NVd));
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00010BA0 File Offset: 0x0000EDA0
		protected void #1Pb(Exception #ob)
		{
			this.ExceptionHandler.#3Ab(#ob);
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0009FF58 File Offset: 0x0009E158
		protected virtual void #1Ld()
		{
			Ignore.#14d<Exception>(new Action(this.#ZMd), null);
			Ignore.#14d<Exception>(new Action(this.#0Md), null);
			Ignore.#14d<Exception>(new Action(this.#1Md), null);
			Ignore.#14d<Exception>(new Action(this.#2Md), null);
			Ignore.#14d<Exception>(new Action(this.#3Md), null);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0009FFD0 File Offset: 0x0009E1D0
		protected virtual void #2Ld()
		{
			#JRd #JRd = this.Reports;
			if (!false)
			{
				#JRd.#9Qd();
			}
			if (this.SettingsManager.ReporterRegenerateReportAutomatically && this.#HMd(this.ApplicationContext.Options.SelectedFileFormat))
			{
				if (this.#OLd())
				{
					this.#JMd();
					return;
				}
			}
			else
			{
				this.ApplicationContext.IsDirty = true;
				\u0007.~\u000F(this.PrintCommand);
				this.ReporterCommands.PrintCommand.InvalidateCanExecute();
				this.ReporterCommands.ExportCommand.InvalidateCanExecute();
			}
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x000A0078 File Offset: 0x0009E278
		protected void #kbb()
		{
			this.#e = Observable.FromEventPattern<EventHandler<EventArgs>, EventArgs>(new Action<EventHandler<EventArgs>>(this.#4Md), new Action<EventHandler<EventArgs>>(this.#6Md)).Buffer(\u001C.\u0007\u0002(500.0), 1000).Subscribe(new Action<IList<EventPattern<EventArgs>>>(this.#7Md));
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x00010BBA File Offset: 0x0000EDBA
		protected virtual void #3Ld()
		{
			EventHandler eventHandler = this.#l;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x0009E4E4 File Offset: 0x0009C6E4
		private void #eLd(object #Ge, EventArgs #He)
		{
			RadPdfViewer radPdfViewer = (RadPdfViewer)#Ge;
			RadPdfViewer radPdfViewer2;
			if (!false)
			{
				radPdfViewer2 = radPdfViewer;
			}
			if (\u0014\u0006.~\u0014\u0010(radPdfViewer2) == ScaleMode.Normal)
			{
				\u0016\u0006.~\u0016\u0010(radPdfViewer2, \u0015\u0006.~\u0015\u0010(radPdfViewer2, #Phc.#3hc(107278505)));
			}
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00010BDE File Offset: 0x0000EDDE
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			this.#Hxb(null);
			this.#1Ld();
			this.Explorer.#4Nd();
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x00010C09 File Offset: 0x0000EE09
		private void #4Ld(object #Ge, EventArgs #He)
		{
			this.#2Ld();
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x000A00E4 File Offset: 0x0009E2E4
		private void #jz(object #Ge, PropertyChangedEventArgs #He)
		{
			if (\u0093.\u0016\u0003(\u007F.~\u001A\u0002(#He), ReflectionHelper.#M4c<ExplorerPosition>(System.Linq.Expressions.Expression.Lambda<Func<ExplorerPosition>>(\u0089\u0005.\u0081\u000F(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#jf()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#wUd.#WTd()).MethodHandle)), new ParameterExpression[0]))))
			{
				this.#8Ld();
			}
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x000A0194 File Offset: 0x0009E394
		private void #fLd(object #Ge, DocumentChangedEventArgs #He)
		{
			ReporterMainViewModelCore<TExplorer>.#l5b #l5b = new ReporterMainViewModelCore<!0>.#l5b();
			#l5b.#a = this;
			#l5b.#b = this.ActivePdfViewer;
			if (#l5b.#b != #Ge || \u0017\u0006.~\u0017\u0010(#He) == null)
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#l5b.#GVd));
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00010C19 File Offset: 0x0000EE19
		private void #Ih(object #Ge, EventArgs #He)
		{
			IGenericLoaderWindow genericLoaderWindow = this.#j;
			if (genericLoaderWindow == null)
			{
				return;
			}
			genericLoaderWindow.#Fgc();
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x000A01F0 File Offset: 0x0009E3F0
		private void #5Ld()
		{
			ReporterMainViewModelCore<!0>.#PVd #PVd = new ReporterMainViewModelCore<!0>.#PVd();
			#PVd.#a = this;
			#PVd.#b = \u0004\u0006.\u0003\u0010((DependencyObject)base.View);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#PVd.#OVd));
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00010C33 File Offset: 0x0000EE33
		private void #6Ld(object #Sb)
		{
			if (!this.#OLd())
			{
				return;
			}
			this.#3Ld();
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x000A0244 File Offset: 0x0009E444
		private void #7Ld(#rQd #He)
		{
			ReportFileFormat reportFileFormat = this.ApplicationContext.Options.SelectedFileFormat;
			#0Qd #0Qd;
			RadPdfViewer radPdfViewer;
			if (reportFileFormat == ReportFileFormat.Word || reportFileFormat == ReportFileFormat.Pdf)
			{
				#0Qd = this.Reports.WordPdfReport;
				radPdfViewer = base.View.WordAndPdfViewer;
			}
			else
			{
				if (reportFileFormat != ReportFileFormat.Text)
				{
					return;
				}
				#0Qd = this.Reports.TextReport;
				radPdfViewer = base.View.TextViewer;
			}
			if (this.IsBusy || #0Qd == null || \u0017\u0006.~\u0018\u0010(radPdfViewer) == null || \u0018\u0006.~\u0019\u0010(radPdfViewer) == null)
			{
				return;
			}
			try
			{
				NavigationHelper.#hQd(#0Qd, this.OptionsCore, radPdfViewer, #He);
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
			}
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00010C50 File Offset: 0x0000EE50
		private void #8Ld()
		{
			base.View.ExplorerPosition = this.SettingsManager.ReporterExplorerPosition;
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x00010C74 File Offset: 0x0000EE74
		private bool #9Ld(object #Sb)
		{
			return this.CanOpenSettings;
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00010C84 File Offset: 0x0000EE84
		private void #mk(object #Sb)
		{
			this.ReporterSettingsWindowViewModel.#jH(base.View);
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00010CA3 File Offset: 0x0000EEA3
		private bool #aMd(object #Sb)
		{
			return !this.IsBusy && this.#hy();
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00010CC1 File Offset: 0x0000EEC1
		private void #bMd(object #Sb)
		{
			if (this.#aMd(#Sb))
			{
				if (!this.#OLd())
				{
					return;
				}
				this.#JMd();
			}
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00010CE7 File Offset: 0x0000EEE7
		private void #cMd()
		{
			base.View.#Fgc();
		}

		// Token: 0x06000DF9 RID: 3577
		protected abstract string #cy();

		// Token: 0x06000DFA RID: 3578
		protected abstract string #dy();

		// Token: 0x06000DFB RID: 3579 RVA: 0x000A0314 File Offset: 0x0009E514
		protected virtual void #aA(#62c #mA)
		{
			ReporterMainViewModelCore<TExplorer>.#RVd #RVd = new ReporterMainViewModelCore<!0>.#RVd();
			#RVd.#a = this;
			#L1c #L1c;
			#RVd.#c = this.FileSystemService.#11c(#mA, out #L1c);
			if (!\u0003.\u0005(#RVd.#c))
			{
				#RVd.#b = (#L1c as #pKd);
				if (#RVd.#b != null)
				{
					#RVd.#d = this.BusyMessage;
					this.BusyMessage = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringExporting.#B2d();
					this.#DMd(#RVd.#b.Format, new Action(#RVd.#QVd), true, false);
				}
			}
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x000A03C4 File Offset: 0x0009E5C4
		private void #dMd()
		{
			if (this.#gMd())
			{
				return;
			}
			ReportFileFormat reportFileFormat = this.ApplicationContext.Options.SelectedFileFormat;
			string #zK = this.#cy();
			string #VK = this.#dy();
			ReportFileFormat #ASd = reportFileFormat;
			ReportFileFormat[] array = new ReportFileFormat[2];
			array[0] = ReportFileFormat.Pdf;
			#62c #mA = #CSd.#ul(#zK, #VK, #ASd, array);
			this.#aA(#mA);
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x000A041C File Offset: 0x0009E61C
		private void #eMd()
		{
			if (this.#gMd())
			{
				return;
			}
			#62c #mA = #CSd.#ul(this.#cy(), this.#dy(), ReportFileFormat.Excel, new ReportFileFormat[]
			{
				ReportFileFormat.Excel
			});
			this.#aA(#mA);
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x000A0464 File Offset: 0x0009E664
		private void #fMd()
		{
			if (this.#gMd())
			{
				return;
			}
			#62c #mA = #CSd.#ul(this.#cy(), this.#dy(), ReportFileFormat.Csv, new ReportFileFormat[]
			{
				ReportFileFormat.Csv
			});
			this.#aA(#mA);
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x000A04AC File Offset: 0x0009E6AC
		private bool #gMd()
		{
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			if (!this.OptionsCore.#Gcd() || (#cA.#Lcd() && this.Reports.TextReport.IsEmpty) || (#cA.#OSd() && this.Reports.WordPdfReport.IsEmpty))
			{
				this.DialogService.#od(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringTheReportIsEmpty.#z2d(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringInformation, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
				return true;
			}
			return false;
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x000A0550 File Offset: 0x0009E750
		private void #hMd()
		{
			if (!this.ApplicationContext.ShowNoPreviewAvailableMessage && this.#gMd())
			{
				return;
			}
			#62c #mA = #CSd.#ul(this.#cy(), this.#dy(), ReportFileFormat.Text, new ReportFileFormat[]
			{
				ReportFileFormat.Text
			});
			this.#aA(#mA);
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x000A05A4 File Offset: 0x0009E7A4
		private void #v5c()
		{
			try
			{
				if (this.#hy())
				{
					switch (this.ApplicationContext.Options.SelectedFileFormat)
					{
					case ReportFileFormat.Word:
					case ReportFileFormat.Pdf:
						this.#dMd();
						break;
					case ReportFileFormat.Text:
						this.#hMd();
						break;
					case ReportFileFormat.Excel:
						this.#eMd();
						break;
					case ReportFileFormat.Csv:
						this.#fMd();
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x000A063C File Offset: 0x0009E83C
		private bool #iMd()
		{
			if (this.IsBusy || !this.#hy())
			{
				return false;
			}
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			this.Reports.#fRd(#cA);
			return this.Explorer.IsNavigationEnabled && (#cA.#Icd() || #cA.#Mcd() || !this.ApplicationContext.IsDirty);
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x000A06BC File Offset: 0x0009E8BC
		protected #jJd #jMd()
		{
			#jJd printOptions = this.OptionsPanelViewModel.View.GetPrintOptions();
			if (printOptions != null && printOptions.PageSelectionMode == PageSelectionMode.CurrentPage)
			{
				int num = this.#tMd();
				if (num > 0)
				{
					printOptions.Pages.Add(new #zId(num, num));
				}
			}
			if (printOptions != null)
			{
				printOptions.FontInfo = this.ReportFontSizeInfoProvider.#3hc(this.SettingsManager.ReportFontSize);
			}
			this.SettingsManager.#mUd(printOptions, #NTd.#a);
			this.SettingsManager.DefaultReportType = this.ApplicationContext.Options.SelectedFileFormat.#PSd();
			ReporterMainViewModelCore<!0>.#lMd(printOptions);
			return printOptions;
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x000A0774 File Offset: 0x0009E974
		protected bool #kMd()
		{
			try
			{
				#jJd #jJd = this.#jMd();
				if (#jJd != null)
				{
					return #jJd.PrinterStatus == #GId.#a;
				}
			}
			catch (Exception)
			{
				return false;
			}
			return false;
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x000A07C0 File Offset: 0x0009E9C0
		private static void #lMd(#jJd #mA)
		{
			if (#mA != null && #mA.PrinterStatus != #GId.#a)
			{
				#mA.AsposePaperSize = new PaperSize?(PaperSize.Letter);
				PageMarginsSpecification #wId = #tId.#mId();
				#mA.Margins.#mg(#wId);
				#mA.PageSelectionMode = PageSelectionMode.AllPages;
				#mA.Orientation = PaperOrientation.Portrait;
				#mA.PaperSize = null;
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x000A081C File Offset: 0x0009EA1C
		private bool #mMd(object #Sb)
		{
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			bool flag = this.Reports.#fRd(#cA);
			return !this.IsBusy && this.#hy() && (#cA.#OSd() || (#cA.#Lcd() && this.Reports.TextReport.DisplayContent != null)) && !this.ApplicationContext.IsDirty && flag && this.#kMd();
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x000A08B4 File Offset: 0x0009EAB4
		private bool #nMd()
		{
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			return !this.IsBusy && this.#hy() && (#cA.#OSd() || #cA.#Lcd());
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x000A0900 File Offset: 0x0009EB00
		private void #oMd(object #Sb)
		{
			try
			{
				ReporterMainViewModelCore<TExplorer>.#TVd #TVd = new ReporterMainViewModelCore<!0>.#TVd();
				if (!this.#gMd())
				{
					#jJd #jJd = this.#ey();
					if (#jJd != null)
					{
						if (#jJd.PrinterStatus != #GId.#a)
						{
							string #SSc = \u0080\u0006.\u0081\u0010(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringTheSelectedPrinterCannotBeUsedForPrinting.#z2d(), \u008E.\u0099\u0002(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPrinterState.#u2d(), #OId.#JId(#jJd.PrinterStatus));
							this.DialogService.#od(#SSc, MessageBoxButton.OK, MessageBoxImage.Hand);
						}
						else if (!#jJd.IsRealPrinterDevice)
						{
							this.DialogService.#od(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringNoPrinterInstalled.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand);
						}
						else
						{
							ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
							#TVd.#a = (#cA.#Lcd() ? this.Reports.TextReport.Document : this.Reports.WordPdfReport.Document);
							if (#jJd.InvalidPageSelection || #jJd.Pages.Any(new Func<IPageSelection, bool>(#TVd.#SVd)))
							{
								this.DialogService.#od(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringInvalidPageNumbersSpecified.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand);
							}
							else if (!#jJd.Pages.Any<IPageSelection>())
							{
								this.DialogService.#od(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringNoPagesSpecifiedToPrint.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand);
							}
							else
							{
								string #SSc = \u0080\u0006.\u0081\u0010(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringDoYouWantToPrintTheSelectedPages.#J2d(), \u008E.\u0099\u0002(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPages.#u2d(true), \u0003\u0005.\u0096\u000E(#Phc.#3hc(107376612), #jJd.Pages.Select(new Func<IPageSelection, string>(this.#qMd))));
								if (this.DialogService.#od(#SSc, StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringConfirm, MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel, MessageBoxOptions.None) == MessageBoxResult.OK)
								{
									this.#pMd(#cA, #jJd);
								}
							}
						}
					}
				}
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x000A0B10 File Offset: 0x0009ED10
		private void #pMd(ReportFileFormat #cA, #jJd #mA)
		{
			ReporterMainViewModelCore<TExplorer>.#acd #acd = new ReporterMainViewModelCore<!0>.#acd();
			#acd.#a = this;
			#acd.#b = #cA;
			#acd.#c = #mA;
			this.IsBusy = true;
			#acd.#d = this.BusyMessage;
			this.BusyMessage = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPrinting.#B2d();
			\u0082\u0006.~\u0083\u0010(\u0081\u0006.\u0082\u0010(), new Action(#acd.#UVd));
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x000A0B88 File Offset: 0x0009ED88
		private string #qMd(IPageSelection #rMd)
		{
			if (#rMd.Start != #rMd.End)
			{
				return \u0005\u0002.\u0005\u0004(\u0097\u0002.\u000E\u0006(), #Phc.#3hc(107278383), new object[]
				{
					#rMd.Start,
					#rMd.End
				});
			}
			return #rMd.Start.ToString(\u0097\u0002.\u000E\u0006());
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x000A0C08 File Offset: 0x0009EE08
		private void #sMd()
		{
			if (this.#nMd())
			{
				PrintOptionsSetup printOptionsSetup = new PrintOptionsSetup();
				ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
				printOptionsSetup.NumberOfLinesPerPage = this.SettingsManager.LinesPerPage;
				if (#cA.#OSd() && this.Reports.WordPdfReport.Builder != null)
				{
					Document document = this.Reports.WordPdfReport.Document;
					if (document != null)
					{
						printOptionsSetup.PagesCount = new int?(\u008D\u0002.~\u0095\u0005(document));
					}
				}
				else if (#cA.#Lcd() && this.Reports.TextReport.Builder != null)
				{
					printOptionsSetup.LinesPerPageMode = false;
					Document document2 = this.Reports.TextReport.Document;
					if (document2 != null)
					{
						printOptionsSetup.PagesCount = new int?(\u008D\u0002.~\u0095\u0005(document2));
					}
				}
				this.OptionsPanelViewModel.View.UpdatePrintOptions(printOptionsSetup);
				return;
			}
			this.OptionsPanelViewModel.View.UpdatePrintOptions(null);
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x000A0D1C File Offset: 0x0009EF1C
		private int #tMd()
		{
			ReporterMainViewModelCore<TExplorer>.#hXb #hXb = new ReporterMainViewModelCore<!0>.#hXb();
			#hXb.#b = this;
			if (this.ActivePdfViewer == null)
			{
				return -1;
			}
			#hXb.#a = -1;
			if (\u0083\u0006.~\u0084\u0010(LayoutHelper.BeginInvokeOnApplicationThread(new Action(#hXb.#WVd)), \u001C.\u0006\u0002(3.0)) != DispatcherOperationStatus.Completed)
			{
				return -1;
			}
			return #hXb.#a;
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00010D00 File Offset: 0x0000EF00
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00010D0C File Offset: 0x0000EF0C
		protected bool IsAutoRegenerationEnabled { get; set; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00010D1D File Offset: 0x0000EF1D
		public DelegateCommand CancelCommand { get; }

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x00010D29 File Offset: 0x0000EF29
		// (set) Token: 0x06000E11 RID: 3601 RVA: 0x00010D35 File Offset: 0x0000EF35
		public bool IsCancellable
		{
			get
			{
				return this.#C;
			}
			private set
			{
				if (this.#C != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107428667));
					this.#C = value;
					base.RaisePropertyChanged(#Phc.#3hc(107428667));
				}
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000E12 RID: 3602 RVA: 0x000A0D8C File Offset: 0x0009EF8C
		// (remove) Token: 0x06000E13 RID: 3603 RVA: 0x000A0DD4 File Offset: 0x0009EFD4
		public event EventHandler ReportGenerated
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#I;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#I, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#I;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#I, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x000A0E1C File Offset: 0x0009F01C
		protected void #AMd(Action #nd)
		{
			bool flag = this.IsAutoRegenerationEnabled;
			this.IsAutoRegenerationEnabled = false;
			try
			{
				\u0007.~\u007F(#nd);
			}
			finally
			{
				this.IsAutoRegenerationEnabled = flag;
			}
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x000A0E68 File Offset: 0x0009F068
		protected bool #1Pb(Action #nd, bool #BMd = false, Func<bool> #CMd = null)
		{
			try
			{
				#nd();
				return true;
			}
			catch (Exception ex)
			{
				if (#CMd == null || !#CMd())
				{
					if (#BMd)
					{
						if (ex is ThreadAbortException)
						{
							goto IL_5C;
						}
						if (#sYd.#pYd(ex).Any(new Func<Exception, bool>(ReporterMainViewModelCore<!0>.<>c.<>9.#XVd)))
						{
							goto IL_5C;
						}
					}
					this.#1Pb(ex);
					return false;
				}
				IL_5C:
				throw new OperationCanceledException();
			}
			return false;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x000A0EF4 File Offset: 0x0009F0F4
		protected virtual void #DMd(ReportFileFormat #cA, Action #yf, bool #EMd, bool #FMd)
		{
			ReporterMainViewModelCore<TExplorer>.#7Vd #7Vd = new ReporterMainViewModelCore<!0>.#7Vd();
			#7Vd.#a = this;
			#7Vd.#b = #cA;
			#7Vd.#c = #EMd;
			#7Vd.#d = #yf;
			#7Vd.#e = #FMd;
			if (this.Reports.#fRd(#7Vd.#b))
			{
				this.#1Pb(#7Vd.#d, false, null);
				return;
			}
			if (!#7Vd.#c)
			{
				this.BusyMessage = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringGeneratingReport.#B2d();
			}
			this.#MId();
			Ignore.#14d<Exception>(new Action(#7Vd.#YVd), null);
			this.#F = false;
			this.#1Pb(new Action(#7Vd.#ZVd), false, new Func<bool>(#7Vd.#6Vd));
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x000A0FC8 File Offset: 0x0009F1C8
		protected virtual void #GMd(ReportFileFormat #cA, bool #FMd, bool #EMd)
		{
			this.IsBusy = false;
			this.IsCancellable = false;
			this.Reports.#oRd(#cA);
			this.ApplicationContext.IsDirty = false;
			this.ApplicationContext.IsCurrentlyGeneratingReport = false;
			if (!#EMd)
			{
				this.ApplicationContext.#XRd(#cA);
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00010B82 File Offset: 0x0000ED82
		protected virtual bool #HMd(ReportFileFormat #IMd)
		{
			return #IMd.#OSd() || #IMd.#Lcd();
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x000A1024 File Offset: 0x0009F224
		protected virtual bool #MId()
		{
			#jJd #jJd = this.#ey();
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			if ((#cA.#OSd() || #cA.#Lcd()) && #jJd.PrinterStatus != #GId.#a)
			{
				this.ApplicationContext.IsDirty = true;
				string #SSc = \u0080\u0006.\u0081\u0010(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringTheSelectedPrinterCannotBeUsed.#z2d(), \u008E.\u0099\u0002(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPrinterState.#u2d(true), #OId.#JId(#jJd.PrinterStatus));
				this.DialogService.#od(#SSc, MessageBoxButton.OK, MessageBoxImage.Hand);
				return false;
			}
			return true;
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x000A10D4 File Offset: 0x0009F2D4
		protected virtual void #JMd()
		{
			if (this.IsBusy || !this.#hy())
			{
				this.#vh(false);
				return;
			}
			if (!this.#OLd())
			{
				return;
			}
			this.#ZLd();
			this.IsBusy = true;
			bool #FMd = this.ApplicationContext.IsDirty;
			this.ApplicationContext.IsDirty = false;
			this.ApplicationContext.Options.IsReportFileFormatChangeAllowed = true;
			this.Explorer.SplitLongTables = this.SettingsManager.ReporterSplitLongTables;
			try
			{
				this.#DMd(this.ApplicationContext.Options.SelectedFileFormat, new Action(this.#8Md), false, #FMd);
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00010D73 File Offset: 0x0000EF73
		protected virtual void #KMd()
		{
			this.#hLd(this.ActivePdfViewer);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x000A11B4 File Offset: 0x0009F3B4
		protected virtual void #hLd(RadPdfViewer #iLd)
		{
			if (\u0018\u0006.~\u0019\u0010(#iLd) == null)
			{
				return;
			}
			#wKd #wKd = null;
			if (base.View.WordAndPdfViewer == #iLd)
			{
				#wKd = this.#a;
			}
			else if (base.View.TextViewer == #iLd)
			{
				#wKd = this.#b;
			}
			if (#wKd == null)
			{
				return;
			}
			#wKd.Scale = \u001B\u0002.~\u0003\u0005(#iLd);
			#wKd.ScaleMode = \u0014\u0006.~\u0014\u0010(#iLd);
			\u0019\u0006.~\u001A\u0010(#iLd, null);
			\u001A\u0006.~\u001B\u0010(#iLd, null);
			this.#LMd(#iLd, #wKd);
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #LMd(RadPdfViewer #iLd, #wKd #ng)
		{
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00010D8D File Offset: 0x0000EF8D
		protected virtual void #MMd()
		{
			this.#hLd(base.View.WordAndPdfViewer);
			this.#hLd(base.View.TextViewer);
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000A1264 File Offset: 0x0009F464
		private void #kz(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#NMd();
			this.#vh(true);
			string text = ReflectionHelper.#M4c<ReportFileFormat>(System.Linq.Expressions.Expression.Lambda<Func<ReportFileFormat>>(\u0089\u0005.\u0081\u000F(\u0089\u0005.\u0081\u000F(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#FLd()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#rUd.#yy()).MethodHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#iSd.#gSd()).MethodHandle)), new ParameterExpression[0]));
			ReportFileFormat reportFileFormat = this.ApplicationContext.Options.SelectedFileFormat;
			if (!this.IsAutoRegenerationEnabled || \u0093.\u0015\u0003(\u007F.~\u001A\u0002(#He), text))
			{
				return;
			}
			this.SettingsManager.DefaultReportType = reportFileFormat.#PSd();
			if (this.ApplicationContext.IsDirty || this.ApplicationContext.CanceledFormats.Contains(reportFileFormat))
			{
				this.#RMd();
				return;
			}
			if (this.#HMd(reportFileFormat))
			{
				this.#DMd(reportFileFormat, new Action(this.#RMd), false, true);
				return;
			}
			this.#RMd();
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x000A13B8 File Offset: 0x0009F5B8
		private void #Hxb(object #Sb)
		{
			object obj = this.#E;
			bool flag = false;
			try
			{
				\u000E\u0004.\u008D\u0008(obj, ref flag);
				if (this.#D != null)
				{
					this.#F = true;
					Thread thread = this.#D;
					if (thread != null)
					{
						thread.Abort();
					}
				}
			}
			finally
			{
				if (flag)
				{
					\u0017.\u009E(obj);
				}
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Ixb(object #Sb)
		{
			return true;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x000A142C File Offset: 0x0009F62C
		private void #NMd()
		{
			ReportFileFormat #cA = this.ApplicationContext.Options.SelectedFileFormat;
			if (#cA.#OSd() || #cA.#Lcd())
			{
				this.ActivePdfViewer = (#cA.#OSd() ? base.View.WordAndPdfViewer : base.View.TextViewer);
			}
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x000A148C File Offset: 0x0009F68C
		private void #OMd()
		{
			if (this.Reports.ExcelReport.IsShown || !this.Reports.ExcelReport.IsValid)
			{
				return;
			}
			this.Reports.ExcelReport.IsShown = true;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#9Md));
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x000A14F0 File Offset: 0x0009F6F0
		private void #PMd()
		{
			if (this.Reports.TextReport.IsShown || !this.Reports.TextReport.IsValid)
			{
				this.ApplicationContext.ShowNoPreviewAvailableMessage = !this.Reports.TextReport.IsDisplayContentAvailable;
				return;
			}
			this.Reports.TextReport.IsShown = true;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#aNd));
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000A1570 File Offset: 0x0009F770
		private void #QMd()
		{
			if (this.Reports.WordPdfReport.IsShown || !this.Reports.WordPdfReport.IsValid)
			{
				return;
			}
			this.Reports.WordPdfReport.IsShown = true;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#bNd));
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000A15D4 File Offset: 0x0009F7D4
		private void #RMd()
		{
			this.ApplicationContext.ShowNoPreviewAvailableMessage = false;
			switch (this.ApplicationContext.Options.SelectedFileFormat)
			{
			case ReportFileFormat.Word:
			case ReportFileFormat.Pdf:
				this.#QMd();
				return;
			case ReportFileFormat.Text:
				this.#PMd();
				return;
			case ReportFileFormat.Excel:
				this.#OMd();
				return;
			case ReportFileFormat.Csv:
				return;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00010DBD File Offset: 0x0000EFBD
		private void #SMd()
		{
			this.DialogService.#RSc(base.View as Window);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00010DE1 File Offset: 0x0000EFE1
		protected virtual void #TMd()
		{
			EventHandler eventHandler = this.#I;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00010E05 File Offset: 0x0000F005
		[CompilerGenerated]
		private void #UMd()
		{
			this.#oMd(null);
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00010E16 File Offset: 0x0000F016
		[CompilerGenerated]
		private bool #VMd()
		{
			return this.#mMd(null);
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00010E27 File Offset: 0x0000F027
		[CompilerGenerated]
		private void #WMd()
		{
			this.ApplicationContext.Options.SelectedFileFormat = this.SettingsManager.DefaultReportType.#jSd();
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000A1644 File Offset: 0x0009F844
		[CompilerGenerated]
		private void #XMd()
		{
			#4Kd #4Kd = base.View;
			double width = #4Kd.Width;
			#4Kd.Width = width - 1.0;
			#4Kd #4Kd2 = base.View;
			width = #4Kd2.Width;
			#4Kd2.Width = width + 1.0;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00010E55 File Offset: 0x0000F055
		[CompilerGenerated]
		private void #YMd()
		{
			this.#k = false;
			if (this.#PLd())
			{
				this.#JMd();
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000A1698 File Offset: 0x0009F898
		[CompilerGenerated]
		private void #CBf()
		{
			try
			{
				this.#k = false;
				this.ApplicationContext.Options.IsReportFileFormatChangeAllowed = true;
				this.ApplicationContext.IsDirty = false;
				this.Reports.#9Qd();
				this.#vh(false);
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00010E7A File Offset: 0x0000F07A
		[CompilerGenerated]
		private void #ZMd()
		{
			this.#hLd(base.View.TextViewer);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00010E99 File Offset: 0x0000F099
		[CompilerGenerated]
		private void #0Md()
		{
			\u001A\u0006.~\u001B\u0010(base.View.TextViewer, null);
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00010EBD File Offset: 0x0000F0BD
		[CompilerGenerated]
		private void #1Md()
		{
			this.#hLd(base.View.WordAndPdfViewer);
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00010EDC File Offset: 0x0000F0DC
		[CompilerGenerated]
		private void #2Md()
		{
			\u001A\u0006.~\u001B\u0010(base.View.WordAndPdfViewer, null);
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00010F00 File Offset: 0x0000F100
		[CompilerGenerated]
		private void #3Md()
		{
			this.Reports.#9Qd();
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00010F19 File Offset: 0x0000F119
		[CompilerGenerated]
		private void #4Md(EventHandler<EventArgs> #5Md)
		{
			this.Explorer.SelectionChanged += #5Md;
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x00010F38 File Offset: 0x0000F138
		[CompilerGenerated]
		private void #6Md(EventHandler<EventArgs> #5Md)
		{
			this.Explorer.SelectionChanged -= #5Md;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00010F57 File Offset: 0x0000F157
		[CompilerGenerated]
		private void #7Md(IList<EventPattern<EventArgs>> #Lg)
		{
			if (#Lg.Any<EventPattern<EventArgs>>())
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#2Ld));
			}
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x000A1708 File Offset: 0x0009F908
		[CompilerGenerated]
		private void #8Md()
		{
			if (!this.#hy())
			{
				\u0019\u0006.~\u001A\u0010(base.View.WordAndPdfViewer, null);
				\u0019\u0006.~\u001A\u0010(base.View.TextViewer, null);
				this.ApplicationContext.Options.IsReportFileFormatChangeAllowed = false;
				this.Explorer.#7Nd();
			}
			else
			{
				this.#RMd();
			}
			this.#vh(true);
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x000A1788 File Offset: 0x0009F988
		[CompilerGenerated]
		private void #9Md()
		{
			try
			{
				if (this.Reports.ExcelReport.IsEmpty || this.Reports.ExcelReport.DisplayContent == null)
				{
					base.View.LoadSpreadsheet(null);
				}
				else
				{
					base.View.LoadSpreadsheet(this.Reports.ExcelReport.DisplayContent);
				}
			}
			catch (Exception #ob)
			{
				this.Reports.ExcelReport.IsShown = false;
				this.#1Pb(#ob);
			}
			finally
			{
				this.IsBusy = false;
				this.#SMd();
				this.#vh(true);
			}
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000A183C File Offset: 0x0009FA3C
		[CompilerGenerated]
		private void #aNd()
		{
			try
			{
				this.#hLd(base.View.TextViewer);
				if (this.Reports.TextReport.DisplayContent != null)
				{
					\u0019\u0006.~\u001A\u0010(base.View.TextViewer, new PdfDocumentSource(this.Reports.TextReport.DisplayContent));
				}
				this.ApplicationContext.ShowNoPreviewAvailableMessage = !this.Reports.TextReport.IsDisplayContentAvailable;
			}
			catch (Exception #ob)
			{
				this.Reports.TextReport.IsShown = false;
				this.#1Pb(#ob);
			}
			finally
			{
				this.IsBusy = false;
				this.#SMd();
				this.#vh(true);
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000A1914 File Offset: 0x0009FB14
		[CompilerGenerated]
		private void #bNd()
		{
			try
			{
				this.#hLd(base.View.WordAndPdfViewer);
				if (this.Reports.WordPdfReport.DisplayContent != null && !this.Reports.WordPdfReport.IsEmpty)
				{
					this.Reports.WordPdfReport.DisplayContent.#i2d();
					\u0019\u0006.~\u001A\u0010(base.View.WordAndPdfViewer, new PdfDocumentSource(this.Reports.WordPdfReport.DisplayContent, \u0084\u0006.\u0086\u0010()));
				}
			}
			catch (Exception #ob)
			{
				this.Reports.WordPdfReport.IsShown = false;
				this.#1Pb(#ob);
			}
			finally
			{
				this.IsBusy = false;
				this.#SMd();
				this.#vh(true);
			}
		}

		// Token: 0x04000530 RID: 1328
		private readonly #wKd #a = new #wKd();

		// Token: 0x04000531 RID: 1329
		private readonly #wKd #b = new #wKd();

		// Token: 0x04000532 RID: 1330
		private OutdatedModelDisplayMode #c;

		// Token: 0x04000533 RID: 1331
		private bool #d;

		// Token: 0x04000534 RID: 1332
		private IDisposable #e;

		// Token: 0x04000535 RID: 1333
		private bool #f;

		// Token: 0x04000536 RID: 1334
		private RadPdfViewer #g;

		// Token: 0x04000537 RID: 1335
		private string #h;

		// Token: 0x04000538 RID: 1336
		private string #i;

		// Token: 0x04000539 RID: 1337
		private IGenericLoaderWindow #j;

		// Token: 0x0400053A RID: 1338
		private volatile bool #k;

		// Token: 0x0400053B RID: 1339
		[CompilerGenerated]
		private EventHandler #l;

		// Token: 0x0400053C RID: 1340
		[CompilerGenerated]
		private Uri #m;

		// Token: 0x0400053D RID: 1341
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x0400053E RID: 1342
		[CompilerGenerated]
		private readonly string #o = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringResultsAreUnavailableOrOutdatedExecuteTheModelToViewTheResults;

		// Token: 0x0400053F RID: 1343
		[CompilerGenerated]
		private readonly #xPd #p;

		// Token: 0x04000540 RID: 1344
		[CompilerGenerated]
		private readonly #tUd #q;

		// Token: 0x04000541 RID: 1345
		[CompilerGenerated]
		private readonly #ATd #r;

		// Token: 0x04000542 RID: 1346
		[CompilerGenerated]
		private readonly #vUd #s;

		// Token: 0x04000543 RID: 1347
		[CompilerGenerated]
		private readonly #rUd #t;

		// Token: 0x04000544 RID: 1348
		[CompilerGenerated]
		private readonly DelegateCommand #u;

		// Token: 0x04000545 RID: 1349
		[CompilerGenerated]
		private readonly DelegateCommand #v;

		// Token: 0x04000546 RID: 1350
		[CompilerGenerated]
		private readonly IDelegateCommand #w;

		// Token: 0x04000547 RID: 1351
		[CompilerGenerated]
		private readonly #uUd #x;

		// Token: 0x04000548 RID: 1352
		[CompilerGenerated]
		private readonly #v2c #y;

		// Token: 0x04000549 RID: 1353
		[CompilerGenerated]
		private readonly #8Sc #z;

		// Token: 0x0400054A RID: 1354
		[CompilerGenerated]
		private readonly #wUd #A;

		// Token: 0x0400054B RID: 1355
		[CompilerGenerated]
		private readonly #uPd #B;

		// Token: 0x0400054C RID: 1356
		private bool #C;

		// Token: 0x0400054D RID: 1357
		private Thread #D;

		// Token: 0x0400054E RID: 1358
		private readonly object #E = new object();

		// Token: 0x0400054F RID: 1359
		private volatile bool #F;

		// Token: 0x04000550 RID: 1360
		[CompilerGenerated]
		private bool #G;

		// Token: 0x04000551 RID: 1361
		[CompilerGenerated]
		private readonly DelegateCommand #H;

		// Token: 0x04000552 RID: 1362
		[CompilerGenerated]
		private EventHandler #I;

		// Token: 0x020001A5 RID: 421
		[CompilerGenerated]
		private sealed class #Ybc
		{
			// Token: 0x06000E3F RID: 3647 RVA: 0x00010F9F File Offset: 0x0000F19F
			internal bool #LVd(#zSd #Rf)
			{
				return \u0093.\u0016\u0003(#Rf.Bookmark, this.#a.Options.DocumentOption.BookmarkName);
			}

			// Token: 0x04000555 RID: 1365
			public #rQd #a;
		}

		// Token: 0x020001A6 RID: 422
		[CompilerGenerated]
		private sealed class #EVd
		{
			// Token: 0x06000E41 RID: 3649 RVA: 0x000A1A0C File Offset: 0x0009FC0C
			internal void #NVd()
			{
				this.#a.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this.#a, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#HLd()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), new ParameterExpression[0]));
				this.#a.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this.#a, \u001E.\u000F\u0002(typeof(ReporterMainViewModelCore<!0>).TypeHandle)), (MethodInfo)\u001F\u0006.\u007F\u0010(methodof(ReporterMainViewModelCore<!0>.#LLd()).MethodHandle, typeof(ReporterMainViewModelCore<!0>).TypeHandle)), new ParameterExpression[0]));
				\u0007.~\u000F(this.#a.PrintCommand);
				this.#a.ReporterCommands.ExitCommand.InvalidateCanExecute();
				this.#a.ReporterCommands.ExportCommand.InvalidateCanExecute();
				this.#a.ReporterCommands.PrintCommand.InvalidateCanExecute();
				\u0007.~\u000F(this.#a.RebuildDocumentCommand);
				this.#a.OpenSettingsCommand.InvalidateCanExecute();
				if (this.#b)
				{
					this.#a.#sMd();
				}
			}

			// Token: 0x04000556 RID: 1366
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x04000557 RID: 1367
			public bool #b;
		}

		// Token: 0x020001A7 RID: 423
		[CompilerGenerated]
		private sealed class #l5b
		{
			// Token: 0x06000E43 RID: 3651 RVA: 0x000A1B74 File Offset: 0x0009FD74
			internal void #GVd()
			{
				try
				{
					if (this.#a.ActiveSettings.IsFirstDocumentChange)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009E\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
						this.#a.ActiveSettings.IsFirstDocumentChange = false;
					}
					else if (this.#a.ActiveSettings.ScaleMode == ScaleMode.Normal)
					{
						if (this.#a.ActiveSettings.Scale > 0.0)
						{
							\u009F\u0002.~\u0095\u0006(this.#b, this.#a.ActiveSettings.Scale);
						}
					}
					else if (this.#a.ActiveSettings.ScaleMode == ScaleMode.FitToWidth)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009F\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
					}
					else if (this.#a.ActiveSettings.ScaleMode == ScaleMode.FitToPage)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009E\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
					}
					this.#a.Explorer.#6Nd();
					this.#a.#vh(true);
					this.#a.#5Ld();
				}
				catch (Exception exception)
				{
					this.#a.Logger.Log(LoggingLevel.Error, exception);
				}
			}

			// Token: 0x04000558 RID: 1368
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x04000559 RID: 1369
			public RadPdfViewer #b;
		}

		// Token: 0x020001A8 RID: 424
		[CompilerGenerated]
		private sealed class #PVd
		{
			// Token: 0x06000E45 RID: 3653 RVA: 0x000A1D30 File Offset: 0x0009FF30
			internal void #OVd()
			{
				\u0007.~\u008B(this.#a.View.PageNumberUpDown);
				\u0007\u0007.~\u000E\u0011(this.#a.View.PageNumberUpDown, 0, 0);
				IInputElement inputElement = this.#b;
				if (inputElement == null)
				{
					return;
				}
				inputElement.Focus();
			}

			// Token: 0x0400055A RID: 1370
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x0400055B RID: 1371
			public IInputElement #b;
		}

		// Token: 0x020001A9 RID: 425
		[CompilerGenerated]
		private sealed class #RVd
		{
			// Token: 0x06000E47 RID: 3655 RVA: 0x000A1D90 File Offset: 0x0009FF90
			internal void #QVd()
			{
				if (this.#a.ApplicationContext.CanceledFormats.Contains(this.#b.Format) || !this.#a.Reports.#fRd(this.#b.Format))
				{
					return;
				}
				try
				{
					Stream stream = this.#a.FileSystemService.#T1c(this.#c);
					try
					{
						this.#a.Reports.#zl(this.#b.Format, stream);
					}
					finally
					{
						if (stream != null)
						{
							\u0007.~\u000E(stream);
						}
					}
				}
				finally
				{
					this.#a.BusyMessage = this.#d;
				}
				this.#a.#vh(true);
			}

			// Token: 0x0400055C RID: 1372
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x0400055D RID: 1373
			public #pKd #b;

			// Token: 0x0400055E RID: 1374
			public string #c;

			// Token: 0x0400055F RID: 1375
			public string #d;
		}

		// Token: 0x020001AA RID: 426
		[CompilerGenerated]
		private sealed class #TVd
		{
			// Token: 0x06000E49 RID: 3657 RVA: 0x00010FD2 File Offset: 0x0000F1D2
			internal bool #SVd(IPageSelection #oEd)
			{
				return #oEd.Start > #oEd.End || #oEd.Start < 1 || #oEd.End > \u008D\u0002.~\u0095\u0005(this.#a);
			}

			// Token: 0x04000560 RID: 1376
			public Document #a;
		}

		// Token: 0x020001AB RID: 427
		[CompilerGenerated]
		private sealed class #acd
		{
			// Token: 0x06000E4B RID: 3659 RVA: 0x000A1E7C File Offset: 0x000A007C
			internal void #UVd()
			{
				try
				{
					#uzc #uzc = new #uzc(\u0019.\u0002\u0002(#Phc.#3hc(107275814), this.#a.#dy()));
					this.#a.Reports.#SHd(this.#b, this.#c);
					#uzc.#szc(#Phc.#3hc(107275829));
				}
				catch (Exception #ob)
				{
					this.#a.#1Pb(#ob);
				}
				finally
				{
					Action action;
					if ((action = this.#e) == null)
					{
						action = (this.#e = new Action(this.#VVd));
					}
					LayoutHelper.BeginInvokeOnApplicationThread(action);
				}
			}

			// Token: 0x06000E4C RID: 3660 RVA: 0x00011011 File Offset: 0x0000F211
			internal void #VVd()
			{
				this.#a.IsBusy = false;
				this.#a.BusyMessage = this.#d;
			}

			// Token: 0x04000561 RID: 1377
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x04000562 RID: 1378
			public ReportFileFormat #b;

			// Token: 0x04000563 RID: 1379
			public #jJd #c;

			// Token: 0x04000564 RID: 1380
			public string #d;

			// Token: 0x04000565 RID: 1381
			public Action #e;
		}

		// Token: 0x020001AC RID: 428
		[CompilerGenerated]
		private sealed class #hXb
		{
			// Token: 0x06000E4E RID: 3662 RVA: 0x0001103C File Offset: 0x0000F23C
			internal void #WVd()
			{
				this.#a = \u008D\u0002.~\u0098\u0005(this.#b.ActivePdfViewer);
			}

			// Token: 0x04000566 RID: 1382
			public int #a;

			// Token: 0x04000567 RID: 1383
			public ReporterMainViewModelCore<#MVd> #b;
		}

		// Token: 0x020001AD RID: 429
		[CompilerGenerated]
		private sealed class #7Vd
		{
			// Token: 0x06000E50 RID: 3664 RVA: 0x00011065 File Offset: 0x0000F265
			internal void #YVd()
			{
				this.#a.Explorer.#4Nd();
			}

			// Token: 0x06000E51 RID: 3665 RVA: 0x000A1F38 File Offset: 0x000A0138
			internal void #ZVd()
			{
				this.#a.ApplicationContext.IsCurrentlyGeneratingReport = true;
				this.#a.IsBusy = true;
				this.#a.IsCancellable = true;
				this.#a.#ZLd();
				this.#a.#fy();
				ReporterMainViewModelCore<!0> reporterMainViewModelCore = this.#a;
				ThreadStart start;
				if ((start = this.#k) == null)
				{
					start = (this.#k = new ThreadStart(this.#0Vd));
				}
				reporterMainViewModelCore.#D = new Thread(start);
				\u0007.~\u008C(this.#a.#D);
			}

			// Token: 0x06000E52 RID: 3666 RVA: 0x000A1FE8 File Offset: 0x000A01E8
			internal void #0Vd()
			{
				try
				{
					ReporterMainViewModelCore<!0> reporterMainViewModelCore = this.#a;
					Action #nd;
					if ((#nd = this.#f) == null)
					{
						#nd = (this.#f = new Action(this.#1Vd));
					}
					bool #BMd = true;
					Func<bool> #CMd;
					if ((#CMd = this.#g) == null)
					{
						#CMd = (this.#g = new Func<bool>(this.#2Vd));
					}
					reporterMainViewModelCore.#1Pb(#nd, #BMd, #CMd);
					object #E = this.#a.#E;
					bool flag = false;
					try
					{
						\u000E\u0004.\u008D\u0008(#E, ref flag);
						this.#a.#D = null;
					}
					finally
					{
						if (flag)
						{
							\u0017.\u009E(#E);
						}
					}
					if (this.#a.#F)
					{
						throw new OperationCanceledException();
					}
					Action action;
					if ((action = this.#j) == null)
					{
						action = (this.#j = new Action(this.#3Vd));
					}
					LayoutHelper.BeginInvokeOnApplicationThread(action);
				}
				catch (OperationCanceledException)
				{
					this.#a.#GMd(this.#b, this.#e, this.#c);
				}
			}

			// Token: 0x06000E53 RID: 3667 RVA: 0x00011088 File Offset: 0x0000F288
			internal void #1Vd()
			{
				this.#a.Reports.#gRd(this.#b);
			}

			// Token: 0x06000E54 RID: 3668 RVA: 0x000110AC File Offset: 0x0000F2AC
			internal bool #2Vd()
			{
				return this.#a.#F;
			}

			// Token: 0x06000E55 RID: 3669 RVA: 0x000A2110 File Offset: 0x000A0310
			internal void #3Vd()
			{
				try
				{
					ReporterMainViewModelCore<!0> reporterMainViewModelCore = this.#a;
					Action #nd;
					if ((#nd = this.#h) == null)
					{
						#nd = (this.#h = new Action(this.#4Vd));
					}
					bool #BMd = false;
					Func<bool> #CMd;
					if ((#CMd = this.#i) == null)
					{
						#CMd = (this.#i = new Func<bool>(this.#5Vd));
					}
					reporterMainViewModelCore.#1Pb(#nd, #BMd, #CMd);
				}
				catch (OperationCanceledException)
				{
					this.#a.#GMd(this.#b, this.#e, this.#c);
				}
				catch (Exception exception)
				{
					this.#a.Logger.Log(LoggingLevel.Warning, exception);
				}
			}

			// Token: 0x06000E56 RID: 3670 RVA: 0x000A21C8 File Offset: 0x000A03C8
			internal void #4Vd()
			{
				this.#a.IsBusy = false;
				this.#a.IsCancellable = false;
				if (!this.#c)
				{
					this.#a.ApplicationContext.#ZRd(this.#b);
				}
				this.#a.ApplicationContext.IsDirty = false;
				this.#a.ApplicationContext.IsCurrentlyGeneratingReport = false;
				this.#a.ApplicationContext.AdditionalBusyIndicatorMessage = null;
				\u0007.~\u007F(this.#d);
				this.#a.#TMd();
			}

			// Token: 0x06000E57 RID: 3671 RVA: 0x000110AC File Offset: 0x0000F2AC
			internal bool #5Vd()
			{
				return this.#a.#F;
			}

			// Token: 0x06000E58 RID: 3672 RVA: 0x000110AC File Offset: 0x0000F2AC
			internal bool #6Vd()
			{
				return this.#a.#F;
			}

			// Token: 0x04000568 RID: 1384
			public ReporterMainViewModelCore<#MVd> #a;

			// Token: 0x04000569 RID: 1385
			public ReportFileFormat #b;

			// Token: 0x0400056A RID: 1386
			public bool #c;

			// Token: 0x0400056B RID: 1387
			public Action #d;

			// Token: 0x0400056C RID: 1388
			public bool #e;

			// Token: 0x0400056D RID: 1389
			public Action #f;

			// Token: 0x0400056E RID: 1390
			public Func<bool> #g;

			// Token: 0x0400056F RID: 1391
			public Action #h;

			// Token: 0x04000570 RID: 1392
			public Func<bool> #i;

			// Token: 0x04000571 RID: 1393
			public Action #j;

			// Token: 0x04000572 RID: 1394
			public ThreadStart #k;
		}
	}
}

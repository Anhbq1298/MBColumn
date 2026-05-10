using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using #5Kd;
using #7hc;
using #ezc;
using #qPd;
using #sUd;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels
{
	// Token: 0x020001C8 RID: 456
	public abstract class ResultsMainViewModelCore<TExplorer> : #CBc<#9Kd>, INotifyPropertyChanged, #RBc<#9Kd>, IViewModel, #rPd where TExplorer : ResultsExplorerViewModelBase
	{
		// Token: 0x06000FED RID: 4077 RVA: 0x000A5B90 File Offset: 0x000A3D90
		protected ResultsMainViewModelCore(#GBc dependencyResolver, #9Kd view, ILogger logger, #v2c fileSystemService, #wPd resultsSettingsWindowViewModel, #tUd exceptionHandler, #wUd reporterSettings, #uUd featuresDescriptor) : base(dependencyResolver, view, logger)
		{
			this.#j = fileSystemService;
			this.#k = resultsSettingsWindowViewModel;
			this.#l = exceptionHandler;
			this.#m = reporterSettings;
			this.#n = featuresDescriptor;
			this.ReporterSettings.PropertyChanged += this.#jz;
			this.#o = new DelegateCommand(new Action<object>(this.#mk), new Predicate<object>(this.#9Ld));
			this.#i = new DelegateCommand(new Action<object>(this.#6Ld));
			base.View.SetViewModel(this);
			base.View.MainContentElementSizeChanged += this.#hNd;
			base.View.Closing += this.#Dh;
			base.View.Loaded += this.#Ih;
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000FEE RID: 4078 RVA: 0x000A5C90 File Offset: 0x000A3E90
		// (remove) Token: 0x06000FEF RID: 4079 RVA: 0x000A5CD8 File Offset: 0x000A3ED8
		public event EventHandler OutdatedReportRebuildRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x0001255E File Offset: 0x0001075E
		// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x0001256A File Offset: 0x0001076A
		public Uri WindowIconUri { get; set; }

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x0001257B File Offset: 0x0001077B
		public DelegateCommand RebuildOutdatedReportCommand { get; }

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x00012587 File Offset: 0x00010787
		// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x00012593 File Offset: 0x00010793
		public OutdatedModelDisplayMode OutdatedModelDisplayMode
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107278437));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278437));
				}
			}
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x000125D1 File Offset: 0x000107D1
		public #v2c FileSystemService { get; }

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x000125DD File Offset: 0x000107DD
		public #wPd ResultsSettingsWindowViewModel { get; }

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x000125E9 File Offset: 0x000107E9
		public #tUd ExceptionHandler { get; }

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x000125F5 File Offset: 0x000107F5
		public #wUd ReporterSettings { get; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x00012601 File Offset: 0x00010801
		public #uUd FeaturesDescriptor { get; }

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x0001260D File Offset: 0x0001080D
		public DelegateCommand OpenSettingsCommand { get; }

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x00012619 File Offset: 0x00010819
		// (set) Token: 0x06000FFC RID: 4092 RVA: 0x00012625 File Offset: 0x00010825
		public bool ShowPleaseWaitProgramIsSolving
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278370));
				}
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x00012653 File Offset: 0x00010853
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x0001265F File Offset: 0x0001085F
		public string Title
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#a, value))
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408142));
				}
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06000FFF RID: 4095
		public abstract TExplorer Explorer { get; }

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x00012697 File Offset: 0x00010897
		// (set) Token: 0x06001001 RID: 4097 RVA: 0x000126A3 File Offset: 0x000108A3
		public bool IsContentPreserved { get; protected set; }

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x000126B4 File Offset: 0x000108B4
		public virtual string ResultsAreUnavailableOrOutdatedMessaage { get; }

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x000126C0 File Offset: 0x000108C0
		public virtual string RegenerateResultsMessage { get; }

		// Token: 0x06001004 RID: 4100 RVA: 0x000126CC File Offset: 0x000108CC
		public virtual void #RLd()
		{
			this.Explorer.#4Nd();
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x000A5D20 File Offset: 0x000A3F20
		public virtual void #od(IGenericLoaderWindow #by)
		{
			if (!this.#pA())
			{
				return;
			}
			if (#by != null)
			{
				this.#d = #by;
			}
			if (!this.#c)
			{
				this.Explorer.#5Nd();
				this.#8Ld();
				this.#c = true;
			}
			else
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#DBf));
			}
			this.#hz();
			this.#vh();
			this.#b = #by;
			base.View.BringToFront();
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x000126EA File Offset: 0x000108EA
		protected virtual void #vh()
		{
			\u0007.~\u000F(this.OpenSettingsCommand);
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x00012708 File Offset: 0x00010908
		protected virtual void #qA()
		{
			this.Explorer.#7Nd();
			this.#vh();
		}

		// Token: 0x06001008 RID: 4104
		protected abstract bool #pA();

		// Token: 0x06001009 RID: 4105
		protected abstract void #hz();

		// Token: 0x0600100A RID: 4106 RVA: 0x0001272C File Offset: 0x0001092C
		protected virtual void #3Ld()
		{
			EventHandler eventHandler = this.#g;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00012750 File Offset: 0x00010950
		private void #Ih(object #Ge, RoutedEventArgs #He)
		{
			IGenericLoaderWindow genericLoaderWindow = this.#d;
			if (genericLoaderWindow == null)
			{
				return;
			}
			genericLoaderWindow.#Fgc();
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x0001276A File Offset: 0x0001096A
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			this.Explorer.#ehd();
			this.Explorer.#4Nd();
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x000A5DA8 File Offset: 0x000A3FA8
		private void #jz(object #Ge, PropertyChangedEventArgs #He)
		{
			\u0093 u0016_u = \u0093.\u0016\u0003;
			string text = \u007F.~\u001A\u0002(#He);
			#wUd #Rf = this.ReporterSettings;
			ParameterExpression parameterExpression = \u0086\u0006.\u0087\u0010(\u001E.\u000F\u0002(typeof(#wUd).TypeHandle), #Phc.#3hc(107398878));
			if (u0016_u(text, #Rf.#h0d(System.Linq.Expressions.Expression.Lambda<Func<#wUd, ExplorerPosition>>(\u0089\u0005.\u0081\u000F(parameterExpression, (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#wUd.#YTd()).MethodHandle)), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				this.#8Ld();
			}
			\u0093 u0016_u2 = \u0093.\u0016\u0003;
			string text2 = \u007F.~\u001A\u0002(#He);
			#wUd #Rf2 = this.ReporterSettings;
			parameterExpression = \u0086\u0006.\u0087\u0010(\u001E.\u000F\u0002(typeof(#wUd).TypeHandle), #Phc.#3hc(107398878));
			if (!u0016_u2(text2, #Rf2.#h0d(System.Linq.Expressions.Expression.Lambda<Func<#wUd, Color>>(\u0089\u0005.\u0081\u000F(parameterExpression, (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#wUd.#4Td()).MethodHandle)), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				\u0093 u0016_u3 = \u0093.\u0016\u0003;
				string text3 = \u007F.~\u001A\u0002(#He);
				#wUd #Rf3 = this.ReporterSettings;
				parameterExpression = \u0086\u0006.\u0087\u0010(\u001E.\u000F\u0002(typeof(#wUd).TypeHandle), #Phc.#3hc(107398878));
				if (!u0016_u3(text3, #Rf3.#h0d(System.Linq.Expressions.Expression.Lambda<Func<#wUd, bool>>(\u0089\u0005.\u0081\u000F(parameterExpression, (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(#wUd.#sOd()).MethodHandle)), new ParameterExpression[]
				{
					parameterExpression
				}))))
				{
					return;
				}
			}
			this.Explorer.#XOd();
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x000A5F48 File Offset: 0x000A4148
		private void #hNd(object #Ge, SizeChangedEventArgs #He)
		{
			this.Explorer.#YOd(\u0095\u0005.~\u0092\u000F(#He).Width);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00012798 File Offset: 0x00010998
		private void #6Ld(object #Sb)
		{
			this.#3Ld();
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x000127A8 File Offset: 0x000109A8
		private void #8Ld()
		{
			base.View.ExplorerPosition = this.ReporterSettings.ResultsExplorerPosition;
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x000127CC File Offset: 0x000109CC
		private bool #9Ld(object #Sb)
		{
			return this.Explorer.IsNavigationEnabled;
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x000127EA File Offset: 0x000109EA
		private void #mk(object #Sb)
		{
			this.ResultsSettingsWindowViewModel.#jH(base.View);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x000A5F84 File Offset: 0x000A4184
		[CompilerGenerated]
		private void #DBf()
		{
			#9Kd #9Kd = base.View;
			double width = #9Kd.Width;
			#9Kd.Width = width - 1.0;
			#9Kd #9Kd2 = base.View;
			width = #9Kd2.Width;
			#9Kd2.Width = width + 1.0;
		}

		// Token: 0x0400063C RID: 1596
		private string #a;

		// Token: 0x0400063D RID: 1597
		private IGenericLoaderWindow #b;

		// Token: 0x0400063E RID: 1598
		private bool #c;

		// Token: 0x0400063F RID: 1599
		private IGenericLoaderWindow #d;

		// Token: 0x04000640 RID: 1600
		private bool #e;

		// Token: 0x04000641 RID: 1601
		private OutdatedModelDisplayMode #f;

		// Token: 0x04000642 RID: 1602
		[CompilerGenerated]
		private EventHandler #g;

		// Token: 0x04000643 RID: 1603
		[CompilerGenerated]
		private Uri #h;

		// Token: 0x04000644 RID: 1604
		[CompilerGenerated]
		private readonly DelegateCommand #i;

		// Token: 0x04000645 RID: 1605
		[CompilerGenerated]
		private readonly #v2c #j;

		// Token: 0x04000646 RID: 1606
		[CompilerGenerated]
		private readonly #wPd #k;

		// Token: 0x04000647 RID: 1607
		[CompilerGenerated]
		private readonly #tUd #l;

		// Token: 0x04000648 RID: 1608
		[CompilerGenerated]
		private readonly #wUd #m;

		// Token: 0x04000649 RID: 1609
		[CompilerGenerated]
		private readonly #uUd #n;

		// Token: 0x0400064A RID: 1610
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x0400064B RID: 1611
		[CompilerGenerated]
		private bool #p = true;

		// Token: 0x0400064C RID: 1612
		[CompilerGenerated]
		private readonly string #q = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringResultsAreUnavailableOrOutdatedExecuteTheModelToViewTheResults;

		// Token: 0x0400064D RID: 1613
		[CompilerGenerated]
		private readonly string #r = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringRegenerateTheResults;
	}
}

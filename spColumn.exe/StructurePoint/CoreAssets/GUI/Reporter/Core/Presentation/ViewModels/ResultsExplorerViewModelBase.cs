using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #mKd;
using #o1d;
using #sUd;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Utils;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels
{
	// Token: 0x020001C3 RID: 451
	public abstract class ResultsExplorerViewModelBase : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06000F8C RID: 3980 RVA: 0x000A4B94 File Offset: 0x000A2D94
		protected ResultsExplorerViewModelBase(#uUd featuresDescriptor, #wUd reporterSettings, #v2c fileSystemService, #tUd exceptionHandler)
		{
			if (fileSystemService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409390));
			}
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409281));
			}
			this.#a = featuresDescriptor;
			this.#n = reporterSettings;
			this.#o = fileSystemService;
			this.#p = exceptionHandler;
			this.#u = new DelegateCommand(new Action<object>(this.#jOd), new Predicate<object>(this.#iOd));
			this.#t = new DelegateCommand(new Action<object>(this.#hOd), new Predicate<object>(this.#gOd));
			this.#w = new DelegateCommand(new Action<object>(this.#7Od), new Predicate<object>(this.#6Od));
			this.#v = new DelegateCommand(new Action<object>(this.#5Od), new Predicate<object>(this.#4Od));
			this.#z = new DelegateCommand(new Action<object>(this.#3Od), new Predicate<object>(this.#2Od));
			this.#q = new DelegateCommand(new Action<object>(this.#v5c), new Predicate<object>(this.#dA));
			this.CurrentAvailableWidth = 500.0;
			this.#e = 1;
			this.#B = new List<ResultsContentOption>();
			this.#r = new RadObservableCollection<ResultsContentOption>();
			this.#x = new RadObservableCollection<ResultsContentOption>();
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x00012048 File Offset: 0x00010248
		// (set) Token: 0x06000F8E RID: 3982 RVA: 0x00012054 File Offset: 0x00010254
		public bool TreeViewShouldExpandCollapseOnDoubleClick { get; set; }

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x00012065 File Offset: 0x00010265
		public #wUd SettingsManager { get; }

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x00012071 File Offset: 0x00010271
		public #v2c FileSystemService { get; }

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0001207D File Offset: 0x0001027D
		public #tUd ExceptionHandler { get; }

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x00012089 File Offset: 0x00010289
		public DelegateCommand ExportCommand { get; }

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x00012095 File Offset: 0x00010295
		public RadObservableCollection<ResultsContentOption> NonHeaderOptions { get; }

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06000F94 RID: 3988
		public abstract bool HideInactiveItems { get; }

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x000120A1 File Offset: 0x000102A1
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x000A4D2C File Offset: 0x000A2F2C
		public bool IsBusy
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107413161));
					this.#j = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107413161));
				}
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x000120AD File Offset: 0x000102AD
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x000A4D7C File Offset: 0x000A2F7C
		public TimeSpan ShowBusyMessageAfter
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (\u008B\u0006.\u008C\u0010(this.#l, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107277956));
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277956));
				}
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x000120B9 File Offset: 0x000102B9
		// (set) Token: 0x06000F9A RID: 3994 RVA: 0x000A4DD0 File Offset: 0x000A2FD0
		public string BusyMessage
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#k, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381157));
					this.#k = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381157));
				}
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x000120C5 File Offset: 0x000102C5
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x000A4E24 File Offset: 0x000A3024
		public string TableTitle
		{
			get
			{
				return this.#s;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#s, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107277927));
					this.#s = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277927));
				}
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x000120D1 File Offset: 0x000102D1
		// (set) Token: 0x06000F9E RID: 3998 RVA: 0x000A4E78 File Offset: 0x000A3078
		public ResultsContentOption ShownContentOption
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					string text;
					if (value == null)
					{
						text = null;
					}
					else
					{
						#XKd #XKd = value.Renderer;
						text = ((#XKd != null) ? #XKd.Title : null);
					}
					this.TableTitle = text;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107277942));
				}
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x000120DD File Offset: 0x000102DD
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x000120E9 File Offset: 0x000102E9
		public int NavigationMin
		{
			get
			{
				return this.#e;
			}
			private set
			{
				if (this.#e != value)
				{
					this.#e = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107277917));
				}
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0001211D File Offset: 0x0001031D
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x0001213B File Offset: 0x0001033B
		public int NavigationMax
		{
			get
			{
				if (!this.IsNavigationEnabled)
				{
					return 0;
				}
				return this.#f;
			}
			private set
			{
				if (this.#f != value)
				{
					this.#f = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107277864));
				}
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x0001216F File Offset: 0x0001036F
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x000A4ED8 File Offset: 0x000A30D8
		public int NavigationCurrent
		{
			get
			{
				if (!this.IsNavigationEnabled)
				{
					return 1;
				}
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					ResultsContentOption resultsContentOption = this.NavigationIndex.ElementAtOrDefault(value - 1);
					if (resultsContentOption != null)
					{
						this.SelectedOption = resultsContentOption;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107277875));
				}
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x0001218D File Offset: 0x0001038D
		public DelegateCommand CollapseTreeCommandCommand { get; }

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x00012199 File Offset: 0x00010399
		public DelegateCommand ExpandTreeCommandCommand { get; }

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x000121A5 File Offset: 0x000103A5
		public DelegateCommand NavigateForwardCommand { get; }

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x000121B1 File Offset: 0x000103B1
		public DelegateCommand NavigateBackwardCommand { get; }

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x000121BD File Offset: 0x000103BD
		public RadObservableCollection<ResultsContentOption> Items { get; }

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06000FAA RID: 4010 RVA: 0x000121C9 File Offset: 0x000103C9
		// (set) Token: 0x06000FAB RID: 4011 RVA: 0x000121D5 File Offset: 0x000103D5
		public bool IsRendererSelected
		{
			get
			{
				return this.#y;
			}
			set
			{
				if (this.#y != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107277850));
					this.#y = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277850));
				}
			}
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06000FAC RID: 4012 RVA: 0x00012213 File Offset: 0x00010413
		// (set) Token: 0x06000FAD RID: 4013 RVA: 0x000A4F2C File Offset: 0x000A312C
		public #XKd SelectedRenderer
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					this.IsRendererSelected = (((value != null) ? value.View : null) != null);
					base.RaisePropertyChanged(#Phc.#3hc(107278305));
				}
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06000FAE RID: 4014 RVA: 0x0001221F File Offset: 0x0001041F
		// (set) Token: 0x06000FAF RID: 4015 RVA: 0x0001224D File Offset: 0x0001044D
		public ResultsContentOption SelectedOption
		{
			get
			{
				if (!this.NavigationIndex.Contains(this.#b))
				{
					return this.DefaultOption;
				}
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					this.#7z(value, false);
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107278659));
				}
			}
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06000FB0 RID: 4016 RVA: 0x00012289 File Offset: 0x00010489
		// (set) Token: 0x06000FB1 RID: 4017 RVA: 0x000A4F7C File Offset: 0x000A317C
		public bool IsNavigationEnabled
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged<int>(Expression.Lambda<Func<int>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#HOd()).MethodHandle)), new ParameterExpression[0]));
					base.RaisePropertyChanged<int>(Expression.Lambda<Func<int>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#JOd()).MethodHandle)), new ParameterExpression[0]));
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107278638));
				}
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00012295 File Offset: 0x00010495
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x000A5064 File Offset: 0x000A3264
		public bool AutoAdjustColumnWidth
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					this.#i = value;
					if (value)
					{
						this.#YOd(this.CurrentAvailableWidth);
					}
					else
					{
						this.#9Nd(new Action<ResultsContentOption>(ResultsExplorerViewModelBase.<>c.<>9.#dWd));
					}
					base.RaisePropertyChanged(#Phc.#3hc(107278280));
				}
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x000122A1 File Offset: 0x000104A1
		public DelegateCommand ApplyMaxWidthCommand { get; }

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x000122AD File Offset: 0x000104AD
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x000122B9 File Offset: 0x000104B9
		public bool IsLoadingExplorerConfiguration { get; private set; }

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x000122CA File Offset: 0x000104CA
		protected List<ResultsContentOption> NavigationIndex { get; }

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x000122D6 File Offset: 0x000104D6
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x000122E2 File Offset: 0x000104E2
		protected double CurrentAvailableWidth { get; set; }

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06000FBA RID: 4026
		protected abstract ResultsContentOption DefaultOption { get; }

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06000FBB RID: 4027 RVA: 0x000122F3 File Offset: 0x000104F3
		public virtual object BottomContent { get; }

		// Token: 0x06000FBC RID: 4028 RVA: 0x000A50D4 File Offset: 0x000A32D4
		public void #4Nd()
		{
			if (!this.#a.SupportsKeepReporterConfiguration)
			{
				return;
			}
			try
			{
				if (this.SettingsManager.KeepResultsExplorerConfiguration)
				{
					this.SettingsManager.ResultsExplorerConfiguration = ExplorerConfigurationHelper.#RLd(this.Items.OfType<ReportContentVisibilityOption>().ToArray<ReportContentVisibilityOption>());
				}
			}
			catch (Exception #ob)
			{
				this.ExceptionHandler.#3Ab(Localization.StringCouldNotSaveExplorerConfiguration.#z2d(), #ob);
			}
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x000A5154 File Offset: 0x000A3354
		public void #5Nd()
		{
			if (!this.#a.SupportsKeepReporterConfiguration)
			{
				return;
			}
			try
			{
				if (this.SettingsManager.KeepResultsExplorerConfiguration)
				{
					this.IsLoadingExplorerConfiguration = true;
					ExplorerConfigurationHelper.#APd(this.SettingsManager.ResultsExplorerConfiguration, this.Items.OfType<ReportContentVisibilityOption>().ToArray<ReportContentVisibilityOption>());
				}
			}
			catch (Exception #ob)
			{
				this.ExceptionHandler.#3Ab(Localization.StringCouldNotLoadExplorerConfiguration.#z2d(), #ob);
			}
			finally
			{
				this.IsLoadingExplorerConfiguration = false;
			}
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x000122FF File Offset: 0x000104FF
		public virtual void #XOd()
		{
			this.#9Nd(new Action<ResultsContentOption>(ResultsExplorerViewModelBase.<>c.<>9.#eWd));
			this.#7z(this.SelectedOption, true);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x000A51F8 File Offset: 0x000A33F8
		public virtual void #7Nd()
		{
			this.IsNavigationEnabled = false;
			base.RaisePropertyChanged<int>(Expression.Lambda<Func<int>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#HOd()).MethodHandle)), new ParameterExpression[0]));
			base.RaisePropertyChanged<int>(Expression.Lambda<Func<int>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#JOd()).MethodHandle)), new ParameterExpression[0]));
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x000A52BC File Offset: 0x000A34BC
		public virtual void #YOd(double #6dd)
		{
			ResultsExplorerViewModelBase.#iWd #iWd = new ResultsExplorerViewModelBase.#iWd();
			#iWd.#a = this;
			#iWd.#b = #6dd;
			this.CurrentAvailableWidth = #iWd.#b;
			if (#iWd.#b <= 0.0 || !this.AutoAdjustColumnWidth)
			{
				return;
			}
			this.#9Nd(new Action<ResultsContentOption>(#iWd.#hWd));
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #dA(object #Vg)
		{
			return false;
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x000A5324 File Offset: 0x000A3524
		protected virtual string #ZOd(ResultsContentOption #bA)
		{
			string text = this.#9z();
			if (this.SelectedOption == null)
			{
				if (!\u0003.\u0004(text))
				{
					return text;
				}
				return #Phc.#3hc(107278251);
			}
			else
			{
				string text2 = this.FileSystemService.#M1c(this.SelectedOption.Renderer.Title, #Phc.#3hc(107381628));
				if (\u0003.\u0004(text))
				{
					return \u0010.\u0092(#Phc.#3hc(107278266), text2, #Phc.#3hc(107278217));
				}
				string text3 = \u009D.\u0099\u0003(text);
				string text4 = \u009D.\u009B\u0003(text);
				string text5 = \u009D.\u009C\u0003(text);
				text4 = \u0080\u0006.\u0081\u0010(text4, #Phc.#3hc(107382888), text2, text5);
				if (\u0003.\u0004(text3))
				{
					return text4;
				}
				return \u008F.\u0010\u0003(new string[]
				{
					text3,
					text4
				});
			}
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0001233F File Offset: 0x0001053F
		protected virtual string #9z()
		{
			return null;
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #aA(ResultsContentOption #bA, ReportFileFormat #cA, string #So)
		{
		}

		// Token: 0x06000FC5 RID: 4037
		protected abstract void #7z(ResultsContentOption #f, bool #nz = false);

		// Token: 0x06000FC6 RID: 4038 RVA: 0x000A5430 File Offset: 0x000A3630
		protected virtual void #vh()
		{
			\u0007.~\u000F(this.ExportCommand);
			\u0007.~\u000F(this.CollapseTreeCommandCommand);
			\u0007.~\u000F(this.ExpandTreeCommandCommand);
			\u0007.~\u000F(this.NavigateForwardCommand);
			\u0007.~\u000F(this.NavigateBackwardCommand);
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x000A549C File Offset: 0x000A369C
		protected void #9Nd(Action<ResultsContentOption> #nd)
		{
			Stack<ResultsContentOption> stack = new Stack<ResultsContentOption>();
			this.Items.#I1d(new Action<ResultsContentOption>(stack.Push));
			while (stack.Count > 0)
			{
				ResultsContentOption resultsContentOption = stack.Pop();
				#nd(resultsContentOption);
				resultsContentOption.Children.OfType<ResultsContentOption>().#I1d(new Action<ResultsContentOption>(stack.Push));
			}
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x000A5508 File Offset: 0x000A3708
		protected void #0Od()
		{
			this.NavigationIndex.Clear();
			if (this.#b == null)
			{
				this.#b = this.DefaultOption;
				base.RaisePropertyChanged<ResultsContentOption>(Expression.Lambda<Func<ResultsContentOption>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#YNd()).MethodHandle)), new ParameterExpression[0]));
			}
			#hZd.#mbb<ResultsContentOption>(this.Items, new Func<ResultsContentOption, IEnumerable<ResultsContentOption>>(ResultsExplorerViewModelBase.<>c.<>9.#fWd), new Action<ResultsContentOption>(this.#8Od));
			int num = this.NavigationIndex.IndexOf(this.SelectedOption ?? this.DefaultOption);
			num = ((num < 0) ? 0 : num);
			this.NavigationMin = 1;
			this.NavigationMax = this.NavigationIndex.Count;
			this.NavigationCurrent = num + 1;
			this.#7z(this.SelectedOption, false);
			this.ShownContentOption = this.SelectedOption;
			base.RaisePropertyChanged(#Phc.#3hc(107278659));
			this.#vh();
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x000A5648 File Offset: 0x000A3848
		protected void #1Od(ResultsContentOption #f)
		{
			int num = this.NavigationIndex.IndexOf(#f);
			if (num >= 0)
			{
				this.NavigationCurrent = num + 1;
				base.RaisePropertyChanged<int>(Expression.Lambda<Func<int>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ResultsExplorerViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ResultsExplorerViewModelBase.#JOd()).MethodHandle)), new ParameterExpression[0]));
				this.#vh();
			}
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x000A56CC File Offset: 0x000A38CC
		protected virtual void #aOd(bool #bOd)
		{
			ResultsExplorerViewModelBase.#jWd #jWd = new ResultsExplorerViewModelBase.#jWd();
			ResultsExplorerViewModelBase.#jWd #jWd2;
			if (!false)
			{
				#jWd2 = #jWd;
			}
			#jWd2.#a = this;
			#jWd2.#b = #bOd;
			LayoutHelper.DelayOperation(0.1, new Action(#jWd2.#bWd));
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00012342 File Offset: 0x00010542
		public void #ehd()
		{
			this.#9Nd(new Action<ResultsContentOption>(ResultsExplorerViewModelBase.<>c.<>9.#gWd));
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x000A5718 File Offset: 0x000A3918
		private void #v5c(object #Vg)
		{
			if (!this.#dA(null))
			{
				return;
			}
			try
			{
				ResultsContentOption #bA = this.ShownContentOption;
				List<#L1c> list = new List<#L1c>();
				list.Add(new #pKd(Localization.StringCommaSeparatedCSV, #Phc.#3hc(107408483), ReportFileFormat.Csv));
				list.Add(new #pKd(#Phc.#3hc(107278208), #Phc.#3hc(107413479), ReportFileFormat.Text));
				list.Add(new #pKd(Localization.StringExcelXLSX, #Phc.#3hc(107350248), ReportFileFormat.Excel));
				string text = this.#ZOd(#bA);
				#62c #21c = new #62c(list, #Phc.#3hc(107413479), (text != null) ? \u009D.\u0099\u0003(text) : \u001E\u0006.\u001F\u0010(Environment.SpecialFolder.Personal))
				{
					InitialFileName = ((!\u0003.\u0004(text)) ? \u009D.\u009A\u0003(\u0019.\u0003\u0002(text, #Phc.#3hc(107413479))) : null),
					FilterIndex = 1
				};
				#L1c #L1c;
				string text2 = this.FileSystemService.#11c(#21c, out #L1c);
				#pKd #pKd = #L1c as #pKd;
				if (!\u0003.\u0004(text2) && #pKd != null)
				{
					this.#aA(#bA, #pKd.Format, text2);
				}
			}
			catch (Exception #ob)
			{
				this.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x00003375 File Offset: 0x00001575
		private bool #2Od(object #Sb)
		{
			return true;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x000A5888 File Offset: 0x000A3A88
		private void #3Od(object #Sb)
		{
			this.AutoAdjustColumnWidth = false;
			#XKd #XKd = this.SelectedRenderer;
			if (#XKd != null)
			{
				#XKd.#hhd();
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x00012371 File Offset: 0x00010571
		private bool #4Od(object #Sb)
		{
			return this.NavigationCurrent + 1 <= this.NavigationMax;
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x000A58B8 File Offset: 0x000A3AB8
		private void #5Od(object #Sb)
		{
			int num = this.NavigationCurrent;
			this.NavigationCurrent = num + 1;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x00012392 File Offset: 0x00010592
		private bool #6Od(object #Sb)
		{
			return this.NavigationCurrent - 1 >= this.NavigationMin;
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x000A58E4 File Offset: 0x000A3AE4
		private void #7Od(object #Sb)
		{
			int num = this.NavigationCurrent;
			this.NavigationCurrent = num - 1;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x000123B3 File Offset: 0x000105B3
		private bool #gOd(object #Sb)
		{
			return this.IsNavigationEnabled;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000123C3 File Offset: 0x000105C3
		private void #hOd(object #Sb)
		{
			this.#aOd(false);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x000123B3 File Offset: 0x000105B3
		private bool #iOd(object #Sb)
		{
			return this.IsNavigationEnabled;
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x000123D4 File Offset: 0x000105D4
		private void #jOd(object #Sb)
		{
			this.#aOd(true);
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x000123E5 File Offset: 0x000105E5
		[CompilerGenerated]
		private void #8Od(ResultsContentOption #uXb)
		{
			if (#uXb.IsEnabled && !#uXb.IsHeader)
			{
				this.NavigationIndex.Add(#uXb);
			}
		}

		// Token: 0x0400060E RID: 1550
		private readonly #uUd #a;

		// Token: 0x0400060F RID: 1551
		private ResultsContentOption #b;

		// Token: 0x04000610 RID: 1552
		private #XKd #c;

		// Token: 0x04000611 RID: 1553
		private bool #d = true;

		// Token: 0x04000612 RID: 1554
		private int #e;

		// Token: 0x04000613 RID: 1555
		private int #f;

		// Token: 0x04000614 RID: 1556
		private int #g;

		// Token: 0x04000615 RID: 1557
		private ResultsContentOption #h;

		// Token: 0x04000616 RID: 1558
		private bool #i;

		// Token: 0x04000617 RID: 1559
		private bool #j;

		// Token: 0x04000618 RID: 1560
		private string #k = #Phc.#3hc(107278005).#B2d();

		// Token: 0x04000619 RID: 1561
		private TimeSpan #l = TimeSpan.FromSeconds(0.5);

		// Token: 0x0400061A RID: 1562
		[CompilerGenerated]
		private bool #m = true;

		// Token: 0x0400061B RID: 1563
		[CompilerGenerated]
		private readonly #wUd #n;

		// Token: 0x0400061C RID: 1564
		[CompilerGenerated]
		private readonly #v2c #o;

		// Token: 0x0400061D RID: 1565
		[CompilerGenerated]
		private readonly #tUd #p;

		// Token: 0x0400061E RID: 1566
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x0400061F RID: 1567
		[CompilerGenerated]
		private readonly RadObservableCollection<ResultsContentOption> #r;

		// Token: 0x04000620 RID: 1568
		private string #s;

		// Token: 0x04000621 RID: 1569
		[CompilerGenerated]
		private readonly DelegateCommand #t;

		// Token: 0x04000622 RID: 1570
		[CompilerGenerated]
		private readonly DelegateCommand #u;

		// Token: 0x04000623 RID: 1571
		[CompilerGenerated]
		private readonly DelegateCommand #v;

		// Token: 0x04000624 RID: 1572
		[CompilerGenerated]
		private readonly DelegateCommand #w;

		// Token: 0x04000625 RID: 1573
		[CompilerGenerated]
		private readonly RadObservableCollection<ResultsContentOption> #x;

		// Token: 0x04000626 RID: 1574
		private bool #y;

		// Token: 0x04000627 RID: 1575
		[CompilerGenerated]
		private readonly DelegateCommand #z;

		// Token: 0x04000628 RID: 1576
		[CompilerGenerated]
		private bool #A;

		// Token: 0x04000629 RID: 1577
		[CompilerGenerated]
		private readonly List<ResultsContentOption> #B;

		// Token: 0x0400062A RID: 1578
		[CompilerGenerated]
		private double #C;

		// Token: 0x0400062B RID: 1579
		[CompilerGenerated]
		private readonly object #D;

		// Token: 0x020001C5 RID: 453
		[CompilerGenerated]
		private sealed class #iWd
		{
			// Token: 0x06000FDF RID: 4063 RVA: 0x0001248F File Offset: 0x0001068F
			internal void #hWd(ResultsContentOption #Rf)
			{
				if (#Rf.Renderer != null && #Rf.Renderer == this.#a.SelectedRenderer)
				{
					#Rf.Renderer.#ihd(this.#b);
				}
			}

			// Token: 0x04000631 RID: 1585
			public ResultsExplorerViewModelBase #a;

			// Token: 0x04000632 RID: 1586
			public double #b;
		}

		// Token: 0x020001C6 RID: 454
		[CompilerGenerated]
		private sealed class #jWd
		{
			// Token: 0x06000FE1 RID: 4065 RVA: 0x000A5910 File Offset: 0x000A3B10
			internal void #bWd()
			{
				ResultsExplorerViewModelBase resultsExplorerViewModelBase = this.#a;
				Action<ResultsContentOption> #nd;
				if ((#nd = this.#c) == null)
				{
					#nd = (this.#c = new Action<ResultsContentOption>(this.#cWd));
				}
				resultsExplorerViewModelBase.#9Nd(#nd);
			}

			// Token: 0x06000FE2 RID: 4066 RVA: 0x000124C9 File Offset: 0x000106C9
			internal void #cWd(ResultsContentOption #Rf)
			{
				if (#Rf.Children.Any<ReportContentVisibilityOption>())
				{
					#Rf.IsExpanded = this.#b;
				}
			}

			// Token: 0x04000633 RID: 1587
			public ResultsExplorerViewModelBase #a;

			// Token: 0x04000634 RID: 1588
			public bool #b;

			// Token: 0x04000635 RID: 1589
			public Action<ResultsContentOption> #c;
		}
	}
}

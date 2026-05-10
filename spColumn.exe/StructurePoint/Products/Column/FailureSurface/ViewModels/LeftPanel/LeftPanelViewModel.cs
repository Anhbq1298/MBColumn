using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using #3Qb;
using #3ve;
using #5Fd;
using #6re;
using #7hc;
using #8xe;
using #Djb;
using #FCd;
using #ipb;
using #kB;
using #lH;
using #Mbb;
using #nib;
using #Oze;
using #qPb;
using #qpb;
using #S9;
using #sUd;
using #Ted;
using #v1c;
using #Wse;
using #Zjb;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Utils;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.FailureSurface.ViewModels.DTO;
using StructurePoint.Products.Column.FailureSurface.ViewModels.Filtering;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel
{
	// Token: 0x02000417 RID: 1047
	internal sealed class LeftPanelViewModel : #HH<ILeftPanelView>, INotifyPropertyChanged, IViewModel<ILeftPanelView>, IViewModel, #mib
	{
		// Token: 0x0600257F RID: 9599 RVA: 0x000D3448 File Offset: 0x000D1648
		public LeftPanelViewModel(Lazy<ILeftPanelView> view, ICoreServices coreServices, #tUd exceptionHandler, #Xgb filterOptionsViewModel, #tbb context, #mAe superImposeContext, #sib superImposeViewModel, #lB reporterDataProvider) : base(view, coreServices)
		{
			this.#a = exceptionHandler;
			this.#b = filterOptionsViewModel;
			this.#c = context;
			this.#d = reporterDataProvider;
			this.#0 = superImposeContext;
			this.#1 = superImposeViewModel;
			this.#Q = new DelegateCommand(new Action<object>(this.#1ib), new Predicate<object>(this.#0ib));
			this.#R = new DelegateCommand(new Action<object>(this.#Zib), new Predicate<object>(this.#Yib));
			this.#S = new DelegateCommand(new Action<object>(this.#Xib), new Predicate<object>(this.#Wib));
			this.#T = new DelegateCommand(new Action<object>(this.#Vib), new Predicate<object>(this.#Uib));
			this.#Y = new DelegateCommand(new Action<object>(this.#Tib), new Predicate<object>(this.#Sib));
			this.#U = new DelegateCommand(new Action<object>(this.#Lib), new Predicate<object>(this.#Kib));
			this.#Z = new DelegateCommand(new Action<object>(this.#Eib), new Predicate<object>(this.#Dib));
			if (coreServices.Settings.RuntimeSettings.IsCommandlineMode)
			{
				return;
			}
			#mpb #mpb = new #mpb();
			this.#X = this.#Fib(#Phc.#3hc(107361790), #mpb.SummarySpecialTable, Visibility.Collapsed);
			this.SummaryTable.IsExpanded = false;
			this.#Jib(#mpb);
			this.#Iib();
			this.#e.#pR(new PropertiesTableItemViewModel[]
			{
				this.SummaryTable,
				this.NavigationTable
			});
			SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 237, 237, 241));
			SolidColorBrush solidColorBrush2 = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 227, 228, 230));
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#e)
			{
				propertiesTableItemViewModel.Renderer.RadGridView.SelectionMode = SelectionMode.Single;
				propertiesTableItemViewModel.Renderer.RadGridView.CanUserSelect = false;
				propertiesTableItemViewModel.Renderer.GridRenderer.HeaderBackgroundBrush = solidColorBrush;
				propertiesTableItemViewModel.Renderer.RadGridView.BorderBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.HorizontalGridLinesBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.VerticalGridLinesBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.GridRenderer.HeaderBorderBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.BorderThickness = default(Thickness);
				propertiesTableItemViewModel.Renderer.GridRenderer.Margin = 40.0;
				if (propertiesTableItemViewModel != this.NavigationTable)
				{
					propertiesTableItemViewModel.Renderer.RadGridView.BorderThickness = new Thickness(1.0, 0.0, 0.0, 0.0);
					propertiesTableItemViewModel.Renderer.GridRenderer.Margin = 20.0;
					propertiesTableItemViewModel.Renderer.GridRenderer.ColumnWidthFactor = 1.0;
					propertiesTableItemViewModel.Renderer.RadGridView.Margin = new Thickness(0.0, -1.0, 0.0, 0.0);
				}
			}
			this.NavigationTable.Renderer.RadGridView.SelectionMode = SelectionMode.Single;
			this.NavigationTable.Renderer.RadGridView.CanUserSelect = true;
			this.#I = Visibility.Visible;
			base.Services.MessageBus.DiagramImposed += this.#qcb;
			base.Services.MessageBus.UnitSystemChanged += this.#EO;
		}

		// Token: 0x140000A4 RID: 164
		// (add) Token: 0x06002580 RID: 9600 RVA: 0x000D38A8 File Offset: 0x000D1AA8
		// (remove) Token: 0x06002581 RID: 9601 RVA: 0x000D38EC File Offset: 0x000D1AEC
		public event EventHandler<#pkb> AxialLoadChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#K;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#K, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#K;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#K, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000A5 RID: 165
		// (add) Token: 0x06002582 RID: 9602 RVA: 0x000D3930 File Offset: 0x000D1B30
		// (remove) Token: 0x06002583 RID: 9603 RVA: 0x000D3974 File Offset: 0x000D1B74
		public event EventHandler<#pkb> AngleChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#L;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#L, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#L;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#L, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000A6 RID: 166
		// (add) Token: 0x06002584 RID: 9604 RVA: 0x000D39B8 File Offset: 0x000D1BB8
		// (remove) Token: 0x06002585 RID: 9605 RVA: 0x000D39FC File Offset: 0x000D1BFC
		public event EventHandler<#lkb> LoadSelectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#lkb> eventHandler = this.#M;
				EventHandler<#lkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#lkb> value2 = (EventHandler<#lkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#lkb>>(ref this.#M, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#lkb> eventHandler = this.#M;
				EventHandler<#lkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#lkb> value2 = (EventHandler<#lkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#lkb>>(ref this.#M, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000A7 RID: 167
		// (add) Token: 0x06002586 RID: 9606 RVA: 0x000D3A40 File Offset: 0x000D1C40
		// (remove) Token: 0x06002587 RID: 9607 RVA: 0x000D3A84 File Offset: 0x000D1C84
		public event EventHandler FiltersChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#N;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#N, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#N;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#N, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000CBB RID: 3259
		// (get) Token: 0x06002588 RID: 9608 RVA: 0x0002345F File Offset: 0x0002165F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000CBC RID: 3260
		// (get) Token: 0x06002589 RID: 9609 RVA: 0x0002346F File Offset: 0x0002166F
		// (set) Token: 0x0600258A RID: 9610 RVA: 0x0002347B File Offset: 0x0002167B
		public QueryableCollectionView AnglesCollectionView { get; private set; }

		// Token: 0x17000CBD RID: 3261
		// (get) Token: 0x0600258B RID: 9611 RVA: 0x0002348C File Offset: 0x0002168C
		// (set) Token: 0x0600258C RID: 9612 RVA: 0x00023498 File Offset: 0x00021698
		public QueryableCollectionView AxialLoadsCollectionView { get; private set; }

		// Token: 0x17000CBE RID: 3262
		// (get) Token: 0x0600258D RID: 9613 RVA: 0x000234A9 File Offset: 0x000216A9
		public DelegateCommand GoToNextAngleCommand { get; }

		// Token: 0x17000CBF RID: 3263
		// (get) Token: 0x0600258E RID: 9614 RVA: 0x000234B5 File Offset: 0x000216B5
		public DelegateCommand GoToPreviousAngleCommand { get; }

		// Token: 0x17000CC0 RID: 3264
		// (get) Token: 0x0600258F RID: 9615 RVA: 0x000234C1 File Offset: 0x000216C1
		public DelegateCommand GoToNextAxialLoadCommand { get; }

		// Token: 0x17000CC1 RID: 3265
		// (get) Token: 0x06002590 RID: 9616 RVA: 0x000234CD File Offset: 0x000216CD
		public DelegateCommand GoToPreviousAxialLoadCommand { get; }

		// Token: 0x17000CC2 RID: 3266
		// (get) Token: 0x06002591 RID: 9617 RVA: 0x000234D9 File Offset: 0x000216D9
		public DelegateCommand ExportNavigationTableCommand { get; }

		// Token: 0x17000CC3 RID: 3267
		// (get) Token: 0x06002592 RID: 9618 RVA: 0x000234E5 File Offset: 0x000216E5
		// (set) Token: 0x06002593 RID: 9619 RVA: 0x000234F1 File Offset: 0x000216F1
		public bool DoNotRaiseSelectionEvents { get; set; }

		// Token: 0x17000CC4 RID: 3268
		// (get) Token: 0x06002594 RID: 9620 RVA: 0x00023502 File Offset: 0x00021702
		// (set) Token: 0x06002595 RID: 9621 RVA: 0x0002350E File Offset: 0x0002170E
		public bool AreNavigationBoxesEnabled
		{
			get
			{
				return this.#u;
			}
			set
			{
				if (this.#u != value)
				{
					this.#u = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361777));
				}
			}
		}

		// Token: 0x17000CC5 RID: 3269
		// (get) Token: 0x06002596 RID: 9622 RVA: 0x0002353C File Offset: 0x0002173C
		// (set) Token: 0x06002597 RID: 9623 RVA: 0x00023548 File Offset: 0x00021748
		public bool IsNavigationExpanded
		{
			get
			{
				return this.#F;
			}
			set
			{
				if (this.#F != value)
				{
					this.#F = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361708));
				}
			}
		}

		// Token: 0x17000CC6 RID: 3270
		// (get) Token: 0x06002598 RID: 9624 RVA: 0x00023576 File Offset: 0x00021776
		// (set) Token: 0x06002599 RID: 9625 RVA: 0x00023582 File Offset: 0x00021782
		public bool IsSectionExpanded
		{
			get
			{
				return this.#G;
			}
			set
			{
				if (this.#G != value)
				{
					this.#G = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361679));
				}
			}
		}

		// Token: 0x17000CC7 RID: 3271
		// (get) Token: 0x0600259A RID: 9626 RVA: 0x000235B0 File Offset: 0x000217B0
		// (set) Token: 0x0600259B RID: 9627 RVA: 0x000235BC File Offset: 0x000217BC
		public bool CanExpandNavigation
		{
			get
			{
				return this.#H;
			}
			set
			{
				if (this.#H != value)
				{
					this.#H = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361686));
				}
			}
		}

		// Token: 0x17000CC8 RID: 3272
		// (get) Token: 0x0600259C RID: 9628 RVA: 0x000235EA File Offset: 0x000217EA
		// (set) Token: 0x0600259D RID: 9629 RVA: 0x000235F6 File Offset: 0x000217F6
		public Visibility NavigationTableVisibility
		{
			get
			{
				return this.#I;
			}
			set
			{
				if (this.#I != value)
				{
					this.#I = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361657));
				}
			}
		}

		// Token: 0x17000CC9 RID: 3273
		// (get) Token: 0x0600259E RID: 9630 RVA: 0x00023624 File Offset: 0x00021824
		// (set) Token: 0x0600259F RID: 9631 RVA: 0x00023630 File Offset: 0x00021830
		public bool IsNavigationTableEnabled
		{
			get
			{
				return this.#t;
			}
			set
			{
				if (this.#t != value)
				{
					this.#t = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361620));
				}
			}
		}

		// Token: 0x17000CCA RID: 3274
		// (get) Token: 0x060025A0 RID: 9632 RVA: 0x0002365E File Offset: 0x0002185E
		// (set) Token: 0x060025A1 RID: 9633 RVA: 0x0002366A File Offset: 0x0002186A
		public bool Diagram3DEnabled
		{
			get
			{
				return this.#v;
			}
			set
			{
				if (this.#v != value)
				{
					this.#v = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361587));
				}
			}
		}

		// Token: 0x17000CCB RID: 3275
		// (get) Token: 0x060025A2 RID: 9634 RVA: 0x00023698 File Offset: 0x00021898
		// (set) Token: 0x060025A3 RID: 9635 RVA: 0x000236A4 File Offset: 0x000218A4
		public bool IsViewportsSelectionEnabled
		{
			get
			{
				return this.#x;
			}
			set
			{
				if (this.#x != value)
				{
					this.#x = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361562));
				}
			}
		}

		// Token: 0x17000CCC RID: 3276
		// (get) Token: 0x060025A4 RID: 9636 RVA: 0x000236D2 File Offset: 0x000218D2
		// (set) Token: 0x060025A5 RID: 9637 RVA: 0x000236DE File Offset: 0x000218DE
		public bool DiagramMMEnabled
		{
			get
			{
				return this.#w;
			}
			set
			{
				if (this.#w != value)
				{
					this.#w = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361013));
				}
			}
		}

		// Token: 0x17000CCD RID: 3277
		// (get) Token: 0x060025A6 RID: 9638 RVA: 0x0002370C File Offset: 0x0002190C
		// (set) Token: 0x060025A7 RID: 9639 RVA: 0x00023718 File Offset: 0x00021918
		public PropertiesTableItemViewModel NavigationTable { get; private set; }

		// Token: 0x17000CCE RID: 3278
		// (get) Token: 0x060025A8 RID: 9640 RVA: 0x00023729 File Offset: 0x00021929
		public PropertiesTableItemViewModel SummaryTable { get; }

		// Token: 0x17000CCF RID: 3279
		// (get) Token: 0x060025A9 RID: 9641 RVA: 0x00023735 File Offset: 0x00021935
		// (set) Token: 0x060025AA RID: 9642 RVA: 0x00023741 File Offset: 0x00021941
		public BitmapSource SectionPreviewBitmap
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (!object.Equals(this.#k, value))
				{
					this.#k = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360988));
				}
			}
		}

		// Token: 0x17000CD0 RID: 3280
		// (get) Token: 0x060025AB RID: 9643 RVA: 0x00023774 File Offset: 0x00021974
		// (set) Token: 0x060025AC RID: 9644 RVA: 0x00023780 File Offset: 0x00021980
		public string SectionDimensionsLabel
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360959));
				}
			}
		}

		// Token: 0x17000CD1 RID: 3281
		// (get) Token: 0x060025AD RID: 9645 RVA: 0x000237B3 File Offset: 0x000219B3
		// (set) Token: 0x060025AE RID: 9646 RVA: 0x000237BF File Offset: 0x000219BF
		public string AxialLoadUniString
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360926));
				}
			}
		}

		// Token: 0x17000CD2 RID: 3282
		// (get) Token: 0x060025AF RID: 9647 RVA: 0x000237F2 File Offset: 0x000219F2
		// (set) Token: 0x060025B0 RID: 9648 RVA: 0x000D3AC8 File Offset: 0x000D1CC8
		public NavigationComboItem SelectedAxialLoad
		{
			get
			{
				return this.#n;
			}
			private set
			{
				if (this.#n != value)
				{
					this.#n = value;
					this.SelectedAxialLoadText = ((value != null) ? value.AxialLoad : 0.0);
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107360869));
				}
			}
		}

		// Token: 0x17000CD3 RID: 3283
		// (get) Token: 0x060025B1 RID: 9649 RVA: 0x000237FE File Offset: 0x000219FE
		// (set) Token: 0x060025B2 RID: 9650 RVA: 0x000D3B24 File Offset: 0x000D1D24
		public NavigationComboItem SelectedAngle
		{
			get
			{
				return this.#o;
			}
			private set
			{
				if (this.#o != value)
				{
					this.#o = value;
					this.SelectedAngleText = ((value != null) ? value.Angle : 0.0);
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107360844));
				}
			}
		}

		// Token: 0x17000CD4 RID: 3284
		// (get) Token: 0x060025B3 RID: 9651 RVA: 0x0002380A File Offset: 0x00021A0A
		// (set) Token: 0x060025B4 RID: 9652 RVA: 0x000D3B80 File Offset: 0x000D1D80
		public double SelectedAngleText
		{
			get
			{
				return this.#p;
			}
			set
			{
				if (this.#p != value)
				{
					this.#p = ((value > 360.0) ? 360.0 : ((value < 0.0) ? 0.0 : value));
					this.#Cib();
					this.#Hib();
					this.#0db(new #pkb(this.#p));
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107360855));
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#pwf));
				}
			}
		}

		// Token: 0x17000CD5 RID: 3285
		// (get) Token: 0x060025B5 RID: 9653 RVA: 0x00023816 File Offset: 0x00021A16
		// (set) Token: 0x060025B6 RID: 9654 RVA: 0x000D3C30 File Offset: 0x000D1E30
		public double SelectedAxialLoadText
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					double val = Math.Max(this.#z, value);
					val = Math.Min(val, this.#A);
					this.#q = val;
					this.#Cib();
					this.#Hib();
					this.#1db(new #pkb(val));
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107360830));
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#qwf));
				}
			}
		}

		// Token: 0x17000CD6 RID: 3286
		// (get) Token: 0x060025B7 RID: 9655 RVA: 0x000D3CB4 File Offset: 0x000D1EB4
		public bool IsLoadPointsFilterApplied
		{
			get
			{
				#Gse #Gse = base.Services.ReporterSettings.#Hse(this.#r);
				return #Gse.IsAnyFilterActive;
			}
		}

		// Token: 0x17000CD7 RID: 3287
		// (get) Token: 0x060025B8 RID: 9656 RVA: 0x00023822 File Offset: 0x00021A22
		public DelegateCommand EditFilterCommand { get; }

		// Token: 0x17000CD8 RID: 3288
		// (get) Token: 0x060025B9 RID: 9657 RVA: 0x0002382E File Offset: 0x00021A2E
		// (set) Token: 0x060025BA RID: 9658 RVA: 0x0002383A File Offset: 0x00021A3A
		public bool IsAngleComboBoxEnabled
		{
			get
			{
				return this.#B;
			}
			set
			{
				if (this.#B != value)
				{
					this.#B = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360769));
				}
			}
		}

		// Token: 0x17000CD9 RID: 3289
		// (get) Token: 0x060025BB RID: 9659 RVA: 0x00023868 File Offset: 0x00021A68
		// (set) Token: 0x060025BC RID: 9660 RVA: 0x00023874 File Offset: 0x00021A74
		public bool IsAxialLoadComboBoxEnabled
		{
			get
			{
				return this.#C;
			}
			set
			{
				if (this.#C != value)
				{
					this.#C = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361248));
				}
			}
		}

		// Token: 0x17000CDA RID: 3290
		// (get) Token: 0x060025BD RID: 9661 RVA: 0x000238A2 File Offset: 0x00021AA2
		public DelegateCommand OnNavigationControlGotFocusCommand { get; }

		// Token: 0x17000CDB RID: 3291
		// (get) Token: 0x060025BE RID: 9662 RVA: 0x000238AE File Offset: 0x00021AAE
		public #mAe SuperImposeContext { get; }

		// Token: 0x17000CDC RID: 3292
		// (get) Token: 0x060025BF RID: 9663 RVA: 0x000238BA File Offset: 0x00021ABA
		public #sib SuperImposeViewModel { get; }

		// Token: 0x060025C0 RID: 9664 RVA: 0x000238C6 File Offset: 0x00021AC6
		protected override void #uh(ILeftPanelView #Ee)
		{
			base.#uh(#Ee);
			#Ee.SizeChanged += this.#scb;
		}

		// Token: 0x060025C1 RID: 9665 RVA: 0x000238ED File Offset: 0x00021AED
		public void #lib(IDiagramPresenterViewModel #uab)
		{
			this.#y = #uab;
		}

		// Token: 0x060025C2 RID: 9666 RVA: 0x000D3CEC File Offset: 0x000D1EEC
		public void #cab()
		{
			this.AreNavigationBoxesEnabled = false;
			this.Diagram3DEnabled = false;
			this.DiagramMMEnabled = false;
			this.IsViewportsSelectionEnabled = false;
			this.NavigationTable.Renderer.GridRenderer.#ehd();
			this.#vh();
		}

		// Token: 0x060025C3 RID: 9667 RVA: 0x000D3D3C File Offset: 0x000D1F3C
		public void #8hb(IList<IDiagramPresenterViewModel> #9hb)
		{
			this.IsAxialLoadComboBoxEnabled = #9hb.Any(new Func<IDiagramPresenterViewModel, bool>(LeftPanelViewModel.<>c.<>9.#G0h));
			this.IsAngleComboBoxEnabled = #9hb.Any(new Func<IDiagramPresenterViewModel, bool>(LeftPanelViewModel.<>c.<>9.#H0h));
		}

		// Token: 0x060025C4 RID: 9668 RVA: 0x000D3DAC File Offset: 0x000D1FAC
		public void #aib(IDiagramPresenterViewModel #uab, bool #eab = false, bool #bib = false)
		{
			this.#y = #uab;
			try
			{
				#Gse #Nib = base.Services.ReporterSettings.#Hse(this.#r);
				if (this.#r != null)
				{
					this.#g.ConsideredAxis = this.#r.Input.Options.ConsideredAxis;
				}
				if (#eab && this.#r != null)
				{
					this.#fib(this.#r);
					this.#gib(this.#r);
				}
				this.AxialLoadsCollectionView.Refresh();
				this.AnglesCollectionView.Refresh();
				this.#Mib(#uab, #Nib, #bib);
				base.RaisePropertyChanged<double>(System.Linq.Expressions.Expression.Lambda<Func<double>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Shb())), Array.Empty<ParameterExpression>()));
				base.RaisePropertyChanged<double>(System.Linq.Expressions.Expression.Lambda<Func<double>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Uhb())), Array.Empty<ParameterExpression>()));
				this.#vh();
			}
			catch (Exception #ob)
			{
				this.#a.#3Ab(#ob);
			}
		}

		// Token: 0x060025C5 RID: 9669 RVA: 0x000D3EF0 File Offset: 0x000D20F0
		public void #cib(double #f)
		{
			this.#q = Math.Round(#f, 1);
			this.#Cib();
			base.RaisePropertyChanged<double>(System.Linq.Expressions.Expression.Lambda<Func<double>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Uhb())), Array.Empty<ParameterExpression>()));
			this.#vh();
		}

		// Token: 0x060025C6 RID: 9670 RVA: 0x000D3F58 File Offset: 0x000D2158
		public void #dib(double #f)
		{
			this.#p = Math.Round(#f, 1);
			this.#Cib();
			base.RaisePropertyChanged<double>(System.Linq.Expressions.Expression.Lambda<Func<double>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Shb())), Array.Empty<ParameterExpression>()));
			this.#vh();
		}

		// Token: 0x060025C7 RID: 9671 RVA: 0x000D3FC0 File Offset: 0x000D21C0
		public void #eib(double #6Q)
		{
			this.#J = #6Q;
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#e)
			{
				propertiesTableItemViewModel.Renderer.#ihd(#6Q);
			}
		}

		// Token: 0x060025C8 RID: 9672 RVA: 0x000D402C File Offset: 0x000D222C
		public void #fib(#lte #Wdb)
		{
			this.NavigationTable.Renderer.RequiresRefresh = true;
			this.NavigationTable.Renderer.GridRenderer.LastColumnMinWidth = new double?((double)52);
			this.NavigationTable.Renderer.GridRenderer.UseCompactHeaderStyles = true;
			#RCd #opb = new #RCd(new #6Fd());
			this.#D.#npb(#opb);
			#Gse #Gse = base.Services.ReporterSettings.#Hse(#Wdb);
			#2Qb #2Qb = base.Services.Settings.CurrentGeneralOptions;
			#hpb #xS = new #hpb((#mpb)this.NavigationTable.DocumentContentOptions, #Wdb);
			#dye #dye = new #dye(this.NavigationTable.Renderer.GridRenderer, #xS);
			#dye.CriticalItemsOptions = new #0ed(new #Wpb(#Gse, this.#D, #Wdb))
			{
				Highlight = #2Qb.HighlightCriticalLoadPoints,
				HighlightColor = #Gse.HighlightCapacityRatioColor
			};
			this.NavigationTable.Renderer.#ghd(#dye);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#YVh));
		}

		// Token: 0x060025C9 RID: 9673 RVA: 0x000D415C File Offset: 0x000D235C
		public void #gib(#lte #Wdb)
		{
			this.SummaryTable.Renderer.RequiresRefresh = true;
			#hpb #xS = new #hpb((#mpb)this.SummaryTable.DocumentContentOptions, #Wdb);
			#dye #dye = new #dye(this.SummaryTable.Renderer.GridRenderer, #xS);
			#Gse #Gse = base.Services.ReporterSettings.#Hse(#Wdb);
			#2Qb #2Qb = base.Services.Settings.CurrentGeneralOptions;
			#dye.CriticalItemsOptions = new #0ed(new #1pb(#Gse, #Wdb.Input.Options.ProblemType == ProblemType.Design, #Wdb.Input.DesignToRequiredRatio))
			{
				Highlight = #2Qb.HighlightCriticalLoadPoints,
				HighlightColor = #Gse.HighlightCapacityRatioColor
			};
			this.SummaryTable.Renderer.#ghd(#dye);
		}

		// Token: 0x060025CA RID: 9674 RVA: 0x000D4244 File Offset: 0x000D2444
		public void #hz(#lte #Wdb, #hwe #hib)
		{
			this.#D = new #Qpb(#Wdb);
			this.#r = #Wdb;
			this.#s = #hib;
			this.#jib(#hib);
			this.#3ib(#Wdb);
			this.AxialLoadUniString = #Wdb.GeneralInfo.UnitStringF;
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#e)
			{
				if (propertiesTableItemViewModel == this.NavigationTable)
				{
					this.#fib(#Wdb);
				}
				else if (propertiesTableItemViewModel == this.SummaryTable)
				{
					this.#gib(#Wdb);
				}
			}
			this.#2ib(this.#s, this.#r);
			this.#aib(this.#y, false, false);
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Whb())), Array.Empty<ParameterExpression>()));
		}

		// Token: 0x060025CB RID: 9675 RVA: 0x000D4360 File Offset: 0x000D2560
		public void #iib(#lte #Od)
		{
			try
			{
				this.SectionPreviewBitmap = #yPb.#ul(#Od, base.Services.Settings);
			}
			catch (Exception #ob)
			{
				this.#a.#3Ab(#ob);
			}
		}

		// Token: 0x060025CC RID: 9676 RVA: 0x000D43B4 File Offset: 0x000D25B4
		public void #jib()
		{
			#hwe #hwe = this.#s;
			if (#hwe != null)
			{
				this.#jib(#hwe);
			}
		}

		// Token: 0x060025CD RID: 9677 RVA: 0x000D43E0 File Offset: 0x000D25E0
		protected void #0db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#L;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060025CE RID: 9678 RVA: 0x000D440C File Offset: 0x000D260C
		protected void #1db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#K;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060025CF RID: 9679 RVA: 0x000D4438 File Offset: 0x000D2638
		protected void #yib(#lkb #He)
		{
			EventHandler<#lkb> eventHandler = this.#M;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060025D0 RID: 9680 RVA: 0x000D4464 File Offset: 0x000D2664
		protected void #zib()
		{
			EventHandler eventHandler = this.#N;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x060025D1 RID: 9681 RVA: 0x0002240A File Offset: 0x0002060A
		public override void UnsubscribeAllEvents()
		{
			base.UnsubscribeAllEvents();
		}

		// Token: 0x060025D2 RID: 9682 RVA: 0x000223FA File Offset: 0x000205FA
		public override void RefreshAllProperties()
		{
			base.RefreshAllProperties();
		}

		// Token: 0x060025D3 RID: 9683 RVA: 0x000D4494 File Offset: 0x000D2694
		private void #EO(object #Ge, EventArgs #He)
		{
			try
			{
				if (base.View.IsVisible)
				{
					#lte #lte = this.#d.#LA(base.Project.Model.#CY(), false);
					this.#fib(#lte);
					this.#gib(#lte);
					this.#iib(#lte);
					this.SectionDimensionsLabel = #yPb.#xPb(#lte);
					this.AxialLoadUniString = #lte.GeneralInfo.UnitStringF;
				}
			}
			catch (Exception #ob)
			{
				this.#a.#3Ab(#ob);
			}
		}

		// Token: 0x060025D4 RID: 9684 RVA: 0x000D452C File Offset: 0x000D272C
		private void #scb(object #Ge, SizeChangedEventArgs #He)
		{
			if (#He.NewSize.Width <= 200.0 || #He.PreviousSize.Width <= 0.0)
			{
				return;
			}
			this.#eib(#He.NewSize.Width);
		}

		// Token: 0x060025D5 RID: 9685 RVA: 0x000D458C File Offset: 0x000D278C
		private void #Aib(object #Ge, SelectionChangeEventArgs #He)
		{
			if (this.DoNotRaiseSelectionEvents)
			{
				return;
			}
			if (#He.AddedItems == null)
			{
				this.#yib(new #lkb(true));
				return;
			}
			GridDataRowCore gridDataRowCore = #He.AddedItems.OfType<GridDataRowCore>().FirstOrDefault<GridDataRowCore>();
			gridDataRowCore = (gridDataRowCore ?? (this.NavigationTable.Renderer.RadGridView.SelectedItems.FirstOrDefault<object>() as GridDataRowCore));
			LoadPointRowMetadata loadPointRowMetadata = ((gridDataRowCore != null) ? gridDataRowCore.Metadata : null) as LoadPointRowMetadata;
			if (loadPointRowMetadata == null)
			{
				this.#yib(new #lkb(true));
				return;
			}
			if (loadPointRowMetadata.AxialLoad != null && loadPointRowMetadata.Angle != null)
			{
				double num = Math.Round(loadPointRowMetadata.Angle.Value, 1);
				double num2 = Math.Round(loadPointRowMetadata.AxialLoad.Value, 1);
				bool #nkb;
				if (num % 180.0 == this.SelectedAngleText % 180.0)
				{
					#nkb = false;
				}
				else
				{
					#nkb = true;
					this.#dib(num);
				}
				bool #mkb = num2 != this.SelectedAxialLoadText;
				this.#cib(num2);
				this.#yib(new #lkb(#mkb, #nkb));
				return;
			}
			if (loadPointRowMetadata.AxialLoad != null)
			{
				this.#yib(new #lkb(true, false));
				return;
			}
			this.#yib(new #lkb(true));
		}

		// Token: 0x060025D6 RID: 9686 RVA: 0x000D46F8 File Offset: 0x000D28F8
		private void #Bib(object #Ge, #Yhd #He)
		{
			double? #0jb = this.#D.#Bpb(#He.DataRow);
			double? #1jb = this.#D.#Cpb(#He.DataRow);
			#He.DataRow.Metadata = new LoadPointRowMetadata
			{
				AxialLoad = this.#D.#Apb(#He.DataRow),
				Angle = LoadPointsHelper.#0Tc(#0jb, #1jb),
				CapacityRatio = this.#D.#Dpb(#He.DataRow),
				DisplayedCapacityRatio = this.#D.#Epb(#He.DataRow),
				MomentX = #0jb,
				MomentY = #1jb,
				Number = this.#D.#wpb(#He.DataRow),
				LoadNumber = this.#D.#xpb(#He.DataRow),
				CombinationNumber = this.#D.#ypb(#He.DataRow),
				Location = this.#D.#zpb(#He.DataRow),
				Calculation = this.#D.CapacityCache.#F1d(this.#D.#wpb(#He.DataRow)),
				Parameters = this.#D.ParametersCache.#F1d(this.#D.#wpb(#He.DataRow))
			};
		}

		// Token: 0x060025D7 RID: 9687 RVA: 0x000238FE File Offset: 0x00021AFE
		private void #qcb(object #Ge, EventArgs #He)
		{
			this.SummaryTable.IsExpanded = false;
			this.IsSectionExpanded = false;
		}

		// Token: 0x060025D8 RID: 9688 RVA: 0x0002391F File Offset: 0x00021B1F
		private void #Cib()
		{
			this.#c.CurrentAxialLoad = this.SelectedAxialLoadText;
			this.#c.CurrentAngle = this.SelectedAngleText;
		}

		// Token: 0x060025D9 RID: 9689 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Dib(object #Sb)
		{
			return true;
		}

		// Token: 0x060025DA RID: 9690 RVA: 0x000D4864 File Offset: 0x000D2A64
		private void #Eib(object #Sb)
		{
			try
			{
				this.NavigationTable.#ljb(null);
				this.NavigationTable.View.RadGridView.SetCurrentValue(DataControl.SelectedItemProperty, null);
			}
			catch (Exception exception)
			{
				this.#a.Logger.Log(LoggingLevel.Warning, exception);
			}
		}

		// Token: 0x060025DB RID: 9691 RVA: 0x000D48CC File Offset: 0x000D2ACC
		private PropertiesTableItemViewModel #Fib(string #wy, Option #bA, Visibility #Gib = Visibility.Collapsed)
		{
			PropertiesTableItemViewModel propertiesTableItemViewModel = new PropertiesTableItemViewModel(#wy, #bA, true, #Gib);
			#mpb #5d = new #mpb();
			ReportOptionsHelper.#xdd<#mpb>(#5d, #bA);
			propertiesTableItemViewModel.DocumentContentOptions = #5d;
			return propertiesTableItemViewModel;
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x0002394F File Offset: 0x00021B4F
		private void #Hib()
		{
			this.NavigationTable.#ljb(null);
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x000D4904 File Offset: 0x000D2B04
		private void #Iib()
		{
			this.AxialLoadsCollectionView = new QueryableCollectionView(this.#i, typeof(NavigationComboItem));
			this.AxialLoadsCollectionView.FilterDescriptors.Add(this.#g);
			this.AnglesCollectionView = new QueryableCollectionView(this.#h, typeof(NavigationComboItem));
			this.AnglesCollectionView.FilterDescriptors.Add(this.#g);
			this.#B = true;
			this.#C = true;
		}

		// Token: 0x060025DE RID: 9694 RVA: 0x000D4990 File Offset: 0x000D2B90
		private void #Jib(#mpb #mA)
		{
			this.NavigationTable = this.#Fib(#Phc.#3hc(107361243), #mA.NavigationSpecialTable, Visibility.Visible);
			this.NavigationTable.Renderer.GridRenderer.ExpandLastColumn = true;
			this.NavigationTable.Renderer.GridRenderer.SortValuePreprocessor = new #Nze();
			this.NavigationTable.Renderer.GridRenderer.EnableBoldHeaders = false;
			this.NavigationTable.Renderer.RadGridView.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
			this.NavigationTable.Renderer.RadGridView.BorderThickness = new Thickness(1.0);
			this.NavigationTable.Renderer.RadGridView.FilterDescriptors.Add(this.#f);
			this.NavigationTable.Renderer.RadGridView.SelectionUnit = GridViewSelectionUnit.FullRow;
			this.NavigationTable.Renderer.RadGridView.IsSynchronizedWithCurrentItem = new bool?(false);
			this.NavigationTable.Renderer.RadGridView.VerticalAlignment = VerticalAlignment.Top;
			this.NavigationTable.Renderer.GridRenderer.RowRendered += this.#Bib;
			this.NavigationTable.Renderer.RadGridView.SelectionChanged += this.#Aib;
			this.NavigationTable.Renderer.RadGridView.Loaded += this.#4ib;
		}

		// Token: 0x060025DF RID: 9695 RVA: 0x000D4B2C File Offset: 0x000D2D2C
		private bool #Kib(object #Sb)
		{
			return this.IsNavigationTableEnabled && this.#r != null && this.#r.Output.CapacityData.LoadPoints.Any<LoadPointDrawingData>() && this.NavigationTable.View.RadGridView.Items.Count > 0;
		}

		// Token: 0x060025E0 RID: 9696 RVA: 0x000D4B90 File Offset: 0x000D2D90
		private void #Lib(object #Sb)
		{
			try
			{
				#62c #21c = new #62c(new List<#L1c>
				{
					new #L1c(#Phc.#3hc(107408528), #Phc.#3hc(107408483))
				}, #Phc.#3hc(107408483), Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(this.#r.GeneralInfo.FileName))
				{
					InitialFileName = Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(this.#r.GeneralInfo.FileName) + #Phc.#3hc(107361194)
				};
				string text = base.FileSystem.#11c(#21c);
				if (!string.IsNullOrWhiteSpace(text))
				{
					using (Stream stream = base.FileSystem.#T1c(text))
					{
						this.NavigationTable.View.RadGridView.Export(stream, new GridViewCsvExportOptions
						{
							ShowColumnHeaders = true
						});
					}
				}
			}
			catch (Exception #ob)
			{
				this.#a.#3Ab(#ob);
			}
		}

		// Token: 0x060025E1 RID: 9697 RVA: 0x000D4CAC File Offset: 0x000D2EAC
		private void #Mib(IDiagramPresenterViewModel #uab, #Gse #Nib, bool #Oib = false)
		{
			this.#y = #uab;
			if (this.#j.#YXd())
			{
				try
				{
					this.#Rib(#uab, #Nib, #Oib);
				}
				finally
				{
					this.#j.#ZXd();
				}
			}
		}

		// Token: 0x060025E2 RID: 9698 RVA: 0x000D4D00 File Offset: 0x000D2F00
		private bool #Pib(IDiagramPresenterViewModel #uab, #Gse #Nib)
		{
			bool flag = this.#E == null || this.#E.IsCapacityRatioFilterActive != #Nib.IsCapacityRatioFilterActive || this.#E.IsLocationFilterActive != #Nib.IsLocationFilterActive || this.#E.IsVisibilityFilterActive != #Nib.IsVisibilityFilterActive || this.#E.CapacityRatioFilterValue != #Nib.CapacityRatioFilterValue || this.#E.LocationFilter != #Nib.LocationFilter;
			this.#E = #Nib;
			IReadOnlyList<LoadPointDrawingData> readOnlyList = (#uab != null) ? #uab.VisibleLoadPoints : null;
			if (!flag && #Nib.IsAnyFilterActive)
			{
				flag = ((this.#f.AllLoadPointsAreVisible ^ readOnlyList == null) || (readOnlyList != null && this.#f.VisibleLoadPoints.Count != readOnlyList.Count));
				if (readOnlyList != null && !flag)
				{
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						if (readOnlyList[i].Index != this.#f.VisibleLoadPoints[i].Index)
						{
							flag = true;
							break;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060025E3 RID: 9699 RVA: 0x000D4E30 File Offset: 0x000D3030
		private IReadOnlyList<LoadPointDrawingData> #Qib(IDiagramPresenterViewModel #uab)
		{
			IReadOnlyList<LoadPointDrawingData> result = (#uab != null) ? #uab.VisibleLoadPoints : null;
			if (#uab != null && #uab.PresenterType == DiagramPresenterType.#a && !base.Services.Settings.Diagram3DAreLoadPointsVisible)
			{
				result = new LoadPointDrawingData[0];
			}
			return result;
		}

		// Token: 0x060025E4 RID: 9700 RVA: 0x000D4E7C File Offset: 0x000D307C
		private void #Rib(IDiagramPresenterViewModel #uab, #Gse #Nib, bool #Oib = false)
		{
			if (!this.#Pib(#uab, #Nib) && !#Oib)
			{
				return;
			}
			GridViewScrollViewer gridViewScrollViewer = this.NavigationTable.View.RadGridView.ChildrenOfType<GridViewScrollViewer>().FirstOrDefault<GridViewScrollViewer>();
			double offset = (gridViewScrollViewer != null) ? gridViewScrollViewer.VerticalOffset : 0.0;
			try
			{
				this.#f.SuspendNotifications();
				if (this.#r != null)
				{
					this.#f.ConsideredAxis = this.#r.Input.Options.ConsideredAxis;
				}
				IReadOnlyList<LoadPointDrawingData> #yjb = this.#Qib(#uab);
				this.#f.#xjb(#yjb);
				this.#f.#wjb(#Nib);
				this.NavigationTable.View.RadGridView.FilterDescriptors.Remove(this.#f);
				this.NavigationTable.View.RadGridView.FilterDescriptors.Add(this.#f);
			}
			finally
			{
				this.#f.ResumeNotifications();
				if (gridViewScrollViewer != null)
				{
					gridViewScrollViewer.ScrollToVerticalOffset(offset);
				}
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#swf));
			}
		}

		// Token: 0x060025E5 RID: 9701 RVA: 0x00023969 File Offset: 0x00021B69
		private bool #Sib(object #Sb)
		{
			return this.IsNavigationTableEnabled && (this.NavigationTable.#kjb().Any<GridDataRowCore>() || this.#i.Count > 1);
		}

		// Token: 0x060025E6 RID: 9702 RVA: 0x000D4FB8 File Offset: 0x000D31B8
		private void #Tib(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			try
			{
				this.#b.View.SetOwner(base.Services.WindowLocator.#VP());
				this.#b.#od(this.#r);
				if (this.#b.DialogResult.GetValueOrDefault())
				{
					this.#aib(this.#y, true, true);
					this.#zib();
				}
				this.#vh();
				base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(LeftPanelViewModel)), methodof(LeftPanelViewModel.#Whb())), Array.Empty<ParameterExpression>()));
			}
			catch (Exception #ob)
			{
				this.#a.#3Ab(#ob);
			}
		}

		// Token: 0x060025E7 RID: 9703 RVA: 0x000D50A8 File Offset: 0x000D32A8
		private bool #Uib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AxialLoadsCollectionView.OfType<NavigationComboItem>().FirstOrDefault<NavigationComboItem>();
			return navigationComboItem != null && this.SelectedAxialLoadText > navigationComboItem.AxialLoad && this.SelectedAxialLoadText > this.#z;
		}

		// Token: 0x060025E8 RID: 9704 RVA: 0x000D50F4 File Offset: 0x000D32F4
		private void #Vib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AxialLoadsCollectionView.OfType<NavigationComboItem>().LastOrDefault(new Func<NavigationComboItem, bool>(this.#twf));
			if (navigationComboItem != null)
			{
				this.SelectedAxialLoadText = navigationComboItem.AxialLoad;
			}
		}

		// Token: 0x060025E9 RID: 9705 RVA: 0x000D513C File Offset: 0x000D333C
		private bool #Wib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AxialLoadsCollectionView.OfType<NavigationComboItem>().LastOrDefault<NavigationComboItem>();
			return navigationComboItem != null && this.SelectedAxialLoadText < navigationComboItem.AxialLoad && this.SelectedAxialLoadText < this.#A;
		}

		// Token: 0x060025EA RID: 9706 RVA: 0x000D5188 File Offset: 0x000D3388
		private void #Xib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AxialLoadsCollectionView.OfType<NavigationComboItem>().FirstOrDefault(new Func<NavigationComboItem, bool>(this.#uwf));
			if (navigationComboItem != null)
			{
				this.SelectedAxialLoadText = navigationComboItem.AxialLoad;
			}
		}

		// Token: 0x060025EB RID: 9707 RVA: 0x000D51D0 File Offset: 0x000D33D0
		private bool #Yib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AnglesCollectionView.OfType<NavigationComboItem>().FirstOrDefault<NavigationComboItem>();
			return navigationComboItem != null && this.SelectedAngleText > navigationComboItem.Angle;
		}

		// Token: 0x060025EC RID: 9708 RVA: 0x000D5210 File Offset: 0x000D3410
		private void #Zib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AnglesCollectionView.OfType<NavigationComboItem>().LastOrDefault(new Func<NavigationComboItem, bool>(this.#vwf));
			if (navigationComboItem != null)
			{
				this.SelectedAngleText = navigationComboItem.Angle;
			}
		}

		// Token: 0x060025ED RID: 9709 RVA: 0x000D5258 File Offset: 0x000D3458
		private bool #0ib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AnglesCollectionView.OfType<NavigationComboItem>().LastOrDefault<NavigationComboItem>();
			return navigationComboItem != null && this.SelectedAngleText < navigationComboItem.Angle;
		}

		// Token: 0x060025EE RID: 9710 RVA: 0x000D5298 File Offset: 0x000D3498
		private void #1ib(object #Sb)
		{
			NavigationComboItem navigationComboItem = this.AnglesCollectionView.OfType<NavigationComboItem>().FirstOrDefault(new Func<NavigationComboItem, bool>(this.#wwf));
			if (navigationComboItem != null)
			{
				this.SelectedAngleText = navigationComboItem.Angle;
			}
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x000D52E0 File Offset: 0x000D34E0
		private new void #vh()
		{
			this.GoToNextAngleCommand.InvalidateCanExecute();
			this.GoToPreviousAngleCommand.InvalidateCanExecute();
			this.GoToNextAxialLoadCommand.InvalidateCanExecute();
			this.GoToPreviousAxialLoadCommand.InvalidateCanExecute();
			this.EditFilterCommand.InvalidateCanExecute();
			this.ExportNavigationTableCommand.InvalidateCanExecute();
		}

		// Token: 0x060025F0 RID: 9712 RVA: 0x000D533C File Offset: 0x000D353C
		private void #jib(#hwe #hib)
		{
			this.#z = (this.#A = 0.0);
			List<float> list = new List<float>();
			bool flag = base.Services.Settings.ShowFactored || base.Services.Settings.ShowNominal;
			if ((!flag || base.Services.Settings.ShowNominal) && #hib.NominalFailureSurfaceData != null)
			{
				list.AddRange(#hib.NominalFailureSurfaceData.Select(new Func<FailureSurfaceData, float>(LeftPanelViewModel.<>c.<>9.#lzf)));
			}
			if ((!flag || base.Services.Settings.ShowFactored) && #hib.FactoredFailureSurfaceData != null)
			{
				list.AddRange(#hib.FactoredFailureSurfaceData.Select(new Func<FailureSurfaceData, float>(LeftPanelViewModel.<>c.<>9.#mzf)));
			}
			if (base.Services.Settings.Diagram3DAreLoadPointsVisible && this.#r.Output.CapacityData.LoadPoints.Any<LoadPointDrawingData>())
			{
				list.AddRange(this.#r.Output.CapacityData.LoadPoints.Select(new Func<LoadPointDrawingData, float>(LeftPanelViewModel.<>c.<>9.#nzf)));
			}
			if (list.Any<float>())
			{
				this.#z = Math.Round((double)list.OrderBy(new Func<float, float>(LeftPanelViewModel.<>c.<>9.#ozf)).First<float>(), 1);
				this.#A = Math.Round((double)list.OrderByDescending(new Func<float, float>(LeftPanelViewModel.<>c.<>9.#pzf)).First<float>(), 1);
			}
		}

		// Token: 0x060025F1 RID: 9713 RVA: 0x000D5528 File Offset: 0x000D3728
		private void #2ib(#hwe #hib, #lte #Wdb)
		{
			LeftPanelViewModel.#xzf #xzf = new LeftPanelViewModel.#xzf();
			LeftPanelViewModel.#xzf #xzf2;
			if (true)
			{
				#xzf2 = #xzf;
			}
			this.#jib(#hib);
			#xzf2.#b = this.SelectedAngle;
			#xzf2.#a = this.SelectedAxialLoad;
			List<NavigationComboItem> source = #Gjb.#Ejb(this.#D, #Wdb, this.NavigationTable.#kjb().ToList<GridDataRowCore>());
			this.#h.Clear();
			this.#i.Clear();
			List<NavigationComboItem> list = source.GroupBy(new Func<NavigationComboItem, string>(LeftPanelViewModel.<>c.<>9.#qzf)).Select(new Func<IGrouping<string, NavigationComboItem>, NavigationComboItem>(LeftPanelViewModel.<>c.<>9.#rzf)).OrderBy(new Func<NavigationComboItem, double>(LeftPanelViewModel.<>c.<>9.#szf)).ToList<NavigationComboItem>();
			this.#i.AddRange(list);
			source = #Gjb.#Ejb(this.#D, #Wdb, this.NavigationTable.#kjb().ToList<GridDataRowCore>());
			List<NavigationComboItem> list2 = source.GroupBy(new Func<NavigationComboItem, string>(LeftPanelViewModel.<>c.<>9.#tzf)).Select(new Func<IGrouping<string, NavigationComboItem>, NavigationComboItem>(LeftPanelViewModel.<>c.<>9.#uzf)).OrderBy(new Func<NavigationComboItem, double>(LeftPanelViewModel.<>c.<>9.#vzf)).ToList<NavigationComboItem>();
			this.#h.AddRange(list2);
			this.SelectedAxialLoad = (((#xzf2.#a != null) ? list.FirstOrDefault(new Func<NavigationComboItem, bool>(#xzf2.#j6b)) : list.FirstOrDefault<NavigationComboItem>()) ?? list.FirstOrDefault<NavigationComboItem>());
			this.SelectedAngle = (((#xzf2.#b != null) ? list2.FirstOrDefault(new Func<NavigationComboItem, bool>(#xzf2.#k6b)) : list2.FirstOrDefault<NavigationComboItem>()) ?? list2.FirstOrDefault<NavigationComboItem>());
		}

		// Token: 0x060025F2 RID: 9714 RVA: 0x000239A3 File Offset: 0x00021BA3
		private void #3ib(#lte #Od)
		{
			this.SectionDimensionsLabel = #yPb.#xPb(#Od);
		}

		// Token: 0x17000CDD RID: 3293
		// (get) Token: 0x060025F3 RID: 9715 RVA: 0x000239BD File Offset: 0x00021BBD
		// (set) Token: 0x060025F4 RID: 9716 RVA: 0x000239C9 File Offset: 0x00021BC9
		public bool IsPropertiesTabVisible
		{
			get
			{
				return this.#5;
			}
			set
			{
				if (this.#5 != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361205));
					this.#5 = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361205));
				}
			}
		}

		// Token: 0x060025F5 RID: 9717 RVA: 0x000D572C File Offset: 0x000D392C
		private void #4ib(object #Ge, RoutedEventArgs #He)
		{
			if (this.#4)
			{
				return;
			}
			this.#4 = true;
			RadGridView element = this.NavigationTable.Renderer.RadGridView;
			ScrollViewer scrollViewer = element.GetChildrenOfType<ScrollViewer>().FirstOrDefault<ScrollViewer>();
			if (scrollViewer != null)
			{
				scrollViewer.ScrollChanged += this.#5ib;
			}
			List<Border> list = element.GetChildrenOfType<Border>().Where(new Func<Border, bool>(LeftPanelViewModel.<>c.<>9.#wzf)).ToList<Border>();
			if (list.Count == 1)
			{
				list[0].Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x060025F6 RID: 9718 RVA: 0x000D57E0 File Offset: 0x000D39E0
		private void #5ib(object #Ge, ScrollChangedEventArgs #He)
		{
			ScrollViewer scrollViewer = this.NavigationTable.Renderer.RadGridView.GetChildrenOfType<ScrollViewer>().First<ScrollViewer>();
			if (scrollViewer.ComputedVerticalScrollBarVisibility != Visibility.Visible)
			{
				this.NavigationTable.Renderer.RadGridView.BorderThickness = LeftPanelViewModel.#3;
				return;
			}
			this.NavigationTable.Renderer.RadGridView.BorderThickness = LeftPanelViewModel.#2;
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x00023A07 File Offset: 0x00021C07
		[CompilerGenerated]
		private void #pwf()
		{
			base.RaisePropertyChanged(#Phc.#3hc(107360855));
		}

		// Token: 0x060025F9 RID: 9721 RVA: 0x00023A25 File Offset: 0x00021C25
		[CompilerGenerated]
		private void #qwf()
		{
			base.RaisePropertyChanged(#Phc.#3hc(107360830));
		}

		// Token: 0x060025FA RID: 9722 RVA: 0x00023A43 File Offset: 0x00021C43
		[CompilerGenerated]
		private void #YVh()
		{
			this.NavigationTable.Renderer.#ihd(this.#J);
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x00023A67 File Offset: 0x00021C67
		[CompilerGenerated]
		private void #swf()
		{
			if (this.#J > 0.0)
			{
				this.#eib(this.#J);
			}
		}

		// Token: 0x060025FC RID: 9724 RVA: 0x00023A92 File Offset: 0x00021C92
		[CompilerGenerated]
		private bool #twf(NavigationComboItem #Rf)
		{
			return #Rf.AxialLoad < this.SelectedAxialLoadText;
		}

		// Token: 0x060025FD RID: 9725 RVA: 0x00023AAE File Offset: 0x00021CAE
		[CompilerGenerated]
		private bool #uwf(NavigationComboItem #Rf)
		{
			return #Rf.AxialLoad > this.SelectedAxialLoadText;
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x00023ACA File Offset: 0x00021CCA
		[CompilerGenerated]
		private bool #vwf(NavigationComboItem #Rf)
		{
			return #Rf.Angle < this.SelectedAngleText;
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x00023AE6 File Offset: 0x00021CE6
		[CompilerGenerated]
		private bool #wwf(NavigationComboItem #Rf)
		{
			return #Rf.Angle > this.SelectedAngleText;
		}

		// Token: 0x04000EC6 RID: 3782
		private readonly #tUd #a;

		// Token: 0x04000EC7 RID: 3783
		private readonly #Xgb #b;

		// Token: 0x04000EC8 RID: 3784
		private readonly #tbb #c;

		// Token: 0x04000EC9 RID: 3785
		private readonly #lB #d;

		// Token: 0x04000ECA RID: 3786
		private readonly List<PropertiesTableItemViewModel> #e = new List<PropertiesTableItemViewModel>();

		// Token: 0x04000ECB RID: 3787
		private readonly #Kjb #f = new #Kjb();

		// Token: 0x04000ECC RID: 3788
		private readonly #Cjb #g = new #Cjb();

		// Token: 0x04000ECD RID: 3789
		private readonly RadObservableCollection<NavigationComboItem> #h = new RadObservableCollection<NavigationComboItem>();

		// Token: 0x04000ECE RID: 3790
		private readonly RadObservableCollection<NavigationComboItem> #i = new RadObservableCollection<NavigationComboItem>();

		// Token: 0x04000ECF RID: 3791
		private readonly NonBlockingLock #j = new NonBlockingLock();

		// Token: 0x04000ED0 RID: 3792
		private BitmapSource #k;

		// Token: 0x04000ED1 RID: 3793
		private string #l;

		// Token: 0x04000ED2 RID: 3794
		private string #m;

		// Token: 0x04000ED3 RID: 3795
		private NavigationComboItem #n;

		// Token: 0x04000ED4 RID: 3796
		private NavigationComboItem #o;

		// Token: 0x04000ED5 RID: 3797
		private double #p;

		// Token: 0x04000ED6 RID: 3798
		private double #q;

		// Token: 0x04000ED7 RID: 3799
		private #lte #r;

		// Token: 0x04000ED8 RID: 3800
		private #hwe #s;

		// Token: 0x04000ED9 RID: 3801
		private bool #t;

		// Token: 0x04000EDA RID: 3802
		private bool #u;

		// Token: 0x04000EDB RID: 3803
		private bool #v;

		// Token: 0x04000EDC RID: 3804
		private bool #w;

		// Token: 0x04000EDD RID: 3805
		private bool #x;

		// Token: 0x04000EDE RID: 3806
		private IDiagramPresenterViewModel #y;

		// Token: 0x04000EDF RID: 3807
		private double #z;

		// Token: 0x04000EE0 RID: 3808
		private double #A;

		// Token: 0x04000EE1 RID: 3809
		private bool #B;

		// Token: 0x04000EE2 RID: 3810
		private bool #C;

		// Token: 0x04000EE3 RID: 3811
		private #Qpb #D;

		// Token: 0x04000EE4 RID: 3812
		private #Gse #E;

		// Token: 0x04000EE5 RID: 3813
		private bool #F = true;

		// Token: 0x04000EE6 RID: 3814
		private bool #G = true;

		// Token: 0x04000EE7 RID: 3815
		private bool #H;

		// Token: 0x04000EE8 RID: 3816
		private Visibility #I;

		// Token: 0x04000EE9 RID: 3817
		private double #J;

		// Token: 0x04000EEA RID: 3818
		[CompilerGenerated]
		private EventHandler<#pkb> #K;

		// Token: 0x04000EEB RID: 3819
		[CompilerGenerated]
		private EventHandler<#pkb> #L;

		// Token: 0x04000EEC RID: 3820
		[CompilerGenerated]
		private EventHandler<#lkb> #M;

		// Token: 0x04000EED RID: 3821
		[CompilerGenerated]
		private EventHandler #N;

		// Token: 0x04000EEE RID: 3822
		[CompilerGenerated]
		private QueryableCollectionView #O;

		// Token: 0x04000EEF RID: 3823
		[CompilerGenerated]
		private QueryableCollectionView #P;

		// Token: 0x04000EF0 RID: 3824
		[CompilerGenerated]
		private readonly DelegateCommand #Q;

		// Token: 0x04000EF1 RID: 3825
		[CompilerGenerated]
		private readonly DelegateCommand #R;

		// Token: 0x04000EF2 RID: 3826
		[CompilerGenerated]
		private readonly DelegateCommand #S;

		// Token: 0x04000EF3 RID: 3827
		[CompilerGenerated]
		private readonly DelegateCommand #T;

		// Token: 0x04000EF4 RID: 3828
		[CompilerGenerated]
		private readonly DelegateCommand #U;

		// Token: 0x04000EF5 RID: 3829
		[CompilerGenerated]
		private bool #V;

		// Token: 0x04000EF6 RID: 3830
		[CompilerGenerated]
		private PropertiesTableItemViewModel #W;

		// Token: 0x04000EF7 RID: 3831
		[CompilerGenerated]
		private readonly PropertiesTableItemViewModel #X;

		// Token: 0x04000EF8 RID: 3832
		[CompilerGenerated]
		private readonly DelegateCommand #Y;

		// Token: 0x04000EF9 RID: 3833
		[CompilerGenerated]
		private readonly DelegateCommand #Z;

		// Token: 0x04000EFA RID: 3834
		[CompilerGenerated]
		private readonly #mAe #0;

		// Token: 0x04000EFB RID: 3835
		[CompilerGenerated]
		private readonly #sib #1;

		// Token: 0x04000EFC RID: 3836
		private static readonly Thickness #2 = new Thickness(1.0);

		// Token: 0x04000EFD RID: 3837
		private static readonly Thickness #3 = new Thickness(1.0, 1.0, 0.0, 0.0);

		// Token: 0x04000EFE RID: 3838
		private bool #4;

		// Token: 0x04000EFF RID: 3839
		private bool #5;

		// Token: 0x02000419 RID: 1049
		[CompilerGenerated]
		private sealed class #xzf
		{
			// Token: 0x06002611 RID: 9745 RVA: 0x00023BD9 File Offset: 0x00021DD9
			internal bool #j6b(NavigationComboItem #Rf)
			{
				return #Rf.AxialLoadDisplayValue == this.#a.AxialLoadDisplayValue;
			}

			// Token: 0x06002612 RID: 9746 RVA: 0x00023BFD File Offset: 0x00021DFD
			internal bool #k6b(NavigationComboItem #Rf)
			{
				return #Rf.AngleDisplayValue == this.#b.AngleDisplayValue;
			}

			// Token: 0x04000F0F RID: 3855
			public NavigationComboItem #a;

			// Token: 0x04000F10 RID: 3856
			public NavigationComboItem #b;
		}
	}
}

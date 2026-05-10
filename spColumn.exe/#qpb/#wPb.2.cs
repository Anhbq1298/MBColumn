using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using #8xe;
using #eU;
using #ipb;
using #kB;
using #lH;
using #N6c;
using #Ted;
using #Wse;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Utils;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #qPb
{
	// Token: 0x020006A8 RID: 1704
	internal sealed class #wPb : #HH<#pPb>, INotifyPropertyChanged, IViewModel, IViewModel<#pPb>, #sPb
	{
		// Token: 0x060038EB RID: 14571 RVA: 0x00110870 File Offset: 0x0010EA70
		public #wPb(Lazy<#pPb> #Ee, IExtendedServices #0c, #lB #oj) : base(#Ee, #0c)
		{
			this.#a = #0c;
			this.#b = #oj;
			base.Services.MessageBus.DefinitionChangesCommitted += this.#owb;
			base.Project.ModelChanged += this.#cl;
			base.Services.MessageBus.UnitSystemChanged += this.#EO;
			base.Services.MessageBus.SolveCompleted += this.#Ch;
		}

		// Token: 0x17001184 RID: 4484
		// (get) Token: 0x060038EC RID: 14572 RVA: 0x000317DC File Offset: 0x0002F9DC
		// (set) Token: 0x060038ED RID: 14573 RVA: 0x000317E8 File Offset: 0x0002F9E8
		public ObservableCollection<PropertiesTableItemViewModel> PropertiesTableItems { get; private set; }

		// Token: 0x17001185 RID: 4485
		// (get) Token: 0x060038EE RID: 14574 RVA: 0x000317F9 File Offset: 0x0002F9F9
		// (set) Token: 0x060038EF RID: 14575 RVA: 0x0011090C File Offset: 0x0010EB0C
		public bool IsVisible
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107351275));
					this.#e = value;
					base.Services.ToolsContext.ToolsBlockedByPropertiesPanel = value;
					this.#a.Renderer.#cg();
					this.#uPb();
					base.RaisePropertyChanged(#Phc.#3hc(107351275));
				}
			}
		}

		// Token: 0x17001186 RID: 4486
		// (get) Token: 0x060038F0 RID: 14576 RVA: 0x00031805 File Offset: 0x0002FA05
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x0011097C File Offset: 0x0010EB7C
		public void #vBf()
		{
			#wPb.#rWb #rWb = new #wPb.#rWb();
			#rWb.#a = this;
			if (!this.IsVisible)
			{
				return;
			}
			#rWb.#b = this.#b.#1Th(false);
			if (#rWb.#b != null)
			{
				byte[] #c2d = #Y7c.#BBf(ColumnModelHelper.#tBf(#rWb.#b.Input));
				if (ListExtensions.#uC<byte>(#c2d, this.#f))
				{
					return;
				}
				this.#f = #c2d;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#rWb.#zBf));
			}
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x00110A14 File Offset: 0x0010EC14
		protected override void #uh(#pPb #Ee)
		{
			base.#uh(#Ee);
			#mpb #mpb = new #mpb();
			this.PropertiesTableItems = new ObservableCollection<PropertiesTableItemViewModel>
			{
				this.#Fib(Strings.StringGeneralInformation_UPPER, #mpb.GeneralInformationSubtable, Visibility.Collapsed),
				this.#Fib(Strings.StringConcreteProperties_Upper, #mpb.MaterialPropertiesConcrete, Visibility.Collapsed),
				this.#Fib(Strings.StringSteelProperties_UPPER, #mpb.MaterialPropertiesSteel, Visibility.Collapsed),
				this.#Fib(Strings.StringSectionProperties_UPPER, #mpb.SectionShapeAndProperties, Visibility.Collapsed),
				this.#Fib(Strings.StringReinforcement_UPPER, #mpb.ReinforcementProperties, Visibility.Collapsed),
				this.#d = this.#Fib(Strings.StringSlenderness_UPPER, #mpb.SlendernessPropertiesSpecialTable, Visibility.Collapsed)
			};
			this.#c.AddRange(this.PropertiesTableItems);
			this.#d.Margin = new Thickness(0.0, 20.0, 0.0, 20.0);
			SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 237, 237, 241));
			SolidColorBrush solidColorBrush2 = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 227, 228, 230));
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#c)
			{
				propertiesTableItemViewModel.Renderer.RadGridView.SelectionMode = SelectionMode.Single;
				propertiesTableItemViewModel.Renderer.RadGridView.CanUserSelect = false;
				propertiesTableItemViewModel.Renderer.RadGridView.BorderBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.HorizontalGridLinesBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.VerticalGridLinesBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.RadGridView.BorderThickness = new Thickness(1.0, 0.0, 0.0, 0.0);
				propertiesTableItemViewModel.Renderer.RadGridView.Margin = new Thickness(0.0, -1.0, 0.0, 0.0);
				propertiesTableItemViewModel.Renderer.GridRenderer.HeaderBorderBrush = solidColorBrush2;
				propertiesTableItemViewModel.Renderer.GridRenderer.HeaderBackgroundBrush = solidColorBrush;
				propertiesTableItemViewModel.Renderer.GridRenderer.Margin = 0.0;
				propertiesTableItemViewModel.Renderer.GridRenderer.ColumnWidthFactor = 0.9;
				propertiesTableItemViewModel.Renderer.GridRenderer.RenderMode = #Igd.#a;
				propertiesTableItemViewModel.Renderer.GridRenderer.ReuseRows = true;
			}
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x00110D10 File Offset: 0x0010EF10
		public void #hz(#lte #Wdb)
		{
			if (!#Wdb.Input.Options.ConsiderSlenderness)
			{
				this.#d.IsExpanded = false;
			}
			this.#d.IsEnabled = #Wdb.Input.Options.ConsiderSlenderness;
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#c)
			{
				propertiesTableItemViewModel.Renderer.RequiresRefresh = true;
				#hpb #xS = new #hpb((#mpb)propertiesTableItemViewModel.DocumentContentOptions, #Wdb);
				#dye #dye = new #dye(propertiesTableItemViewModel.Renderer.GridRenderer, #xS);
				#dye.CriticalItemsOptions = new #0ed();
				propertiesTableItemViewModel.Renderer.#ghd(#dye);
			}
			double actualWidth = base.View.ActualWidth;
			if (actualWidth > 0.0)
			{
				this.#eib(actualWidth);
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#wBf));
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x00110E30 File Offset: 0x0010F030
		public void #eib(double #6Q)
		{
			if (#6Q <= 0.0)
			{
				return;
			}
			foreach (PropertiesTableItemViewModel propertiesTableItemViewModel in this.#c)
			{
				propertiesTableItemViewModel.Renderer.#ihd(#6Q);
			}
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x00031815 File Offset: 0x0002FA15
		private void #Ch(object #Ge, #fW #He)
		{
			this.#uPb();
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x00031825 File Offset: 0x0002FA25
		private void #EO(object #Ge, EventArgs #He)
		{
			if (!base.View.IsVisible)
			{
				return;
			}
			this.#uPb();
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x00031847 File Offset: 0x0002FA47
		private void #cl(object #Ge, #7V #He)
		{
			if (!#He.IsUndoRedo)
			{
				this.IsVisible = false;
			}
		}

		// Token: 0x060038F8 RID: 14584 RVA: 0x00031825 File Offset: 0x0002FA25
		private void #owb(object #Ge, EventArgs #He)
		{
			if (!base.View.IsVisible)
			{
				return;
			}
			this.#uPb();
		}

		// Token: 0x060038F9 RID: 14585 RVA: 0x00110EA4 File Offset: 0x0010F0A4
		private void #uPb()
		{
			#wPb.#ETb #ETb = new #wPb.#ETb();
			#ETb.#a = this;
			if (!this.IsVisible)
			{
				return;
			}
			#ETb.#b = this.#b.#1Th(false);
			if (#ETb.#b != null)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#ETb.#4cc));
			}
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x000D48CC File Offset: 0x000D2ACC
		private PropertiesTableItemViewModel #Fib(string #wy, Option #bA, Visibility #Gib = Visibility.Collapsed)
		{
			PropertiesTableItemViewModel propertiesTableItemViewModel = new PropertiesTableItemViewModel(#wy, #bA, true, #Gib);
			#mpb #5d = new #mpb();
			ReportOptionsHelper.#xdd<#mpb>(#5d, #bA);
			propertiesTableItemViewModel.DocumentContentOptions = #5d;
			return propertiesTableItemViewModel;
		}

		// Token: 0x060038FB RID: 14587 RVA: 0x00031864 File Offset: 0x0002FA64
		[CompilerGenerated]
		private void #wBf()
		{
			this.#eib(base.View.ActualWidth);
		}

		// Token: 0x040017DC RID: 6108
		private readonly IExtendedServices #a;

		// Token: 0x040017DD RID: 6109
		private readonly #lB #b;

		// Token: 0x040017DE RID: 6110
		private readonly List<PropertiesTableItemViewModel> #c = new List<PropertiesTableItemViewModel>();

		// Token: 0x040017DF RID: 6111
		private PropertiesTableItemViewModel #d;

		// Token: 0x040017E0 RID: 6112
		private bool #e;

		// Token: 0x040017E1 RID: 6113
		private byte[] #f;

		// Token: 0x040017E2 RID: 6114
		[CompilerGenerated]
		private ObservableCollection<PropertiesTableItemViewModel> #g;

		// Token: 0x020006A9 RID: 1705
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x060038FD RID: 14589 RVA: 0x00031883 File Offset: 0x0002FA83
			internal void #zBf()
			{
				this.#a.#hz(this.#b);
			}

			// Token: 0x040017E3 RID: 6115
			public #wPb #a;

			// Token: 0x040017E4 RID: 6116
			public #lte #b;
		}

		// Token: 0x020006AA RID: 1706
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x060038FF RID: 14591 RVA: 0x000318A2 File Offset: 0x0002FAA2
			internal void #4cc()
			{
				this.#a.#hz(this.#b);
			}

			// Token: 0x040017E5 RID: 6117
			public #wPb #a;

			// Token: 0x040017E6 RID: 6118
			public #lte #b;
		}
	}
}

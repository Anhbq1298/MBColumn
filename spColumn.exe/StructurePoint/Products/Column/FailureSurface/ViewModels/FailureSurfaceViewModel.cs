using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using #3vb;
using #6re;
using #7hc;
using #Cqb;
using #cYd;
using #eU;
using #lH;
using #LQc;
using #Mbb;
using #rCe;
using #S9;
using #sUd;
using #u3d;
using #vmb;
using #Vob;
using #Wse;
using #xBe;
using #Xc;
using #Zjb;
using #Zmb;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.SPColumn.Diagrams2D3D;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Core;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.FailureSurface.Tools;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x0200040B RID: 1035
	internal sealed class FailureSurfaceViewModel : #HH<IFailureSurfaceView>, INotifyPropertyChanged, IViewModel<IFailureSurfaceView>, IViewModel, #Kgb, #Wgb
	{
		// Token: 0x06002468 RID: 9320 RVA: 0x000CF7F4 File Offset: 0x000CD9F4
		public FailureSurfaceViewModel(ICoreServices services, Lazy<IFailureSurfaceView> view, #zU guiController, #yBe diagramExporter, IDrawingResultsFactory drawingResultsFactory, IEventManagerFactory eventManagerFactory, #Ke viewportHost, #tUd exceptionHandler, #tbb context) : base(view, services)
		{
			this.#h = guiController;
			this.#i = diagramExporter;
			this.#j = viewportHost;
			this.#l = exceptionHandler;
			this.#m = context;
			this.#d = services.DialogService;
			this.#g = new #umb();
			this.#f = new #Bqb(new DefaultCommandFactory());
			this.#k = new ModelVisualizationController(services, this.#g, view.Value, this.#f, guiController, drawingResultsFactory, eventManagerFactory, context);
			this.#k.PropertyChanged += this.#dfb;
			this.#f.ShowHideFactoredSurfaceCommand.SetCommand(new Action(this.#9fb), new Func<bool>(this.#6fb));
			this.#f.HideFactoredSurfaceCommand.SetCommand(new Action(this.#bgb), new Func<bool>(this.#agb));
			this.#f.ShowHideNominalSurfaceCommand.SetCommand(new Action(this.#3fb), new Func<bool>(this.#2fb));
			this.#f.HideNominalSurfaceCommand.SetCommand(new Action(this.#5fb), new Func<bool>(this.#4fb));
			this.#f.ShowHideMxMyPlaneCommand.SetCommand(new Action(this.#cgb));
			this.#f.ShowHideMyPPlaneCommand.SetCommand(new Action(this.#dgb));
			this.#f.ShowHidePMxPlaneCommand.SetCommand(new Action(this.#egb));
			this.#f.ShowHideMainAxesCommand.SetCommand(new Action(this.#fgb));
			this.#f.ShowHideCoordinateSystemCommand.SetCommand(new Action(this.#ggb));
			this.#f.ShowBaseVisualizationCommand.SetCommand(new Action(this.#1fb));
			this.#f.ShowCrossSectionCommand.SetCommand(new Action(this.#Xfb));
			this.#f.RemoveSurfacesFromVisualizationCommand.SetCommand(new Action(this.#Wfb));
			this.#f.ShowHideLoadPointsCommand.SetCommand(new Action(this.#hgb));
			this.#f.ShowHideEditorToolsCommand.SetCommand(new Action(this.#igb));
			this.#f.RefreshVisibilityCommand.SetCommand(new Action(this.#Efb));
			this.#e = view.Value.ModelEditorControl;
			this.#kgb();
			this.#p = #cfb.#a;
			this.#e.SuspendEventsChanged += this.#Ifb;
			this.#e.ViewControls.Panel2D3DVisibilityItemsVisibility = Visibility.Collapsed;
			this.#e.ViewControls.CloseMenuItemClicked += this.#ccb;
			this.#e.CustomButtonBasicModeCursor = StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.MoveVerticalPlane;
			this.#e.CustomButtonAlternateModeCursor = StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.MoveHorizontalPlane;
			view.Value.DataContext = this;
			#Qmb #Qmb = new #Qmb(this, base.View.ModelEditorControl, new DefaultDrawingResultsFactory(), new ResourcesHelper(), this.#g, this.#h, services.Settings, this.#f, new DefaultCommandFactory(), base.Services.DialogService, services.ApplicationInfo, base.Services.WindowLocator);
			CreateHorizontalCrossSectionManager createHorizontalCrossSectionManager = new CreateHorizontalCrossSectionManager(services.Settings);
			this.#a = new CreateHorizontalCrossSectionTool(#Qmb, services.Settings, this.#f, createHorizontalCrossSectionManager);
			this.#a.AxialLoadChanged += this.#ngb;
			this.#a.AxialLoadChanging += this.#ogb;
			CreateVerticalCrossSectionManager createVerticalCrossSectionManager = new CreateVerticalCrossSectionManager(#Qmb, services.Settings);
			this.#b = new CreateVerticalCrossSectionTool(#Qmb, services.Settings, this.#f, createVerticalCrossSectionManager);
			this.#b.AngleChanging += this.#pgb;
			this.#b.AngleChanged += this.#qgb;
			this.#c = new #Xmb(#Qmb, services.Settings);
			this.#k.LoadPointClickedEventArgs += this.#rgb;
			base.View.ModelEditorControl.ViewControls.MouseEnter += this.#Hfb;
			this.#v = new DefaultDrawingResultsFactory().CreateBoxDrawingResult();
			this.#g.TransparentBox = this.#v;
			((FrameworkElement)base.View).KeyDown += this.#sgb;
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x00022BBD File Offset: 0x00020DBD
		private void #dfb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (#He.PropertyName == #Phc.#3hc(107362172))
			{
				base.RaisePropertyChanged(#Phc.#3hc(107362139));
			}
		}

		// Token: 0x14000093 RID: 147
		// (add) Token: 0x0600246A RID: 9322 RVA: 0x000CFC94 File Offset: 0x000CDE94
		// (remove) Token: 0x0600246B RID: 9323 RVA: 0x000CFCD8 File Offset: 0x000CDED8
		public event EventHandler<#pkb> AxialLoadChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#w;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#w, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#w;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#w, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000094 RID: 148
		// (add) Token: 0x0600246C RID: 9324 RVA: 0x000CFD1C File Offset: 0x000CDF1C
		// (remove) Token: 0x0600246D RID: 9325 RVA: 0x000CFD60 File Offset: 0x000CDF60
		public event EventHandler<#pkb> AngleChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#x;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#x;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000095 RID: 149
		// (add) Token: 0x0600246E RID: 9326 RVA: 0x000CFDA4 File Offset: 0x000CDFA4
		// (remove) Token: 0x0600246F RID: 9327 RVA: 0x000CFDE8 File Offset: 0x000CDFE8
		public event EventHandler<#pkb> AxialLoadChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#y;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#y, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#y;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#y, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000096 RID: 150
		// (add) Token: 0x06002470 RID: 9328 RVA: 0x000CFE2C File Offset: 0x000CE02C
		// (remove) Token: 0x06002471 RID: 9329 RVA: 0x000CFE70 File Offset: 0x000CE070
		public event EventHandler<#pkb> AngleChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#z;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#z, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#z;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#z, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000097 RID: 151
		// (add) Token: 0x06002472 RID: 9330 RVA: 0x000CFEB4 File Offset: 0x000CE0B4
		// (remove) Token: 0x06002473 RID: 9331 RVA: 0x000CFEF8 File Offset: 0x000CE0F8
		public event EventHandler<#Yjb> LoadPointClickedEventArgs
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Yjb> eventHandler = this.#A;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#A, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Yjb> eventHandler = this.#A;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#A, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000098 RID: 152
		// (add) Token: 0x06002474 RID: 9332 RVA: 0x000CFF3C File Offset: 0x000CE13C
		// (remove) Token: 0x06002475 RID: 9333 RVA: 0x000CFF80 File Offset: 0x000CE180
		public event EventHandler ViewControlsClosed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#B;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#B, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#B;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#B, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000C73 RID: 3187
		// (get) Token: 0x06002476 RID: 9334 RVA: 0x00022BF2 File Offset: 0x00020DF2
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000C74 RID: 3188
		// (get) Token: 0x06002477 RID: 9335 RVA: 0x00022C02 File Offset: 0x00020E02
		// (set) Token: 0x06002478 RID: 9336 RVA: 0x00022C0E File Offset: 0x00020E0E
		public double ViewTitleFontSize
		{
			get
			{
				return this.#u;
			}
			private set
			{
				if (this.#u != value)
				{
					this.#u = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362094));
				}
			}
		}

		// Token: 0x17000C75 RID: 3189
		// (get) Token: 0x06002479 RID: 9337 RVA: 0x000CFFC4 File Offset: 0x000CE1C4
		public string ViewTitle
		{
			get
			{
				#lte #lte = this.CurrentReportingModel;
				this.#Ofb();
				string text = string.Empty;
				if (!string.IsNullOrWhiteSpace(this.#k.LoadPointsCountMessage))
				{
					text = Environment.NewLine + this.#k.LoadPointsCountMessage;
				}
				if (#lte != null && this.#o == Diagram3DCutType.#b)
				{
					return string.Concat(new string[]
					{
						#Phc.#3hc(107362101),
						this.CutParameter.ToString(#Phc.#3hc(107362056), CultureInfo.CurrentCulture),
						#Phc.#3hc(107362051),
						#lte.GeneralInfo.UnitStringF,
						#Phc.#3hc(107362078),
						text
					});
				}
				if (#lte != null && this.#o == Diagram3DCutType.#c)
				{
					return #Phc.#3hc(107362073) + this.CutParameter.ToString(#Phc.#3hc(107362056), CultureInfo.CurrentCulture) + #Phc.#3hc(107362064) + text;
				}
				return string.Empty;
			}
		}

		// Token: 0x17000C76 RID: 3190
		// (get) Token: 0x0600247A RID: 9338 RVA: 0x00022C3C File Offset: 0x00020E3C
		// (set) Token: 0x0600247B RID: 9339 RVA: 0x00022C48 File Offset: 0x00020E48
		public bool SuspendEvents
		{
			get
			{
				return this.#r;
			}
			set
			{
				if (this.#r != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361511));
					this.#r = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361511));
				}
			}
		}

		// Token: 0x17000C77 RID: 3191
		// (get) Token: 0x0600247C RID: 9340 RVA: 0x00022C86 File Offset: 0x00020E86
		// (set) Token: 0x0600247D RID: 9341 RVA: 0x00022C92 File Offset: 0x00020E92
		public Visibility ViewControlsPanelVisibility
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361522));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361522));
				}
			}
		}

		// Token: 0x17000C78 RID: 3192
		// (get) Token: 0x0600247E RID: 9342 RVA: 0x00022CD0 File Offset: 0x00020ED0
		// (set) Token: 0x0600247F RID: 9343 RVA: 0x000D00E4 File Offset: 0x000CE2E4
		public FailureSurface FailureSurface
		{
			get
			{
				return this.#s;
			}
			private set
			{
				if (this.FailureSurface != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361453));
					this.#s = value;
					this.#Pfb();
					base.RaisePropertyChanged(#Phc.#3hc(107361453));
				}
			}
		}

		// Token: 0x17000C79 RID: 3193
		// (get) Token: 0x06002480 RID: 9344 RVA: 0x00022CDC File Offset: 0x00020EDC
		// (set) Token: 0x06002481 RID: 9345 RVA: 0x00022CE8 File Offset: 0x00020EE8
		public #lte CurrentReportingModel { get; set; }

		// Token: 0x17000C7A RID: 3194
		// (get) Token: 0x06002482 RID: 9346 RVA: 0x00022CF9 File Offset: 0x00020EF9
		// (set) Token: 0x06002483 RID: 9347 RVA: 0x00022D05 File Offset: 0x00020F05
		public bool IsLoaded { get; private set; }

		// Token: 0x17000C7B RID: 3195
		// (get) Token: 0x06002484 RID: 9348 RVA: 0x00022D16 File Offset: 0x00020F16
		// (set) Token: 0x06002485 RID: 9349 RVA: 0x00022D22 File Offset: 0x00020F22
		private double CutParameter
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
					this.#Pfb();
					base.RaisePropertyChanged(#Phc.#3hc(107361464));
				}
			}
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x000D0134 File Offset: 0x000CE334
		public void #tfb()
		{
			if (this.#e.Panel3DCustomButton1.IsChecked.GetValueOrDefault())
			{
				if (this.#a.IsActive)
				{
					this.#a.#tfb();
				}
				if (this.#b.IsActive)
				{
					this.#b.#tfb();
				}
			}
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x00022D56 File Offset: 0x00020F56
		public void #ufb()
		{
			this.#e.CameraDistance += 1.0;
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x00022D7B File Offset: 0x00020F7B
		public void #Mdb(IList<SelectedLoadData> #tk)
		{
			this.#k.#hrb(#tk);
			this.#Ufb();
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x00022D9B File Offset: 0x00020F9B
		public void #Xbb()
		{
			this.#e.ResetToDefaultViewCubePosition();
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x00022DB0 File Offset: 0x00020FB0
		public void #vfb()
		{
			if (this.#o == Diagram3DCutType.#b)
			{
				CreateHorizontalCrossSectionTool createHorizontalCrossSectionTool = this.#a;
				if (!false)
				{
					createHorizontalCrossSectionTool.#vfb();
				}
				return;
			}
			if (this.#o == Diagram3DCutType.#c)
			{
				this.#b.#vfb();
			}
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x00022DE9 File Offset: 0x00020FE9
		public void #wfb(#xbb #xfb, #ybb #yfb)
		{
			this.#a.PartToCut = #xfb;
			this.#b.PartToCut = #yfb;
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x000D0198 File Offset: 0x000CE398
		public void #zfb(double #f, bool #Afb)
		{
			if (this.#o == Diagram3DCutType.#b)
			{
				this.#a.#Zkb(#f);
				if (#Afb)
				{
					this.#a.#Ikb();
				}
			}
			else if (this.#o == Diagram3DCutType.#c)
			{
				this.#b.#Klb(#f);
				if (#Afb)
				{
					this.#b.#Ikb();
				}
			}
			this.CutParameter = #f;
			this.#Pfb();
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x000D0208 File Offset: 0x000CE408
		public void #Bfb(Diagram3DCutType #Odb)
		{
			if (this.#o == #Odb)
			{
				return;
			}
			this.#c.#0kb();
			if (this.#o == Diagram3DCutType.#b)
			{
				this.#a.#0kb();
			}
			if (this.#o == Diagram3DCutType.#c)
			{
				this.#b.#0kb();
			}
			if (this.#o == Diagram3DCutType.#a)
			{
				this.#c.#0kb();
			}
			this.#o = #Odb;
			this.#e.Panel3DCustomButton1.IsEnabled = (#Odb != Diagram3DCutType.#a && base.Services.Settings.ShowNominalOrFactored);
			switch (#Odb)
			{
			case Diagram3DCutType.#a:
				this.#c.#5b();
				break;
			case Diagram3DCutType.#b:
				this.#a.#5b();
				this.#e.Panel3DCustomButton1.Content = this.#b.FailureSurfaceToolContext.ResourcesHelper.ImageFromResourceBitmap(Diagram2D3DIcons.GuidePlane_MM_24x24);
				if (this.#a.AllowFreePlaneControl)
				{
					this.#e.SetMouseCameraControllerCursorMoveVertically();
				}
				break;
			case Diagram3DCutType.#c:
				this.#b.#5b();
				this.#e.Panel3DCustomButton1.Content = this.#b.FailureSurfaceToolContext.ResourcesHelper.ImageFromResourceBitmap(Diagram2D3DIcons.GuidePlane_PM_24x24);
				if (this.#b.AllowFreePlaneControl)
				{
					this.#e.SetMouseCameraControllerCursorMoveHorizontally();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107361415), #Odb, null);
			}
			this.#Pfb();
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x000D0394 File Offset: 0x000CE594
		public void #Cfb(#lte #Od)
		{
			if (((#Od != null) ? #Od.FailureSurface : null) == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#n.#yl();
			this.#n.Diagram3D = #Od.FailureSurface;
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				bool flag = this.#c.IsActive || this.#o == Diagram3DCutType.#a;
				try
				{
					if (flag)
					{
						this.#c.#0kb();
					}
					this.#k.EventManager.ClearAllEventSources();
					this.#k.EventManager.ClearAllExcludedVisuals3D();
					this.#p = #cfb.#a;
					this.#k.#nrb();
					this.#k.#lrb();
					this.#k.#irb(#Od);
					this.FailureSurface = this.#g.FailureSurface;
					this.#h.EditorStatusBar.Diagram3D.#yl();
					if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
					{
						this.#8fb(null);
					}
					this.#mgb();
					this.#Ufb();
					this.IsLoaded = true;
				}
				catch (Exception #ob)
				{
					this.#d.#od(base.MainWindow, Strings.StringAnUnknownErrorOccrued.#z2d(true) + #sYd.#oYd(#ob), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				}
				finally
				{
					this.#jgb();
					this.#lgb();
					this.#Efb();
					this.#e.CameraType = base.Services.Settings.CameraType;
					this.#f.RefreshRibbonToolbar.Execute();
					this.#g.#omb(new EventArgs());
					if (flag)
					{
						this.#c.#5b();
					}
				}
			}
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x000D05B4 File Offset: 0x000CE7B4
		public void #yl()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				FailureSurface failureSurface = this.FailureSurface;
				if (failureSurface != null)
				{
					failureSurface.#yl();
				}
				base.View.ModelEditorControl.ResetLinesUpdater();
				this.#g.#pmb(EventArgs.Empty);
			}
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x00022E0F File Offset: 0x0002100F
		public void #Dfb()
		{
			this.#k.#xrb();
			this.#mgb();
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x000D0634 File Offset: 0x000CE834
		public void #GVh()
		{
			this.#e.CubePanelVisibility = (this.#j.Pane.IsActive && base.Services.Settings.Show3dRotationCube).ToVisibility();
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x000D0684 File Offset: 0x000CE884
		public void #Efb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				this.#e.CubePanelVisibility = (this.#j.Pane.IsActive && base.Services.Settings.Show3dRotationCube).ToVisibility();
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				else
				{
					this.#k.#nrb();
					this.#g.#tmb(new EventArgs());
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				else
				{
					this.#k.#lrb();
					this.#g.#tmb(new EventArgs());
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				else
				{
					this.#k.#qrb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#orb();
					this.#k.#rrb();
				}
				else
				{
					this.#k.#srb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				else
				{
					this.#7fb();
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				else
				{
					this.#k.#vrb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				else
				{
					this.#k.#vrb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				else
				{
					this.#k.#vrb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				this.#k.#wrb();
				this.#Ufb();
			}
			this.#Pfb();
			this.#Vfb();
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x000D08E4 File Offset: 0x000CEAE4
		public void #1bb(#lte #Od, ExportDiagramType #2bb)
		{
			try
			{
				bool flag = this.#i.#LAe(#Od, this.#n, #2bb);
				if (flag)
				{
					base.DialogService.#od(Strings.StringDiagramExportedSuccesfully.#z2d(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
			catch (Exception #ob)
			{
				this.#l.#3Ab(#ob);
			}
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x000D0950 File Offset: 0x000CEB50
		public bool #3bb(ExportDiagramType #2bb)
		{
			#qCe #Gfb = this.#n;
			return FailureSurfaceViewModel.#Ffb(#2bb, #Gfb);
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x000D0978 File Offset: 0x000CEB78
		public static bool #Ffb(ExportDiagramType #2bb, #qCe #Gfb)
		{
			if (#2bb != ExportDiagramType.Nominal)
			{
				return #2bb == ExportDiagramType.Factored && (#Gfb.Diagram3D != null && #Gfb.Diagram3D.FactoredFailureSurfaceData != null) && #Gfb.Diagram3D.FactoredFailureSurfaceData.Any<FailureSurfaceData>();
			}
			return #Gfb.Diagram3D != null && #Gfb.Diagram3D.NominalFailureSurfaceData != null && #Gfb.Diagram3D.NominalFailureSurfaceData.Any<FailureSurfaceData>();
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x000D09EC File Offset: 0x000CEBEC
		public bool #Wbb()
		{
			bool result = false;
			if (this.#e.Rotate3DButton.IsChecked.GetValueOrDefault())
			{
				this.#e.DisableRotate3DMode();
				result = true;
			}
			if (this.#e.Panel3DCustomButton1.IsChecked.GetValueOrDefault())
			{
				this.#e.Panel3DCustomButton1.IsChecked = new bool?(false);
				this.#Kfb(this.#e.Panel3DCustomButton1, null);
				result = true;
			}
			if (this.#e.ZoomToWindowButton.IsChecked.GetValueOrDefault())
			{
				this.#e.DisableZoomToWindowMode(true);
				result = true;
			}
			if (this.#e.TranslateButton.IsChecked.GetValueOrDefault())
			{
				this.#e.DisablePanMode();
				result = true;
			}
			return result;
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x00022E2E File Offset: 0x0002102E
		public void #Vbb()
		{
			this.#e.CleanupOnClose();
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x000D0AD8 File Offset: 0x000CECD8
		protected void #0db(#pkb #He)
		{
			this.CutParameter = #He.Value;
			this.#Pfb();
			this.#Zdb(#He);
			EventHandler<#pkb> eventHandler = this.#x;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x000D0B1C File Offset: 0x000CED1C
		protected void #1db(#pkb #He)
		{
			this.CutParameter = #He.Value;
			this.#Pfb();
			this.#Ydb(#He);
			EventHandler<#pkb> eventHandler = this.#w;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x000D0B60 File Offset: 0x000CED60
		protected void #Ydb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#y;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x000D0B8C File Offset: 0x000CED8C
		protected void #Zdb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#z;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x000D0BB8 File Offset: 0x000CEDB8
		protected void #2db(#Yjb #He)
		{
			EventHandler<#Yjb> eventHandler = this.#A;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
			this.#Ufb();
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x000D0BEC File Offset: 0x000CEDEC
		protected void #acb()
		{
			EventHandler eventHandler = this.#B;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x000D0C1C File Offset: 0x000CEE1C
		private void #Hfb(object #Ge, MouseEventArgs #He)
		{
			if (#He.LeftButton == MouseButtonState.Pressed)
			{
				if (this.#b.IsActive)
				{
					this.#b.#tfb();
				}
				if (this.#a.IsActive)
				{
					this.#a.#tfb();
				}
			}
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x00022E43 File Offset: 0x00021043
		private void #ccb(object #Ge, RadRoutedEventArgs #He)
		{
			this.#acb();
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x00022E53 File Offset: 0x00021053
		private void #Ifb(object #Ge, RoutedEventArgs #He)
		{
			this.SuspendEvents = this.#e.SuspendEvents;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x00022E72 File Offset: 0x00021072
		private void #Jfb(object #Ge, RoutedEventArgs #He)
		{
			this.#e.Panel3DCustomButton1.IsChecked = new bool?(false);
			this.#Kfb(this.#e.Panel3DCustomButton1, null);
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x00022EA8 File Offset: 0x000210A8
		private void #Kfb(object #Ge, RoutedEventArgs #He)
		{
			this.#e.RestoreMouseCameraControllerCursor();
			this.#a.AllowFreePlaneControl = false;
			this.#b.AllowFreePlaneControl = false;
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x000D0C70 File Offset: 0x000CEE70
		private void #Lfb(object #Ge, RoutedEventArgs #He)
		{
			this.#e.DisableRotate3DMode();
			this.#e.DisablePanMode();
			if (this.#a.IsActive)
			{
				this.#e.SetMouseCameraControllerCursorMoveVertically();
			}
			else if (this.#b.IsActive)
			{
				this.#e.SetMouseCameraControllerCursorMoveHorizontally();
			}
			this.#a.AllowFreePlaneControl = true;
			this.#b.AllowFreePlaneControl = true;
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x00022ED9 File Offset: 0x000210D9
		private void #Mfb(object #Ge, RoutedEventArgs #He)
		{
			this.#e.Panel3DCustomButton1.IsChecked = new bool?(false);
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x00022EFD File Offset: 0x000210FD
		private void #Nfb()
		{
			this.#k.#Nfb();
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x000D0CEC File Offset: 0x000CEEEC
		private void #Ofb()
		{
			#5re #5re = base.Services.ReporterSettings.#jJ();
			float num = #5re.TextSize;
			float num2 = num * 96f / 72f;
			this.ViewTitleFontSize = (double)num2;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x000D0D34 File Offset: 0x000CEF34
		private void #Pfb()
		{
			base.RaisePropertyChanged<string>(System.Linq.Expressions.Expression.Lambda<Func<string>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(FailureSurfaceViewModel)), methodof(FailureSurfaceViewModel.#gfb())), Array.Empty<ParameterExpression>()));
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x00022F12 File Offset: 0x00021112
		private void #Qfb(List<IDrawingResult> #Rfb, #apb #Sfb, bool #Tfb)
		{
			if (#Sfb == null || !#Tfb)
			{
				return;
			}
			#Rfb.Add(#Sfb.FailureSurface);
			#Rfb.AddRange(#Sfb.Wireframe);
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x000D0D84 File Offset: 0x000CEF84
		private void #Ufb()
		{
			this.#k.EventManager.ClearAllExcludedVisuals3D();
			List<IDrawingResult> list = new List<IDrawingResult>();
			if (this.#p == #cfb.#a)
			{
				List<IDrawingResult> #Rfb = list;
				FailureSurface failureSurface = this.#g.FailureSurface;
				this.#Qfb(#Rfb, (failureSurface != null) ? failureSurface.NominalSurface : null, base.Services.Settings.ShowNominal);
				List<IDrawingResult> #Rfb2 = list;
				FailureSurface failureSurface2 = this.#g.FailureSurface;
				this.#Qfb(#Rfb2, (failureSurface2 != null) ? failureSurface2.FactoredSurface : null, base.Services.Settings.ShowFactored);
			}
			else
			{
				List<IDrawingResult> #Rfb3 = list;
				FailureSurface failureSurface3 = this.#g.FailureSurface;
				this.#Qfb(#Rfb3, (failureSurface3 != null) ? failureSurface3.NominalCrossSectionSurface : null, base.Services.Settings.ShowNominal);
				List<IDrawingResult> #Rfb4 = list;
				FailureSurface failureSurface4 = this.#g.FailureSurface;
				this.#Qfb(#Rfb4, (failureSurface4 != null) ? failureSurface4.FactoredCrossSectionSurface : null, base.Services.Settings.ShowFactored);
			}
			if (this.#k.PlaneMxMy != null)
			{
				list.AddRange(this.#k.PlaneMxMy);
			}
			if (this.#k.PlaneMyP != null)
			{
				list.AddRange(this.#k.PlaneMyP);
			}
			if (this.#k.PlanePMx != null)
			{
				list.AddRange(this.#k.PlanePMx);
			}
			foreach (IDrawingResult drawingResult in list.Where(new Func<IDrawingResult, bool>(FailureSurfaceViewModel.<>c.<>9.#E0h)))
			{
				this.#k.EventManager.RegisterExcludedVisual3D(drawingResult);
			}
			this.#k.EventManager.RegisterExcludedVisual3D(this.#g.TransparentBox);
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x000D0F68 File Offset: 0x000CF168
		private void #Vfb()
		{
			this.#e.Panel3DCustomButton1.IsChecked = new bool?(this.#e.Panel3DCustomButton1.IsChecked != null && this.#e.Panel3DCustomButton1.IsChecked.Value && base.Services.Settings.ShowNominalOrFactored);
			this.#e.Panel3DCustomButton1.IsEnabled = (this.#o != Diagram3DCutType.#a && base.Services.Settings.ShowNominalOrFactored);
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x000D101C File Offset: 0x000CF21C
		private void #Wfb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#k.#lrb();
				this.#k.#nrb();
			}
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x000D1078 File Offset: 0x000CF278
		private void #Xfb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#p = #cfb.#b;
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				this.#Ufb();
			}
			this.#Yfb();
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x000D1124 File Offset: 0x000CF324
		private void #Yfb()
		{
			if (this.#v != null)
			{
				double #9o = base.Services.Settings.BoundingBoxSizeX * 2.0;
				double #7W = base.Services.Settings.BoundingBoxSizeX * 2.0;
				double #kdc = base.Services.Settings.BoundingBoxSizeX * 2.0;
				this.#v.Center = new Point3D(base.Services.Settings.BoundingBoxCenterX, base.Services.Settings.BoundingBoxCenterY, base.Services.Settings.BoundingBoxCenterZ);
				this.#v.Size = new #03d(#9o, #7W, #kdc);
				this.#v.Color = Color.FromArgb(1, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				this.#e.TransparencySorter.AddExcludedVisual(this.#v);
			}
			this.#e.AddToView(this.#v);
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x000D1248 File Offset: 0x000CF448
		private void #Zfb(bool #0fb)
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#k.#nrb();
				this.#k.#lrb();
				if (#0fb && this.FailureSurface != null)
				{
					this.FailureSurface.#yob();
					this.FailureSurface.#zob();
				}
				this.#p = #cfb.#a;
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
			}
			this.#Yfb();
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x00022F3F File Offset: 0x0002113F
		private void #1fb()
		{
			this.#Zfb(true);
			this.#Ufb();
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x00022F5A File Offset: 0x0002115A
		private bool #2fb()
		{
			return this.FailureSurface != null && this.FailureSurface.NominalSurface.IsNotEmpty;
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x000D132C File Offset: 0x000CF52C
		private void #3fb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				bool flag = !base.Services.Settings.ShowNominal;
				if (flag)
				{
					this.#k.#jrb(this.#p);
				}
				else
				{
					this.#k.#lrb();
					this.#g.#tmb(new EventArgs());
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.ShowNominal = flag;
				this.#k.#wrb();
				this.#Ufb();
			}
			this.#Vfb();
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x00022F5A File Offset: 0x0002115A
		private bool #4fb()
		{
			return this.FailureSurface != null && this.FailureSurface.NominalSurface.IsNotEmpty;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00022F82 File Offset: 0x00021182
		private void #5fb()
		{
			this.#k.#lrb();
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x00022F97 File Offset: 0x00021197
		private bool #6fb()
		{
			return this.FailureSurface != null && this.FailureSurface.FactoredSurface.IsNotEmpty;
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x00022FBF File Offset: 0x000211BF
		private void #7fb()
		{
			this.#k.#7fb();
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x00022FD4 File Offset: 0x000211D4
		public void #8fb(#lte #Od = null)
		{
			#lte #lte;
			if ((#lte = #Od) == null)
			{
				#lte = this.CurrentReportingModel;
			}
			#Od = #lte;
			this.#k.#8fb(#Od);
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x000D14F4 File Offset: 0x000CF6F4
		private void #9fb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				bool flag = !base.Services.Settings.ShowFactored;
				if (flag)
				{
					this.#k.#mrb(this.#p);
				}
				else
				{
					this.#k.#nrb();
					this.#g.#tmb(new EventArgs());
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.ShowFactored = flag;
				this.#k.#wrb();
				this.#Ufb();
			}
			this.#Vfb();
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x00022F97 File Offset: 0x00021197
		private bool #agb()
		{
			return this.FailureSurface != null && this.FailureSurface.FactoredSurface.IsNotEmpty;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x00022FFB File Offset: 0x000211FB
		private void #bgb()
		{
			this.#k.#nrb();
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x000D16BC File Offset: 0x000CF8BC
		private void #cgb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				bool flag = !base.Services.Settings.Diagram3DIsMxMyPlaneVisible;
				if (flag)
				{
					this.#k.#trb(#Bbb.#a);
				}
				else
				{
					this.#k.#vrb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.Diagram3DIsMxMyPlaneVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x000D1864 File Offset: 0x000CFA64
		private void #dgb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				bool flag = !base.Services.Settings.Diagram3DIsMyPPlaneVisible;
				if (flag)
				{
					this.#k.#trb(#Bbb.#b);
				}
				else
				{
					this.#k.#vrb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.Diagram3DIsMyPPlaneVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x000D1A0C File Offset: 0x000CFC0C
		private void #egb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				bool flag = !base.Services.Settings.Diagram3DIsPMxPlaneVisible;
				if (flag)
				{
					this.#k.#trb(#Bbb.#c);
				}
				else
				{
					this.#k.#vrb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.Diagram3DIsPMxPlaneVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x000D1BB4 File Offset: 0x000CFDB4
		private void #fgb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				bool flag = !base.Services.Settings.AreMainAxesVisible;
				if (flag)
				{
					this.#k.#rrb();
				}
				else
				{
					this.#k.#srb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.AreMainAxesVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x000D1D5C File Offset: 0x000CFF5C
		private void #ggb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				bool flag = !base.Services.Settings.IsCoordinateSystemVisible;
				if (flag)
				{
					this.#k.#prb();
				}
				else
				{
					this.#k.#qrb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
				{
					this.#8fb(null);
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.IsCoordinateSystemVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x000D1F04 File Offset: 0x000D0104
		private void #hgb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#Nfb();
				this.#g.#pmb(new EventArgs());
				if (base.Services.Settings.ShowFactored)
				{
					this.#k.#mrb(this.#p);
				}
				if (base.Services.Settings.ShowNominal)
				{
					this.#k.#jrb(this.#p);
				}
				if (base.Services.Settings.IsCoordinateSystemVisible)
				{
					this.#k.#prb();
				}
				if (base.Services.Settings.AreMainAxesVisible)
				{
					this.#k.#rrb();
				}
				bool flag = !base.Services.Settings.Diagram3DAreLoadPointsVisible;
				if (flag)
				{
					this.#8fb(null);
				}
				else
				{
					this.#7fb();
				}
				if (base.Services.Settings.Diagram3DIsMxMyPlaneVisible)
				{
					this.#k.#trb(#Bbb.#a);
				}
				if (base.Services.Settings.Diagram3DIsMyPPlaneVisible)
				{
					this.#k.#trb(#Bbb.#b);
				}
				if (base.Services.Settings.Diagram3DIsPMxPlaneVisible)
				{
					this.#k.#trb(#Bbb.#c);
				}
				this.#g.#qmb(new EventArgs());
				base.Services.Settings.Diagram3DAreLoadPointsVisible = flag;
				this.#g.AreLoadPointsVisible = flag;
				this.#Ufb();
			}
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #igb()
		{
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x00023010 File Offset: 0x00021210
		private void #jgb()
		{
			this.#f.ShowHideFactoredSurfaceCommand.InvalidateCanExecute();
			this.#f.ShowHideNominalSurfaceCommand.InvalidateCanExecute();
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x000D20B4 File Offset: 0x000D02B4
		private void #kgb()
		{
			this.#e.EditorWorkspaceSize = #Lbb.#a;
			this.#e.EditorWorkspaceWithAnnotationsSize = this.#e.EditorWorkspaceSize;
			this.#e.CameraMainAxis = AxisName.Z;
			this.#e.DefaultPositionOfCamera = PredefinedPositionsOfCamera.Default;
			this.#e.TransparencySorter.ConfigureTransparencySorting(10.0, CustomSortingModeType.CustomByCameraDistance);
			this.#e.AxisXLabel = Strings.StringMx;
			this.#e.AxisYLabel = Strings.StringMy;
			this.#e.AxisZLabel = Strings.StringPz;
			this.#e.AdjustZoomToModelButtonVisibility = Visibility.Collapsed;
			this.#e.ZoomToWindowButtonVisibility = Visibility.Collapsed;
			this.#e.Panel3DShowHideViewCubeButton.Visibility = Visibility.Collapsed;
			this.#e.Panel3DCustomButton1.Visibility = Visibility.Visible;
			this.#e.Panel3DCustomButton1.IsEnabled = false;
			this.#e.Panel3DCustomButton1.ToolTip = Strings.StringFreeGuidePlaneControl;
			this.#e.Panel3DCustomButton1.Checked += this.#Lfb;
			this.#e.Panel3DCustomButton1.Unchecked += this.#Kfb;
			this.#e.Rotate3DButton.Margin = new Thickness(3.0, 3.0, 3.0, 5.0);
			this.#e.Rotate3DButton.IsChecked = new bool?(true);
			this.#e.Rotate3DButton.Checked += this.#Mfb;
			this.#e.TranslateButton.Checked += this.#Jfb;
			this.#e.ActionsPanelRotate3DButtonClicked(this, new RoutedEventArgs());
			this.#e.FitCameraPositionToWorkspace();
			this.#e.TransparencySorter.StartTransparencySorting();
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x000D22B4 File Offset: 0x000D04B4
		private void #lgb()
		{
			using (this.#e.TransparencySorter.BeginBulkUpdate())
			{
				this.#k.#orb();
				(base.Services.Settings.AreMainAxesVisible ? new Action(this.#k.#rrb) : new Action(this.#k.#srb))();
				(base.Services.Settings.IsCoordinateSystemVisible ? new Action(this.#k.#prb) : new Action(this.#k.#qrb))();
				(base.Services.Settings.Diagram3DIsMxMyPlaneVisible ? new Action<#Bbb>(this.#k.#trb) : new Action<#Bbb>(this.#k.#vrb))(#Bbb.#a);
				(base.Services.Settings.Diagram3DIsMyPPlaneVisible ? new Action<#Bbb>(this.#k.#trb) : new Action<#Bbb>(this.#k.#vrb))(#Bbb.#b);
				(base.Services.Settings.Diagram3DIsPMxPlaneVisible ? new Action<#Bbb>(this.#k.#trb) : new Action<#Bbb>(this.#k.#vrb))(#Bbb.#c);
				this.#k.#wrb();
			}
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x000D2464 File Offset: 0x000D0664
		private void #mgb()
		{
			bool flag = this.#s.NominalSurface.IsNotEmpty && base.Services.Settings.ShowNominal;
			double num = (double)((base.Services.Settings.IsCoordinateSystemVisible || flag) ? 40 : 10);
			BoundingBoxData boundingBoxData = null;
			List<Point3D> list = new List<Point3D>(10);
			if (base.Services.Settings.Diagram3DAreLoadPointsVisible)
			{
				list.AddRange(this.#s.LoadPoints.Select(new Func<LoadPointData, Point3D>(FailureSurfaceViewModel.<>c.<>9.#F0h)));
			}
			if (flag)
			{
				list.AddRange(this.#s.NominalTransformedPositions);
			}
			if (this.#s.FactoredSurface.IsNotEmpty && base.Services.Settings.ShowFactored)
			{
				list.AddRange(this.#s.FactoredTransformedPositions);
			}
			if (list.Any<Point3D>())
			{
				double num4;
				double num3;
				double num2 = num3 = (num4 = -num);
				double num7;
				double num6;
				double num5 = num6 = (num7 = num);
				foreach (Point3D point3D in list)
				{
					num3 = Math.Min(num3, point3D.X);
					num6 = Math.Max(num6, point3D.X);
					num2 = Math.Min(num2, point3D.Y);
					num5 = Math.Max(num5, point3D.Y);
					num4 = Math.Min(num4, point3D.Z);
					num7 = Math.Max(num7, point3D.Z);
				}
				boundingBoxData = new BoundingBoxData(num3, num6, num2, num5, num4, num7);
			}
			this.#e.EditorWorkspaceSize = ((boundingBoxData != null) ? boundingBoxData : #Lbb.#a);
			this.#e.EditorWorkspaceWithAnnotationsSize = this.#e.EditorWorkspaceSize;
			this.#e.FitCameraPositionToWorkspace();
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x0002303E File Offset: 0x0002123E
		[CompilerGenerated]
		private void #ngb(object #Ge, #pkb #Lg)
		{
			this.#1db(#Lg);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x00023053 File Offset: 0x00021253
		[CompilerGenerated]
		private void #ogb(object #Ge, #pkb #Lg)
		{
			this.#Ydb(#Lg);
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00023068 File Offset: 0x00021268
		[CompilerGenerated]
		private void #pgb(object #Ge, #pkb #Lg)
		{
			this.#Zdb(#Lg);
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x0002307D File Offset: 0x0002127D
		[CompilerGenerated]
		private void #qgb(object #Ge, #pkb #Lg)
		{
			this.#0db(#Lg);
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x00023092 File Offset: 0x00021292
		[CompilerGenerated]
		private void #rgb(object #Ge, #Yjb #Lg)
		{
			this.#2db(#Lg);
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x000230A7 File Offset: 0x000212A7
		[CompilerGenerated]
		private void #sgb(object #Ge, KeyEventArgs #Lg)
		{
			if (#Lg.Key == Key.Escape)
			{
				this.#Wbb();
			}
		}

		// Token: 0x04000E8F RID: 3727
		private readonly CreateHorizontalCrossSectionTool #a;

		// Token: 0x04000E90 RID: 3728
		private readonly CreateVerticalCrossSectionTool #b;

		// Token: 0x04000E91 RID: 3729
		private readonly #Xmb #c;

		// Token: 0x04000E92 RID: 3730
		private readonly #8Sc #d;

		// Token: 0x04000E93 RID: 3731
		private readonly IModelEditorControl #e;

		// Token: 0x04000E94 RID: 3732
		private readonly #2vb #f;

		// Token: 0x04000E95 RID: 3733
		private readonly #3mb #g;

		// Token: 0x04000E96 RID: 3734
		private readonly #zU #h;

		// Token: 0x04000E97 RID: 3735
		private readonly #yBe #i;

		// Token: 0x04000E98 RID: 3736
		private readonly #Ke #j;

		// Token: 0x04000E99 RID: 3737
		private readonly #yrb #k;

		// Token: 0x04000E9A RID: 3738
		private readonly #tUd #l;

		// Token: 0x04000E9B RID: 3739
		private readonly #tbb #m;

		// Token: 0x04000E9C RID: 3740
		private readonly #qCe #n = new #qCe();

		// Token: 0x04000E9D RID: 3741
		private Diagram3DCutType #o;

		// Token: 0x04000E9E RID: 3742
		private #cfb #p;

		// Token: 0x04000E9F RID: 3743
		private Visibility #q;

		// Token: 0x04000EA0 RID: 3744
		private bool #r;

		// Token: 0x04000EA1 RID: 3745
		private FailureSurface #s;

		// Token: 0x04000EA2 RID: 3746
		private double #t;

		// Token: 0x04000EA3 RID: 3747
		private double #u = 15.0;

		// Token: 0x04000EA4 RID: 3748
		private readonly IBoxDrawingResult #v;

		// Token: 0x04000EA5 RID: 3749
		[CompilerGenerated]
		private EventHandler<#pkb> #w;

		// Token: 0x04000EA6 RID: 3750
		[CompilerGenerated]
		private EventHandler<#pkb> #x;

		// Token: 0x04000EA7 RID: 3751
		[CompilerGenerated]
		private EventHandler<#pkb> #y;

		// Token: 0x04000EA8 RID: 3752
		[CompilerGenerated]
		private EventHandler<#pkb> #z;

		// Token: 0x04000EA9 RID: 3753
		[CompilerGenerated]
		private EventHandler<#Yjb> #A;

		// Token: 0x04000EAA RID: 3754
		[CompilerGenerated]
		private EventHandler #B;

		// Token: 0x04000EAB RID: 3755
		[CompilerGenerated]
		private #lte #C;

		// Token: 0x04000EAC RID: 3756
		[CompilerGenerated]
		private bool #D;
	}
}

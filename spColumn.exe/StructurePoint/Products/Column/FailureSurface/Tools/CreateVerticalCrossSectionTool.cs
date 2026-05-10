using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using #3vb;
using #7hc;
using #Cqb;
using #Fmc;
using #S9;
using #u3d;
using #UYd;
using #vmb;
using #Zjb;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Visualization;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Core.Helpers;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Tools
{
	// Token: 0x0200043B RID: 1083
	internal sealed class CreateVerticalCrossSectionTool : #Imb, INotifyPropertyChanged, IEditionToolData, #4mb, #2mb
	{
		// Token: 0x06002799 RID: 10137 RVA: 0x000D90C0 File Offset: 0x000D72C0
		public CreateVerticalCrossSectionTool(#5mb failureSurfaceToolContext, ISettingsManager settingsManager, #2vb failureSurfaceCommandsManager, #1mb createVerticalCrossSectionManager) : base(failureSurfaceToolContext, settingsManager)
		{
			#X0d.#V0d(failureSurfaceToolContext, #Phc.#3hc(107360418), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.FailureSurfaceVisualization, #Phc.#3hc(107360413));
			this.#c = createVerticalCrossSectionManager;
			this.#b = settingsManager;
			base.Header = Strings.StringCut + Environment.NewLine + Strings.StringVertical;
			base.ToolboxName = Strings.StringCut.#O2d() + Strings.StringVertical;
			base.IconImage = failureSurfaceToolContext.ResourcesHelper.ImageFromResourceBitmap(VisualizationIcons.CutVertical);
			failureSurfaceToolContext.FailureSurfaceContext.FailureSurfaceLoaded += this.#ulb;
			failureSurfaceToolContext.FailureSurfaceContext.ViewportCleaned += this.#tlb;
			failureSurfaceToolContext.FailureSurfaceContext.ViewportPopulated += this.#slb;
			IDelegateCommandProxy delegateCommandProxy = failureSurfaceCommandsManager.UpdateVerticalCutterColorCommand;
			Action commandDelegate = new Action(this.#Ylb);
			Func<bool> canExecute;
			if ((canExecute = CreateVerticalCrossSectionTool.#2Ui.#a) == null)
			{
				canExecute = (CreateVerticalCrossSectionTool.#2Ui.#a = new Func<bool>(CreateVerticalCrossSectionTool.#Qlb));
			}
			delegateCommandProxy.SetCommand(commandDelegate, canExecute);
			base.HelpId = #arb.ToolCreateVerticalCrossSection;
			base.ToolTipContent = new RichToolTipContent(#Phc.#3hc(107360328), #Phc.#3hc(107360311), false, false);
		}

		// Token: 0x140000B4 RID: 180
		// (add) Token: 0x0600279A RID: 10138 RVA: 0x000D9214 File Offset: 0x000D7414
		// (remove) Token: 0x0600279B RID: 10139 RVA: 0x000D9258 File Offset: 0x000D7458
		public event EventHandler<#pkb> AngleChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#p;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#p;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000B5 RID: 181
		// (add) Token: 0x0600279C RID: 10140 RVA: 0x000D929C File Offset: 0x000D749C
		// (remove) Token: 0x0600279D RID: 10141 RVA: 0x000D92E0 File Offset: 0x000D74E0
		public event EventHandler<#pkb> AngleChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#q;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#q;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000D44 RID: 3396
		// (get) Token: 0x0600279E RID: 10142 RVA: 0x00024D61 File Offset: 0x00022F61
		// (set) Token: 0x0600279F RID: 10143 RVA: 0x00024D6D File Offset: 0x00022F6D
		public double Angle
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
					this.#Zdb(new #pkb(value));
					base.RaisePropertyChanged(#Phc.#3hc(107360678));
				}
			}
		}

		// Token: 0x17000D45 RID: 3397
		// (get) Token: 0x060027A0 RID: 10144 RVA: 0x00024DA7 File Offset: 0x00022FA7
		// (set) Token: 0x060027A1 RID: 10145 RVA: 0x00024DB3 File Offset: 0x00022FB3
		public #ybb PartToCut
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360431));
				}
			}
		}

		// Token: 0x17000D46 RID: 3398
		// (get) Token: 0x060027A2 RID: 10146 RVA: 0x00024DE1 File Offset: 0x00022FE1
		// (set) Token: 0x060027A3 RID: 10147 RVA: 0x00024DED File Offset: 0x00022FED
		public bool AllowFreePlaneControl
		{
			get
			{
				return this.#o;
			}
			set
			{
				this.#o = value;
				if (base.IsActive)
				{
					if (this.#o)
					{
						this.#Slb();
						return;
					}
					this.#Tlb();
				}
			}
		}

		// Token: 0x060027A4 RID: 10148 RVA: 0x000D9324 File Offset: 0x000D7524
		public override void #5b()
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.#5b();
				this.#m = CreateVerticalCrossSectionTool.#s6b.#b;
				base.ModelEditorControl.RegisterEvents(new ModelEditorControlEventType[]
				{
					ModelEditorControlEventType.MouseLeftButtonUp,
					ModelEditorControlEventType.MouseLeftButtonDown
				});
				this.#Mlb();
				if (this.AllowFreePlaneControl)
				{
					this.#Slb();
				}
				this.#glb();
				this.#Wlb(null);
			}
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x000D93BC File Offset: 0x000D75BC
		public override void #0kb()
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.#0kb();
				base.ModelEditorControl.UnregisterEvents(null);
				this.#vfb();
				this.#1kb();
			}
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x00024E1F File Offset: 0x0002301F
		public override void #1kb()
		{
			if (this.#n)
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#c;
			}
			else
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#b;
				this.#Tlb();
				this.#0lb();
			}
			base.#1kb();
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x000D9420 File Offset: 0x000D7620
		public void #Klb(double #Llb)
		{
			this.Angle = #Llb;
			#c4d #c4d = #Loc.#Goc(#Llb);
			#c4d = #Loc.#soc(#c4d);
			this.#h.UpdateNormal(#c4d, new #c4d(this.#l.X, this.#l.Y, this.#d));
			if (this.#h.Positions != null)
			{
				this.#i.Positions = this.#h.Positions;
			}
		}

		// Token: 0x060027A8 RID: 10152 RVA: 0x000D94A0 File Offset: 0x000D76A0
		public void #Ikb()
		{
			if (!base.IsActive)
			{
				return;
			}
			if (this.HasErrors)
			{
				Window #WSc = base.FailureSurfaceToolContext.WindowLocator.#VP() as Window;
				base.FailureSurfaceToolContext.DialogService.#od(#WSc, Strings.StringInvalidDataSpecified.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				return;
			}
			this.#n = true;
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				this.#olb(this.Angle);
				this.#1kb();
				this.#0lb();
				this.#Ykb();
			}
		}

		// Token: 0x060027A9 RID: 10153 RVA: 0x00024E57 File Offset: 0x00023057
		public void #vfb()
		{
			this.#Vlb(true);
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x000D9568 File Offset: 0x000D7768
		public void #Mlb()
		{
			if (this.#h == null)
			{
				this.#h = base.FailureSurfaceToolContext.DrawingResultsFactory.CreateBoxDrawingResult();
			}
			if (this.#i == null)
			{
				this.#i = this.#rlb();
			}
			double num = this.#b.BoundingBoxSizeX - 2.0 * Math.Abs(this.#l.X);
			double num2 = this.#b.BoundingBoxSizeY - 2.0 * Math.Abs(this.#l.Y);
			double #9o = (num < num2) ? num : num2;
			double #7W = this.#b.BoundingBoxSizeZ;
			double num3 = this.#b.BoundingBoxCenterZ;
			if (this.#b.ShowFactored && !this.#b.ShowNominal)
			{
				double num4 = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface.FactoredSurface.FailureSurface.Positions.Min(new Func<Point3D, double>(CreateVerticalCrossSectionTool.<>c.<>9.#C6b));
				double num5 = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface.FactoredSurface.FailureSurface.Positions.Max(new Func<Point3D, double>(CreateVerticalCrossSectionTool.<>c.<>9.#D6b));
				#7W = Math.Abs(num5 - num4);
				num3 = (num5 + num4) / 2.0;
			}
			this.#Ykb();
			this.#d = num3;
			this.#h.Size = new #03d(#9o, #7W, 0.25);
			if (base.IsActive)
			{
				this.#0lb();
				this.#Ykb();
				if ((this.#b.ShowNominal || this.#b.ShowFactored) && this.AllowFreePlaneControl)
				{
					this.#Slb();
				}
				else
				{
					this.#Tlb();
				}
			}
			this.#h.UpdateNormal(this.#a, new #c4d(this.#l.X, this.#l.Y, this.#d));
			this.#h.Center = new Point3D(this.#l.X, this.#l.Y, this.#b.BoundingBoxCenterZ);
			if (this.#h.Positions != null)
			{
				this.#i.Positions = this.#h.Positions;
			}
			this.#Ylb();
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x000D97F4 File Offset: 0x000D79F4
		public void #Ykb()
		{
			if (base.IsActive && (this.#b.ShowNominal || this.#b.ShowFactored))
			{
				this.#Zlb();
				if (this.AllowFreePlaneControl)
				{
					this.#Slb();
					return;
				}
			}
			else
			{
				this.#Tlb();
				this.#0lb();
			}
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x00024E68 File Offset: 0x00023068
		public override void #tfb()
		{
			this.#Rlb();
		}

		// Token: 0x060027AD RID: 10157 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #2kb(KeyEventArgs #HA)
		{
		}

		// Token: 0x060027AE RID: 10158 RVA: 0x000D9850 File Offset: 0x000D7A50
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (!false)
			{
				base.#3kb(#4kb);
			}
			if (this.AllowFreePlaneControl && this.#m == CreateVerticalCrossSectionTool.#s6b.#b && !base.ModelEditorControl.Rotate3DButton.IsChecked.GetValueOrDefault())
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#a;
				return;
			}
			if (this.AllowFreePlaneControl && this.#m == CreateVerticalCrossSectionTool.#s6b.#c && !base.ModelEditorControl.Rotate3DButton.IsChecked.GetValueOrDefault())
			{
				using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
				{
					this.#vfb();
					this.#0lb();
					this.#Ykb();
				}
				this.#m = CreateVerticalCrossSectionTool.#s6b.#d;
			}
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x00024E78 File Offset: 0x00023078
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			base.#5kb(#4kb);
			this.#Rlb();
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x000D992C File Offset: 0x000D7B2C
		protected void #Zdb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#q;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x000D9958 File Offset: 0x000D7B58
		protected void #0db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#p;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027B2 RID: 10162 RVA: 0x00024E93 File Offset: 0x00023093
		private void #Nlb(object #Ge, MouseEventArgs3D #He)
		{
			this.#Ulb(#He);
		}

		// Token: 0x060027B3 RID: 10163 RVA: 0x00024E93 File Offset: 0x00023093
		private void #Olb(object #Ge, MouseEventArgs3D #He)
		{
			this.#Ulb(#He);
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Plb(object #Ge, MouseEventArgs3D #He)
		{
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x00024EA8 File Offset: 0x000230A8
		private void #slb(object #Ge, EventArgs #He)
		{
			this.#Mlb();
			this.#Klb(this.Angle);
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x00024EC8 File Offset: 0x000230C8
		private void #tlb(object #Ge, EventArgs #He)
		{
			if (base.IsActive)
			{
				this.#0lb();
				this.#Tlb();
			}
		}

		// Token: 0x060027B7 RID: 10167 RVA: 0x000D9984 File Offset: 0x000D7B84
		private void #ulb(object #Ge, EventArgs #He)
		{
			base.#Cmb(ref this.#g);
			this.#l = CoordinateSystemHelper.#zsb(base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface);
			this.#Mlb();
			this.#Xlb();
			this.#g = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface.EventManagerFactory.CreateEventSource(this.#j);
			this.#g.MouseEnter += this.#Nlb;
			this.#g.MouseMove += this.#Olb;
			this.#g.MouseLeave += this.#Plb;
			base.EventManager.RegisterEventSource(this.#g);
			if (base.IsActive)
			{
				this.#Vlb(false);
			}
		}

		// Token: 0x060027B8 RID: 10168 RVA: 0x00003375 File Offset: 0x00001575
		private static bool #Qlb()
		{
			return true;
		}

		// Token: 0x060027B9 RID: 10169 RVA: 0x000D9A70 File Offset: 0x000D7C70
		private void #Rlb()
		{
			if (this.#m == CreateVerticalCrossSectionTool.#s6b.#a)
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#b;
				if (this.AllowFreePlaneControl)
				{
					this.#0db(new #pkb(this.Angle));
					return;
				}
			}
			else if (this.#m == CreateVerticalCrossSectionTool.#s6b.#d)
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#c;
				if (this.AllowFreePlaneControl)
				{
					this.#0db(new #pkb(this.Angle));
					this.#Ikb();
				}
			}
		}

		// Token: 0x060027BA RID: 10170 RVA: 0x000D9AE4 File Offset: 0x000D7CE4
		private void #Slb()
		{
			if (this.#j != null && (this.#b.ShowFactored || this.#b.ShowNominal))
			{
				base.FailureSurfaceToolContext.ModelEditorControl.AddToView(this.#j);
			}
		}

		// Token: 0x060027BB RID: 10171 RVA: 0x00024EEA File Offset: 0x000230EA
		private void #Tlb()
		{
			if (this.#j != null)
			{
				base.FailureSurfaceToolContext.ModelEditorControl.RemoveFromView(this.#j);
			}
		}

		// Token: 0x060027BC RID: 10172 RVA: 0x000D9B38 File Offset: 0x000D7D38
		private void #Ulb(MouseEventArgs3D #HA)
		{
			if (base.ModelEditorControl.SuspendEvents || !this.AllowFreePlaneControl)
			{
				return;
			}
			if ((this.#m == CreateVerticalCrossSectionTool.#s6b.#a || this.#m == CreateVerticalCrossSectionTool.#s6b.#d) && #HA != null && #HA.HitMousePosition != null)
			{
				this.#k = new #c4d(#HA.HitMousePosition.Value.X - this.#l.X, #HA.HitMousePosition.Value.Y - this.#l.Y, 0.0);
				this.#k.#wlc();
				#c4d normal = #Loc.#soc(this.#k);
				this.#h.UpdateNormal(normal, new #c4d(this.#l.X, this.#l.Y, this.#d));
				if (this.#h.Positions != null)
				{
					this.#i.Positions = this.#h.Positions;
				}
				this.#Wlb(new #c4d?(this.#k));
			}
		}

		// Token: 0x060027BD RID: 10173 RVA: 0x00024F16 File Offset: 0x00023116
		private void #glb()
		{
			if (this.#m == CreateVerticalCrossSectionTool.#s6b.#a)
			{
				this.#m = CreateVerticalCrossSectionTool.#s6b.#b;
				this.#0lb();
				this.#Ykb();
			}
		}

		// Token: 0x060027BE RID: 10174 RVA: 0x000D9C78 File Offset: 0x000D7E78
		private void #Vlb(bool #jlb)
		{
			if (!this.#n && #jlb)
			{
				return;
			}
			this.#n = false;
			if (#jlb)
			{
				base.FailureSurfaceToolContext.CommandsManager.ShowBaseVisualizationCommand.Execute();
			}
			this.#Mlb();
			this.#Klb(this.Angle);
			if (this.AllowFreePlaneControl)
			{
				this.#Slb();
			}
			this.#m = CreateVerticalCrossSectionTool.#s6b.#a;
			this.#0lb();
			this.#Ykb();
			this.#glb();
		}

		// Token: 0x060027BF RID: 10175 RVA: 0x000D9CF8 File Offset: 0x000D7EF8
		private void #Wlb(#c4d? #Flb)
		{
			if (#Flb != null)
			{
				double num = #Loc.#Foc(#Flb.Value);
				this.Angle = num;
			}
		}

		// Token: 0x060027C0 RID: 10176 RVA: 0x000D9D30 File Offset: 0x000D7F30
		private void #olb(double #Alb)
		{
			if (!base.IsActive)
			{
				return;
			}
			if (this.HasErrors)
			{
				Window #WSc = base.FailureSurfaceToolContext.WindowLocator.#VP() as Window;
				base.FailureSurfaceToolContext.DialogService.#od(#WSc, Strings.StringInvalidDataSpecified.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				return;
			}
			this.#c.#Ikb(#Alb, this.PartToCut, this.#l);
		}

		// Token: 0x060027C1 RID: 10177 RVA: 0x000D9DAC File Offset: 0x000D7FAC
		private void #Xlb()
		{
			if (this.#j == null)
			{
				this.#j = base.FailureSurfaceToolContext.DrawingResultsFactory.CreateSphereDrawingResult();
				base.FailureSurfaceToolContext.ModelEditorControl.TransparencySorter.AddExcludedVisual(this.#j);
			}
			this.#j.Radius = Math.Sqrt(Math.Pow(this.#b.BoundingBoxSizeZ, 2.0) / 4.0 + Math.Pow(this.#b.BoundingBoxSizeX / 2.0, 2.0) + Math.Pow(this.#b.BoundingBoxSizeY / 2.0, 2.0));
			this.#j.Color = Colors.Transparent;
			this.#j.Center = new Point3D(this.#b.BoundingBoxCenterX, this.#b.BoundingBoxCenterY, this.#b.BoundingBoxCenterZ);
		}

		// Token: 0x060027C2 RID: 10178 RVA: 0x000D9ECC File Offset: 0x000D80CC
		private IPolylineDrawingResult #rlb()
		{
			IPolylineDrawingResult polylineDrawingResult = base.FailureSurfaceToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			polylineDrawingResult.IsClosed = true;
			polylineDrawingResult.LineColor = this.#b.CutPlaneColor;
			polylineDrawingResult.LineThickness = this.#b.CutterBorderThickness;
			polylineDrawingResult.Positions = new List<Point3D>
			{
				new Point3D(this.#b.BoundingBoxCenterX + this.#b.BoundingBoxSizeX / 2.0, this.#b.BoundingBoxCenterY + this.#b.BoundingBoxSizeY / 2.0, this.#b.BoundingBoxCenterZ),
				new Point3D(this.#b.BoundingBoxCenterX - this.#b.BoundingBoxSizeX / 2.0, this.#b.BoundingBoxCenterY + this.#b.BoundingBoxSizeY / 2.0, this.#b.BoundingBoxCenterZ),
				new Point3D(this.#b.BoundingBoxCenterX - this.#b.BoundingBoxSizeX / 2.0, this.#b.BoundingBoxCenterY - this.#b.BoundingBoxSizeY / 2.0, this.#b.BoundingBoxCenterZ),
				new Point3D(this.#b.BoundingBoxCenterX + this.#b.BoundingBoxSizeX / 2.0, this.#b.BoundingBoxCenterY - this.#b.BoundingBoxSizeY / 2.0, this.#b.BoundingBoxCenterZ)
			};
			return polylineDrawingResult;
		}

		// Token: 0x060027C3 RID: 10179 RVA: 0x000DA0A0 File Offset: 0x000D82A0
		private void #Ylb()
		{
			this.#h.Color = (this.#i.LineColor = this.#b.CutPlaneColor);
			base.ModelEditorControl.TransparencySorter.RecollectTransparentModels();
		}

		// Token: 0x060027C4 RID: 10180 RVA: 0x000DA0F0 File Offset: 0x000D82F0
		private void #Zlb()
		{
			if (this.#m == CreateVerticalCrossSectionTool.#s6b.#c)
			{
				base.FailureSurfaceToolContext.ModelEditorControl.AddToView(this.#i);
				return;
			}
			base.FailureSurfaceToolContext.ModelEditorControl.AddToView(this.#h);
			base.ModelEditorControl.TransparencySorter.RecollectTransparentModels();
			IEventManager eventManager = base.EventManager;
			if (eventManager == null)
			{
				return;
			}
			eventManager.RegisterExcludedVisual3D(this.#h);
		}

		// Token: 0x060027C5 RID: 10181 RVA: 0x00024F3F File Offset: 0x0002313F
		private void #0lb()
		{
			base.FailureSurfaceToolContext.ModelEditorControl.RemoveFromView(this.#h);
			base.FailureSurfaceToolContext.ModelEditorControl.RemoveFromView(this.#i);
		}

		// Token: 0x04000FA2 RID: 4002
		private readonly #c4d #a = new #c4d(0.0, 1.0, 0.0);

		// Token: 0x04000FA3 RID: 4003
		private readonly ISettingsManager #b;

		// Token: 0x04000FA4 RID: 4004
		private readonly #1mb #c;

		// Token: 0x04000FA5 RID: 4005
		private double #d;

		// Token: 0x04000FA6 RID: 4006
		private double #e;

		// Token: 0x04000FA7 RID: 4007
		private #ybb #f;

		// Token: 0x04000FA8 RID: 4008
		private IEventSource #g;

		// Token: 0x04000FA9 RID: 4009
		private IBoxDrawingResult #h;

		// Token: 0x04000FAA RID: 4010
		private IPolylineDrawingResult #i;

		// Token: 0x04000FAB RID: 4011
		private ISphereDrawingResult #j;

		// Token: 0x04000FAC RID: 4012
		private #c4d #k;

		// Token: 0x04000FAD RID: 4013
		private Point3D #l;

		// Token: 0x04000FAE RID: 4014
		private CreateVerticalCrossSectionTool.#s6b #m;

		// Token: 0x04000FAF RID: 4015
		private bool #n;

		// Token: 0x04000FB0 RID: 4016
		private bool #o;

		// Token: 0x04000FB1 RID: 4017
		[CompilerGenerated]
		private EventHandler<#pkb> #p;

		// Token: 0x04000FB2 RID: 4018
		[CompilerGenerated]
		private EventHandler<#pkb> #q;

		// Token: 0x0200043C RID: 1084
		private enum #s6b
		{
			// Token: 0x04000FB4 RID: 4020
			#a,
			// Token: 0x04000FB5 RID: 4021
			#b,
			// Token: 0x04000FB6 RID: 4022
			#c,
			// Token: 0x04000FB7 RID: 4023
			#d
		}

		// Token: 0x0200043D RID: 1085
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000FB8 RID: 4024
			public static Func<bool> #a;
		}
	}
}

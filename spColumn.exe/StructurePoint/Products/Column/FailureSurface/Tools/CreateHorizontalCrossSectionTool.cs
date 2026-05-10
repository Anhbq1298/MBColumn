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
using #S9;
using #u3d;
using #vmb;
using #Zjb;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Visualization;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Tools
{
	// Token: 0x0200042E RID: 1070
	internal sealed class CreateHorizontalCrossSectionTool : #Imb, INotifyPropertyChanged, IEditionToolData, #4mb, #0mb
	{
		// Token: 0x060026E9 RID: 9961 RVA: 0x000D70B4 File Offset: 0x000D52B4
		public CreateHorizontalCrossSectionTool(#5mb failureSurfaceToolContext, ISettingsManager settingsManager, #2vb failureSurfaceCommandsManager, #Ymb createHorizontalCrossSectionManager) : base(failureSurfaceToolContext, settingsManager)
		{
			this.#c = settingsManager;
			this.#b = failureSurfaceCommandsManager;
			base.Header = Strings.StringCut + Environment.NewLine + Strings.StringHoriz.#z2d();
			base.ToolboxName = Strings.StringCut.#O2d() + Strings.StringHorizontal;
			base.IconImage = failureSurfaceToolContext.ResourcesHelper.ImageFromResourceBitmap(VisualizationIcons.CutHorizontal);
			this.#7kb(failureSurfaceToolContext);
			this.#9kb();
			this.#d = createHorizontalCrossSectionManager;
			base.HelpId = #arb.ToolCreateHorizontalCrossSection;
			IDelegateCommandProxy delegateCommandProxy = this.#b.UpdateHorizontalCutterColorCommand;
			Action commandDelegate = new Action(this.#vlb);
			Func<bool> canExecute;
			if ((canExecute = CreateHorizontalCrossSectionTool.#2Ui.#a) == null)
			{
				canExecute = (CreateHorizontalCrossSectionTool.#2Ui.#a = new Func<bool>(CreateHorizontalCrossSectionTool.#wlb));
			}
			delegateCommandProxy.SetCommand(commandDelegate, canExecute);
			base.ToolTipContent = new RichToolTipContent(#Phc.#3hc(107361126), #Phc.#3hc(107361109), false, false);
		}

		// Token: 0x140000AC RID: 172
		// (add) Token: 0x060026EA RID: 9962 RVA: 0x000D71C4 File Offset: 0x000D53C4
		// (remove) Token: 0x060026EB RID: 9963 RVA: 0x000D7208 File Offset: 0x000D5408
		public event EventHandler<#pkb> AxialLoadChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#m;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#m;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000AD RID: 173
		// (add) Token: 0x060026EC RID: 9964 RVA: 0x000D724C File Offset: 0x000D544C
		// (remove) Token: 0x060026ED RID: 9965 RVA: 0x000D7290 File Offset: 0x000D5490
		public event EventHandler<#pkb> AxialLoadChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#n;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#n, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#n;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#n, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000D27 RID: 3367
		// (get) Token: 0x060026EE RID: 9966 RVA: 0x0002485D File Offset: 0x00022A5D
		// (set) Token: 0x060026EF RID: 9967 RVA: 0x00024869 File Offset: 0x00022A69
		public double AxialForce
		{
			get
			{
				return this.#h;
			}
			private set
			{
				if (this.#h != value)
				{
					this.#h = value;
					this.#Ydb(new #pkb(value));
					base.RaisePropertyChanged(#Phc.#3hc(107360448));
				}
			}
		}

		// Token: 0x17000D28 RID: 3368
		// (get) Token: 0x060026F0 RID: 9968 RVA: 0x000248A3 File Offset: 0x00022AA3
		// (set) Token: 0x060026F1 RID: 9969 RVA: 0x000248AF File Offset: 0x00022AAF
		public #xbb PartToCut
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
					base.RaisePropertyChanged(#Phc.#3hc(107360431));
				}
			}
		}

		// Token: 0x17000D29 RID: 3369
		// (get) Token: 0x060026F2 RID: 9970 RVA: 0x000248DD File Offset: 0x00022ADD
		// (set) Token: 0x060026F3 RID: 9971 RVA: 0x000248E9 File Offset: 0x00022AE9
		public bool AllowFreePlaneControl
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.#l = value;
				if (base.IsActive)
				{
					if (this.#l)
					{
						this.#clb();
						return;
					}
					this.#dlb();
				}
			}
		}

		// Token: 0x060026F4 RID: 9972 RVA: 0x000D72D4 File Offset: 0x000D54D4
		public void #Ykb()
		{
			if (base.IsActive && (this.#c.ShowFactored || this.#c.ShowNominal))
			{
				this.#xlb();
				if (this.AllowFreePlaneControl)
				{
					this.#clb();
					return;
				}
			}
			else
			{
				this.#ylb();
				this.#dlb();
			}
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x000D7330 File Offset: 0x000D5530
		public void #Zkb(double #nz)
		{
			this.AxialForce = #nz;
			double #blb = this.#mlb(this.AxialForce);
			this.#alb(#blb);
		}

		// Token: 0x060026F6 RID: 9974 RVA: 0x000D7364 File Offset: 0x000D5564
		public override void #5b()
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.#5b();
				this.#Ykb();
				base.ModelEditorControl.RegisterEvents(new ModelEditorControlEventType[]
				{
					ModelEditorControlEventType.MouseLeftButtonUp,
					ModelEditorControlEventType.MouseLeftButtonDown
				});
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#a;
				if (this.AllowFreePlaneControl)
				{
					this.#clb();
				}
				this.#glb();
			}
		}

		// Token: 0x060026F7 RID: 9975 RVA: 0x000D73EC File Offset: 0x000D55EC
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

		// Token: 0x060026F8 RID: 9976 RVA: 0x0002491B File Offset: 0x00022B1B
		public override void #1kb()
		{
			if (this.#o)
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#c;
			}
			else
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#a;
				this.#dlb();
				this.#ylb();
			}
			base.#1kb();
		}

		// Token: 0x060026F9 RID: 9977 RVA: 0x00024953 File Offset: 0x00022B53
		public override void #tfb()
		{
			this.#6kb();
		}

		// Token: 0x060026FA RID: 9978 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #2kb(KeyEventArgs #HA)
		{
		}

		// Token: 0x060026FB RID: 9979 RVA: 0x000D7450 File Offset: 0x000D5650
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			base.#3kb(#4kb);
			if (this.AllowFreePlaneControl && this.#k == CreateHorizontalCrossSectionTool.#s6b.#a && !base.ModelEditorControl.Rotate3DButton.IsChecked.GetValueOrDefault())
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#b;
				return;
			}
			if (this.AllowFreePlaneControl && this.#k == CreateHorizontalCrossSectionTool.#s6b.#c && !base.ModelEditorControl.Rotate3DButton.IsChecked.GetValueOrDefault())
			{
				using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
				{
					this.#vfb();
					this.#ylb();
					this.#Ykb();
				}
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#d;
			}
		}

		// Token: 0x060026FC RID: 9980 RVA: 0x00024963 File Offset: 0x00022B63
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			base.#5kb(#4kb);
			this.#6kb();
		}

		// Token: 0x060026FD RID: 9981 RVA: 0x000D7528 File Offset: 0x000D5728
		protected void #1db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#m;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060026FE RID: 9982 RVA: 0x000D7554 File Offset: 0x000D5754
		protected void #Ydb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#n;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x000D7580 File Offset: 0x000D5780
		private void #6kb()
		{
			if (this.#k == CreateHorizontalCrossSectionTool.#s6b.#b)
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#a;
				if (this.AllowFreePlaneControl)
				{
					this.#1db(new #pkb(this.AxialForce));
					return;
				}
			}
			else if (this.#k == CreateHorizontalCrossSectionTool.#s6b.#d)
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#c;
				if (this.AllowFreePlaneControl)
				{
					this.#1db(new #pkb(this.AxialForce));
					this.#Ikb();
				}
			}
		}

		// Token: 0x06002700 RID: 9984 RVA: 0x000D75F4 File Offset: 0x000D57F4
		private void #7kb(#5mb #8kb)
		{
			#8kb.FailureSurfaceContext.FailureSurfaceLoaded += this.#ulb;
			#8kb.FailureSurfaceContext.ViewportCleaned += this.#tlb;
			#8kb.FailureSurfaceContext.ViewportPopulated += this.#slb;
		}

		// Token: 0x06002701 RID: 9985 RVA: 0x000D7654 File Offset: 0x000D5854
		private void #9kb()
		{
			this.#e = this.#qlb();
			this.#f = this.#rlb();
			this.#g = this.#plb();
			base.ModelEditorControl.TransparencySorter.AddExcludedVisual(this.#g);
		}

		// Token: 0x06002702 RID: 9986 RVA: 0x000D76A8 File Offset: 0x000D58A8
		private void #alb(double #blb)
		{
			CreateHorizontalCrossSectionTool.#SUb #SUb = new CreateHorizontalCrossSectionTool.#SUb();
			#SUb.#a = #blb;
			this.#f.Positions = this.#f.Positions.Select(new Func<Point3D, Point3D>(#SUb.#t6b));
			this.#e.Center = new Point3D(this.#c.BoundingBoxCenterX, this.#c.BoundingBoxCenterY, #SUb.#a);
		}

		// Token: 0x06002703 RID: 9987 RVA: 0x000D7724 File Offset: 0x000D5924
		private void #clb()
		{
			if (this.#g != null && (this.#c.ShowFactored || this.#c.ShowNominal))
			{
				base.ModelEditorControl.AddToView(this.#g);
			}
		}

		// Token: 0x06002704 RID: 9988 RVA: 0x0002497E File Offset: 0x00022B7E
		private void #dlb()
		{
			base.ModelEditorControl.RemoveFromView(this.#g);
		}

		// Token: 0x06002705 RID: 9989 RVA: 0x0002499D File Offset: 0x00022B9D
		private void #elb(object #Ge, MouseEventArgs3D #He)
		{
			this.#hlb(#He);
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x0002499D File Offset: 0x00022B9D
		private void #flb(object #Ge, MouseEventArgs3D #He)
		{
			this.#hlb(#He);
		}

		// Token: 0x06002707 RID: 9991 RVA: 0x000249B2 File Offset: 0x00022BB2
		private void #glb()
		{
			if (this.#k == CreateHorizontalCrossSectionTool.#s6b.#b)
			{
				this.#k = CreateHorizontalCrossSectionTool.#s6b.#a;
				this.#ylb();
				this.#Ykb();
				if (this.AllowFreePlaneControl)
				{
					this.#clb();
				}
			}
		}

		// Token: 0x06002708 RID: 9992 RVA: 0x000D7770 File Offset: 0x000D5970
		private void #hlb(MouseEventArgs3D #He)
		{
			if (!this.AllowFreePlaneControl || base.ModelEditorControl.SuspendEvents)
			{
				return;
			}
			if ((this.#k == CreateHorizontalCrossSectionTool.#s6b.#b || this.#k == CreateHorizontalCrossSectionTool.#s6b.#d) && #He != null && #He.HitMousePosition != null && #He.HitObject != null)
			{
				double num = #He.HitMousePosition.Value.Z;
				this.AxialForce = this.#klb(num);
				this.#alb(num);
			}
		}

		// Token: 0x06002709 RID: 9993 RVA: 0x000D7808 File Offset: 0x000D5A08
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
			this.#o = true;
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				this.#olb(this.#mlb(this.AxialForce));
				this.#1kb();
				this.#ylb();
				this.#Ykb();
			}
		}

		// Token: 0x0600270A RID: 9994 RVA: 0x000D78D4 File Offset: 0x000D5AD4
		private void #ilb(bool #jlb)
		{
			if (!this.#o && #jlb)
			{
				return;
			}
			this.#o = false;
			if (#jlb)
			{
				base.FailureSurfaceToolContext.CommandsManager.ShowBaseVisualizationCommand.Execute();
			}
			this.#k = CreateHorizontalCrossSectionTool.#s6b.#b;
			this.#ylb();
			this.#Ykb();
			this.#glb();
		}

		// Token: 0x0600270B RID: 9995 RVA: 0x000249EA File Offset: 0x00022BEA
		public void #vfb()
		{
			this.#ilb(true);
		}

		// Token: 0x0600270C RID: 9996 RVA: 0x000D7934 File Offset: 0x000D5B34
		private double #klb(double #llb)
		{
			FailureSurface failureSurface = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface;
			return (#llb + failureSurface.TranslateVector.Z * failureSurface.ScaleVector.Z) / failureSurface.ScaleVector.Z;
		}

		// Token: 0x0600270D RID: 9997 RVA: 0x000D798C File Offset: 0x000D5B8C
		private double #mlb(double #nlb)
		{
			FailureSurface failureSurface = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface;
			return (#nlb - failureSurface.TranslateVector.Z) * failureSurface.ScaleVector.Z;
		}

		// Token: 0x0600270E RID: 9998 RVA: 0x000D79D8 File Offset: 0x000D5BD8
		private void #olb(double #Lkb)
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.FailureSurfaceToolContext.CommandsManager.RemoveSurfacesFromVisualizationCommand.Execute();
				FailureSurface failureSurface = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface;
				failureSurface.NominalCrossSectionSurface.#9ob();
				failureSurface.FactoredCrossSectionSurface.#9ob();
				#xbb #Kkb = this.PartToCut;
				this.#d.#Ikb(failureSurface, #Kkb, #Lkb);
				base.FailureSurfaceToolContext.CommandsManager.ShowCrossSectionCommand.Execute();
				this.#Emb(new EventArgs());
			}
		}

		// Token: 0x0600270F RID: 9999 RVA: 0x000D7AA4 File Offset: 0x000D5CA4
		private IBoxDrawingResult #plb()
		{
			IBoxDrawingResult boxDrawingResult = base.FailureSurfaceToolContext.DrawingResultsFactory.CreateBoxDrawingResult();
			boxDrawingResult.Center = new Point3D(this.#c.BoundingBoxCenterX, this.#c.BoundingBoxCenterY, this.#c.BoundingBoxCenterZ);
			boxDrawingResult.Size = new #03d(this.#c.BoundingBoxSizeX, this.#c.BoundingBoxSizeY, this.#c.BoundingBoxSizeZ);
			boxDrawingResult.Color = Color.FromArgb(1, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			return boxDrawingResult;
		}

		// Token: 0x06002710 RID: 10000 RVA: 0x000D7B54 File Offset: 0x000D5D54
		private IBoxDrawingResult #qlb()
		{
			IBoxDrawingResult boxDrawingResult = base.FailureSurfaceToolContext.DrawingResultsFactory.CreateBoxDrawingResult();
			boxDrawingResult.Center = new Point3D(this.#c.BoundingBoxCenterX, this.#c.BoundingBoxCenterY, this.#c.BoundingBoxCenterZ);
			boxDrawingResult.Size = new #03d(this.#c.BoundingBoxSizeX, this.#c.BoundingBoxSizeY, 0.25);
			boxDrawingResult.Color = base.FailureSurfaceToolContext.SettingsManager.CutPlaneColor;
			boxDrawingResult.UpdateNormal(this.#a, new #c4d(0.0, 0.0, 0.0));
			return boxDrawingResult;
		}

		// Token: 0x06002711 RID: 10001 RVA: 0x000D7C2C File Offset: 0x000D5E2C
		private IPolylineDrawingResult #rlb()
		{
			IPolylineDrawingResult polylineDrawingResult = base.FailureSurfaceToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			polylineDrawingResult.IsClosed = true;
			polylineDrawingResult.LineColor = this.#c.CutPlaneColor;
			polylineDrawingResult.LineThickness = this.#c.CutterBorderThickness;
			polylineDrawingResult.Positions = new List<Point3D>
			{
				new Point3D(this.#c.BoundingBoxCenterX + this.#c.BoundingBoxSizeX / 2.0, this.#c.BoundingBoxCenterY + this.#c.BoundingBoxSizeY / 2.0, this.#c.BoundingBoxCenterZ),
				new Point3D(this.#c.BoundingBoxCenterX - this.#c.BoundingBoxSizeX / 2.0, this.#c.BoundingBoxCenterY + this.#c.BoundingBoxSizeY / 2.0, this.#c.BoundingBoxCenterZ),
				new Point3D(this.#c.BoundingBoxCenterX - this.#c.BoundingBoxSizeX / 2.0, this.#c.BoundingBoxCenterY - this.#c.BoundingBoxSizeY / 2.0, this.#c.BoundingBoxCenterZ),
				new Point3D(this.#c.BoundingBoxCenterX + this.#c.BoundingBoxSizeX / 2.0, this.#c.BoundingBoxCenterY - this.#c.BoundingBoxSizeY / 2.0, this.#c.BoundingBoxCenterZ)
			};
			return polylineDrawingResult;
		}

		// Token: 0x06002712 RID: 10002 RVA: 0x000249FB File Offset: 0x00022BFB
		private void #slb(object #Ge, EventArgs #He)
		{
			this.#zlb();
			if (base.IsActive)
			{
				this.#Ykb();
			}
		}

		// Token: 0x06002713 RID: 10003 RVA: 0x00024A1D File Offset: 0x00022C1D
		private void #tlb(object #Ge, EventArgs #He)
		{
			if (base.IsActive)
			{
				this.#ylb();
			}
		}

		// Token: 0x06002714 RID: 10004 RVA: 0x000D7E00 File Offset: 0x000D6000
		private void #ulb(object #Ge, EventArgs #He)
		{
			base.#Cmb(ref this.#j);
			this.#j = base.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface.EventManagerFactory.CreateEventSource(this.#g);
			this.#j.MouseEnter += this.#flb;
			this.#j.MouseMove += this.#elb;
			base.EventManager.RegisterEventSource(this.#j);
			if (base.IsActive)
			{
				this.#ilb(false);
			}
		}

		// Token: 0x06002715 RID: 10005 RVA: 0x000D7EAC File Offset: 0x000D60AC
		private void #vlb()
		{
			this.#e.Color = (this.#f.LineColor = this.#c.CutPlaneColor);
			base.ModelEditorControl.TransparencySorter.RecollectTransparentModels();
		}

		// Token: 0x06002716 RID: 10006 RVA: 0x00003375 File Offset: 0x00001575
		private static bool #wlb()
		{
			return true;
		}

		// Token: 0x06002717 RID: 10007 RVA: 0x000D7EFC File Offset: 0x000D60FC
		private void #xlb()
		{
			if (this.#k == CreateHorizontalCrossSectionTool.#s6b.#c)
			{
				base.FailureSurfaceToolContext.ModelEditorControl.AddToView(this.#f);
				return;
			}
			base.FailureSurfaceToolContext.ModelEditorControl.AddToView(this.#e);
			base.ModelEditorControl.TransparencySorter.RecollectTransparentModels();
			IEventManager eventManager = base.EventManager;
			if (eventManager == null)
			{
				return;
			}
			eventManager.RegisterExcludedVisual3D(this.#e);
		}

		// Token: 0x06002718 RID: 10008 RVA: 0x00024A39 File Offset: 0x00022C39
		private void #ylb()
		{
			base.FailureSurfaceToolContext.ModelEditorControl.RemoveFromView(this.#e);
			base.FailureSurfaceToolContext.ModelEditorControl.RemoveFromView(this.#f);
		}

		// Token: 0x06002719 RID: 10009 RVA: 0x000D7F74 File Offset: 0x000D6174
		private void #zlb()
		{
			if (!this.#c.ShowFactored && !this.#c.ShowNominal)
			{
				return;
			}
			#3mb #3mb = base.FailureSurfaceToolContext.FailureSurfaceContext;
			FailureSurface failureSurface = #3mb.FailureSurface;
			double val;
			if (!this.#c.ShowFactored || !failureSurface.FactoredSurface.IsNotEmpty)
			{
				val = 0.0;
			}
			else
			{
				val = failureSurface.FactoredSurface.FailureSurface.Positions.Max(new Func<Point3D, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#u6b)) * 0.99;
			}
			double val2;
			if (!this.#c.ShowNominal || !failureSurface.NominalSurface.IsNotEmpty)
			{
				val2 = 0.0;
			}
			else
			{
				val2 = failureSurface.NominalSurface.FailureSurface.Positions.Max(new Func<Point3D, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#v6b));
			}
			double val3;
			if (failureSurface.LoadPoints.Count <= 0)
			{
				val3 = 0.0;
			}
			else
			{
				val3 = failureSurface.LoadPoints.Max(new Func<LoadPointData, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#w6b));
			}
			double num = Math.Max(val, Math.Max(val2, val3));
			double val4;
			if (!this.#c.ShowFactored || !failureSurface.FactoredSurface.IsNotEmpty)
			{
				val4 = 0.0;
			}
			else
			{
				val4 = failureSurface.FactoredSurface.FailureSurface.Positions.Min(new Func<Point3D, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#x6b));
			}
			double val5;
			if (!this.#c.ShowNominal || !failureSurface.NominalSurface.IsNotEmpty)
			{
				val5 = 0.0;
			}
			else
			{
				val5 = failureSurface.NominalSurface.FailureSurface.Positions.Min(new Func<Point3D, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#y6b));
			}
			double val6;
			if (failureSurface.LoadPoints.Count <= 0)
			{
				val6 = 0.0;
			}
			else
			{
				val6 = failureSurface.LoadPoints.Min(new Func<LoadPointData, double>(CreateHorizontalCrossSectionTool.<>c.<>9.#z6b));
			}
			double num2 = Math.Min(val4, Math.Min(val5, val6));
			double num3 = Math.Abs(num) + Math.Abs(num2);
			this.#g.Size = new #03d(this.#c.BoundingBoxSizeX, this.#c.BoundingBoxSizeY, num3);
			double num4 = num3 / 2.0;
			if (num > num4)
			{
				this.#g.Center = new Point3D(this.#c.BoundingBoxCenterX, this.#c.BoundingBoxCenterY, num - num4);
			}
			else
			{
				this.#g.Center = new Point3D(this.#c.BoundingBoxCenterX, this.#c.BoundingBoxCenterY, num2 + num4);
			}
			if (this.#e.Center.Z < num2)
			{
				this.AxialForce = this.#klb(num2);
				this.#alb(num2);
				this.#1db(new #pkb(this.#klb(num2)));
				return;
			}
			if (this.#e.Center.Z > num)
			{
				this.AxialForce = this.#klb(num);
				this.#alb(num);
				this.#1db(new #pkb(this.#klb(num)));
			}
		}

		// Token: 0x04000F6B RID: 3947
		private readonly #c4d #a = new #c4d(0.0, 0.0, 1.0);

		// Token: 0x04000F6C RID: 3948
		private readonly #2vb #b;

		// Token: 0x04000F6D RID: 3949
		private readonly ISettingsManager #c;

		// Token: 0x04000F6E RID: 3950
		private readonly #Ymb #d;

		// Token: 0x04000F6F RID: 3951
		private IBoxDrawingResult #e;

		// Token: 0x04000F70 RID: 3952
		private IPolylineDrawingResult #f;

		// Token: 0x04000F71 RID: 3953
		private IBoxDrawingResult #g;

		// Token: 0x04000F72 RID: 3954
		private double #h;

		// Token: 0x04000F73 RID: 3955
		private #xbb #i;

		// Token: 0x04000F74 RID: 3956
		private IEventSource #j;

		// Token: 0x04000F75 RID: 3957
		private CreateHorizontalCrossSectionTool.#s6b #k;

		// Token: 0x04000F76 RID: 3958
		private bool #l;

		// Token: 0x04000F77 RID: 3959
		[CompilerGenerated]
		private EventHandler<#pkb> #m;

		// Token: 0x04000F78 RID: 3960
		[CompilerGenerated]
		private EventHandler<#pkb> #n;

		// Token: 0x04000F79 RID: 3961
		private bool #o;

		// Token: 0x0200042F RID: 1071
		private enum #s6b
		{
			// Token: 0x04000F7B RID: 3963
			#a,
			// Token: 0x04000F7C RID: 3964
			#b,
			// Token: 0x04000F7D RID: 3965
			#c,
			// Token: 0x04000F7E RID: 3966
			#d
		}

		// Token: 0x02000430 RID: 1072
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000F7F RID: 3967
			public static Func<bool> #a;
		}

		// Token: 0x02000432 RID: 1074
		[CompilerGenerated]
		private sealed class #SUb
		{
			// Token: 0x06002723 RID: 10019 RVA: 0x00024A90 File Offset: 0x00022C90
			internal Point3D #t6b(Point3D #Ng)
			{
				return new Point3D(#Ng.X, #Ng.Y, this.#a);
			}

			// Token: 0x04000F87 RID: 3975
			public double #a;
		}
	}
}

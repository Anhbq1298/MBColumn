using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using #3vb;
using #6re;
using #7hc;
using #Cqb;
using #eU;
using #Mbb;
using #NHe;
using #o1d;
using #rCe;
using #S9;
using #u3d;
using #Wse;
using #Zjb;
using #Zmb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Core.Helpers;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Core
{
	// Token: 0x02000471 RID: 1137
	internal sealed class ModelVisualizationController : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #yrb
	{
		// Token: 0x060029FF RID: 10751 RVA: 0x000DFB40 File Offset: 0x000DDD40
		public ModelVisualizationController(ICoreServices services, #3mb failureSurfaceContext, IFailureSurfaceView failureSurfaceView, #2vb failureSurfaceCommandsManager, #zU guiController, IDrawingResultsFactory drawingResultsFactory, IEventManagerFactory eventManagerFactory, #tbb diagramsContext)
		{
			this.#z = new List<IPlaneDrawingResult>();
			this.#A = new List<IPlaneDrawingResult>();
			this.PlaneMxMy = new List<IPlaneDrawingResult>();
			this.#d = services;
			this.#e = failureSurfaceContext;
			this.#f = services.Settings;
			this.#g = drawingResultsFactory;
			this.#i = eventManagerFactory;
			this.#j = failureSurfaceCommandsManager;
			this.#k = diagramsContext;
			this.#l = guiController;
			this.#h = failureSurfaceView.ModelEditorControl;
			this.#h.CameraChanged += this.#Krb;
			this.#y = this.#i.CreateEventManager(this.#h);
		}

		// Token: 0x140000C3 RID: 195
		// (add) Token: 0x06002A00 RID: 10752 RVA: 0x000DFC94 File Offset: 0x000DDE94
		// (remove) Token: 0x06002A01 RID: 10753 RVA: 0x000DFCD8 File Offset: 0x000DDED8
		public event EventHandler<#Yjb> LoadPointClickedEventArgs
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Yjb> eventHandler = this.#x;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Yjb> eventHandler = this.#x;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000E68 RID: 3688
		// (get) Token: 0x06002A02 RID: 10754 RVA: 0x0002655B File Offset: 0x0002475B
		public IEventManager EventManager { get; }

		// Token: 0x17000E69 RID: 3689
		// (get) Token: 0x06002A03 RID: 10755 RVA: 0x00026567 File Offset: 0x00024767
		private FailureSurface FailureSurface
		{
			get
			{
				return this.#e.FailureSurface;
			}
		}

		// Token: 0x17000E6A RID: 3690
		// (get) Token: 0x06002A04 RID: 10756 RVA: 0x0002657C File Offset: 0x0002477C
		public IList<IPlaneDrawingResult> PlaneMyP { get; }

		// Token: 0x17000E6B RID: 3691
		// (get) Token: 0x06002A05 RID: 10757 RVA: 0x00026588 File Offset: 0x00024788
		public IList<IPlaneDrawingResult> PlanePMx { get; }

		// Token: 0x17000E6C RID: 3692
		// (get) Token: 0x06002A06 RID: 10758 RVA: 0x00026594 File Offset: 0x00024794
		// (set) Token: 0x06002A07 RID: 10759 RVA: 0x000265A0 File Offset: 0x000247A0
		public IList<IPlaneDrawingResult> PlaneMxMy { get; set; }

		// Token: 0x17000E6D RID: 3693
		// (get) Token: 0x06002A08 RID: 10760 RVA: 0x000265B1 File Offset: 0x000247B1
		// (set) Token: 0x06002A09 RID: 10761 RVA: 0x000DFD1C File Offset: 0x000DDF1C
		public string LoadPointsCountMessage
		{
			get
			{
				return this.#C;
			}
			set
			{
				if (this.#C != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107362172));
					this.#C = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362172));
				}
			}
		}

		// Token: 0x06002A0A RID: 10762 RVA: 0x000DFD6C File Offset: 0x000DDF6C
		public void #hrb(IList<SelectedLoadData> #tk)
		{
			ModelVisualizationController.#kWb #kWb = new ModelVisualizationController.#kWb();
			#kWb.#a = #tk;
			this.#u.Clear();
			this.#u.AddRange(#kWb.#a);
			List<#Frb> list = this.#n.Union(this.#m).ToList<#Frb>();
			HashSet<#Frb> hashSet = new HashSet<#Frb>(list.Where(new Func<#Frb, bool>(#kWb.#O6b)));
			this.#8fb(this.#v);
			foreach (#Frb #Frb in list)
			{
				double num = #Frb.DistanceRadiusScaleFactor;
				if (hashSet.Contains(#Frb))
				{
					#Frb.SphereDrawingResult.Color = (this.#s = this.#f.CrossSectionSelectedLoadPointColor);
					#Frb.DistanceRadiusScaleFactor = this.#f.CrossSectionSelectedLoadPointRadius;
				}
				else
				{
					#Frb.Color = (#Frb.LoadPointData.IsInner ? this.#f.CrossSectionInnerLoadPointColor : this.#f.CrossSectionOuterLoadPointColor);
					#Frb.DistanceRadiusScaleFactor = (#Frb.LoadPointData.IsInner ? this.#f.CrossSectionInnerLoadPointRadius : this.#f.CrossSectionOuterLoadPointRadius);
				}
				if (Math.Abs(num - #Frb.DistanceRadiusScaleFactor) > 0.0)
				{
					#Frb.Radius = this.#csb(#Frb);
				}
			}
		}

		// Token: 0x06002A0B RID: 10763 RVA: 0x000DFF08 File Offset: 0x000DE108
		public void #irb(#lte #Od)
		{
			this.#v = #Od;
			this.#e.FailureSurface = new FailureSurface(this.#g, this.#i, this.#f);
			this.#e.FailureSurface.#xob(#Od);
			this.#e.FailureSurface.#yob();
			this.#e.FailureSurface.#zob();
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x000DFF7C File Offset: 0x000DE17C
		public void #jrb(#cfb #krb)
		{
			if (this.FailureSurface == null)
			{
				return;
			}
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				if (#krb == #cfb.#a)
				{
					this.FailureSurface.NominalSurface.#7ob(this.#h);
					if (this.FailureSurface.NominalSurface.FailureSurface != null)
					{
						this.#h.TransparencySorter.AddAlwaysOnTopVisual(this.FailureSurface.NominalSurface.FailureSurface);
					}
				}
				else
				{
					this.FailureSurface.NominalCrossSectionSurface.#7ob(this.#h);
					if (this.FailureSurface.NominalCrossSectionSurface.FailureSurface != null)
					{
						this.#h.TransparencySorter.AddAlwaysOnTopVisual(this.FailureSurface.NominalCrossSectionSurface.FailureSurface);
					}
				}
			}
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x000E0074 File Offset: 0x000DE274
		public void #lrb()
		{
			if (this.FailureSurface == null)
			{
				return;
			}
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				this.FailureSurface.NominalSurface.#8ob(this.#h);
				if (this.FailureSurface.NominalSurface.FailureSurface != null)
				{
					this.#h.TransparencySorter.RemoveAlwaysOnTopVisual(this.FailureSurface.NominalSurface.FailureSurface);
				}
				this.FailureSurface.NominalCrossSectionSurface.#8ob(this.#h);
				if (this.FailureSurface.NominalCrossSectionSurface.FailureSurface != null)
				{
					this.#h.TransparencySorter.RemoveAlwaysOnTopVisual(this.FailureSurface.NominalCrossSectionSurface.FailureSurface);
				}
			}
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x000E0168 File Offset: 0x000DE368
		public void #mrb(#cfb #krb)
		{
			if (this.FailureSurface == null)
			{
				return;
			}
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				if (#krb == #cfb.#a)
				{
					this.FailureSurface.FactoredSurface.#7ob(this.#h);
					if (this.FailureSurface.FactoredSurface.FailureSurface != null)
					{
						this.#h.TransparencySorter.AddAlwaysOnTopVisual(this.FailureSurface.FactoredSurface.FailureSurface);
					}
				}
				else
				{
					this.FailureSurface.FactoredCrossSectionSurface.#7ob(this.#h);
					if (this.FailureSurface.FactoredCrossSectionSurface.FailureSurface != null)
					{
						this.#h.TransparencySorter.AddAlwaysOnTopVisual(this.FailureSurface.FactoredCrossSectionSurface.FailureSurface);
					}
				}
			}
		}

		// Token: 0x06002A0F RID: 10767 RVA: 0x000E0260 File Offset: 0x000DE460
		public void #nrb()
		{
			if (this.FailureSurface == null)
			{
				return;
			}
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				this.FailureSurface.FactoredSurface.#8ob(this.#h);
				if (this.FailureSurface.FactoredSurface.FailureSurface != null)
				{
					this.#h.TransparencySorter.RemoveAlwaysOnTopVisual(this.FailureSurface.FactoredSurface.FailureSurface);
				}
				this.FailureSurface.FactoredCrossSectionSurface.#8ob(this.#h);
				if (this.FailureSurface.FactoredCrossSectionSurface.FailureSurface != null)
				{
					this.#h.TransparencySorter.RemoveAlwaysOnTopVisual(this.FailureSurface.FactoredCrossSectionSurface.FailureSurface);
				}
			}
		}

		// Token: 0x06002A10 RID: 10768 RVA: 0x000E0354 File Offset: 0x000DE554
		public void #8fb(#lte #Od)
		{
			this.#7fb();
			this.#v = #Od;
			if (this.FailureSurface == null || #Od == null)
			{
				return;
			}
			this.#e.AreLoadPointsVisible = true;
			#Gse #mA = this.#d.ReporterSettings.#Hse(#Od);
			#5re #st = this.#d.ReporterSettings.#jJ();
			int num;
			List<LoadPointDrawingData> list = this.#Orb(#Od, #st, #mA, out num);
			if (list.Count < num)
			{
				this.LoadPointsCountMessage = Strings.StringOnly0LoadPointsOutOf1Shown.#D2d(new object[]
				{
					list.Count,
					num
				});
			}
			using (List<LoadPointDrawingData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ModelVisualizationController.#qUb #qUb = new ModelVisualizationController.#qUb();
					#qUb.#a = enumerator.Current;
					ModelVisualizationController.#U6b #U6b = new ModelVisualizationController.#U6b();
					#U6b.#a = this.FailureSurface.LoadPoints.FirstOrDefault(new Func<LoadPointData, bool>(#qUb.#R6b));
					if (#U6b.#a != null)
					{
						double #Irb = #U6b.#a.IsInner ? this.#f.CrossSectionInnerLoadPointRadius : this.#f.CrossSectionOuterLoadPointRadius;
						if (this.#u.Any(new Func<SelectedLoadData, bool>(#U6b.#S6b)))
						{
							#Irb = this.#f.CrossSectionSelectedLoadPointRadius;
						}
						#Frb #Frb = new #Frb(this.#g.CreateSphereDrawingResult(), #U6b.#a, #Irb)
						{
							Center = #U6b.#a.Center
						};
						Color color = #U6b.#a.IsInner ? this.#f.CrossSectionInnerLoadPointColor : this.#f.CrossSectionOuterLoadPointColor;
						if (this.#u.Any(new Func<SelectedLoadData, bool>(#U6b.#T6b)))
						{
							color = this.#f.CrossSectionSelectedLoadPointColor;
						}
						#Frb.Color = color;
						this.#h.AddToView(#Frb.SphereDrawingResult);
						#Frb.Radius = this.#csb(#Frb);
						if (#U6b.#a.IsInner)
						{
							this.#m.Add(#Frb);
						}
						else
						{
							this.#n.Add(#Frb);
						}
						IEventSource eventSource = this.FailureSurface.EventManagerFactory.CreateEventSource(#Frb.SphereDrawingResult);
						eventSource.MouseEnter += this.#Mrb;
						eventSource.MouseLeave += this.#Lrb;
						eventSource.MouseClick += this.#Jrb;
						this.EventManager.RegisterEventSource(eventSource);
					}
				}
			}
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x000E0618 File Offset: 0x000DE818
		public void #7fb()
		{
			this.LoadPointsCountMessage = null;
			this.EventManager.ClearAllEventSources();
			foreach (#Frb #Frb in this.#m)
			{
				this.#h.RemoveFromView(#Frb.SphereDrawingResult);
			}
			foreach (#Frb #Frb2 in this.#n)
			{
				this.#h.RemoveFromView(#Frb2.SphereDrawingResult);
			}
			this.#m.Clear();
			this.#n.Clear();
			this.#e.AreLoadPointsVisible = false;
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x000E0714 File Offset: 0x000DE914
		public void #orb()
		{
			Point3D #Clb = CoordinateSystemHelper.#zsb(this.#e.FailureSurface);
			this.#Vrb(#Clb, this.#e, this.#f);
			if (!this.#t)
			{
				this.#Zrb(#Clb);
				this.#t = true;
			}
		}

		// Token: 0x06002A13 RID: 10771 RVA: 0x000E0768 File Offset: 0x000DE968
		public void #prb()
		{
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				CoordinateSystemHelper.#xsb(this.#e.FailureSurface, this.#h);
			}
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x000E07C4 File Offset: 0x000DE9C4
		public void #qrb()
		{
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				CoordinateSystemHelper.#ysb(this.#e.FailureSurface, this.#h);
			}
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x000E0820 File Offset: 0x000DEA20
		public void #rrb()
		{
			IModelEditorControl modelEditorControl = this.#h;
			IDrawingResult drawingResult = this.#o;
			if (!false)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			this.#h.AddToView(this.#p);
			this.#h.AddToView(this.#q);
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x000E0870 File Offset: 0x000DEA70
		public void #srb()
		{
			IModelEditorControl modelEditorControl = this.#h;
			IDrawingResult drawingResult = this.#o;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			this.#h.RemoveFromView(this.#p);
			this.#h.RemoveFromView(this.#q);
		}

		// Token: 0x06002A17 RID: 10775 RVA: 0x000E08C0 File Offset: 0x000DEAC0
		public void #trb(#Bbb #urb)
		{
			switch (#urb)
			{
			case #Bbb.#a:
				if (this.#f.MainAxisPlaneXYColor.A > 0)
				{
					this.#h.AddToView(this.PlaneMxMy);
					return;
				}
				break;
			case #Bbb.#b:
				if (this.#f.MainAxisPlaneYZColor.A > 0)
				{
					this.#h.AddToView(this.PlaneMyP);
					return;
				}
				break;
			case #Bbb.#c:
				if (this.#f.MainAxisPlaneZXColor.A > 0)
				{
					this.#h.AddToView(this.PlanePMx);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x000E0974 File Offset: 0x000DEB74
		public void #vrb(#Bbb #urb)
		{
			switch (#urb)
			{
			case #Bbb.#a:
				this.#h.RemoveFromView(this.PlaneMxMy);
				return;
			case #Bbb.#b:
				this.#h.RemoveFromView(this.PlaneMyP);
				return;
			case #Bbb.#c:
				this.#h.RemoveFromView(this.PlanePMx);
				return;
			default:
				return;
			}
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #wrb()
		{
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x000E09D8 File Offset: 0x000DEBD8
		public void #xrb()
		{
			using (this.#h.TransparencySorter.BeginBulkUpdate())
			{
				this.#o.Color = this.#f.MainAxisXColor;
				this.#p.Color = this.#f.MainAxisYColor;
				this.#q.Color = this.#f.MainAxisZColor;
				this.#Srb(this.PlaneMxMy, this.#f.MainAxisPlaneXYColor, this.#f.Diagram3DIsMxMyPlaneVisible);
				this.#Srb(this.PlaneMyP, this.#f.MainAxisPlaneYZColor, this.#f.Diagram3DIsMyPPlaneVisible);
				this.#Srb(this.PlanePMx, this.#f.MainAxisPlaneZXColor, this.#f.Diagram3DIsPMxPlaneVisible);
				this.#h.CameraType = this.#f.CameraType;
				this.#7rb();
				this.#bsb();
				this.#9rb();
				this.#8rb();
				this.#asb();
			}
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x000E0B0C File Offset: 0x000DED0C
		public void #Nfb()
		{
			this.EventManager.ClearAllEventSources();
			this.#qrb();
			this.#srb();
			this.#7fb();
			this.#vrb(#Bbb.#a);
			this.#vrb(#Bbb.#b);
			this.#vrb(#Bbb.#c);
			this.#nrb();
			this.#lrb();
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x000E0B64 File Offset: 0x000DED64
		protected void #2db(#Yjb #He)
		{
			EventHandler<#Yjb> eventHandler = this.#x;
			if (eventHandler != null && this.#esb())
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x000E0B98 File Offset: 0x000DED98
		private void #Jrb(object #Ge, MouseButtonEventArgs3D #He)
		{
			ModelVisualizationController.#Q5b #Q5b = new ModelVisualizationController.#Q5b();
			if (#He.MouseData.ChangedButton != MouseButton.Right && #He.MouseData.ChangedButton != MouseButton.Left)
			{
				return;
			}
			object hitObject = #He.HitObject;
			#Q5b.#a = (hitObject as ISphereDrawingResult);
			if (#Q5b.#a == null)
			{
				return;
			}
			#Frb #Frb = this.#m.Union(this.#n).FirstOrDefault(new Func<#Frb, bool>(#Q5b.#V6b));
			if (#Frb == null)
			{
				return;
			}
			this.#2db(new #Yjb(#Frb.LoadPointData.MomentX, #Frb.LoadPointData.MomentY, #Frb.LoadPointData.AxialForce, #He.MouseData.ChangedButton, null));
			#Q5b.#a.Radius *= this.#w;
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x000E0C80 File Offset: 0x000DEE80
		private void #Krb(object #Ge, EventArgs #He)
		{
			foreach (#Frb #Frb in this.#m)
			{
				#Frb.Radius = this.#csb(#Frb);
			}
			foreach (#Frb #Frb2 in this.#n)
			{
				#Frb2.Radius = this.#csb(#Frb2);
			}
		}

		// Token: 0x06002A1F RID: 10783 RVA: 0x000E0D3C File Offset: 0x000DEF3C
		private void #Lrb(object #Ge, MouseEventArgs3D #He)
		{
			if (this.#h.SuspendEvents)
			{
				return;
			}
			ISphereDrawingResult sphereDrawingResult = #He.HitObject as ISphereDrawingResult;
			if (sphereDrawingResult != null)
			{
				sphereDrawingResult.Radius /= this.#w;
				this.#e.IsMouseCursorOnForcePoint = false;
				if (this.#r != null)
				{
					this.#r.Color = this.#s;
				}
				this.#l.EditorStatusBar.Diagram3D.#yl();
				this.#e.#smb(new EventArgs());
			}
		}

		// Token: 0x06002A20 RID: 10784 RVA: 0x000E0DE0 File Offset: 0x000DEFE0
		private void #Mrb(object #Ge, MouseEventArgs3D #He)
		{
			if (this.#h.SuspendEvents)
			{
				return;
			}
			ISphereDrawingResult sphereDrawingResult = #He.HitObject as ISphereDrawingResult;
			if (sphereDrawingResult != null)
			{
				this.#e.IsMouseCursorOnForcePoint = true;
				this.#r = sphereDrawingResult;
				this.#s = sphereDrawingResult.Color;
				sphereDrawingResult.Color = this.#f.CrossSectionHoverLoadPointColor;
				sphereDrawingResult.Radius *= this.#w;
				Point3D center = sphereDrawingResult.Center;
				this.#l.EditorStatusBar.Diagram3D.#8mb(this.FailureSurface.#vob(center));
				this.#e.#rmb(new EventArgs());
			}
		}

		// Token: 0x06002A21 RID: 10785 RVA: 0x000E0EA4 File Offset: 0x000DF0A4
		private static bool #3gb(SelectedLoadData #Au, LoadPointData #Nrb)
		{
			return LoadPointDetailsViewModel.#3gb(#Au.MomentX, new double?(#Nrb.MomentX)) && LoadPointDetailsViewModel.#3gb(#Au.MomentY, new double?(#Nrb.MomentY)) && LoadPointDetailsViewModel.#3gb(#Au.AxialForce, new double?(#Nrb.AxialForce));
		}

		// Token: 0x06002A22 RID: 10786 RVA: 0x000E0F08 File Offset: 0x000DF108
		private static bool #3gb(SelectedLoadData #Au, LoadPointDrawingData #Nrb)
		{
			return LoadPointDetailsViewModel.#3gb(#Au.MomentX, new double?((double)#Nrb.MomentX)) && LoadPointDetailsViewModel.#3gb(#Au.MomentY, new double?((double)#Nrb.MomentY)) && LoadPointDetailsViewModel.#3gb(#Au.AxialForce, new double?((double)#Nrb.AxialLoad));
		}

		// Token: 0x06002A23 RID: 10787 RVA: 0x000E0F6C File Offset: 0x000DF16C
		private List<LoadPointDrawingData> #Orb(#lte #Od, #5re #st, #8re #mA, out int #Prb)
		{
			List<LoadPointDrawingData> list = DiagramGeneratorHelper.#QHe(#Od, #uCe.#g, #mA, #Od.Input.Options.ActiveLoad, false);
			#Prb = list.Count;
			if (list.Count <= #st.MaxDisplayedLoadPoints || !this.#k.OpenedDiagramTypes.Any<Diagram2DType>())
			{
				list = this.#Qrb(list, #st.MaxDisplayedLoadPoints);
				return list;
			}
			HashSet<LoadPointDrawingData> hashSet = new HashSet<LoadPointDrawingData>();
			foreach (Diagram2DType diagram2DType in this.#k.OpenedDiagramTypes.Distinct<Diagram2DType>())
			{
				if (diagram2DType == Diagram2DType.DiagramMM)
				{
					List<LoadPointDrawingData> #yjb = DiagramGeneratorHelper.#QHe(#Od, #uCe.#g, #mA, #Od.Input.Options.ActiveLoad, false);
					int num;
					IEnumerable<LoadPointDrawingData> #8f = DiagramsHelper.#LFe(#yjb, this.#u, #st.MaxDisplayedLoadPoints, (float)this.#k.CurrentAxialLoad, out num).Select(new Func<LoadPointTempData, LoadPointDrawingData>(ModelVisualizationController.<>c.<>9.#W6b));
					hashSet.#pR(#8f);
				}
				else
				{
					#uCe #uCe = DiagramsHelper.#SFe(this.#k.CurrentAngle, #Od.Input.Options.ConsideredAxis);
					List<LoadPointDrawingData> #yjb2 = DiagramGeneratorHelper.#QHe(#Od, #uCe, #mA, #Od.Input.Options.ActiveLoad, false);
					if (#uCe > #uCe.#b)
					{
						if (#uCe - #uCe.#c <= 3)
						{
							#0Ie #pNb = DiagramsHelper.#TFe(diagram2DType);
							int num;
							List<LoadPointTempData> source = DiagramsHelper.#OFe(#yjb2, this.#u, #Od.Input.Options.ConsideredAxis, #st.MaxDisplayedLoadPoints, (float)this.#k.CurrentAngle, #pNb, out num);
							hashSet.#pR(source.Select(new Func<LoadPointTempData, LoadPointDrawingData>(ModelVisualizationController.<>c.<>9.#Y6b)));
						}
					}
					else
					{
						int num;
						List<LoadPointTempData> source2 = DiagramsHelper.#RFe(#yjb2, this.#u, #Od.Input.Options.ConsideredAxis, #st.MaxDisplayedLoadPoints, out num);
						hashSet.#pR(source2.Select(new Func<LoadPointTempData, LoadPointDrawingData>(ModelVisualizationController.<>c.<>9.#X6b)));
					}
				}
			}
			if (hashSet.Count < #st.MaxDisplayedLoadPoints)
			{
				IEnumerable<LoadPointDrawingData> second = list.Except(hashSet).OrderByDescending(new Func<LoadPointDrawingData, double?>(ModelVisualizationController.<>c.<>9.#Z6b)).Take(#st.MaxDisplayedLoadPoints - hashSet.Count);
				return hashSet.Union(second).ToList<LoadPointDrawingData>();
			}
			return hashSet.ToList<LoadPointDrawingData>();
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x000E122C File Offset: 0x000DF42C
		private List<LoadPointDrawingData> #Qrb(IList<LoadPointDrawingData> #yjb, int #Rrb)
		{
			List<LoadPointDrawingData> list = #yjb.Where(new Func<LoadPointDrawingData, bool>(this.#fsb)).ToList<LoadPointDrawingData>();
			IOrderedEnumerable<LoadPointDrawingData> source = #yjb.Except(list).OrderByDescending(new Func<LoadPointDrawingData, double?>(ModelVisualizationController.<>c.<>9.#06b));
			return list.Union(source.OrderByDescending(new Func<LoadPointDrawingData, double?>(ModelVisualizationController.<>c.<>9.#16b)).Take(Math.Max(#Rrb - list.Count, 0))).ToList<LoadPointDrawingData>();
		}

		// Token: 0x06002A25 RID: 10789 RVA: 0x000E12E0 File Offset: 0x000DF4E0
		private void #Srb(IList<IPlaneDrawingResult> #Trb, Color #BR, bool #Urb)
		{
			foreach (IPlaneDrawingResult planeDrawingResult in #Trb)
			{
				planeDrawingResult.Color = #BR;
				if (this.#h.IsInView(planeDrawingResult))
				{
					if (#BR.A <= 0)
					{
						this.#h.RemoveFromView(planeDrawingResult);
					}
				}
				else if (#Urb && #BR.A > 0)
				{
					this.#h.AddToView(planeDrawingResult);
				}
			}
		}

		// Token: 0x06002A26 RID: 10790 RVA: 0x000E1384 File Offset: 0x000DF584
		private void #Vrb(Point3D #Clb, #3mb #ib, ISettingsManager #ng)
		{
			double num = 0.0;
			double num2 = 0.0;
			if (#ng.ShowNominal && #ib.FailureSurface.NominalSurface.FailureSurface != null)
			{
				num = #ib.FailureSurface.NominalSurface.FailureSurface.Positions.Min(new Func<Point3D, double>(ModelVisualizationController.<>c.<>9.#26b));
				num2 = #ib.FailureSurface.NominalSurface.FailureSurface.Positions.Max(new Func<Point3D, double>(ModelVisualizationController.<>c.<>9.#36b));
			}
			else if (#ng.ShowFactored && #ib.FailureSurface.FactoredSurface.FailureSurface != null)
			{
				num = #ib.FailureSurface.FactoredSurface.FailureSurface.Positions.Min(new Func<Point3D, double>(ModelVisualizationController.<>c.<>9.#46b));
				num2 = #ib.FailureSurface.FactoredSurface.FailureSurface.Positions.Max(new Func<Point3D, double>(ModelVisualizationController.<>c.<>9.#56b));
			}
			num2 += 0.1 * Math.Abs(num2 - num);
			num -= 0.1 * Math.Abs(num2 - num);
			this.#o = this.#Wrb(new Point3D(-(this.#f.BoundingBoxSizeX / 2.0) - 10.0, #Clb.Y, #Clb.Z), new Point3D(this.#f.BoundingBoxSizeX / 2.0 + 10.0, #Clb.Y, #Clb.Z), this.#f.MainAxisXColor);
			this.#p = this.#Wrb(new Point3D(#Clb.X, -(this.#f.BoundingBoxSizeY / 2.0) - 10.0, #Clb.Z), new Point3D(#Clb.X, this.#f.BoundingBoxSizeY / 2.0 + 10.0, #Clb.Z), this.#f.MainAxisYColor);
			this.#q = this.#Wrb(new Point3D(#Clb.X, #Clb.Y, num), new Point3D(#Clb.X, #Clb.Y, num2), this.#f.MainAxisZColor);
		}

		// Token: 0x06002A27 RID: 10791 RVA: 0x000E164C File Offset: 0x000DF84C
		private IArrowDrawingResult #Wrb(Point3D #Xrb, Point3D #Yrb, Color #BR)
		{
			IArrowDrawingResult arrowDrawingResult = this.#g.CreateArrowDrawingResult();
			arrowDrawingResult.ArrowRadius = this.#f.MainAxisArrowRadius;
			arrowDrawingResult.Radius = this.#f.MainAxisRadius;
			arrowDrawingResult.Color = #BR;
			arrowDrawingResult.StartPosition = #Xrb;
			arrowDrawingResult.EndPosition = #Yrb;
			return arrowDrawingResult;
		}

		// Token: 0x06002A28 RID: 10792 RVA: 0x000265BD File Offset: 0x000247BD
		private void #Zrb(Point3D #Clb)
		{
			this.#0rb(#Clb);
			this.#3rb(#Clb);
			this.#5rb(#Clb);
		}

		// Token: 0x06002A29 RID: 10793 RVA: 0x000E16AC File Offset: 0x000DF8AC
		private void #0rb(Point3D #Clb)
		{
			this.PlaneMxMy = new List<IPlaneDrawingResult>
			{
				this.#1rb(new Point3D(this.#f.BoundingBoxCenterX + this.#f.BoundingBoxSizeX / 4.0, this.#f.BoundingBoxCenterY + this.#f.BoundingBoxSizeY / 4.0, #Clb.Z)),
				this.#1rb(new Point3D(this.#f.BoundingBoxCenterX - this.#f.BoundingBoxSizeX / 4.0, this.#f.BoundingBoxCenterY + this.#f.BoundingBoxSizeY / 4.0, #Clb.Z)),
				this.#1rb(new Point3D(this.#f.BoundingBoxCenterX - this.#f.BoundingBoxSizeX / 4.0, this.#f.BoundingBoxCenterY - this.#f.BoundingBoxSizeY / 4.0, #Clb.Z)),
				this.#1rb(new Point3D(this.#f.BoundingBoxCenterX + this.#f.BoundingBoxSizeX / 4.0, this.#f.BoundingBoxCenterY - this.#f.BoundingBoxSizeY / 4.0, #Clb.Z))
			};
		}

		// Token: 0x06002A2A RID: 10794 RVA: 0x000E184C File Offset: 0x000DFA4C
		private IPlaneDrawingResult #1rb(Point3D #2rb)
		{
			IPlaneDrawingResult planeDrawingResult = this.#g.CreatePlaneDrawingResult();
			IPlaneDrawingResult planeDrawingResult2;
			if (2 != 0)
			{
				planeDrawingResult2 = planeDrawingResult;
			}
			planeDrawingResult2.CenterPosition = #2rb;
			planeDrawingResult2.Color = this.#f.MainAxisPlaneXYColor;
			planeDrawingResult2.HeightDirection = this.#a;
			planeDrawingResult2.Normal = this.#c;
			planeDrawingResult2.Size = new Size(this.#f.BoundingBoxSizeX / 2.0, this.#f.BoundingBoxSizeY / 2.0);
			return planeDrawingResult2;
		}

		// Token: 0x06002A2B RID: 10795 RVA: 0x000E18DC File Offset: 0x000DFADC
		private void #3rb(Point3D #Clb)
		{
			double num = Math.Abs(this.#f.BoundingBoxSizeZ / 2.0 - #Clb.Z);
			double num2 = Math.Abs(-this.#f.BoundingBoxSizeZ / 2.0 - #Clb.Z);
			if (!double.IsNaN(num) && num > 0.0)
			{
				Point3D #2rb = new Point3D(#Clb.X, this.#f.BoundingBoxCenterY + this.#f.BoundingBoxSizeY / 4.0, #Clb.Z + num / 2.0);
				Point3D #2rb2 = new Point3D(#Clb.X, this.#f.BoundingBoxCenterY - this.#f.BoundingBoxSizeY / 4.0, #Clb.Z + num / 2.0);
				this.PlaneMyP.Add(this.#4rb(#2rb, num));
				this.PlaneMyP.Add(this.#4rb(#2rb2, num));
			}
			if (!double.IsNaN(num2) && num2 > 0.0)
			{
				Point3D #2rb3 = new Point3D(#Clb.X, this.#f.BoundingBoxCenterY - this.#f.BoundingBoxSizeY / 4.0, #Clb.Z - num2 / 2.0);
				Point3D #2rb4 = new Point3D(#Clb.X, this.#f.BoundingBoxCenterY + this.#f.BoundingBoxSizeY / 4.0, #Clb.Z - num2 / 2.0);
				this.PlaneMyP.Add(this.#4rb(#2rb3, num2));
				this.PlaneMyP.Add(this.#4rb(#2rb4, num2));
			}
		}

		// Token: 0x06002A2C RID: 10796 RVA: 0x000E1AD8 File Offset: 0x000DFCD8
		private IPlaneDrawingResult #4rb(Point3D #2rb, double #6Q)
		{
			IPlaneDrawingResult planeDrawingResult = this.#g.CreatePlaneDrawingResult();
			planeDrawingResult.CenterPosition = #2rb;
			planeDrawingResult.Color = this.#f.MainAxisPlaneYZColor;
			planeDrawingResult.HeightDirection = this.#b;
			planeDrawingResult.Normal = this.#a;
			planeDrawingResult.Size = new Size(#6Q, this.#f.BoundingBoxSizeY / 2.0);
			return planeDrawingResult;
		}

		// Token: 0x06002A2D RID: 10797 RVA: 0x000E1B50 File Offset: 0x000DFD50
		private void #5rb(Point3D #Clb)
		{
			double num = Math.Abs(this.#f.BoundingBoxSizeZ / 2.0 - #Clb.Z);
			double num2 = Math.Abs(-this.#f.BoundingBoxSizeZ / 2.0 - #Clb.Z);
			if (!double.IsNaN(num) && num > 0.0)
			{
				Point3D #2rb = new Point3D(this.#f.BoundingBoxCenterX + this.#f.BoundingBoxSizeX / 4.0, #Clb.Y, #Clb.Z + num / 2.0);
				Point3D #2rb2 = new Point3D(this.#f.BoundingBoxCenterX - this.#f.BoundingBoxSizeX / 4.0, #Clb.Y, #Clb.Z + num / 2.0);
				this.PlanePMx.Add(this.#6rb(#2rb, num));
				this.PlanePMx.Add(this.#6rb(#2rb2, num));
			}
			if (!double.IsNaN(num2) && num2 > 0.0)
			{
				Point3D #2rb3 = new Point3D(this.#f.BoundingBoxCenterX - this.#f.BoundingBoxSizeX / 4.0, #Clb.Y, #Clb.Z - num2 / 2.0);
				Point3D #2rb4 = new Point3D(this.#f.BoundingBoxCenterX + this.#f.BoundingBoxSizeX / 4.0, #Clb.Y, #Clb.Z - num2 / 2.0);
				this.PlanePMx.Add(this.#6rb(#2rb3, num2));
				this.PlanePMx.Add(this.#6rb(#2rb4, num2));
			}
		}

		// Token: 0x06002A2E RID: 10798 RVA: 0x000E1D4C File Offset: 0x000DFF4C
		private IPlaneDrawingResult #6rb(Point3D #2rb, double #6Q)
		{
			IPlaneDrawingResult planeDrawingResult = this.#g.CreatePlaneDrawingResult();
			planeDrawingResult.CenterPosition = #2rb;
			planeDrawingResult.Color = this.#f.MainAxisPlaneZXColor;
			planeDrawingResult.HeightDirection = this.#c;
			planeDrawingResult.Normal = this.#b;
			planeDrawingResult.Size = new Size(this.#f.BoundingBoxSizeX / 2.0, #6Q);
			return planeDrawingResult;
		}

		// Token: 0x06002A2F RID: 10799 RVA: 0x000E1DC4 File Offset: 0x000DFFC4
		private void #7rb()
		{
			FailureSurface failureSurface = this.#e.FailureSurface;
			FailureSurface failureSurface2;
			if (!false)
			{
				failureSurface2 = failureSurface;
			}
			if (failureSurface2.BoundingBoxDrawingResult != null)
			{
				failureSurface2.BoundingBoxDrawingResult.LineColor = this.#f.CoordinateSystemColor;
			}
			foreach (IMultilineDrawingResult multilineDrawingResult in failureSurface2.AxisLines)
			{
				multilineDrawingResult.LineColor = this.#f.CoordinateSystemColor;
			}
			foreach (ITextDrawingResult textDrawingResult in failureSurface2.AxesTexts)
			{
				textDrawingResult.TextColor = this.#f.CoordinateSystemColor;
			}
		}

		// Token: 0x06002A30 RID: 10800 RVA: 0x000265E0 File Offset: 0x000247E0
		private void #8rb()
		{
			this.#j.UpdateHorizontalCutterColorCommand.Execute();
			this.#j.UpdateVerticalCutterColorCommand.Execute();
		}

		// Token: 0x06002A31 RID: 10801 RVA: 0x000E1EB0 File Offset: 0x000E00B0
		private void #9rb()
		{
			if (this.FailureSurface.FactoredSurface.FailureSurface != null)
			{
				this.FailureSurface.FactoredSurface.FailureSurface.SetColor(this.#f.FailureSurfaceFactoredSurfaceColor, null);
				if (this.FailureSurface.FactoredCrossSectionSurface.IsNotEmpty)
				{
					this.FailureSurface.FactoredCrossSectionSurface.FailureSurface.SetColor(this.#f.FailureSurfaceFactoredSurfaceColor, null);
				}
			}
			if (this.FailureSurface.NominalSurface.FailureSurface != null)
			{
				this.FailureSurface.NominalSurface.FailureSurface.SetColor(this.#f.FailureSurfaceNominalSurfaceColor, null);
				if (this.FailureSurface.NominalCrossSectionSurface.IsNotEmpty)
				{
					this.FailureSurface.NominalCrossSectionSurface.FailureSurface.SetColor(this.#f.FailureSurfaceNominalSurfaceColor, null);
				}
			}
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x000E1FC8 File Offset: 0x000E01C8
		private void #asb()
		{
			foreach (IMultiPolyLineDrawingResult multiPolyLineDrawingResult in this.FailureSurface.NominalSurface.Wireframe)
			{
				multiPolyLineDrawingResult.LineColor = this.#f.FailureSurfaceNominalWireframeLineColor;
				multiPolyLineDrawingResult.LineThickness = this.#f.FailureSurfaceNominalWireframeLineThickness;
			}
			foreach (IMultiPolyLineDrawingResult multiPolyLineDrawingResult2 in this.FailureSurface.NominalCrossSectionSurface.Wireframe)
			{
				multiPolyLineDrawingResult2.LineColor = this.#f.FailureSurfaceNominalWireframeLineColor;
				multiPolyLineDrawingResult2.LineThickness = this.#f.FailureSurfaceNominalWireframeLineThickness;
			}
			foreach (IMultiPolyLineDrawingResult multiPolyLineDrawingResult3 in this.FailureSurface.FactoredSurface.Wireframe)
			{
				multiPolyLineDrawingResult3.LineColor = this.#f.FailureSurfaceFactoredWireframeLineColor;
				multiPolyLineDrawingResult3.LineThickness = this.#f.FailureSurfaceFactoredWireframeLineThickness;
			}
			foreach (IMultiPolyLineDrawingResult multiPolyLineDrawingResult4 in this.FailureSurface.FactoredCrossSectionSurface.Wireframe)
			{
				multiPolyLineDrawingResult4.LineColor = this.#f.FailureSurfaceFactoredWireframeLineColor;
				multiPolyLineDrawingResult4.LineThickness = this.#f.FailureSurfaceFactoredWireframeLineThickness;
			}
		}

		// Token: 0x06002A33 RID: 10803 RVA: 0x000E219C File Offset: 0x000E039C
		private void #bsb()
		{
			foreach (#Frb #Frb in this.#m)
			{
				#Frb.Color = this.#f.CrossSectionInnerLoadPointColor;
				#Frb.DistanceRadiusScaleFactor = this.#f.CrossSectionInnerLoadPointRadius;
				#Frb.Radius = this.#csb(#Frb);
			}
			foreach (#Frb #Frb2 in this.#n)
			{
				#Frb2.Color = this.#f.CrossSectionOuterLoadPointColor;
				#Frb2.DistanceRadiusScaleFactor = this.#f.CrossSectionOuterLoadPointRadius;
				#Frb2.Radius = this.#csb(#Frb2);
			}
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x000E22A0 File Offset: 0x000E04A0
		private double #csb(#Frb #dsb)
		{
			double num = #dsb.DistanceRadiusScaleFactor;
			if (this.#e.AreLoadPointsVisible)
			{
				double? num2 = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#h, #dsb.SphereDrawingResult, #dsb.Center, num);
				if (num2 != null)
				{
					num = num2.Value;
				}
			}
			return Math.Max(num, 0.01);
		}

		// Token: 0x06002A35 RID: 10805 RVA: 0x000E2308 File Offset: 0x000E0508
		private bool #esb()
		{
			return !this.#h.CursorState.PaneModeEnabled && !this.#h.CursorState.RotateModeEnabled && !this.#h.CursorState.ZoomToWindowEnabled;
		}

		// Token: 0x06002A36 RID: 10806 RVA: 0x000E235C File Offset: 0x000E055C
		[CompilerGenerated]
		private bool #fsb(LoadPointDrawingData #gsb)
		{
			ModelVisualizationController.#86b #86b = new ModelVisualizationController.#86b();
			#86b.#a = #gsb;
			return this.#u.Any(new Func<SelectedLoadData, bool>(#86b.#66b));
		}

		// Token: 0x040010BA RID: 4282
		private readonly #c4d #a = new #c4d(1.0, 0.0, 0.0);

		// Token: 0x040010BB RID: 4283
		private readonly #c4d #b = new #c4d(0.0, 1.0, 0.0);

		// Token: 0x040010BC RID: 4284
		private readonly #c4d #c = new #c4d(0.0, 0.0, 1.0);

		// Token: 0x040010BD RID: 4285
		private readonly ICoreServices #d;

		// Token: 0x040010BE RID: 4286
		private readonly #3mb #e;

		// Token: 0x040010BF RID: 4287
		private readonly ISettingsManager #f;

		// Token: 0x040010C0 RID: 4288
		private readonly IDrawingResultsFactory #g;

		// Token: 0x040010C1 RID: 4289
		private readonly IModelEditorControl #h;

		// Token: 0x040010C2 RID: 4290
		private readonly IEventManagerFactory #i;

		// Token: 0x040010C3 RID: 4291
		private readonly #2vb #j;

		// Token: 0x040010C4 RID: 4292
		private readonly #tbb #k;

		// Token: 0x040010C5 RID: 4293
		private readonly #zU #l;

		// Token: 0x040010C6 RID: 4294
		private readonly List<#Frb> #m = new List<#Frb>();

		// Token: 0x040010C7 RID: 4295
		private readonly List<#Frb> #n = new List<#Frb>();

		// Token: 0x040010C8 RID: 4296
		private IArrowDrawingResult #o;

		// Token: 0x040010C9 RID: 4297
		private IArrowDrawingResult #p;

		// Token: 0x040010CA RID: 4298
		private IArrowDrawingResult #q;

		// Token: 0x040010CB RID: 4299
		private ISphereDrawingResult #r;

		// Token: 0x040010CC RID: 4300
		private Color #s;

		// Token: 0x040010CD RID: 4301
		private bool #t;

		// Token: 0x040010CE RID: 4302
		private readonly List<SelectedLoadData> #u = new List<SelectedLoadData>();

		// Token: 0x040010CF RID: 4303
		private #lte #v;

		// Token: 0x040010D0 RID: 4304
		private readonly double #w = 1.25;

		// Token: 0x040010D1 RID: 4305
		[CompilerGenerated]
		private EventHandler<#Yjb> #x;

		// Token: 0x040010D2 RID: 4306
		[CompilerGenerated]
		private readonly IEventManager #y;

		// Token: 0x040010D3 RID: 4307
		[CompilerGenerated]
		private readonly IList<IPlaneDrawingResult> #z;

		// Token: 0x040010D4 RID: 4308
		[CompilerGenerated]
		private readonly IList<IPlaneDrawingResult> #A;

		// Token: 0x040010D5 RID: 4309
		[CompilerGenerated]
		private IList<IPlaneDrawingResult> #B;

		// Token: 0x040010D6 RID: 4310
		private string #C;

		// Token: 0x02000473 RID: 1139
		[CompilerGenerated]
		private sealed class #kWb
		{
			// Token: 0x06002A44 RID: 10820 RVA: 0x000E239C File Offset: 0x000E059C
			internal bool #O6b(#Frb #Nrb)
			{
				ModelVisualizationController.#Q6b #Q6b = new ModelVisualizationController.#Q6b();
				#Q6b.#a = #Nrb;
				return this.#a.Any(new Func<SelectedLoadData, bool>(#Q6b.#P6b));
			}

			// Token: 0x040010E2 RID: 4322
			public IList<SelectedLoadData> #a;
		}

		// Token: 0x02000474 RID: 1140
		[CompilerGenerated]
		private sealed class #Q6b
		{
			// Token: 0x06002A46 RID: 10822 RVA: 0x00026647 File Offset: 0x00024847
			internal bool #P6b(SelectedLoadData #Au)
			{
				return ModelVisualizationController.#3gb(#Au, this.#a.LoadPointData);
			}

			// Token: 0x040010E3 RID: 4323
			public #Frb #a;
		}

		// Token: 0x02000475 RID: 1141
		[CompilerGenerated]
		private sealed class #qUb
		{
			// Token: 0x06002A48 RID: 10824 RVA: 0x00026666 File Offset: 0x00024866
			internal bool #R6b(LoadPointData #Rf)
			{
				return #Rf.#uC((double)this.#a.AxialLoad, (double)this.#a.MomentX, (double)this.#a.MomentY);
			}

			// Token: 0x040010E4 RID: 4324
			public LoadPointDrawingData #a;
		}

		// Token: 0x02000476 RID: 1142
		[CompilerGenerated]
		private sealed class #U6b
		{
			// Token: 0x06002A4A RID: 10826 RVA: 0x0002669E File Offset: 0x0002489E
			internal bool #S6b(SelectedLoadData #Au)
			{
				return ModelVisualizationController.#3gb(#Au, this.#a);
			}

			// Token: 0x06002A4B RID: 10827 RVA: 0x0002669E File Offset: 0x0002489E
			internal bool #T6b(SelectedLoadData #Au)
			{
				return ModelVisualizationController.#3gb(#Au, this.#a);
			}

			// Token: 0x040010E5 RID: 4325
			public LoadPointData #a;
		}

		// Token: 0x02000477 RID: 1143
		[CompilerGenerated]
		private sealed class #Q5b
		{
			// Token: 0x06002A4D RID: 10829 RVA: 0x000266B8 File Offset: 0x000248B8
			internal bool #V6b(#Frb #Rf)
			{
				return #Rf.SphereDrawingResult == this.#a;
			}

			// Token: 0x040010E6 RID: 4326
			public ISphereDrawingResult #a;
		}

		// Token: 0x02000478 RID: 1144
		[CompilerGenerated]
		private sealed class #86b
		{
			// Token: 0x06002A4F RID: 10831 RVA: 0x000266D4 File Offset: 0x000248D4
			internal bool #66b(SelectedLoadData #76b)
			{
				return ModelVisualizationController.#3gb(#76b, this.#a);
			}

			// Token: 0x040010E7 RID: 4327
			public LoadPointDrawingData #a;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #LFb;
using #N6c;
using #RJb;
using #xKe;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select
{
	// Token: 0x02000518 RID: 1304
	internal sealed class MirrorModelTool : #tNb, #uNb, IChildColumnEditorTool, #SFb
	{
		// Token: 0x06002F2D RID: 12077 RVA: 0x0002A301 File Offset: 0x00028501
		public MirrorModelTool(IExtendedServices services, IEditorService editorService) : base(services)
		{
			this.#a = editorService;
		}

		// Token: 0x17000F7E RID: 3966
		// (get) Token: 0x06002F2E RID: 12078 RVA: 0x0002A311 File Offset: 0x00028511
		// (set) Token: 0x06002F2F RID: 12079 RVA: 0x000F388C File Offset: 0x000F1A8C
		public bool IsEnabled
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					if (this.#b)
					{
						base.#KMb(Strings.StringSpecifyMirrorLineStart, true, false, true);
						return;
					}
					this.#fAb(false);
					base.#JMb();
				}
			}
		}

		// Token: 0x06002F30 RID: 12080 RVA: 0x000F38DC File Offset: 0x000F1ADC
		public override void #1kb()
		{
			base.#1kb();
			bool #gAb = this.#c == MirrorModelTool.#s6b.#a;
			this.#fAb(#gAb);
		}

		// Token: 0x06002F31 RID: 12081 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x06002F32 RID: 12082 RVA: 0x000F390C File Offset: 0x000F1B0C
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			base.#fzb(#Ng, #gzb);
			if (!base.#WMb(true) || !this.#jAb())
			{
				return false;
			}
			if (this.#c == MirrorModelTool.#s6b.#a)
			{
				this.#d = #Ng;
				this.#e = null;
				this.#c = MirrorModelTool.#s6b.#b;
				base.#KMb(Strings.StringSpecifyMirrorLineEnd, true, false, true);
				base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			if (this.#c == MirrorModelTool.#s6b.#b)
			{
				this.#e = #Ng;
				this.#c = MirrorModelTool.#s6b.#c;
				return this.#iAb();
			}
			return true;
		}

		// Token: 0x06002F33 RID: 12083 RVA: 0x0002A00D File Offset: 0x0002820D
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002F34 RID: 12084 RVA: 0x000F39C4 File Offset: 0x000F1BC4
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			MirrorModelTool.#BUb #BUb = new MirrorModelTool.#BUb();
			#BUb.#a = this;
			#BUb.#b = planePosition;
			base.HandleDrawOverlay(data, screenPosition, #BUb.#b);
			#BUb.#b = base.#cNb(#LLb.#n, #BUb.#b);
			base.Services.GuiController.EditorStatusBar.Section.#uP(#BUb.#b);
			#BUb.#b = (this.#e ?? #BUb.#b);
			if (this.#c == MirrorModelTool.#s6b.#b)
			{
				#BUb.#c = this.#LAb();
				List<ShapeModel> list = base.EditorContext.Selection.Shapes.SelectedInNaturalOrder.OrderByDescending(new Func<ShapeModel, bool>(MirrorModelTool.<>c.<>9.#M8b)).ToList<ShapeModel>();
				foreach (ShapeModel shapeModel in list)
				{
					List<devDept.Geometry.Point3D> list2 = ColumnShapesHelper.#DHb(base.Project, base.EditorContext.Settings, shapeModel, null);
					IEnumerable<devDept.Geometry.Point3D> source = list2;
					Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D> selector;
					if ((selector = #BUb.#d) == null)
					{
						selector = (#BUb.#d = new Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D>(#BUb.#L8b));
					}
					list2 = source.Select(selector).Where(new Func<devDept.Geometry.Point3D, bool>(MirrorModelTool.<>c.<>9.#N8b)).ToList<devDept.Geometry.Point3D>();
					ColumnShapesHelper.#IHb(list2, base.EditorContext, #qHb.#b, shapeModel.Application);
				}
				#47c<ReinforcementBar> #47c = base.EditorContext.Selection.Bars.SelectedObjects;
				List<ReinforcementBar> list3 = new List<ReinforcementBar>();
				foreach (ReinforcementBar reinforcementBar in #47c)
				{
					devDept.Geometry.Point3D #HAb = reinforcementBar.Point;
					devDept.Geometry.Point3D point3D = MirrorModelTool.#GAb(#HAb, this.#d, #BUb.#b, #BUb.#c);
					if (!(point3D == null))
					{
						ReinforcementBar item = new ReinforcementBar(reinforcementBar.Area, (float)point3D.X, (float)point3D.Y, (float)point3D.Z);
						list3.Add(item);
					}
				}
				ColumnShapesHelper.#HHb(list3, base.EditorContext, #qHb.#b, null);
				base.#8Mb(this.#d, #BUb.#b);
			}
		}

		// Token: 0x06002F35 RID: 12085 RVA: 0x000F3C48 File Offset: 0x000F1E48
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			if (this.#c == MirrorModelTool.#s6b.#a)
			{
				this.#d = null;
				this.#e = null;
				return;
			}
			if (this.#c == MirrorModelTool.#s6b.#b)
			{
				this.#e = args.Point;
				base.#vf();
			}
		}

		// Token: 0x06002F36 RID: 12086 RVA: 0x0002A31D File Offset: 0x0002851D
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#fzb(args.Point, true);
			args.Handled = true;
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x000F3CAC File Offset: 0x000F1EAC
		public static devDept.Geometry.Point3D #GAb(devDept.Geometry.Point3D #HAb, devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, double #IAb)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = #HAb.#QW();
			StructurePoint.CoreAssets.Infrastructure.Data.Point point2 = #Xrb.#QW();
			StructurePoint.CoreAssets.Infrastructure.Data.Point point3 = #Yrb.#QW();
			Vector #4Bb = StructurePoint.CoreAssets.Infrastructure.Data.Point.#H3d(point3, point2);
			if (double.IsNaN(#4Bb.Length) || Math.Abs(#4Bb.Length) < 0.0001)
			{
				return #HAb;
			}
			#IAb = ((#IAb <= 0.0) ? 1.0 : #IAb);
			#4Bb.#wlc();
			#4Bb = Vector.#33d(#4Bb, #IAb);
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point4 = GeometryHelper.#Gmc(StructurePoint.CoreAssets.Infrastructure.Data.Point.#H3d(point2, Vector.#33d(10000000.0, #4Bb)), StructurePoint.CoreAssets.Infrastructure.Data.Point.#G3d(point3, Vector.#33d(10000000.0, #4Bb)), point);
			if (point4 == null)
			{
				return null;
			}
			Vector #4Bb2 = new Vector(point4.Value.X - point.X, point4.Value.Y - point.Y);
			#4Bb2 = Vector.#33d(#4Bb2, 2.0);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = StructurePoint.CoreAssets.Infrastructure.Data.Point.#G3d(point, #4Bb2);
			return #Ng.#TW();
		}

		// Token: 0x06002F38 RID: 12088 RVA: 0x000F3DDC File Offset: 0x000F1FDC
		private void #fAb(bool #gAb)
		{
			this.#c = MirrorModelTool.#s6b.#a;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyMirrorLineStart, true, false, true);
			if (#gAb)
			{
				base.Services.MessageBus.#uV(this);
			}
			base.#vf();
		}

		// Token: 0x06002F39 RID: 12089 RVA: 0x000F3E3C File Offset: 0x000F203C
		private bool #iAb()
		{
			base.Services.MouseAndKeyboard.#M2c();
			this.#a.#0Pb(new Action(this.#MAb));
			this.#c = MirrorModelTool.#s6b.#a;
			base.Services.MessageBus.#tV();
			base.Services.MessageBus.#LV();
			base.Services.MessageBus.#KV();
			base.Renderer.#9f(false, false);
			this.#fAb(true);
			return true;
		}

		// Token: 0x06002F3A RID: 12090 RVA: 0x000F3ECC File Offset: 0x000F20CC
		private void #JAb(double #IAb)
		{
			List<ShapeModel> list = new List<ShapeModel>();
			IList<ShapeModel> list2 = base.EditorContext.Selection.Shapes.SelectedInNaturalOrder;
			foreach (ShapeModel shapeModel in list2)
			{
				ShapeModel shapeModel2 = shapeModel.#EA();
				if (shapeModel2.FigureType == PolygonFigureType.Circle)
				{
					if (shapeModel2.CircleCenter != null && shapeModel2.CircleRadius != null)
					{
						devDept.Geometry.Point3D #Ng = MirrorModelTool.#GAb(shapeModel2.CircleCenter.Value.#TW(), this.#d, this.#e, #IAb);
						int #Znc = #4ai.#3ai(base.Project.Model.Options.Unit, shapeModel2.CircleRadius.Value, 40);
						List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = GeometryHelper.#2nc(#Ng.#PW(), shapeModel2.CircleRadius.Value, #Znc, 0.0, true);
						shapeModel2.#o0(new StructurePoint.CoreAssets.Infrastructure.Data.Point?(#Ng.#QW()));
						shapeModel2.#8wc(new PolygonData(points3D, PolygonType.Circle));
					}
				}
				else
				{
					shapeModel2.#s0();
					List<PolygonData> list3 = shapeModel2.Polygons.ToList<PolygonData>();
					for (int i = 0; i < list3.Count; i++)
					{
						PolygonData polygonData = list3[i];
						List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list4 = polygonData.Points3D.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
						for (int j = 0; j < list4.Count; j++)
						{
							list4[j] = MirrorModelTool.#GAb(list4[j].#TW(), this.#d, this.#e, #IAb).#PW();
						}
						list3[i] = new PolygonData(list4, polygonData.PolygonType);
					}
					shapeModel2.#8wc(list3);
				}
				base.EditorContext.ProjectContext.Model.Shapes.Add(shapeModel2);
				base.Project.#1Uh(shapeModel2);
				list.Add(shapeModel2);
			}
			base.EditorContext.Selection.Shapes.#tOb();
			base.EditorContext.Selection.Shapes.#kCb(list);
		}

		// Token: 0x06002F3B RID: 12091 RVA: 0x000F4148 File Offset: 0x000F2348
		private void #KAb(double #IAb)
		{
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			List<ReinforcementBar> list2 = new List<ReinforcementBar>();
			List<ReinforcementBar> list3 = base.EditorContext.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>();
			foreach (ReinforcementBar reinforcementBar in list3)
			{
				ReinforcementBar reinforcementBar2 = reinforcementBar.#EA();
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = MirrorModelTool.#GAb(reinforcementBar2.Point, this.#d, this.#e, #IAb).#QW();
				ReinforcementBar reinforcementBar3 = ColumnModelHelper.#3W(base.EditorContext.ProjectContext.Model, point);
				if (reinforcementBar3 == reinforcementBar)
				{
					list.Add(reinforcementBar3);
				}
				else
				{
					if (reinforcementBar3 == null)
					{
						reinforcementBar2.Location = point;
					}
					else
					{
						base.EditorContext.ProjectContext.Model.ReinforcementBars.Remove(reinforcementBar3);
						reinforcementBar2.Location = reinforcementBar3.Location;
						list2.Add(reinforcementBar2);
						list2.Add(reinforcementBar3);
					}
					base.EditorContext.ProjectContext.Model.ReinforcementBars.Add(reinforcementBar2);
					list.Add(reinforcementBar2);
				}
			}
			base.EditorContext.Selection.Bars.#tOb();
			base.EditorContext.Selection.Bars.#JOb(list2);
			base.EditorContext.Selection.Bars.#kCb(list);
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x000F42DC File Offset: 0x000F24DC
		private double #LAb()
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = base.EditorContext.ProjectContext.Model.Shapes.SelectMany(new Func<ShapeModel, IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(MirrorModelTool.<>c.<>9.#O8b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			list.AddRange(base.EditorContext.ProjectContext.Model.ReinforcementBars.Select(new Func<ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>(MirrorModelTool.<>c.<>9.#Q8b)));
			BoundingBoxData boundingBoxData = new BoundingBoxData(list);
			return Math.Max(boundingBoxData.Width, boundingBoxData.Height);
		}

		// Token: 0x06002F3D RID: 12093 RVA: 0x000F28A8 File Offset: 0x000F0AA8
		private bool #jAb()
		{
			#47c<ShapeModel> source = base.EditorContext.Selection.Shapes.SelectedObjects;
			#47c<ReinforcementBar> source2 = base.EditorContext.Selection.Bars.SelectedObjects;
			return source.Any<ShapeModel>() || source2.Any<ReinforcementBar>();
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x000F43A0 File Offset: 0x000F25A0
		[CompilerGenerated]
		private void #MAb()
		{
			double #IAb = this.#LAb();
			this.#JAb(#IAb);
			this.#KAb(#IAb);
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.Snapping.Cache.#uP(base.EditorContext.ProjectContext);
			base.EditorContext.Selection.#dPb();
			base.EditorContext.Selection.State.#cg();
		}

		// Token: 0x040012FB RID: 4859
		private readonly IEditorService #a;

		// Token: 0x040012FC RID: 4860
		private bool #b;

		// Token: 0x040012FD RID: 4861
		private MirrorModelTool.#s6b #c;

		// Token: 0x040012FE RID: 4862
		private devDept.Geometry.Point3D #d;

		// Token: 0x040012FF RID: 4863
		private devDept.Geometry.Point3D #e;

		// Token: 0x02000519 RID: 1305
		private enum #s6b
		{
			// Token: 0x04001301 RID: 4865
			#a,
			// Token: 0x04001302 RID: 4866
			#b,
			// Token: 0x04001303 RID: 4867
			#c
		}

		// Token: 0x0200051B RID: 1307
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06002F47 RID: 12103 RVA: 0x0002A3B0 File Offset: 0x000285B0
			internal devDept.Geometry.Point3D #L8b(devDept.Geometry.Point3D #9o)
			{
				return MirrorModelTool.#GAb(#9o, this.#a.#d, this.#b, this.#c);
			}

			// Token: 0x0400130A RID: 4874
			public MirrorModelTool #a;

			// Token: 0x0400130B RID: 4875
			public devDept.Geometry.Point3D #b;

			// Token: 0x0400130C RID: 4876
			public double #c;

			// Token: 0x0400130D RID: 4877
			public Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D> #d;
		}
	}
}

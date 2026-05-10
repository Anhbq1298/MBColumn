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
	// Token: 0x02000530 RID: 1328
	internal sealed class RotateModelTool : #tNb, #uNb, IChildColumnEditorTool, #TFb
	{
		// Token: 0x06002FA7 RID: 12199 RVA: 0x0002A74A File Offset: 0x0002894A
		public RotateModelTool(IExtendedServices services, IEditorService editorService) : base(services)
		{
			this.#a = editorService;
		}

		// Token: 0x17000F85 RID: 3973
		// (get) Token: 0x06002FA8 RID: 12200 RVA: 0x0002A75A File Offset: 0x0002895A
		// (set) Token: 0x06002FA9 RID: 12201 RVA: 0x000F5FF0 File Offset: 0x000F41F0
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
						base.#KMb(Strings.StringSpecifyBasePoint, true, false, true);
						return;
					}
					this.#fAb(false);
					base.#JMb();
				}
			}
		}

		// Token: 0x06002FAA RID: 12202 RVA: 0x000F6040 File Offset: 0x000F4240
		public override void #1kb()
		{
			base.#1kb();
			bool #gAb = this.#c == RotateModelTool.#s6b.#a;
			this.#fAb(#gAb);
		}

		// Token: 0x06002FAB RID: 12203 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x06002FAC RID: 12204 RVA: 0x000F6070 File Offset: 0x000F4270
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true) || !this.#jAb())
			{
				return false;
			}
			if (this.#c == RotateModelTool.#s6b.#a)
			{
				this.#e = #Ng;
				this.#f = #Ng;
				this.#c = RotateModelTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#OMb(Strings.StringSpecifyAngle, true, false, true);
				base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#iAb(#Ng, #gzb);
		}

		// Token: 0x06002FAD RID: 12205 RVA: 0x000F610C File Offset: 0x000F430C
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			double? angle = args.Angle;
			if (angle != null)
			{
				args.Handled = this.#Izb(args.Angle.Value);
				return;
			}
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002FAE RID: 12206 RVA: 0x000F616C File Offset: 0x000F436C
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#g = args.Angle;
			this.#d = args.Point;
			base.#vf();
			this.#Bzb(args.Point);
		}

		// Token: 0x06002FAF RID: 12207 RVA: 0x0002A00D File Offset: 0x0002820D
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

		// Token: 0x06002FB0 RID: 12208 RVA: 0x0002A766 File Offset: 0x00028966
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || !this.#jAb())
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#iAb(planePosition, false);
		}

		// Token: 0x06002FB1 RID: 12209 RVA: 0x000F61C8 File Offset: 0x000F43C8
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d = null;
			this.#g = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#Bzb(planePosition);
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002FB3 RID: 12211 RVA: 0x000F6230 File Offset: 0x000F4430
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#c == RotateModelTool.#s6b.#b)
			{
				RotateModelTool.#uZb #uZb = new RotateModelTool.#uZb();
				devDept.Geometry.Point3D point3D = (this.#d ?? planePosition) - this.#e;
				double angleInRadians = Math.Atan2(point3D.Y, point3D.X);
				if (this.#g != null)
				{
					angleInRadians = GeometryHelper.#Qmc(this.#g.Value);
				}
				#uZb.#a = new Rotation(angleInRadians, Vector3D.AxisZ, this.#e);
				List<ShapeModel> list = base.EditorContext.Selection.Shapes.SelectedObjects.OrderByDescending(new Func<ShapeModel, bool>(RotateModelTool.<>c.<>9.#V8b)).ToList<ShapeModel>();
				foreach (ShapeModel shapeModel in list)
				{
					List<devDept.Geometry.Point3D> list2 = ColumnShapesHelper.#DHb(base.Project, base.EditorContext.Settings, shapeModel, null);
					IEnumerable<devDept.Geometry.Point3D> source = list2;
					Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D> selector;
					if ((selector = #uZb.#b) == null)
					{
						selector = (#uZb.#b = new Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D>(#uZb.#L8b));
					}
					list2 = source.Select(selector).ToList<devDept.Geometry.Point3D>();
					ColumnShapesHelper.#IHb(list2, base.EditorContext, #qHb.#b, shapeModel.Application);
				}
				#47c<ReinforcementBar> #47c = base.EditorContext.Selection.Bars.SelectedObjects;
				List<ReinforcementBar> list3 = new List<ReinforcementBar>();
				foreach (ReinforcementBar reinforcementBar in #47c)
				{
					devDept.Geometry.Point3D p = reinforcementBar.Point;
					devDept.Geometry.Point3D point3D2 = #uZb.#a * p;
					ReinforcementBar item = new ReinforcementBar(reinforcementBar.Area, (float)point3D2.X, (float)point3D2.Y, (float)point3D2.Z);
					list3.Add(item);
				}
				ColumnShapesHelper.#HHb(list3, base.EditorContext, #qHb.#b, null);
				if (this.#g == null)
				{
					base.#8Mb(this.#e, this.#d ?? planePosition);
				}
			}
			if (this.#d != null && this.#c == RotateModelTool.#s6b.#a)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x06002FB4 RID: 12212 RVA: 0x0002A7A6 File Offset: 0x000289A6
		private bool #Izb(double #Udb)
		{
			return base.#WMb(true) && this.#jAb() && this.#iAb(#Udb);
		}

		// Token: 0x06002FB5 RID: 12213 RVA: 0x000F64C8 File Offset: 0x000F46C8
		private void #fAb(bool #gAb)
		{
			this.#c = RotateModelTool.#s6b.#a;
			this.#e = null;
			this.#f = null;
			this.#d = null;
			this.#g = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyBasePoint, true, false, true);
			if (#gAb)
			{
				base.Services.MessageBus.#uV(this);
			}
			base.#vf();
		}

		// Token: 0x06002FB6 RID: 12214 RVA: 0x000F28A8 File Offset: 0x000F0AA8
		private bool #jAb()
		{
			#47c<ShapeModel> source = base.EditorContext.Selection.Shapes.SelectedObjects;
			#47c<ReinforcementBar> source2 = base.EditorContext.Selection.Bars.SelectedObjects;
			return source.Any<ShapeModel>() || source2.Any<ReinforcementBar>();
		}

		// Token: 0x06002FB7 RID: 12215 RVA: 0x0002A7CE File Offset: 0x000289CE
		private void #Bzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#c == RotateModelTool.#s6b.#b)
			{
				this.#f = #Ng;
				base.#RCf();
			}
		}

		// Token: 0x06002FB8 RID: 12216 RVA: 0x000F6544 File Offset: 0x000F4744
		private bool #iAb(double #Udb)
		{
			if (this.#c != RotateModelTool.#s6b.#b)
			{
				return false;
			}
			double num = #Udb * 3.141592653589793 / 180.0;
			double #9Ab;
			if (!false)
			{
				#9Ab = num;
			}
			return this.#8Ab(#9Ab);
		}

		// Token: 0x06002FB9 RID: 12217 RVA: 0x000F6588 File Offset: 0x000F4788
		private bool #iAb(devDept.Geometry.Point3D #Ng, bool #gzb)
		{
			double #1Mb = #gzb ? 0.0 : base.EditorContext.Snapping.#NLb();
			if (this.#c != RotateModelTool.#s6b.#b || !base.#4Mb(this.#e, #Ng, #1Mb))
			{
				return false;
			}
			devDept.Geometry.Point3D point3D = this.#f - this.#e;
			double #9Ab = Math.Atan2(point3D.Y, point3D.X);
			return this.#8Ab(#9Ab);
		}

		// Token: 0x06002FBA RID: 12218 RVA: 0x000F6614 File Offset: 0x000F4814
		private bool #8Ab(double #9Ab)
		{
			RotateModelTool.#NTb #NTb = new RotateModelTool.#NTb();
			#NTb.#a = this;
			base.Services.MouseAndKeyboard.#M2c();
			#NTb.#b = new Rotation(#9Ab, Vector3D.AxisZ, this.#e);
			this.#a.#0Pb(new Action(#NTb.#W8b));
			this.#c = RotateModelTool.#s6b.#a;
			base.Services.MessageBus.#tV();
			base.Services.MessageBus.#LV();
			base.Services.MessageBus.#KV();
			base.Renderer.#9f(false, false);
			this.#fAb(true);
			return true;
		}

		// Token: 0x06002FBB RID: 12219 RVA: 0x000F66D8 File Offset: 0x000F48D8
		private void #aBb(Rotation #bBb)
		{
			List<ShapeModel> list = base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>();
			foreach (ShapeModel shapeModel in list)
			{
				if (shapeModel.FigureType == PolygonFigureType.Circle)
				{
					if (shapeModel.CircleCenter != null && shapeModel.CircleRadius != null)
					{
						devDept.Geometry.Point3D #Ng = #bBb * shapeModel.CircleCenter.Value.#TW();
						int #Znc = #4ai.#3ai(base.Project.Model.Options.Unit, shapeModel.CircleRadius.Value, 40);
						List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = GeometryHelper.#2nc(#Ng.#PW(), shapeModel.CircleRadius.Value, #Znc, 0.0, true);
						shapeModel.#o0(new StructurePoint.CoreAssets.Infrastructure.Data.Point?(#Ng.#QW()));
						shapeModel.#8wc(new PolygonData(points3D, PolygonType.Circle));
					}
				}
				else
				{
					shapeModel.#s0();
					List<PolygonData> list2 = shapeModel.Polygons.ToList<PolygonData>();
					for (int i = 0; i < list2.Count; i++)
					{
						PolygonData polygonData = list2[i];
						List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list3 = polygonData.Points3D.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
						for (int j = 0; j < list3.Count; j++)
						{
							list3[j] = (#bBb * list3[j].#TW()).#PW();
						}
						list2[i] = new PolygonData(list3, polygonData.PolygonType);
					}
					shapeModel.#8wc(list2);
				}
			}
		}

		// Token: 0x06002FBC RID: 12220 RVA: 0x000F68D0 File Offset: 0x000F4AD0
		private void #cBb(Rotation #bBb)
		{
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			List<ReinforcementBar> list2 = base.EditorContext.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>();
			foreach (ReinforcementBar reinforcementBar in list2)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = (#bBb * reinforcementBar.Point).#QW();
				ReinforcementBar reinforcementBar2 = ColumnModelHelper.#3W(base.EditorContext.ProjectContext.Model, #Ng);
				if (reinforcementBar2 == null || list2.Contains(reinforcementBar2))
				{
					reinforcementBar.Location = #Ng;
				}
				else
				{
					base.EditorContext.ProjectContext.Model.ReinforcementBars.Remove(reinforcementBar2);
					reinforcementBar.Location = reinforcementBar2.Location;
					list.Add(reinforcementBar);
					list.Add(reinforcementBar2);
				}
			}
			base.EditorContext.Selection.Bars.#JOb(list);
		}

		// Token: 0x04001341 RID: 4929
		private readonly IEditorService #a;

		// Token: 0x04001342 RID: 4930
		private bool #b;

		// Token: 0x04001343 RID: 4931
		private RotateModelTool.#s6b #c;

		// Token: 0x04001344 RID: 4932
		private devDept.Geometry.Point3D #d;

		// Token: 0x04001345 RID: 4933
		private devDept.Geometry.Point3D #e;

		// Token: 0x04001346 RID: 4934
		private devDept.Geometry.Point3D #f;

		// Token: 0x04001347 RID: 4935
		private double? #g;

		// Token: 0x02000531 RID: 1329
		private enum #s6b
		{
			// Token: 0x04001349 RID: 4937
			#a,
			// Token: 0x0400134A RID: 4938
			#b
		}

		// Token: 0x02000533 RID: 1331
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x06002FC1 RID: 12225 RVA: 0x0002A802 File Offset: 0x00028A02
			internal devDept.Geometry.Point3D #L8b(devDept.Geometry.Point3D #9o)
			{
				return this.#a * #9o;
			}

			// Token: 0x0400134D RID: 4941
			public Rotation #a;

			// Token: 0x0400134E RID: 4942
			public Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D> #b;
		}

		// Token: 0x02000534 RID: 1332
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x06002FC3 RID: 12227 RVA: 0x000F69F0 File Offset: 0x000F4BF0
			internal void #W8b()
			{
				this.#a.#aBb(this.#b);
				this.#a.#cBb(this.#b);
				ColumnModelHelper.#VW(this.#a.Project);
				this.#a.EditorContext.Snapping.Cache.#uP(this.#a.EditorContext.ProjectContext);
				this.#a.EditorContext.Selection.#dPb();
				this.#a.EditorContext.Selection.State.#cg();
			}

			// Token: 0x0400134F RID: 4943
			public RotateModelTool #a;

			// Token: 0x04001350 RID: 4944
			public Rotation #b;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #hR;
using #LFb;
using #N6c;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x02000556 RID: 1366
	internal sealed class OffsetSlabEdgeToolImpl : #tNb, #uNb, IMultiToolChild
	{
		// Token: 0x06003094 RID: 12436 RVA: 0x0002B168 File Offset: 0x00029368
		public OffsetSlabEdgeToolImpl(IExtendedServices services, #3Fb moveModelTool, IEditorService editorService) : base(services)
		{
			this.#i = moveModelTool;
			this.#j = editorService;
		}

		// Token: 0x17000FB5 RID: 4021
		// (get) Token: 0x06003095 RID: 12437 RVA: 0x0002B196 File Offset: 0x00029396
		// (set) Token: 0x06003096 RID: 12438 RVA: 0x0002B1A2 File Offset: 0x000293A2
		public OffsetSlabEdgeToolImpl.#j9b State { get; private set; }

		// Token: 0x17000FB6 RID: 4022
		// (get) Token: 0x06003097 RID: 12439 RVA: 0x0002B1B3 File Offset: 0x000293B3
		public bool IsWorking
		{
			get
			{
				return this.State > OffsetSlabEdgeToolImpl.#j9b.#a;
			}
		}

		// Token: 0x06003098 RID: 12440 RVA: 0x0002B1C6 File Offset: 0x000293C6
		public void #XBb()
		{
			this.#iCb();
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x0002B1D6 File Offset: 0x000293D6
		public override void OnActivated()
		{
			base.OnActivated();
			base.ForceOrthoDisabled = true;
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x0002B1F1 File Offset: 0x000293F1
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			base.ForceOrthoDisabled = false;
		}

		// Token: 0x0600309B RID: 12443 RVA: 0x000F90C8 File Offset: 0x000F72C8
		public override void #1kb()
		{
			if (!false)
			{
				base.#1kb();
			}
			bool flag = this.IsWorking;
			this.State = OffsetSlabEdgeToolImpl.#j9b.#a;
			this.#f = 0.0;
			this.#b = null;
			this.#c = null;
			this.#g = true;
			this.#h.Clear();
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#JMb();
			if (flag)
			{
				base.Services.Renderer.#cg();
			}
		}

		// Token: 0x0600309C RID: 12444 RVA: 0x0002B20C File Offset: 0x0002940C
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#f = args.Offset;
			args.Handled = true;
		}

		// Token: 0x0600309D RID: 12445 RVA: 0x000F9150 File Offset: 0x000F7350
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			this.#f = args.CoordinateX.Value;
			if (this.State == OffsetSlabEdgeToolImpl.#j9b.#b)
			{
				if (this.#cCb(this.#f))
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x0600309E RID: 12446 RVA: 0x0002B234 File Offset: 0x00029434
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			this.#f = args.Offset;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x0600309F RID: 12447 RVA: 0x000F91A8 File Offset: 0x000F73A8
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || !this.#1Bb() || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.EditorContext.Snapping.PerformSnap(this.#h, planePosition, base.EditorContext.Snapping.#NLb());
			this.#b = planePosition;
			if (this.#b == null)
			{
				return;
			}
			this.State = OffsetSlabEdgeToolImpl.#j9b.#b;
			foreach (SegmentData segmentData in this.#d.Segments)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point #mcb = segmentData.#SBb();
				if (StructurePoint.CoreAssets.Infrastructure.Data.Point.#E3d(#mcb, new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#b.X, this.#b.Y)))
				{
					this.#a[0] = segmentData.StartPoint;
					this.#a[1] = segmentData.EndPoint;
					this.#e = segmentData;
				}
			}
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x000F92D8 File Offset: 0x000F74D8
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left || !this.#1Bb())
			{
				return;
			}
			devDept.Geometry.Point3D point3D = base.EditorContext.Snapping.PerformSnap(this.#h, planePosition, base.EditorContext.Snapping.#NLb());
			planePosition = ((point3D != null) ? point3D : base.#bNb(#LLb.#n, planePosition));
			this.#fzb(planePosition, false);
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x000F9370 File Offset: 0x000F7570
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false) || !this.#1Bb())
			{
				return;
			}
			planePosition = new devDept.Geometry.Point3D(planePosition.X, planePosition.Y);
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
		}

		// Token: 0x060030A2 RID: 12450 RVA: 0x000F93DC File Offset: 0x000F75DC
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !this.#1Bb())
			{
				return;
			}
			this.#iCb();
			devDept.Geometry.Point3D point3D = base.EditorContext.Snapping.PerformSnap(this.#h, planePosition, base.EditorContext.Snapping.#NLb());
			base.RenderContext.SetLineSizeExt(1f);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.State == OffsetSlabEdgeToolImpl.#j9b.#a && base.EditorContext.Selection.Shapes.Hovered.Count == 1)
			{
				ShapeModel shapeModel = base.EditorContext.Selection.Shapes.Hovered.Last<ShapeModel>();
				devDept.Geometry.Point3D[] #AHb = shapeModel.#fxc().Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, devDept.Geometry.Point3D>(OffsetSlabEdgeToolImpl.<>c.<>9.#k9b)).ToArray<devDept.Geometry.Point3D>();
				ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#c, shapeModel.Application);
			}
			if (this.#b == null)
			{
				this.#hCb(this.#d);
				devDept.Geometry.Point3D point3D2 = base.EditorContext.Snapping.PerformSnap(this.#h, planePosition, base.EditorContext.Snapping.#NLb());
				if (point3D2 != null)
				{
					base.#jNb(point3D2, true);
					return;
				}
			}
			else
			{
				if (this.#e == null)
				{
					return;
				}
				base.#gNb(this.#b, #KT.#F, 5f, null);
				planePosition = ((point3D != null) ? point3D : base.#cNb(#LLb.#n, planePosition));
				if (this.#e.#Uwc())
				{
					planePosition = new devDept.Geometry.Point3D(this.#b.X, planePosition.Y);
				}
				else if (this.#e.#Twc())
				{
					planePosition = new devDept.Geometry.Point3D(planePosition.X, this.#b.Y);
				}
				else
				{
					planePosition = this.#2Bb(this.#e, planePosition);
				}
				devDept.Geometry.Point3D point3D3 = planePosition - this.#b;
				Vector3D vector3D = Vector3D.Subtract(planePosition, this.#b);
				devDept.Geometry.Point3D point3D4 = new devDept.Geometry.Point3D(this.#b.X + point3D3.X, this.#b.Y + point3D3.Y);
				this.#c = point3D4;
				this.#g = (ColumnShapesHelper.#pHb(base.EditorContext, base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>(), this.#a, point3D3.#QW()) || vector3D.Length <= 0.01);
				PolygonData #JP = new PolygonData(this.#3Bb(point3D3).Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(OffsetSlabEdgeToolImpl.<>c.<>9.#l9b)));
				this.#hCb(#JP);
			}
		}

		// Token: 0x060030A3 RID: 12451 RVA: 0x000F96D4 File Offset: 0x000F78D4
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			#47c<ShapeModel> #47c = base.EditorContext.Selection.Shapes.SelectedObjects;
			if (!base.#WMb(true) || #47c.Count != 1 || this.#b == null)
			{
				return false;
			}
			if (this.#b != null)
			{
				base.#fzb(#Ng, #gzb);
				this.State = OffsetSlabEdgeToolImpl.#j9b.#b;
				base.#VMb(Strings.StringSpecifyOffsetDistance, true, false, false);
				if (this.#h.Contains(#Ng) && base.Editor.DynamicInput.OpenInputDirectly(new devDept.Geometry.Point3D()) != DynamicInputResultState.Commited)
				{
					this.#1kb();
					return false;
				}
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
			}
			this.#6Bb();
			base.Services.MessageBus.#tV();
			this.#1kb();
			return true;
		}

		// Token: 0x060030A4 RID: 12452 RVA: 0x0002A154 File Offset: 0x00028354
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = base.#hzb(#Lg);
			return #Lg.Handled;
		}

		// Token: 0x060030A5 RID: 12453 RVA: 0x000F97C0 File Offset: 0x000F79C0
		private bool #1Bb()
		{
			bool flag = this.#i.IsEnabled;
			if (base.EditorContext.Selection.State.Slabs.OnlySelected && base.EditorContext.Selection.Shapes.NoOfSelectedObjects == 1 && !flag)
			{
				ShapeModel shapeModel = base.EditorContext.Selection.Shapes.SelectedObjects.FirstOrDefault<ShapeModel>();
				if (shapeModel != null && shapeModel.FigureType != PolygonFigureType.Circle)
				{
					return true;
				}
			}
			if (this.State != OffsetSlabEdgeToolImpl.#j9b.#a)
			{
				this.#1kb();
			}
			return false;
		}

		// Token: 0x060030A6 RID: 12454 RVA: 0x000F9864 File Offset: 0x000F7A64
		private devDept.Geometry.Point3D #2Bb(SegmentData #PP, devDept.Geometry.Point3D #jzb)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = this.#fCb(#PP, #jzb.#QW());
			return new devDept.Geometry.Point3D(point.X, point.Y);
		}

		// Token: 0x060030A7 RID: 12455 RVA: 0x000F98A0 File Offset: 0x000F7AA0
		private List<devDept.Geometry.Point3D> #3Bb(devDept.Geometry.Point3D #4Bb)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = this.#d.Points2D.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			List<devDept.Geometry.Point3D> list2 = new List<devDept.Geometry.Point3D>(list.Count);
			foreach (StructurePoint.CoreAssets.Infrastructure.Data.Point value in list)
			{
				if (this.#a.Contains(value))
				{
					devDept.Geometry.Point3D item = new devDept.Geometry.Point3D(value.X + #4Bb.X, value.Y + #4Bb.Y);
					list2.Add(item);
				}
				else
				{
					list2.Add(new devDept.Geometry.Point3D(value.X, value.Y));
				}
			}
			return list2;
		}

		// Token: 0x060030A8 RID: 12456 RVA: 0x0002A6D4 File Offset: 0x000288D4
		private void #5Bb()
		{
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			base.Renderer.#9f(false, false);
		}

		// Token: 0x060030A9 RID: 12457 RVA: 0x000F9978 File Offset: 0x000F7B78
		private void #6Bb()
		{
			if (this.#f == 0.0 && this.#c == this.#b)
			{
				return;
			}
			if (this.#e == null)
			{
				return;
			}
			this.#j.#0Pb(new Func<bool>(this.#jCb));
		}

		// Token: 0x060030AA RID: 12458 RVA: 0x000F99D8 File Offset: 0x000F7BD8
		private bool #7Bb(ShapeModel #rP, double #8Bb, bool #9Bb)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = this.#dCb(this.#e, this.#e.#SBb(), #8Bb);
			List<devDept.Geometry.Point3D> list = this.#3Bb(new devDept.Geometry.Point3D(point.X, point.Y));
			if (!this.#g || !ColumnModelHelper.#9W(list))
			{
				return false;
			}
			PolygonData polygonData = new PolygonData(list.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(OffsetSlabEdgeToolImpl.<>c.<>9.#m9b)));
			ShapeModel #bCb = new ShapeModel(polygonData);
			if (#9Bb && !this.#aCb(#bCb, #rP, #8Bb))
			{
				return false;
			}
			#rP.#8wc(polygonData);
			return true;
		}

		// Token: 0x060030AB RID: 12459 RVA: 0x000F9A94 File Offset: 0x000F7C94
		private bool #aCb(ShapeModel #bCb, ShapeModel #kBb, double #8Bb)
		{
			return (#bCb.Area <= #kBb.Area || #8Bb >= 0.0) && (#bCb.Area >= #kBb.Area || #8Bb <= 0.0);
		}

		// Token: 0x060030AC RID: 12460 RVA: 0x000F9AE4 File Offset: 0x000F7CE4
		private bool #cCb(double #8Bb)
		{
			bool result;
			try
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = this.#dCb(this.#e, this.#e.#SBb(), #8Bb);
				List<devDept.Geometry.Point3D> list = this.#3Bb(new devDept.Geometry.Point3D(point.X, point.Y));
				ShapeModel #kBb = base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>().FirstOrDefault<ShapeModel>();
				PolygonData polygon = new PolygonData(list.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(OffsetSlabEdgeToolImpl.<>c.<>9.#n9b)));
				ShapeModel #bCb = new ShapeModel(polygon);
				if (!this.#aCb(#bCb, #kBb, #8Bb))
				{
					point = this.#dCb(this.#e, this.#e.#SBb(), -#8Bb);
					list = this.#3Bb(new devDept.Geometry.Point3D(point.X, point.Y));
				}
				result = ColumnModelHelper.#9W(list);
			}
			catch (Exception ex)
			{
				if (!(ex is FormatException))
				{
					base.Services.Logger.Log(LoggingLevel.Warning, ex);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060030AD RID: 12461 RVA: 0x000F9C14 File Offset: 0x000F7E14
		private StructurePoint.CoreAssets.Infrastructure.Data.Point #dCb(SegmentData #PP, StructurePoint.CoreAssets.Infrastructure.Data.Point #eCb, double #8Bb)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point result = default(StructurePoint.CoreAssets.Infrastructure.Data.Point);
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = #PP.StartPoint;
			StructurePoint.CoreAssets.Infrastructure.Data.Point point2 = #PP.EndPoint;
			if (this.#c != this.#b)
			{
				result.X = this.#c.X - #eCb.X;
				result.Y = this.#c.Y - #eCb.Y;
			}
			else if (#PP.#Twc())
			{
				result.X = #8Bb;
				result.Y = 0.0;
			}
			else if (#PP.#Uwc())
			{
				result.X = 0.0;
				result.Y = #8Bb;
			}
			else
			{
				GeneralLineEquation generalLineEquation = new GeneralLineEquation(point, point2);
				Vector #4Bb = generalLineEquation.#ulc();
				#4Bb = Vector.#33d(#4Bb, #8Bb);
				result.X = #4Bb.X;
				result.Y = #4Bb.Y;
			}
			return result;
		}

		// Token: 0x060030AE RID: 12462 RVA: 0x000F9D1C File Offset: 0x000F7F1C
		private StructurePoint.CoreAssets.Infrastructure.Data.Point #fCb(SegmentData #PP, StructurePoint.CoreAssets.Infrastructure.Data.Point #gCb)
		{
			GeneralLineEquation generalLineEquation = new GeneralLineEquation(#PP.StartPoint, #PP.EndPoint);
			GeneralLineEquation generalLineEquation2 = generalLineEquation.#rlc(#PP.#SBb());
			GeneralLineEquation generalLineEquation3 = generalLineEquation2.#rlc(#gCb);
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point = generalLineEquation3.#plc(generalLineEquation2);
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point(point.Value.X, point.Value.Y);
		}

		// Token: 0x060030AF RID: 12463 RVA: 0x000F9D8C File Offset: 0x000F7F8C
		private void #hCb(PolygonData #JP)
		{
			if (!base.EditorContext.Selection.Shapes.SelectedObjects.Any<ShapeModel>())
			{
				this.#1kb();
				return;
			}
			foreach (SegmentData segmentData in #JP.Segments)
			{
				devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D(segmentData.#SBb().X, segmentData.#SBb().Y);
				bool #kNb = point3D == this.#b;
				base.#jNb(point3D, #kNb);
			}
		}

		// Token: 0x060030B0 RID: 12464 RVA: 0x000F9E54 File Offset: 0x000F8054
		private void #iCb()
		{
			this.#h.Clear();
			#cLb #cLb = base.EditorContext;
			List<ShapeModel> list = (#cLb != null) ? #cLb.Selection.Shapes.SelectedObjects.ToList<ShapeModel>() : null;
			if (list == null || list.Count != 1)
			{
				return;
			}
			ShapeModel shapeModel = list.First<ShapeModel>();
			if (shapeModel.FigureType == PolygonFigureType.Circle)
			{
				this.#1kb();
				return;
			}
			this.#d = shapeModel.#cxc(0);
			foreach (SegmentData segmentData in this.#d.Segments)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = segmentData.#SBb();
				this.#h.Add(#Ng.#TW());
			}
			this.#h = this.#h.OrderBy(new Func<devDept.Geometry.Point3D, double>(OffsetSlabEdgeToolImpl.<>c.<>9.#o9b)).ThenBy(new Func<devDept.Geometry.Point3D, double>(OffsetSlabEdgeToolImpl.<>c.<>9.#p9b)).ToList<devDept.Geometry.Point3D>();
		}

		// Token: 0x060030B1 RID: 12465 RVA: 0x0002B261 File Offset: 0x00029461
		private void #Bzb()
		{
			base.Viewports.#vf();
		}

		// Token: 0x060030B2 RID: 12466 RVA: 0x000F9F9C File Offset: 0x000F819C
		[CompilerGenerated]
		private bool #jCb()
		{
			ShapeModel #rP = base.EditorContext.Selection.Shapes.SelectedObjects.First<ShapeModel>();
			bool result = this.#7Bb(#rP, this.#f, true) || this.#7Bb(#rP, -this.#f, false);
			this.#5Bb();
			return result;
		}

		// Token: 0x040013B8 RID: 5048
		private readonly StructurePoint.CoreAssets.Infrastructure.Data.Point[] #a = new StructurePoint.CoreAssets.Infrastructure.Data.Point[2];

		// Token: 0x040013B9 RID: 5049
		private devDept.Geometry.Point3D #b;

		// Token: 0x040013BA RID: 5050
		private devDept.Geometry.Point3D #c;

		// Token: 0x040013BB RID: 5051
		private PolygonData #d;

		// Token: 0x040013BC RID: 5052
		private SegmentData #e;

		// Token: 0x040013BD RID: 5053
		private double #f;

		// Token: 0x040013BE RID: 5054
		private bool #g;

		// Token: 0x040013BF RID: 5055
		private List<devDept.Geometry.Point3D> #h = new List<devDept.Geometry.Point3D>();

		// Token: 0x040013C0 RID: 5056
		private readonly #3Fb #i;

		// Token: 0x040013C1 RID: 5057
		private readonly IEditorService #j;

		// Token: 0x040013C2 RID: 5058
		[CompilerGenerated]
		private OffsetSlabEdgeToolImpl.#j9b #k;

		// Token: 0x02000557 RID: 1367
		internal enum #j9b
		{
			// Token: 0x040013C4 RID: 5060
			#a,
			// Token: 0x040013C5 RID: 5061
			#b
		}
	}
}

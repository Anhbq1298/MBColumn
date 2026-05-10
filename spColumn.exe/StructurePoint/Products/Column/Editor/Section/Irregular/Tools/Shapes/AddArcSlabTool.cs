using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #qzb;
using #RJb;
using #xKe;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Shapes
{
	// Token: 0x020004EA RID: 1258
	internal sealed class AddArcSlabTool : #bMb, #uNb, #Gzb
	{
		// Token: 0x06002E22 RID: 11810 RVA: 0x000295A4 File Offset: 0x000277A4
		public AddArcSlabTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F5A RID: 3930
		// (get) Token: 0x06002E23 RID: 11811 RVA: 0x000295B4 File Offset: 0x000277B4
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x06002E24 RID: 11812 RVA: 0x000F025C File Offset: 0x000EE45C
		public override void #1kb()
		{
			base.#1kb();
			this.#e = AddArcSlabTool.#s6b.#a;
			this.#f = CircleDirection.None;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002E25 RID: 11813 RVA: 0x000F02B8 File Offset: 0x000EE4B8
		public override void OnActivated()
		{
			base.OnActivated();
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = false;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
		}

		// Token: 0x06002E26 RID: 11814 RVA: 0x000F0308 File Offset: 0x000EE508
		public override void OnDeactivated()
		{
			if (2 != 0)
			{
				base.OnDeactivated();
			}
			this.#e = AddArcSlabTool.#s6b.#a;
			this.#f = CircleDirection.None;
			this.#b = null;
			this.#c = null;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = true;
			this.#g = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x06002E27 RID: 11815 RVA: 0x000295C9 File Offset: 0x000277C9
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#g = (args.Key == Key.Escape && this.#e == AddArcSlabTool.#s6b.#a);
		}

		// Token: 0x06002E28 RID: 11816 RVA: 0x000295FD File Offset: 0x000277FD
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#g)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002E29 RID: 11817 RVA: 0x000F0384 File Offset: 0x000EE584
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#e == AddArcSlabTool.#s6b.#a)
			{
				this.#b = #Ng;
				this.#e = AddArcSlabTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			if (this.#e == AddArcSlabTool.#s6b.#b)
			{
				this.#c = #Ng;
				this.#e = AddArcSlabTool.#s6b.#c;
				base.#fzb(#Ng, #gzb);
				base.#PMb(Strings.StringSpecifyAngle, this.#b, true, false, true, new Func<double, double>(this.#Pzb));
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x06002E2A RID: 11818 RVA: 0x000F0454 File Offset: 0x000EE654
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			if (args.Mode == DynamicInputMode.Angle && args.Angle != null)
			{
				args.Handled = this.#Izb(args.Angle.Value);
				return;
			}
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002E2B RID: 11819 RVA: 0x000F04BC File Offset: 0x000EE6BC
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			if (base.Editor.DynamicInput.Config.Mode == DynamicInputMode.RelativeAngle)
			{
				if (args.Angle != null)
				{
					this.#Hzb(args.Angle.Value);
				}
			}
			else
			{
				this.#d = args.Point;
			}
			base.#vf();
		}

		// Token: 0x06002E2C RID: 11820 RVA: 0x000F0540 File Offset: 0x000EE740
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			devDept.Geometry.Point3D right = (base.Editor.DynamicInput.Config.LastInputPoint ?? new devDept.Geometry.Point3D()) + (args.FinalPoint ?? new devDept.Geometry.Point3D());
			if (this.#e == AddArcSlabTool.#s6b.#b && this.#b == right)
			{
				args.ErrorMessage = Strings.StringInvalidGeometry;
				return;
			}
			if (this.#e == AddArcSlabTool.#s6b.#c && args.CoordinateX != null)
			{
				double value = args.CoordinateX.Value;
				if (value.Equals(0.0) || Math.Abs(value) >= 360.0)
				{
					args.ErrorMessage = Strings.StringInvalidGeometry;
				}
			}
		}

		// Token: 0x06002E2D RID: 11821 RVA: 0x000F0620 File Offset: 0x000EE820
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if ((this.#e == AddArcSlabTool.#s6b.#b || this.#e == AddArcSlabTool.#s6b.#c) && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002E2E RID: 11822 RVA: 0x000F0688 File Offset: 0x000EE888
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == AddArcSlabTool.#s6b.#c && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x06002E2F RID: 11823 RVA: 0x000F06E8 File Offset: 0x000EE8E8
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
			if (this.#e != AddArcSlabTool.#s6b.#c || !this.#Dzb(planePosition) || this.#f != CircleDirection.None)
			{
				return;
			}
			this.#f = this.#Jzb(planePosition);
		}

		// Token: 0x06002E30 RID: 11824 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002E31 RID: 11825 RVA: 0x000F0774 File Offset: 0x000EE974
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#e == AddArcSlabTool.#s6b.#b)
			{
				base.#8Mb(this.#b, this.#d ?? planePosition);
			}
			if (this.#e == AddArcSlabTool.#s6b.#c)
			{
				devDept.Geometry.Point3D point3D = this.#d ?? planePosition;
				devDept.Geometry.Point3D[] array = this.#Lzb(this.#b, this.#c, point3D);
				if (array.Length > 3 && this.#f != CircleDirection.None)
				{
					ColumnShapesHelper.#IHb(array, base.EditorContext, #qHb.#a, this.#a.PolygonApplication);
				}
				base.#8Mb(this.#b, point3D);
			}
			if (this.#d != null && this.#e == AddArcSlabTool.#s6b.#a)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x06002E32 RID: 11826 RVA: 0x00029634 File Offset: 0x00027834
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#e == AddArcSlabTool.#s6b.#c || this.#e == AddArcSlabTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x000F0890 File Offset: 0x000EEA90
		private void #Hzb(double #Udb)
		{
			this.#f = ((#Udb > 0.0) ? CircleDirection.Clockwise : CircleDirection.CounterClockwise);
			devDept.Geometry.Point3D point3D = this.#c - this.#b;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(this.#b.DistanceTo(this.#c));
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = GeometryHelper.#4nc(this.#b.#QW(), #HS, (double)num - #Udb);
			this.#d = new devDept.Geometry.Point3D(point.X, point.Y);
		}

		// Token: 0x06002E34 RID: 11828 RVA: 0x000F0938 File Offset: 0x000EEB38
		private bool #Izb(double #Udb)
		{
			if (!base.#WMb(true) || this.#e != AddArcSlabTool.#s6b.#c)
			{
				return false;
			}
			this.#f = ((#Udb > 0.0) ? CircleDirection.Clockwise : CircleDirection.CounterClockwise);
			devDept.Geometry.Point3D point3D = this.#c - this.#b;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(this.#b.DistanceTo(this.#c));
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = GeometryHelper.#4nc(this.#b.#QW(), #HS, (double)num - #Udb);
			return this.#Azb(#Ng.#TW());
		}

		// Token: 0x06002E35 RID: 11829 RVA: 0x000F09EC File Offset: 0x000EEBEC
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddArcSlabTool.#NTb #NTb = new AddArcSlabTool.#NTb();
			#NTb.#a = this;
			if (this.#e != AddArcSlabTool.#s6b.#c || this.#f == CircleDirection.None)
			{
				return false;
			}
			if (!ColumnShapesHelper.#OHb(this.#b, this.#c, #Ng))
			{
				return false;
			}
			devDept.Geometry.Point3D[] source = this.#Lzb(this.#b, this.#c, #Ng);
			IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = source.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddArcSlabTool.<>c.<>9.#v8b));
			PolygonData polygon = new PolygonData(points3D);
			#NTb.#b = new ShapeModel(polygon);
			#NTb.#b.Application = this.#a.PolygonApplication;
			UndoAction.#uRb(base.UndoManager, new Action(#NTb.#t8b));
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			this.#e = AddArcSlabTool.#s6b.#a;
			this.#f = CircleDirection.None;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.Renderer.#9f(false, false);
			base.Editor.DynamicInput.SetInputValue(base.Editor.PlanePosition);
			return true;
		}

		// Token: 0x06002E36 RID: 11830 RVA: 0x000F0B34 File Offset: 0x000EED34
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#e == AddArcSlabTool.#s6b.#b)
			{
				return this.#b == null || base.#4Mb(this.#b, #Ng, base.EditorContext.Snapping.#NLb());
			}
			return this.#e == AddArcSlabTool.#s6b.#c && (this.#c == null || base.#4Mb(this.#c, #Ng, base.EditorContext.Snapping.#NLb()));
		}

		// Token: 0x06002E37 RID: 11831 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06002E38 RID: 11832 RVA: 0x000F0BC0 File Offset: 0x000EEDC0
		private CircleDirection #Jzb(devDept.Geometry.Point3D #Kzb)
		{
			devDept.Geometry.Point3D point3D = #Kzb - this.#b;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(#Kzb.DistanceTo(this.#b));
			devDept.Geometry.Point3D point3D2 = this.#b;
			devDept.Geometry.Point3D #MHb = this.#c;
			devDept.Geometry.Point3D #NHb = GeometryHelper.#4nc(point3D2.#QW(), #HS, (double)num).#TW();
			return ColumnShapesHelper.#LHb(point3D2, #MHb, #NHb);
		}

		// Token: 0x06002E39 RID: 11833 RVA: 0x000F0C38 File Offset: 0x000EEE38
		private devDept.Geometry.Point3D[] #Lzb(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Mzb, devDept.Geometry.Point3D #Yrb)
		{
			float #HS = (float)Math.Abs(#Xrb.DistanceTo(#Mzb));
			ValueTuple<float, float> valueTuple = ReinforcementPatternHelper.#OLe(#Xrb, #Mzb, #Yrb);
			float item = valueTuple.Item1;
			float item2 = valueTuple.Item2;
			return this.#Lzb(#Xrb, #HS, item, item2);
		}

		// Token: 0x06002E3A RID: 11834 RVA: 0x000F0C80 File Offset: 0x000EEE80
		private devDept.Geometry.Point3D[] #Lzb(devDept.Geometry.Point3D #wob, float #HS, float #Nzb, float #Ozb)
		{
			int fullCircleNumberOfPoints = #4ai.#3ai(base.Project.Model.Options.Unit, (double)#HS, 40);
			return EyeshotHelper.ConstructArc(#wob, #HS, #Nzb, #Ozb, fullCircleNumberOfPoints, this.#f).ToArray();
		}

		// Token: 0x06002E3B RID: 11835 RVA: 0x00029664 File Offset: 0x00027864
		private double #Pzb(double #Udb)
		{
			if (this.#f == CircleDirection.Clockwise)
			{
				return #Udb;
			}
			return (#Udb - 360.0) % 360.0;
		}

		// Token: 0x04001282 RID: 4738
		private readonly #4zb #a;

		// Token: 0x04001283 RID: 4739
		private devDept.Geometry.Point3D #b;

		// Token: 0x04001284 RID: 4740
		private devDept.Geometry.Point3D #c;

		// Token: 0x04001285 RID: 4741
		private devDept.Geometry.Point3D #d;

		// Token: 0x04001286 RID: 4742
		private AddArcSlabTool.#s6b #e;

		// Token: 0x04001287 RID: 4743
		private CircleDirection #f;

		// Token: 0x04001288 RID: 4744
		private bool #g;

		// Token: 0x020004EB RID: 1259
		private enum #s6b
		{
			// Token: 0x0400128A RID: 4746
			#a,
			// Token: 0x0400128B RID: 4747
			#b,
			// Token: 0x0400128C RID: 4748
			#c
		}

		// Token: 0x020004ED RID: 1261
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x06002E40 RID: 11840 RVA: 0x000F0CD0 File Offset: 0x000EEED0
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x0400128F RID: 4751
			public AddArcSlabTool #a;

			// Token: 0x04001290 RID: 4752
			public ShapeModel #b;
		}
	}
}

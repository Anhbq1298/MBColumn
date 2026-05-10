using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #cMb;
using #Fmc;
using #qzb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
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
	// Token: 0x020004DF RID: 1247
	internal sealed class AddPolygonSlabTool : #bMb, #uNb, #pzb
	{
		// Token: 0x06002DE6 RID: 11750 RVA: 0x00029265 File Offset: 0x00027465
		public AddPolygonSlabTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F58 RID: 3928
		// (get) Token: 0x06002DE7 RID: 11751 RVA: 0x00029280 File Offset: 0x00027480
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x000EF24C File Offset: 0x000ED44C
		public override void #1kb()
		{
			base.#1kb();
			this.#vzb();
			this.#c = null;
			this.#b = null;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.Services.SnappingCache.TemporaryPoints.Clear();
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x00029295 File Offset: 0x00027495
		public override void OnActivated()
		{
			base.OnActivated();
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
		}

		// Token: 0x06002DEA RID: 11754 RVA: 0x000EF2A4 File Offset: 0x000ED4A4
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#vzb();
			this.#b = null;
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#f = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x06002DEB RID: 11755 RVA: 0x000292B7 File Offset: 0x000274B7
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#f = (args.Key == Key.Escape && this.#e == AddPolygonSlabTool.#s6b.#a);
		}

		// Token: 0x06002DEC RID: 11756 RVA: 0x000292EB File Offset: 0x000274EB
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#f)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002DED RID: 11757 RVA: 0x000EF2FC File Offset: 0x000ED4FC
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#e == AddPolygonSlabTool.#s6b.#a)
			{
				this.#wzb(#Ng);
				return true;
			}
			if (this.#e == AddPolygonSlabTool.#s6b.#b && this.#d.Count >= 3 && this.#yzb(#Ng))
			{
				return this.#Azb(#Ng);
			}
			if (this.#e != AddPolygonSlabTool.#s6b.#b || this.#yzb(#Ng))
			{
				return false;
			}
			if (this.#zzb(this.#d.Last<devDept.Geometry.Point3D>(), #Ng, #Ng))
			{
				this.#xzb(#Ng);
				return true;
			}
			return false;
		}

		// Token: 0x06002DEE RID: 11758 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002DEF RID: 11759 RVA: 0x00029322 File Offset: 0x00027522
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x000EF39C File Offset: 0x000ED59C
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (this.#e == AddPolygonSlabTool.#s6b.#b && args.FinalPoint != null && args.CoordinateType == DynamicInputCoordinateType.CoordinateY)
			{
				devDept.Geometry.Point3D point3D = this.#d.Last<devDept.Geometry.Point3D>();
				devDept.Geometry.Point3D point3D2 = point3D + args.FinalPoint;
				if (this.#d.Count >= 3 && this.#yzb(point3D2))
				{
					return;
				}
				if (this.#zzb(point3D, point3D2, point3D2))
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x06002DF1 RID: 11761 RVA: 0x000EF434 File Offset: 0x000ED634
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (args.ChangedButton == System.Windows.Input.MouseButton.Left)
			{
				planePosition = base.#bNb(#LLb.#n, planePosition);
				this.#fzb(planePosition, false);
				return;
			}
			if (args.ChangedButton == System.Windows.Input.MouseButton.Right && this.#b != null)
			{
				args.Handled = true;
				if (this.#d.Count < 3)
				{
					this.#1kb();
					return;
				}
				this.#fzb(this.#b, false);
			}
		}

		// Token: 0x06002DF2 RID: 11762 RVA: 0x000EF4C4 File Offset: 0x000ED6C4
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
		}

		// Token: 0x06002DF3 RID: 11763 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002DF4 RID: 11764 RVA: 0x000EF51C File Offset: 0x000ED71C
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#e == AddPolygonSlabTool.#s6b.#b)
			{
				ColumnShapesHelper.#zHb(this.#d, base.EditorContext);
				base.#8Mb(this.#d.Last<devDept.Geometry.Point3D>(), this.#c ?? planePosition);
			}
			if (this.#c != null && this.#e == AddPolygonSlabTool.#s6b.#a)
			{
				base.#9Mb(this.#c);
			}
		}

		// Token: 0x06002DF5 RID: 11765 RVA: 0x00029360 File Offset: 0x00027560
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#e == AddPolygonSlabTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002DF6 RID: 11766 RVA: 0x000EF5F4 File Offset: 0x000ED7F4
		private static bool #szb(devDept.Geometry.Point3D #tzb, IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> #uzb)
		{
			if (#tzb == null)
			{
				return true;
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = #tzb.#QW();
			IEnumerable<SegmentData> enumerable = #jsc.#Rrc(#uzb);
			foreach (SegmentData segmentData in enumerable)
			{
				if (#jsc.#Src(segmentData, #Ng))
				{
					return false;
				}
				if (#jsc.#Trc(segmentData, new SegmentData(#uzb.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), new StructurePoint.CoreAssets.Infrastructure.Data.Point(#tzb.X, #tzb.Y)), true))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002DF7 RID: 11767 RVA: 0x00029384 File Offset: 0x00027584
		private void #vzb()
		{
			this.#e = AddPolygonSlabTool.#s6b.#a;
			List<devDept.Geometry.Point3D> list = this.#d;
			if (!false)
			{
				list.Clear();
			}
			base.Services.SnappingCache.TemporaryPoints.Clear();
			base.#vf();
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x000EF6A8 File Offset: 0x000ED8A8
		private void #wzb(devDept.Geometry.Point3D #Ng)
		{
			this.#e = AddPolygonSlabTool.#s6b.#b;
			this.#b = #Ng;
			this.#xzb(#Ng);
			base.#fzb(#Ng, false);
			base.#SMb(Strings.StringSpecifyNextPoint, true, false, true);
			base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x000EF700 File Offset: 0x000ED900
		private void #xzb(devDept.Geometry.Point3D #Ng)
		{
			this.#d.Add(#Ng);
			base.Services.SnappingCache.TemporaryPoints.Add(#Ng);
			base.Services.SnappingCache.#tP();
			base.LastInputPoint = #Ng;
			base.#SMb(Strings.StringSpecifyNextPoint, true, false, true);
			base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x000EF774 File Offset: 0x000ED974
		private bool #yzb(devDept.Geometry.Point3D #Ng)
		{
			return Math.Abs(#Ng.X - this.#b.X) < 1E-07 && Math.Abs(#Ng.Y - this.#b.Y) < 1E-07;
		}

		// Token: 0x06002DFB RID: 11771 RVA: 0x000EF7D4 File Offset: 0x000ED9D4
		private bool #zzb(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, devDept.Geometry.Point3D #tzb)
		{
			AddPolygonSlabTool.#KTb #KTb = new AddPolygonSlabTool.#KTb();
			#KTb.#a = #Xrb;
			#KTb.#b = #Yrb;
			#KTb.#c = this;
			if (#tzb != null && this.#d.Contains(#tzb))
			{
				return false;
			}
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = this.#d.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point>(AddPolygonSlabTool.<>c.<>9.#r8b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb2 = #KTb.#a.#QW();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb2 = #KTb.#b.#QW();
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2 = #jsc.#7rc(list, #Xrb2, #Yrb2);
			if (list2 == null || !list2.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
			{
				return true;
			}
			if (!AddPolygonSlabTool.#szb(#tzb, list))
			{
				return false;
			}
			if (list2.Count > 2)
			{
				return false;
			}
			if (#tzb == null && list.Count == 3 && #jsc.#Src(list[0], list[1], list[2]))
			{
				return false;
			}
			bool flag = list2.All(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, bool>(#KTb.#p8b));
			if (flag && list2.Count == 2)
			{
				flag = list2.Any(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, bool>(#KTb.#q8b));
			}
			return flag;
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x000EF918 File Offset: 0x000EDB18
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddPolygonSlabTool.#yZb #yZb = new AddPolygonSlabTool.#yZb();
			#yZb.#a = this;
			if (this.#zzb(this.#d.Last<devDept.Geometry.Point3D>(), #Ng, #Ng))
			{
				this.#xzb(#Ng);
			}
			if (this.#zzb(this.#d.Last<devDept.Geometry.Point3D>(), this.#b, null) && ColumnModelHelper.#9W(this.#d))
			{
				IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = this.#d.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddPolygonSlabTool.<>c.<>9.#s8b));
				#yZb.#b = new ShapeModel(new PolygonData(points3D));
				#yZb.#b.Application = this.#a.PolygonApplication;
				UndoAction.#uRb(base.UndoManager, new Action(#yZb.#t8b));
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.SnappingCache.#uP(base.Project);
				this.#b = null;
				this.#vzb();
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Editor.DynamicInput.SetInputValue(#Ng);
				base.Renderer.#9f(false, false);
				return true;
			}
			return false;
		}

		// Token: 0x06002DFD RID: 11773 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x04001265 RID: 4709
		private readonly #4zb #a;

		// Token: 0x04001266 RID: 4710
		private devDept.Geometry.Point3D #b;

		// Token: 0x04001267 RID: 4711
		private devDept.Geometry.Point3D #c;

		// Token: 0x04001268 RID: 4712
		private readonly List<devDept.Geometry.Point3D> #d = new List<devDept.Geometry.Point3D>();

		// Token: 0x04001269 RID: 4713
		private AddPolygonSlabTool.#s6b #e;

		// Token: 0x0400126A RID: 4714
		private bool #f;

		// Token: 0x020004E0 RID: 1248
		private enum #s6b
		{
			// Token: 0x0400126C RID: 4716
			#a,
			// Token: 0x0400126D RID: 4717
			#b
		}

		// Token: 0x020004E2 RID: 1250
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x06002E03 RID: 11779 RVA: 0x00029421 File Offset: 0x00027621
			internal bool #p8b(StructurePoint.CoreAssets.Infrastructure.Data.Point #gsb)
			{
				return PointsConverter.#uC(#gsb, this.#a.#QW()) || PointsConverter.#uC(#gsb, this.#b.#QW());
			}

			// Token: 0x06002E04 RID: 11780 RVA: 0x00029455 File Offset: 0x00027655
			internal bool #q8b(StructurePoint.CoreAssets.Infrastructure.Data.Point #gsb)
			{
				return PointsConverter.#uC(#gsb, this.#c.#b.#QW());
			}

			// Token: 0x04001271 RID: 4721
			public devDept.Geometry.Point3D #a;

			// Token: 0x04001272 RID: 4722
			public devDept.Geometry.Point3D #b;

			// Token: 0x04001273 RID: 4723
			public AddPolygonSlabTool #c;
		}

		// Token: 0x020004E3 RID: 1251
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06002E06 RID: 11782 RVA: 0x000EFA60 File Offset: 0x000EDC60
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x04001274 RID: 4724
			public AddPolygonSlabTool #a;

			// Token: 0x04001275 RID: 4725
			public ShapeModel #b;
		}
	}
}

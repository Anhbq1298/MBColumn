using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #LFb;
using #qzb;
using #RJb;
using #ryb;
using #xKe;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Shapes
{
	// Token: 0x020004FB RID: 1275
	internal sealed class AddSlabCircleByThreePointsTool : #bMb, #uNb, #MFb, IChildColumnEditorTool, #Uzb
	{
		// Token: 0x06002E84 RID: 11908 RVA: 0x00029A82 File Offset: 0x00027C82
		public AddSlabCircleByThreePointsTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F66 RID: 3942
		// (get) Token: 0x06002E85 RID: 11909 RVA: 0x00029A92 File Offset: 0x00027C92
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x06002E86 RID: 11910 RVA: 0x00029AA7 File Offset: 0x00027CA7
		// (set) Token: 0x06002E87 RID: 11911 RVA: 0x00029AB3 File Offset: 0x00027CB3
		public bool IsEnabled
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
					if (value)
					{
						base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
						return;
					}
					this.#1kb();
				}
			}
		}

		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x06002E88 RID: 11912 RVA: 0x00029AE9 File Offset: 0x00027CE9
		// (set) Token: 0x06002E89 RID: 11913 RVA: 0x00029AF5 File Offset: 0x00027CF5
		public #cOb Wrapper { get; set; }

		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x06002E8A RID: 11914 RVA: 0x00029B06 File Offset: 0x00027D06
		// (set) Token: 0x06002E8B RID: 11915 RVA: 0x00029B12 File Offset: 0x00027D12
		public #qyb Toolbar { get; set; }

		// Token: 0x06002E8C RID: 11916 RVA: 0x00029B23 File Offset: 0x00027D23
		public override void #1kb()
		{
			base.#1kb();
			this.#e = AddSlabCircleByThreePointsTool.#s6b.#a;
			this.#d = null;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002E8D RID: 11917 RVA: 0x000F178C File Offset: 0x000EF98C
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#e = AddSlabCircleByThreePointsTool.#s6b.#a;
			this.#b = null;
			this.#c = null;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#JMb();
			this.#g = false;
			base.#vf();
		}

		// Token: 0x06002E8E RID: 11918 RVA: 0x00029B59 File Offset: 0x00027D59
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#g = (args.Key == Key.Escape && this.#e == AddSlabCircleByThreePointsTool.#s6b.#a);
		}

		// Token: 0x06002E8F RID: 11919 RVA: 0x00029B8D File Offset: 0x00027D8D
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#g)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x000F17EC File Offset: 0x000EF9EC
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#a)
			{
				this.#b = #Ng;
				this.#e = AddSlabCircleByThreePointsTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifySecondPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#b)
			{
				this.#c = #Ng;
				this.#e = AddSlabCircleByThreePointsTool.#s6b.#c;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifyLastPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002E92 RID: 11922 RVA: 0x00029BC4 File Offset: 0x00027DC4
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#d = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002E93 RID: 11923 RVA: 0x000F18AC File Offset: 0x000EFAAC
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			devDept.Geometry.Point3D point3D = (base.Editor.DynamicInput.Config.LastInputPoint ?? new devDept.Geometry.Point3D()) + (args.FinalPoint ?? new devDept.Geometry.Point3D());
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#b && this.#b == point3D)
			{
				args.ErrorMessage = Strings.StringInvalidGeometry;
				return;
			}
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c && (this.#b == point3D || this.#c == point3D))
			{
				args.ErrorMessage = Strings.StringInvalidGeometry;
				return;
			}
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c && args.FinalPoint != null && this.#Vzb(new devDept.Geometry.Point3D(point3D.X, point3D.Y)) == null)
			{
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x06002E94 RID: 11924 RVA: 0x000F19A4 File Offset: 0x000EFBA4
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002E95 RID: 11925 RVA: 0x000F1A04 File Offset: 0x000EFC04
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x06002E96 RID: 11926 RVA: 0x000F1A64 File Offset: 0x000EFC64
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
		}

		// Token: 0x06002E97 RID: 11927 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002E98 RID: 11928 RVA: 0x000F1ABC File Offset: 0x000EFCBC
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#b)
			{
				base.#8Mb(this.#b, this.#d ?? planePosition);
			}
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c)
			{
				devDept.Geometry.Point3D #Ng = this.#d ?? planePosition;
				CircleData circleData = this.#Vzb(#Ng);
				if (circleData != null)
				{
					int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, circleData.Radius, 40);
					devDept.Geometry.Point3D[] #AHb = EyeshotHelper.ConstructRegularPolygon(new devDept.Geometry.Point3D(circleData.Center.X, circleData.Center.Y), circleData.Radius, numberOfSides, 0.0, true).ToArray();
					ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#a, this.#a.PolygonApplication);
				}
				base.#9Mb(this.#b);
				base.#8Mb(this.#c, this.#d ?? planePosition);
			}
			if (this.#d != null && this.#e == AddSlabCircleByThreePointsTool.#s6b.#a)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x06002E99 RID: 11929 RVA: 0x00029C02 File Offset: 0x00027E02
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#e == AddSlabCircleByThreePointsTool.#s6b.#c || this.#e == AddSlabCircleByThreePointsTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002E9A RID: 11930 RVA: 0x000F1C3C File Offset: 0x000EFE3C
		private CircleData #Vzb(devDept.Geometry.Point3D #Ng)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point #mcb = new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#b.X, this.#b.Y);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #ncb = new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#c.X, this.#c.Y);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ckc = new StructurePoint.CoreAssets.Infrastructure.Data.Point(#Ng.X, #Ng.Y);
			return CircleHelper.#pmc(#mcb, #ncb, #Ckc);
		}

		// Token: 0x06002E9B RID: 11931 RVA: 0x000F1CAC File Offset: 0x000EFEAC
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddSlabCircleByThreePointsTool.#p6b #p6b = new AddSlabCircleByThreePointsTool.#p6b();
			AddSlabCircleByThreePointsTool.#p6b #p6b2;
			if (4 != 0)
			{
				#p6b2 = #p6b;
			}
			#p6b2.#a = this;
			if (this.#e != AddSlabCircleByThreePointsTool.#s6b.#c)
			{
				return false;
			}
			CircleData circleData = this.#Vzb(#Ng);
			if (circleData == null)
			{
				return false;
			}
			int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, circleData.Radius, 40);
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = EyeshotHelper.ConstructRegularPolygon(new devDept.Geometry.Point3D(circleData.Center.X, circleData.Center.Y), circleData.Radius, numberOfSides, 0.0, true).Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddSlabCircleByThreePointsTool.<>c.<>9.#y8b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			#p6b2.#b = new ShapeModel(new PolygonData(points3D));
			#p6b2.#b.Application = this.#a.PolygonApplication;
			#p6b2.#b.FigureType = PolygonFigureType.Irregural;
			UndoAction.#uRb(base.UndoManager, new Action(#p6b2.#t8b));
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			this.#e = AddSlabCircleByThreePointsTool.#s6b.#a;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.Renderer.#9f(false, false);
			return true;
		}

		// Token: 0x06002E9C RID: 11932 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06002E9D RID: 11933 RVA: 0x000F1E18 File Offset: 0x000F0018
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#e == AddSlabCircleByThreePointsTool.#s6b.#b)
			{
				return this.#b == null || base.#4Mb(this.#b, #Ng, base.EditorContext.Snapping.#NLb());
			}
			return this.#e == AddSlabCircleByThreePointsTool.#s6b.#c && (this.#c == null || base.#4Mb(this.#c, #Ng, base.EditorContext.Snapping.#NLb()));
		}

		// Token: 0x040012AF RID: 4783
		private readonly #4zb #a;

		// Token: 0x040012B0 RID: 4784
		private devDept.Geometry.Point3D #b;

		// Token: 0x040012B1 RID: 4785
		private devDept.Geometry.Point3D #c;

		// Token: 0x040012B2 RID: 4786
		private devDept.Geometry.Point3D #d;

		// Token: 0x040012B3 RID: 4787
		private AddSlabCircleByThreePointsTool.#s6b #e;

		// Token: 0x040012B4 RID: 4788
		private bool #f;

		// Token: 0x040012B5 RID: 4789
		private bool #g;

		// Token: 0x040012B6 RID: 4790
		[CompilerGenerated]
		private #cOb #h;

		// Token: 0x040012B7 RID: 4791
		[CompilerGenerated]
		private #qyb #i;

		// Token: 0x020004FC RID: 1276
		private enum #s6b
		{
			// Token: 0x040012B9 RID: 4793
			#a,
			// Token: 0x040012BA RID: 4794
			#b,
			// Token: 0x040012BB RID: 4795
			#c
		}

		// Token: 0x020004FE RID: 1278
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x06002EA2 RID: 11938 RVA: 0x000F1EA4 File Offset: 0x000F00A4
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x040012BE RID: 4798
			public AddSlabCircleByThreePointsTool #a;

			// Token: 0x040012BF RID: 4799
			public ShapeModel #b;
		}
	}
}

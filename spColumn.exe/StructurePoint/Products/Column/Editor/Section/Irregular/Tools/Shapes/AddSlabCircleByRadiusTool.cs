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
	// Token: 0x020004F5 RID: 1269
	internal sealed class AddSlabCircleByRadiusTool : #bMb, #uNb, #MFb, IChildColumnEditorTool, #NFb
	{
		// Token: 0x06002E65 RID: 11877 RVA: 0x00029881 File Offset: 0x00027A81
		public AddSlabCircleByRadiusTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F62 RID: 3938
		// (get) Token: 0x06002E66 RID: 11878 RVA: 0x00029891 File Offset: 0x00027A91
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x17000F63 RID: 3939
		// (get) Token: 0x06002E67 RID: 11879 RVA: 0x000298A6 File Offset: 0x00027AA6
		// (set) Token: 0x06002E68 RID: 11880 RVA: 0x000298B2 File Offset: 0x00027AB2
		public bool IsEnabled
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					if (value)
					{
						base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
						return;
					}
					this.#1kb();
				}
			}
		}

		// Token: 0x17000F64 RID: 3940
		// (get) Token: 0x06002E69 RID: 11881 RVA: 0x000298E8 File Offset: 0x00027AE8
		// (set) Token: 0x06002E6A RID: 11882 RVA: 0x000298F4 File Offset: 0x00027AF4
		public #cOb Wrapper { get; set; }

		// Token: 0x17000F65 RID: 3941
		// (get) Token: 0x06002E6B RID: 11883 RVA: 0x00029905 File Offset: 0x00027B05
		// (set) Token: 0x06002E6C RID: 11884 RVA: 0x00029911 File Offset: 0x00027B11
		public #qyb Toolbar { get; set; }

		// Token: 0x06002E6D RID: 11885 RVA: 0x00029922 File Offset: 0x00027B22
		public override void #1kb()
		{
			base.#1kb();
			this.#d = AddSlabCircleByRadiusTool.#s6b.#a;
			this.#c = null;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002E6E RID: 11886 RVA: 0x00029958 File Offset: 0x00027B58
		public override void OnActivated()
		{
			base.OnActivated();
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
		}

		// Token: 0x06002E6F RID: 11887 RVA: 0x000F1280 File Offset: 0x000EF480
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#d = AddSlabCircleByRadiusTool.#s6b.#a;
			this.#b = null;
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#JMb();
			this.#f = false;
			base.#vf();
		}

		// Token: 0x06002E70 RID: 11888 RVA: 0x0002997A File Offset: 0x00027B7A
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#f = (args.Key == Key.Escape && this.#d == AddSlabCircleByRadiusTool.#s6b.#a);
		}

		// Token: 0x06002E71 RID: 11889 RVA: 0x000299AE File Offset: 0x00027BAE
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#f)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002E72 RID: 11890 RVA: 0x000F12D8 File Offset: 0x000EF4D8
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#a)
			{
				this.#b = #Ng;
				this.#d = AddSlabCircleByRadiusTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#UMb(Strings.StringSpecifyRadius, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x06002E73 RID: 11891 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002E74 RID: 11892 RVA: 0x000299E5 File Offset: 0x00027BE5
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002E75 RID: 11893 RVA: 0x000F1344 File Offset: 0x000EF544
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#b && args.FinalPoint != null)
			{
				devDept.Geometry.Point3D left = this.#b + args.FinalPoint;
				if (left != this.#b)
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x06002E76 RID: 11894 RVA: 0x000F13A8 File Offset: 0x000EF5A8
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002E77 RID: 11895 RVA: 0x000F1408 File Offset: 0x000EF608
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x06002E78 RID: 11896 RVA: 0x000F1468 File Offset: 0x000EF668
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

		// Token: 0x06002E79 RID: 11897 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002E7A RID: 11898 RVA: 0x000F14C0 File Offset: 0x000EF6C0
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#b)
			{
				double num = Math.Abs(this.#b.DistanceTo(this.#c ?? planePosition));
				int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, num, 40);
				devDept.Geometry.Point3D[] #AHb = EyeshotHelper.ConstructRegularPolygon(this.#b, num, numberOfSides, 0.0, true).ToArray();
				ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#a, this.#a.PolygonApplication);
				base.#8Mb(this.#b, this.#c ?? planePosition);
			}
			if (this.#c != null && this.#d == AddSlabCircleByRadiusTool.#s6b.#a)
			{
				base.#9Mb(this.#c);
			}
		}

		// Token: 0x06002E7B RID: 11899 RVA: 0x00029A23 File Offset: 0x00027C23
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#d == AddSlabCircleByRadiusTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002E7C RID: 11900 RVA: 0x000F15F4 File Offset: 0x000EF7F4
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddSlabCircleByRadiusTool.#CZb #CZb = new AddSlabCircleByRadiusTool.#CZb();
			#CZb.#a = this;
			if (this.#d == AddSlabCircleByRadiusTool.#s6b.#b)
			{
				double num = Math.Abs(this.#b.DistanceTo(#Ng));
				int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, num, 40);
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = EyeshotHelper.ConstructRegularPolygon(this.#b, num, numberOfSides, 0.0, true).Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddSlabCircleByRadiusTool.<>c.<>9.#x8b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
				#CZb.#b = new ShapeModel(new PolygonData(points3D));
				#CZb.#b.Application = this.#a.PolygonApplication;
				#CZb.#b.FigureType = PolygonFigureType.Irregural;
				UndoAction.#uRb(base.UndoManager, new Action(#CZb.#t8b));
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.SnappingCache.#uP(base.Project);
				this.#d = AddSlabCircleByRadiusTool.#s6b.#a;
				base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
				base.Renderer.#9f(false, false);
				return true;
			}
			return false;
		}

		// Token: 0x06002E7D RID: 11901 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x00029A47 File Offset: 0x00027C47
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			return base.#4Mb(this.#b, #Ng, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x040012A0 RID: 4768
		private readonly #4zb #a;

		// Token: 0x040012A1 RID: 4769
		private devDept.Geometry.Point3D #b;

		// Token: 0x040012A2 RID: 4770
		private devDept.Geometry.Point3D #c;

		// Token: 0x040012A3 RID: 4771
		private AddSlabCircleByRadiusTool.#s6b #d;

		// Token: 0x040012A4 RID: 4772
		private bool #e;

		// Token: 0x040012A5 RID: 4773
		private bool #f;

		// Token: 0x040012A6 RID: 4774
		[CompilerGenerated]
		private #cOb #g;

		// Token: 0x040012A7 RID: 4775
		[CompilerGenerated]
		private #qyb #h;

		// Token: 0x020004F6 RID: 1270
		private enum #s6b
		{
			// Token: 0x040012A9 RID: 4777
			#a,
			// Token: 0x040012AA RID: 4778
			#b
		}

		// Token: 0x020004F8 RID: 1272
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x06002E83 RID: 11907 RVA: 0x000F173C File Offset: 0x000EF93C
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x040012AD RID: 4781
			public AddSlabCircleByRadiusTool #a;

			// Token: 0x040012AE RID: 4782
			public ShapeModel #b;
		}
	}
}

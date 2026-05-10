using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aAb;
using #cMb;
using #LFb;
using #N6c;
using #o1d;
using #RJb;
using #xKe;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.Section;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select
{
	// Token: 0x02000540 RID: 1344
	internal sealed class SplitSlabsTool : #tNb, #uNb, IChildColumnEditorTool, #5Fb
	{
		// Token: 0x06003021 RID: 12321 RVA: 0x0002AC50 File Offset: 0x00028E50
		public SplitSlabsTool(IExtendedServices services, IEditorService editorService) : base(services)
		{
			this.#a = editorService;
		}

		// Token: 0x17000FA7 RID: 4007
		// (get) Token: 0x06003022 RID: 12322 RVA: 0x0002AC60 File Offset: 0x00028E60
		// (set) Token: 0x06003023 RID: 12323 RVA: 0x000F79D0 File Offset: 0x000F5BD0
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
					if (value)
					{
						base.#KMb(Strings.StringSpecifySplitLineStart, true, false, true);
						return;
					}
					base.#JMb();
					base.Services.GuiController.MessageStatusBar.#uP(string.Empty);
				}
			}
		}

		// Token: 0x06003024 RID: 12324 RVA: 0x000F7A2C File Offset: 0x000F5C2C
		public override void #1kb()
		{
			base.#1kb();
			bool #gAb = this.#e == SplitSlabsTool.#s6b.#a;
			this.#fAb(#gAb);
		}

		// Token: 0x06003025 RID: 12325 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06003026 RID: 12326 RVA: 0x0002AC6C File Offset: 0x00028E6C
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			base.#vf();
			this.#Bzb(args.Point);
		}

		// Token: 0x06003027 RID: 12327 RVA: 0x000F7A5C File Offset: 0x000F5C5C
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || !base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == SplitSlabsTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06003028 RID: 12328 RVA: 0x000F7AC4 File Offset: 0x000F5CC4
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			#47c<ShapeModel> #47c = base.EditorContext.Selection.Shapes.SelectedObjects;
			if (!base.#WMb(true) || #47c.Count < 1 || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == SplitSlabsTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x000F7B4C File Offset: 0x000F5D4C
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false) || !base.EditorContext.Selection.Shapes.SelectedObjects.Any<ShapeModel>())
			{
				this.#fAb(true);
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			base.#vf();
			this.#Bzb(planePosition);
		}

		// Token: 0x0600302A RID: 12330 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x000F7BC8 File Offset: 0x000F5DC8
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			#47c<ShapeModel> #47c = base.EditorContext.Selection.Shapes.SelectedObjects;
			if (this.#e == SplitSlabsTool.#s6b.#b && #47c.Count > 0)
			{
				this.#hBb(this.#c, planePosition, base.Editor, base.RenderContext);
			}
		}

		// Token: 0x0600302C RID: 12332 RVA: 0x000F7C64 File Offset: 0x000F5E64
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			#47c<ShapeModel> #47c = base.EditorContext.Selection.Shapes.SelectedObjects;
			if (!base.#WMb(true) || #47c.Count < 1)
			{
				return false;
			}
			if (this.#e == SplitSlabsTool.#s6b.#a)
			{
				this.#c = new devDept.Geometry.Point3D(#Ng.X, #Ng.Y, #Ng.Z);
				this.#d = new devDept.Geometry.Point3D(#Ng.X, #Ng.Y, #Ng.Z);
				this.#e = SplitSlabsTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#KMb(Strings.StringSpecifySplitLineEnd, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			this.#d = #Ng;
			if (this.#c == this.#d)
			{
				return false;
			}
			base.Services.MouseAndKeyboard.#M2c();
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> source = PointsConverter.#Csc(GeometryHelper.#9nc(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.#c.X, this.#c.Y, this.#c.Z), new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.#d.X, this.#d.Y, this.#d.Z)), 0.0).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #oBb = new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#c.X, this.#c.Y);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #pBb = new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#d.X, this.#d.Y);
			this.#mBb(source.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point3D, devDept.Geometry.Point3D>(SplitSlabsTool.<>c.<>9.#X8b)).ToList<devDept.Geometry.Point3D>(), #oBb, #pBb);
			base.Services.MessageBus.#tV();
			return true;
		}

		// Token: 0x0600302D RID: 12333 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x0600302E RID: 12334 RVA: 0x000F7E3C File Offset: 0x000F603C
		private void #fAb(bool #gAb)
		{
			this.#e = SplitSlabsTool.#s6b.#a;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifySplitLineStart, true, false, true);
			if (#gAb)
			{
				base.Services.MessageBus.#uV(this);
			}
			base.#vf();
		}

		// Token: 0x0600302F RID: 12335 RVA: 0x000F7E98 File Offset: 0x000F6098
		private void #hBb(devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb, ColumnEditor #iBb, RenderContextBase #ib)
		{
			#Akb = base.Editor.WorldToScreen(#Akb);
			#Bkb = base.Editor.WorldToScreen(#Bkb);
			#ib.SetColorWireframe(base.Settings.ToolHelperColor, false);
			#ib.SetLineStipple(1, 3855, #iBb.Viewports[0].Camera);
			#ib.EnableLineStipple(true);
			#ib.DrawLine(#Akb, #Bkb);
			#ib.EnableLineStipple(false);
		}

		// Token: 0x06003030 RID: 12336 RVA: 0x0002ACA4 File Offset: 0x00028EA4
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			return base.#4Mb(this.#c, #Ng, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x06003031 RID: 12337 RVA: 0x0002ACCF File Offset: 0x00028ECF
		private void #Bzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#e == SplitSlabsTool.#s6b.#b)
			{
				this.#d = #Ng;
				base.#RCf();
			}
		}

		// Token: 0x06003032 RID: 12338 RVA: 0x000F7F18 File Offset: 0x000F6118
		private void #jBb(ShapeModel #kBb, IList<ShapeModel> #lBb)
		{
			SplitSlabsTool.#CTb #CTb = new SplitSlabsTool.#CTb();
			#CTb.#a = #kBb;
			#CTb.#b = this;
			this.#qBb(base.EditorContext, new List<ShapeModel>
			{
				#CTb.#a
			});
			#lBb.#I1d(new Action<ShapeModel>(#CTb.#08b));
			#lBb.#I1d(new Action<ShapeModel>(#CTb.#18b));
			base.EditorContext.SnappingCache.#uP(base.Project);
			base.EditorContext.Selection.Shapes.#EOb(#CTb.#a);
			base.EditorContext.Selection.Shapes.#HOb(#lBb.ToList<ShapeModel>());
		}

		// Token: 0x06003033 RID: 12339 RVA: 0x000F7FE4 File Offset: 0x000F61E4
		private void #mBb(List<devDept.Geometry.Point3D> #nBb, StructurePoint.CoreAssets.Infrastructure.Data.Point #oBb, StructurePoint.CoreAssets.Infrastructure.Data.Point #pBb)
		{
			SplitSlabsTool.#ETb #ETb = new SplitSlabsTool.#ETb();
			#ETb.#b = #oBb;
			#ETb.#c = #pBb;
			#ETb.#e = this;
			#ETb.#a = new PolygonData(#nBb.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(SplitSlabsTool.<>c.<>9.#Y8b)));
			List<ShapeModel> source = base.EditorContext.Selection.Shapes.SelectedInNaturalOrder.ToList<ShapeModel>();
			#ETb.#d = source.Where(new Func<ShapeModel, bool>(#ETb.#28b)).ToList<ShapeModel>();
			if (!#ETb.#d.Any<ShapeModel>())
			{
				return;
			}
			this.#a.#0Pb(new Func<bool>(#ETb.#38b));
			base.Renderer.#9f(false, false);
			this.#fAb(true);
		}

		// Token: 0x06003034 RID: 12340 RVA: 0x0002ACF3 File Offset: 0x00028EF3
		private void #qBb(#cLb #FR, List<ShapeModel> #rBb)
		{
			#FR.ProjectContext.Model.Shapes.#71d(#rBb);
		}

		// Token: 0x04001379 RID: 4985
		private readonly IEditorService #a;

		// Token: 0x0400137A RID: 4986
		private bool #b;

		// Token: 0x0400137B RID: 4987
		private devDept.Geometry.Point3D #c;

		// Token: 0x0400137C RID: 4988
		private devDept.Geometry.Point3D #d;

		// Token: 0x0400137D RID: 4989
		private SplitSlabsTool.#s6b #e;

		// Token: 0x02000541 RID: 1345
		private enum #s6b
		{
			// Token: 0x0400137F RID: 4991
			#a,
			// Token: 0x04001380 RID: 4992
			#b
		}

		// Token: 0x02000543 RID: 1347
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x0600303B RID: 12347 RVA: 0x0002AD61 File Offset: 0x00028F61
			internal void #08b(ShapeModel #Rf)
			{
				#Rf.Application = this.#a.Application;
			}

			// Token: 0x0600303C RID: 12348 RVA: 0x0002AD80 File Offset: 0x00028F80
			internal void #18b(ShapeModel #Rf)
			{
				this.#b.Project.Model.Shapes.Add(#Rf);
				this.#b.Project.#1Uh(#Rf);
			}

			// Token: 0x04001385 RID: 4997
			public ShapeModel #a;

			// Token: 0x04001386 RID: 4998
			public SplitSlabsTool #b;
		}

		// Token: 0x02000544 RID: 1348
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x0600303E RID: 12350 RVA: 0x0002ADBA File Offset: 0x00028FBA
			internal bool #28b(ShapeModel #Rf)
			{
				return ColumnShapesHelper.#xHb(this.#a, #Rf, this.#b, this.#c);
			}

			// Token: 0x0600303F RID: 12351 RVA: 0x000F80CC File Offset: 0x000F62CC
			internal bool #38b()
			{
				bool result = false;
				ColumnGeometryHelper columnGeometryHelper = new ColumnGeometryHelper();
				foreach (ShapeModel shapeModel in this.#d)
				{
					#TAb.#SAb(shapeModel);
					PolygonData #JP = shapeModel.#cxc(0);
					#yKe #yKe = columnGeometryHelper.#zuc(#JP, new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#b.X, this.#b.Y), new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.#c.X, this.#c.Y));
					if (#yKe != null && #yKe.Shapes.Count > 1)
					{
						List<ShapeModel> list = #yKe.Shapes.Select(new Func<ShapeData, ShapeModel>(SplitSlabsTool.<>c.<>9.#Z8b)).ToList<ShapeModel>();
						SectionValidationHelper sectionValidationHelper = new SectionValidationHelper(this.#e.Services.DialogService, this.#e.Project);
						if (!sectionValidationHelper.#IH(list, true))
						{
							return false;
						}
						this.#e.#jBb(shapeModel, list);
						result = true;
					}
				}
				return result;
			}

			// Token: 0x04001387 RID: 4999
			public PolygonData #a;

			// Token: 0x04001388 RID: 5000
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #b;

			// Token: 0x04001389 RID: 5001
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #c;

			// Token: 0x0400138A RID: 5002
			public List<ShapeModel> #d;

			// Token: 0x0400138B RID: 5003
			public SplitSlabsTool #e;
		}
	}
}

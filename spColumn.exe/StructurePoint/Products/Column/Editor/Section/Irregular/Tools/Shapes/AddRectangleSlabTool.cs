using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #lzb;
using #qzb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Data;
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
	// Token: 0x020004E5 RID: 1253
	internal sealed class AddRectangleSlabTool : #bMb, #uNb, #Czb
	{
		// Token: 0x06002E07 RID: 11783 RVA: 0x00029479 File Offset: 0x00027679
		public AddRectangleSlabTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F59 RID: 3929
		// (get) Token: 0x06002E08 RID: 11784 RVA: 0x00029489 File Offset: 0x00027689
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x06002E09 RID: 11785 RVA: 0x000EFAB0 File Offset: 0x000EDCB0
		public override void #1kb()
		{
			base.#1kb();
			this.#d = AddRectangleSlabTool.#s6b.#a;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#c = null;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002E0A RID: 11786 RVA: 0x0002949E File Offset: 0x0002769E
		public override void OnActivated()
		{
			base.OnActivated();
			base.ForceOrthoDisabled = true;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
		}

		// Token: 0x06002E0B RID: 11787 RVA: 0x000EFB04 File Offset: 0x000EDD04
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			base.ForceOrthoDisabled = false;
			this.#d = AddRectangleSlabTool.#s6b.#a;
			this.#b = null;
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#e = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x06002E0C RID: 11788 RVA: 0x000294C7 File Offset: 0x000276C7
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#e = (args.Key == Key.Escape && this.#d == AddRectangleSlabTool.#s6b.#a);
		}

		// Token: 0x06002E0D RID: 11789 RVA: 0x000294FB File Offset: 0x000276FB
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#e)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002E0E RID: 11790 RVA: 0x000EFB64 File Offset: 0x000EDD64
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#d == AddRectangleSlabTool.#s6b.#a)
			{
				this.#b = #Ng;
				this.#d = AddRectangleSlabTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#TMb(Strings.StringSpecifyDimensions, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x06002E0F RID: 11791 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002E10 RID: 11792 RVA: 0x00029532 File Offset: 0x00027732
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002E11 RID: 11793 RVA: 0x000EFBD0 File Offset: 0x000EDDD0
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = ((this.#Fzb() && this.#b != null) ? base.#bNb(#LLb.#n, this.#Ezb(planePosition)) : base.#bNb(#LLb.#n, planePosition));
			if (this.#d == AddRectangleSlabTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			if (this.#d != AddRectangleSlabTool.#s6b.#b && args.ChangedButton != System.Windows.Input.MouseButton.Middle)
			{
				this.#fzb(planePosition, false);
			}
		}

		// Token: 0x06002E12 RID: 11794 RVA: 0x000EFC7C File Offset: 0x000EDE7C
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == AddRectangleSlabTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			if (this.#Fzb())
			{
				this.#Azb(this.#Ezb(planePosition));
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x06002E13 RID: 11795 RVA: 0x000EFCF0 File Offset: 0x000EDEF0
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			if (this.#Fzb() && this.#b != null && this.#d == AddRectangleSlabTool.#s6b.#b)
			{
				planePosition = this.#Ezb(planePosition);
			}
			if (this.#d != AddRectangleSlabTool.#s6b.#b)
			{
				this.#b = null;
			}
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
		}

		// Token: 0x06002E14 RID: 11796 RVA: 0x000EFD90 File Offset: 0x000EDF90
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			if (this.#Fzb())
			{
				args.SnappedPoint = this.#Ezb(args.SnappedPoint);
			}
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x000EFDE4 File Offset: 0x000EDFE4
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = (this.#Fzb() ? this.#Ezb(base.#cNb(#LLb.#n, planePosition)) : base.#cNb(#LLb.#n, planePosition));
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#d == AddRectangleSlabTool.#s6b.#b)
			{
				devDept.Geometry.Point3D[] #AHb = ColumnShapesHelper.#BHb(this.#b, this.#c ?? planePosition, true);
				ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#a, this.#a.PolygonApplication);
				base.#8Mb(this.#b, this.#c ?? planePosition);
			}
			if (this.#c != null && this.#d == AddRectangleSlabTool.#s6b.#a)
			{
				base.#9Mb(this.#c);
			}
		}

		// Token: 0x06002E16 RID: 11798 RVA: 0x00029570 File Offset: 0x00027770
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#d == AddRectangleSlabTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x000EFEF0 File Offset: 0x000EE0F0
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			double? num = (args.CoordinateType == DynamicInputCoordinateType.CoordinateX) ? args.CoordinateX : args.CoordinateY;
			if (num == null)
			{
				return;
			}
			if (base.Editor.DynamicInput.Config.Mode == DynamicInputMode.RelativeRectangle)
			{
				int #8W = base.Services.Project.Model.DraftingSettings.DynamicInputSettings.Precision;
				string errorMessage;
				#ozb.#mzb(num.Value, #8W, out errorMessage);
				args.ErrorMessage = errorMessage;
			}
		}

		// Token: 0x06002E18 RID: 11800 RVA: 0x000EFF90 File Offset: 0x000EE190
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddRectangleSlabTool.#CTb #CTb = new AddRectangleSlabTool.#CTb();
			#CTb.#a = this;
			if (this.#d == AddRectangleSlabTool.#s6b.#b)
			{
				devDept.Geometry.Point3D[] array = ColumnShapesHelper.#BHb(this.#b, #Ng, false);
				IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = array.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddRectangleSlabTool.<>c.<>9.#u8b));
				PolygonData polygon = new PolygonData(points3D);
				EyeshotBoundingBoxDataLight eyeshotBoundingBoxDataLight = new EyeshotBoundingBoxDataLight(array);
				StructurePoint.CoreAssets.Infrastructure.Data.Point startPoint = new StructurePoint.CoreAssets.Infrastructure.Data.Point(eyeshotBoundingBoxDataLight.MinX, eyeshotBoundingBoxDataLight.MinY);
				#CTb.#b = new ShapeModel(polygon, startPoint, eyeshotBoundingBoxDataLight.MaxX - eyeshotBoundingBoxDataLight.MinX, eyeshotBoundingBoxDataLight.MaxY - eyeshotBoundingBoxDataLight.MinY);
				#CTb.#b.Application = this.#a.PolygonApplication;
				UndoAction.#uRb(base.UndoManager, new Action(#CTb.#t8b));
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.SnappingCache.#uP(base.Project);
				this.#d = AddRectangleSlabTool.#s6b.#a;
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Renderer.#9f(false, false);
				return true;
			}
			return false;
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000F00CC File Offset: 0x000EE2CC
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			return base.#Dzb(this.#b.X, #Ng.X, base.EditorContext.Snapping.#NLb()) && base.#Dzb(this.#b.Y, #Ng.Y, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x06002E1B RID: 11803 RVA: 0x000F0138 File Offset: 0x000EE338
		private devDept.Geometry.Point3D #Ezb(devDept.Geometry.Point3D #jzb)
		{
			devDept.Geometry.Point3D point3D = this.#b;
			if (this.#Fzb() && point3D != null && #jzb != null)
			{
				double value = #jzb.X - point3D.X;
				double value2 = #jzb.Y - point3D.Y;
				double num = point3D.X;
				double num2 = point3D.Y;
				if (Math.Abs(value) > Math.Abs(value2))
				{
					num += (double)Math.Sign(value) * Math.Abs(value2);
					num2 = #jzb.Y;
				}
				else
				{
					num2 += (double)Math.Sign(value2) * Math.Abs(value);
					num = #jzb.X;
				}
				#jzb.X = num;
				#jzb.Y = num2;
				return #jzb;
			}
			return #jzb;
		}

		// Token: 0x06002E1C RID: 11804 RVA: 0x00028DC3 File Offset: 0x00026FC3
		private bool #Fzb()
		{
			return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
		}

		// Token: 0x04001276 RID: 4726
		private readonly #4zb #a;

		// Token: 0x04001277 RID: 4727
		private devDept.Geometry.Point3D #b;

		// Token: 0x04001278 RID: 4728
		private devDept.Geometry.Point3D #c;

		// Token: 0x04001279 RID: 4729
		private AddRectangleSlabTool.#s6b #d;

		// Token: 0x0400127A RID: 4730
		private bool #e;

		// Token: 0x020004E6 RID: 1254
		private enum #s6b
		{
			// Token: 0x0400127C RID: 4732
			#a,
			// Token: 0x0400127D RID: 4733
			#b
		}

		// Token: 0x020004E8 RID: 1256
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06002E21 RID: 11809 RVA: 0x000F020C File Offset: 0x000EE40C
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x04001280 RID: 4736
			public AddRectangleSlabTool #a;

			// Token: 0x04001281 RID: 4737
			public ShapeModel #b;
		}
	}
}

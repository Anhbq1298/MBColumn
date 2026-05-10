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
	// Token: 0x020004F1 RID: 1265
	internal sealed class AddSlabCircleByDiameterTool : #bMb, #uNb, #Qzb, #MFb, IChildColumnEditorTool
	{
		// Token: 0x06002E47 RID: 11847 RVA: 0x000296A2 File Offset: 0x000278A2
		public AddSlabCircleByDiameterTool(IExtendedServices services, #4zb parameters) : base(services)
		{
			this.#a = parameters;
		}

		// Token: 0x17000F5E RID: 3934
		// (get) Token: 0x06002E48 RID: 11848 RVA: 0x000296B2 File Offset: 0x000278B2
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x17000F5F RID: 3935
		// (get) Token: 0x06002E49 RID: 11849 RVA: 0x000296C7 File Offset: 0x000278C7
		// (set) Token: 0x06002E4A RID: 11850 RVA: 0x000296D3 File Offset: 0x000278D3
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
						base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
						return;
					}
					this.#1kb();
				}
			}
		}

		// Token: 0x17000F60 RID: 3936
		// (get) Token: 0x06002E4B RID: 11851 RVA: 0x00029709 File Offset: 0x00027909
		// (set) Token: 0x06002E4C RID: 11852 RVA: 0x00029715 File Offset: 0x00027915
		public #cOb Wrapper { get; set; }

		// Token: 0x17000F61 RID: 3937
		// (get) Token: 0x06002E4D RID: 11853 RVA: 0x00029726 File Offset: 0x00027926
		// (set) Token: 0x06002E4E RID: 11854 RVA: 0x00029732 File Offset: 0x00027932
		public #qyb Toolbar { get; set; }

		// Token: 0x06002E4F RID: 11855 RVA: 0x00029743 File Offset: 0x00027943
		public override void #1kb()
		{
			base.#1kb();
			this.#d = AddSlabCircleByDiameterTool.#s6b.#a;
			this.#c = null;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002E50 RID: 11856 RVA: 0x000F0D20 File Offset: 0x000EEF20
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#d = AddSlabCircleByDiameterTool.#s6b.#a;
			this.#b = null;
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#f = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x06002E51 RID: 11857 RVA: 0x00029779 File Offset: 0x00027979
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#f = (args.Key == Key.Escape && this.#d == AddSlabCircleByDiameterTool.#s6b.#a);
		}

		// Token: 0x06002E52 RID: 11858 RVA: 0x000297AD File Offset: 0x000279AD
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#f)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002E53 RID: 11859 RVA: 0x000F0D78 File Offset: 0x000EEF78
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#a)
			{
				this.#b = #Ng;
				this.#d = AddSlabCircleByDiameterTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifySecondPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x06002E54 RID: 11860 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x000297E4 File Offset: 0x000279E4
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002E56 RID: 11862 RVA: 0x000F0DE4 File Offset: 0x000EEFE4
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#b && args.FinalPoint != null)
			{
				devDept.Geometry.Point3D left = this.#b + args.FinalPoint;
				if (left != this.#b)
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x06002E57 RID: 11863 RVA: 0x000F0E48 File Offset: 0x000EF048
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002E58 RID: 11864 RVA: 0x000F0EA8 File Offset: 0x000EF0A8
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x06002E59 RID: 11865 RVA: 0x000F0F08 File Offset: 0x000EF108
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

		// Token: 0x06002E5A RID: 11866 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002E5B RID: 11867 RVA: 0x000F0F60 File Offset: 0x000EF160
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#b)
			{
				devDept.Geometry.Point3D point3D = this.#c ?? planePosition;
				double num = Math.Abs(this.#b.DistanceTo(point3D)) / 2.0;
				devDept.Geometry.Point3D center = this.#b + (point3D - this.#b) / 2.0;
				int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, num, 40);
				devDept.Geometry.Point3D[] #AHb = EyeshotHelper.ConstructRegularPolygon(center, num, numberOfSides, 0.0, true).ToArray();
				ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#a, this.#a.PolygonApplication);
				base.#8Mb(this.#b, this.#c ?? planePosition);
			}
			if (this.#c != null && this.#d == AddSlabCircleByDiameterTool.#s6b.#a)
			{
				base.#9Mb(this.#c);
			}
		}

		// Token: 0x06002E5C RID: 11868 RVA: 0x00029822 File Offset: 0x00027A22
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#d == AddSlabCircleByDiameterTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002E5D RID: 11869 RVA: 0x000F10C0 File Offset: 0x000EF2C0
		private bool #Azb(devDept.Geometry.Point3D #Ng)
		{
			AddSlabCircleByDiameterTool.#aVb #aVb = new AddSlabCircleByDiameterTool.#aVb();
			#aVb.#a = this;
			if (this.#d == AddSlabCircleByDiameterTool.#s6b.#b)
			{
				double num = Math.Abs(this.#b.DistanceTo(#Ng)) / 2.0;
				devDept.Geometry.Point3D center = this.#b + (#Ng - this.#b) / 2.0;
				int numberOfSides = #4ai.#3ai(base.Project.Model.Options.Unit, num, 40);
				IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = EyeshotHelper.ConstructRegularPolygon(center, num, numberOfSides, 0.0, true).Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(AddSlabCircleByDiameterTool.<>c.<>9.#w8b));
				#aVb.#b = new ShapeModel(new PolygonData(points3D));
				#aVb.#b.Application = this.#a.PolygonApplication;
				#aVb.#b.FigureType = PolygonFigureType.Irregural;
				UndoAction.#uRb(base.UndoManager, new Action(#aVb.#t8b));
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.SnappingCache.#uP(base.Project);
				this.#d = AddSlabCircleByDiameterTool.#s6b.#a;
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Renderer.#9f(false, false);
				return true;
			}
			return false;
		}

		// Token: 0x06002E5E RID: 11870 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06002E5F RID: 11871 RVA: 0x00029846 File Offset: 0x00027A46
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			return base.#4Mb(this.#b, #Ng, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x04001291 RID: 4753
		private readonly #4zb #a;

		// Token: 0x04001292 RID: 4754
		private devDept.Geometry.Point3D #b;

		// Token: 0x04001293 RID: 4755
		private devDept.Geometry.Point3D #c;

		// Token: 0x04001294 RID: 4756
		private AddSlabCircleByDiameterTool.#s6b #d;

		// Token: 0x04001295 RID: 4757
		private bool #e;

		// Token: 0x04001296 RID: 4758
		private bool #f;

		// Token: 0x04001297 RID: 4759
		[CompilerGenerated]
		private #cOb #g;

		// Token: 0x04001298 RID: 4760
		[CompilerGenerated]
		private #qyb #h;

		// Token: 0x020004F2 RID: 1266
		private enum #s6b
		{
			// Token: 0x0400129A RID: 4762
			#a,
			// Token: 0x0400129B RID: 4763
			#b
		}

		// Token: 0x020004F4 RID: 1268
		[CompilerGenerated]
		private sealed class #aVb
		{
			// Token: 0x06002E64 RID: 11876 RVA: 0x000F1230 File Offset: 0x000EF430
			internal void #t8b()
			{
				this.#a.Project.Model.Shapes.Add(this.#b);
				this.#a.Project.#1Uh(this.#b);
			}

			// Token: 0x0400129E RID: 4766
			public AddSlabCircleByDiameterTool #a;

			// Token: 0x0400129F RID: 4767
			public ShapeModel #b;
		}
	}
}

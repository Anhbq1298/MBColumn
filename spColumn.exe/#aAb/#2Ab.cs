using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using #cMb;
using #hR;
using #LFb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace #aAb
{
	// Token: 0x0200050F RID: 1295
	internal class #2Ab : #tNb, #uNb, IChildColumnEditorTool
	{
		// Token: 0x06002EFF RID: 12031 RVA: 0x0002A0B8 File Offset: 0x000282B8
		public #2Ab(IExtendedServices #0c, #UFb #bX) : base(#0c)
		{
			this.#a = #bX;
		}

		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x06002F00 RID: 12032 RVA: 0x0002A0C8 File Offset: 0x000282C8
		// (set) Token: 0x06002F01 RID: 12033 RVA: 0x000F2C30 File Offset: 0x000F0E30
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
					base.ForceOrthoDisabled = value;
					if (value)
					{
						string #LMb = this.Horizontal ? Strings.StringSpecifyReferenceY : Strings.StringSpecifyReferenceX;
						base.#KMb(#LMb, true, false, true);
						this.#ZAb();
						return;
					}
					base.#JMb();
					this.#YAb();
				}
			}
		}

		// Token: 0x17000F7A RID: 3962
		// (get) Token: 0x06002F02 RID: 12034 RVA: 0x0002A0D4 File Offset: 0x000282D4
		// (set) Token: 0x06002F03 RID: 12035 RVA: 0x0002A0E0 File Offset: 0x000282E0
		protected bool Horizontal { get; set; }

		// Token: 0x06002F04 RID: 12036 RVA: 0x0002A0F1 File Offset: 0x000282F1
		public override void #1kb()
		{
			base.#1kb();
			this.#YAb();
			base.Services.MessageBus.#uV(this);
		}

		// Token: 0x06002F05 RID: 12037 RVA: 0x000F2C98 File Offset: 0x000F0E98
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (base.Editor.IsMouseWithinVisualObjects())
			{
				return;
			}
			base.Editor.PaintBackBufferAndSwapBuffers();
			planePosition = base.#bNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			base.HandleMouseMove(args, screenPosition, planePosition);
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x000F2D14 File Offset: 0x000F0F14
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false))
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			this.#0Ab(this.#c ?? planePosition);
			if (this.#c != null)
			{
				base.#9Mb(this.#c);
			}
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x000F2D84 File Offset: 0x000F0F84
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args))
			{
				return;
			}
			if (base.Editor.IsMouseWithinVisualObjects() || !base.#WMb(true))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.Horizontal)
			{
				planePosition.Y = ColumnModelHelper.#OW(planePosition.Y);
			}
			else
			{
				planePosition.X = ColumnModelHelper.#OW(planePosition.X);
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002F09 RID: 12041 RVA: 0x0002A11C File Offset: 0x0002831C
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			base.#vf();
		}

		// Token: 0x06002F0A RID: 12042 RVA: 0x000F2E1C File Offset: 0x000F101C
		public override bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			base.Services.MouseAndKeyboard.#M2c();
			#VAb #VAb = new #VAb(base.Project, base.UndoManager);
			Point3D #Akb;
			Point3D #Bkb;
			this.#1Ab(#Ng, out #Akb, out #Bkb);
			#9zb #9zb = #VAb.#UAb(base.EditorContext.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>(), base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>(), #Akb, #Bkb);
			if (#9zb != null && !#9zb.NothingToAlign)
			{
				if (#9zb.Success)
				{
					ColumnModelHelper.#VW(base.Project);
					base.EditorContext.SnappingCache.#uP(base.Project);
					base.EditorContext.Selection.#dPb();
					base.EditorContext.Selection.State.#cg();
					this.#a.#cg(base.EditorContext, false);
					base.Renderer.#9f(false, false);
				}
				else
				{
					base.Services.DialogService.#od(base.Services.WindowLocator.#6(), Strings.StringTheGeometryOperationResultIsNotValid.#z2d(), Strings.StringError, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
				}
			}
			this.#1kb();
			return base.#fzb(#Ng, #gzb);
		}

		// Token: 0x06002F0B RID: 12043 RVA: 0x0002A154 File Offset: 0x00028354
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = base.#hzb(#Lg);
			return #Lg.Handled;
		}

		// Token: 0x06002F0C RID: 12044 RVA: 0x0002A175 File Offset: 0x00028375
		private void #YAb()
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#vf();
		}

		// Token: 0x06002F0D RID: 12045 RVA: 0x000F2F74 File Offset: 0x000F1174
		private void #ZAb()
		{
			base.Editor.DynamicInput.Config.XValue.Enabled = !this.Horizontal;
			base.Editor.DynamicInput.Config.YValue.Enabled = this.Horizontal;
		}

		// Token: 0x06002F0E RID: 12046 RVA: 0x000F2FD0 File Offset: 0x000F11D0
		private void #0Ab(Point3D #Trb)
		{
			Point3D point;
			Point3D point2;
			this.#1Ab(#Trb, out point, out point2);
			base.RenderContext.SetColorWireframe(#KT.#L, false);
			base.RenderContext.SetLineSizeExt(#KT.#M);
			base.RenderContext.DrawLine(base.Editor.WorldToScreen(point), base.Editor.WorldToScreen(point2));
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x000F3038 File Offset: 0x000F1238
		private void #1Ab(Point3D #Trb, out Point3D #Akb, out Point3D #Bkb)
		{
			Point3D lowerLeftWorldCoord = base.Editor.LowerLeftWorldCoord;
			Point3D upperRightWorldCoord = base.Editor.UpperRightWorldCoord;
			#Akb = (this.Horizontal ? new Point3D(lowerLeftWorldCoord.X, #Trb.Y) : new Point3D(#Trb.X, lowerLeftWorldCoord.Y));
			#Bkb = (this.Horizontal ? new Point3D(upperRightWorldCoord.X, #Trb.Y) : new Point3D(#Trb.X, upperRightWorldCoord.Y));
		}

		// Token: 0x040012DE RID: 4830
		private readonly #UFb #a;

		// Token: 0x040012DF RID: 4831
		private bool #b;

		// Token: 0x040012E0 RID: 4832
		private Point3D #c;

		// Token: 0x040012E1 RID: 4833
		[CompilerGenerated]
		private bool #d;
	}
}

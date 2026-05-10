using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using #cMb;
using #hR;
using #LFb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.Products.Column.Services.API;

namespace #lzb
{
	// Token: 0x020004D4 RID: 1236
	internal sealed class #kzb : #bMb, #uNb, #KFb
	{
		// Token: 0x06002D57 RID: 11607 RVA: 0x00028985 File Offset: 0x00026B85
		public #kzb(IExtendedServices #0c) : base(#0c)
		{
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x000EE04C File Offset: 0x000EC24C
		public override void #1kb()
		{
			base.#1kb();
			this.#c = #kzb.#s6b.#a;
			this.#a = null;
			this.#b = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x06002D59 RID: 11609 RVA: 0x000EE0A8 File Offset: 0x000EC2A8
		public override void OnActivated()
		{
			base.OnActivated();
			this.#c = #kzb.#s6b.#a;
			this.#a = null;
			this.#b = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = false;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
		}

		// Token: 0x06002D5A RID: 11610 RVA: 0x000EE10C File Offset: 0x000EC30C
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#c = #kzb.#s6b.#a;
			this.#a = null;
			this.#b = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = true;
			this.#d = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x06002D5B RID: 11611 RVA: 0x0002898E File Offset: 0x00026B8E
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#d = (args.Key == Key.Escape && this.#c == #kzb.#s6b.#a);
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x000289C2 File Offset: 0x00026BC2
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#d)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06002D5D RID: 11613 RVA: 0x000EE178 File Offset: 0x000EC378
		public override bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			base.#fzb(#Ng, #gzb);
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#c == #kzb.#s6b.#a)
			{
				this.#a = #Ng;
				this.#b = null;
				this.#c = #kzb.#s6b.#b;
				base.#KMb(Strings.StringSpecifyEndPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			if (this.#c == #kzb.#s6b.#b)
			{
				this.#b = #Ng;
				this.#c = #kzb.#s6b.#a;
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return true;
		}

		// Token: 0x06002D5E RID: 11614 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002D5F RID: 11615 RVA: 0x00028A21 File Offset: 0x00026C21
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.#vf();
		}

		// Token: 0x06002D60 RID: 11616 RVA: 0x00028A4D File Offset: 0x00026C4D
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002D61 RID: 11617 RVA: 0x000EE230 File Offset: 0x000EC430
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#a != null)
			{
				this.#izb(planePosition);
				base.#vf();
			}
		}

		// Token: 0x06002D62 RID: 11618 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002D63 RID: 11619 RVA: 0x000EE2B4 File Offset: 0x000EC4B4
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#a != null)
			{
				this.#izb(planePosition);
			}
		}

		// Token: 0x06002D64 RID: 11620 RVA: 0x00028AB9 File Offset: 0x00026CB9
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#c == #kzb.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x06002D65 RID: 11621 RVA: 0x000EE340 File Offset: 0x000EC540
		private void #izb(Point3D #jzb)
		{
			if (this.#b == null)
			{
				base.#6Mb(this.#a, #jzb, base.Settings.ToolHelperColor);
			}
			else
			{
				base.#6Mb(this.#a, this.#b, base.Settings.ToolIdleColor);
			}
			Point3D point3D = this.#a;
			Point3D point3D2 = this.#b ?? #jzb;
			double value = GeometryHelper.#7mc(point3D.X, point3D.Y, point3D2.X, point3D2.Y);
			Point3D point3D3 = base.Editor.WorldToScreen(point3D2.X, point3D2.Y, 0.0);
			point3D3.X += 8.0;
			point3D3.Y += 8.0;
			int precision = base.Services.Settings.DynamicInput.Precision;
			FloatingPointUnitValueFormatter floatingPointUnitValueFormatter = new FloatingPointUnitValueFormatter(precision);
			base.DrawingHelper.DrawTextInBorder(point3D3, floatingPointUnitValueFormatter.CreateDisplayValue(value), ContentAlignment.BottomLeft, new Thickness(4.0, 2.0, 3.0, 2.0), #KT.#W, Color.Black, Color.Black, base.Editor.DynamicInput.PromptFont.Font, null, null);
		}

		// Token: 0x0400124B RID: 4683
		private Point3D #a;

		// Token: 0x0400124C RID: 4684
		private Point3D #b;

		// Token: 0x0400124D RID: 4685
		private #kzb.#s6b #c;

		// Token: 0x0400124E RID: 4686
		private bool #d;

		// Token: 0x020004D5 RID: 1237
		private enum #s6b
		{
			// Token: 0x04001250 RID: 4688
			#a,
			// Token: 0x04001251 RID: 4689
			#b
		}
	}
}

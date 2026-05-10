using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;
using #cMb;
using #RJb;
using #tFb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x02000590 RID: 1424
	internal sealed class #vEb : #bMb, #uNb, #FFb
	{
		// Token: 0x0600322A RID: 12842 RVA: 0x0002C6CD File Offset: 0x0002A8CD
		public #vEb(IExtendedServices #0c, #EFb #Pc, #nFb #9Db) : base(#0c)
		{
			this.#a = #Pc;
			this.#b = #9Db;
		}

		// Token: 0x17000FF2 RID: 4082
		// (get) Token: 0x0600322B RID: 12843 RVA: 0x0002C6E4 File Offset: 0x0002A8E4
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x0600322C RID: 12844 RVA: 0x0002C6F9 File Offset: 0x0002A8F9
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			base.HandleDynamicInputCoordinateSnapRequested(args);
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
		}

		// Token: 0x0600322D RID: 12845 RVA: 0x0002C725 File Offset: 0x0002A925
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#uEb();
			base.#vf();
		}

		// Token: 0x0600322E RID: 12846 RVA: 0x000FF37C File Offset: 0x000FD57C
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			Point3D point3D = this.#d ?? base.#bNb(#LLb.#n, planePosition);
			if (this.#c != null && point3D != null)
			{
				this.#sEb(point3D, this.#c.Value);
			}
		}

		// Token: 0x0600322F RID: 12847 RVA: 0x000FF3F0 File Offset: 0x000FD5F0
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			Point3D point3D = this.#d ?? planePosition;
			double? num = this.#c;
			double? num2 = num;
			double num3 = 0.0;
			if ((num2.GetValueOrDefault() > num3 & num2 != null) && point3D != null)
			{
				base.#iNb(point3D, CircleHelper.#wmc(num.Value));
				planePosition = base.#cNb(#LLb.#n, planePosition);
				base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			}
			if (this.#d != null)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x06003230 RID: 12848 RVA: 0x000FF4E4 File Offset: 0x000FD6E4
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#uEb();
			if (this.#c != null)
			{
				this.#sEb(args.Point, this.#c.Value);
				args.Handled = true;
			}
		}

		// Token: 0x06003231 RID: 12849 RVA: 0x0002C748 File Offset: 0x0002A948
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			this.#d = args.Point;
			base.#vf();
		}

		// Token: 0x06003232 RID: 12850 RVA: 0x000FF538 File Offset: 0x000FD738
		public override void OnActivated()
		{
			this.#a.#5b();
			this.#a.PropertyChanged += this.#ZDb;
			this.#c = null;
			base.Renderer.#eg();
			base.OnActivated();
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.#KMb(Strings.StringSpecifyInsertionPoint, true, false, true);
		}

		// Token: 0x06003233 RID: 12851 RVA: 0x000FF5B0 File Offset: 0x000FD7B0
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#a.PropertyChanged -= this.#ZDb;
			base.#JMb();
			this.#e = false;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
		}

		// Token: 0x06003234 RID: 12852 RVA: 0x0002C76F File Offset: 0x0002A96F
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			this.#e = (args.Key == Key.Escape);
		}

		// Token: 0x06003235 RID: 12853 RVA: 0x0002C794 File Offset: 0x0002A994
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#e)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x0002C7CB File Offset: 0x0002A9CB
		private void #ZDb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (base.IsActive)
			{
				this.#uEb();
				base.#vf();
			}
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x000FF604 File Offset: 0x000FD804
		private void #sEb(Point3D #tEb, double #wCb)
		{
			this.#b.#sEb(#tEb, #wCb);
			base.EditorContext.SnappingCache.#uP(base.Project);
			base.Services.SnappingCache.#uP(base.Project);
			this.#d = null;
			base.Renderer.#9f(false, false);
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x0002C7ED File Offset: 0x0002A9ED
		private void #uEb()
		{
			this.#c = this.#a.#3Eb();
		}

		// Token: 0x04001464 RID: 5220
		private readonly #EFb #a;

		// Token: 0x04001465 RID: 5221
		private readonly #nFb #b;

		// Token: 0x04001466 RID: 5222
		private double? #c;

		// Token: 0x04001467 RID: 5223
		private Point3D #d;

		// Token: 0x04001468 RID: 5224
		private bool #e;
	}
}

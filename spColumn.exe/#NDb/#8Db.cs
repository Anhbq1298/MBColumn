using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #ede;
using #RJb;
using #ryb;
using #tFb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x0200057C RID: 1404
	internal sealed class #8Db : #bMb, #uNb, #wFb
	{
		// Token: 0x060031C4 RID: 12740 RVA: 0x0002C14A File Offset: 0x0002A34A
		public #8Db(IExtendedServices #0c, #vFb #Pc, #nFb #9Db) : base(#0c)
		{
			this.#a = #Pc;
			this.#b = #9Db;
		}

		// Token: 0x17000FE4 RID: 4068
		// (get) Token: 0x060031C5 RID: 12741 RVA: 0x0002C16C File Offset: 0x0002A36C
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x17000FE5 RID: 4069
		// (get) Token: 0x060031C6 RID: 12742 RVA: 0x0002C181 File Offset: 0x0002A381
		// (set) Token: 0x060031C7 RID: 12743 RVA: 0x0002C18D File Offset: 0x0002A38D
		public #cOb Wrapper { get; set; }

		// Token: 0x17000FE6 RID: 4070
		// (get) Token: 0x060031C8 RID: 12744 RVA: 0x0002C19E File Offset: 0x0002A39E
		// (set) Token: 0x060031C9 RID: 12745 RVA: 0x0002C1AA File Offset: 0x0002A3AA
		public #qyb Toolbar { get; set; }

		// Token: 0x060031CA RID: 12746 RVA: 0x000FD93C File Offset: 0x000FBB3C
		public override void #1kb()
		{
			base.#1kb();
			this.#e = #8Db.#s6b.#a;
			this.#d = null;
			this.#c = null;
			this.#j = null;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x060031CB RID: 12747 RVA: 0x000FD98C File Offset: 0x000FBB8C
		public override void OnActivated()
		{
			base.OnActivated();
			this.#a.#5b();
			this.#a.PropertyChanged += this.#ZDb;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
		}

		// Token: 0x060031CC RID: 12748 RVA: 0x000FD9DC File Offset: 0x000FBBDC
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#a.PropertyChanged -= this.#ZDb;
			this.#e = #8Db.#s6b.#a;
			this.#c = null;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#JMb();
			this.#f = false;
			base.#vf();
		}

		// Token: 0x060031CD RID: 12749 RVA: 0x0002C1BB File Offset: 0x0002A3BB
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#f = (args.Key == Key.Escape && this.#e == #8Db.#s6b.#a);
		}

		// Token: 0x060031CE RID: 12750 RVA: 0x0002C1EF File Offset: 0x0002A3EF
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#f)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x060031CF RID: 12751 RVA: 0x000FDA4C File Offset: 0x000FBC4C
		public override bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#e == #8Db.#s6b.#a)
			{
				this.#c = #Ng;
				this.#e = #8Db.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#UMb(Strings.StringSpecifyRadius, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#Azb(#Ng);
		}

		// Token: 0x060031D0 RID: 12752 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x000FDAB8 File Offset: 0x000FBCB8
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#d = args.Point;
			this.#7Db(this.#d);
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x060031D2 RID: 12754 RVA: 0x000FDB10 File Offset: 0x000FBD10
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (this.#e == #8Db.#s6b.#b && args.FinalPoint != null)
			{
				Point3D left = this.#c + args.FinalPoint;
				if (left != this.#c)
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x000FDB74 File Offset: 0x000FBD74
		public override void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == #8Db.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x060031D4 RID: 12756 RVA: 0x000FDBD4 File Offset: 0x000FBDD4
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#e == #8Db.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#Azb(planePosition);
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x000FDC34 File Offset: 0x000FBE34
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#7Db(planePosition);
			this.#Bzb();
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x000FDC94 File Offset: 0x000FBE94
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#e == #8Db.#s6b.#b && this.#i != null)
			{
				double radius = this.#c.DistanceTo(this.#d ?? planePosition);
				Point3D[] #AHb = EyeshotHelper.ConstructRegularPolygon(this.#c, radius, 40, 0.0, true).ToArray();
				#8Ib.#ZIb(#AHb, base.EditorContext);
				ColumnShapesHelper.#HHb(this.#g, this.#i.GetValueOrDefault(), base.EditorContext, #qHb.#a);
				base.#5Mb(this.#c, this.#d ?? planePosition);
			}
			if (this.#d != null && this.#e == #8Db.#s6b.#a)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x0002C226 File Offset: 0x0002A426
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#e == #8Db.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x0002C24A File Offset: 0x0002A44A
		private void #ZDb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (base.IsActive && this.#j != null)
			{
				this.#7Db(this.#j);
				base.#vf();
			}
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x000FDDC4 File Offset: 0x000FBFC4
		private void #7Db(Point3D #Ng)
		{
			this.#g.Clear();
			this.#h = this.#a.#3Eb();
			if (this.#h == null || !(this.#c != null) || !(#Ng != null))
			{
				return;
			}
			this.#j = #Ng;
			this.#i = new double?(CircleHelper.#wmc(this.#h.Value));
			double #HS = this.#c.DistanceTo(#Ng);
			double num = GeometryHelper.#knc(this.#c.X, this.#c.Y, #Ng.X, #Ng.Y);
			num = GeometryHelper.#Qmc(num);
			BarPlacementType barPlacementType = this.#a.BarPlacementType;
			if (barPlacementType == BarPlacementType.Numbers)
			{
				this.#g.AddRange(ReinforcementPatternHelper.#LLe(this.#c, #HS, num, this.#a.NumberOfBarsX).Take(#dde.Instance.BarsAtOnce));
				return;
			}
			if (barPlacementType != BarPlacementType.Spacing)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.#g.AddRange(ReinforcementPatternHelper.#KLe(this.#c, #HS, num, this.#a.BarSpacingX).Take(#dde.Instance.BarsAtOnce));
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x0002C280 File Offset: 0x0002A480
		private void #fAb()
		{
			this.#e = #8Db.#s6b.#a;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x000FDF18 File Offset: 0x000FC118
		private bool #Azb(Point3D #Ng)
		{
			double? num = this.#a.#3Eb();
			if (!this.#g.Any<Point3D>() || num == null)
			{
				return false;
			}
			if (this.#e == #8Db.#s6b.#b)
			{
				if (this.#b.#0Db(this.#g, num.Value))
				{
					this.#fAb();
					ColumnModelHelper.#VW(base.Project);
					base.EditorContext.SnappingCache.#uP(base.Project);
					base.Renderer.#9f(false, false);
					return true;
				}
				this.#fAb();
			}
			return false;
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x0002C2A3 File Offset: 0x0002A4A3
		private bool #Dzb(Point3D #Ng)
		{
			return base.#4Mb(this.#c, #Ng, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x04001438 RID: 5176
		private readonly #vFb #a;

		// Token: 0x04001439 RID: 5177
		private readonly #nFb #b;

		// Token: 0x0400143A RID: 5178
		private Point3D #c;

		// Token: 0x0400143B RID: 5179
		private Point3D #d;

		// Token: 0x0400143C RID: 5180
		private #8Db.#s6b #e;

		// Token: 0x0400143D RID: 5181
		private bool #f;

		// Token: 0x0400143E RID: 5182
		private readonly List<Point3D> #g = new List<Point3D>();

		// Token: 0x0400143F RID: 5183
		private double? #h;

		// Token: 0x04001440 RID: 5184
		private double? #i;

		// Token: 0x04001441 RID: 5185
		private Point3D #j;

		// Token: 0x04001442 RID: 5186
		[CompilerGenerated]
		private #cOb #k;

		// Token: 0x04001443 RID: 5187
		[CompilerGenerated]
		private #qyb #l;

		// Token: 0x0200057D RID: 1405
		private enum #s6b
		{
			// Token: 0x04001445 RID: 5189
			#a,
			// Token: 0x04001446 RID: 5190
			#b
		}
	}
}

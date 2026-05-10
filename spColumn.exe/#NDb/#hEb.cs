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
	// Token: 0x0200057F RID: 1407
	internal class #hEb : #bMb, #uNb, #xFb
	{
		// Token: 0x060031DF RID: 12767 RVA: 0x0002C2CE File Offset: 0x0002A4CE
		public #hEb(IExtendedServices #0c, #zFb #Pc, #nFb #9Db) : base(#0c)
		{
			this.#g = #Pc;
			this.#a = #9Db;
		}

		// Token: 0x17000FE7 RID: 4071
		// (get) Token: 0x060031E0 RID: 12768 RVA: 0x0002C2F0 File Offset: 0x0002A4F0
		// (set) Token: 0x060031E1 RID: 12769 RVA: 0x0002C2FC File Offset: 0x0002A4FC
		public Point3D StartPoint { get; private set; }

		// Token: 0x17000FE8 RID: 4072
		// (get) Token: 0x060031E2 RID: 12770 RVA: 0x0002C30D File Offset: 0x0002A50D
		// (set) Token: 0x060031E3 RID: 12771 RVA: 0x0002C319 File Offset: 0x0002A519
		public Point3D InsertionPoint { get; private set; }

		// Token: 0x17000FE9 RID: 4073
		// (get) Token: 0x060031E4 RID: 12772 RVA: 0x0002C32A File Offset: 0x0002A52A
		// (set) Token: 0x060031E5 RID: 12773 RVA: 0x0002C336 File Offset: 0x0002A536
		protected double? Radius { get; set; }

		// Token: 0x17000FEA RID: 4074
		// (get) Token: 0x060031E6 RID: 12774 RVA: 0x0002C347 File Offset: 0x0002A547
		protected #zFb Parameters { get; }

		// Token: 0x17000FEB RID: 4075
		// (get) Token: 0x060031E7 RID: 12775 RVA: 0x0002C353 File Offset: 0x0002A553
		protected List<Point3D> BarPositions { get; }

		// Token: 0x17000FEC RID: 4076
		// (get) Token: 0x060031E8 RID: 12776 RVA: 0x0002C35F File Offset: 0x0002A55F
		public override IView ParametersView
		{
			get
			{
				return this.Parameters.View;
			}
		}

		// Token: 0x17000FED RID: 4077
		// (get) Token: 0x060031E9 RID: 12777 RVA: 0x0002C378 File Offset: 0x0002A578
		// (set) Token: 0x060031EA RID: 12778 RVA: 0x0002C384 File Offset: 0x0002A584
		protected Point3D LastPoint { get; set; }

		// Token: 0x060031EB RID: 12779 RVA: 0x0002C395 File Offset: 0x0002A595
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			base.HandleDynamicInputCoordinateSnapRequested(args);
			args.SnappedPoint = this.#fEb(args.InputPoint);
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x0002C3BC File Offset: 0x0002A5BC
		public override void #1kb()
		{
			base.#1kb();
			this.#fAb();
		}

		// Token: 0x060031ED RID: 12781 RVA: 0x000FDFC8 File Offset: 0x000FC1C8
		public override void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (planePosition == null || this.#hzb(args) || !base.#WMb(false) || base.Editor.IsCameraSetSideways() || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = this.#fEb(planePosition);
			this.#fzb(planePosition, false);
		}

		// Token: 0x060031EE RID: 12782 RVA: 0x000FE030 File Offset: 0x000FC230
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.InsertionPoint = null;
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = this.#fEb(planePosition);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (this.#b == #hEb.#s6b.#b && base.#Dzb(this.StartPoint, planePosition, base.EditorContext.Snapping.#NLb()))
			{
				this.#7Db(planePosition);
			}
			base.#vf();
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x000FE0DC File Offset: 0x000FC2DC
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = (this.#Fzb() ? this.#Ezb(base.#cNb(#LLb.#n, planePosition)) : base.#cNb(#LLb.#n, planePosition));
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			Point3D point3D = this.InsertionPoint ?? planePosition;
			if (this.#b == #hEb.#s6b.#b && point3D != null && base.#Dzb(this.StartPoint, point3D, base.EditorContext.Snapping.#NLb()))
			{
				Point3D #Ng = base.Editor.WorldToScreen(this.StartPoint);
				Point3D #Ng2 = base.Editor.WorldToScreen(point3D);
				#8Ib.#2Ib(#Ng.#RW(), #Ng2.#RW(), base.Editor, base.Services.Renderer, ushort.MaxValue, false, new Color?(base.Settings.ToolHelperColor));
				base.#5Mb(this.StartPoint, point3D);
			}
			if (this.#b == #hEb.#s6b.#b)
			{
				ColumnShapesHelper.#HHb(this.BarPositions, this.Radius.GetValueOrDefault(), base.EditorContext, #qHb.#a);
			}
			if (this.#b == #hEb.#s6b.#a)
			{
				double? num = this.Parameters.#3Eb();
				double? num2 = num;
				double num3 = 0.0;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					base.#iNb(planePosition, CircleHelper.#wmc(num.Value));
				}
			}
			if (this.InsertionPoint != null)
			{
				base.#9Mb(this.InsertionPoint);
			}
			if (this.#Fzb())
			{
				this.#Ezb(base.#cNb(#LLb.#n, planePosition));
				return;
			}
			base.#cNb(#LLb.#n, planePosition);
		}

		// Token: 0x060031F0 RID: 12784 RVA: 0x000FE2D4 File Offset: 0x000FC4D4
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (planePosition == null || this.#hzb(args) || !base.#WMb(false) || base.Editor.IsCameraSetSideways() || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			if (this.#b == #hEb.#s6b.#b && base.#Dzb(this.StartPoint, planePosition, base.EditorContext.Snapping.#NLb()))
			{
				planePosition = this.#fEb(planePosition);
				this.#fzb(planePosition, false);
			}
		}

		// Token: 0x060031F1 RID: 12785 RVA: 0x000FE370 File Offset: 0x000FC570
		public override bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			if (this.#b == #hEb.#s6b.#a)
			{
				this.StartPoint = #Ng;
				this.#b = #hEb.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#KMb(Strings.StringSpecifyEndPoint, true, false, true);
				this.#7Db(#Ng);
				base.#vf();
				return true;
			}
			if (this.#b == #hEb.#s6b.#b)
			{
				this.#7Db(#Ng);
				base.#fzb(#Ng, #gzb);
				return this.#gEb();
			}
			return base.#fzb(#Ng, #gzb);
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x000FE3F0 File Offset: 0x000FC5F0
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			this.InsertionPoint = args.Point;
			if (this.#b == #hEb.#s6b.#a)
			{
				this.StartPoint = args.Point;
			}
			this.#7Db(args.Point);
			base.#vf();
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x0002C3D6 File Offset: 0x0002A5D6
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.InsertionPoint = args.Point;
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x000FE454 File Offset: 0x000FC654
		public override void OnActivated()
		{
			this.Parameters.#5b();
			this.Parameters.PropertyChanged += this.#ZDb;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.ForceOrthoDisabled = true;
			base.OnActivated();
		}

		// Token: 0x060031F5 RID: 12789 RVA: 0x000FE4BC File Offset: 0x000FC6BC
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.Parameters.PropertyChanged -= this.#ZDb;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#c = false;
			base.ForceOrthoDisabled = false;
			this.#fAb();
			base.#JMb();
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x0002C40A File Offset: 0x0002A60A
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#c = (args.Key == Key.Escape && this.#b == #hEb.#s6b.#a);
		}

		// Token: 0x060031F7 RID: 12791 RVA: 0x0002C43E File Offset: 0x0002A63E
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#c)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x060031F8 RID: 12792 RVA: 0x0002C475 File Offset: 0x0002A675
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#b == #hEb.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x060031F9 RID: 12793 RVA: 0x000FE520 File Offset: 0x000FC720
		protected virtual void #7Db(Point3D #Ng)
		{
			this.BarPositions.Clear();
			this.LastPoint = #Ng;
			double? num = this.Parameters.#3Eb();
			if (num != null)
			{
				this.Radius = new double?(CircleHelper.#wmc(num.Value));
			}
			if (num == null || !(this.StartPoint != null) || !(#Ng != null) || !base.#Dzb(this.StartPoint, #Ng))
			{
				if (num != null && #Ng != null)
				{
					this.BarPositions.Add(#Ng);
				}
				return;
			}
			BarPlacementType barPlacementType = this.Parameters.BarPlacementType;
			if (barPlacementType == BarPlacementType.Numbers)
			{
				this.BarPositions.AddRange(ReinforcementPatternHelper.#JLe(this.StartPoint, #Ng, this.Parameters.NumberOfBarsX, this.Parameters.NumberOfBarsY, true).Take(#dde.Instance.BarsAtOnce));
				return;
			}
			if (barPlacementType != BarPlacementType.Spacing)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.BarPositions.AddRange(ReinforcementPatternHelper.#ILe(this.StartPoint, #Ng, this.Parameters.BarSpacingX, this.Parameters.BarSpacingY, true).Take(#dde.Instance.BarsAtOnce));
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x0002C499 File Offset: 0x0002A699
		private void #ZDb(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#7Db(this.LastPoint);
			base.#vf();
		}

		// Token: 0x060031FB RID: 12795 RVA: 0x00028DC3 File Offset: 0x00026FC3
		private bool #Fzb()
		{
			return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
		}

		// Token: 0x060031FC RID: 12796 RVA: 0x000FE67C File Offset: 0x000FC87C
		private Point3D #Ezb(Point3D #jzb)
		{
			Point3D point3D = this.StartPoint;
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

		// Token: 0x060031FD RID: 12797 RVA: 0x000FE750 File Offset: 0x000FC950
		private Point3D #fEb(Point3D #Ng)
		{
			if (!this.#Fzb() || !(this.StartPoint != null))
			{
				return base.#bNb(#LLb.#n, #Ng);
			}
			return base.#bNb(#LLb.#n, this.#Ezb(#Ng));
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x000FE7A0 File Offset: 0x000FC9A0
		private bool #gEb()
		{
			double? num = this.Parameters.#3Eb();
			if (!this.BarPositions.Any<Point3D>() || num == null)
			{
				return false;
			}
			if (this.#a.#0Db(this.BarPositions, num.Value))
			{
				ColumnModelHelper.#VW(base.Project);
				base.Services.SnappingCache.#uP(base.Project);
				base.Services.Renderer.#9f(false, false);
				this.#fAb();
				return true;
			}
			this.#fAb();
			return false;
		}

		// Token: 0x060031FF RID: 12799 RVA: 0x000FE84C File Offset: 0x000FCA4C
		private void #fAb()
		{
			this.LastPoint = null;
			this.StartPoint = null;
			this.InsertionPoint = null;
			this.#b = #hEb.#s6b.#a;
			this.BarPositions.Clear();
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x04001447 RID: 5191
		private readonly #nFb #a;

		// Token: 0x04001448 RID: 5192
		private #hEb.#s6b #b;

		// Token: 0x04001449 RID: 5193
		private bool #c;

		// Token: 0x0400144A RID: 5194
		[CompilerGenerated]
		private Point3D #d;

		// Token: 0x0400144B RID: 5195
		[CompilerGenerated]
		private Point3D #e;

		// Token: 0x0400144C RID: 5196
		[CompilerGenerated]
		private double? #f;

		// Token: 0x0400144D RID: 5197
		[CompilerGenerated]
		private readonly #zFb #g;

		// Token: 0x0400144E RID: 5198
		[CompilerGenerated]
		private readonly List<Point3D> #h = new List<Point3D>();

		// Token: 0x0400144F RID: 5199
		[CompilerGenerated]
		private Point3D #i;

		// Token: 0x02000580 RID: 1408
		private enum #s6b
		{
			// Token: 0x04001451 RID: 5201
			#a,
			// Token: 0x04001452 RID: 5202
			#b
		}
	}
}

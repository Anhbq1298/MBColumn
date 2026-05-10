using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using #aHb;
using #cMb;
using #LFb;
using #RJb;
using #tFb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x02000588 RID: 1416
	internal sealed class #oEb : #bMb, #uNb, #CFb
	{
		// Token: 0x0600320A RID: 12810 RVA: 0x0002C505 File Offset: 0x0002A705
		public #oEb(IExtendedServices #0c, #BFb #Pc, #1Fb #pEb, #nFb #9Db) : base(#0c)
		{
			this.#a = #Pc;
			this.#f = #pEb;
			this.#g = #9Db;
		}

		// Token: 0x17000FF0 RID: 4080
		// (get) Token: 0x0600320B RID: 12811 RVA: 0x0002C53A File Offset: 0x0002A73A
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x000FE908 File Offset: 0x000FCB08
		public override void OnActivated()
		{
			base.OnActivated();
			this.#a.#5b();
			this.#a.PropertyChanged += this.#ZDb;
			this.#a.IncludeEndBarsVisibility = Visibility.Visible;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x000FE964 File Offset: 0x000FCB64
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#a.PropertyChanged -= this.#ZDb;
			this.#d = #oEb.#s6b.#a;
			this.#b.Clear();
			this.#lEb();
			this.#c = null;
			this.#e = false;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x000FE9E0 File Offset: 0x000FCBE0
		public override void #1kb()
		{
			base.#1kb();
			this.#d = #oEb.#s6b.#a;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#c = null;
			this.#b.Clear();
			this.#h.Clear();
			this.#lEb();
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x0600320F RID: 12815 RVA: 0x000FEA50 File Offset: 0x000FCC50
		public override bool #fzb(Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			this.#b.Add(#Ng);
			this.#lEb();
			this.#d = #oEb.#s6b.#b;
			base.#KMb(Strings.StringSpecifyNextPoint, true, false, true);
			base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
			base.#fzb(#Ng, #gzb);
			return true;
		}

		// Token: 0x06003210 RID: 12816 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06003211 RID: 12817 RVA: 0x000FEAB8 File Offset: 0x000FCCB8
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#c = args.Point;
			this.#7Db(this.#c);
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06003212 RID: 12818 RVA: 0x000FEB10 File Offset: 0x000FCD10
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#d == #oEb.#s6b.#b && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
			this.#7Db(planePosition);
		}

		// Token: 0x06003213 RID: 12819 RVA: 0x0002C54F File Offset: 0x0002A74F
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Right)
			{
				return;
			}
			this.#kEb();
		}

		// Token: 0x06003214 RID: 12820 RVA: 0x000FEB78 File Offset: 0x000FCD78
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#c = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#7Db(planePosition);
			this.#Bzb();
		}

		// Token: 0x06003215 RID: 12821 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06003216 RID: 12822 RVA: 0x000FEBD8 File Offset: 0x000FCDD8
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			double? num = this.#j;
			if (this.#d == #oEb.#s6b.#b && num != null)
			{
				Point3D #3r = this.#b.Last<Point3D>();
				Point3D #4r = this.#c ?? planePosition;
				base.#5Mb(#3r, #4r);
				ColumnShapesHelper.#HHb(this.#h, num.Value, base.EditorContext, #qHb.#a);
			}
			if (this.#d == #oEb.#s6b.#a && num != null)
			{
				base.#iNb(planePosition, num.Value);
			}
			if (this.#c != null && this.#d == #oEb.#s6b.#a)
			{
				base.#9Mb(this.#c);
			}
			base.#cNb(#LLb.#n, planePosition);
		}

		// Token: 0x06003217 RID: 12823 RVA: 0x0002C57F File Offset: 0x0002A77F
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#e = (args.Key == Key.Escape && this.#d == #oEb.#s6b.#a);
		}

		// Token: 0x06003218 RID: 12824 RVA: 0x000FECF8 File Offset: 0x000FCEF8
		public override void HandleKeyUp(KeyEventArgs args)
		{
			if (args.Key == Key.Escape)
			{
				this.#kEb();
			}
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#e)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x06003219 RID: 12825 RVA: 0x0002C5B3 File Offset: 0x0002A7B3
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#d == #oEb.#s6b.#b);
			if (#Lg.ChangedButton == System.Windows.Input.MouseButton.Right && this.#b.Count <= 1)
			{
				this.#1kb();
				return true;
			}
			return false;
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x000FED4C File Offset: 0x000FCF4C
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (base.Editor.DynamicInput.Config.Mode == DynamicInputMode.RelativeRectangle)
			{
				if (args.CoordinateType == DynamicInputCoordinateType.CoordinateX)
				{
					double num = -1E-07;
					double? num2 = args.CoordinateX;
					if (num < num2.GetValueOrDefault() & num2 != null)
					{
						num2 = args.CoordinateX;
						double num3 = 1E-07;
						if (num2.GetValueOrDefault() < num3 & num2 != null)
						{
							args.ErrorMessage = Strings.StringDimensionIsTooSmall;
						}
					}
				}
				if (args.CoordinateType == DynamicInputCoordinateType.CoordinateY)
				{
					double num4 = -1E-07;
					double? num2 = args.CoordinateY;
					if (num4 < num2.GetValueOrDefault() & num2 != null)
					{
						num2 = args.CoordinateY;
						double num3 = 1E-07;
						if (num2.GetValueOrDefault() < num3 & num2 != null)
						{
							args.ErrorMessage = Strings.StringDimensionIsTooSmall;
						}
					}
				}
			}
		}

		// Token: 0x0600321B RID: 12827 RVA: 0x0002C5F0 File Offset: 0x0002A7F0
		private void #ZDb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (base.IsActive && this.#k != null)
			{
				this.#7Db(this.#k);
				base.#vf();
			}
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x0002C626 File Offset: 0x0002A826
		private void #kEb()
		{
			if (this.#d != #oEb.#s6b.#b || this.#b.Count < 2)
			{
				return;
			}
			this.#mEb();
		}

		// Token: 0x0600321D RID: 12829 RVA: 0x000FEE50 File Offset: 0x000FD050
		private void #lEb()
		{
			base.Services.SnappingCache.TemporaryPoints.Clear();
			base.Services.SnappingCache.TemporaryPoints.AddRange(this.#b);
			base.Services.SnappingCache.TemporaryPoints.AddRange(this.#h);
			base.Services.SnappingCache.#tP();
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x000FEEC4 File Offset: 0x000FD0C4
		private void #7Db(Point3D #Ng)
		{
			this.#h.Clear();
			this.#i = this.#a.#3Eb();
			this.#j = null;
			if (this.#i != null && this.#i.Value > 0.0)
			{
				this.#j = new double?(CircleHelper.#wmc(this.#i.Value));
			}
			if (#Ng != null)
			{
				this.#k = #Ng;
			}
			if (this.#d == #oEb.#s6b.#b)
			{
				List<Point3D> list = this.#b.ToList<Point3D>();
				if (#Ng != null)
				{
					list.Add(#Ng);
				}
				if (list.Count == 1)
				{
					this.#h.Add(#Ng);
				}
				for (int i = 1; i < list.Count; i++)
				{
					Point3D #Akb = list[i - 1];
					Point3D #Bkb = list[i];
					List<Point3D> list2 = null;
					BarPlacementType barPlacementType = this.#a.BarPlacementType;
					if (barPlacementType != BarPlacementType.Numbers)
					{
						if (barPlacementType == BarPlacementType.Spacing)
						{
							list2 = ReinforcementPatternHelper.#NLe(#Akb, #Bkb, this.#a.BarSpacingX).Take(this.#f.Limits.BarsAtOnce).ToList<Point3D>();
						}
					}
					else
					{
						list2 = ReinforcementPatternHelper.#MLe(#Akb, #Bkb, this.#a.NumberOfBarsX).Take(this.#f.Limits.BarsAtOnce).ToList<Point3D>();
					}
					if (!this.#a.KeepEndBars && list2 != null)
					{
						list2.#h2d<Point3D>();
					}
					if (list2 != null)
					{
						this.#h.AddRange(list2);
					}
				}
			}
		}

		// Token: 0x0600321F RID: 12831 RVA: 0x000FF070 File Offset: 0x000FD270
		private bool #mEb()
		{
			double? num = this.#i;
			double? num2;
			if (6 != 0)
			{
				num2 = num;
			}
			if (this.#d != #oEb.#s6b.#b || num2 == null || this.#b.Count < 2)
			{
				return false;
			}
			this.#7Db(null);
			if (this.#g.#0Db(this.#h, num2.Value))
			{
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.Snapping.Cache.#uP(base.Project);
				base.Renderer.#9f(false, false);
				this.#d = #oEb.#s6b.#a;
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				this.#1kb();
				return true;
			}
			this.#1kb();
			return false;
		}

		// Token: 0x06003220 RID: 12832 RVA: 0x000FF140 File Offset: 0x000FD340
		private string #nEb()
		{
			if (this.#a.BarPlacementType != BarPlacementType.Numbers)
			{
				return base.Project.Model.Units.Section.BarXCoord.Unit.UnitValueFormatter.CreateDisplayValue(this.#a.BarSpacingX).#O2d() + base.Project.Model.Units.Section.BarXCoord.Unit.UnitSymbol.Symbol;
			}
			return this.#a.NumberOfBarsX.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06003221 RID: 12833 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x06003222 RID: 12834 RVA: 0x0002C653 File Offset: 0x0002A853
		private bool #Dzb(Point3D #Ng)
		{
			return this.#b.Any<Point3D>() && base.#Dzb(this.#b.Last<Point3D>(), #Ng, base.EditorContext.Snapping.#NLb());
		}

		// Token: 0x04001455 RID: 5205
		private readonly #BFb #a;

		// Token: 0x04001456 RID: 5206
		private readonly List<Point3D> #b = new List<Point3D>();

		// Token: 0x04001457 RID: 5207
		private Point3D #c;

		// Token: 0x04001458 RID: 5208
		private #oEb.#s6b #d;

		// Token: 0x04001459 RID: 5209
		private bool #e;

		// Token: 0x0400145A RID: 5210
		private readonly #1Fb #f;

		// Token: 0x0400145B RID: 5211
		private readonly #nFb #g;

		// Token: 0x0400145C RID: 5212
		private readonly List<Point3D> #h = new List<Point3D>();

		// Token: 0x0400145D RID: 5213
		private double? #i;

		// Token: 0x0400145E RID: 5214
		private double? #j;

		// Token: 0x0400145F RID: 5215
		private Point3D #k;

		// Token: 0x02000589 RID: 1417
		private enum #s6b
		{
			// Token: 0x04001461 RID: 5217
			#a,
			// Token: 0x04001462 RID: 5218
			#b
		}
	}
}

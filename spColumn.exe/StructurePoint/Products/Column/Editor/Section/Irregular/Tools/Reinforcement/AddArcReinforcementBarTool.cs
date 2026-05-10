using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using #aHb;
using #cMb;
using #ede;
using #NDb;
using #RJb;
using #tFb;
using #xKe;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x02000575 RID: 1397
	internal sealed class AddArcReinforcementBarTool : #bMb, #uNb, #sFb
	{
		// Token: 0x0600319D RID: 12701 RVA: 0x0002BFB2 File Offset: 0x0002A1B2
		public AddArcReinforcementBarTool(IExtendedServices services, #BFb parameters, #nFb insertBarsHandler) : base(services)
		{
			this.#a = parameters;
			this.#b = insertBarsHandler;
		}

		// Token: 0x17000FE2 RID: 4066
		// (get) Token: 0x0600319E RID: 12702 RVA: 0x0002BFC9 File Offset: 0x0002A1C9
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x000FCB10 File Offset: 0x000FAD10
		public override void OnActivated()
		{
			this.#a.#5b();
			base.OnActivated();
			this.#a.PropertyChanged += this.#ZDb;
			this.#a.IncludeEndBarsVisibility = Visibility.Visible;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = false;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x000FCB7C File Offset: 0x000FAD7C
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#a.PropertyChanged -= this.#ZDb;
			this.#f = AddArcReinforcementBarTool.#s6b.#a;
			this.#g = CircleDirection.None;
			this.#c = null;
			this.#d = null;
			this.#e = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.Editor.DynamicInput.StopFollowingInsertionPointOnCancel = true;
			this.#h = false;
			base.#JMb();
			base.#vf();
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x000FCC10 File Offset: 0x000FAE10
		public override void #1kb()
		{
			base.#1kb();
			this.#f = AddArcReinforcementBarTool.#s6b.#a;
			this.#g = CircleDirection.None;
			this.#e = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyCenterPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x0002BFDE File Offset: 0x0002A1DE
		public override void HandleKeyDown(KeyEventArgs args)
		{
			if (!false)
			{
				base.HandleKeyDown(args);
			}
			this.#h = (args.Key == Key.Escape && this.#f == AddArcReinforcementBarTool.#s6b.#a);
		}

		// Token: 0x060031A3 RID: 12707 RVA: 0x0002C012 File Offset: 0x0002A212
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#h)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x060031A4 RID: 12708 RVA: 0x000FCC6C File Offset: 0x000FAE6C
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true))
			{
				return false;
			}
			if (this.#f == AddArcReinforcementBarTool.#s6b.#a)
			{
				this.#c = #Ng;
				this.#f = AddArcReinforcementBarTool.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifyStartPoint, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			if (this.#f == AddArcReinforcementBarTool.#s6b.#b)
			{
				this.#d = #Ng;
				this.#f = AddArcReinforcementBarTool.#s6b.#c;
				base.#fzb(#Ng, #gzb);
				base.#PMb(Strings.StringSpecifyAngle, this.#c, true, false, true, new Func<double, double>(this.#Pzb));
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#0Db(#Ng);
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x000FCD3C File Offset: 0x000FAF3C
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			if (args.Mode == DynamicInputMode.Angle && args.Angle != null)
			{
				args.Handled = this.#Izb(args.Angle.Value);
				return;
			}
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x060031A6 RID: 12710 RVA: 0x000FCDA4 File Offset: 0x000FAFA4
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			if (base.Editor.DynamicInput.Config.Mode == DynamicInputMode.RelativeAngle)
			{
				if (args.Angle != null)
				{
					this.#Hzb(args.Angle.Value);
				}
			}
			else
			{
				this.#e = args.Point;
			}
			base.#vf();
		}

		// Token: 0x060031A7 RID: 12711 RVA: 0x000FCE28 File Offset: 0x000FB028
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			devDept.Geometry.Point3D right = (base.Editor.DynamicInput.Config.LastInputPoint ?? new devDept.Geometry.Point3D()) + (args.FinalPoint ?? new devDept.Geometry.Point3D());
			if (this.#f == AddArcReinforcementBarTool.#s6b.#b && this.#c == right)
			{
				args.ErrorMessage = Strings.StringInvalidGeometry;
				return;
			}
			if (this.#f == AddArcReinforcementBarTool.#s6b.#c && args.CoordinateX != null)
			{
				double value = args.CoordinateX.Value;
				if (value.Equals(0.0) || Math.Abs(value) >= 360.0)
				{
					args.ErrorMessage = Strings.StringInvalidGeometry;
				}
			}
		}

		// Token: 0x060031A8 RID: 12712 RVA: 0x000FCF08 File Offset: 0x000FB108
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if ((this.#f == AddArcReinforcementBarTool.#s6b.#b || this.#f == AddArcReinforcementBarTool.#s6b.#c) && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#fzb(planePosition, false);
		}

		// Token: 0x060031A9 RID: 12713 RVA: 0x000FCF70 File Offset: 0x000FB170
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			if (this.#f == AddArcReinforcementBarTool.#s6b.#c && !this.#Dzb(planePosition))
			{
				return;
			}
			this.#0Db(planePosition);
		}

		// Token: 0x060031AA RID: 12714 RVA: 0x000FCFD0 File Offset: 0x000FB1D0
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			this.#e = null;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
			if (this.#f != AddArcReinforcementBarTool.#s6b.#c || !this.#Dzb(planePosition) || this.#g != CircleDirection.None)
			{
				return;
			}
			this.#g = this.#Jzb(planePosition);
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x000FD05C File Offset: 0x000FB25C
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (planePosition == null || !base.#WMb(false) || base.Editor.IsCameraSetSideways())
			{
				return;
			}
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#f == AddArcReinforcementBarTool.#s6b.#b)
			{
				base.#5Mb(this.#c, this.#e ?? planePosition);
			}
			if (this.#f == AddArcReinforcementBarTool.#s6b.#c)
			{
				devDept.Geometry.Point3D point3D = this.#e ?? planePosition;
				float num = (float)Math.Abs(this.#c.DistanceTo(this.#d));
				ValueTuple<float, float> valueTuple = ReinforcementPatternHelper.#OLe(this.#c, this.#d, point3D);
				float item = valueTuple.Item1;
				float item2 = valueTuple.Item2;
				int fullCircleNumberOfPoints = #4ai.#3ai(base.Project.Model.Options.Unit, (double)num, 40);
				List<devDept.Geometry.Point3D> list = EyeshotHelper.ConstructArc(this.#c, num, item, item2, fullCircleNumberOfPoints, this.#g);
				#8Ib.#ZIb(list.ToArray(), base.EditorContext);
				List<ReinforcementBar> list2 = this.#1Db(this.#c, this.#d, point3D);
				if (!this.#a.KeepEndBars)
				{
					list2.#h2d<ReinforcementBar>();
				}
				ColumnShapesHelper.#HHb(list2, base.EditorContext, #qHb.#a, null);
				base.#5Mb(this.#c, point3D);
			}
			if (this.#f == AddArcReinforcementBarTool.#s6b.#b)
			{
				double? num2 = this.#a.#3Eb();
				double? num3 = num2;
				double num4 = 0.0;
				if (num3.GetValueOrDefault() > num4 & num3 != null)
				{
					base.#iNb(planePosition, CircleHelper.#wmc(num2.Value));
				}
			}
			if (this.#e != null && this.#f == AddArcReinforcementBarTool.#s6b.#a)
			{
				base.#9Mb(this.#e);
			}
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x0002C049 File Offset: 0x0002A249
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = (this.#f == AddArcReinforcementBarTool.#s6b.#c || this.#f == AddArcReinforcementBarTool.#s6b.#b);
			return base.#hzb(#Lg);
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x0002C079 File Offset: 0x0002A279
		private void #ZDb(object #Ge, PropertyChangedEventArgs #He)
		{
			if (base.IsActive)
			{
				base.#vf();
			}
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x000FD248 File Offset: 0x000FB448
		private bool #0Db(devDept.Geometry.Point3D #Ng)
		{
			double? num = this.#a.#3Eb();
			if (this.#f != AddArcReinforcementBarTool.#s6b.#c || this.#g == CircleDirection.None || num == null)
			{
				return false;
			}
			if (!ColumnShapesHelper.#OHb(this.#c, this.#d, #Ng))
			{
				return false;
			}
			List<ReinforcementBar> source = this.#1Db(this.#c, this.#d, #Ng);
			List<devDept.Geometry.Point3D> list = source.Select(new Func<ReinforcementBar, devDept.Geometry.Point3D>(AddArcReinforcementBarTool.<>c.<>9.#H9b)).ToList<devDept.Geometry.Point3D>();
			if (!this.#a.KeepEndBars)
			{
				list.#h2d<devDept.Geometry.Point3D>();
			}
			if (!list.Any<devDept.Geometry.Point3D>())
			{
				this.#fAb();
				return true;
			}
			if (this.#b.#0Db(list, num.Value))
			{
				this.#f = AddArcReinforcementBarTool.#s6b.#a;
				this.#g = CircleDirection.None;
				base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
				ColumnModelHelper.#VW(base.Project);
				base.EditorContext.SnappingCache.#uP(base.Project);
				base.Renderer.#9f(false, false);
				base.Editor.DynamicInput.SetInputValue(base.Editor.PlanePosition);
				return true;
			}
			this.#fAb();
			return false;
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x0002C095 File Offset: 0x0002A295
		private void #fAb()
		{
			this.#f = AddArcReinforcementBarTool.#s6b.#a;
			this.#g = CircleDirection.None;
			base.#KMb(Strings.StringSpecifyStartPoint, true, false, true);
			base.#vf();
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x000FD398 File Offset: 0x000FB598
		private void #Hzb(double #Udb)
		{
			this.#g = ((#Udb > 0.0) ? CircleDirection.Clockwise : CircleDirection.CounterClockwise);
			devDept.Geometry.Point3D point3D = this.#d - this.#c;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(this.#c.DistanceTo(this.#d));
			StructurePoint.CoreAssets.Infrastructure.Data.Point point = GeometryHelper.#4nc(this.#c.#QW(), #HS, (double)num - #Udb);
			this.#e = new devDept.Geometry.Point3D(point.X, point.Y);
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x000FD440 File Offset: 0x000FB640
		private bool #Izb(double #Udb)
		{
			if (!base.#WMb(true) || this.#f != AddArcReinforcementBarTool.#s6b.#c)
			{
				return false;
			}
			this.#g = ((#Udb > 0.0) ? CircleDirection.Clockwise : CircleDirection.CounterClockwise);
			devDept.Geometry.Point3D point3D = this.#d - this.#c;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(this.#c.DistanceTo(this.#d));
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = GeometryHelper.#4nc(this.#c.#QW(), #HS, (double)num - #Udb);
			return this.#0Db(#Ng.#TW());
		}

		// Token: 0x060031B3 RID: 12723 RVA: 0x0002C0C5 File Offset: 0x0002A2C5
		private double #Pzb(double #Udb)
		{
			if (this.#g == CircleDirection.Clockwise)
			{
				return #Udb;
			}
			return (#Udb - 360.0) % 360.0;
		}

		// Token: 0x060031B4 RID: 12724 RVA: 0x000FD4F4 File Offset: 0x000FB6F4
		private bool #Dzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#f == AddArcReinforcementBarTool.#s6b.#b)
			{
				return this.#c == null || base.#4Mb(this.#c, #Ng, base.EditorContext.Snapping.#NLb());
			}
			return this.#f == AddArcReinforcementBarTool.#s6b.#c && (this.#d == null || base.#4Mb(this.#d, #Ng, base.EditorContext.Snapping.#NLb()));
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x000FD580 File Offset: 0x000FB780
		private List<ReinforcementBar> #1Db(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Mzb, devDept.Geometry.Point3D #Yrb)
		{
			float #HS = (float)Math.Abs(#Xrb.DistanceTo(#Mzb));
			ValueTuple<float, float> valueTuple = ReinforcementPatternHelper.#OLe(#Xrb, #Mzb, #Yrb);
			float item = valueTuple.Item1;
			float item2 = valueTuple.Item2;
			List<devDept.Geometry.Point3D> #BP = (this.#a.BarPlacementType == BarPlacementType.Numbers) ? this.#2Db(#Xrb, #HS, item, item2) : this.#3Db(#Xrb, #HS, item, item2);
			return this.#5Db(#BP);
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x000FD5E8 File Offset: 0x000FB7E8
		private List<devDept.Geometry.Point3D> #2Db(devDept.Geometry.Point3D #wob, float #HS, float #Nzb, float #Ozb)
		{
			this.#4Db(ref #Nzb, ref #Ozb);
			List<float> list = new List<float>();
			int num = this.#a.NumberOfBarsX - 1;
			double num2 = (num > 0) ? ((double)((#Ozb - #Nzb) / (float)num)) : 1.0;
			for (int i = 0; i <= num; i++)
			{
				float item = (float)((double)#Nzb + (double)i * num2);
				list.Add(item);
			}
			return ColumnShapesHelper.#JHb(#wob, #HS, list).Take(#dde.Instance.BarsAtOnce).ToList<devDept.Geometry.Point3D>();
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x000FD67C File Offset: 0x000FB87C
		private List<devDept.Geometry.Point3D> #3Db(devDept.Geometry.Point3D #wob, float #HS, float #Nzb, float #Ozb)
		{
			this.#4Db(ref #Nzb, ref #Ozb);
			List<float> list = new List<float>();
			double num = this.#a.BarSpacingX;
			float num2 = Math.Abs(#Ozb - #Nzb);
			double num3 = (double)num2 / 360.0;
			double num4 = 6.283185307179586 * (double)#HS;
			double num5 = num3 * num4;
			bool flag = this.#g == CircleDirection.Clockwise;
			float num6 = flag ? #Ozb : #Nzb;
			double num7 = flag ? -1.0 : 1.0;
			double num8 = num5 / num + 2.0;
			int num9 = (int)num8;
			if (Math.Abs((double)num9 - num8) <= 0.0)
			{
				num9--;
			}
			num = num5 / (double)(num9 - 1);
			for (int i = 0; i < num9; i++)
			{
				double num10 = (double)i * num / num5;
				float item = (float)((double)num6 + num10 * (double)num2 * num7);
				list.Add(item);
			}
			return ColumnShapesHelper.#JHb(#wob, #HS, list).Take(#dde.Instance.BarsAtOnce).ToList<devDept.Geometry.Point3D>();
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x000FD7A8 File Offset: 0x000FB9A8
		private void #4Db(ref float #Nzb, ref float #Ozb)
		{
			if (this.#g == CircleDirection.Clockwise)
			{
				float num = #Ozb;
				#Ozb = #Nzb;
				#Nzb = num;
			}
			if (#Nzb > #Ozb)
			{
				#Ozb += 360f;
			}
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x000FD7E4 File Offset: 0x000FB9E4
		private List<ReinforcementBar> #5Db(List<devDept.Geometry.Point3D> #BP)
		{
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			double? num = this.#a.#3Eb();
			if (num == null)
			{
				return list;
			}
			foreach (devDept.Geometry.Point3D point3D in #BP)
			{
				ReinforcementBar item = new ReinforcementBar((float)num.Value, (float)point3D.X, (float)point3D.Y, 0f);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x000FD890 File Offset: 0x000FBA90
		private CircleDirection #Jzb(devDept.Geometry.Point3D #Kzb)
		{
			devDept.Geometry.Point3D point3D = #Kzb - this.#c;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double #HS = Math.Abs(#Kzb.DistanceTo(this.#c));
			devDept.Geometry.Point3D point3D2 = this.#c;
			devDept.Geometry.Point3D #MHb = this.#d;
			devDept.Geometry.Point3D #NHb = GeometryHelper.#4nc(point3D2.#QW(), #HS, (double)num).#TW();
			return ColumnShapesHelper.#LHb(point3D2, #MHb, #NHb);
		}

		// Token: 0x04001429 RID: 5161
		private readonly #BFb #a;

		// Token: 0x0400142A RID: 5162
		private readonly #nFb #b;

		// Token: 0x0400142B RID: 5163
		private devDept.Geometry.Point3D #c;

		// Token: 0x0400142C RID: 5164
		private devDept.Geometry.Point3D #d;

		// Token: 0x0400142D RID: 5165
		private devDept.Geometry.Point3D #e;

		// Token: 0x0400142E RID: 5166
		private AddArcReinforcementBarTool.#s6b #f;

		// Token: 0x0400142F RID: 5167
		private CircleDirection #g;

		// Token: 0x04001430 RID: 5168
		private bool #h;

		// Token: 0x02000576 RID: 1398
		private enum #s6b
		{
			// Token: 0x04001432 RID: 5170
			#a,
			// Token: 0x04001433 RID: 5171
			#b,
			// Token: 0x04001434 RID: 5172
			#c
		}
	}
}

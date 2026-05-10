using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #bne;
using #coe;
using #ede;
using #G1h;
using #o1d;
using #Vjc;
using #xKe;
using netDxf;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;
using netDxf.Units;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.DataExchange.DXF;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current.DXF
{
	// Token: 0x020010E6 RID: 4326
	public sealed class DxfFormatReader
	{
		// Token: 0x060092F3 RID: 37619 RVA: 0x001F3580 File Offset: 0x001F1780
		public #Uoe #Cjc(Stream #gp, #dai #mA)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			if (DxfDocument.CheckDxfFileVersion(#gp) < DxfVersion.AutoCad2000)
			{
				return #Uoe.UnsupportedVersion;
			}
			#gp.#i2d();
			DxfDocument dxfDocument = DxfDocument.Load(#gp);
			if (dxfDocument == null)
			{
				return #Uoe.Null;
			}
			LengthUnit #FWi = (#mA.TargetUnitSystem == UnitSystem.SIMetric) ? LengthUnit.Millimeter : LengthUnit.Inch;
			LengthUnit #f = DxfFormatReader.#ene(dxfDocument.DrawingVariables.InsUnits, #FWi);
			UnitSystem #f2 = DxfFormatReader.#cne(dxfDocument.DrawingVariables.InsUnits, #mA.TargetUnitSystem);
			#Uoe #Uoe = new #Uoe
			{
				LengthUnit = #f,
				UnitSystem = #f2,
				IsUnitless = (dxfDocument.DrawingVariables.InsUnits == DrawingUnits.Unitless)
			};
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.#pR(dxfDocument.Entities.Ellipses.Select(new Func<Ellipse, string>(DxfFormatReader.<>c.<>9.#tbi)));
			hashSet.#pR(dxfDocument.Entities.Polylines3D.Select(new Func<Polyline3D, string>(DxfFormatReader.<>c.<>9.#ZWi)));
			hashSet.#pR(dxfDocument.Entities.Polylines2D.Select(new Func<Polyline2D, string>(DxfFormatReader.<>c.<>9.#0Wi)));
			hashSet.#pR(dxfDocument.Entities.Circles.Select(new Func<Circle, string>(DxfFormatReader.<>c.<>9.#1Wi)));
			#Uoe.LayerNames.AddRange(hashSet.OrderBy(new Func<string, string>(DxfFormatReader.<>c.<>9.#2Wi)));
			if (!string.IsNullOrWhiteSpace(#mA.SolidsLayer))
			{
				bool #f3;
				bool #f4;
				List<SectionPolygon> list = this.#ine(PolygonApplication.Solid, dxfDocument, #mA, #mA.SolidsLayer, out #f3, out #f4);
				if (list != null)
				{
					#Uoe.Solids.AddRange(list);
				}
				#Uoe.TooBigSolidsFound = #f4;
				#Uoe.NotClosedSolidsFound = #f3;
			}
			if (!string.IsNullOrWhiteSpace(#mA.OpeningsLayer))
			{
				bool #f5;
				bool #f6;
				List<SectionPolygon> list2 = this.#ine(PolygonApplication.Opening, dxfDocument, #mA, #mA.OpeningsLayer, out #f5, out #f6);
				if (list2 != null)
				{
					#Uoe.Openings.AddRange(list2);
				}
				#Uoe.ToBigOpeningsFound = #f6;
				#Uoe.NotClosedOpeningsFound = #f5;
			}
			if (!string.IsNullOrWhiteSpace(#mA.BarsLayer))
			{
				bool #f7;
				List<ReinforcementBar> list3 = this.#xme(dxfDocument, #mA.BarsLayer, out #f7);
				if (list3 != null)
				{
					#Uoe.ReinforcementBars.AddRange(list3);
				}
				#Uoe.TooManyBarsFound = #f7;
			}
			return #Uoe;
		}

		// Token: 0x060092F4 RID: 37620 RVA: 0x001F3814 File Offset: 0x001F1A14
		private static UnitSystem #cne(DrawingUnits #dne, UnitSystem #EWi)
		{
			switch (#dne)
			{
			case DrawingUnits.Unitless:
				return #EWi;
			case DrawingUnits.Inches:
			case DrawingUnits.Feet:
			case DrawingUnits.Yards:
				return UnitSystem.USCustomary;
			case DrawingUnits.Millimeters:
			case DrawingUnits.Centimeters:
			case DrawingUnits.Meters:
				return UnitSystem.SIMetric;
			}
			throw new #IWi();
		}

		// Token: 0x060092F5 RID: 37621 RVA: 0x001F3860 File Offset: 0x001F1A60
		private static LengthUnit #ene(DrawingUnits #dne, LengthUnit #FWi)
		{
			switch (#dne)
			{
			case DrawingUnits.Unitless:
				return #FWi;
			case DrawingUnits.Inches:
				return LengthUnit.Inch;
			case DrawingUnits.Feet:
				return LengthUnit.Foot;
			case DrawingUnits.Millimeters:
				return LengthUnit.Millimeter;
			case DrawingUnits.Centimeters:
				return LengthUnit.Centimeter;
			case DrawingUnits.Meters:
				return LengthUnit.Meter;
			case DrawingUnits.Yards:
				return LengthUnit.Yard;
			}
			throw new #IWi();
		}

		// Token: 0x060092F6 RID: 37622 RVA: 0x00075DF8 File Offset: 0x00073FF8
		private static bool #sne(string #tne, string #une)
		{
			return string.Equals(#tne, #une, StringComparison.InvariantCultureIgnoreCase);
		}

		// Token: 0x060092F7 RID: 37623 RVA: 0x001F38B4 File Offset: 0x001F1AB4
		private List<ReinforcementBar> #xme(DxfDocument #fne, string #yR, out bool #gne)
		{
			DxfFormatReader.#92b #92b = new DxfFormatReader.#92b();
			#92b.#a = #yR;
			if (this.#hne(#fne, #92b.#a))
			{
				#gne = false;
				return null;
			}
			List<Circle> list = #fne.Entities.Circles.Where(new Func<Circle, bool>(#92b.#zbi)).ToList<Circle>();
			#gne = (list.Count > #dde.Instance.TotalBars);
			List<ReinforcementBar> list2 = new List<ReinforcementBar>();
			foreach (Circle circle in list.Take(#dde.Instance.TotalBars))
			{
				if (Math.Abs(circle.Radius) >= 0.001)
				{
					float x = (float)circle.Center.X;
					float y = (float)circle.Center.Y;
					ReinforcementBar item = new ReinforcementBar((float)(3.141592653589793 * circle.Radius * circle.Radius), x, y, 0f);
					list2.Add(item);
				}
			}
			return list2;
		}

		// Token: 0x060092F8 RID: 37624 RVA: 0x001F39D8 File Offset: 0x001F1BD8
		private bool #hne(DxfDocument #fne, string #yR)
		{
			DxfFormatReader.#W9b #W9b = new DxfFormatReader.#W9b();
			#W9b.#a = #yR;
			return #fne == null || #fne.Layers.Items.FirstOrDefault(new Func<Layer, bool>(#W9b.#ebf)) == null;
		}

		// Token: 0x060092F9 RID: 37625 RVA: 0x001F3A18 File Offset: 0x001F1C18
		private List<SectionPolygon> #ine(PolygonApplication #jne, DxfDocument #fne, #dai #mA, string #yR, out bool #kne, out bool #lne)
		{
			DxfFormatReader.#s0b #s0b = new DxfFormatReader.#s0b();
			#s0b.#d = #mA;
			#s0b.#e = #yR;
			if (this.#hne(#fne, #s0b.#e))
			{
				#lne = false;
				#kne = false;
				return null;
			}
			#s0b.#c = ((#s0b.#d.TargetUnitSystem == UnitSystem.SIMetric) ? LengthUnit.Millimeter : LengthUnit.Inch);
			#s0b.#b = DxfFormatReader.#ene(#fne.DrawingVariables.InsUnits, #s0b.#c);
			#s0b.#a = new LengthConverter();
			List<Polyline3D> #lAc = #fne.Entities.Polylines3D.Where(new Func<Polyline3D, bool>(#s0b.#gbf)).ToList<Polyline3D>();
			List<Polyline2D> #qne = #fne.Entities.Polylines2D.Where(new Func<Polyline2D, bool>(#s0b.#Cbi)).ToList<Polyline2D>();
			List<Ellipse> #nAc = #fne.Entities.Ellipses.Where(new Func<Ellipse, bool>(#s0b.#Dbi)).ToList<Ellipse>();
			List<Circle> #nAc2 = #fne.Entities.Circles.Where(new Func<Circle, bool>(#s0b.#Ebi)).ToList<Circle>();
			List<SectionPolygon> list = this.#49h(#jne, #lAc, #qne, new Func<double, int>(#s0b.#Abi));
			list.AddRange(this.#Zxb(#jne, #nAc, new Func<Ellipse, int>(#s0b.#Fbi)));
			list.AddRange(this.#Zxb(#jne, #nAc2, new Func<double, int>(#s0b.#Abi)));
			List<SectionPolygon> list2 = this.#mne(list, out #kne, out #lne);
			this.#one(list2);
			return list2;
		}

		// Token: 0x060092FA RID: 37626 RVA: 0x001F3B84 File Offset: 0x001F1D84
		private List<SectionPolygon> #mne(List<SectionPolygon> #nne, out bool #kne, out bool #lne)
		{
			DxfFormatReader.#oWb #oWb = new DxfFormatReader.#oWb();
			#gee #gee = #6de.#ul(#ice.Irregular);
			#oWb.#a = #gee.Core.SectionPolygonPointsNumber;
			#kne = #nne.Any(new Func<SectionPolygon, bool>(#oWb.#Gbi));
			#lne = #nne.Any(new Func<SectionPolygon, bool>(#oWb.#Hbi));
			#oWb.#b = new SectionPolygonValidator(#ice.Irregular, 0);
			return #nne.Where(new Func<SectionPolygon, bool>(#oWb.#Ibi)).ToList<SectionPolygon>();
		}

		// Token: 0x060092FB RID: 37627 RVA: 0x001F3C04 File Offset: 0x001F1E04
		private void #one(List<SectionPolygon> #yP)
		{
			foreach (SectionPolygon sectionPolygon in #yP.Where(new Func<SectionPolygon, bool>(DxfFormatReader.<>c.<>9.#3Wi)))
			{
				sectionPolygon.Points.Add(sectionPolygon.Points.First<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>());
			}
		}

		// Token: 0x060092FC RID: 37628 RVA: 0x001F3C80 File Offset: 0x001F1E80
		private List<SectionPolygon> #Zxb(PolygonApplication #Wme, List<Ellipse> #nAc, Func<Ellipse, int> #39h)
		{
			DxfFormatReader.#iZb #iZb = new DxfFormatReader.#iZb();
			#iZb.#a = #Wme;
			#iZb.#b = #39h;
			return #nAc.Select(new Func<Ellipse, SectionPolygon>(#iZb.#Jbi)).ToList<SectionPolygon>();
		}

		// Token: 0x060092FD RID: 37629 RVA: 0x001F3CB8 File Offset: 0x001F1EB8
		private List<SectionPolygon> #Zxb(PolygonApplication #Wme, List<Circle> #nAc, Func<double, int> #39h)
		{
			DxfFormatReader.#BUb #BUb = new DxfFormatReader.#BUb();
			#BUb.#a = #Wme;
			#BUb.#b = #39h;
			return #nAc.Select(new Func<Circle, SectionPolygon>(#BUb.#Jbi)).ToList<SectionPolygon>();
		}

		// Token: 0x060092FE RID: 37630 RVA: 0x001F3CF0 File Offset: 0x001F1EF0
		private List<SectionPolygon> #49h(PolygonApplication #jne, List<Polyline3D> #lAc, List<Polyline2D> #qne, Func<double, int> #39h)
		{
			DxfFormatReader.#61b #61b = new DxfFormatReader.#61b();
			#61b.#a = #jne;
			#61b.#b = #39h;
			List<SectionPolygon> list = #lAc.Select(new Func<Polyline3D, SectionPolygon>(#61b.#Kbi)).ToList<SectionPolygon>();
			list.AddRange(#qne.Select(new Func<Polyline2D, SectionPolygon>(#61b.#Lbi)));
			return list;
		}

		// Token: 0x04003E77 RID: 15991
		public const string #a = "Solids";

		// Token: 0x04003E78 RID: 15992
		public const string #b = "Openings";

		// Token: 0x04003E79 RID: 15993
		public const string #c = "Bars";

		// Token: 0x020010E8 RID: 4328
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x0600930D RID: 37645 RVA: 0x001F3D44 File Offset: 0x001F1F44
			internal bool #Gbi(SectionPolygon #9o)
			{
				double num = (double)#9o.Points.Count;
				double? num2 = this.#a.Min;
				return num < num2.GetValueOrDefault() & num2 != null;
			}

			// Token: 0x0600930E RID: 37646 RVA: 0x001F3D7C File Offset: 0x001F1F7C
			internal bool #Hbi(SectionPolygon #9o)
			{
				double num = (double)#9o.Points.Count;
				double? num2 = this.#a.Max;
				return num > num2.GetValueOrDefault() & num2 != null;
			}

			// Token: 0x0600930F RID: 37647 RVA: 0x001F3DB4 File Offset: 0x001F1FB4
			internal bool #Ibi(SectionPolygon #9o)
			{
				double num = (double)#9o.Points.Count;
				double? num2 = this.#a.Min;
				if (num >= num2.GetValueOrDefault() & num2 != null)
				{
					double num3 = (double)#9o.Points.Count;
					num2 = this.#a.Max;
					if (num3 <= num2.GetValueOrDefault() & num2 != null)
					{
						return this.#b.Validate(#9o).IsValid;
					}
				}
				return false;
			}

			// Token: 0x04003E85 RID: 16005
			public #9ce #a;

			// Token: 0x04003E86 RID: 16006
			public SectionPolygonValidator #b;
		}

		// Token: 0x020010E9 RID: 4329
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06009311 RID: 37649 RVA: 0x001F3E30 File Offset: 0x001F2030
			internal SectionPolygon #Jbi(Ellipse #9o)
			{
				SectionPolygon sectionPolygon = new SectionPolygon();
				sectionPolygon.Application = this.#a;
				sectionPolygon.Points = #K1h.#H1h(new #akc(new #mkc(#9o.Center.X, #9o.Center.Y, #9o.Center.Z, null), #9o.MajorAxis / 2.0, #9o.MinorAxis / 2.0, #9o.Rotation, #9o.StartAngle, #9o.EndAngle, null), this.#b(#9o)).Select(new Func<Point3D, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(DxfFormatReader.<>c.<>9.#4Wi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				sectionPolygon.FigureType = PolygonFigureType.Irregural;
				return sectionPolygon;
			}

			// Token: 0x04003E87 RID: 16007
			public PolygonApplication #a;

			// Token: 0x04003E88 RID: 16008
			public Func<Ellipse, int> #b;
		}

		// Token: 0x020010EA RID: 4330
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06009313 RID: 37651 RVA: 0x001F3F00 File Offset: 0x001F2100
			internal SectionPolygon #Jbi(Circle #9o)
			{
				SectionPolygon sectionPolygon = new SectionPolygon();
				sectionPolygon.Application = this.#a;
				sectionPolygon.Points = #I1h.#H1h(new #Zjc(new #mkc(#9o.Center.X, #9o.Center.Y, #9o.Center.Z, null), #9o.Radius, null), this.#b(#9o.Radius)).Select(new Func<Point3D, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(DxfFormatReader.<>c.<>9.#vbi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				sectionPolygon.CircleCenter = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#9o.Center.X, #9o.Center.Y);
				sectionPolygon.CircleRadius = new double?(#9o.Radius);
				sectionPolygon.FigureType = PolygonFigureType.Circle;
				return sectionPolygon;
			}

			// Token: 0x04003E89 RID: 16009
			public PolygonApplication #a;

			// Token: 0x04003E8A RID: 16010
			public Func<double, int> #b;
		}

		// Token: 0x020010EB RID: 4331
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06009315 RID: 37653 RVA: 0x001F3FE0 File Offset: 0x001F21E0
			internal SectionPolygon #Kbi(Polyline3D #9o)
			{
				SectionPolygon sectionPolygon = new SectionPolygon();
				sectionPolygon.Application = this.#a;
				sectionPolygon.FigureType = PolygonFigureType.Irregural;
				sectionPolygon.Points = #9o.Vertexes.Select(new Func<Vector3, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(DxfFormatReader.<>c.<>9.#5Wi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				return sectionPolygon;
			}

			// Token: 0x06009316 RID: 37654 RVA: 0x001F403C File Offset: 0x001F223C
			internal SectionPolygon #Lbi(Polyline2D #9o)
			{
				SectionPolygon sectionPolygon = new SectionPolygon();
				sectionPolygon.Application = this.#a;
				sectionPolygon.FigureType = PolygonFigureType.Irregural;
				sectionPolygon.Points = DXFPolylineHelper.#S1h(#9o, this.#b).Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(DxfFormatReader.<>c.<>9.#6Wi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				return sectionPolygon;
			}

			// Token: 0x04003E8B RID: 16011
			public PolygonApplication #a;

			// Token: 0x04003E8C RID: 16012
			public Func<double, int> #b;
		}

		// Token: 0x020010EC RID: 4332
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06009318 RID: 37656 RVA: 0x00075E8A File Offset: 0x0007408A
			internal bool #zbi(Circle #9o)
			{
				return DxfFormatReader.#sne(#9o.Layer.Name, this.#a);
			}

			// Token: 0x04003E8D RID: 16013
			public string #a;
		}

		// Token: 0x020010ED RID: 4333
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x0600931A RID: 37658 RVA: 0x00075EA2 File Offset: 0x000740A2
			internal bool #ebf(Layer #9o)
			{
				return DxfFormatReader.#sne(#9o.Name, this.#a);
			}

			// Token: 0x04003E8E RID: 16014
			public string #a;
		}

		// Token: 0x020010EE RID: 4334
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x0600931C RID: 37660 RVA: 0x001F409C File Offset: 0x001F229C
			internal int #Abi(double #Bbi)
			{
				double #HS = this.#a.#Pb(this.#b, this.#c, #Bbi);
				return #4ai.#3ai(this.#d.TargetUnitSystem, #HS, this.#d.MinNoOfCircleSegments);
			}

			// Token: 0x0600931D RID: 37661 RVA: 0x00075EB5 File Offset: 0x000740B5
			internal bool #gbf(Polyline3D #9o)
			{
				return DxfFormatReader.#sne(#9o.Layer.Name, this.#e);
			}

			// Token: 0x0600931E RID: 37662 RVA: 0x00075EB5 File Offset: 0x000740B5
			internal bool #Cbi(Polyline2D #9o)
			{
				return DxfFormatReader.#sne(#9o.Layer.Name, this.#e);
			}

			// Token: 0x0600931F RID: 37663 RVA: 0x00075EB5 File Offset: 0x000740B5
			internal bool #Dbi(Ellipse #9o)
			{
				return DxfFormatReader.#sne(#9o.Layer.Name, this.#e);
			}

			// Token: 0x06009320 RID: 37664 RVA: 0x00075EB5 File Offset: 0x000740B5
			internal bool #Ebi(Circle #9o)
			{
				return DxfFormatReader.#sne(#9o.Layer.Name, this.#e);
			}

			// Token: 0x06009321 RID: 37665 RVA: 0x00075ECD File Offset: 0x000740CD
			internal int #Fbi(Ellipse #He)
			{
				return this.#Abi(Math.Max(#He.MajorAxis, #He.MinorAxis));
			}

			// Token: 0x04003E8F RID: 16015
			public LengthConverter #a;

			// Token: 0x04003E90 RID: 16016
			public LengthUnit #b;

			// Token: 0x04003E91 RID: 16017
			public LengthUnit #c;

			// Token: 0x04003E92 RID: 16018
			public #dai #d;

			// Token: 0x04003E93 RID: 16019
			public string #e;
		}
	}
}

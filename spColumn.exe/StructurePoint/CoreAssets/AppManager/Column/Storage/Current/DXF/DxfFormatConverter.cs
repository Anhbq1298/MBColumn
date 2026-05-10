using System;
using System.Collections.Generic;
using System.Linq;
using #2ic;
using #7hc;
using #Vjc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current.DXF
{
	// Token: 0x020010E4 RID: 4324
	public sealed class DxfFormatConverter
	{
		// Token: 0x060092EC RID: 37612 RVA: 0x001F3244 File Offset: 0x001F1444
		public static #Qjc #8me(ColumnStorageModel #X)
		{
			if (#X == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289973));
			}
			#Qjc #Qjc = new #kkc();
			#Qjc.DrawingUnit = DxfFormatConverter.#9me((#X.Options.Unit == UnitSystem.SIMetric) ? LengthUnit.Millimeter : LengthUnit.Inch);
			#fkc #rR = new #fkc(#Phc.#3hc(107348230), new #3jc(byte.MaxValue, 0, 0));
			foreach (SectionPolygon sectionPolygon in #X.Polygons.Where(new Func<SectionPolygon, bool>(DxfFormatConverter.<>c.<>9.#5af)))
			{
				List<#Jkc> list = new List<#Jkc>();
				for (int i = 0; i < sectionPolygon.Points.Count - 1; i++)
				{
					Point point = sectionPolygon.Points[i];
					list.Add(new #Jkc(new #mkc((double)point.X, (double)point.Y, 0.0, null)));
				}
				#Qjc.PolygonPolylines.Add(new #okc(list, true, #rR, false));
			}
			#fkc #rR2 = new #fkc(#Phc.#3hc(107348253), new #3jc(0, byte.MaxValue, 0));
			foreach (SectionPolygon sectionPolygon2 in #X.Polygons.Where(new Func<SectionPolygon, bool>(DxfFormatConverter.<>c.<>9.#6af)))
			{
				List<#Jkc> list2 = new List<#Jkc>();
				for (int j = 0; j < sectionPolygon2.Points.Count - 1; j++)
				{
					Point point2 = sectionPolygon2.Points[j];
					list2.Add(new #Jkc(new #mkc((double)point2.X, (double)point2.Y, 0.0, null)));
				}
				#Qjc.PolygonPolylines.Add(new #okc(list2, true, #rR2, true));
			}
			#fkc #rR3 = new #fkc(#Phc.#3hc(107348240), new #3jc(0, 0, byte.MaxValue));
			foreach (ReinforcementBar reinforcementBar in #X.ReinforcementBars)
			{
				#mkc #Wjc = new #mkc((double)reinforcementBar.X, (double)reinforcementBar.Y, 0.0, null);
				#Qjc.Circles.Add(new #Zjc(#Wjc, CircleHelper.#wmc((double)reinforcementBar.Area), #rR3));
			}
			return #Qjc;
		}

		// Token: 0x060092ED RID: 37613 RVA: 0x001F350C File Offset: 0x001F170C
		private static ExternDrawingUnit #9me(LengthUnit #l8d)
		{
			switch (#l8d)
			{
			case LengthUnit.Meter:
				return ExternDrawingUnit.Meters;
			case LengthUnit.Centimeter:
				return ExternDrawingUnit.Centimeters;
			case LengthUnit.Millimeter:
				return ExternDrawingUnit.Millimeters;
			case LengthUnit.Yard:
				return ExternDrawingUnit.Yards;
			case LengthUnit.Foot:
				return ExternDrawingUnit.Feet;
			case LengthUnit.Inch:
				return ExternDrawingUnit.Inches;
			case LengthUnit.FootInch:
				return ExternDrawingUnit.Feet;
			case LengthUnit.Point:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107289924), #l8d, null);
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107289924), #l8d, null);
			}
		}
	}
}

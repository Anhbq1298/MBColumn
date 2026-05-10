using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #coe;
using #N7d;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x0200127D RID: 4733
	public static class ImportHelper
	{
		// Token: 0x06009EB2 RID: 40626 RVA: 0x0021A720 File Offset: 0x00218920
		public static List<StandardBar> #gFb(UnitSystem #tLe, #boe #2ie)
		{
			if (#2ie.Bars.Count == 0)
			{
				return new List<StandardBar>();
			}
			if (#tLe == #2ie.Unit)
			{
				return #2ie.Bars;
			}
			LengthConverter lengthConverter = new LengthConverter();
			#O8d #O8d = new #O8d();
			#S7d #S7d = new #S7d();
			LengthUnit #K7d = (#2ie.Unit == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter;
			AreaUnit #K7d2 = (#2ie.Unit == UnitSystem.USCustomary) ? AreaUnit.InchSquared : AreaUnit.MillimeterSquared;
			MassPerLengthUnit #K7d3 = (#2ie.Unit == UnitSystem.USCustomary) ? MassPerLengthUnit.PoundPerLinearFoot : MassPerLengthUnit.KilogramPerMeter;
			LengthUnit #B = (#tLe == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter;
			AreaUnit #B2 = (#tLe == UnitSystem.USCustomary) ? AreaUnit.InchSquared : AreaUnit.MillimeterSquared;
			MassPerLengthUnit #B3 = (#tLe == UnitSystem.USCustomary) ? MassPerLengthUnit.PoundPerLinearFoot : MassPerLengthUnit.KilogramPerMeter;
			List<StandardBar> list = new List<StandardBar>();
			foreach (StandardBar standardBar in #2ie.Bars)
			{
				list.Add(new StandardBar
				{
					Size = standardBar.Size,
					Diameter = (float)lengthConverter.#Pb(#K7d, #B, (double)standardBar.Diameter),
					Area = (float)#O8d.#Pb(#K7d2, #B2, (double)standardBar.Area),
					Weight = (float)#S7d.#Pb(#K7d3, #B3, (double)standardBar.Weight)
				});
			}
			return list;
		}

		// Token: 0x06009EB3 RID: 40627 RVA: 0x0021A85C File Offset: 0x00218A5C
		public static byte[] #uLe(Stream #gp)
		{
			MemoryStream memoryStream = new MemoryStream();
			#gp.CopyTo(memoryStream);
			return memoryStream.ToArray();
		}

		// Token: 0x06009EB4 RID: 40628 RVA: 0x0007CDDD File Offset: 0x0007AFDD
		public static Stream #vLe(byte[] #OYd)
		{
			return new MemoryStream(#OYd);
		}

		// Token: 0x06009EB5 RID: 40629 RVA: 0x0021A87C File Offset: 0x00218A7C
		public static string #wLe(ref List<ReinforcementBar> #KJ)
		{
			List<string> list = new List<string>();
			if (#KJ == null)
			{
				return null;
			}
			int count = #KJ.Count;
			#KJ = #KJ.Where(new Func<ReinforcementBar, bool>(ImportHelper.<>c.<>9.#hgf)).ToList<ReinforcementBar>();
			if (count != #KJ.Count)
			{
				list.Add(Strings.StringReinforcementBarsWithZeroSurfaceHaveNotBeenImported.#z2d());
			}
			int count2 = #KJ.Count;
			#KJ = #KJ.GroupBy(new Func<ReinforcementBar, <>f__AnonymousType0<float, float>>(ImportHelper.<>c.<>9.#igf)).Select(new Func<IGrouping<<>f__AnonymousType0<float, float>, ReinforcementBar>, ReinforcementBar>(ImportHelper.<>c.<>9.#kgf)).Select(new Func<ReinforcementBar, ReinforcementBar>(ImportHelper.<>c.<>9.#lgf)).ToList<ReinforcementBar>();
			if (count2 != #KJ.Count)
			{
				list.Add(Strings.StringReinforcementBarsWithDuplicatePositionsHaveNotBbeenImported.#z2d());
			}
			if (!list.Any<string>())
			{
				return null;
			}
			return string.Join(Environment.NewLine, list);
		}

		// Token: 0x06009EB6 RID: 40630 RVA: 0x0021A98C File Offset: 0x00218B8C
		public static void #9W(SectionPolygon #xLe)
		{
			bool flag = true;
			try
			{
				flag = ColumnGeometryHelper.#1lc(#xLe.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Point3D>(ImportHelper.<>c.<>9.#mgf)).ToList<Point3D>());
			}
			catch (Exception)
			{
				flag = false;
			}
			if (!flag)
			{
				throw new #ooe(Strings.StringInvalidGeometryOfSectionType.#D2d(new object[]
				{
					#xLe.Application
				}).#z2d());
			}
		}

		// Token: 0x06009EB7 RID: 40631 RVA: 0x0021AA14 File Offset: 0x00218C14
		public static List<ReinforcementBar> #yLe(List<ReinforcementBar> #zLe, List<ReinforcementBar> #ALe, ref string #BLe)
		{
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			list.AddRange(#zLe);
			list.AddRange(#ALe);
			int count = list.Count;
			ImportHelper.#wLe(ref list);
			int count2 = list.Count;
			if (count != count2)
			{
				#BLe = (string.IsNullOrWhiteSpace(#BLe) ? null : #BLe.#Tm().#Tm());
				#BLe += Strings.StringExistingReinforcementBarsThatShareTheSamePositionsWithTheImportedBarsHaveBeenReplaced.#z2d();
			}
			return list;
		}
	}
}

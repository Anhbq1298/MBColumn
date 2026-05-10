using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using ClipperLib;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007EC RID: 2028
	internal static class ShapeToClipperPolygonsConverter
	{
		// Token: 0x06004102 RID: 16642 RVA: 0x001307DC File Offset: 0x0012E9DC
		internal static #2uc #Pb(ShapeData #rP)
		{
			if (2 != 0 && -1 != 0)
			{
				string #R0d = #Phc.#3hc(107371527);
				Component #x6c = Component.Geometry;
				string #Qic = #Phc.#3hc(107461430);
				if (4 != 0)
				{
					#X0d.#V0d(#rP, #R0d, #x6c, #Qic);
				}
			}
			IEnumerable<PolygonData> source = #rP.Polygons;
			Func<PolygonData, #1uc> selector;
			if ((selector = ShapeToClipperPolygonsConverter.#2Ui.#a) == null)
			{
				selector = (ShapeToClipperPolygonsConverter.#2Ui.#a = new Func<PolygonData, #1uc>(ShapeToClipperPolygonsConverter.#Pb));
			}
			return new #2uc(source.Select(selector));
		}

		// Token: 0x06004103 RID: 16643 RVA: 0x0013085C File Offset: 0x0012EA5C
		internal static #2uc #Pb(IEnumerable<PolygonData> #4lc)
		{
			#X0d.#V0d(#4lc, #Phc.#3hc(107371137), Component.Geometry, #Phc.#3hc(107460833));
			Func<PolygonData, #1uc> selector;
			if ((selector = ShapeToClipperPolygonsConverter.#2Ui.#a) == null)
			{
				selector = (ShapeToClipperPolygonsConverter.#2Ui.#a = new Func<PolygonData, #1uc>(ShapeToClipperPolygonsConverter.#Pb));
			}
			return new #2uc(#4lc.Select(selector));
		}

		// Token: 0x06004104 RID: 16644 RVA: 0x001308C8 File Offset: 0x0012EAC8
		internal static #1uc #Pb(PolygonData #JP)
		{
			if (true)
			{
				#X0d.#V0d(#JP, #Phc.#3hc(107460780), Component.Geometry, #Phc.#3hc(107460751));
			}
			return new #1uc(#JP.IntPoints);
		}

		// Token: 0x06004105 RID: 16645 RVA: 0x0013091C File Offset: 0x0012EB1C
		internal static IList<PolygonData> #Rsc(List<List<IntPoint>> #Ssc)
		{
			#X0d.#V0d(#Ssc, #Phc.#3hc(107460730), Component.Geometry, #Phc.#3hc(107460677));
			IEnumerable<List<IntPoint>> source = #Ssc.Where(new Func<List<IntPoint>, bool>(ShapeToClipperPolygonsConverter.<>c.<>9.#lyc));
			Func<List<IntPoint>, PolygonData> selector;
			if ((selector = ShapeToClipperPolygonsConverter.#2Ui.#b) == null)
			{
				selector = (ShapeToClipperPolygonsConverter.#2Ui.#b = new Func<List<IntPoint>, PolygonData>(ShapeToClipperPolygonsConverter.#Tsc));
			}
			return source.Select(selector).ToList<PolygonData>();
		}

		// Token: 0x06004106 RID: 16646 RVA: 0x001309B0 File Offset: 0x0012EBB0
		internal static PolygonData #Tsc(List<IntPoint> #zsc)
		{
			#X0d.#V0d(#zsc, #Phc.#3hc(107462056), Component.Geometry, #Phc.#3hc(107460656));
			return new PolygonData(PointsConverter.#Pb(#zsc), PolygonType.Undefined);
		}

		// Token: 0x020007ED RID: 2029
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04001D44 RID: 7492
			public static Func<PolygonData, #1uc> #a;

			// Token: 0x04001D45 RID: 7493
			public static Func<List<IntPoint>, PolygonData> #b;
		}
	}
}

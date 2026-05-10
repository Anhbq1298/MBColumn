using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Fmc
{
	// Token: 0x020007CF RID: 1999
	internal static class #Fpc
	{
		// Token: 0x06004008 RID: 16392 RVA: 0x0012AD3C File Offset: 0x00128F3C
		public static void #Epc(IList<SnappingSegmentData> #En, ShapeData #rP)
		{
			#X0d.#V0d(#En, #Phc.#3hc(107367090), Component.Geometry, #Phc.#3hc(107367049));
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107367028));
			foreach (PolygonData polygonData in #rP.Polygons)
			{
				foreach (SegmentData segmentData in polygonData.Segments)
				{
					#En.Add(new SnappingSegmentData(segmentData, #juc.#b)
					{
						SourceObject = #rP,
						SourcePolygon = polygonData,
						SourceShape = #rP,
						SourceSegment = segmentData
					});
				}
			}
		}

		// Token: 0x06004009 RID: 16393 RVA: 0x0012AE78 File Offset: 0x00129078
		public static void #Epc(IList<SnappingSegmentData> #En, IEnumerable<ShapeData> #6Y)
		{
			string #R0d = #Phc.#3hc(107367090);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107366975);
			if (!false)
			{
				#X0d.#V0d(#En, #R0d, #x6c, #Qic);
			}
			#X0d.#V0d(#6Y, #Phc.#3hc(107372113), Component.Geometry, #Phc.#3hc(107367402));
			using (IEnumerator<ShapeData> enumerator = #6Y.GetEnumerator())
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						goto IL_66;
					}
					IL_4D:
					if (2 != 0)
					{
						ShapeData #rP = enumerator.Current;
						#Fpc.#Epc(#En, #rP);
						continue;
					}
					IL_66:
					if (!false)
					{
						break;
					}
					goto IL_4D;
				}
			}
		}
	}
}

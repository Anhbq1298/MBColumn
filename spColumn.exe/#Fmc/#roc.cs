using System;
using System.Collections.Generic;
using System.Linq;
using #4vc;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Fmc
{
	// Token: 0x020007BD RID: 1981
	internal static class #roc
	{
		// Token: 0x06003FB6 RID: 16310 RVA: 0x001284D4 File Offset: 0x001266D4
		public static Point? #Klc(SegmentData #loc, SegmentData #moc)
		{
			Point value;
			for (;;)
			{
				if (!false)
				{
					#X0d.#V0d(#loc, #Phc.#3hc(107367949), Component.Geometry, #Phc.#3hc(107367956));
				}
				#X0d.#V0d(#moc, #Phc.#3hc(107368415), Component.Geometry, #Phc.#3hc(107368358));
				for (;;)
				{
					Point? point = #jsc.#plc(#loc, #moc, true);
					while (!false)
					{
						if (point == null)
						{
							goto IL_B5;
						}
						if (!false)
						{
							value = default(Point);
							value.X = Math.Round(point.Value.X, #Emc.#a);
							value.Y = Math.Round(point.Value.Y, #Emc.#a);
							break;
						}
					}
					if (false)
					{
						break;
					}
					if (!false)
					{
						goto Block_5;
					}
				}
			}
			Block_5:
			return new Point?(value);
			IL_B5:
			return null;
		}

		// Token: 0x06003FB7 RID: 16311 RVA: 0x001285F0 File Offset: 0x001267F0
		public unsafe static IList<SnappingPointData> #noc(IEnumerable<SnappingSegmentData> #ooc)
		{
			void* ptr = stackalloc byte[8];
			#X0d.#V0d(#ooc, #Phc.#3hc(107368337), Component.Geometry, #Phc.#3hc(107368308));
			Dictionary<Point, SnappingPointData> dictionary;
			for (;;)
			{
				IList<SnappingSegmentData> list2;
				if (8 != 0)
				{
					IList<SnappingSegmentData> list;
					if ((list = (#ooc as IList<SnappingSegmentData>)) == null)
					{
						list = #ooc.ToList<SnappingSegmentData>();
					}
					list2 = list;
					dictionary = new Dictionary<Point, SnappingPointData>();
				}
				IL_4E:
				while (-1 != 0)
				{
					*(int*)ptr = 0;
					for (;;)
					{
						IL_FF:
						int i = *(int*)ptr;
						IL_101:
						while (i < list2.Count)
						{
							SnappingSegmentData snappingSegmentData = list2[*(int*)ptr];
							*(int*)((byte*)ptr + 4) = *(int*)ptr + 1;
							if (8 != 0)
							{
								for (;;)
								{
									int num = i = *(int*)((byte*)ptr + 4);
									if (7 != 0)
									{
										SnappingSegmentData snappingSegmentData2;
										Point value;
										SnappingPointData snappingPointData;
										if (num >= list2.Count)
										{
											if (!false)
											{
												break;
											}
											goto IL_A6;
										}
										else
										{
											snappingSegmentData2 = list2[*(int*)((byte*)ptr + 4)];
											Point? point;
											do
											{
												point = #roc.#Klc(snappingSegmentData, snappingSegmentData2);
											}
											while (false);
											if (point != null)
											{
												value = point.Value;
												if (!dictionary.TryGetValue(value, out snappingPointData))
												{
													goto IL_A6;
												}
												goto IL_BF;
											}
										}
										IL_DA:
										*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
										continue;
										IL_BF:
										snappingPointData.#1sc(snappingSegmentData.SnapOriginInfo);
										snappingPointData.#1sc(snappingSegmentData2.SnapOriginInfo);
										goto IL_DA;
										IL_A6:
										snappingPointData = new SnappingPointData(value, snappingSegmentData.SnapDataOrigin);
										dictionary.Add(value, snappingPointData);
										goto IL_BF;
									}
									goto IL_101;
								}
								*(int*)ptr = *(int*)ptr + 1;
								goto IL_FF;
							}
							goto IL_4E;
						}
						goto Block_10;
					}
				}
			}
			Block_10:
			return dictionary.Values.ToList<SnappingPointData>();
		}

		// Token: 0x06003FB8 RID: 16312 RVA: 0x0012875C File Offset: 0x0012695C
		public static bool #poc(#ewc #qoc, BoundingBoxDataLight #smc)
		{
			#X0d.#V0d(#qoc, #Phc.#3hc(107368255), Component.Geometry, #Phc.#3hc(107368242));
			#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107367677));
			Point #doc = new Point(#qoc.Location.X, #qoc.Location.Y);
			Point point = #qoc.LineSegment.StartPoint;
			Point point2 = #qoc.LineSegment.EndPoint;
			if (!PointsConverter.#uC(point2, point))
			{
				while (GeometryHelper.#coc(#smc, #doc) && GeometryHelper.#coc(#smc, point2) && GeometryHelper.#coc(#smc, point))
				{
					if (-1 != 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}

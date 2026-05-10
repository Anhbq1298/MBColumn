using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #PMc
{
	// Token: 0x02000BD6 RID: 3030
	internal static class #UMc
	{
		// Token: 0x060062D1 RID: 25297 RVA: 0x00181750 File Offset: 0x0017F950
		public static #kNc #TMc(IEnumerable<ShapeDataModel> #6Y, Point3D #HAb)
		{
			string #R0d = #Phc.#3hc(107372113);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107413735);
			if (!false)
			{
				#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
			}
			ShapeDataModel shapeDataModel = null;
			ShapeDataModel #rP;
			if (3 != 0)
			{
				#rP = shapeDataModel;
			}
			PolygonData polygonData = null;
			PolygonData polygonData2;
			if (true)
			{
				polygonData2 = polygonData;
			}
			int num = -1;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			List<Point3D> list = null;
			List<Point3D> list2;
			if (2 != 0)
			{
				list2 = list;
			}
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			int #mNc = -1;
			foreach (ShapeDataModel shapeDataModel2 in #6Y)
			{
				int num3 = 0;
				for (;;)
				{
					IL_D5:
					int i = num3;
					int num4 = shapeDataModel2.PolygonsCount;
					IL_DE:
					while (i < num4)
					{
						PolygonData polygonData3 = shapeDataModel2.#cxc(num3);
						List<Point3D> list3 = new List<Point3D>(polygonData3.Points3D);
						for (;;)
						{
							IL_80:
							int j = 0;
							while (j < list3.Count)
							{
								int num6;
								int num5;
								if (PointsConverter.#uC(list3[j], #HAb))
								{
									#rP = shapeDataModel2;
									if (!false)
									{
										polygonData2 = polygonData3;
										flag2 = true;
										num5 = (num6 = (i = j));
										goto IL_A4;
									}
									goto IL_D5;
								}
								else
								{
									num5 = (num6 = (i = j));
								}
								IL_B6:
								if (!false)
								{
									int num7 = num4 = 1;
									if (num7 != 0)
									{
										j = num5 + num7;
										continue;
									}
									goto IL_DE;
								}
								IL_A4:
								if (5 == 0)
								{
									goto IL_B6;
								}
								num2 = num6;
								list2 = list3;
								if (-1 != 0)
								{
									goto Block_8;
								}
								goto IL_80;
							}
							break;
						}
						IL_CB:
						if (!flag2)
						{
							num3++;
							goto IL_D5;
						}
						break;
						Block_8:
						#mNc = num3;
						goto IL_CB;
					}
					break;
				}
				if (flag2)
				{
					break;
				}
			}
			if (polygonData2 == null || num2 < 0)
			{
				return null;
			}
			List<int> list4 = new List<int>();
			int #nNc;
			int #oNc;
			if (num2 == 0 || num2 == list2.Count - 1)
			{
				list4.Add(0);
				list4.Add(list2.Count - 1);
				#nNc = 1;
				#oNc = list2.Count - 2;
			}
			else
			{
				list4.Add(num2);
				#nNc = num2 - 1;
				#oNc = num2 + 1;
			}
			return new #kNc(#rP, polygonData2, list2, list4, #mNc, num2, #nNc, #oNc);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #7Tc
{
	// Token: 0x02000C6D RID: 3181
	internal static class #6Tc
	{
		// Token: 0x0600668B RID: 26251 RVA: 0x0005268C File Offset: 0x0005088C
		private static bool #QTc(double #f, double #GT, double #HT)
		{
			return #f >= #GT && #f < #HT;
		}

		// Token: 0x0600668C RID: 26252 RVA: 0x00190B2C File Offset: 0x0018ED2C
		public static MoveMode #RTc(SegmentData #PP)
		{
			string #R0d = #Phc.#3hc(107368915);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107441156);
			if (2 != 0)
			{
				#X0d.#V0d(#PP, #R0d, #x6c, #Qic);
			}
			Point point = #PP.StartPoint;
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			if (7 == 0)
			{
				goto IL_17C;
			}
			double val = point2.X;
			Point point3 = #PP.EndPoint;
			if (!false)
			{
				point2 = point3;
			}
			double #8mc = Math.Min(val, point2.X);
			Point point4 = #PP.StartPoint;
			if (!false)
			{
				point2 = point4;
			}
			double val2 = point2.Y;
			Point point5 = #PP.EndPoint;
			if (-1 != 0)
			{
				point2 = point5;
			}
			double num = Math.Min(val2, point2.Y);
			double #9mc;
			if (!false)
			{
				#9mc = num;
			}
			IL_87:
			point2 = #PP.EndPoint;
			double val3 = point2.X;
			point2 = #PP.StartPoint;
			IL_9E:
			double #anc = Math.Max(val3, point2.X);
			point2 = #PP.EndPoint;
			double val4 = point2.Y;
			point2 = #PP.StartPoint;
			double #bnc = Math.Max(val4, point2.Y);
			if (8 == 0)
			{
				goto IL_87;
			}
			double num2 = GeometryHelper.#knc(#8mc, #9mc, #anc, #bnc);
			if (num2 != 360.0)
			{
				goto IL_F1;
			}
			double num3 = 0.0;
			IL_F0:
			num2 = num3;
			IL_F1:
			if (num2 < 0.0)
			{
				double num4 = num3 = 360.0 + num2;
				if (false)
				{
					goto IL_F0;
				}
				num2 = num4;
			}
			if (#6Tc.#QTc(num2, 0.0, 45.0))
			{
				return MoveMode.X;
			}
			if (#6Tc.#QTc(num2, 45.0, 135.0))
			{
				return MoveMode.Y;
			}
			if (#6Tc.#QTc(num2, 135.0, 225.0))
			{
				return MoveMode.X;
			}
			bool flag = #6Tc.#QTc(num2, 225.0, 315.0);
			IL_178:
			if (flag)
			{
				return MoveMode.Y;
			}
			IL_17C:
			double #f = #8mc = num2;
			double #GT = val3 = 315.0;
			if (3 == 0)
			{
				goto IL_9E;
			}
			bool flag2 = flag = #6Tc.#QTc(#f, #GT, 360.0);
			if (false)
			{
				goto IL_178;
			}
			if (flag2)
			{
				return MoveMode.X;
			}
			return MoveMode.FreeDefault;
		}

		// Token: 0x0600668D RID: 26253 RVA: 0x00190D08 File Offset: 0x0018EF08
		public static MoveMode #RTc(IList<SegmentData> #STc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.DesktopControls;
				string #Qic = #Phc.#3hc(107441615);
				if (2 != 0)
				{
					#X0d.#V0d(#STc, #R0d, #x6c, #Qic);
				}
				while (#STc.Any<SegmentData>())
				{
					int num = 1;
					int num2;
					if (!false)
					{
						num2 = num;
					}
					for (;;)
					{
						SegmentData segmentData2;
						SegmentData segmentData4;
						if (num2 >= #STc.Count)
						{
							if (-1 != 0)
							{
								goto Block_5;
							}
						}
						else
						{
							SegmentData segmentData = #STc[num2 - 1];
							if (8 != 0)
							{
								segmentData2 = segmentData;
							}
							SegmentData segmentData3 = #STc[num2];
							if (!false)
							{
								segmentData4 = segmentData3;
							}
						}
						GeneralLineEquation generalLineEquation = new GeneralLineEquation(segmentData2.StartPoint, segmentData2.EndPoint);
						GeneralLineEquation generalLineEquation2 = new GeneralLineEquation(segmentData4.StartPoint, segmentData4.EndPoint);
						GeneralLineEquation #L;
						if (true)
						{
							#L = generalLineEquation2;
						}
						if (!generalLineEquation.#slc(#L, true) || 4 == 0)
						{
							break;
						}
						int num3 = num2 + 1;
						if (5 != 0)
						{
							num2 = num3;
						}
					}
					if (5 != 0)
					{
						return MoveMode.FreeDefault;
					}
				}
			}
			while (6 == 0);
			return MoveMode.FreeDefault;
			Block_5:
			return #6Tc.#RTc(#STc.First<SegmentData>());
		}

		// Token: 0x0600668E RID: 26254 RVA: 0x00052698 File Offset: 0x00050898
		public static Point #TTc(Point #UTc, Point #Xqc)
		{
			double num;
			double xField = num = #UTc.X;
			double num3;
			for (;;)
			{
				double num2 = num3 = #Xqc.X;
				if (false)
				{
					break;
				}
				xField = (num += num2);
				if (true)
				{
					goto Block_2;
				}
			}
			double yField;
			do
			{
				IL_1C:
				yField = (num3 += #Xqc.Y);
			}
			while (3 == 0);
			return new Point(xField, yField);
			Block_2:
			num3 = #UTc.Y;
			goto IL_1C;
		}

		// Token: 0x0600668F RID: 26255 RVA: 0x00190DE4 File Offset: 0x0018EFE4
		public static double? #VTc(Point #Xrb, double #Udb, double #WTc, double #XTc, double #YTc, double #ZTc)
		{
			if (!true)
			{
				goto IL_82;
			}
			double #8mc;
			double num2;
			double num = num2 = (#8mc = #XTc * #XTc);
			if (6 == 0)
			{
				goto IL_92;
			}
			double num4;
			if (true)
			{
				double num3 = Math.Sqrt(num + #ZTc * #ZTc);
				if (5 != 0)
				{
					num4 = num3;
				}
				num2 = #Xrb.X;
			}
			if (num2 != 0.0)
			{
				goto IL_4C;
			}
			IL_33:
			if (#Xrb.Y == 0.0)
			{
				return new double?(num4);
			}
			IL_4C:
			Point point = #6Tc.#2Tc(#Xrb, num4 + 1.0, #Udb);
			Point endPoint;
			if (7 != 0)
			{
				endPoint = point;
			}
			SegmentData #Ztc = new SegmentData(#Xrb, endPoint);
			IList<SegmentData> list = #6Tc.#5Tc(#WTc, #XTc, #YTc, #ZTc);
			IList<SegmentData> #4Tc;
			if (-1 != 0)
			{
				#4Tc = list;
			}
			Point? point2 = #6Tc.#3Tc(#Ztc, #4Tc);
			Point? point3;
			if (!false)
			{
				point3 = point2;
			}
			IL_82:
			if (point3 != null)
			{
				#8mc = #Xrb.X;
			}
			else
			{
				if (!false)
				{
					return null;
				}
				goto IL_33;
			}
			IL_92:
			double #9mc = #Xrb.Y;
			Point value = point3.Value;
			Point point4;
			if (!false)
			{
				point4 = value;
			}
			double #anc = point4.X;
			Point value2 = point3.Value;
			if (5 != 0)
			{
				point4 = value2;
			}
			return new double?(GeometryHelper.#7mc(#8mc, #9mc, #anc, point4.Y));
		}

		// Token: 0x06006690 RID: 26256 RVA: 0x00190EE4 File Offset: 0x0018F0E4
		public static double #0Tc(double #8mc, double #9mc, double #anc, double #bnc)
		{
			double y = #bnc;
			double num = #bnc;
			double result;
			for (;;)
			{
				double num2 = #9mc;
				if (8 != 0)
				{
					y = num - #9mc;
					goto IL_06;
				}
				IL_07:
				double num3 = num2 - #8mc;
				double x;
				if (7 != 0)
				{
					x = num3;
				}
				double #9Ab = num = (y = Math.Atan2(y, x));
				if (false)
				{
					continue;
				}
				result = (y = GeometryHelper.#Pmc(#9Ab));
				if (!false)
				{
					break;
				}
				IL_06:
				num2 = #anc;
				goto IL_07;
			}
			return result;
		}

		// Token: 0x06006691 RID: 26257 RVA: 0x00190F14 File Offset: 0x0018F114
		public static double #0Tc(Point #mcb, Point #ncb, Point #Ckc)
		{
			double y;
			double num = y = #ncb.X - #mcb.X;
			double y2;
			double num2 = y2 = #ncb.Y;
			if (false)
			{
				goto IL_38;
			}
			double x = num2 - #mcb.Y;
			IL_21:
			double result;
			num = (y = (result = Math.Atan2(y, x)));
			if (false)
			{
				return result;
			}
			y2 = #Ckc.X - #mcb.X;
			IL_38:
			double num3 = x = Math.Atan2(y2, #Ckc.Y - #mcb.Y);
			if (4 == 0)
			{
				goto IL_21;
			}
			double num4;
			if (!false)
			{
				num4 = num3;
			}
			result = num - num4;
			return result;
		}

		// Token: 0x06006692 RID: 26258 RVA: 0x000526C6 File Offset: 0x000508C6
		public static double #0Tc(Point #mcb, Point #ncb)
		{
			double num = #ncb.Y;
			double result;
			for (;;)
			{
				double num2 = #mcb.Y;
				double y;
				double num3;
				for (;;)
				{
					y = (num = (result = num - num2));
					if (false)
					{
						break;
					}
					num3 = (num2 = #ncb.X);
					if (!false)
					{
						goto Block_2;
					}
				}
				IL_29:
				if (!false)
				{
					break;
				}
				continue;
				Block_2:
				result = (num = Math.Atan2(y, num3 - #mcb.X));
				goto IL_29;
			}
			return result;
		}

		// Token: 0x06006693 RID: 26259 RVA: 0x000526F4 File Offset: 0x000508F4
		public static double #1Tc(double #8mc, double #9mc, double #anc, double #bnc)
		{
			return Math.Abs(GeometryHelper.#7mc(#8mc, #9mc, #anc, #bnc));
		}

		// Token: 0x06006694 RID: 26260 RVA: 0x00052704 File Offset: 0x00050904
		public static Point #2Tc(Point #wob, double #HS, double #Udb)
		{
			return GeometryHelper.#4nc(#wob, #HS, #Udb);
		}

		// Token: 0x06006695 RID: 26261 RVA: 0x00190F7C File Offset: 0x0018F17C
		private static Point? #3Tc(SegmentData #Ztc, IList<SegmentData> #4Tc)
		{
			Point? result = null;
			IEnumerator<SegmentData> enumerator = #4Tc.GetEnumerator();
			IEnumerator<SegmentData> enumerator2;
			if (5 != 0)
			{
				enumerator2 = enumerator;
				goto IL_12;
			}
			try
			{
				for (;;)
				{
					IL_12:
					while (enumerator2.MoveNext())
					{
						SegmentData segmentData = enumerator2.Current;
						SegmentData #Vrc;
						if (!false)
						{
							#Vrc = segmentData;
						}
						if (!false)
						{
							Point? point = #jsc.#plc(#Ztc, #Vrc);
							if (3 != 0)
							{
								result = point;
							}
							if (result != null)
							{
								goto Block_3;
							}
						}
					}
					goto IL_42;
				}
				Block_3:
				if (!false)
				{
				}
				IL_42:;
			}
			finally
			{
				while (enumerator2 != null)
				{
					if (!false)
					{
						enumerator2.Dispose();
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06006696 RID: 26262 RVA: 0x00190FF4 File Offset: 0x0018F1F4
		private static IList<SegmentData> #5Tc(double #WTc, double #XTc, double #YTc, double #ZTc)
		{
			double xField = #XTc;
			double yField = #YTc;
			SegmentData item;
			SegmentData item2;
			double xField2;
			for (;;)
			{
				SegmentData segmentData = new SegmentData(new Point(xField, yField), new Point(#XTc, #ZTc));
				if (6 != 0)
				{
					item = segmentData;
				}
				xField = #WTc;
				yField = #YTc;
				if (!false)
				{
					SegmentData segmentData2 = new SegmentData(new Point(#WTc, #YTc), new Point(#WTc, #ZTc));
					if (true)
					{
						item2 = segmentData2;
					}
					xField2 = #WTc;
					xField = #WTc;
					if (4 == 0)
					{
						goto IL_4F;
					}
					yField = #ZTc;
					if (true)
					{
						break;
					}
				}
			}
			SegmentData segmentData3 = new SegmentData(new Point(#WTc, #ZTc), new Point(#XTc, #ZTc));
			SegmentData item3;
			if (4 != 0)
			{
				item3 = segmentData3;
			}
			xField2 = #WTc;
			IL_4F:
			SegmentData segmentData4 = new SegmentData(new Point(xField2, #YTc), new Point(#XTc, #YTc));
			SegmentData segmentData5;
			if (2 != 0)
			{
				segmentData5 = segmentData4;
			}
			List<SegmentData> list = new List<SegmentData>();
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			SegmentData item4 = segmentData5;
			if (true)
			{
				list.Add(item4);
			}
			return list;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #4vc;
using #7hc;
using #u3d;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Fmc
{
	// Token: 0x020007D6 RID: 2006
	internal static class #jsc
	{
		// Token: 0x0600408C RID: 16524 RVA: 0x0012CF24 File Offset: 0x0012B124
		public static IList<SegmentData> #Rrc(IList<Point> #BP)
		{
			List<SegmentData> list;
			for (;;)
			{
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107365759));
				for (;;)
				{
					list = new List<SegmentData>();
					int num3;
					int num2;
					int num = num2 = (num3 = #BP.Count);
					int num5;
					int num4 = num5 = 1;
					if (num4 == 0)
					{
						goto IL_67;
					}
					if (num < num4)
					{
						return list;
					}
					Point startPoint = #BP[0];
					int num6 = 1;
					goto IL_6C;
					IL_76:
					int num7;
					if (num3 >= num7)
					{
						break;
					}
					Point point = #BP[num6];
					if (false)
					{
						continue;
					}
					list.Add(new SegmentData(startPoint, point));
					startPoint = point;
					num3 = (num2 = num6);
					num5 = 1;
					IL_67:
					int num8 = num7 = num5;
					int num9;
					if (num8 != 0)
					{
						num9 = num2 + num8;
						goto IL_6B;
					}
					goto IL_76;
					IL_6C:
					num3 = (num9 = num6);
					if (7 != 0)
					{
						num7 = #BP.Count;
						goto IL_76;
					}
					IL_6B:
					num6 = num9;
					goto IL_6C;
				}
				if (!false)
				{
					return list;
				}
			}
			return list;
		}

		// Token: 0x0600408D RID: 16525 RVA: 0x00036686 File Offset: 0x00034886
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public static bool #Src(SegmentData #PP, Point #Ng)
		{
			return #jsc.#Src(#PP, #Ng, false);
		}

		// Token: 0x0600408E RID: 16526 RVA: 0x0003669C File Offset: 0x0003489C
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public static bool #vlc(SegmentData #PP, Point #Ng)
		{
			return #jsc.#vlc(#PP, #Ng, false);
		}

		// Token: 0x0600408F RID: 16527 RVA: 0x000366B2 File Offset: 0x000348B2
		public static bool #Src(Point #mcb, Point #ncb, Point #Ckc)
		{
			return #jsc.#Src(#mcb, #ncb, #Ckc, false);
		}

		// Token: 0x06004090 RID: 16528 RVA: 0x0012CFFC File Offset: 0x0012B1FC
		public static bool #vlc(Point #mcb, Point #ncb, Point #Ckc, bool #tlc)
		{
			double #f;
			while (8 != 0)
			{
				#f = #jsc.#Yrc(#mcb, #ncb, #Ckc);
				bool result = #tlc;
				if (2 == 0)
				{
					return result;
				}
				if (#tlc)
				{
					break;
				}
				if (5 != 0 && !false)
				{
					return #Emc.#U3(#f);
				}
			}
			return #Emc.#Bmc(#f);
		}

		// Token: 0x06004091 RID: 16529 RVA: 0x000366CD File Offset: 0x000348CD
		public static bool #vlc(Point #mcb, Point #ncb, Point #Ckc, double #1Mb)
		{
			return \u0006\u0002.\u0006\u0004(#jsc.#Yrc(#mcb, #ncb, #Ckc)) < #1Mb;
		}

		// Token: 0x06004092 RID: 16530 RVA: 0x0012D054 File Offset: 0x0012B254
		public unsafe static bool #Src(Point #Xrb, Point #Yrb, Point #Ng, bool #tlc)
		{
			void* ptr = stackalloc byte[72];
			*(double*)ptr = #Xrb.X;
			*(double*)(ptr + 8) = #Xrb.Y;
			*(double*)(ptr + 16) = #Yrb.X;
			*(double*)(ptr + 24) = #Yrb.Y;
			*(double*)((byte*)ptr + 32) = #Ng.X;
			*(double*)((byte*)ptr + 40) = #Ng.Y;
			*(double*)((byte*)ptr + 48) = #jsc.#Yrc(*(double*)ptr, *(double*)((byte*)ptr + 8), *(double*)((byte*)ptr + 32), *(double*)((byte*)ptr + 40), *(double*)((byte*)ptr + 16), *(double*)((byte*)ptr + 24));
			bool flag;
			double num;
			if (!#tlc)
			{
				flag = #Emc.#U3(*(double*)((byte*)ptr + 48));
			}
			else
			{
				double #f = num = *(double*)((byte*)ptr + 48);
				if (6 == 0)
				{
					goto IL_121;
				}
				flag = #Emc.#Bmc(#f);
			}
			if (!flag)
			{
				return false;
			}
			*(double*)((byte*)ptr + 56) = (*(double*)((byte*)ptr + 32) - *(double*)ptr) * (*(double*)((byte*)ptr + 16) - *(double*)ptr) + (*(double*)((byte*)ptr + 40) - *(double*)((byte*)ptr + 8)) * (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8));
			if (*(double*)((byte*)ptr + 56) < 0.0 && !#Emc.#Bmc(*(double*)((byte*)ptr + 56)))
			{
				return false;
			}
			*(double*)((byte*)ptr + 64) = (*(double*)((byte*)ptr + 16) - *(double*)ptr) * (*(double*)((byte*)ptr + 16) - *(double*)ptr) + (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8)) * (*(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 8));
			num = *(double*)((byte*)ptr + 56);
			IL_121:
			return num <= *(double*)((byte*)ptr + 64) || #Emc.#Amc(*(double*)((byte*)ptr + 56), *(double*)((byte*)ptr + 64));
		}

		// Token: 0x06004093 RID: 16531 RVA: 0x0012D1E8 File Offset: 0x0012B3E8
		public static bool #Src(SegmentData #PP, Point #Ng, bool #tlc)
		{
			#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107365674));
			return #jsc.#Src(#PP.StartPoint, #PP.EndPoint, #Ng, #tlc);
		}

		// Token: 0x06004094 RID: 16532 RVA: 0x0012D248 File Offset: 0x0012B448
		public static bool #vlc(SegmentData #PP, Point #Ng, bool #tlc)
		{
			#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107365674));
			return #jsc.#vlc(#PP.StartPoint, #PP.EndPoint, #Ng, #tlc);
		}

		// Token: 0x06004095 RID: 16533 RVA: 0x0012D2A8 File Offset: 0x0012B4A8
		public static bool #Trc(SegmentData #Urc, SegmentData #Vrc, bool #tlc)
		{
			#X0d.#V0d(#Urc, #Phc.#3hc(107365653), Component.Geometry, #Phc.#3hc(107365096));
			#X0d.#V0d(#Vrc, #Phc.#3hc(107365075), Component.Geometry, #Phc.#3hc(107365030));
			while (#jsc.#vlc(#Urc, #Vrc.StartPoint, #tlc) && #jsc.#vlc(#Urc, #Vrc.EndPoint, #tlc))
			{
				if (#jsc.#Wrc(#Urc, #Vrc))
				{
					return true;
				}
				bool flag2;
				bool flag = flag2 = #jsc.#Xrc(#Urc, #Vrc);
				if (false)
				{
					goto IL_209;
				}
				if (flag)
				{
					return true;
				}
				Vector vector;
				Vector vector2;
				if (!#Emc.#Amc(#Vrc.StartPoint.X, #Urc.StartPoint.X) || !#Emc.#Amc(#Vrc.StartPoint.Y, #Urc.StartPoint.Y))
				{
					if (#Emc.#Amc(#Vrc.EndPoint.X, #Urc.EndPoint.X))
					{
						if (false)
						{
							continue;
						}
						if (#Emc.#Amc(#Vrc.EndPoint.Y, #Urc.EndPoint.Y))
						{
							vector = Point.#H3d(#Urc.StartPoint, #Urc.EndPoint);
							vector2 = Point.#H3d(#Vrc.StartPoint, #Vrc.EndPoint);
							if (3 == 0)
							{
								goto IL_2FF;
							}
							vector.#wlc();
							if (!false)
							{
								vector2.#wlc();
								goto IL_1B6;
							}
							goto IL_1B6;
						}
					}
					flag2 = #Emc.#Amc(#Vrc.EndPoint.X, #Urc.StartPoint.X);
					goto IL_209;
				}
				Vector vector3 = Point.#H3d(#Urc.EndPoint, #Urc.StartPoint);
				Vector vector4 = Point.#H3d(#Vrc.EndPoint, #Vrc.StartPoint);
				vector3.#wlc();
				vector4.#wlc();
				if (!#Emc.#Amc(vector3.X, vector4.X))
				{
					goto IL_352;
				}
				double #4gb = vector3.Y;
				double #5gb = vector4.Y;
				IL_11F:
				if (#Emc.#Amc(#4gb, #5gb))
				{
					return true;
				}
				goto IL_352;
				IL_1B6:
				if (#Emc.#Amc(vector.X, vector2.X) && #Emc.#Amc(vector.Y, vector2.Y))
				{
					return true;
				}
				goto IL_352;
				IL_209:
				if (!flag2)
				{
					goto IL_2A3;
				}
				double #4gb2 = #Vrc.EndPoint.Y;
				double #5gb2 = #Urc.StartPoint.Y;
				IL_22A:
				if (!#Emc.#Amc(#4gb2, #5gb2))
				{
					goto IL_2A3;
				}
				Vector vector5 = Point.#H3d(#Urc.EndPoint, #Urc.StartPoint);
				IL_244:
				Vector vector6 = Point.#H3d(#Vrc.StartPoint, #Vrc.EndPoint);
				vector5.#wlc();
				vector6.#wlc();
				double #4gb3 = #4gb = vector5.X;
				double #5gb3 = #5gb = vector6.X;
				if (4 == 0)
				{
					goto IL_11F;
				}
				if (!#Emc.#Amc(#4gb3, #5gb3))
				{
					goto IL_352;
				}
				if (7 == 0)
				{
					goto IL_1B6;
				}
				if (#Emc.#Amc(vector5.Y, vector6.Y))
				{
					return true;
				}
				goto IL_352;
				IL_2A3:
				if (!#Emc.#Amc(#Vrc.StartPoint.X, #Urc.EndPoint.X) || !#Emc.#Amc(#Vrc.StartPoint.Y, #Urc.EndPoint.Y))
				{
					goto IL_352;
				}
				Vector vector7 = Point.#H3d(#Urc.StartPoint, #Urc.EndPoint);
				IL_2FF:
				Vector vector8 = Point.#H3d(#Vrc.EndPoint, #Vrc.StartPoint);
				vector7.#wlc();
				vector8.#wlc();
				double #4gb4 = #4gb2 = vector7.X;
				double #5gb4 = #5gb2 = vector8.X;
				if (false)
				{
					goto IL_22A;
				}
				if (#Emc.#Amc(#4gb4, #5gb4) && #Emc.#Amc(vector7.Y, vector8.Y))
				{
					return true;
				}
				IL_352:
				if (true)
				{
					return false;
				}
				goto IL_244;
			}
			return false;
		}

		// Token: 0x06004096 RID: 16534 RVA: 0x0012D65C File Offset: 0x0012B85C
		private static bool #Wrc(SegmentData #Urc, SegmentData #Vrc)
		{
			Point point = #Vrc.StartPoint;
			double num2;
			double num = num2 = point.X;
			double #4gb2;
			double #5gb2;
			if (!false)
			{
				point = #Urc.StartPoint;
				if (num <= point.X || false)
				{
					goto IL_145;
				}
				point = #Vrc.StartPoint;
				double #4gb = #4gb2 = point.X;
				point = #Urc.StartPoint;
				double #5gb = #5gb2 = point.X;
				if (-1 == 0)
				{
					goto IL_24E;
				}
				if (#Emc.#Amc(#4gb, #5gb))
				{
					goto IL_145;
				}
				point = #Vrc.StartPoint;
				num2 = point.X;
			}
			point = #Urc.EndPoint;
			bool flag2;
			if (num2 < point.X)
			{
				point = #Vrc.StartPoint;
				double #4gb3 = point.X;
				point = #Urc.EndPoint;
				if (!#Emc.#Amc(#4gb3, point.X))
				{
					point = #Vrc.StartPoint;
					double num3 = point.Y;
					point = #Urc.StartPoint;
					if (num3 > point.Y)
					{
						point = #Vrc.StartPoint;
						if (6 != 0)
						{
							if (false)
							{
								goto IL_1DA;
							}
							double #4gb4 = point.Y;
							point = #Urc.StartPoint;
							if (#Emc.#Amc(#4gb4, point.Y))
							{
								goto IL_145;
							}
							point = #Vrc.StartPoint;
							double num4 = point.Y;
							point = #Urc.EndPoint;
							if (num4 >= point.Y)
							{
								goto IL_145;
							}
							point = #Vrc.StartPoint;
							double #4gb5 = point.Y;
							point = #Urc.EndPoint;
							bool flag = flag2 = #Emc.#Amc(#4gb5, point.Y);
							if (false)
							{
								goto IL_187;
							}
							if (flag)
							{
								goto IL_145;
							}
						}
						return true;
					}
				}
			}
			IL_145:
			point = #Vrc.StartPoint;
			double num5 = point.X;
			point = #Urc.StartPoint;
			if (num5 >= point.X)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			double #4gb6 = point.X;
			point = #Urc.StartPoint;
			flag2 = #Emc.#Amc(#4gb6, point.X);
			IL_187:
			if (flag2)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			double num6 = point.X;
			point = #Urc.EndPoint;
			if (num6 <= point.X)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			double #4gb7 = point.X;
			point = #Urc.EndPoint;
			int num7 = #Emc.#Amc(#4gb7, point.X) ? 1 : 0;
			IL_1CE:
			if (num7 != 0)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			IL_1DA:
			double num8 = point.Y;
			point = #Urc.StartPoint;
			if (num8 >= point.Y)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			double #4gb8 = point.Y;
			point = #Urc.StartPoint;
			if (#Emc.#Amc(#4gb8, point.Y))
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			double num9 = point.Y;
			point = #Urc.EndPoint;
			if (num9 <= point.Y)
			{
				goto IL_257;
			}
			point = #Vrc.StartPoint;
			#4gb2 = point.Y;
			point = #Urc.EndPoint;
			#5gb2 = point.Y;
			IL_24E:
			return !#Emc.#Amc(#4gb2, #5gb2);
			IL_257:
			int num10 = num7 = 0;
			if (num10 == 0)
			{
				return num10 != 0;
			}
			goto IL_1CE;
		}

		// Token: 0x06004097 RID: 16535 RVA: 0x0012D910 File Offset: 0x0012BB10
		private static bool #Xrc(SegmentData #Urc, SegmentData #Vrc)
		{
			Point point = #Vrc.EndPoint;
			double num2;
			double num = num2 = point.X;
			double #4gb2;
			double #5gb2;
			if (!false)
			{
				point = #Urc.StartPoint;
				if (num <= point.X || false)
				{
					goto IL_145;
				}
				point = #Vrc.EndPoint;
				double #4gb = #4gb2 = point.X;
				point = #Urc.StartPoint;
				double #5gb = #5gb2 = point.X;
				if (-1 == 0)
				{
					goto IL_24E;
				}
				if (#Emc.#Amc(#4gb, #5gb))
				{
					goto IL_145;
				}
				point = #Vrc.EndPoint;
				num2 = point.X;
			}
			point = #Urc.EndPoint;
			bool flag2;
			if (num2 < point.X)
			{
				point = #Vrc.EndPoint;
				double #4gb3 = point.X;
				point = #Urc.EndPoint;
				if (!#Emc.#Amc(#4gb3, point.X))
				{
					point = #Vrc.EndPoint;
					double num3 = point.Y;
					point = #Urc.StartPoint;
					if (num3 > point.Y)
					{
						point = #Vrc.EndPoint;
						if (6 != 0)
						{
							if (false)
							{
								goto IL_1DA;
							}
							double #4gb4 = point.Y;
							point = #Urc.StartPoint;
							if (#Emc.#Amc(#4gb4, point.Y))
							{
								goto IL_145;
							}
							point = #Vrc.EndPoint;
							double num4 = point.Y;
							point = #Urc.EndPoint;
							if (num4 >= point.Y)
							{
								goto IL_145;
							}
							point = #Vrc.EndPoint;
							double #4gb5 = point.Y;
							point = #Urc.EndPoint;
							bool flag = flag2 = #Emc.#Amc(#4gb5, point.Y);
							if (false)
							{
								goto IL_187;
							}
							if (flag)
							{
								goto IL_145;
							}
						}
						return true;
					}
				}
			}
			IL_145:
			point = #Vrc.EndPoint;
			double num5 = point.X;
			point = #Urc.StartPoint;
			if (num5 >= point.X)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			double #4gb6 = point.X;
			point = #Urc.StartPoint;
			flag2 = #Emc.#Amc(#4gb6, point.X);
			IL_187:
			if (flag2)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			double num6 = point.X;
			point = #Urc.EndPoint;
			if (num6 <= point.X)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			double #4gb7 = point.X;
			point = #Urc.EndPoint;
			int num7 = #Emc.#Amc(#4gb7, point.X) ? 1 : 0;
			IL_1CE:
			if (num7 != 0)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			IL_1DA:
			double num8 = point.Y;
			point = #Urc.StartPoint;
			if (num8 >= point.Y)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			double #4gb8 = point.Y;
			point = #Urc.StartPoint;
			if (#Emc.#Amc(#4gb8, point.Y))
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			double num9 = point.Y;
			point = #Urc.EndPoint;
			if (num9 <= point.Y)
			{
				goto IL_257;
			}
			point = #Vrc.EndPoint;
			#4gb2 = point.Y;
			point = #Urc.EndPoint;
			#5gb2 = point.Y;
			IL_24E:
			return !#Emc.#Amc(#4gb2, #5gb2);
			IL_257:
			int num10 = num7 = 0;
			if (num10 == 0)
			{
				return num10 != 0;
			}
			goto IL_1CE;
		}

		// Token: 0x06004098 RID: 16536 RVA: 0x0012DBC4 File Offset: 0x0012BDC4
		public static double #Yrc(Point #mcb, Point #ncb, Point #Ckc)
		{
			double num3;
			double num2;
			double num = num2 = (num3 = #mcb.X);
			double num7;
			double num12;
			for (;;)
			{
				double num6;
				double num5;
				double num4 = num5 = (num6 = (num7 = #Ckc.X));
				double num11;
				if (6 != 0)
				{
					double num8 = num2 = (num = (num3 = num2 - num4));
					double num9 = num5 = #ncb.Y;
					double num10 = num11 = #Ckc.Y;
					if (!false)
					{
						num = (num2 = (num3 = num8 * (num9 - num10)));
						num5 = #mcb.Y;
						goto IL_1D;
					}
					goto IL_21;
				}
				IL_22:
				if (false)
				{
					goto IL_42;
				}
				if (3 == 0)
				{
					goto IL_1D;
				}
				num12 = num6 * (#ncb.X - #Ckc.X);
				if (!false)
				{
					break;
				}
				continue;
				IL_21:
				num6 = (num5 = (num7 = num5 - num11));
				goto IL_22;
				IL_1D:
				num11 = #Ckc.Y;
				goto IL_21;
			}
			num3 = num - num12;
			num7 = 2.0;
			IL_42:
			return num3 / num7;
		}

		// Token: 0x06004099 RID: 16537 RVA: 0x0012DC50 File Offset: 0x0012BE50
		public static double #Yrc(double #Zrc, double #0rc, double #1rc, double #2rc, double #3rc, double #4rc)
		{
			double num = #Zrc;
			double num2 = #3rc;
			double num4;
			double num3;
			do
			{
				num3 = (num = (num4 = num - num2));
				if (7 == 0)
				{
					goto IL_26;
				}
				num2 = #2rc;
			}
			while (4 == 0);
			double result;
			double num5 = result = num3 * (#2rc - #4rc);
			if (4 == 0)
			{
				return result;
			}
			double num6 = #0rc;
			double num7 = #4rc;
			if (!false)
			{
				num6 = #0rc - #4rc;
				num7 = #1rc;
			}
			double num8 = num6 * (num7 - #3rc);
			num4 = num5 - num8;
			IL_26:
			result = num4 / 2.0;
			return result;
		}

		// Token: 0x0600409A RID: 16538 RVA: 0x0012DCAC File Offset: 0x0012BEAC
		public static Point? #5rc(SegmentData #Urc, SegmentData #Vrc)
		{
			#X0d.#V0d(#Urc, #Phc.#3hc(107365653), Component.Geometry, #Phc.#3hc(107365009));
			#X0d.#V0d(#Vrc, #Phc.#3hc(107365075), Component.Geometry, #Phc.#3hc(107364956));
			if (#jsc.#Src(#Urc, #Vrc.StartPoint))
			{
				return new Point?(#Vrc.StartPoint);
			}
			if (#jsc.#Src(#Urc, #Vrc.EndPoint))
			{
				if (!false)
				{
					return new Point?(#Vrc.EndPoint);
				}
				goto IL_93;
			}
			else if (!#jsc.#Src(#Vrc, #Urc.StartPoint))
			{
				goto IL_93;
			}
			IL_87:
			return new Point?(#Urc.StartPoint);
			IL_93:
			if (#jsc.#Src(#Vrc, #Urc.EndPoint))
			{
				return new Point?(#Urc.EndPoint);
			}
			if (-1 != 0)
			{
				return null;
			}
			goto IL_87;
		}

		// Token: 0x0600409B RID: 16539 RVA: 0x000366FC File Offset: 0x000348FC
		public static Point? #plc(SegmentData #Urc, SegmentData #Vrc)
		{
			return #jsc.#plc(#Urc, #Vrc, false);
		}

		// Token: 0x0600409C RID: 16540 RVA: 0x0012DDC0 File Offset: 0x0012BFC0
		public static Point? #6rc(SegmentData #Urc, SegmentData #Vrc)
		{
			#X0d.#V0d(#Urc, #Phc.#3hc(107365653), Component.Geometry, #Phc.#3hc(107364871));
			string #R0d = #Phc.#3hc(107365075);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107365362);
			if (4 != 0)
			{
				#X0d.#V0d(#Vrc, #R0d, #x6c, #Qic);
			}
			Point? result = #jsc.#plc(#Urc, #Vrc, false);
			if (result == null)
			{
				return null;
			}
			Point point = result.Value;
			double num2;
			double num = num2 = point.X;
			if (false)
			{
				goto IL_106;
			}
			double num3 = Math.Abs(num - #Urc.StartPoint.X);
			double #d = #Emc.#d;
			IL_91:
			if (num3 >= #d)
			{
				goto IL_C6;
			}
			point = result.Value;
			IL_9B:
			double num4;
			num2 = (num4 = point.Y);
			point = #Urc.StartPoint;
			IL_A9:
			double num6;
			double num5 = num6 = point.Y;
			if (false)
			{
				goto IL_10D;
			}
			double num7 = num2 = Math.Abs(num4 - num5);
			double num8 = num6 = #Emc.#d;
			if (5 == 0)
			{
				goto IL_10D;
			}
			if (num7 < num8)
			{
				goto IL_1D4;
			}
			IL_C6:
			if (Math.Abs(result.Value.X - #Urc.EndPoint.X) >= #Emc.#d)
			{
				goto IL_11D;
			}
			num2 = result.Value.Y;
			point = #Urc.EndPoint;
			IL_106:
			num6 = point.Y;
			IL_10D:
			if (Math.Abs(num2 - num6) < #Emc.#d)
			{
				goto IL_1D4;
			}
			IL_11D:
			double num10;
			double num12;
			if (Math.Abs(result.Value.X - #Vrc.StartPoint.X) < #Emc.#d)
			{
				double num9 = num10 = result.Value.Y;
				point = #Vrc.StartPoint;
				double num11 = num12 = point.Y;
				if (false)
				{
					goto IL_1BB;
				}
				if (Math.Abs(num9 - num11) < #Emc.#d)
				{
					goto IL_1D4;
				}
			}
			if (Math.Abs(result.Value.X - #Vrc.EndPoint.X) >= #Emc.#d)
			{
				return result;
			}
			num10 = result.Value.Y;
			point = #Vrc.EndPoint;
			num12 = point.Y;
			IL_1BB:
			double num13 = num3 = (num4 = (num2 = Math.Abs(num10 - num12)));
			if (false)
			{
				goto IL_A9;
			}
			double num14 = #d = #Emc.#d;
			if (false)
			{
				goto IL_91;
			}
			if (num13 < num14)
			{
				goto IL_1D4;
			}
			return result;
			IL_1D4:
			if (!false)
			{
				return null;
			}
			goto IL_9B;
		}

		// Token: 0x0600409D RID: 16541 RVA: 0x0012E000 File Offset: 0x0012C200
		public unsafe static Point? #plc(SegmentData #Urc, SegmentData #Vrc, bool #tlc)
		{
			void* ptr = stackalloc byte[80];
			#X0d.#V0d(#Urc, #Phc.#3hc(107365653), Component.Geometry, #Phc.#3hc(107365309));
			#X0d.#V0d(#Vrc, #Phc.#3hc(107365075), Component.Geometry, #Phc.#3hc(107365224));
			Point point = #Urc.StartPoint;
			Point point2 = #Urc.EndPoint;
			Point point3 = #Vrc.StartPoint;
			Point point4 = #Vrc.EndPoint;
			*(double*)ptr = point.Y - point3.Y;
			*(double*)((byte*)ptr + 8) = point4.X - point3.X;
			*(double*)((byte*)ptr + 16) = point.X - point3.X;
			*(double*)((byte*)ptr + 24) = point4.Y - point3.Y;
			*(double*)((byte*)ptr + 32) = point2.X - point.X;
			*(double*)((byte*)ptr + 40) = point2.Y - point.Y;
			*(double*)((byte*)ptr + 48) = *(double*)((byte*)ptr + 32) * *(double*)((byte*)ptr + 24) - *(double*)((byte*)ptr + 40) * *(double*)((byte*)ptr + 8);
			*(double*)((byte*)ptr + 56) = *(double*)ptr * *(double*)((byte*)ptr + 8) - *(double*)((byte*)ptr + 16) * *(double*)((byte*)ptr + 24);
			if (#Emc.#Bmc(*(double*)((byte*)ptr + 48)) && #Emc.#Bmc(*(double*)((byte*)ptr + 56)))
			{
				return #jsc.#5rc(#Urc, #Vrc);
			}
			*(double*)((byte*)ptr + 64) = *(double*)((byte*)ptr + 56) / *(double*)((byte*)ptr + 48);
			if (*(double*)((byte*)ptr + 64) < -#Emc.#d || *(double*)((byte*)ptr + 64) > 1.0 + #Emc.#d)
			{
				return null;
			}
			*(double*)((byte*)ptr + 72) = (*(double*)ptr * *(double*)((byte*)ptr + 32) - *(double*)((byte*)ptr + 16) * *(double*)((byte*)ptr + 40)) / *(double*)((byte*)ptr + 48);
			if (*(double*)((byte*)ptr + 72) < -#Emc.#d || *(double*)((byte*)ptr + 72) > 1.0 + #Emc.#d)
			{
				return null;
			}
			Point point5 = new Point(#Urc.StartPoint.X + *(double*)((byte*)ptr + 64) * *(double*)((byte*)ptr + 32), #Urc.StartPoint.Y + *(double*)((byte*)ptr + 64) * *(double*)((byte*)ptr + 40));
			if (#jsc.#Src(#Urc, point5, #tlc) && #jsc.#Src(#Vrc, point5, #tlc))
			{
				return new Point?(point5);
			}
			return null;
		}

		// Token: 0x0600409E RID: 16542 RVA: 0x0012E278 File Offset: 0x0012C478
		public static IList<Point> #7rc(IList<Point> #8rc, Point #Xrb, Point #Yrb)
		{
			#X0d.#V0d(#8rc, #Phc.#3hc(107365203), Component.Geometry, #Phc.#3hc(107365154));
			List<Point> list = new List<Point>();
			if (#8rc.Count < 2)
			{
				return list;
			}
			SegmentData #Vrc = new SegmentData(#Xrb, #Yrb);
			int i;
			do
			{
				i = 1;
			}
			while (false);
			while (i < #8rc.Count)
			{
				Point? point = #jsc.#plc(new SegmentData(#8rc[i - 1], #8rc[i]), #Vrc);
				if (point != null)
				{
					list.Add(point.Value);
				}
				i++;
			}
			return list;
		}

		// Token: 0x0600409F RID: 16543 RVA: 0x0012E35C File Offset: 0x0012C55C
		public static bool #9rc(IList<Point> #BP, SegmentData #PP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107364589));
			for (;;)
			{
				IL_1F:
				#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107364568));
				for (;;)
				{
					IL_3E:
					int i = #BP.Count;
					int num = 2;
					IL_49:
					while (i >= num)
					{
						int num2 = 1;
						for (;;)
						{
							int num3 = num2;
							while (!false && num3 < #BP.Count)
							{
								if (false)
								{
									goto IL_1F;
								}
								Point? point = #jsc.#plc(new SegmentData(#BP[num3 - 1], #BP[num3]), #PP);
								if (2 == 0)
								{
									goto IL_3E;
								}
								if (-1 == 0)
								{
									goto IL_1F;
								}
								if (point != null)
								{
									return true;
								}
								int num4 = i = num3;
								int num5 = num = 1;
								if (num5 == 0)
								{
									goto IL_49;
								}
								num3 = num4 + num5;
							}
							int num6 = num2 = 0;
							if (num6 == 0)
							{
								return num6 != 0;
							}
						}
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x060040A0 RID: 16544 RVA: 0x0012E450 File Offset: 0x0012C650
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public static SegmentData #asc(#ewc #bsc, BoundingBoxDataLight #smc)
		{
			GeneralLineEquation generalLineEquation;
			Point? point;
			Point? point2;
			Point value;
			for (;;)
			{
				#X0d.#V0d(#bsc, #Phc.#3hc(107364483), Component.Geometry, #Phc.#3hc(107364458));
				#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107364437));
				generalLineEquation = #bsc.LineEquation;
				double #4gb2;
				double #4gb = #4gb2 = #bsc.Angle;
				double #5gb2;
				double #5gb = #5gb2 = 90.0;
				if (8 != 0)
				{
					if (#Emc.#Amc(#4gb, #5gb) || #Emc.#Amc(generalLineEquation.Tangent, \u0006\u0002.\u0011\u0004(90.0)))
					{
						break;
					}
					#4gb2 = #bsc.Angle;
					#5gb2 = 0.0;
				}
				if (#Emc.#Amc(#4gb2, #5gb2) || #Emc.#Bmc(generalLineEquation.Tangent))
				{
					goto IL_DD;
				}
				point = #jsc.#csc(#smc, generalLineEquation, #smc.MinY);
				point2 = #jsc.#csc(#smc, generalLineEquation, #smc.MaxY);
				value = point2.Value;
				if (!false)
				{
					goto Block_3;
				}
			}
			return new SegmentData(new Point(#bsc.Location.X, #smc.MinY), new Point(#bsc.Location.X, #smc.MaxY));
			IL_DD:
			return new SegmentData(new Point(#smc.MinX, generalLineEquation.#nlc(#smc.MinX)), new Point(#smc.MaxX, generalLineEquation.#nlc(#smc.MaxX)));
			Block_3:
			double num = value.X;
			double num2 = #smc.MinX;
			while (num != num2)
			{
				double num3 = num = point2.Value.Y;
				double num4 = num2 = #smc.MinY;
				if (!false)
				{
					if (num3 == num4)
					{
						break;
					}
					IL_187:
					return new SegmentData(point.Value, point2.Value);
				}
			}
			Point value2;
			do
			{
				value2 = point.Value;
				point = new Point?(point2.Value);
			}
			while (2 == 0);
			point2 = new Point?(value2);
			goto IL_187;
		}

		// Token: 0x060040A1 RID: 16545 RVA: 0x0012E648 File Offset: 0x0012C848
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public static Point? #csc(BoundingBoxDataLight #smc, GeneralLineEquation #Llc, double #mlc)
		{
			#X0d.#V0d(#Llc, #Phc.#3hc(107372257), Component.Geometry, #Phc.#3hc(107364352));
			Point value;
			if (true)
			{
				if (!false)
				{
					#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107364811));
					double num = #Llc.#llc(#mlc);
					while (8 != 0)
					{
						if (5 == 0)
						{
							goto IL_7F;
						}
						if (!double.IsNaN(num))
						{
							if (7 == 0)
							{
								continue;
							}
							if (!double.IsInfinity(num))
							{
								value = new Point(num, #mlc);
								goto IL_7F;
							}
						}
						IL_6C:
						return null;
						IL_7F:
						if (false)
						{
							goto IL_6C;
						}
						if (num < #smc.MinX)
						{
							value = new Point(#smc.MinX, #Llc.#nlc(#smc.MinX));
							goto IL_C8;
						}
						if (num > #smc.MaxX)
						{
							break;
						}
						goto IL_C8;
					}
					value = new Point(#smc.MaxX, #Llc.#nlc(#smc.MaxX));
					goto IL_C8;
				}
				Point? result;
				return result;
			}
			IL_C8:
			return new Point?(value);
		}

		// Token: 0x060040A2 RID: 16546 RVA: 0x0012E774 File Offset: 0x0012C974
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #dsc(IList<Point3D> #BP, double #esc)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107364790));
			List<Point3D> list = new List<Point3D>();
			int num = 1;
			for (;;)
			{
				IL_59:
				int i = num;
				int num2 = #BP.Count;
				IL_60:
				while (i < num2)
				{
					list.AddRange(#jsc.#dsc(#BP[num - 1], #BP[num], #esc));
					int num3;
					i = (num3 = num);
					int num5;
					do
					{
						int num4 = num2 = 2;
						if (num4 == 0)
						{
							goto IL_60;
						}
						num2 = num4;
						if (num4 == 0)
						{
							goto IL_60;
						}
						num5 = (num3 = (i = num3 + num4));
					}
					while (false || false);
					num = num5;
					goto IL_59;
				}
				break;
			}
			return list;
		}

		// Token: 0x060040A3 RID: 16547 RVA: 0x0012E82C File Offset: 0x0012CA2C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public unsafe static List<Point3D> #dsc(Point3D #Xrb, Point3D #Yrb, double #esc)
		{
			void* ptr = stackalloc byte[16];
			#c4d #c4d = Point3D.#H3d(#Yrb, #Xrb);
			*(double*)ptr = #c4d.Length;
			List<Point3D> list = new List<Point3D>();
			if (*(double*)ptr <= #esc * 2.0)
			{
				list.#pR(new Point3D[]
				{
					#Xrb,
					#Yrb
				});
			}
			else
			{
				#c4d #4Bb = #c4d.#33d(#c4d, #esc / *(double*)ptr);
				#c4d = new #c4d(0.0, 0.0, 0.0);
				while (#c4d.Length < *(double*)ptr)
				{
					*(double*)((byte*)ptr + 8) = *(double*)ptr - #c4d.Length;
					if (*(double*)((byte*)ptr + 8) <= 0.0)
					{
						break;
					}
					list.Add(#Xrb);
					if (*(double*)((byte*)ptr + 8) <= #4Bb.Length)
					{
						#Xrb = Point3D.#G3d(#Xrb, #c4d.#33d(#4Bb, *(double*)((byte*)ptr + 8) / #4Bb.Length));
						list.Add(#Xrb);
						break;
					}
					#Xrb = Point3D.#G3d(#Xrb, #4Bb);
					list.Add(#Xrb);
					#Xrb = Point3D.#G3d(#Xrb, #4Bb);
					#c4d = #c4d.#G3d(#c4d, #c4d.#33d(#4Bb, 2.0));
				}
			}
			return list;
		}

		// Token: 0x060040A4 RID: 16548 RVA: 0x0012E9A4 File Offset: 0x0012CBA4
		public static double? #lcb(SegmentData #PP, Point #Ng)
		{
			do
			{
				if (4 != 0)
				{
					#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107364705));
				}
			}
			while (false);
			return #jsc.#lcb(#PP.StartPoint, #PP.EndPoint, #Ng);
		}

		// Token: 0x060040A5 RID: 16549 RVA: 0x0012EA08 File Offset: 0x0012CC08
		public unsafe static double? #lcb(Point #Enc, Point #Fnc, Point #Hnc)
		{
			void* ptr = stackalloc byte[16];
			*(double*)ptr = Math.Sqrt(Vector.#33d(Point.#H3d(#Fnc, #Enc), Point.#H3d(#Fnc, #Enc)));
			if (double.IsNaN(*(double*)ptr) || #Emc.#U3(*(double*)ptr))
			{
				return null;
			}
			for (;;)
			{
				*(double*)((byte*)ptr + 8) = Vector.#Dnc(Point.#H3d(#Fnc, #Enc), Point.#H3d(#Hnc, #Enc)) / *(double*)ptr;
				if (Vector.#33d(Point.#H3d(#Hnc, #Fnc), Point.#H3d(#Fnc, #Enc)) > 0.0)
				{
					break;
				}
				if (8 != 0)
				{
					goto Block_3;
				}
			}
			return new double?(Math.Sqrt(Vector.#33d(Point.#H3d(#Fnc, #Hnc), Point.#H3d(#Fnc, #Hnc))));
			Block_3:
			if (Vector.#33d(Point.#H3d(#Hnc, #Enc), Point.#H3d(#Enc, #Fnc)) > 0.0)
			{
				return new double?(Math.Sqrt(Vector.#33d(Point.#H3d(#Enc, #Hnc), Point.#H3d(#Enc, #Hnc))));
			}
			return new double?(Math.Abs(*(double*)((byte*)ptr + 8)));
		}

		// Token: 0x060040A6 RID: 16550 RVA: 0x0012EB50 File Offset: 0x0012CD50
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "OnLine", Justification = "on line != online")]
		public static Point? #fsc(Point #Akb, Point #Bkb, Point #Ng)
		{
			GeneralLineEquation generalLineEquation = new GeneralLineEquation(#Akb, #Bkb);
			GeneralLineEquation #qlc = generalLineEquation.#rlc(#Ng);
			return generalLineEquation.#plc(#qlc);
		}

		// Token: 0x060040A7 RID: 16551 RVA: 0x0012EB8C File Offset: 0x0012CD8C
		public static Point? #gsc(SegmentData #PP, Point #Ng)
		{
			#X0d.#V0d(#PP, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107364652));
			Point value;
			if (7 != 0)
			{
				double? num = #jsc.#lcb(#PP, #Ng);
				Point? result2;
				if (num != null)
				{
					Point? result = #jsc.#fsc(#PP.StartPoint, #PP.EndPoint, #Ng);
					if (result == null)
					{
						if (6 != 0)
						{
							result2 = null;
						}
						return result2;
					}
					if (#Emc.#Amc(GeometryHelper.#lcb(#Ng, result.Value), num.Value))
					{
						return result;
					}
					if (!#Emc.#Amc(GeometryHelper.#lcb(#PP.StartPoint, #Ng), num.Value))
					{
						goto IL_AF;
					}
					if (!false)
					{
						value = #PP.StartPoint;
						goto IL_C3;
					}
					goto IL_4A;
				}
				IL_42:
				result2 = null;
				IL_4A:
				if (7 != 0)
				{
					return result2;
				}
				goto IL_42;
			}
			IL_AF:
			value = #PP.EndPoint;
			IL_C3:
			return new Point?(value);
		}

		// Token: 0x060040A8 RID: 16552 RVA: 0x0012ECAC File Offset: 0x0012CEAC
		public static Point #hsc(Point #Xrb, Point #Yrb)
		{
			return new Point((#Xrb.X + #Yrb.X) / 2.0, (#Xrb.Y + #Yrb.Y) / 2.0);
		}

		// Token: 0x060040A9 RID: 16553 RVA: 0x0012ED04 File Offset: 0x0012CF04
		public static Point #hsc(SegmentData #PP)
		{
			string #R0d = #Phc.#3hc(107368915);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107364631);
			if (!false)
			{
				#X0d.#V0d(#PP, #R0d, #x6c, #Qic);
			}
			return #jsc.#hsc(#PP.StartPoint, #PP.EndPoint);
		}

		// Token: 0x060040AA RID: 16554 RVA: 0x0012ED68 File Offset: 0x0012CF68
		public static bool #isc(IReadOnlyList<Point> #BP, Point #Ng)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107462338));
			int result;
			for (;;)
			{
				Point point;
				int num;
				if (4 != 0)
				{
					if (!false)
					{
						point = #BP[0];
						num = 1;
						goto IL_33;
					}
					goto IL_69;
				}
				IL_6D:
				int num2;
				if (num2 >= #BP.Count)
				{
					return false;
				}
				Point point2 = #BP[num2];
				bool flag = (result = (num = (Point.#E3d(point, point2) ? 1 : 0))) != 0;
				if (false)
				{
					return result != 0;
				}
				if (5 == 0)
				{
					goto IL_33;
				}
				if (flag)
				{
					goto IL_69;
				}
				if (!#jsc.#Src(point, point2, #Ng, false))
				{
					point = point2;
					goto IL_69;
				}
				if (!false)
				{
					break;
				}
				continue;
				IL_3A:
				goto IL_6D;
				IL_69:
				num2++;
				goto IL_6D;
				IL_33:
				if (false)
				{
					goto IL_3A;
				}
				num2 = num;
				goto IL_3A;
			}
			result = 1;
			return result != 0;
		}
	}
}

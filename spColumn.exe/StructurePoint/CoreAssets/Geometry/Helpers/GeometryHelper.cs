using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #Fmc;
using #Qlc;
using #u3d;
using #UYd;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007B7 RID: 1975
	public static class GeometryHelper
	{
		// Token: 0x06003F5A RID: 16218 RVA: 0x00125108 File Offset: 0x00123308
		public unsafe static Point? #Gmc(Point #Hmc, Point #Imc, Point #Jmc)
		{
			void* ptr = stackalloc byte[32];
			Point? result;
			int num;
			for (;;)
			{
				result = GeometryHelper.#Lmc(#Hmc, #Imc, #Jmc);
				bool flag = (num = ((result != null) ? 1 : 0)) != 0;
				if (!true)
				{
					goto IL_112;
				}
				if (6 == 0)
				{
					goto IL_109;
				}
				if (!flag)
				{
					break;
				}
				*(double*)ptr = Math.Min(#Hmc.X, #Imc.X);
				if (false)
				{
					goto IL_DF;
				}
				*(double*)((byte*)ptr + 8) = Math.Max(#Hmc.X, #Imc.X);
				if (!false)
				{
					goto Block_5;
				}
			}
			return null;
			Block_5:
			if (false)
			{
				goto IL_D7;
			}
			*(double*)((byte*)ptr + 16) = Math.Min(#Hmc.Y, #Imc.Y);
			*(double*)((byte*)ptr + 24) = Math.Max(#Hmc.Y, #Imc.Y);
			Point value = result.Value;
			double num2 = value.X;
			double num3 = *(double*)ptr;
			IL_C0:
			if (num2 >= num3)
			{
				value = result.Value;
				if (value.X <= *(double*)((byte*)ptr + 8))
				{
					goto IL_D7;
				}
			}
			num = 0;
			goto IL_112;
			IL_D7:
			value = result.Value;
			IL_DF:
			double num4 = num2 = value.Y;
			double num5 = num3 = *(double*)((byte*)ptr + 16);
			if (false)
			{
				goto IL_C0;
			}
			int num6;
			if (num4 >= num5)
			{
				value = result.Value;
				num6 = ((value.Y > *(double*)((byte*)ptr + 24)) ? 1 : 0);
			}
			else if ((num6 = (num = 0)) == 0)
			{
				goto IL_112;
			}
			num = ((num6 == 0) ? 1 : 0);
			IL_109:
			IL_112:
			if (num == 0)
			{
				return null;
			}
			return result;
		}

		// Token: 0x06003F5B RID: 16219 RVA: 0x00125274 File Offset: 0x00123474
		public unsafe static Point? #Kmc(Point #Hmc, Point #Imc, Point #Jmc)
		{
			void* ptr = stackalloc byte[32];
			Point? point = GeometryHelper.#Lmc(#Hmc, #Imc, #Jmc);
			if (point == null)
			{
				return null;
			}
			*(double*)ptr = Math.Min(#Hmc.X, #Imc.X);
			if (false)
			{
				goto IL_E0;
			}
			if (false)
			{
				goto IL_116;
			}
			*(double*)((byte*)ptr + 8) = Math.Max(#Hmc.X, #Imc.X);
			IL_76:
			*(double*)((byte*)ptr + 16) = Math.Min(#Hmc.Y, #Imc.Y);
			*(double*)((byte*)ptr + 24) = Math.Max(#Hmc.Y, #Imc.Y);
			Point value = point.Value;
			double num2;
			double num = num2 = value.X;
			if (false)
			{
				goto IL_10C;
			}
			double num3 = num;
			double num4;
			if (num3 < *(double*)ptr)
			{
				num4 = *(double*)ptr;
			}
			else
			{
				num4 = num3;
			}
			IL_C1:
			if (false)
			{
				goto IL_C1;
			}
			num3 = num4;
			num3 = ((num3 <= *(double*)((byte*)ptr + 8)) ? num3 : (*(double*)((byte*)ptr + 8)));
			value = point.Value;
			IL_E0:
			double num5 = value.Y;
			double num6;
			double num7;
			do
			{
				num6 = num5;
				num7 = (num5 = num6);
			}
			while (7 == 0);
			double num8;
			if (num7 < *(double*)((byte*)ptr + 16))
			{
				if (false)
				{
					goto IL_FF;
				}
				num8 = *(double*)((byte*)ptr + 16);
			}
			else
			{
				num8 = num6;
			}
			num6 = num8;
			IL_FF:
			if (num6 > *(double*)((byte*)ptr + 24))
			{
				num2 = *(double*)((byte*)ptr + 24);
			}
			else
			{
				if (5 == 0)
				{
					goto IL_76;
				}
				num2 = num6;
			}
			IL_10C:
			num6 = num2;
			IL_116:
			return new Point?(new Point(num3, num6));
		}

		// Token: 0x06003F5C RID: 16220 RVA: 0x001253E4 File Offset: 0x001235E4
		public unsafe static Point? #Lmc(Point #Hmc, Point #Imc, Point #Jmc)
		{
			void* ptr = stackalloc byte[16];
			Point value = new Point(0.0, 0.0);
			double num = #Imc.X;
			IL_2A:
			while (Math.Abs(num - #Hmc.X) < 0.0001)
			{
				double num2 = #Imc.Y;
				double value2;
				do
				{
					value2 = (num = (num2 -= #Hmc.Y));
					if (-1 == 0)
					{
						goto IL_2A;
					}
				}
				while (7 == 0);
				if (Math.Abs(value2) < 0.0001)
				{
					return null;
				}
				break;
			}
			*(double*)ptr = (#Jmc.X - #Hmc.X) * (#Imc.X - #Hmc.X) + (#Jmc.Y - #Hmc.Y) * (#Imc.Y - #Hmc.Y);
			*(double*)((byte*)ptr + 8) = Math.Pow(#Imc.X - #Hmc.X, 2.0) + Math.Pow(#Imc.Y - #Hmc.Y, 2.0);
			*(double*)ptr = *(double*)ptr / *(double*)((byte*)ptr + 8);
			value.X = #Hmc.X + *(double*)ptr * (#Imc.X - #Hmc.X);
			value.Y = #Hmc.Y + *(double*)ptr * (#Imc.Y - #Hmc.Y);
			return new Point?(value);
		}

		// Token: 0x06003F5D RID: 16221 RVA: 0x0012558C File Offset: 0x0012378C
		public unsafe static Point #Mmc(Point #Ng, Point #Nmc, double #Omc)
		{
			void* ptr = stackalloc byte[32];
			void* ptr2;
			if (!false)
			{
				ptr2 = ptr;
			}
			*(double*)ptr2 = #Ng.X;
			*(double*)(ptr2 + 8) = #Ng.Y;
			*(double*)(ptr2 + 16) = #Nmc.X;
			*(double*)(ptr2 + 24) = #Nmc.Y;
			#Omc = GeometryHelper.#Qmc(#Omc);
			#Ng.X = (*(double*)ptr2 - *(double*)((byte*)ptr2 + 16)) * \u0006\u0002.\u0008\u0004(#Omc) - (*(double*)((byte*)ptr2 + 8) - *(double*)((byte*)ptr2 + 24)) * \u0006\u0002.\u000E\u0004(#Omc) + *(double*)((byte*)ptr2 + 16);
			#Ng.Y = (*(double*)ptr2 - *(double*)((byte*)ptr2 + 16)) * \u0006\u0002.\u000E\u0004(#Omc) + (*(double*)((byte*)ptr2 + 8) - *(double*)((byte*)ptr2 + 24)) * \u0006\u0002.\u0008\u0004(#Omc) + *(double*)((byte*)ptr2 + 24);
			return #Ng;
		}

		// Token: 0x06003F5E RID: 16222 RVA: 0x001256A0 File Offset: 0x001238A0
		public unsafe static Point3D #Mmc(Point3D #Ng, Point3D #Nmc, double #Omc)
		{
			void* ptr = stackalloc byte[40];
			if (true)
			{
				*(double*)ptr = #Ng.X;
				*(double*)(ptr + 8) = #Ng.Y;
				*(double*)(ptr + 16) = #Nmc.X;
				*(double*)(ptr + 24) = #Nmc.Y;
				*(double*)((byte*)ptr + 32) = GeometryHelper.#Qmc(#Omc);
				#Ng.X = (*(double*)ptr - *(double*)((byte*)ptr + 16)) * \u0006\u0002.\u0008\u0004(*(double*)((byte*)ptr + 32)) - (*(double*)((byte*)ptr + 8) - *(double*)((byte*)ptr + 24)) * \u0006\u0002.\u000E\u0004(*(double*)((byte*)ptr + 32)) + *(double*)((byte*)ptr + 16);
			}
			#Ng.Y = (*(double*)ptr - *(double*)((byte*)ptr + 16)) * \u0006\u0002.\u000E\u0004(*(double*)((byte*)ptr + 32)) + (*(double*)((byte*)ptr + 8) - *(double*)((byte*)ptr + 24)) * \u0006\u0002.\u0008\u0004(*(double*)((byte*)ptr + 32)) + *(double*)((byte*)ptr + 24);
			return #Ng;
		}

		// Token: 0x06003F5F RID: 16223 RVA: 0x00035B50 File Offset: 0x00033D50
		public static double #Pmc(double #9Ab)
		{
			return #9Ab * 180.0 / 3.141592653589793;
		}

		// Token: 0x06003F60 RID: 16224 RVA: 0x00035B6B File Offset: 0x00033D6B
		public static double #Qmc(double #Rmc)
		{
			return #Rmc * 3.141592653589793 / 180.0;
		}

		// Token: 0x06003F61 RID: 16225 RVA: 0x00035B86 File Offset: 0x00033D86
		public static double #Smc(double #Tmc)
		{
			return GeometryHelper.#Pmc(GeometryHelper.#Umc(#Tmc));
		}

		// Token: 0x06003F62 RID: 16226 RVA: 0x00035B9F File Offset: 0x00033D9F
		public static double #Umc(double #Tmc)
		{
			return GeometryHelper.#hnc(4.0 * \u0006\u0002.\u000F\u0004(#Tmc), false, false);
		}

		// Token: 0x06003F63 RID: 16227 RVA: 0x00035BC9 File Offset: 0x00033DC9
		public static double #Vmc(double #Wmc, double #Xmc, double #Ymc, double #Zmc)
		{
			return GeometryHelper.#7mc(#Wmc, #Xmc, #Ymc, #Zmc);
		}

		// Token: 0x06003F64 RID: 16228 RVA: 0x001257CC File Offset: 0x001239CC
		public unsafe static double[] #0mc(double #1mc, double #2mc, double #3mc, double #4mc, double #Tmc)
		{
			void* ptr;
			if (true)
			{
				ptr = stackalloc byte[24];
			}
			*(double*)ptr = (1.0 / #Tmc - #Tmc) / 2.0;
			do
			{
				*(double*)(ptr + 8) = (#1mc + #3mc - (#4mc - #2mc) * *(double*)ptr) / 2.0;
				*(double*)((byte*)ptr + 16) = (#2mc + #4mc + (#3mc - #1mc) * *(double*)ptr) / 2.0;
			}
			while (5 == 0);
			return new double[]
			{
				*(double*)((byte*)ptr + 8),
				*(double*)((byte*)ptr + 16)
			};
		}

		// Token: 0x06003F65 RID: 16229 RVA: 0x00035BE8 File Offset: 0x00033DE8
		public static double #5mc(double #HS, double #Rmc)
		{
			return GeometryHelper.#6mc(#HS, GeometryHelper.#Qmc(#Rmc));
		}

		// Token: 0x06003F66 RID: 16230 RVA: 0x00035C06 File Offset: 0x00033E06
		public static double #6mc(double #HS, double #9Ab)
		{
			return \u0006\u0002.\u0006\u0004(3.141592653589793 * #HS * (#9Ab / GeometryHelper.#Qmc(180.0)));
		}

		// Token: 0x06003F67 RID: 16231 RVA: 0x00035C3E File Offset: 0x00033E3E
		public static double #7mc(double #8mc, double #9mc, double #anc, double #bnc)
		{
			return GeometryHelper.#cnc(#8mc, #9mc, 0.0, #anc, #bnc, 0.0);
		}

		// Token: 0x06003F68 RID: 16232 RVA: 0x0012587C File Offset: 0x00123A7C
		public static double #cnc(double #8mc, double #9mc, double #dnc, double #anc, double #bnc, double #enc)
		{
			return \u0006\u0002.\u0007\u0004(\u0011\u0002.\u0088\u0004(\u0006\u0002.\u0006\u0004(#8mc - #anc), 2.0) + \u0011\u0002.\u0088\u0004(\u0006\u0002.\u0006\u0004(#9mc - #bnc), 2.0) + \u0011\u0002.\u0088\u0004(\u0006\u0002.\u0006\u0004(#dnc - #enc), 2.0));
		}

		// Token: 0x06003F69 RID: 16233 RVA: 0x00035C6F File Offset: 0x00033E6F
		public static Point #fnc(Point #Xrb, Point #gnc, double #8Bb)
		{
			return Point.#G3d(#Xrb, Vector.#33d(Point.#H3d(#gnc, #Xrb), #8Bb));
		}

		// Token: 0x06003F6A RID: 16234 RVA: 0x0012591C File Offset: 0x00123B1C
		public static double #hnc(double #Udb, bool #inc, bool #jnc)
		{
			bool flag = #jnc;
			bool flag2 = #jnc;
			if (8 == 0)
			{
				goto IL_88;
			}
			if (#jnc)
			{
				#Udb = GeometryHelper.#Qmc(#Udb);
			}
			double num = GeometryHelper.#Qmc(360.0);
			flag = #inc;
			flag2 = #inc;
			IL_34:
			if (!false)
			{
				double num2;
				double num3;
				double num4;
				double num7;
				if (flag2)
				{
					if (\u0006\u0002.\u0006\u0004(#Udb) <= num)
					{
						goto IL_87;
					}
					num2 = #Udb;
					num3 = \u0006\u0002.\u0010\u0004(#Udb / num);
					num4 = num;
				}
				else
				{
					double num5 = num2 = \u0006\u0002.\u0006\u0004(#Udb);
					double num6 = num7 = num;
					if (-1 == 0)
					{
						goto IL_5B;
					}
					if (num5 < num6)
					{
						goto IL_87;
					}
					double num8 = num2 = #Udb;
					double num9 = num3 = \u0006\u0002.\u0010\u0004(#Udb / num);
					double num10 = num4 = num;
					if (!false)
					{
						#Udb = num8 - num9 * num10;
						goto IL_87;
					}
				}
				num7 = num3 * num4;
				IL_5B:
				#Udb = num2 - num7;
				IL_87:
				flag = #jnc;
				flag2 = #jnc;
			}
			IL_88:
			if (!false)
			{
				if (flag && 8 != 0)
				{
					#Udb = GeometryHelper.#Pmc(#Udb);
				}
				return #Udb;
			}
			goto IL_34;
		}

		// Token: 0x06003F6B RID: 16235 RVA: 0x00035CA0 File Offset: 0x00033EA0
		public static double #knc(double #8mc, double #9mc, double #anc, double #bnc)
		{
			return GeometryHelper.#Pmc(GeometryHelper.#lnc(#8mc, #9mc, #anc, #bnc));
		}

		// Token: 0x06003F6C RID: 16236 RVA: 0x00035CC8 File Offset: 0x00033EC8
		public static double #lnc(double #8mc, double #9mc, double #anc, double #bnc)
		{
			return \u0011\u0002.\u0089\u0004(#bnc - #9mc, #anc - #8mc);
		}

		// Token: 0x06003F6D RID: 16237 RVA: 0x00035CEE File Offset: 0x00033EEE
		public static double[] #mnc(double #nnc, double #onc, double #pnc, double #qnc, double #Rmc)
		{
			return GeometryHelper.#rnc(#nnc, #onc, #pnc, #qnc, GeometryHelper.#Qmc(#Rmc));
		}

		// Token: 0x06003F6E RID: 16238 RVA: 0x00125A08 File Offset: 0x00123C08
		public unsafe static double[] #rnc(double #nnc, double #onc, double #pnc, double #qnc, double #9Ab)
		{
			int num2;
			void* ptr;
			if (true)
			{
				int num = num2 = 16;
				if (num == 0)
				{
					goto IL_58;
				}
				ptr = stackalloc byte[num];
			}
			*(double*)ptr = \u0006\u0002.\u0008\u0004(#9Ab) * (#pnc - #nnc) - \u0006\u0002.\u000E\u0004(#9Ab) * (#qnc - #onc) + #nnc;
			*(double*)((byte*)ptr + 8) = \u0006\u0002.\u000E\u0004(#9Ab) * (#pnc - #nnc) + \u0006\u0002.\u0008\u0004(#9Ab) * (#qnc - #onc) + #onc;
			num2 = 2;
			IL_58:
			double[] array = new double[num2];
			array[0] = *(double*)ptr;
			array[1] = *(double*)((byte*)ptr + 8);
			return array;
		}

		// Token: 0x06003F6F RID: 16239 RVA: 0x00125AA8 File Offset: 0x00123CA8
		public unsafe static bool #snc(double #tnc, double #unc, double #vnc, double #wnc, double #xnc, double #ync)
		{
			void* ptr;
			if (!false)
			{
				int result;
				int num = result = 16;
				if (num == 0)
				{
					return result != 0;
				}
				ptr = stackalloc byte[num];
			}
			double num2 = \u0011\u0002.\u0088\u0004(#vnc - #ync, 2.0);
			*(double*)ptr = \u0011\u0002.\u0088\u0004(#tnc - #wnc, 2.0) + \u0011\u0002.\u0088\u0004(#unc - #xnc, 2.0);
			if (num2 <= *(double*)ptr)
			{
				*(double*)((byte*)ptr + 8) = \u0011\u0002.\u0088\u0004(#vnc + #ync, 2.0);
				if (*(double*)ptr <= *(double*)((byte*)ptr + 8))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003F70 RID: 16240 RVA: 0x00125B8C File Offset: 0x00123D8C
		public static bool #znc(Size #hNb, Point #Ng)
		{
			double num = #Ng.X;
			double num2 = 0.0;
			IL_0D:
			while (num >= num2)
			{
				double num3 = #Ng.Y;
				double num7;
				double num8;
				for (;;)
				{
					IL_13:
					double num4 = 0.0;
					while (num3 >= num4)
					{
						do
						{
							double num5 = num = (num3 = #Ng.X);
							if (false)
							{
								goto IL_13;
							}
							double num6 = num2 = #hNb.Width;
							if (false)
							{
								goto IL_0D;
							}
							if (num5 > num6)
							{
								goto IL_45;
							}
						}
						while (false);
						num7 = (num3 = #Ng.Y);
						num8 = (num4 = #hNb.Height);
						if (4 != 0)
						{
							goto Block_6;
						}
					}
					goto IL_45;
				}
				Block_6:
				bool result;
				bool flag = result = (num7 > num8);
				if (!false)
				{
					return !flag;
				}
				return result;
			}
			IL_45:
			return false;
		}

		// Token: 0x06003F71 RID: 16241 RVA: 0x00125C0C File Offset: 0x00123E0C
		public static bool #znc(BoundingBoxDataLight #Anc, Point #Ng)
		{
			double num3;
			double num4;
			for (;;)
			{
				IL_00:
				#X0d.#V0d(#Anc, #Phc.#3hc(107369692), Component.Geometry, #Phc.#3hc(107369663));
				double num = #Ng.X;
				for (;;)
				{
					IL_23:
					double num2 = #Anc.MinX;
					while (num >= num2)
					{
						if (false)
						{
							goto IL_00;
						}
						num3 = (num = #Ng.X);
						if (false)
						{
							goto IL_23;
						}
						num4 = (num2 = #Anc.MaxX);
						if (!false)
						{
							goto Block_3;
						}
					}
					return false;
				}
			}
			Block_3:
			if (num3 <= num4 && (false || #Ng.Y >= #Anc.MinY))
			{
				bool result;
				bool flag = result = (#Ng.Y > #Anc.MaxY);
				if (true)
				{
					result = !flag;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06003F72 RID: 16242 RVA: 0x00035D1C File Offset: 0x00033F1C
		public static bool #Bnc(Point #p0, double #r0, Point #9sb)
		{
			return GeometryHelper.#lcb(#p0, #9sb) <= #r0;
		}

		// Token: 0x06003F73 RID: 16243 RVA: 0x00125CDC File Offset: 0x00123EDC
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "List is usefull here.")]
		public static List<SegmentData> #Cnc(BoundingBoxData #smc)
		{
			if (true)
			{
				#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107369589));
			}
			return #smc.Segments.ToList<SegmentData>();
		}

		// Token: 0x06003F74 RID: 16244 RVA: 0x00125D30 File Offset: 0x00123F30
		public static double #Dnc(Point #Ng, Point #Enc, Point #Fnc)
		{
			double num = #Enc.X;
			double result;
			for (;;)
			{
				double num3;
				double num2 = num3 = num - #Ng.X;
				double num5;
				double num4 = num5 = #Fnc.Y;
				double num6;
				if (!false)
				{
					num6 = #Ng.Y;
					goto IL_14;
				}
				goto IL_25;
				IL_29:
				double num7;
				if (7 != 0)
				{
					result = (num = num2 - num4 * (num7 - #Ng.X));
					if (!false)
					{
						break;
					}
					continue;
				}
				IL_14:
				num2 = (num3 *= num5 - num6);
				double num8 = num5 = (num4 = #Enc.Y);
				if (!false)
				{
					double num9 = num6 = (num7 = #Ng.Y);
					if (!true)
					{
						goto IL_29;
					}
					num4 = (num5 = num8 - num9);
				}
				IL_25:
				num7 = (num6 = #Fnc.X);
				goto IL_29;
			}
			return result;
		}

		// Token: 0x06003F75 RID: 16245 RVA: 0x00125DAC File Offset: 0x00123FAC
		public static double #Gnc(#c4d #mcb, #c4d #ncb)
		{
			double num2;
			double num = num2 = #mcb.X;
			do
			{
				if (!false)
				{
					num = (num2 *= #ncb.X);
				}
			}
			while (4 == 0);
			double num3 = #mcb.Y;
			double num4 = #ncb.Y;
			double num6;
			double num9;
			for (;;)
			{
				double num5 = num3 * num4;
				for (;;)
				{
					num6 = (num += num5);
					double num7 = num3 = #mcb.Z;
					double num8 = num4 = #ncb.Z;
					if (false)
					{
						break;
					}
					num9 = (num5 = num7 * num8);
					if (-1 != 0)
					{
						goto Block_4;
					}
				}
			}
			Block_4:
			return num6 + num9;
		}

		// Token: 0x06003F76 RID: 16246 RVA: 0x00125E0C File Offset: 0x0012400C
		public static double #Gnc(Point #Enc, Point #Fnc, Point #Hnc)
		{
			double num = #Hnc.X;
			double result;
			for (;;)
			{
				double num3;
				double num2 = num3 = num - #Enc.X;
				double num5;
				double num4 = num5 = #Fnc.X;
				double num6;
				if (!false)
				{
					num6 = #Enc.X;
					goto IL_14;
				}
				goto IL_25;
				IL_29:
				double num7;
				if (7 != 0)
				{
					result = (num = num2 + num4 * (num7 - #Enc.Y));
					if (!false)
					{
						break;
					}
					continue;
				}
				IL_14:
				num2 = (num3 *= num5 - num6);
				double num8 = num5 = (num4 = #Hnc.Y);
				if (!false)
				{
					double num9 = num6 = (num7 = #Enc.Y);
					if (!true)
					{
						goto IL_29;
					}
					num4 = (num5 = num8 - num9);
				}
				IL_25:
				num7 = (num6 = #Fnc.Y);
				goto IL_29;
			}
			return result;
		}

		// Token: 0x06003F77 RID: 16247 RVA: 0x00125E88 File Offset: 0x00124088
		public unsafe static IList<Point> #Inc(IList<Point> #BP)
		{
			void* ptr = stackalloc byte[16];
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107369504));
			int i;
			Point[] array;
			if (!false)
			{
				*(int*)ptr = #BP.Count;
				i = 0;
				array = new Point[*(int*)ptr * 2];
				#BP = #BP.OrderBy(new Func<Point, double>(GeometryHelper.<>c.<>9.#rxc)).ThenBy(new Func<Point, double>(GeometryHelper.<>c.<>9.#sxc)).ToList<Point>();
				*(int*)((byte*)ptr + 4) = 0;
				goto IL_FC;
			}
			goto IL_DA;
			IL_AA:
			if (i < 2)
			{
				goto IL_DA;
			}
			double num = GeometryHelper.#Dnc(array[i - 2], array[i - 1], #BP[*(int*)((byte*)ptr + 4)]);
			double num2 = 0.0;
			IL_D8:
			if (num <= num2)
			{
				i--;
				goto IL_AA;
			}
			IL_DA:
			if (false)
			{
				goto IL_114;
			}
			array[i++] = #BP[*(int*)((byte*)ptr + 4)];
			*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
			IL_FC:
			if (*(int*)((byte*)ptr + 4) < *(int*)ptr)
			{
				goto IL_AA;
			}
			*(int*)((byte*)ptr + 8) = *(int*)ptr - 2;
			IL_10C:
			*(int*)((byte*)ptr + 12) = i + 1;
			IL_114:
			while (*(int*)((byte*)ptr + 8) >= 0)
			{
				while (i >= *(int*)((byte*)ptr + 12))
				{
					if (5 == 0)
					{
						goto IL_10C;
					}
					double num3 = num = GeometryHelper.#Dnc(array[i - 2], array[i - 1], #BP[*(int*)((byte*)ptr + 8)]);
					double num4 = num2 = 0.0;
					if (6 == 0)
					{
						goto IL_D8;
					}
					if (num3 > num4)
					{
						break;
					}
					i--;
				}
				array[i++] = #BP[*(int*)((byte*)ptr + 8)];
				*(int*)((byte*)ptr + 8) = *(int*)((byte*)ptr + 8) - 1;
			}
			if (!false)
			{
				return array.Take(i).ToList<Point>();
			}
			goto IL_10C;
		}

		// Token: 0x06003F78 RID: 16248 RVA: 0x0012606C File Offset: 0x0012426C
		public static Point #Jnc(Point #Ng, double #Udb, double #8Bb)
		{
			double xField = #Ng.X + \u0006\u0002.\u0008\u0004(GeometryHelper.#Qmc(#Udb)) * #8Bb;
			double yField = #Ng.Y + \u0006\u0002.\u000E\u0004(GeometryHelper.#Qmc(#Udb)) * #8Bb;
			return new Point(xField, yField);
		}

		// Token: 0x06003F79 RID: 16249 RVA: 0x001260D8 File Offset: 0x001242D8
		public static float #Knc(double #7W, double #9o)
		{
			double num = \u0011\u0002.\u0089\u0004(#7W, #9o);
			double num2 = 180.0;
			double num5;
			double num6;
			double num7;
			do
			{
				double num4;
				double num3 = num4 = num * num2;
				if (!false)
				{
					num4 = num3 / 3.141592653589793;
				}
				for (;;)
				{
					IL_22:
					num5 = num4;
					while (num5 < 0.0)
					{
						if (!false)
						{
							num6 = (num = (num4 = num5));
							if (!false)
							{
								goto Block_4;
							}
							goto IL_22;
						}
					}
					goto IL_48;
				}
				Block_4:
				num7 = (num2 = 360.0);
			}
			while (false);
			num5 = num6 + num7;
			IL_48:
			return (float)num5;
		}

		// Token: 0x06003F7A RID: 16250 RVA: 0x0012614C File Offset: 0x0012434C
		public unsafe static bool #Lnc(IList<Point> #Mnc, Point #Ng)
		{
			void* ptr = stackalloc byte[36];
			#X0d.#V0d(#Mnc, #Phc.#3hc(107369963), Component.Geometry, #Phc.#3hc(107369934));
			IL_29:
			while (#Mnc.Count > 3)
			{
				int? num = null;
				*(int*)(ptr + 24) = 1;
				while (*(int*)((byte*)ptr + 24) < #Mnc.Count)
				{
					Point point = #Mnc[*(int*)((byte*)ptr + 24) - 1];
					Point point2 = #Mnc[*(int*)((byte*)ptr + 24)];
					ref int ptr2 = ref *(int*)((byte*)ptr + 28);
					double num2 = point.X - #Ng.X;
					*(double*)ptr = point.Y - #Ng.Y;
					*(double*)((byte*)ptr + 8) = point2.X - #Ng.X;
					*(double*)((byte*)ptr + 16) = point2.Y - #Ng.Y;
					ptr2 = Math.Sign(num2 * *(double*)((byte*)ptr + 16) - *(double*)ptr * *(double*)((byte*)ptr + 8));
					if (num != null)
					{
						goto IL_F0;
					}
					if (false)
					{
						goto IL_29;
					}
					if (*(int*)((byte*)ptr + 28) == 0)
					{
						goto IL_F0;
					}
					num = new int?(*(int*)((byte*)ptr + 28));
					IL_11E:
					*(int*)((byte*)ptr + 24) = *(int*)((byte*)ptr + 24) + 1;
					continue;
					IL_F0:
					if (*(int*)((byte*)ptr + 28) == 0)
					{
						goto IL_11E;
					}
					int? num3 = num;
					*(int*)((byte*)ptr + 32) = *(int*)((byte*)ptr + 28);
					if (!(num3.GetValueOrDefault() == *(int*)((byte*)ptr + 32) & num3 != null))
					{
						return false;
					}
					goto IL_11E;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06003F7B RID: 16251 RVA: 0x001262DC File Offset: 0x001244DC
		public unsafe static bool #Nnc(IList<Point> #BP)
		{
			void* ptr = stackalloc byte[48];
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107369913));
			if (#BP.Count <= 4)
			{
				return true;
			}
			int? num = null;
			*(int*)(ptr + 24) = #BP.Count - 1;
			*(int*)((byte*)ptr + 28) = 0;
			while (*(int*)((byte*)ptr + 28) < *(int*)((byte*)ptr + 24))
			{
				*(int*)((byte*)ptr + 32) = (*(int*)((byte*)ptr + 28) + 2) % *(int*)((byte*)ptr + 24);
				*(int*)((byte*)ptr + 36) = (*(int*)((byte*)ptr + 28) + 1) % *(int*)((byte*)ptr + 24);
				Point point = #BP[*(int*)((byte*)ptr + 32)];
				ref int ptr2 = ref *(int*)((byte*)ptr + 40);
				double num2 = point.X - #BP[*(int*)((byte*)ptr + 36)].X;
				*(double*)ptr = #BP[*(int*)((byte*)ptr + 32)].Y - #BP[*(int*)((byte*)ptr + 36)].Y;
				point = #BP[*(int*)((byte*)ptr + 28)];
				*(double*)((byte*)ptr + 8) = point.X - #BP[*(int*)((byte*)ptr + 36)].X;
				point = #BP[*(int*)((byte*)ptr + 28)];
				*(double*)((byte*)ptr + 16) = point.Y - #BP[*(int*)((byte*)ptr + 36)].Y;
				ptr2 = Math.Sign(num2 * *(double*)((byte*)ptr + 16) - *(double*)ptr * *(double*)((byte*)ptr + 8));
				if (false)
				{
					goto IL_170;
				}
				int? num3;
				if (num == null)
				{
					num = new int?(*(int*)((byte*)ptr + 40));
				}
				else if (*(int*)((byte*)ptr + 40) != 0)
				{
					num3 = num;
					*(int*)((byte*)ptr + 44) = *(int*)((byte*)ptr + 40);
					goto IL_170;
				}
				IL_18A:
				*(int*)((byte*)ptr + 28) = *(int*)((byte*)ptr + 28) + 1;
				continue;
				IL_170:
				if (!(num3.GetValueOrDefault() == *(int*)((byte*)ptr + 44) & num3 != null))
				{
					return false;
				}
				goto IL_18A;
			}
			return true;
		}

		// Token: 0x06003F7C RID: 16252 RVA: 0x001264D8 File Offset: 0x001246D8
		public unsafe static void #Onc(ShapeData #rP)
		{
			if (false)
			{
				goto IL_78;
			}
			int num2;
			int num = num2 = 8;
			if (num == 0)
			{
				goto IL_A8;
			}
			void* ptr = stackalloc byte[num];
			void* ptr2;
			if (!false)
			{
				ptr2 = ptr;
			}
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107369828));
			if (-1 == 0)
			{
				goto IL_D0;
			}
			List<PolygonData> list = #rP.Polygons.OrderBy(new Func<PolygonData, SqlDouble>(GeometryHelper.<>c.<>9.#txc)).ToList<PolygonData>();
			GeometryHelper.#koc(list);
			*(int*)ptr2 = 0;
			IL_76:
			goto IL_EC;
			IL_78:
			PolygonData polygonData = list[*(int*)ptr2];
			*(int*)((byte*)ptr2 + 4) = 0;
			goto IL_DA;
			IL_A8:
			if (num2 != 0)
			{
				PolygonData polygonData2;
				polygonData2.IsOpening = true;
				polygonData.ChildPolygons.Add(polygonData2);
				polygonData2.PossibleParentPolygons.Add(polygonData);
				polygonData2.ParentPolygon = polygonData;
			}
			IL_D0:
			*(int*)((byte*)ptr2 + 4) = *(int*)((byte*)ptr2 + 4) + 1;
			IL_DA:
			if (*(int*)((byte*)ptr2 + 4) >= #rP.PolygonsCount)
			{
				*(int*)ptr2 = *(int*)ptr2 + 1;
			}
			else
			{
				PolygonData polygonData2 = list[*(int*)((byte*)ptr2 + 4)];
				if (polygonData2 != polygonData)
				{
					num2 = (#0uc.#7tc(polygonData.SqlGeometry, polygonData2.SqlGeometry) ? 1 : 0);
					goto IL_A8;
				}
				goto IL_D0;
			}
			IL_EC:
			if (*(int*)ptr2 < #rP.PolygonsCount)
			{
				goto IL_78;
			}
			List<PolygonData>.Enumerator enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PolygonData polygonData3 = enumerator.Current;
					GeometryHelper.#EZb #EZb = new GeometryHelper.#EZb();
					#EZb.#a = polygonData3.PossibleParentPolygons.OrderBy(new Func<PolygonData, SqlDouble>(GeometryHelper.<>c.<>9.#uxc)).FirstOrDefault<PolygonData>();
					polygonData3.ParentPolygon = #EZb.#a;
					IEnumerable<PolygonData> source = list;
					Func<PolygonData, bool> predicate;
					if ((predicate = #EZb.#b) == null)
					{
						predicate = (#EZb.#b = new Func<PolygonData, bool>(#EZb.#Bxc));
					}
					IEnumerator<PolygonData> enumerator2 = source.Where(predicate).GetEnumerator();
					try
					{
						do
						{
							while (\u0010\u0002.~\u0019\u0004(enumerator2))
							{
								enumerator2.Current.ChildPolygons.Remove(polygonData3);
							}
						}
						while (2 == 0);
					}
					finally
					{
						if (enumerator2 != null)
						{
							\u0007.~\u000E(enumerator2);
						}
					}
				}
			}
			finally
			{
				do
				{
					if (!false)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				while (4 == 0);
			}
			if (3 != 0)
			{
				list = GeometryHelper.#Pnc(list);
				#rP.#yl();
				#rP.#pR(list, false);
				return;
			}
			goto IL_76;
		}

		// Token: 0x06003F7D RID: 16253 RVA: 0x00126754 File Offset: 0x00124954
		internal static List<PolygonData> #Pnc(IList<PolygonData> #yP)
		{
			using (List<HierarchyNode<PolygonData>>.Enumerator enumerator = #yP.#W1d(new Func<PolygonData, PolygonData>(GeometryHelper.<>c.<>9.#vxc), new Func<PolygonData, PolygonData>(GeometryHelper.<>c.<>9.#wxc)).#X1d<PolygonData>().ToList<HierarchyNode<PolygonData>>().GetEnumerator())
			{
				for (;;)
				{
					int num;
					bool flag = (num = (enumerator.MoveNext() ? 1 : 0)) != 0;
					if (false)
					{
						goto IL_79;
					}
					if (!flag)
					{
						break;
					}
					HierarchyNode<PolygonData> hierarchyNode = enumerator.Current;
					int num2 = num = hierarchyNode.Depth;
					int num4;
					int num3 = num4 = 2;
					if (num3 != 0)
					{
						num = num2 % num3;
						goto IL_79;
					}
					IL_7A:
					if (num == num4 && hierarchyNode.Parent != null)
					{
						hierarchyNode.Parent = null;
						if (hierarchyNode.Entity.ParentPolygon != null)
						{
							hierarchyNode.Entity.ParentPolygon.ChildPolygons.Remove(hierarchyNode.Entity);
						}
						hierarchyNode.Entity.ParentPolygon = null;
						hierarchyNode.Entity.IsOpening = false;
						continue;
					}
					continue;
					IL_79:
					num4 = 1;
					goto IL_7A;
				}
			}
			return #yP.OrderBy(new Func<PolygonData, bool>(GeometryHelper.<>c.<>9.#xxc)).ToList<PolygonData>();
		}

		// Token: 0x06003F7E RID: 16254 RVA: 0x001268D0 File Offset: 0x00124AD0
		public unsafe static Point #Qnc(IEnumerable<Point> #BP)
		{
			void* ptr = stackalloc byte[9];
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107369775));
			List<Point> list = #BP.ToList<Point>();
			if (list.Count<Point>() < 3)
			{
				throw new #jYd(#Phc.#3hc(107358670), #Phc.#3hc(107369754), Component.Geometry, #IYd.#c);
			}
			List<Point> #BP2 = new List<Point>(list);
			PointsConverter.#Asc(list);
			int num = list.Count<Point>();
			if (num < 3)
			{
				throw new #jYd(#Phc.#3hc(107358670), #Phc.#3hc(107369157), Component.Geometry, #IYd.#c);
			}
			Point result = default(Point);
			if (num == 3)
			{
				Point point = list[0];
				Point point2 = list[1];
				Point point3 = list[2];
				result = new Point((point.X + point2.X + point3.X) / 3.0, (point.Y + point2.Y + point3.Y) / 3.0);
			}
			else
			{
				SqlGeometry sqlGeometry = #0uc.#PHb(list, true);
				List<SegmentData> source = #jsc.#Rrc(#BP2).ToList<SegmentData>();
				((byte*)ptr)[8] = 0;
				*(int*)ptr = 0;
				while (*(int*)ptr < list.Count)
				{
					Point point4 = list[*(int*)ptr];
					*(int*)((byte*)ptr + 4) = 0;
					while (*(int*)((byte*)ptr + 4) < list.Count)
					{
						GeometryHelper.#hWb #hWb = new GeometryHelper.#hWb();
						Point point5 = list[*(int*)((byte*)ptr + 4)];
						if (Math.Abs(*(int*)ptr - *(int*)((byte*)ptr + 4)) > 1 && point4.X != point5.X && point4.Y != point5.Y)
						{
							#hWb.#a = new Point((point4.X + point5.X) / 2.0, (point4.Y + point5.Y) / 2.0);
							SqlGeometry other = #0uc.#PHb(#hWb.#a);
							SqlBoolean sqlBoolean = !source.Any(new Func<SegmentData, bool>(#hWb.#Cxc));
							if (SqlBoolean.op_False(sqlBoolean) ? sqlBoolean : (sqlBoolean & sqlGeometry.STContains(other)))
							{
								((byte*)ptr)[8] = 1;
								result = #hWb.#a;
								break;
							}
						}
						*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
					}
					if (*(sbyte*)((byte*)ptr + 8) != 0)
					{
						break;
					}
					*(int*)ptr = *(int*)ptr + 1;
				}
			}
			return result;
		}

		// Token: 0x06003F7F RID: 16255 RVA: 0x00126B80 File Offset: 0x00124D80
		public static Point #Qnc(PolygonData #JP)
		{
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107369136));
			if (#JP.Points2D.Count<Point>() < 3)
			{
				throw new #jYd(#Phc.#3hc(107369083), #Phc.#3hc(107369054), Component.Geometry);
			}
			return GeometryHelper.#Qnc(#JP.Points2D.Take(#JP.Points2DCount - 1).ToList<Point>());
		}

		// Token: 0x06003F80 RID: 16256 RVA: 0x00126C14 File Offset: 0x00124E14
		public static double #lcb(Point #mcb, Point #ncb)
		{
			double num = #ncb.Y - #mcb.Y;
			\u0006\u0002 u0007_u = \u0006\u0002.\u0007\u0004;
			double num2 = #ncb.X - #mcb.X;
			return u0007_u(num2 * num2 + num * num);
		}

		// Token: 0x06003F81 RID: 16257 RVA: 0x00126C70 File Offset: 0x00124E70
		public static Point? #Rnc(this IList<Point> #Snc, Point #Ng)
		{
			return #Snc.#Rnc(#Ng, null);
		}

		// Token: 0x06003F82 RID: 16258 RVA: 0x00126CA0 File Offset: 0x00124EA0
		public static Point? #Rnc(this IList<Point> #Snc, Point #Ng, double? #WLb)
		{
			#X0d.#V0d(#Snc, #Phc.#3hc(107368969), Component.Infrastructure, #Phc.#3hc(107368988));
			double? num = null;
			Point? result = null;
			double? num2 = #WLb * #WLb;
			foreach (Point point in #Snc)
			{
				double num3 = GeometryHelper.#Tnc(point, #Ng);
				if (num2 != null)
				{
					double num4 = num3;
					double? num5 = num2;
					if (num4 >= num5.GetValueOrDefault() & num5 != null)
					{
						continue;
					}
				}
				if (num != null && !false)
				{
					double num6 = num3;
					double? num5 = num;
					if (!(num6 < num5.GetValueOrDefault() & num5 != null))
					{
						continue;
					}
				}
				num = new double?(num3);
				result = new Point?(point);
			}
			return result;
		}

		// Token: 0x06003F83 RID: 16259 RVA: 0x00126E0C File Offset: 0x0012500C
		public static double #Tnc(Point #mcb, Point #ncb)
		{
			double num3;
			double num2;
			double num = num2 = (num3 = #ncb.Y);
			if (false)
			{
				goto IL_0C;
			}
			double num4 = #mcb.Y;
			IL_0B:
			num = (num2 = (num3 = num2 - num4));
			IL_0C:
			double num5;
			if (4 != 0)
			{
				num5 = num3;
				num = (num2 = #ncb.X);
			}
			double num6 = num4 = #mcb.X;
			while (!false)
			{
				double num7 = num - num6;
				double num8 = num2 = (num = num7 * num7);
				double num9 = num4 = (num6 = num5 * num5);
				if (-1 != 0)
				{
					return num8 + num9;
				}
			}
			goto IL_0B;
		}

		// Token: 0x06003F84 RID: 16260 RVA: 0x00126E68 File Offset: 0x00125068
		public unsafe static double #lcb(Point3D #mcb, Point3D #ncb)
		{
			void* ptr = stackalloc byte[16];
			\u0006\u0002 u0007_u = \u0006\u0002.\u0007\u0004;
			double num = #ncb.X - #mcb.X;
			*(double*)ptr = #ncb.Y - #mcb.Y;
			*(double*)(ptr + 8) = #ncb.Z - #mcb.Z;
			return u0007_u(num * num + *(double*)ptr * *(double*)ptr + *(double*)((byte*)ptr + 8) * *(double*)((byte*)ptr + 8));
		}

		// Token: 0x06003F85 RID: 16261 RVA: 0x00126EF0 File Offset: 0x001250F0
		internal static bool #WHb(ShapeData #rP, SqlGeometry #YHb)
		{
			GeometryHelper.#JZb #JZb = new GeometryHelper.#JZb();
			GeometryHelper.#JZb #JZb2;
			if (!false)
			{
				#JZb2 = #JZb;
			}
			#JZb2.#a = #YHb;
			if (false)
			{
				goto IL_62;
			}
			int result;
			bool flag = (result = (\u0013\u0002.~\u008D\u0004(#rP.#cxc(0).SqlGeometry, #JZb2.#a).Value ? 1 : 0)) != 0;
			if (2 == 0)
			{
				return result != 0;
			}
			bool flag2 = flag;
			if (#rP.PolygonsCount == 1)
			{
				if (false)
				{
					goto IL_86;
				}
				if (!false)
				{
					return flag2;
				}
			}
			bool flag3 = flag2;
			IL_60:
			if (!flag3)
			{
				goto IL_86;
			}
			IL_62:
			bool result2 = flag3 = !#rP.Polygons.Skip(1).Any(new Func<PolygonData, bool>(#JZb2.#Cbc));
			if (2 != 0)
			{
				return result2;
			}
			goto IL_60;
			IL_86:
			result = 0;
			return result != 0;
		}

		// Token: 0x06003F86 RID: 16262 RVA: 0x00126FCC File Offset: 0x001251CC
		public static bool #WHb(ShapeData #rP, Point #Ng)
		{
			SqlGeometry #YHb;
			if (!false)
			{
				#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107369415));
				if (4 != 0)
				{
					int num = #rP.Polygons.Any<PolygonData>() ? 1 : 0;
					while (num == 0 || 2 == 0)
					{
						int num2 = num = 0;
						if (num2 == 0)
						{
							return num2 != 0;
						}
					}
					#YHb = #0uc.#PHb(#Ng);
				}
			}
			return GeometryHelper.#WHb(#rP, #YHb);
		}

		// Token: 0x06003F87 RID: 16263 RVA: 0x00127044 File Offset: 0x00125244
		public static bool #Unc(ShapeData #rP, Point #Ng)
		{
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107369415));
			int result;
			bool flag = (result = (GeometryHelper.#WHb(#rP, #Ng) ? 1 : 0)) != 0;
			if (!false)
			{
				if (!flag)
				{
					using (List<SegmentData>.Enumerator enumerator = #rP.#cxc(0).Segments.GetEnumerator())
					{
						int num;
						SegmentData segmentData;
						do
						{
							bool flag2 = (num = (enumerator.MoveNext() ? 1 : 0)) != 0;
							if (6 == 0 || 6 == 0)
							{
								goto IL_70;
							}
							if (!flag2)
							{
								goto IL_82;
							}
							if (7 == 0)
							{
								goto IL_71;
							}
							segmentData = enumerator.Current;
							if (false)
							{
								goto IL_82;
							}
						}
						while (!GeometryHelper.#Vnc(#Ng, segmentData.StartPoint, segmentData.EndPoint));
						num = 1;
						IL_70:
						bool result2 = num != 0;
						IL_71:
						return result2;
						IL_82:;
					}
					return false;
				}
				result = 1;
			}
			return result != 0;
		}

		// Token: 0x06003F88 RID: 16264 RVA: 0x00127140 File Offset: 0x00125340
		public unsafe static bool #Vnc(Point #Ng, Point #Wnc, Point #Xnc)
		{
			void* ptr = stackalloc byte[16];
			if (\u0006\u0002.\u0006\u0004(GeometryHelper.#Dnc(#Wnc, #Xnc, #Ng)) > 0.0001)
			{
				return false;
			}
			*(double*)ptr = GeometryHelper.#Gnc(#Wnc, #Xnc, #Ng);
			if (*(double*)ptr < 0.0)
			{
				return false;
			}
			*(double*)((byte*)ptr + 8) = \u0011\u0002.\u0088\u0004(GeometryHelper.#7mc(#Wnc.X, #Wnc.Y, #Xnc.X, #Xnc.Y), 2.0);
			return *(double*)ptr <= *(double*)((byte*)ptr + 8);
		}

		// Token: 0x06003F89 RID: 16265 RVA: 0x00127228 File Offset: 0x00125428
		public static bool #WHb(ShapeData #rP, PolygonData #Ync)
		{
			bool result;
			SqlBoolean sqlBoolean;
			for (;;)
			{
				#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107369394));
				for (;;)
				{
					#X0d.#V0d(#Ync, #Phc.#3hc(107369341), Component.Geometry, #Phc.#3hc(107369284));
					while (!false)
					{
						bool flag = result = #rP.Polygons.Any<PolygonData>();
						if (false)
						{
							return result;
						}
						if (!flag)
						{
							return false;
						}
						if (!false)
						{
							goto Block_3;
						}
					}
				}
				Block_3:
				if (!false)
				{
					sqlBoolean = \u0013\u0002.~\u008D\u0004(#Ync.SqlGeometry, #rP.#cxc(0).SqlGeometry);
					if (4 != 0)
					{
						goto Block_5;
					}
				}
			}
			return false;
			Block_5:
			result = sqlBoolean.Value;
			return result;
		}

		// Token: 0x06003F8A RID: 16266 RVA: 0x00035D3B File Offset: 0x00033F3B
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #9Hb(Point3D #wob, double #HS, int #Znc, bool #CHb)
		{
			return GeometryHelper.#2nc(#wob, #HS, #Znc, 0.0, #CHb);
		}

		// Token: 0x06003F8B RID: 16267 RVA: 0x00035D63 File Offset: 0x00033F63
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #9Hb(Point3D #wob, double #HS, int #Znc, bool #CHb, double #0nc)
		{
			return GeometryHelper.#2nc(#wob, #HS, #Znc, #0nc, #CHb);
		}

		// Token: 0x06003F8C RID: 16268 RVA: 0x00035D88 File Offset: 0x00033F88
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #9Hb(Point3D #wob, double #HS, int #Znc)
		{
			return GeometryHelper.#2nc(#wob, #HS, #Znc, 0.0, true);
		}

		// Token: 0x06003F8D RID: 16269 RVA: 0x0012730C File Offset: 0x0012550C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public unsafe static List<Point> #1nc(Point #wob, double #HS, int #Znc, double #0nc, bool #CHb)
		{
			void* ptr = stackalloc byte[44];
			List<Point> list;
			if (#HS > 0.0)
			{
				if (#Znc < 3)
				{
					if (!false)
					{
						throw new #jYd(#Phc.#3hc(107368689), #Phc.#3hc(107368668), Component.Geometry);
					}
				}
				else
				{
					list = new List<Point>(#Znc + 2);
					*(double*)ptr = 6.283185307179586 / (double)#Znc;
				}
				*(double*)((byte*)ptr + 8) = #wob.X;
				*(double*)((byte*)ptr + 16) = #wob.Y;
				*(int*)((byte*)ptr + 40) = #Znc - 1;
				goto IL_F3;
			}
			if (3 != 0)
			{
				throw new #jYd(#Phc.#3hc(107369231), #Phc.#3hc(107369222), Component.Geometry);
			}
			IL_E7:
			*(int*)((byte*)ptr + 40) = *(int*)((byte*)ptr + 40) - 1;
			IL_F3:
			if (*(int*)((byte*)ptr + 40) < 0)
			{
				if (#CHb)
				{
					list.Add(list[0]);
				}
				return list;
			}
			*(double*)((byte*)ptr + 24) = *(double*)((byte*)ptr + 8) + #HS * Math.Cos((double)(*(int*)((byte*)ptr + 40)) * *(double*)ptr + #0nc);
			*(double*)((byte*)ptr + 32) = *(double*)((byte*)ptr + 16) + #HS * Math.Sin((double)(*(int*)((byte*)ptr + 40)) * *(double*)ptr + #0nc);
			list.Add(new Point(*(double*)((byte*)ptr + 24), *(double*)((byte*)ptr + 32)));
			goto IL_E7;
		}

		// Token: 0x06003F8E RID: 16270 RVA: 0x00127474 File Offset: 0x00125674
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public unsafe static List<Point3D> #2nc(Point3D #wob, double #HS, int #Znc, double #0nc, bool #CHb)
		{
			int num2;
			int num = num2 = 44;
			if (num != 0)
			{
				void* ptr = stackalloc byte[num];
				if (#HS > 0.0)
				{
					int num3 = #Znc;
					List<Point3D> list;
					int num5;
					do
					{
						int num4;
						if (num3 >= 3)
						{
							if (true)
							{
								list = new List<Point3D>();
								if (5 == 0)
								{
									goto IL_B8;
								}
								*(double*)ptr = 6.283185307179586 / (double)#Znc;
								*(double*)((byte*)ptr + 8) = #wob.X;
								*(double*)((byte*)ptr + 16) = #wob.Y;
								*(int*)((byte*)ptr + 40) = #Znc - 1;
							}
							IL_FD:
							if (*(int*)((byte*)ptr + 40) < 0)
							{
								num4 = (#CHb ? 1 : 0);
								if (6 != 0)
								{
									goto Block_8;
								}
								goto IL_45;
							}
							else
							{
								*(double*)((byte*)ptr + 24) = *(double*)((byte*)ptr + 8) + #HS * Math.Cos((double)(*(int*)((byte*)ptr + 40)) * *(double*)ptr + #0nc);
							}
							IL_B8:
							*(double*)((byte*)ptr + 32) = *(double*)((byte*)ptr + 16) + #HS * Math.Sin((double)(*(int*)((byte*)ptr + 40)) * *(double*)ptr + #0nc);
							list.Add(new Point3D(*(double*)((byte*)ptr + 24), *(double*)((byte*)ptr + 32), #wob.Z));
							*(int*)((byte*)ptr + 40) = *(int*)((byte*)ptr + 40) - 1;
							goto IL_FD;
						}
						num4 = 107368689;
						IL_45:
						num5 = (num3 = num4);
					}
					while (num5 == 0);
					throw new #jYd(#Phc.#3hc(num5), #Phc.#3hc(107368562), Component.Geometry);
					Block_8:
					if (#CHb)
					{
						list.Add(list[0]);
					}
					return list;
				}
				num2 = 107369231;
			}
			throw new #jYd(#Phc.#3hc(num2), #Phc.#3hc(107368583), Component.Geometry);
		}

		// Token: 0x06003F8F RID: 16271 RVA: 0x001275EC File Offset: 0x001257EC
		public unsafe static Point #3nc(Point #wob, double #HS, double #Udb)
		{
			void* ptr;
			do
			{
				ptr = stackalloc byte[16];
			}
			while (false);
			double num = #wob.X;
			*(double*)ptr = #wob.Y;
			double num2 = #HS;
			if (!false)
			{
				num2 = #HS * \u0006\u0002.\u0008\u0004(#Udb);
			}
			double xField = num + num2;
			if (7 != 0)
			{
				*(double*)(ptr + 8) = *(double*)ptr + #HS * \u0006\u0002.\u000E\u0004(#Udb);
			}
			return new Point(xField, *(double*)((byte*)ptr + 8));
		}

		// Token: 0x06003F90 RID: 16272 RVA: 0x00035DAC File Offset: 0x00033FAC
		public static Point #4nc(Point #wob, double #HS, double #Udb)
		{
			return GeometryHelper.#3nc(#wob, #HS, GeometryHelper.#Qmc(#Udb));
		}

		// Token: 0x06003F91 RID: 16273 RVA: 0x00127668 File Offset: 0x00125868
		public static double #5nc(Point3D #Xrb, Point3D #Yrb)
		{
			double result;
			double num = result = \u0006\u0002.\u0006\u0004(#Yrb.X - #Xrb.X);
			double num2;
			if (7 != 0)
			{
				if (false)
				{
					return result;
				}
				num2 = \u0006\u0002.\u0006\u0004(#Yrb.Y - #Xrb.Y);
			}
			result = #Emc.#xmc(num * num2);
			return result;
		}

		// Token: 0x06003F92 RID: 16274 RVA: 0x001276DC File Offset: 0x001258DC
		public static bool #6nc(Point3D #Xrb, Point3D #Yrb)
		{
			int result;
			bool flag = (result = (Point3D.#F3d(#Xrb, #Yrb) ? 1 : 0)) != 0;
			if (4 != 0)
			{
				if (!flag)
				{
					goto IL_3D;
				}
				IL_0B:
				if (false)
				{
					goto IL_1B;
				}
				double num2;
				double num = num2 = #Xrb.X;
				double num4;
				double num3 = num4 = #Yrb.X;
				IL_16:
				if (6 == 0)
				{
					goto IL_23;
				}
				if (num2 == num4)
				{
					goto IL_3D;
				}
				IL_1B:
				num = (num2 = #Xrb.Y);
				num3 = (num4 = #Yrb.Y);
				IL_23:
				if (6 == 0)
				{
					goto IL_16;
				}
				if (num != num3)
				{
					return GeometryHelper.#5nc(#Xrb, #Yrb) > 0.0;
				}
				IL_3D:
				if (-1 == 0)
				{
					goto IL_0B;
				}
				result = 0;
			}
			return result != 0;
		}

		// Token: 0x06003F93 RID: 16275 RVA: 0x0012775C File Offset: 0x0012595C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #7nc(Point3D #Xrb, Point3D #Yrb)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			if (!GeometryHelper.#6nc(#Xrb, #Yrb))
			{
				return list2;
			}
			Point3D item3;
			if (4 != 0)
			{
				#c4d #c4d = Point3D.#H3d(#Yrb, #Xrb);
				Point3D item = #Xrb;
				Point3D item2 = new Point3D(item.X, item.Y + #c4d.Y, item.Z);
				item3 = new Point3D(item.X + #c4d.X, item.Y + #c4d.Y, item.Z);
				Point3D item4 = new Point3D(item.X + #c4d.X, item.Y, item.Z);
				list2.Add(item2);
				list2.Add(item3);
				list2.Add(item);
				list2.Add(item2);
				list2.Add(item);
				list2.Add(item4);
				list2.Add(item4);
			}
			do
			{
				list2.Add(item3);
			}
			while (3 == 0);
			return list2;
		}

		// Token: 0x06003F94 RID: 16276 RVA: 0x0012789C File Offset: 0x00125A9C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public unsafe static List<Point3D> #8nc(Point3D #Xrb, Point3D #Yrb)
		{
			void* ptr = stackalloc byte[16];
			List<Point3D> list = new List<Point3D>();
			if (!GeometryHelper.#6nc(#Xrb, #Yrb))
			{
				return list;
			}
			Point3D item = new Point3D(Math.Min(#Xrb.X, #Yrb.X), Math.Min(#Xrb.Y, #Yrb.Y), Math.Min(#Xrb.Z, #Yrb.Z));
			*(double*)ptr = Math.Abs(#Xrb.X - #Yrb.X);
			*(double*)((byte*)ptr + 8) = Math.Abs(#Xrb.Y - #Yrb.Y);
			list.Add(item);
			list.Add(new Point3D(item.X + *(double*)ptr, item.Y, item.Z));
			list.Add(new Point3D(item.X + *(double*)ptr, item.Y + *(double*)((byte*)ptr + 8), item.Z));
			list.Add(new Point3D(item.X, item.Y + *(double*)((byte*)ptr + 8), item.Z));
			list.Add(item);
			return list;
		}

		// Token: 0x06003F95 RID: 16277 RVA: 0x00127A08 File Offset: 0x00125C08
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point3D> #9nc(Point3D #Xrb, Point3D #Yrb)
		{
			List<Point3D> list;
			Point point;
			List<Point> list2;
			if (!false)
			{
				list = new List<Point3D>();
				if (Point3D.#E3d(#Xrb, #Yrb))
				{
					return list;
				}
				double value;
				double num3;
				double num2;
				double num = num2 = (num3 = (value = 0.001));
				double num4;
				if (!false)
				{
					num4 = num;
					num3 = (num2 = (value = #Xrb.X));
				}
				if (3 == 0)
				{
					goto IL_181;
				}
				if (-1 == 0)
				{
					goto IL_179;
				}
				if (num2 == #Yrb.X)
				{
					list.Add(#Xrb);
					list.Add(new Point3D(#Xrb.X + num4, #Xrb.Y, #Xrb.Z));
					list.Add(new Point3D(#Xrb.X + num4, #Xrb.Y, #Yrb.Z));
					list.Add(#Yrb);
					list.Add(#Xrb);
					return list;
				}
				if (#Xrb.Y == #Yrb.Y)
				{
					list.Add(#Xrb);
					list.Add(#Yrb);
					list.Add(new Point3D(#Yrb.X, #Yrb.Y + num4, #Yrb.Z));
					list.Add(new Point3D(#Xrb.X, #Xrb.Y + num4, #Xrb.Z));
					list.Add(#Xrb);
					return list;
				}
				point = PointsConverter.#vsc(#Xrb);
				if (3 == 0)
				{
					return list;
				}
				Point point2 = PointsConverter.#vsc(#Yrb);
				if (point.X > point2.X)
				{
					#e0d.#c0d<Point>(ref point, ref point2);
				}
				#Plc #Plc = new #Plc(point, point2);
				IL_156:
				double num5 = value = Math.Abs(#Plc.A);
				if (false)
				{
					goto IL_181;
				}
				if (num5 >= 0.1)
				{
					goto IL_17A;
				}
				num3 = 1E-06;
				IL_179:
				num4 = num3;
				IL_17A:
				value = #Plc.A;
				IL_181:
				if (Math.Sign(value) > 0)
				{
					num4 = -num4;
				}
				if (false)
				{
					goto IL_156;
				}
				list2 = new List<Point>();
				list2.Add(point);
				list2.Add(point2);
				list2.Add(#Plc.#Mlc(point2).#nlc(point2.X + num4));
				list2.Add(#Plc.#Mlc(point).#nlc(point.X + num4));
			}
			list2.Add(point);
			list.AddRange(list2.Select(new Func<Point, Point3D>(GeometryHelper.<>c.<>9.#yxc)));
			return list;
		}

		// Token: 0x06003F96 RID: 16278 RVA: 0x00127C70 File Offset: 0x00125E70
		public static PolygonData #aoc(params Point[] #BP)
		{
			if (true)
			{
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107368509));
			}
			return new PolygonData(PointsConverter.#vsc(#BP));
		}

		// Token: 0x06003F97 RID: 16279 RVA: 0x00127CC4 File Offset: 0x00125EC4
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point> #boc(IEnumerable<PolygonData> #yP, SegmentData #PP)
		{
			GeometryHelper.#Q5b #Q5b = new GeometryHelper.#Q5b();
			#Q5b.#a = #PP;
			#X0d.#V0d(#yP, #Phc.#3hc(107372425), Component.Geometry, #Phc.#3hc(107368936));
			#X0d.#V0d(#Q5b.#a, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107368870));
			return #yP.SelectMany(new Func<PolygonData, IEnumerable<Point?>>(#Q5b.#Dxc)).Where(new Func<Point?, bool>(GeometryHelper.<>c.<>9.#zxc)).Select(new Func<Point?, Point>(GeometryHelper.<>c.<>9.#Axc)).ToList<Point>();
		}

		// Token: 0x06003F98 RID: 16280 RVA: 0x00127DD4 File Offset: 0x00125FD4
		public static bool #coc(BoundingBoxDataLight #smc, Point #Ng, double #HS)
		{
			if (!GeometryHelper.#coc(#smc, #Ng))
			{
				goto IL_92;
			}
			IL_14:
			if (!GeometryHelper.#coc(#smc, new Point(#Ng.X - #HS, #Ng.Y)) || !GeometryHelper.#coc(#smc, new Point(#Ng.X + #HS, #Ng.Y)))
			{
				goto IL_92;
			}
			IL_56:
			if (GeometryHelper.#coc(#smc, new Point(#Ng.X, #Ng.Y - #HS)))
			{
				if (3 != 0)
				{
					return GeometryHelper.#coc(#smc, new Point(#Ng.X, #Ng.Y + #HS));
				}
				goto IL_14;
			}
			IL_92:
			if (4 != 0)
			{
				return false;
			}
			goto IL_56;
		}

		// Token: 0x06003F99 RID: 16281 RVA: 0x00127EC4 File Offset: 0x001260C4
		public static bool #coc(BoundingBoxDataLight #smc, Point #doc)
		{
			if (true)
			{
				#X0d.#V0d(#smc, #Phc.#3hc(107369578), Component.Geometry, #Phc.#3hc(107368849));
			}
			return #smc.#Zvc(#doc);
		}

		// Token: 0x06003F9A RID: 16282 RVA: 0x00127F14 File Offset: 0x00126114
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "It is a link.")]
		public unsafe static bool #eoc(IReadOnlyList<Point> #BP, int #Xtb, Point #Ng)
		{
			int num = 17;
			bool result;
			do
			{
				void* ptr = stackalloc byte[num];
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107368796));
				*(byte*)(ptr + 16) = 0;
				*(double*)ptr = #Ng.X;
				*(double*)(ptr + 8) = #Ng.Y;
				int num2 = 0;
				int index = #Xtb - 1;
				for (;;)
				{
					Point point;
					Point point2;
					double num3;
					double num4;
					if (num2 < #Xtb && !false)
					{
						point = #BP[num2];
						point2 = #BP[index];
						num3 = point.Y;
						num4 = *(double*)((byte*)ptr + 8);
						goto IL_7C;
					}
					sbyte b;
					result = ((num = (int)(b = *(sbyte*)((byte*)ptr + 16))) != 0);
					if (!false)
					{
						break;
					}
					IL_7E:
					if (b != ((point2.Y > *(double*)((byte*)ptr + 8)) ? 1 : 0))
					{
						double num5 = num3 = *(double*)ptr;
						double num7;
						double num6 = num7 = point2.X;
						if (false)
						{
							goto IL_C4;
						}
						double num8 = num4 = (num7 = num6 - point.X);
						if (false)
						{
							goto IL_7C;
						}
						double num10;
						double num9 = num10 = *(double*)((byte*)ptr + 8);
						double num11;
						if (!false)
						{
							num11 = num8 * (num9 - point.Y);
							goto IL_B4;
						}
						IL_CB:
						double num12 = num11 = num7 + num10;
						if (6 == 0)
						{
							goto IL_B4;
						}
						if (num5 < num12)
						{
							((byte*)ptr)[16] = ((*(sbyte*)((byte*)ptr + 16) == 0) ? 1 : 0);
							goto IL_DE;
						}
						goto IL_DE;
						IL_C4:
						num10 = point.X;
						goto IL_CB;
						IL_B4:
						num7 = num11 / (point2.Y - point.Y);
						goto IL_C4;
					}
					IL_DE:
					index = num2++;
					continue;
					IL_7C:
					b = ((num3 > num4) ? 1 : 0);
					goto IL_7E;
				}
			}
			while (false);
			return result;
		}

		// Token: 0x06003F9B RID: 16283 RVA: 0x00128064 File Offset: 0x00126264
		public static bool #foc(PolygonData #goc, PolygonData #hoc)
		{
			string #R0d = #Phc.#3hc(107368711);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107368726);
			if (3 != 0)
			{
				#X0d.#V0d(#goc, #R0d, #x6c, #Qic);
			}
			do
			{
				#X0d.#V0d(#hoc, #Phc.#3hc(107368129), Component.Geometry, #Phc.#3hc(107368108));
			}
			while (false);
			return #0uc.#7tc(#hoc.SqlGeometry, #goc.SqlGeometry);
		}

		// Token: 0x06003F9C RID: 16284 RVA: 0x001280E4 File Offset: 0x001262E4
		public static bool #foc(PolygonData #JP, IEnumerable<PolygonData> #Wlc)
		{
			if (!false)
			{
				#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107368087));
			}
			#X0d.#V0d(#Wlc, #Phc.#3hc(107371773), Component.Geometry, #Phc.#3hc(107368002));
			IEnumerator<PolygonData> enumerator = #Wlc.GetEnumerator();
			try
			{
				if (!false)
				{
				}
				while (enumerator.MoveNext())
				{
					PolygonData #hoc = enumerator.Current;
					if (GeometryHelper.#foc(#JP, #hoc))
					{
						return true;
					}
				}
			}
			finally
			{
				while (-1 != 0 && enumerator != null)
				{
					if (!false)
					{
						enumerator.Dispose();
						break;
					}
				}
			}
			if (!false)
			{
				return false;
			}
			bool result;
			return result;
		}

		// Token: 0x06003F9D RID: 16285 RVA: 0x001281D4 File Offset: 0x001263D4
		public static List<Point> #ioc(IList<Point> #AHb, double #1Mb = 0.0001)
		{
			List<Point> list = GeometryHelper.#joc(#AHb, #1Mb);
			if (list.Count > 3)
			{
				bool flag = false;
				if (list.First<Point>().#e(list.Last<Point>()))
				{
					flag = true;
					list.RemoveAt(list.Count - 1);
				}
				list = list.#Mmc(2);
				if (flag)
				{
					list.Add(list.First<Point>());
				}
				list = GeometryHelper.#joc(list, #1Mb);
			}
			return list;
		}

		// Token: 0x06003F9E RID: 16286 RVA: 0x00035DCF File Offset: 0x00033FCF
		private static List<#Fu> #Mmc<#Fu>(this List<#Fu> #7p, int #sP)
		{
			return #7p.Skip(#sP).Concat(#7p.Take(#sP)).ToList<#Fu>();
		}

		// Token: 0x06003F9F RID: 16287 RVA: 0x00128274 File Offset: 0x00126474
		private unsafe static List<Point> #joc(IList<Point> #AHb, double #1Mb)
		{
			void* ptr = stackalloc byte[16];
			void* ptr2;
			if (!false)
			{
				ptr2 = ptr;
			}
			*(int*)ptr2 = #AHb.Count;
			if (false)
			{
				goto IL_7F;
			}
			List<Point> list = new List<Point>();
			list.Add(#AHb[0]);
			IL_3E:
			*(int*)((byte*)ptr2 + 4) = 0;
			*(int*)((byte*)ptr2 + 8) = 1;
			*(int*)((byte*)ptr2 + 12) = 2;
			Point #mcb = #AHb[*(int*)((byte*)ptr2 + 4)];
			goto IL_B5;
			IL_7F:
			Point point;
			list.Add(point);
			if (!false)
			{
				*(int*)((byte*)ptr2 + 4) = *(int*)((byte*)ptr2 + 8);
			}
			#mcb = #AHb[*(int*)((byte*)ptr2 + 4)];
			IL_9C:
			if (false)
			{
				goto IL_3E;
			}
			*(int*)((byte*)ptr2 + 8) = *(int*)((byte*)ptr2 + 8) + 1;
			*(int*)((byte*)ptr2 + 12) = *(int*)((byte*)ptr2 + 12) + 1;
			IL_B5:
			if (*(int*)((byte*)ptr2 + 12) >= *(int*)ptr2)
			{
				list.Add(#AHb[*(int*)ptr2 - 1]);
				return list;
			}
			point = #AHb[*(int*)((byte*)ptr2 + 8)];
			Point #Ckc = #AHb[*(int*)((byte*)ptr2 + 12)];
			if (!#jsc.#vlc(#mcb, point, #Ckc, #1Mb))
			{
				goto IL_7F;
			}
			goto IL_9C;
		}

		// Token: 0x06003FA0 RID: 16288 RVA: 0x00128394 File Offset: 0x00126594
		private static void #koc(IEnumerable<PolygonData> #yP)
		{
			if (!false)
			{
				IEnumerator<PolygonData> enumerator = #yP.GetEnumerator();
				goto IL_0F;
				try
				{
					for (;;)
					{
						IL_0F:
						while (!false)
						{
							if (!enumerator.MoveNext() && !false)
							{
								goto Block_6;
							}
							if (!false)
							{
								PolygonData polygonData = enumerator.Current;
								polygonData.ParentPolygon = null;
								polygonData.IsOpening = false;
								polygonData.ChildPolygons.Clear();
								polygonData.PossibleParentPolygons.Clear();
							}
						}
					}
					Block_6:;
				}
				finally
				{
					if (enumerator != null && !false)
					{
						enumerator.Dispose();
					}
				}
			}
		}

		// Token: 0x04001CC6 RID: 7366
		public const double #a = 90.0;

		// Token: 0x04001CC7 RID: 7367
		public const double #b = 0.0;

		// Token: 0x04001CC8 RID: 7368
		public const double #c = 3.141592653589793;

		// Token: 0x04001CC9 RID: 7369
		public const double #d = 0.0001;

		// Token: 0x020007B9 RID: 1977
		[CompilerGenerated]
		private sealed class #EZb
		{
			// Token: 0x06003FAE RID: 16302 RVA: 0x00035E71 File Offset: 0x00034071
			internal bool #Bxc(PolygonData #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x04001CD5 RID: 7381
			public PolygonData #a;

			// Token: 0x04001CD6 RID: 7382
			public Func<PolygonData, bool> #b;
		}

		// Token: 0x020007BA RID: 1978
		[CompilerGenerated]
		private sealed class #hWb
		{
			// Token: 0x06003FB0 RID: 16304 RVA: 0x00035E87 File Offset: 0x00034087
			internal bool #Cxc(SegmentData #PP)
			{
				return #jsc.#Src(#PP, this.#a);
			}

			// Token: 0x04001CD7 RID: 7383
			public Point #a;
		}

		// Token: 0x020007BB RID: 1979
		[CompilerGenerated]
		private sealed class #JZb
		{
			// Token: 0x06003FB2 RID: 16306 RVA: 0x0012843C File Offset: 0x0012663C
			internal bool #Cbc(PolygonData #Rf)
			{
				return \u0013\u0002.~\u008D\u0004(#Rf.SqlGeometry, this.#a).Value;
			}

			// Token: 0x04001CD8 RID: 7384
			public SqlGeometry #a;
		}

		// Token: 0x020007BC RID: 1980
		[CompilerGenerated]
		private sealed class #Q5b
		{
			// Token: 0x06003FB4 RID: 16308 RVA: 0x00128480 File Offset: 0x00126680
			internal IEnumerable<Point?> #Dxc(PolygonData #Rf)
			{
				IEnumerable<SegmentData> source = #Rf.Segments;
				Func<SegmentData, Point?> selector;
				if ((selector = this.#b) == null)
				{
					selector = (this.#b = new Func<SegmentData, Point?>(this.#Exc));
				}
				return source.Select(selector);
			}

			// Token: 0x06003FB5 RID: 16309 RVA: 0x00035EA1 File Offset: 0x000340A1
			internal Point? #Exc(SegmentData #Fxc)
			{
				return #jsc.#plc(this.#a, #Fxc);
			}

			// Token: 0x04001CD9 RID: 7385
			public SegmentData #a;

			// Token: 0x04001CDA RID: 7386
			public Func<SegmentData, Point?> #b;
		}
	}
}

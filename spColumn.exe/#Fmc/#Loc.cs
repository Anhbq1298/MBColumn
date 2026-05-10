using System;
using System.Diagnostics.CodeAnalysis;
using #u3d;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007BE RID: 1982
	internal static class #Loc
	{
		// Token: 0x06003FB9 RID: 16313 RVA: 0x00128860 File Offset: 0x00126A60
		public static #c4d #soc(#c4d #4Bb)
		{
			double #9o;
			double num = #9o = -1.0;
			double #7W;
			double num3;
			double num2 = num3 = (#7W = #4Bb.Y);
			if (6 == 0)
			{
				goto IL_1F;
			}
			#9o = num * num2;
			num3 = 1.0;
			double num4 = #4Bb.X;
			IL_1E:
			#7W = (num3 *= num4);
			IL_1F:
			double num5 = num4 = 1.0;
			while (3 != 0 && 6 != 0)
			{
				double #kdc = num4 = (num5 *= #4Bb.Z);
				if (4 != 0)
				{
					return new #c4d(#9o, #7W, #kdc);
				}
			}
			goto IL_1E;
		}

		// Token: 0x06003FBA RID: 16314 RVA: 0x001288C4 File Offset: 0x00126AC4
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#")]
		public static bool #toc(#c4d #0sb, #c4d #1sb, #c4d #dtb, #c4d #etb, out double #uoc)
		{
			if (4 == 0)
			{
				goto IL_5C;
			}
			#uoc = 0.0;
			double num = #Loc.#Gnc(#dtb, #1sb);
			if (\u0006\u0002.\u0006\u0004(num) <= 0.0001)
			{
				return false;
			}
			#c4d #Doc = #c4d.#H3d(#etb, #0sb);
			IL_50:
			#uoc = #Loc.#Gnc(#Doc, #dtb) / num;
			IL_5C:
			if (8 != 0)
			{
				if (2 != 0)
				{
					double num3;
					double num2 = num3 = #uoc;
					double num5;
					double num4 = num5 = 0.0001;
					if (!false)
					{
						if (num2 < num4)
						{
							goto IL_83;
						}
						num3 = #uoc;
						num5 = 0.9999;
					}
					if (num3 <= num5)
					{
						return true;
					}
					IL_83:
					int result;
					int num6 = result = 0;
					if (num6 == 0)
					{
						return num6 != 0;
					}
					return result != 0;
				}
				return true;
			}
			goto IL_50;
		}

		// Token: 0x06003FBB RID: 16315 RVA: 0x0012899C File Offset: 0x00126B9C
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#")]
		public unsafe static bool #toc(Point3D #0sb, #c4d #1sb, Point3D #mcb, Point3D #ncb, Point3D #Ckc, out double #voc)
		{
			void* ptr = stackalloc byte[32];
			#voc = 0.0;
			#c4d #c4d = new #c4d(#ncb.X - #mcb.X, #ncb.Y - #mcb.Y, #ncb.Z - #mcb.Z);
			#c4d #c4d2 = new #c4d(#Ckc.X - #mcb.X, #Ckc.Y - #mcb.Y, #Ckc.Z - #mcb.Z);
			#c4d #Eoc = #Loc.#Dnc(#1sb, #c4d2);
			*(double*)ptr = #Loc.#Gnc(#c4d, #Eoc);
			if (*(double*)ptr > -0.0001 && *(double*)ptr < 0.0001)
			{
				return false;
			}
			*(double*)((byte*)ptr + 8) = 1.0 / *(double*)ptr;
			#c4d #Doc;
			if (!false)
			{
				bool flag2;
				bool flag = flag2 = #Loc.#Joc(#0sb, #1sb, #mcb, out #voc);
				if (4 == 0)
				{
					goto IL_DF;
				}
				if (!flag)
				{
					flag2 = #Loc.#Joc(#0sb, #1sb, #ncb, out #voc);
					goto IL_DF;
				}
				int result = 1;
				return result != 0;
				IL_DF:
				if (flag2)
				{
					return true;
				}
				bool flag3 = (result = (#Loc.#Joc(#0sb, #1sb, #Ckc, out #voc) ? 1 : 0)) != 0;
				if (false)
				{
					return result != 0;
				}
				if (flag3)
				{
					return true;
				}
				#Doc = new #c4d(#0sb.X - #mcb.X, #0sb.Y - #mcb.Y, #0sb.Z - #mcb.Z);
				if (4 == 0)
				{
					goto IL_16A;
				}
				*(double*)((byte*)ptr + 16) = #Loc.#Gnc(#Doc, #Eoc) * *(double*)((byte*)ptr + 8);
				if (*(double*)((byte*)ptr + 16) < -0.0001)
				{
					return false;
				}
			}
			#c4d #Eoc2;
			if (*(double*)((byte*)ptr + 16) <= 1.0001)
			{
				#Eoc2 = #Loc.#Dnc(#Doc, #c4d);
				goto IL_16A;
			}
			return false;
			IL_16A:
			*(double*)((byte*)ptr + 24) = #Loc.#Gnc(#1sb, #Eoc2) * *(double*)((byte*)ptr + 8);
			if (*(double*)((byte*)ptr + 24) < -0.0001 || *(double*)((byte*)ptr + 16) + *(double*)((byte*)ptr + 24) > 1.0001)
			{
				return false;
			}
			#voc = #Loc.#Gnc(#c4d2, #Eoc2) * *(double*)((byte*)ptr + 8);
			return true;
		}

		// Token: 0x06003FBC RID: 16316 RVA: 0x00128BB4 File Offset: 0x00126DB4
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#")]
		public unsafe static bool #toc(Point #mcb, Point #ncb, Point #Ckc, Point #Dkc, out Point #woc)
		{
			void* ptr = stackalloc byte[16];
			Point #Ng = #mcb;
			double xField = #ncb.X - #mcb.X;
			double yField = #ncb.Y - #mcb.Y;
			Vector vector;
			if (6 != 0)
			{
				vector = new Vector(xField, yField);
			}
			Point point = #Ckc;
			if (8 == 0)
			{
				goto IL_A4;
			}
			Vector #Eoc = new Vector(#Dkc.X - #Ckc.X, #Dkc.Y - #Ckc.Y);
			#woc = new Point(0.0, 0.0);
			if (2 == 0)
			{
				return false;
			}
			double num = #Loc.#Ioc(vector, #Eoc);
			double num2 = 0.0;
			IL_A0:
			if (num == num2)
			{
				return false;
			}
			IL_A4:
			*(double*)ptr = #Loc.#Ioc(new Vector(point.X - #Ng.X, point.Y - #Ng.Y), #Eoc) / #Loc.#Ioc(vector, #Eoc);
			*(double*)((byte*)ptr + 8) = #Loc.#Ioc(new Vector(point.X - #Ng.X, point.Y - #Ng.Y), vector) / #Loc.#Ioc(vector, #Eoc);
			double num3 = num = *(double*)ptr;
			double num4 = num2 = 0.0;
			if (false)
			{
				goto IL_A0;
			}
			if (num3 >= num4)
			{
				double num5 = *(double*)ptr;
				while (num5 <= 1.0 && *(double*)((byte*)ptr + 8) >= 0.0)
				{
					double num6 = num5 = *(double*)((byte*)ptr + 8);
					if (!false)
					{
						if (num6 > 1.0)
						{
							break;
						}
						#woc = Point.#G3d(#Ng, Vector.#33d(*(double*)ptr, vector));
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06003FBD RID: 16317 RVA: 0x00128D74 File Offset: 0x00126F74
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#")]
		public unsafe static bool #toc(Point3D #0sb, #c4d #1sb, Point3D #xoc, double #yoc, out Point3D #zoc)
		{
			void* ptr = stackalloc byte[24];
			#zoc = new Point3D(0.0, 0.0, 0.0);
			#1sb.#wlc();
			#c4d #c4d = new #c4d(#xoc.X - #0sb.X, #xoc.Y - #0sb.Y, #xoc.Z - #0sb.Z);
			*(double*)ptr = #Loc.#Gnc(#c4d, #1sb);
			if (*(double*)ptr < 0.0)
			{
				return false;
			}
			*(double*)((byte*)ptr + 8) = #Loc.#Gnc(#c4d, #c4d) - *(double*)ptr * *(double*)ptr;
			if (*(double*)((byte*)ptr + 8) > #yoc * #yoc)
			{
				return false;
			}
			*(double*)((byte*)ptr + 16) = \u0006\u0002.\u0007\u0004(#yoc * #yoc - *(double*)((byte*)ptr + 8));
			#zoc = Point3D.#G3d(#0sb, #c4d.#33d(*(double*)ptr - *(double*)((byte*)ptr + 16), #1sb));
			return true;
		}

		// Token: 0x06003FBE RID: 16318 RVA: 0x00128EAC File Offset: 0x001270AC
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#")]
		public unsafe static bool #toc(Point3D #0sb, #c4d #1sb, Point3D #Aoc, Point3D #Boc, out double #Coc)
		{
			void* ptr = stackalloc byte[48];
			#Coc = 0.0;
			double num3;
			for (;;)
			{
				*(double*)ptr = (#Aoc.X - #0sb.X) / #1sb.X;
				*(double*)(ptr + 8) = (#Boc.X - #0sb.X) / #1sb.X;
				if (*(double*)ptr > *(double*)((byte*)ptr + 8))
				{
					#Loc.#Hoc(ref *(double*)ptr, ref *(double*)((byte*)ptr + 8));
				}
				*(double*)((byte*)ptr + 16) = (#Aoc.Y - #0sb.Y) / #1sb.Y;
				*(double*)((byte*)ptr + 24) = (#Boc.Y - #0sb.Y) / #1sb.Y;
				double num2;
				double num = num2 = *(double*)((byte*)ptr + 16);
				for (;;)
				{
					if (-1 != 0)
					{
						if (num2 > *(double*)((byte*)ptr + 24))
						{
							#Loc.#Hoc(ref *(double*)((byte*)ptr + 16), ref *(double*)((byte*)ptr + 24));
						}
						if (*(double*)ptr > *(double*)((byte*)ptr + 24) || *(double*)((byte*)ptr + 16) > *(double*)((byte*)ptr + 8))
						{
							return false;
						}
						if (-1 == 0)
						{
							break;
						}
						if (*(double*)((byte*)ptr + 16) > *(double*)ptr)
						{
							*(double*)ptr = *(double*)((byte*)ptr + 16);
						}
						if (*(double*)((byte*)ptr + 24) < *(double*)((byte*)ptr + 8))
						{
							*(double*)((byte*)ptr + 8) = *(double*)((byte*)ptr + 24);
						}
						*(double*)((byte*)ptr + 32) = (#Aoc.Z - #0sb.Z) / #1sb.Z;
						*(double*)((byte*)ptr + 40) = (#Boc.Z - #0sb.Z) / #1sb.Z;
						num = *(double*)((byte*)ptr + 32);
					}
					if (num > *(double*)((byte*)ptr + 40))
					{
						#Loc.#Hoc(ref *(double*)((byte*)ptr + 32), ref *(double*)((byte*)ptr + 40));
					}
					num3 = (num2 = (num = *(double*)ptr));
					if (6 != 0)
					{
						goto Block_9;
					}
				}
			}
			return false;
			Block_9:
			if (num3 > *(double*)((byte*)ptr + 40) || *(double*)((byte*)ptr + 32) > *(double*)((byte*)ptr + 8))
			{
				return false;
			}
			if (*(double*)((byte*)ptr + 32) > *(double*)ptr)
			{
				*(double*)ptr = *(double*)((byte*)ptr + 32);
			}
			if (*(double*)((byte*)ptr + 40) < *(double*)((byte*)ptr + 8))
			{
				*(double*)((byte*)ptr + 8) = *(double*)((byte*)ptr + 40);
			}
			#Coc = Point3D.#G3d(#0sb, #c4d.#33d(*(double*)ptr, #1sb)).Z;
			return true;
		}

		// Token: 0x06003FBF RID: 16319 RVA: 0x001290AC File Offset: 0x001272AC
		public unsafe static double #Gnc(#c4d #Doc, #c4d #Eoc)
		{
			void* ptr = stackalloc byte[16];
			void* ptr2;
			if (5 != 0)
			{
				ptr2 = ptr;
			}
			*(double*)ptr2 = 0.0001;
			*(double*)(ptr2 + 8) = #Doc.X * #Eoc.X + #Doc.Y * #Eoc.Y + #Doc.Z * #Eoc.Z;
			if (\u0006\u0002.\u0006\u0004(*(double*)((byte*)ptr2 + 8)) < *(double*)ptr2)
			{
				return 0.0;
			}
			return *(double*)((byte*)ptr2 + 8);
		}

		// Token: 0x06003FC0 RID: 16320 RVA: 0x00129144 File Offset: 0x00127344
		public static #c4d #Dnc(#c4d #Doc, #c4d #Eoc)
		{
			return new #c4d(#Doc.Y * #Eoc.Z - #Doc.Z * #Eoc.Y, #Doc.Z * #Eoc.X - #Doc.X * #Eoc.Z, #Doc.X * #Eoc.Y - #Doc.Y * #Eoc.X);
		}

		// Token: 0x06003FC1 RID: 16321 RVA: 0x001291D8 File Offset: 0x001273D8
		public static double #Foc(#c4d #dtb)
		{
			double num5;
			if (!false)
			{
				#c4d #c4d = new #c4d(#dtb.X, #dtb.Y, 0.0);
				double num2;
				double num = num2 = \u0011\u0002.\u0089\u0004(#c4d.Y, #c4d.X);
				double num4;
				double num3 = num4 = 3.141592653589793;
				if (7 != 0)
				{
					num2 = num / num3;
					goto IL_43;
				}
				double num6;
				double num7;
				do
				{
					IL_4C:
					num5 = num2 * num4;
					num6 = (num2 = num5);
					num7 = (num4 = 0.0);
				}
				while (false);
				if (num6 >= num7)
				{
					return num5;
				}
				double result;
				double num8 = num2 = (result = num5);
				if (2 != 0)
				{
					result = (num2 = num8 + 360.0);
				}
				if (3 != 0)
				{
					return result;
				}
				IL_43:
				num4 = 180.0;
				goto IL_4C;
			}
			return num5;
		}

		// Token: 0x06003FC2 RID: 16322 RVA: 0x001292A0 File Offset: 0x001274A0
		public unsafe static #c4d #Goc(double #Udb)
		{
			double #9o;
			double #7W;
			#c4d result;
			for (;;)
			{
				IL_00:
				void* ptr = stackalloc byte[16];
				for (;;)
				{
					double num = #Udb;
					double num6;
					for (;;)
					{
						#Udb = num % 360.0;
						if (#Udb == 90.0)
						{
							goto Block_0;
						}
						if (!true)
						{
							goto IL_00;
						}
						if (#Udb == 270.0)
						{
							goto Block_2;
						}
						double num2 = #Udb;
						double num3 = 3.141592653589793;
						double num4;
						double num5;
						do
						{
							num4 = (num2 *= num3);
							num5 = (num3 = 180.0);
						}
						while (false);
						#Udb = num4 / num5;
						num6 = (num = (#9o = \u0006\u0002.\u0011\u0004(#Udb)));
						*(double*)ptr = 0.0;
						double num7 = #Udb;
						double num8 = 1.5707963267948966;
						while (num7 > num8)
						{
							double num9 = num7 = #Udb;
							double num10 = num8 = 4.71238898038469;
							if (!false)
							{
								if (num9 < num10)
								{
									goto Block_6;
								}
								break;
							}
						}
						if (!false)
						{
							goto Block_7;
						}
					}
					IL_F7:
					double num11 = #7W = *(double*)((byte*)ptr + 8);
					if (7 == 0)
					{
						goto IL_40;
					}
					double #7W2 = num6 * num11 + *(double*)ptr;
					result = new #c4d(*(double*)((byte*)ptr + 8), #7W2, 0.0);
					if (4 != 0)
					{
						goto Block_9;
					}
					continue;
					Block_6:
					*(double*)((byte*)ptr + 8) = -1.0;
					goto IL_F7;
					Block_7:
					*(double*)((byte*)ptr + 8) = 1.0;
					goto IL_F7;
				}
			}
			Block_0:
			#9o = 0.0;
			#7W = 1.0;
			IL_40:
			return new #c4d(#9o, #7W, 0.0);
			Block_2:
			return new #c4d(0.0, -1.0, 0.0);
			Block_9:
			result.#wlc();
			return result;
		}

		// Token: 0x06003FC3 RID: 16323 RVA: 0x00129418 File Offset: 0x00127618
		private static void #Hoc(ref double #5Gb, ref double #6Gb)
		{
			if (!true)
			{
				goto IL_11;
			}
			double num;
			if (!false)
			{
				num = #5Gb;
			}
			IL_0B:
			#5Gb = #6Gb;
			IL_11:
			#6Gb = num;
			if (!false && !false)
			{
				return;
			}
			goto IL_0B;
		}

		// Token: 0x06003FC4 RID: 16324 RVA: 0x00035EBB File Offset: 0x000340BB
		private static double #Ioc(Vector #Doc, Vector #Eoc)
		{
			double num = #Doc.X;
			double result;
			for (;;)
			{
				double num2 = #Eoc.Y;
				double num3;
				double num5;
				for (;;)
				{
					num3 = (num = (result = num * num2));
					if (false)
					{
						break;
					}
					double num4 = num2 = #Doc.Y;
					while (!false)
					{
						num5 = (num2 = (num4 *= #Eoc.X));
						if (!false)
						{
							goto Block_3;
						}
					}
				}
				IL_1C:
				if (!false)
				{
					break;
				}
				continue;
				Block_3:
				result = (num = num3 - num5);
				goto IL_1C;
			}
			return result;
		}

		// Token: 0x06003FC5 RID: 16325 RVA: 0x00129454 File Offset: 0x00127654
		private static bool #Joc(Point3D #0sb, #c4d #1sb, Point3D #Ng, out double #voc)
		{
			int result;
			if (3 != 0)
			{
				bool flag = (result = (#Loc.#Koc(#1sb, new #c4d(#Ng.X - #0sb.X, #Ng.Y - #0sb.Y, #Ng.Z - #0sb.Z)) ? 1 : 0)) != 0;
				if (false)
				{
					return result != 0;
				}
				if (!flag)
				{
					#voc = 0.0;
					goto IL_5E;
				}
			}
			if (2 != 0)
			{
				if (3 == 0)
				{
					goto IL_5E;
				}
				#voc = (#Ng.X - #0sb.X) / #1sb.X;
			}
			return true;
			IL_5E:
			result = 0;
			return result != 0;
		}

		// Token: 0x06003FC6 RID: 16326 RVA: 0x00129510 File Offset: 0x00127710
		private static bool #Koc(#c4d #Doc, #c4d #Eoc)
		{
			#Doc.#wlc();
			#Eoc.#wlc();
			double num;
			double x = num = #Doc.X;
			if (6 != 0)
			{
				Point3D #mcb = new Point3D(x, #Doc.Y, #Doc.Z);
				Point3D #ncb = new Point3D(#Eoc.X, #Eoc.Y, #Eoc.Z);
				num = GeometryHelper.#lcb(#mcb, #ncb);
			}
			return num < 0.0001;
		}

		// Token: 0x04001CDB RID: 7387
		private const double #a = 0.0001;
	}
}

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Misc
{
	// Token: 0x020007AF RID: 1967
	[DebuggerDisplay("{CoefficientA}*x + {CoefficientB}*y + {CoefficientC}")]
	public sealed class GeneralLineEquation
	{
		// Token: 0x06003EFB RID: 16123 RVA: 0x00122464 File Offset: 0x00120664
		static GeneralLineEquation()
		{
			if (-1 == 0)
			{
				goto IL_26;
			}
			Point point = default(Point);
			GeneralLineEquation.XAxis = new GeneralLineEquation(point, 0.0, false);
			IL_1B:
			if (false)
			{
				goto IL_40;
			}
			point = default(Point);
			IL_26:
			GeneralLineEquation.YAxis = new GeneralLineEquation(point, new Point(0.0, 1.0));
			IL_40:
			if (false)
			{
				goto IL_26;
			}
			if (true)
			{
				return;
			}
			goto IL_1B;
		}

		// Token: 0x06003EFC RID: 16124 RVA: 0x0003589E File Offset: 0x00033A9E
		public GeneralLineEquation(double coefficientA, double coefficientB, double coefficientC)
		{
			this.CoefficientA = coefficientA;
			this.CoefficientB = coefficientB;
			this.CoefficientC = coefficientC;
			this.#Jlc();
		}

		// Token: 0x06003EFD RID: 16125 RVA: 0x001224E0 File Offset: 0x001206E0
		public GeneralLineEquation(Point point1, Point point2)
		{
			this.CoefficientA = point1.Y - point2.Y;
			this.CoefficientB = point2.X - point1.X;
			this.CoefficientC = (point1.X - point2.X) * point1.Y + (point2.Y - point1.Y) * point1.X;
			this.#Jlc();
		}

		// Token: 0x06003EFE RID: 16126 RVA: 0x00122558 File Offset: 0x00120758
		public GeneralLineEquation(Point location, double angle, bool roundZero)
		{
			double num = Math.Tan(GeometryHelper.#Qmc(angle));
			if (roundZero && #Emc.#Bmc(num))
			{
				num = 0.0;
			}
			double num2 = num;
			double num3 = -num * location.X + location.Y;
			this.CoefficientA = -num2;
			this.CoefficientB = 1.0;
			this.CoefficientC = -num3;
			this.#Jlc();
		}

		// Token: 0x06003EFF RID: 16127 RVA: 0x001225C8 File Offset: 0x001207C8
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
		public double #llc(double #mlc)
		{
			double num = this.CoefficientB;
			double result;
			for (;;)
			{
				double num2 = num * #mlc;
				for (;;)
				{
					double num3 = num = num2 + this.CoefficientC;
					if (false)
					{
						break;
					}
					double num4 = num = (num2 = -num3);
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						result = (num2 = num4 / this.CoefficientA);
						if (!false)
						{
							return result;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06003F00 RID: 16128 RVA: 0x00122614 File Offset: 0x00120814
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
		public double #nlc(double #olc)
		{
			double num = this.CoefficientA;
			double result;
			for (;;)
			{
				double num2 = num * #olc;
				for (;;)
				{
					double num3 = num = num2 + this.CoefficientC;
					if (false)
					{
						break;
					}
					double num4 = num = (num2 = -num3);
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						result = (num2 = num4 / this.CoefficientB);
						if (!false)
						{
							return result;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06003F01 RID: 16129 RVA: 0x00122660 File Offset: 0x00120860
		public unsafe Point? #plc(GeneralLineEquation #qlc)
		{
			void* ptr = stackalloc byte[64];
			#X0d.#V0d(#qlc, #Phc.#3hc(107372904), Component.Geometry, #Phc.#3hc(107372875));
			do
			{
				*(double*)ptr = this.CoefficientA;
				*(double*)(ptr + 8) = this.CoefficientB;
				*(double*)((byte*)ptr + 16) = this.CoefficientC;
				*(double*)((byte*)ptr + 24) = #qlc.CoefficientA;
				*(double*)((byte*)ptr + 32) = #qlc.CoefficientB;
			}
			while (7 == 0);
			*(double*)((byte*)ptr + 40) = #qlc.CoefficientC;
			*(double*)((byte*)ptr + 48) = *(double*)ptr * *(double*)((byte*)ptr + 32) - *(double*)((byte*)ptr + 24) * *(double*)((byte*)ptr + 8);
			while (#Emc.#U3(*(double*)((byte*)ptr + 48)))
			{
				if (!false)
				{
					return null;
				}
			}
			double num = -(*(double*)((byte*)ptr + 16)) * *(double*)((byte*)ptr + 32) - -(*(double*)((byte*)ptr + 40)) * *(double*)((byte*)ptr + 8);
			*(double*)((byte*)ptr + 56) = *(double*)ptr * -(*(double*)((byte*)ptr + 40)) - *(double*)((byte*)ptr + 24) * -(*(double*)((byte*)ptr + 16));
			return new Point?(new Point(num / *(double*)((byte*)ptr + 48), *(double*)((byte*)ptr + 56) / *(double*)((byte*)ptr + 48)));
		}

		// Token: 0x06003F02 RID: 16130 RVA: 0x001227A8 File Offset: 0x001209A8
		public GeneralLineEquation #rlc(Point #Ng)
		{
			double num = -this.CoefficientB;
			double num2 = this.CoefficientA;
			double num3 = num;
			double num4 = #Ng.X;
			double coefficientB;
			double num5;
			double coefficientC;
			double num6;
			do
			{
				num5 = (num3 = (coefficientB = num3 * num4));
				num6 = (num4 = (coefficientC = num2 * #Ng.Y));
				if (false || false)
				{
					goto IL_2A;
				}
			}
			while (-1 == 0);
			double num7 = coefficientB = -(num5 + num6);
			double num8;
			if (!false)
			{
				num8 = num7;
				coefficientB = num2;
			}
			coefficientC = num8;
			IL_2A:
			return new GeneralLineEquation(num, coefficientB, coefficientC);
		}

		// Token: 0x06003F03 RID: 16131 RVA: 0x00122810 File Offset: 0x00120A10
		public unsafe bool #slc(GeneralLineEquation #L0, bool #tlc)
		{
			void* ptr;
			if (!false)
			{
				ptr = stackalloc byte[16];
				#X0d.#V0d(#L0, #Phc.#3hc(107399401), Component.Geometry, #Phc.#3hc(107372854));
			}
			*(double*)ptr = this.CoefficientA * #L0.CoefficientB;
			*(double*)((byte*)ptr + 8) = #L0.CoefficientA * this.CoefficientB;
			double #4gb2;
			double #4gb;
			double #5gb;
			if (!#tlc)
			{
				#4gb = (#4gb2 = *(double*)ptr);
			}
			else
			{
				#4gb = (#4gb2 = *(double*)ptr);
				if (!false && 5 != 0 && !false)
				{
					#5gb = *(double*)((byte*)ptr + 8);
					goto IL_70;
				}
			}
			double #5gb2 = #5gb = *(double*)((byte*)ptr + 8);
			if (6 != 0)
			{
				return #Emc.#zmc(#4gb2, #5gb2);
			}
			IL_70:
			return #Emc.#Amc(#4gb, #5gb);
		}

		// Token: 0x06003F04 RID: 16132 RVA: 0x001228D8 File Offset: 0x00120AD8
		public double #lcb(Point #Ng)
		{
			double result;
			double num = result = \u0006\u0002.\u0006\u0004(this.CoefficientA * #Ng.X + this.CoefficientB * #Ng.Y + this.CoefficientC);
			if (!false)
			{
				result = num / this.#a;
			}
			return result;
		}

		// Token: 0x06003F05 RID: 16133 RVA: 0x00122944 File Offset: 0x00120B44
		public Vector #ulc()
		{
			Vector result = new Vector(this.CoefficientA, this.CoefficientB);
			result.#wlc();
			return result;
		}

		// Token: 0x06003F06 RID: 16134 RVA: 0x00122988 File Offset: 0x00120B88
		public bool #vlc(Point #Ng, bool #tlc)
		{
			double num = this.#nlc(#Ng.X);
			double #4gb2;
			double #5gb2;
			bool result;
			for (;;)
			{
				bool flag = #tlc;
				for (;;)
				{
					double #4gb;
					if (!flag)
					{
						if (-1 == 0)
						{
							break;
						}
						#4gb = (#4gb2 = num);
					}
					else
					{
						#4gb = (#4gb2 = num);
						if (!false)
						{
							goto Block_5;
						}
					}
					double #5gb = #5gb2 = #Ng.Y;
					if (!true)
					{
						goto IL_2C;
					}
					result = (flag = #Emc.#zmc(#4gb, #5gb));
					if (true)
					{
						return result;
					}
				}
			}
			return result;
			Block_5:
			#5gb2 = #Ng.Y;
			IL_2C:
			return #Emc.#Amc(#4gb2, #5gb2);
		}

		// Token: 0x06003F07 RID: 16135 RVA: 0x001229F4 File Offset: 0x00120BF4
		public void #wlc()
		{
			double num;
			if (!false && -1 != 0)
			{
				num = \u0006\u0002.\u0007\u0004(this.CoefficientA * this.CoefficientA + this.CoefficientB * this.CoefficientB);
			}
			this.CoefficientA /= num;
			this.CoefficientB /= num;
			this.CoefficientC /= num;
			this.#Jlc();
		}

		// Token: 0x1700131E RID: 4894
		// (get) Token: 0x06003F08 RID: 16136 RVA: 0x000358C1 File Offset: 0x00033AC1
		// (set) Token: 0x06003F09 RID: 16137 RVA: 0x000358CD File Offset: 0x00033ACD
		public double CoefficientA { get; private set; }

		// Token: 0x1700131F RID: 4895
		// (get) Token: 0x06003F0A RID: 16138 RVA: 0x000358DE File Offset: 0x00033ADE
		// (set) Token: 0x06003F0B RID: 16139 RVA: 0x000358EA File Offset: 0x00033AEA
		public double CoefficientB { get; private set; }

		// Token: 0x17001320 RID: 4896
		// (get) Token: 0x06003F0C RID: 16140 RVA: 0x000358FB File Offset: 0x00033AFB
		// (set) Token: 0x06003F0D RID: 16141 RVA: 0x00035907 File Offset: 0x00033B07
		public double CoefficientC { get; private set; }

		// Token: 0x17001321 RID: 4897
		// (get) Token: 0x06003F0E RID: 16142 RVA: 0x00035918 File Offset: 0x00033B18
		// (set) Token: 0x06003F0F RID: 16143 RVA: 0x00035924 File Offset: 0x00033B24
		public double Tangent { get; private set; }

		// Token: 0x17001322 RID: 4898
		// (get) Token: 0x06003F10 RID: 16144 RVA: 0x00035935 File Offset: 0x00033B35
		// (set) Token: 0x06003F11 RID: 16145 RVA: 0x0003593C File Offset: 0x00033B3C
		public static GeneralLineEquation XAxis { get; private set; }

		// Token: 0x17001323 RID: 4899
		// (get) Token: 0x06003F12 RID: 16146 RVA: 0x00035948 File Offset: 0x00033B48
		// (set) Token: 0x06003F13 RID: 16147 RVA: 0x0003594F File Offset: 0x00033B4F
		public static GeneralLineEquation YAxis { get; private set; }

		// Token: 0x06003F14 RID: 16148 RVA: 0x00122A84 File Offset: 0x00120C84
		private void #Jlc()
		{
			this.#a = \u0006\u0002.\u0007\u0004(this.CoefficientA * this.CoefficientA + this.CoefficientB * this.CoefficientB);
			this.Tangent = this.CoefficientA / this.CoefficientB;
		}

		// Token: 0x04001CB1 RID: 7345
		private double #a;

		// Token: 0x04001CB2 RID: 7346
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001CB3 RID: 7347
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001CB4 RID: 7348
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001CB5 RID: 7349
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001CB6 RID: 7350
		[CompilerGenerated]
		private static GeneralLineEquation #f;

		// Token: 0x04001CB7 RID: 7351
		[CompilerGenerated]
		private static GeneralLineEquation #g;
	}
}

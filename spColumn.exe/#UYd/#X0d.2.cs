using System;
using #cYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #UYd
{
	// Token: 0x02000EDA RID: 3802
	internal static class #X0d
	{
		// Token: 0x060086DF RID: 34527 RVA: 0x001CF188 File Offset: 0x001CD388
		public static void #K6c(int #Sb, string #R0d, int #S0d, int #T0d, Component #x6c, string #Qic)
		{
			if (7 == 0 || false || #Sb < #S0d || #Sb > #T0d)
			{
				throw new #jYd(#R0d, Strings.StringValidRangeIsFromXToY.#D2d(new object[]
				{
					#S0d,
					#T0d
				}).#z2d(), #Qic, #x6c, #IYd.#c);
			}
		}

		// Token: 0x060086E0 RID: 34528 RVA: 0x001CF1D8 File Offset: 0x001CD3D8
		public static void #K6c(double #Sb, string #R0d, double #S0d, double #T0d, Component #x6c, string #Qic)
		{
			if (7 == 0 || false || #Sb < #S0d || #Sb > #T0d)
			{
				throw new #jYd(#R0d, Strings.StringValidRangeIsFromXToY.#D2d(new object[]
				{
					#S0d,
					#T0d
				}).#z2d(), #Qic, #x6c, #IYd.#c);
			}
		}

		// Token: 0x060086E1 RID: 34529 RVA: 0x001CF228 File Offset: 0x001CD428
		public static void #K6c(float #Sb, string #R0d, float #S0d, float #T0d, Component #x6c, string #Qic)
		{
			if (7 == 0 || false || #Sb < #S0d || #Sb > #T0d)
			{
				throw new #jYd(#R0d, Strings.StringValidRangeIsFromXToY.#D2d(new object[]
				{
					#S0d,
					#T0d
				}).#z2d(), #Qic, #x6c, #IYd.#c);
			}
		}

		// Token: 0x060086E2 RID: 34530 RVA: 0x001CF278 File Offset: 0x001CD478
		public static void #K6c(decimal #Sb, string #R0d, decimal #S0d, decimal #T0d, Component #x6c, string #Qic)
		{
			if (#Sb < #S0d || #Sb > #T0d)
			{
				throw new #jYd(#R0d, Strings.StringValidRangeIsFromXToY.#D2d(new object[]
				{
					#S0d,
					#T0d
				}).#z2d(), #Qic, #x6c, #IYd.#c);
			}
		}

		// Token: 0x060086E3 RID: 34531 RVA: 0x0006DA89 File Offset: 0x0006BC89
		public static void #U0d(int #Sb, string #R0d, Component #x6c, string #Qic)
		{
			while (!false && #Sb >= 0)
			{
				if (!false)
				{
					return;
				}
			}
			throw new #jYd(#R0d, Strings.StringValueShouldNotBeNegative.#z2d(), #Qic, #x6c, #IYd.#c);
		}

		// Token: 0x060086E4 RID: 34532 RVA: 0x0006DAAA File Offset: 0x0006BCAA
		public static void #U0d(double #Sb, string #R0d, Component #x6c, string #Qic)
		{
			while (!false && #Sb >= 0.0)
			{
				if (!false)
				{
					return;
				}
			}
			throw new #jYd(#R0d, Strings.StringValueShouldNotBeNegative.#z2d(), #Qic, #x6c, #IYd.#c);
		}

		// Token: 0x060086E5 RID: 34533 RVA: 0x0006DAD3 File Offset: 0x0006BCD3
		public static void #U0d(float #Sb, string #R0d, Component #x6c, string #Qic)
		{
			while (!false && #Sb >= 0f)
			{
				if (!false)
				{
					return;
				}
			}
			throw new #jYd(#R0d, Strings.StringValueShouldNotBeNegative.#z2d(), #Qic, #x6c, #IYd.#c);
		}

		// Token: 0x060086E6 RID: 34534 RVA: 0x0006DAF8 File Offset: 0x0006BCF8
		public static void #U0d(decimal #Sb, string #R0d, Component #x6c, string #Qic)
		{
			while (#Sb < 0m || false)
			{
				if (6 != 0)
				{
					throw new #jYd(#R0d, Strings.StringValueShouldNotBeNegative.#z2d(), #Qic, #x6c, #IYd.#c);
				}
			}
		}

		// Token: 0x060086E7 RID: 34535 RVA: 0x0006DB22 File Offset: 0x0006BD22
		public static void #V0d([#Q0d] object #Rf, string #R0d, Component #x6c, string #Qic)
		{
			if (#Rf == null)
			{
				throw new #iYd(#R0d, #Qic, #x6c, #IYd.#c);
			}
		}

		// Token: 0x060086E8 RID: 34536 RVA: 0x0006DB32 File Offset: 0x0006BD32
		public static void #W0d([#Q0d] string #Sb, string #R0d, Component #x6c, string #Qic)
		{
			while (!false && !string.IsNullOrWhiteSpace(#Sb))
			{
				if (!false)
				{
					return;
				}
			}
			throw new #hYd(#R0d, #Qic, Strings.StringValueShouldNotBeEmpty.#z2d(), #x6c, #IYd.#c);
		}
	}
}

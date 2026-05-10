using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #cYd;
using #N7d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Units
{
	// Token: 0x02000F53 RID: 3923
	public static class UniversalUnitConverter
	{
		// Token: 0x06008A86 RID: 35462 RVA: 0x00070B32 File Offset: 0x0006ED32
		public static double #Pb(LengthUnit #J7d, LengthUnit #b4, double #f)
		{
			return UniversalUnitConverter.#a.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A87 RID: 35463 RVA: 0x00070B4D File Offset: 0x0006ED4D
		public static double #Pb(AreaUnit #J7d, AreaUnit #b4, double #f)
		{
			return UniversalUnitConverter.#b.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A88 RID: 35464 RVA: 0x00070B68 File Offset: 0x0006ED68
		public static double #Pb(ForceUnit #J7d, ForceUnit #b4, double #f)
		{
			return UniversalUnitConverter.#c.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A89 RID: 35465 RVA: 0x00070B83 File Offset: 0x0006ED83
		public static double #Pb(MomentUnit #J7d, MomentUnit #b4, double #f)
		{
			return UniversalUnitConverter.#d.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8A RID: 35466 RVA: 0x00070B9E File Offset: 0x0006ED9E
		public static double #Pb(ForcePerLengthUnit #J7d, ForcePerLengthUnit #b4, double #f)
		{
			return UniversalUnitConverter.#e.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8B RID: 35467 RVA: 0x00070BB9 File Offset: 0x0006EDB9
		public static double #Pb(ForcePerAreaUnit #J7d, ForcePerAreaUnit #b4, double #f)
		{
			return UniversalUnitConverter.#f.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8C RID: 35468 RVA: 0x00070BD4 File Offset: 0x0006EDD4
		public static double #Pb(ForcePerVolumeUnit #J7d, ForcePerVolumeUnit #b4, double #f)
		{
			return UniversalUnitConverter.#g.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8D RID: 35469 RVA: 0x00070BEF File Offset: 0x0006EDEF
		public static double #Pb(AngleUnit #J7d, AngleUnit #b4, double #f)
		{
			return UniversalUnitConverter.#h.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8E RID: 35470 RVA: 0x00070C0A File Offset: 0x0006EE0A
		public static double #Pb(MassPerVolumeUnit #J7d, MassPerVolumeUnit #b4, double #f)
		{
			return UniversalUnitConverter.#i.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A8F RID: 35471 RVA: 0x00070C25 File Offset: 0x0006EE25
		public static double #Pb(DensityAndUnitWeightUnit #J7d, DensityAndUnitWeightUnit #b4, double #f)
		{
			return UniversalUnitConverter.#n.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A90 RID: 35472 RVA: 0x00070C40 File Offset: 0x0006EE40
		public static double #Pb(AreaPerLengthUnit #J7d, AreaPerLengthUnit #b4, double #f)
		{
			return UniversalUnitConverter.#j.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A91 RID: 35473 RVA: 0x00070C5B File Offset: 0x0006EE5B
		public static double #Pb(DimensionlessUnit #J7d, DimensionlessUnit #b4, double #f)
		{
			return UniversalUnitConverter.#k.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A92 RID: 35474 RVA: 0x00070C76 File Offset: 0x0006EE76
		public static double #Pb(MomentPerLengthUnit #J7d, MomentPerLengthUnit #b4, double #f)
		{
			return UniversalUnitConverter.#l.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A93 RID: 35475 RVA: 0x00070C91 File Offset: 0x0006EE91
		public static double #Pb(MomentPerAngleUnit #J7d, MomentPerAngleUnit #b4, double #f)
		{
			return UniversalUnitConverter.#m.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A94 RID: 35476 RVA: 0x00070CAC File Offset: 0x0006EEAC
		public static double #Pb(AreaMomentOfInertiaUnit #J7d, AreaMomentOfInertiaUnit #b4, double #f)
		{
			return UniversalUnitConverter.#o.#Pb(#J7d, #b4, #f);
		}

		// Token: 0x06008A95 RID: 35477 RVA: 0x001D8788 File Offset: 0x001D6988
		[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
		public static double #Pb(Enum #J7d, Enum #b4, double #f)
		{
			#X0d.#V0d(#J7d, #Phc.#3hc(107218871), Component.Units, #Phc.#3hc(107218826));
			#X0d.#V0d(#b4, #Phc.#3hc(107218805), Component.Units, #Phc.#3hc(107218756));
			Type type = #J7d.GetType();
			Type type2 = #b4.GetType();
			if (!#Z7d.#U7d(type))
			{
				throw new #hYd(#Phc.#3hc(107218703), Strings.StringSpecifiedUnitTypeIsNotSupported.#z2d(), #Phc.#3hc(107218718), Component.Units, #IYd.#e);
			}
			if (type != type2)
			{
				throw new #hYd(#Phc.#3hc(107218871), Strings.StringConversionBetweenTheSpecifiedUnitsIsNotPossible.#z2d(), #Phc.#3hc(107218121), Component.Units, #IYd.#a, #JYd.#d);
			}
			if (!#Z7d.#X7d(#J7d))
			{
				throw new #hYd(#Phc.#3hc(107218871), Strings.StringTheSpecifiedUnitInNotSupported.#z2d(), #Phc.#3hc(107218100), Component.Units, #IYd.#e);
			}
			if (!#Z7d.#X7d(#b4))
			{
				throw new #hYd(#Phc.#3hc(107218805), Strings.StringTheSpecifiedUnitInNotSupported.#z2d(), #Phc.#3hc(107218047), Component.Units, #IYd.#e);
			}
			Func<Enum, Enum, double, double> func = UniversalUnitConverter.#q.#F1d(type);
			if (func != null)
			{
				return func(#J7d, #b4, #f);
			}
			throw new #hYd(#Phc.#3hc(107218871), Strings.StringConversionBetweenTheSpecifiedUnitsIsNotPossible.#z2d(), #Phc.#3hc(107217962), Component.Units, #IYd.#a, #JYd.#d);
		}

		// Token: 0x04003905 RID: 14597
		private static readonly #M8d #a = new LengthConverter();

		// Token: 0x04003906 RID: 14598
		private static readonly #X8d #b = new #O8d();

		// Token: 0x04003907 RID: 14599
		private static readonly #Y8d #c = new #Q8d();

		// Token: 0x04003908 RID: 14600
		private static readonly #Z8d #d = new #58d();

		// Token: 0x04003909 RID: 14601
		private static readonly #V8d #e = new #S8d();

		// Token: 0x0400390A RID: 14602
		private static readonly #08d #f = new #88d();

		// Token: 0x0400390B RID: 14603
		private static readonly #W8d #g = new #U8d();

		// Token: 0x0400390C RID: 14604
		private static readonly #07d #h = new #17d();

		// Token: 0x0400390D RID: 14605
		private static readonly #I8d #i = new #47d();

		// Token: 0x0400390E RID: 14606
		private static readonly #F8d #j = new #37d();

		// Token: 0x0400390F RID: 14607
		private static readonly #H8d #k = new #P7d();

		// Token: 0x04003910 RID: 14608
		private static readonly #K8d #l = new #87d();

		// Token: 0x04003911 RID: 14609
		private static readonly #J8d #m = new #67d();

		// Token: 0x04003912 RID: 14610
		private static readonly #G8d #n = new #O7d();

		// Token: 0x04003913 RID: 14611
		private static readonly #E8d #o = new #M7d();

		// Token: 0x04003914 RID: 14612
		private static readonly #Q7d #p = new #S7d();

		// Token: 0x04003915 RID: 14613
		private static readonly Dictionary<Type, Func<Enum, Enum, double, double>> #q = new Dictionary<Type, Func<Enum, Enum, double, double>>
		{
			{
				typeof(AngleUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Lae)
			},
			{
				typeof(AreaPerLengthUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Mae)
			},
			{
				typeof(AreaUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Nae)
			},
			{
				typeof(DensityAndUnitWeightUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Oae)
			},
			{
				typeof(DimensionlessUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Pae)
			},
			{
				typeof(ForcePerAreaUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Qae)
			},
			{
				typeof(ForcePerLengthUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Rae)
			},
			{
				typeof(ForcePerVolumeUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Sae)
			},
			{
				typeof(ForceUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Tae)
			},
			{
				typeof(LengthUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Uae)
			},
			{
				typeof(MassPerVolumeUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Vae)
			},
			{
				typeof(MomentPerAngleUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Wae)
			},
			{
				typeof(MomentPerLengthUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Xae)
			},
			{
				typeof(MomentUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Yae)
			},
			{
				typeof(AreaMomentOfInertiaUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#Zae)
			},
			{
				typeof(MassPerLengthUnit),
				new Func<Enum, Enum, double, double>(UniversalUnitConverter.<>c.<>9.#0ae)
			}
		};
	}
}

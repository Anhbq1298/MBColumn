using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #A9d;
using #N7d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Units.UnitSets
{
	// Token: 0x02000FA0 RID: 4000
	public static class UnitSymbolProvider
	{
		// Token: 0x06008B75 RID: 35701 RVA: 0x001DC648 File Offset: 0x001DA848
		public static IUnitSymbol #29d(Enum #Y7d)
		{
			#X0d.#V0d(#Y7d, #Phc.#3hc(107217941), Component.Units, #Phc.#3hc(107248982));
			Type type = #Y7d.GetType();
			if (!#Z7d.#U7d(type))
			{
				throw new NotSupportedException(Strings.StringSpecifiedUnitTypeIsNotSupported.#z2d());
			}
			Func<Enum, IUnitSymbol> func = UnitSymbolProvider.#a.#F1d(type);
			IUnitSymbol result = null;
			if (func != null)
			{
				result = func(#Y7d);
			}
			return result;
		}

		// Token: 0x06008B76 RID: 35702 RVA: 0x000716B8 File Offset: 0x0006F8B8
		public static IUnitSymbol #29d(DensityAndUnitWeightUnit #39d)
		{
			if (#39d == DensityAndUnitWeightUnit.KilogramPerCubicMeter)
			{
				return UnitSymbolProvider.#fb;
			}
			if (#39d != DensityAndUnitWeightUnit.PoundForcePerCubicFoot)
			{
				return null;
			}
			return UnitSymbolProvider.#P;
		}

		// Token: 0x06008B77 RID: 35703 RVA: 0x000716D8 File Offset: 0x0006F8D8
		public static IUnitSymbol #29d(MomentPerAngleUnit #49d)
		{
			switch (#49d)
			{
			case MomentPerAngleUnit.KiloNewtonMeterPerRadian:
				return UnitSymbolProvider.#8;
			case MomentPerAngleUnit.MegaNewtonMeterPerRadian:
				return UnitSymbolProvider.#9;
			case MomentPerAngleUnit.FootKiloPoundForcePerRadian:
				return UnitSymbolProvider.#ab;
			case MomentPerAngleUnit.InchPoundForcePerRadian:
				return UnitSymbolProvider.#bb;
			default:
				return null;
			}
		}

		// Token: 0x06008B78 RID: 35704 RVA: 0x001DC6B8 File Offset: 0x001DA8B8
		public static IUnitSymbol #29d(MomentPerLengthUnit #59d)
		{
			switch (#59d)
			{
			case MomentPerLengthUnit.NewtonMeterPerMeter:
				return UnitSymbolProvider.#W;
			case MomentPerLengthUnit.Newton:
				return UnitSymbolProvider.#R;
			case MomentPerLengthUnit.KiloNewtonMeterPerMeter:
				return UnitSymbolProvider.#X;
			case MomentPerLengthUnit.KiloNewton:
				return UnitSymbolProvider.#S;
			case MomentPerLengthUnit.InchPoundForcePerInch:
				return UnitSymbolProvider.#Y;
			case MomentPerLengthUnit.PoundForce:
				return UnitSymbolProvider.#T;
			case MomentPerLengthUnit.FootKiloPoundForcePerFoot:
				return UnitSymbolProvider.#Z;
			case MomentPerLengthUnit.KiloPoundForce:
				return UnitSymbolProvider.#U;
			default:
				return null;
			}
		}

		// Token: 0x06008B79 RID: 35705 RVA: 0x0007170F File Offset: 0x0006F90F
		public static IUnitSymbol #29d(DimensionlessUnit #69d)
		{
			switch (#69d)
			{
			case DimensionlessUnit.ConstantValue:
				return UnitSymbolProvider.#cb;
			case DimensionlessUnit.Percent:
				return UnitSymbolProvider.#db;
			case DimensionlessUnit.PerMille:
				return UnitSymbolProvider.#eb;
			default:
				return null;
			}
		}

		// Token: 0x06008B7A RID: 35706 RVA: 0x0007173C File Offset: 0x0006F93C
		public static IUnitSymbol #29d(AreaPerLengthUnit #79d)
		{
			switch (#79d)
			{
			case AreaPerLengthUnit.InchSquaredPerFoot:
				return UnitSymbolProvider.#x;
			case AreaPerLengthUnit.InchSquaredPerInch:
				return UnitSymbolProvider.#w;
			case AreaPerLengthUnit.CentimeterSquaredPerMeter:
				return UnitSymbolProvider.#v;
			case AreaPerLengthUnit.MillimeterSquaredPerMeter:
				return UnitSymbolProvider.#u;
			default:
				return null;
			}
		}

		// Token: 0x06008B7B RID: 35707 RVA: 0x00071773 File Offset: 0x0006F973
		public static IUnitSymbol #29d(MassPerVolumeUnit #89d)
		{
			if (#89d == MassPerVolumeUnit.KilogramPerCubicMeter)
			{
				return UnitSymbolProvider.#fb;
			}
			return null;
		}

		// Token: 0x06008B7C RID: 35708 RVA: 0x001DC724 File Offset: 0x001DA924
		public static IUnitSymbol #29d(ForcePerVolumeUnit #99d)
		{
			switch (#99d)
			{
			case ForcePerVolumeUnit.NewtonPerCubicMeter:
				return UnitSymbolProvider.#L;
			case ForcePerVolumeUnit.KiloNewtonPerCubicMeter:
				return UnitSymbolProvider.#N;
			case ForcePerVolumeUnit.MegaNewtonPerCubicMeter:
				return UnitSymbolProvider.#M;
			case ForcePerVolumeUnit.PoundForcePerCubicInch:
				return UnitSymbolProvider.#O;
			case ForcePerVolumeUnit.PoundForcePerCubicFoot:
				return UnitSymbolProvider.#P;
			case ForcePerVolumeUnit.KiloPoundForcePerCubicFoot:
				return UnitSymbolProvider.#Q;
			default:
				return null;
			}
		}

		// Token: 0x06008B7D RID: 35709 RVA: 0x001DC77C File Offset: 0x001DA97C
		public static IUnitSymbol #29d(ForcePerAreaUnit #78d)
		{
			switch (#78d)
			{
			case ForcePerAreaUnit.Pascal:
				return UnitSymbolProvider.#n;
			case ForcePerAreaUnit.Kilopascal:
				return UnitSymbolProvider.#o;
			case ForcePerAreaUnit.MegaPascal:
				return UnitSymbolProvider.#q;
			case ForcePerAreaUnit.GigaPascal:
				return UnitSymbolProvider.#r;
			case ForcePerAreaUnit.PoundForcePerSquareInch:
				return UnitSymbolProvider.#j;
			case ForcePerAreaUnit.PoundForcePerSquareFoot:
				return UnitSymbolProvider.#k;
			case ForcePerAreaUnit.KiloPoundForcePerSquareInch:
				return UnitSymbolProvider.#l;
			case ForcePerAreaUnit.KiloPoundForcePerSquareFoot:
				return UnitSymbolProvider.#m;
			case ForcePerAreaUnit.KiloNewtonPerSquareMeter:
				return UnitSymbolProvider.#p;
			default:
				return null;
			}
		}

		// Token: 0x06008B7E RID: 35710 RVA: 0x001DC7F0 File Offset: 0x001DA9F0
		public static IUnitSymbol #29d(ForcePerLengthUnit #aae)
		{
			switch (#aae)
			{
			case ForcePerLengthUnit.NewtonPerMeter:
				return UnitSymbolProvider.#E;
			case ForcePerLengthUnit.KiloNewtonPerMeter:
				return UnitSymbolProvider.#F;
			case ForcePerLengthUnit.PoundForcePerInch:
				return UnitSymbolProvider.#H;
			case ForcePerLengthUnit.PoundForcePerFoot:
				return UnitSymbolProvider.#J;
			case ForcePerLengthUnit.KiloPoundForcePerFoot:
				return UnitSymbolProvider.#K;
			case ForcePerLengthUnit.KiloPoundForcePerInch:
				return UnitSymbolProvider.#I;
			case ForcePerLengthUnit.MegaNewtonPerMeter:
				return UnitSymbolProvider.#G;
			default:
				return null;
			}
		}

		// Token: 0x06008B7F RID: 35711 RVA: 0x001DC850 File Offset: 0x001DAA50
		public static IUnitSymbol #29d(MomentUnit #bae)
		{
			switch (#bae)
			{
			case MomentUnit.NewtonMillimeter:
				return UnitSymbolProvider.#1;
			case MomentUnit.NewtonMeter:
				return UnitSymbolProvider.#2;
			case MomentUnit.KiloNewtonMeter:
				return UnitSymbolProvider.#3;
			case MomentUnit.KilogramForceMeter:
				return UnitSymbolProvider.#4;
			case MomentUnit.InchPoundForce:
				return UnitSymbolProvider.#5;
			case MomentUnit.InchKiloPoundForce:
				return UnitSymbolProvider.#6;
			case MomentUnit.FootPoundForce:
				return UnitSymbolProvider.#7;
			case MomentUnit.FootKiloPoundForce:
				return UnitSymbolProvider.#0;
			default:
				return null;
			}
		}

		// Token: 0x06008B80 RID: 35712 RVA: 0x001DC8BC File Offset: 0x001DAABC
		public static IUnitSymbol #29d(ForceUnit #cae)
		{
			switch (#cae)
			{
			case ForceUnit.Newton:
				return UnitSymbolProvider.#R;
			case ForceUnit.KiloNewton:
				return UnitSymbolProvider.#S;
			case ForceUnit.KilogramForce:
				return UnitSymbolProvider.#V;
			case ForceUnit.PoundForce:
				return UnitSymbolProvider.#T;
			case ForceUnit.KiloPoundForce:
				return UnitSymbolProvider.#U;
			default:
				return null;
			}
		}

		// Token: 0x06008B81 RID: 35713 RVA: 0x00071783 File Offset: 0x0006F983
		public static IUnitSymbol #29d(AreaMomentOfInertiaUnit #dae)
		{
			if (#dae == AreaMomentOfInertiaUnit.InchesDoubleSquared)
			{
				return UnitSymbolProvider.#gb;
			}
			if (#dae != AreaMomentOfInertiaUnit.MilimetersDoubleSquared)
			{
				return null;
			}
			return UnitSymbolProvider.#hb;
		}

		// Token: 0x06008B82 RID: 35714 RVA: 0x000717A3 File Offset: 0x0006F9A3
		public static IUnitSymbol #29d(MassPerLengthUnit #6jb)
		{
			if (#6jb == MassPerLengthUnit.KilogramPerMeter)
			{
				return UnitSymbolProvider.#ib;
			}
			if (#6jb != MassPerLengthUnit.PoundPerLinearFoot)
			{
				return null;
			}
			return UnitSymbolProvider.#jb;
		}

		// Token: 0x06008B83 RID: 35715 RVA: 0x000717C3 File Offset: 0x0006F9C3
		private static IUnitSymbol #29d(AngleUnit #eae)
		{
			if (#eae == AngleUnit.Degree)
			{
				return UnitSymbolProvider.#s;
			}
			if (#eae != AngleUnit.Radian)
			{
				return null;
			}
			return UnitSymbolProvider.#t;
		}

		// Token: 0x06008B84 RID: 35716 RVA: 0x001DC908 File Offset: 0x001DAB08
		private static IUnitSymbol #29d(LengthUnit #fae)
		{
			switch (#fae)
			{
			case LengthUnit.Meter:
				return UnitSymbolProvider.#g;
			case LengthUnit.Centimeter:
				return UnitSymbolProvider.#h;
			case LengthUnit.Millimeter:
				return UnitSymbolProvider.#i;
			case LengthUnit.Yard:
				return UnitSymbolProvider.#c;
			case LengthUnit.Foot:
				return UnitSymbolProvider.#d;
			case LengthUnit.Inch:
				return UnitSymbolProvider.#e;
			case LengthUnit.FootInch:
				return UnitSymbolProvider.#b;
			case LengthUnit.Point:
				return UnitSymbolProvider.#f;
			default:
				return null;
			}
		}

		// Token: 0x06008B85 RID: 35717 RVA: 0x001DC974 File Offset: 0x001DAB74
		private static IUnitSymbol #29d(AreaUnit #gae)
		{
			switch (#gae)
			{
			case AreaUnit.MillimeterSquared:
				return UnitSymbolProvider.#y;
			case AreaUnit.CentimeterSquared:
				return UnitSymbolProvider.#z;
			case AreaUnit.MeterSquared:
				return UnitSymbolProvider.#A;
			case AreaUnit.InchSquared:
				return UnitSymbolProvider.#B;
			case AreaUnit.FootSquared:
				return UnitSymbolProvider.#C;
			case AreaUnit.YardSquared:
				return UnitSymbolProvider.#D;
			default:
				return null;
			}
		}

		// Token: 0x040039AA RID: 14762
		private static readonly Dictionary<Type, Func<Enum, IUnitSymbol>> #a = new Dictionary<Type, Func<Enum, IUnitSymbol>>
		{
			{
				typeof(AngleUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#kbe)
			},
			{
				typeof(AreaPerLengthUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#lbe)
			},
			{
				typeof(AreaUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#mbe)
			},
			{
				typeof(DensityAndUnitWeightUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#nbe)
			},
			{
				typeof(DimensionlessUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#obe)
			},
			{
				typeof(ForcePerAreaUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#pbe)
			},
			{
				typeof(ForcePerLengthUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#qbe)
			},
			{
				typeof(ForcePerVolumeUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#rbe)
			},
			{
				typeof(ForceUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#sbe)
			},
			{
				typeof(LengthUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#tbe)
			},
			{
				typeof(MassPerVolumeUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#ube)
			},
			{
				typeof(MomentPerAngleUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#vbe)
			},
			{
				typeof(MomentPerLengthUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#wbe)
			},
			{
				typeof(MomentUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#xbe)
			},
			{
				typeof(AreaMomentOfInertiaUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#ybe)
			},
			{
				typeof(MassPerLengthUnit),
				new Func<Enum, IUnitSymbol>(UnitSymbolProvider.<>c.<>9.#zbe)
			}
		};

		// Token: 0x040039AB RID: 14763
		public static readonly #vae #b = new #vae(#Phc.#3hc(107248897), #Phc.#3hc(107248916));

		// Token: 0x040039AC RID: 14764
		public static readonly #vae #c = new #vae(#Phc.#3hc(107248363), #Phc.#3hc(107223953));

		// Token: 0x040039AD RID: 14765
		public static readonly #vae #d = new #vae(#Phc.#3hc(107248354), #Phc.#3hc(107230535));

		// Token: 0x040039AE RID: 14766
		public static readonly #vae #e = new #vae(#Phc.#3hc(107280476), #Phc.#3hc(107265223));

		// Token: 0x040039AF RID: 14767
		public static readonly #vae #f = new #vae(#Phc.#3hc(107248377), #Phc.#3hc(107248368));

		// Token: 0x040039B0 RID: 14768
		public static readonly #vae #g = new #vae(#Phc.#3hc(107248331), #Phc.#3hc(107230552));

		// Token: 0x040039B1 RID: 14769
		public static readonly #vae #h = new #vae(#Phc.#3hc(107248322), #Phc.#3hc(107230557));

		// Token: 0x040039B2 RID: 14770
		public static readonly #vae #i = new #vae(#Phc.#3hc(107248337), #Phc.#3hc(107230530));

		// Token: 0x040039B3 RID: 14771
		public static readonly #vae #j = new #vae(#Phc.#3hc(107248288), #Phc.#3hc(107252044));

		// Token: 0x040039B4 RID: 14772
		public static readonly #vae #k = new #vae(#Phc.#3hc(107248287), #Phc.#3hc(107223244));

		// Token: 0x040039B5 RID: 14773
		public static readonly #vae #l = new #vae(#Phc.#3hc(107248254), #Phc.#3hc(107223239));

		// Token: 0x040039B6 RID: 14774
		public static readonly #vae #m = new #vae(#Phc.#3hc(107248217), #Phc.#3hc(107223234));

		// Token: 0x040039B7 RID: 14775
		public static readonly #vae #n = new #vae(#Phc.#3hc(107248180), #Phc.#3hc(107223264));

		// Token: 0x040039B8 RID: 14776
		public static readonly #vae #o = new #vae(#Phc.#3hc(107248139), #Phc.#3hc(107223291));

		// Token: 0x040039B9 RID: 14777
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #p = new #vae(#Phc.#3hc(107248154), #Phc.#3hc(107248633));

		// Token: 0x040039BA RID: 14778
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Megapascal")]
		public static readonly #vae #q = new #vae(#Phc.#3hc(107248624), #Phc.#3hc(107223286));

		// Token: 0x040039BB RID: 14779
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gigapascal")]
		public static readonly #vae #r = new #vae(#Phc.#3hc(107248607), #Phc.#3hc(107223281));

		// Token: 0x040039BC RID: 14780
		public static readonly #vae #s = new #vae(#Phc.#3hc(107248558), #Phc.#3hc(107248549));

		// Token: 0x040039BD RID: 14781
		public static readonly #vae #t = new #vae(#Phc.#3hc(107248544), #Phc.#3hc(107248567));

		// Token: 0x040039BE RID: 14782
		public static readonly #vae #u = new #vae(#Phc.#3hc(107248522), #Phc.#3hc(107248485));

		// Token: 0x040039BF RID: 14783
		public static readonly #vae #v = new #vae(#Phc.#3hc(107248508), #Phc.#3hc(107248471));

		// Token: 0x040039C0 RID: 14784
		public static readonly #vae #w = new #vae(#Phc.#3hc(107248430), #Phc.#3hc(107248437));

		// Token: 0x040039C1 RID: 14785
		public static readonly #vae #x = new #vae(#Phc.#3hc(107248392), #Phc.#3hc(107247855));

		// Token: 0x040039C2 RID: 14786
		public static readonly #vae #y = new #vae(#Phc.#3hc(107247842), #Phc.#3hc(107247817));

		// Token: 0x040039C3 RID: 14787
		public static readonly #vae #z = new #vae(#Phc.#3hc(107247808), #Phc.#3hc(107247783));

		// Token: 0x040039C4 RID: 14788
		public static readonly #vae #A = new #vae(#Phc.#3hc(107247806), #Phc.#3hc(107247757));

		// Token: 0x040039C5 RID: 14789
		public static readonly #vae #B = new #vae(#Phc.#3hc(107247752), #Phc.#3hc(107247767));

		// Token: 0x040039C6 RID: 14790
		public static readonly #vae #C = new #vae(#Phc.#3hc(107247726), #Phc.#3hc(107247741));

		// Token: 0x040039C7 RID: 14791
		public static readonly #vae #D = new #vae(#Phc.#3hc(107247732), #Phc.#3hc(107247683));

		// Token: 0x040039C8 RID: 14792
		public static readonly #vae #E = new #vae(#Phc.#3hc(107247706), #Phc.#3hc(107223837));

		// Token: 0x040039C9 RID: 14793
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #F = new #vae(#Phc.#3hc(107247653), #Phc.#3hc(107223832));

		// Token: 0x040039CA RID: 14794
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Meganewton")]
		public static readonly #vae #G = new #vae(#Phc.#3hc(107247628), #Phc.#3hc(107247635));

		// Token: 0x040039CB RID: 14795
		public static readonly #vae #H = new #vae(#Phc.#3hc(107248106), #Phc.#3hc(107223279));

		// Token: 0x040039CC RID: 14796
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #I = new #vae(#Phc.#3hc(107248113), #Phc.#3hc(107248084));

		// Token: 0x040039CD RID: 14797
		public static readonly #vae #J = new #vae(#Phc.#3hc(107248047), #Phc.#3hc(107223274));

		// Token: 0x040039CE RID: 14798
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #K = new #vae(#Phc.#3hc(107248054), #Phc.#3hc(107223269));

		// Token: 0x040039CF RID: 14799
		public static readonly #vae #L = new #vae(#Phc.#3hc(107248025), #Phc.#3hc(107247996));

		// Token: 0x040039D0 RID: 14800
		public static readonly #vae #M = new #vae(#Phc.#3hc(107247987), #Phc.#3hc(107247938));

		// Token: 0x040039D1 RID: 14801
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #N = new #vae(#Phc.#3hc(107247961), #Phc.#3hc(107247928));

		// Token: 0x040039D2 RID: 14802
		public static readonly #vae #O = new #vae(#Phc.#3hc(107247887), #Phc.#3hc(107223202));

		// Token: 0x040039D3 RID: 14803
		public static readonly #vae #P = new #vae(#Phc.#3hc(107247342), #Phc.#3hc(107223229));

		// Token: 0x040039D4 RID: 14804
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #Q = new #vae(#Phc.#3hc(107247309), #Phc.#3hc(107223224));

		// Token: 0x040039D5 RID: 14805
		public static readonly #vae #R = new #vae(#Phc.#3hc(107247272), #Phc.#3hc(107223881));

		// Token: 0x040039D6 RID: 14806
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #S = new #vae(#Phc.#3hc(107247295), #Phc.#3hc(107223876));

		// Token: 0x040039D7 RID: 14807
		public static readonly #vae #T = new #vae(#Phc.#3hc(107247246), #Phc.#3hc(107223903));

		// Token: 0x040039D8 RID: 14808
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #U = new #vae(#Phc.#3hc(107247261), #Phc.#3hc(107247208));

		// Token: 0x040039D9 RID: 14809
		public static readonly #vae #V = new #vae(#Phc.#3hc(107247231), #Phc.#3hc(107223898));

		// Token: 0x040039DA RID: 14810
		public static readonly #vae #W = new #vae(#Phc.#3hc(107247178), #Phc.#3hc(107247149));

		// Token: 0x040039DB RID: 14811
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #X = new #vae(#Phc.#3hc(107247140), #Phc.#3hc(107247107));

		// Token: 0x040039DC RID: 14812
		public static readonly #vae #Y = new #vae(#Phc.#3hc(107247130), #Phc.#3hc(107247613));

		// Token: 0x040039DD RID: 14813
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #Z = new #vae(#Phc.#3hc(107247600), #Phc.#3hc(107247531));

		// Token: 0x040039DE RID: 14814
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #0 = new #vae(#Phc.#3hc(107247550), #Phc.#3hc(107223814));

		// Token: 0x040039DF RID: 14815
		public static readonly #vae #1 = new #vae(#Phc.#3hc(107247493), #Phc.#3hc(107223893));

		// Token: 0x040039E0 RID: 14816
		public static readonly #vae #2 = new #vae(#Phc.#3hc(107247468), #Phc.#3hc(107223888));

		// Token: 0x040039E1 RID: 14817
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #3 = new #vae(#Phc.#3hc(107247483), #Phc.#3hc(107223851));

		// Token: 0x040039E2 RID: 14818
		public static readonly #vae #4 = new #vae(#Phc.#3hc(107247430), #Phc.#3hc(107223846));

		// Token: 0x040039E3 RID: 14819
		public static readonly #vae #5 = new #vae(#Phc.#3hc(107247441), #Phc.#3hc(107223841));

		// Token: 0x040039E4 RID: 14820
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #6 = new #vae(#Phc.#3hc(107247420), #Phc.#3hc(107223864));

		// Token: 0x040039E5 RID: 14821
		public static readonly #vae #7 = new #vae(#Phc.#3hc(107247363), #Phc.#3hc(107223823));

		// Token: 0x040039E6 RID: 14822
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilonewton")]
		public static readonly #vae #8 = new #vae(#Phc.#3hc(107246830), #Phc.#3hc(107246797));

		// Token: 0x040039E7 RID: 14823
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Meganewton")]
		public static readonly #vae #9 = new #vae(#Phc.#3hc(107246784), #Phc.#3hc(107246783));

		// Token: 0x040039E8 RID: 14824
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Kilopound")]
		public static readonly #vae #ab = new #vae(#Phc.#3hc(107246770), #Phc.#3hc(107246701));

		// Token: 0x040039E9 RID: 14825
		public static readonly #vae #bb = new #vae(#Phc.#3hc(107246716), #Phc.#3hc(107246683));

		// Token: 0x040039EA RID: 14826
		public static readonly #vae #cb = new #vae(#Phc.#3hc(107246634), #Phc.#3hc(107408434));

		// Token: 0x040039EB RID: 14827
		public static readonly #vae #db = new #vae(#Phc.#3hc(107246645), #Phc.#3hc(107360069));

		// Token: 0x040039EC RID: 14828
		public static readonly #vae #eb = new #vae(#Phc.#3hc(107246600), #Phc.#3hc(107246619));

		// Token: 0x040039ED RID: 14829
		public static readonly #vae #fb = new #vae(#Phc.#3hc(107246614), #Phc.#3hc(107247097));

		// Token: 0x040039EE RID: 14830
		public static readonly #vae #gb = new #vae(#Phc.#3hc(107247088), #Phc.#3hc(107247059));

		// Token: 0x040039EF RID: 14831
		public static readonly #vae #hb = new #vae(#Phc.#3hc(107247018), #Phc.#3hc(107246985));

		// Token: 0x040039F0 RID: 14832
		public static readonly #vae #ib = new #vae(#Phc.#3hc(107246976), #Phc.#3hc(107246951));

		// Token: 0x040039F1 RID: 14833
		public static readonly #vae #jb = new #vae(#Phc.#3hc(107246974), #Phc.#3hc(107223274));
	}
}

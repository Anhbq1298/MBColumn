using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F64 RID: 3940
	internal static class #Z7d
	{
		// Token: 0x06008ACF RID: 35535 RVA: 0x000710EC File Offset: 0x0006F2EC
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		public static IEnumerable<Type> #T7d()
		{
			return #Z7d.#a;
		}

		// Token: 0x06008AD0 RID: 35536 RVA: 0x000710F3 File Offset: 0x0006F2F3
		public static bool #U7d(Type #e4)
		{
			return #Z7d.#a.Contains(#e4);
		}

		// Token: 0x06008AD1 RID: 35537 RVA: 0x001D90B4 File Offset: 0x001D72B4
		public static IList<#W7d> #V7d<#W7d>()
		{
			Type typeFromHandle = typeof(!!0);
			if (#Z7d.#U7d(typeFromHandle))
			{
				return Enum.GetValues(typeFromHandle).OfType<#W7d>().ToList<#W7d>();
			}
			return null;
		}

		// Token: 0x06008AD2 RID: 35538 RVA: 0x00071108 File Offset: 0x0006F308
		public static IEnumerable #V7d(Type #e4)
		{
			if (#Z7d.#U7d(#e4))
			{
				return Enum.GetValues(#e4).OfType<Enum>();
			}
			return null;
		}

		// Token: 0x06008AD3 RID: 35539 RVA: 0x001D90F4 File Offset: 0x001D72F4
		public static bool #X7d(Enum #Y7d)
		{
			#X0d.#V0d(#Y7d, #Phc.#3hc(107217941), Component.Units, #Phc.#3hc(107218408));
			Type type = #Y7d.GetType();
			if (#Z7d.#U7d(type))
			{
				foreach (object obj in #Z7d.#V7d(type))
				{
					ValueType obj2 = (ValueType)obj;
					if (#Y7d.Equals(obj2))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0400392B RID: 14635
		private static readonly Type[] #a = new Type[]
		{
			typeof(LengthUnit),
			typeof(AreaUnit),
			typeof(ForceUnit),
			typeof(MomentUnit),
			typeof(ForcePerLengthUnit),
			typeof(ForcePerAreaUnit),
			typeof(ForcePerVolumeUnit),
			typeof(AngleUnit),
			typeof(MassPerVolumeUnit),
			typeof(DensityAndUnitWeightUnit),
			typeof(AreaPerLengthUnit),
			typeof(DimensionlessUnit),
			typeof(MomentPerLengthUnit),
			typeof(MomentPerAngleUnit),
			typeof(AreaMomentOfInertiaUnit),
			typeof(MassPerLengthUnit)
		};
	}
}

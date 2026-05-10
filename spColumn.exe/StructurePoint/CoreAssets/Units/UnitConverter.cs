using System;
using System.Collections.Generic;
using #N7d;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Units
{
	// Token: 0x02000F55 RID: 3925
	public sealed class UnitConverter<TUnit> : #L8d<!0> where TUnit : struct, IComparable
	{
		// Token: 0x06008AA9 RID: 35497 RVA: 0x001D8BDC File Offset: 0x001D6DDC
		public UnitConverter()
		{
			Func<#L8d<TUnit>> func = UnitConverter<!0>.#b.#F1d(typeof(!0));
			if (func != null)
			{
				this.#a = func();
			}
			if (this.#a == null)
			{
				throw new InvalidOperationException(Strings.StringSpecifiedUnitTypeIsNotSupported.#z2d());
			}
		}

		// Token: 0x06008AAA RID: 35498 RVA: 0x00070F27 File Offset: 0x0006F127
		public double #Pb(TUnit #K7d, TUnit #B6, double #c4)
		{
			return this.#a.#Pb(#K7d, #B6, #c4);
		}

		// Token: 0x04003917 RID: 14615
		private readonly #L8d<TUnit> #a;

		// Token: 0x04003918 RID: 14616
		private static readonly Dictionary<Type, Func<#L8d<TUnit>>> #b = new Dictionary<Type, Func<#L8d<!0>>>
		{
			{
				typeof(LengthUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#1ae)
			},
			{
				typeof(AreaUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#2ae)
			},
			{
				typeof(ForceUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#3ae)
			},
			{
				typeof(MomentUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#4ae)
			},
			{
				typeof(ForcePerLengthUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#5ae)
			},
			{
				typeof(ForcePerAreaUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#6ae)
			},
			{
				typeof(ForcePerVolumeUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#7ae)
			},
			{
				typeof(AngleUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#8ae)
			},
			{
				typeof(MassPerVolumeUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#9ae)
			},
			{
				typeof(DensityAndUnitWeightUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#abe)
			},
			{
				typeof(AreaPerLengthUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#bbe)
			},
			{
				typeof(DimensionlessUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#cbe)
			},
			{
				typeof(MomentPerAngleUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#dbe)
			},
			{
				typeof(MomentPerLengthUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#ebe)
			},
			{
				typeof(AreaMomentOfInertiaUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#fbe)
			},
			{
				typeof(MassPerLengthUnit),
				new Func<#L8d<!0>>(UnitConverter<!0>.<>c.<>9.#gbe)
			}
		};
	}
}

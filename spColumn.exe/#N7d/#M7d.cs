using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F58 RID: 3928
	internal sealed class #M7d : #L8d<AreaMomentOfInertiaUnit>, #E8d
	{
		// Token: 0x06008ABF RID: 35519 RVA: 0x001D8E64 File Offset: 0x001D7064
		public double #Pb(AreaMomentOfInertiaUnit #K7d, AreaMomentOfInertiaUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #M7d.#L7d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AC0 RID: 35520 RVA: 0x00071053 File Offset: 0x0006F253
		private static double #L7d(AreaMomentOfInertiaUnit #A6, AreaMomentOfInertiaUnit #B6)
		{
			return #M7d.#a[#A6][#B6];
		}

		// Token: 0x06008AC2 RID: 35522 RVA: 0x001D8E90 File Offset: 0x001D7090
		// Note: this type is marked as 'beforefieldinit'.
		static #M7d()
		{
			Dictionary<AreaMomentOfInertiaUnit, Dictionary<AreaMomentOfInertiaUnit, double>> dictionary = new Dictionary<AreaMomentOfInertiaUnit, Dictionary<AreaMomentOfInertiaUnit, double>>();
			dictionary.Add(AreaMomentOfInertiaUnit.InchesDoubleSquared, new Dictionary<AreaMomentOfInertiaUnit, double>
			{
				{
					AreaMomentOfInertiaUnit.MilimetersDoubleSquared,
					416231.4256
				}
			});
			AreaMomentOfInertiaUnit key = AreaMomentOfInertiaUnit.MilimetersDoubleSquared;
			Dictionary<AreaMomentOfInertiaUnit, double> dictionary2 = new Dictionary<AreaMomentOfInertiaUnit, double>();
			dictionary2.Add(AreaMomentOfInertiaUnit.InchesDoubleSquared, 2.4025096100288302E-06);
			if (!false)
			{
				dictionary.Add(key, dictionary2);
			}
			#M7d.#a = dictionary;
		}

		// Token: 0x0400391A RID: 14618
		private static readonly Dictionary<AreaMomentOfInertiaUnit, Dictionary<AreaMomentOfInertiaUnit, double>> #a;
	}
}

using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F5E RID: 3934
	internal sealed class #P7d : #L8d<DimensionlessUnit>, #H8d
	{
		// Token: 0x06008AC7 RID: 35527 RVA: 0x001D8F7C File Offset: 0x001D717C
		public double #Pb(DimensionlessUnit #K7d, DimensionlessUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #P7d.#L7d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AC8 RID: 35528 RVA: 0x00071091 File Offset: 0x0006F291
		private static double #L7d(DimensionlessUnit #A6, DimensionlessUnit #B6)
		{
			return #P7d.#a[#A6][#B6];
		}

		// Token: 0x06008ACA RID: 35530 RVA: 0x001D8FA8 File Offset: 0x001D71A8
		// Note: this type is marked as 'beforefieldinit'.
		static #P7d()
		{
			Dictionary<DimensionlessUnit, Dictionary<DimensionlessUnit, double>> dictionary = new Dictionary<DimensionlessUnit, Dictionary<DimensionlessUnit, double>>();
			dictionary.Add(DimensionlessUnit.ConstantValue, new Dictionary<DimensionlessUnit, double>
			{
				{
					DimensionlessUnit.Percent,
					100.0
				},
				{
					DimensionlessUnit.PerMille,
					1000.0
				}
			});
			dictionary.Add(DimensionlessUnit.Percent, new Dictionary<DimensionlessUnit, double>
			{
				{
					DimensionlessUnit.ConstantValue,
					0.01
				},
				{
					DimensionlessUnit.PerMille,
					10.0
				}
			});
			DimensionlessUnit key = DimensionlessUnit.PerMille;
			Dictionary<DimensionlessUnit, double> dictionary2 = new Dictionary<DimensionlessUnit, double>();
			dictionary2.Add(DimensionlessUnit.ConstantValue, 0.001);
			DimensionlessUnit key2 = DimensionlessUnit.Percent;
			double value = 0.1;
			if (!false)
			{
				dictionary2.Add(key2, value);
			}
			dictionary.Add(key, dictionary2);
			#P7d.#a = dictionary;
		}

		// Token: 0x04003922 RID: 14626
		private static readonly Dictionary<DimensionlessUnit, Dictionary<DimensionlessUnit, double>> #a;
	}
}

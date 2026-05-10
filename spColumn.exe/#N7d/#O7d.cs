using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F5B RID: 3931
	internal sealed class #O7d : #L8d<DensityAndUnitWeightUnit>, #G8d
	{
		// Token: 0x06008AC3 RID: 35523 RVA: 0x001D8EF0 File Offset: 0x001D70F0
		public double #Pb(DensityAndUnitWeightUnit #K7d, DensityAndUnitWeightUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #O7d.#L7d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AC4 RID: 35524 RVA: 0x00071072 File Offset: 0x0006F272
		private static double #L7d(DensityAndUnitWeightUnit #A6, DensityAndUnitWeightUnit #B6)
		{
			return #O7d.#a[#A6][#B6];
		}

		// Token: 0x06008AC6 RID: 35526 RVA: 0x001D8F1C File Offset: 0x001D711C
		// Note: this type is marked as 'beforefieldinit'.
		static #O7d()
		{
			Dictionary<DensityAndUnitWeightUnit, Dictionary<DensityAndUnitWeightUnit, double>> dictionary = new Dictionary<DensityAndUnitWeightUnit, Dictionary<DensityAndUnitWeightUnit, double>>();
			dictionary.Add(DensityAndUnitWeightUnit.KilogramPerCubicMeter, new Dictionary<DensityAndUnitWeightUnit, double>
			{
				{
					DensityAndUnitWeightUnit.PoundForcePerCubicFoot,
					0.06242796057614461
				}
			});
			DensityAndUnitWeightUnit key = DensityAndUnitWeightUnit.PoundForcePerCubicFoot;
			Dictionary<DensityAndUnitWeightUnit, double> dictionary2 = new Dictionary<DensityAndUnitWeightUnit, double>();
			dictionary2.Add(DensityAndUnitWeightUnit.KilogramPerCubicMeter, 16.01846337396014);
			if (!false)
			{
				dictionary.Add(key, dictionary2);
			}
			#O7d.#a = dictionary;
		}

		// Token: 0x0400391E RID: 14622
		private static readonly Dictionary<DensityAndUnitWeightUnit, Dictionary<DensityAndUnitWeightUnit, double>> #a;
	}
}

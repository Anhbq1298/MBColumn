using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F63 RID: 3939
	internal sealed class #S7d : #L8d<MassPerLengthUnit>, #Q7d
	{
		// Token: 0x06008ACB RID: 35531 RVA: 0x000710B0 File Offset: 0x0006F2B0
		public double #Pb(MassPerLengthUnit #K7d, MassPerLengthUnit #B6, double #c4)
		{
			if (#K7d != #B6)
			{
				return #c4 * #S7d.#R7d(#K7d, #B6);
			}
			return #c4;
		}

		// Token: 0x06008ACC RID: 35532 RVA: 0x000710CD File Offset: 0x0006F2CD
		public static double #R7d(MassPerLengthUnit #K7d, MassPerLengthUnit #B6)
		{
			return #S7d.#a[#K7d][#B6];
		}

		// Token: 0x06008ACE RID: 35534 RVA: 0x001D9054 File Offset: 0x001D7254
		// Note: this type is marked as 'beforefieldinit'.
		static #S7d()
		{
			Dictionary<MassPerLengthUnit, IDictionary<MassPerLengthUnit, double>> dictionary = new Dictionary<MassPerLengthUnit, IDictionary<MassPerLengthUnit, double>>();
			dictionary.Add(MassPerLengthUnit.PoundPerLinearFoot, new Dictionary<MassPerLengthUnit, double>
			{
				{
					MassPerLengthUnit.KilogramPerMeter,
					1.488164
				}
			});
			MassPerLengthUnit key = MassPerLengthUnit.KilogramPerMeter;
			Dictionary<MassPerLengthUnit, double> dictionary2 = new Dictionary<MassPerLengthUnit, double>();
			dictionary2.Add(MassPerLengthUnit.PoundPerLinearFoot, 0.6719689496587742);
			if (!false)
			{
				dictionary.Add(key, dictionary2);
			}
			#S7d.#a = dictionary;
		}

		// Token: 0x0400392A RID: 14634
		private static readonly IDictionary<MassPerLengthUnit, IDictionary<MassPerLengthUnit, double>> #a;
	}
}

using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F69 RID: 3945
	internal sealed class #37d : #L8d<AreaPerLengthUnit>, #F8d
	{
		// Token: 0x06008ADA RID: 35546 RVA: 0x001D9340 File Offset: 0x001D7540
		public double #Pb(AreaPerLengthUnit #K7d, AreaPerLengthUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #37d.#27d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008ADB RID: 35547 RVA: 0x0007117E File Offset: 0x0006F37E
		public static double #27d(AreaPerLengthUnit #K7d, AreaPerLengthUnit #B6)
		{
			return #37d.#a[#K7d][#B6];
		}

		// Token: 0x06008ADD RID: 35549 RVA: 0x001D936C File Offset: 0x001D756C
		// Note: this type is marked as 'beforefieldinit'.
		static #37d()
		{
			Dictionary<AreaPerLengthUnit, IDictionary<AreaPerLengthUnit, double>> dictionary = new Dictionary<AreaPerLengthUnit, IDictionary<AreaPerLengthUnit, double>>();
			AreaPerLengthUnit key = AreaPerLengthUnit.MillimeterSquaredPerMeter;
			Dictionary<AreaPerLengthUnit, double> dictionary2 = new Dictionary<AreaPerLengthUnit, double>();
			dictionary2.Add(AreaPerLengthUnit.MillimeterSquaredPerMeter, 1.0);
			dictionary2.Add(AreaPerLengthUnit.CentimeterSquaredPerMeter, 0.01);
			dictionary2.Add(AreaPerLengthUnit.InchSquaredPerFoot, 0.0004724409448818898);
			AreaPerLengthUnit key2 = AreaPerLengthUnit.InchSquaredPerInch;
			double value = 3.937007874015748E-05;
			if (7 != 0)
			{
				dictionary2.Add(key2, value);
			}
			dictionary.Add(key, dictionary2);
			dictionary.Add(AreaPerLengthUnit.CentimeterSquaredPerMeter, new Dictionary<AreaPerLengthUnit, double>
			{
				{
					AreaPerLengthUnit.MillimeterSquaredPerMeter,
					100.0
				},
				{
					AreaPerLengthUnit.CentimeterSquaredPerMeter,
					1.0
				},
				{
					AreaPerLengthUnit.InchSquaredPerFoot,
					0.04724409448818898
				},
				{
					AreaPerLengthUnit.InchSquaredPerInch,
					0.003937007874015748
				}
			});
			dictionary.Add(AreaPerLengthUnit.InchSquaredPerFoot, new Dictionary<AreaPerLengthUnit, double>
			{
				{
					AreaPerLengthUnit.MillimeterSquaredPerMeter,
					2116.666666666667
				},
				{
					AreaPerLengthUnit.CentimeterSquaredPerMeter,
					21.16666666666667
				},
				{
					AreaPerLengthUnit.InchSquaredPerFoot,
					1.0
				},
				{
					AreaPerLengthUnit.InchSquaredPerInch,
					0.08333333333333333
				}
			});
			dictionary.Add(AreaPerLengthUnit.InchSquaredPerInch, new Dictionary<AreaPerLengthUnit, double>
			{
				{
					AreaPerLengthUnit.MillimeterSquaredPerMeter,
					25400.0
				},
				{
					AreaPerLengthUnit.CentimeterSquaredPerMeter,
					254.0
				},
				{
					AreaPerLengthUnit.InchSquaredPerFoot,
					12.0
				},
				{
					AreaPerLengthUnit.InchSquaredPerInch,
					1.0
				}
			});
			#37d.#a = dictionary;
		}

		// Token: 0x04003930 RID: 14640
		private static readonly IDictionary<AreaPerLengthUnit, IDictionary<AreaPerLengthUnit, double>> #a;
	}
}

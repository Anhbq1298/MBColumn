using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F6F RID: 3951
	internal sealed class #67d : #L8d<MomentPerAngleUnit>, #J8d
	{
		// Token: 0x06008AE0 RID: 35552 RVA: 0x001D94D0 File Offset: 0x001D76D0
		public double #Pb(MomentPerAngleUnit #K7d, MomentPerAngleUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #67d.#57d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AE1 RID: 35553 RVA: 0x000711A4 File Offset: 0x0006F3A4
		private static double #57d(MomentPerAngleUnit #K7d, MomentPerAngleUnit #B6)
		{
			return #67d.#a[#K7d][#B6];
		}

		// Token: 0x06008AE3 RID: 35555 RVA: 0x001D94FC File Offset: 0x001D76FC
		// Note: this type is marked as 'beforefieldinit'.
		static #67d()
		{
			Dictionary<MomentPerAngleUnit, IDictionary<MomentPerAngleUnit, double>> dictionary = new Dictionary<MomentPerAngleUnit, IDictionary<MomentPerAngleUnit, double>>();
			MomentPerAngleUnit key = MomentPerAngleUnit.KiloNewtonMeterPerRadian;
			Dictionary<MomentPerAngleUnit, double> dictionary2 = new Dictionary<MomentPerAngleUnit, double>();
			dictionary2.Add(MomentPerAngleUnit.KiloNewtonMeterPerRadian, 1.0);
			dictionary2.Add(MomentPerAngleUnit.MegaNewtonMeterPerRadian, 0.001);
			dictionary2.Add(MomentPerAngleUnit.InchPoundForcePerRadian, 8850.745791327185);
			MomentPerAngleUnit key2 = MomentPerAngleUnit.FootKiloPoundForcePerRadian;
			double value = 0.7375621492772654;
			if (7 != 0)
			{
				dictionary2.Add(key2, value);
			}
			dictionary.Add(key, dictionary2);
			dictionary.Add(MomentPerAngleUnit.MegaNewtonMeterPerRadian, new Dictionary<MomentPerAngleUnit, double>
			{
				{
					MomentPerAngleUnit.KiloNewtonMeterPerRadian,
					1000.0
				},
				{
					MomentPerAngleUnit.MegaNewtonMeterPerRadian,
					1.0
				},
				{
					MomentPerAngleUnit.InchPoundForcePerRadian,
					8850745.791327184
				},
				{
					MomentPerAngleUnit.FootKiloPoundForcePerRadian,
					737.5621492772653
				}
			});
			dictionary.Add(MomentPerAngleUnit.InchPoundForcePerRadian, new Dictionary<MomentPerAngleUnit, double>
			{
				{
					MomentPerAngleUnit.KiloNewtonMeterPerRadian,
					0.0001129848290276167
				},
				{
					MomentPerAngleUnit.MegaNewtonMeterPerRadian,
					1.129848290276167E-07
				},
				{
					MomentPerAngleUnit.InchPoundForcePerRadian,
					1.0
				},
				{
					MomentPerAngleUnit.FootKiloPoundForcePerRadian,
					8.333333333333333E-05
				}
			});
			dictionary.Add(MomentPerAngleUnit.FootKiloPoundForcePerRadian, new Dictionary<MomentPerAngleUnit, double>
			{
				{
					MomentPerAngleUnit.KiloNewtonMeterPerRadian,
					1.3558179483314
				},
				{
					MomentPerAngleUnit.MegaNewtonMeterPerRadian,
					0.0013558179483314
				},
				{
					MomentPerAngleUnit.InchPoundForcePerRadian,
					12000.0
				},
				{
					MomentPerAngleUnit.FootKiloPoundForcePerRadian,
					1.0
				}
			});
			#67d.#a = dictionary;
		}

		// Token: 0x04003938 RID: 14648
		private static readonly IDictionary<MomentPerAngleUnit, IDictionary<MomentPerAngleUnit, double>> #a;
	}
}

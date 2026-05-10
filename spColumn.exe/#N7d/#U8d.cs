using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F83 RID: 3971
	internal sealed class #U8d : #L8d<ForcePerVolumeUnit>, #W8d
	{
		// Token: 0x06008B07 RID: 35591 RVA: 0x001DAB94 File Offset: 0x001D8D94
		public double #Pb(ForcePerVolumeUnit #K7d, ForcePerVolumeUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #U8d.#T8d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008B08 RID: 35592 RVA: 0x000712D2 File Offset: 0x0006F4D2
		private static double #T8d(ForcePerVolumeUnit #K7d, ForcePerVolumeUnit #B6)
		{
			return #U8d.#a[#K7d][#B6];
		}

		// Token: 0x06008B0A RID: 35594 RVA: 0x001DABC0 File Offset: 0x001D8DC0
		// Note: this type is marked as 'beforefieldinit'.
		static #U8d()
		{
			Dictionary<ForcePerVolumeUnit, IDictionary<ForcePerVolumeUnit, double>> dictionary = new Dictionary<ForcePerVolumeUnit, IDictionary<ForcePerVolumeUnit, double>>();
			ForcePerVolumeUnit key = ForcePerVolumeUnit.NewtonPerCubicMeter;
			Dictionary<ForcePerVolumeUnit, double> dictionary2 = new Dictionary<ForcePerVolumeUnit, double>();
			dictionary2.Add(ForcePerVolumeUnit.NewtonPerCubicMeter, 1.0);
			dictionary2.Add(ForcePerVolumeUnit.KiloNewtonPerCubicMeter, 0.001);
			dictionary2.Add(ForcePerVolumeUnit.MegaNewtonPerCubicMeter, 1E-06);
			dictionary2.Add(ForcePerVolumeUnit.PoundForcePerCubicInch, 3.683958538347314E-06);
			dictionary2.Add(ForcePerVolumeUnit.PoundForcePerCubicFoot, 0.006365880354264159);
			ForcePerVolumeUnit key2 = ForcePerVolumeUnit.KiloPoundForcePerCubicFoot;
			double value = 6.365880354264159E-06;
			if (!false)
			{
				dictionary2.Add(key2, value);
			}
			dictionary.Add(key, dictionary2);
			ForcePerVolumeUnit key3 = ForcePerVolumeUnit.KiloNewtonPerCubicMeter;
			Dictionary<ForcePerVolumeUnit, double> dictionary3 = new Dictionary<ForcePerVolumeUnit, double>();
			dictionary3.Add(ForcePerVolumeUnit.NewtonPerCubicMeter, 1000.0);
			dictionary3.Add(ForcePerVolumeUnit.KiloNewtonPerCubicMeter, 1.0);
			dictionary3.Add(ForcePerVolumeUnit.MegaNewtonPerCubicMeter, 0.001);
			dictionary3.Add(ForcePerVolumeUnit.PoundForcePerCubicInch, 0.003683958538347314);
			dictionary3.Add(ForcePerVolumeUnit.PoundForcePerCubicFoot, 6.365880354264159);
			ForcePerVolumeUnit key4 = ForcePerVolumeUnit.KiloPoundForcePerCubicFoot;
			double value2 = 0.006365880354264159;
			if (8 != 0)
			{
				dictionary3.Add(key4, value2);
			}
			dictionary.Add(key3, dictionary3);
			dictionary.Add(ForcePerVolumeUnit.MegaNewtonPerCubicMeter, new Dictionary<ForcePerVolumeUnit, double>
			{
				{
					ForcePerVolumeUnit.NewtonPerCubicMeter,
					1000000.0
				},
				{
					ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
					1000.0
				},
				{
					ForcePerVolumeUnit.MegaNewtonPerCubicMeter,
					1.0
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicInch,
					3.683958538347314
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicFoot,
					6365.880354264159
				},
				{
					ForcePerVolumeUnit.KiloPoundForcePerCubicFoot,
					6.365880354264159
				}
			});
			dictionary.Add(ForcePerVolumeUnit.PoundForcePerCubicInch, new Dictionary<ForcePerVolumeUnit, double>
			{
				{
					ForcePerVolumeUnit.NewtonPerCubicMeter,
					271447.1375263134
				},
				{
					ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
					271.4471375263134
				},
				{
					ForcePerVolumeUnit.MegaNewtonPerCubicMeter,
					0.2714471375263134
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicInch,
					1.0
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicFoot,
					1728.0
				},
				{
					ForcePerVolumeUnit.KiloPoundForcePerCubicFoot,
					1.728
				}
			});
			dictionary.Add(ForcePerVolumeUnit.PoundForcePerCubicFoot, new Dictionary<ForcePerVolumeUnit, double>
			{
				{
					ForcePerVolumeUnit.NewtonPerCubicMeter,
					157.0874638462462
				},
				{
					ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
					0.1570874638462462
				},
				{
					ForcePerVolumeUnit.MegaNewtonPerCubicMeter,
					0.0001570874638462462
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicInch,
					0.0005787037037037037
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicFoot,
					1.0
				},
				{
					ForcePerVolumeUnit.KiloPoundForcePerCubicFoot,
					0.001
				}
			});
			dictionary.Add(ForcePerVolumeUnit.KiloPoundForcePerCubicFoot, new Dictionary<ForcePerVolumeUnit, double>
			{
				{
					ForcePerVolumeUnit.NewtonPerCubicMeter,
					157087.4638462462
				},
				{
					ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
					157.0874638462462
				},
				{
					ForcePerVolumeUnit.MegaNewtonPerCubicMeter,
					0.1570874638462462
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicInch,
					0.5787037037037037
				},
				{
					ForcePerVolumeUnit.PoundForcePerCubicFoot,
					1000.0
				},
				{
					ForcePerVolumeUnit.KiloPoundForcePerCubicFoot,
					1.0
				}
			});
			#U8d.#a = dictionary;
		}

		// Token: 0x0400396D RID: 14701
		private static readonly IDictionary<ForcePerVolumeUnit, IDictionary<ForcePerVolumeUnit, double>> #a;
	}
}

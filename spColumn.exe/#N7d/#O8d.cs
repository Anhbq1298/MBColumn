using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F7A RID: 3962
	internal sealed class #O8d : #L8d<AreaUnit>, #X8d
	{
		// Token: 0x06008AFB RID: 35579 RVA: 0x001DA2A8 File Offset: 0x001D84A8
		public double #Pb(AreaUnit #K7d, AreaUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #O8d.#N8d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AFC RID: 35580 RVA: 0x00071275 File Offset: 0x0006F475
		private static double #N8d(AreaUnit #K7d, AreaUnit #B6)
		{
			return #O8d.#a[#K7d][#B6];
		}

		// Token: 0x06008AFE RID: 35582 RVA: 0x001DA2D4 File Offset: 0x001D84D4
		// Note: this type is marked as 'beforefieldinit'.
		static #O8d()
		{
			Dictionary<AreaUnit, IDictionary<AreaUnit, double>> dictionary = new Dictionary<AreaUnit, IDictionary<AreaUnit, double>>();
			AreaUnit key = AreaUnit.MillimeterSquared;
			Dictionary<AreaUnit, double> dictionary2 = new Dictionary<AreaUnit, double>();
			dictionary2.Add(AreaUnit.MillimeterSquared, 1.0);
			dictionary2.Add(AreaUnit.CentimeterSquared, 0.01);
			dictionary2.Add(AreaUnit.MeterSquared, 1E-06);
			dictionary2.Add(AreaUnit.InchSquared, 0.0015500031000062);
			dictionary2.Add(AreaUnit.FootSquared, 1.076391041670972E-05);
			AreaUnit key2 = AreaUnit.YardSquared;
			double value = 1.19599004630108E-06;
			if (!false)
			{
				dictionary2.Add(key2, value);
			}
			dictionary.Add(key, dictionary2);
			AreaUnit key3 = AreaUnit.CentimeterSquared;
			Dictionary<AreaUnit, double> dictionary3 = new Dictionary<AreaUnit, double>();
			dictionary3.Add(AreaUnit.MillimeterSquared, 100.0);
			dictionary3.Add(AreaUnit.CentimeterSquared, 1.0);
			dictionary3.Add(AreaUnit.MeterSquared, 0.0001);
			dictionary3.Add(AreaUnit.InchSquared, 0.15500031000062);
			dictionary3.Add(AreaUnit.FootSquared, 0.001076391041670972);
			AreaUnit key4 = AreaUnit.YardSquared;
			double value2 = 0.000119599004630108;
			if (8 != 0)
			{
				dictionary3.Add(key4, value2);
			}
			dictionary.Add(key3, dictionary3);
			dictionary.Add(AreaUnit.MeterSquared, new Dictionary<AreaUnit, double>
			{
				{
					AreaUnit.MillimeterSquared,
					1000000.0
				},
				{
					AreaUnit.CentimeterSquared,
					10000.0
				},
				{
					AreaUnit.MeterSquared,
					1.0
				},
				{
					AreaUnit.InchSquared,
					1550.0031000062
				},
				{
					AreaUnit.FootSquared,
					10.76391041670972
				},
				{
					AreaUnit.YardSquared,
					1.19599004630108
				}
			});
			dictionary.Add(AreaUnit.InchSquared, new Dictionary<AreaUnit, double>
			{
				{
					AreaUnit.MillimeterSquared,
					645.16
				},
				{
					AreaUnit.CentimeterSquared,
					6.4516
				},
				{
					AreaUnit.MeterSquared,
					0.00064516
				},
				{
					AreaUnit.InchSquared,
					1.0
				},
				{
					AreaUnit.FootSquared,
					0.006944444444444444
				},
				{
					AreaUnit.YardSquared,
					0.0007716049382716049
				}
			});
			dictionary.Add(AreaUnit.FootSquared, new Dictionary<AreaUnit, double>
			{
				{
					AreaUnit.MillimeterSquared,
					92903.04
				},
				{
					AreaUnit.CentimeterSquared,
					929.0304
				},
				{
					AreaUnit.MeterSquared,
					0.09290304
				},
				{
					AreaUnit.InchSquared,
					144.0
				},
				{
					AreaUnit.FootSquared,
					1.0
				},
				{
					AreaUnit.YardSquared,
					0.1111111111111111
				}
			});
			dictionary.Add(AreaUnit.YardSquared, new Dictionary<AreaUnit, double>
			{
				{
					AreaUnit.MillimeterSquared,
					836127.36
				},
				{
					AreaUnit.CentimeterSquared,
					8361.2736
				},
				{
					AreaUnit.MeterSquared,
					0.83612736
				},
				{
					AreaUnit.InchSquared,
					1296.0
				},
				{
					AreaUnit.FootSquared,
					9.0
				},
				{
					AreaUnit.YardSquared,
					1.0
				}
			});
			#O8d.#a = dictionary;
		}

		// Token: 0x04003955 RID: 14677
		private static readonly IDictionary<AreaUnit, IDictionary<AreaUnit, double>> #a;
	}
}

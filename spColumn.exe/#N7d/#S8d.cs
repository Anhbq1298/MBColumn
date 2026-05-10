using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F80 RID: 3968
	internal sealed class #S8d : #L8d<ForcePerLengthUnit>, #V8d
	{
		// Token: 0x06008B03 RID: 35587 RVA: 0x001DA7CC File Offset: 0x001D89CC
		public double #Pb(ForcePerLengthUnit #K7d, ForcePerLengthUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #S8d.#R8d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008B04 RID: 35588 RVA: 0x000712B3 File Offset: 0x0006F4B3
		private static double #R8d(ForcePerLengthUnit #K7d, ForcePerLengthUnit #B6)
		{
			return #S8d.#a[#K7d][#B6];
		}

		// Token: 0x04003964 RID: 14692
		private static readonly IDictionary<ForcePerLengthUnit, IDictionary<ForcePerLengthUnit, double>> #a = new Dictionary<ForcePerLengthUnit, IDictionary<ForcePerLengthUnit, double>>
		{
			{
				ForcePerLengthUnit.NewtonPerMeter,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						1.0
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						0.001
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						1E-06
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						0.005710147154732646
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						5.710147154732646E-06
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						0.06852176585679176
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						6.852176585679177E-05
					}
				}
			},
			{
				ForcePerLengthUnit.KiloNewtonPerMeter,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						1000.0
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						1.0
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						0.001
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						5.710147154732646
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						0.005710147154732646
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						68.52176585679176
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						0.06852176585679176
					}
				}
			},
			{
				ForcePerLengthUnit.MegaNewtonPerMeter,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						1000000.0
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						1000.0
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						1.0
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						5710.147154732646
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						5.710147154732646
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						68521.76585679175
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						68.52176585679176
					}
				}
			},
			{
				ForcePerLengthUnit.PoundForcePerInch,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						175.1268352464764
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						0.1751268352464764
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						0.0001751268352464764
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						1.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						0.001
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						12.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						0.012
					}
				}
			},
			{
				ForcePerLengthUnit.KiloPoundForcePerInch,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						175126.8352464764
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						175.1268352464764
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						0.1751268352464764
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						1000.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						1.0
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						12000.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						12.0
					}
				}
			},
			{
				ForcePerLengthUnit.PoundForcePerFoot,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						14.59390293720636
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						0.01459390293720636
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						1.459390293720636E-05
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						0.08333333333333333
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						8.333333333333333E-05
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						1.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						0.001
					}
				}
			},
			{
				ForcePerLengthUnit.KiloPoundForcePerFoot,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						14593.90293720636
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						14.59390293720636
					},
					{
						ForcePerLengthUnit.MegaNewtonPerMeter,
						0.01459390293720636
					},
					{
						ForcePerLengthUnit.PoundForcePerInch,
						83.33333333333333
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerInch,
						0.08333333333333333
					},
					{
						ForcePerLengthUnit.PoundForcePerFoot,
						1000.0
					},
					{
						ForcePerLengthUnit.KiloPoundForcePerFoot,
						1.0
					}
				}
			}
		};
	}
}

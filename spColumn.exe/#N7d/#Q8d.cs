using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F7D RID: 3965
	internal sealed class #Q8d : #L8d<ForceUnit>, #Y8d
	{
		// Token: 0x06008AFF RID: 35583 RVA: 0x001DA59C File Offset: 0x001D879C
		public double #Pb(ForceUnit #K7d, ForceUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #Q8d.#P8d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008B00 RID: 35584 RVA: 0x00071294 File Offset: 0x0006F494
		public static double #P8d(ForceUnit #K7d, ForceUnit #B6)
		{
			return #Q8d.#a[#K7d][#B6];
		}

		// Token: 0x0400395D RID: 14685
		private static readonly IDictionary<ForceUnit, IDictionary<ForceUnit, double>> #a = new Dictionary<ForceUnit, IDictionary<ForceUnit, double>>
		{
			{
				ForceUnit.Newton,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.Newton,
						1.0
					},
					{
						ForceUnit.KiloNewton,
						0.001
					},
					{
						ForceUnit.PoundForce,
						0.2248089430997105
					},
					{
						ForceUnit.KiloPoundForce,
						0.0002248089430997105
					},
					{
						ForceUnit.KilogramForce,
						0.1019716212977928
					}
				}
			},
			{
				ForceUnit.KiloNewton,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.Newton,
						1000.0
					},
					{
						ForceUnit.KiloNewton,
						1.0
					},
					{
						ForceUnit.PoundForce,
						224.8089430997105
					},
					{
						ForceUnit.KiloPoundForce,
						0.2248089430997105
					},
					{
						ForceUnit.KilogramForce,
						101.9716212977928
					}
				}
			},
			{
				ForceUnit.PoundForce,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.Newton,
						4.4482216152605
					},
					{
						ForceUnit.KiloNewton,
						0.0044482216152605
					},
					{
						ForceUnit.PoundForce,
						1.0
					},
					{
						ForceUnit.KiloPoundForce,
						0.001
					},
					{
						ForceUnit.KilogramForce,
						0.45359237
					}
				}
			},
			{
				ForceUnit.KiloPoundForce,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.Newton,
						4448.2216152605
					},
					{
						ForceUnit.KiloNewton,
						4.4482216152605
					},
					{
						ForceUnit.PoundForce,
						1000.0
					},
					{
						ForceUnit.KiloPoundForce,
						1.0
					},
					{
						ForceUnit.KilogramForce,
						453.59237
					}
				}
			},
			{
				ForceUnit.KilogramForce,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.Newton,
						9.80665
					},
					{
						ForceUnit.KiloNewton,
						0.00980665
					},
					{
						ForceUnit.PoundForce,
						2.204622621848776
					},
					{
						ForceUnit.KiloPoundForce,
						0.002204622621848776
					},
					{
						ForceUnit.KilogramForce,
						1.0
					}
				}
			}
		};
	}
}

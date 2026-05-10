using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F8C RID: 3980
	internal sealed class #88d : #L8d<ForcePerAreaUnit>, #08d
	{
		// Token: 0x06008B14 RID: 35604 RVA: 0x001DB714 File Offset: 0x001D9914
		public double #Pb(ForcePerAreaUnit #K7d, ForcePerAreaUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #88d.#68d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008B15 RID: 35605 RVA: 0x00071350 File Offset: 0x0006F550
		public static double #68d(ForcePerAreaUnit #K7d, ForcePerAreaUnit #B6)
		{
			#K7d = #88d.#28d(#K7d);
			#B6 = #88d.#28d(#B6);
			return #88d.#a[#K7d][#B6];
		}

		// Token: 0x06008B16 RID: 35606 RVA: 0x0007137F File Offset: 0x0006F57F
		private static ForcePerAreaUnit #28d(ForcePerAreaUnit #78d)
		{
			if (#78d == ForcePerAreaUnit.KiloNewtonPerSquareMeter)
			{
				return ForcePerAreaUnit.Kilopascal;
			}
			return #78d;
		}

		// Token: 0x0400398A RID: 14730
		private static readonly IDictionary<ForcePerAreaUnit, IDictionary<ForcePerAreaUnit, double>> #a = new Dictionary<ForcePerAreaUnit, IDictionary<ForcePerAreaUnit, double>>
		{
			{
				ForcePerAreaUnit.Pascal,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						1.0
					},
					{
						ForcePerAreaUnit.Kilopascal,
						0.001
					},
					{
						ForcePerAreaUnit.MegaPascal,
						1E-06
					},
					{
						ForcePerAreaUnit.GigaPascal,
						1E-09
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						0.0001450377377302092
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						0.02088543423315013
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						1.450377377302092E-07
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						2.088543423315013E-05
					}
				}
			},
			{
				ForcePerAreaUnit.Kilopascal,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						1000.0
					},
					{
						ForcePerAreaUnit.Kilopascal,
						1.0
					},
					{
						ForcePerAreaUnit.MegaPascal,
						0.001
					},
					{
						ForcePerAreaUnit.GigaPascal,
						1E-06
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						0.1450377377302092
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						20.88543423315013
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						0.0001450377377302092
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						0.02088543423315013
					}
				}
			},
			{
				ForcePerAreaUnit.MegaPascal,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						1000000.0
					},
					{
						ForcePerAreaUnit.Kilopascal,
						1000.0
					},
					{
						ForcePerAreaUnit.MegaPascal,
						1.0
					},
					{
						ForcePerAreaUnit.GigaPascal,
						0.001
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						145.0377377302092
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						20885.43423315013
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						0.1450377377302092
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						20.88543423315013
					}
				}
			},
			{
				ForcePerAreaUnit.GigaPascal,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						1000000000.0
					},
					{
						ForcePerAreaUnit.Kilopascal,
						1000000.0
					},
					{
						ForcePerAreaUnit.MegaPascal,
						1000.0
					},
					{
						ForcePerAreaUnit.GigaPascal,
						1.0
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						145037.7377302092
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						20885434.23315013
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						145.0377377302092
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						20885.43423315013
					}
				}
			},
			{
				ForcePerAreaUnit.PoundForcePerSquareInch,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						6894.757293168361
					},
					{
						ForcePerAreaUnit.Kilopascal,
						6.894757293168361
					},
					{
						ForcePerAreaUnit.MegaPascal,
						0.006894757293168361
					},
					{
						ForcePerAreaUnit.GigaPascal,
						6.894757293168361E-06
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						1.0
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						144.0
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						0.001
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						0.144
					}
				}
			},
			{
				ForcePerAreaUnit.PoundForcePerSquareFoot,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						47.88025898033584
					},
					{
						ForcePerAreaUnit.Kilopascal,
						0.04788025898033584
					},
					{
						ForcePerAreaUnit.MegaPascal,
						4.788025898033584E-05
					},
					{
						ForcePerAreaUnit.GigaPascal,
						4.788025898033584E-08
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						0.006944444444444444
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						1.0
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						6.944444444444444E-06
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						0.001
					}
				}
			},
			{
				ForcePerAreaUnit.KiloPoundForcePerSquareInch,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						6894757.293168361
					},
					{
						ForcePerAreaUnit.Kilopascal,
						6894.757293168361
					},
					{
						ForcePerAreaUnit.MegaPascal,
						6.894757293168361
					},
					{
						ForcePerAreaUnit.GigaPascal,
						0.006894757293168361
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						1000.0
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						144000.0
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						1.0
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						144.0
					}
				}
			},
			{
				ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
				new Dictionary<ForcePerAreaUnit, double>
				{
					{
						ForcePerAreaUnit.Pascal,
						47880.25898033584
					},
					{
						ForcePerAreaUnit.Kilopascal,
						47.88025898033584
					},
					{
						ForcePerAreaUnit.MegaPascal,
						0.04788025898033584
					},
					{
						ForcePerAreaUnit.GigaPascal,
						4.788025898033584E-05
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareInch,
						6.944444444444444
					},
					{
						ForcePerAreaUnit.PoundForcePerSquareFoot,
						1000.0
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareInch,
						0.006944444444444444
					},
					{
						ForcePerAreaUnit.KiloPoundForcePerSquareFoot,
						1.0
					}
				}
			}
		};
	}
}

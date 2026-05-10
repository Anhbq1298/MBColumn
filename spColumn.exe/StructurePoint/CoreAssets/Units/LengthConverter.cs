using System;
using System.Collections.Generic;
using #N7d;

namespace StructurePoint.CoreAssets.Units
{
	// Token: 0x02000F8A RID: 3978
	public sealed class LengthConverter : #L8d<LengthUnit>, #M8d
	{
		// Token: 0x06008B0B RID: 35595 RVA: 0x001DAE88 File Offset: 0x001D9088
		public double #Pb(LengthUnit #K7d, LengthUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= LengthConverter.#18d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008B0C RID: 35596 RVA: 0x000712F1 File Offset: 0x0006F4F1
		public static double #18d(LengthUnit #K7d, LengthUnit #B6)
		{
			#K7d = LengthConverter.#28d(#K7d);
			#B6 = LengthConverter.#28d(#B6);
			return LengthConverter.#a[#K7d][#B6];
		}

		// Token: 0x06008B0D RID: 35597 RVA: 0x00071320 File Offset: 0x0006F520
		private static LengthUnit #28d(LengthUnit #l8d)
		{
			if (#l8d == LengthUnit.FootInch)
			{
				return LengthUnit.Foot;
			}
			return #l8d;
		}

		// Token: 0x04003988 RID: 14728
		private static readonly IDictionary<LengthUnit, IDictionary<LengthUnit, double>> #a = new Dictionary<LengthUnit, IDictionary<LengthUnit, double>>
		{
			{
				LengthUnit.Millimeter,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						1.0
					},
					{
						LengthUnit.Centimeter,
						0.1
					},
					{
						LengthUnit.Meter,
						0.001
					},
					{
						LengthUnit.Point,
						2.834645669291339
					},
					{
						LengthUnit.Inch,
						0.03937007874015748
					},
					{
						LengthUnit.Foot,
						0.003280839895013123
					},
					{
						LengthUnit.Yard,
						0.001093613298337708
					}
				}
			},
			{
				LengthUnit.Centimeter,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						10.0
					},
					{
						LengthUnit.Centimeter,
						1.0
					},
					{
						LengthUnit.Meter,
						0.01
					},
					{
						LengthUnit.Point,
						28.34645669291339
					},
					{
						LengthUnit.Inch,
						0.3937007874015748
					},
					{
						LengthUnit.Foot,
						0.03280839895013123
					},
					{
						LengthUnit.Yard,
						0.01093613298337708
					}
				}
			},
			{
				LengthUnit.Meter,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						1000.0
					},
					{
						LengthUnit.Centimeter,
						100.0
					},
					{
						LengthUnit.Meter,
						1.0
					},
					{
						LengthUnit.Point,
						2834.645669291339
					},
					{
						LengthUnit.Inch,
						39.37007874015748
					},
					{
						LengthUnit.Foot,
						3.280839895013123
					},
					{
						LengthUnit.Yard,
						1.093613298337708
					}
				}
			},
			{
				LengthUnit.Point,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						0.3527777777777778
					},
					{
						LengthUnit.Centimeter,
						0.03527777777777778
					},
					{
						LengthUnit.Meter,
						0.0003527777777777778
					},
					{
						LengthUnit.Point,
						1.0
					},
					{
						LengthUnit.Inch,
						0.01388888888888889
					},
					{
						LengthUnit.Foot,
						0.001157407407407407
					},
					{
						LengthUnit.Yard,
						0.0003858024691358025
					}
				}
			},
			{
				LengthUnit.Inch,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						25.4
					},
					{
						LengthUnit.Centimeter,
						2.54
					},
					{
						LengthUnit.Meter,
						0.0254
					},
					{
						LengthUnit.Point,
						72.0
					},
					{
						LengthUnit.Inch,
						1.0
					},
					{
						LengthUnit.Foot,
						0.08333333333333333
					},
					{
						LengthUnit.Yard,
						0.02777777777777778
					}
				}
			},
			{
				LengthUnit.Foot,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						304.8
					},
					{
						LengthUnit.Centimeter,
						30.48
					},
					{
						LengthUnit.Meter,
						0.3048
					},
					{
						LengthUnit.Point,
						864.0
					},
					{
						LengthUnit.Inch,
						12.0
					},
					{
						LengthUnit.Foot,
						1.0
					},
					{
						LengthUnit.Yard,
						0.3333333333333333
					}
				}
			},
			{
				LengthUnit.Yard,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.Millimeter,
						914.4
					},
					{
						LengthUnit.Centimeter,
						91.44
					},
					{
						LengthUnit.Meter,
						0.9144
					},
					{
						LengthUnit.Point,
						2592.0
					},
					{
						LengthUnit.Inch,
						36.0
					},
					{
						LengthUnit.Foot,
						3.0
					},
					{
						LengthUnit.Yard,
						1.0
					}
				}
			}
		};
	}
}

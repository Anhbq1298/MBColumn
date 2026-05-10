using System;
using System.Collections.Generic;
using System.ComponentModel;
using #7hc;

namespace StructurePoint.Kernel.CoreAssets.Operation.Localizator
{
	// Token: 0x02000F12 RID: 3858
	public static class UnitConverter
	{
		// Token: 0x06008957 RID: 35159 RVA: 0x001D4324 File Offset: 0x001D2524
		public static double Convert(double length, LengthUnit lengthUnitIn, LengthUnit lengthUnitOut)
		{
			double num = length;
			if (lengthUnitIn != lengthUnitOut)
			{
				num *= UnitConverter.GetLengthConversionFactor(lengthUnitIn, lengthUnitOut);
			}
			return num;
		}

		// Token: 0x06008958 RID: 35160 RVA: 0x001D4344 File Offset: 0x001D2544
		public static double Convert(double area, AreaUnit areaUnitIn, AreaUnit areaUnitOut)
		{
			double num = area;
			if (areaUnitIn != areaUnitOut)
			{
				num *= UnitConverter.GetAreaConversionFactor(areaUnitIn, areaUnitOut);
			}
			return num;
		}

		// Token: 0x06008959 RID: 35161 RVA: 0x001D4364 File Offset: 0x001D2564
		public static double Convert(double force, ForceUnit forceUnitIn, ForceUnit forceUnitsOut)
		{
			double num = force;
			if (forceUnitIn != forceUnitsOut)
			{
				num *= UnitConverter.GetForceConversionFactor(forceUnitIn, forceUnitsOut);
			}
			return num;
		}

		// Token: 0x0600895A RID: 35162 RVA: 0x001D4384 File Offset: 0x001D2584
		public static double Convert(double moment, MomentUnit momentUnitIn, MomentUnit momentUnitOut)
		{
			double num = moment;
			if (momentUnitIn != momentUnitOut)
			{
				num *= UnitConverter.GetMomentConversionFactor(momentUnitIn, momentUnitOut);
			}
			return num;
		}

		// Token: 0x0600895B RID: 35163 RVA: 0x001D43A4 File Offset: 0x001D25A4
		public static double Convert(double forcePerLength, ForcePerLengthUnit forcePerLengthUnitIn, ForcePerLengthUnit forcePerLengthUnitOut)
		{
			double num = forcePerLength;
			if (forcePerLengthUnitIn != forcePerLengthUnitOut)
			{
				num *= UnitConverter.GetForcePerLengthConversionFactor(forcePerLengthUnitIn, forcePerLengthUnitOut);
			}
			return num;
		}

		// Token: 0x0600895C RID: 35164 RVA: 0x001D43C4 File Offset: 0x001D25C4
		public static double Convert(double pressure, PressureUnit pressureUnitIn, PressureUnit pressureUnitOut)
		{
			double num = pressure;
			if (pressureUnitIn != pressureUnitOut)
			{
				num *= UnitConverter.GetPressureConversionFactor(pressureUnitIn, pressureUnitOut);
			}
			return num;
		}

		// Token: 0x0600895D RID: 35165 RVA: 0x001D43E4 File Offset: 0x001D25E4
		public static double Convert(double forcePerVolume, ForcePerVolumeUnit forcePerVolumeUnitIn, ForcePerVolumeUnit forcePerVolumeUnitOut)
		{
			double num = forcePerVolume;
			if (forcePerVolumeUnitIn != forcePerVolumeUnitOut)
			{
				num *= UnitConverter.GetForcePerVolumeConversionFactors(forcePerVolumeUnitIn, forcePerVolumeUnitOut);
			}
			return num;
		}

		// Token: 0x0600895E RID: 35166 RVA: 0x0006FD71 File Offset: 0x0006DF71
		public static string GetUnitSymbol(LengthUnit lengthUnit)
		{
			return UnitConverter.lengthUnitSymbols[lengthUnit];
		}

		// Token: 0x0600895F RID: 35167 RVA: 0x0006FD7E File Offset: 0x0006DF7E
		public static string GetUnitSymbol(AreaUnit areaUnit)
		{
			return UnitConverter.areaUnitSymbols[areaUnit];
		}

		// Token: 0x06008960 RID: 35168 RVA: 0x0006FD8B File Offset: 0x0006DF8B
		public static string GetUnitSymbol(ForceUnit forceUnit)
		{
			return UnitConverter.forceUnitSymbols[forceUnit];
		}

		// Token: 0x06008961 RID: 35169 RVA: 0x0006FD98 File Offset: 0x0006DF98
		public static string GetUnitSymbol(MomentUnit momentUnit)
		{
			return UnitConverter.momentUnitSymbols[momentUnit];
		}

		// Token: 0x06008962 RID: 35170 RVA: 0x0006FDA5 File Offset: 0x0006DFA5
		public static string GetUnitSymbol(ForcePerLengthUnit forcePerLengthUnit)
		{
			return UnitConverter.forcePerLengthUnitSymbols[forcePerLengthUnit];
		}

		// Token: 0x06008963 RID: 35171 RVA: 0x0006FDB2 File Offset: 0x0006DFB2
		public static string GetUnitSymbol(PressureUnit pressureUnit)
		{
			return UnitConverter.pressureUnitSymbols[pressureUnit];
		}

		// Token: 0x06008964 RID: 35172 RVA: 0x0006FDBF File Offset: 0x0006DFBF
		public static string GetUnitSymbol(ForcePerVolumeUnit forcePerVolumeUnit)
		{
			return UnitConverter.forcePerVolumeUnitSymbols[forcePerVolumeUnit];
		}

		// Token: 0x06008965 RID: 35173 RVA: 0x0006FDCC File Offset: 0x0006DFCC
		public static double GetLengthConversionFactor(LengthUnit lengthUnitIn, LengthUnit lengthUnitOut)
		{
			return UnitConverter.lengthConversionFactors[lengthUnitIn][lengthUnitOut];
		}

		// Token: 0x06008966 RID: 35174 RVA: 0x0006FDDF File Offset: 0x0006DFDF
		public static double GetAreaConversionFactor(AreaUnit areaUnitIn, AreaUnit areaUnitOut)
		{
			return UnitConverter.areaConversionFactors[areaUnitIn][areaUnitOut];
		}

		// Token: 0x06008967 RID: 35175 RVA: 0x0006FDF2 File Offset: 0x0006DFF2
		public static double GetForceConversionFactor(ForceUnit forceUnitIn, ForceUnit forceUnitOut)
		{
			return UnitConverter.forceConversionFactors[forceUnitIn][forceUnitOut];
		}

		// Token: 0x06008968 RID: 35176 RVA: 0x0006FE05 File Offset: 0x0006E005
		public static double GetMomentConversionFactor(MomentUnit momentUnitIn, MomentUnit momentUnitOut)
		{
			return UnitConverter.momentConversionFactors[momentUnitIn][momentUnitOut];
		}

		// Token: 0x06008969 RID: 35177 RVA: 0x0006FE18 File Offset: 0x0006E018
		public static double GetForcePerLengthConversionFactor(ForcePerLengthUnit forcePerLengthUnitIn, ForcePerLengthUnit forcePerLengthUnitOut)
		{
			return UnitConverter.forcePerLengthConversionFactors[forcePerLengthUnitIn][forcePerLengthUnitOut];
		}

		// Token: 0x0600896A RID: 35178 RVA: 0x0006FE2B File Offset: 0x0006E02B
		public static double GetPressureConversionFactor(PressureUnit pressureUnitIn, PressureUnit pressureUnitOut)
		{
			return UnitConverter.pressureConversionFactors[pressureUnitIn][pressureUnitOut];
		}

		// Token: 0x0600896B RID: 35179 RVA: 0x0006FE3E File Offset: 0x0006E03E
		public static double GetForcePerVolumeConversionFactors(ForcePerVolumeUnit forcePerVolumeUnitIn, ForcePerVolumeUnit forcePerVolumeUnitOut)
		{
			return UnitConverter.forcePerVolumeConversionFactors[forcePerVolumeUnitIn][forcePerVolumeUnitOut];
		}

		// Token: 0x0600896C RID: 35180 RVA: 0x001D4404 File Offset: 0x001D2604
		public static bool TryGetMomentUnit(LengthUnit lengthUnit, ForceUnit forceUnit, out MomentUnit momentUnit)
		{
			if (forceUnit == ForceUnit.N && lengthUnit == LengthUnit.mm)
			{
				momentUnit = MomentUnit.Nmm;
				return true;
			}
			if (forceUnit == ForceUnit.N && lengthUnit == LengthUnit.m)
			{
				momentUnit = MomentUnit.Nm;
				return true;
			}
			if (forceUnit == ForceUnit.kN && lengthUnit == LengthUnit.m)
			{
				momentUnit = MomentUnit.kNm;
				return true;
			}
			if (forceUnit == ForceUnit.kG && lengthUnit == LengthUnit.m)
			{
				momentUnit = MomentUnit.kGm;
				return true;
			}
			if (forceUnit == ForceUnit.lbf && lengthUnit == LengthUnit.inch)
			{
				momentUnit = MomentUnit.inlbf;
				return true;
			}
			if (forceUnit == ForceUnit.kip && lengthUnit == LengthUnit.inch)
			{
				momentUnit = MomentUnit.inkip;
				return true;
			}
			if (forceUnit == ForceUnit.lbf && lengthUnit == LengthUnit.foot)
			{
				momentUnit = MomentUnit.ftlbf;
				return true;
			}
			if (forceUnit == ForceUnit.kip && lengthUnit == LengthUnit.foot)
			{
				momentUnit = MomentUnit.ftkip;
				return true;
			}
			momentUnit = MomentUnit.inlbf;
			return false;
		}

		// Token: 0x0600896D RID: 35181 RVA: 0x001D447C File Offset: 0x001D267C
		public static LengthUnit GetLengthUnit(MomentUnit momentUnit)
		{
			switch (momentUnit)
			{
			case MomentUnit.Nmm:
				return LengthUnit.mm;
			case MomentUnit.Nm:
			case MomentUnit.kNm:
			case MomentUnit.kGm:
				return LengthUnit.m;
			case MomentUnit.inlbf:
			case MomentUnit.inkip:
				return LengthUnit.inch;
			case MomentUnit.ftlbf:
			case MomentUnit.ftkip:
				return LengthUnit.foot;
			default:
				throw new InvalidEnumArgumentException(#Phc.#3hc(107223979));
			}
		}

		// Token: 0x0600896E RID: 35182 RVA: 0x0006FE51 File Offset: 0x0006E051
		public static AreaUnit GetAreaUnit(LengthUnit lengthUnit)
		{
			switch (lengthUnit)
			{
			case LengthUnit.mm:
				return AreaUnit.mm2;
			case LengthUnit.cm:
				return AreaUnit.cm2;
			case LengthUnit.m:
				return AreaUnit.m2;
			case LengthUnit.inch:
				return AreaUnit.inch2;
			case LengthUnit.foot:
				return AreaUnit.foot2;
			case LengthUnit.yard:
				return AreaUnit.yard2;
			default:
				throw new InvalidEnumArgumentException(#Phc.#3hc(107223950));
			}
		}

		// Token: 0x0600896F RID: 35183 RVA: 0x0006FE8E File Offset: 0x0006E08E
		public static AreaUnit GetAreaUnit(MomentUnit momentUnit)
		{
			return UnitConverter.GetAreaUnit(UnitConverter.GetLengthUnit(momentUnit));
		}

		// Token: 0x06008970 RID: 35184 RVA: 0x001D44C8 File Offset: 0x001D26C8
		public static ForceUnit GetForceUnit(MomentUnit momentUnit)
		{
			switch (momentUnit)
			{
			case MomentUnit.Nmm:
			case MomentUnit.Nm:
				return ForceUnit.N;
			case MomentUnit.kNm:
				return ForceUnit.kN;
			case MomentUnit.kGm:
				return ForceUnit.kG;
			case MomentUnit.inlbf:
			case MomentUnit.ftlbf:
				return ForceUnit.lbf;
			case MomentUnit.inkip:
			case MomentUnit.ftkip:
				return ForceUnit.kip;
			default:
				throw new InvalidEnumArgumentException(#Phc.#3hc(107223979));
			}
		}

		// Token: 0x06008971 RID: 35185 RVA: 0x001D4518 File Offset: 0x001D2718
		public static bool TryGetForcePerLengthUnit(MomentUnit momentUnit, out ForcePerLengthUnit forcePerLengthUnit)
		{
			switch (momentUnit)
			{
			case MomentUnit.Nm:
				forcePerLengthUnit = ForcePerLengthUnit.NewtonPerMeter;
				return true;
			case MomentUnit.kNm:
				forcePerLengthUnit = ForcePerLengthUnit.KiloNewtonPerMeter;
				return true;
			case MomentUnit.inlbf:
				forcePerLengthUnit = ForcePerLengthUnit.pli;
				return true;
			case MomentUnit.ftlbf:
				forcePerLengthUnit = ForcePerLengthUnit.plf;
				return true;
			case MomentUnit.ftkip:
				forcePerLengthUnit = ForcePerLengthUnit.klf;
				return true;
			}
			forcePerLengthUnit = ForcePerLengthUnit.pli;
			return false;
		}

		// Token: 0x06008972 RID: 35186 RVA: 0x001D4568 File Offset: 0x001D2768
		public static bool TryGetPressureUnit(MomentUnit momentUnit, out PressureUnit pressureUnit)
		{
			switch (momentUnit)
			{
			case MomentUnit.Nmm:
				pressureUnit = PressureUnit.MPa;
				return true;
			case MomentUnit.Nm:
				pressureUnit = PressureUnit.Pa;
				return true;
			case MomentUnit.kNm:
				pressureUnit = PressureUnit.kPa;
				return true;
			case MomentUnit.inlbf:
				pressureUnit = PressureUnit.psi;
				return true;
			case MomentUnit.inkip:
				pressureUnit = PressureUnit.ksi;
				return true;
			case MomentUnit.ftlbf:
				pressureUnit = PressureUnit.psf;
				return true;
			case MomentUnit.ftkip:
				pressureUnit = PressureUnit.ksf;
				return true;
			}
			pressureUnit = PressureUnit.psi;
			return false;
		}

		// Token: 0x06008973 RID: 35187 RVA: 0x001D45C4 File Offset: 0x001D27C4
		public static bool TryGetForcePerVolumehUnit(MomentUnit momentUnit, out ForcePerVolumeUnit forcePerVolumeUnit)
		{
			switch (momentUnit)
			{
			case MomentUnit.Nm:
				forcePerVolumeUnit = ForcePerVolumeUnit.NewtonPerCubicMeter;
				return true;
			case MomentUnit.kNm:
				forcePerVolumeUnit = ForcePerVolumeUnit.KiloNewtonPerCubicMeter;
				return true;
			case MomentUnit.kGm:
				forcePerVolumeUnit = ForcePerVolumeUnit.KilogramPerCubicMeter;
				return true;
			case MomentUnit.inlbf:
				forcePerVolumeUnit = ForcePerVolumeUnit.pci;
				return true;
			case MomentUnit.ftlbf:
				forcePerVolumeUnit = ForcePerVolumeUnit.pcf;
				return true;
			case MomentUnit.ftkip:
				forcePerVolumeUnit = ForcePerVolumeUnit.kcf;
				return true;
			}
			forcePerVolumeUnit = ForcePerVolumeUnit.pci;
			return false;
		}

		// Token: 0x0400387E RID: 14462
		private static readonly IDictionary<LengthUnit, IDictionary<LengthUnit, double>> lengthConversionFactors = new Dictionary<LengthUnit, IDictionary<LengthUnit, double>>
		{
			{
				LengthUnit.mm,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						1.0
					},
					{
						LengthUnit.cm,
						0.1
					},
					{
						LengthUnit.m,
						0.001
					},
					{
						LengthUnit.inch,
						0.0393700787401575
					},
					{
						LengthUnit.foot,
						0.00328083989501312
					},
					{
						LengthUnit.yard,
						0.00109361329833771
					},
					{
						LengthUnit.micron,
						1000.0
					}
				}
			},
			{
				LengthUnit.cm,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						10.0
					},
					{
						LengthUnit.cm,
						1.0
					},
					{
						LengthUnit.m,
						0.01
					},
					{
						LengthUnit.inch,
						0.393700787401575
					},
					{
						LengthUnit.foot,
						0.0328083989501312
					},
					{
						LengthUnit.yard,
						0.0109361329833771
					},
					{
						LengthUnit.micron,
						10000.0
					}
				}
			},
			{
				LengthUnit.m,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						1000.0
					},
					{
						LengthUnit.cm,
						100.0
					},
					{
						LengthUnit.m,
						1.0
					},
					{
						LengthUnit.inch,
						39.3700787401575
					},
					{
						LengthUnit.foot,
						3.28083989501312
					},
					{
						LengthUnit.yard,
						1.09361329833771
					},
					{
						LengthUnit.micron,
						1000000.0
					}
				}
			},
			{
				LengthUnit.inch,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						25.4
					},
					{
						LengthUnit.cm,
						2.54
					},
					{
						LengthUnit.m,
						0.0254
					},
					{
						LengthUnit.inch,
						1.0
					},
					{
						LengthUnit.foot,
						0.0833333333333333
					},
					{
						LengthUnit.yard,
						0.0277777777777778
					},
					{
						LengthUnit.micron,
						25400.0
					}
				}
			},
			{
				LengthUnit.foot,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						304.8
					},
					{
						LengthUnit.cm,
						30.48
					},
					{
						LengthUnit.m,
						0.3048
					},
					{
						LengthUnit.inch,
						12.0
					},
					{
						LengthUnit.foot,
						1.0
					},
					{
						LengthUnit.yard,
						0.333333333333333
					},
					{
						LengthUnit.micron,
						304800.0
					}
				}
			},
			{
				LengthUnit.yard,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						914.4
					},
					{
						LengthUnit.cm,
						91.44
					},
					{
						LengthUnit.m,
						0.9144
					},
					{
						LengthUnit.inch,
						36.0
					},
					{
						LengthUnit.foot,
						3.0
					},
					{
						LengthUnit.yard,
						1.0
					},
					{
						LengthUnit.micron,
						914400.0
					}
				}
			},
			{
				LengthUnit.micron,
				new Dictionary<LengthUnit, double>
				{
					{
						LengthUnit.mm,
						0.001
					},
					{
						LengthUnit.cm,
						0.0001
					},
					{
						LengthUnit.m,
						0.001
					},
					{
						LengthUnit.inch,
						3.93700787401575E-05
					},
					{
						LengthUnit.foot,
						3.28083989501312E-06
					},
					{
						LengthUnit.yard,
						1.09361329833771E-06
					},
					{
						LengthUnit.micron,
						1.0
					}
				}
			}
		};

		// Token: 0x0400387F RID: 14463
		private static readonly IDictionary<LengthUnit, string> lengthUnitSymbols = new Dictionary<LengthUnit, string>
		{
			{
				LengthUnit.mm,
				#Phc.#3hc(107230530)
			},
			{
				LengthUnit.cm,
				#Phc.#3hc(107230557)
			},
			{
				LengthUnit.m,
				#Phc.#3hc(107230552)
			},
			{
				LengthUnit.inch,
				#Phc.#3hc(107265223)
			},
			{
				LengthUnit.foot,
				#Phc.#3hc(107230535)
			},
			{
				LengthUnit.yard,
				#Phc.#3hc(107223953)
			},
			{
				LengthUnit.micron,
				#Phc.#3hc(107223916)
			}
		};

		// Token: 0x04003880 RID: 14464
		private static readonly IDictionary<AreaUnit, IDictionary<AreaUnit, double>> areaConversionFactors = new Dictionary<AreaUnit, IDictionary<AreaUnit, double>>
		{
			{
				AreaUnit.mm2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						1.0
					},
					{
						AreaUnit.cm2,
						0.01
					},
					{
						AreaUnit.m2,
						1E-06
					},
					{
						AreaUnit.inch2,
						0.0015500031000062
					},
					{
						AreaUnit.foot2,
						1.07639104167097E-05
					},
					{
						AreaUnit.yard2,
						1.19599004630108E-06
					}
				}
			},
			{
				AreaUnit.cm2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						100.0
					},
					{
						AreaUnit.cm2,
						1.0
					},
					{
						AreaUnit.m2,
						0.0001
					},
					{
						AreaUnit.inch2,
						0.15500031000062
					},
					{
						AreaUnit.foot2,
						0.00107639104167097
					},
					{
						AreaUnit.yard2,
						0.000119599004630108
					}
				}
			},
			{
				AreaUnit.m2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						1000000.0
					},
					{
						AreaUnit.cm2,
						10000.0
					},
					{
						AreaUnit.m2,
						1.0
					},
					{
						AreaUnit.inch2,
						1550.0031000062
					},
					{
						AreaUnit.foot2,
						10.7639104167097
					},
					{
						AreaUnit.yard2,
						1.19599004630108
					}
				}
			},
			{
				AreaUnit.inch2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						645.16
					},
					{
						AreaUnit.cm2,
						6.4516
					},
					{
						AreaUnit.m2,
						0.00064516
					},
					{
						AreaUnit.inch2,
						1.0
					},
					{
						AreaUnit.foot2,
						0.00694444444444444
					},
					{
						AreaUnit.yard2,
						0.000771604938271605
					}
				}
			},
			{
				AreaUnit.foot2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						92903.04
					},
					{
						AreaUnit.cm2,
						929.0304
					},
					{
						AreaUnit.m2,
						0.09290304
					},
					{
						AreaUnit.inch2,
						144.0
					},
					{
						AreaUnit.foot2,
						1.0
					},
					{
						AreaUnit.yard2,
						0.111111111111111
					}
				}
			},
			{
				AreaUnit.yard2,
				new Dictionary<AreaUnit, double>
				{
					{
						AreaUnit.mm2,
						836127.36
					},
					{
						AreaUnit.cm2,
						8361.2736
					},
					{
						AreaUnit.m2,
						0.83612736
					},
					{
						AreaUnit.inch2,
						1296.0
					},
					{
						AreaUnit.foot2,
						9.0
					},
					{
						AreaUnit.yard2,
						1.0
					}
				}
			}
		};

		// Token: 0x04003881 RID: 14465
		private static readonly IDictionary<AreaUnit, string> areaUnitSymbols = new Dictionary<AreaUnit, string>
		{
			{
				AreaUnit.mm2,
				#Phc.#3hc(107223911)
			},
			{
				AreaUnit.cm2,
				#Phc.#3hc(107223906)
			},
			{
				AreaUnit.m2,
				#Phc.#3hc(107223933)
			},
			{
				AreaUnit.inch2,
				#Phc.#3hc(107223928)
			},
			{
				AreaUnit.foot2,
				#Phc.#3hc(107223923)
			},
			{
				AreaUnit.yard2,
				#Phc.#3hc(107223886)
			}
		};

		// Token: 0x04003882 RID: 14466
		private static readonly IDictionary<ForceUnit, IDictionary<ForceUnit, double>> forceConversionFactors = new Dictionary<ForceUnit, IDictionary<ForceUnit, double>>
		{
			{
				ForceUnit.N,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						1.0
					},
					{
						ForceUnit.kN,
						0.001
					},
					{
						ForceUnit.lbf,
						0.22480894309971
					},
					{
						ForceUnit.kip,
						0.00022480894309971
					},
					{
						ForceUnit.kG,
						0.101971621297793
					},
					{
						ForceUnit.tonf,
						0.000101971621297793
					}
				}
			},
			{
				ForceUnit.kN,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						1000.0
					},
					{
						ForceUnit.kN,
						1.0
					},
					{
						ForceUnit.lbf,
						224.80894309971
					},
					{
						ForceUnit.kip,
						0.22480894309971
					},
					{
						ForceUnit.kG,
						101.971621297793
					},
					{
						ForceUnit.tonf,
						0.101971621297793
					}
				}
			},
			{
				ForceUnit.lbf,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						4.4482216152605
					},
					{
						ForceUnit.kN,
						0.00444822161526049
					},
					{
						ForceUnit.lbf,
						1.0
					},
					{
						ForceUnit.kip,
						0.001
					},
					{
						ForceUnit.kG,
						0.45359237
					},
					{
						ForceUnit.tonf,
						0.00045359237
					}
				}
			},
			{
				ForceUnit.kip,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						4448.2216152605
					},
					{
						ForceUnit.kN,
						4.4482216152605
					},
					{
						ForceUnit.lbf,
						1000.0
					},
					{
						ForceUnit.kip,
						1.0
					},
					{
						ForceUnit.kG,
						453.59237
					},
					{
						ForceUnit.tonf,
						0.45359237
					}
				}
			},
			{
				ForceUnit.kG,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						9.80665
					},
					{
						ForceUnit.kN,
						0.00980665
					},
					{
						ForceUnit.lbf,
						2.20462262184878
					},
					{
						ForceUnit.kip,
						0.00220462262184878
					},
					{
						ForceUnit.kG,
						1.0
					},
					{
						ForceUnit.tonf,
						0.001
					}
				}
			},
			{
				ForceUnit.tonf,
				new Dictionary<ForceUnit, double>
				{
					{
						ForceUnit.N,
						9806.65
					},
					{
						ForceUnit.kN,
						9.80665
					},
					{
						ForceUnit.lbf,
						2204.62262184878
					},
					{
						ForceUnit.kip,
						2.20462262184878
					},
					{
						ForceUnit.kG,
						1000.0
					},
					{
						ForceUnit.tonf,
						1.0
					}
				}
			}
		};

		// Token: 0x04003883 RID: 14467
		private static readonly IDictionary<ForceUnit, string> forceUnitSymbols = new Dictionary<ForceUnit, string>
		{
			{
				ForceUnit.N,
				#Phc.#3hc(107223881)
			},
			{
				ForceUnit.kN,
				#Phc.#3hc(107223876)
			},
			{
				ForceUnit.lbf,
				#Phc.#3hc(107223903)
			},
			{
				ForceUnit.kip,
				#Phc.#3hc(107230564)
			},
			{
				ForceUnit.kG,
				#Phc.#3hc(107223898)
			},
			{
				ForceUnit.tonf,
				#Phc.#3hc(107230576)
			}
		};

		// Token: 0x04003884 RID: 14468
		private static readonly IDictionary<MomentUnit, IDictionary<MomentUnit, double>> momentConversionFactors = new Dictionary<MomentUnit, IDictionary<MomentUnit, double>>
		{
			{
				MomentUnit.Nmm,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						1.0
					},
					{
						MomentUnit.Nm,
						0.001
					},
					{
						MomentUnit.kNm,
						1E-06
					},
					{
						MomentUnit.kGm,
						0.000101971621297793
					},
					{
						MomentUnit.inlbf,
						0.00885074579132719
					},
					{
						MomentUnit.inkip,
						8.85074579132719E-06
					},
					{
						MomentUnit.ftlbf,
						0.000737562149277265
					},
					{
						MomentUnit.ftkip,
						7.37562149277265E-07
					}
				}
			},
			{
				MomentUnit.Nm,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						1000.0
					},
					{
						MomentUnit.Nm,
						1.0
					},
					{
						MomentUnit.kNm,
						0.001
					},
					{
						MomentUnit.kGm,
						0.101971621297793
					},
					{
						MomentUnit.inlbf,
						8.85074579132718
					},
					{
						MomentUnit.inkip,
						0.00885074579132719
					},
					{
						MomentUnit.ftlbf,
						0.737562149277265
					},
					{
						MomentUnit.ftkip,
						0.000737562149277265
					}
				}
			},
			{
				MomentUnit.kNm,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						1000000.0
					},
					{
						MomentUnit.Nm,
						1000.0
					},
					{
						MomentUnit.kNm,
						1.0
					},
					{
						MomentUnit.kGm,
						101.971621297793
					},
					{
						MomentUnit.inlbf,
						8850.74579132719
					},
					{
						MomentUnit.inkip,
						8.85074579132718
					},
					{
						MomentUnit.ftlbf,
						737.562149277265
					},
					{
						MomentUnit.ftkip,
						0.737562149277265
					}
				}
			},
			{
				MomentUnit.kGm,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						9806.65
					},
					{
						MomentUnit.Nm,
						9.80665
					},
					{
						MomentUnit.kNm,
						0.00980665
					},
					{
						MomentUnit.kGm,
						1.0
					},
					{
						MomentUnit.inlbf,
						86.7961662145187
					},
					{
						MomentUnit.inkip,
						0.0867961662145187
					},
					{
						MomentUnit.ftlbf,
						7.23301385120989
					},
					{
						MomentUnit.ftkip,
						0.00723301385120989
					}
				}
			},
			{
				MomentUnit.inlbf,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						112.984829027617
					},
					{
						MomentUnit.Nm,
						0.112984829027617
					},
					{
						MomentUnit.kNm,
						0.000112984829027617
					},
					{
						MomentUnit.kGm,
						0.011521246198
					},
					{
						MomentUnit.inlbf,
						1.0
					},
					{
						MomentUnit.inkip,
						0.001
					},
					{
						MomentUnit.ftlbf,
						0.0833333333333333
					},
					{
						MomentUnit.ftkip,
						8.33333333333333E-05
					}
				}
			},
			{
				MomentUnit.inkip,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						112984.829027617
					},
					{
						MomentUnit.Nm,
						112.984829027617
					},
					{
						MomentUnit.kNm,
						0.112984829027617
					},
					{
						MomentUnit.kGm,
						11.521246198
					},
					{
						MomentUnit.inlbf,
						1000.0
					},
					{
						MomentUnit.inkip,
						1.0
					},
					{
						MomentUnit.ftlbf,
						83.3333333333333
					},
					{
						MomentUnit.ftkip,
						0.0833333333333333
					}
				}
			},
			{
				MomentUnit.ftlbf,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						1355.8179483314
					},
					{
						MomentUnit.Nm,
						1.3558179483314
					},
					{
						MomentUnit.kNm,
						0.0013558179483314
					},
					{
						MomentUnit.kGm,
						0.138254954376
					},
					{
						MomentUnit.inlbf,
						12.0
					},
					{
						MomentUnit.inkip,
						0.012
					},
					{
						MomentUnit.ftlbf,
						1.0
					},
					{
						MomentUnit.ftkip,
						0.001
					}
				}
			},
			{
				MomentUnit.ftkip,
				new Dictionary<MomentUnit, double>
				{
					{
						MomentUnit.Nmm,
						1355817.9483314
					},
					{
						MomentUnit.Nm,
						1355.8179483314
					},
					{
						MomentUnit.kNm,
						1.3558179483314
					},
					{
						MomentUnit.kGm,
						138.254954376
					},
					{
						MomentUnit.inlbf,
						12000.0
					},
					{
						MomentUnit.inkip,
						12.0
					},
					{
						MomentUnit.ftlbf,
						1000.0
					},
					{
						MomentUnit.ftkip,
						1.0
					}
				}
			}
		};

		// Token: 0x04003885 RID: 14469
		private static readonly IDictionary<MomentUnit, string> momentUnitSymbols = new Dictionary<MomentUnit, string>
		{
			{
				MomentUnit.Nmm,
				#Phc.#3hc(107223893)
			},
			{
				MomentUnit.Nm,
				#Phc.#3hc(107223888)
			},
			{
				MomentUnit.kNm,
				#Phc.#3hc(107223851)
			},
			{
				MomentUnit.kGm,
				#Phc.#3hc(107223846)
			},
			{
				MomentUnit.inlbf,
				#Phc.#3hc(107223841)
			},
			{
				MomentUnit.inkip,
				#Phc.#3hc(107223864)
			},
			{
				MomentUnit.ftlbf,
				#Phc.#3hc(107223823)
			},
			{
				MomentUnit.ftkip,
				#Phc.#3hc(107223814)
			}
		};

		// Token: 0x04003886 RID: 14470
		private static readonly IDictionary<ForcePerLengthUnit, IDictionary<ForcePerLengthUnit, double>> forcePerLengthConversionFactors = new Dictionary<ForcePerLengthUnit, IDictionary<ForcePerLengthUnit, double>>
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
						ForcePerLengthUnit.pli,
						0.00571014715473265
					},
					{
						ForcePerLengthUnit.plf,
						0.0685217658567918
					},
					{
						ForcePerLengthUnit.klf,
						6.85217658567918E-05
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
						ForcePerLengthUnit.pli,
						5.71014715473265
					},
					{
						ForcePerLengthUnit.plf,
						68.5217658567918
					},
					{
						ForcePerLengthUnit.klf,
						0.0685217658567918
					}
				}
			},
			{
				ForcePerLengthUnit.pli,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						175.126835246476
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						0.175126835246476
					},
					{
						ForcePerLengthUnit.pli,
						1.0
					},
					{
						ForcePerLengthUnit.plf,
						12.0
					},
					{
						ForcePerLengthUnit.klf,
						0.012
					}
				}
			},
			{
				ForcePerLengthUnit.plf,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						14.5939029372064
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						0.0145939029372064
					},
					{
						ForcePerLengthUnit.pli,
						0.0833333333333333
					},
					{
						ForcePerLengthUnit.plf,
						1.0
					},
					{
						ForcePerLengthUnit.klf,
						0.001
					}
				}
			},
			{
				ForcePerLengthUnit.klf,
				new Dictionary<ForcePerLengthUnit, double>
				{
					{
						ForcePerLengthUnit.NewtonPerMeter,
						14593.9029372064
					},
					{
						ForcePerLengthUnit.KiloNewtonPerMeter,
						14.5939029372064
					},
					{
						ForcePerLengthUnit.pli,
						83.3333333333333
					},
					{
						ForcePerLengthUnit.plf,
						1000.0
					},
					{
						ForcePerLengthUnit.klf,
						1.0
					}
				}
			}
		};

		// Token: 0x04003887 RID: 14471
		private static readonly IDictionary<ForcePerLengthUnit, string> forcePerLengthUnitSymbols = new Dictionary<ForcePerLengthUnit, string>
		{
			{
				ForcePerLengthUnit.NewtonPerMeter,
				#Phc.#3hc(107223837)
			},
			{
				ForcePerLengthUnit.KiloNewtonPerMeter,
				#Phc.#3hc(107223832)
			},
			{
				ForcePerLengthUnit.pli,
				#Phc.#3hc(107223279)
			},
			{
				ForcePerLengthUnit.plf,
				#Phc.#3hc(107223274)
			},
			{
				ForcePerLengthUnit.klf,
				#Phc.#3hc(107223269)
			}
		};

		// Token: 0x04003888 RID: 14472
		private static readonly IDictionary<PressureUnit, IDictionary<PressureUnit, double>> pressureConversionFactors = new Dictionary<PressureUnit, IDictionary<PressureUnit, double>>
		{
			{
				PressureUnit.Pa,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						1.0
					},
					{
						PressureUnit.kPa,
						0.001
					},
					{
						PressureUnit.MPa,
						1E-06
					},
					{
						PressureUnit.GPa,
						1E-09
					},
					{
						PressureUnit.psi,
						0.000145037737730209
					},
					{
						PressureUnit.psf,
						0.0208854342331501
					},
					{
						PressureUnit.ksi,
						1.45037737730209E-07
					},
					{
						PressureUnit.ksf,
						2.08854342331501E-05
					}
				}
			},
			{
				PressureUnit.kPa,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						1000.0
					},
					{
						PressureUnit.kPa,
						1.0
					},
					{
						PressureUnit.MPa,
						0.001
					},
					{
						PressureUnit.GPa,
						1E-06
					},
					{
						PressureUnit.psi,
						0.145037737730209
					},
					{
						PressureUnit.psf,
						20.8854342331501
					},
					{
						PressureUnit.ksi,
						0.000145037737730209
					},
					{
						PressureUnit.ksf,
						0.0208854342331501
					}
				}
			},
			{
				PressureUnit.MPa,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						1000000.0
					},
					{
						PressureUnit.kPa,
						1000.0
					},
					{
						PressureUnit.MPa,
						1.0
					},
					{
						PressureUnit.GPa,
						0.001
					},
					{
						PressureUnit.psi,
						145.037737730209
					},
					{
						PressureUnit.psf,
						20885.4342331501
					},
					{
						PressureUnit.ksi,
						0.145037737730209
					},
					{
						PressureUnit.ksf,
						20.8854342331501
					}
				}
			},
			{
				PressureUnit.GPa,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						1000000000.0
					},
					{
						PressureUnit.kPa,
						1000000.0
					},
					{
						PressureUnit.MPa,
						1000.0
					},
					{
						PressureUnit.GPa,
						1.0
					},
					{
						PressureUnit.psi,
						145037.737730209
					},
					{
						PressureUnit.psf,
						20885434.2331501
					},
					{
						PressureUnit.ksi,
						145.037737730209
					},
					{
						PressureUnit.ksf,
						20885.4342331501
					}
				}
			},
			{
				PressureUnit.psi,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						6894.75729316836
					},
					{
						PressureUnit.kPa,
						6.89475729316836
					},
					{
						PressureUnit.MPa,
						0.00689475729316836
					},
					{
						PressureUnit.GPa,
						6.89475729316836E-06
					},
					{
						PressureUnit.psi,
						1.0
					},
					{
						PressureUnit.psf,
						144.0
					},
					{
						PressureUnit.ksi,
						0.001
					},
					{
						PressureUnit.ksf,
						0.144
					}
				}
			},
			{
				PressureUnit.psf,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						47.8802589803358
					},
					{
						PressureUnit.kPa,
						0.0478802589803358
					},
					{
						PressureUnit.MPa,
						4.78802589803358E-05
					},
					{
						PressureUnit.GPa,
						4.78802589803358E-08
					},
					{
						PressureUnit.psi,
						0.00694444444444444
					},
					{
						PressureUnit.psf,
						1.0
					},
					{
						PressureUnit.ksi,
						6.94444444444444E-06
					},
					{
						PressureUnit.ksf,
						0.001
					}
				}
			},
			{
				PressureUnit.ksi,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						6894757.29316836
					},
					{
						PressureUnit.kPa,
						6894.75729316836
					},
					{
						PressureUnit.MPa,
						6.89475729316836
					},
					{
						PressureUnit.GPa,
						0.00689475729316836
					},
					{
						PressureUnit.psi,
						1000.0
					},
					{
						PressureUnit.psf,
						144000.0
					},
					{
						PressureUnit.ksi,
						1.0
					},
					{
						PressureUnit.ksf,
						144.0
					}
				}
			},
			{
				PressureUnit.ksf,
				new Dictionary<PressureUnit, double>
				{
					{
						PressureUnit.Pa,
						47880.2589803358
					},
					{
						PressureUnit.kPa,
						47.8802589803358
					},
					{
						PressureUnit.MPa,
						0.0478802589803358
					},
					{
						PressureUnit.GPa,
						4.78802589803358E-05
					},
					{
						PressureUnit.psi,
						6.94444444444444
					},
					{
						PressureUnit.psf,
						1000.0
					},
					{
						PressureUnit.ksi,
						0.00694444444444444
					},
					{
						PressureUnit.ksf,
						1.0
					}
				}
			}
		};

		// Token: 0x04003889 RID: 14473
		private static readonly IDictionary<PressureUnit, string> pressureUnitSymbols = new Dictionary<PressureUnit, string>
		{
			{
				PressureUnit.Pa,
				#Phc.#3hc(107223264)
			},
			{
				PressureUnit.kPa,
				#Phc.#3hc(107223291)
			},
			{
				PressureUnit.MPa,
				#Phc.#3hc(107223286)
			},
			{
				PressureUnit.GPa,
				#Phc.#3hc(107223281)
			},
			{
				PressureUnit.psi,
				#Phc.#3hc(107252044)
			},
			{
				PressureUnit.psf,
				#Phc.#3hc(107223244)
			},
			{
				PressureUnit.ksi,
				#Phc.#3hc(107223239)
			},
			{
				PressureUnit.ksf,
				#Phc.#3hc(107223234)
			}
		};

		// Token: 0x0400388A RID: 14474
		private static readonly IDictionary<ForcePerVolumeUnit, IDictionary<ForcePerVolumeUnit, double>> forcePerVolumeConversionFactors = new Dictionary<ForcePerVolumeUnit, IDictionary<ForcePerVolumeUnit, double>>
		{
			{
				ForcePerVolumeUnit.NewtonPerCubicMeter,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						1.0
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						0.001
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						0.101971620999999
					},
					{
						ForcePerVolumeUnit.pci,
						3.68395853834731E-06
					},
					{
						ForcePerVolumeUnit.pcf,
						0.00636588035426416
					},
					{
						ForcePerVolumeUnit.kcf,
						6.36588035426416E-06
					}
				}
			},
			{
				ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						1000.0
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						1.0
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						101.971620999999
					},
					{
						ForcePerVolumeUnit.pci,
						0.00368395853834731
					},
					{
						ForcePerVolumeUnit.pcf,
						6.36588035426416
					},
					{
						ForcePerVolumeUnit.kcf,
						0.00636588035426416
					}
				}
			},
			{
				ForcePerVolumeUnit.KilogramPerCubicMeter,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						9.8066500286389
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						0.0098066500286389
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						1.0
					},
					{
						ForcePerVolumeUnit.pci,
						3.61272920000995E-05
					},
					{
						ForcePerVolumeUnit.pcf,
						0.0624279605759893
					},
					{
						ForcePerVolumeUnit.kcf,
						6.24279605759893E-05
					}
				}
			},
			{
				ForcePerVolumeUnit.pci,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						271447.137526313
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						271.447137526313
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						27679.904710191
					},
					{
						ForcePerVolumeUnit.pci,
						1.0
					},
					{
						ForcePerVolumeUnit.pcf,
						1728.0
					},
					{
						ForcePerVolumeUnit.kcf,
						1.728
					}
				}
			},
			{
				ForcePerVolumeUnit.pcf,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						157.087463846246
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						0.157087463846246
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						16.018463374
					},
					{
						ForcePerVolumeUnit.pci,
						0.000578703703703704
					},
					{
						ForcePerVolumeUnit.pcf,
						1.0
					},
					{
						ForcePerVolumeUnit.kcf,
						0.001
					}
				}
			},
			{
				ForcePerVolumeUnit.kcf,
				new Dictionary<ForcePerVolumeUnit, double>
				{
					{
						ForcePerVolumeUnit.NewtonPerCubicMeter,
						157087.463846246
					},
					{
						ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
						157.087463846246
					},
					{
						ForcePerVolumeUnit.KilogramPerCubicMeter,
						16018.463374
					},
					{
						ForcePerVolumeUnit.pci,
						0.578703703703704
					},
					{
						ForcePerVolumeUnit.pcf,
						1000.0
					},
					{
						ForcePerVolumeUnit.kcf,
						1.0
					}
				}
			}
		};

		// Token: 0x0400388B RID: 14475
		private static readonly IDictionary<ForcePerVolumeUnit, string> forcePerVolumeUnitSymbols = new Dictionary<ForcePerVolumeUnit, string>
		{
			{
				ForcePerVolumeUnit.NewtonPerCubicMeter,
				#Phc.#3hc(107223261)
			},
			{
				ForcePerVolumeUnit.KiloNewtonPerCubicMeter,
				#Phc.#3hc(107223252)
			},
			{
				ForcePerVolumeUnit.KilogramPerCubicMeter,
				#Phc.#3hc(107223211)
			},
			{
				ForcePerVolumeUnit.pci,
				#Phc.#3hc(107223202)
			},
			{
				ForcePerVolumeUnit.pcf,
				#Phc.#3hc(107223229)
			},
			{
				ForcePerVolumeUnit.kcf,
				#Phc.#3hc(107223224)
			}
		};
	}
}

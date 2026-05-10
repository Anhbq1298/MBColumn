using System;
using #2be;
using StructurePoint.CoreAssets.Units;

namespace #ede
{
	// Token: 0x0200104B RID: 4171
	internal sealed class #6de
	{
		// Token: 0x06008EF0 RID: 36592 RVA: 0x00073B9C File Offset: 0x00071D9C
		public static #gee #ul(#ice #ib)
		{
			if (#ib.UnitSystem != UnitSystem.SIMetric)
			{
				return #6de.#b;
			}
			return #6de.#a;
		}

		// Token: 0x06008EF1 RID: 36593 RVA: 0x001E5D60 File Offset: 0x001E3F60
		private static #gee #4de()
		{
			return new #gee
			{
				Core = new #ode
				{
					DesignDimension = new #6ce(new double?(0.0), new double?((double)2540000f), false, true, 2),
					InvestigationDimensions = new #6ce(new double?((double)2.54f), new double?((double)2540000f), true, true, 2),
					ModelCoordinate = new #6ce(new double?((double)-25400000f), new double?((double)25400000f), true, true, 2),
					SectionPolygonPointsNumber = new #9ce(new double?((double)3), new double?((double)10001), true, true),
					TotalSectionDimension = new #6ce(new double?((double)2.54f), new double?((double)25400000f), true, true, 2)
				},
				Reinforcement = new #yee
				{
					InvestigationEqualNumberOfBars = new #9ce(new double?((double)4), new double?((double)10000), true, true),
					DesignEqualNumberOfBars = new #9ce(new double?((double)4), new double?((double)10000), true, true),
					ClearCover = new #6ce(new double?(0.0), new double?((double)25000f), false, true, 2),
					InvestigationDifferentTopBottomNumberOfBars = new #9ce(new double?((double)2), new double?((double)10000), true, true),
					InvestigationDifferentLeftRightNumberOfBars = new #9ce(new double?(0.0), new double?((double)10000), true, true),
					DesignDifferentTopBottomNoOfBars = new #9ce(new double?((double)4), new double?((double)5000), true, true),
					DesignDifferentLeftRightNoOfBars = new #9ce(new double?(0.0), new double?((double)5000), true, true),
					BarArea = new #6ce(new double?(0.0), new double?((double)64516f), false, true, 2),
					BarAreaImport = new #6ce(new double?(0.01), new double?((double)64516f), true, true, 2)
				},
				Materials = new #3de
				{
					SteelFyNonCsaNonStandard = new #6ce(new double?((double)68.95f), new double?((double)1861.65f), true, true, 2),
					SteelFyNonCsaStandard = new #6ce(new double?((double)68.95f), new double?((double)551.6f), true, true, 2),
					SteenFyCsaNonStandard = new #6ce(new double?((double)100f), new double?((double)1860f), true, true, 2),
					SteelFyCsaStandard = new #6ce(new double?((double)100f), new double?((double)500f), true, true, 2),
					ConcreteFcpNonCsaNonStandard = new #6ce(new double?((double)13.79f), new double?((double)137.9f), true, true, 2),
					ConcreteFcpNonCsaStandard = new #6ce(new double?((double)13.79f), new double?((double)82.74f), true, true, 2),
					ConcreteFcpCsaNonStandard = new #6ce(new double?((double)10f), new double?((double)150f), true, true, 2),
					ConcreteFcpCsaStandard = new #6ce(new double?((double)10f), new double?((double)80f), true, true, 2),
					Ec = new #6ce(new double?((double)689.5f), new double?((double)6895000f), true, true, 2),
					Fc = new #6ce(new double?((double)1.72375f), null, true, true, 2),
					Beta1 = new #6ce(new double?((double)0.5f), new double?((double)1f), true, true, 2),
					Eps = new #6ce(new double?((double)0.0005f), new double?((double)0.3f), true, true, 4),
					Es = new #6ce(new double?((double)6888.1f), new double?((double)68950000f), true, true, 2),
					Eyt = new #6ce(new double?(0.0), new double?((double)0.005f), false, false, 3),
					EytAci19 = new #6ce(new double?(0.0), new double?((double)0.01f), false, false, 3)
				},
				ReductionFactors = new #lee
				{
					A = new #6ce(new double?(0.1), new double?(2.0), true, true, 2),
					B = new #6ce(new double?(0.1), new double?(1.0), true, true, 2),
					C = new #6ce(new double?(0.1), new double?(1.0), true, true, 2),
					MinDimension = new #6ce(new double?((double)2.54f), new double?((double)2540000f), true, true, 2)
				},
				DesignCriteria = new #tde
				{
					CapacityRatio = new #6ce(new double?((double)0.1f), new double?((double)1.001f), true, true, 3),
					MinRebarClearSpacing = new #6ce(new double?((double)10f), new double?((double)2500f), true, true, 2),
					MinReinforcementRatio = new #6ce(new double?(0.1), new double?(4.0), true, true, 2),
					MaxReinforcementRatio = new #6ce(null, new double?(20.0), true, true, 2)
				},
				StandardBars = new #afe
				{
					Size = new #6ce(new double?(0.0), new double?((double)100), false, true, 2),
					Diameter = new #6ce(new double?(0.0), new double?((double)250), false, true, 2),
					Area = new #6ce(new double?(0.0), new double?((double)50000f), false, true, 2),
					Weight = new #6ce(new double?(0.0), new double?((double)50000f), false, true, 2),
					Count = new #9ce(new double?((double)1), new double?((double)16), true, true)
				},
				Loads = new #yde
				{
					MomentY = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					MomentX = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					AxialLoad = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					LoadFactor = new #6ce(new double?((double)-10f), new double?((double)10f), true, true, 2),
					SustainedLoadFactor = new #6ce(new double?(0.0), new double?((double)100), true, true, 0)
				},
				Slenderness = new #7ee
				{
					CrackedIBeams = new #6ce(new double?(0.0), new double?((double)1), true, true, 6),
					CrackedIColumns = new #6ce(new double?(0.0), new double?((double)1), true, true, 6),
					StiffnessReductionFactorPhi = new #6ce(new double?(0.4), new double?(1.0), true, true, 2),
					DesignedColumnHeight = new #6ce(new double?(0.0), new double?((double)1000f), false, true, 6),
					DesignedColumnKBraced = new #6ce(new double?((double)0.5f), new double?(1.0), true, true, 6),
					DesignedColumnKSway = new #6ce(new double?(1.0), new double?(99.0), true, true, 6),
					DesignedColumnSumPc = new #6ce(new double?(1.0), new double?((double)1000000f), true, true, 5),
					DesignedColumnSumPu = new #6ce(new double?(1.0), new double?((double)1000000f), true, true, 5),
					ColumnAboveBelowWidth = new #6ce(new double?((double)2.54f), new double?((double)2540000f), true, true, 2),
					ColumnAboveBelowDepth = new #6ce(new double?((double)2.54f), new double?((double)2540000f), true, true, 2),
					ColumnAboveBelowEc = new #6ce(new double?((double)689.5f), new double?((double)6895000f), true, true, 2),
					ColumnAboveBelowFcp = new #6ce(new double?((double)13.79f), new double?((double)137.9f), true, true, 2),
					ColumnAboveBelowHeight = new #6ce(new double?(0.0), new double?((double)1000f), true, true, 2),
					SlendernessBeamWidth = new #6ce(new double?(0.0), new double?((double)2540000f), true, true, 2),
					SlendernessBeamDepth = new #6ce(new double?(0.0), new double?((double)2540000f), true, true, 2),
					SlendernessBeamEc = new #6ce(new double?((double)689.5f), new double?((double)6895000f), true, true, 2),
					SlendernessBeamFcp = new #6ce(new double?((double)13.79f), new double?((double)137.9f), true, true, 2),
					SlendernessBeamLength = new #6ce(new double?(0.0), new double?((double)1000), false, true, 2),
					SlendernessBeamMofi = new #6ce(new double?(0.0), new double?((double)1E+25f), false, true, 2)
				}
			};
		}

		// Token: 0x06008EF2 RID: 36594 RVA: 0x001E674C File Offset: 0x001E494C
		private static #gee #5de()
		{
			return new #gee
			{
				Core = new #ode
				{
					DesignDimension = new #6ce(new double?(0.0), new double?((double)100000f), false, true, 2),
					InvestigationDimensions = new #6ce(new double?((double)0.1f), new double?((double)100000f), true, true, 2),
					ModelCoordinate = new #6ce(new double?((double)-1000000f), new double?((double)1000000f), true, true, 2),
					SectionPolygonPointsNumber = new #9ce(new double?((double)3), new double?((double)10001), true, true),
					TotalSectionDimension = new #6ce(new double?((double)0.1f), new double?((double)1000000f), true, true, 2)
				},
				Reinforcement = new #yee
				{
					InvestigationEqualNumberOfBars = new #9ce(new double?((double)4), new double?((double)10000), true, true),
					DesignEqualNumberOfBars = new #9ce(new double?((double)4), new double?((double)10000), true, true),
					ClearCover = new #6ce(new double?(0.0), new double?((double)999f), false, true, 2),
					InvestigationDifferentTopBottomNumberOfBars = new #9ce(new double?((double)2), new double?((double)10000), true, true),
					InvestigationDifferentLeftRightNumberOfBars = new #9ce(new double?(0.0), new double?((double)10000), true, true),
					DesignDifferentTopBottomNoOfBars = new #9ce(new double?((double)4), new double?((double)5000), true, true),
					DesignDifferentLeftRightNoOfBars = new #9ce(new double?(0.0), new double?((double)5000), true, true),
					BarArea = new #6ce(new double?(0.0), new double?((double)100f), false, true, 2),
					BarAreaImport = new #6ce(new double?(0.01), new double?((double)100f), true, true, 2)
				},
				Materials = new #3de
				{
					SteelFyNonCsaNonStandard = new #6ce(new double?((double)10f), new double?((double)270f), true, true, 2),
					SteelFyNonCsaStandard = new #6ce(new double?((double)10f), new double?((double)80f), true, true, 2),
					SteenFyCsaNonStandard = new #6ce(new double?((double)14.5033f), new double?((double)269.761f), true, true, 2),
					SteelFyCsaStandard = new #6ce(new double?((double)14.5033f), new double?((double)72.5163f), true, true, 2),
					ConcreteFcpNonCsaNonStandard = new #6ce(new double?((double)2f), new double?((double)20f), true, true, 2),
					ConcreteFcpNonCsaStandard = new #6ce(new double?((double)2f), new double?((double)12f), true, true, 2),
					ConcreteFcpCsaNonStandard = new #6ce(new double?((double)1.45033f), new double?((double)21.7549f), true, true, 2),
					ConcreteFcpCsaStandard = new #6ce(new double?((double)1.45033f), new double?((double)11.6026f), true, true, 2),
					Ec = new #6ce(new double?((double)100f), new double?((double)1000000f), true, true, 2),
					Fc = new #6ce(new double?((double)0.25f), null, true, true, 2),
					Beta1 = new #6ce(new double?((double)0.5f), new double?((double)1f), true, true, 2),
					Eps = new #6ce(new double?((double)0.0005f), new double?((double)0.3f), true, true, 4),
					Es = new #6ce(new double?((double)999f), new double?((double)10000000f), true, true, 2),
					Eyt = new #6ce(new double?(0.0), new double?((double)0.005f), false, false, 3),
					EytAci19 = new #6ce(new double?(0.0), new double?((double)0.01f), false, false, 3)
				},
				ReductionFactors = new #lee
				{
					A = new #6ce(new double?(0.1), new double?(2.0), true, true, 2),
					B = new #6ce(new double?(0.1), new double?(1.0), true, true, 2),
					C = new #6ce(new double?(0.1), new double?(1.0), true, true, 2),
					MinDimension = new #6ce(new double?((double)0.1f), new double?((double)100000f), true, true, 2)
				},
				DesignCriteria = new #tde
				{
					CapacityRatio = new #6ce(new double?((double)0.1f), new double?((double)1.001f), true, true, 3),
					MinRebarClearSpacing = new #6ce(new double?((double)0.25f), new double?((double)99f), true, true, 2),
					MinReinforcementRatio = new #6ce(new double?(0.1), new double?(4.0), true, true, 2),
					MaxReinforcementRatio = new #6ce(null, new double?(20.0), true, true, 2)
				},
				StandardBars = new #afe
				{
					Size = new #6ce(new double?(0.0), new double?((double)100), false, true, 2),
					Diameter = new #6ce(new double?(0.0), new double?((double)10f), false, true, 2),
					Area = new #6ce(new double?(0.0), new double?((double)10), false, true, 2),
					Weight = new #6ce(new double?(0.0), new double?((double)100), false, true, 2),
					Count = new #9ce(new double?((double)1), new double?((double)16), true, true)
				},
				Loads = new #yde
				{
					MomentY = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					MomentX = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					AxialLoad = new #6ce(new double?((double)-1E+12f), new double?((double)1E+12f), true, true, 2),
					LoadFactor = new #6ce(new double?((double)-10f), new double?((double)10f), true, true, 2),
					SustainedLoadFactor = new #6ce(new double?(0.0), new double?((double)100), true, true, 0)
				},
				Slenderness = new #7ee
				{
					CrackedIBeams = new #6ce(new double?(0.0), new double?((double)1), true, true, 2),
					CrackedIColumns = new #6ce(new double?(0.0), new double?((double)1), true, true, 2),
					StiffnessReductionFactorPhi = new #6ce(new double?(0.4), new double?(1.0), true, true, 2),
					DesignedColumnHeight = new #6ce(new double?(0.0), new double?((double)1000f), false, true, 6),
					DesignedColumnKBraced = new #6ce(new double?((double)0.5f), new double?(1.0), true, true, 6),
					DesignedColumnKSway = new #6ce(new double?(1.0), new double?(99.0), true, true, 6),
					DesignedColumnSumPc = new #6ce(new double?(1.0), new double?((double)1000000f), true, true, 5),
					DesignedColumnSumPu = new #6ce(new double?(1.0), new double?((double)1000000f), true, true, 5),
					ColumnAboveBelowWidth = new #6ce(new double?((double)0.1f), new double?((double)100000f), true, true, 2),
					ColumnAboveBelowDepth = new #6ce(new double?((double)0.1f), new double?((double)100000f), true, true, 2),
					ColumnAboveBelowEc = new #6ce(new double?((double)100f), new double?((double)1000000f), true, true, 2),
					ColumnAboveBelowFcp = new #6ce(new double?((double)2f), new double?((double)20f), true, true, 2),
					ColumnAboveBelowHeight = new #6ce(new double?(0.0), new double?((double)1000f), true, true, 2),
					SlendernessBeamWidth = new #6ce(new double?(0.0), new double?((double)100000f), true, true, 2),
					SlendernessBeamDepth = new #6ce(new double?(0.0), new double?((double)100000f), true, true, 2),
					SlendernessBeamEc = new #6ce(new double?((double)100f), new double?((double)1000000f), true, true, 2),
					SlendernessBeamFcp = new #6ce(new double?((double)2f), new double?((double)20f), true, true, 2),
					SlendernessBeamLength = new #6ce(new double?(0.0), new double?((double)1000), false, true, 2),
					SlendernessBeamMofi = new #6ce(new double?(0.0), new double?((double)1E+25f), false, true, 2)
				}
			};
		}

		// Token: 0x04003BE8 RID: 15336
		private static readonly #gee #a = #6de.#4de();

		// Token: 0x04003BE9 RID: 15337
		private static readonly #gee #b = #6de.#5de();
	}
}

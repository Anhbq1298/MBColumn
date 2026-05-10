using System;
using #7hc;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #04
{
	// Token: 0x020003B5 RID: 949
	internal static class #y6
	{
		// Token: 0x0600200F RID: 8207 RVA: 0x000C3C10 File Offset: 0x000C1E10
		internal static #Z4 #q6()
		{
			return new #Z4
			{
				ConcreteStrength = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 5, null),
				ConcreteElasticity = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 2, null),
				ConcreteMaxStress = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 5, null),
				ConcreteBetaOne = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				ConcreteUltimateStrain = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 8, null),
				ReinforcingSteelStrength = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 4, null),
				ReinforcingSteelElasticity = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 1, null),
				ReinforcingSteelEtyLimit = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 8, null),
				CapacityReductionAxialCompression = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				CapacityReductionTensionControlled = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				CapacityReductionCompressionControlled = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceAxialCompression = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceSteel = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceConcrete = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceIrregularSectionMinDim = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 4, null),
				ReinforcementRatioMinimum = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.Percent, 4, null),
				ReinforcementRatioMaximum = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.Percent, 4, null),
				ReinforcementBarsMinClearSpacing = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 4, null),
				AllowableCapacityRatio = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 4, null),
				ReinforcementSize = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 0, null),
				ReinforcementDiameter = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 5, null),
				ReinforcementArea = new ColumnUnit<AreaUnit>(UnitSystem.USCustomary, AreaUnit.InchSquared, 5, null),
				ReinforcementWeight = new ColumnUnit<MassPerLengthUnit>(UnitSystem.USCustomary, MassPerLengthUnit.PoundPerLinearFoot, 6, null)
			};
		}

		// Token: 0x06002010 RID: 8208 RVA: 0x000C3E0C File Offset: 0x000C200C
		internal static #Z4 #r6()
		{
			return new #Z4
			{
				ConcreteStrength = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 4, null),
				ConcreteElasticity = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 1, null),
				ConcreteMaxStress = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 4, null),
				ConcreteBetaOne = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				ConcreteUltimateStrain = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 8, null),
				ReinforcingSteelStrength = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 3, null),
				ReinforcingSteelElasticity = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 0, null),
				ReinforcingSteelEtyLimit = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 8, null),
				CapacityReductionAxialCompression = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				CapacityReductionTensionControlled = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				CapacityReductionCompressionControlled = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceAxialCompression = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceSteel = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceConcrete = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				MaterialResistanceIrregularSectionMinDim = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 4, null),
				ReinforcementRatioMinimum = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.Percent, 4, null),
				ReinforcementRatioMaximum = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.Percent, 4, null),
				ReinforcementBarsMinClearSpacing = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 3, null),
				AllowableCapacityRatio = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 4, null),
				ReinforcementSize = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 0, null),
				ReinforcementDiameter = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 5, null),
				ReinforcementArea = new ColumnUnit<AreaUnit>(UnitSystem.SIMetric, AreaUnit.MillimeterSquared, 4, null),
				ReinforcementWeight = new ColumnUnit<MassPerLengthUnit>(UnitSystem.SIMetric, MassPerLengthUnit.KilogramPerMeter, 6, null)
			};
		}

		// Token: 0x06002011 RID: 8209 RVA: 0x000C4008 File Offset: 0x000C2208
		internal static #p6 #s6()
		{
			return new #p6
			{
				DesignColumnClearHeight = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Foot, 6, null),
				SwayCriteriaPcPc = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 5, null),
				SwayCriteriaPuPu = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 5, null),
				EffectiveLengthKNSFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				EffectiveLengthKSFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null),
				ColumnHeight = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Foot, 6, null),
				ColumnWidth = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 6, null),
				ColumnDepth = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 6, null),
				ColumnFc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 6, null),
				ColumnEc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 4, null),
				BeamSpan = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Foot, 6, null),
				BeamWidth = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 6, null),
				BeamDepth = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 6, null),
				BeamFc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 6, null),
				BeamEc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.USCustomary, ForcePerAreaUnit.KiloPoundForcePerSquareInch, 6, null),
				BeamInertia = new ColumnUnit<AreaMomentOfInertiaUnit>(UnitSystem.USCustomary, AreaMomentOfInertiaUnit.InchesDoubleSquared, 6, #Phc.#3hc(107386851)),
				SlendernessStiffnessReductionFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 2, null),
				SlendernessClbCoeff = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 2, null),
				SlendernessClcCoeff = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 2, null)
			};
		}

		// Token: 0x06002012 RID: 8210 RVA: 0x000C41C0 File Offset: 0x000C23C0
		internal static #p6 #t6()
		{
			return new #p6
			{
				DesignColumnClearHeight = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Meter, 6, null),
				SwayCriteriaPcPc = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 5, null),
				SwayCriteriaPuPu = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 5, null),
				EffectiveLengthKNSFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				EffectiveLengthKSFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				ColumnHeight = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Meter, 6, null),
				ColumnWidth = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 6, null),
				ColumnDepth = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 6, null),
				ColumnFc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 6, null),
				ColumnEc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 4, null),
				BeamSpan = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Meter, 6, null),
				BeamWidth = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 6, null),
				BeamDepth = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 6, null),
				BeamFc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 6, null),
				BeamEc = new ColumnUnit<ForcePerAreaUnit>(UnitSystem.SIMetric, ForcePerAreaUnit.MegaPascal, 4, null),
				BeamInertia = new ColumnUnit<AreaMomentOfInertiaUnit>(UnitSystem.SIMetric, AreaMomentOfInertiaUnit.MilimetersDoubleSquared, 4, #Phc.#3hc(107386851)),
				SlendernessStiffnessReductionFactor = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				SlendernessClbCoeff = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null),
				SlendernessClcCoeff = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null)
			};
		}

		// Token: 0x06002013 RID: 8211 RVA: 0x000C4378 File Offset: 0x000C2578
		internal static #r5 #u6()
		{
			return new #r5
			{
				FactoredLoadPu = new ColumnUnit<ForceUnit>(UnitSystem.USCustomary, ForceUnit.KiloPoundForce, 10, null),
				FactoredLoadMux = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 10, null),
				FactoredLoadMuy = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 10, null),
				AxialLoadInitial = new ColumnUnit<ForceUnit>(UnitSystem.USCustomary, ForceUnit.KiloPoundForce, 5, null),
				AxialLoadFinal = new ColumnUnit<ForceUnit>(UnitSystem.USCustomary, ForceUnit.KiloPoundForce, 6, null),
				AxialLoadIncrement = new ColumnUnit<ForceUnit>(UnitSystem.USCustomary, ForceUnit.KiloPoundForce, 6, null),
				ServiceLoadP = new ColumnUnit<ForceUnit>(UnitSystem.USCustomary, ForceUnit.KiloPoundForce, 5, null),
				ServiceLoadMxTop = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 5, null),
				ServiceLoadMxBot = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 5, null),
				ServiceLoadMyTop = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 5, null),
				ServiceLoadMyBot = new ColumnUnit<MomentUnit>(UnitSystem.USCustomary, MomentUnit.FootKiloPoundForce, 5, null),
				SustainedLoad = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.Percent),
				LoadCombination = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 6, null)
			};
		}

		// Token: 0x06002014 RID: 8212 RVA: 0x000C44B0 File Offset: 0x000C26B0
		internal static #r5 #v6()
		{
			return new #r5
			{
				FactoredLoadPu = new ColumnUnit<ForceUnit>(UnitSystem.SIMetric, ForceUnit.KiloNewton, 6, null),
				FactoredLoadMux = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 6, null),
				FactoredLoadMuy = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 6, null),
				AxialLoadInitial = new ColumnUnit<ForceUnit>(UnitSystem.SIMetric, ForceUnit.KiloNewton, 6, null),
				AxialLoadFinal = new ColumnUnit<ForceUnit>(UnitSystem.SIMetric, ForceUnit.KiloNewton, 6, null),
				AxialLoadIncrement = new ColumnUnit<ForceUnit>(UnitSystem.SIMetric, ForceUnit.KiloNewton, 6, null),
				ServiceLoadP = new ColumnUnit<ForceUnit>(UnitSystem.SIMetric, ForceUnit.KiloNewton, 5, null),
				ServiceLoadMxTop = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 5, null),
				ServiceLoadMxBot = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 5, null),
				ServiceLoadMyTop = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 5, null),
				ServiceLoadMyBot = new ColumnUnit<MomentUnit>(UnitSystem.SIMetric, MomentUnit.KiloNewtonMeter, 5, null),
				SustainedLoad = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.Percent),
				LoadCombination = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 6, null)
			};
		}

		// Token: 0x06002015 RID: 8213 RVA: 0x000C45E4 File Offset: 0x000C27E4
		internal static #M5 #w6()
		{
			return new #M5
			{
				Width = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 4, null),
				Depth = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 4, null),
				Diameter = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 4, null),
				ClearCover = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 5, null),
				BarArea = new ColumnUnit<AreaUnit>(UnitSystem.USCustomary, AreaUnit.InchSquared, 5, null),
				BarXCoord = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 5, null),
				BarYCoord = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 5, null),
				BarZCoord = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 5, null),
				MinClearBarSpacing = new ColumnUnit<LengthUnit>(UnitSystem.USCustomary, LengthUnit.Inch, 2, null),
				GrossArea = new ColumnUnit<AreaUnit>(UnitSystem.USCustomary, AreaUnit.InchSquared, 2, null),
				TotalAs = new ColumnUnit<AreaUnit>(UnitSystem.USCustomary, AreaUnit.InchSquared, 2, null),
				Rho = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.Percent, 2, null),
				MaxCapacityRatio = new ColumnUnit<DimensionlessUnit>(UnitSystem.USCustomary, DimensionlessUnit.ConstantValue, 2, null)
			};
		}

		// Token: 0x06002016 RID: 8214 RVA: 0x000C4718 File Offset: 0x000C2918
		internal static #M5 #x6()
		{
			return new #M5
			{
				Width = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 3, null),
				Depth = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 3, null),
				Diameter = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 3, null),
				ClearCover = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 4, null),
				BarArea = new ColumnUnit<AreaUnit>(UnitSystem.SIMetric, AreaUnit.MillimeterSquared, 2, null),
				BarXCoord = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 2, null),
				BarYCoord = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 2, null),
				BarZCoord = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 2, null),
				MinClearBarSpacing = new ColumnUnit<LengthUnit>(UnitSystem.SIMetric, LengthUnit.Millimeter, 2, null),
				GrossArea = new ColumnUnit<AreaUnit>(UnitSystem.SIMetric, AreaUnit.MillimeterSquared, 2, null),
				TotalAs = new ColumnUnit<AreaUnit>(UnitSystem.SIMetric, AreaUnit.MillimeterSquared, 2, null),
				Rho = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.Percent, 2, null),
				MaxCapacityRatio = new ColumnUnit<DimensionlessUnit>(UnitSystem.SIMetric, DimensionlessUnit.ConstantValue, 2, null)
			};
		}
	}
}

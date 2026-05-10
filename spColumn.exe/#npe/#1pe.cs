using System;
using #9pe;
using #P6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #npe
{
	// Token: 0x02001117 RID: 4375
	internal static class #1pe
	{
		// Token: 0x06009428 RID: 37928 RVA: 0x001F9A50 File Offset: 0x001F7C50
		public static void #vpe(UnitSystem #Qg, DesignCodes #is, ConfinementType #DJb, bool #Ype, #kqe #Zpe)
		{
			#N5e #N5e = new #N5e((#A5e)#is);
			if (#DJb == ConfinementType.Tied)
			{
				#Zpe.C = (#N5e.IsCodeAci ? 0.65f : ((#is == DesignCodes.CSA94) ? 0.6f : (#Ype ? 0.7f : 0.65f)));
				#Zpe.B = (#N5e.IsCodeAci ? 0.9f : 0.85f);
				#Zpe.A = 0.8f;
			}
			else if (#DJb == ConfinementType.Spiral)
			{
				#Zpe.C = (#N5e.IsCodeAci ? (#N5e.IsCodeAci08Plus ? 0.75f : 0.7f) : ((#is == DesignCodes.CSA94) ? 0.6f : (#Ype ? 0.7f : 0.65f)));
				#Zpe.B = (#N5e.IsCodeAci ? 0.9f : 0.85f);
				#Zpe.A = (#N5e.IsCodeCsa14Plus ? 0.9f : 0.85f);
			}
			#Zpe.Trans = 0.1f;
		}

		// Token: 0x06009429 RID: 37929 RVA: 0x001F9B48 File Offset: 0x001F7D48
		public static void #0pe(ColumnStorageModel #Od)
		{
			DesignEngine designEngine = new DesignEngine(#Od, new #O6e());
			designEngine.#tOe();
			ReductionFactors reductionFactors = #Od.ReductionFactors;
			#N5e #N5e = new #N5e((#A5e)#Od.Options.Code);
			Options options = #Od.Options;
			#Od.Options.RedType = 0;
			#1pe.#vpe(options.Unit, options.Code, options.ConfinementType, #Od.MaterialProperties.Precast, #Od.ReductionFactors);
			reductionFactors.A = designEngine.CodeExpert.#j8e(designEngine.InputModel, designEngine.RuntimeModel, #Od.ReductionFactors.A, #Od.ReductionFactors.MinDimension);
			if (#N5e.IsCodeAci)
			{
				if (#Od.SlendernessOptFactor == 0)
				{
					#Od.StiffnessReductionFactorPhi = 0.75f;
					return;
				}
			}
			else
			{
				reductionFactors.Trans = 0.1f;
				if (#Od.SlendernessOptFactor == 0)
				{
					#Od.StiffnessReductionFactorPhi = 0.75f;
				}
			}
		}
	}
}

using System;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #6re
{
	// Token: 0x0200116D RID: 4461
	internal static class #Ise
	{
		// Token: 0x0600970F RID: 38671 RVA: 0x001FC748 File Offset: 0x001FA948
		public static #Gse #Hse(this #yse #iw, #lte #Od)
		{
			#Gse #Gse = #iw.#kJ();
			if (#Od != null)
			{
				if (#Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity)
				{
					#Gse.CapacityRatioFilterValue = 1.0;
				}
				#Gse.CapacityRatioCalculationMethod = #Od.Input.Options.SectionCapacityMethod;
			}
			return #Gse;
		}
	}
}

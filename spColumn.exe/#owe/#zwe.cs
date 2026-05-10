using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.Units;

namespace #owe
{
	// Token: 0x02001196 RID: 4502
	internal static class #zwe
	{
		// Token: 0x0600989A RID: 39066 RVA: 0x00202CF8 File Offset: 0x00200EF8
		public static void #ywe(UnitSystem #Qg, GeneralInformation #6h)
		{
			if (#Qg == UnitSystem.SIMetric)
			{
				#6h.UnitStringD = #Phc.#3hc(107230530);
				#6h.UnitStringL = #Phc.#3hc(107230552);
				#6h.UnitStringF = #Phc.#3hc(107223876);
				#6h.UnitStringM = #Phc.#3hc(107223851);
				#6h.UnitStringS = #Phc.#3hc(107223286);
				#6h.UnitStringW = #Phc.#3hc(107246951);
				return;
			}
			#6h.UnitStringD = #Phc.#3hc(107265223);
			#6h.UnitStringL = #Phc.#3hc(107230535);
			#6h.UnitStringF = #Phc.#3hc(107230564);
			#6h.UnitStringM = #Phc.#3hc(107286734);
			#6h.UnitStringS = #Phc.#3hc(107223239);
			#6h.UnitStringW = #Phc.#3hc(107223274);
		}
	}
}

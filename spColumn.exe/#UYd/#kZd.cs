using System;
using System.Xml.Linq;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #UYd
{
	// Token: 0x02000ECD RID: 3789
	internal static class #kZd
	{
		// Token: 0x06008671 RID: 34417 RVA: 0x0006D6AD File Offset: 0x0006B8AD
		public static string #iZd(string #jZd)
		{
			string #R0d = #Phc.#3hc(107226846);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226797);
			if (!false)
			{
				#X0d.#V0d(#jZd, #R0d, #x6c, #Qic);
			}
			return XDocument.Parse(#jZd).ToString(SaveOptions.DisableFormatting);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02001290 RID: 4752
	public static class SettingsHelper
	{
		// Token: 0x06009F42 RID: 40770 RVA: 0x0021CD44 File Offset: 0x0021AF44
		public static string #0Le(List<double> #Wne)
		{
			if (#Wne == null || !#Wne.Any<double>())
			{
				return null;
			}
			#Wne = #Wne.Distinct<double>().OrderBy(new Func<double, double>(SettingsHelper.<>c.<>9.#Dgf)).ToList<double>();
			return string.Join(#Phc.#3hc(107376612), #Wne.Select(new Func<double, string>(SettingsHelper.<>c.<>9.#Egf)));
		}

		// Token: 0x06009F43 RID: 40771 RVA: 0x0021CDC4 File Offset: 0x0021AFC4
		public static string #1Le(List<double> #Wne)
		{
			if (#Wne == null || !#Wne.Any<double>())
			{
				return null;
			}
			#Wne = #Wne.Select(new Func<double, double>(SettingsHelper.<>c.<>9.#Fgf)).Distinct<double>().OrderBy(new Func<double, double>(SettingsHelper.<>c.<>9.#Ggf)).ToList<double>();
			return string.Join(#Phc.#3hc(107376612), #Wne.Select(new Func<double, string>(SettingsHelper.<>c.<>9.#Hgf)));
		}
	}
}

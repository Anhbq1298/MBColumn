using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using #7hc;
using #eU;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Products.Column.ViewModels.Etabs;

namespace #ID
{
	// Token: 0x0200022E RID: 558
	internal sealed class #eF
	{
		// Token: 0x060012DB RID: 4827 RVA: 0x000ACC24 File Offset: 0x000AAE24
		public void #zl(Stream #gp, #oW #xn, IEnumerable<PreviewItem> #8f)
		{
			string str = #Phc.#3hc(107408397);
			using (StreamWriter streamWriter = new StreamWriter(#gp, Encoding.UTF8, 1024, true))
			{
				#eF.#Ppb(#xn, streamWriter);
				foreach (PreviewItem previewItem in #8f)
				{
					streamWriter.Write(previewItem.Member + str);
					streamWriter.Write(previewItem.Section + str);
					streamWriter.Write(previewItem.LoadCombination + str);
					streamWriter.Write(previewItem.Station + str);
					streamWriter.Write(previewItem.Step + str);
					streamWriter.Write(previewItem.Load.P.ToString(#Phc.#3hc(107408392), CultureInfo.InvariantCulture) + str);
					streamWriter.Write(previewItem.Load.Mx.ToString(#Phc.#3hc(107408392), CultureInfo.InvariantCulture) + str);
					streamWriter.Write(previewItem.Load.My.ToString(#Phc.#3hc(107408392), CultureInfo.InvariantCulture));
					streamWriter.WriteLine();
				}
				streamWriter.Flush();
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x000ACDCC File Offset: 0x000AAFCC
		private static void #Ppb(#oW #xn, StreamWriter #Ipb)
		{
			#Ipb.WriteLine(#Phc.#3hc(107408387));
			UnitSystem unitSystem = #xn.Model.Options.Unit;
			string text = UnitSymbolProvider.#29d((unitSystem == UnitSystem.USCustomary) ? LengthUnit.Foot : LengthUnit.Meter).Symbol;
			string text2 = #xn.Model.Units.Loads.FactoredLoadPu.Symbol;
			string text3 = #xn.Model.Units.Loads.FactoredLoadMux.Symbol;
			#Ipb.WriteLine(string.Concat(new string[]
			{
				#Phc.#3hc(107408858),
				text,
				#Phc.#3hc(107408853),
				text2,
				#Phc.#3hc(107408397),
				text3,
				#Phc.#3hc(107408397),
				text3
			}));
		}
	}
}

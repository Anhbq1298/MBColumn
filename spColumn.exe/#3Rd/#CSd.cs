using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #mKd;
using #v1c;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #3Rd
{
	// Token: 0x02000E22 RID: 3618
	internal static class #CSd
	{
		// Token: 0x06008206 RID: 33286 RVA: 0x001C34F8 File Offset: 0x001C16F8
		public static #62c #ul(string #zK, string #VK, ReportFileFormat #ASd, params ReportFileFormat[] #BSd)
		{
			#CSd.#GTb #GTb = new #CSd.#GTb();
			#GTb.#a = #ASd;
			if (#BSd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107276813));
			}
			List<ReportFileFormat> list = #BSd.ToList<ReportFileFormat>();
			list.Add(#GTb.#a);
			List<ReportFileFormat> list2 = list.Distinct<ReportFileFormat>().ToList<ReportFileFormat>();
			List<#L1c> list3 = new List<#L1c>();
			foreach (ReportFileFormat #cA in list2)
			{
				switch (#cA)
				{
				case ReportFileFormat.Word:
					list3.Add(new #pKd(#Phc.#3hc(107276800), #Phc.#3hc(107350801), #cA));
					break;
				case ReportFileFormat.Pdf:
					list3.Add(new #pKd(#Phc.#3hc(107277283), #Phc.#3hc(107350806), #cA));
					break;
				case ReportFileFormat.Text:
					list3.Add(new #pKd(#Phc.#3hc(107277258), #Phc.#3hc(107413479), #cA));
					break;
				case ReportFileFormat.Excel:
					list3.Add(new #pKd(#Phc.#3hc(107277265), #Phc.#3hc(107350248), #cA));
					break;
				case ReportFileFormat.Csv:
					list3.Add(new #pKd(#Phc.#3hc(107277236), #Phc.#3hc(107408483), #cA));
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			#zK = (\u0003.\u0004(#zK) ? \u001E\u0006.\u001F\u0010(Environment.SpecialFolder.Personal) : #zK);
			#pKd #pKd = list3.OfType<#pKd>().First(new Func<#pKd, bool>(#GTb.#2Wd));
			#VK = \u0010.\u0092(#VK, #Phc.#3hc(107356879), #pKd.Extension);
			return new #62c(list3, #pKd.Extension, #zK)
			{
				FilterIndex = list3.OfType<#pKd>().ToList<#pKd>().IndexOf(#pKd),
				InitialFileName = #VK
			};
		}

		// Token: 0x02000E23 RID: 3619
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008208 RID: 33288 RVA: 0x00069DE9 File Offset: 0x00067FE9
			internal bool #2Wd(#pKd #Rf)
			{
				return #Rf.Format == this.#a;
			}

			// Token: 0x04003557 RID: 13655
			public ReportFileFormat #a;
		}
	}
}

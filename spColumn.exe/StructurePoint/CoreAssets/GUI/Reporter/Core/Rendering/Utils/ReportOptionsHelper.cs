using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Utils
{
	// Token: 0x02000D11 RID: 3345
	public static class ReportOptionsHelper
	{
		// Token: 0x06006E39 RID: 28217 RVA: 0x001A44C0 File Offset: 0x001A26C0
		public static void #xdd<#ydd>(#ydd #5d, Option #bA) where #ydd : DocumentContentOptionsCore
		{
			ReportOptionsHelper<#ydd>.#EUd #EUd = new ReportOptionsHelper<!!0>.#EUd();
			#EUd.#a = #bA;
			if (#5d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384720));
			}
			IReadOnlyList<Option> #zPd = #5d.#Fcd();
			#hZd.#mbb<Option>(#zPd, new Func<Option, IEnumerable<Option>>(ReportOptionsHelper.<>c__0<!!0>.<>9.#FUd), new Action<Option>(ReportOptionsHelper.<>c__0<!!0>.<>9.#GUd));
			#hZd.#mbb<Option>(#zPd, new Func<Option, IEnumerable<Option>>(ReportOptionsHelper.<>c__0<!!0>.<>9.#HUd), new Action<Option>(#EUd.#DUd));
		}

		// Token: 0x02000D13 RID: 3347
		[CompilerGenerated]
		private sealed class #EUd<#ydd> where #ydd : DocumentContentOptionsCore
		{
			// Token: 0x06006E42 RID: 28226 RVA: 0x001A4590 File Offset: 0x001A2790
			internal void #DUd(Option #uXb)
			{
				if (!\u0003.\u0004(#uXb.BookmarkName) && \u0093.\u0016\u0003(#uXb.BookmarkName, this.#a.BookmarkName))
				{
					#uXb.Value = new bool?(true);
					#uXb.IsEnabled = true;
					#hZd.#bZd<Option>(#uXb, new Func<Option, Option>(ReportOptionsHelper.<>c__0<!0>.<>9.#IUd)).#I1d(new Action<Option>(ReportOptionsHelper.<>c__0<!0>.<>9.#JUd));
				}
			}

			// Token: 0x04002C58 RID: 11352
			public Option #a;
		}
	}
}

using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D5 RID: 4565
	internal sealed class #dze : #nwe
	{
		// Token: 0x060099AE RID: 39342 RVA: 0x00079E04 File Offset: 0x00078004
		public #dze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099AF RID: 39343 RVA: 0x0020AC0C File Offset: 0x00208E0C
		public override void #pEd()
		{
			Option option = base.Options.LoadingLoadCombinations;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringLoadCombinations = Localization.StringLoadCombinations;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringLoadCombinations, #4cd, null, #Tcd, null);
			base.#Rcd(new LoadingLoadCombinationsTable(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

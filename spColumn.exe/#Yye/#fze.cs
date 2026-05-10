using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D7 RID: 4567
	internal sealed class #fze : #nwe
	{
		// Token: 0x060099B2 RID: 39346 RVA: 0x00079E04 File Offset: 0x00078004
		public #fze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099B3 RID: 39347 RVA: 0x0020ACFC File Offset: 0x00208EFC
		public override void #pEd()
		{
			Option option = base.Options.LoadingLoadCases;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringLoadCases = Localization.StringLoadCases;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringLoadCases, #4cd, null, #Tcd, null);
			base.#Rcd(new #yye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

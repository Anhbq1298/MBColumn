using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D8 RID: 4568
	internal sealed class #gze : #nwe
	{
		// Token: 0x060099B4 RID: 39348 RVA: 0x00079E04 File Offset: 0x00078004
		public #gze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099B5 RID: 39349 RVA: 0x0020AD74 File Offset: 0x00208F74
		public override void #pEd()
		{
			Option option = base.Options.LoadingLoadCases;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSustainedLoadFactors = Localization.StringSustainedLoadFactors;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSustainedLoadFactors, #4cd, null, #Tcd, null);
			base.#Rcd(new #zye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

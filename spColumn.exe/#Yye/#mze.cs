using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011DE RID: 4574
	internal sealed class #mze : #nwe
	{
		// Token: 0x060099C0 RID: 39360 RVA: 0x00079E04 File Offset: 0x00078004
		public #mze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099C1 RID: 39361 RVA: 0x0020B0B4 File Offset: 0x002092B4
		public override void #pEd()
		{
			Option option = base.Options.MomentGeneralParameters;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringGeneralParameters = Localization.StringGeneralParameters;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringGeneralParameters, #4cd, null, #Tcd, null);
			base.#Rcd(new #Gye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

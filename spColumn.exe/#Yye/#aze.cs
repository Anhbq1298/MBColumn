using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011CD RID: 4557
	internal sealed class #aze : #nwe
	{
		// Token: 0x0600998E RID: 39310 RVA: 0x00079E04 File Offset: 0x00078004
		public #aze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600998F RID: 39311 RVA: 0x0020A494 File Offset: 0x00208694
		public override void #pEd()
		{
			Option option = base.Options.ReinforcementConfinementAndFactors;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringConfinementAndFactors = Localization.StringConfinementAndFactors;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringConfinementAndFactors, #4cd, null, #Tcd, null);
			base.#Rcd(new #Lye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

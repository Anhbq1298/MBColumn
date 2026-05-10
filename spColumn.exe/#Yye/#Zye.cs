using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C1 RID: 4545
	internal sealed class #Zye : #nwe
	{
		// Token: 0x0600996D RID: 39277 RVA: 0x00079E04 File Offset: 0x00078004
		public #Zye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600996E RID: 39278 RVA: 0x002099EC File Offset: 0x00207BEC
		public override void #pEd()
		{
			Option option = base.Options.GeneralInformation;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringGeneralInformation = Localization.StringGeneralInformation;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringGeneralInformation, #4cd, null, #Tcd, null);
			base.#Rcd(new #vye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

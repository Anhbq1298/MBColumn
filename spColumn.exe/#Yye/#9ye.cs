using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011CC RID: 4556
	internal sealed class #9ye : #nwe
	{
		// Token: 0x0600998C RID: 39308 RVA: 0x00079E04 File Offset: 0x00078004
		public #9ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600998D RID: 39309 RVA: 0x0020A41C File Offset: 0x0020861C
		public override void #pEd()
		{
			Option option = base.Options.ReinforcementDesignCriteria;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringDesignCriteria = Localization.StringDesignCriteria;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringDesignCriteria, #4cd, null, #Tcd, null);
			base.#Rcd(new #Mye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

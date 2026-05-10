using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011DA RID: 4570
	internal sealed class #ize : #nwe
	{
		// Token: 0x060099B8 RID: 39352 RVA: 0x00079E04 File Offset: 0x00078004
		public #ize(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099B9 RID: 39353 RVA: 0x0020AE38 File Offset: 0x00209038
		public override void #pEd()
		{
			if (!base.Options.SlendernessSwayCriteria.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSwayCriteria = Localization.StringSwayCriteria;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = base.Options.SlendernessSwayCriteria.BookmarkName;
			#ldd.#3cd(stringSwayCriteria, #4cd, null, #Tcd, null);
			base.#Rcd(new #Vye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

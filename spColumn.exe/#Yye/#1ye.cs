using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C3 RID: 4547
	internal sealed class #1ye : #nwe
	{
		// Token: 0x06009971 RID: 39281 RVA: 0x00079E04 File Offset: 0x00078004
		public #1ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x06009972 RID: 39282 RVA: 0x00209AB0 File Offset: 0x00207CB0
		public override void #pEd()
		{
			Option option = base.Options.MaterialPropertiesConcrete;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringConcrete = Localization.StringConcrete;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringConcrete, #4cd, null, #Tcd, null);
			base.#Rcd(new #Aye(base.Model, null));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

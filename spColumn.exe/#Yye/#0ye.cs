using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C2 RID: 4546
	internal sealed class #0ye : #nwe
	{
		// Token: 0x0600996F RID: 39279 RVA: 0x00079E4A File Offset: 0x0007804A
		public #0ye(#pwe #ib) : base(#ib)
		{
			base.Children.Add(new #1ye(#ib));
			base.Children.Add(new #2ye(#ib));
		}

		// Token: 0x06009970 RID: 39280 RVA: 0x00209A64 File Offset: 0x00207C64
		public override void #pEd()
		{
			Option option = base.Options.MaterialProperties;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringMaterialProperties = Localization.StringMaterialProperties;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringMaterialProperties, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

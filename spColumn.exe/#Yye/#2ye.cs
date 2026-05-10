using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C4 RID: 4548
	internal sealed class #2ye : #nwe
	{
		// Token: 0x06009973 RID: 39283 RVA: 0x00079E04 File Offset: 0x00078004
		public #2ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x06009974 RID: 39284 RVA: 0x00209B28 File Offset: 0x00207D28
		public override void #pEd()
		{
			Option option = base.Options.MaterialPropertiesSteel;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSteel = Localization.StringSteel;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSteel, #4cd, null, #Tcd, null);
			base.#Rcd(new #Bye(base.Model, null));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

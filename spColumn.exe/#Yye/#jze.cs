using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011DB RID: 4571
	internal sealed class #jze : #nwe
	{
		// Token: 0x060099BA RID: 39354 RVA: 0x00079E04 File Offset: 0x00078004
		public #jze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099BB RID: 39355 RVA: 0x0020AEB8 File Offset: 0x002090B8
		public override void #pEd()
		{
			Option option = base.Options.SlendernessColumns;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringColumns = Localization.StringColumns;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringColumns, #4cd, null, #Tcd, null);
			base.#Rcd(new #Uye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

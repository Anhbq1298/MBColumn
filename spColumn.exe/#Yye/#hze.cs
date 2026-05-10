using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D9 RID: 4569
	internal sealed class #hze : #nwe
	{
		// Token: 0x060099B6 RID: 39350 RVA: 0x00079F75 File Offset: 0x00078175
		public #hze(#pwe #ib) : base(#ib)
		{
			base.Children.Add(new #ize(#ib));
			base.Children.Add(new #jze(#ib));
			base.Children.Add(new #kze(#ib));
		}

		// Token: 0x060099B7 RID: 39351 RVA: 0x0020ADEC File Offset: 0x00208FEC
		public override void #pEd()
		{
			Option option = base.Options.Slenderness;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSlenderness = Localization.StringSlenderness;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSlenderness, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

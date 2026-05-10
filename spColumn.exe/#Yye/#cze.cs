using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D4 RID: 4564
	internal sealed class #cze : #nwe
	{
		// Token: 0x060099AC RID: 39340 RVA: 0x0020AB14 File Offset: 0x00208D14
		public #cze(#pwe #ib) : base(#ib)
		{
			if (#ib.Model.TestOptions.TestMode)
			{
				base.Children.Add(new #dze(base.Context));
				base.Children.Add(new #eze(base.Context));
				base.Children.Add(new #gze(base.Context));
				return;
			}
			base.Children.Add(new #fze(base.Context));
			base.Children.Add(new #dze(base.Context));
			base.Children.Add(new #eze(base.Context));
		}

		// Token: 0x060099AD RID: 39341 RVA: 0x0020ABC0 File Offset: 0x00208DC0
		public override void #pEd()
		{
			Option option = base.Options.Loading;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringLoading = Localization.StringLoading;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringLoading, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

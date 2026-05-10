using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011DD RID: 4573
	internal sealed class #lze : #nwe
	{
		// Token: 0x060099BE RID: 39358 RVA: 0x0020B010 File Offset: 0x00209210
		public #lze(#pwe #ib) : base(#ib)
		{
			base.Children.Add(new #mze(base.Context));
			base.Children.Add(new #nze(base.Context));
			base.Children.Add(new MagnificationFactorsItemsPage(base.Context));
		}

		// Token: 0x060099BF RID: 39359 RVA: 0x0020B068 File Offset: 0x00209268
		public override void #pEd()
		{
			Option option = base.Options.MomentMagnification;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringMomentMagnification = Localization.StringMomentMagnification;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringMomentMagnification, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

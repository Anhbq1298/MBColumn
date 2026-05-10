using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011CA RID: 4554
	internal sealed class #7ye : #nwe
	{
		// Token: 0x06009988 RID: 39304 RVA: 0x0020A2C0 File Offset: 0x002084C0
		public #7ye(#pwe #ib) : base(#ib)
		{
			base.Children.Add(new #8ye(#ib));
			base.Children.Add(new #9ye(#ib));
			base.Children.Add(new #aze(base.Context));
			base.Children.Add(new ReinforcementPropertiesPage(base.Context));
			base.Children.Add(new ReinforcementBarsProvidedPage(base.Context));
		}

		// Token: 0x06009989 RID: 39305 RVA: 0x0020A338 File Offset: 0x00208538
		public override void #pEd()
		{
			Option option = base.Options.Reinforcement;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringReinforcement = Localization.StringReinforcement;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringReinforcement, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

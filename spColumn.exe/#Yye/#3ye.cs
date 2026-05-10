using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011C5 RID: 4549
	internal sealed class #3ye : #nwe
	{
		// Token: 0x06009975 RID: 39285 RVA: 0x00079E75 File Offset: 0x00078075
		public #3ye(#pwe #ib) : base(#ib)
		{
			base.Children.Add(new #4ye(#ib));
			base.Children.Add(new #5ye(#ib));
			base.Children.Add(new ExternalAndInternalPointsPage(#ib));
		}

		// Token: 0x06009976 RID: 39286 RVA: 0x00209BA0 File Offset: 0x00207DA0
		public override void #pEd()
		{
			Option option = base.Options.Section;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringSection = Localization.StringSection;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSection, #4cd, null, #Tcd, null);
			base.#wEd();
		}
	}
}

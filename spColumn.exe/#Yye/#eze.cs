using System;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011D6 RID: 4566
	internal sealed class #eze : #nwe
	{
		// Token: 0x060099B0 RID: 39344 RVA: 0x00079E04 File Offset: 0x00078004
		public #eze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099B1 RID: 39345 RVA: 0x0020AC84 File Offset: 0x00208E84
		public override void #pEd()
		{
			Option option = base.Options.LoadingServiceLoads;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringServiceLoads = Localization.StringServiceLoads;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringServiceLoads, #4cd, null, #Tcd, null);
			base.#Rcd(new LoadingServiceLoadsTable(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

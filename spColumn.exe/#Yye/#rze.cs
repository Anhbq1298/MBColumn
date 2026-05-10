using System;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #Yye
{
	// Token: 0x020011EB RID: 4587
	internal sealed class #rze : #nwe
	{
		// Token: 0x06009A09 RID: 39433 RVA: 0x00079E04 File Offset: 0x00078004
		public #rze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x06009A0A RID: 39434 RVA: 0x0020BB7C File Offset: 0x00209D7C
		public override void #pEd()
		{
			Option option = base.Options.LoadsAndCapacities;
			Options options = base.Model.Input.Options;
			if (!option.#ISd() || options.ActiveLoad != LoadType.Axial || (base.Model.TestOptions.TestMode && base.Model.TestOptions.OriginalLoadType == LoadType.NoLoads))
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringAxialLoadsAndCorrespondingMomentCapacities = Localization.StringAxialLoadsAndCorrespondingMomentCapacities;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringAxialLoadsAndCorrespondingMomentCapacities, #4cd, null, #Tcd, null);
			base.#Rcd(new #gye(base.Model));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using #hye;
using #owe;
using #Qcd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011D1 RID: 4561
	internal sealed class ReinforcementBarsProvidedPage : #nwe
	{
		// Token: 0x0600999E RID: 39326 RVA: 0x00079E04 File Offset: 0x00078004
		public ReinforcementBarsProvidedPage(#pwe context) : base(context)
		{
		}

		// Token: 0x0600999F RID: 39327 RVA: 0x00079F24 File Offset: 0x00078124
		public static IEnumerable<string> #bze(#lte #Od)
		{
			if (#Od.Input.Options.ActiveReinforcement == ReinforcementType.Irregular)
			{
				if (#Od.BasicProperties.Bars.Any(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, bool>(ReinforcementBarsProvidedPage.<>c.<>9.#Gcf)))
				{
					yield return Localization.StringXBarOutsideOfSection;
					yield return Localization.StringNoteUnreliableResultsMayBeProducedDueToBarsOutsideOfSection.#z2d();
				}
			}
			yield break;
		}

		// Token: 0x060099A0 RID: 39328 RVA: 0x0020A974 File Offset: 0x00208B74
		public override void #pEd()
		{
			Options options = base.Model.Input.Options;
			Option option = base.Options.ReinforcementBarsProvided;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringBarsProvided = Localization.StringBarsProvided;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringBarsProvided, #4cd, null, #Tcd, null);
			if (options.ActiveReinforcement == ReinforcementType.Irregular)
			{
				base.#Rcd(new #Wye(base.Model, 3));
			}
			else
			{
				base.#Rcd(new #Kye(base.Model));
			}
			List<string> #wed = ReinforcementBarsProvidedPage.#bze(base.Model).ToList<string>();
			base.#eCd(#wed, true);
		}
	}
}

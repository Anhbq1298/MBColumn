using System;
using System.Collections.Generic;
using System.Linq;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Yye
{
	// Token: 0x020011DF RID: 4575
	internal sealed class #nze : #nwe
	{
		// Token: 0x060099C2 RID: 39362 RVA: 0x00079E04 File Offset: 0x00078004
		public #nze(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x060099C3 RID: 39363 RVA: 0x0020B12C File Offset: 0x0020932C
		public override void #pEd()
		{
			Option option = base.Options.MomentEffectiveLengthFactors;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringEffectiveLengthFactors = Localization.StringEffectiveLengthFactors;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringEffectiveLengthFactors, #4cd, null, #Tcd, null);
			#Eye #Xpb = new #Eye(base.Model);
			base.#Rcd(#Xpb);
			List<string> #wed = #nze.#bze(base.Model).ToList<string>();
			base.#eCd(#wed, true);
		}

		// Token: 0x060099C4 RID: 39364 RVA: 0x00079FB1 File Offset: 0x000781B1
		public static IEnumerable<string> #bze(#lte #Od)
		{
			int i = #Od.Input.Options.AxisStart;
			while (i <= #Od.Input.Options.AxisEnd)
			{
				if (((i == 0) ? #Od.Output.Slenderness.SlendernessX : #Od.Output.Slenderness.SlendernessY).Klur > 100f)
				{
					yield return Localization.StringNotes.#u2d();
					if (!#Od.Input.Options.IsACI08Plus())
					{
						yield return string.Format(Localization.StringSlendernessKlurIsGreaterThan100, #Yxe.Klur).#z2d();
						yield return Localization.StringASecondOrderFrameAnalysisMustBePerformedToAccountForSlenderness.#z2d();
						break;
					}
					yield return string.Format(Localization.StringSlendernessKlurIsGreaterThan100, #Yxe.Klur).#z2d();
					yield return Localization.StringASecondOrderFrameAnalysisIsRecommendedToAccountForSlenderness.#z2d();
					break;
				}
				else
				{
					i++;
				}
			}
			yield break;
		}
	}
}

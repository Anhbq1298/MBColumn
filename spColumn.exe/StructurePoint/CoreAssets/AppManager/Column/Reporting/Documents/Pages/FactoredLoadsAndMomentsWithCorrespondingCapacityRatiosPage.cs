using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011EC RID: 4588
	internal sealed class FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage : #nwe
	{
		// Token: 0x06009A0B RID: 39435 RVA: 0x00079E04 File Offset: 0x00078004
		public FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage(#pwe context) : base(context)
		{
		}

		// Token: 0x06009A0C RID: 39436 RVA: 0x0007A1C9 File Offset: 0x000783C9
		public static IEnumerable<string> #bze(#lte #Od)
		{
			return FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.#sze(#Od).Union(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.#qze(#Od));
		}

		// Token: 0x06009A0D RID: 39437 RVA: 0x0020BC34 File Offset: 0x00209E34
		public override void #pEd()
		{
			Option option = base.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios;
			if (!option.#ISd() || (base.Model.TestOptions.TestMode && base.Model.TestOptions.OriginalLoadType == LoadType.NoLoads))
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringFactoredLoadsAndMomentsWithCorrespondingCapacityRatios = Localization.StringFactoredLoadsAndMomentsWithCorrespondingCapacityRatios;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringFactoredLoadsAndMomentsWithCorrespondingCapacityRatios, #4cd, null, #Tcd, null);
			base.#eCd(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.#sze(base.Model), false);
			FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable #Xpb = new FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable(base.Model);
			base.#Rcd(#Xpb);
			base.#eCd(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.#qze(base.Model), true);
		}

		// Token: 0x06009A0E RID: 39438 RVA: 0x0007A1DC File Offset: 0x000783DC
		public static IEnumerable<string> #qze(#lte #Od)
		{
			if (#Od.Input.Options.ActiveLoad == LoadType.Factored)
			{
				if (!#Od.Output.BiaxialFactoredLoads.Any(new Func<BiaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Tcf)))
				{
					if (!#Od.Output.UniaxialFactoredLoads.Any(new Func<UniaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Ucf)))
					{
						goto IL_D3;
					}
				}
				yield return Localization.StringSectionCapacityExceededReviseDesign;
				IL_D3:
				if (#Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity)
				{
					if (!#Od.Output.BiaxialFactoredLoads.Any(new Func<BiaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Vcf)))
					{
						if (!#Od.Output.UniaxialFactoredLoads.Any(new Func<UniaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Wcf)))
						{
							goto IL_1D7;
						}
					}
					yield return string.Concat(new string[]
					{
						#Yxe.Pmax,
						#Phc.#3hc(107359847),
						#ned.#qp(#Od.Output.Variables.Pmax, NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
						#Phc.#3hc(107399922),
						#Od.GeneralInfo.UnitStringF
					});
					IL_1D7:
					if (!#Od.Output.BiaxialFactoredLoads.Any(new Func<BiaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Xcf)))
					{
						if (!#Od.Output.UniaxialFactoredLoads.Any(new Func<UniaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Ycf)))
						{
							goto IL_559;
						}
					}
					yield return string.Concat(new string[]
					{
						#Yxe.Pmin,
						#Phc.#3hc(107359847),
						#ned.#qp(#Od.Output.Variables.Pmin, NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
						#Phc.#3hc(107399922),
						#Od.GeneralInfo.UnitStringF
					});
				}
			}
			else if (#Od.Input.Options.ActiveLoad == LoadType.Service)
			{
				if (!#Od.Output.BiaxialServiceLoads.Any(new Func<BiaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#Zcf)))
				{
					if (!#Od.Output.UniaxialServiceLoads.Any(new Func<UniaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#0cf)))
					{
						goto IL_36B;
					}
				}
				yield return Localization.StringSectionCapacityExceededReviseDesign;
				IL_36B:
				if (#Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity)
				{
					if (!#Od.Output.BiaxialServiceLoads.Any(new Func<BiaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#1cf)))
					{
						if (!#Od.Output.UniaxialServiceLoads.Any(new Func<UniaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#2cf)))
						{
							goto IL_46F;
						}
					}
					yield return string.Concat(new string[]
					{
						#Yxe.Pmax,
						#Phc.#3hc(107359847),
						#ned.#qp(#Od.Output.Variables.Pmax, NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
						#Phc.#3hc(107399922),
						#Od.GeneralInfo.UnitStringF
					});
					IL_46F:
					if (!#Od.Output.BiaxialServiceLoads.Any(new Func<BiaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#3cf)))
					{
						if (!#Od.Output.UniaxialServiceLoads.Any(new Func<UniaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.<>c.<>9.#4cf)))
						{
							goto IL_559;
						}
					}
					yield return string.Concat(new string[]
					{
						#Yxe.Pmin,
						#Phc.#3hc(107359847),
						#ned.#qp(#Od.Output.Variables.Pmin, NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
						#Phc.#3hc(107399922),
						#Od.GeneralInfo.UnitStringF
					});
				}
			}
			IL_559:
			yield break;
		}

		// Token: 0x06009A0F RID: 39439 RVA: 0x0007A1EC File Offset: 0x000783EC
		private static IEnumerable<string> #sze(#lte #Od)
		{
			yield return (#Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.CriticalCapacity) ? Localization.StringNOTECalculationsAreBasedOnCriticalCapacityMethod : Localization.StringNOTECalculationsAreBasedOnConstantAxialLoadMethod;
			if (#Od.Input.Options.ProblemType == ProblemType.Design)
			{
				yield return Localization.StringDesignAllowableCapacityRatio + #Phc.#3hc(107309132) + #ned.#qp(new float?(#Od.Input.DesignToRequiredRatio), NativeNumberFormat.F12_2, #Phc.#3hc(107381628));
			}
			if (#Od.Input.Options.ActiveLoad == LoadType.Service)
			{
				yield return Localization.StringNOTEEachLoadingCombinationIncludesTheFollowingCases.Remove(0, 6).#u2d();
				yield return Localization.StringTopAtColumnTop;
				yield return Localization.StringBotAtColumnBottom;
			}
			yield break;
		}
	}
}

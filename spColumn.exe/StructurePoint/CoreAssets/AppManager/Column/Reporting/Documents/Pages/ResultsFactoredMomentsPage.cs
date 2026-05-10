using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011E4 RID: 4580
	internal sealed class ResultsFactoredMomentsPage : #nwe
	{
		// Token: 0x060099E0 RID: 39392 RVA: 0x00079E04 File Offset: 0x00078004
		public ResultsFactoredMomentsPage(#pwe context) : base(context)
		{
		}

		// Token: 0x060099E1 RID: 39393 RVA: 0x0007A09F File Offset: 0x0007829F
		public static IEnumerable<string> #bze(IList<FactoredMoment> #8f)
		{
			return ResultsFactoredMomentsPage.#pze().Union(ResultsFactoredMomentsPage.#qze(#8f));
		}

		// Token: 0x060099E2 RID: 39394 RVA: 0x0020B710 File Offset: 0x00209910
		public override void #pEd()
		{
			if (!base.Options.FactoredMoments.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringFactoredMoments = Localization.StringFactoredMoments;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = base.Options.FactoredMoments.BookmarkName;
			#ldd.#3cd(stringFactoredMoments, #4cd, null, #Tcd, null);
			base.#eCd(ResultsFactoredMomentsPage.#pze(), false);
			foreach (IGrouping<FactoredMoment.Axis, FactoredMoment> grouping in base.Model.Output.FactoredMoments.GroupBy(new Func<FactoredMoment, FactoredMoment.Axis>(ResultsFactoredMomentsPage.<>c.<>9.#Ocf)))
			{
				Option option = (grouping.Key == FactoredMoment.Axis.X) ? base.Options.FactoredMomentsXAxis : base.Options.FactoredMomentsYAxis;
				if (option.#ISd())
				{
					#ldd #ldd2 = base.Renderer;
					string #Ukc = string.Format(Localization.StringXAxis.ToLower(CultureInfo.CurrentCulture), grouping.Key);
					StyleIdentifier #4cd2 = StyleIdentifier.Heading2;
					#Tcd = option.BookmarkName;
					#ldd2.#3cd(#Ukc, #4cd2, null, #Tcd, null);
					this.#oze(grouping.ToList<FactoredMoment>());
				}
			}
		}

		// Token: 0x060099E3 RID: 39395 RVA: 0x0007A0B1 File Offset: 0x000782B1
		private static IEnumerable<string> #pze()
		{
			yield return Localization.StringNOTEEachLoadingCombinationIncludesTheFollowingCases.#u2d();
			yield return Localization.StringTopAtColumnTop;
			yield return Localization.StringBotAtColumnBottom;
			yield break;
		}

		// Token: 0x060099E4 RID: 39396 RVA: 0x0007A0BA File Offset: 0x000782BA
		private static IEnumerable<string> #qze(IList<FactoredMoment> #8f)
		{
			if (#8f.Any(new Func<FactoredMoment, bool>(ResultsFactoredMomentsPage.<>c.<>9.#Pcf)))
			{
				yield return Localization.StringXMminExceedsMiForXAndYAxisBendingButShallBeAppliedToEachAxisSeparatelyForCapacityCheck.#D2d(new object[]
				{
					#Yxe.Mmin,
					#Yxe.Mi
				}).#z2d();
			}
			if (#8f.Any(new Func<FactoredMoment, bool>(ResultsFactoredMomentsPage.<>c.<>9.#Qcf)))
			{
				yield return Localization.StringXMagnifiedSecondOrderMomentExceeds14TimesFirstOrderMomentReviseDesign;
			}
			yield break;
		}

		// Token: 0x060099E5 RID: 39397 RVA: 0x0007A0CA File Offset: 0x000782CA
		private void #oze(IList<FactoredMoment> #8f)
		{
			base.#Rcd(new #tye(base.Model, #8f));
			base.#eCd(ResultsFactoredMomentsPage.#qze(#8f), true);
		}
	}
}

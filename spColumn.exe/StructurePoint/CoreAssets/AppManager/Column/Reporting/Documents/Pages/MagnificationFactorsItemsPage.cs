using System;
using System.Collections.Generic;
using System.Linq;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011E1 RID: 4577
	internal sealed class MagnificationFactorsItemsPage : #nwe
	{
		// Token: 0x060099CD RID: 39373 RVA: 0x00079E04 File Offset: 0x00078004
		public MagnificationFactorsItemsPage(#pwe context) : base(context)
		{
		}

		// Token: 0x060099CE RID: 39374 RVA: 0x00079FEB File Offset: 0x000781EB
		public static IEnumerable<string> #bze(#lte #Od, IList<MomentMagnificationFactor> #Zpe, MomentMagnificationFactor.Axis #6gb)
		{
			if (#Zpe.Any(new Func<MomentMagnificationFactor, bool>(MagnificationFactorsItemsPage.<>c.<>9.#Gcf)))
			{
				yield return Localization.StringXSlendernessNeedNotBeConsidered.#z2d();
			}
			if (#Zpe.Any(new Func<MomentMagnificationFactor, bool>(MagnificationFactorsItemsPage.<>c.<>9.#Lcf)))
			{
				yield return string.Format(Localization.StringxStrengthAndStabilityOfStructureAsAWholeUnderFactoredGravityLoadsIsExceededDeltaSGreaterThanX, #Yxe.DeltaS).#z2d();
				yield return Localization.StringReviseDesign;
			}
			if (#Zpe.Any(new Func<MomentMagnificationFactor, bool>(MagnificationFactorsItemsPage.<>c.<>9.#Mcf)))
			{
				bool flag = (#6gb == MomentMagnificationFactor.Axis.X) ? #Od.Input.DesignedColumnX.IsBraced : #Od.Input.DesignedColumnY.IsBraced;
				string arg = flag ? #Yxe.Pu : #Yxe.SumPu;
				string arg2 = flag ? #Yxe.Pc : #Yxe.SumPc;
				yield return string.Format(Localization.StringAppliedLoadIsGreaterThanBucklingLoadXYZReviseDesign, arg, #Yxe.PhiK, arg2);
			}
			if (#Zpe.Any(new Func<MomentMagnificationFactor, bool>(MagnificationFactorsItemsPage.<>c.<>9.#Ncf)))
			{
				yield return string.Format(Localization.StringFactorXGreaterThan35SecondOrderEffectsAlongColumnLengthAreConsidered, #Yxe.KPrimlur).#z2d();
			}
			yield break;
		}

		// Token: 0x060099CF RID: 39375 RVA: 0x0020B368 File Offset: 0x00209568
		public override void #pEd()
		{
			if (!base.Options.MomentMagnification.#ISd())
			{
				return;
			}
			foreach (IGrouping<MomentMagnificationFactor.Axis, MomentMagnificationFactor> grouping in base.Model.Output.MomentMagnificationFactors.GroupBy(new Func<MomentMagnificationFactor, MomentMagnificationFactor.Axis>(MagnificationFactorsItemsPage.<>c.<>9.#Ocf)))
			{
				Option option = (grouping.Key == MomentMagnificationFactor.Axis.X) ? base.Options.MomentMagnificationFactorsX : base.Options.MomentMagnificationFactorsY;
				if (option.#ISd())
				{
					#ldd #ldd = base.Renderer;
					string #Ukc = string.Format(Localization.StringMagnificationFactorsXAxis, grouping.Key);
					StyleIdentifier #4cd = StyleIdentifier.Heading2;
					string #Tcd = option.BookmarkName;
					#ldd.#3cd(#Ukc, #4cd, null, #Tcd, null);
					this.#oze(grouping.Key, grouping.ToList<MomentMagnificationFactor>());
				}
			}
		}

		// Token: 0x060099D0 RID: 39376 RVA: 0x0020B464 File Offset: 0x00209664
		private void #oze(MomentMagnificationFactor.Axis #6gb, IList<MomentMagnificationFactor> #Zpe)
		{
			base.#eCd(MagnificationFactorsItemsPage.#bze(base.Model, #Zpe, #6gb).ToList<string>(), false);
			base.#Rcd(new #Fye(base.Model, #Zpe));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}

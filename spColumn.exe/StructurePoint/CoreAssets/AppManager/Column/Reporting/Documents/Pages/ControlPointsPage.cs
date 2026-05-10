using System;
using System.Collections.Generic;
using System.Linq;
using #owe;
using #Qcd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011E8 RID: 4584
	internal sealed class ControlPointsPage : #nwe
	{
		// Token: 0x060099FB RID: 39419 RVA: 0x00079E04 File Offset: 0x00078004
		public ControlPointsPage(#pwe context) : base(context)
		{
		}

		// Token: 0x060099FC RID: 39420 RVA: 0x0007A17B File Offset: 0x0007837B
		public static IEnumerable<string> #bze(#lte #Od)
		{
			if (#Od.Output.ControlPoints.Any(new Func<ControlPoint, bool>(ControlPointsPage.<>c.<>9.#Gcf)))
			{
				yield return Localization.StringXAxialLoadCapacityIncreaseInTransitionZoneBetweenBalancedPointAndTensionControlIsNotRepresentedGraphicallyAndIsNotConsideredInSectionDesignAndInvestigation;
			}
			yield break;
		}

		// Token: 0x060099FD RID: 39421 RVA: 0x0020BA30 File Offset: 0x00209C30
		public override void #pEd()
		{
			Option option = base.Options.ControlPoints;
			if (!option.#ISd() || (base.Model.TestOptions.TestMode && base.Model.TestOptions.OriginalLoadType != LoadType.NoLoads))
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string stringControlPoints = Localization.StringControlPoints;
			StyleIdentifier #4cd = StyleIdentifier.Heading1;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringControlPoints, #4cd, null, #Tcd, null);
			base.#Rcd(new ControlPointsTable(base.Model));
			base.#eCd(ControlPointsPage.#bze(base.Model), true);
		}
	}
}

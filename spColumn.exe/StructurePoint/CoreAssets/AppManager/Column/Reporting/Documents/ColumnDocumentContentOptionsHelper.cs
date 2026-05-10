using System;
using System.Collections.Generic;
using System.Linq;
using #12e;
using #7hc;
using #o1d;
using #owe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents
{
	// Token: 0x02001191 RID: 4497
	public sealed class ColumnDocumentContentOptionsHelper
	{
		// Token: 0x06009883 RID: 39043 RVA: 0x00078FF8 File Offset: 0x000771F8
		public ColumnDocumentContentOptionsHelper(#uwe options, #lte model)
		{
			if (options == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.#a = options;
			if (model == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#b = model;
		}

		// Token: 0x06009884 RID: 39044 RVA: 0x00202438 File Offset: 0x00200638
		public void #iwe()
		{
			if (this.#b.Input.Options.SectionType != SectionType.Irregular && this.#b.Input.Options.SectionType != SectionType.IrregularTemplate)
			{
				return;
			}
			this.#a.SectionSolids.Children.Clear();
			List<SectionPolygon> list = this.#b.Input.Polygons.Where(new Func<SectionPolygon, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#9bf)).ToList<SectionPolygon>();
			for (int i = 0; i < list.Count; i++)
			{
				this.#kwe(this.#a.SectionSolids, i);
			}
			this.#a.SectionOpenings.Children.Clear();
			List<SectionPolygon> list2 = this.#b.Input.Polygons.Where(new Func<SectionPolygon, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#acf)).ToList<SectionPolygon>();
			for (int j = 0; j < list2.Count; j++)
			{
				this.#kwe(this.#a.SectionOpenings, j);
			}
		}

		// Token: 0x06009885 RID: 39045 RVA: 0x0020255C File Offset: 0x0020075C
		public void #jwe()
		{
			ColumnStorageModel columnStorageModel = this.#b.Input;
			#l4e #l4e = this.#b.Output;
			this.#a.#Fcd().#I1d(new Action<Option>(ColumnDocumentContentOptionsHelper.<>c.<>9.#bcf));
			#l4e #l4e2 = this.#b.Output;
			bool flag = #l4e2 != null && #l4e2.SolveCompleted;
			bool flag2 = this.#b.Output != null;
			bool #f = columnStorageModel.Options.ProblemType == ProblemType.Design;
			this.#a.MaterialProperties.IsEnabled = true;
			this.#a.MaterialPropertiesConcrete.IsEnabled = true;
			this.#a.MaterialPropertiesSteel.IsEnabled = true;
			ReinforcementType activeReinforcement = columnStorageModel.Options.ActiveReinforcement;
			SectionType sectionType = columnStorageModel.Options.SectionType;
			bool #f2 = (activeReinforcement == ReinforcementType.Different && flag) || (activeReinforcement == ReinforcementType.Irregular && columnStorageModel.ReinforcementBars.Any<ReinforcementBar>());
			this.#a.Section.IsEnabled = true;
			this.#a.SectionShapeAndProperties.IsEnabled = true;
			this.#a.SectionFigure.IsEnabled = true;
			this.#a.SectionSolids.IsEnabled = (columnStorageModel.Polygons.Any(new Func<SectionPolygon, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#ccf)) && (sectionType == SectionType.Irregular || sectionType == SectionType.IrregularTemplate));
			this.#a.SectionOpenings.IsEnabled = (columnStorageModel.Polygons.Any(new Func<SectionPolygon, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#dcf)) && (sectionType == SectionType.Irregular || sectionType == SectionType.IrregularTemplate));
			this.#a.Reinforcement.IsEnabled = true;
			this.#a.ReinforcementBarSet.IsEnabled = true;
			this.#a.ReinforcementDesignCriteria.IsEnabled = #f;
			this.#a.ReinforcementConfinementAndFactors.IsEnabled = true;
			this.#a.ReinforcementProperties.IsEnabled = true;
			this.#a.ReinforcementBarsProvided.IsEnabled = #f2;
			bool #f3 = columnStorageModel.Options.ActiveLoad == LoadType.Service;
			this.#a.Loading.IsEnabled = #f3;
			this.#a.LoadingLoadCases.IsEnabled = #f3;
			this.#a.LoadingLoadCombinations.IsEnabled = #f3;
			this.#a.LoadingServiceLoads.IsEnabled = #f3;
			ConsideredAxis consideredAxis = columnStorageModel.Options.ConsideredAxis;
			bool flag3 = consideredAxis == ConsideredAxis.Y || consideredAxis == ConsideredAxis.Both;
			bool flag4 = consideredAxis == ConsideredAxis.X || consideredAxis == ConsideredAxis.Both;
			bool considerSlenderness = columnStorageModel.Options.ConsiderSlenderness;
			this.#a.Slenderness.IsEnabled = considerSlenderness;
			this.#a.SlendernessSwayCriteria.IsEnabled = considerSlenderness;
			this.#a.SlendernessColumns.IsEnabled = considerSlenderness;
			this.#a.SlendernessYBeams.IsEnabled = (considerSlenderness && flag3);
			this.#a.SlendernessXBeams.IsEnabled = (considerSlenderness && flag4);
			this.#a.MomentMagnification.IsEnabled = (considerSlenderness && flag2);
			this.#a.MomentGeneralParameters.IsEnabled = (considerSlenderness && flag2);
			this.#a.MomentEffectiveLengthFactors.IsEnabled = (considerSlenderness && flag2);
			Option option = this.#a.MomentMagnificationFactorsY;
			bool #f4;
			if (considerSlenderness && flag3 && flag2)
			{
				#f4 = #l4e.MomentMagnificationFactors.Any(new Func<MomentMagnificationFactor, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#ecf));
			}
			else
			{
				#f4 = false;
			}
			option.IsEnabled = #f4;
			Option option2 = this.#a.MomentMagnificationFactorsX;
			bool #f5;
			if (considerSlenderness && flag4 && flag2)
			{
				#f5 = #l4e.MomentMagnificationFactors.Any(new Func<MomentMagnificationFactor, bool>(ColumnDocumentContentOptionsHelper.<>c.<>9.#fcf));
			}
			else
			{
				#f5 = false;
			}
			option2.IsEnabled = #f5;
			this.#a.FactoredMoments.IsEnabled = (considerSlenderness && flag2 && #l4e.FactoredMoments.Any<FactoredMoment>() && #l4e.MomentMagnificationFactors.Any<MomentMagnificationFactor>());
			this.#a.FactoredMomentsYAxis.IsEnabled = (this.#a.FactoredMoments.IsEnabled && flag3 && flag2);
			this.#a.FactoredMomentsXAxis.IsEnabled = (this.#a.FactoredMoments.IsEnabled && flag4 && flag2);
			this.#a.SolverMessages.IsEnabled = (this.#b.Output != null && this.#b.SolverMessages.Any<SolverMessage>());
			this.#a.ControlPoints.IsEnabled = (this.#b.#ite() && flag && #l4e.ControlPoints.Any<ControlPoint>());
			this.#a.LoadsAndCapacities.IsEnabled = (this.#b.#ite() && flag && columnStorageModel.Options.ActiveLoad == LoadType.Axial && this.#b.Input.AxialLoads.Count > 0);
			this.#a.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios.IsEnabled = (this.#b.#ite() && flag && ((columnStorageModel.Options.ActiveLoad == LoadType.Service && this.#b.Input.ServiceLoads.Count > 0 && columnStorageModel.LoadFactors.Any<LoadFactor>()) || (columnStorageModel.Options.ActiveLoad == LoadType.Factored && this.#b.Input.FactoredLoads.Count > 0)));
			this.#a.Screenshots.IsEnabled = (this.#b.#ite() && flag && this.#a.Screenshots.Children.Any<Option>());
			this.#a.Results.#NSd();
		}

		// Token: 0x06009886 RID: 39046 RVA: 0x00079036 File Offset: 0x00077236
		private void #kwe(Option #jA, int #4jb)
		{
			new Option(#jA, #jA.BookmarkName + #Phc.#3hc(107455028) + #4jb.ToString()).IsEnabled = true;
		}

		// Token: 0x040041A0 RID: 16800
		private readonly #uwe #a;

		// Token: 0x040041A1 RID: 16801
		private readonly #lte #b;
	}
}

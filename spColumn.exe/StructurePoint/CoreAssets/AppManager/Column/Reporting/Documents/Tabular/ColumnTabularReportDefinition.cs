using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Fd;
using #7hc;
using #Ded;
using #hye;
using #owe;
using #Rwe;
using #Wse;
using #Yye;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular
{
	// Token: 0x02000458 RID: 1112
	public class ColumnTabularReportDefinition : #Ced
	{
		// Token: 0x060028D0 RID: 10448 RVA: 0x0002584C File Offset: 0x00023A4C
		public ColumnTabularReportDefinition(#uwe options, #lte model)
		{
			this.Options = options;
			this.Model = model;
		}

		// Token: 0x17000DB6 RID: 3510
		// (get) Token: 0x060028D1 RID: 10449 RVA: 0x00025878 File Offset: 0x00023A78
		public #uwe Options { get; }

		// Token: 0x17000DB7 RID: 3511
		// (get) Token: 0x060028D2 RID: 10450 RVA: 0x00025880 File Offset: 0x00023A80
		public #lte Model { get; }

		// Token: 0x17000DB8 RID: 3512
		// (get) Token: 0x060028D3 RID: 10451 RVA: 0x00025888 File Offset: 0x00023A88
		public IReadOnlyList<#JGd> AllHeaders
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x060028D4 RID: 10452 RVA: 0x000DCB00 File Offset: 0x000DAD00
		protected override void #gpb()
		{
			#lte #lte = this.Model;
			Options options = #lte.Input.Options;
			ReinforcementType activeReinforcement = options.ActiveReinforcement;
			this.#bye(#lte);
			if (this.Options.GeneralInformation.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, Localization.StringGeneralInformation, this.Options.GeneralInformation);
				base.#ved(#Ae, new #vye(#lte), null);
			}
			this.#Bed(this.Options.MaterialProperties, StyleIdentifier.Heading1, Localization.StringMaterialProperties);
			if (this.Options.MaterialPropertiesConcrete.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringConcrete, this.Options.MaterialPropertiesConcrete);
				base.#ved(#Ae, new #Aye(#lte, null), null);
			}
			if (this.Options.MaterialPropertiesSteel.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringSteel, this.Options.MaterialPropertiesSteel);
				base.#ved(#Ae, new #Bye(#lte, null), null);
			}
			this.#Bed(this.Options.Section, StyleIdentifier.Heading1, Localization.StringSection);
			if (this.Options.SectionShapeAndProperties.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringShapeAndProperties, this.Options.SectionShapeAndProperties);
				base.#ved(#Ae, new #Rye(#lte, null), null);
			}
			if (options.SectionType == SectionType.Irregular)
			{
				List<SectionPolygon> list = #lte.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnTabularReportDefinition.<>c.<>9.#gcf)).OrderBy(new Func<SectionPolygon, int>(ColumnTabularReportDefinition.<>c.<>9.#hcf)).ToList<SectionPolygon>();
				List<SectionPolygon> list2 = #lte.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ColumnTabularReportDefinition.<>c.<>9.#icf)).OrderBy(new Func<SectionPolygon, int>(ColumnTabularReportDefinition.<>c.<>9.#jcf)).ToList<SectionPolygon>();
				if (this.Model.TestOptions.TestMode)
				{
					SectionPolygon sectionPolygon = list.FirstOrDefault<SectionPolygon>();
					if (this.Options.SectionSolids.#ISd() && sectionPolygon != null)
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringExteriorPoints, this.Options.SectionSolids);
						base.#ved(#Ae, new #Qye(#lte, sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ColumnTabularReportDefinition.<>c.<>9.#kcf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), 1), null);
					}
					SectionPolygon sectionPolygon2 = list2.FirstOrDefault<SectionPolygon>();
					if (this.Options.SectionOpenings.#ISd() && sectionPolygon2 != null)
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringInteriorPoints, this.Options.SectionOpenings);
						base.#ved(#Ae, new #Qye(#lte, sectionPolygon2.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ColumnTabularReportDefinition.<>c.<>9.#lcf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), 1), null);
					}
				}
				else
				{
					if (this.Options.SectionSolids.#ISd())
					{
						this.#Bed(this.Options.SectionSolids, StyleIdentifier.Heading2, Strings.StringSolids);
						for (int i = 0; i < this.Options.SectionSolids.Children.Count; i++)
						{
							Option option = this.Options.SectionSolids.Children[i];
							SectionPolygon sectionPolygon3 = list[i];
							if (option.#ISd())
							{
								#JGd #Ae = base.#zed(StyleIdentifier.Heading3, sectionPolygon3.DisplayId, option);
								base.#ved(#Ae, new #Qye(#lte, sectionPolygon3.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ColumnTabularReportDefinition.<>c.<>9.#mcf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), 1), null);
							}
						}
					}
					if (this.Options.SectionOpenings.#ISd())
					{
						this.#Bed(this.Options.SectionOpenings, StyleIdentifier.Heading2, Strings.StringOpenings);
						for (int j = 0; j < list2.Count; j++)
						{
							Option option2 = this.Options.SectionOpenings.Children[j];
							SectionPolygon sectionPolygon4 = list2[j];
							if (option2.#ISd())
							{
								#JGd #Ae = base.#zed(StyleIdentifier.Heading3, sectionPolygon4.DisplayId, option2);
								base.#ved(#Ae, new #Qye(#lte, sectionPolygon4.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ColumnTabularReportDefinition.<>c.<>9.#ncf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), 1), null);
							}
						}
					}
				}
			}
			this.#Bed(this.Options.Reinforcement, StyleIdentifier.Heading1, Localization.StringReinforcement);
			if (this.Options.ReinforcementBarSet.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringBarSet.#u2d(true) + #yhe.#Gwe(#lte.Input.BarGroupType), this.Options.ReinforcementBarSet);
				base.#ved(#Ae, new #Iye(#lte, 1), null);
			}
			if (this.Options.ReinforcementDesignCriteria.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringDesignCriteria, this.Options.ReinforcementDesignCriteria);
				base.#ved(#Ae, new #Mye(#lte), null);
			}
			if (this.Options.ReinforcementConfinementAndFactors.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringConfinementAndFactors, this.Options.ReinforcementConfinementAndFactors);
				base.#ved(#Ae, new #Lye(#lte), null);
			}
			if (this.Options.ReinforcementProperties.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.Arrangement, this.Options.ReinforcementProperties);
				base.#ved(#Ae, new #Nye(#lte, null, false), ReinforcementPropertiesPage.#bze(#lte));
			}
			if (this.Options.ReinforcementBarsProvided.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringBarsProvided, this.Options.ReinforcementBarsProvided);
				if (activeReinforcement == ReinforcementType.Irregular)
				{
					base.#ved(#Ae, new #Wye(#lte, 1), ReinforcementBarsProvidedPage.#bze(#lte));
				}
				else
				{
					base.#ved(#Ae, new #Kye(#lte), ReinforcementBarsProvidedPage.#bze(#lte));
				}
			}
			if (options.ActiveLoad == LoadType.Service)
			{
				this.#Bed(this.Options.Loading, StyleIdentifier.Heading1, Localization.StringLoading);
				if (this.Model.TestOptions.TestMode)
				{
					if (this.Options.LoadingLoadCombinations.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringLoadCombinations, this.Options.LoadingLoadCombinations);
						base.#ved(#Ae, new LoadingLoadCombinationsTable(#lte), null);
					}
					if (this.Options.LoadingServiceLoads.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringServiceLoads, this.Options.LoadingServiceLoads);
						base.#ved(#Ae, new LoadingServiceLoadsTable(#lte), null);
					}
					if (this.Options.LoadingLoadCases.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringSustainedLoadFactors, this.Options.LoadingLoadCases);
						base.#ved(#Ae, new #zye(#lte), null);
					}
				}
				else
				{
					if (this.Options.LoadingLoadCases.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringLoadCases, this.Options.LoadingLoadCases);
						base.#ved(#Ae, new #yye(#lte), null);
					}
					if (this.Options.LoadingLoadCombinations.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringLoadCombinations, this.Options.LoadingLoadCombinations);
						base.#ved(#Ae, new LoadingLoadCombinationsTable(#lte), null);
					}
					if (this.Options.LoadingServiceLoads.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringServiceLoads, this.Options.LoadingServiceLoads);
						base.#ved(#Ae, new LoadingServiceLoadsTable(#lte), null);
					}
				}
			}
			if (options.ConsiderSlenderness)
			{
				this.#Bed(this.Options.Slenderness, StyleIdentifier.Heading1, Localization.StringSlenderness);
				if (this.Options.SlendernessSwayCriteria.#ISd())
				{
					#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringSwayCriteria, this.Options.SlendernessSwayCriteria);
					base.#ved(#Ae, new #Vye(#lte), null);
				}
				if (this.Options.SlendernessColumns.#ISd())
				{
					#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringColumns, this.Options.SlendernessColumns);
					base.#ved(#Ae, new #Uye(#lte), null);
				}
				for (int k = options.AxisStart; k <= options.AxisEnd; k++)
				{
					ConsideredAxis consideredAxis = (ConsideredAxis)k;
					Option option3 = (consideredAxis == ConsideredAxis.X) ? this.Options.SlendernessXBeams : this.Options.SlendernessYBeams;
					if (option3.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, consideredAxis.ToString() + #Phc.#3hc(107382888) + Localization.StringBeams, option3);
						base.#ved(#Ae, new #Sye(#lte, consideredAxis), null);
					}
				}
				this.#Bed(this.Options.MomentMagnification, StyleIdentifier.Heading1, Localization.StringMomentMagnification);
				if (this.Options.MomentGeneralParameters.#ISd())
				{
					#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringGeneralParameters, this.Options.MomentGeneralParameters);
					base.#ved(#Ae, new #Gye(#lte), null);
				}
				if (this.Options.MomentEffectiveLengthFactors.#ISd())
				{
					#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringEffectiveLengthFactors, this.Options.MomentEffectiveLengthFactors);
					base.#ved(#Ae, new #Eye(#lte), #nze.#bze(#lte));
				}
				if (#lte.Output != null)
				{
					foreach (IGrouping<MomentMagnificationFactor.Axis, MomentMagnificationFactor> grouping in #lte.Output.MomentMagnificationFactors.GroupBy(new Func<MomentMagnificationFactor, MomentMagnificationFactor.Axis>(ColumnTabularReportDefinition.<>c.<>9.#ocf)))
					{
						List<MomentMagnificationFactor> #Zpe = grouping.ToList<MomentMagnificationFactor>();
						Option option4 = (grouping.Key == MomentMagnificationFactor.Axis.X) ? this.Options.MomentMagnificationFactorsX : this.Options.MomentMagnificationFactorsY;
						if (option4.#ISd())
						{
							#JGd #Ae = base.#zed(StyleIdentifier.Heading2, string.Format(Localization.StringMagnificationFactors0Axis, grouping.Key), option4);
							base.#ved(#Ae, new #Fye(#lte, #Zpe), MagnificationFactorsItemsPage.#bze(#lte, #Zpe, grouping.Key));
						}
					}
				}
			}
			if (this.Options.SolverMessages.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Strings.StringSolverMessages, this.Options.SolverMessages);
				base.#ved(#Ae, new SolverMessagesTable(#lte), null);
			}
			if (#lte.Output != null && #lte.Output.MomentMagnificationFactors.Any<MomentMagnificationFactor>() && #lte.Output.FactoredMoments.Any<FactoredMoment>() && this.Options.FactoredMoments.#ISd())
			{
				base.#Aed(this.Options.FactoredMoments, StyleIdentifier.Heading1, Localization.StringFactoredMoments);
				foreach (IGrouping<FactoredMoment.Axis, FactoredMoment> grouping2 in #lte.Output.FactoredMoments.GroupBy(new Func<FactoredMoment, FactoredMoment.Axis>(ColumnTabularReportDefinition.<>c.<>9.#pcf)))
				{
					Option option5 = (grouping2.Key == FactoredMoment.Axis.X) ? this.Options.FactoredMomentsXAxis : this.Options.FactoredMomentsYAxis;
					if (option5.#ISd())
					{
						#JGd #Ae = base.#zed(StyleIdentifier.Heading2, grouping2.Key.ToString() + #Phc.#3hc(107382888) + Localization.StringAxis.ToLower(CultureInfo.CurrentCulture), option5);
						base.#ved(#Ae, new #tye(#lte, grouping2.ToList<FactoredMoment>()), ResultsFactoredMomentsPage.#bze(grouping2.ToList<FactoredMoment>()));
					}
				}
			}
			if (#lte.#ite() && this.Options.ControlPoints.#ISd() && (!this.Model.TestOptions.TestMode || this.Model.TestOptions.OriginalLoadType == LoadType.NoLoads))
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, Localization.StringControlPoints, this.Options.ControlPoints);
				base.#ved(#Ae, new ControlPointsTable(#lte), ControlPointsPage.#bze(#lte));
			}
			if (#lte.#ite() && this.Options.LoadsAndCapacities.#ISd() && options.ActiveLoad == LoadType.Axial && (!this.Model.TestOptions.TestMode || this.Model.TestOptions.OriginalLoadType != LoadType.NoLoads))
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, Localization.StringAxialLoadsAndCorrespondingMomentCapacities, this.Options.LoadsAndCapacities);
				base.#ved(#Ae, new #gye(#lte), null);
			}
			if (this.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios.#ISd() && (options.ActiveLoad == LoadType.Factored || options.ActiveLoad == LoadType.Service) && (!this.Model.TestOptions.TestMode || this.Model.TestOptions.OriginalLoadType != LoadType.NoLoads))
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, Localization.StringFactoredLoadsAndMomentsWithCorrespondingCapacityRatios, this.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios);
				FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable #Xpb = new FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable(#lte);
				base.#ved(#Ae, #Xpb, FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage.#bze(#lte));
			}
		}

		// Token: 0x060028D5 RID: 10453 RVA: 0x000DD834 File Offset: 0x000DBA34
		private void #bye(#lte #Od)
		{
			this.#cye(StyleIdentifier.Heading1, Localization.StringGeneralInformation, this.Options.GeneralInformation);
			this.#cye(StyleIdentifier.Heading2, Localization.StringConcrete, this.Options.MaterialPropertiesConcrete);
			this.#cye(StyleIdentifier.Heading2, Localization.StringSteel, this.Options.MaterialPropertiesSteel);
			this.#cye(StyleIdentifier.Heading1, Localization.StringSection, this.Options.Section);
			this.#cye(StyleIdentifier.Heading2, Localization.StringShapeAndProperties, this.Options.SectionShapeAndProperties);
			this.#cye(StyleIdentifier.Heading2, Strings.StringSolids, this.Options.SectionSolids);
			this.#cye(StyleIdentifier.Heading2, Strings.StringOpenings, this.Options.SectionOpenings);
			this.#cye(StyleIdentifier.Heading1, Localization.StringReinforcement, this.Options.Reinforcement);
			this.#cye(StyleIdentifier.Heading2, Localization.StringBarSet.#u2d(true) + #yhe.#Gwe(#Od.Input.BarGroupType), this.Options.ReinforcementBarSet);
			this.#cye(StyleIdentifier.Heading2, Localization.StringDesignCriteria, this.Options.ReinforcementDesignCriteria);
			this.#cye(StyleIdentifier.Heading2, Localization.StringConfinementAndFactors, this.Options.ReinforcementConfinementAndFactors);
			this.#cye(StyleIdentifier.Heading2, Localization.Arrangement, this.Options.ReinforcementProperties);
			this.#cye(StyleIdentifier.Heading2, Localization.StringBarsProvided, this.Options.ReinforcementBarsProvided);
			this.#cye(StyleIdentifier.Heading1, Localization.StringLoading, this.Options.Loading);
			this.#cye(StyleIdentifier.Heading2, Localization.StringLoadCases, this.Options.LoadingLoadCases);
			this.#cye(StyleIdentifier.Heading2, Localization.StringLoadCombinations, this.Options.LoadingLoadCombinations);
			this.#cye(StyleIdentifier.Heading2, Localization.StringServiceLoads, this.Options.LoadingServiceLoads);
			this.#cye(StyleIdentifier.Heading1, Localization.StringSlenderness, this.Options.Slenderness);
			this.#cye(StyleIdentifier.Heading2, Localization.StringSwayCriteria, this.Options.SlendernessSwayCriteria);
			this.#cye(StyleIdentifier.Heading2, Localization.StringColumns, this.Options.SlendernessColumns);
			this.#cye(StyleIdentifier.Heading2, ConsideredAxis.X.ToString() + #Phc.#3hc(107382888) + Localization.StringBeams, this.Options.SlendernessXBeams);
			this.#cye(StyleIdentifier.Heading2, ConsideredAxis.Y.ToString() + #Phc.#3hc(107382888) + Localization.StringBeams, this.Options.SlendernessYBeams);
			this.#cye(StyleIdentifier.Heading1, Localization.StringMomentMagnification, this.Options.MomentMagnification);
			this.#cye(StyleIdentifier.Heading2, string.Format(Localization.StringMagnificationFactors0Axis, ConsideredAxis.X), this.Options.MomentMagnificationFactorsX);
			this.#cye(StyleIdentifier.Heading2, string.Format(Localization.StringMagnificationFactors0Axis, ConsideredAxis.Y), this.Options.MomentMagnificationFactorsY);
			this.#cye(StyleIdentifier.Heading1, Localization.StringFactoredMoments, this.Options.FactoredMoments);
			this.#cye(StyleIdentifier.Heading2, FactoredMoment.Axis.X.ToString() + #Phc.#3hc(107382888) + Localization.StringAxis.ToLower(CultureInfo.CurrentCulture), this.Options.FactoredMomentsXAxis);
			this.#cye(StyleIdentifier.Heading2, FactoredMoment.Axis.Y.ToString() + #Phc.#3hc(107382888) + Localization.StringAxis.ToLower(CultureInfo.CurrentCulture), this.Options.FactoredMomentsYAxis);
			this.#cye(StyleIdentifier.Heading1, Localization.StringControlPoints, this.Options.ControlPoints);
			this.#cye(StyleIdentifier.Heading1, Localization.StringAxialLoadsAndCorrespondingMomentCapacities, this.Options.LoadsAndCapacities);
			this.#cye(StyleIdentifier.Heading1, Localization.StringFactoredLoadsAndMomentsWithCorrespondingCapacityRatios, this.Options.FactoredLoadsAndMomentsWithCorrespondingCapacityRatios);
		}

		// Token: 0x060028D6 RID: 10454 RVA: 0x000DDBC8 File Offset: 0x000DBDC8
		private void #cye(StyleIdentifier #4cd, string #Ukc, Option #bA)
		{
			#JGd #JGd = this.#b.#KGd(#4cd, #Ukc);
			#JGd.Option = #bA;
			this.#a.Add(#JGd);
		}

		// Token: 0x04001036 RID: 4150
		private readonly List<#JGd> #a = new List<#JGd>();

		// Token: 0x04001037 RID: 4151
		private readonly SectionHeaderHandler #b = new SectionHeaderHandler();

		// Token: 0x04001038 RID: 4152
		[CompilerGenerated]
		private readonly #uwe #c;

		// Token: 0x04001039 RID: 4153
		[CompilerGenerated]
		private readonly #lte #d;
	}
}

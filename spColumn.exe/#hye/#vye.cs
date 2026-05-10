using System;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011A5 RID: 4517
	internal sealed class #vye : #qwe
	{
		// Token: 0x0600992A RID: 39210 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #vye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x0600992B RID: 39211 RVA: 0x002055C4 File Offset: 0x002037C4
		public override void #npb(#6Dd #opb)
		{
			ProjectInfo projectInfo = base.Model.Input.ProjectInfo;
			Options options = base.Model.Input.Options;
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				100.0,
				130.0
			}))
			{
				#2dd.#Vdd(#5Dd);
				#5Dd.#VDd(ParagraphAlignment.Left, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Localization.StringFileName,
					LayoutHelper.CompactPath(base.Model.GeneralInfo.FileName, 50)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringProject,
					string.IsNullOrWhiteSpace(projectInfo.Project) ? #Phc.#3hc(107361293) : projectInfo.Project
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringColumn,
					string.IsNullOrWhiteSpace(projectInfo.ColumnId) ? #Phc.#3hc(107361293) : projectInfo.ColumnId
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringEngineer,
					string.IsNullOrWhiteSpace(projectInfo.Engineer) ? #Phc.#3hc(107361293) : projectInfo.Engineer
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCode,
					#yhe.#Pwe(options.Code)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringBarSet,
					#yhe.#Gwe(base.Model.Input.BarGroupType)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringUnits,
					#yhe.#Owe(options.Unit)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRunOption,
					#yhe.#Nwe(options.ProblemType)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRunAxis,
					#yhe.#Mwe(options.ConsideredAxis)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringSlenderness,
					options.ConsiderSlenderness ? Localization.StringConsidered : Localization.StringNotConsidered
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringColumnType,
					#yhe.#Jwe(options, base.Model.Output)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCapacityMethod,
					#yhe.#Lwe(options.SectionCapacityMethod)
				});
			}
		}
	}
}

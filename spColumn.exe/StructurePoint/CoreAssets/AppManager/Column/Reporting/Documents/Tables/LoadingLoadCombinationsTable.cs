using System;
using System.Linq;
using #7hc;
using #FCd;
using #owe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011A8 RID: 4520
	internal sealed class LoadingLoadCombinationsTable : #qwe
	{
		// Token: 0x06009932 RID: 39218 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public LoadingLoadCombinationsTable(#lte model) : base(model)
		{
		}

		// Token: 0x06009933 RID: 39219 RVA: 0x002059A0 File Offset: 0x00203BA0
		public override void #npb(#6Dd #opb)
		{
			double[] #Zpb = Enumerable.Range(1, 6).Select(new Func<int, double>(LoadingLoadCombinationsTable.<>c.<>9.#qcf)).ToArray<double>();
			using (#5Dd #5Dd = #opb.#ul(1, #Zpb))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Localization.StringCombination,
					Localization.StringDead,
					Localization.StringLive,
					Localization.StringWind,
					Localization.StringEQ,
					Localization.StringSnow
				});
				int num = 1;
				foreach (LoadFactor loadFactor in base.Model.Input.LoadFactors)
				{
					#5Dd.#ODd(new string[]
					{
						string.Format(#Phc.#3hc(107286094), num++)
					});
					#5Dd.#ODd(new string[]
					{
						#ned.#qp(new float?(loadFactor.Dead), NativeNumberFormat.F10_3, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						#ned.#qp(new float?(loadFactor.Live), NativeNumberFormat.F10_3, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						#ned.#qp(new float?(loadFactor.Wind), NativeNumberFormat.F10_3, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						#ned.#qp(new float?(loadFactor.Earthquake), NativeNumberFormat.F10_3, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						#ned.#qp(new float?(loadFactor.Snow), NativeNumberFormat.F10_3, #Phc.#3hc(107381628))
					});
				}
			}
		}
	}
}

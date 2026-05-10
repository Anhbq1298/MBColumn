using System;
using #12e;
using #7hc;
using #FCd;
using #hZe;
using #owe;
using #wdd;
using #Wse;
using Aspose.Words;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011B4 RID: 4532
	internal sealed class #Kye : #qwe
	{
		// Token: 0x0600994F RID: 39247 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Kye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06009950 RID: 39248 RVA: 0x00207798 File Offset: 0x00205998
		public override void #npb(#6Dd #opb)
		{
			ColumnStorageModel columnStorageModel = base.Model.Input;
			Options options = base.Model.Input.Options;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#l4e #l4e = base.Model.Output;
			#A0e #A0e = (#l4e != null) ? #l4e.InvestigationReinforcement : null;
			if (options.ActiveReinforcement == ReinforcementType.Different && #A0e != null)
			{
				using (#5Dd #5Dd = #opb.#ul(2, new double[]
				{
					30.0,
					10.0,
					30.0,
					30.0
				}))
				{
					#5Dd.#TDd(1);
					#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
					#5Dd.#VDd(ParagraphAlignment.Left, new int[1]);
					#5Dd.TableAlignment = TableAlignment.Left;
					#5Dd.#ODd(new string[]
					{
						string.Empty,
						string.Empty,
						Localization.StringBars,
						Localization.StringClearCover
					});
					#5Dd.#ODd(new string[]
					{
						string.Empty,
						string.Empty,
						string.Empty,
						generalInformation.UnitStringD
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringTop,
						#A0e.AmountOfBars[0].ToString(),
						#Phc.#3hc(107378801) + columnStorageModel.GetBarSize(#A0e.BarNumber[0]).ToString(),
						#ned.#qp(new float?(#A0e.ClearCover[0]), NativeNumberFormat.G, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringBottom,
						#A0e.AmountOfBars[1].ToString(),
						#Phc.#3hc(107378801) + columnStorageModel.GetBarSize(#A0e.BarNumber[1]).ToString(),
						#ned.#qp(new float?(#A0e.ClearCover[1]), NativeNumberFormat.G, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringLeft,
						#A0e.AmountOfBars[2].ToString(),
						#Phc.#3hc(107378801) + columnStorageModel.GetBarSize(#A0e.BarNumber[2]).ToString(),
						#ned.#qp(new float?(#A0e.ClearCover[2]), NativeNumberFormat.G, #Phc.#3hc(107381628))
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringRight,
						#A0e.AmountOfBars[3].ToString(),
						#Phc.#3hc(107378801) + columnStorageModel.GetBarSize(#A0e.BarNumber[3]).ToString(),
						#ned.#qp(new float?(#A0e.ClearCover[3]), NativeNumberFormat.G, #Phc.#3hc(107381628))
					});
					#5Dd.PreferredWidth = 50f;
				}
			}
		}
	}
}

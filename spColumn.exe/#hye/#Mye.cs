using System;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011B6 RID: 4534
	internal sealed class #Mye : #qwe
	{
		// Token: 0x06009953 RID: 39251 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Mye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06009954 RID: 39252 RVA: 0x00207DD4 File Offset: 0x00205FD4
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			ReinforcementRatios reinforcementRatios = base.Model.Input.ReinforcementRatios;
			string text = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				140.0,
				#2dd.PropertiesDataColumnWidth,
				#2dd.PropertiesUnitColumnWidth
			}))
			{
				#2dd.#Vdd(#5Dd);
				#5Dd.#ODd(new string[]
				{
					Localization.StringBarSelection,
					#yhe.#ume(base.Model.Input.Options.DesignTarget),
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.AsMin + #Phc.#3hc(107286080) + #Yxe.Ag,
					#ned.#qp(base.Model.AsMin, NativeNumberFormat.G, #Phc.#3hc(107381628)),
					text
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.AsMax + #Phc.#3hc(107286063) + #Yxe.Ag,
					#ned.#qp(base.Model.AsMax, NativeNumberFormat.G, #Phc.#3hc(107381628)),
					text
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringAllowableCapacityRatioLesserThanOneIsSafe,
					#ned.#qp(new float?(base.Model.Input.DesignToRequiredRatio), NativeNumberFormat.F12_2, #Phc.#3hc(107381628)),
					string.Empty
				});
			}
		}
	}
}

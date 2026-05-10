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
	// Token: 0x020011AE RID: 4526
	internal sealed class #Aye : #qwe
	{
		// Token: 0x06009940 RID: 39232 RVA: 0x00079D21 File Offset: 0x00077F21
		public #Aye(#lte #Od, double[] #Zpb = null) : base(#Od)
		{
			this.#a = #Zpb;
		}

		// Token: 0x06009941 RID: 39233 RVA: 0x00206730 File Offset: 0x00204930
		public override void #npb(#6Dd #opb)
		{
			MaterialProperties materialProperties = base.Model.Input.MaterialProperties;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			using (#5Dd #5Dd = #opb.#Xdd(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					Localization.StringType,
					materialProperties.IsConcreteStandard ? Localization.StringStandard : Localization.StringUserDefined,
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.FPrimC,
					#ned.#qp(new float?(materialProperties.Fcp), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Ec,
					#ned.#qp(new float?(materialProperties.Ec), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Fc,
					#ned.#qp(new float?(materialProperties.Fc), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.EpsU,
					#ned.#qp(new float?(materialProperties.Eps), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringD + #Phc.#3hc(107224088) + generalInformation.UnitStringD
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Beta1,
					#ned.#qp(new float?(materialProperties.Beta1), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					string.Empty
				});
			}
		}

		// Token: 0x040041CC RID: 16844
		private readonly double[] #a;
	}
}

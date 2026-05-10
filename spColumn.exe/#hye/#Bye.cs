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
	// Token: 0x020011AF RID: 4527
	internal sealed class #Bye : #qwe
	{
		// Token: 0x06009942 RID: 39234 RVA: 0x00079D31 File Offset: 0x00077F31
		public #Bye(#lte #Od, double[] #Zpb = null) : base(#Od)
		{
			this.#a = #Zpb;
		}

		// Token: 0x06009943 RID: 39235 RVA: 0x00206904 File Offset: 0x00204B04
		public override void #npb(#6Dd #opb)
		{
			MaterialProperties materialProperties = base.Model.Input.MaterialProperties;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			using (#5Dd #5Dd = #opb.#Xdd(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					Localization.StringType,
					materialProperties.IsSteelStandard ? Localization.StringStandard : Localization.StringUserDefined,
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Fy,
					#ned.#qp(new float?(materialProperties.Fy), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Es,
					#ned.#qp(new float?(materialProperties.Es), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.EpsTy,
					#ned.#qp(new float?(materialProperties.Eyt), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringD + #Phc.#3hc(107224088) + generalInformation.UnitStringD
				});
			}
		}

		// Token: 0x040041CD RID: 16845
		private readonly double[] #a;
	}
}

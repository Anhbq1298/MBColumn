using System;
using #7hc;
using #FCd;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #kve
{
	// Token: 0x02001182 RID: 4482
	internal sealed class #lve : #qwe
	{
		// Token: 0x06009808 RID: 38920 RVA: 0x00078C40 File Offset: 0x00076E40
		public #lve(#lte #Od, double #6dd) : base(#Od)
		{
			this.#a = #6dd;
		}

		// Token: 0x06009809 RID: 38921 RVA: 0x002006C8 File Offset: 0x001FE8C8
		public override void #npb(#6Dd #opb)
		{
			MaterialProperties materialProperties = base.Model.Input.MaterialProperties;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			using (#5Dd #5Dd = #opb.#Ive(this.#a))
			{
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
				#5Dd.#PDd();
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
				#5Dd.PreferredWidth = (float)this.#a;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}

		// Token: 0x04004163 RID: 16739
		private readonly double #a;
	}
}

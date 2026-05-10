using System;
using #12e;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace #qpb
{
	// Token: 0x02000468 RID: 1128
	internal sealed class #0pb : #qwe
	{
		// Token: 0x06002964 RID: 10596 RVA: 0x00025ECB File Offset: 0x000240CB
		public #0pb(#lte #Od, double[] #Zpb = null) : base(#Od)
		{
			this.#a = #Zpb;
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x000DF50C File Offset: 0x000DD70C
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			NativeNumberFormat #cA = (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_2 : NativeNumberFormat.F10_0;
			#l4e #l4e = base.Model.Output;
			string text = (#l4e != null) ? #l4e.CapacityData.OverallCapacity : null;
			string text2 = (!string.IsNullOrWhiteSpace(text)) ? text : #Phc.#3hc(107361293);
			using (#5Dd #5Dd = #opb.#Xdd(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					#Yxe.FPrimC,
					#ned.#qp(new float?(base.Model.Input.MaterialProperties.Fcp), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Fy,
					#ned.#qp(new float?(base.Model.Input.MaterialProperties.Fy), NativeNumberFormat.G, #Phc.#3hc(107381628)),
					generalInformation.UnitStringS
				});
				#5Dd #5Dd2 = #5Dd;
				string[] array = new string[3];
				array[0] = Strings.StringGrossArea;
				int num = 1;
				#l4e #l4e2 = base.Model.Output;
				array[num] = #ned.#qp((#l4e2 != null) ? new float?(#l4e2.Variables.SectionPropAg) : null, NativeNumberFormat.G, #Phc.#3hc(107361293));
				array[2] = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
				#5Dd2.#ODd(array);
				#5Dd #5Dd3 = #5Dd;
				string[] array2 = new string[3];
				array2[0] = Strings.StringTotal + #Phc.#3hc(107399922) + #Yxe.As;
				int num2 = 1;
				#l4e #l4e3 = base.Model.Output;
				array2[num2] = #ned.#qp((#l4e3 != null) ? #l4e3.Variables.SectionPropTotalSteelArea : null, #cA, #Phc.#3hc(107361293));
				array2[2] = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
				#5Dd3.#ODd(array2);
				#5Dd #5Dd4 = #5Dd;
				string[] array3 = new string[3];
				array3[0] = Strings.StringRho;
				int num3 = 1;
				#l4e #l4e4 = base.Model.Output;
				array3[num3] = #ned.#qp((#l4e4 != null) ? #l4e4.Variables.SectionPropRho : null, NativeNumberFormat.F10_2, #Phc.#3hc(107361293));
				array3[2] = #Phc.#3hc(107360069);
				#5Dd4.#ODd(array3);
				#5Dd.#ODd(new string[]
				{
					Strings.StringMaxCapacityRatio,
					text2,
					string.Empty
				});
			}
		}

		// Token: 0x0400108A RID: 4234
		private readonly double[] #a;
	}
}

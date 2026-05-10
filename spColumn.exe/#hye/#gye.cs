using System;
using #12e;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Units;

namespace #hye
{
	// Token: 0x0200119E RID: 4510
	internal sealed class #gye : #qwe
	{
		// Token: 0x0600990A RID: 39178 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #gye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x0600990B RID: 39179 RVA: 0x00203734 File Offset: 0x00201934
		public override void #npb(#6Dd #opb)
		{
			Options options = base.Model.Input.Options;
			using (#5Dd #5Dd = #opb.#ul(2, this.#fye()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				this.#Ppb(#5Dd);
				NativeNumberFormat #cA = (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F8_3 : NativeNumberFormat.F8_0;
				float? num = null;
				int num2 = 1;
				foreach (#Jce #Jce in base.Model.Output.AxialLoads)
				{
					#5Dd.#QDd(new int?(num2++));
					#5Dd #5Dd2 = #5Dd;
					string[] array = new string[1];
					int num3 = 0;
					float? num4 = #Jce.P;
					array[num3] = #ned.#qp((num4 != null) ? num4 : num, NativeNumberFormat.F12_1, #Phc.#3hc(107381628));
					#5Dd2.#QDd(array);
					num = #Jce.P;
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#Jce.Rm), NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#Jce.C), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#Jce.Dt), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(#Jce.Eps), NativeNumberFormat.F8_5, #Phc.#3hc(107381628))
					});
					if (options.IsACI())
					{
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(#Jce.Phi, NativeNumberFormat.F6_3, #Phc.#3hc(107381628))
						});
					}
				}
			}
		}

		// Token: 0x0600990C RID: 39180 RVA: 0x00203938 File Offset: 0x00201B38
		private void #Ppb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			if (options.IsACI())
			{
				#Ipb.#ODd(new string[]
				{
					Localization.StringNo,
					#Yxe.PhiPn,
					#Yxe.#Xxe(options.ConsideredAxis.ToString()),
					Localization.StringNADepth,
					#Yxe.DtDepth,
					#Yxe.EpsT,
					#Yxe.Phi
				});
				#Ipb.#ODd(new string[]
				{
					string.Empty,
					generalInformation.UnitStringF,
					generalInformation.UnitStringM,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD,
					string.Empty,
					string.Empty
				});
				return;
			}
			#Ipb.#ODd(new string[]
			{
				Localization.StringNo,
				#Yxe.PhiPn,
				#Yxe.#Xxe(options.ConsideredAxis.ToString()),
				Localization.StringNADepth,
				#Yxe.DtDepth,
				#Yxe.EpsS
			});
			#Ipb.#ODd(new string[]
			{
				string.Empty,
				generalInformation.UnitStringF,
				generalInformation.UnitStringM,
				generalInformation.UnitStringD,
				generalInformation.UnitStringD,
				string.Empty
			});
		}

		// Token: 0x0600990D RID: 39181 RVA: 0x00203AA0 File Offset: 0x00201CA0
		private double[] #fye()
		{
			return (base.Model.Input.Options.IsACI() ? new #aed(new double[]
			{
				4.0,
				12.0,
				12.0,
				8.0,
				8.0,
				8.0,
				6.0
			}) : new #aed(new double[]
			{
				4.0,
				12.0,
				12.0,
				8.0,
				8.0,
				8.0
			})).#7dd();
		}
	}
}

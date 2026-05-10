using System;
using System.Collections.Generic;
using System.Globalization;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011B1 RID: 4529
	internal sealed class #Fye : #qwe
	{
		// Token: 0x06009948 RID: 39240 RVA: 0x00079D52 File Offset: 0x00077F52
		public #Fye(#lte #Od, IList<MomentMagnificationFactor> #Zpe) : base(#Od)
		{
			this.#a = #Zpe;
		}

		// Token: 0x06009949 RID: 39241 RVA: 0x00206CAC File Offset: 0x00204EAC
		public override void #npb(#6Dd #opb)
		{
			#aed #aed = new #aed(new double[]
			{
				3.0,
				4.0,
				10.0,
				10.0,
				10.0,
				7.0,
				7.0,
				10.0,
				6.0,
				10.0,
				6.0,
				6.0,
				6.0,
				2.0
			});
			using (#5Dd #5Dd = #opb.#ul(3, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Center, Array.Empty<int>());
				#5Dd.#Fhd(2, new string[]
				{
					Localization.StringLoad
				});
				#5Dd.#Fhd(5, ParagraphAlignment.Center, new string[]
				{
					Localization.StringAtEnds
				});
				#5Dd.#Fhd(6, ParagraphAlignment.Center, new string[]
				{
					Localization.StringAlongLength
				});
				#5Dd.#QDd(new string[]
				{
					string.Empty
				});
				string text = base.Model.GeneralInfo.UnitStringF;
				#5Dd.#Fhd(2, new string[]
				{
					Localization.StringCombo
				});
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				if (base.Model.Input.Options.IsACI())
				{
					#5Dd.#ODd(new string[]
					{
						#Yxe.SumPu,
						#Yxe.Pc,
						#Yxe.SumPc,
						#Yxe.BetaDs,
						#Yxe.DeltaSLowerCase,
						#Yxe.Pu,
						#Yxe.KPrimlur,
						#Yxe.Pc,
						#Yxe.BetaDns,
						#Yxe.Cm,
						#Yxe.DeltaLowerCase,
						string.Empty
					});
				}
				else
				{
					#5Dd.#ODd(new string[]
					{
						#Yxe.SumPf,
						#Yxe.Pc,
						#Yxe.SumPc,
						#Yxe.BetaDs,
						#Yxe.DeltaSLowerCase,
						#Yxe.Pf,
						#Yxe.KPrimlur,
						#Yxe.Pc,
						#Yxe.BetaDns,
						#Yxe.Cm,
						#Yxe.DeltaLowerCase,
						string.Empty
					});
				}
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					text,
					text,
					text,
					string.Empty,
					string.Empty,
					text,
					string.Empty,
					text,
					string.Empty,
					string.Empty,
					string.Empty,
					string.Empty
				});
				foreach (MomentMagnificationFactor momentMagnificationFactor in this.#a)
				{
					#5Dd.#QDd(new int?(momentMagnificationFactor.Load));
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107360079),
						momentMagnificationFactor.Combination.ToString(CultureInfo.InvariantCulture)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.SumPu, NativeNumberFormat.F10_2)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.Pc, NativeNumberFormat.F10_2, 10000000f, NativeNumberFormat.F10_1)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.SumPc, NativeNumberFormat.F10_2, 10000000f, NativeNumberFormat.F10_1)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.BetaDs, NativeNumberFormat.F6_3)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.DeltaS, NativeNumberFormat.F6_3)
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(momentMagnificationFactor.Pu), NativeNumberFormat.F10_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.KluR, NativeNumberFormat.F6_2)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.PcLength, NativeNumberFormat.F10_2)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.BetaD, NativeNumberFormat.F6_3)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.Cm, NativeNumberFormat.F6_3)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(momentMagnificationFactor.Delta, NativeNumberFormat.F6_3)
					});
					#5Dd.#QDd(new string[]
					{
						momentMagnificationFactor.#Y3e().Trim()
					});
				}
				#5Dd.#WDd(#2dd.#d, new int[]
				{
					1,
					6
				});
			}
		}

		// Token: 0x040041CF RID: 16847
		private readonly IList<MomentMagnificationFactor> #a;
	}
}

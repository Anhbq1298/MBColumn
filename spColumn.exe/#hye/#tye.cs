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
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #hye
{
	// Token: 0x020011A4 RID: 4516
	internal sealed class #tye : #qwe
	{
		// Token: 0x06009928 RID: 39208 RVA: 0x00079CC1 File Offset: 0x00077EC1
		public #tye(#lte #Od, IList<FactoredMoment> #uye) : base(#Od)
		{
			this.#a = #uye;
		}

		// Token: 0x06009929 RID: 39209 RVA: 0x0020515C File Offset: 0x0020335C
		public override void #npb(#6Dd #opb)
		{
			#aed #aed = new #aed(new double[]
			{
				3.0,
				3.0,
				3.0,
				12.0,
				12.0,
				12.0,
				12.0,
				4.0,
				12.0,
				12.0,
				9.0,
				3.0
			});
			using (#5Dd #5Dd = #opb.#ul(3, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#Fhd(3, new string[]
				{
					Localization.StringLoad
				});
				#5Dd.#VDd(ParagraphAlignment.Center, Array.Empty<int>());
				#5Dd.#Fhd(3, ParagraphAlignment.Center, new string[]
				{
					#Yxe.First,
					string.Empty.#O2d(),
					Localization.StringOrder
				});
				#5Dd.#QDd(new string[]
				{
					string.Empty
				});
				#5Dd.#Fhd(3, ParagraphAlignment.Center, new string[]
				{
					#Yxe.Second,
					string.Empty.#O2d(),
					Localization.StringOrder
				});
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#QDd(new string[]
				{
					Localization.StringRatio
				});
				#5Dd.#QDd(new string[]
				{
					string.Empty
				});
				#5Dd.#RDd(true, new int[]
				{
					7
				});
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				string text = base.Model.GeneralInfo.UnitStringM;
				#5Dd.#Fhd(3, new string[]
				{
					Localization.StringCombo
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Mns,
					#Yxe.Ms,
					base.Model.Input.Options.IsCSA() ? #Yxe.Mf : #Yxe.Mu,
					#Yxe.Mmin
				});
				#5Dd.#QDd(new string[]
				{
					string.Empty
				});
				#5Dd.#Fhd(1, ParagraphAlignment.Right, new string[]
				{
					#Yxe.Mi
				});
				#5Dd.#ODd(new string[]
				{
					#Yxe.Mc,
					#Yxe.Second + #Phc.#3hc(107224088) + #Yxe.First,
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					string.Empty,
					text,
					text,
					text,
					text,
					string.Empty,
					text,
					text,
					string.Empty,
					string.Empty
				});
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				for (int i = 0; i < this.#a.Count; i++)
				{
					FactoredMoment factoredMoment = this.#a[i];
					#5Dd.#QDd(factoredMoment.Load);
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107360079),
						factoredMoment.Combination.ToString()
					});
					#5Dd.#jDd(factoredMoment.MomentSide == FactoredMoment.#vif.#a, #Phc.#3hc(107280502), #Phc.#3hc(107286131));
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(factoredMoment.Mns, NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(factoredMoment.Ms, NativeNumberFormat.F12_2)
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(factoredMoment.Mu, NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(factoredMoment.MMin, NativeNumberFormat.F12_2)
					});
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107359889),
						#6xe.#5xe(factoredMoment.MiIndex.GetValueOrDefault(0).ToString(CultureInfo.InvariantCulture)),
						#Phc.#3hc(107224197)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(factoredMoment.Mi, NativeNumberFormat.F12_2)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(factoredMoment.Mc, NativeNumberFormat.F12_2)
					});
					#5Dd.#QDd(new string[]
					{
						base.#qp(factoredMoment.Ratio, NativeNumberFormat.F9_3)
					});
					#5Dd.#ODd(new string[]
					{
						factoredMoment.#q3e().Trim()
					});
				}
				#5Dd.#WDd(#2dd.#f, new int[]
				{
					2,
					5,
					6,
					9
				});
			}
		}

		// Token: 0x040041C3 RID: 16835
		private readonly IList<FactoredMoment> #a;
	}
}

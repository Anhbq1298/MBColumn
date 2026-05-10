using System;
using #7hc;
using #FCd;
using #owe;
using #Qcd;
using #wdd;
using #Wse;
using Aspose.Words;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011AD RID: 4525
	internal sealed class #zye : #qwe
	{
		// Token: 0x0600993E RID: 39230 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #zye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x0600993F RID: 39231 RVA: 0x00206510 File Offset: 0x00204710
		public override void #npb(#6Dd #opb)
		{
			using (#5Dd #5Dd = #opb.#ul(2, new double[]
			{
				55.0,
				55.0
			}))
			{
				#5Dd.#XDd(#rdd.#b, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Right, new int[]
				{
					1
				});
				#5Dd.#VDd(ParagraphAlignment.Left, new int[1]);
				#5Dd.TableAlignment = TableAlignment.Left;
				#5Dd.#ODd(new string[]
				{
					Localization.StringLoadCase,
					Localization.StringFactor
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					#Phc.#3hc(107360069)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringDead,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Dead), NativeNumberFormat.F10_0, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringLive,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Live), NativeNumberFormat.F10_0, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringWind,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Wind), NativeNumberFormat.F10_0, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringEQ,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Earthquake), NativeNumberFormat.F10_0, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringSnow,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Snow), NativeNumberFormat.F10_0, #Phc.#3hc(107381628))
				});
				#5Dd.PreferredWidth = 110f;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}
	}
}

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
	// Token: 0x020011AC RID: 4524
	internal sealed class #yye : #qwe
	{
		// Token: 0x0600993C RID: 39228 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #yye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x0600993D RID: 39229 RVA: 0x00206294 File Offset: 0x00204494
		public override void #npb(#6Dd #opb)
		{
			using (#5Dd #5Dd = #opb.#ul(2, new double[]
			{
				55.0,
				55.0,
				100.0
			}))
			{
				#5Dd.#XDd(#rdd.#b, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Right, new int[]
				{
					2
				});
				#5Dd.#VDd(ParagraphAlignment.Right, new int[]
				{
					1
				});
				#5Dd.#VDd(ParagraphAlignment.Left, new int[1]);
				#5Dd.TableAlignment = TableAlignment.Left;
				#5Dd.#ODd(new string[]
				{
					Localization.StringCase,
					Localization.StringType,
					Localization.StringSustainedLoad
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					#Phc.#3hc(107360069)
				});
				#5Dd.#ODd(new string[]
				{
					#Phc.#3hc(107408119),
					Localization.StringDead,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Dead), NativeNumberFormat.G, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					#Phc.#3hc(107408114),
					Localization.StringLive,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Live), NativeNumberFormat.G, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					#Phc.#3hc(107408077),
					Localization.StringWind,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Wind), NativeNumberFormat.G, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					#Phc.#3hc(107395517),
					Localization.StringEQ,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Earthquake), NativeNumberFormat.G, #Phc.#3hc(107381628))
				});
				#5Dd.#ODd(new string[]
				{
					#Phc.#3hc(107386851),
					Localization.StringSnow,
					#ned.#qp(new float?(base.Model.Input.SustainedLoadFactors.Snow), NativeNumberFormat.G, #Phc.#3hc(107381628))
				});
				#5Dd.PreferredWidth = 210f;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace #hye
{
	// Token: 0x020011B3 RID: 4531
	internal sealed class #Iye : #qwe
	{
		// Token: 0x0600994C RID: 39244 RVA: 0x00079D62 File Offset: 0x00077F62
		public #Iye(#lte #Od, int #Jye = 3) : base(#Od)
		{
			this.SplitIntoColumns = #Jye;
		}

		// Token: 0x17002CA4 RID: 11428
		// (get) Token: 0x0600994D RID: 39245 RVA: 0x00079D72 File Offset: 0x00077F72
		public int SplitIntoColumns { get; }

		// Token: 0x0600994E RID: 39246 RVA: 0x00207558 File Offset: 0x00205758
		public override void #npb(#6Dd #opb)
		{
			List<StandardBar> bars = base.Model.Input.Bars;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#aed #aed = new #aed(new double[]
			{
				1.0,
				1.0,
				1.0
			});
			double[] #Zpb = #aed.#7dd(this.SplitIntoColumns);
			NativeNumberFormat #cA = NativeNumberFormat.F10_2;
			string text = generalInformation.UnitStringD;
			string text2 = generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
			using (#5Dd #5Dd = #opb.#ul(2, #Zpb))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				for (int i = 0; i < this.SplitIntoColumns; i++)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringBar,
						Localization.StringDiameter,
						Localization.StringArea
					});
				}
				for (int j = 0; j < this.SplitIntoColumns; j++)
				{
					#5Dd.#ODd(new string[]
					{
						string.Empty,
						text,
						text2
					});
				}
				foreach (StandardBar standardBar in bars.Take(base.Model.Input.Bars.Count))
				{
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107378801) + standardBar.Size.ToString()
					});
					double value = Math.Round((double)standardBar.Diameter, 3);
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new double?(value), #cA)
					});
					double value2 = Math.Round((double)standardBar.Area, 3);
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new double?(value2), #cA)
					});
				}
				#5Dd.#WDd(#2dd.#d, #aed.#9dd(this.SplitIntoColumns));
				#5Dd.PreferredWidth = 33.333332f * (float)this.SplitIntoColumns;
			}
		}

		// Token: 0x040041D0 RID: 16848
		private const int #a = 3;

		// Token: 0x040041D1 RID: 16849
		[CompilerGenerated]
		private readonly int #b;
	}
}

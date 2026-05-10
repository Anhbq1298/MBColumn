using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #FCd;
using #owe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Units;

namespace #hye
{
	// Token: 0x020011B8 RID: 4536
	internal sealed class #Qye : #qwe
	{
		// Token: 0x06009957 RID: 39255 RVA: 0x00079D91 File Offset: 0x00077F91
		public #Qye(#lte #Od, IReadOnlyList<Point> #BP, int #Jye = 3) : base(#Od)
		{
			this.#b = #BP;
			this.SplitIntoColumns = #Jye;
		}

		// Token: 0x17002CA5 RID: 11429
		// (get) Token: 0x06009958 RID: 39256 RVA: 0x00079DA8 File Offset: 0x00077FA8
		// (set) Token: 0x06009959 RID: 39257 RVA: 0x00079DB0 File Offset: 0x00077FB0
		public int SplitIntoColumns { get; set; }

		// Token: 0x0600995A RID: 39258 RVA: 0x002083B4 File Offset: 0x002065B4
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#aed #aed = new #aed(new double[]
			{
				8.0,
				15.0,
				15.0
			});
			NativeNumberFormat #cA = (base.Model.Input.Options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_1 : NativeNumberFormat.F10_1;
			double[] #Zpb = #aed.#7dd(this.SplitIntoColumns);
			using (#5Dd #5Dd = #opb.#ul(2, #Zpb))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				for (int i = 0; i < this.SplitIntoColumns; i++)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringPoints,
						#Phc.#3hc(107408964),
						#Phc.#3hc(107408991)
					});
				}
				for (int j = 0; j < this.SplitIntoColumns; j++)
				{
					#5Dd.#ODd(new string[]
					{
						string.Empty,
						generalInformation.UnitStringD,
						generalInformation.UnitStringD
					});
				}
				if (this.#b != null)
				{
					int num = 1;
					for (int k = 0; k < this.#b.Count - 1; k++)
					{
						Point point = this.#b[k];
						#5Dd.#ODd(new string[]
						{
							num.ToString(CultureInfo.CurrentCulture),
							#ned.#qp(new float?(point.X), #cA, #Phc.#3hc(107381628)),
							#ned.#qp(new float?(point.Y), #cA, #Phc.#3hc(107381628))
						});
						num++;
					}
				}
				#5Dd.#WDd(#2dd.#d, #aed.#9dd(this.SplitIntoColumns));
				#5Dd.PreferredWidth = 33.333332f * (float)this.SplitIntoColumns;
			}
		}

		// Token: 0x040041D4 RID: 16852
		private const int #a = 3;

		// Token: 0x040041D5 RID: 16853
		private readonly IReadOnlyList<Point> #b;

		// Token: 0x040041D6 RID: 16854
		[CompilerGenerated]
		private int #c;
	}
}

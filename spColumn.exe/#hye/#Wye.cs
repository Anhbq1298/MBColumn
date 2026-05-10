using System;
using System.Runtime.CompilerServices;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using #y6e;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Units;

namespace #hye
{
	// Token: 0x020011BF RID: 4543
	internal sealed class #Wye : #qwe
	{
		// Token: 0x06009968 RID: 39272 RVA: 0x00079DEC File Offset: 0x00077FEC
		public #Wye(#lte #Od, int #Jye = 3) : base(#Od)
		{
			this.SplitIntoColumns = #Jye;
		}

		// Token: 0x17002CA6 RID: 11430
		// (get) Token: 0x06009969 RID: 39273 RVA: 0x00079DFC File Offset: 0x00077FFC
		public int SplitIntoColumns { get; }

		// Token: 0x0600996A RID: 39274 RVA: 0x00209740 File Offset: 0x00207940
		public override void #npb(#6Dd #opb)
		{
			if (base.Model.Input.Options.ActiveReinforcement != ReinforcementType.Irregular)
			{
				return;
			}
			#aed #aed = new #aed(new double[]
			{
				30.0,
				30.0,
				30.0,
				10.0
			});
			string text = base.Model.GeneralInfo.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074));
			string text2 = base.Model.GeneralInfo.UnitStringD;
			NativeNumberFormat #cA = (base.Model.Input.Options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_1 : NativeNumberFormat.F10_1;
			using (#5Dd #5Dd = #opb.#ul(2, #aed.#7dd(this.SplitIntoColumns)))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				for (int i = 0; i < this.SplitIntoColumns; i++)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringArea,
						#Phc.#3hc(107408964),
						#Phc.#3hc(107408991),
						string.Empty
					});
				}
				for (int j = 0; j < this.SplitIntoColumns; j++)
				{
					#5Dd.#ODd(new string[]
					{
						text,
						text2,
						text2,
						string.Empty
					});
				}
				foreach (ReinforcementBar reinforcementBar in base.Model.BasicProperties.Bars)
				{
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(reinforcementBar.Area), (base.Model.Input.Options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F10_2 : NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(reinforcementBar.X), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(reinforcementBar.Y), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						(reinforcementBar.Location == #I6e.#b) ? #Phc.#3hc(107425009) : string.Empty
					});
				}
				#5Dd.#WDd(#2dd.#d, #aed.#9dd(this.SplitIntoColumns));
				#5Dd.PreferredWidth = 33.333332f * (float)this.SplitIntoColumns;
			}
		}

		// Token: 0x040041DB RID: 16859
		private const int #a = 3;

		// Token: 0x040041DC RID: 16860
		[CompilerGenerated]
		private readonly int #b;
	}
}

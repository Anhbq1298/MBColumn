using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #00c
{
	// Token: 0x02000CB3 RID: 3251
	internal sealed class #50c
	{
		// Token: 0x060069FE RID: 27134 RVA: 0x0019BA48 File Offset: 0x00199C48
		public #50c(string #em, string #f, string #60c)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107432330));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107432309));
			this.Label = #em;
			this.Value = #f;
			this.Category = #60c;
		}

		// Token: 0x060069FF RID: 27135 RVA: 0x0019BAA8 File Offset: 0x00199CA8
		public #50c(string #em, object #f, string #60c, IUnit #6jb)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107432224));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431659));
			#X0d.#V0d(#6jb, #Phc.#3hc(107431638), Component.GUIFramework, #Phc.#3hc(107431597));
			this.Label = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107408730), new object[]
			{
				#em,
				#6jb.UnitSymbol.SquareFormattedSymbol
			});
			this.Value = #6jb.UnitValueFormatter.CreateDisplayValue(#f.ToString());
			this.Category = #60c;
		}

		// Token: 0x06006A00 RID: 27136 RVA: 0x0019BB64 File Offset: 0x00199D64
		public #50c(string #em, object #f, string #60c, IUnitValueFormatter #70c)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107431576));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431491));
			#X0d.#V0d(#70c, #Phc.#3hc(107431438), Component.GUIFramework, #Phc.#3hc(107431445));
			this.Label = #em;
			this.Value = #70c.CreateDisplayValue(#f.ToString());
			this.Category = #60c;
		}

		// Token: 0x06006A01 RID: 27137 RVA: 0x0019BBF0 File Offset: 0x00199DF0
		public #50c(string #em, string #f)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107431872));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431819));
			this.Label = #em;
			this.Value = #f;
		}

		// Token: 0x06006A02 RID: 27138 RVA: 0x0019BC4C File Offset: 0x00199E4C
		public #50c(string #em, object #f, IUnitValueFormatter #70c, string #80c)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107431798));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431713));
			#X0d.#V0d(#70c, #Phc.#3hc(107431438), Component.GUIFramework, #Phc.#3hc(107431148));
			this.Label = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107408730), new object[]
			{
				#em,
				#80c
			});
			this.Value = #70c.CreateDisplayValue(#f.ToString());
		}

		// Token: 0x06006A03 RID: 27139 RVA: 0x0019BCF0 File Offset: 0x00199EF0
		public #50c(string #em, object #f, IUnitValueFormatter #70c, string #80c, string #60c)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107431798));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431713));
			#X0d.#V0d(#70c, #Phc.#3hc(107431438), Component.GUIFramework, #Phc.#3hc(107431148));
			this.Label = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107408730), new object[]
			{
				#em,
				#80c
			});
			this.Value = #70c.CreateDisplayValue(#f.ToString());
			this.Category = #60c;
		}

		// Token: 0x06006A04 RID: 27140 RVA: 0x0019BD9C File Offset: 0x00199F9C
		public #50c(string #em, object #f, IUnitValueFormatter #70c)
		{
			#X0d.#V0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107431127));
			#X0d.#V0d(#f, #Phc.#3hc(107386484), Component.GUIFramework, #Phc.#3hc(107431042));
			#X0d.#V0d(#70c, #Phc.#3hc(107431438), Component.GUIFramework, #Phc.#3hc(107430989));
			this.Label = #em;
			this.Value = #70c.CreateDisplayValue(#f.ToString());
		}

		// Token: 0x17001D33 RID: 7475
		// (get) Token: 0x06006A05 RID: 27141 RVA: 0x00053DAA File Offset: 0x00051FAA
		// (set) Token: 0x06006A06 RID: 27142 RVA: 0x00053DB2 File Offset: 0x00051FB2
		public string Label { get; private set; }

		// Token: 0x17001D34 RID: 7476
		// (get) Token: 0x06006A07 RID: 27143 RVA: 0x00053DBB File Offset: 0x00051FBB
		// (set) Token: 0x06006A08 RID: 27144 RVA: 0x00053DC3 File Offset: 0x00051FC3
		public string Value { get; set; }

		// Token: 0x17001D35 RID: 7477
		// (get) Token: 0x06006A09 RID: 27145 RVA: 0x00053DCC File Offset: 0x00051FCC
		// (set) Token: 0x06006A0A RID: 27146 RVA: 0x00053DD4 File Offset: 0x00051FD4
		public string Category { get; private set; }

		// Token: 0x17001D36 RID: 7478
		// (get) Token: 0x06006A0B RID: 27147 RVA: 0x00053DDD File Offset: 0x00051FDD
		// (set) Token: 0x06006A0C RID: 27148 RVA: 0x00053DE5 File Offset: 0x00051FE5
		public int OrderIndex { get; set; }

		// Token: 0x04002B61 RID: 11105
		private const string #a = "{0} {1}";

		// Token: 0x04002B62 RID: 11106
		[CompilerGenerated]
		private string #b;

		// Token: 0x04002B63 RID: 11107
		[CompilerGenerated]
		private string #c;

		// Token: 0x04002B64 RID: 11108
		[CompilerGenerated]
		private string #d;

		// Token: 0x04002B65 RID: 11109
		[CompilerGenerated]
		private int #e;
	}
}

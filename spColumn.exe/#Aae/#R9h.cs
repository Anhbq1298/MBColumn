using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #Aae
{
	// Token: 0x02000FB8 RID: 4024
	internal sealed class #R9h : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BFC RID: 35836 RVA: 0x00071F0D File Offset: 0x0007010D
		public #R9h(string #cA)
		{
			this.#a = #cA;
		}

		// Token: 0x170028E5 RID: 10469
		// (get) Token: 0x06008BFD RID: 35837 RVA: 0x00071F1C File Offset: 0x0007011C
		public string Format { get; }

		// Token: 0x170028E6 RID: 10470
		// (get) Token: 0x06008BFE RID: 35838 RVA: 0x00071F28 File Offset: 0x00070128
		// (set) Token: 0x06008BFF RID: 35839 RVA: 0x00071F34 File Offset: 0x00070134
		public int Precision { get; set; }

		// Token: 0x170028E7 RID: 10471
		// (get) Token: 0x06008C00 RID: 35840 RVA: 0x00071F45 File Offset: 0x00070145
		// (set) Token: 0x06008C01 RID: 35841 RVA: 0x00071F51 File Offset: 0x00070151
		public UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008C02 RID: 35842 RVA: 0x00071F62 File Offset: 0x00070162
		public static IUnitValueFormatter #Q9h()
		{
			return new #R9h(#Phc.#3hc(107455033));
		}

		// Token: 0x06008C03 RID: 35843 RVA: 0x001DDAB8 File Offset: 0x001DBCB8
		public string CreateDisplayValue(string boundValue)
		{
			double value;
			if (!double.TryParse(boundValue, out value))
			{
				return boundValue;
			}
			return this.CreateDisplayValue(value);
		}

		// Token: 0x06008C04 RID: 35844 RVA: 0x00071F7B File Offset: 0x0007017B
		public string CreateDisplayValue(double value)
		{
			return value.ToString(this.Format, CultureInfo.CurrentCulture);
		}

		// Token: 0x06008C05 RID: 35845 RVA: 0x000143CE File Offset: 0x000125CE
		public string CreateBoundValue(string displayValue)
		{
			return displayValue;
		}

		// Token: 0x06008C06 RID: 35846 RVA: 0x000143CE File Offset: 0x000125CE
		public double Round(double value)
		{
			return value;
		}

		// Token: 0x04003A11 RID: 14865
		[CompilerGenerated]
		private readonly string #a;

		// Token: 0x04003A12 RID: 14866
		[CompilerGenerated]
		private int #b;

		// Token: 0x04003A13 RID: 14867
		[CompilerGenerated]
		private UnitValueAlignment #c;
	}
}

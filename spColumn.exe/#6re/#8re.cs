using System;
using System.Runtime.CompilerServices;

namespace #6re
{
	// Token: 0x02001161 RID: 4449
	internal class #8re : IComparable<#8re>
	{
		// Token: 0x17002BB9 RID: 11193
		// (get) Token: 0x060096DE RID: 38622 RVA: 0x00078209 File Offset: 0x00076409
		public static #8re Defaults
		{
			get
			{
				return new #8re
				{
					CapacityRatioFilterValue = 1.0
				};
			}
		}

		// Token: 0x17002BBA RID: 11194
		// (get) Token: 0x060096DF RID: 38623 RVA: 0x0007821F File Offset: 0x0007641F
		// (set) Token: 0x060096E0 RID: 38624 RVA: 0x00078227 File Offset: 0x00076427
		public double CapacityRatioFilterValue { get; set; }

		// Token: 0x17002BBB RID: 11195
		// (get) Token: 0x060096E1 RID: 38625 RVA: 0x00078230 File Offset: 0x00076430
		// (set) Token: 0x060096E2 RID: 38626 RVA: 0x00078238 File Offset: 0x00076438
		public bool IsCapacityRatioFilterActive { get; set; }

		// Token: 0x17002BBC RID: 11196
		// (get) Token: 0x060096E3 RID: 38627 RVA: 0x00078241 File Offset: 0x00076441
		// (set) Token: 0x060096E4 RID: 38628 RVA: 0x00078249 File Offset: 0x00076449
		public string LocationFilter { get; set; }

		// Token: 0x17002BBD RID: 11197
		// (get) Token: 0x060096E5 RID: 38629 RVA: 0x00078252 File Offset: 0x00076452
		// (set) Token: 0x060096E6 RID: 38630 RVA: 0x0007825A File Offset: 0x0007645A
		public bool IsLocationFilterActive { get; set; }

		// Token: 0x060096E7 RID: 38631 RVA: 0x001FC63C File Offset: 0x001FA83C
		public int #Qhd(#8re #L0)
		{
			if (this == #L0)
			{
				return 0;
			}
			if (#L0 == null)
			{
				return 1;
			}
			int num = this.CapacityRatioFilterValue.CompareTo(#L0.CapacityRatioFilterValue);
			if (num != 0)
			{
				return num;
			}
			int num2 = this.IsCapacityRatioFilterActive.CompareTo(#L0.IsCapacityRatioFilterActive);
			if (num2 != 0)
			{
				return num2;
			}
			int num3 = string.Compare(this.LocationFilter, #L0.LocationFilter, StringComparison.Ordinal);
			if (num3 != 0)
			{
				return num3;
			}
			return this.IsLocationFilterActive.CompareTo(#L0.IsLocationFilterActive);
		}

		// Token: 0x040040AA RID: 16554
		[CompilerGenerated]
		private double #a;

		// Token: 0x040040AB RID: 16555
		[CompilerGenerated]
		private bool #b;

		// Token: 0x040040AC RID: 16556
		[CompilerGenerated]
		private string #c;

		// Token: 0x040040AD RID: 16557
		[CompilerGenerated]
		private bool #d;
	}
}

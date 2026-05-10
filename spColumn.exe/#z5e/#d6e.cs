using System;
using System.Runtime.CompilerServices;

namespace #z5e
{
	// Token: 0x0200136B RID: 4971
	internal sealed class #d6e
	{
		// Token: 0x0600A718 RID: 42776 RVA: 0x00081F35 File Offset: 0x00080135
		public #d6e(float #e6e, float #f6e)
		{
			this.MinReinforcementRatio = #e6e;
			this.MaxReinforcementRatio = #f6e;
		}

		// Token: 0x17003071 RID: 12401
		// (get) Token: 0x0600A719 RID: 42777 RVA: 0x00081F4B File Offset: 0x0008014B
		// (set) Token: 0x0600A71A RID: 42778 RVA: 0x00081F53 File Offset: 0x00080153
		public float MinReinforcementRatio { get; private set; }

		// Token: 0x17003072 RID: 12402
		// (get) Token: 0x0600A71B RID: 42779 RVA: 0x00081F5C File Offset: 0x0008015C
		// (set) Token: 0x0600A71C RID: 42780 RVA: 0x00081F64 File Offset: 0x00080164
		public float MaxReinforcementRatio { get; private set; }

		// Token: 0x0400499C RID: 18844
		[CompilerGenerated]
		private float #a;

		// Token: 0x0400499D RID: 18845
		[CompilerGenerated]
		private float #b;
	}
}

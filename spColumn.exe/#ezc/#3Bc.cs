using System;
using System.Runtime.CompilerServices;

namespace #ezc
{
	// Token: 0x02000B54 RID: 2900
	internal sealed class #3Bc
	{
		// Token: 0x06005EA1 RID: 24225 RVA: 0x0004EAE6 File Offset: 0x0004CCE6
		public #3Bc(bool #4Bc)
		{
			this.IsSuccessful = #4Bc;
		}

		// Token: 0x06005EA2 RID: 24226 RVA: 0x0004EAF5 File Offset: 0x0004CCF5
		public #3Bc(bool #4Bc, bool #5Bc) : this(#4Bc)
		{
			this.RequiresApplicationRestart = #5Bc;
		}

		// Token: 0x06005EA3 RID: 24227 RVA: 0x0004EB05 File Offset: 0x0004CD05
		public #3Bc(string #nzb)
		{
			this.ErrorMessage = #nzb;
			this.IsSuccessful = string.IsNullOrWhiteSpace(#nzb);
		}

		// Token: 0x17001AD7 RID: 6871
		// (get) Token: 0x06005EA4 RID: 24228 RVA: 0x0004EB20 File Offset: 0x0004CD20
		// (set) Token: 0x06005EA5 RID: 24229 RVA: 0x0004EB28 File Offset: 0x0004CD28
		public bool IsSuccessful { get; private set; }

		// Token: 0x17001AD8 RID: 6872
		// (get) Token: 0x06005EA6 RID: 24230 RVA: 0x0004EB31 File Offset: 0x0004CD31
		// (set) Token: 0x06005EA7 RID: 24231 RVA: 0x0004EB39 File Offset: 0x0004CD39
		public string ErrorMessage { get; private set; }

		// Token: 0x17001AD9 RID: 6873
		// (get) Token: 0x06005EA8 RID: 24232 RVA: 0x0004EB42 File Offset: 0x0004CD42
		// (set) Token: 0x06005EA9 RID: 24233 RVA: 0x0004EB4A File Offset: 0x0004CD4A
		public bool RequiresApplicationRestart { get; private set; }

		// Token: 0x17001ADA RID: 6874
		// (get) Token: 0x06005EAA RID: 24234 RVA: 0x0004EB53 File Offset: 0x0004CD53
		// (set) Token: 0x06005EAB RID: 24235 RVA: 0x0004EB5B File Offset: 0x0004CD5B
		public bool SettingsHaveChanged { get; set; }

		// Token: 0x0400272C RID: 10028
		[CompilerGenerated]
		private bool #a;

		// Token: 0x0400272D RID: 10029
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400272E RID: 10030
		[CompilerGenerated]
		private bool #c;

		// Token: 0x0400272F RID: 10031
		[CompilerGenerated]
		private bool #d;
	}
}

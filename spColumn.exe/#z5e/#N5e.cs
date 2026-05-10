using System;
using System.Runtime.CompilerServices;

namespace #z5e
{
	// Token: 0x02001364 RID: 4964
	internal sealed class #N5e
	{
		// Token: 0x0600A680 RID: 42624 RVA: 0x0008197A File Offset: 0x0007FB7A
		public #N5e(#A5e #3)
		{
			this.Code = #3;
			this.#M5e();
		}

		// Token: 0x17003037 RID: 12343
		// (get) Token: 0x0600A681 RID: 42625 RVA: 0x0008198F File Offset: 0x0007FB8F
		public #A5e Code { get; }

		// Token: 0x17003038 RID: 12344
		// (get) Token: 0x0600A682 RID: 42626 RVA: 0x00081997 File Offset: 0x0007FB97
		// (set) Token: 0x0600A683 RID: 42627 RVA: 0x0008199F File Offset: 0x0007FB9F
		public bool IsCodeAci { get; private set; }

		// Token: 0x17003039 RID: 12345
		// (get) Token: 0x0600A684 RID: 42628 RVA: 0x000819A8 File Offset: 0x0007FBA8
		// (set) Token: 0x0600A685 RID: 42629 RVA: 0x000819B0 File Offset: 0x0007FBB0
		public bool IsCodeCsa { get; private set; }

		// Token: 0x1700303A RID: 12346
		// (get) Token: 0x0600A686 RID: 42630 RVA: 0x000819B9 File Offset: 0x0007FBB9
		// (set) Token: 0x0600A687 RID: 42631 RVA: 0x000819C1 File Offset: 0x0007FBC1
		public bool IsCodeAci08Plus { get; private set; }

		// Token: 0x1700303B RID: 12347
		// (get) Token: 0x0600A688 RID: 42632 RVA: 0x000819CA File Offset: 0x0007FBCA
		// (set) Token: 0x0600A689 RID: 42633 RVA: 0x000819D2 File Offset: 0x0007FBD2
		public bool IsCodeCsa14Plus { get; private set; }

		// Token: 0x0600A68A RID: 42634 RVA: 0x000819DB File Offset: 0x0007FBDB
		private static bool #J5e(#A5e #3)
		{
			return #3 == #A5e.#a || #3 == #A5e.#c || #3 == #A5e.#e || #3 == #A5e.#f || #3 == #A5e.#g || #3 == #A5e.#i;
		}

		// Token: 0x0600A68B RID: 42635 RVA: 0x000819F6 File Offset: 0x0007FBF6
		private static bool #K5e(#A5e #3)
		{
			return #3 == #A5e.#b || #3 == #A5e.#d || #3 == #A5e.#h || #3 == #A5e.#j;
		}

		// Token: 0x0600A68C RID: 42636 RVA: 0x00081A0B File Offset: 0x0007FC0B
		private static bool #i3(#A5e #3)
		{
			return #3 == #A5e.#h || #3 == #A5e.#j;
		}

		// Token: 0x0600A68D RID: 42637 RVA: 0x00081A18 File Offset: 0x0007FC18
		private static bool #L5e(#A5e #3)
		{
			return #3 == #A5e.#e || #3 == #A5e.#f || #3 == #A5e.#g || #3 == #A5e.#i;
		}

		// Token: 0x0600A68E RID: 42638 RVA: 0x00081A2C File Offset: 0x0007FC2C
		private void #M5e()
		{
			this.IsCodeAci = this.#J5e();
			this.IsCodeCsa = this.#K5e();
			this.IsCodeAci08Plus = this.#L5e();
			this.IsCodeCsa14Plus = #N5e.#i3(this.Code);
		}

		// Token: 0x0600A68F RID: 42639 RVA: 0x00081A63 File Offset: 0x0007FC63
		private bool #J5e()
		{
			return #N5e.#J5e(this.Code);
		}

		// Token: 0x0600A690 RID: 42640 RVA: 0x00081A70 File Offset: 0x0007FC70
		private bool #K5e()
		{
			return #N5e.#K5e(this.Code);
		}

		// Token: 0x0600A691 RID: 42641 RVA: 0x00081A7D File Offset: 0x0007FC7D
		private bool #L5e()
		{
			return #N5e.#L5e(this.Code);
		}

		// Token: 0x04004956 RID: 18774
		[CompilerGenerated]
		private readonly #A5e #a;

		// Token: 0x04004957 RID: 18775
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04004958 RID: 18776
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04004959 RID: 18777
		[CompilerGenerated]
		private bool #d;

		// Token: 0x0400495A RID: 18778
		[CompilerGenerated]
		private bool #e;
	}
}

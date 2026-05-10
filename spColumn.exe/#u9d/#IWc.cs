using System;
using System.Runtime.CompilerServices;

namespace #u9d
{
	// Token: 0x02000F93 RID: 3987
	internal sealed class #IWc
	{
		// Token: 0x06008B35 RID: 35637 RVA: 0x00071485 File Offset: 0x0006F685
		public #IWc(string #nzb)
		{
			this.ErrorMessage = #nzb;
			this.IsValid = string.IsNullOrWhiteSpace(#nzb);
		}

		// Token: 0x06008B36 RID: 35638 RVA: 0x000714A0 File Offset: 0x0006F6A0
		public #IWc(bool #DCb)
		{
			this.IsValid = #DCb;
		}

		// Token: 0x170028B8 RID: 10424
		// (get) Token: 0x06008B37 RID: 35639 RVA: 0x000714AF File Offset: 0x0006F6AF
		public static #IWc Success
		{
			get
			{
				return #IWc.#a;
			}
		}

		// Token: 0x170028B9 RID: 10425
		// (get) Token: 0x06008B38 RID: 35640 RVA: 0x000714B6 File Offset: 0x0006F6B6
		// (set) Token: 0x06008B39 RID: 35641 RVA: 0x000714C2 File Offset: 0x0006F6C2
		public bool IsValid { get; private set; }

		// Token: 0x170028BA RID: 10426
		// (get) Token: 0x06008B3A RID: 35642 RVA: 0x000714D3 File Offset: 0x0006F6D3
		// (set) Token: 0x06008B3B RID: 35643 RVA: 0x000714DF File Offset: 0x0006F6DF
		public string ErrorMessage { get; private set; }

		// Token: 0x04003998 RID: 14744
		private static readonly #IWc #a = new #IWc(true);

		// Token: 0x04003999 RID: 14745
		[CompilerGenerated]
		private bool #b;

		// Token: 0x0400399A RID: 14746
		[CompilerGenerated]
		private string #c;
	}
}

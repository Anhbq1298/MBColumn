using System;
using System.Runtime.CompilerServices;

namespace #Zjb
{
	// Token: 0x02000427 RID: 1063
	internal sealed class #lkb : EventArgs
	{
		// Token: 0x060026C2 RID: 9922 RVA: 0x00024687 File Offset: 0x00022887
		public #lkb(bool #mkb, bool #nkb)
		{
			this.#a = #mkb;
			this.#b = #nkb;
		}

		// Token: 0x060026C3 RID: 9923 RVA: 0x0002469D File Offset: 0x0002289D
		public #lkb(bool #okb)
		{
			this.#c = #okb;
		}

		// Token: 0x17000D1C RID: 3356
		// (get) Token: 0x060026C4 RID: 9924 RVA: 0x000246AC File Offset: 0x000228AC
		public bool AxialLoadChanged { get; }

		// Token: 0x17000D1D RID: 3357
		// (get) Token: 0x060026C5 RID: 9925 RVA: 0x000246B8 File Offset: 0x000228B8
		public bool AngleChanged { get; }

		// Token: 0x17000D1E RID: 3358
		// (get) Token: 0x060026C6 RID: 9926 RVA: 0x000246C4 File Offset: 0x000228C4
		public bool SelectionCleared { get; }

		// Token: 0x04000F5A RID: 3930
		[CompilerGenerated]
		private readonly bool #a;

		// Token: 0x04000F5B RID: 3931
		[CompilerGenerated]
		private readonly bool #b;

		// Token: 0x04000F5C RID: 3932
		[CompilerGenerated]
		private readonly bool #c;
	}
}

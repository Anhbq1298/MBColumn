using System;
using System.Runtime.CompilerServices;
using #y6e;

namespace #hZe
{
	// Token: 0x0200132A RID: 4906
	internal sealed class #f0e
	{
		// Token: 0x0600A3CD RID: 41933 RVA: 0x0007FF47 File Offset: 0x0007E147
		public #f0e(bool #DCb, #M6e? #g0e)
		{
			this.IsValid = #DCb;
			this.MessageCode = #g0e;
		}

		// Token: 0x17002EFB RID: 12027
		// (get) Token: 0x0600A3CE RID: 41934 RVA: 0x0007FF5D File Offset: 0x0007E15D
		// (set) Token: 0x0600A3CF RID: 41935 RVA: 0x0007FF65 File Offset: 0x0007E165
		public bool IsValid { get; private set; }

		// Token: 0x17002EFC RID: 12028
		// (get) Token: 0x0600A3D0 RID: 41936 RVA: 0x0007FF6E File Offset: 0x0007E16E
		// (set) Token: 0x0600A3D1 RID: 41937 RVA: 0x0007FF76 File Offset: 0x0007E176
		public #M6e? MessageCode { get; private set; }

		// Token: 0x040047C5 RID: 18373
		[CompilerGenerated]
		private bool #a;

		// Token: 0x040047C6 RID: 18374
		[CompilerGenerated]
		private #M6e? #b;
	}
}

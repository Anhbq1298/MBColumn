using System;
using System.Runtime.CompilerServices;

namespace #pXd
{
	// Token: 0x02000EA3 RID: 3747
	internal sealed class #NXd : #KXd
	{
		// Token: 0x17002807 RID: 10247
		// (get) Token: 0x060085C8 RID: 34248 RVA: 0x0006CF17 File Offset: 0x0006B117
		// (set) Token: 0x060085C9 RID: 34249 RVA: 0x0006CF1F File Offset: 0x0006B11F
		public Func<bool> Func { get; set; }

		// Token: 0x17002808 RID: 10248
		// (get) Token: 0x060085CA RID: 34250 RVA: 0x0006CF28 File Offset: 0x0006B128
		public bool IsCancellationRequested
		{
			get
			{
				Func<bool> func = this.Func;
				return func != null && func();
			}
		}

		// Token: 0x060085CB RID: 34251 RVA: 0x0006CF3B File Offset: 0x0006B13B
		public void #GEd()
		{
			if (this.IsCancellationRequested)
			{
				throw new OperationCanceledException();
			}
		}

		// Token: 0x04003740 RID: 14144
		[CompilerGenerated]
		private Func<bool> #a;
	}
}

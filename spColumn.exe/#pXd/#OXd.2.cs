using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace #pXd
{
	// Token: 0x02000EA4 RID: 3748
	internal sealed class #OXd : #KXd
	{
		// Token: 0x060085CD RID: 34253 RVA: 0x0006CF4B File Offset: 0x0006B14B
		public #OXd(CancellationToken #PXd)
		{
			this.#a = #PXd;
		}

		// Token: 0x17002809 RID: 10249
		// (get) Token: 0x060085CE RID: 34254 RVA: 0x0006CF5A File Offset: 0x0006B15A
		public static #KXd None { get; } = new #OXd(CancellationToken.None);

		// Token: 0x1700280A RID: 10250
		// (get) Token: 0x060085CF RID: 34255 RVA: 0x001CBDAC File Offset: 0x001C9FAC
		public bool IsCancellationRequested
		{
			get
			{
				CancellationToken cancellationToken = this.#a;
				CancellationToken cancellationToken2;
				if (!false)
				{
					cancellationToken2 = cancellationToken;
				}
				return cancellationToken2.IsCancellationRequested;
			}
		}

		// Token: 0x060085D0 RID: 34256 RVA: 0x001CBDD0 File Offset: 0x001C9FD0
		public void #GEd()
		{
			CancellationToken cancellationToken = this.#a;
			CancellationToken cancellationToken2;
			if (!false)
			{
				cancellationToken2 = cancellationToken;
			}
			if (!false)
			{
				cancellationToken2.ThrowIfCancellationRequested();
			}
		}

		// Token: 0x04003741 RID: 14145
		private readonly CancellationToken #a;

		// Token: 0x04003742 RID: 14146
		[CompilerGenerated]
		private static readonly #KXd #b;
	}
}

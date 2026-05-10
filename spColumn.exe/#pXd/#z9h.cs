using System;
using System.Threading;

namespace #pXd
{
	// Token: 0x02000EA6 RID: 3750
	internal sealed class #z9h
	{
		// Token: 0x1700280B RID: 10251
		// (get) Token: 0x060085D4 RID: 34260 RVA: 0x0006CF72 File Offset: 0x0006B172
		public bool AnyScopeActive
		{
			get
			{
				return Interlocked.CompareExchange(ref this.#a, 0, 0) > 0;
			}
		}

		// Token: 0x060085D5 RID: 34261 RVA: 0x0006CF84 File Offset: 0x0006B184
		public IDisposable #y9h()
		{
			return new #z9h.#F9h(this);
		}

		// Token: 0x04003743 RID: 14147
		private int #a;

		// Token: 0x02000EA7 RID: 3751
		private sealed class #F9h : IDisposable
		{
			// Token: 0x060085D7 RID: 34263 RVA: 0x0006CF8C File Offset: 0x0006B18C
			public #F9h(#z9h #G9h)
			{
				this.#a = #G9h;
				Interlocked.Increment(ref #G9h.#a);
			}

			// Token: 0x060085D8 RID: 34264 RVA: 0x0006CFA7 File Offset: 0x0006B1A7
			public void #1()
			{
				Interlocked.Decrement(ref this.#a.#a);
			}

			// Token: 0x04003744 RID: 14148
			private readonly #z9h #a;
		}
	}
}

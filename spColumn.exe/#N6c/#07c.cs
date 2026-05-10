using System;
using #54d;
using #7hc;
using #ezc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #N6c
{
	// Token: 0x02000CFB RID: 3323
	internal sealed class #07c : IDisposable
	{
		// Token: 0x06006C93 RID: 27795 RVA: 0x000550DB File Offset: 0x000532DB
		public #07c(#h8c #17c)
		{
			#X0d.#V0d(#17c, #Phc.#3hc(107263710), Component.GUIFramework, #Phc.#3hc(107263649));
			this.#a = #17c;
			if (!#17c.IsNotificationSuspended)
			{
				#17c.#NBc();
				this.#b = true;
			}
		}

		// Token: 0x06006C94 RID: 27796 RVA: 0x0005511B File Offset: 0x0005331B
		protected void #1(bool #POb)
		{
			if (this.#b)
			{
				bool flag = #44d.#a;
				#PBc #PBc = this.#a;
				if (4 != 0)
				{
					#PBc.#OBc();
				}
			}
		}

		// Token: 0x06006C95 RID: 27797 RVA: 0x0005513C File Offset: 0x0005333C
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04002C2B RID: 11307
		private readonly #h8c #a;

		// Token: 0x04002C2C RID: 11308
		private readonly bool #b;
	}
}

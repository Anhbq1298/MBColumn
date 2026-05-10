using System;
using #7hc;
using #8Cc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #gCc
{
	// Token: 0x02000B57 RID: 2903
	internal sealed class #fCc : IDisposable
	{
		// Token: 0x06005EB5 RID: 24245 RVA: 0x0004EBC7 File Offset: 0x0004CDC7
		public #fCc(#bDc #DJ)
		{
			#X0d.#V0d(#DJ, #Phc.#3hc(107404911), Component.GUIFramework, #Phc.#3hc(107417681));
			this.#a = #DJ;
			this.#b = #DJ.IsEnabled;
			#DJ.IsEnabled = false;
		}

		// Token: 0x06005EB6 RID: 24246 RVA: 0x0004EC05 File Offset: 0x0004CE05
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

		// Token: 0x06005EB7 RID: 24247 RVA: 0x0004EC21 File Offset: 0x0004CE21
		protected void #1(bool #POb)
		{
			if (#POb)
			{
				#bDc #bDc = this.#a;
				bool #f = this.#b;
				if (!false)
				{
					#bDc.IsEnabled = #f;
				}
			}
		}

		// Token: 0x04002731 RID: 10033
		private readonly #bDc #a;

		// Token: 0x04002732 RID: 10034
		private readonly bool #b;
	}
}

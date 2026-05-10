using System;
using #OT;
using #sUd;

namespace #ID
{
	// Token: 0x02000210 RID: 528
	internal sealed class #HD : #nF
	{
		// Token: 0x060011F9 RID: 4601 RVA: 0x00013CBD File Offset: 0x00011EBD
		public #HD(#oF #JD, #tUd #5x)
		{
			this.#a = #JD;
			this.#b = #5x;
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x000AA15C File Offset: 0x000A835C
		public #TT #GD()
		{
			#TT #TT = new #TT();
			try
			{
				#TT.IsSuccess = this.#a.#od();
				if (#TT.IsSuccess)
				{
					#TT.ImportedFactoredLoads.AddRange(this.#a.ImportedFactoryLoads);
				}
			}
			catch (Exception #ob)
			{
				this.#b.#3Ab(#ob);
			}
			return #TT;
		}

		// Token: 0x04000713 RID: 1811
		private readonly #oF #a;

		// Token: 0x04000714 RID: 1812
		private readonly #tUd #b;
	}
}

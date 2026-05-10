using System;
using #2be;
using #ede;
using #eU;
using #u9d;

namespace #ABb
{
	// Token: 0x0200054C RID: 1356
	internal sealed class #MBb
	{
		// Token: 0x0600304C RID: 12364 RVA: 0x0002AE5D File Offset: 0x0002905D
		public #MBb(#oW #xn)
		{
			this.#a = #xn;
		}

		// Token: 0x17000FA8 RID: 4008
		// (get) Token: 0x0600304D RID: 12365 RVA: 0x0002AE6C File Offset: 0x0002906C
		private #gee Boundaries
		{
			get
			{
				return #6de.#ul(this.#a.Model.#BY());
			}
		}

		// Token: 0x0600304E RID: 12366 RVA: 0x0002AE8F File Offset: 0x0002908F
		public static bool #EBb(double #f)
		{
			return !double.IsNaN(#f) && !double.IsInfinity(#f);
		}

		// Token: 0x0600304F RID: 12367 RVA: 0x0002AEB0 File Offset: 0x000290B0
		public bool #FBb(double #f, out string #nzb)
		{
			return this.#KBb(this.Boundaries.Core.TotalSectionDimension, #f, out #nzb);
		}

		// Token: 0x06003050 RID: 12368 RVA: 0x0002AED6 File Offset: 0x000290D6
		public bool #GBb(double #f, out string #nzb)
		{
			return this.#KBb(this.Boundaries.Core.ModelCoordinate, #f, out #nzb);
		}

		// Token: 0x06003051 RID: 12369 RVA: 0x000F83F4 File Offset: 0x000F65F4
		public bool #HBb(double #f, out string #nzb)
		{
			#6ce #LBb = this.Boundaries.Reinforcement.BarArea;
			return this.#KBb(#LBb, #f, out #nzb);
		}

		// Token: 0x06003052 RID: 12370 RVA: 0x0002AEFC File Offset: 0x000290FC
		public bool #IBb(double #f, out string #nzb)
		{
			return this.#KBb(this.Boundaries.Reinforcement.ClearCover, #f, out #nzb);
		}

		// Token: 0x06003053 RID: 12371 RVA: 0x0002AEFC File Offset: 0x000290FC
		public bool #JBb(double #f, out string #nzb)
		{
			return this.#KBb(this.Boundaries.Reinforcement.ClearCover, #f, out #nzb);
		}

		// Token: 0x06003054 RID: 12372 RVA: 0x000F8428 File Offset: 0x000F6628
		private bool #KBb(#6ce #LBb, double #f, out string #nzb)
		{
			#IWc #IWc = #Xce.#IH(#LBb, #f);
			#nzb = #IWc.ErrorMessage;
			return #IWc.IsValid;
		}

		// Token: 0x04001392 RID: 5010
		private readonly #oW #a;
	}
}

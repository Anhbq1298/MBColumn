using System;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #s6e
{
	// Token: 0x02001375 RID: 4981
	internal sealed class #w6e : #t6e
	{
		// Token: 0x0600A751 RID: 42833 RVA: 0x0008218C File Offset: 0x0008038C
		public #w6e(float #Sc, float #0W, float #Tc, float #ZW)
		{
			this.#b = #Sc;
			this.#a = #0W;
			this.#c = #Tc;
			this.#d = #ZW;
		}

		// Token: 0x0600A752 RID: 42834 RVA: 0x002328CC File Offset: 0x00230ACC
		public bool #q6e(Point #Ng)
		{
			return #Ng.X >= (double)this.#b && #Ng.X <= (double)this.#c && #Ng.Y >= (double)this.#a && #Ng.Y <= (double)this.#d;
		}

		// Token: 0x040049B9 RID: 18873
		private readonly float #a;

		// Token: 0x040049BA RID: 18874
		private readonly float #b;

		// Token: 0x040049BB RID: 18875
		private readonly float #c;

		// Token: 0x040049BC RID: 18876
		private readonly float #d;
	}
}

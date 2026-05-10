using System;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #s6e
{
	// Token: 0x02001371 RID: 4977
	internal sealed class #r6e : #t6e
	{
		// Token: 0x0600A74A RID: 42826 RVA: 0x00082153 File Offset: 0x00080353
		public #r6e(float #HS)
		{
			this.#b = #HS * #HS;
		}

		// Token: 0x0600A74B RID: 42827 RVA: 0x00082164 File Offset: 0x00080364
		public bool #q6e(Point #Ng)
		{
			return GeometryHelper.#Tnc(#Ng, this.#a) <= (double)this.#b;
		}

		// Token: 0x040049B5 RID: 18869
		private readonly Point #a;

		// Token: 0x040049B6 RID: 18870
		private readonly float #b;
	}
}

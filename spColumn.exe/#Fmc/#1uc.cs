using System;
using System.Collections.Generic;
using #7hc;
using #UYd;
using ClipperLib;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Fmc
{
	// Token: 0x02000805 RID: 2053
	internal sealed class #1uc : List<IntPoint>
	{
		// Token: 0x060041E4 RID: 16868 RVA: 0x00037427 File Offset: 0x00035627
		public #1uc(IEnumerable<IntPoint> #zsc)
		{
			#X0d.#V0d(#zsc, #Phc.#3hc(107462056), Component.Geometry, #Phc.#3hc(107458969));
			base.AddRange(#zsc);
		}
	}
}

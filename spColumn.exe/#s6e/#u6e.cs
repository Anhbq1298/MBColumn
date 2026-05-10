using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #s6e
{
	// Token: 0x02001373 RID: 4979
	internal sealed class #u6e : #t6e
	{
		// Token: 0x0600A74D RID: 42829 RVA: 0x00232820 File Offset: 0x00230A20
		public #u6e(List<Point[]> #v6e)
		{
			this.#a = new List<PolygonData>();
			foreach (Point[] array in #v6e)
			{
				if (array.Length >= 3)
				{
					this.#a.Add(new PolygonData(PointsConverter.#vsc(array), PolygonType.Undefined, true));
				}
			}
		}

		// Token: 0x0600A74E RID: 42830 RVA: 0x00232898 File Offset: 0x00230A98
		public bool #q6e(Point #Ng)
		{
			#u6e.#wbc #wbc = new #u6e.#wbc();
			#wbc.#a = #Ng;
			return this.#a.Any(new Func<PolygonData, bool>(#wbc.#Lif));
		}

		// Token: 0x040049B7 RID: 18871
		private readonly List<PolygonData> #a;

		// Token: 0x02001374 RID: 4980
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x0600A750 RID: 42832 RVA: 0x0008217E File Offset: 0x0008037E
			internal bool #Lif(PolygonData #JP)
			{
				return #JP.#Lnc(this.#a);
			}

			// Token: 0x040049B8 RID: 18872
			public Point #a;
		}
	}
}

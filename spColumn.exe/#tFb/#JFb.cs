using System;
using #eU;
using StructurePoint.CoreAssets.Units;

namespace #tFb
{
	// Token: 0x02000594 RID: 1428
	internal interface #JFb
	{
		// Token: 0x17000FF6 RID: 4086
		// (get) Token: 0x06003246 RID: 12870
		// (set) Token: 0x06003247 RID: 12871
		double Cover { get; set; }

		// Token: 0x17000FF7 RID: 4087
		// (get) Token: 0x06003248 RID: 12872
		// (set) Token: 0x06003249 RID: 12873
		#fU CoverType { get; set; }

		// Token: 0x17000FF8 RID: 4088
		// (get) Token: 0x0600324A RID: 12874
		// (set) Token: 0x0600324B RID: 12875
		UnitSystem ActiveUnitSystem { get; set; }

		// Token: 0x0600324C RID: 12876
		void #eb(bool #nz);

		// Token: 0x0600324D RID: 12877
		void #gFb(UnitSystem #4r);
	}
}

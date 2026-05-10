using System;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #2ic
{
	// Token: 0x02000761 RID: 1889
	internal interface #fjc : #ijc
	{
		// Token: 0x17001266 RID: 4710
		// (get) Token: 0x06003D01 RID: 15617
		// (set) Token: 0x06003D02 RID: 15618
		IPoint CenterPoint { get; set; }

		// Token: 0x17001267 RID: 4711
		// (get) Token: 0x06003D03 RID: 15619
		// (set) Token: 0x06003D04 RID: 15620
		double EndAngle { get; set; }

		// Token: 0x17001268 RID: 4712
		// (get) Token: 0x06003D05 RID: 15621
		// (set) Token: 0x06003D06 RID: 15622
		double MajorAxisLength { get; set; }

		// Token: 0x17001269 RID: 4713
		// (get) Token: 0x06003D07 RID: 15623
		// (set) Token: 0x06003D08 RID: 15624
		double MinorAxisLength { get; set; }

		// Token: 0x1700126A RID: 4714
		// (get) Token: 0x06003D09 RID: 15625
		// (set) Token: 0x06003D0A RID: 15626
		double StartAngle { get; set; }

		// Token: 0x1700126B RID: 4715
		// (get) Token: 0x06003D0B RID: 15627
		// (set) Token: 0x06003D0C RID: 15628
		double MajorAxisAngle { get; set; }
	}
}

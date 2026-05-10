using System;
using #Fmc;
using #YKc;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #NWc
{
	// Token: 0x02000C94 RID: 3220
	internal interface #oW
	{
		// Token: 0x17001CD5 RID: 7381
		// (get) Token: 0x0600682C RID: 26668
		#WWc MainModel { get; }

		// Token: 0x17001CD6 RID: 7382
		// (get) Token: 0x0600682D RID: 26669
		// (set) Token: 0x0600682E RID: 26670
		#hvc SnappingModes { get; set; }

		// Token: 0x17001CD7 RID: 7383
		// (get) Token: 0x0600682F RID: 26671
		IUnitValueFormatter GeometryDimensionUnitValueFormatter { get; }

		// Token: 0x17001CD8 RID: 7384
		// (get) Token: 0x06006830 RID: 26672
		// (set) Token: 0x06006831 RID: 26673
		string GeometryDimensionUnitSymbol { get; set; }

		// Token: 0x17001CD9 RID: 7385
		// (get) Token: 0x06006832 RID: 26674
		string AngleUnitSymbol { get; }

		// Token: 0x14000191 RID: 401
		// (add) Token: 0x06006833 RID: 26675
		// (remove) Token: 0x06006834 RID: 26676
		event EventHandler<#cLc> SnappingModeChanged;
	}
}

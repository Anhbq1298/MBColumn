using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;

namespace #3ve
{
	// Token: 0x02001190 RID: 4496
	internal sealed class #hwe
	{
		// Token: 0x0600986C RID: 39020 RVA: 0x00078F14 File Offset: 0x00077114
		public #hwe()
		{
			this.FactoredFailureSurfaceData = new List<FailureSurfaceData>();
			this.NominalFailureSurfaceData = new List<FailureSurfaceData>();
			this.DisplayOptions = new FailureSurfaceDisplayOptions();
		}

		// Token: 0x17002C3C RID: 11324
		// (get) Token: 0x0600986D RID: 39021 RVA: 0x00078F3D File Offset: 0x0007713D
		// (set) Token: 0x0600986E RID: 39022 RVA: 0x00078F45 File Offset: 0x00077145
		public List<FailureSurfaceData> FactoredFailureSurfaceData { get; set; }

		// Token: 0x17002C3D RID: 11325
		// (get) Token: 0x0600986F RID: 39023 RVA: 0x00078F4E File Offset: 0x0007714E
		// (set) Token: 0x06009870 RID: 39024 RVA: 0x00078F56 File Offset: 0x00077156
		public List<FailureSurfaceData> NominalFailureSurfaceData { get; set; }

		// Token: 0x17002C3E RID: 11326
		// (get) Token: 0x06009871 RID: 39025 RVA: 0x00078F5F File Offset: 0x0007715F
		// (set) Token: 0x06009872 RID: 39026 RVA: 0x00078F67 File Offset: 0x00077167
		public string MomentUnitString { get; set; }

		// Token: 0x17002C3F RID: 11327
		// (get) Token: 0x06009873 RID: 39027 RVA: 0x00078F70 File Offset: 0x00077170
		// (set) Token: 0x06009874 RID: 39028 RVA: 0x00078F78 File Offset: 0x00077178
		public string ForceUnitString { get; set; }

		// Token: 0x17002C40 RID: 11328
		// (get) Token: 0x06009875 RID: 39029 RVA: 0x00078F81 File Offset: 0x00077181
		// (set) Token: 0x06009876 RID: 39030 RVA: 0x00078F89 File Offset: 0x00077189
		public string LengthUnitString { get; set; }

		// Token: 0x17002C41 RID: 11329
		// (get) Token: 0x06009877 RID: 39031 RVA: 0x00078F92 File Offset: 0x00077192
		// (set) Token: 0x06009878 RID: 39032 RVA: 0x00078F9A File Offset: 0x0007719A
		public long ParentWindowHandle { get; set; }

		// Token: 0x17002C42 RID: 11330
		// (get) Token: 0x06009879 RID: 39033 RVA: 0x00078FA3 File Offset: 0x000771A3
		// (set) Token: 0x0600987A RID: 39034 RVA: 0x00078FAB File Offset: 0x000771AB
		public string GeometryDimensionUnitSymbol { get; set; }

		// Token: 0x17002C43 RID: 11331
		// (get) Token: 0x0600987B RID: 39035 RVA: 0x00078FB4 File Offset: 0x000771B4
		// (set) Token: 0x0600987C RID: 39036 RVA: 0x00078FBC File Offset: 0x000771BC
		public string ReinforcementAreaUnitSymbol { get; set; }

		// Token: 0x17002C44 RID: 11332
		// (get) Token: 0x0600987D RID: 39037 RVA: 0x00078FC5 File Offset: 0x000771C5
		// (set) Token: 0x0600987E RID: 39038 RVA: 0x00078FCD File Offset: 0x000771CD
		public double RegularSectionDimensionX { get; set; }

		// Token: 0x17002C45 RID: 11333
		// (get) Token: 0x0600987F RID: 39039 RVA: 0x00078FD6 File Offset: 0x000771D6
		// (set) Token: 0x06009880 RID: 39040 RVA: 0x00078FDE File Offset: 0x000771DE
		public double RegularSectionDimensionY { get; set; }

		// Token: 0x17002C46 RID: 11334
		// (get) Token: 0x06009881 RID: 39041 RVA: 0x00078FE7 File Offset: 0x000771E7
		// (set) Token: 0x06009882 RID: 39042 RVA: 0x00078FEF File Offset: 0x000771EF
		public FailureSurfaceDisplayOptions DisplayOptions { get; set; }

		// Token: 0x04004195 RID: 16789
		[CompilerGenerated]
		private List<FailureSurfaceData> #a;

		// Token: 0x04004196 RID: 16790
		[CompilerGenerated]
		private List<FailureSurfaceData> #b;

		// Token: 0x04004197 RID: 16791
		[CompilerGenerated]
		private string #c;

		// Token: 0x04004198 RID: 16792
		[CompilerGenerated]
		private string #d;

		// Token: 0x04004199 RID: 16793
		[CompilerGenerated]
		private string #e;

		// Token: 0x0400419A RID: 16794
		[CompilerGenerated]
		private long #f;

		// Token: 0x0400419B RID: 16795
		[CompilerGenerated]
		private string #g;

		// Token: 0x0400419C RID: 16796
		[CompilerGenerated]
		private string #h;

		// Token: 0x0400419D RID: 16797
		[CompilerGenerated]
		private double #i;

		// Token: 0x0400419E RID: 16798
		[CompilerGenerated]
		private double #j;

		// Token: 0x0400419F RID: 16799
		[CompilerGenerated]
		private FailureSurfaceDisplayOptions #k;
	}
}

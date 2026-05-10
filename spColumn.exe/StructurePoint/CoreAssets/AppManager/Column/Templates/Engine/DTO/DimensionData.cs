using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO
{
	// Token: 0x0200109B RID: 4251
	public sealed class DimensionData
	{
		// Token: 0x17002A2A RID: 10794
		// (get) Token: 0x0600910F RID: 37135 RVA: 0x00074ECB File Offset: 0x000730CB
		// (set) Token: 0x06009110 RID: 37136 RVA: 0x00074ED3 File Offset: 0x000730D3
		public Point Start { get; set; }

		// Token: 0x17002A2B RID: 10795
		// (get) Token: 0x06009111 RID: 37137 RVA: 0x00074EDC File Offset: 0x000730DC
		// (set) Token: 0x06009112 RID: 37138 RVA: 0x00074EE4 File Offset: 0x000730E4
		public Point Orientation { get; set; }

		// Token: 0x17002A2C RID: 10796
		// (get) Token: 0x06009113 RID: 37139 RVA: 0x00074EED File Offset: 0x000730ED
		// (set) Token: 0x06009114 RID: 37140 RVA: 0x00074EF5 File Offset: 0x000730F5
		public double Order { get; set; }

		// Token: 0x17002A2D RID: 10797
		// (get) Token: 0x06009115 RID: 37141 RVA: 0x00074EFE File Offset: 0x000730FE
		public List<DimensionStep> Steps { get; } = new List<DimensionStep>();

		// Token: 0x04003CF8 RID: 15608
		[CompilerGenerated]
		private Point #a;

		// Token: 0x04003CF9 RID: 15609
		[CompilerGenerated]
		private Point #b;

		// Token: 0x04003CFA RID: 15610
		[CompilerGenerated]
		private double #c;

		// Token: 0x04003CFB RID: 15611
		[CompilerGenerated]
		private readonly List<DimensionStep> #d;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #6re
{
	// Token: 0x0200116C RID: 4460
	internal sealed class #Gse : #8re
	{
		// Token: 0x17002BCB RID: 11211
		// (get) Token: 0x06009704 RID: 38660 RVA: 0x00078336 File Offset: 0x00076536
		public static #Gse Default
		{
			get
			{
				return new #Gse
				{
					CapacityRatioFilterValue = 1.0,
					HighlightCapacityRatioWithThreshold = true,
					HighlightCapacityRatioColor = Color.FromArgb(byte.MaxValue, 242, 220, 219)
				};
			}
		}

		// Token: 0x17002BCC RID: 11212
		// (get) Token: 0x06009705 RID: 38661 RVA: 0x00078372 File Offset: 0x00076572
		// (set) Token: 0x06009706 RID: 38662 RVA: 0x0007837A File Offset: 0x0007657A
		public bool HighlightCapacityRatioWithThreshold { get; set; }

		// Token: 0x17002BCD RID: 11213
		// (get) Token: 0x06009707 RID: 38663 RVA: 0x00078383 File Offset: 0x00076583
		// (set) Token: 0x06009708 RID: 38664 RVA: 0x0007838B File Offset: 0x0007658B
		public Color HighlightCapacityRatioColor { get; set; }

		// Token: 0x17002BCE RID: 11214
		// (get) Token: 0x06009709 RID: 38665 RVA: 0x00078394 File Offset: 0x00076594
		// (set) Token: 0x0600970A RID: 38666 RVA: 0x0007839C File Offset: 0x0007659C
		public bool IsVisibilityFilterActive { get; set; }

		// Token: 0x17002BCF RID: 11215
		// (get) Token: 0x0600970B RID: 38667 RVA: 0x000783A5 File Offset: 0x000765A5
		public bool IsAnyFilterActive
		{
			get
			{
				return base.IsCapacityRatioFilterActive || base.IsLocationFilterActive || this.IsVisibilityFilterActive;
			}
		}

		// Token: 0x17002BD0 RID: 11216
		// (get) Token: 0x0600970C RID: 38668 RVA: 0x000783BF File Offset: 0x000765BF
		// (set) Token: 0x0600970D RID: 38669 RVA: 0x000783C7 File Offset: 0x000765C7
		public SectionCapacityMethodType CapacityRatioCalculationMethod { get; set; }

		// Token: 0x040040DD RID: 16605
		[CompilerGenerated]
		private bool #a;

		// Token: 0x040040DE RID: 16606
		[CompilerGenerated]
		private Color #b;

		// Token: 0x040040DF RID: 16607
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040040E0 RID: 16608
		[CompilerGenerated]
		private SectionCapacityMethodType #d;
	}
}

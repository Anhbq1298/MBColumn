using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace #3Qb
{
	// Token: 0x020006C2 RID: 1730
	internal sealed class #2Qb
	{
		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x06003979 RID: 14713 RVA: 0x00031DED File Offset: 0x0002FFED
		public static #2Qb Default { get; } = new #2Qb
		{
			AutomaticallyGenerateTextResultsFile = true,
			HighlightCriticalLoadPoints = true,
			HighlightingColor = Color.FromArgb(byte.MaxValue, 242, 220, 219),
			ReorderSolidAndOpeningLabelsBeforeSolve = true
		};

		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x0600397A RID: 14714 RVA: 0x00031DF4 File Offset: 0x0002FFF4
		// (set) Token: 0x0600397B RID: 14715 RVA: 0x00031E00 File Offset: 0x00030000
		public bool AutomaticallyGenerateTextResultsFile { get; set; }

		// Token: 0x170011AA RID: 4522
		// (get) Token: 0x0600397C RID: 14716 RVA: 0x00031E11 File Offset: 0x00030011
		// (set) Token: 0x0600397D RID: 14717 RVA: 0x00031E1D File Offset: 0x0003001D
		public bool HighlightCriticalLoadPoints { get; set; }

		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x0600397E RID: 14718 RVA: 0x00031E2E File Offset: 0x0003002E
		// (set) Token: 0x0600397F RID: 14719 RVA: 0x00031E3A File Offset: 0x0003003A
		public Color HighlightingColor { get; set; }

		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x06003980 RID: 14720 RVA: 0x00031E4B File Offset: 0x0003004B
		// (set) Token: 0x06003981 RID: 14721 RVA: 0x00031E57 File Offset: 0x00030057
		public bool ReorderSolidAndOpeningLabelsBeforeSolve { get; set; }

		// Token: 0x06003982 RID: 14722 RVA: 0x00031E68 File Offset: 0x00030068
		public void #mg(#2Qb #ng)
		{
			this.HighlightCriticalLoadPoints = #ng.HighlightCriticalLoadPoints;
			this.AutomaticallyGenerateTextResultsFile = #ng.AutomaticallyGenerateTextResultsFile;
			this.HighlightingColor = #ng.HighlightingColor;
			this.ReorderSolidAndOpeningLabelsBeforeSolve = #ng.ReorderSolidAndOpeningLabelsBeforeSolve;
		}

		// Token: 0x04001861 RID: 6241
		[CompilerGenerated]
		private static readonly #2Qb #a;

		// Token: 0x04001862 RID: 6242
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001863 RID: 6243
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04001864 RID: 6244
		[CompilerGenerated]
		private Color #d;

		// Token: 0x04001865 RID: 6245
		[CompilerGenerated]
		private bool #e;
	}
}

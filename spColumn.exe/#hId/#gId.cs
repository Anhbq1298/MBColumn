using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #BTd;
using #LQc;
using #sUd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.Logger;

namespace #hId
{
	// Token: 0x02000D9B RID: 3483
	internal sealed class #gId
	{
		// Token: 0x06007E02 RID: 32258 RVA: 0x00066821 File Offset: 0x00064A21
		public #gId()
		{
			this.#b = new List<PageMarginsSpecification>();
		}

		// Token: 0x170025C1 RID: 9665
		// (get) Token: 0x06007E03 RID: 32259 RVA: 0x00066834 File Offset: 0x00064A34
		// (set) Token: 0x06007E04 RID: 32260 RVA: 0x00066840 File Offset: 0x00064A40
		public string UnitString { get; set; }

		// Token: 0x170025C2 RID: 9666
		// (get) Token: 0x06007E05 RID: 32261 RVA: 0x00066851 File Offset: 0x00064A51
		public List<PageMarginsSpecification> PageMargins { get; }

		// Token: 0x170025C3 RID: 9667
		// (get) Token: 0x06007E06 RID: 32262 RVA: 0x0006685D File Offset: 0x00064A5D
		// (set) Token: 0x06007E07 RID: 32263 RVA: 0x00066869 File Offset: 0x00064A69
		public PageMarginType SelectedMarginType { get; set; }

		// Token: 0x170025C4 RID: 9668
		// (get) Token: 0x06007E08 RID: 32264 RVA: 0x0006687A File Offset: 0x00064A7A
		// (set) Token: 0x06007E09 RID: 32265 RVA: 0x00066886 File Offset: 0x00064A86
		public PaperOrientation PaperOrientation { get; set; }

		// Token: 0x170025C5 RID: 9669
		// (get) Token: 0x06007E0A RID: 32266 RVA: 0x00066897 File Offset: 0x00064A97
		// (set) Token: 0x06007E0B RID: 32267 RVA: 0x000668A3 File Offset: 0x00064AA3
		public string PrinterName { get; set; }

		// Token: 0x170025C6 RID: 9670
		// (get) Token: 0x06007E0C RID: 32268 RVA: 0x000668B4 File Offset: 0x00064AB4
		// (set) Token: 0x06007E0D RID: 32269 RVA: 0x000668C0 File Offset: 0x00064AC0
		public int? PaperRawKind { get; set; }

		// Token: 0x170025C7 RID: 9671
		// (get) Token: 0x06007E0E RID: 32270 RVA: 0x000668D1 File Offset: 0x00064AD1
		// (set) Token: 0x06007E0F RID: 32271 RVA: 0x000668DD File Offset: 0x00064ADD
		public System.Drawing.Printing.PaperSize PaperSize { get; set; }

		// Token: 0x170025C8 RID: 9672
		// (get) Token: 0x06007E10 RID: 32272 RVA: 0x000668EE File Offset: 0x00064AEE
		// (set) Token: 0x06007E11 RID: 32273 RVA: 0x000668FA File Offset: 0x00064AFA
		public Aspose.Words.PaperSize? AsposePaperSize { get; set; }

		// Token: 0x170025C9 RID: 9673
		// (get) Token: 0x06007E12 RID: 32274 RVA: 0x0006690B File Offset: 0x00064B0B
		// (set) Token: 0x06007E13 RID: 32275 RVA: 0x00066917 File Offset: 0x00064B17
		public ILogger Logger { get; set; }

		// Token: 0x170025CA RID: 9674
		// (get) Token: 0x06007E14 RID: 32276 RVA: 0x00066928 File Offset: 0x00064B28
		// (set) Token: 0x06007E15 RID: 32277 RVA: 0x00066934 File Offset: 0x00064B34
		public #ATd FontSizeInfoProvider { get; set; }

		// Token: 0x170025CB RID: 9675
		// (get) Token: 0x06007E16 RID: 32278 RVA: 0x00066945 File Offset: 0x00064B45
		// (set) Token: 0x06007E17 RID: 32279 RVA: 0x00066951 File Offset: 0x00064B51
		public #wUd Settings { get; set; }

		// Token: 0x170025CC RID: 9676
		// (get) Token: 0x06007E18 RID: 32280 RVA: 0x00066962 File Offset: 0x00064B62
		// (set) Token: 0x06007E19 RID: 32281 RVA: 0x0006696E File Offset: 0x00064B6E
		public #8Sc DialogService { get; set; }

		// Token: 0x170025CD RID: 9677
		// (get) Token: 0x06007E1A RID: 32282 RVA: 0x0006697F File Offset: 0x00064B7F
		// (set) Token: 0x06007E1B RID: 32283 RVA: 0x0006698B File Offset: 0x00064B8B
		public Visibility PageRangeOptionsVisibility { get; set; }

		// Token: 0x06007E1C RID: 32284 RVA: 0x001BBE30 File Offset: 0x001BA030
		public #jJd #dId(bool #eId)
		{
			#jJd #jJd = new #jJd();
			#jJd.PaperSize = this.PaperSize;
			#jJd.AsposePaperSize = this.AsposePaperSize;
			#jJd.Margins.#mg((this.PageMargins.FirstOrDefault(new Func<PageMarginsSpecification, bool>(this.#fId)) ?? this.PageMargins.First<PageMarginsSpecification>()).#xId(#eId));
			#jJd.Orientation = this.PaperOrientation;
			#jJd.Printer = this.PrinterName;
			#jJd.FontInfo = ReportFontSizeInfoProvider.Instance.#3hc(ReportFontSizes.Large);
			return #jJd;
		}

		// Token: 0x06007E1D RID: 32285 RVA: 0x0006699C File Offset: 0x00064B9C
		[CompilerGenerated]
		private bool #fId(PageMarginsSpecification #Rf)
		{
			return #Rf.MarginType == this.SelectedMarginType;
		}

		// Token: 0x04003396 RID: 13206
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003397 RID: 13207
		[CompilerGenerated]
		private readonly List<PageMarginsSpecification> #b;

		// Token: 0x04003398 RID: 13208
		[CompilerGenerated]
		private PageMarginType #c;

		// Token: 0x04003399 RID: 13209
		[CompilerGenerated]
		private PaperOrientation #d;

		// Token: 0x0400339A RID: 13210
		[CompilerGenerated]
		private string #e;

		// Token: 0x0400339B RID: 13211
		[CompilerGenerated]
		private int? #f;

		// Token: 0x0400339C RID: 13212
		[CompilerGenerated]
		private System.Drawing.Printing.PaperSize #g;

		// Token: 0x0400339D RID: 13213
		[CompilerGenerated]
		private Aspose.Words.PaperSize? #h;

		// Token: 0x0400339E RID: 13214
		[CompilerGenerated]
		private ILogger #i;

		// Token: 0x0400339F RID: 13215
		[CompilerGenerated]
		private #ATd #j;

		// Token: 0x040033A0 RID: 13216
		[CompilerGenerated]
		private #wUd #k;

		// Token: 0x040033A1 RID: 13217
		[CompilerGenerated]
		private #8Sc #l;

		// Token: 0x040033A2 RID: 13218
		[CompilerGenerated]
		private Visibility #m;
	}
}

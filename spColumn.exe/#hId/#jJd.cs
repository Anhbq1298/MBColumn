using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using #3Rd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace #hId
{
	// Token: 0x02000DAB RID: 3499
	internal sealed class #jJd
	{
		// Token: 0x06007E66 RID: 32358 RVA: 0x00066F7F File Offset: 0x0006517F
		public #jJd()
		{
			this.Pages = new List<IPageSelection>();
			this.Margins = new PageMarginsSpecification();
		}

		// Token: 0x170025DE RID: 9694
		// (get) Token: 0x06007E67 RID: 32359 RVA: 0x00066F9D File Offset: 0x0006519D
		// (set) Token: 0x06007E68 RID: 32360 RVA: 0x00066FA9 File Offset: 0x000651A9
		public string Printer { get; set; }

		// Token: 0x170025DF RID: 9695
		// (get) Token: 0x06007E69 RID: 32361 RVA: 0x00066FBA File Offset: 0x000651BA
		// (set) Token: 0x06007E6A RID: 32362 RVA: 0x00066FC6 File Offset: 0x000651C6
		public #GId PrinterStatus { get; set; }

		// Token: 0x170025E0 RID: 9696
		// (get) Token: 0x06007E6B RID: 32363 RVA: 0x00066FD7 File Offset: 0x000651D7
		// (set) Token: 0x06007E6C RID: 32364 RVA: 0x00066FE3 File Offset: 0x000651E3
		public bool IsRealPrinterDevice { get; set; }

		// Token: 0x170025E1 RID: 9697
		// (get) Token: 0x06007E6D RID: 32365 RVA: 0x00066FF4 File Offset: 0x000651F4
		// (set) Token: 0x06007E6E RID: 32366 RVA: 0x00067000 File Offset: 0x00065200
		public PaperOrientation Orientation { get; set; }

		// Token: 0x170025E2 RID: 9698
		// (get) Token: 0x06007E6F RID: 32367 RVA: 0x00067011 File Offset: 0x00065211
		// (set) Token: 0x06007E70 RID: 32368 RVA: 0x0006701D File Offset: 0x0006521D
		public System.Drawing.Printing.PaperSize PaperSize { get; set; }

		// Token: 0x170025E3 RID: 9699
		// (get) Token: 0x06007E71 RID: 32369 RVA: 0x0006702E File Offset: 0x0006522E
		// (set) Token: 0x06007E72 RID: 32370 RVA: 0x0006703A File Offset: 0x0006523A
		public Aspose.Words.PaperSize? AsposePaperSize { get; set; }

		// Token: 0x170025E4 RID: 9700
		// (get) Token: 0x06007E73 RID: 32371 RVA: 0x0006704B File Offset: 0x0006524B
		// (set) Token: 0x06007E74 RID: 32372 RVA: 0x00067057 File Offset: 0x00065257
		public bool NoPaperSelected { get; set; }

		// Token: 0x170025E5 RID: 9701
		// (get) Token: 0x06007E75 RID: 32373 RVA: 0x00067068 File Offset: 0x00065268
		// (set) Token: 0x06007E76 RID: 32374 RVA: 0x00067074 File Offset: 0x00065274
		public PageSelectionMode PageSelectionMode { get; set; }

		// Token: 0x170025E6 RID: 9702
		// (get) Token: 0x06007E77 RID: 32375 RVA: 0x00067085 File Offset: 0x00065285
		// (set) Token: 0x06007E78 RID: 32376 RVA: 0x00067091 File Offset: 0x00065291
		public bool InvalidPageSelection { get; set; }

		// Token: 0x170025E7 RID: 9703
		// (get) Token: 0x06007E79 RID: 32377 RVA: 0x000670A2 File Offset: 0x000652A2
		// (set) Token: 0x06007E7A RID: 32378 RVA: 0x000670AE File Offset: 0x000652AE
		public List<IPageSelection> Pages { get; private set; }

		// Token: 0x170025E8 RID: 9704
		// (get) Token: 0x06007E7B RID: 32379 RVA: 0x000670BF File Offset: 0x000652BF
		// (set) Token: 0x06007E7C RID: 32380 RVA: 0x000670CB File Offset: 0x000652CB
		public string PageSelectionRaw { get; set; }

		// Token: 0x170025E9 RID: 9705
		// (get) Token: 0x06007E7D RID: 32381 RVA: 0x000670DC File Offset: 0x000652DC
		// (set) Token: 0x06007E7E RID: 32382 RVA: 0x000670E8 File Offset: 0x000652E8
		public PageMarginsSpecification Margins { get; set; }

		// Token: 0x170025EA RID: 9706
		// (get) Token: 0x06007E7F RID: 32383 RVA: 0x000670F9 File Offset: 0x000652F9
		// (set) Token: 0x06007E80 RID: 32384 RVA: 0x00067105 File Offset: 0x00065305
		public PrinterSettings PrinterSettings { get; set; }

		// Token: 0x170025EB RID: 9707
		// (get) Token: 0x06007E81 RID: 32385 RVA: 0x00067116 File Offset: 0x00065316
		// (set) Token: 0x06007E82 RID: 32386 RVA: 0x00067122 File Offset: 0x00065322
		public int LinesPerPage { get; set; }

		// Token: 0x170025EC RID: 9708
		// (get) Token: 0x06007E83 RID: 32387 RVA: 0x00067133 File Offset: 0x00065333
		// (set) Token: 0x06007E84 RID: 32388 RVA: 0x0006713F File Offset: 0x0006533F
		public #dTd FontInfo { get; set; }

		// Token: 0x06007E85 RID: 32389 RVA: 0x001BC7AC File Offset: 0x001BA9AC
		public #jJd #EA()
		{
			return new #jJd
			{
				Printer = this.Printer,
				IsRealPrinterDevice = this.IsRealPrinterDevice,
				Orientation = this.Orientation,
				PaperSize = this.PaperSize,
				AsposePaperSize = this.AsposePaperSize,
				NoPaperSelected = this.NoPaperSelected,
				PageSelectionMode = this.PageSelectionMode,
				InvalidPageSelection = this.InvalidPageSelection,
				Pages = this.Pages,
				PageSelectionRaw = this.PageSelectionRaw,
				LinesPerPage = this.LinesPerPage,
				PrinterSettings = this.PrinterSettings,
				Margins = new PageMarginsSpecification().#mg(this.Margins),
				FontInfo = this.FontInfo,
				PrinterStatus = this.PrinterStatus
			};
		}

		// Token: 0x040033CD RID: 13261
		[CompilerGenerated]
		private string #a;

		// Token: 0x040033CE RID: 13262
		[CompilerGenerated]
		private #GId #b;

		// Token: 0x040033CF RID: 13263
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040033D0 RID: 13264
		[CompilerGenerated]
		private PaperOrientation #d;

		// Token: 0x040033D1 RID: 13265
		[CompilerGenerated]
		private System.Drawing.Printing.PaperSize #e;

		// Token: 0x040033D2 RID: 13266
		[CompilerGenerated]
		private Aspose.Words.PaperSize? #f;

		// Token: 0x040033D3 RID: 13267
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040033D4 RID: 13268
		[CompilerGenerated]
		private PageSelectionMode #h;

		// Token: 0x040033D5 RID: 13269
		[CompilerGenerated]
		private bool #i;

		// Token: 0x040033D6 RID: 13270
		[CompilerGenerated]
		private List<IPageSelection> #j;

		// Token: 0x040033D7 RID: 13271
		[CompilerGenerated]
		private string #k;

		// Token: 0x040033D8 RID: 13272
		[CompilerGenerated]
		private PageMarginsSpecification #l;

		// Token: 0x040033D9 RID: 13273
		[CompilerGenerated]
		private PrinterSettings #m;

		// Token: 0x040033DA RID: 13274
		[CompilerGenerated]
		private int #n;

		// Token: 0x040033DB RID: 13275
		[CompilerGenerated]
		private #dTd #o;
	}
}

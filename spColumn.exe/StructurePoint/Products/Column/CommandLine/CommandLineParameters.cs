using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;

namespace StructurePoint.Products.Column.CommandLine
{
	// Token: 0x020006CC RID: 1740
	internal sealed class CommandLineParameters
	{
		// Token: 0x170011C7 RID: 4551
		// (get) Token: 0x060039DA RID: 14810 RVA: 0x000323F0 File Offset: 0x000305F0
		// (set) Token: 0x060039DB RID: 14811 RVA: 0x000323FC File Offset: 0x000305FC
		public string InputPath { get; set; }

		// Token: 0x170011C8 RID: 4552
		// (get) Token: 0x060039DC RID: 14812 RVA: 0x0003240D File Offset: 0x0003060D
		// (set) Token: 0x060039DD RID: 14813 RVA: 0x00032419 File Offset: 0x00030619
		public string OutputPath { get; set; }

		// Token: 0x170011C9 RID: 4553
		// (get) Token: 0x060039DE RID: 14814 RVA: 0x0003242A File Offset: 0x0003062A
		// (set) Token: 0x060039DF RID: 14815 RVA: 0x00032436 File Offset: 0x00030636
		public bool PdfReportRequested { get; set; }

		// Token: 0x170011CA RID: 4554
		// (get) Token: 0x060039E0 RID: 14816 RVA: 0x00032447 File Offset: 0x00030647
		// (set) Token: 0x060039E1 RID: 14817 RVA: 0x00032453 File Offset: 0x00030653
		public bool WordReportRequested { get; set; }

		// Token: 0x170011CB RID: 4555
		// (get) Token: 0x060039E2 RID: 14818 RVA: 0x00032464 File Offset: 0x00030664
		// (set) Token: 0x060039E3 RID: 14819 RVA: 0x00032470 File Offset: 0x00030670
		public bool ExcelReportRequested { get; set; }

		// Token: 0x170011CC RID: 4556
		// (get) Token: 0x060039E4 RID: 14820 RVA: 0x00032481 File Offset: 0x00030681
		// (set) Token: 0x060039E5 RID: 14821 RVA: 0x0003248D File Offset: 0x0003068D
		public bool CsvReportRequested { get; set; }

		// Token: 0x170011CD RID: 4557
		// (get) Token: 0x060039E6 RID: 14822 RVA: 0x0003249E File Offset: 0x0003069E
		// (set) Token: 0x060039E7 RID: 14823 RVA: 0x000324AA File Offset: 0x000306AA
		public string PdfReportPath { get; set; }

		// Token: 0x170011CE RID: 4558
		// (get) Token: 0x060039E8 RID: 14824 RVA: 0x000324BB File Offset: 0x000306BB
		// (set) Token: 0x060039E9 RID: 14825 RVA: 0x000324C7 File Offset: 0x000306C7
		public string WordReportPath { get; set; }

		// Token: 0x170011CF RID: 4559
		// (get) Token: 0x060039EA RID: 14826 RVA: 0x000324D8 File Offset: 0x000306D8
		// (set) Token: 0x060039EB RID: 14827 RVA: 0x000324E4 File Offset: 0x000306E4
		public string ExcelReportPath { get; set; }

		// Token: 0x170011D0 RID: 4560
		// (get) Token: 0x060039EC RID: 14828 RVA: 0x000324F5 File Offset: 0x000306F5
		// (set) Token: 0x060039ED RID: 14829 RVA: 0x00032501 File Offset: 0x00030701
		public string CsvReportPath { get; set; }

		// Token: 0x170011D1 RID: 4561
		// (get) Token: 0x060039EE RID: 14830 RVA: 0x00032512 File Offset: 0x00030712
		// (set) Token: 0x060039EF RID: 14831 RVA: 0x0003251E File Offset: 0x0003071E
		public string ColumnType { get; set; }

		// Token: 0x170011D2 RID: 4562
		// (get) Token: 0x060039F0 RID: 14832 RVA: 0x0003252F File Offset: 0x0003072F
		// (set) Token: 0x060039F1 RID: 14833 RVA: 0x0003253B File Offset: 0x0003073B
		public string CtiPath { get; set; }

		// Token: 0x170011D3 RID: 4563
		// (get) Token: 0x060039F2 RID: 14834 RVA: 0x0003254C File Offset: 0x0003074C
		// (set) Token: 0x060039F3 RID: 14835 RVA: 0x00032558 File Offset: 0x00030758
		public bool CtiRequested { get; set; }

		// Token: 0x170011D4 RID: 4564
		// (get) Token: 0x060039F4 RID: 14836 RVA: 0x00032569 File Offset: 0x00030769
		// (set) Token: 0x060039F5 RID: 14837 RVA: 0x00032575 File Offset: 0x00030775
		public bool RemoveDuplicateLoads { get; set; }

		// Token: 0x170011D5 RID: 4565
		// (get) Token: 0x060039F6 RID: 14838 RVA: 0x00032586 File Offset: 0x00030786
		// (set) Token: 0x060039F7 RID: 14839 RVA: 0x00032592 File Offset: 0x00030792
		public float? DiagramInterpolationConvergenceEpsilon { get; set; }

		// Token: 0x170011D6 RID: 4566
		// (get) Token: 0x060039F8 RID: 14840 RVA: 0x000325A3 File Offset: 0x000307A3
		// (set) Token: 0x060039F9 RID: 14841 RVA: 0x000325AF File Offset: 0x000307AF
		public LateralLoadsCompatibilityMode LateralLoadsCompatibilityMode { get; set; }

		// Token: 0x170011D7 RID: 4567
		// (get) Token: 0x060039FA RID: 14842 RVA: 0x000325C0 File Offset: 0x000307C0
		public bool IsColumnArchitectural
		{
			get
			{
				string a = #Phc.#3hc(107350261);
				string text = this.ColumnType;
				return string.Equals(a, (text != null) ? text.Trim() : null, StringComparison.OrdinalIgnoreCase);
			}
		}

		// Token: 0x170011D8 RID: 4568
		// (get) Token: 0x060039FB RID: 14843 RVA: 0x0011336C File Offset: 0x0011156C
		public bool IsColumnTypeValid
		{
			get
			{
				string a = #Phc.#3hc(107350261);
				string text = this.ColumnType;
				if (!string.Equals(a, (text != null) ? text.Trim() : null, StringComparison.OrdinalIgnoreCase))
				{
					string a2 = #Phc.#3hc(107350261);
					string text2 = this.ColumnType;
					if (!string.Equals(a2, (text2 != null) ? text2.Trim() : null, StringComparison.OrdinalIgnoreCase))
					{
						return string.IsNullOrWhiteSpace(this.ColumnType);
					}
				}
				return true;
			}
		}

		// Token: 0x170011D9 RID: 4569
		// (get) Token: 0x060039FC RID: 14844 RVA: 0x000325F0 File Offset: 0x000307F0
		// (set) Token: 0x060039FD RID: 14845 RVA: 0x000325FC File Offset: 0x000307FC
		public bool ContinueProcessingWhenBarsAreOutsideOfSection { get; set; }

		// Token: 0x170011DA RID: 4570
		// (get) Token: 0x060039FE RID: 14846 RVA: 0x0003260D File Offset: 0x0003080D
		// (set) Token: 0x060039FF RID: 14847 RVA: 0x00032619 File Offset: 0x00030819
		public bool ContinueProcessingWhenRhoIsGreaterThanEight { get; set; }

		// Token: 0x170011DB RID: 4571
		// (get) Token: 0x06003A00 RID: 14848 RVA: 0x0003262A File Offset: 0x0003082A
		// (set) Token: 0x06003A01 RID: 14849 RVA: 0x00032636 File Offset: 0x00030836
		public bool TestMode { get; set; }

		// Token: 0x170011DC RID: 4572
		// (get) Token: 0x06003A02 RID: 14850 RVA: 0x00032647 File Offset: 0x00030847
		// (set) Token: 0x06003A03 RID: 14851 RVA: 0x00032653 File Offset: 0x00030853
		public bool ExportCsvDiagram { get; set; }

		// Token: 0x170011DD RID: 4573
		// (get) Token: 0x06003A04 RID: 14852 RVA: 0x00032664 File Offset: 0x00030864
		// (set) Token: 0x06003A05 RID: 14853 RVA: 0x00032670 File Offset: 0x00030870
		public string CsvDiagramPath { get; set; }

		// Token: 0x170011DE RID: 4574
		// (get) Token: 0x06003A06 RID: 14854 RVA: 0x00032681 File Offset: 0x00030881
		// (set) Token: 0x06003A07 RID: 14855 RVA: 0x0003268D File Offset: 0x0003088D
		public bool CsvDiagramPathSpecified { get; set; }

		// Token: 0x170011DF RID: 4575
		// (get) Token: 0x06003A08 RID: 14856 RVA: 0x0003269E File Offset: 0x0003089E
		// (set) Token: 0x06003A09 RID: 14857 RVA: 0x000326AA File Offset: 0x000308AA
		public bool ExportTxtDiagram { get; set; }

		// Token: 0x170011E0 RID: 4576
		// (get) Token: 0x06003A0A RID: 14858 RVA: 0x000326BB File Offset: 0x000308BB
		// (set) Token: 0x06003A0B RID: 14859 RVA: 0x000326C7 File Offset: 0x000308C7
		public string TxtDiagramPath { get; set; }

		// Token: 0x170011E1 RID: 4577
		// (get) Token: 0x06003A0C RID: 14860 RVA: 0x000326D8 File Offset: 0x000308D8
		// (set) Token: 0x06003A0D RID: 14861 RVA: 0x000326E4 File Offset: 0x000308E4
		public bool TxtDiagramPathSpecified { get; set; }

		// Token: 0x170011E2 RID: 4578
		// (get) Token: 0x06003A0E RID: 14862 RVA: 0x000326F5 File Offset: 0x000308F5
		// (set) Token: 0x06003A0F RID: 14863 RVA: 0x00032701 File Offset: 0x00030901
		public bool IncludeNominalDiagram { get; set; }

		// Token: 0x170011E3 RID: 4579
		// (get) Token: 0x06003A10 RID: 14864 RVA: 0x00032712 File Offset: 0x00030912
		// (set) Token: 0x06003A11 RID: 14865 RVA: 0x0003271E File Offset: 0x0003091E
		public bool ExportDxf { get; set; }

		// Token: 0x170011E4 RID: 4580
		// (get) Token: 0x06003A12 RID: 14866 RVA: 0x0003272F File Offset: 0x0003092F
		// (set) Token: 0x06003A13 RID: 14867 RVA: 0x0003273B File Offset: 0x0003093B
		public string DxfPath { get; set; }

		// Token: 0x170011E5 RID: 4581
		// (get) Token: 0x06003A14 RID: 14868 RVA: 0x0003274C File Offset: 0x0003094C
		// (set) Token: 0x06003A15 RID: 14869 RVA: 0x00032758 File Offset: 0x00030958
		public bool Batch { get; set; }

		// Token: 0x0400188D RID: 6285
		public const string #a = "arch";

		// Token: 0x0400188E RID: 6286
		public const string #b = "arch";

		// Token: 0x0400188F RID: 6287
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001890 RID: 6288
		[CompilerGenerated]
		private string #d;

		// Token: 0x04001891 RID: 6289
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04001892 RID: 6290
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04001893 RID: 6291
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04001894 RID: 6292
		[CompilerGenerated]
		private bool #h;

		// Token: 0x04001895 RID: 6293
		[CompilerGenerated]
		private string #i;

		// Token: 0x04001896 RID: 6294
		[CompilerGenerated]
		private string #j;

		// Token: 0x04001897 RID: 6295
		[CompilerGenerated]
		private string #k;

		// Token: 0x04001898 RID: 6296
		[CompilerGenerated]
		private string #l;

		// Token: 0x04001899 RID: 6297
		[CompilerGenerated]
		private string #m;

		// Token: 0x0400189A RID: 6298
		[CompilerGenerated]
		private string #n;

		// Token: 0x0400189B RID: 6299
		[CompilerGenerated]
		private bool #o;

		// Token: 0x0400189C RID: 6300
		[CompilerGenerated]
		private bool #p;

		// Token: 0x0400189D RID: 6301
		[CompilerGenerated]
		private float? #q;

		// Token: 0x0400189E RID: 6302
		[CompilerGenerated]
		private LateralLoadsCompatibilityMode #r;

		// Token: 0x0400189F RID: 6303
		[CompilerGenerated]
		private bool #s = true;

		// Token: 0x040018A0 RID: 6304
		[CompilerGenerated]
		private bool #t = true;

		// Token: 0x040018A1 RID: 6305
		[CompilerGenerated]
		private bool #u;

		// Token: 0x040018A2 RID: 6306
		[CompilerGenerated]
		private bool #v;

		// Token: 0x040018A3 RID: 6307
		[CompilerGenerated]
		private string #w;

		// Token: 0x040018A4 RID: 6308
		[CompilerGenerated]
		private bool #x;

		// Token: 0x040018A5 RID: 6309
		[CompilerGenerated]
		private bool #y;

		// Token: 0x040018A6 RID: 6310
		[CompilerGenerated]
		private string #z;

		// Token: 0x040018A7 RID: 6311
		[CompilerGenerated]
		private bool #A;

		// Token: 0x040018A8 RID: 6312
		[CompilerGenerated]
		private bool #B;

		// Token: 0x040018A9 RID: 6313
		[CompilerGenerated]
		private bool #C;

		// Token: 0x040018AA RID: 6314
		[CompilerGenerated]
		private string #D;

		// Token: 0x040018AB RID: 6315
		[CompilerGenerated]
		private bool #E;
	}
}

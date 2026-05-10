using System;
using System.Collections.Generic;
using #3Rd;
using #Qcd;
using Aspose.Words;
using Aspose.Words.Tables;

namespace #FCd
{
	// Token: 0x02000D32 RID: 3378
	internal interface #5Dd : IDisposable
	{
		// Token: 0x17001F57 RID: 8023
		// (get) Token: 0x06006F6D RID: 28525
		// (set) Token: 0x06006F6E RID: 28526
		float PreferredWidth { get; set; }

		// Token: 0x17001F58 RID: 8024
		// (get) Token: 0x06006F6F RID: 28527
		bool[] HtmlColumns { get; }

		// Token: 0x17001F59 RID: 8025
		// (get) Token: 0x06006F70 RID: 28528
		#zTd CurrentStyle { get; }

		// Token: 0x17001F5A RID: 8026
		// (get) Token: 0x06006F71 RID: 28529
		IReadOnlyList<#zTd> Styles { get; }

		// Token: 0x17001F5B RID: 8027
		// (get) Token: 0x06006F72 RID: 28530
		IReadOnlyList<#zTd> ColunmStyles { get; }

		// Token: 0x17001F5C RID: 8028
		// (get) Token: 0x06006F73 RID: 28531
		// (set) Token: 0x06006F74 RID: 28532
		#rdd TableWidthType { get; set; }

		// Token: 0x17001F5D RID: 8029
		// (get) Token: 0x06006F75 RID: 28533
		double[] ColumnWidths { get; }

		// Token: 0x17001F5E RID: 8030
		// (get) Token: 0x06006F76 RID: 28534
		#rdd[] ColumnWidthTypes { get; }

		// Token: 0x17001F5F RID: 8031
		// (get) Token: 0x06006F77 RID: 28535
		// (set) Token: 0x06006F78 RID: 28536
		TableAlignment TableAlignment { get; set; }

		// Token: 0x17001F60 RID: 8032
		// (get) Token: 0x06006F79 RID: 28537
		bool SupportsTextWrapping { get; }

		// Token: 0x17001F61 RID: 8033
		// (get) Token: 0x06006F7A RID: 28538
		// (set) Token: 0x06006F7B RID: 28539
		bool EnforceTableAlignment { get; set; }

		// Token: 0x17001F62 RID: 8034
		// (get) Token: 0x06006F7C RID: 28540
		// (set) Token: 0x06006F7D RID: 28541
		int? NumberOfBoldHeaderRows { get; set; }

		// Token: 0x17001F63 RID: 8035
		// (get) Token: 0x06006F7E RID: 28542
		#eDd Borders { get; }

		// Token: 0x17001F64 RID: 8036
		// (get) Token: 0x06006F7F RID: 28543
		// (set) Token: 0x06006F80 RID: 28544
		double? TableLeftIndent { get; set; }

		// Token: 0x17001F65 RID: 8037
		// (get) Token: 0x06006F81 RID: 28545
		// (set) Token: 0x06006F82 RID: 28546
		#sdd AutoSizeMode { get; set; }

		// Token: 0x17001F66 RID: 8038
		// (get) Token: 0x06006F83 RID: 28547
		int CurrentCellIndex { get; }

		// Token: 0x17001F67 RID: 8039
		// (get) Token: 0x06006F84 RID: 28548
		int CurrentRowIndex { get; }

		// Token: 0x06006F85 RID: 28549
		void ResetCurrentStyle();

		// Token: 0x06006F86 RID: 28550
		void #ODd(params string[] #Qb);

		// Token: 0x06006F87 RID: 28551
		void #PDd();

		// Token: 0x06006F88 RID: 28552
		void #QDd(params string[] #Qb);

		// Token: 0x06006F89 RID: 28553
		void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb);

		// Token: 0x06006F8A RID: 28554
		void #Fhd(int #1f, params string[] #Qb);

		// Token: 0x06006F8B RID: 28555
		void #QDd(int? #f);

		// Token: 0x06006F8C RID: 28556
		void #RDd(bool #f, params int[] #SDd);

		// Token: 0x06006F8D RID: 28557
		void #TDd(int #8r = -1);

		// Token: 0x06006F8E RID: 28558
		void #UDd(int #8r = -1);

		// Token: 0x06006F8F RID: 28559
		void #VDd(ParagraphAlignment #rT, params int[] #SDd);

		// Token: 0x06006F90 RID: 28560
		void #WDd(double #f, params int[] #Dob);

		// Token: 0x06006F91 RID: 28561
		void #XDd(#rdd #YDd, params int[] #SDd);

		// Token: 0x06006F92 RID: 28562
		void #ZDd(params string[] #Qb);

		// Token: 0x06006F93 RID: 28563
		void #ZDd(ParagraphAlignment #rT, params string[] #Qb);

		// Token: 0x06006F94 RID: 28564
		void #0Dd(#SCd #C, double #f);

		// Token: 0x06006F95 RID: 28565
		void #1Dd(int #2Dd, #SCd #C, double #f);

		// Token: 0x06006F96 RID: 28566
		void #3Dd(bool #f, params int[] #SDd);

		// Token: 0x06006F97 RID: 28567
		void #4Dd();
	}
}

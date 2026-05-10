using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #5Fd;
using #7hc;
using #Qcd;

namespace #Ted
{
	// Token: 0x02000D1E RID: 3358
	internal sealed class #Wfd
	{
		// Token: 0x06006E82 RID: 28290 RVA: 0x001A4D04 File Offset: 0x001A2F04
		public #Wfd(IList<#EGd> #Zgb, double[] #Zpb, #0ed #mA, int[] #Xfd)
		{
			if (#Zgb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377558));
			}
			if (#Zpb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253239));
			}
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.CriticalItemsOptions = #mA;
			this.Rows = #Zgb;
			this.ColumnWidths = #Zpb;
			this.PixelWidths = #Xfd;
		}

		// Token: 0x17001F06 RID: 7942
		// (get) Token: 0x06006E83 RID: 28291 RVA: 0x0005908C File Offset: 0x0005728C
		// (set) Token: 0x06006E84 RID: 28292 RVA: 0x00059098 File Offset: 0x00057298
		public #0ed CriticalItemsOptions { get; private set; }

		// Token: 0x17001F07 RID: 7943
		// (get) Token: 0x06006E85 RID: 28293 RVA: 0x000590A9 File Offset: 0x000572A9
		// (set) Token: 0x06006E86 RID: 28294 RVA: 0x000590B5 File Offset: 0x000572B5
		public int HeaderRowCount { get; set; }

		// Token: 0x17001F08 RID: 7944
		// (get) Token: 0x06006E87 RID: 28295 RVA: 0x000590C6 File Offset: 0x000572C6
		// (set) Token: 0x06006E88 RID: 28296 RVA: 0x000590D2 File Offset: 0x000572D2
		public int ColumnsCount { get; set; }

		// Token: 0x17001F09 RID: 7945
		// (get) Token: 0x06006E89 RID: 28297 RVA: 0x000590E3 File Offset: 0x000572E3
		// (set) Token: 0x06006E8A RID: 28298 RVA: 0x000590EF File Offset: 0x000572EF
		public double PreferredWidth { get; set; }

		// Token: 0x17001F0A RID: 7946
		// (get) Token: 0x06006E8B RID: 28299 RVA: 0x00059100 File Offset: 0x00057300
		// (set) Token: 0x06006E8C RID: 28300 RVA: 0x0005910C File Offset: 0x0005730C
		public #rdd WidthType { get; set; }

		// Token: 0x17001F0B RID: 7947
		// (get) Token: 0x06006E8D RID: 28301 RVA: 0x0005911D File Offset: 0x0005731D
		// (set) Token: 0x06006E8E RID: 28302 RVA: 0x00059129 File Offset: 0x00057329
		public int NumberOfBoldHeaderRows { get; set; }

		// Token: 0x17001F0C RID: 7948
		// (get) Token: 0x06006E8F RID: 28303 RVA: 0x0005913A File Offset: 0x0005733A
		// (set) Token: 0x06006E90 RID: 28304 RVA: 0x00059146 File Offset: 0x00057346
		public IList<#EGd> Rows { get; private set; }

		// Token: 0x17001F0D RID: 7949
		// (get) Token: 0x06006E91 RID: 28305 RVA: 0x00059157 File Offset: 0x00057357
		// (set) Token: 0x06006E92 RID: 28306 RVA: 0x00059163 File Offset: 0x00057363
		public double[] ColumnWidths { get; private set; }

		// Token: 0x17001F0E RID: 7950
		// (get) Token: 0x06006E93 RID: 28307 RVA: 0x00059174 File Offset: 0x00057374
		// (set) Token: 0x06006E94 RID: 28308 RVA: 0x00059180 File Offset: 0x00057380
		public int[] PixelWidths { get; private set; }

		// Token: 0x17001F0F RID: 7951
		// (get) Token: 0x06006E95 RID: 28309 RVA: 0x00059191 File Offset: 0x00057391
		// (set) Token: 0x06006E96 RID: 28310 RVA: 0x0005919D File Offset: 0x0005739D
		public bool ForcePreferredWidth { get; set; }

		// Token: 0x04002C75 RID: 11381
		[CompilerGenerated]
		private #0ed #a;

		// Token: 0x04002C76 RID: 11382
		[CompilerGenerated]
		private int #b;

		// Token: 0x04002C77 RID: 11383
		[CompilerGenerated]
		private int #c;

		// Token: 0x04002C78 RID: 11384
		[CompilerGenerated]
		private double #d;

		// Token: 0x04002C79 RID: 11385
		[CompilerGenerated]
		private #rdd #e;

		// Token: 0x04002C7A RID: 11386
		[CompilerGenerated]
		private int #f;

		// Token: 0x04002C7B RID: 11387
		[CompilerGenerated]
		private IList<#EGd> #g;

		// Token: 0x04002C7C RID: 11388
		[CompilerGenerated]
		private double[] #h;

		// Token: 0x04002C7D RID: 11389
		[CompilerGenerated]
		private int[] #i;

		// Token: 0x04002C7E RID: 11390
		[CompilerGenerated]
		private bool #j;
	}
}

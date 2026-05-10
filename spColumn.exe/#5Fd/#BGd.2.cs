using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aspose.Words;

namespace #5Fd
{
	// Token: 0x02000D85 RID: 3461
	[DebuggerDisplay("C:{CellIndex} - \"{Value}\"")]
	internal sealed class #BGd
	{
		// Token: 0x17002598 RID: 9624
		// (get) Token: 0x06007D54 RID: 32084 RVA: 0x00065E43 File Offset: 0x00064043
		// (set) Token: 0x06007D55 RID: 32085 RVA: 0x00065E4F File Offset: 0x0006404F
		public string Value { get; set; }

		// Token: 0x17002599 RID: 9625
		// (get) Token: 0x06007D56 RID: 32086 RVA: 0x00065E60 File Offset: 0x00064060
		// (set) Token: 0x06007D57 RID: 32087 RVA: 0x00065E6C File Offset: 0x0006406C
		public ParagraphAlignment Alignment { get; set; }

		// Token: 0x1700259A RID: 9626
		// (get) Token: 0x06007D58 RID: 32088 RVA: 0x00065E7D File Offset: 0x0006407D
		// (set) Token: 0x06007D59 RID: 32089 RVA: 0x00065E89 File Offset: 0x00064089
		public int Merge { get; set; }

		// Token: 0x1700259B RID: 9627
		// (get) Token: 0x06007D5A RID: 32090 RVA: 0x00065E9A File Offset: 0x0006409A
		public bool IsMerged
		{
			get
			{
				return this.ForceIsMerged || this.Merge > 1;
			}
		}

		// Token: 0x1700259C RID: 9628
		// (get) Token: 0x06007D5B RID: 32091 RVA: 0x00065EBB File Offset: 0x000640BB
		// (set) Token: 0x06007D5C RID: 32092 RVA: 0x00065EC7 File Offset: 0x000640C7
		public int CellIndex { get; set; }

		// Token: 0x1700259D RID: 9629
		// (get) Token: 0x06007D5D RID: 32093 RVA: 0x00065ED8 File Offset: 0x000640D8
		// (set) Token: 0x06007D5E RID: 32094 RVA: 0x00065EE4 File Offset: 0x000640E4
		public bool ForceIsMerged { get; set; }

		// Token: 0x0400334F RID: 13135
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003350 RID: 13136
		[CompilerGenerated]
		private ParagraphAlignment #b;

		// Token: 0x04003351 RID: 13137
		[CompilerGenerated]
		private int #c;

		// Token: 0x04003352 RID: 13138
		[CompilerGenerated]
		private int #d;

		// Token: 0x04003353 RID: 13139
		[CompilerGenerated]
		private bool #e;
	}
}

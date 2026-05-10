using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Words;

namespace #3Rd
{
	// Token: 0x02000E32 RID: 3634
	internal sealed class #zTd
	{
		// Token: 0x170026EF RID: 9967
		// (get) Token: 0x06008264 RID: 33380 RVA: 0x0006A30E File Offset: 0x0006850E
		// (set) Token: 0x06008265 RID: 33381 RVA: 0x0006A31A File Offset: 0x0006851A
		public ParagraphAlignment HorizontalAlignment { get; set; }

		// Token: 0x170026F0 RID: 9968
		// (get) Token: 0x06008266 RID: 33382 RVA: 0x0006A32B File Offset: 0x0006852B
		// (set) Token: 0x06008267 RID: 33383 RVA: 0x0006A337 File Offset: 0x00068537
		public Color? Background { get; set; }

		// Token: 0x170026F1 RID: 9969
		// (get) Token: 0x06008268 RID: 33384 RVA: 0x0006A348 File Offset: 0x00068548
		// (set) Token: 0x06008269 RID: 33385 RVA: 0x0006A354 File Offset: 0x00068554
		public bool Bold { get; set; }

		// Token: 0x170026F2 RID: 9970
		// (get) Token: 0x0600826A RID: 33386 RVA: 0x0006A365 File Offset: 0x00068565
		// (set) Token: 0x0600826B RID: 33387 RVA: 0x0006A371 File Offset: 0x00068571
		public bool Border { get; set; }

		// Token: 0x0600826C RID: 33388 RVA: 0x001C3C44 File Offset: 0x001C1E44
		public #zTd #EA()
		{
			#zTd #zTd = new #zTd();
			this.#77c(#zTd);
			return #zTd;
		}

		// Token: 0x0600826D RID: 33389 RVA: 0x0006A382 File Offset: 0x00068582
		public void #77c(#zTd #4cd)
		{
			#4cd.Background = this.Background;
			#4cd.HorizontalAlignment = this.HorizontalAlignment;
			#4cd.Bold = this.Bold;
		}

		// Token: 0x04003584 RID: 13700
		[CompilerGenerated]
		private ParagraphAlignment #a;

		// Token: 0x04003585 RID: 13701
		[CompilerGenerated]
		private Color? #b;

		// Token: 0x04003586 RID: 13702
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003587 RID: 13703
		[CompilerGenerated]
		private bool #d;
	}
}

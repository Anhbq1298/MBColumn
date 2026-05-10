using System;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #hId;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;

namespace #VEd
{
	// Token: 0x02000D67 RID: 3431
	internal class #4Ed
	{
		// Token: 0x06007CAD RID: 31917 RVA: 0x0006550F File Offset: 0x0006370F
		public #4Ed()
		{
			this.#a = new Document();
			this.#b = new DocumentBuilder(this.Document);
			this.#d = new #qSd();
			this.#e = new SectionHeaderHandler();
		}

		// Token: 0x06007CAE RID: 31918 RVA: 0x00065549 File Offset: 0x00063749
		public #4Ed(DocumentBuilder #tCd)
		{
			if (#tCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251540));
			}
			this.#b = #tCd;
		}

		// Token: 0x17002575 RID: 9589
		// (get) Token: 0x06007CAF RID: 31919 RVA: 0x0006556C File Offset: 0x0006376C
		public Document Document { get; }

		// Token: 0x17002576 RID: 9590
		// (get) Token: 0x06007CB0 RID: 31920 RVA: 0x00065578 File Offset: 0x00063778
		public DocumentBuilder Builder { get; }

		// Token: 0x17002577 RID: 9591
		// (get) Token: 0x06007CB1 RID: 31921 RVA: 0x00065584 File Offset: 0x00063784
		// (set) Token: 0x06007CB2 RID: 31922 RVA: 0x00065590 File Offset: 0x00063790
		public #jJd PrintOptions { get; set; }

		// Token: 0x17002578 RID: 9592
		// (get) Token: 0x06007CB3 RID: 31923 RVA: 0x000655A1 File Offset: 0x000637A1
		public #qSd Map { get; }

		// Token: 0x17002579 RID: 9593
		// (get) Token: 0x06007CB4 RID: 31924 RVA: 0x000655AD File Offset: 0x000637AD
		public SectionHeaderHandler HeaderHandler { get; }

		// Token: 0x1700257A RID: 9594
		// (get) Token: 0x06007CB5 RID: 31925 RVA: 0x000655B9 File Offset: 0x000637B9
		// (set) Token: 0x06007CB6 RID: 31926 RVA: 0x000655C5 File Offset: 0x000637C5
		public bool SplitLongTables { get; set; }

		// Token: 0x1700257B RID: 9595
		// (get) Token: 0x06007CB7 RID: 31927 RVA: 0x000655D6 File Offset: 0x000637D6
		// (set) Token: 0x06007CB8 RID: 31928 RVA: 0x000655E2 File Offset: 0x000637E2
		public bool IncludeCover { get; set; }

		// Token: 0x1700257C RID: 9596
		// (get) Token: 0x06007CB9 RID: 31929 RVA: 0x000655F3 File Offset: 0x000637F3
		// (set) Token: 0x06007CBA RID: 31930 RVA: 0x000655FF File Offset: 0x000637FF
		public bool IncludeTableOfContents { get; set; }

		// Token: 0x1700257D RID: 9597
		// (get) Token: 0x06007CBB RID: 31931 RVA: 0x00065610 File Offset: 0x00063810
		// (set) Token: 0x06007CBC RID: 31932 RVA: 0x0006561C File Offset: 0x0006381C
		public string TableOfContentsBookmarkName { get; set; }

		// Token: 0x0400330F RID: 13071
		[CompilerGenerated]
		private readonly Document #a;

		// Token: 0x04003310 RID: 13072
		[CompilerGenerated]
		private readonly DocumentBuilder #b;

		// Token: 0x04003311 RID: 13073
		[CompilerGenerated]
		private #jJd #c;

		// Token: 0x04003312 RID: 13074
		[CompilerGenerated]
		private readonly #qSd #d;

		// Token: 0x04003313 RID: 13075
		[CompilerGenerated]
		private readonly SectionHeaderHandler #e;

		// Token: 0x04003314 RID: 13076
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04003315 RID: 13077
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04003316 RID: 13078
		[CompilerGenerated]
		private bool #h;

		// Token: 0x04003317 RID: 13079
		[CompilerGenerated]
		private string #i;
	}
}

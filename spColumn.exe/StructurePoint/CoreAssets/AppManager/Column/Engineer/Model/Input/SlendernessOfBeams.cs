using System;
using System.Runtime.CompilerServices;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input
{
	// Token: 0x0200136C RID: 4972
	public sealed class SlendernessOfBeams
	{
		// Token: 0x0600A71D RID: 42781 RVA: 0x002325C0 File Offset: 0x002307C0
		public SlendernessOfBeams(SlendernessOfBeams item)
		{
			this.AboveLeft = new #y5e(item.AboveLeft);
			this.AboveRight = new #y5e(item.AboveRight);
			this.BelowLeft = new #y5e(item.BelowLeft);
			this.BelowRight = new #y5e(item.BelowRight);
		}

		// Token: 0x0600A71E RID: 42782 RVA: 0x00232618 File Offset: 0x00230818
		internal SlendernessOfBeams(SLDBEAM item)
		{
			this.AboveLeft = new #y5e(item.#a);
			this.AboveRight = new #y5e(item.#b);
			this.BelowLeft = new #y5e(item.#c);
			this.BelowRight = new #y5e(item.#d);
		}

		// Token: 0x17003073 RID: 12403
		// (get) Token: 0x0600A71F RID: 42783 RVA: 0x00081F6D File Offset: 0x0008016D
		// (set) Token: 0x0600A720 RID: 42784 RVA: 0x00081F75 File Offset: 0x00080175
		public #y5e AboveLeft { get; private set; }

		// Token: 0x17003074 RID: 12404
		// (get) Token: 0x0600A721 RID: 42785 RVA: 0x00081F7E File Offset: 0x0008017E
		// (set) Token: 0x0600A722 RID: 42786 RVA: 0x00081F86 File Offset: 0x00080186
		public #y5e AboveRight { get; private set; }

		// Token: 0x17003075 RID: 12405
		// (get) Token: 0x0600A723 RID: 42787 RVA: 0x00081F8F File Offset: 0x0008018F
		// (set) Token: 0x0600A724 RID: 42788 RVA: 0x00081F97 File Offset: 0x00080197
		public #y5e BelowLeft { get; private set; }

		// Token: 0x17003076 RID: 12406
		// (get) Token: 0x0600A725 RID: 42789 RVA: 0x00081FA0 File Offset: 0x000801A0
		// (set) Token: 0x0600A726 RID: 42790 RVA: 0x00081FA8 File Offset: 0x000801A8
		public #y5e BelowRight { get; private set; }

		// Token: 0x0400499E RID: 18846
		[CompilerGenerated]
		private #y5e #a;

		// Token: 0x0400499F RID: 18847
		[CompilerGenerated]
		private #y5e #b;

		// Token: 0x040049A0 RID: 18848
		[CompilerGenerated]
		private #y5e #c;

		// Token: 0x040049A1 RID: 18849
		[CompilerGenerated]
		private #y5e #d;
	}
}

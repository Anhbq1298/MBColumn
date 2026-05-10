using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E4F RID: 3663
	public sealed class ETABSFrame
	{
		// Token: 0x17002781 RID: 10113
		// (get) Token: 0x06008367 RID: 33639 RVA: 0x0006B2D0 File Offset: 0x000694D0
		// (set) Token: 0x06008368 RID: 33640 RVA: 0x0006B2D8 File Offset: 0x000694D8
		public string Name { get; private set; }

		// Token: 0x17002782 RID: 10114
		// (get) Token: 0x06008369 RID: 33641 RVA: 0x0006B2E1 File Offset: 0x000694E1
		// (set) Token: 0x0600836A RID: 33642 RVA: 0x0006B2E9 File Offset: 0x000694E9
		public string Label { get; private set; }

		// Token: 0x17002783 RID: 10115
		// (get) Token: 0x0600836B RID: 33643 RVA: 0x0006B2F2 File Offset: 0x000694F2
		// (set) Token: 0x0600836C RID: 33644 RVA: 0x0006B2FA File Offset: 0x000694FA
		public string Story { get; private set; }

		// Token: 0x17002784 RID: 10116
		// (get) Token: 0x0600836D RID: 33645 RVA: 0x0006B303 File Offset: 0x00069503
		// (set) Token: 0x0600836E RID: 33646 RVA: 0x0006B30B File Offset: 0x0006950B
		public string Section { get; private set; }

		// Token: 0x0600836F RID: 33647 RVA: 0x0006B314 File Offset: 0x00069514
		internal ETABSFrame(string name, string label, string story, string section)
		{
			this.Name = name;
			this.Label = label;
			this.Story = story;
			this.Section = section;
		}

		// Token: 0x040035F3 RID: 13811
		[CompilerGenerated]
		private string #a;

		// Token: 0x040035F4 RID: 13812
		[CompilerGenerated]
		private string #b;

		// Token: 0x040035F5 RID: 13813
		[CompilerGenerated]
		private string #c;

		// Token: 0x040035F6 RID: 13814
		[CompilerGenerated]
		private string #d;
	}
}

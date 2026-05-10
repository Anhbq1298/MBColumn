using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E54 RID: 3668
	public sealed class ETABSPier
	{
		// Token: 0x1700278B RID: 10123
		// (get) Token: 0x06008387 RID: 33671 RVA: 0x0006B48A File Offset: 0x0006968A
		internal string Name
		{
			get
			{
				return this.Label + this.Story;
			}
		}

		// Token: 0x1700278C RID: 10124
		// (get) Token: 0x06008388 RID: 33672 RVA: 0x0006B49D File Offset: 0x0006969D
		// (set) Token: 0x06008389 RID: 33673 RVA: 0x0006B4A5 File Offset: 0x000696A5
		public string Label { get; private set; }

		// Token: 0x1700278D RID: 10125
		// (get) Token: 0x0600838A RID: 33674 RVA: 0x0006B4AE File Offset: 0x000696AE
		// (set) Token: 0x0600838B RID: 33675 RVA: 0x0006B4B6 File Offset: 0x000696B6
		public string Story { get; private set; }

		// Token: 0x0600838C RID: 33676 RVA: 0x0006B4BF File Offset: 0x000696BF
		internal ETABSPier(string label, string story)
		{
			this.Label = label;
			this.Story = story;
		}

		// Token: 0x04003610 RID: 13840
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003611 RID: 13841
		[CompilerGenerated]
		private string #b;
	}
}

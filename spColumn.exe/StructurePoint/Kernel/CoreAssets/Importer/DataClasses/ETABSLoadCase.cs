using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E51 RID: 3665
	public sealed class ETABSLoadCase
	{
		// Token: 0x17002785 RID: 10117
		// (get) Token: 0x06008370 RID: 33648 RVA: 0x0006B339 File Offset: 0x00069539
		// (set) Token: 0x06008371 RID: 33649 RVA: 0x0006B341 File Offset: 0x00069541
		public string Name { get; private set; }

		// Token: 0x17002786 RID: 10118
		// (get) Token: 0x06008372 RID: 33650 RVA: 0x0006B34A File Offset: 0x0006954A
		// (set) Token: 0x06008373 RID: 33651 RVA: 0x0006B352 File Offset: 0x00069552
		public ETABSLoadCaseType Type { get; private set; }

		// Token: 0x17002787 RID: 10119
		// (get) Token: 0x06008374 RID: 33652 RVA: 0x0006B35B File Offset: 0x0006955B
		// (set) Token: 0x06008375 RID: 33653 RVA: 0x0006B363 File Offset: 0x00069563
		public bool Analyzed { get; private set; }

		// Token: 0x06008376 RID: 33654 RVA: 0x0006B36C File Offset: 0x0006956C
		internal ETABSLoadCase(string name, ETABSLoadCaseType type, bool analyzed)
		{
			this.Name = name;
			this.Type = type;
			this.Analyzed = analyzed;
		}

		// Token: 0x04003606 RID: 13830
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003607 RID: 13831
		[CompilerGenerated]
		private ETABSLoadCaseType #b;

		// Token: 0x04003608 RID: 13832
		[CompilerGenerated]
		private bool #c;
	}
}

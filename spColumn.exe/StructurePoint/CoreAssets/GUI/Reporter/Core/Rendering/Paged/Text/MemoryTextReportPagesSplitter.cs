using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Fd;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text
{
	// Token: 0x02000D7E RID: 3454
	public sealed class MemoryTextReportPagesSplitter : #bGd
	{
		// Token: 0x06007D26 RID: 32038 RVA: 0x001B983C File Offset: 0x001B7A3C
		public MemoryTextReportPagesSplitter(string text)
		{
			this.#a = text.Split(new char[]
			{
				'\f'
			}).Select(new Func<string, TextReportPage>(MemoryTextReportPagesSplitter.<>c.<>9.#NWb)).ToList<TextReportPage>();
		}

		// Token: 0x17002591 RID: 9617
		// (get) Token: 0x06007D27 RID: 32039 RVA: 0x00065AC9 File Offset: 0x00063CC9
		public bool HasNextPage
		{
			get
			{
				return this.#b != this.#a.Count - 1;
			}
		}

		// Token: 0x17002592 RID: 9618
		// (get) Token: 0x06007D28 RID: 32040 RVA: 0x00065AEF File Offset: 0x00063CEF
		// (set) Token: 0x06007D29 RID: 32041 RVA: 0x00065AFB File Offset: 0x00063CFB
		public TextReportPage CurrentPage { get; private set; }

		// Token: 0x06007D2A RID: 32042 RVA: 0x00065B0C File Offset: 0x00063D0C
		public bool #aGd()
		{
			if (this.HasNextPage)
			{
				this.#b++;
				this.CurrentPage = this.#a[this.#b];
				return true;
			}
			return false;
		}

		// Token: 0x0400333E RID: 13118
		private readonly List<TextReportPage> #a;

		// Token: 0x0400333F RID: 13119
		private int #b = -1;

		// Token: 0x04003340 RID: 13120
		[CompilerGenerated]
		private TextReportPage #c;
	}
}

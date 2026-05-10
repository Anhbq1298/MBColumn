using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text
{
	// Token: 0x02000D83 RID: 3459
	public sealed class TextReportPage
	{
		// Token: 0x06007D49 RID: 32073 RVA: 0x00065DE1 File Offset: 0x00063FE1
		public TextReportPage(string content)
		{
			this.Content = content;
		}

		// Token: 0x06007D4A RID: 32074 RVA: 0x000035C3 File Offset: 0x000017C3
		public TextReportPage()
		{
		}

		// Token: 0x17002597 RID: 9623
		// (get) Token: 0x06007D4B RID: 32075 RVA: 0x00065DF0 File Offset: 0x00063FF0
		// (set) Token: 0x06007D4C RID: 32076 RVA: 0x00065DFC File Offset: 0x00063FFC
		public string Content { get; set; }

		// Token: 0x0400334C RID: 13132
		[CompilerGenerated]
		private string #a;
	}
}

using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001059 RID: 4185
	public sealed class TemplateError
	{
		// Token: 0x06008F6D RID: 36717 RVA: 0x00073F8E File Offset: 0x0007218E
		public TemplateError(string templateName, string message)
		{
			this.TemplateName = templateName;
			this.Message = message;
		}

		// Token: 0x06008F6E RID: 36718 RVA: 0x00073FA4 File Offset: 0x000721A4
		public TemplateError(string message)
		{
			this.Message = message;
		}

		// Token: 0x170029C1 RID: 10689
		// (get) Token: 0x06008F6F RID: 36719 RVA: 0x00073FB3 File Offset: 0x000721B3
		public string Message { get; }

		// Token: 0x170029C2 RID: 10690
		// (get) Token: 0x06008F70 RID: 36720 RVA: 0x00073FBB File Offset: 0x000721BB
		// (set) Token: 0x06008F71 RID: 36721 RVA: 0x00073FC3 File Offset: 0x000721C3
		public string TemplateName { get; set; }

		// Token: 0x04003C22 RID: 15394
		[CompilerGenerated]
		private readonly string #a;

		// Token: 0x04003C23 RID: 15395
		[CompilerGenerated]
		private string #b;
	}
}

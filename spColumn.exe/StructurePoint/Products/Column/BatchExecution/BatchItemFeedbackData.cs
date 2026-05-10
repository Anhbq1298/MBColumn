using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.BatchExecution
{
	// Token: 0x020006D5 RID: 1749
	internal sealed class BatchItemFeedbackData : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06003A47 RID: 14919 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public BatchItemFeedbackData()
		{
		}

		// Token: 0x06003A48 RID: 14920 RVA: 0x00032969 File Offset: 0x00030B69
		public BatchItemFeedbackData(string type, Message.EnumType typeRaw, string message)
		{
			this.Type = type;
			this.TypeRaw = typeRaw;
			this.Message = message;
		}

		// Token: 0x170011E6 RID: 4582
		// (get) Token: 0x06003A49 RID: 14921 RVA: 0x00032986 File Offset: 0x00030B86
		// (set) Token: 0x06003A4A RID: 14922 RVA: 0x00032992 File Offset: 0x00030B92
		public string Type { get; set; }

		// Token: 0x170011E7 RID: 4583
		// (get) Token: 0x06003A4B RID: 14923 RVA: 0x000329A3 File Offset: 0x00030BA3
		// (set) Token: 0x06003A4C RID: 14924 RVA: 0x000329AF File Offset: 0x00030BAF
		public Message.EnumType TypeRaw { get; set; }

		// Token: 0x170011E8 RID: 4584
		// (get) Token: 0x06003A4D RID: 14925 RVA: 0x000329C0 File Offset: 0x00030BC0
		// (set) Token: 0x06003A4E RID: 14926 RVA: 0x000329CC File Offset: 0x00030BCC
		public string Message { get; set; }

		// Token: 0x040018CE RID: 6350
		[CompilerGenerated]
		private string #a;

		// Token: 0x040018CF RID: 6351
		[CompilerGenerated]
		private Message.EnumType #b;

		// Token: 0x040018D0 RID: 6352
		[CompilerGenerated]
		private string #c;
	}
}

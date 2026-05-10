using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;

namespace StructurePoint.Products.Column.BatchExecution.Execution
{
	// Token: 0x020006FB RID: 1787
	internal sealed class FormattedMessage
	{
		// Token: 0x06003B3D RID: 15165 RVA: 0x000035C3 File Offset: 0x000017C3
		public FormattedMessage()
		{
		}

		// Token: 0x06003B3E RID: 15166 RVA: 0x000334C4 File Offset: 0x000316C4
		public FormattedMessage(string text, bool isError, bool isWarning, bool isNote, Message message)
		{
			this.Text = text;
			this.IsError = isError;
			this.IsWarning = isWarning;
			this.IsNote = isNote;
			this.Message = message;
		}

		// Token: 0x1700121A RID: 4634
		// (get) Token: 0x06003B3F RID: 15167 RVA: 0x000334F1 File Offset: 0x000316F1
		// (set) Token: 0x06003B40 RID: 15168 RVA: 0x000334FD File Offset: 0x000316FD
		public string Text { get; set; }

		// Token: 0x1700121B RID: 4635
		// (get) Token: 0x06003B41 RID: 15169 RVA: 0x0003350E File Offset: 0x0003170E
		// (set) Token: 0x06003B42 RID: 15170 RVA: 0x0003351A File Offset: 0x0003171A
		public bool IsError { get; set; }

		// Token: 0x1700121C RID: 4636
		// (get) Token: 0x06003B43 RID: 15171 RVA: 0x0003352B File Offset: 0x0003172B
		// (set) Token: 0x06003B44 RID: 15172 RVA: 0x00033537 File Offset: 0x00031737
		public bool IsWarning { get; set; }

		// Token: 0x1700121D RID: 4637
		// (get) Token: 0x06003B45 RID: 15173 RVA: 0x00033548 File Offset: 0x00031748
		// (set) Token: 0x06003B46 RID: 15174 RVA: 0x00033554 File Offset: 0x00031754
		public bool IsNote { get; set; }

		// Token: 0x1700121E RID: 4638
		// (get) Token: 0x06003B47 RID: 15175 RVA: 0x00033565 File Offset: 0x00031765
		// (set) Token: 0x06003B48 RID: 15176 RVA: 0x00033571 File Offset: 0x00031771
		public Message Message { get; set; }

		// Token: 0x06003B49 RID: 15177 RVA: 0x00033582 File Offset: 0x00031782
		public static FormattedMessage #qn(string #5)
		{
			return new FormattedMessage
			{
				Text = #5,
				IsError = true
			};
		}

		// Token: 0x04001949 RID: 6473
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400194A RID: 6474
		[CompilerGenerated]
		private bool #b;

		// Token: 0x0400194B RID: 6475
		[CompilerGenerated]
		private bool #c;

		// Token: 0x0400194C RID: 6476
		[CompilerGenerated]
		private bool #d;

		// Token: 0x0400194D RID: 6477
		[CompilerGenerated]
		private Message #e;
	}
}

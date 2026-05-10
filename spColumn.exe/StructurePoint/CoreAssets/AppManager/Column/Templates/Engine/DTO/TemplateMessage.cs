using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO
{
	// Token: 0x020010A0 RID: 4256
	public sealed class TemplateMessage
	{
		// Token: 0x06009148 RID: 37192 RVA: 0x0007512D File Offset: 0x0007332D
		public TemplateMessage(string message)
		{
			this.Message = message;
		}

		// Token: 0x06009149 RID: 37193 RVA: 0x000035C3 File Offset: 0x000017C3
		public TemplateMessage()
		{
		}

		// Token: 0x17002A49 RID: 10825
		// (get) Token: 0x0600914A RID: 37194 RVA: 0x0007513C File Offset: 0x0007333C
		// (set) Token: 0x0600914B RID: 37195 RVA: 0x00075144 File Offset: 0x00073344
		public string Function { get; set; }

		// Token: 0x17002A4A RID: 10826
		// (get) Token: 0x0600914C RID: 37196 RVA: 0x0007514D File Offset: 0x0007334D
		// (set) Token: 0x0600914D RID: 37197 RVA: 0x00075155 File Offset: 0x00073355
		public string Message { get; set; }

		// Token: 0x17002A4B RID: 10827
		// (get) Token: 0x0600914E RID: 37198 RVA: 0x0007515E File Offset: 0x0007335E
		public string FullMessage
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(this.Function))
				{
					return this.Function + #Phc.#3hc(107382888) + this.Message;
				}
				return this.Message;
			}
		}

		// Token: 0x04003D17 RID: 15639
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003D18 RID: 15640
		[CompilerGenerated]
		private string #b;
	}
}

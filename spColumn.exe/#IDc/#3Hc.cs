using System;
using System.Runtime.CompilerServices;

namespace #IDc
{
	// Token: 0x02000B92 RID: 2962
	internal sealed class #3Hc
	{
		// Token: 0x0600614A RID: 24906 RVA: 0x0004FC77 File Offset: 0x0004DE77
		public #3Hc()
		{
			this.CallerInfo = string.Empty;
			this.FilePath = string.Empty;
		}

		// Token: 0x0600614B RID: 24907 RVA: 0x0004FC95 File Offset: 0x0004DE95
		public #3Hc(string #czc)
		{
			this.CallerInfo = (string.IsNullOrWhiteSpace(#czc) ? string.Empty : #czc);
			this.FilePath = string.Empty;
		}

		// Token: 0x0600614C RID: 24908 RVA: 0x0004FCBE File Offset: 0x0004DEBE
		public #3Hc(string #czc, string #4Hc)
		{
			this.CallerInfo = (string.IsNullOrWhiteSpace(#czc) ? string.Empty : #czc);
			this.FilePath = (string.IsNullOrWhiteSpace(#4Hc) ? string.Empty : #4Hc);
		}

		// Token: 0x17001BB8 RID: 7096
		// (get) Token: 0x0600614D RID: 24909 RVA: 0x0004FCF2 File Offset: 0x0004DEF2
		// (set) Token: 0x0600614E RID: 24910 RVA: 0x0004FCFA File Offset: 0x0004DEFA
		public string CallerInfo { get; set; }

		// Token: 0x17001BB9 RID: 7097
		// (get) Token: 0x0600614F RID: 24911 RVA: 0x0004FD03 File Offset: 0x0004DF03
		// (set) Token: 0x06006150 RID: 24912 RVA: 0x0004FD0B File Offset: 0x0004DF0B
		public string FilePath { get; set; }

		// Token: 0x06006151 RID: 24913 RVA: 0x0004FD14 File Offset: 0x0004DF14
		public static #3Hc #2Hc(string #czc)
		{
			return new #3Hc(#czc);
		}

		// Token: 0x040027D2 RID: 10194
		[CompilerGenerated]
		private string #a;

		// Token: 0x040027D3 RID: 10195
		[CompilerGenerated]
		private string #b;
	}
}

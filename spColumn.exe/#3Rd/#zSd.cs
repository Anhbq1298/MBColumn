using System;
using System.Runtime.CompilerServices;
using #7hc;
using Aspose.Words;

namespace #3Rd
{
	// Token: 0x02000E20 RID: 3616
	internal sealed class #zSd
	{
		// Token: 0x060081FB RID: 33275 RVA: 0x001C34A0 File Offset: 0x001C16A0
		public #zSd(string #UGd, string #Ae, string #pSd, StyleIdentifier #4cd)
		{
			if (#UGd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107276835));
			}
			if (#Ae == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107276854));
			}
			this.Bookmark = #UGd;
			this.Header = #Ae;
			this.DisplayHeader = #pSd;
			this.Style = #4cd;
		}

		// Token: 0x170026CC RID: 9932
		// (get) Token: 0x060081FC RID: 33276 RVA: 0x00069D58 File Offset: 0x00067F58
		// (set) Token: 0x060081FD RID: 33277 RVA: 0x00069D64 File Offset: 0x00067F64
		public string Bookmark { get; private set; }

		// Token: 0x170026CD RID: 9933
		// (get) Token: 0x060081FE RID: 33278 RVA: 0x00069D75 File Offset: 0x00067F75
		// (set) Token: 0x060081FF RID: 33279 RVA: 0x00069D81 File Offset: 0x00067F81
		public string Header { get; private set; }

		// Token: 0x170026CE RID: 9934
		// (get) Token: 0x06008200 RID: 33280 RVA: 0x00069D92 File Offset: 0x00067F92
		// (set) Token: 0x06008201 RID: 33281 RVA: 0x00069D9E File Offset: 0x00067F9E
		public string DisplayHeader { get; private set; }

		// Token: 0x170026CF RID: 9935
		// (get) Token: 0x06008202 RID: 33282 RVA: 0x00069DAF File Offset: 0x00067FAF
		// (set) Token: 0x06008203 RID: 33283 RVA: 0x00069DBB File Offset: 0x00067FBB
		public StyleIdentifier Style { get; private set; }

		// Token: 0x170026D0 RID: 9936
		// (get) Token: 0x06008204 RID: 33284 RVA: 0x00069DCC File Offset: 0x00067FCC
		// (set) Token: 0x06008205 RID: 33285 RVA: 0x00069DD8 File Offset: 0x00067FD8
		public bool IsScreenshoot { get; set; }

		// Token: 0x0400354F RID: 13647
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003550 RID: 13648
		[CompilerGenerated]
		private string #b;

		// Token: 0x04003551 RID: 13649
		[CompilerGenerated]
		private string #c;

		// Token: 0x04003552 RID: 13650
		[CompilerGenerated]
		private StyleIdentifier #d;

		// Token: 0x04003553 RID: 13651
		[CompilerGenerated]
		private bool #e;
	}
}

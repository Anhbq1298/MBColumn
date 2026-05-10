using System;
using System.Runtime.CompilerServices;
using #7hc;
using ClosedXML.Excel;

namespace #QBd
{
	// Token: 0x02000D4D RID: 3405
	internal sealed class #VBd
	{
		// Token: 0x06007BF9 RID: 31737 RVA: 0x00064A11 File Offset: 0x00062C11
		public #VBd(#hCd #odd)
		{
			if (#odd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107254045));
			}
			this.Deformatter = #odd;
			this.Workbook = new XLWorkbook();
		}

		// Token: 0x1700254F RID: 9551
		// (get) Token: 0x06007BFA RID: 31738 RVA: 0x00064A3E File Offset: 0x00062C3E
		// (set) Token: 0x06007BFB RID: 31739 RVA: 0x00064A4A File Offset: 0x00062C4A
		public XLWorkbook Workbook { get; private set; }

		// Token: 0x17002550 RID: 9552
		// (get) Token: 0x06007BFC RID: 31740 RVA: 0x00064A5B File Offset: 0x00062C5B
		// (set) Token: 0x06007BFD RID: 31741 RVA: 0x00064A67 File Offset: 0x00062C67
		public #hCd Deformatter { get; private set; }

		// Token: 0x040032D3 RID: 13011
		[CompilerGenerated]
		private XLWorkbook #a;

		// Token: 0x040032D4 RID: 13012
		[CompilerGenerated]
		private #hCd #b;
	}
}

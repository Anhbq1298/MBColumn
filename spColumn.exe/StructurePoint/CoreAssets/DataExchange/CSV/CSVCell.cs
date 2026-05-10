using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.DataExchange.CSV
{
	// Token: 0x02000783 RID: 1923
	public sealed class CSVCell
	{
		// Token: 0x06003DE9 RID: 15849 RVA: 0x000035C3 File Offset: 0x000017C3
		public CSVCell()
		{
		}

		// Token: 0x06003DEA RID: 15850 RVA: 0x00034ED5 File Offset: 0x000330D5
		public CSVCell(string value)
		{
			this.Value = value;
		}

		// Token: 0x170012DE RID: 4830
		// (get) Token: 0x06003DEB RID: 15851 RVA: 0x00034EE4 File Offset: 0x000330E4
		// (set) Token: 0x06003DEC RID: 15852 RVA: 0x00034EEC File Offset: 0x000330EC
		public string Value { get; set; }

		// Token: 0x04001C23 RID: 7203
		[CompilerGenerated]
		private string #a;
	}
}

using System;
using System.Runtime.CompilerServices;

namespace #Yfc
{
	// Token: 0x0200071D RID: 1821
	internal sealed class #Xfc
	{
		// Token: 0x06003BF1 RID: 15345 RVA: 0x00033BEE File Offset: 0x00031DEE
		public #Xfc(uint? #Zfc)
		{
			this.ErrorCode = #Zfc;
		}

		// Token: 0x06003BF2 RID: 15346 RVA: 0x00033BFD File Offset: 0x00031DFD
		public #Xfc(string #nzb)
		{
			this.ErrorMessage = #nzb;
		}

		// Token: 0x06003BF3 RID: 15347 RVA: 0x000035C3 File Offset: 0x000017C3
		public #Xfc()
		{
		}

		// Token: 0x1700121F RID: 4639
		// (get) Token: 0x06003BF4 RID: 15348 RVA: 0x00033C0C File Offset: 0x00031E0C
		// (set) Token: 0x06003BF5 RID: 15349 RVA: 0x00033C18 File Offset: 0x00031E18
		public uint? ErrorCode { get; set; }

		// Token: 0x17001220 RID: 4640
		// (get) Token: 0x06003BF6 RID: 15350 RVA: 0x00033C29 File Offset: 0x00031E29
		// (set) Token: 0x06003BF7 RID: 15351 RVA: 0x00033C35 File Offset: 0x00031E35
		public string ErrorMessage { get; set; }

		// Token: 0x06003BF8 RID: 15352 RVA: 0x00119178 File Offset: 0x00117378
		public bool #Wfc()
		{
			uint? num;
			if (!false)
			{
				num = this.ErrorCode;
			}
			if (7 == 0)
			{
				goto IL_21;
			}
			int num3;
			int num2 = num3 = 0;
			if (num2 == 0)
			{
				uint num4 = (uint)num2;
				num3 = ((num.GetValueOrDefault() == num4) ? 1 : 0);
			}
			IL_1A:
			if ((num3 & ((num != null) ? 1 : 0)) == 0)
			{
				return false;
			}
			IL_21:
			bool result = (num3 = (\u0003.\u0004(this.ErrorMessage) ? 1 : 0)) != 0;
			if (!false)
			{
				return result;
			}
			goto IL_1A;
		}

		// Token: 0x04001B1F RID: 6943
		[CompilerGenerated]
		private uint? #a;

		// Token: 0x04001B20 RID: 6944
		[CompilerGenerated]
		private string #b;
	}
}

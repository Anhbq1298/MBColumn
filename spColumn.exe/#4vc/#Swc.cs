using System;
using System.Runtime.CompilerServices;

namespace #4vc
{
	// Token: 0x0200081A RID: 2074
	internal class #Swc<#Zoc> : #hwc<!0>
	{
		// Token: 0x06004292 RID: 17042 RVA: 0x000035C3 File Offset: 0x000017C3
		public #Swc()
		{
		}

		// Token: 0x06004293 RID: 17043 RVA: 0x00037E36 File Offset: 0x00036036
		public #Swc(#Zoc #Akb, #Zoc #Bkb)
		{
			this.Start = #Akb;
			this.End = #Bkb;
		}

		// Token: 0x170013A6 RID: 5030
		// (get) Token: 0x06004294 RID: 17044 RVA: 0x00037E4C File Offset: 0x0003604C
		// (set) Token: 0x06004295 RID: 17045 RVA: 0x00037E58 File Offset: 0x00036058
		public #Zoc Start { get; set; }

		// Token: 0x170013A7 RID: 5031
		// (get) Token: 0x06004296 RID: 17046 RVA: 0x00037E69 File Offset: 0x00036069
		// (set) Token: 0x06004297 RID: 17047 RVA: 0x00037E75 File Offset: 0x00036075
		public #Zoc End { get; set; }

		// Token: 0x06004298 RID: 17048 RVA: 0x00037E86 File Offset: 0x00036086
		public virtual #hwc<#Zoc> #ul(#Zoc #Akb, #Zoc #Bkb)
		{
			return new #Swc<!0>(#Akb, #Bkb);
		}

		// Token: 0x04001E01 RID: 7681
		[CompilerGenerated]
		private #Zoc #a;

		// Token: 0x04001E02 RID: 7682
		[CompilerGenerated]
		private #Zoc #b;
	}
}

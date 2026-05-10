using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x0200077C RID: 1916
	internal sealed class #mkc : #ijc, IPoint
	{
		// Token: 0x170012C1 RID: 4801
		// (get) Token: 0x06003DA9 RID: 15785 RVA: 0x00034BE5 File Offset: 0x00032DE5
		// (set) Token: 0x06003DAA RID: 15786 RVA: 0x00034BED File Offset: 0x00032DED
		public double X { get; set; }

		// Token: 0x170012C2 RID: 4802
		// (get) Token: 0x06003DAB RID: 15787 RVA: 0x00034BF6 File Offset: 0x00032DF6
		// (set) Token: 0x06003DAC RID: 15788 RVA: 0x00034BFE File Offset: 0x00032DFE
		public double Y { get; set; }

		// Token: 0x170012C3 RID: 4803
		// (get) Token: 0x06003DAD RID: 15789 RVA: 0x00034C07 File Offset: 0x00032E07
		// (set) Token: 0x06003DAE RID: 15790 RVA: 0x00034C0F File Offset: 0x00032E0F
		public double Z { get; set; }

		// Token: 0x170012C4 RID: 4804
		// (get) Token: 0x06003DAF RID: 15791 RVA: 0x00034C18 File Offset: 0x00032E18
		// (set) Token: 0x06003DB0 RID: 15792 RVA: 0x00034C20 File Offset: 0x00032E20
		public #jjc Layer { get; set; }

		// Token: 0x06003DB1 RID: 15793 RVA: 0x00034C29 File Offset: 0x00032E29
		public #mkc(double #9o, double #7W, double #kdc, #fkc #rR)
		{
			this.X = #9o;
			this.Y = #7W;
			this.Z = #kdc;
			this.Layer = #rR;
		}

		// Token: 0x04001C08 RID: 7176
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001C09 RID: 7177
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001C0A RID: 7178
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001C0B RID: 7179
		[CompilerGenerated]
		private #jjc #d;
	}
}

using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000772 RID: 1906
	internal sealed class #Zjc : #ijc, #tjc
	{
		// Token: 0x17001290 RID: 4752
		// (get) Token: 0x06003D52 RID: 15698 RVA: 0x00034824 File Offset: 0x00032A24
		// (set) Token: 0x06003D53 RID: 15699 RVA: 0x0003482C File Offset: 0x00032A2C
		public IPoint CenterPoint { get; set; }

		// Token: 0x17001291 RID: 4753
		// (get) Token: 0x06003D54 RID: 15700 RVA: 0x00034835 File Offset: 0x00032A35
		// (set) Token: 0x06003D55 RID: 15701 RVA: 0x0003483D File Offset: 0x00032A3D
		public double Radius { get; set; }

		// Token: 0x17001292 RID: 4754
		// (get) Token: 0x06003D56 RID: 15702 RVA: 0x00034846 File Offset: 0x00032A46
		// (set) Token: 0x06003D57 RID: 15703 RVA: 0x0003484E File Offset: 0x00032A4E
		public #jjc Layer { get; set; }

		// Token: 0x06003D58 RID: 15704 RVA: 0x00034857 File Offset: 0x00032A57
		public #Zjc(#mkc #Wjc, double #HS, #fkc #rR)
		{
			this.CenterPoint = #Wjc;
			this.Radius = #HS;
			this.Layer = #rR;
		}

		// Token: 0x04001BD7 RID: 7127
		[CompilerGenerated]
		private IPoint #a;

		// Token: 0x04001BD8 RID: 7128
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001BD9 RID: 7129
		[CompilerGenerated]
		private #jjc #c;
	}
}

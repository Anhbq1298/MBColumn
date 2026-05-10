using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000771 RID: 1905
	internal sealed class #Ujc : #ijc, #sjc
	{
		// Token: 0x1700128B RID: 4747
		// (get) Token: 0x06003D47 RID: 15687 RVA: 0x000347A2 File Offset: 0x000329A2
		// (set) Token: 0x06003D48 RID: 15688 RVA: 0x000347AA File Offset: 0x000329AA
		public IPoint CenterPoint { get; set; }

		// Token: 0x1700128C RID: 4748
		// (get) Token: 0x06003D49 RID: 15689 RVA: 0x000347B3 File Offset: 0x000329B3
		// (set) Token: 0x06003D4A RID: 15690 RVA: 0x000347BB File Offset: 0x000329BB
		public double EndAngle { get; set; }

		// Token: 0x1700128D RID: 4749
		// (get) Token: 0x06003D4B RID: 15691 RVA: 0x000347C4 File Offset: 0x000329C4
		// (set) Token: 0x06003D4C RID: 15692 RVA: 0x000347CC File Offset: 0x000329CC
		public double Radius { get; set; }

		// Token: 0x1700128E RID: 4750
		// (get) Token: 0x06003D4D RID: 15693 RVA: 0x000347D5 File Offset: 0x000329D5
		// (set) Token: 0x06003D4E RID: 15694 RVA: 0x000347DD File Offset: 0x000329DD
		public double StartAngle { get; set; }

		// Token: 0x1700128F RID: 4751
		// (get) Token: 0x06003D4F RID: 15695 RVA: 0x000347E6 File Offset: 0x000329E6
		// (set) Token: 0x06003D50 RID: 15696 RVA: 0x000347EE File Offset: 0x000329EE
		public #jjc Layer { get; set; }

		// Token: 0x06003D51 RID: 15697 RVA: 0x000347F7 File Offset: 0x000329F7
		public #Ujc(#mkc #Wjc, double #HS, double #Xjc, double #Yjc, #fkc #rR)
		{
			this.CenterPoint = #Wjc;
			this.Radius = #HS;
			this.StartAngle = #Xjc;
			this.EndAngle = #Yjc;
			this.Layer = #rR;
		}

		// Token: 0x04001BD2 RID: 7122
		[CompilerGenerated]
		private IPoint #a;

		// Token: 0x04001BD3 RID: 7123
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001BD4 RID: 7124
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001BD5 RID: 7125
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001BD6 RID: 7126
		[CompilerGenerated]
		private #jjc #e;
	}
}

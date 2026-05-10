using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000776 RID: 1910
	internal sealed class #akc : #fjc, #ijc
	{
		// Token: 0x1700129C RID: 4764
		// (get) Token: 0x06003D69 RID: 15721 RVA: 0x00034947 File Offset: 0x00032B47
		// (set) Token: 0x06003D6A RID: 15722 RVA: 0x0003494F File Offset: 0x00032B4F
		public IPoint CenterPoint { get; set; }

		// Token: 0x1700129D RID: 4765
		// (get) Token: 0x06003D6B RID: 15723 RVA: 0x00034958 File Offset: 0x00032B58
		// (set) Token: 0x06003D6C RID: 15724 RVA: 0x00034960 File Offset: 0x00032B60
		public double EndAngle { get; set; }

		// Token: 0x1700129E RID: 4766
		// (get) Token: 0x06003D6D RID: 15725 RVA: 0x00034969 File Offset: 0x00032B69
		// (set) Token: 0x06003D6E RID: 15726 RVA: 0x00034971 File Offset: 0x00032B71
		public double MajorAxisLength { get; set; }

		// Token: 0x1700129F RID: 4767
		// (get) Token: 0x06003D6F RID: 15727 RVA: 0x0003497A File Offset: 0x00032B7A
		// (set) Token: 0x06003D70 RID: 15728 RVA: 0x00034982 File Offset: 0x00032B82
		public double MinorAxisLength { get; set; }

		// Token: 0x170012A0 RID: 4768
		// (get) Token: 0x06003D71 RID: 15729 RVA: 0x0003498B File Offset: 0x00032B8B
		// (set) Token: 0x06003D72 RID: 15730 RVA: 0x00034993 File Offset: 0x00032B93
		public double StartAngle { get; set; }

		// Token: 0x170012A1 RID: 4769
		// (get) Token: 0x06003D73 RID: 15731 RVA: 0x0003499C File Offset: 0x00032B9C
		// (set) Token: 0x06003D74 RID: 15732 RVA: 0x000349A4 File Offset: 0x00032BA4
		public double MajorAxisAngle { get; set; }

		// Token: 0x170012A2 RID: 4770
		// (get) Token: 0x06003D75 RID: 15733 RVA: 0x000349AD File Offset: 0x00032BAD
		// (set) Token: 0x06003D76 RID: 15734 RVA: 0x000349B5 File Offset: 0x00032BB5
		public #jjc Layer { get; set; }

		// Token: 0x06003D77 RID: 15735 RVA: 0x000349BE File Offset: 0x00032BBE
		public #akc(#mkc #Wjc, double #bkc, double #ckc, double #dkc, double #Xjc, double #Yjc, #fkc #rR)
		{
			this.CenterPoint = #Wjc;
			this.MajorAxisLength = #bkc;
			this.MinorAxisLength = #ckc;
			this.MajorAxisAngle = #dkc;
			this.StartAngle = #Xjc;
			this.EndAngle = #Yjc;
			this.Layer = #rR;
		}

		// Token: 0x04001BE3 RID: 7139
		[CompilerGenerated]
		private IPoint #a;

		// Token: 0x04001BE4 RID: 7140
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001BE5 RID: 7141
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001BE6 RID: 7142
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001BE7 RID: 7143
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001BE8 RID: 7144
		[CompilerGenerated]
		private double #f;

		// Token: 0x04001BE9 RID: 7145
		[CompilerGenerated]
		private #jjc #g;
	}
}

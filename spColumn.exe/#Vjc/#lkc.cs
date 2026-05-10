using System;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x0200077B RID: 1915
	internal sealed class #lkc : #ijc
	{
		// Token: 0x170012BB RID: 4795
		// (get) Token: 0x06003D9C RID: 15772 RVA: 0x00034B52 File Offset: 0x00032D52
		// (set) Token: 0x06003D9D RID: 15773 RVA: 0x00034B5A File Offset: 0x00032D5A
		public string Text { get; set; }

		// Token: 0x170012BC RID: 4796
		// (get) Token: 0x06003D9E RID: 15774 RVA: 0x00034B63 File Offset: 0x00032D63
		// (set) Token: 0x06003D9F RID: 15775 RVA: 0x00034B6B File Offset: 0x00032D6B
		public #mkc Position { get; set; }

		// Token: 0x170012BD RID: 4797
		// (get) Token: 0x06003DA0 RID: 15776 RVA: 0x00034B74 File Offset: 0x00032D74
		// (set) Token: 0x06003DA1 RID: 15777 RVA: 0x00034B7C File Offset: 0x00032D7C
		public double Height { get; set; }

		// Token: 0x170012BE RID: 4798
		// (get) Token: 0x06003DA2 RID: 15778 RVA: 0x00034B85 File Offset: 0x00032D85
		// (set) Token: 0x06003DA3 RID: 15779 RVA: 0x00034B8D File Offset: 0x00032D8D
		public double Angle { get; set; }

		// Token: 0x170012BF RID: 4799
		// (get) Token: 0x06003DA4 RID: 15780 RVA: 0x00034B96 File Offset: 0x00032D96
		// (set) Token: 0x06003DA5 RID: 15781 RVA: 0x00034B9E File Offset: 0x00032D9E
		public byte Alignment { get; set; }

		// Token: 0x170012C0 RID: 4800
		// (get) Token: 0x06003DA6 RID: 15782 RVA: 0x00034BA7 File Offset: 0x00032DA7
		// (set) Token: 0x06003DA7 RID: 15783 RVA: 0x00034BAF File Offset: 0x00032DAF
		public #jjc Layer { get; set; }

		// Token: 0x06003DA8 RID: 15784 RVA: 0x00034BB8 File Offset: 0x00032DB8
		public #lkc(string #hvb, #mkc #0bb, double #YW, double #Udb, #fkc #rR)
		{
			this.Text = #hvb;
			this.Position = #0bb;
			this.Height = #YW;
			this.Angle = #Udb;
			this.Layer = #rR;
		}

		// Token: 0x04001C02 RID: 7170
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001C03 RID: 7171
		[CompilerGenerated]
		private #mkc #b;

		// Token: 0x04001C04 RID: 7172
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001C05 RID: 7173
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001C06 RID: 7174
		[CompilerGenerated]
		private byte #e;

		// Token: 0x04001C07 RID: 7175
		[CompilerGenerated]
		private #jjc #f;
	}
}

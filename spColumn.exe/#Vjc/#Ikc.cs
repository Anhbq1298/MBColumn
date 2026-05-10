using System;
using System.Runtime.CompilerServices;
using #2ic;

namespace #Vjc
{
	// Token: 0x02000780 RID: 1920
	internal sealed class #Ikc : #ijc
	{
		// Token: 0x170012D1 RID: 4817
		// (get) Token: 0x06003DCB RID: 15819 RVA: 0x00034D7A File Offset: 0x00032F7A
		// (set) Token: 0x06003DCC RID: 15820 RVA: 0x00034D82 File Offset: 0x00032F82
		public string Text { get; set; }

		// Token: 0x170012D2 RID: 4818
		// (get) Token: 0x06003DCD RID: 15821 RVA: 0x00034D8B File Offset: 0x00032F8B
		// (set) Token: 0x06003DCE RID: 15822 RVA: 0x00034D93 File Offset: 0x00032F93
		public #mkc Position { get; set; }

		// Token: 0x170012D3 RID: 4819
		// (get) Token: 0x06003DCF RID: 15823 RVA: 0x00034D9C File Offset: 0x00032F9C
		// (set) Token: 0x06003DD0 RID: 15824 RVA: 0x00034DA4 File Offset: 0x00032FA4
		public string Font { get; set; }

		// Token: 0x170012D4 RID: 4820
		// (get) Token: 0x06003DD1 RID: 15825 RVA: 0x00034DAD File Offset: 0x00032FAD
		// (set) Token: 0x06003DD2 RID: 15826 RVA: 0x00034DB5 File Offset: 0x00032FB5
		public double Height { get; set; }

		// Token: 0x170012D5 RID: 4821
		// (get) Token: 0x06003DD3 RID: 15827 RVA: 0x00034DBE File Offset: 0x00032FBE
		// (set) Token: 0x06003DD4 RID: 15828 RVA: 0x00034DC6 File Offset: 0x00032FC6
		public double Angle { get; set; }

		// Token: 0x170012D6 RID: 4822
		// (get) Token: 0x06003DD5 RID: 15829 RVA: 0x00034DCF File Offset: 0x00032FCF
		// (set) Token: 0x06003DD6 RID: 15830 RVA: 0x00034DD7 File Offset: 0x00032FD7
		public byte HorizontalAlignment { get; set; }

		// Token: 0x170012D7 RID: 4823
		// (get) Token: 0x06003DD7 RID: 15831 RVA: 0x00034DE0 File Offset: 0x00032FE0
		// (set) Token: 0x06003DD8 RID: 15832 RVA: 0x00034DE8 File Offset: 0x00032FE8
		public byte VerticalAlignment { get; set; }

		// Token: 0x170012D8 RID: 4824
		// (get) Token: 0x06003DD9 RID: 15833 RVA: 0x00034DF1 File Offset: 0x00032FF1
		// (set) Token: 0x06003DDA RID: 15834 RVA: 0x00034DF9 File Offset: 0x00032FF9
		public #jjc Layer { get; set; }

		// Token: 0x06003DDB RID: 15835 RVA: 0x00034E02 File Offset: 0x00033002
		public #Ikc(string #hvb, #mkc #0bb, string #Avb, double #YW, double #Udb, #fkc #rR)
		{
			this.Text = #hvb;
			this.Position = #0bb;
			this.Font = #Avb;
			this.Height = #YW;
			this.Angle = #Udb;
			this.Layer = #rR;
		}

		// Token: 0x04001C16 RID: 7190
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001C17 RID: 7191
		[CompilerGenerated]
		private #mkc #b;

		// Token: 0x04001C18 RID: 7192
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001C19 RID: 7193
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001C1A RID: 7194
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001C1B RID: 7195
		[CompilerGenerated]
		private byte #f;

		// Token: 0x04001C1C RID: 7196
		[CompilerGenerated]
		private byte #g;

		// Token: 0x04001C1D RID: 7197
		[CompilerGenerated]
		private #jjc #h;
	}
}

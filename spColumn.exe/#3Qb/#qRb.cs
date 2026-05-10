using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Core;

namespace #3Qb
{
	// Token: 0x020006C3 RID: 1731
	internal sealed class #qRb
	{
		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x06003985 RID: 14725 RVA: 0x00031EA6 File Offset: 0x000300A6
		public static #qRb Default { get; }

		// Token: 0x170011AE RID: 4526
		// (get) Token: 0x06003986 RID: 14726 RVA: 0x00031EAD File Offset: 0x000300AD
		// (set) Token: 0x06003987 RID: 14727 RVA: 0x00031EB9 File Offset: 0x000300B9
		public Color TextColor { get; set; }

		// Token: 0x170011AF RID: 4527
		// (get) Token: 0x06003988 RID: 14728 RVA: 0x00031ECA File Offset: 0x000300CA
		// (set) Token: 0x06003989 RID: 14729 RVA: 0x00031ED6 File Offset: 0x000300D6
		public int LabelSize { get; set; }

		// Token: 0x170011B0 RID: 4528
		// (get) Token: 0x0600398A RID: 14730 RVA: 0x00031EE7 File Offset: 0x000300E7
		// (set) Token: 0x0600398B RID: 14731 RVA: 0x00031EF3 File Offset: 0x000300F3
		public Color DimensionsColor { get; set; }

		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x0600398C RID: 14732 RVA: 0x00031F04 File Offset: 0x00030104
		// (set) Token: 0x0600398D RID: 14733 RVA: 0x00031F10 File Offset: 0x00030110
		public Color SolidColor { get; set; }

		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x0600398E RID: 14734 RVA: 0x00031F21 File Offset: 0x00030121
		// (set) Token: 0x0600398F RID: 14735 RVA: 0x00031F2D File Offset: 0x0003012D
		public Color OpeningColor { get; set; }

		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x06003990 RID: 14736 RVA: 0x00031F3E File Offset: 0x0003013E
		// (set) Token: 0x06003991 RID: 14737 RVA: 0x00031F4A File Offset: 0x0003014A
		public Color BarPointColor { get; set; }

		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x06003992 RID: 14738 RVA: 0x00031F5B File Offset: 0x0003015B
		// (set) Token: 0x06003993 RID: 14739 RVA: 0x00031F67 File Offset: 0x00030167
		public Color BarAreaColor { get; set; }

		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x06003994 RID: 14740 RVA: 0x00031F78 File Offset: 0x00030178
		// (set) Token: 0x06003995 RID: 14741 RVA: 0x00031F84 File Offset: 0x00030184
		public Color BarLrPointColor { get; set; }

		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x06003996 RID: 14742 RVA: 0x00031F95 File Offset: 0x00030195
		// (set) Token: 0x06003997 RID: 14743 RVA: 0x00031FA1 File Offset: 0x000301A1
		public Color BarLrAreaColor { get; set; }

		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x06003998 RID: 14744 RVA: 0x00031FB2 File Offset: 0x000301B2
		// (set) Token: 0x06003999 RID: 14745 RVA: 0x00031FBE File Offset: 0x000301BE
		public bool CoverVisibility { get; set; }

		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x0600399A RID: 14746 RVA: 0x00031FCF File Offset: 0x000301CF
		// (set) Token: 0x0600399B RID: 14747 RVA: 0x00031FDB File Offset: 0x000301DB
		public bool SectionAnnotationsVisibility { get; set; }

		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x0600399C RID: 14748 RVA: 0x00031FEC File Offset: 0x000301EC
		// (set) Token: 0x0600399D RID: 14749 RVA: 0x00031FF8 File Offset: 0x000301F8
		public LineType CoverLineType { get; set; }

		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x0600399E RID: 14750 RVA: 0x00032009 File Offset: 0x00030209
		// (set) Token: 0x0600399F RID: 14751 RVA: 0x00032015 File Offset: 0x00030215
		public Color CoverLineColor { get; set; }

		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x060039A0 RID: 14752 RVA: 0x00032026 File Offset: 0x00030226
		// (set) Token: 0x060039A1 RID: 14753 RVA: 0x00032032 File Offset: 0x00030232
		public Color MainGridLineColor { get; set; }

		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x060039A2 RID: 14754 RVA: 0x00032043 File Offset: 0x00030243
		// (set) Token: 0x060039A3 RID: 14755 RVA: 0x0003204F File Offset: 0x0003024F
		public Color GridLineColor { get; set; }

		// Token: 0x060039A4 RID: 14756 RVA: 0x00032060 File Offset: 0x00030260
		public void #oRb(#3se #pRb)
		{
			#pRb.SectionColor = this.SolidColor;
			#pRb.LeftRightBarColor = this.BarLrAreaColor;
			#pRb.OpeningColor = this.OpeningColor;
			#pRb.BarColor = this.BarAreaColor;
		}

		// Token: 0x060039A5 RID: 14757 RVA: 0x001124A8 File Offset: 0x001106A8
		public void #mg(#qRb #L0)
		{
			this.TextColor = #L0.TextColor;
			this.LabelSize = #L0.LabelSize;
			this.DimensionsColor = #L0.DimensionsColor;
			this.SolidColor = #L0.SolidColor;
			this.OpeningColor = #L0.OpeningColor;
			this.BarPointColor = #L0.BarPointColor;
			this.BarAreaColor = #L0.BarAreaColor;
			this.BarLrPointColor = #L0.BarLrPointColor;
			this.BarLrAreaColor = #L0.BarLrAreaColor;
			this.CoverVisibility = #L0.CoverVisibility;
			this.SectionAnnotationsVisibility = #L0.SectionAnnotationsVisibility;
			this.CoverLineType = #L0.CoverLineType;
			this.CoverLineColor = #L0.CoverLineColor;
			this.MainGridLineColor = #L0.MainGridLineColor;
			this.GridLineColor = #L0.GridLineColor;
		}

		// Token: 0x060039A7 RID: 14759 RVA: 0x00112588 File Offset: 0x00110788
		// Note: this type is marked as 'beforefieldinit'.
		static #qRb()
		{
			#qRb #qRb = new #qRb();
			#qRb.TextColor = Colors.Black;
			#qRb.LabelSize = 12;
			#qRb.DimensionsColor = Colors.Black;
			byte a = 128;
			Color color = Colors.DarkGray;
			byte r = color.R;
			color = Colors.DarkGray;
			byte g = color.G;
			color = Colors.DarkGray;
			#qRb.SolidColor = Color.FromArgb(a, r, g, color.B);
			byte a2 = 128;
			color = Colors.LightCyan;
			byte r2 = color.R;
			color = Colors.LightCyan;
			byte g2 = color.G;
			color = Colors.LightCyan;
			#qRb.OpeningColor = Color.FromArgb(a2, r2, g2, color.B);
			#qRb.BarPointColor = Colors.Black;
			#qRb.BarAreaColor = Colors.Black;
			#qRb.BarLrPointColor = Color.FromArgb(byte.MaxValue, 0, 159, byte.MaxValue);
			#qRb.BarLrAreaColor = Color.FromArgb(byte.MaxValue, 0, 159, byte.MaxValue);
			#qRb.CoverVisibility = true;
			#qRb.SectionAnnotationsVisibility = true;
			#qRb.CoverLineType = LineType.Dashed;
			#qRb.CoverLineColor = Color.FromArgb(byte.MaxValue, byte.MaxValue, 130, 130);
			#qRb.GridLineColor = Color.FromArgb(byte.MaxValue, 222, 237, byte.MaxValue);
			#qRb.MainGridLineColor = Color.FromArgb(byte.MaxValue, 179, 212, byte.MaxValue);
			#qRb.Default = #qRb;
		}

		// Token: 0x04001866 RID: 6246
		[CompilerGenerated]
		private static readonly #qRb #a;

		// Token: 0x04001867 RID: 6247
		[CompilerGenerated]
		private Color #b;

		// Token: 0x04001868 RID: 6248
		[CompilerGenerated]
		private int #c;

		// Token: 0x04001869 RID: 6249
		[CompilerGenerated]
		private Color #d;

		// Token: 0x0400186A RID: 6250
		[CompilerGenerated]
		private Color #e;

		// Token: 0x0400186B RID: 6251
		[CompilerGenerated]
		private Color #f;

		// Token: 0x0400186C RID: 6252
		[CompilerGenerated]
		private Color #g;

		// Token: 0x0400186D RID: 6253
		[CompilerGenerated]
		private Color #h;

		// Token: 0x0400186E RID: 6254
		[CompilerGenerated]
		private Color #i;

		// Token: 0x0400186F RID: 6255
		[CompilerGenerated]
		private Color #j;

		// Token: 0x04001870 RID: 6256
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04001871 RID: 6257
		[CompilerGenerated]
		private bool #l;

		// Token: 0x04001872 RID: 6258
		[CompilerGenerated]
		private LineType #m;

		// Token: 0x04001873 RID: 6259
		[CompilerGenerated]
		private Color #n;

		// Token: 0x04001874 RID: 6260
		[CompilerGenerated]
		private Color #o;

		// Token: 0x04001875 RID: 6261
		[CompilerGenerated]
		private Color #p;
	}
}

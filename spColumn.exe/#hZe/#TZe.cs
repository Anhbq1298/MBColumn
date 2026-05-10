using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001324 RID: 4900
	[DebuggerDisplay("P={AxialLoad}, Mx={MomentX}, My={MomentY}")]
	internal struct #TZe
	{
		// Token: 0x17002EE9 RID: 12009
		// (get) Token: 0x0600A395 RID: 41877 RVA: 0x0007FC81 File Offset: 0x0007DE81
		// (set) Token: 0x0600A396 RID: 41878 RVA: 0x0007FC89 File Offset: 0x0007DE89
		public float AxialLoad { readonly get; set; }

		// Token: 0x17002EEA RID: 12010
		// (get) Token: 0x0600A397 RID: 41879 RVA: 0x0007FC92 File Offset: 0x0007DE92
		// (set) Token: 0x0600A398 RID: 41880 RVA: 0x0007FC9A File Offset: 0x0007DE9A
		public float AbsoluteMomentMagnitudeR { readonly get; set; }

		// Token: 0x17002EEB RID: 12011
		// (get) Token: 0x0600A399 RID: 41881 RVA: 0x0007FCA3 File Offset: 0x0007DEA3
		// (set) Token: 0x0600A39A RID: 41882 RVA: 0x0007FCAB File Offset: 0x0007DEAB
		public float MomentX { readonly get; set; }

		// Token: 0x17002EEC RID: 12012
		// (get) Token: 0x0600A39B RID: 41883 RVA: 0x0007FCB4 File Offset: 0x0007DEB4
		// (set) Token: 0x0600A39C RID: 41884 RVA: 0x0007FCBC File Offset: 0x0007DEBC
		public float MomentY { readonly get; set; }

		// Token: 0x0600A39D RID: 41885 RVA: 0x0022EBFC File Offset: 0x0022CDFC
		public static #TZe #Dge(#E2e #SZe)
		{
			return new #TZe
			{
				AxialLoad = #SZe.AxialLoad,
				MomentX = #SZe.Moment,
				MomentY = 0f
			};
		}

		// Token: 0x0600A39E RID: 41886 RVA: 0x0022EC3C File Offset: 0x0022CE3C
		public static #TZe #Dge(#E2e #SZe, float #Udb)
		{
			return new #TZe
			{
				AxialLoad = #SZe.AxialLoad,
				AbsoluteMomentMagnitudeR = #SZe.Moment,
				MomentX = #SZe.Moment * (float)Math.Cos((double)(#Udb * 3.1415927f / 180f)),
				MomentY = #SZe.Moment * (float)Math.Sin((double)(#Udb * 3.1415927f / 180f))
			};
		}

		// Token: 0x0600A39F RID: 41887 RVA: 0x0022ECB4 File Offset: 0x0022CEB4
		public static #TZe #Dge(#IZe #SZe)
		{
			return new #TZe
			{
				AxialLoad = #SZe.UltimateAxialLoad,
				MomentX = #SZe.UltimateMomentX,
				MomentY = #SZe.UltimateMomentY,
				AbsoluteMomentMagnitudeR = #SZe.UltimateMomentR
			};
		}

		// Token: 0x0600A3A0 RID: 41888 RVA: 0x0007FCC5 File Offset: 0x0007DEC5
		public void #SWi(ref #E2e #SZe)
		{
			this.AxialLoad = #SZe.AxialLoad;
			this.MomentX = #SZe.Moment;
			this.MomentY = 0f;
		}

		// Token: 0x0600A3A1 RID: 41889 RVA: 0x0007FCEA File Offset: 0x0007DEEA
		public void #SWi(ref #IZe #SZe)
		{
			this.AxialLoad = #SZe.UltimateAxialLoad;
			this.MomentX = #SZe.UltimateMomentX;
			this.MomentY = #SZe.UltimateMomentY;
			this.AbsoluteMomentMagnitudeR = #SZe.UltimateMomentR;
		}

		// Token: 0x0600A3A2 RID: 41890 RVA: 0x0007FD1C File Offset: 0x0007DF1C
		public void #M3d(ref #E2e #SZe)
		{
			this.AxialLoad -= #SZe.AxialLoad;
			this.MomentX -= #SZe.Moment;
		}

		// Token: 0x0600A3A3 RID: 41891 RVA: 0x0007FD44 File Offset: 0x0007DF44
		public void #vzc(ref #E2e #SZe)
		{
			this.AxialLoad += #SZe.AxialLoad;
			this.MomentX += #SZe.Moment;
		}

		// Token: 0x0600A3A4 RID: 41892 RVA: 0x0022ED04 File Offset: 0x0022CF04
		public void #M3d(ref #IZe #SZe)
		{
			this.AxialLoad -= #SZe.UltimateAxialLoad;
			this.MomentX -= #SZe.UltimateMomentX;
			this.MomentY -= #SZe.UltimateMomentY;
			this.AbsoluteMomentMagnitudeR -= #SZe.UltimateMomentR;
		}

		// Token: 0x0600A3A5 RID: 41893 RVA: 0x0022ED60 File Offset: 0x0022CF60
		public void #vzc(ref #IZe #SZe)
		{
			this.AxialLoad += #SZe.UltimateAxialLoad;
			this.MomentX += #SZe.UltimateMomentX;
			this.MomentY += #SZe.UltimateMomentY;
			this.AbsoluteMomentMagnitudeR += #SZe.UltimateMomentR;
		}

		// Token: 0x040047B2 RID: 18354
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047B3 RID: 18355
		[CompilerGenerated]
		private float #b;

		// Token: 0x040047B4 RID: 18356
		[CompilerGenerated]
		private float #c;

		// Token: 0x040047B5 RID: 18357
		[CompilerGenerated]
		private float #d;
	}
}

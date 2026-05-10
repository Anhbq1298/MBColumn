using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace #3Rd
{
	// Token: 0x02000E31 RID: 3633
	internal sealed class #sTd
	{
		// Token: 0x06008258 RID: 33368 RVA: 0x001C3BA4 File Offset: 0x001C1DA4
		public #sTd(SvgDocument #tTd)
		{
			if (#tTd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107277166));
			}
			this.Document = #tTd;
			this.ActualHeight = (double)#tTd.Height.Value;
			this.ActualWidth = (double)#tTd.Width.Value;
		}

		// Token: 0x06008259 RID: 33369 RVA: 0x0006A215 File Offset: 0x00068415
		public #sTd(SvgDocument #tTd, double #6Q, double #YW)
		{
			if (#tTd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107277166));
			}
			this.Document = #tTd;
			this.ActualHeight = #YW;
			this.ActualWidth = #6Q;
		}

		// Token: 0x0600825A RID: 33370 RVA: 0x0006A245 File Offset: 0x00068445
		public #sTd(SvgDocument #uTd, Size #hNb) : this(#uTd, #hNb.Width, #hNb.Height)
		{
		}

		// Token: 0x170026E9 RID: 9961
		// (get) Token: 0x0600825B RID: 33371 RVA: 0x0006A25C File Offset: 0x0006845C
		// (set) Token: 0x0600825C RID: 33372 RVA: 0x0006A268 File Offset: 0x00068468
		public SvgDocument Document { get; private set; }

		// Token: 0x170026EA RID: 9962
		// (get) Token: 0x0600825D RID: 33373 RVA: 0x0006A279 File Offset: 0x00068479
		public Size ActualSize
		{
			get
			{
				return new Size(this.ActualWidth, this.ActualHeight);
			}
		}

		// Token: 0x170026EB RID: 9963
		// (get) Token: 0x0600825E RID: 33374 RVA: 0x0006A298 File Offset: 0x00068498
		public string SvgString
		{
			get
			{
				if (\u0003.\u0004(this.#b))
				{
					this.#b = \u009C\u0006.\u009E\u0010(this.Document);
				}
				return this.#b;
			}
		}

		// Token: 0x170026EC RID: 9964
		// (get) Token: 0x0600825F RID: 33375 RVA: 0x0006A2D4 File Offset: 0x000684D4
		// (set) Token: 0x06008260 RID: 33376 RVA: 0x0006A2E0 File Offset: 0x000684E0
		public double ActualWidth { get; private set; }

		// Token: 0x170026ED RID: 9965
		// (get) Token: 0x06008261 RID: 33377 RVA: 0x0006A2F1 File Offset: 0x000684F1
		// (set) Token: 0x06008262 RID: 33378 RVA: 0x0006A2FD File Offset: 0x000684FD
		public double ActualHeight { get; private set; }

		// Token: 0x170026EE RID: 9966
		// (get) Token: 0x06008263 RID: 33379 RVA: 0x001C3BFC File Offset: 0x001C1DFC
		public byte[] SvgData
		{
			get
			{
				byte[] result;
				if ((result = this.#a) == null)
				{
					result = (this.#a = \u0010\u0004.~\u008F\u0008(\u009A.\u0094\u0003(), this.SvgString));
				}
				return result;
			}
		}

		// Token: 0x0400357F RID: 13695
		private byte[] #a;

		// Token: 0x04003580 RID: 13696
		private string #b;

		// Token: 0x04003581 RID: 13697
		[CompilerGenerated]
		private SvgDocument #c;

		// Token: 0x04003582 RID: 13698
		[CompilerGenerated]
		private double #d;

		// Token: 0x04003583 RID: 13699
		[CompilerGenerated]
		private double #e;
	}
}

using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x02000399 RID: 921
	internal sealed class #f1 : #20, IDesignDimensions
	{
		// Token: 0x06001DF4 RID: 7668 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #f1()
		{
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x000C2224 File Offset: 0x000C0424
		public #f1(DesignDimensions #Rf)
		{
			this.MinWidth = #Rf.MinWidth;
			this.MaxWidth = #Rf.MaxWidth;
			this.WidthIncrement = #Rf.WidthIncrement;
			this.MinHeight = #Rf.MinHeight;
			this.MaxHeight = #Rf.MaxHeight;
			this.HeightIncrement = #Rf.HeightIncrement;
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06001DF6 RID: 7670 RVA: 0x0001CC35 File Offset: 0x0001AE35
		// (set) Token: 0x06001DF7 RID: 7671 RVA: 0x0001CC41 File Offset: 0x0001AE41
		public float MinWidth
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<float>(ref this.#a, value, #Phc.#3hc(107399365));
			}
		}

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x06001DF8 RID: 7672 RVA: 0x0001CC67 File Offset: 0x0001AE67
		// (set) Token: 0x06001DF9 RID: 7673 RVA: 0x0001CC73 File Offset: 0x0001AE73
		public float MaxWidth
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<float>(ref this.#b, value, #Phc.#3hc(107399384));
			}
		}

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06001DFA RID: 7674 RVA: 0x0001CC99 File Offset: 0x0001AE99
		// (set) Token: 0x06001DFB RID: 7675 RVA: 0x0001CCA5 File Offset: 0x0001AEA5
		public float WidthIncrement
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<float>(ref this.#c, value, #Phc.#3hc(107399339));
			}
		}

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x06001DFC RID: 7676 RVA: 0x0001CCCB File Offset: 0x0001AECB
		// (set) Token: 0x06001DFD RID: 7677 RVA: 0x0001CCD7 File Offset: 0x0001AED7
		public float MinHeight
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<float>(ref this.#d, value, #Phc.#3hc(107399350));
			}
		}

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06001DFE RID: 7678 RVA: 0x0001CCFD File Offset: 0x0001AEFD
		// (set) Token: 0x06001DFF RID: 7679 RVA: 0x0001CD09 File Offset: 0x0001AF09
		public float MaxHeight
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<float>(ref this.#e, value, #Phc.#3hc(107399305));
			}
		}

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06001E00 RID: 7680 RVA: 0x0001CD2F File Offset: 0x0001AF2F
		// (set) Token: 0x06001E01 RID: 7681 RVA: 0x0001CD3B File Offset: 0x0001AF3B
		public float HeightIncrement
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<float>(ref this.#f, value, #Phc.#3hc(107399324));
			}
		}

		// Token: 0x06001E02 RID: 7682 RVA: 0x000C2280 File Offset: 0x000C0480
		public DesignDimensions #CY()
		{
			return new DesignDimensions
			{
				WidthIncrement = this.WidthIncrement,
				MinHeight = this.MinHeight,
				MaxWidth = this.MaxWidth,
				HeightIncrement = this.HeightIncrement,
				MinWidth = this.MinWidth,
				MaxHeight = this.MaxHeight
			};
		}

		// Token: 0x04000BEE RID: 3054
		private float #a;

		// Token: 0x04000BEF RID: 3055
		private float #b;

		// Token: 0x04000BF0 RID: 3056
		private float #c;

		// Token: 0x04000BF1 RID: 3057
		private float #d;

		// Token: 0x04000BF2 RID: 3058
		private float #e;

		// Token: 0x04000BF3 RID: 3059
		private float #f;
	}
}

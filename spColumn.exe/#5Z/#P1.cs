using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x0200039C RID: 924
	internal sealed class #P1 : #20
	{
		// Token: 0x06001E17 RID: 7703 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #P1()
		{
		}

		// Token: 0x06001E18 RID: 7704 RVA: 0x000C2448 File Offset: 0x000C0648
		public #P1(DesignReinforcementSidesDifferent #Rf)
		{
			this.MinTopBottomNumberOfBars = #Rf.MinTopBottomNumberOfBars;
			this.MaxTopBottomNumberOfBars = #Rf.MaxTopBottomNumberOfBars;
			this.MinLeftRightNumberOfBars = #Rf.MinLeftRightNumberOfBars;
			this.MaxLeftRightNumberOfBars = #Rf.MaxLeftRightNumberOfBars;
			this.MinTopBottomBarSize = #Rf.MinTopBottomBarSize;
			this.MaxTopBottomBarSize = #Rf.MaxTopBottomBarSize;
			this.MinLeftRightBarSize = #Rf.MinLeftRightBarSize;
			this.MaxLeftRightBarSize = #Rf.MaxLeftRightBarSize;
			this.TopBottomClearCover = #Rf.TopBottomClearCover;
			this.LeftRightClearCover = #Rf.LeftRightClearCover;
		}

		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x06001E19 RID: 7705 RVA: 0x0001CEDD File Offset: 0x0001B0DD
		// (set) Token: 0x06001E1A RID: 7706 RVA: 0x0001CEE9 File Offset: 0x0001B0E9
		public int MinTopBottomNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<int>(ref this.#a, value, #Phc.#3hc(107399184));
			}
		}

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x06001E1B RID: 7707 RVA: 0x0001CF0F File Offset: 0x0001B10F
		// (set) Token: 0x06001E1C RID: 7708 RVA: 0x0001CF1B File Offset: 0x0001B11B
		public int MaxTopBottomNumberOfBars
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<int>(ref this.#b, value, #Phc.#3hc(107399631));
			}
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x06001E1D RID: 7709 RVA: 0x0001CF41 File Offset: 0x0001B141
		// (set) Token: 0x06001E1E RID: 7710 RVA: 0x0001CF4D File Offset: 0x0001B14D
		public int MinLeftRightNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<int>(ref this.#c, value, #Phc.#3hc(107399598));
			}
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x06001E1F RID: 7711 RVA: 0x0001CF73 File Offset: 0x0001B173
		// (set) Token: 0x06001E20 RID: 7712 RVA: 0x0001CF7F File Offset: 0x0001B17F
		public int MaxLeftRightNumberOfBars
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<int>(ref this.#d, value, #Phc.#3hc(107399565));
			}
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06001E21 RID: 7713 RVA: 0x0001CFA5 File Offset: 0x0001B1A5
		// (set) Token: 0x06001E22 RID: 7714 RVA: 0x0001CFB1 File Offset: 0x0001B1B1
		public int MinTopBottomBarSize
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<int>(ref this.#e, value, #Phc.#3hc(107399532));
			}
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06001E23 RID: 7715 RVA: 0x0001CFD7 File Offset: 0x0001B1D7
		// (set) Token: 0x06001E24 RID: 7716 RVA: 0x0001CFE3 File Offset: 0x0001B1E3
		public int MaxTopBottomBarSize
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<int>(ref this.#f, value, #Phc.#3hc(107399503));
			}
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06001E25 RID: 7717 RVA: 0x0001D009 File Offset: 0x0001B209
		// (set) Token: 0x06001E26 RID: 7718 RVA: 0x0001D015 File Offset: 0x0001B215
		public int MinLeftRightBarSize
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<int>(ref this.#g, value, #Phc.#3hc(107399506));
			}
		}

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06001E27 RID: 7719 RVA: 0x0001D03B File Offset: 0x0001B23B
		// (set) Token: 0x06001E28 RID: 7720 RVA: 0x0001D047 File Offset: 0x0001B247
		public int MaxLeftRightBarSize
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<int>(ref this.#h, value, #Phc.#3hc(107399477));
			}
		}

		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06001E29 RID: 7721 RVA: 0x0001D06D File Offset: 0x0001B26D
		// (set) Token: 0x06001E2A RID: 7722 RVA: 0x0001D079 File Offset: 0x0001B279
		public float TopBottomClearCover
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<float>(ref this.#i, value, #Phc.#3hc(107399448));
			}
		}

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x06001E2B RID: 7723 RVA: 0x0001D09F File Offset: 0x0001B29F
		// (set) Token: 0x06001E2C RID: 7724 RVA: 0x0001D0AB File Offset: 0x0001B2AB
		public float LeftRightClearCover
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<float>(ref this.#j, value, #Phc.#3hc(107398907));
			}
		}

		// Token: 0x06001E2D RID: 7725 RVA: 0x000C24D4 File Offset: 0x000C06D4
		public DesignReinforcementSidesDifferent #CY()
		{
			return new DesignReinforcementSidesDifferent
			{
				TopBottomClearCover = this.TopBottomClearCover,
				MinTopBottomBarSize = this.MinTopBottomBarSize,
				MinTopBottomNumberOfBars = this.MinTopBottomNumberOfBars,
				MinLeftRightNumberOfBars = this.MinLeftRightNumberOfBars,
				LeftRightClearCover = this.LeftRightClearCover,
				MaxLeftRightBarSize = this.MaxLeftRightBarSize,
				MaxLeftRightNumberOfBars = this.MaxLeftRightNumberOfBars,
				MaxTopBottomBarSize = this.MaxTopBottomBarSize,
				MaxTopBottomNumberOfBars = this.MaxTopBottomNumberOfBars,
				MinLeftRightBarSize = this.MinLeftRightBarSize
			};
		}

		// Token: 0x04000BFB RID: 3067
		private int #a;

		// Token: 0x04000BFC RID: 3068
		private int #b;

		// Token: 0x04000BFD RID: 3069
		private int #c;

		// Token: 0x04000BFE RID: 3070
		private int #d;

		// Token: 0x04000BFF RID: 3071
		private int #e;

		// Token: 0x04000C00 RID: 3072
		private int #f;

		// Token: 0x04000C01 RID: 3073
		private int #g;

		// Token: 0x04000C02 RID: 3074
		private int #h;

		// Token: 0x04000C03 RID: 3075
		private float #i;

		// Token: 0x04000C04 RID: 3076
		private float #j;
	}
}

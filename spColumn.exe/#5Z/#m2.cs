using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x020003A0 RID: 928
	internal sealed class #m2 : #20
	{
		// Token: 0x06001E46 RID: 7750 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #m2()
		{
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x000C2620 File Offset: 0x000C0820
		public #m2(InvestigationReinforcementSidesDifferent #Rf)
		{
			this.TopNumberOfBars = #Rf.TopNumberOfBars;
			this.BottomNumberOfBars = #Rf.BottomNumberOfBars;
			this.LeftNumberOfBars = #Rf.LeftNumberOfBars;
			this.RightNumberOfBars = #Rf.RightNumberOfBars;
			this.TopBarSize = #Rf.TopBarSize;
			this.BottomBarSize = #Rf.BottomBarSize;
			this.LeftBarSize = #Rf.LeftBarSize;
			this.RightBarSize = #Rf.RightBarSize;
			this.TopClearCover = #Rf.TopClearCover;
			this.BottomClearCover = #Rf.BottomClearCover;
			this.LeftClearCover = #Rf.LeftClearCover;
			this.RightClearCover = #Rf.RightClearCover;
		}

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06001E48 RID: 7752 RVA: 0x0001D311 File Offset: 0x0001B511
		// (set) Token: 0x06001E49 RID: 7753 RVA: 0x0001D31D File Offset: 0x0001B51D
		public int TopNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<int>(ref this.#a, value, #Phc.#3hc(107398734));
			}
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06001E4A RID: 7754 RVA: 0x0001D343 File Offset: 0x0001B543
		// (set) Token: 0x06001E4B RID: 7755 RVA: 0x0001D34F File Offset: 0x0001B54F
		public int BottomNumberOfBars
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<int>(ref this.#b, value, #Phc.#3hc(107398745));
			}
		}

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x06001E4C RID: 7756 RVA: 0x0001D375 File Offset: 0x0001B575
		// (set) Token: 0x06001E4D RID: 7757 RVA: 0x0001D381 File Offset: 0x0001B581
		public int LeftNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<int>(ref this.#c, value, #Phc.#3hc(107398688));
			}
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x06001E4E RID: 7758 RVA: 0x0001D3A7 File Offset: 0x0001B5A7
		// (set) Token: 0x06001E4F RID: 7759 RVA: 0x0001D3B3 File Offset: 0x0001B5B3
		public int RightNumberOfBars
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<int>(ref this.#d, value, #Phc.#3hc(107398663));
			}
		}

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06001E50 RID: 7760 RVA: 0x0001D3D9 File Offset: 0x0001B5D9
		// (set) Token: 0x06001E51 RID: 7761 RVA: 0x0001D3E5 File Offset: 0x0001B5E5
		public int TopBarSize
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<int>(ref this.#e, value, #Phc.#3hc(107399150));
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06001E52 RID: 7762 RVA: 0x0001D40B File Offset: 0x0001B60B
		// (set) Token: 0x06001E53 RID: 7763 RVA: 0x0001D417 File Offset: 0x0001B617
		public int BottomBarSize
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<int>(ref this.#f, value, #Phc.#3hc(107399165));
			}
		}

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06001E54 RID: 7764 RVA: 0x0001D43D File Offset: 0x0001B63D
		// (set) Token: 0x06001E55 RID: 7765 RVA: 0x0001D449 File Offset: 0x0001B649
		public int LeftBarSize
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<int>(ref this.#g, value, #Phc.#3hc(107399112));
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x06001E56 RID: 7766 RVA: 0x0001D46F File Offset: 0x0001B66F
		// (set) Token: 0x06001E57 RID: 7767 RVA: 0x0001D47B File Offset: 0x0001B67B
		public int RightBarSize
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<int>(ref this.#h, value, #Phc.#3hc(107399127));
			}
		}

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x06001E58 RID: 7768 RVA: 0x0001D4A1 File Offset: 0x0001B6A1
		// (set) Token: 0x06001E59 RID: 7769 RVA: 0x0001D4AD File Offset: 0x0001B6AD
		public float TopClearCover
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<float>(ref this.#i, value, #Phc.#3hc(107399078));
			}
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x06001E5A RID: 7770 RVA: 0x0001D4D3 File Offset: 0x0001B6D3
		// (set) Token: 0x06001E5B RID: 7771 RVA: 0x0001D4DF File Offset: 0x0001B6DF
		public float BottomClearCover
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<float>(ref this.#j, value, #Phc.#3hc(107399089));
			}
		}

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x0001D505 File Offset: 0x0001B705
		// (set) Token: 0x06001E5D RID: 7773 RVA: 0x0001D511 File Offset: 0x0001B711
		public float LeftClearCover
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<float>(ref this.#k, value, #Phc.#3hc(107399064));
			}
		}

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x0001D537 File Offset: 0x0001B737
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x0001D543 File Offset: 0x0001B743
		public float RightClearCover
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<float>(ref this.#l, value, #Phc.#3hc(107399011));
			}
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x000C26C4 File Offset: 0x000C08C4
		public InvestigationReinforcementSidesDifferent #CY()
		{
			return new InvestigationReinforcementSidesDifferent
			{
				LeftClearCover = this.LeftClearCover,
				RightClearCover = this.RightClearCover,
				BottomBarSize = this.BottomBarSize,
				BottomClearCover = this.BottomClearCover,
				BottomNumberOfBars = this.BottomNumberOfBars,
				LeftBarSize = this.LeftBarSize,
				LeftNumberOfBars = this.LeftNumberOfBars,
				RightBarSize = this.RightBarSize,
				RightNumberOfBars = this.RightNumberOfBars,
				TopBarSize = this.TopBarSize,
				TopClearCover = this.TopClearCover,
				TopNumberOfBars = this.TopNumberOfBars
			};
		}

		// Token: 0x04000C0C RID: 3084
		private int #a;

		// Token: 0x04000C0D RID: 3085
		private int #b;

		// Token: 0x04000C0E RID: 3086
		private int #c;

		// Token: 0x04000C0F RID: 3087
		private int #d;

		// Token: 0x04000C10 RID: 3088
		private int #e;

		// Token: 0x04000C11 RID: 3089
		private int #f;

		// Token: 0x04000C12 RID: 3090
		private int #g;

		// Token: 0x04000C13 RID: 3091
		private int #h;

		// Token: 0x04000C14 RID: 3092
		private float #i;

		// Token: 0x04000C15 RID: 3093
		private float #j;

		// Token: 0x04000C16 RID: 3094
		private float #k;

		// Token: 0x04000C17 RID: 3095
		private float #l;
	}
}

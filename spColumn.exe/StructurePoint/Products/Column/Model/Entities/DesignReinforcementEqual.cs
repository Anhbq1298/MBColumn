using System;
using #5Z;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x0200039B RID: 923
	internal sealed class DesignReinforcementEqual : #20
	{
		// Token: 0x06001E0A RID: 7690 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public DesignReinforcementEqual()
		{
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x000C239C File Offset: 0x000C059C
		public DesignReinforcementEqual(DesignReinforcementEqual item)
		{
			this.MinNumberOfBars = item.MinNumberOfBars;
			this.MinBarSize = item.MinBarSize;
			this.MaxNumberOfBars = item.MaxNumberOfBars;
			this.MaxBarSize = item.MaxBarSize;
			this.ClearCover = item.ClearCover;
		}

		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x06001E0C RID: 7692 RVA: 0x0001CDE3 File Offset: 0x0001AFE3
		// (set) Token: 0x06001E0D RID: 7693 RVA: 0x0001CDEF File Offset: 0x0001AFEF
		public int MinNumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<int>(ref this.#a, value, #Phc.#3hc(107399245));
			}
		}

		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x06001E0E RID: 7694 RVA: 0x0001CE15 File Offset: 0x0001B015
		// (set) Token: 0x06001E0F RID: 7695 RVA: 0x0001CE21 File Offset: 0x0001B021
		public int MinBarSize
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<int>(ref this.#b, value, #Phc.#3hc(107399256));
			}
		}

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x06001E10 RID: 7696 RVA: 0x0001CE47 File Offset: 0x0001B047
		// (set) Token: 0x06001E11 RID: 7697 RVA: 0x0001CE53 File Offset: 0x0001B053
		public int MaxNumberOfBars
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<int>(ref this.#c, value, #Phc.#3hc(107399207));
			}
		}

		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x06001E12 RID: 7698 RVA: 0x0001CE79 File Offset: 0x0001B079
		// (set) Token: 0x06001E13 RID: 7699 RVA: 0x0001CE85 File Offset: 0x0001B085
		public int MaxBarSize
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<int>(ref this.#d, value, #Phc.#3hc(107399218));
			}
		}

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x06001E14 RID: 7700 RVA: 0x0001CEAB File Offset: 0x0001B0AB
		// (set) Token: 0x06001E15 RID: 7701 RVA: 0x0001CEB7 File Offset: 0x0001B0B7
		public float ClearCover
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<float>(ref this.#e, value, #Phc.#3hc(107399169));
			}
		}

		// Token: 0x06001E16 RID: 7702 RVA: 0x000C23EC File Offset: 0x000C05EC
		public DesignReinforcementEqual #CY()
		{
			return new DesignReinforcementEqual
			{
				ClearCover = this.ClearCover,
				MaxNumberOfBars = this.MaxNumberOfBars,
				MaxBarSize = this.MaxBarSize,
				MinNumberOfBars = this.MinNumberOfBars,
				MinBarSize = this.MinBarSize
			};
		}

		// Token: 0x04000BF6 RID: 3062
		private int #a;

		// Token: 0x04000BF7 RID: 3063
		private int #b;

		// Token: 0x04000BF8 RID: 3064
		private int #c;

		// Token: 0x04000BF9 RID: 3065
		private int #d;

		// Token: 0x04000BFA RID: 3066
		private float #e;
	}
}

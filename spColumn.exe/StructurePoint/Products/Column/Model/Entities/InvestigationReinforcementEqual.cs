using System;
using #5Z;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x0200039F RID: 927
	internal sealed class InvestigationReinforcementEqual : #20
	{
		// Token: 0x06001E3D RID: 7741 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public InvestigationReinforcementEqual()
		{
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x0001D218 File Offset: 0x0001B418
		public InvestigationReinforcementEqual(InvestigationReinforcementEqual item)
		{
			this.NumberOfBars = item.NumberOfBars;
			this.BarSize = item.BarSize;
			this.ClearCover = item.ClearCover;
		}

		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06001E3F RID: 7743 RVA: 0x0001D244 File Offset: 0x0001B444
		// (set) Token: 0x06001E40 RID: 7744 RVA: 0x0001D250 File Offset: 0x0001B450
		public int NumberOfBars
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<int>(ref this.#a, value, #Phc.#3hc(107398764));
			}
		}

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x06001E41 RID: 7745 RVA: 0x0001D276 File Offset: 0x0001B476
		// (set) Token: 0x06001E42 RID: 7746 RVA: 0x0001D282 File Offset: 0x0001B482
		public int BarSize
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<int>(ref this.#b, value, #Phc.#3hc(107398779));
			}
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06001E43 RID: 7747 RVA: 0x0001D2A8 File Offset: 0x0001B4A8
		// (set) Token: 0x06001E44 RID: 7748 RVA: 0x0001D2B4 File Offset: 0x0001B4B4
		public float ClearCover
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<float>(ref this.#c, value, #Phc.#3hc(107399169));
			}
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x0001D2DA File Offset: 0x0001B4DA
		public InvestigationReinforcementEqual #CY()
		{
			return new InvestigationReinforcementEqual
			{
				ClearCover = this.ClearCover,
				NumberOfBars = this.NumberOfBars,
				BarSize = this.BarSize
			};
		}

		// Token: 0x04000C09 RID: 3081
		private int #a;

		// Token: 0x04000C0A RID: 3082
		private int #b;

		// Token: 0x04000C0B RID: 3083
		private float #c;
	}
}

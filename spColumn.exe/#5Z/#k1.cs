using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x0200039A RID: 922
	internal sealed class #k1 : #20
	{
		// Token: 0x06001E03 RID: 7683 RVA: 0x0001CD61 File Offset: 0x0001AF61
		public #k1()
		{
			this.AllEqual = new StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual();
			this.Different = new #P1();
		}

		// Token: 0x06001E04 RID: 7684 RVA: 0x000C22E8 File Offset: 0x000C04E8
		public #k1(DesignReinforcement #Rf)
		{
			this.AllEqual = ((#Rf.AllEqual != null) ? new StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual(#Rf.AllEqual) : new StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual());
			this.Different = ((#Rf.Different != null) ? new #P1(#Rf.Different) : new #P1());
		}

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06001E05 RID: 7685 RVA: 0x0001CD7F File Offset: 0x0001AF7F
		// (set) Token: 0x06001E06 RID: 7686 RVA: 0x0001CD8B File Offset: 0x0001AF8B
		public StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual AllEqual
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual>(ref this.#a, value, #Phc.#3hc(107399271));
			}
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06001E07 RID: 7687 RVA: 0x0001CDB1 File Offset: 0x0001AFB1
		// (set) Token: 0x06001E08 RID: 7688 RVA: 0x0001CDBD File Offset: 0x0001AFBD
		public #P1 Different
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#P1>(ref this.#b, value, #Phc.#3hc(107399290));
			}
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x000C233C File Offset: 0x000C053C
		public DesignReinforcement #CY()
		{
			DesignReinforcement designReinforcement = new DesignReinforcement();
			#P1 #P = this.Different;
			DesignReinforcementSidesDifferent different;
			if ((different = ((#P != null) ? #P.#CY() : null)) == null)
			{
				different = new DesignReinforcementSidesDifferent();
			}
			designReinforcement.Different = different;
			StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual designReinforcementEqual = this.AllEqual;
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.DesignReinforcementEqual allEqual;
			if ((allEqual = ((designReinforcementEqual != null) ? designReinforcementEqual.#CY() : null)) == null)
			{
				allEqual = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.DesignReinforcementEqual();
			}
			designReinforcement.AllEqual = allEqual;
			return designReinforcement;
		}

		// Token: 0x04000BF4 RID: 3060
		private StructurePoint.Products.Column.Model.Entities.DesignReinforcementEqual #a;

		// Token: 0x04000BF5 RID: 3061
		private #P1 #b;
	}
}

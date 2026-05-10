using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x0200039E RID: 926
	internal sealed class #T1 : #20
	{
		// Token: 0x06001E36 RID: 7734 RVA: 0x0001D196 File Offset: 0x0001B396
		public #T1()
		{
			this.AllEqual = new StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual();
			this.Different = new #m2();
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x000C256C File Offset: 0x000C076C
		public #T1(InvestigationReinforcement #Rf)
		{
			this.AllEqual = ((#Rf.AllEqual != null) ? new StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual(#Rf.AllEqual) : new StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual());
			this.Different = ((#Rf.Different != null) ? new #m2(#Rf.Different) : new #m2());
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06001E38 RID: 7736 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		// (set) Token: 0x06001E39 RID: 7737 RVA: 0x0001D1C0 File Offset: 0x0001B3C0
		public StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual AllEqual
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual>(ref this.#a, value, #Phc.#3hc(107399271));
			}
		}

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06001E3A RID: 7738 RVA: 0x0001D1E6 File Offset: 0x0001B3E6
		// (set) Token: 0x06001E3B RID: 7739 RVA: 0x0001D1F2 File Offset: 0x0001B3F2
		public #m2 Different
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#m2>(ref this.#b, value, #Phc.#3hc(107399290));
			}
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x000C25C0 File Offset: 0x000C07C0
		public InvestigationReinforcement #CY()
		{
			InvestigationReinforcement investigationReinforcement = new InvestigationReinforcement();
			#m2 #m = this.Different;
			InvestigationReinforcementSidesDifferent different;
			if ((different = ((#m != null) ? #m.#CY() : null)) == null)
			{
				different = new InvestigationReinforcementSidesDifferent();
			}
			investigationReinforcement.Different = different;
			StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual investigationReinforcementEqual = this.AllEqual;
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.InvestigationReinforcementEqual allEqual;
			if ((allEqual = ((investigationReinforcementEqual != null) ? investigationReinforcementEqual.#CY() : null)) == null)
			{
				allEqual = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.InvestigationReinforcementEqual();
			}
			investigationReinforcement.AllEqual = allEqual;
			return investigationReinforcement;
		}

		// Token: 0x04000C07 RID: 3079
		private StructurePoint.Products.Column.Model.Entities.InvestigationReinforcementEqual #a;

		// Token: 0x04000C08 RID: 3080
		private #m2 #b;
	}
}

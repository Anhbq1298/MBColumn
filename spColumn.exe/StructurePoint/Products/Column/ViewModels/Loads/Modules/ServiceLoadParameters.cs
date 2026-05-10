using System;
using #5Z;
using #7hc;
using #n8;

namespace StructurePoint.Products.Column.ViewModels.Loads.Modules
{
	// Token: 0x02000203 RID: 515
	internal sealed class ServiceLoadParameters : #20
	{
		// Token: 0x0600118D RID: 4493 RVA: 0x000137CB File Offset: 0x000119CB
		public ServiceLoadParameters()
		{
			this.ServiceLoads = new #V3();
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x000137DE File Offset: 0x000119DE
		// (set) Token: 0x0600118F RID: 4495 RVA: 0x000137EA File Offset: 0x000119EA
		public string Name
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<string>(ref this.#a, value, #Phc.#3hc(107409209));
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x00013810 File Offset: 0x00011A10
		// (set) Token: 0x06001191 RID: 4497 RVA: 0x0001381C File Offset: 0x00011A1C
		public #K8 ServiceLoads
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#K8>(ref this.#b, value, #Phc.#3hc(107409200));
			}
		}

		// Token: 0x040006E9 RID: 1769
		private string #a;

		// Token: 0x040006EA RID: 1770
		private #K8 #b;
	}
}

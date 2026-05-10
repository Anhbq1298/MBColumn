using System;
using #7hc;
using #n8;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Definitions;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020003A7 RID: 935
	[#zZ(typeof(IReinforcementRatiosValidator))]
	internal sealed class ReinforcementRatios : ValidatableBaseEntity, #q8<#J8>, #J8, IReinforcementRatios
	{
		// Token: 0x06001EF6 RID: 7926 RVA: 0x000131A7 File Offset: 0x000113A7
		public ReinforcementRatios()
		{
		}

		// Token: 0x06001EF7 RID: 7927 RVA: 0x0001E1E2 File Offset: 0x0001C3E2
		public ReinforcementRatios(float minReinforcementRatio, float maxReinforcementRatio)
		{
			this.#a = minReinforcementRatio;
			this.#b = maxReinforcementRatio;
		}

		// Token: 0x06001EF8 RID: 7928 RVA: 0x0001E1F8 File Offset: 0x0001C3F8
		public ReinforcementRatios(ReinforcementRatios item)
		{
			this.#a = item.MinReinforcementRatio;
			this.#b = item.MaxReinforcementRatio;
		}

		// Token: 0x06001EF9 RID: 7929 RVA: 0x0001E218 File Offset: 0x0001C418
		public ReinforcementRatios(#J8 other)
		{
			this.CopyFrom(other);
		}

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x06001EFA RID: 7930 RVA: 0x0001E227 File Offset: 0x0001C427
		// (set) Token: 0x06001EFB RID: 7931 RVA: 0x0001E233 File Offset: 0x0001C433
		public float MinReinforcementRatio
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107408038));
			}
		}

		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x06001EFC RID: 7932 RVA: 0x0001E259 File Offset: 0x0001C459
		// (set) Token: 0x06001EFD RID: 7933 RVA: 0x0001E265 File Offset: 0x0001C465
		public float MaxReinforcementRatio
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107408009));
			}
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x0001E28B File Offset: 0x0001C48B
		public ReinforcementRatios #CY()
		{
			return new ReinforcementRatios
			{
				MaxReinforcementRatio = this.MaxReinforcementRatio,
				MinReinforcementRatio = this.MinReinforcementRatio
			};
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x0001E2B6 File Offset: 0x0001C4B6
		public void CopyFrom(#J8 other)
		{
			this.MinReinforcementRatio = other.MinReinforcementRatio;
			this.MaxReinforcementRatio = other.MaxReinforcementRatio;
		}

		// Token: 0x04000C4D RID: 3149
		private float #a;

		// Token: 0x04000C4E RID: 3150
		private float #b;
	}
}

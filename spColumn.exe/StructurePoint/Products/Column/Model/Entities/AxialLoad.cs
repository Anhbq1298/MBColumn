using System;
using #7hc;
using #9pe;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020001F1 RID: 497
	[#zZ(typeof(#RZ))]
	internal sealed class AxialLoad : ValidatableBaseEntity, #8pe
	{
		// Token: 0x0600110E RID: 4366 RVA: 0x0001318A File Offset: 0x0001138A
		public AxialLoad(float initialLoad, float finalLoad, float increment)
		{
			this.#a = initialLoad;
			this.#b = finalLoad;
			this.#c = increment;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x000131A7 File Offset: 0x000113A7
		public AxialLoad()
		{
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x000131AF File Offset: 0x000113AF
		public AxialLoad(AxialLoad item)
		{
			this.#a = item.InitialLoad;
			this.#b = item.FinalLoad;
			this.#c = item.Increment;
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x000131DB File Offset: 0x000113DB
		public AxialLoad(AxialLoad item)
		{
			this.#a = item.InitialLoad;
			this.#b = item.FinalLoad;
			this.#c = item.Increment;
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06001112 RID: 4370 RVA: 0x00013207 File Offset: 0x00011407
		// (set) Token: 0x06001113 RID: 4371 RVA: 0x00013213 File Offset: 0x00011413
		public float InitialLoad
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107399969));
			}
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06001114 RID: 4372 RVA: 0x00013239 File Offset: 0x00011439
		// (set) Token: 0x06001115 RID: 4373 RVA: 0x00013245 File Offset: 0x00011445
		public float FinalLoad
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107399984));
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06001116 RID: 4374 RVA: 0x0001326B File Offset: 0x0001146B
		// (set) Token: 0x06001117 RID: 4375 RVA: 0x00013277 File Offset: 0x00011477
		public float Increment
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107399939));
			}
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0001329D File Offset: 0x0001149D
		public AxialLoad #CY()
		{
			return new AxialLoad
			{
				InitialLoad = this.InitialLoad,
				FinalLoad = this.FinalLoad,
				Increment = this.Increment
			};
		}

		// Token: 0x040006B9 RID: 1721
		private float #a;

		// Token: 0x040006BA RID: 1722
		private float #b;

		// Token: 0x040006BB RID: 1723
		private float #c;
	}
}

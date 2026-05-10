using System;
using #7hc;
using #9pe;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020001FF RID: 511
	[#zZ(typeof(#PZ))]
	internal sealed class FactoredLoad : ValidatableBaseEntity, #dqe
	{
		// Token: 0x06001175 RID: 4469 RVA: 0x00013602 File Offset: 0x00011802
		public FactoredLoad(float axialLoad, float momentX, float momentY)
		{
			this.#a = axialLoad;
			this.#b = momentX;
			this.#c = momentY;
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x000131A7 File Offset: 0x000113A7
		public FactoredLoad()
		{
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x0001361F File Offset: 0x0001181F
		public FactoredLoad(FactoredLoad item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			this.#a = item.AxialLoad;
			this.#b = item.MomentX;
			this.#c = item.MomentY;
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x0001365E File Offset: 0x0001185E
		public FactoredLoad(FactoredLoad item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			this.#a = item.AxialLoad;
			this.#b = item.MomentX;
			this.#c = item.MomentY;
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06001179 RID: 4473 RVA: 0x0001369D File Offset: 0x0001189D
		// (set) Token: 0x0600117A RID: 4474 RVA: 0x000136A9 File Offset: 0x000118A9
		public float AxialLoad
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107398869));
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x0600117B RID: 4475 RVA: 0x000136CF File Offset: 0x000118CF
		// (set) Token: 0x0600117C RID: 4476 RVA: 0x000136DB File Offset: 0x000118DB
		public float MomentX
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107398824));
			}
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x0600117D RID: 4477 RVA: 0x00013701 File Offset: 0x00011901
		// (set) Token: 0x0600117E RID: 4478 RVA: 0x0001370D File Offset: 0x0001190D
		public float MomentY
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107398843));
			}
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x00013733 File Offset: 0x00011933
		public FactoredLoad #CY()
		{
			return new FactoredLoad
			{
				AxialLoad = this.AxialLoad,
				MomentX = this.MomentX,
				MomentY = this.MomentY
			};
		}

		// Token: 0x040006E5 RID: 1765
		private float #a;

		// Token: 0x040006E6 RID: 1766
		private float #b;

		// Token: 0x040006E7 RID: 1767
		private float #c;
	}
}

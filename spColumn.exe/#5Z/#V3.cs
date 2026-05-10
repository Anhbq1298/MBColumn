using System;
using #7hc;
using #9pe;
using #n8;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x020003A9 RID: 937
	[#zZ(typeof(#TZ))]
	internal sealed class #V3 : ValidatableBaseEntity, #qqe, #K8
	{
		// Token: 0x06001F1A RID: 7962 RVA: 0x000131A7 File Offset: 0x000113A7
		public #V3()
		{
		}

		// Token: 0x06001F1B RID: 7963 RVA: 0x000C3418 File Offset: 0x000C1618
		public #V3(ServiceLoadCaseData #Rf)
		{
			this.#a = #Rf.AxialLoad;
			this.#b = #Rf.MomentXTop;
			this.#c = #Rf.MomentXBottom;
			this.#d = #Rf.MomentYTop;
			this.#e = #Rf.MomentYBottom;
		}

		// Token: 0x06001F1C RID: 7964 RVA: 0x000C3468 File Offset: 0x000C1668
		public #V3(#K8 #L0)
		{
			this.#a = #L0.AxialLoad;
			this.#b = #L0.MomentXTop;
			this.#c = #L0.MomentXBottom;
			this.#d = #L0.MomentYTop;
			this.#e = #L0.MomentYBottom;
		}

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06001F1D RID: 7965 RVA: 0x0001E4E7 File Offset: 0x0001C6E7
		// (set) Token: 0x06001F1E RID: 7966 RVA: 0x0001E4F3 File Offset: 0x0001C6F3
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

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06001F1F RID: 7967 RVA: 0x0001E519 File Offset: 0x0001C719
		// (set) Token: 0x06001F20 RID: 7968 RVA: 0x0001E525 File Offset: 0x0001C725
		public float MomentXTop
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107397887));
			}
		}

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06001F21 RID: 7969 RVA: 0x0001E54B File Offset: 0x0001C74B
		// (set) Token: 0x06001F22 RID: 7970 RVA: 0x0001E557 File Offset: 0x0001C757
		public float MomentXBottom
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107397838));
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06001F23 RID: 7971 RVA: 0x0001E57D File Offset: 0x0001C77D
		// (set) Token: 0x06001F24 RID: 7972 RVA: 0x0001E589 File Offset: 0x0001C789
		public float MomentYTop
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107397849));
			}
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06001F25 RID: 7973 RVA: 0x0001E5AF File Offset: 0x0001C7AF
		// (set) Token: 0x06001F26 RID: 7974 RVA: 0x0001E5BB File Offset: 0x0001C7BB
		public float MomentYBottom
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107397800));
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06001F27 RID: 7975 RVA: 0x0000A8BF File Offset: 0x00008ABF
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001F28 RID: 7976 RVA: 0x000C34B8 File Offset: 0x000C16B8
		public ServiceLoadCaseData #CY()
		{
			return new ServiceLoadCaseData
			{
				AxialLoad = this.AxialLoad,
				MomentXBottom = this.MomentXBottom,
				MomentXTop = this.MomentXTop,
				MomentYBottom = this.MomentYBottom,
				MomentYTop = this.MomentYTop
			};
		}

		// Token: 0x06001F29 RID: 7977 RVA: 0x000C3514 File Offset: 0x000C1714
		public bool #e(#V3 #L0)
		{
			return #L0 != null && (Math.Abs(this.AxialLoad - #L0.AxialLoad) <= 0f && Math.Abs(this.MomentXTop - #L0.MomentXTop) <= 0f && Math.Abs(this.MomentXBottom - #L0.MomentXBottom) <= 0f && Math.Abs(this.MomentYTop - #L0.MomentYTop) <= 0f) && Math.Abs(this.MomentYBottom - #L0.MomentYBottom) <= 0f;
		}

		// Token: 0x06001F2A RID: 7978 RVA: 0x000C35C8 File Offset: 0x000C17C8
		public bool #U3()
		{
			return this.AxialLoad == 0f && this.MomentXTop == 0f && this.MomentXBottom == 0f && this.MomentYTop == 0f && this.MomentYBottom == 0f;
		}

		// Token: 0x06001F2B RID: 7979 RVA: 0x000C3624 File Offset: 0x000C1824
		public void #yl()
		{
			float axialLoad = 0f;
			if (!false)
			{
				this.AxialLoad = axialLoad;
			}
			this.MomentXTop = 0f;
			this.MomentXBottom = 0f;
			this.MomentYTop = 0f;
			this.MomentYBottom = 0f;
		}

		// Token: 0x04000C54 RID: 3156
		private float #a;

		// Token: 0x04000C55 RID: 3157
		private float #b;

		// Token: 0x04000C56 RID: 3158
		private float #c;

		// Token: 0x04000C57 RID: 3159
		private float #d;

		// Token: 0x04000C58 RID: 3160
		private float #e;
	}
}

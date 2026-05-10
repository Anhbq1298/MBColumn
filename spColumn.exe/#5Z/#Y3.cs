using System;
using #7hc;
using #9pe;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x020003AE RID: 942
	[#zZ(typeof(#WZ))]
	internal sealed class #Y3 : ValidatableBaseEntity, #sqe
	{
		// Token: 0x06001F63 RID: 8035 RVA: 0x000131A7 File Offset: 0x000113A7
		public #Y3()
		{
		}

		// Token: 0x06001F64 RID: 8036 RVA: 0x000C3B08 File Offset: 0x000C1D08
		public #Y3(SustainedLoadFactors #Rf)
		{
			this.#a = #Rf.Dead;
			this.#b = #Rf.Live;
			this.#c = #Rf.Wind;
			this.#d = #Rf.Earthquake;
			this.#e = #Rf.Snow;
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x06001F65 RID: 8037 RVA: 0x0001E9FD File Offset: 0x0001CBFD
		// (set) Token: 0x06001F66 RID: 8038 RVA: 0x0001EA09 File Offset: 0x0001CC09
		public float Dead
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#00<float>(ref this.#a, value, #Phc.#3hc(107398345));
			}
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x06001F67 RID: 8039 RVA: 0x0001EA2F File Offset: 0x0001CC2F
		// (set) Token: 0x06001F68 RID: 8040 RVA: 0x0001EA3B File Offset: 0x0001CC3B
		public float Live
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#00<float>(ref this.#b, value, #Phc.#3hc(107398336));
			}
		}

		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06001F69 RID: 8041 RVA: 0x0001EA61 File Offset: 0x0001CC61
		// (set) Token: 0x06001F6A RID: 8042 RVA: 0x0001EA6D File Offset: 0x0001CC6D
		public float Wind
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#00<float>(ref this.#c, value, #Phc.#3hc(107398359));
			}
		}

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06001F6B RID: 8043 RVA: 0x0001EA93 File Offset: 0x0001CC93
		// (set) Token: 0x06001F6C RID: 8044 RVA: 0x0001EA9F File Offset: 0x0001CC9F
		public float Earthquake
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#00<float>(ref this.#d, value, #Phc.#3hc(107398318));
			}
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06001F6D RID: 8045 RVA: 0x0001EAC5 File Offset: 0x0001CCC5
		// (set) Token: 0x06001F6E RID: 8046 RVA: 0x0001EAD1 File Offset: 0x0001CCD1
		public float Snow
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#00<float>(ref this.#e, value, #Phc.#3hc(107398333));
			}
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x000C3B58 File Offset: 0x000C1D58
		public SustainedLoadFactors #CY()
		{
			return new SustainedLoadFactors
			{
				Wind = this.Wind,
				Snow = this.Snow,
				Dead = this.Dead,
				Live = this.Live,
				Earthquake = this.Earthquake
			};
		}

		// Token: 0x04000C6D RID: 3181
		private float #a;

		// Token: 0x04000C6E RID: 3182
		private float #b;

		// Token: 0x04000C6F RID: 3183
		private float #c;

		// Token: 0x04000C70 RID: 3184
		private float #d;

		// Token: 0x04000C71 RID: 3185
		private float #e;
	}
}

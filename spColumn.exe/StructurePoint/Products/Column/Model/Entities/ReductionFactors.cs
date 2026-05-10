using System;
using #7hc;
using #9pe;
using #n8;
using #xZ;
using #YZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020003A5 RID: 933
	[#zZ(typeof(#3Z))]
	internal sealed class ReductionFactors : ValidatableBaseEntity, #q8<#kqe>, #I8, #kqe
	{
		// Token: 0x06001ED5 RID: 7893 RVA: 0x000131A7 File Offset: 0x000113A7
		public ReductionFactors()
		{
		}

		// Token: 0x06001ED6 RID: 7894 RVA: 0x000C2ED8 File Offset: 0x000C10D8
		public ReductionFactors(ReductionFactors item)
		{
			this.#b = item.B;
			this.#c = item.C;
			this.#d = item.Trans;
			this.#e = item.MinDimension;
			this.#a = item.A;
		}

		// Token: 0x06001ED7 RID: 7895 RVA: 0x0001DFA5 File Offset: 0x0001C1A5
		public ReductionFactors(#I8 other)
		{
			this.CopyFrom(other);
		}

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x0001DFB4 File Offset: 0x0001C1B4
		// (set) Token: 0x06001ED9 RID: 7897 RVA: 0x0001DFC0 File Offset: 0x0001C1C0
		public float A
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107408119));
			}
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x06001EDA RID: 7898 RVA: 0x0001DFE6 File Offset: 0x0001C1E6
		// (set) Token: 0x06001EDB RID: 7899 RVA: 0x0001DFF2 File Offset: 0x0001C1F2
		public float B
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107408114));
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x06001EDC RID: 7900 RVA: 0x0001E018 File Offset: 0x0001C218
		// (set) Token: 0x06001EDD RID: 7901 RVA: 0x0001E024 File Offset: 0x0001C224
		public float C
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107408077));
			}
		}

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x06001EDE RID: 7902 RVA: 0x0001E04A File Offset: 0x0001C24A
		// (set) Token: 0x06001EDF RID: 7903 RVA: 0x0001E056 File Offset: 0x0001C256
		public float Trans
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107408302));
			}
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x0001E07C File Offset: 0x0001C27C
		// (set) Token: 0x06001EE1 RID: 7905 RVA: 0x0001E088 File Offset: 0x0001C288
		public float MinDimension
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107408293));
			}
		}

		// Token: 0x06001EE2 RID: 7906 RVA: 0x000C2F28 File Offset: 0x000C1128
		public ReductionFactors #CY()
		{
			return new ReductionFactors
			{
				Trans = this.Trans,
				C = this.C,
				B = this.B,
				MinDimension = this.MinDimension,
				A = this.A
			};
		}

		// Token: 0x06001EE3 RID: 7907 RVA: 0x000C2F84 File Offset: 0x000C1184
		public void CopyFrom(#kqe other)
		{
			this.A = other.A;
			this.B = other.B;
			this.C = other.C;
			this.Trans = other.Trans;
			this.MinDimension = other.MinDimension;
		}

		// Token: 0x04000C44 RID: 3140
		private float #a;

		// Token: 0x04000C45 RID: 3141
		private float #b;

		// Token: 0x04000C46 RID: 3142
		private float #c;

		// Token: 0x04000C47 RID: 3143
		private float #d;

		// Token: 0x04000C48 RID: 3144
		private float #e;
	}
}

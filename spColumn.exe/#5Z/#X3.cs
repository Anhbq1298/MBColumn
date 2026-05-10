using System;
using #7hc;
using #BZ;
using #n8;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x020003AD RID: 941
	[#zZ(typeof(#AZ))]
	internal sealed class #X3 : ValidatableBaseEntity, #q8<#N8>, #N8, ISlendernessOfDesignedColumn
	{
		// Token: 0x06001F4D RID: 8013 RVA: 0x000131A7 File Offset: 0x000113A7
		public #X3()
		{
		}

		// Token: 0x06001F4E RID: 8014 RVA: 0x000C3974 File Offset: 0x000C1B74
		public #X3(SlendernessOfDesignedColumn #Rf)
		{
			this.#a = #Rf.Height;
			this.#b = #Rf.Kbraced;
			this.#c = #Rf.Ksway;
			this.#d = #Rf.IsBraced;
			this.#e = #Rf.CheckSwayAtEndsOnly;
			this.#f = #Rf.Kmode;
			this.#g = #Rf.SumPc;
			this.#h = #Rf.SumPu;
			this.#i = #Rf.EndCondition;
		}

		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06001F4F RID: 8015 RVA: 0x0001E83B File Offset: 0x0001CA3B
		// (set) Token: 0x06001F50 RID: 8016 RVA: 0x0001E847 File Offset: 0x0001CA47
		public float Height
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107412672));
			}
		}

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x06001F51 RID: 8017 RVA: 0x0001E86D File Offset: 0x0001CA6D
		// (set) Token: 0x06001F52 RID: 8018 RVA: 0x0001E879 File Offset: 0x0001CA79
		public float Kbraced
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107412695));
			}
		}

		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x06001F53 RID: 8019 RVA: 0x0001E89F File Offset: 0x0001CA9F
		// (set) Token: 0x06001F54 RID: 8020 RVA: 0x0001E8AB File Offset: 0x0001CAAB
		public float Ksway
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107412650));
			}
		}

		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x06001F55 RID: 8021 RVA: 0x0001E8D1 File Offset: 0x0001CAD1
		// (set) Token: 0x06001F56 RID: 8022 RVA: 0x0001E8DD File Offset: 0x0001CADD
		public bool IsBraced
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<bool>(ref this.#d, value, #Phc.#3hc(107412641));
			}
		}

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06001F57 RID: 8023 RVA: 0x0001E903 File Offset: 0x0001CB03
		// (set) Token: 0x06001F58 RID: 8024 RVA: 0x0001E90F File Offset: 0x0001CB0F
		public bool CheckSwayAtEndsOnly
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<bool>(ref this.#e, value, #Phc.#3hc(107412660));
			}
		}

		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06001F59 RID: 8025 RVA: 0x0001E935 File Offset: 0x0001CB35
		// (set) Token: 0x06001F5A RID: 8026 RVA: 0x0001E941 File Offset: 0x0001CB41
		public Kmode Kmode
		{
			get
			{
				return this.#f;
			}
			set
			{
				base.#Z0<Kmode>(ref this.#f, value, #Phc.#3hc(107412631));
			}
		}

		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06001F5B RID: 8027 RVA: 0x0001E967 File Offset: 0x0001CB67
		// (set) Token: 0x06001F5C RID: 8028 RVA: 0x0001E973 File Offset: 0x0001CB73
		public float SumPc
		{
			get
			{
				return this.#g;
			}
			set
			{
				base.#Z0<float>(ref this.#g, value, #Phc.#3hc(107412590));
			}
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06001F5D RID: 8029 RVA: 0x0001E999 File Offset: 0x0001CB99
		// (set) Token: 0x06001F5E RID: 8030 RVA: 0x0001E9A5 File Offset: 0x0001CBA5
		public float SumPu
		{
			get
			{
				return this.#h;
			}
			set
			{
				base.#Z0<float>(ref this.#h, value, #Phc.#3hc(107412581));
			}
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06001F5F RID: 8031 RVA: 0x0001E9CB File Offset: 0x0001CBCB
		// (set) Token: 0x06001F60 RID: 8032 RVA: 0x0001E9D7 File Offset: 0x0001CBD7
		public EndConditionType EndCondition
		{
			get
			{
				return this.#i;
			}
			set
			{
				base.#Z0<EndConditionType>(ref this.#i, value, #Phc.#3hc(107412527));
			}
		}

		// Token: 0x06001F61 RID: 8033 RVA: 0x000C39F4 File Offset: 0x000C1BF4
		public void CopyFrom(#N8 source)
		{
			this.CheckSwayAtEndsOnly = source.CheckSwayAtEndsOnly;
			this.Height = source.Height;
			this.IsBraced = source.IsBraced;
			this.Kmode = source.Kmode;
			this.Kbraced = source.Kbraced;
			this.Ksway = source.Ksway;
			this.SumPc = source.SumPc;
			this.SumPu = source.SumPu;
			this.EndCondition = source.EndCondition;
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x000C3A7C File Offset: 0x000C1C7C
		public SlendernessOfDesignedColumn #CY()
		{
			return new SlendernessOfDesignedColumn
			{
				Height = this.Height,
				CheckSwayAtEndsOnly = this.CheckSwayAtEndsOnly,
				IsBraced = this.IsBraced,
				Kbraced = this.Kbraced,
				Kmode = this.Kmode,
				Ksway = this.Ksway,
				SumPc = this.SumPc,
				SumPu = this.SumPu,
				EndCondition = this.EndCondition
			};
		}

		// Token: 0x04000C64 RID: 3172
		private float #a;

		// Token: 0x04000C65 RID: 3173
		private float #b;

		// Token: 0x04000C66 RID: 3174
		private float #c;

		// Token: 0x04000C67 RID: 3175
		private bool #d;

		// Token: 0x04000C68 RID: 3176
		private bool #e;

		// Token: 0x04000C69 RID: 3177
		private Kmode #f;

		// Token: 0x04000C6A RID: 3178
		private float #g;

		// Token: 0x04000C6B RID: 3179
		private float #h;

		// Token: 0x04000C6C RID: 3180
		private EndConditionType #i;
	}
}

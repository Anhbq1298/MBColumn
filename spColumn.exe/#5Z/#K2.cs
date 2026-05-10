using System;
using #7hc;
using #9pe;
using #n8;
using #xZ;
using #YZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x020003A2 RID: 930
	[#zZ(typeof(#2Z))]
	internal sealed class #K2 : ValidatableBaseEntity, #q8<#H8>, #Vai, #hqe, #Uai, #iqe, #H8, #jqe
	{
		// Token: 0x06001E76 RID: 7798 RVA: 0x000131A7 File Offset: 0x000113A7
		public #K2()
		{
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x000C2908 File Offset: 0x000C0B08
		public #K2(MaterialProperties #Rf)
		{
			this.#a = #Rf.Fcp;
			this.#b = #Rf.Ec;
			this.#c = #Rf.Fc;
			this.#d = #Rf.Beta1;
			this.#e = #Rf.Eps;
			this.#f = #Rf.Fy;
			this.#g = #Rf.Es;
			this.#h = #Rf.IsConcreteStandard;
			this.#i = #Rf.IsSteelStandard;
			this.#j = #Rf.Eyt;
			this.#k = #Rf.Precast;
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x0001D72B File Offset: 0x0001B92B
		public #K2(#H8 #L0)
		{
			this.CopyFrom(#L0);
		}

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x06001E79 RID: 7801 RVA: 0x0001D73A File Offset: 0x0001B93A
		public static #K2 Empty
		{
			get
			{
				return new #K2();
			}
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x06001E7A RID: 7802 RVA: 0x0001D745 File Offset: 0x0001B945
		// (set) Token: 0x06001E7B RID: 7803 RVA: 0x0001D751 File Offset: 0x0001B951
		public float Fcp
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107412979));
			}
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x06001E7C RID: 7804 RVA: 0x0001D777 File Offset: 0x0001B977
		// (set) Token: 0x06001E7D RID: 7805 RVA: 0x0001D783 File Offset: 0x0001B983
		public float Ec
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107412942));
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06001E7E RID: 7806 RVA: 0x0001D7A9 File Offset: 0x0001B9A9
		// (set) Token: 0x06001E7F RID: 7807 RVA: 0x0001D7B5 File Offset: 0x0001B9B5
		public float Fc
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107407900));
			}
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06001E80 RID: 7808 RVA: 0x0001D7DB File Offset: 0x0001B9DB
		// (set) Token: 0x06001E81 RID: 7809 RVA: 0x0001D7E7 File Offset: 0x0001B9E7
		public float Beta1
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107407895));
			}
		}

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06001E82 RID: 7810 RVA: 0x0001D80D File Offset: 0x0001BA0D
		// (set) Token: 0x06001E83 RID: 7811 RVA: 0x0001D819 File Offset: 0x0001BA19
		public float Eps
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107408366));
			}
		}

		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06001E84 RID: 7812 RVA: 0x0001D83F File Offset: 0x0001BA3F
		// (set) Token: 0x06001E85 RID: 7813 RVA: 0x0001D84B File Offset: 0x0001BA4B
		public float Fy
		{
			get
			{
				return this.#f;
			}
			set
			{
				base.#Z0<float>(ref this.#f, value, #Phc.#3hc(107408699));
			}
		}

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06001E86 RID: 7814 RVA: 0x0001D871 File Offset: 0x0001BA71
		// (set) Token: 0x06001E87 RID: 7815 RVA: 0x0001D87D File Offset: 0x0001BA7D
		public float Es
		{
			get
			{
				return this.#g;
			}
			set
			{
				base.#Z0<float>(ref this.#g, value, #Phc.#3hc(107408672));
			}
		}

		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06001E88 RID: 7816 RVA: 0x0001D8A3 File Offset: 0x0001BAA3
		// (set) Token: 0x06001E89 RID: 7817 RVA: 0x0001D8AF File Offset: 0x0001BAAF
		public bool IsConcreteStandard
		{
			get
			{
				return this.#h;
			}
			set
			{
				base.#Z0<bool>(ref this.#h, value, #Phc.#3hc(107412937));
			}
		}

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x06001E8A RID: 7818 RVA: 0x0001D8D5 File Offset: 0x0001BAD5
		// (set) Token: 0x06001E8B RID: 7819 RVA: 0x0001D8E1 File Offset: 0x0001BAE1
		public bool IsSteelStandard
		{
			get
			{
				return this.#i;
			}
			set
			{
				base.#Z0<bool>(ref this.#i, value, #Phc.#3hc(107408694));
			}
		}

		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x06001E8C RID: 7820 RVA: 0x0001D907 File Offset: 0x0001BB07
		// (set) Token: 0x06001E8D RID: 7821 RVA: 0x0001D913 File Offset: 0x0001BB13
		public float Eyt
		{
			get
			{
				return this.#j;
			}
			set
			{
				base.#Z0<float>(ref this.#j, value, #Phc.#3hc(107408641));
			}
		}

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x06001E8E RID: 7822 RVA: 0x0001D939 File Offset: 0x0001BB39
		// (set) Token: 0x06001E8F RID: 7823 RVA: 0x0001D945 File Offset: 0x0001BB45
		public bool Precast
		{
			get
			{
				return this.#k;
			}
			set
			{
				base.#Z0<bool>(ref this.#k, value, #Phc.#3hc(107408361));
			}
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x000C29A0 File Offset: 0x000C0BA0
		public MaterialProperties #CY()
		{
			return new MaterialProperties
			{
				Ec = this.Ec,
				Fcp = this.Fcp,
				Beta1 = this.Beta1,
				Eps = this.Eps,
				Es = this.Es,
				Eyt = this.Eyt,
				Fc = this.Fc,
				Fy = this.Fy,
				IsConcreteStandard = this.IsConcreteStandard,
				IsSteelStandard = this.IsSteelStandard,
				Precast = this.Precast
			};
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x0001D96B File Offset: 0x0001BB6B
		public float #G2()
		{
			return 0.005f / this.Eps;
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x0001D981 File Offset: 0x0001BB81
		public float #H2()
		{
			return this.Fy / this.Es / this.Eps;
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x0001D9A3 File Offset: 0x0001BBA3
		public float #I2()
		{
			return this.Eyt / this.Eps;
		}

		// Token: 0x06001E94 RID: 7828 RVA: 0x000C2A4C File Offset: 0x000C0C4C
		public bool #J2(#K2 #Vg)
		{
			return this.#a.Equals(#Vg.#a) && this.#b.Equals(#Vg.#b) && this.#c.Equals(#Vg.#c) && this.#e.Equals(#Vg.#e) && this.#f.Equals(#Vg.#f) && this.#g.Equals(#Vg.#g) && this.#d.Equals(#Vg.#d) && this.#j.Equals(#Vg.#j);
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x000C2B14 File Offset: 0x000C0D14
		public void CopyFrom(#H8 other)
		{
			this.Fcp = other.Fcp;
			this.Ec = other.Ec;
			this.Fc = other.Fc;
			this.Beta1 = other.Beta1;
			this.Eps = other.Eps;
			this.Fy = other.Fy;
			this.Es = other.Es;
			this.IsConcreteStandard = other.IsConcreteStandard;
			this.IsSteelStandard = other.IsSteelStandard;
			this.Eyt = other.Eyt;
			this.Precast = other.Precast;
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x0001D9BE File Offset: 0x0001BBBE
		public void #rVh(#Vai #L0)
		{
			this.Fy = #L0.Fy;
			this.Es = #L0.Es;
			this.IsSteelStandard = #L0.IsSteelStandard;
			this.Eyt = #L0.Eyt;
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x000C2BC4 File Offset: 0x000C0DC4
		public void #sVh(#Uai #L0)
		{
			this.Fcp = #L0.Fcp;
			this.Ec = #L0.Ec;
			this.Fc = #L0.Fc;
			this.Beta1 = #L0.Beta1;
			this.Eps = #L0.Eps;
			this.IsConcreteStandard = #L0.IsConcreteStandard;
			this.Precast = #L0.Precast;
		}

		// Token: 0x04000C21 RID: 3105
		private float #a;

		// Token: 0x04000C22 RID: 3106
		private float #b;

		// Token: 0x04000C23 RID: 3107
		private float #c;

		// Token: 0x04000C24 RID: 3108
		private float #d;

		// Token: 0x04000C25 RID: 3109
		private float #e;

		// Token: 0x04000C26 RID: 3110
		private float #f;

		// Token: 0x04000C27 RID: 3111
		private float #g;

		// Token: 0x04000C28 RID: 3112
		private bool #h;

		// Token: 0x04000C29 RID: 3113
		private bool #i;

		// Token: 0x04000C2A RID: 3114
		private float #j;

		// Token: 0x04000C2B RID: 3115
		private bool #k;
	}
}

using System;
using #5Z;
using #7hc;
using #9pe;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020003A8 RID: 936
	[#zZ(typeof(#UZ))]
	internal sealed class ServiceLoad : ValidatableBaseEntity, #pqe
	{
		// Token: 0x06001F00 RID: 7936 RVA: 0x0001E2DC File Offset: 0x0001C4DC
		public ServiceLoad()
		{
			this.#a = new #V3();
			this.#b = new #V3();
			this.#c = new #V3();
			this.#d = new #V3();
			this.#e = new #V3();
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x000C31A0 File Offset: 0x000C13A0
		public ServiceLoad(ServiceLoad item)
		{
			this.#a = new #V3(item.Dead);
			this.#b = new #V3(item.Live);
			this.#c = new #V3(item.Wind);
			this.#d = new #V3(item.Earthquake);
			this.#e = new #V3(item.Snow);
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x000C3208 File Offset: 0x000C1408
		public ServiceLoad(ServiceLoad item)
		{
			this.#a = new #V3(item.Dead);
			this.#b = new #V3(item.Live);
			this.#c = new #V3(item.Wind);
			this.#d = new #V3(item.Earthquake);
			this.#e = new #V3(item.Snow);
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06001F03 RID: 7939 RVA: 0x0001E31B File Offset: 0x0001C51B
		// (set) Token: 0x06001F04 RID: 7940 RVA: 0x0001E327 File Offset: 0x0001C527
		public #V3 Dead
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<#V3>(ref this.#a, value, #Phc.#3hc(107398345));
			}
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x06001F05 RID: 7941 RVA: 0x0001E34D File Offset: 0x0001C54D
		// (set) Token: 0x06001F06 RID: 7942 RVA: 0x0001E359 File Offset: 0x0001C559
		public #V3 Live
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<#V3>(ref this.#b, value, #Phc.#3hc(107398336));
			}
		}

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x06001F07 RID: 7943 RVA: 0x0001E37F File Offset: 0x0001C57F
		// (set) Token: 0x06001F08 RID: 7944 RVA: 0x0001E38B File Offset: 0x0001C58B
		public #V3 Wind
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<#V3>(ref this.#c, value, #Phc.#3hc(107398359));
			}
		}

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x06001F09 RID: 7945 RVA: 0x0001E3B1 File Offset: 0x0001C5B1
		// (set) Token: 0x06001F0A RID: 7946 RVA: 0x0001E3BD File Offset: 0x0001C5BD
		public #V3 Earthquake
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<#V3>(ref this.#d, value, #Phc.#3hc(107398318));
			}
		}

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x0001E3E3 File Offset: 0x0001C5E3
		// (set) Token: 0x06001F0C RID: 7948 RVA: 0x0001E3EF File Offset: 0x0001C5EF
		public #V3 Snow
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<#V3>(ref this.#e, value, #Phc.#3hc(107398333));
			}
		}

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x0001E415 File Offset: 0x0001C615
		// (set) Token: 0x06001F0E RID: 7950 RVA: 0x0001E425 File Offset: 0x0001C625
		#qqe #pqe.Live
		{
			get
			{
				return this.Live;
			}
			set
			{
				this.Live = (#V3)value;
			}
		}

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06001F0F RID: 7951 RVA: 0x0001E43F File Offset: 0x0001C63F
		// (set) Token: 0x06001F10 RID: 7952 RVA: 0x0001E44F File Offset: 0x0001C64F
		#qqe #pqe.Wind
		{
			get
			{
				return this.Wind;
			}
			set
			{
				this.Wind = (#V3)value;
			}
		}

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06001F11 RID: 7953 RVA: 0x0001E469 File Offset: 0x0001C669
		// (set) Token: 0x06001F12 RID: 7954 RVA: 0x0001E479 File Offset: 0x0001C679
		#qqe #pqe.Earthquake
		{
			get
			{
				return this.Earthquake;
			}
			set
			{
				this.Earthquake = (#V3)value;
			}
		}

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06001F13 RID: 7955 RVA: 0x0001E493 File Offset: 0x0001C693
		// (set) Token: 0x06001F14 RID: 7956 RVA: 0x0001E4A3 File Offset: 0x0001C6A3
		#qqe #pqe.Snow
		{
			get
			{
				return this.Snow;
			}
			set
			{
				this.Snow = (#V3)value;
			}
		}

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x0001E4BD File Offset: 0x0001C6BD
		// (set) Token: 0x06001F16 RID: 7958 RVA: 0x0001E4CD File Offset: 0x0001C6CD
		#qqe #pqe.Dead
		{
			get
			{
				return this.Dead;
			}
			set
			{
				this.Dead = (#V3)value;
			}
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x000C3270 File Offset: 0x000C1470
		public bool #U3()
		{
			return this.Snow.#U3() && this.Live.#U3() && this.Wind.#U3() && this.Dead.#U3() && this.Earthquake.#U3();
		}

		// Token: 0x06001F18 RID: 7960 RVA: 0x000C32CC File Offset: 0x000C14CC
		public bool #e(ServiceLoad #L0)
		{
			return #L0 != null && (this.Snow.#e(#L0.Snow) && this.Live.#e(#L0.Live) && this.Wind.#e(#L0.Wind) && this.Dead.#e(#L0.Dead)) && this.Earthquake.#e(#L0.Earthquake);
		}

		// Token: 0x06001F19 RID: 7961 RVA: 0x000C334C File Offset: 0x000C154C
		public ServiceLoad #CY()
		{
			ServiceLoad serviceLoad = new ServiceLoad();
			#V3 #V = this.Snow;
			ServiceLoadCaseData snow;
			if ((snow = ((#V != null) ? #V.#CY() : null)) == null)
			{
				snow = new ServiceLoadCaseData();
			}
			serviceLoad.Snow = snow;
			#V3 #V2 = this.Live;
			ServiceLoadCaseData live;
			if ((live = ((#V2 != null) ? #V2.#CY() : null)) == null)
			{
				live = new ServiceLoadCaseData();
			}
			serviceLoad.Live = live;
			#V3 #V3 = this.Wind;
			ServiceLoadCaseData wind;
			if ((wind = ((#V3 != null) ? #V3.#CY() : null)) == null)
			{
				wind = new ServiceLoadCaseData();
			}
			serviceLoad.Wind = wind;
			#V3 #V4 = this.Dead;
			serviceLoad.Dead = (((#V4 != null) ? #V4.#CY() : null) ?? new ServiceLoadCaseData());
			#V3 #V5 = this.Earthquake;
			serviceLoad.Earthquake = (((#V5 != null) ? #V5.#CY() : null) ?? new ServiceLoadCaseData());
			return serviceLoad;
		}

		// Token: 0x04000C4F RID: 3151
		private #V3 #a;

		// Token: 0x04000C50 RID: 3152
		private #V3 #b;

		// Token: 0x04000C51 RID: 3153
		private #V3 #c;

		// Token: 0x04000C52 RID: 3154
		private #V3 #d;

		// Token: 0x04000C53 RID: 3155
		private #V3 #e;
	}
}

using System;
using #7hc;
using #9pe;
using #n8;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020003AC RID: 940
	[#zZ(typeof(ISlendernessColumnsAboveBelowValidator))]
	internal sealed class SlendernessOfColumn : ValidatableBaseEntity, #q8<#M8>, #M8, #rqe
	{
		// Token: 0x06001F3B RID: 7995 RVA: 0x000131A7 File Offset: 0x000113A7
		public SlendernessOfColumn()
		{
		}

		// Token: 0x06001F3C RID: 7996 RVA: 0x000C3828 File Offset: 0x000C1A28
		public SlendernessOfColumn(SlendernessOfColumn item)
		{
			this.#a = item.Height;
			this.#b = item.Width;
			this.#c = item.Depth;
			this.#d = item.Fcp;
			this.#e = item.Ec;
			this.#f = item.IsConcreteStandard;
			this.#g = item.SlendernessColumnType;
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06001F3D RID: 7997 RVA: 0x0001E6DD File Offset: 0x0001C8DD
		// (set) Token: 0x06001F3E RID: 7998 RVA: 0x0001E6E9 File Offset: 0x0001C8E9
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

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06001F3F RID: 7999 RVA: 0x0001E70F File Offset: 0x0001C90F
		// (set) Token: 0x06001F40 RID: 8000 RVA: 0x0001E71B File Offset: 0x0001C91B
		public float Width
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107412974));
			}
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x0001E741 File Offset: 0x0001C941
		// (set) Token: 0x06001F42 RID: 8002 RVA: 0x0001E74D File Offset: 0x0001C94D
		public float Depth
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107412965));
			}
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06001F43 RID: 8003 RVA: 0x0001E773 File Offset: 0x0001C973
		// (set) Token: 0x06001F44 RID: 8004 RVA: 0x0001E77F File Offset: 0x0001C97F
		public float Fcp
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107412979));
			}
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06001F45 RID: 8005 RVA: 0x0001E7A5 File Offset: 0x0001C9A5
		// (set) Token: 0x06001F46 RID: 8006 RVA: 0x0001E7B1 File Offset: 0x0001C9B1
		public float Ec
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107412942));
			}
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06001F47 RID: 8007 RVA: 0x0001E7D7 File Offset: 0x0001C9D7
		// (set) Token: 0x06001F48 RID: 8008 RVA: 0x0001E7E3 File Offset: 0x0001C9E3
		public bool IsConcreteStandard
		{
			get
			{
				return this.#f;
			}
			set
			{
				base.#Z0<bool>(ref this.#f, value, #Phc.#3hc(107412937));
			}
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06001F49 RID: 8009 RVA: 0x0001E809 File Offset: 0x0001CA09
		// (set) Token: 0x06001F4A RID: 8010 RVA: 0x0001E815 File Offset: 0x0001CA15
		public SlendernessColumnType SlendernessColumnType
		{
			get
			{
				return this.#g;
			}
			set
			{
				base.#Z0<SlendernessColumnType>(ref this.#g, value, #Phc.#3hc(107412919));
			}
		}

		// Token: 0x06001F4B RID: 8011 RVA: 0x000C3890 File Offset: 0x000C1A90
		public void CopyFrom(#M8 source)
		{
			this.Height = source.Height;
			this.Width = source.Width;
			this.Fcp = source.Fcp;
			this.Ec = source.Ec;
			this.Depth = source.Depth;
			this.IsConcreteStandard = source.IsConcreteStandard;
			this.SlendernessColumnType = source.SlendernessColumnType;
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x000C3900 File Offset: 0x000C1B00
		public SlendernessOfColumn #CY()
		{
			return new SlendernessOfColumn
			{
				Height = this.Height,
				Fcp = this.Fcp,
				Ec = this.Ec,
				Width = this.Width,
				Depth = this.Depth,
				IsConcreteStandard = this.IsConcreteStandard,
				SlendernessColumnType = this.SlendernessColumnType
			};
		}

		// Token: 0x04000C5D RID: 3165
		private float #a;

		// Token: 0x04000C5E RID: 3166
		private float #b;

		// Token: 0x04000C5F RID: 3167
		private float #c;

		// Token: 0x04000C60 RID: 3168
		private float #d;

		// Token: 0x04000C61 RID: 3169
		private float #e;

		// Token: 0x04000C62 RID: 3170
		private bool #f;

		// Token: 0x04000C63 RID: 3171
		private SlendernessColumnType #g;
	}
}

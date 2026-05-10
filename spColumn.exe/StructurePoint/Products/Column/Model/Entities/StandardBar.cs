using System;
using #7hc;
using #xZ;
using #YZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x02000241 RID: 577
	[#zZ(typeof(#1Z))]
	internal sealed class StandardBar : ValidatableBaseEntity, IStandardBar
	{
		// Token: 0x0600134F RID: 4943 RVA: 0x00014C5B File Offset: 0x00012E5B
		public StandardBar(int size, float diameter, float area, float weight)
		{
			this.<ValidationResults>k__BackingField = new CustomObservableCollection<ValidationResultItem>();
			base..ctor();
			this.size = size;
			this.diameter = diameter;
			this.area = area;
			this.weight = weight;
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x00014C8B File Offset: 0x00012E8B
		public StandardBar()
		{
			this.<ValidationResults>k__BackingField = new CustomObservableCollection<ValidationResultItem>();
			base..ctor();
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x000AE2DC File Offset: 0x000AC4DC
		public StandardBar(StandardBar item)
		{
			this.<ValidationResults>k__BackingField = new CustomObservableCollection<ValidationResultItem>();
			base..ctor();
			this.size = item.Size;
			this.diameter = item.Diameter;
			this.area = item.Area;
			this.weight = item.Weight;
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06001352 RID: 4946 RVA: 0x00014C9E File Offset: 0x00012E9E
		// (set) Token: 0x06001353 RID: 4947 RVA: 0x00014CAA File Offset: 0x00012EAA
		public int Size
		{
			get
			{
				return this.size;
			}
			set
			{
				base.#Z0<int>(ref this.size, value, #Phc.#3hc(107397811));
			}
		}

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001354 RID: 4948 RVA: 0x00014CD0 File Offset: 0x00012ED0
		// (set) Token: 0x06001355 RID: 4949 RVA: 0x00014CDC File Offset: 0x00012EDC
		public float Diameter
		{
			get
			{
				return this.diameter;
			}
			set
			{
				base.#Z0<float>(ref this.diameter, value, #Phc.#3hc(107397770));
			}
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001356 RID: 4950 RVA: 0x00014D02 File Offset: 0x00012F02
		// (set) Token: 0x06001357 RID: 4951 RVA: 0x00014D0E File Offset: 0x00012F0E
		public float Area
		{
			get
			{
				return this.area;
			}
			set
			{
				base.#Z0<float>(ref this.area, value, #Phc.#3hc(107397869));
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001358 RID: 4952 RVA: 0x00014D34 File Offset: 0x00012F34
		// (set) Token: 0x06001359 RID: 4953 RVA: 0x00014D40 File Offset: 0x00012F40
		public float Weight
		{
			get
			{
				return this.weight;
			}
			set
			{
				base.#Z0<float>(ref this.weight, value, #Phc.#3hc(107397789));
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x00014D66 File Offset: 0x00012F66
		public string DisplayValue
		{
			get
			{
				return string.Format(#Phc.#3hc(107397780), this.Size);
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x0600135B RID: 4955 RVA: 0x00014D8E File Offset: 0x00012F8E
		// (set) Token: 0x0600135C RID: 4956 RVA: 0x00014D9A File Offset: 0x00012F9A
		public bool HasCustomValidationError
		{
			get
			{
				return this.hasCustomValidationError;
			}
			set
			{
				this.SetProperty<bool>(ref this.hasCustomValidationError, value, #Phc.#3hc(107398324));
			}
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x00014DC0 File Offset: 0x00012FC0
		public CustomObservableCollection<ValidationResultItem> ValidationResults { get; }

		// Token: 0x0600135E RID: 4958 RVA: 0x000AE32C File Offset: 0x000AC52C
		public StandardBar ToStorageModel()
		{
			return new StandardBar
			{
				Area = this.Area,
				Diameter = this.Diameter,
				Size = this.Size,
				Weight = this.Weight
			};
		}

		// Token: 0x040007F6 RID: 2038
		private int size;

		// Token: 0x040007F7 RID: 2039
		private float diameter;

		// Token: 0x040007F8 RID: 2040
		private float area;

		// Token: 0x040007F9 RID: 2041
		private float weight;

		// Token: 0x040007FA RID: 2042
		private bool hasCustomValidationError;
	}
}

using System;
using System.Runtime.CompilerServices;
using #7hc;
using #9pe;
using #QZ;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x0200024A RID: 586
	[#zZ(typeof(#SZ))]
	internal sealed class LoadFactor : ValidatableBaseEntity, #gqe
	{
		// Token: 0x06001394 RID: 5012 RVA: 0x00014FA5 File Offset: 0x000131A5
		public LoadFactor()
		{
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x00014FB8 File Offset: 0x000131B8
		public LoadFactor(float dead, float live, float wind, float earthquake, float snow)
		{
			this.#a = dead;
			this.#b = live;
			this.#c = wind;
			this.#d = earthquake;
			this.#e = snow;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x000AED90 File Offset: 0x000ACF90
		public LoadFactor(LoadFactor item)
		{
			this.#a = item.Dead;
			this.#b = item.Live;
			this.#c = item.Wind;
			this.#d = item.Earthquake;
			this.#e = item.Snow;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x000AEDEC File Offset: 0x000ACFEC
		public LoadFactor(LoadFactor other)
		{
			this.#a = other.Dead;
			this.#b = other.Live;
			this.#c = other.Wind;
			this.#d = other.Earthquake;
			this.#e = other.Snow;
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001398 RID: 5016 RVA: 0x00014FF0 File Offset: 0x000131F0
		// (set) Token: 0x06001399 RID: 5017 RVA: 0x00014FFC File Offset: 0x000131FC
		public float Dead
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107398345));
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x0600139A RID: 5018 RVA: 0x00015022 File Offset: 0x00013222
		// (set) Token: 0x0600139B RID: 5019 RVA: 0x0001502E File Offset: 0x0001322E
		public float Live
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107398336));
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x0600139C RID: 5020 RVA: 0x00015054 File Offset: 0x00013254
		// (set) Token: 0x0600139D RID: 5021 RVA: 0x00015060 File Offset: 0x00013260
		public float Wind
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107398359));
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x0600139E RID: 5022 RVA: 0x00015086 File Offset: 0x00013286
		// (set) Token: 0x0600139F RID: 5023 RVA: 0x00015092 File Offset: 0x00013292
		public float Earthquake
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107398318));
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x060013A0 RID: 5024 RVA: 0x000150B8 File Offset: 0x000132B8
		// (set) Token: 0x060013A1 RID: 5025 RVA: 0x000150C4 File Offset: 0x000132C4
		public float Snow
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107398333));
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x060013A2 RID: 5026 RVA: 0x000150EA File Offset: 0x000132EA
		// (set) Token: 0x060013A3 RID: 5027 RVA: 0x000150F6 File Offset: 0x000132F6
		public bool HasCustomValidationError
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107398324));
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060013A4 RID: 5028 RVA: 0x0001511C File Offset: 0x0001331C
		public CustomObservableCollection<ValidationResultItem> ValidationResults { get; }

		// Token: 0x060013A5 RID: 5029 RVA: 0x000AEE48 File Offset: 0x000AD048
		public LoadFactor #CY()
		{
			return new LoadFactor
			{
				Wind = this.Wind,
				Snow = this.Snow,
				Live = this.Live,
				Earthquake = this.Earthquake,
				Dead = this.Dead
			};
		}

		// Token: 0x04000807 RID: 2055
		private float #a;

		// Token: 0x04000808 RID: 2056
		private float #b;

		// Token: 0x04000809 RID: 2057
		private float #c;

		// Token: 0x0400080A RID: 2058
		private float #d;

		// Token: 0x0400080B RID: 2059
		private float #e;

		// Token: 0x0400080C RID: 2060
		private bool #f;

		// Token: 0x0400080D RID: 2061
		[CompilerGenerated]
		private readonly CustomObservableCollection<ValidationResultItem> #g = new CustomObservableCollection<ValidationResultItem>();
	}
}

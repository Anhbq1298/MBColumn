using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #f7
{
	// Token: 0x020003C0 RID: 960
	internal sealed class #H7 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x060020D5 RID: 8405 RVA: 0x0002022A File Offset: 0x0001E42A
		// (set) Token: 0x060020D6 RID: 8406 RVA: 0x00020236 File Offset: 0x0001E436
		public bool ShowCoordinates
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397957));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397957));
				}
			}
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x060020D7 RID: 8407 RVA: 0x00020274 File Offset: 0x0001E474
		// (set) Token: 0x060020D8 RID: 8408 RVA: 0x00020280 File Offset: 0x0001E480
		public int FloatingPointPrecision
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397968));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397968));
				}
			}
		}

		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x060020D9 RID: 8409 RVA: 0x000202BE File Offset: 0x0001E4BE
		// (set) Token: 0x060020DA RID: 8410 RVA: 0x000202CA File Offset: 0x0001E4CA
		public int FootInchPrecision
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397903));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397903));
				}
			}
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x00020308 File Offset: 0x0001E508
		public StatusBarSettings #CY()
		{
			return new StatusBarSettings
			{
				ShowCoordinates = this.ShowCoordinates,
				FloatingPointPrecision = this.FloatingPointPrecision,
				FootInchPrecision = this.FootInchPrecision
			};
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x0002033F File Offset: 0x0001E53F
		public static #H7 #c7(StatusBarSettings #G7)
		{
			return new #H7
			{
				ShowCoordinates = #G7.ShowCoordinates,
				FloatingPointPrecision = #G7.FloatingPointPrecision,
				FootInchPrecision = #G7.FootInchPrecision
			};
		}

		// Token: 0x04000D45 RID: 3397
		private bool #a;

		// Token: 0x04000D46 RID: 3398
		private int #b;

		// Token: 0x04000D47 RID: 3399
		private int #c;
	}
}

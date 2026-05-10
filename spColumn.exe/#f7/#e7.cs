using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #f7
{
	// Token: 0x020003BC RID: 956
	internal sealed class #e7 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002099 RID: 8345 RVA: 0x0001FB06 File Offset: 0x0001DD06
		public #e7()
		{
			this.DrawingGridSettings = new #j7();
			this.DynamicInputSettings = new #n7();
			this.SnappingSettings = new #z7();
			this.StatusBarSettings = new #H7();
		}

		// Token: 0x17000B4E RID: 2894
		// (get) Token: 0x0600209A RID: 8346 RVA: 0x0001FB3A File Offset: 0x0001DD3A
		// (set) Token: 0x0600209B RID: 8347 RVA: 0x0001FB46 File Offset: 0x0001DD46
		public #j7 DrawingGridSettings
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397724));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397724));
				}
			}
		}

		// Token: 0x17000B4F RID: 2895
		// (get) Token: 0x0600209C RID: 8348 RVA: 0x0001FB84 File Offset: 0x0001DD84
		// (set) Token: 0x0600209D RID: 8349 RVA: 0x0001FB90 File Offset: 0x0001DD90
		public #n7 DynamicInputSettings
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397695));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397695));
				}
			}
		}

		// Token: 0x17000B50 RID: 2896
		// (get) Token: 0x0600209E RID: 8350 RVA: 0x0001FBCE File Offset: 0x0001DDCE
		// (set) Token: 0x0600209F RID: 8351 RVA: 0x0001FBDA File Offset: 0x0001DDDA
		public #z7 SnappingSettings
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397634));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397634));
				}
			}
		}

		// Token: 0x17000B51 RID: 2897
		// (get) Token: 0x060020A0 RID: 8352 RVA: 0x0001FC18 File Offset: 0x0001DE18
		// (set) Token: 0x060020A1 RID: 8353 RVA: 0x0001FC24 File Offset: 0x0001DE24
		public #H7 StatusBarSettings
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398121));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398121));
				}
			}
		}

		// Token: 0x060020A2 RID: 8354 RVA: 0x000C6A10 File Offset: 0x000C4C10
		public DraftingSettings #CY()
		{
			return new DraftingSettings
			{
				DrawingGridSettings = this.DrawingGridSettings.#CY(),
				DynamicInputSettings = this.DynamicInputSettings.#CY(),
				SnappingSettings = this.SnappingSettings.#CY(),
				StatusBarSettings = this.StatusBarSettings.#CY()
			};
		}

		// Token: 0x060020A3 RID: 8355 RVA: 0x000C6A74 File Offset: 0x000C4C74
		public static #e7 #c7(DraftingSettings #d7)
		{
			return new #e7
			{
				DrawingGridSettings = #j7.#c7(#d7.DrawingGridSettings),
				DynamicInputSettings = #n7.#c7(#d7.DynamicInputSettings),
				SnappingSettings = #z7.#c7(#d7.SnappingSettings),
				StatusBarSettings = #H7.#c7(#d7.StatusBarSettings)
			};
		}

		// Token: 0x04000D2D RID: 3373
		private #j7 #a;

		// Token: 0x04000D2E RID: 3374
		private #n7 #b;

		// Token: 0x04000D2F RID: 3375
		private #z7 #c;

		// Token: 0x04000D30 RID: 3376
		private #H7 #d;
	}
}

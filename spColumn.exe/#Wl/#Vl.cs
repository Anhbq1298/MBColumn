using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #Wl
{
	// Token: 0x020000FF RID: 255
	internal sealed class #Vl : NotifyPropertyChangedObjectBase
	{
		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0000C497 File Offset: 0x0000A697
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x0000C4A3 File Offset: 0x0000A6A3
		public bool IsSnapChecked
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381569));
				}
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0000C4D1 File Offset: 0x0000A6D1
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x0000C4DD File Offset: 0x0000A6DD
		public bool IsObjectSnapChecked
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381548));
				}
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0000C50B File Offset: 0x0000A70B
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0000C517 File Offset: 0x0000A717
		public bool IsDrawingGridChecked
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381519));
				}
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0000C545 File Offset: 0x0000A745
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0000C551 File Offset: 0x0000A751
		public bool IsDynamicInputChecked
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381522));
				}
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0000C57F File Offset: 0x0000A77F
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0000C58B File Offset: 0x0000A78B
		public bool IsOrthoChecked
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380981));
				}
			}
		}

		// Token: 0x040002AC RID: 684
		private bool #a;

		// Token: 0x040002AD RID: 685
		private bool #b;

		// Token: 0x040002AE RID: 686
		private bool #c;

		// Token: 0x040002AF RID: 687
		private bool #d;

		// Token: 0x040002B0 RID: 688
		private bool #e;
	}
}

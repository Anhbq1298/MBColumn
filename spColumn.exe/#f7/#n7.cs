using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #f7
{
	// Token: 0x020003BE RID: 958
	internal sealed class #n7 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B56 RID: 2902
		// (get) Token: 0x060020AF RID: 8367 RVA: 0x0001FD8A File Offset: 0x0001DF8A
		// (set) Token: 0x060020B0 RID: 8368 RVA: 0x0001FD96 File Offset: 0x0001DF96
		public bool ShowPrompt
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380834));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380834));
				}
			}
		}

		// Token: 0x17000B57 RID: 2903
		// (get) Token: 0x060020B1 RID: 8369 RVA: 0x0001FDD4 File Offset: 0x0001DFD4
		// (set) Token: 0x060020B2 RID: 8370 RVA: 0x0001FDE0 File Offset: 0x0001DFE0
		public bool ShowInputBoxes
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380887));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380887));
				}
			}
		}

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x060020B3 RID: 8371 RVA: 0x0001FE1E File Offset: 0x0001E01E
		// (set) Token: 0x060020B4 RID: 8372 RVA: 0x0001FE2A File Offset: 0x0001E02A
		public bool Enabled
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398111));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398111));
				}
			}
		}

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x060020B5 RID: 8373 RVA: 0x0001FE68 File Offset: 0x0001E068
		// (set) Token: 0x060020B6 RID: 8374 RVA: 0x0001FE74 File Offset: 0x0001E074
		public int Precision
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380928));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x000C6B78 File Offset: 0x000C4D78
		public DynamicInputSettings #CY()
		{
			return new DynamicInputSettings
			{
				ShowPrompt = this.ShowPrompt,
				ShowInputBoxes = this.ShowInputBoxes,
				Enabled = this.Enabled,
				Precision = this.Precision
			};
		}

		// Token: 0x060020B8 RID: 8376 RVA: 0x000C6BC8 File Offset: 0x000C4DC8
		public static #n7 #c7(DynamicInputSettings #m7)
		{
			return new #n7
			{
				ShowPrompt = #m7.ShowPrompt,
				ShowInputBoxes = #m7.ShowInputBoxes,
				Enabled = #m7.Enabled,
				Precision = #m7.Precision
			};
		}

		// Token: 0x04000D35 RID: 3381
		private int #a;

		// Token: 0x04000D36 RID: 3382
		private bool #b;

		// Token: 0x04000D37 RID: 3383
		private bool #c;

		// Token: 0x04000D38 RID: 3384
		private bool #d;
	}
}

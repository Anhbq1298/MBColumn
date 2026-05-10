using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #f7
{
	// Token: 0x020003BD RID: 957
	internal sealed class #j7 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B52 RID: 2898
		// (get) Token: 0x060020A4 RID: 8356 RVA: 0x0001FC62 File Offset: 0x0001DE62
		// (set) Token: 0x060020A5 RID: 8357 RVA: 0x0001FC6E File Offset: 0x0001DE6E
		public double SpacingX
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380947));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380947));
				}
			}
		}

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x060020A6 RID: 8358 RVA: 0x0001FCAC File Offset: 0x0001DEAC
		// (set) Token: 0x060020A7 RID: 8359 RVA: 0x0001FCB8 File Offset: 0x0001DEB8
		public double SpacingY
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380902));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380902));
				}
			}
		}

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x060020A8 RID: 8360 RVA: 0x0001FCF6 File Offset: 0x0001DEF6
		// (set) Token: 0x060020A9 RID: 8361 RVA: 0x0001FD02 File Offset: 0x0001DF02
		public bool GridEnabled
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398128));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398128));
				}
			}
		}

		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x060020AA RID: 8362 RVA: 0x0001FD40 File Offset: 0x0001DF40
		// (set) Token: 0x060020AB RID: 8363 RVA: 0x0001FD4C File Offset: 0x0001DF4C
		public bool EqualXAndYSpacing
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380921));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380921));
				}
			}
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x000C6AD8 File Offset: 0x000C4CD8
		public DrawingGridSettings #CY()
		{
			return new DrawingGridSettings
			{
				SpacingX = this.SpacingX,
				SpacingY = this.SpacingY,
				GridEnabled = this.GridEnabled,
				EqualXAndYSpacing = this.EqualXAndYSpacing
			};
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x000C6B28 File Offset: 0x000C4D28
		public static #j7 #c7(DrawingGridSettings #i7)
		{
			return new #j7
			{
				SpacingX = #i7.SpacingX,
				SpacingY = #i7.SpacingY,
				GridEnabled = #i7.GridEnabled,
				EqualXAndYSpacing = #i7.EqualXAndYSpacing
			};
		}

		// Token: 0x04000D31 RID: 3377
		private double #a;

		// Token: 0x04000D32 RID: 3378
		private double #b;

		// Token: 0x04000D33 RID: 3379
		private bool #c;

		// Token: 0x04000D34 RID: 3380
		private bool #d;
	}
}

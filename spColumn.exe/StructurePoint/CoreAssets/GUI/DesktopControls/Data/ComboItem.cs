using System;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A11 RID: 2577
	public class ComboItem<TValue> : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060054FB RID: 21755 RVA: 0x0004666F File Offset: 0x0004486F
		public ComboItem(TValue value, string displayValue)
		{
			this.Value = value;
			this.DisplayValue = displayValue;
		}

		// Token: 0x17001878 RID: 6264
		// (get) Token: 0x060054FC RID: 21756 RVA: 0x00046685 File Offset: 0x00044885
		// (set) Token: 0x060054FD RID: 21757 RVA: 0x00046691 File Offset: 0x00044891
		public TValue Value { get; private set; }

		// Token: 0x17001879 RID: 6265
		// (get) Token: 0x060054FE RID: 21758 RVA: 0x000466A2 File Offset: 0x000448A2
		// (set) Token: 0x060054FF RID: 21759 RVA: 0x00164CDC File Offset: 0x00162EDC
		public string DisplayValue
		{
			get
			{
				return this.displayValue;
			}
			set
			{
				if (this.displayValue != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107462980));
					this.displayValue = value;
					base.RaisePropertyChanged(#Phc.#3hc(107462980));
				}
			}
		}

		// Token: 0x0400244E RID: 9294
		private string displayValue;
	}
}

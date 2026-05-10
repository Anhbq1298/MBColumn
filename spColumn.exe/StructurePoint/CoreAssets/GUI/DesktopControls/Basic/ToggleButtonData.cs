using System;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ACE RID: 2766
	public class ToggleButtonData : ButtonData, IButtonData, IToggleButtonData
	{
		// Token: 0x1700196D RID: 6509
		// (get) Token: 0x06005A0E RID: 23054 RVA: 0x0004AD8B File Offset: 0x00048F8B
		// (set) Token: 0x06005A0F RID: 23055 RVA: 0x0016E040 File Offset: 0x0016C240
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				bool flag = this.isChecked;
				if (flag != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.isChecked = value;
					this.OnIsCheckedChanged(flag, value);
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x14000161 RID: 353
		// (add) Token: 0x06005A10 RID: 23056 RVA: 0x0016E094 File Offset: 0x0016C294
		// (remove) Token: 0x06005A11 RID: 23057 RVA: 0x0016E0D8 File Offset: 0x0016C2D8
		public event EventHandler IsCheckedChanged;

		// Token: 0x06005A12 RID: 23058 RVA: 0x0016E11C File Offset: 0x0016C31C
		protected virtual void OnIsCheckedChanged(bool oldValue, bool newValue)
		{
			EventHandler isCheckedChanged = this.IsCheckedChanged;
			if (isCheckedChanged != null)
			{
				isCheckedChanged(this, new EventArgs());
			}
		}

		// Token: 0x04002597 RID: 9623
		private bool isChecked;
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A5 RID: 2213
	public sealed class RibbonToggleButtonGroup : RibbonButton
	{
		// Token: 0x060045CF RID: 17871 RVA: 0x0003A564 File Offset: 0x00038764
		public RibbonToggleButtonGroup()
		{
			this.buttons = new ObservableCollection<RibbonToggleButton>();
		}

		// Token: 0x17001468 RID: 5224
		// (get) Token: 0x060045D0 RID: 17872 RVA: 0x0003A577 File Offset: 0x00038777
		public IEnumerable<RibbonToggleButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x140000E1 RID: 225
		// (add) Token: 0x060045D1 RID: 17873 RVA: 0x0013D380 File Offset: 0x0013B580
		// (remove) Token: 0x060045D2 RID: 17874 RVA: 0x0013D3C4 File Offset: 0x0013B5C4
		public event EventHandler<ToggleButtonIsCheckedChangedEventArgs> ToggleButtonIsCheckedChanged;

		// Token: 0x060045D3 RID: 17875 RVA: 0x0013D408 File Offset: 0x0013B608
		protected void OnToggleButtonIsCheckedChanged(ToggleButtonIsCheckedChangedEventArgs e)
		{
			EventHandler<ToggleButtonIsCheckedChangedEventArgs> toggleButtonIsCheckedChanged = this.ToggleButtonIsCheckedChanged;
			if (toggleButtonIsCheckedChanged != null)
			{
				toggleButtonIsCheckedChanged(this, e);
			}
		}

		// Token: 0x060045D4 RID: 17876 RVA: 0x0013D434 File Offset: 0x0013B634
		public void AddButton(RibbonToggleButton button)
		{
			#X0d.#V0d(button, #Phc.#3hc(107454381), Component.DesktopControls, #Phc.#3hc(107454319));
			this.buttons.Add(button);
			button.IsCheckedChanged += this.Button_IsCheckedChanged;
		}

		// Token: 0x060045D5 RID: 17877 RVA: 0x0003A583 File Offset: 0x00038783
		private void Button_IsCheckedChanged(object sender, IsCheckedChangedEventArgs<object> e)
		{
			this.OnToggleButtonIsCheckedChanged(new ToggleButtonIsCheckedChangedEventArgs(e.Value, e.IsChecked));
		}

		// Token: 0x04001FB0 RID: 8112
		private readonly ObservableCollection<RibbonToggleButton> buttons;
	}
}

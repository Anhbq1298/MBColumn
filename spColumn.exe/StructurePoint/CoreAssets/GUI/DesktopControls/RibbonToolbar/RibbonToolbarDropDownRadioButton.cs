using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FD RID: 2301
	public sealed class RibbonToolbarDropDownRadioButton : RibbonToolbarRadioButton, IRibbonToolbarButton, IRibbonToolbarRadioButton, IRibbonToolbarDropDownRadioButton
	{
		// Token: 0x0600495E RID: 18782 RVA: 0x0003DD61 File Offset: 0x0003BF61
		public RibbonToolbarDropDownRadioButton()
		{
			this.childButtons = new ObservableCollection<IRibbonToolbarRadioButton>();
			base.IsEnabled = true;
		}

		// Token: 0x0600495F RID: 18783 RVA: 0x00144E50 File Offset: 0x00143050
		public RibbonToolbarDropDownRadioButton(IEnumerable<IRibbonToolbarRadioButton> buttons)
		{
			this.childButtons = new ObservableCollection<IRibbonToolbarRadioButton>(buttons);
			this.SelectedButton = this.childButtons.FirstOrDefault<IRibbonToolbarRadioButton>();
			base.IsEnabled = true;
			if (this.SelectedButton != null)
			{
				base.GroupName = this.SelectedButton.GroupName;
			}
		}

		// Token: 0x1700157F RID: 5503
		// (get) Token: 0x06004960 RID: 18784 RVA: 0x0003DD7B File Offset: 0x0003BF7B
		public IEnumerable<IRibbonToolbarRadioButton> ChildButtons
		{
			get
			{
				return this.childButtons;
			}
		}

		// Token: 0x17001580 RID: 5504
		// (get) Token: 0x06004961 RID: 18785 RVA: 0x0003DD87 File Offset: 0x0003BF87
		// (set) Token: 0x06004962 RID: 18786 RVA: 0x00144EA0 File Offset: 0x001430A0
		public IRibbonToolbarRadioButton SelectedButton
		{
			get
			{
				return this.selectedButton;
			}
			set
			{
				if (this.selectedButton != value && value != null)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450239));
					this.selectedButton = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450239));
				}
			}
		}

		// Token: 0x040020E6 RID: 8422
		private ObservableCollection<IRibbonToolbarRadioButton> childButtons;

		// Token: 0x040020E7 RID: 8423
		private IRibbonToolbarRadioButton selectedButton;
	}
}

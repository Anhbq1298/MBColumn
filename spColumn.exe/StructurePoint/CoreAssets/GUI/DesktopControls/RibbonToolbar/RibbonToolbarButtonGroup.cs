using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FC RID: 2300
	public sealed class RibbonToolbarButtonGroup : RibbonToolbarButton
	{
		// Token: 0x06004959 RID: 18777 RVA: 0x0003DCC3 File Offset: 0x0003BEC3
		public RibbonToolbarButtonGroup(IEnumerable<IRibbonToolbarButton> buttons, Orientation orientation)
		{
			this.buttons = new ObservableCollection<IRibbonToolbarButton>(buttons);
			this.orientation = orientation;
		}

		// Token: 0x0600495A RID: 18778 RVA: 0x0003DCDE File Offset: 0x0003BEDE
		public RibbonToolbarButtonGroup(IRibbonToolbarButton firstButton, IRibbonToolbarButton secondButton, Orientation orientation)
		{
			this.buttons = new ObservableCollection<IRibbonToolbarButton>(new List<IRibbonToolbarButton>
			{
				firstButton,
				secondButton
			});
			this.orientation = orientation;
		}

		// Token: 0x1700157D RID: 5501
		// (get) Token: 0x0600495B RID: 18779 RVA: 0x0003DD0B File Offset: 0x0003BF0B
		public IEnumerable<IRibbonToolbarButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x1700157E RID: 5502
		// (get) Token: 0x0600495C RID: 18780 RVA: 0x0003DD17 File Offset: 0x0003BF17
		// (set) Token: 0x0600495D RID: 18781 RVA: 0x0003DD23 File Offset: 0x0003BF23
		public Orientation Orientation
		{
			get
			{
				return this.orientation;
			}
			set
			{
				if (this.orientation != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450099));
					this.orientation = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450099));
				}
			}
		}

		// Token: 0x040020E4 RID: 8420
		private ObservableCollection<IRibbonToolbarButton> buttons;

		// Token: 0x040020E5 RID: 8421
		private Orientation orientation;
	}
}

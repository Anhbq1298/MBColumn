using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008AB RID: 2219
	public sealed class RibbonButtonGroup : RibbonButton
	{
		// Token: 0x060045F3 RID: 17907 RVA: 0x0003A778 File Offset: 0x00038978
		public RibbonButtonGroup()
		{
			this.buttons = new ObservableCollection<RibbonButton>();
		}

		// Token: 0x17001475 RID: 5237
		// (get) Token: 0x060045F4 RID: 17908 RVA: 0x0003A78B File Offset: 0x0003898B
		public IEnumerable<RibbonButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x060045F5 RID: 17909 RVA: 0x0003A797 File Offset: 0x00038997
		public void AddButton(RibbonButton button)
		{
			#X0d.#V0d(button, #Phc.#3hc(107454381), Component.DesktopControls, #Phc.#3hc(107454319));
			this.buttons.Add(button);
		}

		// Token: 0x04001FC0 RID: 8128
		private readonly ObservableCollection<RibbonButton> buttons;
	}
}

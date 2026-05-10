using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FF RID: 2303
	public sealed class RibbonToolbarGroup : NotifyPropertyChangedObjectBase
	{
		// Token: 0x0600496B RID: 18795 RVA: 0x0003DE25 File Offset: 0x0003C025
		public RibbonToolbarGroup()
		{
			this.buttons = new ObservableCollection<IRibbonToolbarButton>();
		}

		// Token: 0x0600496C RID: 18796 RVA: 0x0003DE38 File Offset: 0x0003C038
		public RibbonToolbarGroup(IEnumerable<IRibbonToolbarButton> buttons)
		{
			this.buttons = new ObservableCollection<IRibbonToolbarButton>(buttons);
			this.HeaderVisibility = Visibility.Collapsed;
		}

		// Token: 0x0600496D RID: 18797 RVA: 0x0003DE53 File Offset: 0x0003C053
		public RibbonToolbarGroup(IEnumerable<IRibbonToolbarButton> buttons, string header, ToolbarGroupHeaderPosition headerPosition)
		{
			this.buttons = new ObservableCollection<IRibbonToolbarButton>(buttons);
			this.Header = header;
			this.HeaderPosition = headerPosition;
			this.HeaderVisibility = Visibility.Visible;
		}

		// Token: 0x17001583 RID: 5507
		// (get) Token: 0x0600496E RID: 18798 RVA: 0x0003DE7C File Offset: 0x0003C07C
		public IEnumerable<IRibbonToolbarButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x17001584 RID: 5508
		// (get) Token: 0x0600496F RID: 18799 RVA: 0x0003DE88 File Offset: 0x0003C088
		// (set) Token: 0x06004970 RID: 18800 RVA: 0x00144F3C File Offset: 0x0014313C
		public string Header
		{
			get
			{
				return this.header;
			}
			set
			{
				if (this.header != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450197));
					this.header = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450197));
				}
			}
		}

		// Token: 0x17001585 RID: 5509
		// (get) Token: 0x06004971 RID: 18801 RVA: 0x0003DE94 File Offset: 0x0003C094
		// (set) Token: 0x06004972 RID: 18802 RVA: 0x0003DEA0 File Offset: 0x0003C0A0
		public Visibility HeaderVisibility
		{
			get
			{
				return this.headerVisibility;
			}
			set
			{
				if (this.headerVisibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450156));
					this.headerVisibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450156));
				}
			}
		}

		// Token: 0x17001586 RID: 5510
		// (get) Token: 0x06004973 RID: 18803 RVA: 0x0003DEDE File Offset: 0x0003C0DE
		// (set) Token: 0x06004974 RID: 18804 RVA: 0x0003DEEA File Offset: 0x0003C0EA
		public ToolbarGroupHeaderPosition HeaderPosition
		{
			get
			{
				return this.headerPosition;
			}
			set
			{
				if (this.headerPosition != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450163));
					this.headerPosition = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450163));
				}
			}
		}

		// Token: 0x06004975 RID: 18805 RVA: 0x0003DF28 File Offset: 0x0003C128
		public void AddButton(IRibbonToolbarButton button)
		{
			#X0d.#V0d(button, #Phc.#3hc(107454381), Component.DesktopControls, #Phc.#3hc(107450142));
			this.buttons.Add(button);
		}

		// Token: 0x040020EA RID: 8426
		private ObservableCollection<IRibbonToolbarButton> buttons;

		// Token: 0x040020EB RID: 8427
		private string header;

		// Token: 0x040020EC RID: 8428
		private Visibility headerVisibility;

		// Token: 0x040020ED RID: 8429
		private ToolbarGroupHeaderPosition headerPosition;
	}
}

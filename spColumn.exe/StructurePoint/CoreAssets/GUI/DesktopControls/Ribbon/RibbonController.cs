using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008AA RID: 2218
	public sealed class RibbonController : NotifyPropertyChangedObjectBase, IRibbonController
	{
		// Token: 0x060045E7 RID: 17895 RVA: 0x0013D4CC File Offset: 0x0013B6CC
		public RibbonController(RibbonControl ribbonControl)
		{
			#X0d.#V0d(ribbonControl, #Phc.#3hc(107454237), Component.GUI, #Phc.#3hc(107453672));
			ribbonControl.DataContext = this;
			this.tabs = new ObservableCollection<RibbonTab>();
			this.quickAccessItems = new ObservableCollection<RibbonButton>();
			this.applicationMenuItems = new ObservableCollection<RibbonBackstageButton>();
		}

		// Token: 0x1700146E RID: 5230
		// (get) Token: 0x060045E8 RID: 17896 RVA: 0x0003A6A8 File Offset: 0x000388A8
		public IList<RibbonTab> Tabs
		{
			get
			{
				return this.tabs;
			}
		}

		// Token: 0x1700146F RID: 5231
		// (get) Token: 0x060045E9 RID: 17897 RVA: 0x0003A6B4 File Offset: 0x000388B4
		public IList<RibbonButton> QuickAccessItems
		{
			get
			{
				return this.quickAccessItems;
			}
		}

		// Token: 0x17001470 RID: 5232
		// (get) Token: 0x060045EA RID: 17898 RVA: 0x0003A6C0 File Offset: 0x000388C0
		public IList<RibbonBackstageButton> ApplicationMenuItems
		{
			get
			{
				return this.applicationMenuItems;
			}
		}

		// Token: 0x17001471 RID: 5233
		// (get) Token: 0x060045EB RID: 17899 RVA: 0x0003A6CC File Offset: 0x000388CC
		// (set) Token: 0x060045EC RID: 17900 RVA: 0x0003A6D8 File Offset: 0x000388D8
		public RibbonTab SelectedTab
		{
			get
			{
				return this.selectedTab;
			}
			set
			{
				if (this.selectedTab != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453651));
					this.selectedTab = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453651));
				}
			}
		}

		// Token: 0x17001472 RID: 5234
		// (get) Token: 0x060045ED RID: 17901 RVA: 0x0003A716 File Offset: 0x00038916
		// (set) Token: 0x060045EE RID: 17902 RVA: 0x0013D524 File Offset: 0x0013B724
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408142));
					this.title = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408142));
				}
			}
		}

		// Token: 0x17001473 RID: 5235
		// (get) Token: 0x060045EF RID: 17903 RVA: 0x0003A722 File Offset: 0x00038922
		// (set) Token: 0x060045F0 RID: 17904 RVA: 0x0013D574 File Offset: 0x0013B774
		public string AppName
		{
			get
			{
				return this.appName;
			}
			set
			{
				if (this.appName != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453602));
					this.appName = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453602));
				}
			}
		}

		// Token: 0x17001474 RID: 5236
		// (get) Token: 0x060045F1 RID: 17905 RVA: 0x0003A72E File Offset: 0x0003892E
		// (set) Token: 0x060045F2 RID: 17906 RVA: 0x0003A73A File Offset: 0x0003893A
		public bool IsBackstageOpened
		{
			get
			{
				return this.isBackstageOpened;
			}
			set
			{
				if (this.isBackstageOpened != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453621));
					this.isBackstageOpened = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453621));
				}
			}
		}

		// Token: 0x04001FB9 RID: 8121
		private RibbonTab selectedTab;

		// Token: 0x04001FBA RID: 8122
		private readonly ObservableCollection<RibbonBackstageButton> applicationMenuItems;

		// Token: 0x04001FBB RID: 8123
		private readonly ObservableCollection<RibbonButton> quickAccessItems;

		// Token: 0x04001FBC RID: 8124
		private readonly ObservableCollection<RibbonTab> tabs;

		// Token: 0x04001FBD RID: 8125
		private string title;

		// Token: 0x04001FBE RID: 8126
		private string appName;

		// Token: 0x04001FBF RID: 8127
		private bool isBackstageOpened;
	}
}

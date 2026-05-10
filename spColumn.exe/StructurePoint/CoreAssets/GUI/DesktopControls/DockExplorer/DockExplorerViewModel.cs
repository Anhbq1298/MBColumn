using System;
using System.Linq;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Docking;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.DockExplorer
{
	// Token: 0x020008B4 RID: 2228
	public sealed class DockExplorerViewModel : NotifyPropertyChangedObjectBase, IDockExplorerViewModel
	{
		// Token: 0x0600462F RID: 17967 RVA: 0x0003AAA7 File Offset: 0x00038CA7
		public DockExplorerViewModel(IDockingController dockingController)
		{
			#X0d.#V0d(dockingController, #Phc.#3hc(107453839), Component.DesktopControls, #Phc.#3hc(107453846));
			this.dockingController = dockingController;
			this.openedTabs = new RadObservableCollection<DockableViewController>();
		}

		// Token: 0x06004630 RID: 17968 RVA: 0x0013D868 File Offset: 0x0013BA68
		public void Show()
		{
			this.dockExplorerWindow = new DockExplorerWindow(this);
			this.openedTabs.Clear();
			this.openedTabs.AddRange(from item in this.dockingController.DockableViewControllers
			where !item.IsHidden && item.IsFloating
			orderby item.LastActiveAt descending
			select item);
			this.SelectedTab = ((this.openedTabs.Count > 1) ? this.openedTabs.Skip(1).FirstOrDefault<DockableViewController>() : this.openedTabs.FirstOrDefault<DockableViewController>());
			this.dockExplorerWindow.ShowDialog();
		}

		// Token: 0x06004631 RID: 17969 RVA: 0x0013D948 File Offset: 0x0013BB48
		public void MoveToNext()
		{
			if (this.openedTabs.Any<DockableViewController>())
			{
				int num = (this.selectedTab != null) ? (this.openedTabs.IndexOf(this.selectedTab) + 1) : 0;
				if (num >= this.openedTabs.Count)
				{
					num = 0;
				}
				this.SelectedTab = this.openedTabs.ElementAt(num);
			}
		}

		// Token: 0x06004632 RID: 17970 RVA: 0x0013D9B0 File Offset: 0x0013BBB0
		public void Close()
		{
			if (!this.IsHidden)
			{
				if (this.dockExplorerWindow != null)
				{
					this.dockExplorerWindow.Close();
				}
				if (this.selectedTab != null)
				{
					this.dockingController.SelectView(this.selectedTab.DockableView);
				}
			}
			this.selectedTab = null;
		}

		// Token: 0x1700148E RID: 5262
		// (get) Token: 0x06004633 RID: 17971 RVA: 0x0003AADC File Offset: 0x00038CDC
		public RadObservableCollection<DockableViewController> OpenedTabs
		{
			get
			{
				return this.openedTabs;
			}
		}

		// Token: 0x1700148F RID: 5263
		// (get) Token: 0x06004634 RID: 17972 RVA: 0x0003AAE8 File Offset: 0x00038CE8
		// (set) Token: 0x06004635 RID: 17973 RVA: 0x0003AAF4 File Offset: 0x00038CF4
		public DockableViewController SelectedTab
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

		// Token: 0x17001490 RID: 5264
		// (get) Token: 0x06004636 RID: 17974 RVA: 0x0003AB32 File Offset: 0x00038D32
		public bool IsHidden
		{
			get
			{
				return this.dockExplorerWindow == null || !this.dockExplorerWindow.IsVisible;
			}
		}

		// Token: 0x04001FD5 RID: 8149
		private DockExplorerWindow dockExplorerWindow;

		// Token: 0x04001FD6 RID: 8150
		private readonly IDockingController dockingController;

		// Token: 0x04001FD7 RID: 8151
		private readonly RadObservableCollection<DockableViewController> openedTabs;

		// Token: 0x04001FD8 RID: 8152
		private DockableViewController selectedTab;
	}
}

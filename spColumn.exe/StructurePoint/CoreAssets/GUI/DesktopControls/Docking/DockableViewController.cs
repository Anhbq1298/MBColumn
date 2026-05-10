using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A7 RID: 2471
	public sealed class DockableViewController : IDockableViewController
	{
		// Token: 0x0600502B RID: 20523 RVA: 0x0015D854 File Offset: 0x0015BA54
		public DockableViewController(IDockableView dockableView, DockableViewStartOptions dockableViewStartOptions, RadPane radPane)
		{
			#X0d.#V0d(dockableView, #Phc.#3hc(107465861), Component.GUI, #Phc.#3hc(107466058));
			#X0d.#V0d(dockableViewStartOptions, #Phc.#3hc(107465823), Component.GUI, #Phc.#3hc(107466037));
			#X0d.#V0d(radPane, #Phc.#3hc(107465440), Component.GUI, #Phc.#3hc(107465423));
			this.DockableView = dockableView;
			this.DockableViewStartOptions = dockableViewStartOptions;
			this.radPane = radPane;
			this.radPane.Activated += this.RadPane_Activated;
			this.radPane.Deactivated += this.RadPane_Deactivated;
		}

		// Token: 0x0600502C RID: 20524 RVA: 0x0015D8FC File Offset: 0x0015BAFC
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaiseIsActiveChanged(bool isActive)
		{
			EventHandler<DockableViewIsActiveChangedEventArgs> isActiveChanged = this.IsActiveChanged;
			if (isActiveChanged != null)
			{
				isActiveChanged(this, new DockableViewIsActiveChangedEventArgs(isActive));
			}
		}

		// Token: 0x17001706 RID: 5894
		// (get) Token: 0x0600502D RID: 20525 RVA: 0x00042D3A File Offset: 0x00040F3A
		// (set) Token: 0x0600502E RID: 20526 RVA: 0x00042D46 File Offset: 0x00040F46
		public IDockableView DockableView { get; private set; }

		// Token: 0x17001707 RID: 5895
		// (get) Token: 0x0600502F RID: 20527 RVA: 0x00042D57 File Offset: 0x00040F57
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal RadPane RadPane
		{
			get
			{
				return this.radPane;
			}
		}

		// Token: 0x17001708 RID: 5896
		// (get) Token: 0x06005030 RID: 20528 RVA: 0x00042D63 File Offset: 0x00040F63
		// (set) Token: 0x06005031 RID: 20529 RVA: 0x00042D6F File Offset: 0x00040F6F
		public DockableViewStartOptions DockableViewStartOptions { get; private set; }

		// Token: 0x17001709 RID: 5897
		// (get) Token: 0x06005032 RID: 20530 RVA: 0x00042D80 File Offset: 0x00040F80
		// (set) Token: 0x06005033 RID: 20531 RVA: 0x00042D95 File Offset: 0x00040F95
		public bool IsHidden
		{
			get
			{
				return this.radPane.IsHidden;
			}
			set
			{
				this.radPane.IsHidden = value;
			}
		}

		// Token: 0x1700170A RID: 5898
		// (get) Token: 0x06005034 RID: 20532 RVA: 0x00042DAF File Offset: 0x00040FAF
		// (set) Token: 0x06005035 RID: 20533 RVA: 0x00042DC4 File Offset: 0x00040FC4
		public bool IsActive
		{
			get
			{
				return this.radPane.IsActive;
			}
			set
			{
				this.radPane.IsActive = value;
			}
		}

		// Token: 0x1700170B RID: 5899
		// (get) Token: 0x06005036 RID: 20534 RVA: 0x00042DDE File Offset: 0x00040FDE
		// (set) Token: 0x06005037 RID: 20535 RVA: 0x00042DEA File Offset: 0x00040FEA
		public DateTime LastActiveAt { get; private set; }

		// Token: 0x1700170C RID: 5900
		// (get) Token: 0x06005038 RID: 20536 RVA: 0x00042DFB File Offset: 0x00040FFB
		public bool IsFloating
		{
			get
			{
				return this.radPane.IsFloating;
			}
		}

		// Token: 0x1700170D RID: 5901
		// (get) Token: 0x06005039 RID: 20537 RVA: 0x00042E10 File Offset: 0x00041010
		// (set) Token: 0x0600503A RID: 20538 RVA: 0x00042E25 File Offset: 0x00041025
		public bool CanUserClose
		{
			get
			{
				return this.radPane.CanUserClose;
			}
			set
			{
				this.radPane.CanUserClose = value;
			}
		}

		// Token: 0x1700170E RID: 5902
		// (get) Token: 0x0600503B RID: 20539 RVA: 0x00042E3F File Offset: 0x0004103F
		// (set) Token: 0x0600503C RID: 20540 RVA: 0x00042E54 File Offset: 0x00041054
		public bool CanUserPin
		{
			get
			{
				return this.radPane.CanUserPin;
			}
			set
			{
				this.radPane.CanUserPin = value;
			}
		}

		// Token: 0x1700170F RID: 5903
		// (get) Token: 0x0600503D RID: 20541 RVA: 0x00042E6E File Offset: 0x0004106E
		// (set) Token: 0x0600503E RID: 20542 RVA: 0x00042E88 File Offset: 0x00041088
		public string Title
		{
			get
			{
				return this.radPane.Header as string;
			}
			set
			{
				this.radPane.Header = value;
			}
		}

		// Token: 0x17001710 RID: 5904
		// (get) Token: 0x0600503F RID: 20543 RVA: 0x00042D57 File Offset: 0x00040F57
		public object ViewObject
		{
			get
			{
				return this.radPane;
			}
		}

		// Token: 0x14000132 RID: 306
		// (add) Token: 0x06005040 RID: 20544 RVA: 0x0015D92C File Offset: 0x0015BB2C
		// (remove) Token: 0x06005041 RID: 20545 RVA: 0x0015D970 File Offset: 0x0015BB70
		public event EventHandler<DockableViewIsActiveChangedEventArgs> IsActiveChanged;

		// Token: 0x06005042 RID: 20546 RVA: 0x00042EA2 File Offset: 0x000410A2
		public void BringToFront()
		{
			if (this.radPane.PaneGroup != null)
			{
				this.radPane.Focus();
				this.IsHidden = false;
				this.IsActive = true;
			}
		}

		// Token: 0x06005043 RID: 20547 RVA: 0x00042ED7 File Offset: 0x000410D7
		private void RadPane_Activated(object sender, EventArgs e)
		{
			this.LastActiveAt = DateTime.Now;
			this.RaiseIsActiveChanged(true);
		}

		// Token: 0x06005044 RID: 20548 RVA: 0x00042EF7 File Offset: 0x000410F7
		private void RadPane_Deactivated(object sender, EventArgs e)
		{
			this.RaiseIsActiveChanged(false);
		}

		// Token: 0x04002359 RID: 9049
		private readonly RadPane radPane;
	}
}

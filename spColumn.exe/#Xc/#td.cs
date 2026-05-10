using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using #hg;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #Xc
{
	// Token: 0x020000A4 RID: 164
	internal sealed class #td : #vd
	{
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000552 RID: 1362 RVA: 0x0008A5C0 File Offset: 0x000887C0
		// (remove) Token: 0x06000553 RID: 1363 RVA: 0x0008A604 File Offset: 0x00088804
		public event EventHandler ActiveDockingChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x00009EFA File Offset: 0x000080FA
		// (set) Token: 0x06000555 RID: 1365 RVA: 0x00009F06 File Offset: 0x00008106
		public RadDocking EditorDocking { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x00009F17 File Offset: 0x00008117
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x00009F23 File Offset: 0x00008123
		public RadDocking DiagramsDocking { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x00009F34 File Offset: 0x00008134
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x00009F40 File Offset: 0x00008140
		public #ud DiagramsViewports { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x00009F51 File Offset: 0x00008151
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x00009F5D File Offset: 0x0000815D
		public #jg EditorViewports { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00009F6E File Offset: 0x0000816E
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x00009F7A File Offset: 0x0000817A
		public bool IsChangingArrangement { get; private set; }

		// Token: 0x0600055E RID: 1374 RVA: 0x00009F8B File Offset: 0x0000818B
		public void #jd()
		{
			this.#md(new Action(this.#rd));
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00009FAB File Offset: 0x000081AB
		public void #kd()
		{
			this.#md(new Action(this.#sd));
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00009FCB File Offset: 0x000081CB
		protected void #ld()
		{
			EventHandler eventHandler = this.#a;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0008A648 File Offset: 0x00088848
		private void #md(Action #nd)
		{
			try
			{
				this.IsChangingArrangement = true;
				#nd();
				this.#ld();
			}
			finally
			{
				this.IsChangingArrangement = false;
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0008A690 File Offset: 0x00088890
		private void #od(#jg #pd)
		{
			RadDocking radDocking = #pd.Docking;
			radDocking.Opacity = 1.0;
			radDocking.IsHitTestVisible = true;
			radDocking.Visibility = Visibility.Visible;
			foreach (IViewport viewport in #pd.Viewports)
			{
				if (viewport.Host.Pane.IsHidden)
				{
					viewport.Host.Pane.IsHidden = false;
				}
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0008A738 File Offset: 0x00088938
		private void #qd(#jg #pd)
		{
			RadDocking radDocking = #pd.Docking;
			radDocking.Visibility = Visibility.Collapsed;
			foreach (IViewport viewport in #pd.Viewports)
			{
				if (viewport.Host.Pane.IsFloating)
				{
					viewport.Host.Pane.IsHidden = true;
				}
			}
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00009FEF File Offset: 0x000081EF
		[CompilerGenerated]
		private void #rd()
		{
			this.#qd(this.DiagramsViewports);
			this.#od(this.EditorViewports);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0000A015 File Offset: 0x00008215
		[CompilerGenerated]
		private void #sd()
		{
			this.#qd(this.EditorViewports);
			this.#od(this.DiagramsViewports);
		}

		// Token: 0x0400011C RID: 284
		[CompilerGenerated]
		private EventHandler #a;

		// Token: 0x0400011D RID: 285
		[CompilerGenerated]
		private RadDocking #b;

		// Token: 0x0400011E RID: 286
		[CompilerGenerated]
		private RadDocking #c;

		// Token: 0x0400011F RID: 287
		[CompilerGenerated]
		private #ud #d;

		// Token: 0x04000120 RID: 288
		[CompilerGenerated]
		private #jg #e;

		// Token: 0x04000121 RID: 289
		[CompilerGenerated]
		private bool #f;
	}
}

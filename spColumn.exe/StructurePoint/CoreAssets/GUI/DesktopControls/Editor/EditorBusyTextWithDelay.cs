using System;
using System.Windows.Threading;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor
{
	// Token: 0x02000AE2 RID: 2786
	public sealed class EditorBusyTextWithDelay
	{
		// Token: 0x06005A98 RID: 23192 RVA: 0x0016F3C0 File Offset: 0x0016D5C0
		public EditorBusyTextWithDelay(EyeshotEditor editor, string busyText, TimeSpan delay)
		{
			if (editor == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351888));
			}
			this.editor = editor;
			this.busyText = busyText;
			if (delay <= TimeSpan.Zero)
			{
				editor.BusyText = busyText;
				return;
			}
			if (editor.Dispatcher != null)
			{
				this.timer = new DispatcherTimer(delay, DispatcherPriority.Normal, new EventHandler(this.Timer_Tick), editor.Dispatcher);
				this.timer.IsEnabled = true;
			}
		}

		// Token: 0x06005A99 RID: 23193 RVA: 0x0004B60B File Offset: 0x0004980B
		public void Cencel()
		{
			this.busyText = null;
			this.canceled = true;
		}

		// Token: 0x06005A9A RID: 23194 RVA: 0x0004B61B File Offset: 0x0004981B
		private void Timer_Tick(object sender, EventArgs e)
		{
			this.timer.IsEnabled = false;
			if (!this.canceled)
			{
				this.editor.BusyText = this.busyText;
				this.editor.Invalidate();
			}
		}

		// Token: 0x040025D9 RID: 9689
		private readonly EyeshotEditor editor;

		// Token: 0x040025DA RID: 9690
		private string busyText;

		// Token: 0x040025DB RID: 9691
		private bool canceled;

		// Token: 0x040025DC RID: 9692
		private DispatcherTimer timer;
	}
}

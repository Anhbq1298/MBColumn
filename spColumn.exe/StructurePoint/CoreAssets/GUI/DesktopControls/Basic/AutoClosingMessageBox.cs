using System;
using System.Threading;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A78 RID: 2680
	public sealed class AutoClosingMessageBox
	{
		// Token: 0x06005781 RID: 22401 RVA: 0x00166EB0 File Offset: 0x001650B0
		private AutoClosingMessageBox(Window parent, string caption, TimeSpan timeout, Func<string, Window, MessageBoxButton, MessageBoxImage, MessageBoxResult, MessageBoxOptions, MessageBoxResult> showMethod, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
		{
			this.caption = (caption ?? string.Empty);
			this.result = button.ToMessageBoxResult(defaultResult);
			using (new Timer(new TimerCallback(this.OnTimerElapsed), this.result.ToDialogButtonId(button), (int)timeout.TotalMilliseconds, -1))
			{
				this.result = showMethod(this.caption, parent, button, icon, defaultResult, options);
			}
		}

		// Token: 0x06005782 RID: 22402 RVA: 0x00166F48 File Offset: 0x00165148
		public static MessageBoxResult Show(TimeSpan timeout, Window parent, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
		{
			return new AutoClosingMessageBox(parent, caption, timeout, delegate(string capt, Window parentWindow, MessageBoxButton btns, MessageBoxImage image, MessageBoxResult defaults, MessageBoxOptions opts)
			{
				if (parentWindow == null)
				{
					return MessageBox.Show(messageBoxText, capt, btns, image, defaults, opts);
				}
				return MessageBox.Show(parentWindow, messageBoxText, capt, btns, image, defaults, opts);
			}, button, icon, defaultResult, options).result;
		}

		// Token: 0x06005783 RID: 22403 RVA: 0x00166F90 File Offset: 0x00165190
		public static MessageBoxResult Show(TimeSpan timeout, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
		{
			return new AutoClosingMessageBox(null, caption, timeout, delegate(string capt, Window parentWindow, MessageBoxButton btns, MessageBoxImage image, MessageBoxResult defaults, MessageBoxOptions opts)
			{
				if (parentWindow == null)
				{
					return MessageBox.Show(messageBoxText, capt, btns, image, defaults, opts);
				}
				return MessageBox.Show(parentWindow, messageBoxText, capt, btns, image, defaults, opts);
			}, button, icon, defaultResult, options).result;
		}

		// Token: 0x06005784 RID: 22404 RVA: 0x00048278 File Offset: 0x00046478
		private void OnTimerElapsed(object state)
		{
			this.CloseMessageBoxWindow((int)state);
		}

		// Token: 0x06005785 RID: 22405 RVA: 0x00048292 File Offset: 0x00046492
		private void CloseMessageBoxWindow(int dlgButtonId)
		{
			Win32Api.SendCommandToDlgButton(Win32Api.FindMessageBox(this.caption), dlgButtonId);
		}

		// Token: 0x040024AF RID: 9391
		private readonly string caption;

		// Token: 0x040024B0 RID: 9392
		private readonly MessageBoxResult result;
	}
}

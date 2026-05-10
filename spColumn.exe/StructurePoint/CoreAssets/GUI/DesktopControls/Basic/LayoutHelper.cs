using System;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using #7hc;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ACB RID: 2763
	public static class LayoutHelper
	{
		// Token: 0x060059FC RID: 23036 RVA: 0x0004ABEA File Offset: 0x00048DEA
		public static System.Drawing.Color ToDrawingColor(this System.Windows.Media.Color color)
		{
			return System.Drawing.Color.FromArgb((int)color.A, (int)color.R, (int)color.G, (int)color.B);
		}

		// Token: 0x060059FD RID: 23037 RVA: 0x0004AC19 File Offset: 0x00048E19
		public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color)
		{
			return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		// Token: 0x060059FE RID: 23038 RVA: 0x0004AC48 File Offset: 0x00048E48
		public static void InvokeOnApplicationThread(Action action)
		{
			Application.Current.Dispatcher.Invoke(action);
		}

		// Token: 0x060059FF RID: 23039 RVA: 0x0004AC66 File Offset: 0x00048E66
		public static T InvokeOnApplicationThread<T>(Func<T> func)
		{
			return Application.Current.Dispatcher.Invoke<T>(func);
		}

		// Token: 0x06005A00 RID: 23040 RVA: 0x0004AC84 File Offset: 0x00048E84
		public static void Refresh()
		{
			LayoutHelper.InvokeOnApplicationThread(delegate()
			{
			});
		}

		// Token: 0x06005A01 RID: 23041 RVA: 0x0004ACAE File Offset: 0x00048EAE
		public static DispatcherOperation BeginInvokeOnApplicationThread(Action action)
		{
			return Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, action);
		}

		// Token: 0x06005A02 RID: 23042 RVA: 0x0004ACCD File Offset: 0x00048ECD
		public static DispatcherOperation BeginInvokeOnApplicationThread(Action action, DispatcherPriority priority)
		{
			return Application.Current.Dispatcher.BeginInvoke(priority, action);
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x0004ACEC File Offset: 0x00048EEC
		public static void DelayOperation(double seconds, Action operation)
		{
			LayoutHelper.DelayOperation(TimeSpan.FromSeconds(seconds), operation);
		}

		// Token: 0x06005A04 RID: 23044 RVA: 0x0016DF80 File Offset: 0x0016C180
		public static void DelayOperation(TimeSpan delay, Action operation)
		{
			if (operation == null)
			{
				return;
			}
			DispatcherTimer timer = new DispatcherTimer
			{
				Interval = delay
			};
			timer.Tick += delegate(object sender, EventArgs e)
			{
				timer.Stop();
				Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Loaded, operation);
			};
			timer.Start();
		}

		// Token: 0x06005A05 RID: 23045 RVA: 0x0016DFE4 File Offset: 0x0016C1E4
		public static string CompactPath(string path, int length)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return string.Empty;
			}
			long num = (long)length + 1L;
			if (num > 2147483647L)
			{
				num = 2147483647L;
				length = (int)num - 1;
			}
			StringBuilder stringBuilder = new StringBuilder((int)num);
			ShlwApi.PathCompactPathEx(stringBuilder, path, (uint)length, 0U);
			return stringBuilder.ToString();
		}

		// Token: 0x06005A06 RID: 23046 RVA: 0x0004AD06 File Offset: 0x00048F06
		public static void Refresh(this UIElement uiElement)
		{
			if (uiElement == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107424389));
			}
			uiElement.Dispatcher.Invoke(DispatcherPriority.Render, LayoutHelper.EmptyDelegate);
		}

		// Token: 0x04002592 RID: 9618
		private static readonly Action EmptyDelegate = delegate()
		{
		};
	}
}

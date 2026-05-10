using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;
using #7hc;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC2 RID: 2754
	public static class WindowHelper
	{
		// Token: 0x060059BC RID: 22972 RVA: 0x0004A8A2 File Offset: 0x00048AA2
		public static bool IsValid(this Window window)
		{
			return window != null && new WindowInteropHelper(window).Handle != IntPtr.Zero;
		}

		// Token: 0x060059BD RID: 22973 RVA: 0x0016D8F0 File Offset: 0x0016BAF0
		public static void HideMinimizeButton(this Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (handle == IntPtr.Zero)
			{
				return;
			}
			User32.WindowStyles windowStyles = (User32.WindowStyles)User32.GetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE);
			windowStyles &= ~User32.WindowStyles.WS_GROUP;
			User32.SetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE, (int)windowStyles);
		}

		// Token: 0x060059BE RID: 22974 RVA: 0x0016D948 File Offset: 0x0016BB48
		public static void HideMaximizeButton(this Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (handle == IntPtr.Zero)
			{
				return;
			}
			User32.WindowStyles windowStyles = (User32.WindowStyles)User32.GetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE);
			windowStyles &= ~User32.WindowStyles.WS_MAXIMIZEBOX;
			User32.SetWindowLong(handle, User32.WindowLongFlags.GWL_STYLE, (int)windowStyles);
		}

		// Token: 0x060059BF RID: 22975 RVA: 0x0016D9A0 File Offset: 0x0016BBA0
		public static void ShowEx(this Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378032));
			}
			if (!window.IsVisible)
			{
				window.Show();
			}
			if (window.WindowState == WindowState.Minimized)
			{
				window.WindowState = WindowState.Normal;
			}
			window.Activate();
			window.Topmost = true;
			window.Topmost = false;
			window.Focus();
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x0016DA08 File Offset: 0x0016BC08
		public static bool IsAnyModalWindowOpen()
		{
			if (!ComponentDispatcher.IsThreadModal)
			{
				IEnumerable<Window> source = Application.Current.Windows.OfType<Window>();
				Func<Window, bool> predicate;
				if ((predicate = WindowHelper.<>O.<0>__IsModal) == null)
				{
					predicate = (WindowHelper.<>O.<0>__IsModal = new Func<Window, bool>(WindowHelper.IsModal));
				}
				return source.Any(predicate);
			}
			return true;
		}

		// Token: 0x060059C1 RID: 22977 RVA: 0x0016DA5C File Offset: 0x0016BC5C
		public static bool IsModal(this Window window)
		{
			bool result;
			try
			{
				FieldInfo field = typeof(Window).GetField(#Phc.#3hc(107425660), BindingFlags.Instance | BindingFlags.NonPublic);
				object obj = (field != null) ? field.GetValue(window) : null;
				result = (obj != null && (bool)obj);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				result = false;
			}
			return result;
		}

		// Token: 0x060059C2 RID: 22978 RVA: 0x0016DAC8 File Offset: 0x0016BCC8
		public static bool RefreshLayout(object item)
		{
			Window window = item as Window;
			if (window == null)
			{
				return false;
			}
			Window window2 = window;
			double width = window2.Width;
			window2.Width = width + 1.0;
			Window window3 = window;
			width = window3.Width;
			window3.Width = width - 1.0;
			return true;
		}

		// Token: 0x060059C3 RID: 22979 RVA: 0x0016DB20 File Offset: 0x0016BD20
		public static bool RefreshLayoutAsync(object item)
		{
			if (!(item is Window))
			{
				return false;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				WindowHelper.RefreshLayout(item);
			});
			return true;
		}

		// Token: 0x02000AC3 RID: 2755
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400257B RID: 9595
			public static Func<Window, bool> <0>__IsModal;
		}
	}
}

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B18 RID: 2840
	public sealed class WindowPositionContraint
	{
		// Token: 0x06005D12 RID: 23826 RVA: 0x00175368 File Offset: 0x00173568
		public WindowPositionContraint(Window window, Func<Rect?> constraintFunc)
		{
			if (window == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378032));
			}
			this.window = window;
			if (constraintFunc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420712));
			}
			this.constraintFunc = constraintFunc;
			this.window.Loaded += this.Window_Loaded;
		}

		// Token: 0x06005D13 RID: 23827 RVA: 0x0004D970 File Offset: 0x0004BB70
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			HwndSource hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(this.window).Handle);
			if (hwndSource == null)
			{
				return;
			}
			hwndSource.AddHook(new HwndSourceHook(this.HwndSourceHookHandler));
		}

		// Token: 0x06005D14 RID: 23828 RVA: 0x0004D99D File Offset: 0x0004BB9D
		private Rect? GetEditorScreenBounds()
		{
			return this.constraintFunc();
		}

		// Token: 0x06005D15 RID: 23829 RVA: 0x001753C8 File Offset: 0x001735C8
		private void RestrictPosition(IntPtr lParam)
		{
			Rect? editorScreenBounds = this.GetEditorScreenBounds();
			if (editorScreenBounds == null)
			{
				return;
			}
			WindowPositionContraint.MoveRectangle moveRectangle = (WindowPositionContraint.MoveRectangle)Marshal.PtrToStructure(lParam, typeof(WindowPositionContraint.MoveRectangle));
			if ((double)moveRectangle.Left < editorScreenBounds.Value.Left)
			{
				moveRectangle.Left = (int)editorScreenBounds.Value.Left;
				Marshal.StructureToPtr<WindowPositionContraint.MoveRectangle>(moveRectangle, lParam, true);
				return;
			}
			if ((double)moveRectangle.Right > editorScreenBounds.Value.Right)
			{
				moveRectangle.Right = (int)editorScreenBounds.Value.Right;
				moveRectangle.Left = moveRectangle.Right - (int)this.window.ActualWidth;
				Marshal.StructureToPtr<WindowPositionContraint.MoveRectangle>(moveRectangle, lParam, true);
				return;
			}
			if ((double)moveRectangle.Top < editorScreenBounds.Value.Top)
			{
				moveRectangle.Top = (int)editorScreenBounds.Value.Top;
				Marshal.StructureToPtr<WindowPositionContraint.MoveRectangle>(moveRectangle, lParam, true);
				return;
			}
			if ((double)moveRectangle.Bottom > editorScreenBounds.Value.Bottom)
			{
				moveRectangle.Bottom = (int)editorScreenBounds.Value.Bottom;
				moveRectangle.Top = (int)(editorScreenBounds.Value.Bottom - this.window.ActualHeight);
				Marshal.StructureToPtr<WindowPositionContraint.MoveRectangle>(moveRectangle, lParam, true);
			}
		}

		// Token: 0x06005D16 RID: 23830 RVA: 0x0004D9AA File Offset: 0x0004BBAA
		private IntPtr HwndSourceHookHandler(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 534)
			{
				this.RestrictPosition(lParam);
			}
			return IntPtr.Zero;
		}

		// Token: 0x040026C3 RID: 9923
		private readonly Window window;

		// Token: 0x040026C4 RID: 9924
		private readonly Func<Rect?> constraintFunc;

		// Token: 0x02000B19 RID: 2841
		private struct MoveRectangle
		{
			// Token: 0x040026C5 RID: 9925
			public int Left;

			// Token: 0x040026C6 RID: 9926
			public int Top;

			// Token: 0x040026C7 RID: 9927
			public int Right;

			// Token: 0x040026C8 RID: 9928
			public int Bottom;
		}
	}
}

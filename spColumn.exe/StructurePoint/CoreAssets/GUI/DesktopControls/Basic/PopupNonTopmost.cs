using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using #7hc;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8C RID: 2700
	public sealed class PopupNonTopmost : Popup
	{
		// Token: 0x1700191A RID: 6426
		// (get) Token: 0x06005814 RID: 22548 RVA: 0x00048B8C File Offset: 0x00046D8C
		// (set) Token: 0x06005815 RID: 22549 RVA: 0x00048BA6 File Offset: 0x00046DA6
		public bool IsTopmost
		{
			get
			{
				return (bool)base.GetValue(PopupNonTopmost.IsTopmostProperty);
			}
			set
			{
				base.SetValue(PopupNonTopmost.IsTopmostProperty, value);
			}
		}

		// Token: 0x06005816 RID: 22550 RVA: 0x00048BC5 File Offset: 0x00046DC5
		protected override void OnOpened(EventArgs e)
		{
			this.SetTopmostState(this.IsTopmost);
		}

		// Token: 0x06005817 RID: 22551 RVA: 0x0016896C File Offset: 0x00166B6C
		private static void OnIsTopmostChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			PopupNonTopmost popupNonTopmost = obj as PopupNonTopmost;
			if (popupNonTopmost != null)
			{
				popupNonTopmost.SetTopmostState(popupNonTopmost.IsTopmost);
			}
		}

		// Token: 0x06005818 RID: 22552 RVA: 0x0016899C File Offset: 0x00166B9C
		private void SetTopmostState(bool isTop)
		{
			if (base.Child != null)
			{
				HwndSource hwndSource = PresentationSource.FromVisual(base.Child) as HwndSource;
				if (hwndSource != null)
				{
					IntPtr handle = hwndSource.Handle;
					RECT rect;
					if (User32.GetWindowRect(handle, out rect))
					{
						if (isTop)
						{
							User32.SetWindowPos(handle, PopupNonTopmost.HwndTopmost, rect.left, rect.top, (int)base.Width, (int)base.Height, User32.SetWindowPosFlags.SWP_NOACTIVATE | User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOOWNERZORDER | User32.SetWindowPosFlags.SWP_NOREDRAW | User32.SetWindowPosFlags.SWP_NOSENDCHANGING | User32.SetWindowPosFlags.SWP_NOSIZE);
							return;
						}
						User32.SetWindowPos(handle, PopupNonTopmost.HwndBottom, rect.left, rect.top, (int)base.Width, (int)base.Height, User32.SetWindowPosFlags.SWP_NOACTIVATE | User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOOWNERZORDER | User32.SetWindowPosFlags.SWP_NOREDRAW | User32.SetWindowPosFlags.SWP_NOSENDCHANGING | User32.SetWindowPosFlags.SWP_NOSIZE);
						User32.SetWindowPos(handle, PopupNonTopmost.HwndTop, rect.left, rect.top, (int)base.Width, (int)base.Height, User32.SetWindowPosFlags.SWP_NOACTIVATE | User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOOWNERZORDER | User32.SetWindowPosFlags.SWP_NOREDRAW | User32.SetWindowPosFlags.SWP_NOSENDCHANGING | User32.SetWindowPosFlags.SWP_NOSIZE);
						User32.SetWindowPos(handle, PopupNonTopmost.HwndNotopmost, rect.left, rect.top, (int)base.Width, (int)base.Height, User32.SetWindowPosFlags.SWP_NOACTIVATE | User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOOWNERZORDER | User32.SetWindowPosFlags.SWP_NOREDRAW | User32.SetWindowPosFlags.SWP_NOSENDCHANGING | User32.SetWindowPosFlags.SWP_NOSIZE);
					}
				}
			}
		}

		// Token: 0x040024DA RID: 9434
		private const User32.SetWindowPosFlags TopmostFlags = User32.SetWindowPosFlags.SWP_NOACTIVATE | User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOOWNERZORDER | User32.SetWindowPosFlags.SWP_NOREDRAW | User32.SetWindowPosFlags.SWP_NOSENDCHANGING | User32.SetWindowPosFlags.SWP_NOSIZE;

		// Token: 0x040024DB RID: 9435
		public static readonly DependencyProperty IsTopmostProperty = DependencyProperty.Register(#Phc.#3hc(107428701), typeof(bool), typeof(PopupNonTopmost), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(PopupNonTopmost.OnIsTopmostChanged)));

		// Token: 0x040024DC RID: 9436
		private static readonly IntPtr HwndTopmost = new IntPtr(-1);

		// Token: 0x040024DD RID: 9437
		private static readonly IntPtr HwndNotopmost = new IntPtr(-2);

		// Token: 0x040024DE RID: 9438
		private static readonly IntPtr HwndTop = new IntPtr(0);

		// Token: 0x040024DF RID: 9439
		private static readonly IntPtr HwndBottom = new IntPtr(1);
	}
}

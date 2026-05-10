using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000886 RID: 2182
	[CLSCompliant(false)]
	public static class NativeMethods
	{
		// Token: 0x06004506 RID: 17670
		[DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
		public static extern uint MM_BeginPeriod(uint uMilliseconds);

		// Token: 0x06004507 RID: 17671 RVA: 0x0013C944 File Offset: 0x0013AB44
		internal static NativeMethods.RECT GetWindowRectangle(Window window)
		{
			Vanara.PInvoke.RECT rect;
			User32.GetWindowRect(new WindowInteropHelper(window).Handle, out rect);
			return new NativeMethods.RECT
			{
				Bottom = rect.bottom,
				Left = rect.left,
				Right = rect.right,
				Top = rect.top
			};
		}

		// Token: 0x02000887 RID: 2183
		internal struct RECT
		{
			// Token: 0x04001F74 RID: 8052
			public int Left;

			// Token: 0x04001F75 RID: 8053
			public int Top;

			// Token: 0x04001F76 RID: 8054
			public int Right;

			// Token: 0x04001F77 RID: 8055
			public int Bottom;
		}
	}
}

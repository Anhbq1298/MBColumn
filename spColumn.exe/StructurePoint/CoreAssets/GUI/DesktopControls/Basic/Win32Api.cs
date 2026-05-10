using System;
using System.Security;
using #7hc;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC0 RID: 2752
	[SecuritySafeCritical]
	internal static class Win32Api
	{
		// Token: 0x060059B8 RID: 22968 RVA: 0x0004A884 File Offset: 0x00048A84
		public static HWND FindMessageBox(string caption)
		{
			return User32.FindWindow(#Phc.#3hc(107425637), caption);
		}

		// Token: 0x060059B9 RID: 22969 RVA: 0x0016D838 File Offset: 0x0016BA38
		public static void SendCommandToDlgButton(HWND hWnd, int dlgButtonId)
		{
			if (hWnd == IntPtr.Zero)
			{
				return;
			}
			User32.EnumChildWindows(hWnd, delegate(HWND handle, IntPtr _)
			{
				int dlgCtrlID = User32.GetDlgCtrlID(handle);
				if (dlgCtrlID == dlgButtonId)
				{
					User32.PostMessage(hWnd, 273U, new IntPtr(dlgCtrlID), handle.DangerousGetHandle());
				}
				return dlgCtrlID != dlgButtonId;
			}, IntPtr.Zero);
		}
	}
}

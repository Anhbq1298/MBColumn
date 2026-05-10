using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Forms;
using Alphaleonis.Win32.Filesystem;

namespace #ezc
{
	// Token: 0x02000B33 RID: 2867
	internal static class #jzc
	{
		// Token: 0x06005DCD RID: 24013 RVA: 0x0004E2F1 File Offset: 0x0004C4F1
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static void #fzc()
		{
			if (!false)
			{
				System.Windows.Forms.Application.DoEvents();
			}
		}

		// Token: 0x06005DCE RID: 24014 RVA: 0x0004E2FD File Offset: 0x0004C4FD
		public static string #gzc()
		{
			ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule == null)
			{
				return null;
			}
			return mainModule.FileName;
		}

		// Token: 0x06005DCF RID: 24015 RVA: 0x001760EC File Offset: 0x001742EC
		public static string #hzc()
		{
			string text = #jzc.#gzc();
			string text2;
			if (!false)
			{
				text2 = text;
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return Path.GetDirectoryName(text2);
			}
			return text2;
		}

		// Token: 0x06005DD0 RID: 24016 RVA: 0x00176118 File Offset: 0x00174318
		public static bool #izc()
		{
			bool result;
			try
			{
				if (8 == 0 || 5 == 0)
				{
					goto IL_1F;
				}
				System.Windows.Application application = System.Windows.Application.Current;
				ShutdownMode shutdownMode = System.Windows.Application.Current.ShutdownMode;
				if (-1 != 0)
				{
					application.ShutdownMode = shutdownMode;
				}
				IL_1A:
				bool flag = false;
				if (2 != 0)
				{
					result = flag;
				}
				IL_1F:
				if (2 == 0)
				{
					goto IL_1A;
				}
			}
			catch (Exception)
			{
				result = true;
			}
			return result;
		}
	}
}

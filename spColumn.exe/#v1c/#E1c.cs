using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using #7hc;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Vanara.PInvoke;

namespace #v1c
{
	// Token: 0x02000CBB RID: 3259
	internal static class #E1c
	{
		// Token: 0x06006A5E RID: 27230 RVA: 0x0019CB78 File Offset: 0x0019AD78
		public static void #z1c(string #A1c)
		{
			string text;
			if (Environment.Is64BitProcess)
			{
				if (8 != 0)
				{
					text = #Phc.#3hc(107431183);
					goto IL_20;
				}
				goto IL_24;
			}
			IL_07:
			text = #Phc.#3hc(107431212);
			IL_20:
			string text2;
			if (6 != 0)
			{
				text2 = text;
			}
			IL_24:
			if (false)
			{
				goto IL_07;
			}
			string #C1c = Path.Combine(new string[]
			{
				#A1c,
				text2
			});
			string #D1c = #Phc.#3hc(107431186);
			if (6 != 0)
			{
				#E1c.#B1c(#C1c, #D1c);
			}
			string #D1c2 = #Phc.#3hc(107430625);
			if (4 != 0)
			{
				#E1c.#B1c(#C1c, #D1c2);
			}
			if (!false)
			{
				return;
			}
			goto IL_07;
		}

		// Token: 0x06006A5F RID: 27231 RVA: 0x0019CBF4 File Offset: 0x0019ADF4
		[SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
		private static void #B1c(string #C1c, string #D1c)
		{
			Kernel32.SafeHINSTANCE safeHINSTANCE = Kernel32.LoadLibrary(Path.Combine(new string[]
			{
				#C1c,
				#D1c
			}));
			Kernel32.SafeHINSTANCE safeHINSTANCE2;
			if (!false)
			{
				safeHINSTANCE2 = safeHINSTANCE;
			}
			if (safeHINSTANCE2.DangerousGetHandle() == IntPtr.Zero)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				int num;
				if (-1 != 0)
				{
					num = lastWin32Error;
				}
				throw new ApplicationException(Strings.StringErrorLoadingLibrary.#u2d(true) + #D1c.#M2d() + Strings.StringErrorCode.#u2d(true) + num.ToString());
			}
			List<Kernel32.SafeHINSTANCE> list = #E1c.#a;
			Kernel32.SafeHINSTANCE item = safeHINSTANCE2;
			if (!false)
			{
				list.Add(item);
			}
		}

		// Token: 0x04002B8C RID: 11148
		private static readonly List<Kernel32.SafeHINSTANCE> #a = new List<Kernel32.SafeHINSTANCE>();
	}
}

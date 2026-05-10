using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.Framework.Services
{
	// Token: 0x02000C24 RID: 3108
	public static class MessageBoxExt
	{
		// Token: 0x06006509 RID: 25865 RVA: 0x00051990 File Offset: 0x0004FB90
		public static MessageBoxResult #od(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl)
		{
			return MessageBoxExt.#od(#jA, #MQc, #5, #NQc, #Kl, MessageBoxResult.None, MessageBoxOptions.None);
		}

		// Token: 0x0600650A RID: 25866 RVA: 0x0018D294 File Offset: 0x0018B494
		public static MessageBoxResult #od(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl, MessageBoxResult #PE, MessageBoxOptions #mA)
		{
			MessageBoxExt.#v0b #v0b = new MessageBoxExt.#v0b();
			MessageBoxExt.#v0b #v0b2;
			if (!false)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = new List<HWND>();
			MessageBoxResult result;
			try
			{
				if (!false)
				{
					uint num;
					uint windowThreadProcessId = User32.GetWindowThreadProcessId(new HWND(new WindowInteropHelper(#jA).Handle), out num);
					if (!false)
					{
						User32.EnumThreadWindows(windowThreadProcessId, new User32.EnumWindowsProc(#v0b2.#yad), IntPtr.Zero);
					}
					MessageBoxResult messageBoxResult = MessageBox.Show(#5, #MQc, #NQc, #Kl, #PE, #mA);
					if (3 != 0)
					{
						result = messageBoxResult;
					}
				}
			}
			finally
			{
				#v0b2.#a.ForEach(new Action<HWND>(MessageBoxExt.<>c.<>9.#zad));
			}
			return result;
		}

		// Token: 0x02000C26 RID: 3110
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x0600650F RID: 25871 RVA: 0x000519B5 File Offset: 0x0004FBB5
			internal bool #yad(HWND #Uzc, IntPtr #Jdb)
			{
				int num;
				for (;;)
				{
					if (5 != 0 && User32.IsWindowEnabled(#Uzc))
					{
						List<HWND> list = this.#a;
						if (-1 != 0)
						{
							list.Add(#Uzc);
						}
						User32.EnableWindow(#Uzc, false);
					}
					IL_1F:
					if (false)
					{
						continue;
					}
					num = 1;
					if (num != 0)
					{
						break;
					}
					goto IL_1F;
				}
				return num != 0;
			}

			// Token: 0x04002972 RID: 10610
			public List<HWND> #a;
		}
	}
}

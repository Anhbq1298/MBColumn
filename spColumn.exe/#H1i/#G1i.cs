using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using #7hc;

namespace #H1i
{
	// Token: 0x02000E66 RID: 3686
	internal sealed class #G1i
	{
		// Token: 0x060083EA RID: 33770 RVA: 0x001C65F4 File Offset: 0x001C47F4
		public static List<Process> #A1i(string #B1i)
		{
			if (string.IsNullOrWhiteSpace(#B1i))
			{
				throw new ArgumentException(#Phc.#3hc(107268281), #Phc.#3hc(107268200));
			}
			int id = Process.GetCurrentProcess().Id;
			List<Process> #F1i = #G1i.#C1i(#B1i);
			return #G1i.#D1i(id, #F1i);
		}

		// Token: 0x060083EB RID: 33771 RVA: 0x001C663C File Offset: 0x001C483C
		public static List<Process> #C1i(string #B1i)
		{
			Process[] processes = Process.GetProcesses();
			List<Process> list = new List<Process>();
			foreach (Process process in processes)
			{
				if (process.ProcessName.ToLower() == #B1i)
				{
					list.Add(process);
				}
			}
			return list;
		}

		// Token: 0x060083EC RID: 33772 RVA: 0x001C6684 File Offset: 0x001C4884
		private static List<Process> #D1i(int #E1i, List<Process> #F1i)
		{
			if (#F1i == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107268215));
			}
			if (#E1i <= 0)
			{
				throw new ArgumentException(#Phc.#3hc(107268186), #Phc.#3hc(107268149));
			}
			List<Process> list = new List<Process>();
			foreach (Process process in #F1i)
			{
				Process process2 = #G1i.#e4i.#d4i(process.Id);
				if (process2 != null && process2.Id == #E1i)
				{
					list.Add(process);
					list.AddRange(#G1i.#D1i(process.Id, #F1i));
				}
			}
			return list;
		}

		// Token: 0x02000E67 RID: 3687
		private struct #e4i
		{
			// Token: 0x060083EE RID: 33774
			[DllImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess")]
			private static extern int #83i(IntPtr #93i, int #a4i, ref #G1i.#e4i #b4i, int #c4i, out int #JRi);

			// Token: 0x060083EF RID: 33775 RVA: 0x0006B8D6 File Offset: 0x00069AD6
			public static Process #d4i(int #yGe)
			{
				return #G1i.#e4i.#d4i(Process.GetProcessById(#yGe).Handle);
			}

			// Token: 0x060083F0 RID: 33776 RVA: 0x001C6738 File Offset: 0x001C4938
			public static Process #d4i(IntPtr #Fec)
			{
				#G1i.#e4i structure = default(#G1i.#e4i);
				int num2;
				int num = #G1i.#e4i.#83i(#Fec, 0, ref structure, Marshal.SizeOf<#G1i.#e4i>(structure), out num2);
				if (num != 0)
				{
					throw new Win32Exception(num);
				}
				Process result;
				try
				{
					result = Process.GetProcessById(structure.#f.ToInt32());
				}
				catch (ArgumentException)
				{
					result = null;
				}
				return result;
			}

			// Token: 0x04003661 RID: 13921
			private readonly IntPtr #a;

			// Token: 0x04003662 RID: 13922
			private readonly IntPtr #b;

			// Token: 0x04003663 RID: 13923
			private readonly IntPtr #c;

			// Token: 0x04003664 RID: 13924
			private readonly IntPtr #d;

			// Token: 0x04003665 RID: 13925
			private readonly IntPtr #e;

			// Token: 0x04003666 RID: 13926
			private IntPtr #f;
		}
	}
}

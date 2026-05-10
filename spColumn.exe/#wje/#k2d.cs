using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace #wje
{
	// Token: 0x020010BE RID: 4286
	internal static class #k2d
	{
		// Token: 0x0600921D RID: 37405 RVA: 0x001F05DC File Offset: 0x001EE7DC
		public static string #Ake(this string #f)
		{
			if (#f == null)
			{
				return #f;
			}
			#f = #f.Trim();
			List<char> list = new List<char>(#f.Length);
			foreach (char c in #f)
			{
				if (c < ' ' || c == '\0')
				{
					break;
				}
				list.Add(c);
			}
			return new string(list.ToArray());
		}

		// Token: 0x0600921E RID: 37406 RVA: 0x001F0638 File Offset: 0x001EE838
		public static bool #Bke<#Fu>(this Stream #gp, int #hNb, out #Fu[] #87c) where #Fu : struct
		{
			#87c = new !!0[#hNb];
			for (int i = 0; i < #hNb; i++)
			{
				#Fu #Fu;
				if (!#gp.#Cke(out #Fu, 0))
				{
					return false;
				}
				#87c[i] = #Fu;
			}
			return true;
		}

		// Token: 0x0600921F RID: 37407 RVA: 0x001F0670 File Offset: 0x001EE870
		public static bool #Cke<#Fu>(this Stream #gp, out #Fu #PE, int #Dke = 0) where #Fu : struct
		{
			#PE = default(!!0);
			int num = Marshal.SizeOf(typeof(!!0));
			byte[] array = new byte[num];
			if (#gp.Read(array, 0, num - #Dke) != num - #Dke)
			{
				return false;
			}
			GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			#PE = (!!0)((object)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(!!0)));
			gchandle.Free();
			return true;
		}

		// Token: 0x06009220 RID: 37408 RVA: 0x000757E5 File Offset: 0x000739E5
		public static bool #Eke(this Stream #gp, int #dTc, ref string #PE)
		{
			if (!#gp.#IAc(#dTc, ref #PE))
			{
				return false;
			}
			#PE = #PE.#Ake();
			return true;
		}

		// Token: 0x06009221 RID: 37409 RVA: 0x000757FD File Offset: 0x000739FD
		public static bool #Eke(this Stream #gp, int #dTc, Encoding #51c, ref string #PE)
		{
			if (!#gp.#IAc(#dTc, #51c, ref #PE))
			{
				return false;
			}
			#PE = #PE.#Ake();
			return true;
		}

		// Token: 0x06009222 RID: 37410 RVA: 0x001F06E0 File Offset: 0x001EE8E0
		public static bool #IAc(this Stream #gp, int #dTc, ref string #PE)
		{
			byte[] array = new byte[#dTc];
			if (#gp.Read(array, 0, #dTc) != #dTc)
			{
				return false;
			}
			#PE = Encoding.ASCII.GetString(array);
			return true;
		}

		// Token: 0x06009223 RID: 37411 RVA: 0x001F0710 File Offset: 0x001EE910
		public static bool #IAc(this Stream #gp, int #dTc, Encoding #51c, ref string #PE)
		{
			byte[] array = new byte[#dTc];
			if (#gp.Read(array, 0, #dTc) != #dTc)
			{
				return false;
			}
			#PE = #51c.GetString(array);
			return true;
		}
	}
}

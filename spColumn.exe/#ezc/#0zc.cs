using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Vanara.PInvoke;

namespace #ezc
{
	// Token: 0x02000B3B RID: 2875
	internal static class #0zc
	{
		// Token: 0x06005DFC RID: 24060 RVA: 0x001762E0 File Offset: 0x001744E0
		public static void #Gzc(IntPtr #Hzc, WindowState #8Rb)
		{
			do
			{
				IntPtr wParam;
				if (!false && !false)
				{
					wParam = new IntPtr((int)#8Rb);
				}
				User32.PostMessage(new HWND(#Hzc), 5U, wParam, (IntPtr)0);
			}
			while (false);
		}

		// Token: 0x06005DFD RID: 24061 RVA: 0x00176314 File Offset: 0x00174514
		public static void #Izc(#WBc #Jzc, IntPtr #Kzc)
		{
			while (!(#Kzc == IntPtr.Zero))
			{
				if (2 != 0)
				{
					Window window = #Jzc as Window;
					Window window2;
					if (3 != 0)
					{
						window2 = window;
					}
					while (!false)
					{
						if (window2 != null)
						{
							WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window2);
							if (2 != 0)
							{
								windowInteropHelper.Owner = #Kzc;
							}
						}
						if (8 != 0)
						{
							return;
						}
					}
					break;
				}
			}
		}

		// Token: 0x06005DFE RID: 24062 RVA: 0x0017635C File Offset: 0x0017455C
		public static bool #Lzc(string #Mzc)
		{
			bool result;
			do
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(#Phc.#3hc(107420135));
				bool flag = false;
				if (!false)
				{
					result = flag;
				}
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
				ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator;
				if (6 != 0)
				{
					managementObjectEnumerator = enumerator;
				}
				try
				{
					while (managementObjectEnumerator.MoveNext())
					{
						ManagementBaseObject managementBaseObject = managementObjectEnumerator.Current;
						ManagementObject managementObject = managementBaseObject as ManagementObject;
						ManagementObject managementObject2;
						if (7 != 0)
						{
							managementObject2 = managementObject;
						}
						if (5 == 0 || (managementObject2 != null && string.Equals(managementObject2[#Phc.#3hc(107409209)].ToString(), #Mzc, StringComparison.OrdinalIgnoreCase) && string.Equals(managementObject2[#Phc.#3hc(107420126)].ToString(), #Phc.#3hc(107420077), StringComparison.CurrentCultureIgnoreCase)))
						{
							bool flag2 = true;
							if (!false)
							{
								result = flag2;
							}
						}
					}
				}
				finally
				{
					if (managementObjectEnumerator == null)
					{
						goto IL_A2;
					}
					IL_9C:
					((IDisposable)managementObjectEnumerator).Dispose();
					IL_A2:
					if (3 == 0 || false)
					{
						goto IL_9C;
					}
				}
			}
			while (5 == 0);
			return result;
		}

		// Token: 0x06005DFF RID: 24063 RVA: 0x00176438 File Offset: 0x00174638
		public static DialogResult #Nzc(IntPtr #Ozc, PrinterSettings #Pzc)
		{
			DialogResult dialogResult = DialogResult.Cancel;
			DialogResult result;
			if (5 != 0)
			{
				result = dialogResult;
			}
			IntPtr hdevmode = #Pzc.GetHdevmode(#Pzc.DefaultPageSettings);
			IntPtr intPtr;
			if (5 != 0)
			{
				intPtr = hdevmode;
			}
			for (;;)
			{
				if (false)
				{
					goto IL_93;
				}
				int cb = #0zc.#Tzc(#Ozc, IntPtr.Zero, #Pzc.PrinterName, IntPtr.Zero, IntPtr.Zero, 0);
				IntPtr intPtr2 = Kernel32.GlobalLock(intPtr);
				IntPtr #Yzc;
				if (4 != 0)
				{
					#Yzc = intPtr2;
				}
				IntPtr intPtr3 = Marshal.AllocHGlobal(cb);
				IntPtr intPtr4;
				if (3 != 0)
				{
					intPtr4 = intPtr3;
				}
				IntPtr h = #Ozc;
				if (!false)
				{
					long num = (long)#0zc.#Tzc(#Ozc, IntPtr.Zero, #Pzc.PrinterName, intPtr4, #Yzc, 14);
					long num3;
					if (4 != 0)
					{
						long num2 = 1L;
						if (true)
						{
							num3 = num2;
						}
					}
					if (num == num3)
					{
						DialogResult dialogResult2 = DialogResult.OK;
						if (!false)
						{
							result = dialogResult2;
						}
						#Pzc.SetHdevmode(intPtr4);
						#Pzc.DefaultPageSettings.SetHdevmode(intPtr4);
						goto IL_93;
					}
					goto IL_93;
				}
				IL_A0:
				Kernel32.GlobalFree(h);
				Marshal.FreeHGlobal(intPtr4);
				if (4 != 0)
				{
					break;
				}
				continue;
				IL_93:
				Kernel32.GlobalUnlock(intPtr);
				h = intPtr;
				goto IL_A0;
			}
			return result;
		}

		// Token: 0x06005E00 RID: 24064 RVA: 0x0017651C File Offset: 0x0017471C
		public static BitmapSource #Qzc(Bitmap #Ic)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr;
			if (-1 != 0)
			{
				intPtr = zero;
			}
			BitmapSource result;
			try
			{
				IntPtr hbitmap = #Ic.GetHbitmap();
				if (4 != 0)
				{
					intPtr = hbitmap;
				}
				BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
				if (2 != 0)
				{
					result = bitmapSource;
				}
			}
			finally
			{
				IntPtr value;
				IntPtr h = value = intPtr;
				do
				{
					if (!false)
					{
						if (!(value != IntPtr.Zero))
						{
							goto IL_56;
						}
						h = (value = intPtr);
					}
				}
				while (4 == 0 || false);
				Gdi32.DeleteObject(h);
				IL_56:;
			}
			return result;
		}

		// Token: 0x06005E01 RID: 24065 RVA: 0x00176594 File Offset: 0x00174794
		internal static string #Rzc(ShlwApi.ASSOCSTR #Szc, string #In)
		{
			if (-1 == 0)
			{
				goto IL_5F;
			}
			string #R0d = #Phc.#3hc(107420068);
			Component #x6c = Component.DesktopControls;
			string #Qic = #Phc.#3hc(107420087);
			if (true)
			{
				#X0d.#V0d(#In, #R0d, #x6c, #Qic);
			}
			int num = 0;
			uint capacity;
			int num2;
			do
			{
				if (!false)
				{
					capacity = (uint)num;
				}
				num2 = (num = 0);
			}
			while (num2 != 0);
			if ((num2 ?? ((ShlwApi.AssocQueryString((ShlwApi.ASSOCF)num2, #Szc, #In, null, null, ref capacity) != 1) ? 1 : 0)) != 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder((int)capacity);
			StringBuilder stringBuilder2;
			if (!false)
			{
				stringBuilder2 = stringBuilder;
			}
			IL_4B:
			if (!(ShlwApi.AssocQueryString(ShlwApi.ASSOCF.ASSOCF_NONE, #Szc, #In, null, stringBuilder2, ref capacity) != 0))
			{
				return stringBuilder2.ToString();
			}
			IL_5F:
			if (3 != 0)
			{
				return null;
			}
			goto IL_4B;
		}

		// Token: 0x06005E02 RID: 24066
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, EntryPoint = "DocumentPropertiesW", ExactSpelling = true, SetLastError = true)]
		private static extern int #Tzc(IntPtr #Uzc, IntPtr #Vzc, [MarshalAs(UnmanagedType.LPWStr)] string #Wzc, IntPtr #Xzc, IntPtr #Yzc, int #Zzc);

		// Token: 0x040026FA RID: 9978
		private const int #a = 4;

		// Token: 0x040026FB RID: 9979
		private const int #b = 2;

		// Token: 0x040026FC RID: 9980
		private const int #c = 8;
	}
}

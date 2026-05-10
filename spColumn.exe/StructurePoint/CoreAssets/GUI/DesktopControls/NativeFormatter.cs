using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000882 RID: 2178
	public static class NativeFormatter
	{
		// Token: 0x060044F2 RID: 17650 RVA: 0x0013C724 File Offset: 0x0013A924
		public static bool Format(NativeNumberFormat format, double value, out string result)
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			bool flag = NativeFormatter._snwprintf_s(stringBuilder, stringBuilder.Capacity, 50, NativeFormatter.MyCreateFormat(format), value) >= 0;
			result = (flag ? stringBuilder.ToString() : null);
			return flag;
		}

		// Token: 0x060044F3 RID: 17651
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern int _snwprintf_s([MarshalAs(UnmanagedType.LPWStr)] StringBuilder str, int bufferSize, int length, string format, double p);

		// Token: 0x060044F4 RID: 17652 RVA: 0x0013C770 File Offset: 0x0013A970
		private static string MyCreateFormat(NativeNumberFormat format)
		{
			string text = format.ToString();
			string text2;
			if (!false)
			{
				text2 = text;
			}
			if (text2.StartsWith(#Phc.#3hc(107455038)) || text2.StartsWith(#Phc.#3hc(107386851)) || (text2.StartsWith(#Phc.#3hc(107455033)) && text2.Contains(#Phc.#3hc(107455028))))
			{
				return #Phc.#3hc(107360069) + text2.Substring(1).Replace('_', '.') + char.ToLower(text2[0], CultureInfo.InvariantCulture).ToString();
			}
			if (text2.StartsWith(#Phc.#3hc(107455033)))
			{
				string arg = text2.Substring(1);
				return string.Format(#Phc.#3hc(107454991), arg);
			}
			return string.Empty;
		}
	}
}

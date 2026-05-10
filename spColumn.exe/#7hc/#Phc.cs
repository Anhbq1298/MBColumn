using System;
using System.Collections.Generic;
using System.IO;

namespace #7hc
{
	// Token: 0x02000748 RID: 1864
	internal sealed class #Phc
	{
		// Token: 0x06003CBD RID: 15549 RVA: 0x00034521 File Offset: 0x00032721
		public static string #3hc(int A_0)
		{
			return #Phc.#fKg.#3hc(A_0);
		}

		// Token: 0x06003CBE RID: 15550 RVA: 0x0011ADA4 File Offset: 0x00118FA4
		public static string #4hc(int A_0)
		{
			object obj = #Phc.#e;
			\u0017.\u009D(obj);
			try
			{
				string text;
				#Phc.#d.TryGetValue(A_0, out text);
				if (text != null)
				{
					return text;
				}
			}
			finally
			{
				\u0017.\u009E(obj);
			}
			return #Phc.#5hc(A_0);
		}

		// Token: 0x06003CBF RID: 15551 RVA: 0x0011AE0C File Offset: 0x0011900C
		public static string #5hc(int A_0)
		{
			int num = A_0;
			byte[] array = #Phc.#c;
			int num2 = num;
			int num3 = num2 + 1;
			if (!false)
			{
				num = num3;
			}
			int num4 = array[num2];
			int num5;
			if ((num4 & 128) == 0)
			{
				num5 = num4;
				if (num5 == 0)
				{
					return string.Empty;
				}
			}
			else if ((num4 & 64) == 0)
			{
				num5 = ((num4 & 63) << 8) + (int)#Phc.#c[num++];
			}
			else
			{
				num5 = ((num4 & 31) << 24) + ((int)#Phc.#c[num++] << 16) + ((int)#Phc.#c[num++] << 8) + (int)#Phc.#c[num++];
			}
			string result;
			try
			{
				byte[] array2 = \u009C.\u0096\u0003(\u009B.~\u0095\u0003(\u009A.\u0094\u0003(), #Phc.#c, num, num5));
				string text = \u009D.\u0097\u0003(\u009B.~\u0095\u0003(\u009A.\u0094\u0003(), array2, 0, array2.Length));
				if (#Phc.#f)
				{
					#Phc.#6hc(A_0, text);
				}
				result = text;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003CC0 RID: 15552 RVA: 0x0011AF20 File Offset: 0x00119120
		public static void #6hc(int A_0, string A_1)
		{
			try
			{
				object obj = #Phc.#e;
				\u0017 u009D = \u0017.\u009D;
				object obj2 = obj;
				if (3 != 0)
				{
					u009D(obj2);
				}
				try
				{
					#Phc.#d.Add(A_0, A_1);
				}
				finally
				{
					\u0017.\u009E(obj);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06003CC1 RID: 15553 RVA: 0x0011AF88 File Offset: 0x00119188
		static #Phc()
		{
			if (\u0093.\u0016\u0003(#Phc.#a, "1"))
			{
				#Phc.#f = true;
				#Phc.#d = new Dictionary<int, string>();
			}
			#Phc.#g = \u009E.\u009D\u0003(#Phc.#b);
			Stream stream = \u0001\u0002.~\u009F\u0003(\u009F.\u009E\u0003(), "{f9d602eb-5494-42a8-99d2-170d5c02ccfb}");
			try
			{
				int num = \u0003\u0002.\u0003\u0004(\u0002\u0002.~\u0001\u0004(stream));
				#Phc.#c = new byte[num];
				\u0004\u0002.~\u0004\u0004(stream, #Phc.#c, 0, num);
			}
			finally
			{
				if (stream != null)
				{
					\u0007.~\u000E(stream);
				}
			}
		}

		// Token: 0x04001B73 RID: 7027
		private static readonly string #a = "0";

		// Token: 0x04001B74 RID: 7028
		private static readonly string #b = "91";

		// Token: 0x04001B75 RID: 7029
		private static readonly byte[] #c = null;

		// Token: 0x04001B76 RID: 7030
		private static readonly Dictionary<int, string> #d;

		// Token: 0x04001B77 RID: 7031
		private static readonly object #e = new object();

		// Token: 0x04001B78 RID: 7032
		private static readonly bool #f = false;

		// Token: 0x04001B79 RID: 7033
		private static readonly int #g = 0;

		// Token: 0x02000749 RID: 1865
		public static class #fKg
		{
			// Token: 0x06003CC2 RID: 15554 RVA: 0x00034531 File Offset: 0x00032731
			public static string #3hc(int A_0)
			{
				int num = A_0 ^ 107396847;
				if (!false)
				{
					A_0 = num;
				}
				A_0 -= #Phc.#g;
				if (!#Phc.#f)
				{
					return #Phc.#5hc(A_0);
				}
				return #Phc.#4hc(A_0);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading;
using #7hc;
using #hTb;

namespace #N6c
{
	// Token: 0x02000CF9 RID: 3321
	internal static class #Y7c
	{
		// Token: 0x17001DA7 RID: 7591
		// (get) Token: 0x06006C85 RID: 27781 RVA: 0x00055091 File Offset: 0x00053291
		internal static ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable
		{
			get
			{
				return LazyInitializer.EnsureInitialized<ConditionalWeakTable<object, SerializationInfo>>(ref #Y7c.#c);
			}
		}

		// Token: 0x06006C86 RID: 27782 RVA: 0x001A37A8 File Offset: 0x001A19A8
		public static int #T7c(int #GT)
		{
			if (#GT < 0)
			{
				throw new ArgumentException(#Phc.#3hc(107263743));
			}
			int num = 0;
			int num2;
			if (8 != 0)
			{
				num2 = num;
			}
			int result;
			for (;;)
			{
				while (!false)
				{
					if (num2 >= #Y7c.#b.Length)
					{
						return #GT;
					}
					if (2 != 0)
					{
						int num3 = #Y7c.#b[num2];
						int num4;
						if (!false)
						{
							num4 = num3;
						}
						int num5;
						if (num4 >= #GT)
						{
							result = (num5 = num4);
							if (6 != 0)
							{
								return result;
							}
						}
						else
						{
							num5 = num2 + 1;
						}
						if (!false)
						{
							num2 = num5;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06006C87 RID: 27783 RVA: 0x001A3808 File Offset: 0x001A1A08
		public static int #U7c(int #V7c)
		{
			int #GT;
			int num = #GT = 2 * #V7c;
			IL_03:
			while (6 != 0)
			{
				int num2;
				if (true)
				{
					num2 = num;
				}
				int i = num2;
				int num3 = 2146435069;
				while (i > num3)
				{
					int num4 = i = (#GT = (num = 2146435069));
					if (num4 == 0)
					{
						goto IL_03;
					}
					num3 = #V7c;
					if (7 != 0)
					{
						if (num4 > #V7c)
						{
							return 2146435069;
						}
						break;
					}
				}
				#GT = num2;
				break;
			}
			return #Y7c.#T7c(#GT);
		}

		// Token: 0x06006C88 RID: 27784 RVA: 0x001A3844 File Offset: 0x001A1A44
		public static byte[] #BBf(Stream #gp)
		{
			byte[] result;
			if (4 != 0)
			{
				SHA1Managed sha1Managed = new SHA1Managed();
				SHA1Managed sha1Managed2;
				if (6 != 0)
				{
					sha1Managed2 = sha1Managed;
				}
				try
				{
					byte[] array = sha1Managed2.ComputeHash(#gp);
					if (!false)
					{
						result = array;
					}
				}
				finally
				{
					while (!false && sha1Managed2 != null)
					{
						if (3 != 0)
						{
							((IDisposable)sha1Managed2).Dispose();
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06006C89 RID: 27785 RVA: 0x0005509D File Offset: 0x0005329D
		internal static object #W7c(object #AC)
		{
			return #AC;
		}

		// Token: 0x06006C8A RID: 27786 RVA: 0x000550A0 File Offset: 0x000532A0
		public static #f8c<#Fu> #X7c<#Fu>(this IEnumerable<#Fu> #8f)
		{
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			return new #f8c<!!0>(#8f);
		}

		// Token: 0x06006C8B RID: 27787 RVA: 0x000550BB File Offset: 0x000532BB
		// Note: this type is marked as 'beforefieldinit'.
		static #Y7c()
		{
			int[] array = new int[104];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#a).FieldHandle;
			if (7 != 0)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			#Y7c.#b = array;
		}

		// Token: 0x04002C28 RID: 11304
		public const int #a = 2146435069;

		// Token: 0x04002C29 RID: 11305
		private static readonly int[] #b;

		// Token: 0x04002C2A RID: 11306
		private static ConditionalWeakTable<object, SerializationInfo> #c;
	}
}

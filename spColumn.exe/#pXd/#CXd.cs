using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;

namespace #pXd
{
	// Token: 0x02000E9F RID: 3743
	internal static class #CXd
	{
		// Token: 0x060085BA RID: 34234 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #sXd<#Fu>(this #Fu #tXd)
		{
		}

		// Token: 0x060085BB RID: 34235 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #uXd<#Fu>(this #Fu #tXd)
		{
		}

		// Token: 0x060085BC RID: 34236 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #vXd<#Fu>(this #Fu #tXd, string #5)
		{
		}

		// Token: 0x060085BD RID: 34237 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #vXd<#Fu>(this #Fu #tXd, string #5, bool #wXd)
		{
		}

		// Token: 0x060085BE RID: 34238 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #vXd(Type #C, string #5)
		{
		}

		// Token: 0x060085BF RID: 34239 RVA: 0x00009E6A File Offset: 0x0000806A
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void #vXd(Type #C, string #5, bool #wXd)
		{
		}

		// Token: 0x060085C0 RID: 34240 RVA: 0x001CBC14 File Offset: 0x001C9E14
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static void #xXd()
		{
			try
			{
				#CXd.StackTraceInfoProvider;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060085C1 RID: 34241 RVA: 0x001CBC3C File Offset: 0x001C9E3C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		[Conditional("DEBUG")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void #yXd(Type #C, string #zXd, bool #wXd = false)
		{
			try
			{
				int num = 3;
				for (;;)
				{
					int num2;
					if (true)
					{
						num2 = num;
					}
					if (#wXd)
					{
						goto IL_08;
					}
					IL_0F:
					if (8 != 0)
					{
						string text = (#CXd.StackTraceInfoProvider != null) ? #CXd.StackTraceInfoProvider.#QXd(num2) : #Phc.#3hc(107227652);
						string text2;
						if (4 != 0)
						{
							text2 = text;
						}
						bool flag = (num = (string.IsNullOrWhiteSpace(text2) ? 1 : 0)) != 0;
						if (5 == 0)
						{
							continue;
						}
						string text3 = flag ? #Phc.#3hc(107227652) : text2;
						if (!false)
						{
							text2 = text3;
						}
					}
					if (!false)
					{
						break;
					}
					IL_08:
					int num3 = num2 + 1;
					if (8 == 0)
					{
						goto IL_0F;
					}
					num2 = num3;
					goto IL_0F;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x17002805 RID: 10245
		// (get) Token: 0x060085C2 RID: 34242 RVA: 0x0006CF08 File Offset: 0x0006B108
		// (set) Token: 0x060085C3 RID: 34243 RVA: 0x0006CF0F File Offset: 0x0006B10F
		public static #TXd StackTraceInfoProvider { get; set; }

		// Token: 0x0400373F RID: 14143
		[CompilerGenerated]
		private static #TXd #a;
	}
}

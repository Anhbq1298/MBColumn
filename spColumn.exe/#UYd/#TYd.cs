using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using #7hc;
using Vanara.PInvoke;

namespace #UYd
{
	// Token: 0x02000EC5 RID: 3781
	internal static class #TYd
	{
		// Token: 0x1700281D RID: 10269
		// (get) Token: 0x0600864D RID: 34381 RVA: 0x0006D588 File Offset: 0x0006B788
		// (set) Token: 0x0600864E RID: 34382 RVA: 0x0006D58F File Offset: 0x0006B78F
		public static bool Active { get; set; }

		// Token: 0x1700281E RID: 10270
		// (get) Token: 0x0600864F RID: 34383 RVA: 0x0006D597 File Offset: 0x0006B797
		// (set) Token: 0x06008650 RID: 34384 RVA: 0x0006D59E File Offset: 0x0006B79E
		public static ConsoleColor InfoColor { get; set; } = ConsoleColor.Gray;

		// Token: 0x1700281F RID: 10271
		// (get) Token: 0x06008651 RID: 34385 RVA: 0x0006D5A6 File Offset: 0x0006B7A6
		// (set) Token: 0x06008652 RID: 34386 RVA: 0x0006D5AD File Offset: 0x0006B7AD
		public static ConsoleColor WarnColor { get; set; } = ConsoleColor.Yellow;

		// Token: 0x17002820 RID: 10272
		// (get) Token: 0x06008653 RID: 34387 RVA: 0x0006D5B5 File Offset: 0x0006B7B5
		// (set) Token: 0x06008654 RID: 34388 RVA: 0x0006D5BC File Offset: 0x0006B7BC
		public static ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;

		// Token: 0x06008655 RID: 34389 RVA: 0x001CC710 File Offset: 0x001CA910
		public static void #SYd(ConsoleColor #BR, string #5, bool #cA = true)
		{
			if (#TYd.Active)
			{
				if (4 != 0)
				{
					if (!false)
					{
						#TYd.#IPd();
					}
					if (false)
					{
						return;
					}
					#TYd.#l4d #l4d = new #TYd.#l4d(#BR);
					#TYd.#l4d #l4d2;
					if (6 != 0)
					{
						#l4d2 = #l4d;
						goto IL_1B;
					}
					try
					{
						do
						{
							IL_1B:
							string #6 = #5 ?? string.Empty;
							bool #qWi = false;
							if (5 != 0)
							{
								#TYd.#SYd(#6, #cA, #qWi);
							}
						}
						while (false);
					}
					finally
					{
						if (#l4d2 != null)
						{
							((IDisposable)#l4d2).Dispose();
						}
					}
				}
				return;
			}
		}

		// Token: 0x06008656 RID: 34390 RVA: 0x001CC77C File Offset: 0x001CA97C
		public static void #npb(ConsoleColor #BR, string #5, bool #cA = true)
		{
			if (#TYd.Active)
			{
				if (4 != 0)
				{
					if (!false)
					{
						#TYd.#IPd();
					}
					if (false)
					{
						return;
					}
					#TYd.#l4d #l4d = new #TYd.#l4d(#BR);
					#TYd.#l4d #l4d2;
					if (6 != 0)
					{
						#l4d2 = #l4d;
						goto IL_1B;
					}
					try
					{
						do
						{
							IL_1B:
							string #6 = #5 ?? string.Empty;
							bool #qWi = true;
							if (5 != 0)
							{
								#TYd.#SYd(#6, #cA, #qWi);
							}
						}
						while (false);
					}
					finally
					{
						if (#l4d2 != null)
						{
							((IDisposable)#l4d2).Dispose();
						}
					}
				}
				return;
			}
		}

		// Token: 0x06008657 RID: 34391 RVA: 0x001CC77C File Offset: 0x001CA97C
		public static void #uP(ConsoleColor #BR, string #5, bool #cA = true)
		{
			if (#TYd.Active)
			{
				if (4 != 0)
				{
					if (!false)
					{
						#TYd.#IPd();
					}
					if (false)
					{
						return;
					}
					#TYd.#l4d #l4d = new #TYd.#l4d(#BR);
					#TYd.#l4d #l4d2;
					if (6 != 0)
					{
						#l4d2 = #l4d;
						goto IL_1B;
					}
					try
					{
						do
						{
							IL_1B:
							string #6 = #5 ?? string.Empty;
							bool #qWi = true;
							if (5 != 0)
							{
								#TYd.#SYd(#6, #cA, #qWi);
							}
						}
						while (false);
					}
					finally
					{
						if (#l4d2 != null)
						{
							((IDisposable)#l4d2).Dispose();
						}
					}
				}
				return;
			}
		}

		// Token: 0x06008658 RID: 34392 RVA: 0x0006D5C4 File Offset: 0x0006B7C4
		public static void #pn(string #5 = null, bool #cA = true)
		{
			ConsoleColor #BR = #TYd.InfoColor;
			if (2 != 0)
			{
				#TYd.#SYd(#BR, #5, #cA);
			}
		}

		// Token: 0x06008659 RID: 34393 RVA: 0x0006D5DA File Offset: 0x0006B7DA
		public static void #tn(string #5, bool #cA = true)
		{
			ConsoleColor #BR = #TYd.WarnColor;
			if (2 != 0)
			{
				#TYd.#SYd(#BR, #5, #cA);
			}
		}

		// Token: 0x0600865A RID: 34394 RVA: 0x0006D5F0 File Offset: 0x0006B7F0
		public static void #qn(string #5, bool #cA = true)
		{
			ConsoleColor #BR = #TYd.ErrorColor;
			if (2 != 0)
			{
				#TYd.#SYd(#BR, #5, #cA);
			}
		}

		// Token: 0x0600865B RID: 34395 RVA: 0x001CC7E8 File Offset: 0x001CA9E8
		public static string #qp(string #5)
		{
			DateTime now = DateTime.Now;
			DateTime dateTime;
			if (!false)
			{
				dateTime = now;
			}
			return dateTime.ToString(#Phc.#3hc(107455033), CultureInfo.InvariantCulture) + #Phc.#3hc(107382888) + #5;
		}

		// Token: 0x0600865C RID: 34396 RVA: 0x001CC828 File Offset: 0x001CAA28
		private static void #IPd()
		{
			int nStdHandle;
			bool flag = (nStdHandle = (#TYd.#a ? 1 : 0)) != 0;
			if (2 != 0)
			{
				if (flag)
				{
					return;
				}
				if (8 == 0)
				{
					goto IL_1F;
				}
				#TYd.#a = true;
				nStdHandle = -11;
			}
			IL_16:
			HFILE stdHandle = Kernel32.GetStdHandle((Kernel32.StdHandleType)nStdHandle);
			HFILE hConsoleOutput;
			if (!false)
			{
				hConsoleOutput = stdHandle;
			}
			IL_1F:
			Kernel32.CONSOLE_SCREEN_BUFFER_INFOEX console_SCREEN_BUFFER_INFOEX = default(Kernel32.CONSOLE_SCREEN_BUFFER_INFOEX);
			if (!false)
			{
				console_SCREEN_BUFFER_INFOEX.cbSize = (uint)Marshal.SizeOf(typeof(Kernel32.CONSOLE_SCREEN_BUFFER_INFOEX));
				if (Kernel32.GetConsoleScreenBufferInfoEx(hConsoleOutput, ref console_SCREEN_BUFFER_INFOEX))
				{
					console_SCREEN_BUFFER_INFOEX.ColorTable[14] = new COLORREF(byte.MaxValue, 145, 0);
					nStdHandle = (Kernel32.SetConsoleScreenBufferInfoEx(hConsoleOutput, console_SCREEN_BUFFER_INFOEX) ? 1 : 0);
					if (5 != 0)
					{
						return;
					}
					goto IL_16;
				}
			}
		}

		// Token: 0x0600865D RID: 34397 RVA: 0x001CC8AC File Offset: 0x001CAAAC
		private static void #SYd(string #5, bool #cA, bool #qWi)
		{
			if (string.IsNullOrWhiteSpace(#5))
			{
				goto IL_21;
			}
			int num = #cA ? 1 : 0;
			if (false)
			{
				goto IL_C4;
			}
			string text;
			if (#cA)
			{
				text = #TYd.#qp(#5);
				goto IL_1A;
			}
			IL_11:
			text = #5;
			IL_1A:
			if (!false)
			{
				#5 = text;
			}
			IL_21:
			bool flag = string.IsNullOrWhiteSpace(#5);
			string[] array2;
			string text3;
			int num3;
			while (!flag)
			{
				string[] array = #5.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				if (8 != 0)
				{
					array2 = array;
				}
				flag = #cA;
				if (!false)
				{
					string text2 = #cA ? #TYd.#qp(string.Empty) : string.Empty;
					if (!false)
					{
						text3 = text2;
					}
					int num2 = 0;
					if (4 != 0)
					{
						num3 = num2;
					}
					goto IL_C3;
				}
			}
			return;
			IL_C3:
			num = num3;
			IL_C4:
			if (num >= array2.Length)
			{
				return;
			}
			string text4 = ((num3 > 0) ? string.Empty.PadLeft(text3.Length, ' ') : string.Empty) + array2[num3];
			string text5;
			if (!false)
			{
				text5 = text4;
			}
			if (false)
			{
				goto IL_11;
			}
			if (#qWi)
			{
				string value = #Phc.#3hc(107268481) + text5;
				if (5 != 0)
				{
					Console.Write(value);
				}
			}
			else
			{
				Console.WriteLine(text5);
			}
			IL_B4:
			if (!false)
			{
				num3++;
				goto IL_C3;
			}
			goto IL_B4;
		}

		// Token: 0x040037A0 RID: 14240
		private static bool #a;

		// Token: 0x040037A1 RID: 14241
		[CompilerGenerated]
		private static bool #b;

		// Token: 0x040037A2 RID: 14242
		[CompilerGenerated]
		private static ConsoleColor #c;

		// Token: 0x040037A3 RID: 14243
		[CompilerGenerated]
		private static ConsoleColor #d;

		// Token: 0x040037A4 RID: 14244
		[CompilerGenerated]
		private static ConsoleColor #e;

		// Token: 0x02000EC6 RID: 3782
		internal sealed class #l4d : IDisposable
		{
			// Token: 0x0600865F RID: 34399 RVA: 0x0006D61C File Offset: 0x0006B81C
			public #l4d(ConsoleColor #m4d)
			{
				this.#a = Console.ForegroundColor;
				Console.ForegroundColor = #m4d;
			}

			// Token: 0x06008660 RID: 34400 RVA: 0x0006D635 File Offset: 0x0006B835
			public void #1()
			{
				ConsoleColor foregroundColor = this.#a;
				if (!false)
				{
					Console.ForegroundColor = foregroundColor;
				}
			}

			// Token: 0x040037A5 RID: 14245
			private readonly ConsoleColor #a;
		}
	}
}

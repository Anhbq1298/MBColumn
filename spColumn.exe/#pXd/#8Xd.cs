using System;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #pXd
{
	// Token: 0x02000EAB RID: 3755
	internal static class #8Xd
	{
		// Token: 0x060085E5 RID: 34277 RVA: 0x001CBEC0 File Offset: 0x001CA0C0
		public static void #2Xd(TimeSpan #CA)
		{
			while (#CA.TotalSeconds > 0.0)
			{
				if (!false)
				{
					EventWaitHandle eventWaitHandle = new ManualResetEvent(false);
					EventWaitHandle eventWaitHandle2;
					if (!false)
					{
						eventWaitHandle2 = eventWaitHandle;
						goto IL_20;
					}
					try
					{
						do
						{
							IL_20:
							eventWaitHandle2.WaitOne(#CA);
						}
						while (false);
					}
					finally
					{
						if (eventWaitHandle2 != null)
						{
							((IDisposable)eventWaitHandle2).Dispose();
						}
					}
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x060085E6 RID: 34278 RVA: 0x0006D061 File Offset: 0x0006B261
		public static #Fu #3Xd<#Fu, #6Xd>(Func<#Fu> #4Xd, int #5Xd) where #6Xd : Exception
		{
			string #R0d = #Phc.#3hc(107228008);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107228031);
			if (!false)
			{
				#X0d.#V0d(#4Xd, #R0d, #x6c, #Qic);
			}
			return #8Xd.#3Xd<#Fu, #6Xd>(#4Xd, #5Xd, TimeSpan.Zero);
		}

		// Token: 0x060085E7 RID: 34279 RVA: 0x001CBF1C File Offset: 0x001CA11C
		public static #Fu #3Xd<#Fu, #6Xd>(Func<#Fu> #4Xd, int #5Xd, TimeSpan #7Xd) where #6Xd : Exception
		{
			string #R0d = #Phc.#3hc(107228008);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107227946);
			if (5 != 0)
			{
				#X0d.#V0d(#4Xd, #R0d, #x6c, #Qic);
			}
			int num = 1;
			int i;
			if (!false)
			{
				i = num;
			}
			while (i < #5Xd)
			{
				try
				{
					#Fu #Fu = #4Xd();
					#Fu result;
					if (!false)
					{
						result = #Fu;
					}
					return result;
				}
				catch (!!1)
				{
					#8Xd.#2Xd(#7Xd);
				}
				int num2 = i + 1;
				if (6 == 0)
				{
					continue;
				}
				i = num2;
			}
			return #4Xd();
		}

		// Token: 0x060085E8 RID: 34280 RVA: 0x0006D093 File Offset: 0x0006B293
		public static void #3Xd<#6Xd>(Action #nd, int #5Xd) where #6Xd : Exception
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107351365);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107227925);
				if (!false)
				{
					#X0d.#V0d(#nd, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					TimeSpan zero = TimeSpan.Zero;
					if (4 != 0)
					{
						#8Xd.#3Xd<#6Xd>(#nd, #5Xd, zero);
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060085E9 RID: 34281 RVA: 0x001CBF98 File Offset: 0x001CA198
		public static void #3Xd<#6Xd>(Action #nd, int #5Xd, TimeSpan #7Xd) where #6Xd : Exception
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107351365);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107227328);
				if (!false)
				{
					#X0d.#V0d(#nd, #R0d, #x6c, #Qic);
				}
				int num = 1;
				for (;;)
				{
					IL_1E:
					int num2;
					if (!false)
					{
						num2 = num;
					}
					while (!false)
					{
						for (;;)
						{
							int num3 = num = num2;
							if (false)
							{
								goto IL_1E;
							}
							if (num3 >= #5Xd)
							{
								break;
							}
							try
							{
								if (true)
								{
									#nd();
								}
								break;
							}
							catch (!!0)
							{
								#8Xd.#2Xd(#7Xd);
							}
							int num4 = num2 + 1;
							if (!false)
							{
								num2 = num4;
							}
						}
						if (-1 != 0)
						{
							goto Block_3;
						}
					}
					break;
				}
			}
			Block_3:
			if (!false)
			{
				#nd();
			}
		}
	}
}

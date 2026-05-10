using System;
using System.Linq;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Infrastructure
{
	// Token: 0x02000EA8 RID: 3752
	public sealed class NonBlockingLock
	{
		// Token: 0x060085D9 RID: 34265 RVA: 0x0006CFBA File Offset: 0x0006B1BA
		public NonBlockingLock()
		{
			this.#a = 0;
		}

		// Token: 0x060085DA RID: 34266 RVA: 0x001CBDF8 File Offset: 0x001C9FF8
		public static bool #UXd(params NonBlockingLock[] #VXd)
		{
			do
			{
				string #R0d = #Phc.#3hc(107228139);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107228146);
				if (8 != 0)
				{
					#X0d.#V0d(#VXd, #R0d, #x6c, #Qic);
				}
			}
			while (7 == 0 || false);
			return #VXd.Any(new Func<NonBlockingLock, bool>(NonBlockingLock.<>c.<>9.#d4d));
		}

		// Token: 0x060085DB RID: 34267 RVA: 0x001CBE54 File Offset: 0x001CA054
		public static void #WXd(params NonBlockingLock[] #VXd)
		{
			string #R0d = #Phc.#3hc(107228139);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107228093);
			if (2 != 0)
			{
				#X0d.#V0d(#VXd, #R0d, #x6c, #Qic);
			}
			int num2;
			if (!false)
			{
				if (false)
				{
				}
				int num = 0;
				if (3 != 0)
				{
					num2 = num;
				}
				if (false)
				{
					return;
				}
				if (8 != 0)
				{
					goto IL_40;
				}
				goto IL_40;
			}
			IL_32:
			NonBlockingLock nonBlockingLock = #VXd[num2];
			if (2 != 0)
			{
				nonBlockingLock.#ZXd();
			}
			int num3 = num2 + 1;
			if (true)
			{
				num2 = num3;
			}
			IL_40:
			if (num2 < #VXd.Length)
			{
				goto IL_32;
			}
		}

		// Token: 0x060085DC RID: 34268 RVA: 0x0006CFC9 File Offset: 0x0006B1C9
		public bool #XXd()
		{
			return Interlocked.CompareExchange(ref this.#a, 1, 1) == 1;
		}

		// Token: 0x060085DD RID: 34269 RVA: 0x0006CFDB File Offset: 0x0006B1DB
		public bool #YXd()
		{
			return Interlocked.Exchange(ref this.#a, 1) == 0;
		}

		// Token: 0x060085DE RID: 34270 RVA: 0x0006CFEC File Offset: 0x0006B1EC
		public void #ZXd()
		{
			Interlocked.Exchange(ref this.#a, 0);
		}

		// Token: 0x04003745 RID: 14149
		private int #a;
	}
}

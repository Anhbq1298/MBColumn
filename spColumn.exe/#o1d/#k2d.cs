using System;
using System.IO;
using System.Text;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #o1d
{
	// Token: 0x02000EF4 RID: 3828
	internal static class #k2d
	{
		// Token: 0x0600877D RID: 34685 RVA: 0x001D1238 File Offset: 0x001CF438
		public static bool #i2d(this Stream #gp)
		{
			int result;
			do
			{
				string #R0d = #Phc.#3hc(107377314);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107224844);
				if (3 != 0)
				{
					#X0d.#V0d(#gp, #R0d, #x6c, #Qic);
				}
				if (4 == 0)
				{
					return false;
				}
				bool flag = (result = (#gp.CanSeek ? 1 : 0)) != 0;
				if (-1 == 0)
				{
					return result != 0;
				}
				if (!flag)
				{
					return false;
				}
				#gp.Seek(0L, SeekOrigin.Begin);
			}
			while (false);
			result = 1;
			return result != 0;
		}

		// Token: 0x0600877E RID: 34686 RVA: 0x001D1288 File Offset: 0x001CF488
		public static void #LAc(this Stream #gp, string #Ukc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107377314);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107224311);
				if (!false)
				{
					#X0d.#V0d(#gp, #R0d, #x6c, #Qic);
				}
				StreamWriter streamWriter = new StreamWriter(#gp, Encoding.UTF8, 2048);
				StreamWriter streamWriter2;
				if (!false)
				{
					streamWriter2 = streamWriter;
				}
				try
				{
					if (!false)
					{
						TextWriter textWriter = streamWriter2;
						if (5 != 0)
						{
							textWriter.WriteLine(#Ukc);
						}
						TextWriter textWriter2 = streamWriter2;
						if (6 != 0)
						{
							textWriter2.Flush();
						}
					}
				}
				finally
				{
					if (streamWriter2 != null && -1 != 0)
					{
						((IDisposable)streamWriter2).Dispose();
					}
				}
			}
			while (false);
		}

		// Token: 0x0600877F RID: 34687 RVA: 0x0006E191 File Offset: 0x0006C391
		public static MemoryStream #j2d(this byte[] #87c)
		{
			if (#87c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107224226));
			}
			return new MemoryStream(#87c);
		}
	}
}

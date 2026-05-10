using System;
using System.IO;
using System.Text;
using #7hc;
using #o1d;

namespace #5Fd
{
	// Token: 0x02000D80 RID: 3456
	internal sealed class #iGd : #gGd
	{
		// Token: 0x06007D2E RID: 32046 RVA: 0x00065B6C File Offset: 0x00063D6C
		public #iGd(Encoding #51c)
		{
			if (#51c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281661));
			}
			this.#a = #51c;
		}

		// Token: 0x06007D2F RID: 32047 RVA: 0x00065B9A File Offset: 0x00063D9A
		public #iGd() : this(Encoding.UTF8)
		{
		}

		// Token: 0x17002593 RID: 9619
		// (get) Token: 0x06007D30 RID: 32048 RVA: 0x00065BA7 File Offset: 0x00063DA7
		public long Length
		{
			get
			{
				return (long)\u008D\u0002.~\u0090\u0005(this.#b);
			}
		}

		// Token: 0x06007D31 RID: 32049 RVA: 0x00065BC2 File Offset: 0x00063DC2
		public string #h()
		{
			return \u007F.~\u0011\u0002(this.#b);
		}

		// Token: 0x06007D32 RID: 32050 RVA: 0x00065BDC File Offset: 0x00063DDC
		public void #cGd(string #f)
		{
			\u0097\u0003.~\u0012\u0008(this.#b, #f);
		}

		// Token: 0x06007D33 RID: 32051 RVA: 0x00065BFC File Offset: 0x00063DFC
		public void #dGd(char #f)
		{
			\u009D\u0004.~\u008F\u000E(this.#b, #f);
		}

		// Token: 0x06007D34 RID: 32052 RVA: 0x00065C1C File Offset: 0x00063E1C
		public void #cGd()
		{
			\u009E\u0004.~\u0090\u000E(this.#b);
		}

		// Token: 0x06007D35 RID: 32053 RVA: 0x00065C37 File Offset: 0x00063E37
		public void #dGd(string #f)
		{
			\u0097\u0003.~\u0011\u0008(this.#b, #f);
		}

		// Token: 0x06007D36 RID: 32054 RVA: 0x00065C57 File Offset: 0x00063E57
		public char #eGd()
		{
			return \u008C\u0002.~\u008B\u0005(this.#b, \u008D\u0002.~\u0090\u0005(this.#b) - 1);
		}

		// Token: 0x06007D37 RID: 32055 RVA: 0x001B9898 File Offset: 0x001B7A98
		public void #fGd(Stream #dAb)
		{
			#dAb.#i2d();
			if (\u0002\u0002.~\u0001\u0004(#dAb) != 0L)
			{
				\u009F\u0004.~\u0092\u000E(#dAb, 0L);
			}
			StreamWriter streamWriter = new StreamWriter(#dAb, this.#a, 4096, true);
			try
			{
				\u0007\u0003.~\u0011\u0007(streamWriter, \u007F.~\u0011\u0002(this.#b));
			}
			finally
			{
				if (streamWriter != null)
				{
					\u0007.~\u000E(streamWriter);
				}
			}
		}

		// Token: 0x04003343 RID: 13123
		private readonly Encoding #a;

		// Token: 0x04003344 RID: 13124
		private readonly StringBuilder #b = new StringBuilder();
	}
}

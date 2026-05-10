using System;
using System.IO;
using System.Linq;
using System.Text;
using #o1d;

namespace #5Fd
{
	// Token: 0x02000D82 RID: 3458
	internal sealed class #mGd : IDisposable, #gGd
	{
		// Token: 0x06007D3E RID: 32062 RVA: 0x00065CC1 File Offset: 0x00063EC1
		public #mGd(Stream #gp, Encoding #51c)
		{
			this.#a = new StreamWriter(#gp, #51c, 4096, true);
		}

		// Token: 0x06007D3F RID: 32063 RVA: 0x00065CDC File Offset: 0x00063EDC
		public #mGd(Stream #gp) : this(#gp, Encoding.UTF8)
		{
		}

		// Token: 0x17002596 RID: 9622
		// (get) Token: 0x06007D40 RID: 32064 RVA: 0x00065CEA File Offset: 0x00063EEA
		public long Length
		{
			get
			{
				return \u0002\u0002.~\u0001\u0004(\u0001\u0005.~\u0094\u000E(this.#a));
			}
		}

		// Token: 0x06007D41 RID: 32065 RVA: 0x00065D12 File Offset: 0x00063F12
		public void #lGd()
		{
			\u0007.~\u001C(this.#a);
		}

		// Token: 0x06007D42 RID: 32066 RVA: 0x001B9A60 File Offset: 0x001B7C60
		public void #cGd(string #f)
		{
			\u0007\u0003.~\u0011\u0007(this.#a, #f);
			\u0007\u0003.~\u0011\u0007(this.#a, \u008E.\u0099\u0002());
			this.#b = '\n';
		}

		// Token: 0x06007D43 RID: 32067 RVA: 0x00065D2C File Offset: 0x00063F2C
		public void #dGd(char #f)
		{
			\u0002\u0005.~\u0095\u000E(this.#a, #f);
			this.#b = #f;
		}

		// Token: 0x06007D44 RID: 32068 RVA: 0x00065D52 File Offset: 0x00063F52
		public void #cGd()
		{
			\u0007\u0003.~\u0011\u0007(this.#a, \u008E.\u0099\u0002());
			this.#b = '\n';
		}

		// Token: 0x06007D45 RID: 32069 RVA: 0x00065D82 File Offset: 0x00063F82
		public void #dGd(string #f)
		{
			if (\u0003.\u0005(#f))
			{
				return;
			}
			\u0007\u0003.~\u0011\u0007(this.#a, #f);
			this.#b = #f.Last<char>();
		}

		// Token: 0x06007D46 RID: 32070 RVA: 0x00065DBB File Offset: 0x00063FBB
		public char #eGd()
		{
			return this.#b;
		}

		// Token: 0x06007D47 RID: 32071 RVA: 0x001B9AAC File Offset: 0x001B7CAC
		public void #fGd(Stream #dAb)
		{
			\u0007.~\u001C(this.#a);
			long num = \u0002\u0002.~\u0002\u0004(\u0001\u0005.~\u0094\u000E(this.#a));
			\u0001\u0005.~\u0094\u000E(this.#a).#i2d();
			#dAb.#i2d();
			\u009F\u0004.~\u0092\u000E(#dAb, 0L);
			\u0089\u0003.~\u009B\u0007(\u0001\u0005.~\u0094\u000E(this.#a), #dAb);
			\u009F\u0004.~\u0093\u000E(\u0001\u0005.~\u0094\u000E(this.#a), num);
		}

		// Token: 0x06007D48 RID: 32072 RVA: 0x00065DC7 File Offset: 0x00063FC7
		public void #1()
		{
			\u0007.~\u001D(this.#a);
		}

		// Token: 0x0400334A RID: 13130
		private readonly StreamWriter #a;

		// Token: 0x0400334B RID: 13131
		private char #b;
	}
}

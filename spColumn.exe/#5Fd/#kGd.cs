using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;

namespace #5Fd
{
	// Token: 0x02000D81 RID: 3457
	internal sealed class #kGd : #bGd
	{
		// Token: 0x06007D38 RID: 32056 RVA: 0x001B9924 File Offset: 0x001B7B24
		public #kGd(Stream #gp)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			this.#a = #gp;
			this.HasNextPage = true;
			this.#b = new StreamReader(#gp);
		}

		// Token: 0x17002594 RID: 9620
		// (get) Token: 0x06007D39 RID: 32057 RVA: 0x00065C87 File Offset: 0x00063E87
		// (set) Token: 0x06007D3A RID: 32058 RVA: 0x00065C93 File Offset: 0x00063E93
		public bool HasNextPage { get; private set; }

		// Token: 0x17002595 RID: 9621
		// (get) Token: 0x06007D3B RID: 32059 RVA: 0x00065CA4 File Offset: 0x00063EA4
		// (set) Token: 0x06007D3C RID: 32060 RVA: 0x00065CB0 File Offset: 0x00063EB0
		public TextReportPage CurrentPage { get; private set; }

		// Token: 0x06007D3D RID: 32061 RVA: 0x001B9970 File Offset: 0x001B7B70
		public bool #aGd()
		{
			string text = null;
			this.HasNextPage = false;
			string text2;
			for (;;)
			{
				text2 = \u007F.~\u0016\u0002(this.#b);
				if (text2 == null)
				{
					goto IL_5B;
				}
				if (\u008D\u0002.~\u008C\u0005(text2) > 0 && \u008C\u0002.~\u008A\u0005(text2, 0) == '\f')
				{
					break;
				}
				\u0097\u0003.~\u0012\u0008(this.#c, text2);
			}
			text = text2;
			IL_5B:
			this.CurrentPage = new TextReportPage(\u007F.~\u0011\u0002(this.#c));
			bool result = \u008D\u0002.~\u0090\u0005(this.#c) > 0;
			\u009E\u0004.~\u0091\u000E(this.#c);
			if (!\u0003.\u0004(text))
			{
				text = \u0014.~\u0098(text, 1);
				\u0097\u0003.~\u0012\u0008(this.#c, text);
				this.HasNextPage = true;
			}
			return result;
		}

		// Token: 0x04003345 RID: 13125
		private readonly Stream #a;

		// Token: 0x04003346 RID: 13126
		private readonly StreamReader #b;

		// Token: 0x04003347 RID: 13127
		private readonly StringBuilder #c = new StringBuilder();

		// Token: 0x04003348 RID: 13128
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04003349 RID: 13129
		[CompilerGenerated]
		private TextReportPage #e;
	}
}

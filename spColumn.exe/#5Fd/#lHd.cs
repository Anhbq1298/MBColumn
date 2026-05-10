using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using #7hc;

namespace #5Fd
{
	// Token: 0x02000D90 RID: 3472
	internal class #lHd
	{
		// Token: 0x06007D9E RID: 32158 RVA: 0x001BA2AC File Offset: 0x001B84AC
		public #lHd(int #mHd, #gGd #tCd)
		{
			this.PageSize = #mHd;
			this.LineWidth = 112;
			if (#tCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251540));
			}
			this.#b = #tCd;
			this.#i = new List<#QGd>();
			this.AutoSplitLongLines = true;
			this.AddHeaderToFirstPage = true;
		}

		// Token: 0x06007D9F RID: 32159 RVA: 0x0006622B File Offset: 0x0006442B
		public #lHd(int #mHd) : this(#mHd, new #iGd())
		{
		}

		// Token: 0x170025AA RID: 9642
		// (get) Token: 0x06007DA0 RID: 32160 RVA: 0x00066239 File Offset: 0x00064439
		// (set) Token: 0x06007DA1 RID: 32161 RVA: 0x00066245 File Offset: 0x00064445
		public bool AutoSplitLongLines { get; set; }

		// Token: 0x170025AB RID: 9643
		// (get) Token: 0x06007DA2 RID: 32162 RVA: 0x00066256 File Offset: 0x00064456
		// (set) Token: 0x06007DA3 RID: 32163 RVA: 0x00066262 File Offset: 0x00064462
		public int LineWidth { get; set; }

		// Token: 0x170025AC RID: 9644
		// (get) Token: 0x06007DA4 RID: 32164 RVA: 0x00066273 File Offset: 0x00064473
		public List<#QGd> NewPageStartContents { get; }

		// Token: 0x170025AD RID: 9645
		// (get) Token: 0x06007DA5 RID: 32165 RVA: 0x0006627F File Offset: 0x0006447F
		// (set) Token: 0x06007DA6 RID: 32166 RVA: 0x0006628B File Offset: 0x0006448B
		public bool AddHeaderToFirstPage { get; set; }

		// Token: 0x170025AE RID: 9646
		// (get) Token: 0x06007DA7 RID: 32167 RVA: 0x0006629C File Offset: 0x0006449C
		// (set) Token: 0x06007DA8 RID: 32168 RVA: 0x000662A8 File Offset: 0x000644A8
		public int PageSize { get; set; }

		// Token: 0x170025AF RID: 9647
		// (get) Token: 0x06007DA9 RID: 32169 RVA: 0x000662B9 File Offset: 0x000644B9
		// (set) Token: 0x06007DAA RID: 32170 RVA: 0x000662C5 File Offset: 0x000644C5
		public bool WriteXmlTestTags { get; set; }

		// Token: 0x170025B0 RID: 9648
		// (get) Token: 0x06007DAB RID: 32171 RVA: 0x000662D6 File Offset: 0x000644D6
		// (set) Token: 0x06007DAC RID: 32172 RVA: 0x000662E2 File Offset: 0x000644E2
		public int NumberOfPages { get; private set; }

		// Token: 0x06007DAD RID: 32173 RVA: 0x000662F3 File Offset: 0x000644F3
		public void #fdd()
		{
			this.#gHd();
		}

		// Token: 0x06007DAE RID: 32174 RVA: 0x00066303 File Offset: 0x00064503
		public void #fGd(Stream #dAb)
		{
			this.#b.#fGd(#dAb);
		}

		// Token: 0x06007DAF RID: 32175 RVA: 0x0006631D File Offset: 0x0006451D
		public string #cHd()
		{
			return \u008E\u0003.~\u0002\u0008(\u007F.~\u0011\u0002(this.#b), new char[]
			{
				'\r',
				'\n',
				' ',
				'\f'
			});
		}

		// Token: 0x06007DB0 RID: 32176 RVA: 0x001BA324 File Offset: 0x001B8524
		public void #dGd(string #f, bool #dHd = false)
		{
			if (#f == null)
			{
				return;
			}
			bool flag = \u0005\u0005.~\u0098\u000E(#f, \u008E.\u0099\u0002(), StringComparison.Ordinal);
			if (this.AddHeaderToFirstPage && this.#e == 1 && this.#f == 0 && !this.#d)
			{
				this.#d = true;
				this.#gHd(this.#e);
			}
			#f = this.#hHd(#f, this.LineWidth);
			int num = 0;
			List<Match> list = \u0090\u0002.~\u009C\u0005(this.#c, #f).OfType<Match>().ToList<Match>();
			if (#dHd && list.Count > 0)
			{
				int count = list.Count;
				if (this.#f + count >= this.PageSize)
				{
					this.#gHd();
				}
			}
			foreach (Match match in list)
			{
				int num2 = \u008D\u0002.~\u008E\u0005(match) - num;
				if (num2 > 0)
				{
					this.#b.#dGd(\u0018.~\u0001\u0002(#f, num, num2));
				}
				num = \u008D\u0002.~\u008E\u0005(match) + \u008D\u0002.~\u008F\u0005(match);
				this.#b.#cGd();
				this.#kHd();
				if (match == list.Last<Match>())
				{
					string text = \u0014.~\u0098(#f, \u008D\u0002.~\u008E\u0005(match) + \u008D\u0002.~\u008F\u0005(match));
					if (!\u0003.\u0004(text))
					{
						this.#b.#dGd(text);
						if (flag)
						{
							this.#b.#cGd();
						}
					}
				}
			}
			if (list.Count <= 0)
			{
				this.#b.#dGd(#f);
			}
		}

		// Token: 0x06007DB1 RID: 32177 RVA: 0x00066356 File Offset: 0x00064556
		public void #cGd()
		{
			this.#b.#cGd();
			this.#kHd();
		}

		// Token: 0x06007DB2 RID: 32178 RVA: 0x00066375 File Offset: 0x00064575
		public void #cGd(string #f, bool #dHd = false)
		{
			if (#f == null)
			{
				return;
			}
			this.#dGd(\u0019.\u0002\u0002(\u008E\u0003.~\u0002\u0008(#f, new char[0]), \u008E.\u0099\u0002()), #dHd);
		}

		// Token: 0x06007DB3 RID: 32179 RVA: 0x001BA500 File Offset: 0x001B8700
		protected virtual void #eHd(int #fHd)
		{
			this.#cGd();
			this.#cGd();
			foreach (#QGd #QGd in this.NewPageStartContents)
			{
				foreach (string text in #QGd.Lines)
				{
					this.#cGd(text, false);
				}
			}
		}

		// Token: 0x06007DB4 RID: 32180 RVA: 0x000663B3 File Offset: 0x000645B3
		private void #gHd(int #fHd)
		{
			if (!this.WriteXmlTestTags)
			{
				this.#eHd(#fHd);
			}
		}

		// Token: 0x06007DB5 RID: 32181 RVA: 0x001BA5B4 File Offset: 0x001B87B4
		private string #hHd(string #iHd, int #jHd)
		{
			if (\u008D\u0002.~\u008C\u0005(#iHd) <= #jHd || !this.AutoSplitLongLines || this.WriteXmlTestTags)
			{
				return #iHd;
			}
			string[] array = \u0006\u0005.\u0099\u000E(#iHd, \u008E.\u0099\u0002());
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = \u0080.~\u0081\u0002(#iHd, \u008E.\u0099\u0002());
			foreach (string text in array)
			{
				if (\u008D\u0002.~\u008C\u0005(text) <= #jHd)
				{
					\u0097\u0003.~\u0012\u0008(stringBuilder, text);
				}
				else
				{
					\u0097\u0003.~\u0012\u0008(stringBuilder, \u0010.\u0093(text, \u0010.\u0092(#Phc.#3hc(107281464), #jHd.ToString(), #Phc.#3hc(107281423)), \u0019.\u0002\u0002(#Phc.#3hc(107281438), \u008E.\u0099\u0002())));
				}
			}
			return \u008E\u0003.~\u0002\u0008(\u007F.~\u0011\u0002(stringBuilder), new char[0]) + (flag ? \u008E.\u0099\u0002() : string.Empty);
		}

		// Token: 0x06007DB6 RID: 32182 RVA: 0x001BA6F8 File Offset: 0x001B88F8
		private void #gHd()
		{
			if (this.WriteXmlTestTags)
			{
				return;
			}
			if (this.#b.Length > 0L && this.#b.#eGd() != '\n')
			{
				this.#b.#dGd(\u008E.\u0099\u0002());
			}
			this.#b.#dGd('\f');
			int num = this.NumberOfPages;
			this.NumberOfPages = num + 1;
			this.#f = 0;
			num = this.#e + 1;
			this.#e = num;
			this.#eHd(num);
		}

		// Token: 0x06007DB7 RID: 32183 RVA: 0x000663D0 File Offset: 0x000645D0
		private void #kHd()
		{
			this.#f = (this.#f + 1) % this.PageSize;
			if (this.#f == 0)
			{
				this.#gHd();
			}
		}

		// Token: 0x0400336E RID: 13166
		private const char #a = '\f';

		// Token: 0x0400336F RID: 13167
		private readonly #gGd #b;

		// Token: 0x04003370 RID: 13168
		private readonly Regex #c = new Regex(#Phc.#3hc(107281469), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		// Token: 0x04003371 RID: 13169
		private bool #d;

		// Token: 0x04003372 RID: 13170
		private int #e = 1;

		// Token: 0x04003373 RID: 13171
		private int #f;

		// Token: 0x04003374 RID: 13172
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04003375 RID: 13173
		[CompilerGenerated]
		private int #h;

		// Token: 0x04003376 RID: 13174
		[CompilerGenerated]
		private readonly List<#QGd> #i;

		// Token: 0x04003377 RID: 13175
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04003378 RID: 13176
		[CompilerGenerated]
		private int #k;

		// Token: 0x04003379 RID: 13177
		[CompilerGenerated]
		private bool #l;

		// Token: 0x0400337A RID: 13178
		[CompilerGenerated]
		private int #m;
	}
}

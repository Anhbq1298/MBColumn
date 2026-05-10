using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #3Rd;
using #5Fd;
using #7hc;
using #FCd;
using #Qcd;
using #wdd;
using Aspose.Words;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text
{
	// Token: 0x02000D8C RID: 3468
	public class TextContentRenderer : #ldd
	{
		// Token: 0x06007D7E RID: 32126 RVA: 0x00066090 File Offset: 0x00064290
		public TextContentRenderer(#ZGd context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.#b = context;
			this.#a = new #RHd(context);
		}

		// Token: 0x06007D7F RID: 32127 RVA: 0x000660CA File Offset: 0x000642CA
		public void #Rcd(#uDd #Xpb)
		{
			#Xpb.#npb(this.#a);
		}

		// Token: 0x06007D80 RID: 32128 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #Scd(string #Tcd, string #Ukc = " ")
		{
		}

		// Token: 0x06007D81 RID: 32129 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #Ucd(#sTd #Vcd, bool #Wcd = true, double #Xcd = 0.87, string #Ycd = null, string #MQc = null, string #Tcd = null, string #Zcd = null, string #0cd = null, double? #1cd = null)
		{
		}

		// Token: 0x06007D82 RID: 32130 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #2cd()
		{
		}

		// Token: 0x06007D83 RID: 32131 RVA: 0x00008FC0 File Offset: 0x000071C0
		public StructurePoint.CoreAssets.Infrastructure.Data.Size #idd(double #jdd, bool #kdd = false)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06007D84 RID: 32132 RVA: 0x001B9FF0 File Offset: 0x001B81F0
		public void #3cd(string #Ukc, StyleIdentifier #4cd = StyleIdentifier.BodyText, ParagraphAlignment? #rT = null, string #Tcd = null, string #5cd = null)
		{
			#Ukc = this.#VGd(#Ukc, #4cd);
			this.#TGd(#4cd, #Ukc, #Tcd);
			int length = #Ukc.Length;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(#Ukc);
			if (#4cd == StyleIdentifier.Heading1)
			{
				stringBuilder.AppendLine(string.Empty.PadLeft(length, '='));
			}
			this.#b.Paginator.#cGd(stringBuilder.ToString(), true);
		}

		// Token: 0x06007D85 RID: 32133 RVA: 0x000660E4 File Offset: 0x000642E4
		public void #npb(string #Ukc, StyleIdentifier #4cd = StyleIdentifier.BodyText, ParagraphAlignment? #rT = null)
		{
			#Ukc = this.#VGd(#Ukc, #4cd);
			this.#b.Paginator.#dGd(#Ukc, false);
		}

		// Token: 0x06007D86 RID: 32134 RVA: 0x001BA064 File Offset: 0x001B8264
		public void #6cd(string #7cd, StyleIdentifier? #4cd = null)
		{
			#7cd = this.#b.Deformatter.#NBd(#7cd);
			this.#npb(#7cd, StyleIdentifier.BodyText, null);
		}

		// Token: 0x06007D87 RID: 32135 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #8cd(object #LH)
		{
		}

		// Token: 0x06007D88 RID: 32136 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #9cd(bool #add)
		{
		}

		// Token: 0x06007D89 RID: 32137 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #bdd()
		{
		}

		// Token: 0x06007D8A RID: 32138 RVA: 0x001BA0A4 File Offset: 0x001B82A4
		public void #cdd(int #AWc = 1)
		{
			for (int i = 0; i < #AWc; i++)
			{
				this.#3cd(string.Empty, StyleIdentifier.BodyText, null, null, null);
			}
		}

		// Token: 0x06007D8B RID: 32139 RVA: 0x001BA0E4 File Offset: 0x001B82E4
		public void #ddd(Color #edd)
		{
			this.#3cd(#Phc.#3hc(107281543), StyleIdentifier.BodyText, null, null, null);
		}

		// Token: 0x06007D8C RID: 32140 RVA: 0x0006610E File Offset: 0x0006430E
		public void #fdd()
		{
			this.#b.Paginator.#fdd();
		}

		// Token: 0x06007D8D RID: 32141 RVA: 0x0006612C File Offset: 0x0006432C
		public void #gdd()
		{
			this.#cdd(1);
		}

		// Token: 0x06007D8E RID: 32142 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool #hdd()
		{
			return false;
		}

		// Token: 0x06007D8F RID: 32143 RVA: 0x001BA11C File Offset: 0x001B831C
		protected string #RGd(string #SGd)
		{
			TextContentRenderer.#uZb #uZb = new TextContentRenderer.#uZb();
			#uZb.#a = this;
			string[] source = \u009C\u0004.~\u008E\u000E(#SGd, new string[]
			{
				\u008E.\u0099\u0002()
			}, StringSplitOptions.None);
			if (source.Any(new Func<string, bool>(#uZb.#5Ud)))
			{
				return #SGd;
			}
			int num = source.Max(new Func<string, int>(TextContentRenderer.<>c.<>9.#7Ud));
			int num2 = (this.#b.Paginator.LineWidth - num) / 2;
			if (num2 <= 0)
			{
				return #SGd;
			}
			#uZb.#b = \u000F.~\u0090(string.Empty, num2, ' ');
			return \u0003\u0005.\u0096\u000E(\u008E.\u0099\u0002(), source.Select(new Func<string, string>(#uZb.#6Ud)));
		}

		// Token: 0x06007D90 RID: 32144 RVA: 0x001BA20C File Offset: 0x001B840C
		private void #TGd(StyleIdentifier #KFd, string #Ukc, string #UGd)
		{
			if (#2dd.#1dd(#KFd) && !\u0003.\u0004(#UGd) && !\u0003.\u0004(#Ukc))
			{
				this.#b.DocumentMap.#vzc(#UGd, #Ukc, #KFd, null);
			}
		}

		// Token: 0x06007D91 RID: 32145 RVA: 0x0006613D File Offset: 0x0006433D
		private string #VGd(string #Ukc, StyleIdentifier #t6c)
		{
			if (#2dd.#1dd(#t6c))
			{
				return this.#c.#KGd(#t6c, #Ukc).Number + (#Ukc ?? string.Empty);
			}
			return #Ukc;
		}

		// Token: 0x04003362 RID: 13154
		private readonly #6Dd #a;

		// Token: 0x04003363 RID: 13155
		private readonly #ZGd #b;

		// Token: 0x04003364 RID: 13156
		private readonly SectionHeaderHandler #c = new SectionHeaderHandler();

		// Token: 0x02000D8E RID: 3470
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x06007D96 RID: 32150 RVA: 0x0006619B File Offset: 0x0006439B
			internal bool #5Ud(string #Ztc)
			{
				return \u008D\u0002.~\u008C\u0005(#Ztc) - 2 >= this.#a.#b.Paginator.LineWidth;
			}

			// Token: 0x06007D97 RID: 32151 RVA: 0x000661D0 File Offset: 0x000643D0
			internal string #6Ud(string #Rf)
			{
				return \u0019.\u0002\u0002(this.#b, #Rf);
			}

			// Token: 0x04003367 RID: 13159
			public TextContentRenderer #a;

			// Token: 0x04003368 RID: 13160
			public string #b;
		}
	}
}

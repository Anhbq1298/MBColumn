using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using #3Rd;
using #5Fd;
using #7hc;
using #FCd;
using #Qcd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #VEd
{
	// Token: 0x02000D66 RID: 3430
	internal class #UEd : #ldd
	{
		// Token: 0x06007C91 RID: 31889 RVA: 0x00065413 File Offset: 0x00063613
		public #UEd(#4Ed #ib)
		{
			this.ContextCore = #ib;
			this.#d = new #qFd(#ib);
			this.Fields = new List<Field>();
			this.SvgInsertHelper = new SvgInsertHelper(#ib.Builder, this);
		}

		// Token: 0x17002571 RID: 9585
		// (get) Token: 0x06007C92 RID: 31890 RVA: 0x0006544B File Offset: 0x0006364B
		// (set) Token: 0x06007C93 RID: 31891 RVA: 0x00065457 File Offset: 0x00063657
		public List<Field> Fields { get; private set; }

		// Token: 0x17002572 RID: 9586
		// (get) Token: 0x06007C94 RID: 31892 RVA: 0x00065468 File Offset: 0x00063668
		public DocumentBuilder Builder
		{
			get
			{
				return this.ContextCore.Builder;
			}
		}

		// Token: 0x17002573 RID: 9587
		// (get) Token: 0x06007C95 RID: 31893 RVA: 0x00065481 File Offset: 0x00063681
		// (set) Token: 0x06007C96 RID: 31894 RVA: 0x0006548D File Offset: 0x0006368D
		private protected SvgInsertHelper SvgInsertHelper { protected get; private set; }

		// Token: 0x06007C97 RID: 31895 RVA: 0x0006549E File Offset: 0x0006369E
		public StructurePoint.CoreAssets.Infrastructure.Data.Size #idd(double #jdd, bool #kdd = false)
		{
			return this.SvgInsertHelper.#idd(#jdd, #kdd);
		}

		// Token: 0x06007C98 RID: 31896 RVA: 0x001B62E0 File Offset: 0x001B44E0
		public virtual void #2cd()
		{
			foreach (Field field in this.Fields)
			{
				\u0007.~\u0017(field);
			}
		}

		// Token: 0x06007C99 RID: 31897 RVA: 0x000654B9 File Offset: 0x000636B9
		public void #Rcd(#uDd #Xpb)
		{
			#Xpb.#npb(this.#d);
		}

		// Token: 0x06007C9A RID: 31898 RVA: 0x001B6344 File Offset: 0x001B4544
		public void #Scd(string #Tcd, string #Ukc = " ")
		{
			if (!\u0003.\u0004(#Tcd))
			{
				\u009C\u0003.~\u0018\u0008(this.Builder, #Tcd);
				\u0007\u0003.~\u0007\u0007(this.Builder, #Ukc);
				\u009D\u0003.~\u0019\u0008(this.Builder, #Tcd);
			}
		}

		// Token: 0x06007C9B RID: 31899 RVA: 0x001B63A0 File Offset: 0x001B45A0
		public void #Ucd(#sTd #Vcd, bool #Wcd = true, double #Xcd = 0.87, string #Ycd = null, string #MQc = null, string #Tcd = null, string #Zcd = null, string #0cd = null, double? #1cd = null)
		{
			this.SvgInsertHelper.#Ucd(#Vcd, #Wcd, #Xcd, #Ycd, #MQc, #Tcd, #Zcd, #0cd, #1cd);
		}

		// Token: 0x06007C9C RID: 31900 RVA: 0x001B63D4 File Offset: 0x001B45D4
		public void #3cd(string #Ukc, StyleIdentifier #4cd = StyleIdentifier.BodyText, ParagraphAlignment? #rT = null, string #Tcd = null, string #5cd = null)
		{
			bool flag = #2dd.#1dd(#4cd);
			if (flag)
			{
				this.#QEd(#Ukc, #4cd, #Tcd);
				this.#REd();
			}
			if (#4cd != StyleIdentifier.User)
			{
				this.Builder.ParagraphFormat.StyleIdentifier = #4cd;
			}
			if (!string.IsNullOrWhiteSpace(#5cd))
			{
				this.Builder.ParagraphFormat.StyleName = #5cd;
			}
			if (#rT != null)
			{
				this.Builder.ParagraphFormat.Alignment = #rT.Value;
			}
			if (flag)
			{
				this.Builder.Write((#Ukc ?? string.Empty).Trim());
				this.#Scd(#Tcd, #Phc.#3hc(107399922));
				this.Builder.Writeln();
			}
			else
			{
				this.Builder.Writeln((#Ukc ?? string.Empty).Trim());
			}
			this.Builder.ParagraphFormat.ClearFormatting();
			if (flag)
			{
				this.#REd();
			}
		}

		// Token: 0x06007C9D RID: 31901 RVA: 0x001B64DC File Offset: 0x001B46DC
		public void #npb(string #Ukc, StyleIdentifier #4cd = StyleIdentifier.BodyText, ParagraphAlignment? #rT = 0)
		{
			if (#2dd.#1dd(#4cd))
			{
				this.#REd();
			}
			this.Builder.ParagraphFormat.StyleIdentifier = #4cd;
			if (#rT != null)
			{
				this.Builder.ParagraphFormat.Alignment = #rT.Value;
			}
			this.Builder.Write((#Ukc ?? string.Empty).Trim());
			this.Builder.ParagraphFormat.ClearFormatting();
			if (#2dd.#1dd(#4cd))
			{
				this.#REd();
			}
		}

		// Token: 0x06007C9E RID: 31902 RVA: 0x001B657C File Offset: 0x001B477C
		public void #6cd(string #7cd, StyleIdentifier? #4cd = null)
		{
			if (#4cd != null)
			{
				this.Builder.ParagraphFormat.StyleIdentifier = #4cd.Value;
				this.Builder.Font.Size = this.ContextCore.PrintOptions.FontInfo.ContentFontSize;
			}
			if (#2dd.#Ydd(#7cd))
			{
				this.Builder.InsertHtml(#7cd, true);
			}
			else
			{
				this.Builder.Write(#7cd);
			}
			if (#4cd != null)
			{
				this.Builder.ParagraphFormat.ClearFormatting();
			}
		}

		// Token: 0x06007C9F RID: 31903 RVA: 0x001B6628 File Offset: 0x001B4828
		public void #8cd(object #LH)
		{
			Field field = #LH as Field;
			if (field != null)
			{
				this.Fields.Add(field);
			}
		}

		// Token: 0x06007CA0 RID: 31904 RVA: 0x001B6658 File Offset: 0x001B4858
		public void #9cd(bool #add)
		{
			this.#OEd();
			this.#3cd(string.Empty, StyleIdentifier.BodyText, null, null, null);
			this.#PEd();
			if (#add)
			{
				this.#fdd();
			}
		}

		// Token: 0x06007CA1 RID: 31905 RVA: 0x001B66A0 File Offset: 0x001B48A0
		public void #fdd()
		{
			if (!this.ContextCore.IncludeCover && !this.ContextCore.IncludeTableOfContents && this.#e == 0)
			{
				this.#e++;
				return;
			}
			\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.PageBreak);
			this.#e++;
		}

		// Token: 0x06007CA2 RID: 31906 RVA: 0x000654D3 File Offset: 0x000636D3
		public void #gdd()
		{
			\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.ParagraphBreak);
		}

		// Token: 0x06007CA3 RID: 31907 RVA: 0x00003375 File Offset: 0x00001575
		public bool #hdd()
		{
			return true;
		}

		// Token: 0x06007CA4 RID: 31908 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #bdd()
		{
		}

		// Token: 0x06007CA5 RID: 31909 RVA: 0x001B670C File Offset: 0x001B490C
		public void #cdd(int #AWc = 1)
		{
			if (#AWc > 0)
			{
				for (int i = 0; i < #AWc; i++)
				{
					\u0007.~\u0018(this.Builder);
				}
			}
		}

		// Token: 0x06007CA6 RID: 31910 RVA: 0x001B6748 File Offset: 0x001B4948
		public void #ddd(Color #edd)
		{
			double num = \u001B\u0002.~\u0099\u0004(\u009F\u0003.~\u001B\u0008(this.Builder)) - \u001B\u0002.~\u009A\u0004(\u009F\u0003.~\u001B\u0008(this.Builder)) - \u001B\u0002.~\u009B\u0004(\u009F\u0003.~\u001B\u0008(this.Builder));
			if (num <= 0.0)
			{
				return;
			}
			Shape shape = new Shape(\u0001\u0004.~\u001C\u0008(this.Builder), ShapeType.Line)
			{
				Width = num,
				StrokeColor = #edd
			};
			\u009F\u0002.~\u001C\u0006(\u0003\u0004.~\u0081\u0008(shape), 1.0);
			\u0004\u0004.~\u0082\u0008(this.Builder, shape);
		}

		// Token: 0x06007CA7 RID: 31911 RVA: 0x001B6828 File Offset: 0x001B4A28
		protected virtual void #OEd()
		{
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0083\u0008(this.Builder), this.ContextCore.PrintOptions.FontInfo.TableOfContentsHeaderFontSize);
			\u0095.~\u001F\u0003(\u0005\u0004.~\u0083\u0008(this.Builder), true);
			\u0002\u0004.~\u001E\u0008(\u0005\u0004.~\u0083\u0008(this.Builder), \u0083\u0003.\u0092\u0007());
			this.#Scd(this.ContextCore.TableOfContentsBookmarkName, #Phc.#3hc(107399922));
			\u0007\u0003.~\u0008\u0007(this.Builder, #Phc.#3hc(107251621));
			\u0007.~\u0019(\u0005\u0004.~\u0083\u0008(this.Builder));
			this.#8cd(\u0006\u0004.~\u0087\u0008(this.Builder, #Phc.#3hc(107251640)));
			\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.ParagraphBreak);
		}

		// Token: 0x06007CA8 RID: 31912 RVA: 0x001B6944 File Offset: 0x001B4B44
		protected virtual void #PEd()
		{
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0083\u0008(this.Builder), this.ContextCore.PrintOptions.FontInfo.TableOfContentsHeaderFontSize);
			\u0095.~\u001F\u0003(\u0005\u0004.~\u0083\u0008(this.Builder), true);
			this.#Scd(#Phc.#3hc(107251611), #Phc.#3hc(107399922));
			\u0007\u0003.~\u0008\u0007(this.Builder, #Phc.#3hc(107251554));
			\u0007.~\u0019(\u0005\u0004.~\u0083\u0008(this.Builder));
			this.#8cd(\u0006\u0004.~\u0087\u0008(this.Builder, #Phc.#3hc(107251533)));
			\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.ParagraphBreak);
		}

		// Token: 0x06007CA9 RID: 31913 RVA: 0x001B6A38 File Offset: 0x001B4C38
		private void #QEd(string #Ukc, StyleIdentifier #4cd, string #Tcd)
		{
			#JGd #JGd = this.ContextCore.HeaderHandler.#KGd(#4cd, #Ukc);
			this.ContextCore.Map.#vzc(#Tcd, \u0019.\u0002\u0002(#JGd.Number, #JGd.Header), #4cd, null);
		}

		// Token: 0x06007CAA RID: 31914 RVA: 0x001B6A90 File Offset: 0x001B4C90
		private void #REd()
		{
			\u009F\u0002 ~_u001F_u = \u009F\u0002.~\u001F\u0006;
			object obj = \u0007\u0004.~\u0089\u0008(this.Builder);
			double num;
			\u009F\u0002.~\u001E\u0006(\u0007\u0004.~\u0089\u0008(this.Builder), num = 0.0);
			~_u001F_u(obj, num);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0083\u0008(this.Builder), 1.0);
			\u009F\u0002.~\u007F\u0006(\u0007\u0004.~\u0089\u0008(this.Builder), 0.0);
			\u0008\u0004.~\u008C\u0008(\u0007\u0004.~\u0089\u0008(this.Builder), LineSpacingRule.Exactly);
			\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.ParagraphBreak);
			\u0007.~\u001A(\u0007\u0004.~\u0089\u0008(this.Builder));
			\u0007.~\u0019(\u0005\u0004.~\u0083\u0008(this.Builder));
		}

		// Token: 0x17002574 RID: 9588
		// (get) Token: 0x06007CAB RID: 31915 RVA: 0x000654F2 File Offset: 0x000636F2
		// (set) Token: 0x06007CAC RID: 31916 RVA: 0x000654FE File Offset: 0x000636FE
		public #4Ed ContextCore { get; private set; }

		// Token: 0x0400330A RID: 13066
		[CompilerGenerated]
		private List<Field> #a;

		// Token: 0x0400330B RID: 13067
		[CompilerGenerated]
		private SvgInsertHelper #b;

		// Token: 0x0400330C RID: 13068
		[CompilerGenerated]
		private #4Ed #c;

		// Token: 0x0400330D RID: 13069
		private readonly #6Dd #d;

		// Token: 0x0400330E RID: 13070
		private int #e;
	}
}

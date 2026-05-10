using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #3Rd;
using #7hc;
using #hId;
using #VEd;
using #wdd;
using #yEd;
using Aspose.Words;
using Aspose.Words.Layout;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf
{
	// Token: 0x02000D72 RID: 3442
	public abstract class WordPdfReportGeneratorCore : #CEd, #CFd
	{
		// Token: 0x17002585 RID: 9605
		// (get) Token: 0x06007CE2 RID: 31970 RVA: 0x0006577C File Offset: 0x0006397C
		// (set) Token: 0x06007CE3 RID: 31971 RVA: 0x00065788 File Offset: 0x00063988
		private protected #jJd PrintOptions { protected get; private set; }

		// Token: 0x06007CE4 RID: 31972 RVA: 0x00065799 File Offset: 0x00063999
		protected WordPdfReportGeneratorCore()
		{
			#eFd.#9Ed();
			this.#a = new Lazy<LayoutCollector>(new Func<LayoutCollector>(this.#9Ub), LazyThreadSafetyMode.ExecutionAndPublication);
			this.#b = new Lazy<LayoutEnumerator>(new Func<LayoutEnumerator>(this.#TFd), LazyThreadSafetyMode.ExecutionAndPublication);
		}

		// Token: 0x17002586 RID: 9606
		// (get) Token: 0x06007CE5 RID: 31973 RVA: 0x000657D6 File Offset: 0x000639D6
		public Document Document
		{
			get
			{
				this.#IFd();
				return this.DocumentContext.Document;
			}
		}

		// Token: 0x17002587 RID: 9607
		// (get) Token: 0x06007CE6 RID: 31974 RVA: 0x000657F5 File Offset: 0x000639F5
		[Browsable(false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LayoutCollector LayoutCollector
		{
			get
			{
				this.#IFd();
				return this.#a.Value;
			}
		}

		// Token: 0x17002588 RID: 9608
		// (get) Token: 0x06007CE7 RID: 31975 RVA: 0x00065814 File Offset: 0x00063A14
		[Browsable(false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LayoutEnumerator LayoutEnumerator
		{
			get
			{
				this.#IFd();
				return this.#b.Value;
			}
		}

		// Token: 0x17002589 RID: 9609
		// (get) Token: 0x06007CE8 RID: 31976 RVA: 0x00065833 File Offset: 0x00063A33
		public DocumentBuilder Builder
		{
			get
			{
				this.#IFd();
				return this.DocumentContext.Builder;
			}
		}

		// Token: 0x1700258A RID: 9610
		// (get) Token: 0x06007CE9 RID: 31977 RVA: 0x00065852 File Offset: 0x00063A52
		// (set) Token: 0x06007CEA RID: 31978 RVA: 0x0006585E File Offset: 0x00063A5E
		public #4Ed DocumentContext { get; private set; }

		// Token: 0x1700258B RID: 9611
		// (get) Token: 0x06007CEB RID: 31979 RVA: 0x0006586F File Offset: 0x00063A6F
		// (set) Token: 0x06007CEC RID: 31980 RVA: 0x0006587B File Offset: 0x00063A7B
		private protected #AEd Definition { protected get; private set; }

		// Token: 0x06007CED RID: 31981 RVA: 0x0006588C File Offset: 0x00063A8C
		public void #bCd()
		{
			if (!this.#e)
			{
				this.#OFd();
				this.#Jed(this.Definition);
				this.#e = true;
			}
		}

		// Token: 0x06007CEE RID: 31982 RVA: 0x000658BB File Offset: 0x00063ABB
		public void #bCd(#3Fd #cA, Func<Stream> #En)
		{
			this.#bCd();
			this.#zl(#cA, #En);
		}

		// Token: 0x06007CEF RID: 31983 RVA: 0x000658D7 File Offset: 0x00063AD7
		public void #bCd(#3Fd #cA, Stream #En)
		{
			this.#bCd();
			this.#zl(#cA, #En);
		}

		// Token: 0x06007CF0 RID: 31984 RVA: 0x001B7E2C File Offset: 0x001B602C
		public static void #FFd(DocumentBuilder #tCd, #jJd #GFd)
		{
			PageSetup pageSetup = \u009F\u0003.~\u001B\u0008(#tCd);
			if (#GFd.AsposePaperSize != null)
			{
				\u0089\u0004.~\u001B\u000E(pageSetup, #GFd.AsposePaperSize.Value);
			}
			else if (#GFd.PaperSize != null)
			{
				System.Drawing.Printing.PaperSize paperSize = #GFd.PaperSize;
				\u0089\u0004.~\u001B\u000E(pageSetup, Aspose.Words.PaperSize.Custom);
				\u009F\u0002.~\u0086\u0006(pageSetup, (double)\u008D\u0002.~\u0092\u0005(paperSize) / 100.0 * 72.0);
				\u009F\u0002.~\u0087\u0006(pageSetup, (double)\u008D\u0002.~\u0093\u0005(paperSize) / 100.0 * 72.0);
			}
			pageSetup.Orientation = ((#GFd.Orientation == PaperOrientation.Landscape) ? Orientation.Landscape : Orientation.Portrait);
			if (#GFd.Margins != null)
			{
				\u009F\u0002.~\u0088\u0006(pageSetup, #GFd.Margins.Top);
				\u009F\u0002.~\u0089\u0006(pageSetup, #GFd.Margins.Right);
				\u009F\u0002.~\u008A\u0006(pageSetup, #GFd.Margins.Left);
				\u009F\u0002.~\u008B\u0006(pageSetup, #GFd.Margins.Bottom);
				\u009F\u0002.~\u008C\u0006(pageSetup, #GFd.Margins.Top);
			}
		}

		// Token: 0x06007CF1 RID: 31985 RVA: 0x000658F3 File Offset: 0x00063AF3
		public void #FFd(#jJd #GFd)
		{
			if (#GFd == null)
			{
				return;
			}
			this.PrintOptions = #GFd;
			this.DocumentContext.PrintOptions = #GFd;
			WordPdfReportGeneratorCore.#FFd(this.Builder, #GFd);
		}

		// Token: 0x06007CF2 RID: 31986 RVA: 0x001B7F8C File Offset: 0x001B618C
		protected override void #BEd()
		{
			foreach (Paragraph paragraph in \u0084\u0004.~\u0014\u000E(this.Document, NodeType.Paragraph, true).OfType<Paragraph>().Where(new Func<Paragraph, bool>(WordPdfReportGeneratorCore.<>c.<>9.#0Ud)).ToList<Paragraph>())
			{
				this.#PFd(paragraph);
				Node node = \u008B\u0004.~\u001D\u000E(paragraph);
				do
				{
					if (node != null && \u008C\u0004.~\u001E\u000E(node) == NodeType.Paragraph)
					{
						this.#PFd((Paragraph)node);
					}
					if (node == null || \u008C\u0004.~\u001E\u000E(node) == NodeType.Table)
					{
						break;
					}
					node = \u008B\u0004.~\u001D\u000E(node);
				}
				while (node != null);
			}
		}

		// Token: 0x06007CF3 RID: 31987 RVA: 0x001B8080 File Offset: 0x001B6280
		protected virtual void #zl(#3Fd #cA, Stream #En)
		{
			if (this.#RFd(#cA) == SaveFormat.Pdf)
			{
				PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
				\u0087\u0002.~\u007F\u0005(\u008D\u0004.~\u001F\u000E(pdfSaveOptions), 2);
				\u0087\u0002.~\u0080\u0005(\u008D\u0004.~\u001F\u000E(pdfSaveOptions), 5);
				\u0095.~\u0087\u0003(pdfSaveOptions, true);
				\u008E\u0004.~\u007F\u000E(this.Document, #En, pdfSaveOptions);
				return;
			}
			OoxmlSaveOptions ooxmlSaveOptions = new OoxmlSaveOptions(SaveFormat.Docx);
			\u0095.~\u0087\u0003(ooxmlSaveOptions, true);
			\u008E\u0004.~\u007F\u000E(this.Document, #En, ooxmlSaveOptions);
		}

		// Token: 0x06007CF4 RID: 31988 RVA: 0x001B8130 File Offset: 0x001B6330
		protected virtual void #zl(#3Fd #cA, Func<Stream> #En)
		{
			Stream stream = #En();
			Stream stream2;
			if (!false)
			{
				stream2 = stream;
			}
			try
			{
				this.#zl(#cA, stream2);
			}
			finally
			{
				if (stream2 != null)
				{
					((IDisposable)stream2).Dispose();
				}
			}
		}

		// Token: 0x06007CF5 RID: 31989 RVA: 0x001B8178 File Offset: 0x001B6378
		protected void #eb(#4Ed #HFd, #AEd #xS)
		{
			if (#HFd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107282304));
			}
			if (#xS == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253735));
			}
			this.DocumentContext = #HFd;
			this.Definition = #xS;
			this.#c = true;
		}

		// Token: 0x06007CF6 RID: 31990 RVA: 0x00065924 File Offset: 0x00063B24
		protected void #IFd()
		{
			if (!this.#c)
			{
				throw new InvalidOperationException(#Phc.#3hc(107282283));
			}
		}

		// Token: 0x06007CF7 RID: 31991 RVA: 0x001B81CC File Offset: 0x001B63CC
		private void #JFd(StyleIdentifier #KFd, List #7p, int #rQb, double #Cvb, bool #LFd = false, double #MFd = 12.0, double #NFd = 3.0)
		{
			\u0007\u0003 ~_u000E_u = \u0007\u0003.~\u000E\u0007;
			\u0005\u0004 ~_u0086_u = \u0005\u0004.~\u0086\u0008;
			Style style = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), #KFd);
			style.ParagraphFormat.LineSpacing = 12.0;
			style.ParagraphFormat.LineSpacingRule = LineSpacingRule.Exactly;
			style.ParagraphFormat.SpaceAfter = #NFd;
			style.ParagraphFormat.SpaceBefore = 0.0;
			style.ParagraphFormat.SpaceAfterAuto = false;
			style.ParagraphFormat.SpaceBeforeAuto = false;
			style.ParagraphFormat.LeftIndent = 0.0;
			style.ParagraphFormat.FirstLineIndent = 0.0;
			style.ListFormat.List = #7p;
			style.ListFormat.ListLevelNumber = #rQb;
			style.ListFormat.ListLevel.NumberPosition = 0.0;
			style.ListFormat.ListLevel.TextPosition = 0.0;
			style.ListFormat.ListLevel.TabPosition = 0.0;
			style.ListFormat.ListLevel.TrailingCharacter = ListTrailingCharacter.Space;
			style.Font.Size = #Cvb;
			style.Font.NoProofing = true;
			style.Font.Bold = true;
			style.Font.Italic = #LFd;
			~_u000E_u(~_u0086_u(style), #Phc.#3hc(107356910));
		}

		// Token: 0x06007CF8 RID: 31992 RVA: 0x001B8358 File Offset: 0x001B6558
		private void #OFd()
		{
			List #7p = \u0096\u0004.~\u0088\u000E(\u0095\u0004.~\u0087\u000E(this.Document), ListTemplate.OutlineLegal);
			#dTd #dTd = this.DocumentContext.PrintOptions.FontInfo;
			this.#JFd(StyleIdentifier.Heading1, #7p, 0, #dTd.Header1FontSize, false, 0.0, 1.0);
			this.#JFd(StyleIdentifier.Heading2, #7p, 1, #dTd.Header2FontSize, true, 0.0, 2.0);
			this.#JFd(StyleIdentifier.Heading3, #7p, 2, #dTd.Header3FontSize, false, 12.0, 3.0);
			this.#JFd(StyleIdentifier.Heading4, #7p, 3, #dTd.Header3FontSize, false, 12.0, 3.0);
			this.#JFd(StyleIdentifier.Heading5, #7p, 4, #dTd.Header5FontSize, false, 12.0, 3.0);
			\u009F\u0002 ~_u001E_u = \u009F\u0002.~\u001E\u0006;
			\u0007\u0004 ~_u008B_u = \u0007\u0004.~\u008B\u0008;
			Style style = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.BodyText);
			style.Font.NoProofing = true;
			style.Font.Size = #dTd.ContentFontSize;
			style.Font.Name = #2dd.#g;
			~_u001E_u(~_u008B_u(style), 0.0);
			for (int i = 19; i <= 27; i++)
			{
				StyleIdentifier styleIdentifier = (StyleIdentifier)i;
				\u0007\u0003 ~_u000E_u = \u0007\u0003.~\u000E\u0007;
				\u0005\u0004 ~_u0086_u = \u0005\u0004.~\u0086\u0008;
				Style style2 = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), styleIdentifier);
				style2.Font.Bold = false;
				style2.Font.Bold = false;
				style2.Font.Size = #dTd.TableOfContentsContentFontSize;
				~_u000E_u(~_u0086_u(style2), #2dd.#g);
			}
			Style style3 = \u0097\u0004.~\u0089\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleType.Paragraph, #Phc.#3hc(107282258));
			\u0095.~\u001F\u0003(\u0005\u0004.~\u0086\u0008(style3), true);
			\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u008B\u0008(style3), ParagraphAlignment.Left);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0086\u0008(style3), #dTd.ContentFontSize);
			\u0007\u0003.~\u000E\u0007(\u0005\u0004.~\u0086\u0008(style3), #2dd.#g);
			style3 = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Normal);
			\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u008B\u0008(style3), ParagraphAlignment.Left);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0086\u0008(style3), #dTd.TableOfContentsContentFontSize);
			\u0007\u0003.~\u000E\u0007(\u0005\u0004.~\u0086\u0008(style3), #2dd.#g);
			style3 = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.NoSpacing);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0086\u0008(style3), #dTd.ContentFontSize);
			\u009F\u0002.~\u007F\u0006(\u0007\u0004.~\u008B\u0008(style3), 18.0);
			style3 = \u0098\u0004.~\u008A\u000E(\u008F\u0004.~\u0080\u000E(this.Document), style3);
			\u0007\u0003.~\u000F\u0007(style3, #2dd.NoSpacingSmallStyleKey);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0086\u0008(style3), #dTd.ContentFontSize / 2.0);
			\u009F\u0002.~\u007F\u0006(\u0007\u0004.~\u008B\u0008(style3), 6.0);
			\u0008\u0004.~\u008C\u0008(\u0007\u0004.~\u008B\u0008(style3), LineSpacingRule.Exactly);
			style3 = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.BodyText2);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0086\u0008(style3), 4.0);
			\u0007\u0003.~\u000E\u0007(\u0005\u0004.~\u0086\u0008(style3), #2dd.#g);
			\u009F\u0002.~\u001E\u0006(\u0007\u0004.~\u008B\u0008(style3), 0.0);
			\u0095.~\u0088\u0003(\u0007\u0004.~\u008B\u0008(style3), false);
			\u0008\u0004.~\u008C\u0008(\u0007\u0004.~\u008B\u0008(style3), LineSpacingRule.Exactly);
		}

		// Token: 0x06007CF9 RID: 31993 RVA: 0x001B879C File Offset: 0x001B699C
		private void #PFd(Paragraph #QFd)
		{
			\u0095.~\u008B\u0003(\u0007\u0004.~\u008A\u0008(#QFd), false);
			\u0095.~\u0084\u0003(\u0007\u0004.~\u008A\u0008(#QFd), true);
			\u0095.~\u008C\u0003(\u0007\u0004.~\u008A\u0008(#QFd), true);
		}

		// Token: 0x06007CFA RID: 31994 RVA: 0x0006594A File Offset: 0x00063B4A
		private SaveFormat #RFd(#3Fd #SFd)
		{
			if (#SFd == #3Fd.#a)
			{
				return SaveFormat.Docx;
			}
			if (#SFd != #3Fd.#b)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107282213), #SFd, null);
			}
			return SaveFormat.Pdf;
		}

		// Token: 0x06007CFB RID: 31995 RVA: 0x0006597D File Offset: 0x00063B7D
		[CompilerGenerated]
		private LayoutCollector #9Ub()
		{
			return new LayoutCollector(this.Document);
		}

		// Token: 0x06007CFC RID: 31996 RVA: 0x00065996 File Offset: 0x00063B96
		[CompilerGenerated]
		private LayoutEnumerator #TFd()
		{
			return new LayoutEnumerator(this.Document);
		}

		// Token: 0x04003328 RID: 13096
		private readonly Lazy<LayoutCollector> #a;

		// Token: 0x04003329 RID: 13097
		private readonly Lazy<LayoutEnumerator> #b;

		// Token: 0x0400332A RID: 13098
		private bool #c;

		// Token: 0x0400332B RID: 13099
		[CompilerGenerated]
		private #jJd #d;

		// Token: 0x0400332C RID: 13100
		private bool #e;

		// Token: 0x0400332D RID: 13101
		[CompilerGenerated]
		private #4Ed #f;

		// Token: 0x0400332E RID: 13102
		[CompilerGenerated]
		private #AEd #g;
	}
}

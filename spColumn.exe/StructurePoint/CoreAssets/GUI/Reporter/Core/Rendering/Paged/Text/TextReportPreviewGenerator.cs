using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #3Rd;
using #5Fd;
using #7hc;
using #hId;
using #VEd;
using Aspose.Words;
using Aspose.Words.Layout;
using Aspose.Words.Saving;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text
{
	// Token: 0x02000D92 RID: 3474
	public sealed class TextReportPreviewGenerator : #CFd
	{
		// Token: 0x06007DCD RID: 32205 RVA: 0x001BAB14 File Offset: 0x001B8D14
		public TextReportPreviewGenerator()
		{
			this.#e = new DocumentBuilder(this.Document);
			this.Builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.BodyText;
			this.#a = new Lazy<LayoutCollector>(new Func<LayoutCollector>(this.#DXb), LazyThreadSafetyMode.ExecutionAndPublication);
			this.#b = new Lazy<LayoutEnumerator>(new Func<LayoutEnumerator>(this.#BHd), LazyThreadSafetyMode.ExecutionAndPublication);
		}

		// Token: 0x170025B8 RID: 9656
		// (get) Token: 0x06007DCE RID: 32206 RVA: 0x00066568 File Offset: 0x00064768
		public Document Document { get; }

		// Token: 0x170025B9 RID: 9657
		// (get) Token: 0x06007DCF RID: 32207 RVA: 0x00066574 File Offset: 0x00064774
		[Browsable(false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LayoutCollector LayoutCollector
		{
			get
			{
				return this.#a.Value;
			}
		}

		// Token: 0x170025BA RID: 9658
		// (get) Token: 0x06007DD0 RID: 32208 RVA: 0x00066589 File Offset: 0x00064789
		[Browsable(false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LayoutEnumerator LayoutEnumerator
		{
			get
			{
				return this.#b.Value;
			}
		}

		// Token: 0x170025BB RID: 9659
		// (get) Token: 0x06007DD1 RID: 32209 RVA: 0x0006659E File Offset: 0x0006479E
		public DocumentBuilder Builder { get; }

		// Token: 0x06007DD2 RID: 32210 RVA: 0x000665AA File Offset: 0x000647AA
		public Stream #fp(string #Ukc, #qSd #tHd)
		{
			return this.#fp(new MemoryTextReportPagesSplitter(#Ukc), #tHd, new MemoryStream());
		}

		// Token: 0x06007DD3 RID: 32211 RVA: 0x001BAB88 File Offset: 0x001B8D88
		public Stream #fp(#bGd #uHd, #qSd #tHd, Stream #En)
		{
			if (#tHd == null || #uHd == null)
			{
				return null;
			}
			this.#yHd(#uHd, #tHd);
			this.#AHd();
			\u008E\u0004.~\u007F\u000E(this.Document, #En, new PdfSaveOptions
			{
				OutlineOptions = 
				{
					HeadingsOutlineLevels = 5
				}
			});
			return #En;
		}

		// Token: 0x06007DD4 RID: 32212 RVA: 0x001BABDC File Offset: 0x001B8DDC
		public void #FFd(#jJd #GFd)
		{
			if (#GFd == null)
			{
				return;
			}
			this.#c = #GFd;
			PageSetup pageSetup = \u009F\u0003.~\u001B\u0008(this.Builder);
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

		// Token: 0x06007DD5 RID: 32213 RVA: 0x001BAD4C File Offset: 0x001B8F4C
		private List<TextReportPreviewGenerator.SearchHit> #vHd(string #Ukc, #qSd #tHd)
		{
			TextReportPreviewGenerator.#DUb #DUb = new TextReportPreviewGenerator.#DUb();
			#DUb.#a = #Ukc;
			return #tHd.Map.Select(new Func<#zSd, TextReportPreviewGenerator.SearchHit>(#DUb.#8Ud)).Where(new Func<TextReportPreviewGenerator.SearchHit, bool>(TextReportPreviewGenerator.<>c.<>9.#9Ud)).OrderBy(new Func<TextReportPreviewGenerator.SearchHit, int>(TextReportPreviewGenerator.<>c.<>9.#aVd)).ThenByDescending(new Func<TextReportPreviewGenerator.SearchHit, int>(TextReportPreviewGenerator.<>c.<>9.#bVd)).ToList<TextReportPreviewGenerator.SearchHit>();
		}

		// Token: 0x06007DD6 RID: 32214 RVA: 0x001BAE0C File Offset: 0x001B900C
		private void #wHd(string #xHd, #qSd #tHd)
		{
			if (\u0003.\u0005(#xHd))
			{
				return;
			}
			while (\u008D\u0002.~\u008C\u0005(#xHd) > 0)
			{
				TextReportPreviewGenerator.SearchHit searchHit = this.#vHd(#xHd, #tHd).FirstOrDefault<TextReportPreviewGenerator.SearchHit>();
				if (searchHit == null)
				{
					\u0099\u0004.~\u008B\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), StyleIdentifier.BodyText);
					\u0007\u0003.~\u0007\u0007(this.Builder, #xHd);
					return;
				}
				string text = \u0018.~\u0001\u0002(#xHd, 0, searchHit.Index);
				\u0007\u0003.~\u0007\u0007(this.Builder, text);
				#xHd = \u0014.~\u0098(#xHd, searchHit.Index);
				string text2 = \u0018.~\u0001\u0002(#xHd, 0, \u008D\u0002.~\u008C\u0005(searchHit.Item.Header));
				\u0099\u0004.~\u008B\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), searchHit.Item.Style);
				\u0007\u0003.~\u0007\u0007(this.Builder, text2);
				\u009C\u0003.~\u0018\u0008(this.Builder, searchHit.Item.Bookmark);
				\u0007\u0003.~\u0007\u0007(this.Builder, string.Empty.#O2d());
				\u009D\u0003.~\u0019\u0008(this.Builder, searchHit.Item.Bookmark);
				\u0007.~\u0018(this.Builder);
				\u0099\u0004.~\u008B\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), StyleIdentifier.BodyText);
				int num = \u008D\u0002.~\u008C\u0005(searchHit.Item.Header) + \u008D\u0002.~\u008C\u0005(\u008E.\u0099\u0002());
				if (num > \u008D\u0002.~\u008C\u0005(#xHd))
				{
					num = \u008D\u0002.~\u008C\u0005(#xHd);
				}
				#xHd = \u0014.~\u0098(#xHd, num);
			}
		}

		// Token: 0x06007DD7 RID: 32215 RVA: 0x001BB000 File Offset: 0x001B9200
		private void #yHd(#bGd #uHd, #qSd #tHd)
		{
			while (#uHd.#aGd())
			{
				TextReportPage textReportPage = #uHd.CurrentPage;
				if (!\u0003.\u0004(textReportPage.Content))
				{
					this.#wHd(textReportPage.Content, #tHd);
					if (#uHd.HasNextPage)
					{
						\u009E\u0003.~\u001A\u0008(this.Builder, BreakType.PageBreak);
					}
				}
			}
		}

		// Token: 0x06007DD8 RID: 32216 RVA: 0x001BB064 File Offset: 0x001B9264
		private void #zHd(Style #4cd)
		{
			Font font = \u0005\u0004.~\u0086\u0008(#4cd);
			#jJd #jJd = this.#c;
			font.Size = ((#jJd != null) ? #jJd.FontInfo.ContentFontSize : 8.0);
			\u0007\u0003.~\u000E\u0007(\u0005\u0004.~\u0086\u0008(#4cd), #Phc.#3hc(107421227));
			\u0002\u0004.~\u001E\u0008(\u0005\u0004.~\u0086\u0008(#4cd), \u0083\u0003.\u0092\u0007());
			\u0095.~\u001F\u0003(\u0005\u0004.~\u0086\u0008(#4cd), false);
			\u0095.~\u008A\u0003(\u0005\u0004.~\u0086\u0008(#4cd), false);
			\u009F\u0002.~\u001F\u0006(\u0007\u0004.~\u008B\u0008(#4cd), 0.0);
			\u009F\u0002.~\u001E\u0006(\u0007\u0004.~\u008B\u0008(#4cd), 0.0);
		}

		// Token: 0x06007DD9 RID: 32217 RVA: 0x001BB164 File Offset: 0x001B9364
		private void #AHd()
		{
			Style #4cd = \u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.BodyText);
			this.#zHd(#4cd);
			this.#zHd(\u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Heading1));
			this.#zHd(\u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Heading2));
			this.#zHd(\u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Heading3));
			this.#zHd(\u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Heading4));
			this.#zHd(\u0090\u0004.~\u0081\u000E(\u008F\u0004.~\u0080\u000E(this.Document), StyleIdentifier.Heading5));
		}

		// Token: 0x06007DDA RID: 32218 RVA: 0x000665CA File Offset: 0x000647CA
		[CompilerGenerated]
		private LayoutCollector #DXb()
		{
			return new LayoutCollector(this.Document);
		}

		// Token: 0x06007DDB RID: 32219 RVA: 0x000665E3 File Offset: 0x000647E3
		[CompilerGenerated]
		private LayoutEnumerator #BHd()
		{
			return new LayoutEnumerator(this.Document);
		}

		// Token: 0x04003380 RID: 13184
		private readonly Lazy<LayoutCollector> #a;

		// Token: 0x04003381 RID: 13185
		private readonly Lazy<LayoutEnumerator> #b;

		// Token: 0x04003382 RID: 13186
		private #jJd #c;

		// Token: 0x04003383 RID: 13187
		[CompilerGenerated]
		private readonly Document #d = new Document();

		// Token: 0x04003384 RID: 13188
		[CompilerGenerated]
		private readonly DocumentBuilder #e;

		// Token: 0x02000D93 RID: 3475
		private sealed class SearchHit
		{
			// Token: 0x06007DDC RID: 32220 RVA: 0x000665FC File Offset: 0x000647FC
			public SearchHit(#zSd item, int index)
			{
				this.#a = item;
				this.#b = index;
			}

			// Token: 0x170025BC RID: 9660
			// (get) Token: 0x06007DDD RID: 32221 RVA: 0x00066612 File Offset: 0x00064812
			public #zSd Item { get; }

			// Token: 0x170025BD RID: 9661
			// (get) Token: 0x06007DDE RID: 32222 RVA: 0x0006661E File Offset: 0x0006481E
			public int Index { get; }

			// Token: 0x04003385 RID: 13189
			[CompilerGenerated]
			private readonly #zSd #a;

			// Token: 0x04003386 RID: 13190
			[CompilerGenerated]
			private readonly int #b;
		}

		// Token: 0x02000D95 RID: 3477
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06007DE5 RID: 32229 RVA: 0x00066683 File Offset: 0x00064883
			internal TextReportPreviewGenerator.SearchHit #8Ud(#zSd #Rf)
			{
				return new TextReportPreviewGenerator.SearchHit(#Rf, \u0011.~\u0094(this.#a, #Rf.Header, StringComparison.OrdinalIgnoreCase));
			}

			// Token: 0x0400338B RID: 13195
			public string #a;
		}
	}
}

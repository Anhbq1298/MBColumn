using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #6Pd;
using #7hc;
using #UYd;
using #VEd;
using #VQd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Navigation;
using Telerik.Windows.Documents.Fixed.UI;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation
{
	// Token: 0x02000DFF RID: 3583
	public static class NavigationHelper
	{
		// Token: 0x06008119 RID: 33049 RVA: 0x001C1B44 File Offset: 0x001BFD44
		public static void #hQd(#0Qd #iQd, DocumentContentOptionsCore #mA, RadPdfViewer #iLd, #rQd #Lg)
		{
			NavigationHelper.#GTb #GTb = new NavigationHelper.#GTb();
			#GTb.#a = #iLd;
			if (#iQd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107278156));
			}
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			if (#GTb.#a == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107278163));
			}
			if (#Lg == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107417169));
			}
			#uzc #uzc = new #uzc(#Phc.#3hc(107278122));
			RadFixedDocument radFixedDocument = \u0017\u0006.~\u0018\u0010(#GTb.#a);
			RadFixedPage radFixedPage = (radFixedDocument != null) ? radFixedDocument.Pages.FirstOrDefault<RadFixedPage>() : null;
			double? num = (radFixedPage != null) ? new double?(radFixedPage.ActualHeight) : null;
			if (num == null || \u0015\u0002.\u0090\u0004(num.Value))
			{
				return;
			}
			#gQd #gQd = NavigationHelper.#lQd(#iQd, #mA, #Lg.Options, num.Value);
			if (#gQd == null)
			{
				return;
			}
			#uzc.#szc(#Phc.#3hc(107278129));
			NavigationHelper.#GTb #GTb2 = #GTb;
			RadFixedDocument radFixedDocument2 = \u0017\u0006.~\u0018\u0010(#GTb.#a);
			#GTb2.#b = ((radFixedDocument2 != null) ? radFixedDocument2.Pages.ElementAtOrDefault(#gQd.PageIndex) : null);
			if (#GTb.#b == null)
			{
				return;
			}
			if (\u0014\u0006.~\u0014\u0010(#GTb.#a) == ScaleMode.FitToPage)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#GTb.#zWd));
				return;
			}
			#GTb.#c = #gQd.VerticalOffset - 18.0;
			#GTb.#c = \u0011\u0002.\u008B\u0004(0.0, #GTb.#c);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#GTb.#BWd));
		}

		// Token: 0x0600811A RID: 33050 RVA: 0x000692A8 File Offset: 0x000674A8
		public static IEnumerable<ReportContentVisibilityOption> #jQd(this ReportContentVisibilityOption #kQd)
		{
			NavigationHelper.#HWd #HWd = new NavigationHelper.#HWd(-2);
			#HWd.#e = #kQd;
			return #HWd;
		}

		// Token: 0x0600811B RID: 33051 RVA: 0x001C1D04 File Offset: 0x001BFF04
		public static #gQd #lQd(#0Qd #TKd, DocumentContentOptionsCore #mA, ReportContentVisibilityOption #bA, double #mQd)
		{
			if (#bA.IsEnabled)
			{
				bool? flag = #bA.IsChecked;
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null))
				{
					#dQd #dQd = NavigationHelper.#oQd(#TKd, #mA, #bA);
					if (#dQd != null)
					{
						double #f = #dQd.Top.GetValueOrDefault();
						if (#dQd.Top != null && #dQd.PageSize != null)
						{
							#f = (#dQd.PageSize.Value - #dQd.Top.Value) / #dQd.PageSize.Value * #mQd;
						}
						return new #gQd
						{
							PageIndex = #dQd.PageIndex,
							VerticalOffset = #f
						};
					}
					return null;
				}
			}
			return null;
		}

		// Token: 0x0600811C RID: 33052 RVA: 0x001C1DE0 File Offset: 0x001BFFE0
		public static #gQd #lQd(#CFd #TKd, ReportContentVisibilityOption #bA, double #mQd)
		{
			bool flag = #bA.DocumentOption is ScreenshootOption;
			Node node = \u0003.\u0004(#bA.DocumentOption.BookmarkName) ? null : NavigationHelper.#pQd(#TKd, #bA.DocumentOption.BookmarkName);
			if (node == null)
			{
				#bA = #bA.#jQd().Skip(1).FirstOrDefault(new Func<ReportContentVisibilityOption, bool>(NavigationHelper.<>c.<>9.#IWd));
				if (#bA == null)
				{
					return null;
				}
				node = NavigationHelper.#pQd(#TKd, #bA.DocumentOption.BookmarkName);
			}
			if (node == null)
			{
				return null;
			}
			int num = \u0013\u0004.~\u0095\u0008(#TKd.LayoutCollector, node);
			if (num <= 0)
			{
				return null;
			}
			Node node2 = node;
			if (!flag)
			{
				node2 = (NavigationHelper.#qQd(#TKd.Document, node) ?? node);
			}
			object obj = \u0096\u0006.~\u0098\u0010(#TKd.LayoutCollector, node2);
			\u008A.~\u0092\u0002(#TKd.LayoutEnumerator, obj);
			double num2 = (double)(flag ? \u0097\u0006.~\u0099\u0010(#TKd.LayoutEnumerator).Top : (\u0097\u0006.~\u0099\u0010(#TKd.LayoutEnumerator).Top - \u0097\u0006.~\u0099\u0010(#TKd.LayoutEnumerator).Height));
			double num3 = \u001B\u0002.~\u009D\u0004(\u009F\u0003.~\u001B\u0008(#TKd.Builder));
			double #f = num2 / num3 * #mQd;
			return new #gQd
			{
				PageIndex = num - 1,
				VerticalOffset = #f
			};
		}

		// Token: 0x0600811D RID: 33053 RVA: 0x001C1F78 File Offset: 0x001C0178
		private static #dQd #nQd(#0Qd #TKd, DocumentContentOptionsCore #mA, ReportContentVisibilityOption #bA)
		{
			NavigationHelper.#xTb #xTb = new NavigationHelper.#xTb();
			#xTb.#a = #bA;
			#dQd #dQd = #TKd.Outlines.FirstOrDefault(new Func<#dQd, bool>(#xTb.#KWd));
			if (#dQd == null && #mA.#Dcd(#xTb.#a.DocumentOption))
			{
				#dQd = #TKd.Outlines.FirstOrDefault(new Func<#dQd, bool>(#xTb.#LWd));
			}
			return #dQd;
		}

		// Token: 0x0600811E RID: 33054 RVA: 0x001C1FE8 File Offset: 0x001C01E8
		private static #dQd #oQd(#0Qd #TKd, DocumentContentOptionsCore #mA, ReportContentVisibilityOption #bA)
		{
			#dQd #dQd = NavigationHelper.#nQd(#TKd, #mA, #bA);
			if (#dQd != null)
			{
				return #dQd;
			}
			#bA = #bA.#jQd().Skip(1).FirstOrDefault(new Func<ReportContentVisibilityOption, bool>(NavigationHelper.<>c.<>9.#JWd));
			if (#bA == null || !#bA.IsEnabled || !#bA.IsChecked.GetValueOrDefault())
			{
				return null;
			}
			return NavigationHelper.#nQd(#TKd, #mA, #bA);
		}

		// Token: 0x0600811F RID: 33055 RVA: 0x001C2070 File Offset: 0x001C0270
		private static BookmarkStart #pQd(#CFd #TKd, string #wy)
		{
			NavigationHelper.#ITb #ITb = new NavigationHelper.#ITb();
			#ITb.#a = #wy;
			if (\u0003.\u0004(#ITb.#a))
			{
				return null;
			}
			#ITb.#b = #ITb.#a.#Al(40);
			return \u0084\u0004.~\u0014\u000E(#TKd.Document, NodeType.BookmarkStart, true).OfType<BookmarkStart>().FirstOrDefault(new Func<BookmarkStart, bool>(#ITb.#MWd));
		}

		// Token: 0x06008120 RID: 33056 RVA: 0x001C20E8 File Offset: 0x001C02E8
		private static Node #qQd(Document #bFd, Node #uXb)
		{
			Node node = #uXb;
			while (node != null && (\u008C\u0004.~\u001E\u000E(node) != NodeType.Paragraph || (\u0098\u0006.~\u009A\u0010(\u0007\u0004.~\u008A\u0008((Paragraph)node)) != StyleIdentifier.Heading1 && \u0098\u0006.~\u009A\u0010(\u0007\u0004.~\u008A\u0008((Paragraph)node)) != StyleIdentifier.Heading2 && \u0098\u0006.~\u009A\u0010(\u0007\u0004.~\u008A\u0008((Paragraph)node)) != StyleIdentifier.Heading3)))
			{
				node = \u0099\u0006.~\u009B\u0010(node, #bFd);
			}
			return node;
		}

		// Token: 0x02000E01 RID: 3585
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008126 RID: 33062 RVA: 0x001C21FC File Offset: 0x001C03FC
			internal void #zWd()
			{
				Action #nd;
				if ((#nd = this.#d) == null)
				{
					#nd = (this.#d = new Action(this.#AWd));
				}
				Ignore.#14d<Exception>(#nd, null);
			}

			// Token: 0x06008127 RID: 33063 RVA: 0x000692C8 File Offset: 0x000674C8
			internal void #AWd()
			{
				\u0087\u0002.~\u0084\u0005(this.#a, \u008D\u0002.~\u0099\u0005(this.#b));
			}

			// Token: 0x06008128 RID: 33064 RVA: 0x001C223C File Offset: 0x001C043C
			internal void #BWd()
			{
				Action #nd;
				if ((#nd = this.#e) == null)
				{
					#nd = (this.#e = new Action(this.#CWd));
				}
				Ignore.#14d<Exception>(#nd, null);
			}

			// Token: 0x06008129 RID: 33065 RVA: 0x000692F6 File Offset: 0x000674F6
			internal void #CWd()
			{
				\u0016\u0007.~\u0018\u0011(this.#a, new Location
				{
					Page = this.#b,
					Top = new double?(this.#c)
				});
			}

			// Token: 0x040034F3 RID: 13555
			public RadPdfViewer #a;

			// Token: 0x040034F4 RID: 13556
			public RadFixedPage #b;

			// Token: 0x040034F5 RID: 13557
			public double #c;

			// Token: 0x040034F6 RID: 13558
			public Action #d;

			// Token: 0x040034F7 RID: 13559
			public Action #e;
		}

		// Token: 0x02000E02 RID: 3586
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x0600812B RID: 33067 RVA: 0x00069336 File Offset: 0x00067536
			internal bool #DWd(ReportContentVisibilityOption #EWd)
			{
				return !this.#a.Contains(#EWd);
			}

			// Token: 0x040034F8 RID: 13560
			public HashSet<ReportContentVisibilityOption> #a;

			// Token: 0x040034F9 RID: 13561
			public Func<ReportContentVisibilityOption, bool> #b;
		}

		// Token: 0x02000E03 RID: 3587
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x0600812D RID: 33069 RVA: 0x00069353 File Offset: 0x00067553
			internal bool #KWd(#dQd #Rf)
			{
				return \u0006.\u0008(#Rf.BookmarkName, this.#a.DocumentOption.BookmarkName, StringComparison.Ordinal);
			}

			// Token: 0x0600812E RID: 33070 RVA: 0x00069382 File Offset: 0x00067582
			internal bool #LWd(#dQd #Rf)
			{
				return \u0006.\u0008(#Rf.Title, this.#a.DocumentOption.BookmarkName, StringComparison.Ordinal);
			}

			// Token: 0x040034FA RID: 13562
			public ReportContentVisibilityOption #a;
		}

		// Token: 0x02000E04 RID: 3588
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x06008130 RID: 33072 RVA: 0x001C227C File Offset: 0x001C047C
			internal bool #MWd(BookmarkStart #Rf)
			{
				return \u0093.\u0016\u0003(\u007F.~\u001E\u0002(#Rf), this.#a) || \u0093.\u0016\u0003(\u007F.~\u001E\u0002(#Rf), this.#b);
			}

			// Token: 0x040034FB RID: 13563
			public string #a;

			// Token: 0x040034FC RID: 13564
			public string #b;
		}
	}
}

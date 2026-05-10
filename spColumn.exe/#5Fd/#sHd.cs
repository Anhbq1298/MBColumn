using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #hId;
using #Qcd;
using #VEd;
using #yEd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #5Fd
{
	// Token: 0x02000D91 RID: 3473
	internal abstract class #sHd : #CEd
	{
		// Token: 0x06007DB8 RID: 32184 RVA: 0x00066401 File Offset: 0x00064601
		protected #sHd(bool #IEd)
		{
			#eFd.#9Ed();
			this.#b = #IEd;
		}

		// Token: 0x06007DB9 RID: 32185 RVA: 0x00066415 File Offset: 0x00064615
		protected #sHd() : this(false)
		{
		}

		// Token: 0x170025B1 RID: 9649
		// (get) Token: 0x06007DBA RID: 32186 RVA: 0x0006641E File Offset: 0x0006461E
		protected static int DefaultNumberOfLines
		{
			get
			{
				return 80;
			}
		}

		// Token: 0x170025B2 RID: 9650
		// (get) Token: 0x06007DBB RID: 32187 RVA: 0x00066422 File Offset: 0x00064622
		public bool RenderXmlTestTags { get; }

		// Token: 0x170025B3 RID: 9651
		// (get) Token: 0x06007DBC RID: 32188 RVA: 0x0006642E File Offset: 0x0006462E
		public #qSd DocumentMap
		{
			get
			{
				return this.DocumentContext.DocumentMap;
			}
		}

		// Token: 0x170025B4 RID: 9652
		// (get) Token: 0x06007DBD RID: 32189 RVA: 0x00066447 File Offset: 0x00064647
		// (set) Token: 0x06007DBE RID: 32190 RVA: 0x00066453 File Offset: 0x00064653
		public string RawReportText { get; private set; }

		// Token: 0x170025B5 RID: 9653
		// (get) Token: 0x06007DBF RID: 32191 RVA: 0x00066464 File Offset: 0x00064664
		// (set) Token: 0x06007DC0 RID: 32192 RVA: 0x00066470 File Offset: 0x00064670
		private protected #AEd Definition { protected get; private set; }

		// Token: 0x170025B6 RID: 9654
		// (get) Token: 0x06007DC1 RID: 32193 RVA: 0x00066481 File Offset: 0x00064681
		// (set) Token: 0x06007DC2 RID: 32194 RVA: 0x0006648D File Offset: 0x0006468D
		private protected #ZGd DocumentContext { protected get; private set; }

		// Token: 0x170025B7 RID: 9655
		// (get) Token: 0x06007DC3 RID: 32195 RVA: 0x0006649E File Offset: 0x0006469E
		public int NumberOfPages
		{
			get
			{
				return this.DocumentContext.Paginator.NumberOfPages;
			}
		}

		// Token: 0x06007DC4 RID: 32196 RVA: 0x001BA798 File Offset: 0x001B8998
		public void #FFd(#jJd #GFd)
		{
			int #f;
			double num;
			if (!false)
			{
				double num2;
				#sHd.#qHd(#GFd, out #f, out num, out num2);
			}
			this.DocumentContext.Paginator.PageSize = #f;
			int num3 = (int)(num / #GFd.FontInfo.ContentCharacterWidth) - 1;
			if (num3 < 80)
			{
				throw new Exception(\u0019.\u0002\u0002(Localization.StringNotEnoughSpaceToPrepareTextReport.#z2d(true), Localization.StringPleaseChangePaperSizeOrMargins.#z2d()));
			}
			this.DocumentContext.Paginator.LineWidth = num3;
		}

		// Token: 0x06007DC5 RID: 32197 RVA: 0x001BA820 File Offset: 0x001B8A20
		public static void #qHd(#jJd #GFd, out int #rHd, out double #6Q, out double #YW)
		{
			Aspose.Words.PaperSize? paperSize = #GFd.AsposePaperSize;
			if (paperSize != null)
			{
				DocumentBuilder documentBuilder = new DocumentBuilder(new Document());
				\u0089\u0004.~\u001B\u000E(\u009F\u0003.~\u001B\u0008(documentBuilder), #GFd.AsposePaperSize.Value);
				#6Q = \u001B\u0002.~\u0099\u0004(\u009F\u0003.~\u001B\u0008(documentBuilder));
				#YW = \u001B\u0002.~\u009D\u0004(\u009F\u0003.~\u001B\u0008(documentBuilder));
			}
			else
			{
				if (#GFd.PaperSize == null)
				{
					throw new ArgumentException(#Phc.#3hc(107281433).#z2d(), #Phc.#3hc(107281908));
				}
				System.Drawing.Printing.PaperSize paperSize2 = #GFd.PaperSize;
				#6Q = (double)\u008D\u0002.~\u0092\u0005(paperSize2) / 100.0 * 72.0;
				#YW = (double)\u008D\u0002.~\u0093\u0005(paperSize2) / 100.0 * 72.0;
			}
			if (#GFd.Orientation == PaperOrientation.Landscape)
			{
				double num = #6Q;
				#6Q = #YW;
				#YW = num;
			}
			if (#GFd.Margins != null)
			{
				#YW -= #GFd.Margins.Top;
				#6Q -= #GFd.Margins.Right;
				#6Q -= #GFd.Margins.Left;
				#YW -= #GFd.Margins.Bottom;
			}
			#rHd = (int)\u0006\u0002.\u0013\u0004(#YW / #GFd.FontInfo.ContentCharacterHeight) - 1;
		}

		// Token: 0x06007DC6 RID: 32198 RVA: 0x000664BC File Offset: 0x000646BC
		public virtual void #bCd(Func<Stream> #En)
		{
			this.#IFd();
			this.#Jed(this.Definition);
			this.#zl(#En);
		}

		// Token: 0x06007DC7 RID: 32199 RVA: 0x000664E3 File Offset: 0x000646E3
		public void #bCd(Stream #gp)
		{
			this.#IFd();
			this.#Jed(this.Definition);
			if (#gp != null)
			{
				this.#zl(#gp);
			}
		}

		// Token: 0x06007DC8 RID: 32200 RVA: 0x001BA9A8 File Offset: 0x001B8BA8
		protected override void #Jed(#AEd #xS)
		{
			#xEd #xEd = this.Definition.Pages.FirstOrDefault<#xEd>();
			#ldd #ldd = (#xEd != null) ? #xEd.Context.Renderer : null;
			if (this.RenderXmlTestTags && #ldd != null)
			{
				#ldd.#3cd(#Phc.#3hc(107281859), StyleIdentifier.BodyText, null, null, null);
				#ldd.#3cd(#Phc.#3hc(107281806), StyleIdentifier.BodyText, null, null, null);
				#ldd.#pGd();
			}
			base.#Jed(#xS);
			if (this.RenderXmlTestTags && #ldd != null)
			{
				#ldd.#qGd();
				#ldd.#3cd(#Phc.#3hc(107281793), StyleIdentifier.BodyText, null, null, null);
			}
		}

		// Token: 0x06007DC9 RID: 32201 RVA: 0x0006650D File Offset: 0x0006470D
		protected void #IFd()
		{
			if (!this.#a)
			{
				throw new InvalidOperationException(#Phc.#3hc(107282283));
			}
		}

		// Token: 0x06007DCA RID: 32202 RVA: 0x001BAA78 File Offset: 0x001B8C78
		protected virtual void #zl(Func<Stream> #En)
		{
			using (Stream stream = #En())
			{
				this.#zl(stream);
			}
		}

		// Token: 0x06007DCB RID: 32203 RVA: 0x00066533 File Offset: 0x00064733
		protected virtual void #zl(Stream #gp)
		{
			this.DocumentContext.Paginator.#fGd(#gp);
			this.RawReportText = this.DocumentContext.Paginator.#cHd();
		}

		// Token: 0x06007DCC RID: 32204 RVA: 0x001BAABC File Offset: 0x001B8CBC
		protected void #eb(#ZGd #HFd, #AEd #xS)
		{
			if (#HFd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107282304));
			}
			this.DocumentContext = #HFd;
			if (#xS == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253735));
			}
			this.Definition = #xS;
			this.#a = true;
		}

		// Token: 0x0400337B RID: 13179
		private bool #a;

		// Token: 0x0400337C RID: 13180
		[CompilerGenerated]
		private readonly bool #b;

		// Token: 0x0400337D RID: 13181
		[CompilerGenerated]
		private string #c;

		// Token: 0x0400337E RID: 13182
		[CompilerGenerated]
		private #AEd #d;

		// Token: 0x0400337F RID: 13183
		[CompilerGenerated]
		private #ZGd #e;
	}
}

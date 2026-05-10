using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #o1d;
using #UYd;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace #6Pd
{
	// Token: 0x02000DFA RID: 3578
	internal sealed class #5Pd
	{
		// Token: 0x060080FB RID: 33019 RVA: 0x000690D8 File Offset: 0x000672D8
		public #5Pd(Stream #gp, #qSd #tHd)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			if (#tHd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107278205));
			}
			this.#a = #gp;
			this.#b = #tHd;
		}

		// Token: 0x060080FC RID: 33020 RVA: 0x001C17D4 File Offset: 0x001BF9D4
		public IReadOnlyList<#dQd> #0Pd()
		{
			List<#dQd> list = new List<#dQd>();
			this.#a.#i2d();
			#5Pd.#dZb #dZb = new #5Pd.#dZb();
			#dZb.#a = PdfReader.Open(this.#a, PdfDocumentOpenMode.Modify);
			try
			{
				List<PdfPage> #4Pd = Enumerable.Range(0, #dZb.#a.PageCount).Select(new Func<int, PdfPage>(#dZb.#vWd)).ToList<PdfPage>();
				this.#3Pd(#dZb.#a, #4Pd, list);
			}
			finally
			{
				if (#dZb.#a != null)
				{
					((IDisposable)#dZb.#a).Dispose();
				}
			}
			this.#a.#i2d();
			return list;
		}

		// Token: 0x060080FD RID: 33021 RVA: 0x001C1894 File Offset: 0x001BFA94
		private void #1Pd(PdfDocument #bFd, PdfOutline #2Pd)
		{
			\u0091\u0006.~\u0092\u0010(\u0090\u0006.~\u0091\u0010(#bFd), #2Pd);
			if (\u0092\u0006.~\u0093\u0010(#2Pd) != null)
			{
				\u0094\u0006.~\u0096\u0010(\u0093\u0006.~\u0094\u0010(\u0092\u0006.~\u0093\u0010(#2Pd)), #2Pd);
				return;
			}
			\u0094\u0006.~\u0096\u0010(\u0093\u0006.~\u0095\u0010(#bFd), #2Pd);
		}

		// Token: 0x060080FE RID: 33022 RVA: 0x001C190C File Offset: 0x001BFB0C
		private void #3Pd(PdfDocument #bFd, List<PdfPage> #4Pd, List<#dQd> #kmc)
		{
			Stack<PdfOutline> stack = new Stack<PdfOutline>(#bFd.Outlines);
			bool flag = false;
			while (stack.Count > 0)
			{
				#5Pd.#MZb #MZb = new #5Pd.#MZb();
				#MZb.#a = stack.Pop();
				PdfPage pdfPage = #4Pd.FirstOrDefault(new Func<PdfPage, bool>(#MZb.#wWd));
				int #f = #4Pd.IndexOf(pdfPage);
				#zSd #zSd = this.#b.Map.FirstOrDefault(new Func<#zSd, bool>(#MZb.#xWd));
				if (#zSd == null)
				{
					#zSd = this.#b.Map.FirstOrDefault(new Func<#zSd, bool>(#MZb.#yWd));
					if (#zSd != null)
					{
						this.#1Pd(#bFd, #MZb.#a);
						flag = true;
					}
				}
				if (#zSd == null)
				{
					this.#1Pd(#bFd, #MZb.#a);
					flag = true;
				}
				#kmc.Add(new #dQd
				{
					Left = #MZb.#a.Left,
					Top = #MZb.#a.Top,
					PageIndex = #f,
					Title = #MZb.#a.Title,
					PageSize = ((pdfPage != null) ? new double?(pdfPage.Height.Point) : null),
					BookmarkName = ((#zSd != null) ? #zSd.Bookmark : null)
				});
				if (#MZb.#a.HasChildren)
				{
					stack.#fZd(#MZb.#a.Outlines);
				}
			}
			if (flag)
			{
				this.#a.SetLength(0L);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					#bFd.Save(memoryStream, false);
					memoryStream.#i2d();
					PdfReader.Open(memoryStream, PdfDocumentOpenMode.Modify).Save(this.#a, false);
				}
			}
		}

		// Token: 0x040034E3 RID: 13539
		private readonly Stream #a;

		// Token: 0x040034E4 RID: 13540
		private readonly #qSd #b;

		// Token: 0x02000DFB RID: 3579
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06008100 RID: 33024 RVA: 0x00069114 File Offset: 0x00067314
			internal PdfPage #vWd(int #He)
			{
				return \u000F\u0007.~\u0011\u0011(\u000E\u0007.~\u0010\u0011(this.#a), #He);
			}

			// Token: 0x040034E5 RID: 13541
			public PdfDocument #a;
		}

		// Token: 0x02000DFC RID: 3580
		[CompilerGenerated]
		private sealed class #MZb
		{
			// Token: 0x06008102 RID: 33026 RVA: 0x001C1AE8 File Offset: 0x001BFCE8
			internal bool #wWd(PdfPage #gsb)
			{
				return \u0013\u0007.\u0015\u0011(\u0011\u0007.~\u0013\u0011(\u0010\u0007.~\u0012\u0011(#gsb)), \u0011\u0007.~\u0013\u0011(\u0010\u0007.~\u0012\u0011(\u0012\u0007.~\u0014\u0011(this.#a))));
			}

			// Token: 0x06008103 RID: 33027 RVA: 0x0006913D File Offset: 0x0006733D
			internal bool #xWd(#zSd #Rf)
			{
				return \u0093.\u0016\u0003(#Rf.Header, \u007F.~\u001D\u0002(this.#a));
			}

			// Token: 0x06008104 RID: 33028 RVA: 0x0006916B File Offset: 0x0006736B
			internal bool #yWd(#zSd #Rf)
			{
				return #Rf.IsScreenshoot && \u0093.\u0016\u0003(#Rf.Bookmark, \u007F.~\u001D\u0002(this.#a));
			}

			// Token: 0x040034E6 RID: 13542
			public PdfOutline #a;
		}
	}
}

using System;
using System.Collections.Generic;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace #hId
{
	// Token: 0x02000D9D RID: 3485
	internal static class #tId
	{
		// Token: 0x06007E1F RID: 32287 RVA: 0x000669B8 File Offset: 0x00064BB8
		public static IEnumerable<PageMarginsSpecification> #jId(bool #kId)
		{
			#tId.#iVd #iVd = new #tId.#iVd(-2);
			#iVd.#e = #kId;
			return #iVd;
		}

		// Token: 0x06007E20 RID: 32288 RVA: 0x000669C8 File Offset: 0x00064BC8
		public static PageMarginsSpecification #lId()
		{
			return new PageMarginsSpecification(PageMarginType.Narrow, #Phc.#3hc(107281745), 0.5, 0.5, 0.5, 0.5);
		}

		// Token: 0x06007E21 RID: 32289 RVA: 0x00066A06 File Offset: 0x00064C06
		public static PageMarginsSpecification #mId()
		{
			return new PageMarginsSpecification(PageMarginType.Normal, #Phc.#3hc(107281724), 0.75, 0.75, 0.75, 0.75);
		}

		// Token: 0x06007E22 RID: 32290 RVA: 0x00066A44 File Offset: 0x00064C44
		public static PageMarginsSpecification #nId()
		{
			return new PageMarginsSpecification(PageMarginType.Custom, #Phc.#3hc(107281671), 0.75, 0.75, 0.75, 0.75);
		}

		// Token: 0x06007E23 RID: 32291 RVA: 0x00066A82 File Offset: 0x00064C82
		public static PageMarginsSpecification #oId()
		{
			return new PageMarginsSpecification(PageMarginType.Wide, #Phc.#3hc(107281690), 1.0, 1.0, 1.0, 1.0);
		}

		// Token: 0x06007E24 RID: 32292 RVA: 0x00066AC0 File Offset: 0x00064CC0
		public static PageMarginsSpecification #pId()
		{
			return new PageMarginsSpecification(PageMarginType.Narrow, #Phc.#3hc(107281129), 12.7, 12.7, 12.7, 12.7);
		}

		// Token: 0x06007E25 RID: 32293 RVA: 0x00066AFE File Offset: 0x00064CFE
		public static PageMarginsSpecification #qId()
		{
			return new PageMarginsSpecification(PageMarginType.Normal, #Phc.#3hc(107281140), 19.05, 19.05, 19.05, 19.05);
		}

		// Token: 0x06007E26 RID: 32294 RVA: 0x00066B3C File Offset: 0x00064D3C
		public static PageMarginsSpecification #rId()
		{
			return new PageMarginsSpecification(PageMarginType.Custom, #Phc.#3hc(107281671), 19.05, 19.05, 19.05, 19.05);
		}

		// Token: 0x06007E27 RID: 32295 RVA: 0x00066B7A File Offset: 0x00064D7A
		public static PageMarginsSpecification #sId()
		{
			return new PageMarginsSpecification(PageMarginType.Wide, #Phc.#3hc(107281119), 25.4, 25.4, 25.4, 25.4);
		}
	}
}

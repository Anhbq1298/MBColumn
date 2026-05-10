using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E4D RID: 3661
	public sealed class ETABSFactoredLoadSummary
	{
		// Token: 0x17002776 RID: 10102
		// (get) Token: 0x0600833F RID: 33599 RVA: 0x0006B187 File Offset: 0x00069387
		// (set) Token: 0x06008340 RID: 33600 RVA: 0x0006B18F File Offset: 0x0006938F
		public string Element { get; private set; }

		// Token: 0x17002777 RID: 10103
		// (get) Token: 0x06008341 RID: 33601 RVA: 0x0006B198 File Offset: 0x00069398
		// (set) Token: 0x06008342 RID: 33602 RVA: 0x0006B1A0 File Offset: 0x000693A0
		public string Section { get; private set; }

		// Token: 0x17002778 RID: 10104
		// (get) Token: 0x06008343 RID: 33603 RVA: 0x0006B1A9 File Offset: 0x000693A9
		// (set) Token: 0x06008344 RID: 33604 RVA: 0x0006B1B1 File Offset: 0x000693B1
		public string LoadCombination { get; private set; }

		// Token: 0x17002779 RID: 10105
		// (get) Token: 0x06008345 RID: 33605 RVA: 0x0006B1BA File Offset: 0x000693BA
		// (set) Token: 0x06008346 RID: 33606 RVA: 0x0006B1C2 File Offset: 0x000693C2
		public string Station { get; private set; }

		// Token: 0x1700277A RID: 10106
		// (get) Token: 0x06008347 RID: 33607 RVA: 0x0006B1CB File Offset: 0x000693CB
		// (set) Token: 0x06008348 RID: 33608 RVA: 0x0006B1D3 File Offset: 0x000693D3
		public string Step { get; private set; }

		// Token: 0x1700277B RID: 10107
		// (get) Token: 0x06008349 RID: 33609 RVA: 0x0006B1DC File Offset: 0x000693DC
		// (set) Token: 0x0600834A RID: 33610 RVA: 0x0006B1E4 File Offset: 0x000693E4
		public double P { get; private set; }

		// Token: 0x1700277C RID: 10108
		// (get) Token: 0x0600834B RID: 33611 RVA: 0x0006B1ED File Offset: 0x000693ED
		// (set) Token: 0x0600834C RID: 33612 RVA: 0x0006B1F5 File Offset: 0x000693F5
		public double Mx { get; private set; }

		// Token: 0x1700277D RID: 10109
		// (get) Token: 0x0600834D RID: 33613 RVA: 0x0006B1FE File Offset: 0x000693FE
		// (set) Token: 0x0600834E RID: 33614 RVA: 0x0006B206 File Offset: 0x00069406
		public double My { get; private set; }

		// Token: 0x1700277E RID: 10110
		// (get) Token: 0x0600834F RID: 33615 RVA: 0x0006B20F File Offset: 0x0006940F
		// (set) Token: 0x06008350 RID: 33616 RVA: 0x0006B217 File Offset: 0x00069417
		private double StationValue { get; set; }

		// Token: 0x1700277F RID: 10111
		// (get) Token: 0x06008351 RID: 33617 RVA: 0x0006B220 File Offset: 0x00069420
		// (set) Token: 0x06008352 RID: 33618 RVA: 0x0006B228 File Offset: 0x00069428
		private double StepValue { get; set; }

		// Token: 0x17002780 RID: 10112
		// (get) Token: 0x06008353 RID: 33619 RVA: 0x0006B231 File Offset: 0x00069431
		// (set) Token: 0x06008354 RID: 33620 RVA: 0x0006B239 File Offset: 0x00069439
		private string Subelement { get; set; }

		// Token: 0x06008355 RID: 33621 RVA: 0x001C4C60 File Offset: 0x001C2E60
		private ETABSFactoredLoadSummary(string element, string section, string loadCombination, double stationValue, string station, double stepValue, string step, string subelement, double p, double mx, double my)
		{
			this.Element = element;
			this.Section = section;
			this.LoadCombination = loadCombination;
			this.StationValue = stationValue;
			this.Station = station;
			this.StepValue = stepValue;
			this.Step = step;
			this.Subelement = subelement;
			this.P = p;
			this.Mx = mx;
			this.My = my;
		}

		// Token: 0x06008356 RID: 33622 RVA: 0x001C4CC8 File Offset: 0x001C2EC8
		private static IEnumerable<ETABSFactoredLoadSummary> #DE(IEnumerable<ETABSFactoredLoadSummary> #tk)
		{
			return #tk.OrderBy(new Func<ETABSFactoredLoadSummary, string>(ETABSFactoredLoadSummary.<>c.<>9.#47h)).ThenBy(new Func<ETABSFactoredLoadSummary, string>(ETABSFactoredLoadSummary.<>c.<>9.#57h)).ThenBy(new Func<ETABSFactoredLoadSummary, string>(ETABSFactoredLoadSummary.<>c.<>9.#67h)).ThenBy(new Func<ETABSFactoredLoadSummary, double>(ETABSFactoredLoadSummary.<>c.<>9.#77h)).ThenBy(new Func<ETABSFactoredLoadSummary, string>(ETABSFactoredLoadSummary.<>c.<>9.#87h)).ThenBy(new Func<ETABSFactoredLoadSummary, double>(ETABSFactoredLoadSummary.<>c.<>9.#97h)).ThenBy(new Func<ETABSFactoredLoadSummary, string>(ETABSFactoredLoadSummary.<>c.<>9.#a8h)).ToList<ETABSFactoredLoadSummary>();
		}

		// Token: 0x06008357 RID: 33623 RVA: 0x001C4DD8 File Offset: 0x001C2FD8
		public static IEnumerable<ETABSFactoredLoadSummary> #Q5h(IEnumerable<ETABSFactoredLoad> #fUh, IEnumerable<ETABSFrame> #8r)
		{
			return ETABSFactoredLoadSummary.#DE(#fUh.Join(#8r, new Func<ETABSFactoredLoad, string>(ETABSFactoredLoadSummary.<>c.<>9.#b8h), new Func<ETABSFrame, string>(ETABSFactoredLoadSummary.<>c.<>9.#c8h), new Func<ETABSFactoredLoad, ETABSFrame, <>f__AnonymousType6<ETABSFactoredLoad, string>>(ETABSFactoredLoadSummary.<>c.<>9.#d8h)).Select(new Func<<>f__AnonymousType6<ETABSFactoredLoad, string>, ETABSFactoredLoadSummary>(ETABSFactoredLoadSummary.<>c.<>9.#e8h)));
		}

		// Token: 0x06008358 RID: 33624 RVA: 0x0006B242 File Offset: 0x00069442
		public static IEnumerable<ETABSFactoredLoadSummary> #R5h(IEnumerable<ETABSFactoredLoad> #fUh)
		{
			return ETABSFactoredLoadSummary.#DE(#fUh.Select(new Func<ETABSFactoredLoad, ETABSFactoredLoadSummary>(ETABSFactoredLoadSummary.<>c.<>9.#f8h)));
		}

		// Token: 0x040035DB RID: 13787
		[CompilerGenerated]
		private string #a;

		// Token: 0x040035DC RID: 13788
		[CompilerGenerated]
		private string #b;

		// Token: 0x040035DD RID: 13789
		[CompilerGenerated]
		private string #c;

		// Token: 0x040035DE RID: 13790
		[CompilerGenerated]
		private string #d;

		// Token: 0x040035DF RID: 13791
		[CompilerGenerated]
		private string #e;

		// Token: 0x040035E0 RID: 13792
		[CompilerGenerated]
		private double #f;

		// Token: 0x040035E1 RID: 13793
		[CompilerGenerated]
		private double #g;

		// Token: 0x040035E2 RID: 13794
		[CompilerGenerated]
		private double #h;

		// Token: 0x040035E3 RID: 13795
		[CompilerGenerated]
		private double #i;

		// Token: 0x040035E4 RID: 13796
		[CompilerGenerated]
		private double #j;

		// Token: 0x040035E5 RID: 13797
		[CompilerGenerated]
		private string #k;
	}
}

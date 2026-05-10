using System;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #NHe
{
	// Token: 0x02001251 RID: 4689
	internal static class #MHe
	{
		// Token: 0x06009D55 RID: 40277 RVA: 0x0007BF8E File Offset: 0x0007A18E
		public static bool #IH(UniCurve #NAe)
		{
			return #NAe.PlotPoint;
		}

		// Token: 0x06009D56 RID: 40278 RVA: 0x0007BF96 File Offset: 0x0007A196
		public static UniCurve[] #IH(UniCurve[] #NAe)
		{
			Func<UniCurve, bool> predicate;
			if ((predicate = #MHe.#2Ui.#a) == null)
			{
				predicate = (#MHe.#2Ui.#a = new Func<UniCurve, bool>(#MHe.#IH));
			}
			return #NAe.Where(predicate).ToArray<UniCurve>();
		}

		// Token: 0x02001252 RID: 4690
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04004406 RID: 17414
			public static Func<UniCurve, bool> #a;
		}
	}
}

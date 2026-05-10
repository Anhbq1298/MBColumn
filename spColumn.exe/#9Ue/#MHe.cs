using System;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #9Ue
{
	// Token: 0x020012E8 RID: 4840
	internal static class #MHe
	{
		// Token: 0x0600A1BA RID: 41402 RVA: 0x0007BF8E File Offset: 0x0007A18E
		public static bool #IH(UniCurve #NAe)
		{
			return #NAe.PlotPoint;
		}

		// Token: 0x0600A1BB RID: 41403 RVA: 0x0007EB4A File Offset: 0x0007CD4A
		public static UniCurve[] #IH(UniCurve[] #NAe)
		{
			Func<UniCurve, bool> predicate;
			if ((predicate = #MHe.#2Ui.#a) == null)
			{
				predicate = (#MHe.#2Ui.#a = new Func<UniCurve, bool>(#MHe.#IH));
			}
			return #NAe.Where(predicate).ToArray<UniCurve>();
		}

		// Token: 0x020012E9 RID: 4841
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040046C0 RID: 18112
			public static Func<UniCurve, bool> #a;
		}
	}
}

using System;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;

namespace #gMe
{
	// Token: 0x020012CD RID: 4813
	internal static class #OSe
	{
		// Token: 0x0600A11D RID: 41245 RVA: 0x0022541C File Offset: 0x0022361C
		public static float #bpb(float #MSe, InputModel #Od, bool #NSe, #38e #jMe)
		{
			if (#NSe || #MSe >= 1f)
			{
				return 1f;
			}
			Options options = #Od.Options;
			bool flag = options.ProblemType == #z6e.#b;
			bool flag2 = options.ProblemType == #z6e.#a;
			bool flag3 = options.ColumnType == #B6e.#b;
			if ((flag && flag3) || (flag2 && options.IsColumnConsideredArchitectural))
			{
				return #jMe.#d8e(#MSe);
			}
			return 1f;
		}
	}
}

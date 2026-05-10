using System;
using System.Linq;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.ViewModels.Loads.Helpers.Extensions
{
	// Token: 0x0200020D RID: 525
	internal static class LoadsExtensions
	{
		// Token: 0x060011F0 RID: 4592 RVA: 0x000A9DA0 File Offset: 0x000A7FA0
		public static FactoredLoad #LB(this CustomObservableCollection<FactoredLoad> #tk, FactoredLoad #MB)
		{
			int num = #tk.#C7c(#MB);
			if (num < 1)
			{
				return #MB;
			}
			return #tk[num - 1];
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x000A9DD0 File Offset: 0x000A7FD0
		public static float #NB(this CustomObservableCollection<FactoredLoad> #tk)
		{
			float num = #tk.Max(new Func<FactoredLoad, float>(LoadsExtensions.<>c.<>9.#FXb));
			float num2;
			if (!false)
			{
				num2 = num;
			}
			return num2 + 1f;
		}

		// Token: 0x04000710 RID: 1808
		private const float #a = 1f;
	}
}

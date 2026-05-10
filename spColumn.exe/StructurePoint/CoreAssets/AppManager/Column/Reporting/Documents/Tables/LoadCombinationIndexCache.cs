using System;
using System.Collections.Generic;
using System.Linq;
using #12e;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011A6 RID: 4518
	public sealed class LoadCombinationIndexCache
	{
		// Token: 0x0600992C RID: 39212 RVA: 0x0020584C File Offset: 0x00203A4C
		public LoadCombinationIndexCache(#lte model)
		{
			bool flag;
			if (model == null)
			{
				flag = (null != null);
			}
			else
			{
				#l4e #l4e = model.Output;
				flag = (((#l4e != null) ? #l4e.FactoredMoments : null) != null);
			}
			if (!flag || !model.Input.Options.ConsiderSlenderness)
			{
				return;
			}
			List<FactoredMoment> list = model.Output.FactoredMoments.Where(new Func<FactoredMoment, bool>(LoadCombinationIndexCache.<>c.<>9.#8Zb)).ToList<FactoredMoment>();
			if (!list.Any<FactoredMoment>())
			{
				list = model.Output.FactoredMoments.Where(new Func<FactoredMoment, bool>(LoadCombinationIndexCache.<>c.<>9.#oK)).ToList<FactoredMoment>();
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.#a[i] = list[i];
			}
		}

		// Token: 0x0600992D RID: 39213 RVA: 0x00205930 File Offset: 0x00203B30
		public bool #3hc(int #4jb, out int #ivb, out int #wye, out FactoredMoment.#vif #xye)
		{
			#ivb = (#wye = -1);
			#xye = FactoredMoment.#vif.#a;
			FactoredMoment factoredMoment = this.#a.#F1d(#4jb);
			if (factoredMoment == null)
			{
				return false;
			}
			#ivb = (factoredMoment.Load ?? 1);
			#wye = (factoredMoment.Combination ?? 1);
			#xye = factoredMoment.MomentSide;
			return true;
		}

		// Token: 0x040041C4 RID: 16836
		private readonly Dictionary<int, FactoredMoment> #a = new Dictionary<int, FactoredMoment>();
	}
}

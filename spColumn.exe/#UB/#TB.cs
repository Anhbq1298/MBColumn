using System;
using #5Z;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Model.Entities;

namespace #UB
{
	// Token: 0x0200020F RID: 527
	internal static class #TB
	{
		// Token: 0x060011F5 RID: 4597 RVA: 0x000A9E18 File Offset: 0x000A8018
		public static int #OB(this CustomObservableCollection<LoadFactor> #PB)
		{
			foreach (LoadFactor loadFactor in #PB)
			{
				int num = 0;
				foreach (LoadFactor loadFactor2 in #PB)
				{
					if (loadFactor2.Dead.Equals(loadFactor.Dead) && loadFactor2.Earthquake.Equals(loadFactor.Earthquake) && loadFactor2.Live.Equals(loadFactor.Live) && loadFactor2.Snow.Equals(loadFactor.Snow) && loadFactor2.Wind.Equals(loadFactor.Wind))
					{
						num++;
					}
				}
				if (num >= 2)
				{
					return num;
				}
			}
			return 0;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x000A9F40 File Offset: 0x000A8140
		public static bool #QB(this #V3 #RB, #V3 #SB)
		{
			return #RB.AxialLoad.Equals(#SB.AxialLoad) && #RB.MomentXBottom.Equals(#SB.MomentXBottom) && #RB.MomentXTop.Equals(#SB.MomentXTop) && #RB.MomentYBottom.Equals(#SB.MomentYBottom) && #RB.MomentYTop.Equals(#SB.MomentYTop);
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x000A9FD4 File Offset: 0x000A81D4
		public static bool #QB(this ServiceLoad #RB, ServiceLoad #SB)
		{
			return #RB.Dead.#QB(#SB.Dead) && #RB.Live.#QB(#SB.Live) && #RB.Earthquake.#QB(#SB.Earthquake) && #RB.Wind.#QB(#SB.Wind) && #RB.Snow.#QB(#SB.Snow);
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x000AA04C File Offset: 0x000A824C
		public static int #OB(this CustomObservableCollection<ServiceLoad> #PB)
		{
			foreach (ServiceLoad serviceLoad in #PB)
			{
				int num = 0;
				foreach (ServiceLoad serviceLoad2 in #PB)
				{
					if (serviceLoad2.Dead.#QB(serviceLoad.Dead) && serviceLoad2.Earthquake.#QB(serviceLoad.Earthquake) && serviceLoad2.Live.#QB(serviceLoad.Live) && serviceLoad2.Snow.#QB(serviceLoad.Snow) && serviceLoad2.Wind.#QB(serviceLoad.Wind))
					{
						num++;
					}
				}
				if (num >= 2)
				{
					return num;
				}
			}
			return 0;
		}
	}
}

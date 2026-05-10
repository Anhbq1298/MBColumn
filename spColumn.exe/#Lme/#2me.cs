using System;
using System.Collections.Generic;
using System.IO;
using #7hc;
using #coe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #Lme
{
	// Token: 0x020010E1 RID: 4321
	internal sealed class #2me : #Foe
	{
		// Token: 0x060092E0 RID: 37600 RVA: 0x00075C6B File Offset: 0x00073E6B
		public #2me(Stream #gp) : base(#gp)
		{
		}

		// Token: 0x060092E1 RID: 37601 RVA: 0x001F2E04 File Offset: 0x001F1004
		public List<FactoredLoad> #ZE()
		{
			if (base.#qoe(#Phc.#3hc(107289992)))
			{
				base.#roe(#Phc.#3hc(107289992), true);
			}
			else if (base.#uoe() == null)
			{
				throw new #ooe(Strings.StringCannotFind0Keyword.#D2d(new object[]
				{
					#Phc.#3hc(107289992)
				}).#z2d());
			}
			int num = base.#toe(true);
			if (num > 10000)
			{
				base.#ame(Strings.StringTheMaximumNumberOfFactoredLoadEentries0IsExceeded.#D2d(new object[]
				{
					10000
				}).#z2d());
			}
			List<FactoredLoad> list = new List<FactoredLoad>();
			for (int i = 0; i < num; i++)
			{
				float axialLoad;
				float momentX;
				float momentY;
				base.#voe(out axialLoad, out momentX, out momentY, true);
				FactoredLoad item = new FactoredLoad(axialLoad, momentX, momentY);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060092E2 RID: 37602 RVA: 0x001F2EDC File Offset: 0x001F10DC
		public List<ServiceLoad> #7ie()
		{
			if (base.#qoe(#Phc.#3hc(107290003)))
			{
				base.#roe(#Phc.#3hc(107290003), true);
			}
			else if (base.#uoe() == null)
			{
				throw new #ooe(Strings.StringCannotFind0Keyword.#D2d(new object[]
				{
					#Phc.#3hc(107290003)
				}).#z2d());
			}
			int num = base.#toe(true);
			if (num > 50)
			{
				base.#ame(Strings.StringTheMaximumNumberOfServiceLoadEntries0IsExceeded.#D2d(new object[]
				{
					50
				}).#z2d());
			}
			List<ServiceLoad> list = new List<ServiceLoad>();
			for (int i = 0; i < num; i++)
			{
				List<float> list2 = base.#voe(5, true);
				list2.AddRange(base.#voe(5, true));
				list2.AddRange(base.#voe(5, true));
				list2.AddRange(base.#voe(5, true));
				list2.AddRange(base.#voe(5, true));
				ServiceLoad item = new ServiceLoad(list2.ToArray());
				list.Add(item);
			}
			return list;
		}
	}
}

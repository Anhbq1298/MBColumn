using System;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #cYd
{
	// Token: 0x02000EB2 RID: 3762
	internal static class #lYd
	{
		// Token: 0x060085FF RID: 34303 RVA: 0x0006D20A File Offset: 0x0006B40A
		public static void #kYd([#Q0d] this object #f, string #wy, string #Qic, Component #x6c)
		{
			while (!true || #f != null)
			{
				if (!false)
				{
					return;
				}
			}
			throw new #mYd(Strings.StringAssumptionFailed.#u2d(true) + Strings.StringTheValueXCannotBeNull.#D2d(new object[]
			{
				#wy
			}), #Qic, #x6c);
		}
	}
}

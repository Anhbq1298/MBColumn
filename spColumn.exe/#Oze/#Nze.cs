using System;
using System.Globalization;
using #Ted;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;

namespace #Oze
{
	// Token: 0x020011FB RID: 4603
	internal sealed class #Nze : #ogd
	{
		// Token: 0x06009A50 RID: 39504 RVA: 0x0020D584 File Offset: 0x0020B784
		public string #mgd(string #f, bool #ngd)
		{
			if (#ngd)
			{
				return CapacityRatioHelper.#hVe(#f).ToString(CultureInfo.InvariantCulture);
			}
			return #f;
		}
	}
}

using System;
using #2ic;

namespace StructurePoint.CoreAssets.DataExchange.ExternFormat
{
	// Token: 0x02000764 RID: 1892
	public interface ILine : #ijc
	{
		// Token: 0x1700126F RID: 4719
		// (get) Token: 0x06003D13 RID: 15635
		// (set) Token: 0x06003D14 RID: 15636
		IPoint EndPoint { get; set; }

		// Token: 0x17001270 RID: 4720
		// (get) Token: 0x06003D15 RID: 15637
		// (set) Token: 0x06003D16 RID: 15638
		IPoint StartPoint { get; set; }
	}
}

using System;
using #2ic;

namespace StructurePoint.CoreAssets.DataExchange.ExternFormat
{
	// Token: 0x02000768 RID: 1896
	public interface IVertex
	{
		// Token: 0x17001277 RID: 4727
		// (get) Token: 0x06003D21 RID: 15649
		// (set) Token: 0x06003D22 RID: 15650
		#sjc Arc { get; set; }

		// Token: 0x17001278 RID: 4728
		// (get) Token: 0x06003D23 RID: 15651
		// (set) Token: 0x06003D24 RID: 15652
		IPoint Point { get; set; }
	}
}

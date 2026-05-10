using System;

namespace StructurePoint.Products.Column.BatchExecution
{
	// Token: 0x020006D6 RID: 1750
	internal enum ItemState
	{
		// Token: 0x040018D2 RID: 6354
		None,
		// Token: 0x040018D3 RID: 6355
		Queued,
		// Token: 0x040018D4 RID: 6356
		Processing,
		// Token: 0x040018D5 RID: 6357
		Error,
		// Token: 0x040018D6 RID: 6358
		Warning,
		// Token: 0x040018D7 RID: 6359
		Cancelled,
		// Token: 0x040018D8 RID: 6360
		Success
	}
}

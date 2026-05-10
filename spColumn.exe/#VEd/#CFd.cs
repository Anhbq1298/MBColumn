using System;
using Aspose.Words;
using Aspose.Words.Layout;

namespace #VEd
{
	// Token: 0x02000D71 RID: 3441
	internal interface #CFd
	{
		// Token: 0x17002581 RID: 9601
		// (get) Token: 0x06007CDE RID: 31966
		Document Document { get; }

		// Token: 0x17002582 RID: 9602
		// (get) Token: 0x06007CDF RID: 31967
		LayoutCollector LayoutCollector { get; }

		// Token: 0x17002583 RID: 9603
		// (get) Token: 0x06007CE0 RID: 31968
		LayoutEnumerator LayoutEnumerator { get; }

		// Token: 0x17002584 RID: 9604
		// (get) Token: 0x06007CE1 RID: 31969
		DocumentBuilder Builder { get; }
	}
}

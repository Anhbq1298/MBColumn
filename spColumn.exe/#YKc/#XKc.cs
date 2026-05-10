using System;
using #Fmc;

namespace #YKc
{
	// Token: 0x02000BB7 RID: 2999
	internal interface #XKc
	{
		// Token: 0x17001BE2 RID: 7138
		// (get) Token: 0x06006254 RID: 25172
		bool LeaveCuttingPolygon { get; }

		// Token: 0x17001BE3 RID: 7139
		// (get) Token: 0x06006255 RID: 25173
		bool RequireUserConfirmationForRemovalOfShapesWhenRemovingNodes { get; }

		// Token: 0x17001BE4 RID: 7140
		// (get) Token: 0x06006256 RID: 25174
		bool UseCustomSnappingModeForPreciseInputInitialAndRelativePointsSelection { get; }

		// Token: 0x17001BE5 RID: 7141
		// (get) Token: 0x06006257 RID: 25175
		#hvc CustomSnappingModeForPreciseInputInitialAndRelativePointsSelection { get; }
	}
}

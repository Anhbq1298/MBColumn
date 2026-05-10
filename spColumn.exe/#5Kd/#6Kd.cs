using System;
using #ezc;
using StructurePoint.CoreAssets.GUI.Framework.Services;

namespace #5Kd
{
	// Token: 0x02000DCB RID: 3531
	internal interface #6Kd : #QBc, #WBc
	{
		// Token: 0x140001A6 RID: 422
		// (add) Token: 0x06007FB9 RID: 32697
		// (remove) Token: 0x06007FBA RID: 32698
		event EventHandler Activated;

		// Token: 0x1700263F RID: 9791
		// (get) Token: 0x06007FBB RID: 32699
		// (set) Token: 0x06007FBC RID: 32700
		IGenericLoaderWindow AssociatedLoaderWindow { get; set; }
	}
}

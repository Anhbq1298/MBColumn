using System;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;

namespace #7Tc
{
	// Token: 0x02000C72 RID: 3186
	internal interface #iUc
	{
		// Token: 0x1400017F RID: 383
		// (add) Token: 0x0600669A RID: 26266
		// (remove) Token: 0x0600669B RID: 26267
		event EventHandler PreciseInputCanceled;

		// Token: 0x14000180 RID: 384
		// (add) Token: 0x0600669C RID: 26268
		// (remove) Token: 0x0600669D RID: 26269
		event EventHandler<PreciseInputChangedEventArgs> PreciseInputChanged;

		// Token: 0x14000181 RID: 385
		// (add) Token: 0x0600669E RID: 26270
		// (remove) Token: 0x0600669F RID: 26271
		event EventHandler<PreciseInputCompletedEventArgs> PreciseInputCompleted;

		// Token: 0x060066A0 RID: 26272
		void #gUc(PreciseInputParameters #hUc);
	}
}

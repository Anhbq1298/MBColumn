using System;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;

namespace #7Tc
{
	// Token: 0x02000C73 RID: 3187
	internal interface #jUc
	{
		// Token: 0x060066A1 RID: 26273
		void Show(PreciseInputParameters initializeInputParameters);

		// Token: 0x060066A2 RID: 26274
		void Update(PreciseInputParameters initializeInputParameters);

		// Token: 0x17001C7B RID: 7291
		// (get) Token: 0x060066A3 RID: 26275
		// (set) Token: 0x060066A4 RID: 26276
		bool IsPreciseInputEnabled { get; set; }

		// Token: 0x17001C7C RID: 7292
		// (get) Token: 0x060066A5 RID: 26277
		bool IsOpened { get; }

		// Token: 0x14000182 RID: 386
		// (add) Token: 0x060066A6 RID: 26278
		// (remove) Token: 0x060066A7 RID: 26279
		event EventHandler PreciseInputCanceled;

		// Token: 0x14000183 RID: 387
		// (add) Token: 0x060066A8 RID: 26280
		// (remove) Token: 0x060066A9 RID: 26281
		event EventHandler<PreciseInputChangedEventArgs> PreciseInputChanged;

		// Token: 0x14000184 RID: 388
		// (add) Token: 0x060066AA RID: 26282
		// (remove) Token: 0x060066AB RID: 26283
		event EventHandler<PreciseInputCompletedEventArgs> PreciseInputCompleted;

		// Token: 0x14000185 RID: 389
		// (add) Token: 0x060066AC RID: 26284
		// (remove) Token: 0x060066AD RID: 26285
		event EventHandler PreciseInputClosed;
	}
}

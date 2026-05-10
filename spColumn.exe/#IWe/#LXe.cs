using System;
using #12e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x02001306 RID: 4870
	internal sealed class #LXe : #NXe
	{
		// Token: 0x0600A2CB RID: 41675 RVA: 0x0007F460 File Offset: 0x0007D660
		public #LXe(#l4e #Kwe, RuntimeModel #iMe) : base(#Kwe, #iMe)
		{
		}

		// Token: 0x0600A2CC RID: 41676 RVA: 0x0022C664 File Offset: 0x0022A864
		protected override void #KXe(#L6e #VTe)
		{
			if (#VTe.HasFlag(#L6e.#f))
			{
				base.#MXe(Message.#R6e(#M6e.#j, Array.Empty<object>()));
			}
			if (#VTe.HasFlag(#L6e.#e))
			{
				base.#MXe(Message.#qn(#M6e.#k, Array.Empty<object>()));
			}
			if (#VTe.HasFlag(#L6e.#h))
			{
				base.#MXe(Message.#qn(#M6e.#m, Array.Empty<object>()));
			}
		}
	}
}

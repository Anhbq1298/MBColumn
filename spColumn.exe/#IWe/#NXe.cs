using System;
using #12e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #IWe
{
	// Token: 0x02001307 RID: 4871
	internal class #NXe : #rXe
	{
		// Token: 0x0600A2CD RID: 41677 RVA: 0x0007F46A File Offset: 0x0007D66A
		public #NXe(#l4e #Kwe, RuntimeModel #iMe)
		{
			this.#a = #Kwe;
			this.#b = #iMe;
		}

		// Token: 0x0600A2CE RID: 41678 RVA: 0x0022C6E8 File Offset: 0x0022A8E8
		public void #qXe(#L6e #VTe)
		{
			this.#KXe(#VTe);
			if (#VTe.HasFlag(#L6e.#b))
			{
				this.#MXe(Message.#qn(#M6e.#n, Array.Empty<object>()));
			}
			if (#VTe.HasFlag(#L6e.#c))
			{
				this.#MXe(Message.#qn(#M6e.#o, Array.Empty<object>()));
			}
			if (#VTe.HasFlag(#L6e.#d))
			{
				this.#MXe(Message.#qn(#M6e.#p, Array.Empty<object>()));
			}
		}

		// Token: 0x0600A2CF RID: 41679 RVA: 0x0022C76C File Offset: 0x0022A96C
		protected virtual void #KXe(#L6e #VTe)
		{
			if (#VTe.HasFlag(#L6e.#f))
			{
				this.#MXe(Message.#ZSc(#M6e.#i, Array.Empty<object>()));
				return;
			}
			if (#VTe.HasFlag(#L6e.#e))
			{
				this.#MXe(Message.#qn(#M6e.#k, Array.Empty<object>()));
				return;
			}
			if (#VTe.HasFlag(#L6e.#i))
			{
				this.#MXe(Message.#qn(#M6e.#l, Array.Empty<object>()));
			}
		}

		// Token: 0x0600A2D0 RID: 41680 RVA: 0x0007F480 File Offset: 0x0007D680
		protected void #MXe(Message #5)
		{
			this.#b.MessageBus.#rne(#5, null);
			this.#a.#vzc(#5);
		}

		// Token: 0x04004757 RID: 18263
		private readonly #l4e #a;

		// Token: 0x04004758 RID: 18264
		private readonly RuntimeModel #b;
	}
}

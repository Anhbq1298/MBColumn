using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #APb;
using #cMb;
using StructurePoint.Products.Column.Services.API;

namespace #aHb
{
	// Token: 0x02000611 RID: 1553
	internal sealed class #5Hb : #6Nb, INotifyPropertyChanged, #DNb, #WPb
	{
		// Token: 0x060034C5 RID: 13509 RVA: 0x00106458 File Offset: 0x00104658
		public #5Hb(IExtendedServices #0c) : base(#0c.ViewportsManager, #0c.MessageBus)
		{
			#3Hb #Ph = new #3Hb(#0c);
			this.#a = new #cOb(#Ph);
		}

		// Token: 0x1700107D RID: 4221
		// (get) Token: 0x060034C6 RID: 13510 RVA: 0x0002E557 File Offset: 0x0002C757
		public #cOb PointingWrapper { get; }

		// Token: 0x060034C7 RID: 13511 RVA: 0x0002E563 File Offset: 0x0002C763
		public override void #5b()
		{
			base.#5b();
			this.#tyb(this.PointingWrapper);
		}

		// Token: 0x040015DD RID: 5597
		[CompilerGenerated]
		private readonly #cOb #a;
	}
}

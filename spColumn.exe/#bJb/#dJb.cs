using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #APb;
using #cMb;
using StructurePoint.Products.Column.Services.API;

namespace #bJb
{
	// Token: 0x0200062A RID: 1578
	internal sealed class #dJb : #6Nb, INotifyPropertyChanged, #DNb, #VPb
	{
		// Token: 0x0600357E RID: 13694 RVA: 0x0010859C File Offset: 0x0010679C
		public #dJb(IExtendedServices #0c) : base(#0c.ViewportsManager, #0c.MessageBus)
		{
			#FJb #Ph = new #FJb(#0c);
			this.#a = new #cOb(#Ph);
		}

		// Token: 0x170010B0 RID: 4272
		// (get) Token: 0x0600357F RID: 13695 RVA: 0x0002EF07 File Offset: 0x0002D107
		public #cOb PointingWrapper { get; }

		// Token: 0x06003580 RID: 13696 RVA: 0x0002EF13 File Offset: 0x0002D113
		public override void #5b()
		{
			base.#5b();
			this.#tyb(this.PointingWrapper);
		}

		// Token: 0x04001625 RID: 5669
		[CompilerGenerated]
		private readonly #cOb #a;
	}
}

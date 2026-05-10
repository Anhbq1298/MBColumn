using System;
using System.Runtime.CompilerServices;
using #12e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #hZe
{
	// Token: 0x0200132C RID: 4908
	internal sealed class #y0e
	{
		// Token: 0x0600A3EA RID: 41962 RVA: 0x00080063 File Offset: 0x0007E263
		public #y0e()
		{
			this.Id = #y0e.#a++;
		}

		// Token: 0x17002F06 RID: 12038
		// (get) Token: 0x0600A3EB RID: 41963 RVA: 0x00080089 File Offset: 0x0007E289
		internal int Id { get; }

		// Token: 0x17002F07 RID: 12039
		// (get) Token: 0x0600A3EC RID: 41964 RVA: 0x00080091 File Offset: 0x0007E291
		// (set) Token: 0x0600A3ED RID: 41965 RVA: 0x00080099 File Offset: 0x0007E299
		public UniCurve[] UniCurve { get; internal set; }

		// Token: 0x17002F08 RID: 12040
		// (get) Token: 0x0600A3EE RID: 41966 RVA: 0x000800A2 File Offset: 0x0007E2A2
		// (set) Token: 0x0600A3EF RID: 41967 RVA: 0x000800AA File Offset: 0x0007E2AA
		public BiCurve[] BiCurve { get; internal set; }

		// Token: 0x17002F09 RID: 12041
		// (get) Token: 0x0600A3F0 RID: 41968 RVA: 0x000800B3 File Offset: 0x0007E2B3
		// (set) Token: 0x0600A3F1 RID: 41969 RVA: 0x000800BB File Offset: 0x0007E2BB
		public #J3e SpliceLines { get; internal set; } = new #J3e();

		// Token: 0x040047D0 RID: 18384
		private static int #a;

		// Token: 0x040047D1 RID: 18385
		[CompilerGenerated]
		private readonly int #b;

		// Token: 0x040047D2 RID: 18386
		[CompilerGenerated]
		private UniCurve[] #c;

		// Token: 0x040047D3 RID: 18387
		[CompilerGenerated]
		private BiCurve[] #d;

		// Token: 0x040047D4 RID: 18388
		[CompilerGenerated]
		private #J3e #e;
	}
}

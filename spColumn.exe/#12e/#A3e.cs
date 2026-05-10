using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #hZe;

namespace #12e
{
	// Token: 0x02001353 RID: 4947
	[DebuggerDisplay("AL: {AxialLoad}, Moment: {Moment}")]
	internal sealed class #A3e
	{
		// Token: 0x17002FBC RID: 12220
		// (get) Token: 0x0600A580 RID: 42368 RVA: 0x00081101 File Offset: 0x0007F301
		// (set) Token: 0x0600A581 RID: 42369 RVA: 0x00081109 File Offset: 0x0007F309
		public float AxialLoad { get; set; }

		// Token: 0x17002FBD RID: 12221
		// (get) Token: 0x0600A582 RID: 42370 RVA: 0x00081112 File Offset: 0x0007F312
		// (set) Token: 0x0600A583 RID: 42371 RVA: 0x0008111A File Offset: 0x0007F31A
		public float Moment { get; set; }

		// Token: 0x0600A584 RID: 42372 RVA: 0x00081123 File Offset: 0x0007F323
		internal void #mg(#YZe #ivb)
		{
			this.AxialLoad = #ivb.AxialLoad;
			this.Moment = #ivb.AbsoluteMomentMagnitude;
		}

		// Token: 0x040048C7 RID: 18631
		[CompilerGenerated]
		private float #a;

		// Token: 0x040048C8 RID: 18632
		[CompilerGenerated]
		private float #b;
	}
}

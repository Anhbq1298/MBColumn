using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace #g7e
{
	// Token: 0x0200138F RID: 5007
	internal sealed class #q7e : CancelEventArgs
	{
		// Token: 0x0600A786 RID: 42886 RVA: 0x000822E0 File Offset: 0x000804E0
		public #q7e(#q7e.#Mif #vp, int #r7e)
		{
			this.SolveProcessStage = new #q7e.#Mif?(#vp);
			this.ProgressPercentage = new int?(#r7e);
		}

		// Token: 0x0600A787 RID: 42887 RVA: 0x00082300 File Offset: 0x00080500
		public #q7e(#q7e.#Mif #vp)
		{
			this.SolveProcessStage = new #q7e.#Mif?(#vp);
		}

		// Token: 0x0600A788 RID: 42888 RVA: 0x00233044 File Offset: 0x00231244
		public #q7e(#q7e.#Mif #vp, int #NHb, int #a7e)
		{
			this.SolveProcessStage = new #q7e.#Mif?(#vp);
			this.ProgressPercentage = new int?((int)((double)#NHb * 1.0 / ((double)#a7e * 1.0) * 100.0));
			this.Total = new int?(#a7e);
			this.Current = new int?(#NHb);
		}

		// Token: 0x17003093 RID: 12435
		// (get) Token: 0x0600A789 RID: 42889 RVA: 0x00082314 File Offset: 0x00080514
		public int? ProgressPercentage { get; }

		// Token: 0x17003094 RID: 12436
		// (get) Token: 0x0600A78A RID: 42890 RVA: 0x0008231C File Offset: 0x0008051C
		public #q7e.#Mif? SolveProcessStage { get; }

		// Token: 0x17003095 RID: 12437
		// (get) Token: 0x0600A78B RID: 42891 RVA: 0x00082324 File Offset: 0x00080524
		public int? Current { get; }

		// Token: 0x17003096 RID: 12438
		// (get) Token: 0x0600A78C RID: 42892 RVA: 0x0008232C File Offset: 0x0008052C
		public int? Total { get; }

		// Token: 0x04004A2B RID: 18987
		[CompilerGenerated]
		private readonly int? #a;

		// Token: 0x04004A2C RID: 18988
		[CompilerGenerated]
		private readonly #q7e.#Mif? #b;

		// Token: 0x04004A2D RID: 18989
		[CompilerGenerated]
		private readonly int? #c;

		// Token: 0x04004A2E RID: 18990
		[CompilerGenerated]
		private readonly int? #d;

		// Token: 0x02001390 RID: 5008
		public enum #Mif
		{
			// Token: 0x04004A30 RID: 18992
			#a,
			// Token: 0x04004A31 RID: 18993
			#b,
			// Token: 0x04004A32 RID: 18994
			#c
		}
	}
}

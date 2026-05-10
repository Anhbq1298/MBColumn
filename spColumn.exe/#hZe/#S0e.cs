using System;
using System.Runtime.CompilerServices;
using #12e;

namespace #hZe
{
	// Token: 0x02001331 RID: 4913
	internal sealed class #S0e
	{
		// Token: 0x0600A417 RID: 42007 RVA: 0x0022F834 File Offset: 0x0022DA34
		public #S0e(float #T0e, float #U0e, float #V0e, float #W0e, float #AMe, float #BMe, bool #hW, float #eYe, float #X0e, float #Y0e, float #lTe)
		{
			this.UltimateMinMomentX = #T0e;
			this.UltimateMinMomentY = #U0e;
			this.UltimateMaxMomentX = #V0e;
			this.UltimateMaxMomentY = #W0e;
			this.UltimateMomentX = #AMe;
			this.UltimateMomentY = #BMe;
			this.Success = #hW;
			this.BarMaximumStrain = #eYe;
			this.NeutralAxisDepth = #X0e;
			this.TensionDistance = #Y0e;
			this.UltimateSafeFactor = #lTe;
		}

		// Token: 0x17002F13 RID: 12051
		// (get) Token: 0x0600A418 RID: 42008 RVA: 0x000802EE File Offset: 0x0007E4EE
		// (set) Token: 0x0600A419 RID: 42009 RVA: 0x000802F6 File Offset: 0x0007E4F6
		public float TensionDistance { get; internal set; }

		// Token: 0x17002F14 RID: 12052
		// (get) Token: 0x0600A41A RID: 42010 RVA: 0x000802FF File Offset: 0x0007E4FF
		// (set) Token: 0x0600A41B RID: 42011 RVA: 0x00080307 File Offset: 0x0007E507
		public float BarMaximumStrain { get; internal set; }

		// Token: 0x17002F15 RID: 12053
		// (get) Token: 0x0600A41C RID: 42012 RVA: 0x00080310 File Offset: 0x0007E510
		// (set) Token: 0x0600A41D RID: 42013 RVA: 0x00080318 File Offset: 0x0007E518
		public float NeutralAxisDepth { get; internal set; }

		// Token: 0x17002F16 RID: 12054
		// (get) Token: 0x0600A41E RID: 42014 RVA: 0x00080321 File Offset: 0x0007E521
		public bool Success { get; }

		// Token: 0x17002F17 RID: 12055
		// (get) Token: 0x0600A41F RID: 42015 RVA: 0x00080329 File Offset: 0x0007E529
		public float UltimateMaxMomentX { get; }

		// Token: 0x17002F18 RID: 12056
		// (get) Token: 0x0600A420 RID: 42016 RVA: 0x00080331 File Offset: 0x0007E531
		public float UltimateMaxMomentY { get; }

		// Token: 0x17002F19 RID: 12057
		// (get) Token: 0x0600A421 RID: 42017 RVA: 0x00080339 File Offset: 0x0007E539
		public float UltimateMinMomentX { get; }

		// Token: 0x17002F1A RID: 12058
		// (get) Token: 0x0600A422 RID: 42018 RVA: 0x00080341 File Offset: 0x0007E541
		public float UltimateMinMomentY { get; }

		// Token: 0x17002F1B RID: 12059
		// (get) Token: 0x0600A423 RID: 42019 RVA: 0x00080349 File Offset: 0x0007E549
		public float UltimateMomentX { get; }

		// Token: 0x17002F1C RID: 12060
		// (get) Token: 0x0600A424 RID: 42020 RVA: 0x00080351 File Offset: 0x0007E551
		public float UltimateMomentY { get; }

		// Token: 0x17002F1D RID: 12061
		// (get) Token: 0x0600A425 RID: 42021 RVA: 0x00080359 File Offset: 0x0007E559
		public float UltimateSafeFactor { get; }

		// Token: 0x17002F1E RID: 12062
		// (get) Token: 0x0600A426 RID: 42022 RVA: 0x00080361 File Offset: 0x0007E561
		// (set) Token: 0x0600A427 RID: 42023 RVA: 0x00080369 File Offset: 0x0007E569
		public float PhiPn { get; set; }

		// Token: 0x17002F1F RID: 12063
		// (get) Token: 0x0600A428 RID: 42024 RVA: 0x00080372 File Offset: 0x0007E572
		// (set) Token: 0x0600A429 RID: 42025 RVA: 0x0008037A File Offset: 0x0007E57A
		public float PhiMn { get; set; }

		// Token: 0x0600A42A RID: 42026 RVA: 0x00080383 File Offset: 0x0007E583
		internal void #77c(#u3e #kmc)
		{
			#kmc.PhiMn = new float?(this.PhiMn);
			#kmc.PhiPn = new float?(this.PhiPn);
		}

		// Token: 0x040047E2 RID: 18402
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047E3 RID: 18403
		[CompilerGenerated]
		private float #b;

		// Token: 0x040047E4 RID: 18404
		[CompilerGenerated]
		private float #c;

		// Token: 0x040047E5 RID: 18405
		[CompilerGenerated]
		private readonly bool #d;

		// Token: 0x040047E6 RID: 18406
		[CompilerGenerated]
		private readonly float #e;

		// Token: 0x040047E7 RID: 18407
		[CompilerGenerated]
		private readonly float #f;

		// Token: 0x040047E8 RID: 18408
		[CompilerGenerated]
		private readonly float #g;

		// Token: 0x040047E9 RID: 18409
		[CompilerGenerated]
		private readonly float #h;

		// Token: 0x040047EA RID: 18410
		[CompilerGenerated]
		private readonly float #i;

		// Token: 0x040047EB RID: 18411
		[CompilerGenerated]
		private readonly float #j;

		// Token: 0x040047EC RID: 18412
		[CompilerGenerated]
		private readonly float #k;

		// Token: 0x040047ED RID: 18413
		[CompilerGenerated]
		private float #l;

		// Token: 0x040047EE RID: 18414
		[CompilerGenerated]
		private float #m;
	}
}

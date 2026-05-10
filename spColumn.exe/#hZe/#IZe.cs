using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x02001321 RID: 4897
	internal struct #IZe
	{
		// Token: 0x0600A37E RID: 41854 RVA: 0x0007FB67 File Offset: 0x0007DD67
		public #IZe(float #JMe, float #1Xe, float #2Xe, float #JZe, float #KZe)
		{
			this.UltimateAxialLoad = #JMe;
			this.UltimateMomentX = #1Xe;
			this.UltimateMomentY = #2Xe;
			this.UltimateMomentR = #JZe;
			this.MaxSteelStrain = #KZe;
		}

		// Token: 0x0600A37F RID: 41855 RVA: 0x0007FB8E File Offset: 0x0007DD8E
		public #IZe(float #JMe, float #1Xe, float #2Xe, float #JZe)
		{
			this.UltimateAxialLoad = #JMe;
			this.UltimateMomentX = #1Xe;
			this.UltimateMomentY = #2Xe;
			this.UltimateMomentR = #JZe;
			this.MaxSteelStrain = 0f;
		}

		// Token: 0x17002ED9 RID: 11993
		// (get) Token: 0x0600A380 RID: 41856 RVA: 0x0007FBB8 File Offset: 0x0007DDB8
		public static #IZe Empty
		{
			get
			{
				return new #IZe(0f, 0f, 0f, 0f, 0f);
			}
		}

		// Token: 0x17002EDA RID: 11994
		// (get) Token: 0x0600A381 RID: 41857 RVA: 0x0007FBD8 File Offset: 0x0007DDD8
		public readonly float MaxSteelStrain { get; }

		// Token: 0x17002EDB RID: 11995
		// (get) Token: 0x0600A382 RID: 41858 RVA: 0x0007FBE0 File Offset: 0x0007DDE0
		public readonly float UltimateAxialLoad { get; }

		// Token: 0x17002EDC RID: 11996
		// (get) Token: 0x0600A383 RID: 41859 RVA: 0x0007FBE8 File Offset: 0x0007DDE8
		public readonly float UltimateMomentR { get; }

		// Token: 0x17002EDD RID: 11997
		// (get) Token: 0x0600A384 RID: 41860 RVA: 0x0007FBF0 File Offset: 0x0007DDF0
		public readonly float UltimateMomentX { get; }

		// Token: 0x17002EDE RID: 11998
		// (get) Token: 0x0600A385 RID: 41861 RVA: 0x0007FBF8 File Offset: 0x0007DDF8
		public readonly float UltimateMomentY { get; }

		// Token: 0x040047A3 RID: 18339
		[CompilerGenerated]
		private readonly float #a;

		// Token: 0x040047A4 RID: 18340
		[CompilerGenerated]
		private readonly float #b;

		// Token: 0x040047A5 RID: 18341
		[CompilerGenerated]
		private readonly float #c;

		// Token: 0x040047A6 RID: 18342
		[CompilerGenerated]
		private readonly float #d;

		// Token: 0x040047A7 RID: 18343
		[CompilerGenerated]
		private readonly float #e;
	}
}

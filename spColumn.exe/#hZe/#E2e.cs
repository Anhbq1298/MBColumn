using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x0200133E RID: 4926
	internal struct #E2e
	{
		// Token: 0x0600A4EF RID: 42223 RVA: 0x00080BD6 File Offset: 0x0007EDD6
		public #E2e(float #Tdb, float #cpb, float #KZe)
		{
			this.AxialLoad = #Tdb;
			this.Moment = #cpb;
			this.MaxSteelStrain = #KZe;
		}

		// Token: 0x0600A4F0 RID: 42224 RVA: 0x00080BED File Offset: 0x0007EDED
		public #E2e(float #Tdb, float #cpb)
		{
			this.AxialLoad = #Tdb;
			this.Moment = #cpb;
			this.MaxSteelStrain = 0f;
		}

		// Token: 0x17002F75 RID: 12149
		// (get) Token: 0x0600A4F1 RID: 42225 RVA: 0x00080C08 File Offset: 0x0007EE08
		public static #E2e Empty
		{
			get
			{
				return new #E2e(0f, 0f, 0f);
			}
		}

		// Token: 0x17002F76 RID: 12150
		// (get) Token: 0x0600A4F2 RID: 42226 RVA: 0x00080C1E File Offset: 0x0007EE1E
		public readonly float AxialLoad { get; }

		// Token: 0x17002F77 RID: 12151
		// (get) Token: 0x0600A4F3 RID: 42227 RVA: 0x00080C26 File Offset: 0x0007EE26
		public readonly float MaxSteelStrain { get; }

		// Token: 0x17002F78 RID: 12152
		// (get) Token: 0x0600A4F4 RID: 42228 RVA: 0x00080C2E File Offset: 0x0007EE2E
		public readonly float Moment { get; }

		// Token: 0x04004853 RID: 18515
		[CompilerGenerated]
		private readonly float #a;

		// Token: 0x04004854 RID: 18516
		[CompilerGenerated]
		private readonly float #b;

		// Token: 0x04004855 RID: 18517
		[CompilerGenerated]
		private readonly float #c;
	}
}

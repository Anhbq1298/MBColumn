using System;
using System.Runtime.CompilerServices;

namespace #hZe
{
	// Token: 0x0200133D RID: 4925
	internal struct #D2e
	{
		// Token: 0x0600A4EB RID: 42219 RVA: 0x00080BB6 File Offset: 0x0007EDB6
		public #D2e(float #KZe, #TZe #s1e)
		{
			this.MaxSteelStrain = #KZe;
			this.ColumnLoad = #s1e;
		}

		// Token: 0x17002F72 RID: 12146
		// (get) Token: 0x0600A4EC RID: 42220 RVA: 0x00080BC6 File Offset: 0x0007EDC6
		public readonly float MaxSteelStrain { get; }

		// Token: 0x17002F73 RID: 12147
		// (get) Token: 0x0600A4ED RID: 42221 RVA: 0x00080BCE File Offset: 0x0007EDCE
		public readonly #TZe ColumnLoad { get; }

		// Token: 0x17002F74 RID: 12148
		// (get) Token: 0x0600A4EE RID: 42222 RVA: 0x00230160 File Offset: 0x0022E360
		public static #D2e Empty
		{
			get
			{
				return default(#D2e);
			}
		}

		// Token: 0x04004851 RID: 18513
		[CompilerGenerated]
		private readonly float #a;

		// Token: 0x04004852 RID: 18514
		[CompilerGenerated]
		private readonly #TZe #b;
	}
}

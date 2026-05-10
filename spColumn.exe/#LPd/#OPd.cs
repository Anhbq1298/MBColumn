using System;
using System.Runtime.CompilerServices;

namespace #LPd
{
	// Token: 0x02000DF6 RID: 3574
	internal sealed class #OPd : EventArgs
	{
		// Token: 0x060080F0 RID: 33008 RVA: 0x00068FF4 File Offset: 0x000671F4
		public #OPd(bool #PPd)
		{
			this.IsSourceValid = #PPd;
		}

		// Token: 0x17002677 RID: 9847
		// (get) Token: 0x060080F1 RID: 33009 RVA: 0x00069003 File Offset: 0x00067203
		// (set) Token: 0x060080F2 RID: 33010 RVA: 0x0006900F File Offset: 0x0006720F
		public bool IsSourceValid { get; private set; }

		// Token: 0x040034E1 RID: 13537
		[CompilerGenerated]
		private bool #a;
	}
}

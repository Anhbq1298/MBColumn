using System;
using System.Runtime.CompilerServices;
using #v1c;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #mKd
{
	// Token: 0x02000DC0 RID: 3520
	internal sealed class #pKd : #L1c
	{
		// Token: 0x06007F23 RID: 32547 RVA: 0x00067B28 File Offset: 0x00065D28
		public #pKd(string #oT, string #In, ReportFileFormat #cA) : base(#oT, #In)
		{
			this.Format = #cA;
		}

		// Token: 0x17002618 RID: 9752
		// (get) Token: 0x06007F24 RID: 32548 RVA: 0x00067B39 File Offset: 0x00065D39
		// (set) Token: 0x06007F25 RID: 32549 RVA: 0x00067B45 File Offset: 0x00065D45
		public ReportFileFormat Format { get; private set; }

		// Token: 0x0400342B RID: 13355
		[CompilerGenerated]
		private ReportFileFormat #a;
	}
}

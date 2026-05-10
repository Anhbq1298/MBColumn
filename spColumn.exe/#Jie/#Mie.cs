using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;

namespace #Jie
{
	// Token: 0x020010AB RID: 4267
	internal sealed class #Mie : EventArgs
	{
		// Token: 0x06009183 RID: 37251 RVA: 0x00075382 File Offset: 0x00073582
		public #Mie(LateralLoadsCompatibilityMode #Nie)
		{
			this.CompatibilityMode = #Nie;
		}

		// Token: 0x17002A5B RID: 10843
		// (get) Token: 0x06009184 RID: 37252 RVA: 0x00075391 File Offset: 0x00073591
		// (set) Token: 0x06009185 RID: 37253 RVA: 0x00075399 File Offset: 0x00073599
		public LateralLoadsCompatibilityMode CompatibilityMode { get; set; }

		// Token: 0x04003D31 RID: 15665
		[CompilerGenerated]
		private LateralLoadsCompatibilityMode #a;
	}
}

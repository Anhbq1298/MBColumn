using System;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000781 RID: 1921
	internal sealed class #Jkc : IVertex
	{
		// Token: 0x170012D9 RID: 4825
		// (get) Token: 0x06003DDC RID: 15836 RVA: 0x00034E37 File Offset: 0x00033037
		// (set) Token: 0x06003DDD RID: 15837 RVA: 0x00034E3F File Offset: 0x0003303F
		public #sjc Arc { get; set; }

		// Token: 0x170012DA RID: 4826
		// (get) Token: 0x06003DDE RID: 15838 RVA: 0x00034E48 File Offset: 0x00033048
		// (set) Token: 0x06003DDF RID: 15839 RVA: 0x00034E50 File Offset: 0x00033050
		public IPoint Point { get; set; }

		// Token: 0x06003DE0 RID: 15840 RVA: 0x00034E59 File Offset: 0x00033059
		public #Jkc(#mkc #Ng)
		{
			this.Point = #Ng;
			this.Arc = null;
		}

		// Token: 0x06003DE1 RID: 15841 RVA: 0x00034E6F File Offset: 0x0003306F
		public #Jkc(#mkc #Ng, #Ujc #Kkc)
		{
			this.Point = #Ng;
			this.Arc = #Kkc;
		}

		// Token: 0x04001C1E RID: 7198
		[CompilerGenerated]
		private #sjc #a;

		// Token: 0x04001C1F RID: 7199
		[CompilerGenerated]
		private IPoint #b;
	}
}

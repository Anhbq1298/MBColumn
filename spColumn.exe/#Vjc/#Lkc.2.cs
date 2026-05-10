using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x02000782 RID: 1922
	[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXFX")]
	internal sealed class #Lkc : #ijc, #yjc
	{
		// Token: 0x170012DB RID: 4827
		// (get) Token: 0x06003DE2 RID: 15842 RVA: 0x00034E85 File Offset: 0x00033085
		// (set) Token: 0x06003DE3 RID: 15843 RVA: 0x00034E8D File Offset: 0x0003308D
		public IPoint Direction { get; set; }

		// Token: 0x170012DC RID: 4828
		// (get) Token: 0x06003DE4 RID: 15844 RVA: 0x00034E96 File Offset: 0x00033096
		// (set) Token: 0x06003DE5 RID: 15845 RVA: 0x00034E9E File Offset: 0x0003309E
		public IPoint Origin { get; set; }

		// Token: 0x170012DD RID: 4829
		// (get) Token: 0x06003DE6 RID: 15846 RVA: 0x00034EA7 File Offset: 0x000330A7
		// (set) Token: 0x06003DE7 RID: 15847 RVA: 0x00034EAF File Offset: 0x000330AF
		public #jjc Layer { get; set; }

		// Token: 0x06003DE8 RID: 15848 RVA: 0x00034EB8 File Offset: 0x000330B8
		public #Lkc(#mkc #Mkc, #mkc #pKb, #jjc #rR)
		{
			this.Origin = #Mkc;
			this.Direction = #pKb;
			this.Layer = #rR;
		}

		// Token: 0x04001C20 RID: 7200
		[CompilerGenerated]
		private IPoint #a;

		// Token: 0x04001C21 RID: 7201
		[CompilerGenerated]
		private IPoint #b;

		// Token: 0x04001C22 RID: 7202
		[CompilerGenerated]
		private #jjc #c;
	}
}

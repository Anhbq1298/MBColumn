using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;

namespace #g7e
{
	// Token: 0x0200138D RID: 5005
	internal sealed class #k7e : EventArgs
	{
		// Token: 0x0600A781 RID: 42881 RVA: 0x000822A3 File Offset: 0x000804A3
		public #k7e(Message #5, object[] #Pc = null)
		{
			this.Message = #5;
			this.Parameters = #Pc;
		}

		// Token: 0x17003090 RID: 12432
		// (get) Token: 0x0600A782 RID: 42882 RVA: 0x000822B9 File Offset: 0x000804B9
		public Message Message { get; }

		// Token: 0x17003091 RID: 12433
		// (get) Token: 0x0600A783 RID: 42883 RVA: 0x000822C1 File Offset: 0x000804C1
		public object[] Parameters { get; }

		// Token: 0x04004A28 RID: 18984
		[CompilerGenerated]
		private readonly Message #a;

		// Token: 0x04004A29 RID: 18985
		[CompilerGenerated]
		private readonly object[] #b;
	}
}

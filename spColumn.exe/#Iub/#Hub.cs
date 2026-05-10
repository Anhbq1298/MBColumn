using System;
using System.Runtime.CompilerServices;
using System.Windows;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Iub
{
	// Token: 0x0200048C RID: 1164
	internal sealed class #Hub
	{
		// Token: 0x06002B32 RID: 11058 RVA: 0x00026FFA File Offset: 0x000251FA
		public #Hub()
		{
			this.Visibility = Visibility.Visible;
		}

		// Token: 0x17000E91 RID: 3729
		// (get) Token: 0x06002B33 RID: 11059 RVA: 0x00027009 File Offset: 0x00025209
		// (set) Token: 0x06002B34 RID: 11060 RVA: 0x00027015 File Offset: 0x00025215
		public StructurePoint.CoreAssets.Infrastructure.Data.Point Position { get; set; }

		// Token: 0x17000E92 RID: 3730
		// (get) Token: 0x06002B35 RID: 11061 RVA: 0x00027026 File Offset: 0x00025226
		// (set) Token: 0x06002B36 RID: 11062 RVA: 0x00027032 File Offset: 0x00025232
		public Visibility Visibility { get; set; }

		// Token: 0x04001140 RID: 4416
		[CompilerGenerated]
		private StructurePoint.CoreAssets.Infrastructure.Data.Point #a;

		// Token: 0x04001141 RID: 4417
		[CompilerGenerated]
		private Visibility #b;
	}
}

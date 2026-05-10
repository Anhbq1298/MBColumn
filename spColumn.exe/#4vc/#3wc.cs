using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #4vc
{
	// Token: 0x0200081B RID: 2075
	internal sealed class #3wc
	{
		// Token: 0x170013A8 RID: 5032
		// (get) Token: 0x06004299 RID: 17049 RVA: 0x00037E9B File Offset: 0x0003609B
		// (set) Token: 0x0600429A RID: 17050 RVA: 0x00037EA7 File Offset: 0x000360A7
		public Point3D StartPoint { get; private set; }

		// Token: 0x170013A9 RID: 5033
		// (get) Token: 0x0600429B RID: 17051 RVA: 0x00037EB8 File Offset: 0x000360B8
		// (set) Token: 0x0600429C RID: 17052 RVA: 0x00037EC4 File Offset: 0x000360C4
		public Point3D EndPoint { get; private set; }

		// Token: 0x0600429D RID: 17053 RVA: 0x00037ED5 File Offset: 0x000360D5
		public #3wc(Point3D #Xrb, Point3D #Yrb)
		{
			this.StartPoint = #Xrb;
			this.EndPoint = #Yrb;
		}

		// Token: 0x04001E03 RID: 7683
		[CompilerGenerated]
		private Point3D #a;

		// Token: 0x04001E04 RID: 7684
		[CompilerGenerated]
		private Point3D #b;
	}
}

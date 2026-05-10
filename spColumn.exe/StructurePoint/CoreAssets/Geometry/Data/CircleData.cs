using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x0200080D RID: 2061
	public sealed class CircleData
	{
		// Token: 0x06004237 RID: 16951 RVA: 0x000379E9 File Offset: 0x00035BE9
		public CircleData(Point center, double radius)
		{
			this.Center = center;
			this.Radius = radius;
		}

		// Token: 0x1700138C RID: 5004
		// (get) Token: 0x06004238 RID: 16952 RVA: 0x000379FF File Offset: 0x00035BFF
		// (set) Token: 0x06004239 RID: 16953 RVA: 0x00037A0B File Offset: 0x00035C0B
		public Point Center { get; private set; }

		// Token: 0x1700138D RID: 5005
		// (get) Token: 0x0600423A RID: 16954 RVA: 0x00037A1C File Offset: 0x00035C1C
		// (set) Token: 0x0600423B RID: 16955 RVA: 0x00037A28 File Offset: 0x00035C28
		public double Radius { get; private set; }

		// Token: 0x04001DDD RID: 7645
		[CompilerGenerated]
		private Point #a;

		// Token: 0x04001DDE RID: 7646
		[CompilerGenerated]
		private double #b;
	}
}

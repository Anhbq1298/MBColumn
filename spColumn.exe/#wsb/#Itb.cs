using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #S9;
using #u3d;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace #wsb
{
	// Token: 0x02000481 RID: 1153
	internal sealed class #Itb
	{
		// Token: 0x17000E77 RID: 3703
		// (get) Token: 0x06002AA1 RID: 10913 RVA: 0x000268CA File Offset: 0x00024ACA
		// (set) Token: 0x06002AA2 RID: 10914 RVA: 0x000268D6 File Offset: 0x00024AD6
		public FailureSurface FailureSurface { get; set; }

		// Token: 0x17000E78 RID: 3704
		// (get) Token: 0x06002AA3 RID: 10915 RVA: 0x000268E7 File Offset: 0x00024AE7
		// (set) Token: 0x06002AA4 RID: 10916 RVA: 0x000268F3 File Offset: 0x00024AF3
		public #xbb WhichPartToCutHorizontal { get; set; }

		// Token: 0x17000E79 RID: 3705
		// (get) Token: 0x06002AA5 RID: 10917 RVA: 0x00026904 File Offset: 0x00024B04
		// (set) Token: 0x06002AA6 RID: 10918 RVA: 0x00026910 File Offset: 0x00024B10
		public IList<Point3D> PointsConsistingFailureSurface { get; set; }

		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x06002AA7 RID: 10919 RVA: 0x00026921 File Offset: 0x00024B21
		// (set) Token: 0x06002AA8 RID: 10920 RVA: 0x0002692D File Offset: 0x00024B2D
		public IList<int> IndexesConsistingFailureSurface { get; set; }

		// Token: 0x17000E7B RID: 3707
		// (get) Token: 0x06002AA9 RID: 10921 RVA: 0x0002693E File Offset: 0x00024B3E
		// (set) Token: 0x06002AAA RID: 10922 RVA: 0x0002694A File Offset: 0x00024B4A
		public double CrossSectionHeight { get; set; }

		// Token: 0x17000E7C RID: 3708
		// (get) Token: 0x06002AAB RID: 10923 RVA: 0x0002695B File Offset: 0x00024B5B
		// (set) Token: 0x06002AAC RID: 10924 RVA: 0x00026967 File Offset: 0x00024B67
		public #ybb WhichPartToCutVertical { get; set; }

		// Token: 0x17000E7D RID: 3709
		// (get) Token: 0x06002AAD RID: 10925 RVA: 0x00026978 File Offset: 0x00024B78
		// (set) Token: 0x06002AAE RID: 10926 RVA: 0x00026984 File Offset: 0x00024B84
		public #c4d Normal { get; set; }

		// Token: 0x17000E7E RID: 3710
		// (get) Token: 0x06002AAF RID: 10927 RVA: 0x00026995 File Offset: 0x00024B95
		// (set) Token: 0x06002AB0 RID: 10928 RVA: 0x000269A1 File Offset: 0x00024BA1
		public Point3D CoordinateSystemOrigin { get; set; }

		// Token: 0x17000E7F RID: 3711
		// (get) Token: 0x06002AB1 RID: 10929 RVA: 0x000269B2 File Offset: 0x00024BB2
		// (set) Token: 0x06002AB2 RID: 10930 RVA: 0x000269BE File Offset: 0x00024BBE
		public List<PolyLine3D> Wireframe { get; set; }

		// Token: 0x04001108 RID: 4360
		[CompilerGenerated]
		private FailureSurface #a;

		// Token: 0x04001109 RID: 4361
		[CompilerGenerated]
		private #xbb #b;

		// Token: 0x0400110A RID: 4362
		[CompilerGenerated]
		private IList<Point3D> #c;

		// Token: 0x0400110B RID: 4363
		[CompilerGenerated]
		private IList<int> #d;

		// Token: 0x0400110C RID: 4364
		[CompilerGenerated]
		private double #e;

		// Token: 0x0400110D RID: 4365
		[CompilerGenerated]
		private #ybb #f;

		// Token: 0x0400110E RID: 4366
		[CompilerGenerated]
		private #c4d #g;

		// Token: 0x0400110F RID: 4367
		[CompilerGenerated]
		private Point3D #h;

		// Token: 0x04001110 RID: 4368
		[CompilerGenerated]
		private List<PolyLine3D> #i;
	}
}

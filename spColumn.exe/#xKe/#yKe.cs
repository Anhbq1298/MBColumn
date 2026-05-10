using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.Geometry.Data;

namespace #xKe
{
	// Token: 0x0200126C RID: 4716
	internal sealed class #yKe
	{
		// Token: 0x17002DB9 RID: 11705
		// (get) Token: 0x06009E4D RID: 40525 RVA: 0x0007C9E1 File Offset: 0x0007ABE1
		public List<ShapeData> Shapes { get; } = new List<ShapeData>();

		// Token: 0x17002DBA RID: 11706
		// (get) Token: 0x06009E4E RID: 40526 RVA: 0x0007C9E9 File Offset: 0x0007ABE9
		// (set) Token: 0x06009E4F RID: 40527 RVA: 0x0007C9F1 File Offset: 0x0007ABF1
		public Geometry Geometry { get; set; }

		// Token: 0x0400446A RID: 17514
		[CompilerGenerated]
		private readonly List<ShapeData> #a;

		// Token: 0x0400446B RID: 17515
		[CompilerGenerated]
		private Geometry #b;
	}
}

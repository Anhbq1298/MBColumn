using System;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using StructurePoint.Products.Column.Model.Entities;

namespace #hR
{
	// Token: 0x020002E9 RID: 745
	internal sealed class #fS
	{
		// Token: 0x060019BA RID: 6586 RVA: 0x00019A7B File Offset: 0x00017C7B
		public #fS(Point3D #Ng, #8R #C = #8R.#a)
		{
			this.Point = #Ng;
			this.Type = #C;
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x00019A91 File Offset: 0x00017C91
		public #fS(ShapeModel #rP, Point3D #Ng)
		{
			this.Shape = #rP;
			this.Point = #Ng;
			this.Type = #8R.#a;
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x060019BC RID: 6588 RVA: 0x00019AAE File Offset: 0x00017CAE
		// (set) Token: 0x060019BD RID: 6589 RVA: 0x00019ABA File Offset: 0x00017CBA
		public ShapeModel Shape { get; set; }

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x060019BE RID: 6590 RVA: 0x00019ACB File Offset: 0x00017CCB
		// (set) Token: 0x060019BF RID: 6591 RVA: 0x00019AD7 File Offset: 0x00017CD7
		public Point3D Point { get; set; }

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x060019C0 RID: 6592 RVA: 0x00019AE8 File Offset: 0x00017CE8
		// (set) Token: 0x060019C1 RID: 6593 RVA: 0x00019AF4 File Offset: 0x00017CF4
		public bool IsSelected { get; set; }

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x060019C2 RID: 6594 RVA: 0x00019B05 File Offset: 0x00017D05
		// (set) Token: 0x060019C3 RID: 6595 RVA: 0x00019B11 File Offset: 0x00017D11
		public #8R Type { get; set; }

		// Token: 0x040009D9 RID: 2521
		[CompilerGenerated]
		private ShapeModel #a;

		// Token: 0x040009DA RID: 2522
		[CompilerGenerated]
		private Point3D #b;

		// Token: 0x040009DB RID: 2523
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040009DC RID: 2524
		[CompilerGenerated]
		private #8R #d;
	}
}

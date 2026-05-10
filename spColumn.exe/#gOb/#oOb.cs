using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.Products.Column.Model.Entities;

namespace #gOb
{
	// Token: 0x02000692 RID: 1682
	internal sealed class #oOb
	{
		// Token: 0x17001162 RID: 4450
		// (get) Token: 0x06003852 RID: 14418 RVA: 0x00030FE3 File Offset: 0x0002F1E3
		public List<ReinforcementBar> Bars { get; }

		// Token: 0x17001163 RID: 4451
		// (get) Token: 0x06003853 RID: 14419 RVA: 0x00030FEF File Offset: 0x0002F1EF
		public List<ShapeModel> Shapes { get; }

		// Token: 0x06003854 RID: 14420 RVA: 0x00030FFB File Offset: 0x0002F1FB
		public bool #nOb()
		{
			return this.Bars.Any<ReinforcementBar>() || this.Shapes.Any<ShapeModel>();
		}

		// Token: 0x040017A0 RID: 6048
		[CompilerGenerated]
		private readonly List<ReinforcementBar> #a = new List<ReinforcementBar>();

		// Token: 0x040017A1 RID: 6049
		[CompilerGenerated]
		private readonly List<ShapeModel> #b = new List<ShapeModel>();
	}
}

using System;
using System.Collections.Generic;
using devDept.Geometry;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Model.Entities;

namespace #LFb
{
	// Token: 0x02000550 RID: 1360
	internal interface #VFb
	{
		// Token: 0x17000FB0 RID: 4016
		// (get) Token: 0x06003070 RID: 12400
		List<ReinforcementBar> Nodes { get; }

		// Token: 0x17000FB1 RID: 4017
		// (get) Token: 0x06003071 RID: 12401
		List<ShapeModel> Slabs { get; }

		// Token: 0x17000FB2 RID: 4018
		// (get) Token: 0x06003072 RID: 12402
		bool ContainsAnyItem { get; }

		// Token: 0x06003073 RID: 12403
		void #yl();

		// Token: 0x06003074 RID: 12404
		void #QBb(SelectionManager #RBb);

		// Token: 0x06003075 RID: 12405
		Point3D #SBb();
	}
}

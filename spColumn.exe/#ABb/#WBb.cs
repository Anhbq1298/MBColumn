using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #8Cc;
using #LFb;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core;
using StructurePoint.Products.Column.Model.Entities;

namespace #ABb
{
	// Token: 0x0200054D RID: 1357
	internal sealed class #WBb : #VFb
	{
		// Token: 0x06003055 RID: 12373 RVA: 0x0002AF22 File Offset: 0x00029122
		public #WBb(#bDc #DJ)
		{
			this.#a = #DJ;
		}

		// Token: 0x17000FA9 RID: 4009
		// (get) Token: 0x06003056 RID: 12374 RVA: 0x0002AF47 File Offset: 0x00029147
		public List<ReinforcementBar> Nodes { get; }

		// Token: 0x17000FAA RID: 4010
		// (get) Token: 0x06003057 RID: 12375 RVA: 0x0002AF53 File Offset: 0x00029153
		public List<ShapeModel> Slabs { get; }

		// Token: 0x17000FAB RID: 4011
		// (get) Token: 0x06003058 RID: 12376 RVA: 0x0002AF5F File Offset: 0x0002915F
		public bool ContainsAnyItem
		{
			get
			{
				return this.Nodes.Any<ReinforcementBar>() || this.Slabs.Any<ShapeModel>();
			}
		}

		// Token: 0x06003059 RID: 12377 RVA: 0x0002AF87 File Offset: 0x00029187
		public void #yl()
		{
			this.Nodes.Clear();
			this.Slabs.Clear();
		}

		// Token: 0x0600305A RID: 12378 RVA: 0x000F8458 File Offset: 0x000F6658
		public void #QBb(SelectionManager #RBb)
		{
			Dictionary<ReinforcementBar, ReinforcementBar> #VBb = new Dictionary<ReinforcementBar, ReinforcementBar>();
			using (this.#a.#AA())
			{
				this.Nodes.AddRange(this.#UBb(#RBb.Bars.SelectedObjects, #VBb));
				this.Slabs.AddRange(this.#TBb(#RBb.Shapes.SelectedInNaturalOrder));
			}
		}

		// Token: 0x0600305B RID: 12379 RVA: 0x000F84D8 File Offset: 0x000F66D8
		public devDept.Geometry.Point3D #SBb()
		{
			BoundingBoxData boundingBoxData = BoundingBoxHelper.#wBb(this.Nodes, this.Slabs);
			Point point = boundingBoxData.#SBb();
			return new devDept.Geometry.Point3D(point.X, point.Y);
		}

		// Token: 0x0600305C RID: 12380 RVA: 0x0002AFAB File Offset: 0x000291AB
		private IEnumerable<ShapeModel> #TBb(IEnumerable<ShapeModel> #eAb)
		{
			#WBb.#98b #98b = new #WBb.#98b(-2);
			#98b.#e = #eAb;
			return #98b;
		}

		// Token: 0x0600305D RID: 12381 RVA: 0x0002AFBB File Offset: 0x000291BB
		private IEnumerable<ReinforcementBar> #UBb(IEnumerable<ReinforcementBar> #6W, Dictionary<ReinforcementBar, ReinforcementBar> #VBb)
		{
			#WBb.#c9b #c9b = new #WBb.#c9b(-2);
			#c9b.#e = #6W;
			#c9b.#g = #VBb;
			return #c9b;
		}

		// Token: 0x04001393 RID: 5011
		private readonly #bDc #a;

		// Token: 0x04001394 RID: 5012
		[CompilerGenerated]
		private readonly List<ReinforcementBar> #b = new List<ReinforcementBar>();

		// Token: 0x04001395 RID: 5013
		[CompilerGenerated]
		private readonly List<ShapeModel> #c = new List<ShapeModel>();
	}
}

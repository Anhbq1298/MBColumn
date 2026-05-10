using System;
using System.Collections.Generic;
using System.Linq;
using #gOb;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x020006A0 RID: 1696
	internal sealed class ShapesSelectionManager : #QOb<ShapeModel>
	{
		// Token: 0x1700117B RID: 4475
		// (get) Token: 0x060038CE RID: 14542 RVA: 0x000316D7 File Offset: 0x0002F8D7
		public IList<ShapeModel> SelectedInNaturalOrder
		{
			get
			{
				return base.SelectedObjects.OrderBy(new Func<ShapeModel, int>(ShapesSelectionManager.<>c.<>9.#3cc)).ToList<ShapeModel>();
			}
		}
	}
}

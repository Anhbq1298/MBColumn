using System;
using System.Collections.Generic;
using System.Linq;
using #aHb;
using #RJb;
using devDept.Geometry;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000600 RID: 1536
	internal sealed class ColumnDisplayHelper
	{
		// Token: 0x06003488 RID: 13448 RVA: 0x0002E394 File Offset: 0x0002C594
		public static void #nHb(#cLb #FR, ColumnEditor #iBb, Point3D #qAb)
		{
			ColumnDisplayHelper.#pHb(#FR, #qAb);
			ColumnDisplayHelper.#oHb(#FR, #qAb);
		}

		// Token: 0x06003489 RID: 13449 RVA: 0x00104F84 File Offset: 0x00103184
		private static void #oHb(#cLb #FR, Point3D #qAb)
		{
			List<ReinforcementBar> #KJ = #FR.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>();
			ColumnShapesHelper.#HHb(#KJ, #FR, #qHb.#b, #qAb);
		}

		// Token: 0x0600348A RID: 13450 RVA: 0x00104FBC File Offset: 0x001031BC
		private static void #pHb(#cLb #FR, Point3D #qAb)
		{
			List<ShapeModel> list = #FR.Selection.Shapes.SelectedInNaturalOrder.OrderByDescending(new Func<ShapeModel, bool>(ColumnDisplayHelper.<>c.<>9.#obc)).ToList<ShapeModel>();
			foreach (ShapeModel shapeModel in list)
			{
				List<Point3D> #AHb = ColumnShapesHelper.#DHb(#FR.ProjectContext, #FR.Settings, shapeModel, #qAb);
				ColumnShapesHelper.#IHb(#AHb, #FR, #qHb.#b, shapeModel.Application);
			}
		}
	}
}

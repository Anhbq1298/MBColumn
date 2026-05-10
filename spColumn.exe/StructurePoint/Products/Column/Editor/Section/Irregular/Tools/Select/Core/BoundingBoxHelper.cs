using System;
using System.Collections.Generic;
using System.Linq;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x02000548 RID: 1352
	internal static class BoundingBoxHelper
	{
		// Token: 0x06003041 RID: 12353 RVA: 0x000F8224 File Offset: 0x000F6424
		public static BoundingBoxData #tBb(BoundingBoxData #uBb, BoundingBoxData #vBb)
		{
			double minX = (#uBb.MinX < #vBb.MinX) ? #uBb.MinX : #vBb.MinX;
			double maxX = (#uBb.MaxX > #vBb.MaxX) ? #uBb.MaxX : #vBb.MaxX;
			double maxY = (#uBb.MaxY > #vBb.MaxY) ? #uBb.MaxY : #vBb.MaxY;
			double minY = (#uBb.MinY < #vBb.MinY) ? #uBb.MinY : #vBb.MinY;
			return new BoundingBoxData(minX, maxX, minY, maxY);
		}

		// Token: 0x06003042 RID: 12354 RVA: 0x000F82CC File Offset: 0x000F64CC
		public static BoundingBoxData #wBb(IEnumerable<ReinforcementBar> #6W, IEnumerable<ShapeModel> #eAb)
		{
			List<Point> list = BoundingBoxHelper.#xBb(#6W, #eAb);
			if (list.Count <= 0)
			{
				return new BoundingBoxData();
			}
			return new BoundingBoxData(list);
		}

		// Token: 0x06003043 RID: 12355 RVA: 0x000F8304 File Offset: 0x000F6504
		private static List<Point> #xBb(IEnumerable<ReinforcementBar> #6W, IEnumerable<ShapeModel> #eAb)
		{
			IEnumerable<Point> first = BoundingBoxHelper.#yBb(#6W);
			IEnumerable<Point> second = #eAb.SelectMany(new Func<ShapeModel, IEnumerable<Point>>(BoundingBoxHelper.<>c.<>9.#48b));
			return first.Concat(second).ToList<Point>();
		}

		// Token: 0x06003044 RID: 12356 RVA: 0x0002ADF1 File Offset: 0x00028FF1
		private static IEnumerable<Point> #yBb(IEnumerable<ReinforcementBar> #6W)
		{
			return #6W.Select(new Func<ReinforcementBar, Point>(BoundingBoxHelper.<>c.<>9.#58b));
		}
	}
}

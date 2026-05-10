using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using NetTopologySuite.Precision;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Model.Entities;

namespace #aAb
{
	// Token: 0x02000522 RID: 1314
	internal sealed class #TAb : ColumnGeometryHelper
	{
		// Token: 0x06002F5F RID: 12127 RVA: 0x000F4A70 File Offset: 0x000F2C70
		public static void #SAb(ShapeModel #rP)
		{
			GeometryPrecisionReducer geometryPrecisionReducer = ColumnGeometryHelper.#KKe(ColumnGeometryHelper.#e);
			IReadOnlyList<StructurePoint.CoreAssets.Infrastructure.Data.Point> readOnlyList = #rP.#cxc(0).Points2D;
			List<Point3D> list = new List<Point3D>();
			foreach (StructurePoint.CoreAssets.Infrastructure.Data.Point point in readOnlyList)
			{
				NetTopologySuite.Geometries.Point point2 = new NetTopologySuite.Geometries.Point(point.X, point.Y);
				point2 = (NetTopologySuite.Geometries.Point)geometryPrecisionReducer.Reduce(point2);
				list.Add(new Point3D(point2.X, point2.Y));
			}
			#rP.#8wc(new PolygonData(list));
		}
	}
}

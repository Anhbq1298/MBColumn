using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #klc;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x0200038C RID: 908
	internal sealed class ShapeModel : ShapeData
	{
		// Token: 0x06001D66 RID: 7526 RVA: 0x000C13E4 File Offset: 0x000BF5E4
		public ShapeModel(SectionPolygon polygon)
		{
			if (polygon == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399958));
			}
			this.Application = polygon.Application;
			this.FigureType = polygon.FigureType;
			this.CircleCenter = ((polygon.CircleCenter != null) ? new StructurePoint.CoreAssets.Infrastructure.Data.Point?(new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)polygon.CircleCenter.X, (double)polygon.CircleCenter.Y)) : null);
			this.CircleRadius = polygon.CircleRadius;
			this.RectStartPoint = ((polygon.RectStartPoint != null) ? new StructurePoint.CoreAssets.Infrastructure.Data.Point?(new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)polygon.RectStartPoint.X, (double)polygon.RectStartPoint.Y)) : null);
			this.CircleRadius = polygon.CircleRadius;
			this.RectHeight = polygon.RectHeight;
			this.RectWidth = polygon.RectWidth;
			this.Id = polygon.Id;
			base.#8wc(new PolygonData(polygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Point3D>(ShapeModel.<>c.<>9.#22b))));
			base.DetermineRelationshipsState = #jlc.#b;
			base.#t3h();
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x0001C2D3 File Offset: 0x0001A4D3
		public ShapeModel()
		{
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x0001C2DB File Offset: 0x0001A4DB
		public ShapeModel(PolygonData polygon, StructurePoint.CoreAssets.Infrastructure.Data.Point startPoint, double width, double height) : base(polygon)
		{
			this.FigureType = PolygonFigureType.Rectangle;
			this.RectStartPoint = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(startPoint);
			this.RectWidth = new double?(width);
			this.RectHeight = new double?(height);
			base.#t3h();
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x0001C316 File Offset: 0x0001A516
		public ShapeModel(PolygonData polygon) : base(polygon)
		{
			this.FigureType = PolygonFigureType.Irregural;
			base.#t3h();
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x0001C32C File Offset: 0x0001A52C
		public ShapeModel(PolygonData polygon, #jlc determineRelationships) : base(polygon, determineRelationships)
		{
			base.#t3h();
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x0001C33C File Offset: 0x0001A53C
		public ShapeModel(IEnumerable<PolygonData> polygons) : base(polygons)
		{
			base.#t3h();
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x000C1518 File Offset: 0x000BF718
		public ShapeModel(ShapeModel other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.CircleCenter = other.CircleCenter;
			this.CircleRadius = other.CircleRadius;
			this.FigureType = other.FigureType;
			this.RectHeight = other.RectHeight;
			this.RectStartPoint = other.RectStartPoint;
			this.RectWidth = other.RectWidth;
			this.Application = other.Application;
			base.#8wc(other.Polygons.Select(new Func<PolygonData, PolygonData>(ShapeModel.<>c.<>9.#RGf)).ToList<PolygonData>());
			base.#t3h();
		}

		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x06001D6D RID: 7533 RVA: 0x0001C34B File Offset: 0x0001A54B
		// (set) Token: 0x06001D6E RID: 7534 RVA: 0x0001C357 File Offset: 0x0001A557
		public PolygonFigureType FigureType { get; set; }

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x06001D6F RID: 7535 RVA: 0x0001C368 File Offset: 0x0001A568
		// (set) Token: 0x06001D70 RID: 7536 RVA: 0x0001C374 File Offset: 0x0001A574
		public PolygonApplication Application { get; set; }

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06001D71 RID: 7537 RVA: 0x0001C385 File Offset: 0x0001A585
		// (set) Token: 0x06001D72 RID: 7538 RVA: 0x0001C391 File Offset: 0x0001A591
		public StructurePoint.CoreAssets.Infrastructure.Data.Point? RectStartPoint { get; private set; }

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06001D73 RID: 7539 RVA: 0x0001C3A2 File Offset: 0x0001A5A2
		// (set) Token: 0x06001D74 RID: 7540 RVA: 0x0001C3AE File Offset: 0x0001A5AE
		public double? RectWidth { get; private set; }

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x06001D75 RID: 7541 RVA: 0x0001C3BF File Offset: 0x0001A5BF
		// (set) Token: 0x06001D76 RID: 7542 RVA: 0x0001C3CB File Offset: 0x0001A5CB
		public double? RectHeight { get; private set; }

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x06001D77 RID: 7543 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		// (set) Token: 0x06001D78 RID: 7544 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
		public StructurePoint.CoreAssets.Infrastructure.Data.Point? CircleCenter { get; private set; }

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06001D79 RID: 7545 RVA: 0x0001C3F9 File Offset: 0x0001A5F9
		// (set) Token: 0x06001D7A RID: 7546 RVA: 0x0001C405 File Offset: 0x0001A605
		public double? CircleRadius { get; private set; }

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06001D7B RID: 7547 RVA: 0x0001C416 File Offset: 0x0001A616
		// (set) Token: 0x06001D7C RID: 7548 RVA: 0x0001C422 File Offset: 0x0001A622
		public int Id { get; set; }

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06001D7D RID: 7549 RVA: 0x000C15D0 File Offset: 0x000BF7D0
		public string DisplayId
		{
			get
			{
				if (this.Application != PolygonApplication.Solid)
				{
					return string.Format(#Phc.#3hc(107399392), this.Id);
				}
				return string.Format(#Phc.#3hc(107399415), this.Id);
			}
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x000C1628 File Offset: 0x000BF828
		public Geometry #n0()
		{
			PolygonData polygonData = base.Polygons.ElementAtOrDefault(0);
			if (polygonData == null)
			{
				return Polygon.Empty;
			}
			return new Polygon(new LinearRing(polygonData.Points3D.Select(new Func<Point3D, Coordinate>(ShapeModel.<>c.<>9.#5Zh)).ToArray<Coordinate>()));
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x000C1690 File Offset: 0x000BF890
		public SectionPolygon #CY()
		{
			SectionPolygon sectionPolygon = new SectionPolygon
			{
				Application = this.Application,
				CircleRadius = this.CircleRadius,
				RectHeight = this.RectHeight,
				RectWidth = this.RectWidth,
				FigureType = this.FigureType,
				RectStartPoint = ((this.RectStartPoint != null) ? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(this.RectStartPoint.Value.X, this.RectStartPoint.Value.Y) : null),
				CircleCenter = ((this.CircleCenter != null) ? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(this.CircleCenter.Value.X, this.CircleCenter.Value.Y) : null),
				Id = this.Id
			};
			PolygonData polygonData = base.Polygons.ElementAtOrDefault(0);
			if (polygonData != null)
			{
				sectionPolygon.Points = polygonData.Points2D.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(ShapeModel.<>c.<>9.#6Zh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
			}
			return sectionPolygon;
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x0001C433 File Offset: 0x0001A633
		public ShapeModel #EA()
		{
			return new ShapeModel(this);
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0001C443 File Offset: 0x0001A643
		public void #o0(StructurePoint.CoreAssets.Infrastructure.Data.Point? #p0)
		{
			this.CircleCenter = #p0;
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x0001C458 File Offset: 0x0001A658
		public void #q0(double #r0)
		{
			this.CircleRadius = new double?(#r0);
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x000C17E4 File Offset: 0x000BF9E4
		public void #s0()
		{
			this.FigureType = PolygonFigureType.Irregural;
			double? num = null;
			this.CircleRadius = num;
			this.RectHeight = (this.RectWidth = num);
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point = null;
			this.CircleCenter = point;
			this.RectStartPoint = point;
		}

		// Token: 0x04000BC2 RID: 3010
		[CompilerGenerated]
		private PolygonFigureType #a;

		// Token: 0x04000BC3 RID: 3011
		[CompilerGenerated]
		private PolygonApplication #b;

		// Token: 0x04000BC4 RID: 3012
		[CompilerGenerated]
		private StructurePoint.CoreAssets.Infrastructure.Data.Point? #c;

		// Token: 0x04000BC5 RID: 3013
		[CompilerGenerated]
		private double? #d;

		// Token: 0x04000BC6 RID: 3014
		[CompilerGenerated]
		private double? #e;

		// Token: 0x04000BC7 RID: 3015
		[CompilerGenerated]
		private StructurePoint.CoreAssets.Infrastructure.Data.Point? #f;

		// Token: 0x04000BC8 RID: 3016
		[CompilerGenerated]
		private double? #g;

		// Token: 0x04000BC9 RID: 3017
		[CompilerGenerated]
		private int #h;
	}
}

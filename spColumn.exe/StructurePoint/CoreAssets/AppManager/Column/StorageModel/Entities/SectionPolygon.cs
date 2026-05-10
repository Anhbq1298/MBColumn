using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using #7hc;
using NetTopologySuite.Geometries;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02000FF6 RID: 4086
	[DataContract(Name = "SectionPolygon", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SectionPolygon
	{
		// Token: 0x06008D5D RID: 36189 RVA: 0x00072BB3 File Offset: 0x00070DB3
		public SectionPolygon()
		{
		}

		// Token: 0x06008D5E RID: 36190 RVA: 0x001E1AB4 File Offset: 0x001DFCB4
		public SectionPolygon(SectionPolygon other)
		{
			this.FigureType = other.FigureType;
			this.Application = other.Application;
			this.RectStartPoint = ((other.RectStartPoint != null) ? new Point(other.RectStartPoint) : null);
			this.RectWidth = other.RectWidth;
			this.RectHeight = other.RectHeight;
			this.CircleCenter = ((other.CircleCenter != null) ? new Point(other.CircleCenter) : null);
			this.CircleRadius = other.CircleRadius;
			this.Points.AddRange(from p in other.Points
			select new Point(p));
		}

		// Token: 0x17002933 RID: 10547
		// (get) Token: 0x06008D5F RID: 36191 RVA: 0x00072BCD File Offset: 0x00070DCD
		// (set) Token: 0x06008D60 RID: 36192 RVA: 0x00072BD5 File Offset: 0x00070DD5
		[DataMember(Name = "Points", Order = 10)]
		public List<Point> Points { get; set; } = new List<Point>();

		// Token: 0x17002934 RID: 10548
		// (get) Token: 0x06008D61 RID: 36193 RVA: 0x00072BDE File Offset: 0x00070DDE
		// (set) Token: 0x06008D62 RID: 36194 RVA: 0x00072BE6 File Offset: 0x00070DE6
		[DataMember(Name = "FigureType", Order = 20)]
		public PolygonFigureType FigureType { get; set; } = PolygonFigureType.Irregural;

		// Token: 0x17002935 RID: 10549
		// (get) Token: 0x06008D63 RID: 36195 RVA: 0x00072BEF File Offset: 0x00070DEF
		// (set) Token: 0x06008D64 RID: 36196 RVA: 0x00072BF7 File Offset: 0x00070DF7
		[DataMember(Name = "Application", Order = 30)]
		public PolygonApplication Application { get; set; }

		// Token: 0x17002936 RID: 10550
		// (get) Token: 0x06008D65 RID: 36197 RVA: 0x00072C00 File Offset: 0x00070E00
		// (set) Token: 0x06008D66 RID: 36198 RVA: 0x00072C08 File Offset: 0x00070E08
		[DataMember(Name = "RectStartPoint", Order = 100, IsRequired = false)]
		public Point RectStartPoint { get; set; }

		// Token: 0x17002937 RID: 10551
		// (get) Token: 0x06008D67 RID: 36199 RVA: 0x00072C11 File Offset: 0x00070E11
		// (set) Token: 0x06008D68 RID: 36200 RVA: 0x00072C19 File Offset: 0x00070E19
		[DataMember(Name = "RectWidth", Order = 110, IsRequired = false)]
		public double? RectWidth { get; set; }

		// Token: 0x17002938 RID: 10552
		// (get) Token: 0x06008D69 RID: 36201 RVA: 0x00072C22 File Offset: 0x00070E22
		// (set) Token: 0x06008D6A RID: 36202 RVA: 0x00072C2A File Offset: 0x00070E2A
		[DataMember(Name = "RectHeight", Order = 120, IsRequired = false)]
		public double? RectHeight { get; set; }

		// Token: 0x17002939 RID: 10553
		// (get) Token: 0x06008D6B RID: 36203 RVA: 0x00072C33 File Offset: 0x00070E33
		// (set) Token: 0x06008D6C RID: 36204 RVA: 0x00072C3B File Offset: 0x00070E3B
		[DataMember(Name = "CircleCenter", Order = 130, IsRequired = false)]
		public Point CircleCenter { get; set; }

		// Token: 0x1700293A RID: 10554
		// (get) Token: 0x06008D6D RID: 36205 RVA: 0x00072C44 File Offset: 0x00070E44
		// (set) Token: 0x06008D6E RID: 36206 RVA: 0x00072C4C File Offset: 0x00070E4C
		[DataMember(Name = "CircleRadius", Order = 140, IsRequired = false)]
		public double? CircleRadius { get; set; }

		// Token: 0x1700293B RID: 10555
		// (get) Token: 0x06008D6F RID: 36207 RVA: 0x00072C55 File Offset: 0x00070E55
		// (set) Token: 0x06008D70 RID: 36208 RVA: 0x00072C5D File Offset: 0x00070E5D
		[DataMember(Name = "Id", Order = 150, IsRequired = false)]
		public int Id { get; set; }

		// Token: 0x1700293C RID: 10556
		// (get) Token: 0x06008D71 RID: 36209 RVA: 0x00072C66 File Offset: 0x00070E66
		[IgnoreDataMember]
		[XmlIgnore]
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

		// Token: 0x06008D72 RID: 36210 RVA: 0x00072CA5 File Offset: 0x00070EA5
		public Geometry ToGeometry()
		{
			return new Polygon(new LinearRing((from item in this.Points
			select new Coordinate((double)item.X, (double)item.Y)).ToArray<Coordinate>()));
		}
	}
}

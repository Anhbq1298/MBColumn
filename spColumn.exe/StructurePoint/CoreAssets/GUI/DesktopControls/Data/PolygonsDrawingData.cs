using System;
using System.Collections.Generic;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A2A RID: 2602
	public sealed class PolygonsDrawingData
	{
		// Token: 0x06005622 RID: 22050 RVA: 0x001657FC File Offset: 0x001639FC
		public PolygonsDrawingData(PolygonDrawingData polygonDrawingData, LineFormat outerLineFormat, Color? outerSurfacesFillColor, double? height, double? verticalOffsetOfShape, double? verticalOffsetOfEdge, double? verticalOffsetOfNode)
		{
			#X0d.#V0d(polygonDrawingData, #Phc.#3hc(107429472), Component.DesktopControls, #Phc.#3hc(107429447));
			this.Polygons = new List<PolygonDrawingData>
			{
				polygonDrawingData
			}.AsReadOnly();
			this.OuterLinesFormat = outerLineFormat;
			this.OuterSurfacesFillColor = outerSurfacesFillColor;
			this.Height = height;
			this.VerticalOffsetOfShape = verticalOffsetOfShape;
			this.VerticalOffsetOfEdge = verticalOffsetOfEdge;
			this.VerticalOffsetOfNode = verticalOffsetOfNode;
		}

		// Token: 0x06005623 RID: 22051 RVA: 0x00165870 File Offset: 0x00163A70
		public PolygonsDrawingData(PolygonDrawingData polygonDrawingData, LineFormat outerLineFormat, Color fillColor) : this(polygonDrawingData, outerLineFormat, new Color?(fillColor), null, null, null, null)
		{
		}

		// Token: 0x06005624 RID: 22052 RVA: 0x000475D9 File Offset: 0x000457D9
		public PolygonsDrawingData(IEnumerable<PolygonDrawingData> polygons)
		{
			this.Polygons = new List<PolygonDrawingData>(polygons).AsReadOnly();
		}

		// Token: 0x06005625 RID: 22053 RVA: 0x001658B0 File Offset: 0x00163AB0
		public PolygonsDrawingData(PolygonDrawingData polygonDrawingData) : this(polygonDrawingData, null, null, null, null, null, null)
		{
		}

		// Token: 0x170018CD RID: 6349
		// (get) Token: 0x06005626 RID: 22054 RVA: 0x000475F2 File Offset: 0x000457F2
		// (set) Token: 0x06005627 RID: 22055 RVA: 0x000475FE File Offset: 0x000457FE
		public IReadOnlyList<PolygonDrawingData> Polygons { get; private set; }

		// Token: 0x170018CE RID: 6350
		// (get) Token: 0x06005628 RID: 22056 RVA: 0x0004760F File Offset: 0x0004580F
		// (set) Token: 0x06005629 RID: 22057 RVA: 0x0004761B File Offset: 0x0004581B
		public Color? OuterSurfacesFillColor { get; set; }

		// Token: 0x170018CF RID: 6351
		// (get) Token: 0x0600562A RID: 22058 RVA: 0x0004762C File Offset: 0x0004582C
		// (set) Token: 0x0600562B RID: 22059 RVA: 0x00047638 File Offset: 0x00045838
		public Color? InnerSurfacesFillColor { get; set; }

		// Token: 0x170018D0 RID: 6352
		// (get) Token: 0x0600562C RID: 22060 RVA: 0x00047649 File Offset: 0x00045849
		// (set) Token: 0x0600562D RID: 22061 RVA: 0x00047655 File Offset: 0x00045855
		public double? Height { get; set; }

		// Token: 0x170018D1 RID: 6353
		// (get) Token: 0x0600562E RID: 22062 RVA: 0x00047666 File Offset: 0x00045866
		// (set) Token: 0x0600562F RID: 22063 RVA: 0x00047672 File Offset: 0x00045872
		public double? VerticalOffsetOfShape { get; set; }

		// Token: 0x170018D2 RID: 6354
		// (get) Token: 0x06005630 RID: 22064 RVA: 0x00047683 File Offset: 0x00045883
		// (set) Token: 0x06005631 RID: 22065 RVA: 0x0004768F File Offset: 0x0004588F
		public double? VerticalOffsetOfEdge { get; set; }

		// Token: 0x170018D3 RID: 6355
		// (get) Token: 0x06005632 RID: 22066 RVA: 0x000476A0 File Offset: 0x000458A0
		// (set) Token: 0x06005633 RID: 22067 RVA: 0x000476AC File Offset: 0x000458AC
		public double? VerticalOffsetOfNode { get; set; }

		// Token: 0x170018D4 RID: 6356
		// (get) Token: 0x06005634 RID: 22068 RVA: 0x000476BD File Offset: 0x000458BD
		// (set) Token: 0x06005635 RID: 22069 RVA: 0x000476C9 File Offset: 0x000458C9
		public double? PointSize { get; set; }

		// Token: 0x170018D5 RID: 6357
		// (get) Token: 0x06005636 RID: 22070 RVA: 0x000476DA File Offset: 0x000458DA
		// (set) Token: 0x06005637 RID: 22071 RVA: 0x000476E6 File Offset: 0x000458E6
		public Color? PointColor { get; set; }

		// Token: 0x170018D6 RID: 6358
		// (get) Token: 0x06005638 RID: 22072 RVA: 0x000476F7 File Offset: 0x000458F7
		// (set) Token: 0x06005639 RID: 22073 RVA: 0x00047703 File Offset: 0x00045903
		public LineFormat InnerLinesFormat { get; set; }

		// Token: 0x170018D7 RID: 6359
		// (get) Token: 0x0600563A RID: 22074 RVA: 0x00047714 File Offset: 0x00045914
		// (set) Token: 0x0600563B RID: 22075 RVA: 0x00047720 File Offset: 0x00045920
		public LineFormat OuterLinesFormat { get; set; }

		// Token: 0x170018D8 RID: 6360
		// (get) Token: 0x0600563C RID: 22076 RVA: 0x00047731 File Offset: 0x00045931
		// (set) Token: 0x0600563D RID: 22077 RVA: 0x0004773D File Offset: 0x0004593D
		public double PointsOffset { get; set; }
	}
}

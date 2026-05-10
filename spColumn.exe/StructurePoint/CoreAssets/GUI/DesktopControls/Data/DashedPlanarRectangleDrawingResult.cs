using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A1C RID: 2588
	public sealed class DashedPlanarRectangleDrawingResult : DrawingResultBase, IDrawingResult, IDashedPlanarRectangleDrawingResult
	{
		// Token: 0x06005571 RID: 21873 RVA: 0x00046CF6 File Offset: 0x00044EF6
		public DashedPlanarRectangleDrawingResult(bool drawBoundingPolyline)
		{
			this.DrawBoundingPolyline = drawBoundingPolyline;
			this.RectangleVisual = new PlanarRectangleVisual3D();
			if (this.DrawBoundingPolyline)
			{
				this.DashedMultilineDrawingResult = new DashedMultilineDrawingResult();
			}
		}

		// Token: 0x1700189E RID: 6302
		// (get) Token: 0x06005572 RID: 21874 RVA: 0x00046D23 File Offset: 0x00044F23
		// (set) Token: 0x06005573 RID: 21875 RVA: 0x00046D2F File Offset: 0x00044F2F
		private PlanarRectangleVisual3D RectangleVisual { get; set; }

		// Token: 0x1700189F RID: 6303
		// (get) Token: 0x06005574 RID: 21876 RVA: 0x00046D40 File Offset: 0x00044F40
		// (set) Token: 0x06005575 RID: 21877 RVA: 0x00046D4C File Offset: 0x00044F4C
		private DashedMultilineDrawingResult DashedMultilineDrawingResult { get; set; }

		// Token: 0x170018A0 RID: 6304
		// (get) Token: 0x06005576 RID: 21878 RVA: 0x00046D5D File Offset: 0x00044F5D
		// (set) Token: 0x06005577 RID: 21879 RVA: 0x00046D69 File Offset: 0x00044F69
		public bool DrawBoundingPolyline { get; private set; }

		// Token: 0x170018A1 RID: 6305
		// (get) Token: 0x06005578 RID: 21880 RVA: 0x00046D7A File Offset: 0x00044F7A
		// (set) Token: 0x06005579 RID: 21881 RVA: 0x00046D93 File Offset: 0x00044F93
		public Point3D StartPoint
		{
			get
			{
				return this.RectangleVisual.StartPoint;
			}
			set
			{
				this.RectangleVisual.StartPoint = value;
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x170018A2 RID: 6306
		// (get) Token: 0x0600557A RID: 21882 RVA: 0x001653DC File Offset: 0x001635DC
		// (set) Token: 0x0600557B RID: 21883 RVA: 0x00046DB3 File Offset: 0x00044FB3
		public Point3D EndPoint
		{
			get
			{
				return this.RectangleVisual.EndPoint.GetValueOrDefault();
			}
			set
			{
				this.RectangleVisual.EndPoint = new Point3D?(value);
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x170018A3 RID: 6307
		// (get) Token: 0x0600557C RID: 21884 RVA: 0x00046DD8 File Offset: 0x00044FD8
		// (set) Token: 0x0600557D RID: 21885 RVA: 0x00046DF1 File Offset: 0x00044FF1
		public Color Color
		{
			get
			{
				return this.RectangleVisual.Color;
			}
			set
			{
				this.RectangleVisual.Color = value;
			}
		}

		// Token: 0x170018A4 RID: 6308
		// (get) Token: 0x0600557E RID: 21886 RVA: 0x00165408 File Offset: 0x00163608
		// (set) Token: 0x0600557F RID: 21887 RVA: 0x00046E0B File Offset: 0x0004500B
		public Color? LineColor
		{
			get
			{
				if (this.DashedMultilineDrawingResult == null)
				{
					return null;
				}
				return new Color?(this.DashedMultilineDrawingResult.LineColor);
			}
			set
			{
				if (this.DashedMultilineDrawingResult != null && value != null)
				{
					this.DashedMultilineDrawingResult.LineColor = value.Value;
				}
			}
		}

		// Token: 0x170018A5 RID: 6309
		// (get) Token: 0x06005580 RID: 21888 RVA: 0x00046E3C File Offset: 0x0004503C
		// (set) Token: 0x06005581 RID: 21889 RVA: 0x00046E67 File Offset: 0x00045067
		public double LineThickness
		{
			get
			{
				if (this.DashedMultilineDrawingResult == null)
				{
					return 0.0;
				}
				return this.DashedMultilineDrawingResult.LineThickness;
			}
			set
			{
				if (this.DashedMultilineDrawingResult != null)
				{
					this.DashedMultilineDrawingResult.LineThickness = value;
				}
			}
		}

		// Token: 0x170018A6 RID: 6310
		// (get) Token: 0x06005582 RID: 21890 RVA: 0x00046E89 File Offset: 0x00045089
		// (set) Token: 0x06005583 RID: 21891 RVA: 0x00046EA2 File Offset: 0x000450A2
		public double SegmentLength
		{
			get
			{
				return this.DashedMultilineDrawingResult.SegmentLength;
			}
			set
			{
				this.DashedMultilineDrawingResult.SegmentLength = value;
			}
		}

		// Token: 0x06005584 RID: 21892 RVA: 0x00046EBC File Offset: 0x000450BC
		public IEnumerable<Point3D> CalculatePoints()
		{
			return this.RectangleVisual.ConstructRectangle();
		}

		// Token: 0x06005585 RID: 21893 RVA: 0x00165444 File Offset: 0x00163644
		private void MyUpdatePolyline()
		{
			if (this.DashedMultilineDrawingResult != null && this.RectangleVisual.EndPoint != null)
			{
				this.DashedMultilineDrawingResult.Positions = GeometryHelper.#7nc(this.StartPoint, this.EndPoint);
			}
		}

		// Token: 0x06005586 RID: 21894 RVA: 0x00165498 File Offset: 0x00163698
		protected internal override IEnumerable<object> RetrieveDisplayedObjects()
		{
			List<object> list = new List<object>();
			object rectangleVisual = this.RectangleVisual;
			if (!false)
			{
				list.Add(rectangleVisual);
			}
			List<object> list2 = list;
			if (this.DashedMultilineDrawingResult != null)
			{
				list2.AddRange(this.DashedMultilineDrawingResult.RetrieveDisplayedObjects());
			}
			return list2;
		}
	}
}

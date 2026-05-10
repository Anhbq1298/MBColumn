using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A24 RID: 2596
	public sealed class PlanarRectangleDrawingResult : DrawingResultBase, IDrawingResult, IPlanarRectangleDrawingResult
	{
		// Token: 0x060055DD RID: 21981 RVA: 0x00046FE6 File Offset: 0x000451E6
		public PlanarRectangleDrawingResult(bool drawBoundingPolyline)
		{
			this.DrawBoundingPolyline = drawBoundingPolyline;
			this.RectangleVisual = new PlanarRectangleVisual3D();
			if (this.DrawBoundingPolyline)
			{
				this.PolylineDrawingResult = new PolylineDrawingResult();
			}
		}

		// Token: 0x170018B9 RID: 6329
		// (get) Token: 0x060055DE RID: 21982 RVA: 0x00047013 File Offset: 0x00045213
		// (set) Token: 0x060055DF RID: 21983 RVA: 0x0004701F File Offset: 0x0004521F
		private PlanarRectangleVisual3D RectangleVisual { get; set; }

		// Token: 0x170018BA RID: 6330
		// (get) Token: 0x060055E0 RID: 21984 RVA: 0x00047030 File Offset: 0x00045230
		// (set) Token: 0x060055E1 RID: 21985 RVA: 0x0004703C File Offset: 0x0004523C
		private PolylineDrawingResult PolylineDrawingResult { get; set; }

		// Token: 0x170018BB RID: 6331
		// (get) Token: 0x060055E2 RID: 21986 RVA: 0x0004704D File Offset: 0x0004524D
		// (set) Token: 0x060055E3 RID: 21987 RVA: 0x00047059 File Offset: 0x00045259
		public bool DrawBoundingPolyline { get; private set; }

		// Token: 0x170018BC RID: 6332
		// (get) Token: 0x060055E4 RID: 21988 RVA: 0x0004706A File Offset: 0x0004526A
		// (set) Token: 0x060055E5 RID: 21989 RVA: 0x00047083 File Offset: 0x00045283
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

		// Token: 0x170018BD RID: 6333
		// (get) Token: 0x060055E6 RID: 21990 RVA: 0x001654E0 File Offset: 0x001636E0
		// (set) Token: 0x060055E7 RID: 21991 RVA: 0x000470A3 File Offset: 0x000452A3
		public Point3D EndPoint
		{
			get
			{
				Point3D? endPoint = this.RectangleVisual.EndPoint;
				if (endPoint == null)
				{
					return this.StartPoint;
				}
				return this.RectangleVisual.EndPoint.Value;
			}
			set
			{
				this.RectangleVisual.EndPoint = new Point3D?(value);
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x170018BE RID: 6334
		// (get) Token: 0x060055E8 RID: 21992 RVA: 0x000470C8 File Offset: 0x000452C8
		// (set) Token: 0x060055E9 RID: 21993 RVA: 0x000470E1 File Offset: 0x000452E1
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

		// Token: 0x170018BF RID: 6335
		// (get) Token: 0x060055EA RID: 21994 RVA: 0x00165528 File Offset: 0x00163728
		// (set) Token: 0x060055EB RID: 21995 RVA: 0x000470FB File Offset: 0x000452FB
		public Color? LineColor
		{
			get
			{
				if (this.PolylineDrawingResult == null)
				{
					return null;
				}
				return new Color?(this.PolylineDrawingResult.LineColor);
			}
			set
			{
				if (this.PolylineDrawingResult != null && value != null)
				{
					this.PolylineDrawingResult.LineColor = value.Value;
				}
			}
		}

		// Token: 0x170018C0 RID: 6336
		// (get) Token: 0x060055EC RID: 21996 RVA: 0x0004712C File Offset: 0x0004532C
		// (set) Token: 0x060055ED RID: 21997 RVA: 0x00047157 File Offset: 0x00045357
		public double LineThickness
		{
			get
			{
				if (this.PolylineDrawingResult == null)
				{
					return 0.0;
				}
				return this.PolylineDrawingResult.LineThickness;
			}
			set
			{
				if (this.PolylineDrawingResult != null)
				{
					this.PolylineDrawingResult.LineThickness = value;
				}
			}
		}

		// Token: 0x060055EE RID: 21998 RVA: 0x00047179 File Offset: 0x00045379
		public IEnumerable<Point3D> CalculatePoints()
		{
			return this.RectangleVisual.ConstructRectangle();
		}

		// Token: 0x060055EF RID: 21999 RVA: 0x00047192 File Offset: 0x00045392
		private void MyUpdatePolyline()
		{
			if (this.PolylineDrawingResult != null)
			{
				this.PolylineDrawingResult.Positions = this.RectangleVisual.ConstructRectangle();
			}
		}

		// Token: 0x060055F0 RID: 22000 RVA: 0x00165564 File Offset: 0x00163764
		protected internal override IEnumerable<object> RetrieveDisplayedObjects()
		{
			List<object> list = new List<object>();
			object rectangleVisual = this.RectangleVisual;
			if (!false)
			{
				list.Add(rectangleVisual);
			}
			List<object> list2 = list;
			if (this.PolylineDrawingResult != null)
			{
				list2.AddRange(this.PolylineDrawingResult.RetrieveDisplayedObjects());
			}
			return list2;
		}
	}
}

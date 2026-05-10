using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F9 RID: 2553
	[CLSCompliant(false)]
	public class PlanarCircleDrawingResult : DrawingResultBase, IEditableObject, IDrawingResult, IPlanarCircleDrawingResult
	{
		// Token: 0x060053EF RID: 21487 RVA: 0x0004581D File Offset: 0x00043A1D
		public PlanarCircleDrawingResult(bool drawBoundingPolyline)
		{
			this.DrawBoundingPolyline = drawBoundingPolyline;
			this.PlanarCircleVisual = new PlanarApproximatedCircleVisual3D();
			if (this.DrawBoundingPolyline)
			{
				this.PolylineDrawingResult = new PolylineDrawingResult();
			}
		}

		// Token: 0x17001806 RID: 6150
		// (get) Token: 0x060053F0 RID: 21488 RVA: 0x0004584A File Offset: 0x00043A4A
		// (set) Token: 0x060053F1 RID: 21489 RVA: 0x00045856 File Offset: 0x00043A56
		protected PlanarApproximatedCircleVisual3D PlanarCircleVisual { get; set; }

		// Token: 0x17001807 RID: 6151
		// (get) Token: 0x060053F2 RID: 21490 RVA: 0x00045867 File Offset: 0x00043A67
		// (set) Token: 0x060053F3 RID: 21491 RVA: 0x00045873 File Offset: 0x00043A73
		private PolylineDrawingResult PolylineDrawingResult { get; set; }

		// Token: 0x17001808 RID: 6152
		// (get) Token: 0x060053F4 RID: 21492 RVA: 0x00045884 File Offset: 0x00043A84
		// (set) Token: 0x060053F5 RID: 21493 RVA: 0x00045890 File Offset: 0x00043A90
		public bool DrawBoundingPolyline { get; private set; }

		// Token: 0x17001809 RID: 6153
		// (get) Token: 0x060053F6 RID: 21494 RVA: 0x000458A1 File Offset: 0x00043AA1
		// (set) Token: 0x060053F7 RID: 21495 RVA: 0x000458BA File Offset: 0x00043ABA
		public Point3D Center
		{
			get
			{
				return this.PlanarCircleVisual.Center;
			}
			set
			{
				this.PlanarCircleVisual.Center = value;
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x1700180A RID: 6154
		// (get) Token: 0x060053F8 RID: 21496 RVA: 0x000458DA File Offset: 0x00043ADA
		// (set) Token: 0x060053F9 RID: 21497 RVA: 0x000458F3 File Offset: 0x00043AF3
		public int NumberOfSides
		{
			get
			{
				return this.PlanarCircleVisual.NumberOfSides;
			}
			set
			{
				this.PlanarCircleVisual.NumberOfSides = value;
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x1700180B RID: 6155
		// (get) Token: 0x060053FA RID: 21498 RVA: 0x00045913 File Offset: 0x00043B13
		// (set) Token: 0x060053FB RID: 21499 RVA: 0x0004592C File Offset: 0x00043B2C
		public double Radius
		{
			get
			{
				return this.PlanarCircleVisual.Radius;
			}
			set
			{
				this.PlanarCircleVisual.Radius = value;
				this.MyUpdatePolyline();
			}
		}

		// Token: 0x1700180C RID: 6156
		// (get) Token: 0x060053FC RID: 21500 RVA: 0x0004594C File Offset: 0x00043B4C
		// (set) Token: 0x060053FD RID: 21501 RVA: 0x00045965 File Offset: 0x00043B65
		public Color Color
		{
			get
			{
				return this.PlanarCircleVisual.Color;
			}
			set
			{
				this.PlanarCircleVisual.Color = value;
			}
		}

		// Token: 0x1700180D RID: 6157
		// (get) Token: 0x060053FE RID: 21502 RVA: 0x00164454 File Offset: 0x00162654
		// (set) Token: 0x060053FF RID: 21503 RVA: 0x0004597F File Offset: 0x00043B7F
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

		// Token: 0x1700180E RID: 6158
		// (get) Token: 0x06005400 RID: 21504 RVA: 0x000459B0 File Offset: 0x00043BB0
		// (set) Token: 0x06005401 RID: 21505 RVA: 0x000459DB File Offset: 0x00043BDB
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

		// Token: 0x06005402 RID: 21506 RVA: 0x000459FD File Offset: 0x00043BFD
		public IEnumerable<Point3D> CalculatePoints()
		{
			return this.PlanarCircleVisual.ApproximateCircle();
		}

		// Token: 0x06005403 RID: 21507 RVA: 0x00045A16 File Offset: 0x00043C16
		public void BeginEdit()
		{
			this.PlanarCircleVisual.BeginEdit();
			if (this.DrawBoundingPolyline)
			{
				this.PolylineDrawingResult.BeginEdit();
			}
		}

		// Token: 0x06005404 RID: 21508 RVA: 0x00045A42 File Offset: 0x00043C42
		public void EndEdit()
		{
			this.PlanarCircleVisual.EndEdit();
			this.PolylineDrawingResult.EndEdit();
		}

		// Token: 0x06005405 RID: 21509 RVA: 0x00045A66 File Offset: 0x00043C66
		public void CancelEdit()
		{
			this.PlanarCircleVisual.CancelEdit();
			this.PolylineDrawingResult.CancelEdit();
		}

		// Token: 0x06005406 RID: 21510 RVA: 0x00045A8A File Offset: 0x00043C8A
		protected void MyUpdatePolyline()
		{
			if (this.DrawBoundingPolyline)
			{
				this.PolylineDrawingResult.Positions = this.PlanarCircleVisual.ApproximateCircle();
			}
		}

		// Token: 0x06005407 RID: 21511 RVA: 0x00164490 File Offset: 0x00162690
		protected internal override IEnumerable<object> RetrieveDisplayedObjects()
		{
			List<object> list = new List<object>();
			object planarCircleVisual = this.PlanarCircleVisual;
			if (!false)
			{
				list.Add(planarCircleVisual);
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

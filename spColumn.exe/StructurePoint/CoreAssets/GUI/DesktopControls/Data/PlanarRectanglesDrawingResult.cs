using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FD RID: 2557
	public sealed class PlanarRectanglesDrawingResult : DrawingResultBase, IDrawingResult, IPlanarRectanglesDrawingResult
	{
		// Token: 0x06005421 RID: 21537 RVA: 0x00045AB6 File Offset: 0x00043CB6
		public PlanarRectanglesDrawingResult()
		{
			this.PlanarRectanglesMeshElement = new PlanarRectanglesMeshElement3D();
		}

		// Token: 0x06005422 RID: 21538 RVA: 0x00045AC9 File Offset: 0x00043CC9
		protected internal override object RetrieveDisplayedObject()
		{
			return this.PlanarRectanglesMeshElement;
		}

		// Token: 0x1700181C RID: 6172
		// (get) Token: 0x06005423 RID: 21539 RVA: 0x00045AD9 File Offset: 0x00043CD9
		// (set) Token: 0x06005424 RID: 21540 RVA: 0x00045AE5 File Offset: 0x00043CE5
		private PlanarRectanglesMeshElement3D PlanarRectanglesMeshElement { get; set; }

		// Token: 0x1700181D RID: 6173
		// (get) Token: 0x06005425 RID: 21541 RVA: 0x00045AF6 File Offset: 0x00043CF6
		// (set) Token: 0x06005426 RID: 21542 RVA: 0x00045B02 File Offset: 0x00043D02
		public double Width
		{
			get
			{
				return this.width;
			}
			set
			{
				if (this.width != value)
				{
					this.width = value;
					this.PlanarRectanglesMeshElement.Width = value;
				}
			}
		}

		// Token: 0x1700181E RID: 6174
		// (get) Token: 0x06005427 RID: 21543 RVA: 0x00045B2C File Offset: 0x00043D2C
		// (set) Token: 0x06005428 RID: 21544 RVA: 0x00045B38 File Offset: 0x00043D38
		public double Height
		{
			get
			{
				return this.height;
			}
			set
			{
				if (this.height != value)
				{
					this.height = value;
					this.PlanarRectanglesMeshElement.Height = value;
				}
			}
		}

		// Token: 0x1700181F RID: 6175
		// (get) Token: 0x06005429 RID: 21545 RVA: 0x00045B62 File Offset: 0x00043D62
		// (set) Token: 0x0600542A RID: 21546 RVA: 0x00045B6E File Offset: 0x00043D6E
		public IEnumerable<Point3D> CenterPoints
		{
			get
			{
				return this.centerPoints;
			}
			set
			{
				if (this.centerPoints != value)
				{
					this.centerPoints = value;
					this.PlanarRectanglesMeshElement.CenterPoints = value;
				}
			}
		}

		// Token: 0x17001820 RID: 6176
		// (get) Token: 0x0600542B RID: 21547 RVA: 0x00045B98 File Offset: 0x00043D98
		// (set) Token: 0x0600542C RID: 21548 RVA: 0x00045BA4 File Offset: 0x00043DA4
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				if (this.color != value)
				{
					this.color = value;
					this.PlanarRectanglesMeshElement.Fill = new SolidColorBrush(value);
				}
			}
		}

		// Token: 0x17001821 RID: 6177
		// (get) Token: 0x0600542D RID: 21549 RVA: 0x00045BD8 File Offset: 0x00043DD8
		public IEnumerable<PolyLine3D> Polylines
		{
			get
			{
				return this.PlanarRectanglesMeshElement.Polylines;
			}
		}

		// Token: 0x04002432 RID: 9266
		private double width;

		// Token: 0x04002433 RID: 9267
		private double height;

		// Token: 0x04002434 RID: 9268
		private IEnumerable<Point3D> centerPoints;

		// Token: 0x04002435 RID: 9269
		private Color color;
	}
}

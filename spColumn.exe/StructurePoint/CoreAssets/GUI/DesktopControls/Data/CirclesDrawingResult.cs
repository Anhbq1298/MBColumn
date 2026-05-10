using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A04 RID: 2564
	public sealed class CirclesDrawingResult : DrawingResultBase, IDrawingResult, ICirclesDrawingResult
	{
		// Token: 0x0600546E RID: 21614 RVA: 0x00045F8F File Offset: 0x0004418F
		public CirclesDrawingResult()
		{
			this.CirclesMeshElement = new CirclesMeshElement3D();
		}

		// Token: 0x1700183D RID: 6205
		// (get) Token: 0x0600546F RID: 21615 RVA: 0x00045FA2 File Offset: 0x000441A2
		// (set) Token: 0x06005470 RID: 21616 RVA: 0x00045FAE File Offset: 0x000441AE
		private CirclesMeshElement3D CirclesMeshElement { get; set; }

		// Token: 0x1700183E RID: 6206
		// (get) Token: 0x06005471 RID: 21617 RVA: 0x00045FBF File Offset: 0x000441BF
		// (set) Token: 0x06005472 RID: 21618 RVA: 0x00045FDD File Offset: 0x000441DD
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public IList<Point3D> Points
		{
			get
			{
				return this.CirclesMeshElement.Points.Convert();
			}
			set
			{
				this.CirclesMeshElement.Points = value.Convert();
			}
		}

		// Token: 0x1700183F RID: 6207
		// (get) Token: 0x06005473 RID: 21619 RVA: 0x00045FFC File Offset: 0x000441FC
		// (set) Token: 0x06005474 RID: 21620 RVA: 0x00046007 File Offset: 0x00044207
		public Color Color
		{
			get
			{
				return Colors.Transparent;
			}
			set
			{
				this.CirclesMeshElement.Fill = new SolidColorBrush(value);
			}
		}

		// Token: 0x17001840 RID: 6208
		// (get) Token: 0x06005475 RID: 21621 RVA: 0x00046026 File Offset: 0x00044226
		// (set) Token: 0x06005476 RID: 21622 RVA: 0x0004603F File Offset: 0x0004423F
		public double Radius
		{
			get
			{
				return this.CirclesMeshElement.Radius;
			}
			set
			{
				this.CirclesMeshElement.Radius = value;
			}
		}

		// Token: 0x17001841 RID: 6209
		// (get) Token: 0x06005477 RID: 21623 RVA: 0x00046059 File Offset: 0x00044259
		// (set) Token: 0x06005478 RID: 21624 RVA: 0x00046072 File Offset: 0x00044272
		public int Sides
		{
			get
			{
				return this.CirclesMeshElement.Sides;
			}
			set
			{
				this.CirclesMeshElement.Sides = value;
			}
		}

		// Token: 0x17001842 RID: 6210
		// (get) Token: 0x06005479 RID: 21625 RVA: 0x0004608C File Offset: 0x0004428C
		public IEnumerable<PolyLine3D> Polylines
		{
			get
			{
				return this.CirclesMeshElement.Polylines;
			}
		}

		// Token: 0x17001843 RID: 6211
		// (get) Token: 0x0600547A RID: 21626 RVA: 0x000460A5 File Offset: 0x000442A5
		// (set) Token: 0x0600547B RID: 21627 RVA: 0x000460BE File Offset: 0x000442BE
		public bool GeneratePolylines
		{
			get
			{
				return this.CirclesMeshElement.GeneratePolylines;
			}
			set
			{
				this.CirclesMeshElement.GeneratePolylines = value;
			}
		}

		// Token: 0x0600547C RID: 21628 RVA: 0x000460D8 File Offset: 0x000442D8
		protected internal override object RetrieveDisplayedObject()
		{
			return this.CirclesMeshElement;
		}
	}
}

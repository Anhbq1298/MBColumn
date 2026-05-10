using System;
using System.Collections.Generic;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F6 RID: 2550
	public sealed class HTypeDrawingResult : DrawingResultBase, IDrawingResult, IHTypeDrawingResult
	{
		// Token: 0x060053CA RID: 21450 RVA: 0x00045609 File Offset: 0x00043809
		public HTypeDrawingResult()
		{
			this.MeshElement = new HTypeMeshElement3D();
		}

		// Token: 0x060053CB RID: 21451 RVA: 0x0004561C File Offset: 0x0004381C
		protected internal override object RetrieveDisplayedObject()
		{
			return this.MeshElement;
		}

		// Token: 0x170017F4 RID: 6132
		// (get) Token: 0x060053CC RID: 21452 RVA: 0x0004562C File Offset: 0x0004382C
		// (set) Token: 0x060053CD RID: 21453 RVA: 0x00045638 File Offset: 0x00043838
		private HTypeMeshElement3D MeshElement { get; set; }

		// Token: 0x170017F5 RID: 6133
		// (get) Token: 0x060053CE RID: 21454 RVA: 0x00045649 File Offset: 0x00043849
		// (set) Token: 0x060053CF RID: 21455 RVA: 0x00045662 File Offset: 0x00043862
		public IEnumerable<Point3D> CenterPoints
		{
			get
			{
				return this.MeshElement.CenterPoints;
			}
			set
			{
				this.MeshElement.CenterPoints = value;
			}
		}

		// Token: 0x170017F6 RID: 6134
		// (get) Token: 0x060053D0 RID: 21456 RVA: 0x0004567C File Offset: 0x0004387C
		// (set) Token: 0x060053D1 RID: 21457 RVA: 0x00045688 File Offset: 0x00043888
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
				this.MeshElement.Fill = new SolidColorBrush(value);
			}
		}

		// Token: 0x170017F7 RID: 6135
		// (get) Token: 0x060053D2 RID: 21458 RVA: 0x000456AE File Offset: 0x000438AE
		// (set) Token: 0x060053D3 RID: 21459 RVA: 0x000456C7 File Offset: 0x000438C7
		public double RotationAngle
		{
			get
			{
				return this.MeshElement.RotationAngle;
			}
			set
			{
				this.MeshElement.RotationAngle = value;
			}
		}

		// Token: 0x170017F8 RID: 6136
		// (get) Token: 0x060053D4 RID: 21460 RVA: 0x000456E1 File Offset: 0x000438E1
		// (set) Token: 0x060053D5 RID: 21461 RVA: 0x000456FA File Offset: 0x000438FA
		public double WebThickness
		{
			get
			{
				return this.MeshElement.WebThickness;
			}
			set
			{
				this.MeshElement.WebThickness = value;
			}
		}

		// Token: 0x170017F9 RID: 6137
		// (get) Token: 0x060053D6 RID: 21462 RVA: 0x00045714 File Offset: 0x00043914
		// (set) Token: 0x060053D7 RID: 21463 RVA: 0x0004572D File Offset: 0x0004392D
		public double WebWeight
		{
			get
			{
				return this.MeshElement.WebHeight;
			}
			set
			{
				this.MeshElement.WebHeight = value;
			}
		}

		// Token: 0x170017FA RID: 6138
		// (get) Token: 0x060053D8 RID: 21464 RVA: 0x00045747 File Offset: 0x00043947
		// (set) Token: 0x060053D9 RID: 21465 RVA: 0x00045760 File Offset: 0x00043960
		public double FlangeThickness
		{
			get
			{
				return this.MeshElement.FlangeThickness;
			}
			set
			{
				this.MeshElement.FlangeThickness = value;
			}
		}

		// Token: 0x170017FB RID: 6139
		// (get) Token: 0x060053DA RID: 21466 RVA: 0x0004577A File Offset: 0x0004397A
		// (set) Token: 0x060053DB RID: 21467 RVA: 0x00045793 File Offset: 0x00043993
		public double FlangeWidth
		{
			get
			{
				return this.MeshElement.FlangeWidth;
			}
			set
			{
				this.MeshElement.FlangeWidth = value;
			}
		}

		// Token: 0x170017FC RID: 6140
		// (get) Token: 0x060053DC RID: 21468 RVA: 0x000457AD File Offset: 0x000439AD
		public IEnumerable<PolyLine3D> Polylines
		{
			get
			{
				return this.MeshElement.Polylines;
			}
		}

		// Token: 0x0400242D RID: 9261
		private Color color;
	}
}

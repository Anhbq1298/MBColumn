using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A00 RID: 2560
	public sealed class ArrowDrawingResult : DrawingResultBase, IDrawingResult, IArrowDrawingResult
	{
		// Token: 0x0600543B RID: 21563 RVA: 0x00045D09 File Offset: 0x00043F09
		public ArrowDrawingResult()
		{
			this.ArrowVisual = new ArrowVisual3D();
		}

		// Token: 0x17001827 RID: 6183
		// (get) Token: 0x0600543C RID: 21564 RVA: 0x00045D1C File Offset: 0x00043F1C
		// (set) Token: 0x0600543D RID: 21565 RVA: 0x00045D28 File Offset: 0x00043F28
		internal ArrowVisual3D ArrowVisual { get; private set; }

		// Token: 0x17001828 RID: 6184
		// (get) Token: 0x0600543E RID: 21566 RVA: 0x00045D39 File Offset: 0x00043F39
		// (set) Token: 0x0600543F RID: 21567 RVA: 0x00045D52 File Offset: 0x00043F52
		public double ArrowAngle
		{
			get
			{
				return this.ArrowVisual.ArrowAngle;
			}
			set
			{
				this.ArrowVisual.ArrowAngle = value;
			}
		}

		// Token: 0x17001829 RID: 6185
		// (get) Token: 0x06005440 RID: 21568 RVA: 0x00045D6C File Offset: 0x00043F6C
		// (set) Token: 0x06005441 RID: 21569 RVA: 0x00045D85 File Offset: 0x00043F85
		public double ArrowRadius
		{
			get
			{
				return this.ArrowVisual.ArrowRadius;
			}
			set
			{
				this.ArrowVisual.ArrowRadius = value;
			}
		}

		// Token: 0x1700182A RID: 6186
		// (get) Token: 0x06005442 RID: 21570 RVA: 0x00045D9F File Offset: 0x00043F9F
		// (set) Token: 0x06005443 RID: 21571 RVA: 0x00045DB8 File Offset: 0x00043FB8
		public double Radius
		{
			get
			{
				return this.ArrowVisual.Radius;
			}
			set
			{
				this.ArrowVisual.Radius = value;
			}
		}

		// Token: 0x1700182B RID: 6187
		// (get) Token: 0x06005444 RID: 21572 RVA: 0x00045DD2 File Offset: 0x00043FD2
		// (set) Token: 0x06005445 RID: 21573 RVA: 0x00045DF0 File Offset: 0x00043FF0
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D StartPosition
		{
			get
			{
				return this.ArrowVisual.StartPosition.Convert();
			}
			set
			{
				this.ArrowVisual.StartPosition = value.Convert();
			}
		}

		// Token: 0x1700182C RID: 6188
		// (get) Token: 0x06005446 RID: 21574 RVA: 0x00045E0F File Offset: 0x0004400F
		// (set) Token: 0x06005447 RID: 21575 RVA: 0x00045E2D File Offset: 0x0004402D
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D EndPosition
		{
			get
			{
				return this.ArrowVisual.EndPosition.Convert();
			}
			set
			{
				this.ArrowVisual.EndPosition = value.Convert();
			}
		}

		// Token: 0x1700182D RID: 6189
		// (get) Token: 0x06005448 RID: 21576 RVA: 0x00045E4C File Offset: 0x0004404C
		// (set) Token: 0x06005449 RID: 21577 RVA: 0x00164568 File Offset: 0x00162768
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
				DiffuseMaterial diffuseMaterial = new DiffuseMaterial(new SolidColorBrush(value));
				this.ArrowVisual.Material = diffuseMaterial;
				this.ArrowVisual.BackMaterial = diffuseMaterial;
			}
		}

		// Token: 0x0600544A RID: 21578 RVA: 0x00045E58 File Offset: 0x00044058
		protected internal override object RetrieveDisplayedObject()
		{
			return this.ArrowVisual;
		}

		// Token: 0x0400243C RID: 9276
		private Color color;
	}
}

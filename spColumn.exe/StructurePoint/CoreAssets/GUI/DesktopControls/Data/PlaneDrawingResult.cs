using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0A RID: 2570
	public sealed class PlaneDrawingResult : DrawingResultBase, IDrawingResult, IPlaneDrawingResult
	{
		// Token: 0x060054AD RID: 21677 RVA: 0x00046222 File Offset: 0x00044422
		public PlaneDrawingResult()
		{
			this.PlaneVisual = new PlaneVisual3D();
		}

		// Token: 0x17001858 RID: 6232
		// (get) Token: 0x060054AE RID: 21678 RVA: 0x00046235 File Offset: 0x00044435
		// (set) Token: 0x060054AF RID: 21679 RVA: 0x00046241 File Offset: 0x00044441
		internal PlaneVisual3D PlaneVisual { get; private set; }

		// Token: 0x17001859 RID: 6233
		// (get) Token: 0x060054B0 RID: 21680 RVA: 0x00046252 File Offset: 0x00044452
		// (set) Token: 0x060054B1 RID: 21681 RVA: 0x00046270 File Offset: 0x00044470
		public #c4d Normal
		{
			get
			{
				return this.PlaneVisual.Normal.Convert();
			}
			set
			{
				this.PlaneVisual.Normal = value.Convert();
			}
		}

		// Token: 0x1700185A RID: 6234
		// (get) Token: 0x060054B2 RID: 21682 RVA: 0x0004628F File Offset: 0x0004448F
		// (set) Token: 0x060054B3 RID: 21683 RVA: 0x000462AD File Offset: 0x000444AD
		public #c4d HeightDirection
		{
			get
			{
				return this.PlaneVisual.HeightDirection.Convert();
			}
			set
			{
				this.PlaneVisual.HeightDirection = value.Convert();
			}
		}

		// Token: 0x1700185B RID: 6235
		// (get) Token: 0x060054B4 RID: 21684 RVA: 0x000462CC File Offset: 0x000444CC
		// (set) Token: 0x060054B5 RID: 21685 RVA: 0x000462EA File Offset: 0x000444EA
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D CenterPosition
		{
			get
			{
				return this.PlaneVisual.CenterPosition.Convert();
			}
			set
			{
				this.PlaneVisual.CenterPosition = value.Convert();
			}
		}

		// Token: 0x1700185C RID: 6236
		// (get) Token: 0x060054B6 RID: 21686 RVA: 0x00046309 File Offset: 0x00044509
		// (set) Token: 0x060054B7 RID: 21687 RVA: 0x00046327 File Offset: 0x00044527
		public Size Size
		{
			get
			{
				return this.PlaneVisual.Size.Convert();
			}
			set
			{
				this.PlaneVisual.Size = value.Convert();
			}
		}

		// Token: 0x1700185D RID: 6237
		// (get) Token: 0x060054B8 RID: 21688 RVA: 0x00046346 File Offset: 0x00044546
		// (set) Token: 0x060054B9 RID: 21689 RVA: 0x00164AF8 File Offset: 0x00162CF8
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
				this.PlaneVisual.Material = diffuseMaterial;
				this.PlaneVisual.BackMaterial = diffuseMaterial;
			}
		}

		// Token: 0x060054BA RID: 21690 RVA: 0x00046352 File Offset: 0x00044552
		protected internal override object RetrieveDisplayedObject()
		{
			return this.PlaneVisual;
		}

		// Token: 0x04002445 RID: 9285
		private Color color;
	}
}

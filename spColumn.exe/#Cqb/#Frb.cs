using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace #Cqb
{
	// Token: 0x02000470 RID: 1136
	internal sealed class #Frb
	{
		// Token: 0x060029F4 RID: 10740 RVA: 0x00026468 File Offset: 0x00024668
		public #Frb(ISphereDrawingResult #Grb, LoadPointData #Hrb, double #Irb)
		{
			this.#a = #Grb;
			this.#c = #Hrb;
			this.DistanceRadiusScaleFactor = #Irb;
		}

		// Token: 0x17000E62 RID: 3682
		// (get) Token: 0x060029F5 RID: 10741 RVA: 0x00026485 File Offset: 0x00024685
		public ISphereDrawingResult SphereDrawingResult { get; }

		// Token: 0x17000E63 RID: 3683
		// (get) Token: 0x060029F6 RID: 10742 RVA: 0x00026491 File Offset: 0x00024691
		// (set) Token: 0x060029F7 RID: 10743 RVA: 0x0002649D File Offset: 0x0002469D
		public double DistanceRadiusScaleFactor { get; set; }

		// Token: 0x17000E64 RID: 3684
		// (get) Token: 0x060029F8 RID: 10744 RVA: 0x000264AE File Offset: 0x000246AE
		public LoadPointData LoadPointData { get; }

		// Token: 0x17000E65 RID: 3685
		// (get) Token: 0x060029F9 RID: 10745 RVA: 0x000264BA File Offset: 0x000246BA
		// (set) Token: 0x060029FA RID: 10746 RVA: 0x000264D3 File Offset: 0x000246D3
		public Color Color
		{
			get
			{
				return this.SphereDrawingResult.Color;
			}
			set
			{
				this.SphereDrawingResult.Color = value;
			}
		}

		// Token: 0x17000E66 RID: 3686
		// (get) Token: 0x060029FB RID: 10747 RVA: 0x000264ED File Offset: 0x000246ED
		// (set) Token: 0x060029FC RID: 10748 RVA: 0x00026506 File Offset: 0x00024706
		public Point3D Center
		{
			get
			{
				return this.SphereDrawingResult.Center;
			}
			set
			{
				this.SphereDrawingResult.Center = value;
			}
		}

		// Token: 0x17000E67 RID: 3687
		// (get) Token: 0x060029FD RID: 10749 RVA: 0x00026520 File Offset: 0x00024720
		// (set) Token: 0x060029FE RID: 10750 RVA: 0x00026539 File Offset: 0x00024739
		public double Radius
		{
			get
			{
				return this.SphereDrawingResult.Radius;
			}
			set
			{
				if (!double.IsNaN(value))
				{
					this.SphereDrawingResult.Radius = value;
				}
			}
		}

		// Token: 0x040010B7 RID: 4279
		[CompilerGenerated]
		private readonly ISphereDrawingResult #a;

		// Token: 0x040010B8 RID: 4280
		[CompilerGenerated]
		private double #b;

		// Token: 0x040010B9 RID: 4281
		[CompilerGenerated]
		private readonly LoadPointData #c;
	}
}

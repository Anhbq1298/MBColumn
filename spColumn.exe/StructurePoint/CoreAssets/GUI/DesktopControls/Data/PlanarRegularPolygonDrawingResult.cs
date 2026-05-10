using System;
using System.ComponentModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F8 RID: 2552
	[CLSCompliant(false)]
	public sealed class PlanarRegularPolygonDrawingResult : PlanarCircleDrawingResult, IEditableObject, IDrawingResult, IPlanarCircleDrawingResult, IPlanarRegularPolygonDrawingResult
	{
		// Token: 0x060053EC RID: 21484 RVA: 0x000457C6 File Offset: 0x000439C6
		public PlanarRegularPolygonDrawingResult(bool drawBoundingPolyline) : base(drawBoundingPolyline)
		{
			base.PlanarCircleVisual = new PlanarApproximatedRegularPolygonVisual3D();
		}

		// Token: 0x17001805 RID: 6149
		// (get) Token: 0x060053ED RID: 21485 RVA: 0x000457DA File Offset: 0x000439DA
		// (set) Token: 0x060053EE RID: 21486 RVA: 0x000457F8 File Offset: 0x000439F8
		public double Angle
		{
			get
			{
				return ((PlanarApproximatedRegularPolygonVisual3D)base.PlanarCircleVisual).Angle;
			}
			set
			{
				((PlanarApproximatedRegularPolygonVisual3D)base.PlanarCircleVisual).Angle = value;
				base.MyUpdatePolyline();
			}
		}
	}
}

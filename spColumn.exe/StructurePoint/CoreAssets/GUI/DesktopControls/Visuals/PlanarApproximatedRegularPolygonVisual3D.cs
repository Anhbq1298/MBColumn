using System;
using System.Collections.Generic;
using System.Windows;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BC RID: 2236
	internal sealed class PlanarApproximatedRegularPolygonVisual3D : PlanarApproximatedCircleVisual3D
	{
		// Token: 0x170014B5 RID: 5301
		// (get) Token: 0x0600469F RID: 18079 RVA: 0x0003B46F File Offset: 0x0003966F
		// (set) Token: 0x060046A0 RID: 18080 RVA: 0x0003B489 File Offset: 0x00039689
		public double Angle
		{
			get
			{
				return (double)base.GetValue(PlanarApproximatedRegularPolygonVisual3D.AngleProperty);
			}
			set
			{
				base.SetValue(PlanarApproximatedRegularPolygonVisual3D.AngleProperty, value);
			}
		}

		// Token: 0x060046A1 RID: 18081 RVA: 0x0013EEE0 File Offset: 0x0013D0E0
		public override IList<Point3D> ApproximateCircle()
		{
			int #Znc = Math.Max(base.NumberOfSides, 3);
			double #HS = Math.Max(0.1, base.Radius);
			return GeometryHelper.#2nc(base.Center, #HS, #Znc, this.Angle, true);
		}

		// Token: 0x04002007 RID: 8199
		public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(#Phc.#3hc(107360678), typeof(double), typeof(PlanarApproximatedRegularPolygonVisual3D), new PropertyMetadata(0.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));
	}
}

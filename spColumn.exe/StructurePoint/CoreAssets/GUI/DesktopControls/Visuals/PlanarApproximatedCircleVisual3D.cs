using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Utilities;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BD RID: 2237
	[CLSCompliant(false)]
	public class PlanarApproximatedCircleVisual3D : MeshElement3D
	{
		// Token: 0x170014B6 RID: 5302
		// (get) Token: 0x060046A4 RID: 18084 RVA: 0x0003B4B0 File Offset: 0x000396B0
		// (set) Token: 0x060046A5 RID: 18085 RVA: 0x0003B4CA File Offset: 0x000396CA
		public Color Color
		{
			get
			{
				return (Color)base.GetValue(PlanarApproximatedCircleVisual3D.ColorProperty);
			}
			set
			{
				base.SetValue(PlanarApproximatedCircleVisual3D.ColorProperty, value);
			}
		}

		// Token: 0x060046A6 RID: 18086 RVA: 0x0013EF90 File Offset: 0x0013D190
		private static void MyOnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			Color color = (Color)e.NewValue;
			((PlanarApproximatedCircleVisual3D)sender).Fill = new SolidColorBrush(color);
		}

		// Token: 0x170014B7 RID: 5303
		// (get) Token: 0x060046A7 RID: 18087 RVA: 0x0003B4E9 File Offset: 0x000396E9
		// (set) Token: 0x060046A8 RID: 18088 RVA: 0x0003B503 File Offset: 0x00039703
		public double Radius
		{
			get
			{
				return (double)base.GetValue(PlanarApproximatedCircleVisual3D.RadiusProperty);
			}
			set
			{
				base.SetValue(PlanarApproximatedCircleVisual3D.RadiusProperty, value);
			}
		}

		// Token: 0x170014B8 RID: 5304
		// (get) Token: 0x060046A9 RID: 18089 RVA: 0x0003B522 File Offset: 0x00039722
		// (set) Token: 0x060046AA RID: 18090 RVA: 0x0003B53C File Offset: 0x0003973C
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D Center
		{
			get
			{
				return (StructurePoint.CoreAssets.Infrastructure.Data.Point3D)base.GetValue(PlanarApproximatedCircleVisual3D.CenterProperty);
			}
			set
			{
				base.SetValue(PlanarApproximatedCircleVisual3D.CenterProperty, value);
			}
		}

		// Token: 0x170014B9 RID: 5305
		// (get) Token: 0x060046AB RID: 18091 RVA: 0x0003B55B File Offset: 0x0003975B
		// (set) Token: 0x060046AC RID: 18092 RVA: 0x0003B575 File Offset: 0x00039775
		public int NumberOfSides
		{
			get
			{
				return (int)base.GetValue(PlanarApproximatedCircleVisual3D.NumberOfSidesProperty);
			}
			set
			{
				base.SetValue(PlanarApproximatedCircleVisual3D.NumberOfSidesProperty, value);
			}
		}

		// Token: 0x060046AD RID: 18093 RVA: 0x0013EFC8 File Offset: 0x0013D1C8
		public virtual IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> ApproximateCircle()
		{
			int #Znc = Math.Max(this.NumberOfSides, 3);
			double #HS = Math.Max(0.1, this.Radius);
			return GeometryHelper.#9Hb(this.Center, #HS, #Znc);
		}

		// Token: 0x060046AE RID: 18094 RVA: 0x0013F010 File Offset: 0x0013D210
		protected override MeshGeometry3D Tessellate()
		{
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = this.ApproximateCircle();
			List<System.Windows.Media.Media3D.Point3D> positionsToAppend = list.Convert().ToList<System.Windows.Media.Media3D.Point3D>();
			List<int> triangleIndicesToAppend = Triangulator.Triangulate(PointsConverter.#vsc(list).Convert().ToList<System.Windows.Point>());
			MeshBuilder meshBuilder = new MeshBuilder(false, false);
			meshBuilder.Append(positionsToAppend, triangleIndicesToAppend, null, null);
			return meshBuilder.ToMesh(false);
		}

		// Token: 0x04002008 RID: 8200
		public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(#Phc.#3hc(107453376), typeof(double), typeof(PlanarApproximatedCircleVisual3D), new PropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002009 RID: 8201
		public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(#Phc.#3hc(107453365), typeof(StructurePoint.CoreAssets.Infrastructure.Data.Point3D), typeof(PlanarApproximatedCircleVisual3D), new PropertyMetadata(default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D), new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x0400200A RID: 8202
		public static readonly DependencyProperty NumberOfSidesProperty = DependencyProperty.Register(#Phc.#3hc(107453324), typeof(int), typeof(PlanarApproximatedCircleVisual3D), new PropertyMetadata(10, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x0400200B RID: 8203
		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(#Phc.#3hc(107453335), typeof(Color), typeof(PlanarApproximatedCircleVisual3D), new PropertyMetadata(Colors.Gray, new PropertyChangedCallback(PlanarApproximatedCircleVisual3D.MyOnColorChanged)));
	}
}

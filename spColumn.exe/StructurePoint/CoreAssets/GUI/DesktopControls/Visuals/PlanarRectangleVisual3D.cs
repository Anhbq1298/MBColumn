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
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008C1 RID: 2241
	internal sealed class PlanarRectangleVisual3D : MeshElement3D
	{
		// Token: 0x170014CF RID: 5327
		// (get) Token: 0x060046EB RID: 18155 RVA: 0x0003BA10 File Offset: 0x00039C10
		// (set) Token: 0x060046EC RID: 18156 RVA: 0x0003BA2A File Offset: 0x00039C2A
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D StartPoint
		{
			get
			{
				return (StructurePoint.CoreAssets.Infrastructure.Data.Point3D)base.GetValue(PlanarRectangleVisual3D.StartPointProperty);
			}
			set
			{
				base.SetValue(PlanarRectangleVisual3D.StartPointProperty, value);
			}
		}

		// Token: 0x170014D0 RID: 5328
		// (get) Token: 0x060046ED RID: 18157 RVA: 0x0003BA49 File Offset: 0x00039C49
		// (set) Token: 0x060046EE RID: 18158 RVA: 0x0003BA63 File Offset: 0x00039C63
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D? EndPoint
		{
			get
			{
				return (StructurePoint.CoreAssets.Infrastructure.Data.Point3D?)base.GetValue(PlanarRectangleVisual3D.EndPointProperty);
			}
			set
			{
				base.SetValue(PlanarRectangleVisual3D.EndPointProperty, value);
			}
		}

		// Token: 0x170014D1 RID: 5329
		// (get) Token: 0x060046EF RID: 18159 RVA: 0x0003BA82 File Offset: 0x00039C82
		// (set) Token: 0x060046F0 RID: 18160 RVA: 0x0003BA9C File Offset: 0x00039C9C
		public Color Color
		{
			get
			{
				return (Color)base.GetValue(PlanarRectangleVisual3D.ColorProperty);
			}
			set
			{
				base.SetValue(PlanarRectangleVisual3D.ColorProperty, value);
			}
		}

		// Token: 0x060046F1 RID: 18161 RVA: 0x0013FF74 File Offset: 0x0013E174
		private static void MyOnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			Color color = (Color)e.NewValue;
			PlanarRectangleVisual3D planarRectangleVisual3D = (PlanarRectangleVisual3D)sender;
			Material material = MaterialHelper.CreateMaterial(color);
			planarRectangleVisual3D.Material = material;
			planarRectangleVisual3D.BackMaterial = material;
		}

		// Token: 0x060046F2 RID: 18162 RVA: 0x0013FFB4 File Offset: 0x0013E1B4
		public List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> ConstructRectangle()
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D? endPoint = this.EndPoint;
			if (endPoint != null)
			{
				list.AddRange(GeometryHelper.#8nc(this.StartPoint, endPoint.Value));
			}
			if (!VisualMeshTriangulator.CanPerformTriangulation(list))
			{
				list.Clear();
			}
			return list;
		}

		// Token: 0x060046F3 RID: 18163 RVA: 0x0014000C File Offset: 0x0013E20C
		protected override MeshGeometry3D Tessellate()
		{
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = this.ConstructRectangle();
			if (list.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>())
			{
				List<int> triangleIndicesToAppend = Triangulator.Triangulate(PointsConverter.#vsc(list).Convert());
				MeshBuilder meshBuilder = new MeshBuilder(false, false);
				meshBuilder.Append(list.Convert(), triangleIndicesToAppend, null, null);
				return meshBuilder.ToMesh(false);
			}
			return null;
		}

		// Token: 0x04002026 RID: 8230
		public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register(#Phc.#3hc(107453294), typeof(StructurePoint.CoreAssets.Infrastructure.Data.Point3D), typeof(PlanarRectangleVisual3D), new PropertyMetadata(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(0.0, 0.0, 0.0), new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002027 RID: 8231
		public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register(#Phc.#3hc(107453309), typeof(StructurePoint.CoreAssets.Infrastructure.Data.Point3D?), typeof(PlanarRectangleVisual3D), new PropertyMetadata(null, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002028 RID: 8232
		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(#Phc.#3hc(107453335), typeof(Color), typeof(PlanarRectangleVisual3D), new PropertyMetadata(Colors.Gray, new PropertyChangedCallback(PlanarRectangleVisual3D.MyOnColorChanged)));
	}
}

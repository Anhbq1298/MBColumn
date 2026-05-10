using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BF RID: 2239
	internal sealed class CirclesMeshElement3D : MeshElement3D
	{
		// Token: 0x060046BE RID: 18110 RVA: 0x0003B672 File Offset: 0x00039872
		public CirclesMeshElement3D()
		{
			this.Polylines = new List<PolyLine3D>();
			this.GeneratePolylines = true;
		}

		// Token: 0x170014BE RID: 5310
		// (get) Token: 0x060046BF RID: 18111 RVA: 0x0003B68C File Offset: 0x0003988C
		// (set) Token: 0x060046C0 RID: 18112 RVA: 0x0003B6A6 File Offset: 0x000398A6
		public IList<System.Windows.Media.Media3D.Point3D> Points
		{
			get
			{
				return (IList<System.Windows.Media.Media3D.Point3D>)base.GetValue(CirclesMeshElement3D.PointsProperty);
			}
			set
			{
				base.SetValue(CirclesMeshElement3D.PointsProperty, value);
			}
		}

		// Token: 0x170014BF RID: 5311
		// (get) Token: 0x060046C1 RID: 18113 RVA: 0x0003B6C0 File Offset: 0x000398C0
		// (set) Token: 0x060046C2 RID: 18114 RVA: 0x0003B6DA File Offset: 0x000398DA
		public double Radius
		{
			get
			{
				return (double)base.GetValue(CirclesMeshElement3D.RadiusProperty);
			}
			set
			{
				base.SetValue(CirclesMeshElement3D.RadiusProperty, value);
			}
		}

		// Token: 0x170014C0 RID: 5312
		// (get) Token: 0x060046C3 RID: 18115 RVA: 0x0003B6F9 File Offset: 0x000398F9
		// (set) Token: 0x060046C4 RID: 18116 RVA: 0x0003B713 File Offset: 0x00039913
		public int Sides
		{
			get
			{
				return (int)base.GetValue(CirclesMeshElement3D.SidesProperty);
			}
			set
			{
				base.SetValue(CirclesMeshElement3D.SidesProperty, value);
			}
		}

		// Token: 0x170014C1 RID: 5313
		// (get) Token: 0x060046C5 RID: 18117 RVA: 0x0003B732 File Offset: 0x00039932
		// (set) Token: 0x060046C6 RID: 18118 RVA: 0x0003B73E File Offset: 0x0003993E
		public List<PolyLine3D> Polylines { get; private set; }

		// Token: 0x170014C2 RID: 5314
		// (get) Token: 0x060046C7 RID: 18119 RVA: 0x0003B74F File Offset: 0x0003994F
		// (set) Token: 0x060046C8 RID: 18120 RVA: 0x0003B75B File Offset: 0x0003995B
		public bool GeneratePolylines { get; set; }

		// Token: 0x060046C9 RID: 18121 RVA: 0x0013F578 File Offset: 0x0013D778
		protected override MeshGeometry3D Tessellate()
		{
			IList<System.Windows.Media.Media3D.Point3D> points = this.Points;
			double radius = this.Radius;
			int sides = this.Sides;
			if (this.Polylines != null)
			{
				this.Polylines.Clear();
			}
			if (points == null || !points.Any<System.Windows.Media.Media3D.Point3D>() || radius <= 0.0 || sides <= 0)
			{
				return new MeshGeometry3D();
			}
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			bool generatePolylines = this.GeneratePolylines;
			Vector3D[] generationVector = this.MyCreateGenerationVector(sides, radius);
			System.Windows.Media.Media3D.Point3D[] collection;
			int[] collection2;
			this.MyCalculatePositionsAndTriangleIndices(points, generationVector, out collection, out collection2);
			meshGeometry3D.Positions = new Point3DCollection(collection);
			meshGeometry3D.Positions.Freeze();
			meshGeometry3D.TriangleIndices = new Int32Collection(collection2);
			meshGeometry3D.TriangleIndices.Freeze();
			if (meshGeometry3D.CanFreeze)
			{
				meshGeometry3D.Freeze();
			}
			return meshGeometry3D;
		}

		// Token: 0x060046CA RID: 18122 RVA: 0x0013F650 File Offset: 0x0013D850
		private Vector3D[] MyCreateGenerationVector(int sides, double radius)
		{
			if (this.lastNumberOfSides != sides || this.lastRadius != radius)
			{
				this.lastNumberOfSides = sides;
				this.lastRadius = radius;
				if (this.cachedGenerationVector == null || this.cachedGenerationVector.Length != sides)
				{
					this.cachedGenerationVector = new Vector3D[sides];
				}
				double num = 6.283185307179586 / (double)sides;
				for (int i = 0; i < sides; i++)
				{
					this.cachedGenerationVector[i] = new Vector3D(radius * Math.Cos(num * (double)i), radius * Math.Sin(num * (double)i), 0.0);
				}
			}
			return this.cachedGenerationVector;
		}

		// Token: 0x060046CB RID: 18123 RVA: 0x0013F70C File Offset: 0x0013D90C
		private void MyCalculatePositionsAndTriangleIndices(IList<System.Windows.Media.Media3D.Point3D> points, Vector3D[] generationVector, out System.Windows.Media.Media3D.Point3D[] positions, out int[] triangleIndicies)
		{
			int sides = this.Sides;
			positions = new System.Windows.Media.Media3D.Point3D[points.Count * (sides + 1)];
			int num = 0;
			triangleIndicies = new int[3 * points.Count * sides];
			int num2 = 0;
			for (int i = 0; i < points.Count; i++)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = null;
				if (this.GeneratePolylines)
				{
					list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(sides + 2);
				}
				int num3 = i * (sides + 1);
				System.Windows.Media.Media3D.Point3D point3D = points[i];
				positions[num++] = point3D;
				foreach (Vector3D vector in generationVector)
				{
					System.Windows.Media.Media3D.Point3D point3D2 = point3D + vector;
					positions[num++] = point3D2;
					if (this.GeneratePolylines)
					{
						list.Add(point3D2.Convert());
					}
				}
				for (int k = 1; k < sides; k++)
				{
					triangleIndicies[num2++] = num3;
					triangleIndicies[num2++] = num3 + k;
					triangleIndicies[num2++] = num3 + k + 1;
				}
				triangleIndicies[num2++] = num3;
				triangleIndicies[num2++] = num3 + 1;
				triangleIndicies[num2++] = num - 1;
				if (this.GeneratePolylines)
				{
					this.Polylines.Add(new PolyLine3D(list));
				}
			}
		}

		// Token: 0x04002010 RID: 8208
		private int lastNumberOfSides;

		// Token: 0x04002011 RID: 8209
		private double lastRadius;

		// Token: 0x04002012 RID: 8210
		private Vector3D[] cachedGenerationVector;

		// Token: 0x04002013 RID: 8211
		public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(#Phc.#3hc(107453385), typeof(IList<System.Windows.Media.Media3D.Point3D>), typeof(CirclesMeshElement3D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002014 RID: 8212
		public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(#Phc.#3hc(107453376), typeof(double), typeof(CirclesMeshElement3D), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002015 RID: 8213
		public static readonly DependencyProperty SidesProperty = DependencyProperty.Register(#Phc.#3hc(107453399), typeof(int), typeof(CirclesMeshElement3D), new FrameworkPropertyMetadata(10, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));
	}
}

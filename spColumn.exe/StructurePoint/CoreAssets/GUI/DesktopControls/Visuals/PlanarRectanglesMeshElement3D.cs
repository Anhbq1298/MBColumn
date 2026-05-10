using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BE RID: 2238
	internal sealed class PlanarRectanglesMeshElement3D : MeshElement3D
	{
		// Token: 0x060046B1 RID: 18097 RVA: 0x0003B59C File Offset: 0x0003979C
		public PlanarRectanglesMeshElement3D()
		{
			this.Polylines = new List<PolyLine3D>();
		}

		// Token: 0x060046B2 RID: 18098 RVA: 0x0013F1A4 File Offset: 0x0013D3A4
		protected override MeshGeometry3D Tessellate()
		{
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			if (this.Polylines != null)
			{
				this.Polylines.Clear();
			}
			if (this.Width * this.Height <= 0.0 || this.CenterPoints == null || !this.CenterPoints.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>())
			{
				return meshGeometry3D;
			}
			if (this.Polylines != null)
			{
				this.Polylines.EnsureTotalCapacity(this.CenterPoints.Count<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>() + 1);
			}
			Vector3D[] vectors = this.MyCreateVectors();
			System.Windows.Media.Media3D.Point3D[] collection;
			int[] collection2;
			this.MyCalculatePositionsAndTriangleIndices(vectors, out collection, out collection2);
			Point3DCollection point3DCollection = new Point3DCollection(collection);
			point3DCollection.Freeze();
			meshGeometry3D.Positions = point3DCollection;
			Int32Collection int32Collection = new Int32Collection(collection2);
			int32Collection.Freeze();
			meshGeometry3D.TriangleIndices = int32Collection;
			if (meshGeometry3D.CanFreeze)
			{
				meshGeometry3D.Freeze();
			}
			return meshGeometry3D;
		}

		// Token: 0x170014BA RID: 5306
		// (get) Token: 0x060046B3 RID: 18099 RVA: 0x0003B5AF File Offset: 0x000397AF
		// (set) Token: 0x060046B4 RID: 18100 RVA: 0x0003B5BB File Offset: 0x000397BB
		public List<PolyLine3D> Polylines { get; private set; }

		// Token: 0x170014BB RID: 5307
		// (get) Token: 0x060046B5 RID: 18101 RVA: 0x0003B5CC File Offset: 0x000397CC
		// (set) Token: 0x060046B6 RID: 18102 RVA: 0x0003B5E6 File Offset: 0x000397E6
		public double Width
		{
			get
			{
				return (double)base.GetValue(PlanarRectanglesMeshElement3D.WidthProperty);
			}
			set
			{
				base.SetValue(PlanarRectanglesMeshElement3D.WidthProperty, value);
			}
		}

		// Token: 0x170014BC RID: 5308
		// (get) Token: 0x060046B7 RID: 18103 RVA: 0x0003B605 File Offset: 0x00039805
		// (set) Token: 0x060046B8 RID: 18104 RVA: 0x0003B61F File Offset: 0x0003981F
		public double Height
		{
			get
			{
				return (double)base.GetValue(PlanarRectanglesMeshElement3D.HeightProperty);
			}
			set
			{
				base.SetValue(PlanarRectanglesMeshElement3D.HeightProperty, value);
			}
		}

		// Token: 0x170014BD RID: 5309
		// (get) Token: 0x060046B9 RID: 18105 RVA: 0x0003B63E File Offset: 0x0003983E
		// (set) Token: 0x060046BA RID: 18106 RVA: 0x0003B658 File Offset: 0x00039858
		public IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> CenterPoints
		{
			get
			{
				return (IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>)base.GetValue(PlanarRectanglesMeshElement3D.CenterPointsProperty);
			}
			set
			{
				base.SetValue(PlanarRectanglesMeshElement3D.CenterPointsProperty, value);
			}
		}

		// Token: 0x060046BB RID: 18107 RVA: 0x0013F288 File Offset: 0x0013D488
		private Vector3D[] MyCreateVectors()
		{
			double num = this.Width * 0.5;
			double num2 = this.Height * 0.5;
			return new Vector3D[]
			{
				new Vector3D(-num, num2, 0.0),
				new Vector3D(num, num2, 0.0),
				new Vector3D(num, -num2, 0.0),
				new Vector3D(-num, -num2, 0.0)
			};
		}

		// Token: 0x060046BC RID: 18108 RVA: 0x0013F33C File Offset: 0x0013D53C
		private void MyCalculatePositionsAndTriangleIndices(Vector3D[] vectors, out System.Windows.Media.Media3D.Point3D[] positions, out int[] triangleIndices)
		{
			IList<System.Windows.Media.Media3D.Point3D> list = this.CenterPoints.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>().Convert();
			positions = new System.Windows.Media.Media3D.Point3D[list.Count * vectors.Length];
			triangleIndices = new int[list.Count * 6];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list2 = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(vectors.Length + 2);
				System.Windows.Media.Media3D.Point3D point = list[i];
				foreach (Vector3D vector in vectors)
				{
					System.Windows.Media.Media3D.Point3D point3D = point + vector;
					positions[num++] = point3D;
					list2.Add(point3D.Convert());
				}
				int num3 = i * 4;
				triangleIndices[num2++] = num3;
				triangleIndices[num2++] = num3 + 1;
				triangleIndices[num2++] = num3 + 2;
				triangleIndices[num2++] = num3;
				triangleIndices[num2++] = num3 + 2;
				triangleIndices[num2++] = num3 + 3;
				list2.Add(list2[0]);
				if (this.Polylines != null)
				{
					this.Polylines.Add(new PolyLine3D(list2));
				}
			}
		}

		// Token: 0x0400200D RID: 8205
		public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(#Phc.#3hc(107412974), typeof(double), typeof(PlanarRectanglesMeshElement3D), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x0400200E RID: 8206
		public static readonly DependencyProperty HeightProperty = DependencyProperty.Register(#Phc.#3hc(107412672), typeof(double), typeof(PlanarRectanglesMeshElement3D), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x0400200F RID: 8207
		public static readonly DependencyProperty CenterPointsProperty = DependencyProperty.Register(#Phc.#3hc(107453423), typeof(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>), typeof(PlanarRectanglesMeshElement3D), new FrameworkPropertyMetadata(new PropertyChangedCallback(MeshElement3D.GeometryChanged)));
	}
}

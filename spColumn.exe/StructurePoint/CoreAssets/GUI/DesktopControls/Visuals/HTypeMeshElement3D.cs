using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BB RID: 2235
	internal sealed class HTypeMeshElement3D : MeshElement3D
	{
		// Token: 0x0600468C RID: 18060 RVA: 0x0003B2EE File Offset: 0x000394EE
		public HTypeMeshElement3D()
		{
			this.Polylines = new List<PolyLine3D>();
		}

		// Token: 0x0600468D RID: 18061 RVA: 0x0013E874 File Offset: 0x0013CA74
		protected override MeshGeometry3D Tessellate()
		{
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
			MeshGeometry3D meshGeometry3D2;
			if (6 != 0)
			{
				meshGeometry3D2 = meshGeometry3D;
			}
			if (this.Polylines != null)
			{
				this.Polylines.Clear();
			}
			if (this.WebThickness <= 0.0 || this.WebHeight <= 0.0 || this.FlangeWidth <= 0.0 || this.FlangeThickness <= 0.0 || this.CenterPoints == null || !this.CenterPoints.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>())
			{
				return meshGeometry3D2;
			}
			System.Windows.Media.Media3D.Point3D[] collection;
			int[] collection2;
			this.MyCalculatePositionsAndTriangleIndices(out collection, out collection2);
			Point3DCollection point3DCollection = new Point3DCollection(collection);
			point3DCollection.Freeze();
			meshGeometry3D2.Positions = point3DCollection;
			Int32Collection int32Collection = new Int32Collection(collection2);
			int32Collection.Freeze();
			meshGeometry3D2.TriangleIndices = int32Collection;
			if (meshGeometry3D2.CanFreeze)
			{
				meshGeometry3D2.Freeze();
			}
			return meshGeometry3D2;
		}

		// Token: 0x170014AE RID: 5294
		// (get) Token: 0x0600468E RID: 18062 RVA: 0x0003B301 File Offset: 0x00039501
		// (set) Token: 0x0600468F RID: 18063 RVA: 0x0003B30D File Offset: 0x0003950D
		public List<PolyLine3D> Polylines { get; private set; }

		// Token: 0x170014AF RID: 5295
		// (get) Token: 0x06004690 RID: 18064 RVA: 0x0003B31E File Offset: 0x0003951E
		// (set) Token: 0x06004691 RID: 18065 RVA: 0x0003B338 File Offset: 0x00039538
		public double WebThickness
		{
			get
			{
				return (double)base.GetValue(HTypeMeshElement3D.WebThicknessProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.WebThicknessProperty, value);
			}
		}

		// Token: 0x170014B0 RID: 5296
		// (get) Token: 0x06004692 RID: 18066 RVA: 0x0003B357 File Offset: 0x00039557
		// (set) Token: 0x06004693 RID: 18067 RVA: 0x0003B371 File Offset: 0x00039571
		public double WebHeight
		{
			get
			{
				return (double)base.GetValue(HTypeMeshElement3D.WebHeightProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.WebHeightProperty, value);
			}
		}

		// Token: 0x170014B1 RID: 5297
		// (get) Token: 0x06004694 RID: 18068 RVA: 0x0003B390 File Offset: 0x00039590
		// (set) Token: 0x06004695 RID: 18069 RVA: 0x0003B3AA File Offset: 0x000395AA
		public double FlangeThickness
		{
			get
			{
				return (double)base.GetValue(HTypeMeshElement3D.FlangeThicknessProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.FlangeThicknessProperty, value);
			}
		}

		// Token: 0x170014B2 RID: 5298
		// (get) Token: 0x06004696 RID: 18070 RVA: 0x0003B3C9 File Offset: 0x000395C9
		// (set) Token: 0x06004697 RID: 18071 RVA: 0x0003B3E3 File Offset: 0x000395E3
		public double FlangeWidth
		{
			get
			{
				return (double)base.GetValue(HTypeMeshElement3D.FlangeWidthProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.FlangeWidthProperty, value);
			}
		}

		// Token: 0x170014B3 RID: 5299
		// (get) Token: 0x06004698 RID: 18072 RVA: 0x0003B402 File Offset: 0x00039602
		// (set) Token: 0x06004699 RID: 18073 RVA: 0x0003B41C File Offset: 0x0003961C
		public IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> CenterPoints
		{
			get
			{
				return (IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>)base.GetValue(HTypeMeshElement3D.CenterPointsProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.CenterPointsProperty, value);
			}
		}

		// Token: 0x170014B4 RID: 5300
		// (get) Token: 0x0600469A RID: 18074 RVA: 0x0003B436 File Offset: 0x00039636
		// (set) Token: 0x0600469B RID: 18075 RVA: 0x0003B450 File Offset: 0x00039650
		public double RotationAngle
		{
			get
			{
				return (double)base.GetValue(HTypeMeshElement3D.RotationAngleProperty);
			}
			set
			{
				base.SetValue(HTypeMeshElement3D.RotationAngleProperty, value);
			}
		}

		// Token: 0x0600469C RID: 18076 RVA: 0x0013E95C File Offset: 0x0013CB5C
		private void MyCalculatePositionsAndTriangleIndices(out System.Windows.Media.Media3D.Point3D[] positions, out int[] triangleIndices)
		{
			Vector3D[] array = this.MyCreateVectors();
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = this.CenterPoints.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			positions = new System.Windows.Media.Media3D.Point3D[list.Count * array.Length];
			triangleIndices = new int[list.Count * 6 * 3];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = list[i];
				System.Windows.Media.Media3D.Point3D point = point3D.Convert();
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list2 = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(array.Length + 2);
				foreach (Vector3D vector in array)
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D2 = (point + vector).Convert();
					if (this.RotationAngle != 0.0)
					{
						point3D2 = GeometryHelper.#Mmc(point3D2, point3D, this.RotationAngle);
					}
					list2.Add(point3D2);
					positions[num++] = point3D2.Convert();
				}
				int num3 = i * array.Length;
				triangleIndices[num2++] = num3;
				triangleIndices[num2++] = num3 + 1;
				triangleIndices[num2++] = num3 + 2;
				triangleIndices[num2++] = num3;
				triangleIndices[num2++] = num3 + 2;
				triangleIndices[num2++] = num3 + 11;
				triangleIndices[num2++] = num3 + 3;
				triangleIndices[num2++] = num3 + 10;
				triangleIndices[num2++] = num3 + 9;
				triangleIndices[num2++] = num3 + 3;
				triangleIndices[num2++] = num3 + 4;
				triangleIndices[num2++] = num3 + 9;
				triangleIndices[num2++] = num3 + 5;
				triangleIndices[num2++] = num3 + 6;
				triangleIndices[num2++] = num3 + 7;
				triangleIndices[num2++] = num3 + 5;
				triangleIndices[num2++] = num3 + 7;
				triangleIndices[num2++] = num3 + 8;
				list2.Add(list2[0]);
				if (this.Polylines != null)
				{
					this.Polylines.Add(new PolyLine3D(list2));
				}
			}
		}

		// Token: 0x0600469D RID: 18077 RVA: 0x0013EB74 File Offset: 0x0013CD74
		private Vector3D[] MyCreateVectors()
		{
			double num = this.WebHeight * 0.5;
			double num2 = this.WebThickness * 0.5;
			double num3 = this.FlangeWidth * 0.5;
			return new Vector3D[]
			{
				new Vector3D(-this.FlangeThickness - num, -num3, 0.0),
				new Vector3D(-this.FlangeThickness - num, num3, 0.0),
				new Vector3D(-num, num3, 0.0),
				new Vector3D(-num, num2, 0.0),
				new Vector3D(num, num2, 0.0),
				new Vector3D(num, num3, 0.0),
				new Vector3D(this.FlangeThickness + num, num3, 0.0),
				new Vector3D(this.FlangeThickness + num, -num3, 0.0),
				new Vector3D(num, -num3, 0.0),
				new Vector3D(num, -num2, 0.0),
				new Vector3D(-num, -num2, 0.0),
				new Vector3D(-num, -num3, 0.0)
			};
		}

		// Token: 0x04002001 RID: 8193
		public static readonly DependencyProperty WebThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107453011), typeof(double), typeof(HTypeMeshElement3D), new PropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002002 RID: 8194
		public static readonly DependencyProperty WebHeightProperty = DependencyProperty.Register(#Phc.#3hc(107452962), typeof(double), typeof(HTypeMeshElement3D), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002003 RID: 8195
		public static readonly DependencyProperty FlangeThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107452981), typeof(double), typeof(HTypeMeshElement3D), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002004 RID: 8196
		public static readonly DependencyProperty FlangeWidthProperty = DependencyProperty.Register(#Phc.#3hc(107452928), typeof(double), typeof(HTypeMeshElement3D), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002005 RID: 8197
		public static readonly DependencyProperty CenterPointsProperty = DependencyProperty.Register(#Phc.#3hc(107453423), typeof(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>), typeof(HTypeMeshElement3D), new FrameworkPropertyMetadata(new PropertyChangedCallback(MeshElement3D.GeometryChanged)));

		// Token: 0x04002006 RID: 8198
		public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.Register(#Phc.#3hc(107453438), typeof(double), typeof(HTypeMeshElement3D), new PropertyMetadata(0.0, new PropertyChangedCallback(MeshElement3D.GeometryChanged)));
	}
}

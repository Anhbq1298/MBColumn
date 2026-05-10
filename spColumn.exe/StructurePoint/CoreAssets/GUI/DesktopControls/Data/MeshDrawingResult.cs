using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0E RID: 2574
	public sealed class MeshDrawingResult : DrawingResultBase, IDrawingResult, IMeshDrawingResult
	{
		// Token: 0x060054DD RID: 21725 RVA: 0x000464F2 File Offset: 0x000446F2
		public MeshDrawingResult()
		{
			this.GeometryModel = new GeometryModel3D();
			this.ModelVisual = new ModelVisual3D();
		}

		// Token: 0x1700186D RID: 6253
		// (get) Token: 0x060054DE RID: 21726 RVA: 0x00046510 File Offset: 0x00044710
		// (set) Token: 0x060054DF RID: 21727 RVA: 0x0004651C File Offset: 0x0004471C
		private GeometryModel3D GeometryModel { get; set; }

		// Token: 0x1700186E RID: 6254
		// (get) Token: 0x060054E0 RID: 21728 RVA: 0x0004652D File Offset: 0x0004472D
		// (set) Token: 0x060054E1 RID: 21729 RVA: 0x00046539 File Offset: 0x00044739
		internal ModelVisual3D ModelVisual { get; private set; }

		// Token: 0x1700186F RID: 6255
		// (get) Token: 0x060054E2 RID: 21730 RVA: 0x0004654A File Offset: 0x0004474A
		// (set) Token: 0x060054E3 RID: 21731 RVA: 0x00046556 File Offset: 0x00044756
		public IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> Positions { get; private set; }

		// Token: 0x17001870 RID: 6256
		// (get) Token: 0x060054E4 RID: 21732 RVA: 0x00046567 File Offset: 0x00044767
		// (set) Token: 0x060054E5 RID: 21733 RVA: 0x00046573 File Offset: 0x00044773
		public IEnumerable<int> Indexes { get; private set; }

		// Token: 0x060054E6 RID: 21734 RVA: 0x00046584 File Offset: 0x00044784
		public void Freeze()
		{
			this.ModelVisual.Content = this.GeometryModel;
		}

		// Token: 0x060054E7 RID: 21735 RVA: 0x00164B3C File Offset: 0x00162D3C
		public void SetColor(Color color, double? opacity)
		{
			SolidColorBrush solidColorBrush = new SolidColorBrush(color);
			if (opacity != null)
			{
				solidColorBrush.Opacity = opacity.Value;
			}
			Material material = new DiffuseMaterial(solidColorBrush);
			this.GeometryModel.Material = material;
			this.GeometryModel.BackMaterial = material;
		}

		// Token: 0x060054E8 RID: 21736 RVA: 0x00164B94 File Offset: 0x00162D94
		public void SetTransforms(#c4d? translateVector, #c4d? scaleVector)
		{
			if (translateVector == null && scaleVector == null)
			{
				return;
			}
			Transform3DGroup transform3DGroup = new Transform3DGroup();
			if (translateVector != null)
			{
				transform3DGroup.Children.Add(new TranslateTransform3D(translateVector.Value.Convert()));
			}
			if (scaleVector != null)
			{
				transform3DGroup.Children.Add(new ScaleTransform3D(scaleVector.Value.Convert()));
			}
			this.ModelVisual.Transform = transform3DGroup;
		}

		// Token: 0x060054E9 RID: 21737 RVA: 0x00164C1C File Offset: 0x00162E1C
		public void SetContent(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points, IEnumerable<int> triangleIndexes)
		{
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list;
			if ((list = (points as IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>)) == null)
			{
				list = points.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			}
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list2 = list;
			IList<int> list3 = (triangleIndexes as IList<int>) ?? triangleIndexes.ToList<int>();
			this.Positions = list2;
			this.Indexes = list3;
			MeshGeometry3D geometry = new MeshGeometry3D
			{
				Positions = new Point3DCollection(list2.Convert()),
				TriangleIndices = new Int32Collection(list3)
			};
			this.GeometryModel.Geometry = geometry;
		}

		// Token: 0x060054EA RID: 21738 RVA: 0x000465A3 File Offset: 0x000447A3
		protected internal override object RetrieveDisplayedObject()
		{
			return this.ModelVisual;
		}
	}
}

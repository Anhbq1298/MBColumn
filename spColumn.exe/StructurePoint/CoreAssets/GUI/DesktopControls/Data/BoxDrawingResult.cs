using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A02 RID: 2562
	public sealed class BoxDrawingResult : DrawingResultBase, IDrawingResult, IBoxDrawingResult
	{
		// Token: 0x06005457 RID: 21591 RVA: 0x00045E68 File Offset: 0x00044068
		public BoxDrawingResult()
		{
			this.BoxVisual = new BoxVisual3D();
		}

		// Token: 0x17001834 RID: 6196
		// (get) Token: 0x06005458 RID: 21592 RVA: 0x00045E7B File Offset: 0x0004407B
		// (set) Token: 0x06005459 RID: 21593 RVA: 0x00045E87 File Offset: 0x00044087
		internal BoxVisual3D BoxVisual { get; private set; }

		// Token: 0x17001835 RID: 6197
		// (get) Token: 0x0600545A RID: 21594 RVA: 0x00045E98 File Offset: 0x00044098
		// (set) Token: 0x0600545B RID: 21595 RVA: 0x001645AC File Offset: 0x001627AC
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				if (this.color != value)
				{
					this.color = value;
					DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(value));
					this.BoxVisual.Material = material;
				}
			}
		}

		// Token: 0x17001836 RID: 6198
		// (get) Token: 0x0600545C RID: 21596 RVA: 0x00045EA4 File Offset: 0x000440A4
		// (set) Token: 0x0600545D RID: 21597 RVA: 0x00045EC2 File Offset: 0x000440C2
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D Center
		{
			get
			{
				return this.BoxVisual.CenterPosition.Convert();
			}
			set
			{
				this.BoxVisual.CenterPosition = value.Convert();
			}
		}

		// Token: 0x17001837 RID: 6199
		// (get) Token: 0x0600545E RID: 21598 RVA: 0x00045EE1 File Offset: 0x000440E1
		// (set) Token: 0x0600545F RID: 21599 RVA: 0x00045EFF File Offset: 0x000440FF
		public #03d Size
		{
			get
			{
				return this.BoxVisual.Size.Convert();
			}
			set
			{
				this.BoxVisual.Size = value.Convert();
			}
		}

		// Token: 0x17001838 RID: 6200
		// (get) Token: 0x06005460 RID: 21600 RVA: 0x001645F4 File Offset: 0x001627F4
		public IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> Positions
		{
			get
			{
				System.Windows.Media.Media3D.Point3D centerPosition = this.BoxVisual.CenterPosition;
				Size3D size = this.BoxVisual.Size;
				System.Windows.Media.Media3D.Point3D item = new System.Windows.Media.Media3D.Point3D(centerPosition.X - size.X / 2.0, centerPosition.Y - size.Y / 2.0, centerPosition.Z);
				System.Windows.Media.Media3D.Point3D item2 = new System.Windows.Media.Media3D.Point3D(centerPosition.X + size.X / 2.0, centerPosition.Y - size.Y / 2.0, centerPosition.Z);
				System.Windows.Media.Media3D.Point3D item3 = new System.Windows.Media.Media3D.Point3D(centerPosition.X + size.X / 2.0, centerPosition.Y + size.Y / 2.0, centerPosition.Z);
				System.Windows.Media.Media3D.Point3D item4 = new System.Windows.Media.Media3D.Point3D(centerPosition.X - size.X / 2.0, centerPosition.Y + size.Y / 2.0, centerPosition.Z);
				return from point in new List<System.Windows.Media.Media3D.Point3D>
				{
					item,
					item2,
					item3,
					item4
				}
				select this.BoxVisual.Transform.Transform(point).Convert();
			}
		}

		// Token: 0x06005461 RID: 21601 RVA: 0x0016476C File Offset: 0x0016296C
		public void UpdateNormal(#c4d normal, #c4d translateVector)
		{
			Transform3DGroup transform3DGroup = new Transform3DGroup();
			Vector3D vector = new Vector3D(0.0, 1.0, 0.0);
			Vector3D vector2 = new Vector3D(normal.X, normal.Y, normal.Z);
			double num = Math.Acos(BoxDrawingResult.DotProduct(vector, vector2)) * 180.0 / 3.141592653589793;
			if (1.0 * vector2.X > 0.0)
			{
				num = 360.0 - num;
			}
			transform3DGroup.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0.0, 0.0, 1.0), num)));
			Vector3D vector3 = new Vector3D(0.0, 0.0, 1.0);
			Vector3D axis = BoxDrawingResult.CrossProduct(vector3, vector2);
			double angle = Math.Acos(BoxDrawingResult.DotProduct(vector3, vector2) / (vector3.Length * vector2.Length)) * 180.0 / 3.141592653589793;
			transform3DGroup.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(axis, angle)));
			transform3DGroup.Children.Add(new TranslateTransform3D(translateVector.X, translateVector.Y, translateVector.Z));
			this.BoxVisual.Transform = transform3DGroup;
		}

		// Token: 0x06005462 RID: 21602 RVA: 0x00045F1E File Offset: 0x0004411E
		protected internal override object RetrieveDisplayedObject()
		{
			return this.BoxVisual;
		}

		// Token: 0x06005463 RID: 21603 RVA: 0x00164900 File Offset: 0x00162B00
		private static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
		{
			return new Vector3D(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X);
		}

		// Token: 0x06005464 RID: 21604 RVA: 0x00045F2E File Offset: 0x0004412E
		private static double DotProduct(Vector3D vector1, Vector3D vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		// Token: 0x0400243E RID: 9278
		private Color color;
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002EC RID: 748
	internal sealed class #vS : BaseCoreRenderer
	{
		// Token: 0x060019DE RID: 6622 RVA: 0x00019690 File Offset: 0x00017890
		public #vS(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x000B92D8 File Offset: 0x000B74D8
		public override void #fR()
		{
			List<Point3D> list = new List<Point3D>(base.CoreRendererModel.Labels.Count * 2);
			foreach (BillboardLabel billboardLabel in base.CoreRendererModel.Labels)
			{
				Point3D item = base.Editor.WorldToScreen(billboardLabel.PointPosition);
				Point3D point3D = base.Editor.WorldToScreen(billboardLabel.BoundingBoxIntersection);
				point3D.X += (billboardLabel.IsLeft ? -1.0 : 1.0) * 90.0;
				Font orCreate = FontsCache.GetOrCreate(#KT.#d, billboardLabel.TextSize);
				int x = (int)point3D.X;
				int y = (int)point3D.Y;
				list.Add(item);
				list.Add(point3D);
				base.Editor.DrawTextExt(x, y, billboardLabel.Label, orCreate, billboardLabel.Color, Color.Transparent, billboardLabel.Alignment, RotateFlipType.Rotate180FlipX, true);
			}
			if (list.Any<Point3D>())
			{
				base.Context.EnableXOR(false);
				base.Context.SetColorWireframe(Color.Black, true);
				base.Context.DrawLines(list.ToArray());
			}
		}

		// Token: 0x040009E9 RID: 2537
		public const float #a = 90f;
	}
}

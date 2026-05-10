using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002EB RID: 747
	internal sealed class #uS : BaseCoreRenderer
	{
		// Token: 0x060019DC RID: 6620 RVA: 0x00019690 File Offset: 0x00017890
		public #uS(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x000B8E58 File Offset: 0x000B7058
		public override void #fR()
		{
			if (!base.CoreRendererModel.ShowDimensions || base.CoreRendererModel.SelectionDimensions.ModelBoundingBox == null)
			{
				return;
			}
			#7R #7R = base.CoreRendererModel.SelectionDimensions;
			if (#7R.TextSize <= 0)
			{
				return;
			}
			BoundingBoxData boundingBoxData = #7R.ModelBoundingBox;
			Font orCreate = FontsCache.GetOrCreate(#KT.#d, (float)#7R.TextSize);
			float num = 2f * orCreate.Size;
			double num2 = (double)num / 2.0;
			float num3 = num / 2f;
			float num4 = num / 4f;
			List<Point3D> list = new List<Point3D>(4);
			if (!string.IsNullOrWhiteSpace(#7R.VerticalLabel))
			{
				Point3D point3D = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MinX, boundingBoxData.MinY));
				Point3D point3D2 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MinX, boundingBoxData.MaxY));
				point3D.X -= (double)num;
				point3D2.X -= (double)num;
				point3D.Y -= (double)num4;
				point3D2.Y += (double)num4;
				list.#pR(new Point3D[]
				{
					(Point3D)point3D.Clone(),
					(Point3D)point3D2.Clone()
				});
				point3D.Y += (double)num4;
				point3D2.Y -= (double)num4;
				list.#pR(new Point3D[]
				{
					new Point3D(point3D.X - (double)num4, point3D.Y),
					new Point3D(point3D.X + (double)num3, point3D.Y)
				});
				list.#pR(new Point3D[]
				{
					new Point3D(point3D2.X - (double)num4, point3D2.Y),
					new Point3D(point3D2.X + (double)num3, point3D2.Y)
				});
				point3D.Y += (point3D2.Y - point3D.Y) / 2.0;
				point3D.X -= num2;
				base.Editor.DrawTextExt((int)point3D.X, (int)point3D.Y, #7R.VerticalLabel, orCreate, #7R.TextColor, Color.Transparent, ContentAlignment.MiddleRight, RotateFlipType.Rotate180FlipX, true);
			}
			if (!string.IsNullOrWhiteSpace(#7R.HorizontalLabel))
			{
				Point3D point3D3 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MinX, boundingBoxData.MaxY));
				Point3D point3D4 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MaxX, boundingBoxData.MaxY));
				point3D3.Y += (double)num;
				point3D4.Y += (double)num;
				point3D4.X += (double)num4;
				point3D3.X -= (double)num4;
				list.#pR(new Point3D[]
				{
					(Point3D)point3D3.Clone(),
					(Point3D)point3D4.Clone()
				});
				point3D4.X -= (double)num4;
				point3D3.X += (double)num4;
				list.#pR(new Point3D[]
				{
					new Point3D(point3D3.X, point3D3.Y - (double)num3),
					new Point3D(point3D3.X, point3D3.Y + (double)num4)
				});
				list.#pR(new Point3D[]
				{
					new Point3D(point3D4.X, point3D4.Y - (double)num3),
					new Point3D(point3D4.X, point3D4.Y + (double)num4)
				});
				point3D3.X += (point3D4.X - point3D3.X) / 2.0;
				point3D3.Y += num2;
				base.Editor.DrawTextExt((int)point3D3.X, (int)point3D3.Y, #7R.HorizontalLabel, orCreate, #7R.TextColor, Color.Transparent, ContentAlignment.MiddleCenter, true);
			}
			if (list.Any<Point3D>())
			{
				base.Context.SetLineSize(1f, true, false);
				base.Context.SetColorWireframe(#7R.DimensionsColor, false);
				base.Context.DrawLines(list.ToArray());
			}
			base.#fR();
		}
	}
}

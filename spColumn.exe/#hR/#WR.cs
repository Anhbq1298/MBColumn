using System;
using System.Drawing;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002E6 RID: 742
	internal sealed class #WR : BaseCoreRenderer
	{
		// Token: 0x060019AA RID: 6570 RVA: 0x00019690 File Offset: 0x00017890
		public #WR(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x000B8A2C File Offset: 0x000B6C2C
		public override void #fR()
		{
			if (!base.CoreRendererModel.ShowDimensions || base.CoreRendererModel.Dimensions.ModelBoundingBox == null)
			{
				return;
			}
			#7R #7R = base.CoreRendererModel.Dimensions;
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
			if (!string.IsNullOrWhiteSpace(#7R.VerticalLabel))
			{
				Point3D point3D = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MaxX, boundingBoxData.MinY));
				Point3D point3D2 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MaxX, boundingBoxData.MaxY));
				point3D.X += (double)num;
				point3D2.X += (double)num;
				point3D.Y -= (double)num4;
				point3D2.Y += (double)num4;
				base.Context.SetLineSize(1f, true, false);
				base.Context.SetColorWireframe(#7R.DimensionsColor, false);
				base.Context.DrawLine(point3D, point3D2);
				point3D.Y += (double)num4;
				point3D2.Y -= (double)num4;
				base.Context.DrawLine(new Point3D(point3D.X - (double)num3, point3D.Y), new Point3D(point3D.X + (double)num4, point3D.Y));
				base.Context.DrawLine(new Point3D(point3D2.X - (double)num3, point3D2.Y), new Point3D(point3D2.X + (double)num4, point3D2.Y));
				point3D.Y += (point3D2.Y - point3D.Y) / 2.0;
				point3D.X += num2;
				base.Editor.DrawTextExt((int)point3D.X, (int)point3D.Y, #7R.VerticalLabel, orCreate, #7R.TextColor, Color.Transparent, ContentAlignment.MiddleCenter, RotateFlipType.Rotate90FlipX, true);
			}
			if (!string.IsNullOrWhiteSpace(#7R.HorizontalLabel))
			{
				Point3D point3D3 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MinX, boundingBoxData.MinY));
				Point3D point3D4 = base.Editor.WorldToScreen(new Point3D(boundingBoxData.MaxX, boundingBoxData.MinY));
				point3D3.Y -= (double)num;
				point3D4.Y -= (double)num;
				point3D4.X += (double)num4;
				point3D3.X -= (double)num4;
				base.Context.SetLineSize(1f, true, false);
				base.Context.SetColorWireframe(#7R.DimensionsColor, false);
				base.Context.DrawLine(point3D3, point3D4);
				point3D4.X -= (double)num4;
				point3D3.X += (double)num4;
				base.Context.DrawLine(new Point3D(point3D3.X, point3D3.Y - (double)num4), new Point3D(point3D3.X, point3D3.Y + (double)num3));
				base.Context.DrawLine(new Point3D(point3D4.X, point3D4.Y - (double)num4), new Point3D(point3D4.X, point3D4.Y + (double)num3));
				point3D3.X += (point3D4.X - point3D3.X) / 2.0;
				point3D3.Y -= num2;
				base.Editor.DrawTextExt((int)point3D3.X, (int)point3D3.Y, #7R.HorizontalLabel, orCreate, #7R.TextColor, Color.Transparent, ContentAlignment.MiddleCenter, true);
			}
			base.#fR();
		}
	}
}

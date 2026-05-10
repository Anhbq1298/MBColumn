using System;
using System.Drawing;
using #7hc;
using #U5c;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002E2 RID: 738
	internal sealed class #gR : BaseCoreRenderer
	{
		// Token: 0x0600197C RID: 6524 RVA: 0x00019690 File Offset: 0x00017890
		public #gR(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x000B8364 File Offset: 0x000B6564
		public override void #fR()
		{
			if (!base.CoreRendererModel.ShowAnnotations)
			{
				return;
			}
			foreach (#fS #fS in base.CoreRendererModel.Centroids)
			{
				Point3D point3D = base.Editor.WorldToScreen(#fS.Point);
				int x = (int)point3D.X;
				int num = (int)point3D.Y;
				if (#fS.Type == #8R.#a && #fS.Shape != null)
				{
					if (#fS.Shape.Application == PolygonApplication.Solid)
					{
						num += 20;
					}
					if (#fS.Shape.Application == PolygonApplication.Opening)
					{
						num -= 20;
					}
					string text = #fS.Shape.DisplayId;
					if (#T5c.#R5c())
					{
						text = text + #Phc.#3hc(107400770) + #fS.Shape.#cxc(0).Points2DCount.ToString();
					}
					base.Editor.DrawTextExt(x, num, text, FontsCache.GetOrCreate(#KT.#d, #KT.#R), Color.Black, Color.Transparent, ContentAlignment.MiddleCenter, RotateFlipType.Rotate180FlipX, false);
				}
			}
		}
	}
}

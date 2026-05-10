using System;
using System.Drawing;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002FE RID: 766
	internal sealed class #JT : BaseCoreRenderer
	{
		// Token: 0x06001AAB RID: 6827 RVA: 0x0001A5F6 File Offset: 0x000187F6
		public #JT(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x000BD1A4 File Offset: 0x000BB3A4
		public override void #fR()
		{
			if (!base.CoreRendererModel.ShowCentroid)
			{
				return;
			}
			foreach (#fS #fS in base.CoreRendererModel.Centroids)
			{
				Point3D point3D = base.Editor.WorldToScreen(#fS.Point);
				if (#fS.Type == #8R.#a)
				{
					base.Editor.DrawingHelper.DrawCross(point3D, #fS.IsSelected ? this.#e : this.#d, 5.5, this.#c);
				}
				else
				{
					base.Editor.DrawingHelper.DrawCross(point3D, #fS.IsSelected ? this.#e : this.#d, 7.5, this.#c);
					Point3D[] vertices = EyeshotHelper.ConstructRegularPolygon(point3D, 4.0, 40, 0.0, true).ToArray();
					base.Context.DrawLineStrip(vertices);
				}
			}
		}

		// Token: 0x04000A65 RID: 2661
		private const double #a = 5.5;

		// Token: 0x04000A66 RID: 2662
		private const double #b = 7.5;

		// Token: 0x04000A67 RID: 2663
		private readonly float #c = 1f;

		// Token: 0x04000A68 RID: 2664
		private readonly Color #d = Color.Black;

		// Token: 0x04000A69 RID: 2665
		private readonly Color #e = Color.FromArgb(255, 81, 180, 83);
	}
}

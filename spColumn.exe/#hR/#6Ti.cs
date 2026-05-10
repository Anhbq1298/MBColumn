using System;
using System.Drawing;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002E0 RID: 736
	internal sealed class #6Ti : BaseCoreRenderer
	{
		// Token: 0x06001971 RID: 6513 RVA: 0x00019690 File Offset: 0x00017890
		public #6Ti(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x000B82AC File Offset: 0x000B64AC
		public override void #fR()
		{
			if (!base.CoreRendererModel.ShowDxfImportNote || string.IsNullOrWhiteSpace(base.CoreRendererModel.DxfImportNote))
			{
				return;
			}
			Font orCreate = FontsCache.GetOrCreate(#KT.#d, 10f);
			int num = (int)base.Editor.DpiScaleUpY(5.0);
			double num2 = base.Editor.DpiScaleUpY(base.Editor.ActualHeight) - (double)num;
			base.Editor.DrawTextExt(num, (int)num2, base.CoreRendererModel.DxfImportNote, orCreate, Color.Black, Color.Transparent, ContentAlignment.TopLeft, false);
			base.#fR();
		}
	}
}

using System;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AF9 RID: 2809
	public static class RenderContextExtensions
	{
		// Token: 0x06005B8D RID: 23437 RVA: 0x0004C991 File Offset: 0x0004AB91
		public static void SetLineSizeExt(this RenderContextBase context, float lineSize)
		{
			context.SetLineSize(lineSize, true, true);
		}

		// Token: 0x06005B8E RID: 23438 RVA: 0x0004C99D File Offset: 0x0004AB9D
		public static void FixOverlayColor(this RenderContextBase context)
		{
			context.SetLineSizeExt(1f);
		}
	}
}

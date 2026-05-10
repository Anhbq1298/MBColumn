using System;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200084E RID: 2126
	public abstract class TemplatesCoreRenderer
	{
		// Token: 0x170013F0 RID: 5104
		// (get) Token: 0x060043B1 RID: 17329 RVA: 0x00038A92 File Offset: 0x00036C92
		// (set) Token: 0x060043B2 RID: 17330 RVA: 0x00038A9A File Offset: 0x00036C9A
		public EyeshotEditor Editor { get; set; }

		// Token: 0x170013F1 RID: 5105
		// (get) Token: 0x060043B3 RID: 17331 RVA: 0x00038AA3 File Offset: 0x00036CA3
		// (set) Token: 0x060043B4 RID: 17332 RVA: 0x00038AAB File Offset: 0x00036CAB
		public TemplateExecutionResult Result { get; set; }

		// Token: 0x170013F2 RID: 5106
		// (get) Token: 0x060043B5 RID: 17333 RVA: 0x00038AB4 File Offset: 0x00036CB4
		// (set) Token: 0x060043B6 RID: 17334 RVA: 0x00038ABC File Offset: 0x00036CBC
		public TemplateRenderOptions RenderOptions { get; set; } = TemplateRenderOptions.Default;

		// Token: 0x170013F3 RID: 5107
		// (get) Token: 0x060043B7 RID: 17335 RVA: 0x00038AC5 File Offset: 0x00036CC5
		// (set) Token: 0x060043B8 RID: 17336 RVA: 0x00038ACD File Offset: 0x00036CCD
		public TemplatesRendererContext Context { get; set; } = new TemplatesRendererContext();

		// Token: 0x060043B9 RID: 17337 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void DrawForeground()
		{
		}
	}
}

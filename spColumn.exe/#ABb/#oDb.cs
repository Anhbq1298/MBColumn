using System;
using #LFb;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;

namespace #ABb
{
	// Token: 0x02000565 RID: 1381
	internal static class #oDb
	{
		// Token: 0x06003122 RID: 12578 RVA: 0x000FB56C File Offset: 0x000F976C
		public static void #nDb(IExtendedServices #0c, #UFb #bX)
		{
			IModelEditorViewport modelEditorViewport = #0c.ViewportsManager.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				modelEditorViewport.EditorContext.Selection.State.#cg();
			}
			if (modelEditorViewport != null)
			{
				modelEditorViewport.EditorContext.Selection.#dPb();
			}
			#0c.Renderer.#9f(false, false);
			#0c.MessageBus.#MV();
			#0c.MessageBus.#KV();
			#0c.MessageBus.#tV();
			if (modelEditorViewport != null && #bX != null)
			{
				#bX.#cg(modelEditorViewport.EditorContext, false);
			}
			if (modelEditorViewport != null)
			{
				modelEditorViewport.Renderer.#cg();
			}
		}
	}
}

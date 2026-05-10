using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000859 RID: 2137
	public sealed class TemplateEyeshotEditor : EyeshotEditor
	{
		// Token: 0x060043F5 RID: 17397 RVA: 0x00139E08 File Offset: 0x00138008
		public TemplateEyeshotEditor() : base(true)
		{
			base.Zoom.FitMargin = 40;
			this.drawingHelper = new DrawingHelper(this);
			this.Renderers.Add(new TemplateDimensionsCoreRenderer
			{
				Editor = this
			});
			this.Renderers.Add(new TemplateDimTextsCoreRenderer
			{
				Editor = this
			});
			this.Renderers.Add(new TemplateLeadersRenderer
			{
				Editor = this
			});
			this.Renderers.Add(new TemplateShapeLabelsCoreRenderer
			{
				Editor = this
			});
			this.Renderers.Add(new CentroidCoreRenderer
			{
				Editor = this
			});
		}

		// Token: 0x17001400 RID: 5120
		// (get) Token: 0x060043F6 RID: 17398 RVA: 0x00038D01 File Offset: 0x00036F01
		public List<TemplatesCoreRenderer> Renderers { get; } = new List<TemplatesCoreRenderer>();

		// Token: 0x060043F7 RID: 17399 RVA: 0x00139EB4 File Offset: 0x001380B4
		protected override void DrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data)
		{
			base.DrawOverlay(data);
			foreach (TemplatesCoreRenderer templatesCoreRenderer in this.Renderers)
			{
				templatesCoreRenderer.DrawForeground();
			}
			this.drawingHelper.DrawCoordinateOrigin();
		}

		// Token: 0x060043F8 RID: 17400 RVA: 0x00038D09 File Offset: 0x00036F09
		protected override void DrawViewportBackground(devDept.Eyeshot.Environment.DrawSceneParams data)
		{
			base.renderContext.ClearColor(Color.White);
		}

		// Token: 0x04001EC7 RID: 7879
		private readonly DrawingHelper drawingHelper;
	}
}

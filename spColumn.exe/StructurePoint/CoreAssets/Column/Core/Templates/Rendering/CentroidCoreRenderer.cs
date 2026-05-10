using System;
using System.Drawing;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200084C RID: 2124
	public sealed class CentroidCoreRenderer : TemplatesCoreRenderer
	{
		// Token: 0x060043AB RID: 17323 RVA: 0x00138DB0 File Offset: 0x00136FB0
		public override void DrawForeground()
		{
			TemplateExecutionResult result = base.Result;
			if (result == null)
			{
				return;
			}
			Point3D point3D = SectionGeometryHelper.#gxc((from item in result.Polygons
			where item.Application == PolygonApplication.Solid
			select item).ToList<SectionPolygon>(), (from item in result.Polygons
			where item.Application == PolygonApplication.Opening
			select item).ToList<SectionPolygon>());
			if (point3D != null)
			{
				DrawingHelper drawingHelper = new DrawingHelper(base.Editor);
				point3D = base.Editor.WorldToScreen(point3D);
				drawingHelper.DrawCross(point3D, Color.Black, 10.0, 1f);
				Point3D[] vertices = EyeshotHelper.ConstructRegularPolygon(point3D, 4.0, 40, 0.0, true).ToArray();
				base.Editor.renderContext.DrawLineStrip(vertices);
			}
			base.DrawForeground();
		}
	}
}

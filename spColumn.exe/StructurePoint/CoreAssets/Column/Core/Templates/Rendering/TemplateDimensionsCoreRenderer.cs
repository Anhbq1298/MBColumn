using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #7hc;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000857 RID: 2135
	public sealed class TemplateDimensionsCoreRenderer : TemplatesCoreRenderer
	{
		// Token: 0x060043EF RID: 17391 RVA: 0x00139A0C File Offset: 0x00137C0C
		public override void DrawForeground()
		{
			TemplateExecutionResult result = base.Result;
			if (result == null)
			{
				return;
			}
			this.DrawDimensions(result, base.RenderOptions);
			base.DrawForeground();
		}

		// Token: 0x060043F0 RID: 17392 RVA: 0x00139A38 File Offset: 0x00137C38
		private void DrawDimensions(TemplateExecutionResult result, TemplateRenderOptions options)
		{
			if (!result.Dimensions.Any<DimensionData>() || !options.ShowAnnotations)
			{
				return;
			}
			RenderContextBase renderContext = base.Editor.renderContext;
			int capacity;
			if (!result.Dimensions.Any<DimensionData>())
			{
				capacity = 1;
			}
			else
			{
				capacity = (from item in result.Dimensions
				select item.Steps.Count * 4 + 1).Sum();
			}
			List<Point3D> list = new List<Point3D>(capacity);
			for (int i = 0; i < result.Dimensions.Count; i++)
			{
				DimensionData dimensionData = result.Dimensions[i];
				float num = 2f * options.FontSize;
				double s = (double)num / 2.0;
				float num2 = num / 2f;
				float num3 = num / 4f;
				num = (float)((double)num * dimensionData.Order);
				Font orCreate = FontsCache.GetOrCreate(options.FontName, options.FontSize);
				Point3D point3D = new Point3D((double)dimensionData.Start.X, (double)dimensionData.Start.Y);
				DimensionCacheItem dimensionCacheItem = base.Context.Dimensions[i];
				Vector3D vector3D = (dimensionCacheItem != null) ? dimensionCacheItem.SideOrientationVector : null;
				Vector2D vector2D = (dimensionCacheItem != null) ? dimensionCacheItem.OrientationVector : null;
				if (!(vector3D == null) && !(vector2D == null))
				{
					Vector3D v = -1.0 * vector3D;
					Vector3D vector3D2 = vector2D.ToVector3D();
					Point3D point3D2 = (Point3D)point3D.Clone();
					Point3D a = base.Editor.WorldToScreen(point3D2);
					Vector3D b = vector3D2 * (double)num3;
					for (int j = 0; j < dimensionData.Steps.Count; j++)
					{
						DimensionStep dimensionStep = dimensionData.Steps[j];
						double s2 = dimensionStep.Value;
						if (j == 0)
						{
							list.Add(a + vector3D * (double)num2 + v * (double)num);
							list.Add(a + v * (double)num3 + v * (double)num);
						}
						point3D2 += vector3D2 * s2;
						a = base.Editor.WorldToScreen(point3D2);
						list.Add(base.Editor.WorldToScreen(point3D) + v * (double)num - b);
						list.Add(a + v * (double)num + b);
						list.Add(a + vector3D * (double)num2 + v * (double)num);
						list.Add(a + v * (double)num3 + v * (double)num);
						float num4 = (float)GeometryHelper.#Pmc(vector3D2.AngleInXY);
						RotateFlipType flipType = RenderingHelper.GetFlipType(num4);
						string text = (!string.IsNullOrWhiteSpace(dimensionStep.Text) && options.ShowParameters) ? dimensionStep.Text : s2.ToString(#Phc.#3hc(107362056));
						Point3D point3D3 = point3D2 - vector3D2 * s2 * 0.5;
						point3D3 = base.Editor.WorldToScreen(point3D3);
						point3D3 += v * (double)num + v * s;
						base.Editor.DrawTextExt((int)point3D3.X, (int)point3D3.Y, text, orCreate, options.FontColor.ToDrawingColor(), Color.Transparent, ContentAlignment.MiddleCenter, flipType, num4, false);
					}
				}
			}
			if (list.Any<Point3D>())
			{
				renderContext.EnableXOR(false);
				renderContext.SetColorWireframe(Color.Black, true);
				renderContext.DrawLines(list.ToArray());
			}
		}
	}
}

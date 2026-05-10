using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #Gfe;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000865 RID: 2149
	public sealed class TemplateDimTextsCoreRenderer : TemplatesCoreRenderer
	{
		// Token: 0x0600445E RID: 17502 RVA: 0x0013B180 File Offset: 0x00139380
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

		// Token: 0x0600445F RID: 17503 RVA: 0x0013B1AC File Offset: 0x001393AC
		private void DrawDimensions(TemplateExecutionResult result, TemplateRenderOptions options)
		{
			if (!result.DimTexts.Any<#Lfe>() || !options.ShowAnnotations)
			{
				return;
			}
			RenderContextBase renderContext = base.Editor.renderContext;
			List<Point3D> list = new List<Point3D>(result.DimTexts.Count * 6);
			foreach (#Lfe #Lfe in result.DimTexts)
			{
				float num = 2f * options.FontSize;
				double s = (double)num / 2.0;
				float num2 = num / 2f;
				float num3 = num / 4f;
				num *= (float)#Lfe.Order;
				Font orCreate = FontsCache.GetOrCreate(options.FontName, options.FontSize);
				Point3D point3D = new Point3D((double)#Lfe.StartPoint.X, (double)#Lfe.StartPoint.Y);
				Point3D point3D2 = new Point3D((double)#Lfe.EndPoint.X, (double)#Lfe.EndPoint.Y);
				Vector2D vector2D = new Vector2D(point3D, point3D2);
				vector2D.Normalize();
				bool left = #Lfe.Side == #Ffe.#b;
				Point3D point3D3 = EyeshotGeometry.PointOnSide(point3D, point3D2, left);
				if (!(point3D3 == null))
				{
					Point3D point3D4 = point3D + Vector3D.Subtract(point3D2, point3D) * 0.5;
					Vector3D vector3D = new Vector2D(point3D4, point3D3).ToVector3D();
					vector3D.Normalize();
					Vector3D v = -1.0 * vector3D;
					Vector3D vector3D2 = vector2D.ToVector3D();
					Vector3D b = vector3D2 * (double)num3;
					Point3D a = base.Editor.WorldToScreen(point3D);
					Point3D a2 = base.Editor.WorldToScreen(point3D2);
					list.#pR(new Point3D[]
					{
						a + vector3D * (double)num2 + v * (double)num,
						a + v * (double)num3 + v * (double)num
					});
					list.#pR(new Point3D[]
					{
						a2 + vector3D * (double)num2 + v * (double)num,
						a2 + v * (double)num3 + v * (double)num
					});
					list.#pR(new Point3D[]
					{
						a + v * (double)num - b,
						a2 + v * (double)num + b
					});
					float num4 = (float)GeometryHelper.#Pmc(vector3D2.AngleInXY);
					RotateFlipType flipType = RenderingHelper.GetFlipType(num4);
					Point3D point3D5 = (Point3D)point3D4.Clone();
					point3D5 = base.Editor.WorldToScreen(point3D5);
					point3D5 += v * (double)num + v * s;
					base.Editor.DrawTextExt((int)point3D5.X, (int)point3D5.Y, #Lfe.Text, orCreate, options.FontColor.ToDrawingColor(), Color.Transparent, ContentAlignment.MiddleCenter, flipType, num4, false);
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #6he;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000866 RID: 2150
	public sealed class TemplateShapeLabelsCoreRenderer : TemplatesCoreRenderer
	{
		// Token: 0x06004461 RID: 17505 RVA: 0x0013B520 File Offset: 0x00139720
		public override void DrawForeground()
		{
			TemplateExecutionResult result = base.Result;
			if (result == null)
			{
				return;
			}
			TemplateRenderOptions renderOptions = base.RenderOptions;
			if (!result.ShapeLabels.Any<#5he>())
			{
				return;
			}
			RenderContextBase renderContext = base.Editor.renderContext;
			List<CacheItem> cache = base.Context.Cache;
			renderContext.EnableXOR(true);
			foreach (#5he #5he in result.ShapeLabels)
			{
				if (!string.IsNullOrWhiteSpace(#5he.Text))
				{
					double num = (double)(2f * renderOptions.FontSize) / 2.0;
					Font orCreate = FontsCache.GetOrCreate(renderOptions.FontName, renderOptions.FontSize);
					Point3D point3D = new Point3D((double)#5he.Start.X, (double)#5he.Start.Y);
					Point3D point3D2 = new Point3D((double)#5he.End.X, (double)#5he.End.Y);
					Point3D point3D3 = new Point3D((double)#5he.End.X, (double)#5he.End.Y);
					Vector2D vector2D = new Vector2D(point3D, point3D3);
					double length = vector2D.Length;
					vector2D.Normalize();
					TemplateShapeLabelsCoreRenderer.TempPoint tempPoint = this.FindClosestPoint(point3D, vector2D.ToVector3D(), point3D2, length);
					if (tempPoint != null)
					{
						point3D3 = tempPoint.Orientation;
						Point3D closest = tempPoint.Closest;
						Vector3D vector3D = new Vector2D(point3D3, closest).ToVector3D();
						vector3D.Normalize();
						Vector3D v = -1.0 * vector3D;
						Vector3D vector3D2 = vector2D.ToVector3D();
						float num2 = (float)GeometryHelper.#Pmc(vector3D2.AngleInXY);
						RotateFlipType flipType = RenderingHelper.GetFlipType(num2);
						string text = #5he.Text;
						double s = 0.0;
						double s2 = 0.0;
						ContentAlignment textAlign;
						Point3D point3D4;
						switch (#5he.Alignment)
						{
						case #7he.#a:
							textAlign = ContentAlignment.MiddleCenter;
							point3D4 = point3D + Vector3D.Subtract(point3D2, point3D) * 0.5;
							break;
						case #7he.#b:
						{
							textAlign = ContentAlignment.MiddleCenter;
							point3D4 = point3D;
							TextureBase orCreate2 = base.Editor.TextTextureCache.GetOrCreate(base.Editor, text, orCreate, renderOptions.FontColor.ToDrawingColor(), Color.Transparent, textAlign, flipType, num2);
							s = 1.0 * (double)orCreate2.Size.Width / 2.0;
							s2 = num * 1.2;
							break;
						}
						case #7he.#c:
						{
							point3D4 = point3D2;
							textAlign = ContentAlignment.MiddleCenter;
							TextureBase orCreate2 = base.Editor.TextTextureCache.GetOrCreate(base.Editor, text, orCreate, renderOptions.FontColor.ToDrawingColor(), Color.Transparent, textAlign, flipType, num2);
							s = -1.0 * (double)orCreate2.Size.Width / 2.0;
							s2 = -num * 1.2;
							break;
						}
						default:
							throw new ArgumentOutOfRangeException();
						}
						point3D4 = base.Editor.WorldToScreen(point3D4);
						point3D4 += v * num;
						point3D4 += vector3D2 * s + vector3D2 * s2;
						base.Editor.DrawTextExt((int)point3D4.X, (int)point3D4.Y, text, orCreate, renderOptions.FontColor.ToDrawingColor(), Color.Transparent, textAlign, flipType, num2, false);
					}
				}
			}
			renderContext.EnableXOR(false);
		}

		// Token: 0x06004462 RID: 17506 RVA: 0x0013B8C4 File Offset: 0x00139AC4
		private TemplateShapeLabelsCoreRenderer.TempPoint FindClosestPoint(Point3D startPoint, Vector3D orientationVector, Point3D orientationPoint, double originalLength)
		{
			List<TemplateShapeLabelsCoreRenderer.TempPoint> list = new List<TemplateShapeLabelsCoreRenderer.TempPoint>();
			for (double num = 0.0; num <= 1.0; num += 0.1)
			{
				Point3D point3D = startPoint + num * originalLength * orientationVector;
				EyeshootGeneralLineEquation eyeshootGeneralLineEquation = new EyeshootGeneralLineEquation(startPoint, point3D);
				eyeshootGeneralLineEquation = eyeshootGeneralLineEquation.Normal(point3D);
				Point3D point3D2 = RenderingHelper.FindClosestShapePoint(base.Context.Cache, point3D, eyeshootGeneralLineEquation);
				if (!(point3D2 == null))
				{
					list.Add(new TemplateShapeLabelsCoreRenderer.TempPoint(point3D2, point3D));
				}
			}
			if (!list.Any<TemplateShapeLabelsCoreRenderer.TempPoint>())
			{
				return null;
			}
			var <>f__AnonymousType = (from item in list
			select new
			{
				Point = item,
				Distance = item.Closest.DistanceTo(item.Orientation)
			} into item
			orderby item.Distance
			select item).FirstOrDefault();
			if (<>f__AnonymousType == null)
			{
				return null;
			}
			return <>f__AnonymousType.Point;
		}

		// Token: 0x02000867 RID: 2151
		private sealed class TempPoint
		{
			// Token: 0x06004464 RID: 17508 RVA: 0x00039174 File Offset: 0x00037374
			public TempPoint(Point3D closest, Point3D orientation)
			{
				this.Closest = closest;
				this.Orientation = orientation;
			}

			// Token: 0x17001415 RID: 5141
			// (get) Token: 0x06004465 RID: 17509 RVA: 0x0003918A File Offset: 0x0003738A
			public Point3D Closest { get; }

			// Token: 0x17001416 RID: 5142
			// (get) Token: 0x06004466 RID: 17510 RVA: 0x00039192 File Offset: 0x00037392
			public Point3D Orientation { get; }
		}
	}
}

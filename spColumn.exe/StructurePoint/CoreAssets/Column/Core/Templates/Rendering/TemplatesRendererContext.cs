using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000869 RID: 2153
	public sealed class TemplatesRendererContext
	{
		// Token: 0x17001417 RID: 5143
		// (get) Token: 0x0600446B RID: 17515 RVA: 0x000391C7 File Offset: 0x000373C7
		public List<CacheItem> Cache { get; } = new List<CacheItem>();

		// Token: 0x17001418 RID: 5144
		// (get) Token: 0x0600446C RID: 17516 RVA: 0x000391CF File Offset: 0x000373CF
		public List<DimensionCacheItem> Dimensions { get; } = new List<DimensionCacheItem>();

		// Token: 0x0600446D RID: 17517 RVA: 0x0013B9AC File Offset: 0x00139BAC
		public static TemplatesRendererContext Create(TemplateExecutionResult result)
		{
			TemplatesRendererContext templatesRendererContext = new TemplatesRendererContext();
			templatesRendererContext.Cache.AddRange(TemplatesRendererContext.CreateCache(result));
			templatesRendererContext.Dimensions.AddRange(TemplatesRendererContext.CreateDimensionsCache(templatesRendererContext.Cache, result));
			return templatesRendererContext;
		}

		// Token: 0x0600446E RID: 17518 RVA: 0x000391D7 File Offset: 0x000373D7
		private static IEnumerable<DimensionCacheItem> CreateDimensionsCache(IList<CacheItem> covers, TemplateExecutionResult result)
		{
			foreach (DimensionData dimensionData in result.Dimensions)
			{
				devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D((double)dimensionData.Start.X, (double)dimensionData.Start.Y);
				Vector3D vector3D = null;
				Vector2D vector2D = null;
				for (int i = 0; i < 100; i++)
				{
					devDept.Geometry.Point3D point3D2 = new devDept.Geometry.Point3D((double)dimensionData.Orientation.X, (double)dimensionData.Orientation.Y);
					vector2D = new Vector2D(point3D, point3D2);
					double length = vector2D.Length;
					vector2D.Normalize();
					point3D2 = point3D + 1.0 * (double)i / 100.0 * length * vector2D.ToVector3D();
					EyeshootGeneralLineEquation eyeshootGeneralLineEquation = new EyeshootGeneralLineEquation(point3D, point3D2);
					eyeshootGeneralLineEquation = eyeshootGeneralLineEquation.Normal(point3D2);
					devDept.Geometry.Point3D point3D3 = RenderingHelper.FindClosestShapePoint(covers, point3D2, eyeshootGeneralLineEquation);
					if (!(point3D3 == null))
					{
						vector3D = new Vector2D(point3D2, point3D3).ToVector3D();
						vector3D.Normalize();
						break;
					}
				}
				yield return new DimensionCacheItem((vector3D == null) ? null : vector2D, vector3D);
			}
			List<DimensionData>.Enumerator enumerator = default(List<DimensionData>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x0600446F RID: 17519 RVA: 0x0013B9E8 File Offset: 0x00139BE8
		private static List<CacheItem> CreateCache(TemplateExecutionResult result)
		{
			List<CacheItem> list = new List<CacheItem>();
			double[] array = new double[]
			{
				0.05,
				0.005,
				0.1
			};
			foreach (SectionPolygon sectionPolygon in result.Polygons)
			{
				BoundingBoxData boundingBoxData = new BoundingBoxData((from item in sectionPolygon.Points
				select new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)item.X, (double)item.Y)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>());
				List<List<devDept.Geometry.Point3D>> list2 = new List<List<devDept.Geometry.Point3D>>();
				foreach (double num in array)
				{
					List<devDept.Geometry.Point3D> list3 = ReinforcementPatternHelper.#qP(sectionPolygon, Math.Max(boundingBoxData.Width, boundingBoxData.Height) * num, true);
					if (list3 != null && list3.Any<devDept.Geometry.Point3D>())
					{
						list2.Add(list3);
					}
				}
				Geometry geometry = GeometryConverter.#Vxb(sectionPolygon);
				list.Add(new CacheItem(geometry, list2));
			}
			return list;
		}
	}
}

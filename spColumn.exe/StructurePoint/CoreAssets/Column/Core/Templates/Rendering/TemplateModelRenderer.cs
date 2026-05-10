using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #Gfe;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Column.Core.Core;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using TriangleNet.Geometry;
using TriangleNet.Meshing;
using TriangleNet.Topology;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200085B RID: 2139
	public sealed class TemplateModelRenderer : TemplateBaseRenderer
	{
		// Token: 0x060043FC RID: 17404 RVA: 0x00139FD4 File Offset: 0x001381D4
		private void DetermineOverlappingBars(IList<TemplateReinforcementBar> bars)
		{
			this.overlappingBarLocations.Clear();
			List<TemplateModelRenderer.BarDistanceMetadata> list = (from bar in bars
			where (double)bar.Area > TemplateModelRenderer.MinBarArea
			select bar into item
			select new TemplateModelRenderer.BarDistanceMetadata
			{
				Radius = CircleHelper.#wmc((double)item.Area),
				Location = new devDept.Geometry.Point3D((double)item.X, (double)item.Y),
				Bar = item
			}).ToList<TemplateModelRenderer.BarDistanceMetadata>();
			for (int i = 0; i < list.Count; i++)
			{
				TemplateModelRenderer.BarDistanceMetadata barDistanceMetadata = list[i];
				devDept.Geometry.Point3D location = barDistanceMetadata.Location;
				for (int j = i + 1; j < list.Count; j++)
				{
					TemplateModelRenderer.BarDistanceMetadata barDistanceMetadata2 = list[j];
					if (location.DistanceTo(barDistanceMetadata2.Location) < barDistanceMetadata.Radius + barDistanceMetadata2.Radius)
					{
						this.overlappingBarLocations.Add(barDistanceMetadata.Location);
						this.overlappingBarLocations.Add(barDistanceMetadata2.Location);
					}
				}
			}
		}

		// Token: 0x060043FD RID: 17405 RVA: 0x0013A0C4 File Offset: 0x001382C4
		private void RenderReinforcement(TemplateExecutionResult definition, int numberOfShapeLayers, TemplateRenderOptions options)
		{
			this.DetermineOverlappingBars(definition.Bars);
			List<Entity> list = new List<Entity>(definition.Bars.Count + 1);
			double num = (double)(definition.ColoredZones.Count + definition.Polygons.Count) * this.shapeLayerOffset + 0.001;
			List<TemplateReinforcementBar> list2 = definition.Bars;
			this.DetermineOverlappingBars(definition.Bars);
			for (int i = 0; i < list2.Count; i++)
			{
				TemplateReinforcementBar templateReinforcementBar = list2[i];
				if ((double)templateReinforcementBar.Area > 0.001)
				{
					double num2 = Math.Round(CircleHelper.#wmc((double)templateReinforcementBar.Area), this.RadiusDecimalPlaces);
					if (num2 > 0.0)
					{
						bool isOverlapped = this.overlappingBarLocations.Contains(new devDept.Geometry.Point3D((double)templateReinforcementBar.X, (double)templateReinforcementBar.Y));
						TemplateModelRenderer.ReinforcementBlockMetadata block = this.GetBlock(this.reinforcementBlocks, num2, isOverlapped, templateReinforcementBar.Color);
						if (block != null)
						{
							list.Add(new CustomBlockReference(new devDept.Geometry.Point3D((double)templateReinforcementBar.X, (double)templateReinforcementBar.Y, num), block.Block.Name, 0.0)
							{
								VisualOrder = num
							});
						}
					}
				}
			}
			foreach (IGrouping<Color, TemplateReinforcementBar> grouping in from item in definition.Bars
			group item by item.Color)
			{
				this.RenderBarCloud(list, grouping.ToList<TemplateReinforcementBar>(), grouping.Key, numberOfShapeLayers);
			}
			base.AddRange<Entity>(list, #Phc.#3hc(107455589));
		}

		// Token: 0x060043FE RID: 17406 RVA: 0x0013A298 File Offset: 0x00138498
		private TemplateModelRenderer.ReinforcementBlockMetadata GetBlock(IList<TemplateModelRenderer.ReinforcementBlockMetadata> blocks, double radius, bool isOverlapped, Color color)
		{
			return blocks.FirstOrDefault((TemplateModelRenderer.ReinforcementBlockMetadata item) => Math.Abs(item.Radius - radius) < 1E-06 && item.IsOverlapped == isOverlapped && item.Color == color);
		}

		// Token: 0x060043FF RID: 17407 RVA: 0x0013A2D4 File Offset: 0x001384D4
		private void CreateBlocks(TemplateExecutionResult executionResult)
		{
			var source = (from bar in executionResult.Bars
			where (double)bar.Area > 0.001
			select bar into item
			select new
			{
				Radius = Math.Round(CircleHelper.#wmc((double)item.Area), this.RadiusDecimalPlaces),
				Color = item.Color
			}).Distinct().ToList();
			List<TemplateModelRenderer.ReinforcementBlockMetadata> list = this.reinforcementBlocks.ToList<TemplateModelRenderer.ReinforcementBlockMetadata>();
			foreach (var <>f__AnonymousType in from specs in source
			where specs.Radius > 0.0
			select specs)
			{
				this.CreateBarBlock(list, <>f__AnonymousType.Radius, false, <>f__AnonymousType.Color);
				this.CreateBarBlock(list, <>f__AnonymousType.Radius, true, <>f__AnonymousType.Color);
			}
			this.reinforcementBlocks.#F7c(list);
			base.Editor.Blocks.#F7c(from b in list
			select b.Block);
		}

		// Token: 0x06004400 RID: 17408 RVA: 0x0013A3F4 File Offset: 0x001385F4
		private void CreateBarBlock(List<TemplateModelRenderer.ReinforcementBlockMetadata> existingBlocks, double radius, bool isOverlapped, Color color)
		{
			TemplateModelRenderer.ReinforcementBlockMetadata existingBlock = this.GetBlock(existingBlocks, radius, isOverlapped, color);
			if (existingBlock != null)
			{
				existingBlocks.RemoveAll((TemplateModelRenderer.ReinforcementBlockMetadata x) => x.Equals(existingBlock));
				return;
			}
			Block block = this.CreateBarBlock(radius, isOverlapped, color);
			base.Editor.Blocks.AddOrReplace(block);
			this.reinforcementBlocks.Add(new TemplateModelRenderer.ReinforcementBlockMetadata
			{
				Block = block,
				Radius = radius,
				IsOverlapped = isOverlapped,
				Color = color
			});
		}

		// Token: 0x06004401 RID: 17409 RVA: 0x0013A480 File Offset: 0x00138680
		private Block CreateBarBlock(double radius, bool overLapped, Color color)
		{
			string barAreaMaterial = overLapped ? #Phc.#3hc(107455527) : base.CreateOrUpdateMaterial(string.Format(#Phc.#3hc(107455552), color.ToArgb()), color).Name;
			string name;
			if (!overLapped)
			{
				string format = #Phc.#3hc(107455502);
				int num = this.blocksCounter;
				this.blocksCounter = num + 1;
				name = string.Format(format, num);
			}
			else
			{
				string format2 = #Phc.#3hc(107455969);
				int num = this.blocksCounter;
				this.blocksCounter = num + 1;
				name = string.Format(format2, num);
			}
			Block block = new Block(name);
			this.CreateBarEntities(block.Entities, radius, barAreaMaterial);
			return block;
		}

		// Token: 0x06004402 RID: 17410 RVA: 0x0013A528 File Offset: 0x00138728
		private void CreateBarEntities(IList<Entity> entities, double radius, string barAreaMaterial)
		{
			CustomRegion item = new CustomRegion(devDept.Eyeshot.Entities.Region.CreatePolygon(EyeshotHelper.ConstructRegularPolygon(new devDept.Geometry.Point3D(0.0, 0.0, 0.0), radius, 20, 0.0, false).ToArray()))
			{
				MaterialName = barAreaMaterial,
				ColorMethod = colorMethodType.byEntity,
				VisualOrder = 0.01,
				EdgeColor = Color.Transparent
			};
			entities.Add(item);
		}

		// Token: 0x06004403 RID: 17411 RVA: 0x0013A5A8 File Offset: 0x001387A8
		private void RenderBarCloud(List<Entity> entities, IList<TemplateReinforcementBar> bars, Color color, int numberOfShapeLayers)
		{
			if (!bars.Any<TemplateReinforcementBar>())
			{
				return;
			}
			double offset = (double)numberOfShapeLayers * RendererConstants.ShapesLayersSpan + RendererConstants.ReinforcementLayerShift * 3.0;
			CustomPointCloud item2 = new CustomPointCloud((from item in bars
			select new devDept.Geometry.Point3D((double)item.X, (double)item.Y, offset)).ToList<devDept.Geometry.Point3D>(), RendererConstants.BarPointSize)
			{
				Color = color,
				ColorMethod = colorMethodType.byEntity
			};
			entities.Add(item2);
		}

		// Token: 0x06004404 RID: 17412 RVA: 0x0013A61C File Offset: 0x0013881C
		public TemplateModelRenderer(EyeshotEditor editor) : base(editor)
		{
			this.zoomingHelper = new ModelZoomingHelper(editor);
		}

		// Token: 0x17001401 RID: 5121
		// (get) Token: 0x06004405 RID: 17413 RVA: 0x00038D1B File Offset: 0x00036F1B
		// (set) Token: 0x06004406 RID: 17414 RVA: 0x00038D23 File Offset: 0x00036F23
		public int RadiusDecimalPlaces { get; set; } = 3;

		// Token: 0x06004407 RID: 17415 RVA: 0x0013A670 File Offset: 0x00138870
		public void Clear()
		{
			base.Editor.Entities.#71d((Entity entity) => entity.LayerName == #Phc.#3hc(107455589));
			base.Editor.Entities.#71d((Entity entity) => entity.LayerName == #Phc.#3hc(107455930));
			base.Editor.Entities.#71d((Entity entity) => entity.LayerName == #Phc.#3hc(107401209));
			base.Editor.Labels.Clear();
		}

		// Token: 0x06004408 RID: 17416 RVA: 0x00038D2C File Offset: 0x00036F2C
		public void ClearAll()
		{
			this.Clear();
			this.reinforcementBlocks.ForEach(delegate(TemplateModelRenderer.ReinforcementBlockMetadata item)
			{
				base.Editor.Blocks.Remove(item.Block);
			});
			this.reinforcementBlocks.Clear();
		}

		// Token: 0x06004409 RID: 17417 RVA: 0x0013A720 File Offset: 0x00138920
		public void Render(TemplateExecutionResult executionResult, TemplateRenderOptions options, bool zoomFit = true)
		{
			this.Initialize(options);
			base.Editor.CreateControl();
			base.Editor.ViewHomeOverride = delegate()
			{
				this.zoomingHelper.ZoomFitMagic(this.margin);
			};
			base.Editor.ZoomToWorkspaceOverride = new Action(this.ZoomToModel);
			this.Clear();
			this.DrawShapes(executionResult);
			if (options.ShowColoredZones)
			{
				this.DrawZones(executionResult, options);
			}
			this.CreateBlocks(executionResult);
			this.RenderReinforcement(executionResult, 3, options);
			if (options.ShowAnnotations)
			{
				this.DrawLeaders(executionResult, options);
			}
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> newSectionPoints = executionResult.Polygons.SelectMany((SectionPolygon item) => from p in item.Points
			select new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)p.X, (double)p.Y)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> newReinforcementPoints = (from b in executionResult.Bars
			select new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)b.X, (double)b.Y)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			if (zoomFit)
			{
				base.Editor.Entities.Regen(null);
				base.Editor.Entities.UpdateBoundingBox();
				this.zoomingHelper.ZoomFitMagic(newSectionPoints, newReinforcementPoints, this.margin);
				return;
			}
			this.zoomingHelper.UpdateOnly(newSectionPoints, newReinforcementPoints);
		}

		// Token: 0x0600440A RID: 17418 RVA: 0x00038D56 File Offset: 0x00036F56
		private string GetPrefix(#Gge leaderType)
		{
			if (leaderType == #Gge.#c)
			{
				return #Phc.#3hc(107455908);
			}
			if (leaderType == #Gge.#b)
			{
				return #Phc.#3hc(107455935);
			}
			return string.Empty;
		}

		// Token: 0x0600440B RID: 17419 RVA: 0x0013A850 File Offset: 0x00138A50
		private void DrawLeaders(TemplateExecutionResult result, TemplateRenderOptions options)
		{
			base.Editor.Labels.Clear();
			float num = 2f * options.FontSize;
			Font orCreate = FontsCache.GetOrCreate(options.FontName, options.FontSize);
			foreach (LeaderWithText leaderWithText in result.Texts)
			{
				devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D((double)leaderWithText.TargetPoint.X, (double)leaderWithText.TargetPoint.Y);
				devDept.Geometry.Point3D point3D2 = new devDept.Geometry.Point3D((double)leaderWithText.BasePoint.X, (double)leaderWithText.BasePoint.Y);
				devDept.Geometry.Point3D point3D3 = this.FindIntersection(result.Polygons, point3D, point3D2);
				bool flag = point3D.X < point3D2.X;
				string text = string.IsNullOrWhiteSpace(leaderWithText.Line2) ? string.Empty.#O2d() : (this.GetPrefix(leaderWithText.LeaderType2) + leaderWithText.Line2);
				text += System.Environment.NewLine;
				text = text + this.GetPrefix(leaderWithText.LeaderType1) + leaderWithText.Line1;
				text += System.Environment.NewLine;
				text += leaderWithText.GroupName;
				CustomLeaderAndText customLeaderAndText = new CustomLeaderAndText(point3D, text, orCreate, Color.Black, new Vector2D());
				customLeaderAndText.Alignment = (flag ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft);
				customLeaderAndText.IsLeft = flag;
				customLeaderAndText.TargetPosition = point3D;
				customLeaderAndText.Editor = base.Editor;
				customLeaderAndText.BasePosition = point3D2;
				customLeaderAndText.ShapePosition = (point3D3 ?? point3D);
				customLeaderAndText.Margin = (double)(num * (float)(leaderWithText.Order + 1));
				base.Editor.Labels.Add(customLeaderAndText);
			}
		}

		// Token: 0x0600440C RID: 17420 RVA: 0x00038D7B File Offset: 0x00036F7B
		private devDept.Geometry.Point3D Convert(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point point)
		{
			return new devDept.Geometry.Point3D((double)point.X, (double)point.Y);
		}

		// Token: 0x0600440D RID: 17421 RVA: 0x0013AA3C File Offset: 0x00138C3C
		private devDept.Geometry.Point3D FindIntersection(IList<SectionPolygon> polygons, devDept.Geometry.Point3D start, devDept.Geometry.Point3D end)
		{
			foreach (SectionPolygon sectionPolygon in polygons)
			{
				for (int i = 1; i < sectionPolygon.Points.Count; i++)
				{
					Point2D startPoint = this.Convert(sectionPolygon.Points[i - 1]);
					devDept.Geometry.Point3D endPoint = this.Convert(sectionPolygon.Points[i]);
					Point2D point2D = EyeshotGeometry.Intersection(startPoint, endPoint, start, end, true);
					if (point2D != null)
					{
						return new devDept.Geometry.Point3D(point2D.X, point2D.Y);
					}
				}
			}
			return null;
		}

		// Token: 0x0600440E RID: 17422 RVA: 0x0013AAF0 File Offset: 0x00138CF0
		private void Initialize(TemplateRenderOptions options)
		{
			if (!base.LayerExists(#Phc.#3hc(107455589)))
			{
				base.RecreateLayer(#Phc.#3hc(107455589));
			}
			if (!base.LayerExists(#Phc.#3hc(107455930)))
			{
				base.RecreateLayer(#Phc.#3hc(107455930));
			}
			if (!base.LayerExists(#Phc.#3hc(107401209)))
			{
				base.RecreateLayer(#Phc.#3hc(107401209));
			}
			base.CreateOrUpdateMaterial(#Phc.#3hc(107400569), options.SolidsColor.ToDrawingColor());
			base.CreateOrUpdateMaterial(#Phc.#3hc(107400594), options.OpeningsColor.ToDrawingColor());
			base.CreateOrUpdateMaterial(#Phc.#3hc(107401083), options.BarsColor.ToDrawingColor());
			base.CreateOrUpdateMaterial(#Phc.#3hc(107455527), Color.FromArgb(255, 155, 0, 0));
			base.CreateOrUpdateMaterial(#Phc.#3hc(107455901), Color.FromArgb(255, 255, 0, 0));
		}

		// Token: 0x0600440F RID: 17423 RVA: 0x0013AC00 File Offset: 0x00138E00
		private void DrawZones(TemplateExecutionResult executionResult, TemplateRenderOptions options)
		{
			List<Entity> list = new List<Entity>();
			List<SectionPolygon> list2 = executionResult.ColoredZones;
			SectionPolygonValidator sectionPolygonValidator = new SectionPolygonValidator(#ice.Irregular, 0);
			double num = (double)(executionResult.Polygons.Count + 1) * this.shapeLayerOffset;
			for (int i = 0; i < list2.Count; i++)
			{
				SectionPolygon polygon = list2[i];
				ZoneInfo zoneInfo = options.ZoneInfos.FirstOrDefault((ZoneInfo zi) => zi.Id == polygon.Id);
				if (zoneInfo != null && sectionPolygonValidator.Validate(polygon).IsValid)
				{
					double offset = num + (double)i * 0.0001;
					List<devDept.Geometry.Point3D> list3 = (from item in polygon.Points
					select new devDept.Geometry.Point3D((double)item.X, (double)item.Y, offset)).ToList<devDept.Geometry.Point3D>();
					if (list3.Count > 1 && list3[0].DistanceTo(list3.Last<devDept.Geometry.Point3D>()) <= 0.001)
					{
						list3.RemoveAt(list3.Count - 1);
					}
					GenericMesher genericMesher = new GenericMesher();
					Vertex[] array = (from item in list3
					select new Vertex(item.X, item.Y)).ToArray<Vertex>();
					devDept.Geometry.Point3D[] vertices = (from item in array
					select new devDept.Geometry.Point3D(item.X, item.Y, offset)).ToArray<devDept.Geometry.Point3D>();
					Polygon polygon2 = new Polygon();
					polygon2.Add(new Contour(array), false);
					List<IndexTriangle> triangles = (from triangle in genericMesher.Triangulate(polygon2, new ConstraintOptions
					{
						ConformingDelaunay = false
					}).Triangles
					select new IndexTriangle(triangle.GetVertexID(0), triangle.GetVertexID(1), triangle.GetVertexID(2))).ToList<IndexTriangle>();
					string name = #Phc.#3hc(107455868) + zoneInfo.ColorIndex.ToString();
					list.Add(new CustomMeshEntity(vertices, triangles)
					{
						VisualOrder = offset,
						MaterialName = base.CreateOrUpdateMaterial(name, zoneInfo.ShapeColor).Name,
						ColorMethod = colorMethodType.byEntity,
						EdgesColor = null,
						EdgeStyle = Mesh.edgeStyleType.None
					});
				}
			}
			base.AddRange<Entity>(list, #Phc.#3hc(107455930));
		}

		// Token: 0x06004410 RID: 17424 RVA: 0x0013AE50 File Offset: 0x00139050
		private void DrawShapes(TemplateExecutionResult executionResult)
		{
			List<Entity> list = new List<Entity>();
			List<SectionPolygon> list2 = (from item in executionResult.Polygons
			orderby item.Application == PolygonApplication.Solid descending, item.Id
			select item).ToList<SectionPolygon>();
			SectionPolygonValidator sectionPolygonValidator = new SectionPolygonValidator(#ice.Irregular, 0);
			for (int i = 0; i < list2.Count; i++)
			{
				SectionPolygon sectionPolygon = list2[i];
				if (sectionPolygonValidator.Validate(sectionPolygon).IsValid)
				{
					double offset = (double)i * this.shapeLayerOffset;
					List<devDept.Geometry.Point3D> list3 = (from item in sectionPolygon.Points
					select new devDept.Geometry.Point3D((double)item.X, (double)item.Y, offset)).ToList<devDept.Geometry.Point3D>();
					if (list3.Count > 1 && list3[0].DistanceTo(list3.Last<devDept.Geometry.Point3D>()) <= 0.001)
					{
						list3.RemoveAt(list3.Count - 1);
					}
					GenericMesher genericMesher = new GenericMesher();
					Vertex[] array = (from item in list3
					select new Vertex(item.X, item.Y)).ToArray<Vertex>();
					devDept.Geometry.Point3D[] vertices = (from item in array
					select new devDept.Geometry.Point3D(item.X, item.Y, offset)).ToArray<devDept.Geometry.Point3D>();
					Polygon polygon = new Polygon();
					polygon.Add(new Contour(array), false);
					List<IndexTriangle> triangles = (from triangle in genericMesher.Triangulate(polygon, new ConstraintOptions
					{
						ConformingDelaunay = false
					}).Triangles
					select new IndexTriangle(triangle.GetVertexID(0), triangle.GetVertexID(1), triangle.GetVertexID(2))).ToList<IndexTriangle>();
					list.Add(new CustomMeshEntity(vertices, triangles)
					{
						VisualOrder = offset,
						MaterialName = ((sectionPolygon.Application == PolygonApplication.Solid) ? #Phc.#3hc(107400569) : #Phc.#3hc(107400594)),
						ColorMethod = colorMethodType.byEntity
					});
				}
			}
			base.AddRange<Entity>(list, #Phc.#3hc(107455930));
		}

		// Token: 0x06004411 RID: 17425 RVA: 0x0013B06C File Offset: 0x0013926C
		private void ZoomToModel()
		{
			for (int i = 0; i < 2; i++)
			{
				this.<ZoomToModel>g__Impl|40_0();
			}
		}

		// Token: 0x06004416 RID: 17430 RVA: 0x00038DF0 File Offset: 0x00036FF0
		[CompilerGenerated]
		private void <ZoomToModel>g__Impl|40_0()
		{
			base.Editor.ZoomToWorkspace(20);
			base.Editor.Invalidate();
			base.Editor.Entities.UpdateBoundingBox();
		}

		// Token: 0x04001EC9 RID: 7881
		private readonly HashSet<devDept.Geometry.Point3D> overlappingBarLocations = new HashSet<devDept.Geometry.Point3D>();

		// Token: 0x04001ECA RID: 7882
		public static double MinBarArea = 0.001;

		// Token: 0x04001ECB RID: 7883
		private const string SolidMaterial = "SolidsMaterial";

		// Token: 0x04001ECC RID: 7884
		private const string OpeningsMaterial = "OpeningsMaterial";

		// Token: 0x04001ECD RID: 7885
		private const string DimensionsLayer = "DimensionsLayer";

		// Token: 0x04001ECE RID: 7886
		private const string BarAreaMaterial = "BarAreaMaterial";

		// Token: 0x04001ECF RID: 7887
		private const string InvalidBarMaterial = "InvalidBarMaterial";

		// Token: 0x04001ED0 RID: 7888
		private const string InvalidBarPointMaterial = "InvalidBarPointMaterial";

		// Token: 0x04001ED1 RID: 7889
		private const string SectionLayer = "TemplateSectionLayer";

		// Token: 0x04001ED2 RID: 7890
		private const string ReinforcementLayer = "TemplateReinforcementLayer";

		// Token: 0x04001ED3 RID: 7891
		private readonly ModelZoomingHelper zoomingHelper;

		// Token: 0x04001ED4 RID: 7892
		private int blocksCounter;

		// Token: 0x04001ED5 RID: 7893
		private readonly List<TemplateModelRenderer.ReinforcementBlockMetadata> reinforcementBlocks = new List<TemplateModelRenderer.ReinforcementBlockMetadata>();

		// Token: 0x04001ED6 RID: 7894
		private readonly int margin = 100;

		// Token: 0x04001ED7 RID: 7895
		private readonly double shapeLayerOffset = 0.0001;

		// Token: 0x0200085C RID: 2140
		private sealed class ReinforcementBlockMetadata
		{
			// Token: 0x17001402 RID: 5122
			// (get) Token: 0x06004417 RID: 17431 RVA: 0x00038E1A File Offset: 0x0003701A
			// (set) Token: 0x06004418 RID: 17432 RVA: 0x00038E22 File Offset: 0x00037022
			public Block Block { get; set; }

			// Token: 0x17001403 RID: 5123
			// (get) Token: 0x06004419 RID: 17433 RVA: 0x00038E2B File Offset: 0x0003702B
			// (set) Token: 0x0600441A RID: 17434 RVA: 0x00038E33 File Offset: 0x00037033
			public double Radius { get; set; }

			// Token: 0x17001404 RID: 5124
			// (get) Token: 0x0600441B RID: 17435 RVA: 0x00038E3C File Offset: 0x0003703C
			// (set) Token: 0x0600441C RID: 17436 RVA: 0x00038E44 File Offset: 0x00037044
			public bool IsOverlapped { get; set; }

			// Token: 0x17001405 RID: 5125
			// (get) Token: 0x0600441D RID: 17437 RVA: 0x00038E4D File Offset: 0x0003704D
			// (set) Token: 0x0600441E RID: 17438 RVA: 0x00038E55 File Offset: 0x00037055
			public Color Color { get; set; }
		}

		// Token: 0x0200085D RID: 2141
		private struct BarDistanceMetadata
		{
			// Token: 0x17001406 RID: 5126
			// (get) Token: 0x06004420 RID: 17440 RVA: 0x00038E5E File Offset: 0x0003705E
			// (set) Token: 0x06004421 RID: 17441 RVA: 0x00038E66 File Offset: 0x00037066
			public TemplateReinforcementBar Bar { readonly get; set; }

			// Token: 0x17001407 RID: 5127
			// (get) Token: 0x06004422 RID: 17442 RVA: 0x00038E6F File Offset: 0x0003706F
			// (set) Token: 0x06004423 RID: 17443 RVA: 0x00038E77 File Offset: 0x00037077
			public devDept.Geometry.Point3D Location { readonly get; set; }

			// Token: 0x17001408 RID: 5128
			// (get) Token: 0x06004424 RID: 17444 RVA: 0x00038E80 File Offset: 0x00037080
			// (set) Token: 0x06004425 RID: 17445 RVA: 0x00038E88 File Offset: 0x00037088
			public double Radius { readonly get; set; }
		}
	}
}

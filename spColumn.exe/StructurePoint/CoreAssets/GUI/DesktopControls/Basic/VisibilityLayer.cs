using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AD3 RID: 2771
	public sealed class VisibilityLayer : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06005A26 RID: 23078 RVA: 0x0016E2E0 File Offset: 0x0016C4E0
		public VisibilityLayer(IModelEditorControl modelEditorControl, VisibilityLayer parentVisibilityLayer)
		{
			this.modelEditorControl = modelEditorControl;
			this.ParentVisibilityLayer = parentVisibilityLayer;
			this.multiLineDrawingResults = new HashSet<IMultilineDrawingResult>();
			this.dashedMultiLineDrawingResults = new HashSet<IDashedMultilineDrawingResult>();
			this.pointsDrawingResults = new HashSet<IPointsDrawingResult>();
			this.polygonsDrawingResults = new HashSet<IPolygonsDrawingResult>();
			this.annotationDrawingResults = new HashSet<IAnnotationDrawingResult>();
			this.textDrawingResults = new HashSet<ITextDrawingResult>();
			this.multiTextsDrawingResults = new HashSet<IMultiTextDrawingResult>();
			this.billboardTextDrawingResults = new HashSet<IBillboardTextDrawingResult>();
			this.isVisible = true;
		}

		// Token: 0x17001971 RID: 6513
		// (get) Token: 0x06005A27 RID: 23079 RVA: 0x0004AE81 File Offset: 0x00049081
		// (set) Token: 0x06005A28 RID: 23080 RVA: 0x0016E378 File Offset: 0x0016C578
		public bool IsVisible
		{
			get
			{
				return this.isVisible;
			}
			set
			{
				if (this.isVisible != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107351275));
					this.isVisible = value;
					this.MyApplyVisibility(value);
					base.RaisePropertyChanged(#Phc.#3hc(107351275));
				}
			}
		}

		// Token: 0x17001972 RID: 6514
		// (get) Token: 0x06005A29 RID: 23081 RVA: 0x0004AE8D File Offset: 0x0004908D
		// (set) Token: 0x06005A2A RID: 23082 RVA: 0x0004AE99 File Offset: 0x00049099
		public VisibilityLayer ParentVisibilityLayer { get; private set; }

		// Token: 0x17001973 RID: 6515
		// (get) Token: 0x06005A2B RID: 23083 RVA: 0x0004AEAA File Offset: 0x000490AA
		public bool IsParentLayerVisible
		{
			get
			{
				return this.ParentVisibilityLayer == null || this.ParentVisibilityLayer.IsVisible;
			}
		}

		// Token: 0x17001974 RID: 6516
		// (get) Token: 0x06005A2C RID: 23084 RVA: 0x0004AECD File Offset: 0x000490CD
		public IEnumerable<Point> AllPoints
		{
			get
			{
				return this.MyGetAllPoints();
			}
		}

		// Token: 0x06005A2D RID: 23085 RVA: 0x0004AEDD File Offset: 0x000490DD
		public void AddDependentLayer(VisibilityLayer visibilityLayer)
		{
			if (visibilityLayer == null || this.dependentVisibilityLayers.Contains(visibilityLayer))
			{
				return;
			}
			this.dependentVisibilityLayers.Add(visibilityLayer);
		}

		// Token: 0x06005A2E RID: 23086 RVA: 0x0004AF09 File Offset: 0x00049109
		public void Add(IMultilineDrawingResult multilineDrawingResult)
		{
			#X0d.#V0d(multilineDrawingResult, #Phc.#3hc(107424323), Component.DesktopControls, #Phc.#3hc(107424290));
			this.MyAdd<IMultilineDrawingResult>(this.multiLineDrawingResults, multilineDrawingResult);
		}

		// Token: 0x06005A2F RID: 23087 RVA: 0x0004AF3F File Offset: 0x0004913F
		public void Add(IDashedMultilineDrawingResult multilineDrawingResult)
		{
			#X0d.#V0d(multilineDrawingResult, #Phc.#3hc(107424323), Component.DesktopControls, #Phc.#3hc(107424749));
			this.MyAdd<IDashedMultilineDrawingResult>(this.dashedMultiLineDrawingResults, multilineDrawingResult);
		}

		// Token: 0x06005A30 RID: 23088 RVA: 0x0004AF75 File Offset: 0x00049175
		public void Add(IMultiTextDrawingResult multiTextDrawingResult)
		{
			#X0d.#V0d(multiTextDrawingResult, #Phc.#3hc(107424728), Component.DesktopControls, #Phc.#3hc(107424695));
			this.MyAdd<IMultiTextDrawingResult>(this.multiTextsDrawingResults, multiTextDrawingResult);
		}

		// Token: 0x06005A31 RID: 23089 RVA: 0x0004AFAB File Offset: 0x000491AB
		public void Add(IPointsDrawingResult pointsDrawingResult)
		{
			#X0d.#V0d(pointsDrawingResult, #Phc.#3hc(107466878), Component.DesktopControls, #Phc.#3hc(107424610));
			this.MyAdd<IPointsDrawingResult>(this.pointsDrawingResults, pointsDrawingResult);
		}

		// Token: 0x06005A32 RID: 23090 RVA: 0x0004AFE1 File Offset: 0x000491E1
		public void Add(IPolygonsDrawingResult polygonsDrawingResult)
		{
			#X0d.#V0d(polygonsDrawingResult, #Phc.#3hc(107467170), Component.DesktopControls, #Phc.#3hc(107424557));
			this.MyAdd<IPolygonsDrawingResult>(this.polygonsDrawingResults, polygonsDrawingResult);
		}

		// Token: 0x06005A33 RID: 23091 RVA: 0x0004B017 File Offset: 0x00049217
		public void Add(IAnnotationDrawingResult annotationDrawingResult)
		{
			#X0d.#V0d(annotationDrawingResult, #Phc.#3hc(107424536), Component.DesktopControls, #Phc.#3hc(107423991));
			this.MyAdd<IAnnotationDrawingResult>(this.annotationDrawingResults, annotationDrawingResult);
		}

		// Token: 0x06005A34 RID: 23092 RVA: 0x0004B04D File Offset: 0x0004924D
		public void Add(ITextDrawingResult textDrawingResult)
		{
			#X0d.#V0d(textDrawingResult, #Phc.#3hc(107423906), Component.DesktopControls, #Phc.#3hc(107423881));
			this.MyAdd<ITextDrawingResult>(this.textDrawingResults, textDrawingResult);
		}

		// Token: 0x06005A35 RID: 23093 RVA: 0x0004B083 File Offset: 0x00049283
		public void Add(IBillboardTextDrawingResult billboardTextDrawingResult)
		{
			#X0d.#V0d(billboardTextDrawingResult, #Phc.#3hc(107423860), Component.DesktopControls, #Phc.#3hc(107423791));
			this.MyAdd<IBillboardTextDrawingResult>(this.billboardTextDrawingResults, billboardTextDrawingResult);
		}

		// Token: 0x06005A36 RID: 23094 RVA: 0x0016E3C8 File Offset: 0x0016C5C8
		public void Remove(IMultilineDrawingResult multilineDrawingResult)
		{
			#X0d.#V0d(multilineDrawingResult, #Phc.#3hc(107424323), Component.DesktopControls, #Phc.#3hc(107423770));
			this.multiLineDrawingResults.Remove(multilineDrawingResult);
			this.modelEditorControl.RemoveFromView(multilineDrawingResult);
		}

		// Token: 0x06005A37 RID: 23095 RVA: 0x0016E418 File Offset: 0x0016C618
		public void Remove(IDashedMultilineDrawingResult multilineDrawingResult)
		{
			#X0d.#V0d(multilineDrawingResult, #Phc.#3hc(107424323), Component.DesktopControls, #Phc.#3hc(107423770));
			this.dashedMultiLineDrawingResults.Remove(multilineDrawingResult);
			this.modelEditorControl.RemoveFromView(multilineDrawingResult);
		}

		// Token: 0x06005A38 RID: 23096 RVA: 0x0016E468 File Offset: 0x0016C668
		public void Remove(IPointsDrawingResult pointsDrawingResult)
		{
			#X0d.#V0d(pointsDrawingResult, #Phc.#3hc(107466878), Component.DesktopControls, #Phc.#3hc(107424197));
			this.pointsDrawingResults.Remove(pointsDrawingResult);
			this.modelEditorControl.RemoveFromView(pointsDrawingResult);
		}

		// Token: 0x06005A39 RID: 23097 RVA: 0x0016E4B8 File Offset: 0x0016C6B8
		public void Remove(IPolygonsDrawingResult polygonsDrawingResult)
		{
			#X0d.#V0d(polygonsDrawingResult, #Phc.#3hc(107467170), Component.DesktopControls, #Phc.#3hc(107424176));
			this.polygonsDrawingResults.Remove(polygonsDrawingResult);
			this.modelEditorControl.RemoveFromView(polygonsDrawingResult);
		}

		// Token: 0x06005A3A RID: 23098 RVA: 0x0016E508 File Offset: 0x0016C708
		public void Remove(IAnnotationDrawingResult annotationDrawingResult)
		{
			#X0d.#V0d(annotationDrawingResult, #Phc.#3hc(107424536), Component.DesktopControls, #Phc.#3hc(107424123));
			this.annotationDrawingResults.Remove(annotationDrawingResult);
			this.modelEditorControl.RemoveFromView(annotationDrawingResult);
		}

		// Token: 0x06005A3B RID: 23099 RVA: 0x0016E558 File Offset: 0x0016C758
		public void Remove(ITextDrawingResult textDrawingResult)
		{
			#X0d.#V0d(textDrawingResult, #Phc.#3hc(107423906), Component.DesktopControls, #Phc.#3hc(107424038));
			this.textDrawingResults.Remove(textDrawingResult);
			this.modelEditorControl.RemoveFromView(textDrawingResult);
		}

		// Token: 0x06005A3C RID: 23100 RVA: 0x0016E5A8 File Offset: 0x0016C7A8
		public void Remove(IBillboardTextDrawingResult billboardTextDrawingResult)
		{
			#X0d.#V0d(billboardTextDrawingResult, #Phc.#3hc(107423860), Component.DesktopControls, #Phc.#3hc(107424017));
			this.billboardTextDrawingResults.Remove(billboardTextDrawingResult);
			this.modelEditorControl.RemoveFromView(billboardTextDrawingResult);
		}

		// Token: 0x06005A3D RID: 23101 RVA: 0x0016E5F8 File Offset: 0x0016C7F8
		public void Remove(IMultiTextDrawingResult multiTextDrawingResult)
		{
			#X0d.#V0d(multiTextDrawingResult, #Phc.#3hc(107424728), Component.DesktopControls, #Phc.#3hc(107423452));
			this.multiTextsDrawingResults.Remove(multiTextDrawingResult);
			this.modelEditorControl.RemoveFromView(multiTextDrawingResult);
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x0016E648 File Offset: 0x0016C848
		public void RemoveAllDrawingResults()
		{
			using (this.modelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				this.modelEditorControl.RemoveFromView(this.multiLineDrawingResults);
				this.modelEditorControl.RemoveFromView(this.dashedMultiLineDrawingResults);
				this.modelEditorControl.RemoveFromView(this.pointsDrawingResults);
				this.modelEditorControl.RemoveFromView(this.polygonsDrawingResults);
				this.modelEditorControl.RemoveFromView(this.annotationDrawingResults);
				this.modelEditorControl.RemoveFromView(this.textDrawingResults);
				this.modelEditorControl.RemoveFromView(this.multiTextsDrawingResults);
				this.modelEditorControl.RemoveFromView(this.billboardTextDrawingResults);
				this.multiLineDrawingResults.Clear();
				this.dashedMultiLineDrawingResults.Clear();
				this.pointsDrawingResults.Clear();
				this.polygonsDrawingResults.Clear();
				this.annotationDrawingResults.Clear();
				this.textDrawingResults.Clear();
				this.multiTextsDrawingResults.Clear();
				this.billboardTextDrawingResults.Clear();
			}
		}

		// Token: 0x06005A3F RID: 23103 RVA: 0x0016E780 File Offset: 0x0016C980
		private void MyAdd<T>(HashSet<T> set, T element) where T : IDrawingResult
		{
			bool flag = set.Add(element);
			if (this.IsVisible && flag)
			{
				this.modelEditorControl.AddToView(element);
			}
		}

		// Token: 0x06005A40 RID: 23104 RVA: 0x0016E7BC File Offset: 0x0016C9BC
		private void MyApplyVisibilityForDirectLayerContent(bool visible)
		{
			using (this.modelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				if (visible)
				{
					foreach (IPolygonsDrawingResult polygonsDrawingResult in this.polygonsDrawingResults)
					{
						this.modelEditorControl.AddToView(polygonsDrawingResult);
						VisibilityLayer.MyShakeLines(polygonsDrawingResult, 0.001);
					}
					foreach (IMultilineDrawingResult multilineDrawingResult in this.multiLineDrawingResults)
					{
						this.modelEditorControl.AddToView(multilineDrawingResult);
						multilineDrawingResult.LineThickness += 0.001;
					}
					foreach (IDashedMultilineDrawingResult dashedMultilineDrawingResult in this.dashedMultiLineDrawingResults)
					{
						this.modelEditorControl.AddToView(dashedMultilineDrawingResult);
						dashedMultilineDrawingResult.LineThickness += 0.001;
					}
					this.modelEditorControl.AddToView(this.pointsDrawingResults);
					this.modelEditorControl.AddToView(this.annotationDrawingResults);
					this.modelEditorControl.AddToView(this.textDrawingResults);
					this.modelEditorControl.AddToView(this.multiTextsDrawingResults);
					this.modelEditorControl.AddToView(this.billboardTextDrawingResults);
				}
				else
				{
					foreach (IPolygonsDrawingResult polygonsDrawingResult2 in this.polygonsDrawingResults)
					{
						this.modelEditorControl.RemoveFromView(polygonsDrawingResult2);
						VisibilityLayer.MyShakeLines(polygonsDrawingResult2, -0.001);
					}
					foreach (IMultilineDrawingResult multilineDrawingResult2 in this.multiLineDrawingResults)
					{
						this.modelEditorControl.RemoveFromView(multilineDrawingResult2);
						multilineDrawingResult2.LineThickness -= 0.001;
					}
					foreach (IDashedMultilineDrawingResult dashedMultilineDrawingResult2 in this.dashedMultiLineDrawingResults)
					{
						this.modelEditorControl.RemoveFromView(dashedMultilineDrawingResult2);
						dashedMultilineDrawingResult2.LineThickness -= 0.001;
					}
					this.modelEditorControl.RemoveFromView(this.pointsDrawingResults);
					this.modelEditorControl.RemoveFromView(this.annotationDrawingResults);
					this.modelEditorControl.RemoveFromView(this.textDrawingResults);
					this.modelEditorControl.RemoveFromView(this.multiTextsDrawingResults);
					this.modelEditorControl.RemoveFromView(this.billboardTextDrawingResults);
				}
			}
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x0016EB50 File Offset: 0x0016CD50
		private void MyApplyVisibilityForDependentLayers(bool visible)
		{
			if (visible)
			{
				using (List<VisibilityLayer>.Enumerator enumerator = this.dependentVisibilityLayers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VisibilityLayer visibilityLayer = enumerator.Current;
						bool flag = this.dependentLayersVisibilityCache.#F1d(visibilityLayer, true);
						visibilityLayer.IsVisible = flag;
					}
					return;
				}
			}
			foreach (VisibilityLayer visibilityLayer2 in this.dependentVisibilityLayers)
			{
				this.dependentLayersVisibilityCache[visibilityLayer2] = visibilityLayer2.IsVisible;
				visibilityLayer2.IsVisible = false;
			}
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x0004B0B9 File Offset: 0x000492B9
		private void MyApplyVisibility(bool visible)
		{
			this.MyApplyVisibilityForDirectLayerContent(visible);
			this.MyApplyVisibilityForDependentLayers(visible);
			this.modelEditorControl.TransparencySorter.PerformSimpleTransparencySort();
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x0016EC28 File Offset: 0x0016CE28
		private static void MyShakeLines(IPolygonsDrawingResult polygonsDrawingResult, double value)
		{
			foreach (IPolylineDrawingResult polylineDrawingResult in polygonsDrawingResult.InnerEdgesDrawingResults.Union(polygonsDrawingResult.OuterEdgesDrawingResults))
			{
				polylineDrawingResult.LineThickness += value;
			}
		}

		// Token: 0x06005A44 RID: 23108 RVA: 0x0016EC94 File Offset: 0x0016CE94
		private IList<Point> MyGetAllPoints()
		{
			List<Point3D> list = new List<Point3D>();
			list.AddRange(this.multiLineDrawingResults.SelectMany((IMultilineDrawingResult item) => item.Positions));
			list.AddRange(this.dashedMultiLineDrawingResults.SelectMany((IDashedMultilineDrawingResult item) => item.Positions));
			list.AddRange(this.pointsDrawingResults.SelectMany((IPointsDrawingResult item) => item.Points));
			list.AddRange(this.polygonsDrawingResults.SelectMany((IPolygonsDrawingResult item) => item.OuterEdgesDrawingResults).SelectMany((IPolylineDrawingResult item) => item.Positions));
			list.AddRange(this.polygonsDrawingResults.SelectMany((IPolygonsDrawingResult item) => item.InnerEdgesDrawingResults).SelectMany((IPolylineDrawingResult item) => item.Positions));
			list.AddRange(from item in this.textDrawingResults
			select item.Position);
			return PointsConverter.#vsc((from item in list
			where !double.IsNaN(item.X) && !double.IsNaN(item.Y) && !double.IsNaN(item.Z)
			select item).ToList<Point3D>());
		}

		// Token: 0x0400259D RID: 9629
		private const double CnstLinesUpdateThreshold = 0.001;

		// Token: 0x0400259E RID: 9630
		private readonly IModelEditorControl modelEditorControl;

		// Token: 0x0400259F RID: 9631
		private readonly HashSet<IPolygonsDrawingResult> polygonsDrawingResults;

		// Token: 0x040025A0 RID: 9632
		private readonly HashSet<IPointsDrawingResult> pointsDrawingResults;

		// Token: 0x040025A1 RID: 9633
		private readonly HashSet<IMultilineDrawingResult> multiLineDrawingResults;

		// Token: 0x040025A2 RID: 9634
		private readonly HashSet<IDashedMultilineDrawingResult> dashedMultiLineDrawingResults;

		// Token: 0x040025A3 RID: 9635
		private readonly HashSet<IAnnotationDrawingResult> annotationDrawingResults;

		// Token: 0x040025A4 RID: 9636
		private readonly HashSet<ITextDrawingResult> textDrawingResults;

		// Token: 0x040025A5 RID: 9637
		private readonly HashSet<IMultiTextDrawingResult> multiTextsDrawingResults;

		// Token: 0x040025A6 RID: 9638
		private readonly HashSet<IBillboardTextDrawingResult> billboardTextDrawingResults;

		// Token: 0x040025A7 RID: 9639
		private bool isVisible;

		// Token: 0x040025A8 RID: 9640
		private readonly List<VisibilityLayer> dependentVisibilityLayers = new List<VisibilityLayer>();

		// Token: 0x040025A9 RID: 9641
		private readonly Dictionary<VisibilityLayer, bool> dependentLayersVisibilityCache = new Dictionary<VisibilityLayer, bool>();
	}
}

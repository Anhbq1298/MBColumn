using System;
using System.Collections.Generic;
using System.Windows.Media;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008DB RID: 2267
	public class SnapPointsMarker : ISnapPointsMarker
	{
		// Token: 0x060047D5 RID: 18389 RVA: 0x00142368 File Offset: 0x00140568
		public SnapPointsMarker(IModelEditorControl modelEditorControl, IDrawingResultsFactory drawingResultsFactory)
		{
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107452193));
			#X0d.#V0d(drawingResultsFactory, #Phc.#3hc(107451628), Component.DesktopControls, #Phc.#3hc(107451599));
			this.modelEditorControl = modelEditorControl;
			this.PointsDrawingResult = drawingResultsFactory.CreatePointsDrawingResult();
			this.PointsDrawingResult.PointColor = this.DefaultSnapPointsColor;
			this.PointsDrawingResult.PointSize = 4.0;
			this.SnapPointZOffset = 0.06;
		}

		// Token: 0x1700150A RID: 5386
		// (get) Token: 0x060047D6 RID: 18390 RVA: 0x0003C964 File Offset: 0x0003AB64
		// (set) Token: 0x060047D7 RID: 18391 RVA: 0x0003C970 File Offset: 0x0003AB70
		public double SnapPointZOffset { get; set; }

		// Token: 0x1700150B RID: 5387
		// (get) Token: 0x060047D8 RID: 18392 RVA: 0x0003C981 File Offset: 0x0003AB81
		// (set) Token: 0x060047D9 RID: 18393 RVA: 0x0003C98D File Offset: 0x0003AB8D
		public IPointsDrawingResult PointsDrawingResult { get; private set; }

		// Token: 0x1700150C RID: 5388
		// (get) Token: 0x060047DA RID: 18394 RVA: 0x0003C99E File Offset: 0x0003AB9E
		// (set) Token: 0x060047DB RID: 18395 RVA: 0x0003C9AA File Offset: 0x0003ABAA
		public Color DefaultSnapPointsColor { get; set; }

		// Token: 0x1700150D RID: 5389
		// (get) Token: 0x060047DC RID: 18396 RVA: 0x0003C9BB File Offset: 0x0003ABBB
		// (set) Token: 0x060047DD RID: 18397 RVA: 0x0003C9C7 File Offset: 0x0003ABC7
		public Color KeyPointSnapPointColor { get; set; }

		// Token: 0x1700150E RID: 5390
		// (get) Token: 0x060047DE RID: 18398 RVA: 0x0003C9D8 File Offset: 0x0003ABD8
		// (set) Token: 0x060047DF RID: 18399 RVA: 0x0003C9E4 File Offset: 0x0003ABE4
		public double DefaultSnapPointsSize { get; set; }

		// Token: 0x1700150F RID: 5391
		// (get) Token: 0x060047E0 RID: 18400 RVA: 0x0003C9F5 File Offset: 0x0003ABF5
		// (set) Token: 0x060047E1 RID: 18401 RVA: 0x0003CA01 File Offset: 0x0003AC01
		public double KeyPointSnapPointSize { get; set; }

		// Token: 0x060047E2 RID: 18402 RVA: 0x001423F8 File Offset: 0x001405F8
		public virtual void Mark(Point3D? point)
		{
			if (point != null)
			{
				this.PointsDrawingResult.Points = new List<Point3D>
				{
					PointsConverter.#Csc(point.Value, this.SnapPointZOffset)
				};
				this.PointsDrawingResult.PointColor = this.DefaultSnapPointsColor;
				this.PointsDrawingResult.PointSize = this.DefaultSnapPointsSize;
				this.modelEditorControl.AddToView(this.PointsDrawingResult);
				return;
			}
			this.modelEditorControl.RemoveFromView(this.PointsDrawingResult);
		}

		// Token: 0x060047E3 RID: 18403 RVA: 0x00142490 File Offset: 0x00140690
		public virtual void Mark(#Atc snapToPointResult)
		{
			if (snapToPointResult == null || snapToPointResult.NoSnappingPerformed)
			{
				this.modelEditorControl.RemoveFromView(this.PointsDrawingResult);
				return;
			}
			snapToPointResult.SnapToPointOrigin;
			this.PointsDrawingResult.PointColor = this.DefaultSnapPointsColor;
			this.PointsDrawingResult.PointSize = this.DefaultSnapPointsSize;
			this.modelEditorControl.AddToView(this.PointsDrawingResult);
			this.PointsDrawingResult.Points = new List<Point3D>
			{
				PointsConverter.#Csc(snapToPointResult.Point, this.SnapPointZOffset)
			};
		}

		// Token: 0x060047E4 RID: 18404 RVA: 0x0014253C File Offset: 0x0014073C
		public virtual void Mark(#fuc snapToEdgeResult)
		{
			if (snapToEdgeResult == null)
			{
				this.modelEditorControl.RemoveFromView(this.PointsDrawingResult);
				return;
			}
			this.PointsDrawingResult.Points = new List<Point3D>
			{
				PointsConverter.#vsc(snapToEdgeResult.Point, this.SnapPointZOffset)
			};
			if (snapToEdgeResult.SnapToEdgeOrigin == #iuc.#a)
			{
				this.PointsDrawingResult.PointColor = this.KeyPointSnapPointColor;
				this.PointsDrawingResult.PointSize = this.KeyPointSnapPointSize;
			}
			else
			{
				this.PointsDrawingResult.PointColor = this.DefaultSnapPointsColor;
				this.PointsDrawingResult.PointSize = this.DefaultSnapPointsSize;
			}
			this.modelEditorControl.AddToView(this.PointsDrawingResult);
		}

		// Token: 0x04002082 RID: 8322
		private const double CnstSnappingPointOffset = 0.06;

		// Token: 0x04002083 RID: 8323
		private readonly IModelEditorControl modelEditorControl;
	}
}

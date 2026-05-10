using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Column.Core.Core
{
	// Token: 0x0200086F RID: 2159
	public sealed class ModelZoomingHelper
	{
		// Token: 0x06004498 RID: 17560 RVA: 0x00039317 File Offset: 0x00037517
		public ModelZoomingHelper(EyeshotEditor editor)
		{
			this.editor = editor;
		}

		// Token: 0x06004499 RID: 17561 RVA: 0x0013BE1C File Offset: 0x0013A01C
		public void ZoomFitMagic(int margin = -1)
		{
			margin = Math.Max(margin, this.editor.Zoom.FitMargin);
			this.editor.ZoomFitExt(false, margin);
			this.editor.AdjustNearAndFarPlanes();
			this.editor.Invalidate();
			double num = this.CalculateViewProportion();
			if (num <= 0.0)
			{
				return;
			}
			double? num2 = this.CalculateENB();
			if (num2 == null)
			{
				return;
			}
			double num3 = Math.Min(this.GetDesiredProportion(num2.Value), num);
			double distance = this.editor.Camera.Distance * num / num3;
			this.editor.Camera.Distance = distance;
			this.editor.AdjustNearAndFarPlanes();
			this.editor.Invalidate();
		}

		// Token: 0x0600449A RID: 17562 RVA: 0x0003933C File Offset: 0x0003753C
		public void UpdateOnly(IList<Point> newSectionPoints, IList<Point> newReinforcementPoints)
		{
			this.sectionPoints.Clear();
			this.reinforcementPoints.Clear();
			this.sectionPoints.AddRange(newSectionPoints);
			this.reinforcementPoints.AddRange(newReinforcementPoints);
		}

		// Token: 0x0600449B RID: 17563 RVA: 0x0003936C File Offset: 0x0003756C
		public void ZoomFitMagic(IList<Point> newSectionPoints, IList<Point> newReinforcementPoints, int margin = -1)
		{
			this.UpdateOnly(newSectionPoints, newReinforcementPoints);
			this.ZoomFitMagic(margin);
		}

		// Token: 0x0600449C RID: 17564 RVA: 0x0003937D File Offset: 0x0003757D
		private double GetDesiredProportion(double enb)
		{
			if (enb <= 40.0)
			{
				return 0.4;
			}
			if (enb <= 80.0)
			{
				return 0.6;
			}
			return 0.8;
		}

		// Token: 0x0600449D RID: 17565 RVA: 0x0013BEDC File Offset: 0x0013A0DC
		private double CalculateViewProportion()
		{
			this.editor.Entities.Regen(null);
			this.editor.Entities.UpdateBoundingBox();
			this.editor.Camera.UpdateMatrices();
			this.editor.Camera.UpdateLocation();
			devDept.Geometry.Point3D point3D = this.editor.WorldToScreen(this.editor.Entities.BoxMin);
			devDept.Geometry.Point3D point3D2 = this.editor.WorldToScreen(this.editor.Entities.BoxMax);
			double actualHeight = this.editor.ActualHeight;
			double num = point3D2.Y - point3D.Y;
			double actualWidth = this.editor.ActualWidth;
			double num2 = point3D2.X - point3D.X;
			return Math.Max(num / actualHeight, num2 / actualWidth);
		}

		// Token: 0x0600449E RID: 17566 RVA: 0x0013BFA4 File Offset: 0x0013A1A4
		private double? CalculateENB()
		{
			int count = this.reinforcementPoints.Count;
			List<Point> list = this.sectionPoints.ToList<Point>();
			list.AddRange(this.reinforcementPoints);
			if (list.Any<Point>())
			{
				BoundingBoxData boundingBoxData = new BoundingBoxData(list);
				return new double?((double)count * 1.0 * (2.0 - Math.Min(boundingBoxData.Width, boundingBoxData.Height) / Math.Max(boundingBoxData.Width, boundingBoxData.Height)));
			}
			return null;
		}

		// Token: 0x04001F26 RID: 7974
		private readonly EyeshotEditor editor;

		// Token: 0x04001F27 RID: 7975
		private readonly List<Point> sectionPoints = new List<Point>();

		// Token: 0x04001F28 RID: 7976
		private readonly List<Point> reinforcementPoints = new List<Point>();
	}
}

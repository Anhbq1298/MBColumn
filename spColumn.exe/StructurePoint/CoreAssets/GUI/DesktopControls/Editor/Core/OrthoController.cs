using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #o1d;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AF5 RID: 2805
	public sealed class OrthoController
	{
		// Token: 0x06005B7B RID: 23419 RVA: 0x0004C8D4 File Offset: 0x0004AAD4
		public OrthoController(OrthoControllerParams parameters)
		{
			this.parameters = parameters;
		}

		// Token: 0x17001A22 RID: 6690
		// (get) Token: 0x06005B7C RID: 23420 RVA: 0x0004C8E3 File Offset: 0x0004AAE3
		public bool IsOrthoActive
		{
			get
			{
				return this.parameters.IsOrthoEnabled() && this.startPoint != null;
			}
		}

		// Token: 0x17001A23 RID: 6691
		// (get) Token: 0x06005B7D RID: 23421 RVA: 0x0016FC8C File Offset: 0x0016DE8C
		private List<Point3D> AxesDirections
		{
			get
			{
				return new List<Point3D>
				{
					new Point3D(1.0, 0.0),
					new Point3D(0.0, 1.0)
				};
			}
		}

		// Token: 0x06005B7E RID: 23422 RVA: 0x0004C905 File Offset: 0x0004AB05
		public void SetStartPoint(Point3D startPoint)
		{
			this.startPoint = startPoint;
		}

		// Token: 0x06005B7F RID: 23423 RVA: 0x0004C90E File Offset: 0x0004AB0E
		public void InvalidateStartPoint()
		{
			this.startPoint = null;
		}

		// Token: 0x06005B80 RID: 23424 RVA: 0x0016FCD8 File Offset: 0x0016DED8
		public void DrawOrthoOverlay(EyeshotEditor editor, RenderContextBase renderContext)
		{
			if (!this.IsOrthoActive)
			{
				return;
			}
			(from direction in this.AxesDirections
			select this.startPoint + direction).#I1d(delegate(Point3D referencePoint)
			{
				this.DrawAxisThroughPoint(editor, renderContext, this.startPoint, referencePoint);
			});
		}

		// Token: 0x06005B81 RID: 23425 RVA: 0x0016FD34 File Offset: 0x0016DF34
		public void ApplyConstraintsOnPosition(Point3D currentPosition)
		{
			if (!this.IsOrthoActive)
			{
				return;
			}
			Segment3D nearestAxis = this.GetNearestAxis(currentPosition);
			Point3D point3D = currentPosition.ProjectTo(nearestAxis);
			currentPosition.X = point3D.X;
			currentPosition.Y = point3D.Y;
		}

		// Token: 0x06005B82 RID: 23426 RVA: 0x0016FD74 File Offset: 0x0016DF74
		public Segment3D GetNearestAxis(Point3D currentPosition)
		{
			if (currentPosition == null)
			{
				return null;
			}
			return (from direction in this.AxesDirections
			select new Segment3D(this.startPoint, this.startPoint + direction) into axis
			orderby currentPosition.DistanceTo(axis)
			select axis).First<Segment3D>();
		}

		// Token: 0x06005B83 RID: 23427 RVA: 0x0016FDD4 File Offset: 0x0016DFD4
		private void DrawAxisThroughPoint(EyeshotEditor editor, RenderContextBase renderContext, Point3D basePoint, Point3D referencePoint)
		{
			Vector3D vector3D = new Vector3D(basePoint, referencePoint);
			vector3D.Normalize();
			double s = 300.0;
			Point3D point = basePoint - vector3D * 2.0;
			Point3D point2 = basePoint + vector3D * 2.0;
			Point3D p = editor.WorldToScreen(point);
			Point3D p2 = editor.WorldToScreen(point2);
			Point3D a = editor.WorldToScreen(basePoint);
			Vector3D vector3D2 = new Vector3D(p, p2);
			Vector3D vector3D3 = vector3D2 * -1.0;
			vector3D2.Normalize();
			vector3D3.Normalize();
			renderContext.SetLineStipple(1, 61680, editor.Camera);
			renderContext.SetColorMaterial(Color.FromKnownColor(KnownColor.Gold), false);
			renderContext.SetLineSize(1.5f, true, false);
			renderContext.EnableLineStipple(true);
			renderContext.DrawBufferedLine(a + vector3D2 * s, a + vector3D3 * s);
			renderContext.EndDrawBufferedLines();
			renderContext.EnableLineStipple(false);
		}

		// Token: 0x0400260D RID: 9741
		private const double AxisLineLength = 600.0;

		// Token: 0x0400260E RID: 9742
		private const float AxisLineWidth = 1.5f;

		// Token: 0x0400260F RID: 9743
		private const ushort AxisLineStipple = 61680;

		// Token: 0x04002610 RID: 9744
		private const KnownColor AxisLineColor = KnownColor.Gold;

		// Token: 0x04002611 RID: 9745
		private Point3D startPoint;

		// Token: 0x04002612 RID: 9746
		private readonly OrthoControllerParams parameters;
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A19 RID: 2585
	public abstract class LinesDrawingResultBase : DrawingResultBase, ILinesDrawingResultBase
	{
		// Token: 0x17001895 RID: 6293
		// (get) Token: 0x06005558 RID: 21848 RVA: 0x00046C2E File Offset: 0x00044E2E
		// (set) Token: 0x06005559 RID: 21849 RVA: 0x00046C3A File Offset: 0x00044E3A
		public Visibility Visibility
		{
			get
			{
				return this.visibility;
			}
			set
			{
				if (this.visibility != value)
				{
					this.visibility = value;
					this.OnVisibilityChanged(value);
				}
			}
		}

		// Token: 0x17001896 RID: 6294
		// (get) Token: 0x0600555A RID: 21850 RVA: 0x00046C5F File Offset: 0x00044E5F
		// (set) Token: 0x0600555B RID: 21851 RVA: 0x00046C6B File Offset: 0x00044E6B
		public IEnumerable<Point3D> Positions
		{
			get
			{
				return this.positions;
			}
			set
			{
				this.positions = value;
				this.OnPositionsChanged(value);
			}
		}

		// Token: 0x17001897 RID: 6295
		// (get) Token: 0x0600555C RID: 21852 RVA: 0x00046C87 File Offset: 0x00044E87
		// (set) Token: 0x0600555D RID: 21853 RVA: 0x00046C93 File Offset: 0x00044E93
		public Color LineColor
		{
			get
			{
				return this.lineColor;
			}
			set
			{
				if (this.lineColor != value)
				{
					this.lineColor = value;
					this.OnLineColorChanged(value);
				}
			}
		}

		// Token: 0x17001898 RID: 6296
		// (get) Token: 0x0600555E RID: 21854 RVA: 0x00046CBD File Offset: 0x00044EBD
		// (set) Token: 0x0600555F RID: 21855 RVA: 0x00046CC9 File Offset: 0x00044EC9
		public double LineThickness
		{
			get
			{
				return this.lineThickness;
			}
			set
			{
				if (this.lineThickness != value)
				{
					this.lineThickness = value;
					this.OnLineThicknessChanged(value);
				}
			}
		}

		// Token: 0x06005560 RID: 21856
		protected abstract void OnVisibilityChanged(Visibility newVisibility);

		// Token: 0x06005561 RID: 21857
		protected abstract void OnPositionsChanged(IEnumerable<Point3D> newPositions);

		// Token: 0x06005562 RID: 21858
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "OnLine")]
		protected abstract void OnLineColorChanged(Color newLineColor);

		// Token: 0x06005563 RID: 21859
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "OnLine")]
		protected abstract void OnLineThicknessChanged(double newThickness);

		// Token: 0x06005564 RID: 21860
		public abstract void SetTransforms(#c4d? translateVector, #c4d? scaleVector);

		// Token: 0x04002461 RID: 9313
		private IEnumerable<Point3D> positions;

		// Token: 0x04002462 RID: 9314
		private Visibility visibility;

		// Token: 0x04002463 RID: 9315
		private Color lineColor;

		// Token: 0x04002464 RID: 9316
		private double lineThickness;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #Fmc;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A18 RID: 2584
	public sealed class DashedMultilineDrawingResult : LinesDrawingResultBase, IDrawingResult, ILinesDrawingResultBase, IDashedMultilineDrawingResult
	{
		// Token: 0x0600554C RID: 21836 RVA: 0x00046B38 File Offset: 0x00044D38
		public DashedMultilineDrawingResult()
		{
			this.MultiLineVisual = new MultiLineVisual3D();
			this.SegmentLength = 5.0;
		}

		// Token: 0x17001893 RID: 6291
		// (get) Token: 0x0600554D RID: 21837 RVA: 0x00046B5A File Offset: 0x00044D5A
		// (set) Token: 0x0600554E RID: 21838 RVA: 0x00046B66 File Offset: 0x00044D66
		internal MultiLineVisual3D MultiLineVisual { get; private set; }

		// Token: 0x17001894 RID: 6292
		// (get) Token: 0x0600554F RID: 21839 RVA: 0x00046B77 File Offset: 0x00044D77
		// (set) Token: 0x06005550 RID: 21840 RVA: 0x00046B83 File Offset: 0x00044D83
		public double SegmentLength
		{
			get
			{
				return this.segmentLength;
			}
			set
			{
				if (this.segmentLength != value)
				{
					this.segmentLength = value;
					this.MyRecalculatePositions();
				}
			}
		}

		// Token: 0x06005551 RID: 21841 RVA: 0x00046BA7 File Offset: 0x00044DA7
		protected override void OnVisibilityChanged(Visibility newVisibility)
		{
			this.MultiLineVisual.IsVisible = (newVisibility == Visibility.Visible);
		}

		// Token: 0x06005552 RID: 21842 RVA: 0x00046BC4 File Offset: 0x00044DC4
		protected override void OnPositionsChanged(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> newPositions)
		{
			this.currentPoints = ((newPositions != null) ? newPositions.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>() : null);
			this.MyRecalculatePositions();
		}

		// Token: 0x06005553 RID: 21843 RVA: 0x00046BEA File Offset: 0x00044DEA
		protected override void OnLineColorChanged(Color newLineColor)
		{
			this.MultiLineVisual.LineColor = newLineColor;
		}

		// Token: 0x06005554 RID: 21844 RVA: 0x00046C04 File Offset: 0x00044E04
		protected override void OnLineThicknessChanged(double newThickness)
		{
			this.MultiLineVisual.LineThickness = newThickness;
		}

		// Token: 0x06005555 RID: 21845 RVA: 0x00165310 File Offset: 0x00163510
		public override void SetTransforms(#c4d? translateVector, #c4d? scaleVector)
		{
			if (translateVector == null && scaleVector == null)
			{
				return;
			}
			Transform3DGroup transform3DGroup = new Transform3DGroup();
			if (translateVector != null)
			{
				transform3DGroup.Children.Add(new TranslateTransform3D(translateVector.Value.Convert()));
			}
			if (scaleVector != null)
			{
				transform3DGroup.Children.Add(new ScaleTransform3D(scaleVector.Value.Convert()));
			}
			this.MultiLineVisual.Transform = transform3DGroup;
		}

		// Token: 0x06005556 RID: 21846 RVA: 0x00165398 File Offset: 0x00163598
		private void MyRecalculatePositions()
		{
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = this.currentPoints;
			if (list != null)
			{
				this.MultiLineVisual.Positions = new Point3DCollection(#jsc.#dsc(list, this.segmentLength).Convert());
			}
		}

		// Token: 0x06005557 RID: 21847 RVA: 0x00046C1E File Offset: 0x00044E1E
		protected internal override object RetrieveDisplayedObject()
		{
			return this.MultiLineVisual;
		}

		// Token: 0x0400245E RID: 9310
		private IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> currentPoints;

		// Token: 0x0400245F RID: 9311
		private double segmentLength;
	}
}

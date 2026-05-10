using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A16 RID: 2582
	public sealed class CrossIndicatorDrawingResult : DrawingResultBase, IDrawingResult, ICrossIndicatorDrawingResult
	{
		// Token: 0x06005528 RID: 21800 RVA: 0x00164FC4 File Offset: 0x001631C4
		public CrossIndicatorDrawingResult()
		{
			this.MultiLineVisual3D = new MultiLineVisual3D();
			this.LineThickness = 1.5;
			this.CrossSegmentDefaultLength = 8.0;
			this.Scale = 1.0;
			this.crossSegmentDefaultOffset = 2.5;
			this.LineColor = Colors.Black;
			this.CenterPoint = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			this.GapInCenter = true;
		}

		// Token: 0x17001882 RID: 6274
		// (get) Token: 0x06005529 RID: 21801 RVA: 0x00046952 File Offset: 0x00044B52
		// (set) Token: 0x0600552A RID: 21802 RVA: 0x0004695E File Offset: 0x00044B5E
		internal MultiLineVisual3D MultiLineVisual3D { get; private set; }

		// Token: 0x17001883 RID: 6275
		// (get) Token: 0x0600552B RID: 21803 RVA: 0x0004696F File Offset: 0x00044B6F
		// (set) Token: 0x0600552C RID: 21804 RVA: 0x00046988 File Offset: 0x00044B88
		public double LineThickness
		{
			get
			{
				return this.MultiLineVisual3D.LineThickness;
			}
			set
			{
				if (this.MultiLineVisual3D.LineThickness != value)
				{
					this.MultiLineVisual3D.LineThickness = value;
				}
			}
		}

		// Token: 0x17001884 RID: 6276
		// (get) Token: 0x0600552D RID: 21805 RVA: 0x000469B0 File Offset: 0x00044BB0
		// (set) Token: 0x0600552E RID: 21806 RVA: 0x000469C9 File Offset: 0x00044BC9
		public Color LineColor
		{
			get
			{
				return this.MultiLineVisual3D.LineColor;
			}
			set
			{
				if (this.MultiLineVisual3D.LineColor != value)
				{
					this.MultiLineVisual3D.LineColor = value;
				}
			}
		}

		// Token: 0x17001885 RID: 6277
		// (get) Token: 0x0600552F RID: 21807 RVA: 0x000469F6 File Offset: 0x00044BF6
		public double CrossSegmentLength
		{
			get
			{
				return this.crossSegmentDefaultLength * this.scale;
			}
		}

		// Token: 0x17001886 RID: 6278
		// (get) Token: 0x06005530 RID: 21808 RVA: 0x00046A0D File Offset: 0x00044C0D
		// (set) Token: 0x06005531 RID: 21809 RVA: 0x00046A19 File Offset: 0x00044C19
		public double CrossSegmentDefaultLength
		{
			get
			{
				return this.crossSegmentDefaultLength;
			}
			set
			{
				if (this.crossSegmentDefaultLength != value)
				{
					this.crossSegmentDefaultLength = value;
					this.MyUpdateGeometry();
				}
			}
		}

		// Token: 0x17001887 RID: 6279
		// (get) Token: 0x06005532 RID: 21810 RVA: 0x00046A3D File Offset: 0x00044C3D
		// (set) Token: 0x06005533 RID: 21811 RVA: 0x00046A49 File Offset: 0x00044C49
		public double Scale
		{
			get
			{
				return this.scale;
			}
			set
			{
				if (this.scale != value)
				{
					this.scale = value;
					this.MyUpdateGeometry();
				}
			}
		}

		// Token: 0x17001888 RID: 6280
		// (get) Token: 0x06005534 RID: 21812 RVA: 0x00046A6D File Offset: 0x00044C6D
		// (set) Token: 0x06005535 RID: 21813 RVA: 0x00046A79 File Offset: 0x00044C79
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D CenterPoint
		{
			get
			{
				return this.centerPoint;
			}
			set
			{
				if (StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#F3d(this.centerPoint, value))
				{
					this.centerPoint = value;
					this.MyUpdateGeometry();
				}
			}
		}

		// Token: 0x17001889 RID: 6281
		// (get) Token: 0x06005536 RID: 21814 RVA: 0x00046AA2 File Offset: 0x00044CA2
		// (set) Token: 0x06005537 RID: 21815 RVA: 0x00046AAE File Offset: 0x00044CAE
		public double EffectiveSegmentLength { get; private set; }

		// Token: 0x1700188A RID: 6282
		// (get) Token: 0x06005538 RID: 21816 RVA: 0x00046ABF File Offset: 0x00044CBF
		// (set) Token: 0x06005539 RID: 21817 RVA: 0x00046ACB File Offset: 0x00044CCB
		public bool GapInCenter
		{
			get
			{
				return this.gapInCenter;
			}
			set
			{
				if (this.gapInCenter != value)
				{
					this.gapInCenter = value;
					this.MyUpdateGeometry();
				}
			}
		}

		// Token: 0x0600553A RID: 21818 RVA: 0x00046AEF File Offset: 0x00044CEF
		private void MyUpdateGeometry()
		{
			if (this.GapInCenter)
			{
				this.MultiLineVisual3D.Positions = this.MyCreateLinesWithGapInCenter();
				return;
			}
			this.MultiLineVisual3D.Positions = this.MyCreateLines();
		}

		// Token: 0x0600553B RID: 21819 RVA: 0x00165040 File Offset: 0x00163240
		private Point3DCollection MyCreateLinesWithGapInCenter()
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			double num = this.crossSegmentDefaultOffset * this.scale;
			double z = this.centerPoint.Z;
			double num2 = 1.75 * this.scale;
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X - this.CrossSegmentLength - num, this.centerPoint.Y, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X - num - num2, this.centerPoint.Y, z));
			this.EffectiveSegmentLength = GeometryHelper.#lcb(list2[0], list2[1]);
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X + this.CrossSegmentLength + num, this.centerPoint.Y, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X + num + num2, this.centerPoint.Y, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y - this.CrossSegmentLength - num, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y - num - num2, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y + this.CrossSegmentLength + num, z));
			list2.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y + num + num2, z));
			return new Point3DCollection(list2.Convert());
		}

		// Token: 0x0600553C RID: 21820 RVA: 0x00165208 File Offset: 0x00163408
		private Point3DCollection MyCreateLines()
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
			double z = this.centerPoint.Z;
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X - this.CrossSegmentLength, this.centerPoint.Y, z));
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X + this.CrossSegmentLength, this.centerPoint.Y, z));
			this.EffectiveSegmentLength = GeometryHelper.#lcb(list[0], list[1]);
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y - this.CrossSegmentLength, z));
			list.Add(new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(this.centerPoint.X, this.centerPoint.Y + this.CrossSegmentLength, z));
			return new Point3DCollection(list.Convert());
		}

		// Token: 0x0600553D RID: 21821 RVA: 0x00046B28 File Offset: 0x00044D28
		protected internal override object RetrieveDisplayedObject()
		{
			return this.MultiLineVisual3D;
		}

		// Token: 0x04002456 RID: 9302
		private const double ConstCenterGap = 1.75;

		// Token: 0x04002457 RID: 9303
		private double crossSegmentDefaultLength;

		// Token: 0x04002458 RID: 9304
		private double crossSegmentDefaultOffset;

		// Token: 0x04002459 RID: 9305
		private double scale;

		// Token: 0x0400245A RID: 9306
		private StructurePoint.CoreAssets.Infrastructure.Data.Point3D centerPoint;

		// Token: 0x0400245B RID: 9307
		private bool gapInCenter;
	}
}

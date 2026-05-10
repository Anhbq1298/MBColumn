using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C5 RID: 2245
	public abstract class ArrowLineBase : Shape
	{
		// Token: 0x06004711 RID: 18193 RVA: 0x00140630 File Offset: 0x0013E830
		protected ArrowLineBase()
		{
			this.PathGeometry = new PathGeometry();
			this.PathFigure = new PathFigure();
			this.PolyLineSegment = new PolyLineSegment();
			this.PathFigure.Segments.Add(this.PolyLineSegment);
			this.startArrowFigure = new PathFigure();
			PolyLineSegment value = new PolyLineSegment();
			this.startArrowFigure.Segments.Add(value);
			this.endArrowFigure = new PathFigure();
			value = new PolyLineSegment();
			this.endArrowFigure.Segments.Add(value);
		}

		// Token: 0x170014DE RID: 5342
		// (get) Token: 0x06004712 RID: 18194 RVA: 0x0003BD05 File Offset: 0x00039F05
		// (set) Token: 0x06004713 RID: 18195 RVA: 0x0003BD11 File Offset: 0x00039F11
		protected PathGeometry PathGeometry { get; set; }

		// Token: 0x170014DF RID: 5343
		// (get) Token: 0x06004714 RID: 18196 RVA: 0x0003BD22 File Offset: 0x00039F22
		// (set) Token: 0x06004715 RID: 18197 RVA: 0x0003BD2E File Offset: 0x00039F2E
		protected PathFigure PathFigure { get; set; }

		// Token: 0x170014E0 RID: 5344
		// (get) Token: 0x06004716 RID: 18198 RVA: 0x0003BD3F File Offset: 0x00039F3F
		// (set) Token: 0x06004717 RID: 18199 RVA: 0x0003BD4B File Offset: 0x00039F4B
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PolyLine")]
		protected PolyLineSegment PolyLineSegment { get; set; }

		// Token: 0x170014E1 RID: 5345
		// (get) Token: 0x06004718 RID: 18200 RVA: 0x0003BD5C File Offset: 0x00039F5C
		// (set) Token: 0x06004719 RID: 18201 RVA: 0x0003BD76 File Offset: 0x00039F76
		public double ArrowAngle
		{
			get
			{
				return (double)base.GetValue(ArrowLineBase.ArrowAngleProperty);
			}
			set
			{
				base.SetValue(ArrowLineBase.ArrowAngleProperty, value);
			}
		}

		// Token: 0x170014E2 RID: 5346
		// (get) Token: 0x0600471A RID: 18202 RVA: 0x0003BD95 File Offset: 0x00039F95
		// (set) Token: 0x0600471B RID: 18203 RVA: 0x0003BDAF File Offset: 0x00039FAF
		public double ArrowLength
		{
			get
			{
				return (double)base.GetValue(ArrowLineBase.ArrowLengthProperty);
			}
			set
			{
				base.SetValue(ArrowLineBase.ArrowLengthProperty, value);
			}
		}

		// Token: 0x170014E3 RID: 5347
		// (get) Token: 0x0600471C RID: 18204 RVA: 0x0003BDCE File Offset: 0x00039FCE
		// (set) Token: 0x0600471D RID: 18205 RVA: 0x0003BDE8 File Offset: 0x00039FE8
		public ArrowEnds ArrowEnds
		{
			get
			{
				return (ArrowEnds)base.GetValue(ArrowLineBase.ArrowEndsProperty);
			}
			set
			{
				base.SetValue(ArrowLineBase.ArrowEndsProperty, value);
			}
		}

		// Token: 0x170014E4 RID: 5348
		// (get) Token: 0x0600471E RID: 18206 RVA: 0x0003BE07 File Offset: 0x0003A007
		// (set) Token: 0x0600471F RID: 18207 RVA: 0x0003BE21 File Offset: 0x0003A021
		public bool IsArrowClosed
		{
			get
			{
				return (bool)base.GetValue(ArrowLineBase.IsArrowClosedProperty);
			}
			set
			{
				base.SetValue(ArrowLineBase.IsArrowClosedProperty, value);
			}
		}

		// Token: 0x170014E5 RID: 5349
		// (get) Token: 0x06004720 RID: 18208 RVA: 0x001406C0 File Offset: 0x0013E8C0
		protected override Geometry DefiningGeometry
		{
			get
			{
				int count = this.PolyLineSegment.Points.Count;
				if (count > 0)
				{
					if ((this.ArrowEnds & ArrowEnds.Start) == ArrowEnds.Start)
					{
						Point startPoint = this.PathFigure.StartPoint;
						Point point = this.PolyLineSegment.Points[0];
						this.PathGeometry.Figures.Add(this.MyCalculateArrow(this.startArrowFigure, point, startPoint));
					}
					if ((this.ArrowEnds & ArrowEnds.End) == ArrowEnds.End)
					{
						Point point2 = (count == 1) ? this.PathFigure.StartPoint : this.PolyLineSegment.Points[count - 2];
						Point point3 = this.PolyLineSegment.Points[count - 1];
						this.PathGeometry.Figures.Add(this.MyCalculateArrow(this.endArrowFigure, point2, point3));
					}
				}
				return this.PathGeometry;
			}
		}

		// Token: 0x06004721 RID: 18209 RVA: 0x001407B4 File Offset: 0x0013E9B4
		private PathFigure MyCalculateArrow(PathFigure pathFigure, Point point1, Point point2)
		{
			Matrix matrix = default(Matrix);
			Vector vector = point1 - point2;
			vector.Normalize();
			vector *= this.ArrowLength;
			PolyLineSegment polyLineSegment = pathFigure.Segments[0] as PolyLineSegment;
			if (polyLineSegment != null)
			{
				polyLineSegment.Points.Clear();
				matrix.Rotate(this.ArrowAngle / 2.0);
				pathFigure.StartPoint = point2 + vector * matrix;
				polyLineSegment.Points.Add(point2);
				matrix.Rotate(-this.ArrowAngle);
				polyLineSegment.Points.Add(point2 + vector * matrix);
			}
			pathFigure.IsClosed = this.IsArrowClosed;
			if (this.IsArrowClosed)
			{
				pathFigure.IsFilled = true;
			}
			return pathFigure;
		}

		// Token: 0x04002038 RID: 8248
		private readonly PathFigure startArrowFigure;

		// Token: 0x04002039 RID: 8249
		private readonly PathFigure endArrowFigure;

		// Token: 0x0400203D RID: 8253
		public static readonly DependencyProperty ArrowAngleProperty = DependencyProperty.Register(#Phc.#3hc(107453246), typeof(double), typeof(ArrowLineBase), new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x0400203E RID: 8254
		public static readonly DependencyProperty ArrowLengthProperty = DependencyProperty.Register(#Phc.#3hc(107453197), typeof(double), typeof(ArrowLineBase), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x0400203F RID: 8255
		public static readonly DependencyProperty ArrowEndsProperty = DependencyProperty.Register(#Phc.#3hc(107453212), typeof(ArrowEnds), typeof(ArrowLineBase), new FrameworkPropertyMetadata(ArrowEnds.End, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x04002040 RID: 8256
		public static readonly DependencyProperty IsArrowClosedProperty = DependencyProperty.Register(#Phc.#3hc(107452655), typeof(bool), typeof(ArrowLineBase), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));
	}
}

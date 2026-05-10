using System;
using System.Windows;
using System.Windows.Media;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C4 RID: 2244
	public sealed class ArrowLine : ArrowLineBase
	{
		// Token: 0x170014D9 RID: 5337
		// (get) Token: 0x06004706 RID: 18182 RVA: 0x0003BC19 File Offset: 0x00039E19
		// (set) Token: 0x06004707 RID: 18183 RVA: 0x0003BC33 File Offset: 0x00039E33
		public double X1
		{
			get
			{
				return (double)base.GetValue(ArrowLine.X1Property);
			}
			set
			{
				base.SetValue(ArrowLine.X1Property, value);
			}
		}

		// Token: 0x170014DA RID: 5338
		// (get) Token: 0x06004708 RID: 18184 RVA: 0x0003BC52 File Offset: 0x00039E52
		// (set) Token: 0x06004709 RID: 18185 RVA: 0x0003BC6C File Offset: 0x00039E6C
		public double Y1
		{
			get
			{
				return (double)base.GetValue(ArrowLine.Y1Property);
			}
			set
			{
				base.SetValue(ArrowLine.Y1Property, value);
			}
		}

		// Token: 0x170014DB RID: 5339
		// (get) Token: 0x0600470A RID: 18186 RVA: 0x0003BC8B File Offset: 0x00039E8B
		// (set) Token: 0x0600470B RID: 18187 RVA: 0x0003BCA5 File Offset: 0x00039EA5
		public double X2
		{
			get
			{
				return (double)base.GetValue(ArrowLine.X2Property);
			}
			set
			{
				base.SetValue(ArrowLine.X2Property, value);
			}
		}

		// Token: 0x170014DC RID: 5340
		// (get) Token: 0x0600470C RID: 18188 RVA: 0x0003BCC4 File Offset: 0x00039EC4
		// (set) Token: 0x0600470D RID: 18189 RVA: 0x0003BCDE File Offset: 0x00039EDE
		public double Y2
		{
			get
			{
				return (double)base.GetValue(ArrowLine.Y2Property);
			}
			set
			{
				base.SetValue(ArrowLine.Y2Property, value);
			}
		}

		// Token: 0x170014DD RID: 5341
		// (get) Token: 0x0600470E RID: 18190 RVA: 0x0014047C File Offset: 0x0013E67C
		protected override Geometry DefiningGeometry
		{
			get
			{
				base.PathGeometry.Figures.Clear();
				base.PathFigure.StartPoint = new Point(this.X1, this.Y1);
				base.PolyLineSegment.Points.Clear();
				base.PolyLineSegment.Points.Add(new Point(this.X2, this.Y2));
				base.PathGeometry.Figures.Add(base.PathFigure);
				return base.DefiningGeometry;
			}
		}

		// Token: 0x04002034 RID: 8244
		public static readonly DependencyProperty X1Property = DependencyProperty.Register(#Phc.#3hc(107453296), typeof(double), typeof(ArrowLine), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x04002035 RID: 8245
		public static readonly DependencyProperty Y1Property = DependencyProperty.Register(#Phc.#3hc(107453259), typeof(double), typeof(ArrowLine), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x04002036 RID: 8246
		public static readonly DependencyProperty X2Property = DependencyProperty.Register(#Phc.#3hc(107453254), typeof(double), typeof(ArrowLine), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		// Token: 0x04002037 RID: 8247
		public static readonly DependencyProperty Y2Property = DependencyProperty.Register(#Phc.#3hc(107453249), typeof(double), typeof(ArrowLine), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
	}
}

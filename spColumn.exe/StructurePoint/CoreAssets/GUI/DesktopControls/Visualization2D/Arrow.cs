using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C2 RID: 2242
	public sealed class Arrow : Shape
	{
		// Token: 0x170014D2 RID: 5330
		// (get) Token: 0x060046F6 RID: 18166 RVA: 0x0003BABB File Offset: 0x00039CBB
		// (set) Token: 0x060046F7 RID: 18167 RVA: 0x0003BAD5 File Offset: 0x00039CD5
		[TypeConverter(typeof(LengthConverter))]
		public double X1
		{
			get
			{
				return (double)base.GetValue(Arrow.X1Property);
			}
			set
			{
				base.SetValue(Arrow.X1Property, value);
			}
		}

		// Token: 0x170014D3 RID: 5331
		// (get) Token: 0x060046F8 RID: 18168 RVA: 0x0003BAF4 File Offset: 0x00039CF4
		// (set) Token: 0x060046F9 RID: 18169 RVA: 0x0003BB0E File Offset: 0x00039D0E
		[TypeConverter(typeof(LengthConverter))]
		public double Y1
		{
			get
			{
				return (double)base.GetValue(Arrow.Y1Property);
			}
			set
			{
				base.SetValue(Arrow.Y1Property, value);
			}
		}

		// Token: 0x170014D4 RID: 5332
		// (get) Token: 0x060046FA RID: 18170 RVA: 0x0003BB2D File Offset: 0x00039D2D
		// (set) Token: 0x060046FB RID: 18171 RVA: 0x0003BB47 File Offset: 0x00039D47
		[TypeConverter(typeof(LengthConverter))]
		public double X2
		{
			get
			{
				return (double)base.GetValue(Arrow.X2Property);
			}
			set
			{
				base.SetValue(Arrow.X2Property, value);
			}
		}

		// Token: 0x170014D5 RID: 5333
		// (get) Token: 0x060046FC RID: 18172 RVA: 0x0003BB66 File Offset: 0x00039D66
		// (set) Token: 0x060046FD RID: 18173 RVA: 0x0003BB80 File Offset: 0x00039D80
		[TypeConverter(typeof(LengthConverter))]
		public double Y2
		{
			get
			{
				return (double)base.GetValue(Arrow.Y2Property);
			}
			set
			{
				base.SetValue(Arrow.Y2Property, value);
			}
		}

		// Token: 0x170014D6 RID: 5334
		// (get) Token: 0x060046FE RID: 18174 RVA: 0x0003BB9F File Offset: 0x00039D9F
		// (set) Token: 0x060046FF RID: 18175 RVA: 0x0003BBB9 File Offset: 0x00039DB9
		[TypeConverter(typeof(LengthConverter))]
		public double HeadWidth
		{
			get
			{
				return (double)base.GetValue(Arrow.HeadWidthProperty);
			}
			set
			{
				base.SetValue(Arrow.HeadWidthProperty, value);
			}
		}

		// Token: 0x170014D7 RID: 5335
		// (get) Token: 0x06004700 RID: 18176 RVA: 0x0003BBD8 File Offset: 0x00039DD8
		// (set) Token: 0x06004701 RID: 18177 RVA: 0x0003BBF2 File Offset: 0x00039DF2
		[TypeConverter(typeof(LengthConverter))]
		public double HeadHeight
		{
			get
			{
				return (double)base.GetValue(Arrow.HeadHeightProperty);
			}
			set
			{
				base.SetValue(Arrow.HeadHeightProperty, value);
			}
		}

		// Token: 0x170014D8 RID: 5336
		// (get) Token: 0x06004702 RID: 18178 RVA: 0x0014016C File Offset: 0x0013E36C
		protected override Geometry DefiningGeometry
		{
			get
			{
				StreamGeometry streamGeometry = new StreamGeometry();
				streamGeometry.FillRule = FillRule.EvenOdd;
				using (StreamGeometryContext streamGeometryContext = streamGeometry.Open())
				{
					this.MyDrawArrowGeometry(streamGeometryContext);
				}
				streamGeometry.Freeze();
				return streamGeometry;
			}
		}

		// Token: 0x06004703 RID: 18179 RVA: 0x001401C4 File Offset: 0x0013E3C4
		private void MyDrawArrowGeometry(StreamGeometryContext context)
		{
			double num = Math.Atan2(this.Y1 - this.Y2, this.X1 - this.X2);
			double num2 = Math.Sin(num);
			double num3 = Math.Cos(num);
			Point startPoint = new Point(this.X1, this.Y1);
			Point point = new Point(this.X2, this.Y2);
			Point point2 = new Point(this.X2 + (this.HeadWidth * num3 - this.HeadHeight * num2), this.Y2 + this.HeadWidth * num2 + this.HeadHeight * num3);
			Point point3 = new Point(this.X2 + (this.HeadWidth * num3 + this.HeadHeight * num2), this.Y2 - (this.HeadHeight * num3 - this.HeadWidth * num2));
			context.BeginFigure(startPoint, true, false);
			context.LineTo(point, true, true);
			context.LineTo(point2, true, true);
			context.LineTo(point, true, true);
			context.LineTo(point3, true, true);
		}

		// Token: 0x04002029 RID: 8233
		public static readonly DependencyProperty X1Property = DependencyProperty.Register(#Phc.#3hc(107453296), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400202A RID: 8234
		public static readonly DependencyProperty Y1Property = DependencyProperty.Register(#Phc.#3hc(107453259), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400202B RID: 8235
		public static readonly DependencyProperty X2Property = DependencyProperty.Register(#Phc.#3hc(107453254), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400202C RID: 8236
		public static readonly DependencyProperty Y2Property = DependencyProperty.Register(#Phc.#3hc(107453249), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400202D RID: 8237
		public static readonly DependencyProperty HeadWidthProperty = DependencyProperty.Register(#Phc.#3hc(107453276), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400202E RID: 8238
		public static readonly DependencyProperty HeadHeightProperty = DependencyProperty.Register(#Phc.#3hc(107453231), typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
	}
}

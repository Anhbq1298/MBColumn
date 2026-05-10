using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008BA RID: 2234
	internal sealed class CustomBillboardTextVisual3D : BillboardVisual3D
	{
		// Token: 0x170014A1 RID: 5281
		// (get) Token: 0x0600466C RID: 18028 RVA: 0x0003AFD8 File Offset: 0x000391D8
		// (set) Token: 0x0600466D RID: 18029 RVA: 0x0003AFF2 File Offset: 0x000391F2
		public Thickness Margin
		{
			get
			{
				return (Thickness)base.GetValue(CustomBillboardTextVisual3D.MarginProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.MarginProperty, value);
			}
		}

		// Token: 0x170014A2 RID: 5282
		// (get) Token: 0x0600466E RID: 18030 RVA: 0x0003B011 File Offset: 0x00039211
		// (set) Token: 0x0600466F RID: 18031 RVA: 0x0003B02B File Offset: 0x0003922B
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextVisual3D.BackgroundProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.BackgroundProperty, value);
			}
		}

		// Token: 0x170014A3 RID: 5283
		// (get) Token: 0x06004670 RID: 18032 RVA: 0x0003B045 File Offset: 0x00039245
		// (set) Token: 0x06004671 RID: 18033 RVA: 0x0003B05F File Offset: 0x0003925F
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextVisual3D.BorderBrushProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.BorderBrushProperty, value);
			}
		}

		// Token: 0x170014A4 RID: 5284
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x0003B079 File Offset: 0x00039279
		// (set) Token: 0x06004673 RID: 18035 RVA: 0x0003B093 File Offset: 0x00039293
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(CustomBillboardTextVisual3D.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.BorderThicknessProperty, value);
			}
		}

		// Token: 0x170014A5 RID: 5285
		// (get) Token: 0x06004674 RID: 18036 RVA: 0x0003B0B2 File Offset: 0x000392B2
		// (set) Token: 0x06004675 RID: 18037 RVA: 0x0003B0CC File Offset: 0x000392CC
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(CustomBillboardTextVisual3D.FontFamilyProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.FontFamilyProperty, value);
			}
		}

		// Token: 0x170014A6 RID: 5286
		// (get) Token: 0x06004676 RID: 18038 RVA: 0x0003B0E6 File Offset: 0x000392E6
		// (set) Token: 0x06004677 RID: 18039 RVA: 0x0003B100 File Offset: 0x00039300
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(CustomBillboardTextVisual3D.FontSizeProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.FontSizeProperty, value);
			}
		}

		// Token: 0x170014A7 RID: 5287
		// (get) Token: 0x06004678 RID: 18040 RVA: 0x0003B11F File Offset: 0x0003931F
		// (set) Token: 0x06004679 RID: 18041 RVA: 0x0003B139 File Offset: 0x00039339
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(CustomBillboardTextVisual3D.FontWeightProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.FontWeightProperty, value);
			}
		}

		// Token: 0x170014A8 RID: 5288
		// (get) Token: 0x0600467A RID: 18042 RVA: 0x0003B158 File Offset: 0x00039358
		// (set) Token: 0x0600467B RID: 18043 RVA: 0x0003B172 File Offset: 0x00039372
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextVisual3D.ForegroundProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.ForegroundProperty, value);
			}
		}

		// Token: 0x170014A9 RID: 5289
		// (get) Token: 0x0600467C RID: 18044 RVA: 0x0003B18C File Offset: 0x0003938C
		// (set) Token: 0x0600467D RID: 18045 RVA: 0x0003B1A6 File Offset: 0x000393A6
		public double HeightFactor
		{
			get
			{
				return (double)base.GetValue(CustomBillboardTextVisual3D.HeightFactorProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.HeightFactorProperty, value);
			}
		}

		// Token: 0x170014AA RID: 5290
		// (get) Token: 0x0600467E RID: 18046 RVA: 0x0003B1C5 File Offset: 0x000393C5
		// (set) Token: 0x0600467F RID: 18047 RVA: 0x0003B1DF File Offset: 0x000393DF
		public MaterialType MaterialType
		{
			get
			{
				return (MaterialType)base.GetValue(CustomBillboardTextVisual3D.MaterialTypeProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.MaterialTypeProperty, value);
			}
		}

		// Token: 0x170014AB RID: 5291
		// (get) Token: 0x06004680 RID: 18048 RVA: 0x0003B1FE File Offset: 0x000393FE
		// (set) Token: 0x06004681 RID: 18049 RVA: 0x0003B218 File Offset: 0x00039418
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(CustomBillboardTextVisual3D.PaddingProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.PaddingProperty, value);
			}
		}

		// Token: 0x170014AC RID: 5292
		// (get) Token: 0x06004682 RID: 18050 RVA: 0x0003B237 File Offset: 0x00039437
		// (set) Token: 0x06004683 RID: 18051 RVA: 0x0003B251 File Offset: 0x00039451
		public string Text
		{
			get
			{
				return (string)base.GetValue(CustomBillboardTextVisual3D.TextProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextVisual3D.TextProperty, value);
			}
		}

		// Token: 0x170014AD RID: 5293
		// (get) Token: 0x06004684 RID: 18052 RVA: 0x0013E310 File Offset: 0x0013C510
		public StructurePoint.CoreAssets.Infrastructure.Data.Size EffectiveModelSize
		{
			get
			{
				System.Windows.Media.Media3D.Rect3D bounds = base.Visual3DModel.Bounds;
				return new StructurePoint.CoreAssets.Infrastructure.Data.Size(bounds.SizeX, bounds.SizeY);
			}
		}

		// Token: 0x06004685 RID: 18053 RVA: 0x0003B26B File Offset: 0x0003946B
		public void BeginUpdate()
		{
			this.isUpdating = true;
		}

		// Token: 0x06004686 RID: 18054 RVA: 0x0003B278 File Offset: 0x00039478
		public void EndUpdate()
		{
			this.isUpdating = false;
			this.MyVisualChanged();
		}

		// Token: 0x06004687 RID: 18055 RVA: 0x0003B293 File Offset: 0x00039493
		private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((CustomBillboardTextVisual3D)d).MyVisualChanged();
		}

		// Token: 0x06004688 RID: 18056 RVA: 0x0013E348 File Offset: 0x0013C548
		private void MyVisualChanged()
		{
			if (this.isUpdating)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.Text))
			{
				base.Material = null;
				return;
			}
			TextBlock textBlock = new TextBlock(new Run(this.Text))
			{
				Foreground = this.Foreground,
				Background = this.Background,
				FontWeight = this.FontWeight,
				Padding = this.Padding
			};
			if (this.FontFamily != null)
			{
				textBlock.FontFamily = this.FontFamily;
			}
			if (this.FontSize > 0.0)
			{
				textBlock.FontSize = this.FontSize;
			}
			FrameworkElement frameworkElement = (this.BorderBrush != null) ? this.MyCreateBorder(textBlock) : textBlock;
			frameworkElement.Measure(new System.Windows.Size(1000.0, 1000.0));
			frameworkElement.Arrange(new System.Windows.Rect(frameworkElement.DesiredSize));
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)(frameworkElement.ActualWidth + this.Margin.Left + this.Margin.Right) + 1, (int)(frameworkElement.ActualHeight + this.Margin.Top + this.Margin.Bottom) + 1, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(frameworkElement);
			ImageBrush brush = new ImageBrush(renderTargetBitmap);
			if (this.MaterialType == MaterialType.Diffuse)
			{
				base.Material = new DiffuseMaterial(brush);
			}
			if (this.MaterialType == MaterialType.Emissive)
			{
				base.Material = new EmissiveMaterial(brush);
			}
			base.Width = frameworkElement.ActualWidth + this.Margin.Left + this.Margin.Right;
			base.Height = frameworkElement.ActualHeight * this.HeightFactor + this.Margin.Top + this.Margin.Bottom;
		}

		// Token: 0x06004689 RID: 18057 RVA: 0x0003B2A8 File Offset: 0x000394A8
		private FrameworkElement MyCreateBorder(TextBlock innerElement)
		{
			return new Border
			{
				BorderBrush = this.BorderBrush,
				BorderThickness = this.BorderThickness,
				Child = innerElement,
				Margin = this.Margin
			};
		}

		// Token: 0x04001FF3 RID: 8179
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(#Phc.#3hc(107363120), typeof(Brush), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF4 RID: 8180
		public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(#Phc.#3hc(107453716), typeof(Brush), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF5 RID: 8181
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107453155), typeof(Thickness), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(new Thickness(1.0), new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF6 RID: 8182
		public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(#Phc.#3hc(107453134), typeof(FontFamily), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF7 RID: 8183
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(#Phc.#3hc(107453149), typeof(double), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(0.0, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF8 RID: 8184
		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(#Phc.#3hc(107453136), typeof(FontWeight), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FF9 RID: 8185
		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(#Phc.#3hc(107453119), typeof(Brush), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(Brushes.Black, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FFA RID: 8186
		public static readonly DependencyProperty HeightFactorProperty = DependencyProperty.Register(#Phc.#3hc(107453070), typeof(double), typeof(CustomBillboardTextVisual3D), new PropertyMetadata(1.0, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FFB RID: 8187
		public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(#Phc.#3hc(107453076), typeof(Thickness), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(new Thickness(0.0), new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FFC RID: 8188
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(#Phc.#3hc(107350927), typeof(string), typeof(CustomBillboardTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FFD RID: 8189
		public static readonly DependencyProperty MaterialTypeProperty = DependencyProperty.Register(#Phc.#3hc(107452996), typeof(MaterialType), typeof(CustomBillboardTextVisual3D), new PropertyMetadata(MaterialType.Diffuse));

		// Token: 0x04001FFE RID: 8190
		public static readonly DependencyProperty MarginProperty = DependencyProperty.Register(#Phc.#3hc(107361172), typeof(Thickness), typeof(CustomBillboardTextVisual3D), new PropertyMetadata(default(Thickness), new PropertyChangedCallback(CustomBillboardTextVisual3D.VisualChanged)));

		// Token: 0x04001FFF RID: 8191
		private bool isUpdating;
	}
}

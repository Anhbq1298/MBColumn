using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Visuals;
using HelixToolkit.Wpf;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008C0 RID: 2240
	internal sealed class CircleTextVisual3D : CircleVisual3D
	{
		// Token: 0x170014C3 RID: 5315
		// (get) Token: 0x060046CD RID: 18125 RVA: 0x0003B76C File Offset: 0x0003996C
		// (set) Token: 0x060046CE RID: 18126 RVA: 0x0003B786 File Offset: 0x00039986
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(CircleTextVisual3D.BackgroundProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.BackgroundProperty, value);
			}
		}

		// Token: 0x170014C4 RID: 5316
		// (get) Token: 0x060046CF RID: 18127 RVA: 0x0003B7A0 File Offset: 0x000399A0
		// (set) Token: 0x060046D0 RID: 18128 RVA: 0x0003B7BA File Offset: 0x000399BA
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(CircleTextVisual3D.BorderBrushProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.BorderBrushProperty, value);
			}
		}

		// Token: 0x170014C5 RID: 5317
		// (get) Token: 0x060046D1 RID: 18129 RVA: 0x0003B7D4 File Offset: 0x000399D4
		// (set) Token: 0x060046D2 RID: 18130 RVA: 0x0003B7EE File Offset: 0x000399EE
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(CircleTextVisual3D.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.BorderThicknessProperty, value);
			}
		}

		// Token: 0x170014C6 RID: 5318
		// (get) Token: 0x060046D3 RID: 18131 RVA: 0x0003B80D File Offset: 0x00039A0D
		// (set) Token: 0x060046D4 RID: 18132 RVA: 0x0003B827 File Offset: 0x00039A27
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(CircleTextVisual3D.FontFamilyProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.FontFamilyProperty, value);
			}
		}

		// Token: 0x170014C7 RID: 5319
		// (get) Token: 0x060046D5 RID: 18133 RVA: 0x0003B841 File Offset: 0x00039A41
		// (set) Token: 0x060046D6 RID: 18134 RVA: 0x0003B85B File Offset: 0x00039A5B
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(CircleTextVisual3D.FontSizeProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.FontSizeProperty, value);
			}
		}

		// Token: 0x170014C8 RID: 5320
		// (get) Token: 0x060046D7 RID: 18135 RVA: 0x0003B87A File Offset: 0x00039A7A
		// (set) Token: 0x060046D8 RID: 18136 RVA: 0x0003B894 File Offset: 0x00039A94
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(CircleTextVisual3D.FontWeightProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.FontWeightProperty, value);
			}
		}

		// Token: 0x170014C9 RID: 5321
		// (get) Token: 0x060046D9 RID: 18137 RVA: 0x0003B8B3 File Offset: 0x00039AB3
		// (set) Token: 0x060046DA RID: 18138 RVA: 0x0003B8CD File Offset: 0x00039ACD
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(CircleTextVisual3D.ForegroundProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.ForegroundProperty, value);
			}
		}

		// Token: 0x170014CA RID: 5322
		// (get) Token: 0x060046DB RID: 18139 RVA: 0x0003B8E7 File Offset: 0x00039AE7
		// (set) Token: 0x060046DC RID: 18140 RVA: 0x0003B901 File Offset: 0x00039B01
		public MaterialType MaterialType
		{
			get
			{
				return (MaterialType)base.GetValue(CircleTextVisual3D.MaterialTypeProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.MaterialTypeProperty, value);
			}
		}

		// Token: 0x170014CB RID: 5323
		// (get) Token: 0x060046DD RID: 18141 RVA: 0x0003B920 File Offset: 0x00039B20
		// (set) Token: 0x060046DE RID: 18142 RVA: 0x0003B93A File Offset: 0x00039B3A
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(CircleTextVisual3D.PaddingProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.PaddingProperty, value);
			}
		}

		// Token: 0x170014CC RID: 5324
		// (get) Token: 0x060046DF RID: 18143 RVA: 0x0003B959 File Offset: 0x00039B59
		// (set) Token: 0x060046E0 RID: 18144 RVA: 0x0003B973 File Offset: 0x00039B73
		public string Text
		{
			get
			{
				return (string)base.GetValue(CircleTextVisual3D.TextProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.TextProperty, value);
			}
		}

		// Token: 0x170014CD RID: 5325
		// (get) Token: 0x060046E1 RID: 18145 RVA: 0x0003B98D File Offset: 0x00039B8D
		// (set) Token: 0x060046E2 RID: 18146 RVA: 0x0003B9A7 File Offset: 0x00039BA7
		public CornerRadius BorderCornerRadius
		{
			get
			{
				return (CornerRadius)base.GetValue(CircleTextVisual3D.BorderCornerRadiusProperty);
			}
			set
			{
				base.SetValue(CircleTextVisual3D.BorderCornerRadiusProperty, value);
			}
		}

		// Token: 0x170014CE RID: 5326
		// (get) Token: 0x060046E3 RID: 18147 RVA: 0x0003B9C6 File Offset: 0x00039BC6
		// (set) Token: 0x060046E4 RID: 18148 RVA: 0x0003B9D2 File Offset: 0x00039BD2
		public bool IsUpdating { get; set; }

		// Token: 0x060046E5 RID: 18149 RVA: 0x0003B9E3 File Offset: 0x00039BE3
		public void Update()
		{
			this.MyVisualChanged();
		}

		// Token: 0x060046E6 RID: 18150 RVA: 0x0003B9F3 File Offset: 0x00039BF3
		private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((CircleTextVisual3D)d).MyVisualChanged();
		}

		// Token: 0x060046E7 RID: 18151 RVA: 0x0013F964 File Offset: 0x0013DB64
		private void MyVisualChanged()
		{
			if (this.IsUpdating)
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
				Padding = this.Padding,
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center,
				MinWidth = 25.0,
				TextAlignment = TextAlignment.Center,
				UseLayoutRounding = true
			};
			if (this.FontFamily != null)
			{
				textBlock.FontFamily = this.FontFamily;
			}
			if (this.FontSize > 0.0)
			{
				textBlock.FontSize = this.FontSize;
			}
			FrameworkElement frameworkElement;
			if (this.BorderBrush != null)
			{
				if (this.BorderCornerRadius.BottomLeft != 0.0 || this.BorderCornerRadius.BottomRight != 0.0 || this.BorderCornerRadius.TopLeft != 0.0 || this.BorderCornerRadius.TopRight != 0.0)
				{
					Grid grid = new Grid();
					grid.UseLayoutRounding = true;
					Border border = this.MyCreateBorder();
					border.Background = this.Background;
					border.Child = grid;
					frameworkElement = border;
					Border border2 = this.MyCreateBorder();
					border2.Background = Brushes.White;
					border2.BorderBrush = null;
					grid.Children.Add(border2);
					grid.Children.Add(textBlock);
					textBlock.OpacityMask = new VisualBrush(border2);
					textBlock.Opacity = 1.0;
				}
				else
				{
					Border border3 = this.MyCreateBorder();
					border3.Child = textBlock;
					frameworkElement = border3;
				}
			}
			else
			{
				frameworkElement = textBlock;
			}
			frameworkElement.Measure(new Size(1000.0, 1000.0));
			frameworkElement.Arrange(new Rect(frameworkElement.DesiredSize));
			double num = 2.0833333333333335;
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)(num * frameworkElement.ActualWidth + 1.0), (int)(num * frameworkElement.ActualHeight + 1.0), num * 96.0, num * 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Clear();
			renderTargetBitmap.Render(frameworkElement);
			ImageBrush brush = new ImageBrush(renderTargetBitmap);
			if (this.MaterialType == MaterialType.Diffuse)
			{
				base.Material = new DiffuseMaterial(brush);
				base.BackMaterial = new DiffuseMaterial(brush);
			}
			if (this.MaterialType == MaterialType.Emissive)
			{
				base.Material = new EmissiveMaterial(brush);
				base.BackMaterial = new EmissiveMaterial(brush);
			}
		}

		// Token: 0x060046E8 RID: 18152 RVA: 0x0013FC28 File Offset: 0x0013DE28
		private Border MyCreateBorder()
		{
			return new Border
			{
				BorderBrush = this.BorderBrush,
				BorderThickness = this.BorderThickness,
				CornerRadius = this.BorderCornerRadius,
				MinWidth = 25.0,
				UseLayoutRounding = true
			};
		}

		// Token: 0x04002018 RID: 8216
		private const double ConstDefaultDpi = 96.0;

		// Token: 0x04002019 RID: 8217
		private const double ConstRenderDpi = 200.0;

		// Token: 0x0400201A RID: 8218
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(#Phc.#3hc(107363120), typeof(Brush), typeof(CircleTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x0400201B RID: 8219
		public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(#Phc.#3hc(107453716), typeof(Brush), typeof(CircleTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x0400201C RID: 8220
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107453155), typeof(Thickness), typeof(CircleTextVisual3D), new UIPropertyMetadata(new Thickness(1.0), new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x0400201D RID: 8221
		public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(#Phc.#3hc(107453134), typeof(FontFamily), typeof(CircleTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x0400201E RID: 8222
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(#Phc.#3hc(107453149), typeof(double), typeof(CircleTextVisual3D), new UIPropertyMetadata(0.0, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x0400201F RID: 8223
		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(#Phc.#3hc(107453136), typeof(FontWeight), typeof(CircleTextVisual3D), new UIPropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x04002020 RID: 8224
		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(#Phc.#3hc(107453119), typeof(Brush), typeof(CircleTextVisual3D), new UIPropertyMetadata(Brushes.Black, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x04002021 RID: 8225
		public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(#Phc.#3hc(107453076), typeof(Thickness), typeof(CircleTextVisual3D), new UIPropertyMetadata(new Thickness(0.0), new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x04002022 RID: 8226
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(#Phc.#3hc(107350927), typeof(string), typeof(CircleTextVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));

		// Token: 0x04002023 RID: 8227
		public static readonly DependencyProperty MaterialTypeProperty = DependencyProperty.Register(#Phc.#3hc(107452996), typeof(MaterialType), typeof(CircleTextVisual3D), new PropertyMetadata(MaterialType.Diffuse));

		// Token: 0x04002024 RID: 8228
		public static readonly DependencyProperty BorderCornerRadiusProperty = DependencyProperty.Register(#Phc.#3hc(107453358), typeof(CornerRadius), typeof(CircleTextVisual3D), new UIPropertyMetadata(new CornerRadius(0.0), new PropertyChangedCallback(CircleTextVisual3D.VisualChanged)));
	}
}

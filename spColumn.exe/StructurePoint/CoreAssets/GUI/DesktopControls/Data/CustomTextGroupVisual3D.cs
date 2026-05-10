using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009E9 RID: 2537
	internal sealed class CustomTextGroupVisual3D : ModelVisual3D
	{
		// Token: 0x170017B1 RID: 6065
		// (get) Token: 0x06005321 RID: 21281 RVA: 0x00044CD9 File Offset: 0x00042ED9
		// (set) Token: 0x06005322 RID: 21282 RVA: 0x00044CF3 File Offset: 0x00042EF3
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(CustomTextGroupVisual3D.BackgroundProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.BackgroundProperty, value);
			}
		}

		// Token: 0x170017B2 RID: 6066
		// (get) Token: 0x06005323 RID: 21283 RVA: 0x00044D0D File Offset: 0x00042F0D
		// (set) Token: 0x06005324 RID: 21284 RVA: 0x00044D27 File Offset: 0x00042F27
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(CustomTextGroupVisual3D.BorderBrushProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.BorderBrushProperty, value);
			}
		}

		// Token: 0x170017B3 RID: 6067
		// (get) Token: 0x06005325 RID: 21285 RVA: 0x00044D41 File Offset: 0x00042F41
		// (set) Token: 0x06005326 RID: 21286 RVA: 0x00044D5B File Offset: 0x00042F5B
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(CustomTextGroupVisual3D.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.BorderThicknessProperty, value);
			}
		}

		// Token: 0x170017B4 RID: 6068
		// (get) Token: 0x06005327 RID: 21287 RVA: 0x00044D7A File Offset: 0x00042F7A
		// (set) Token: 0x06005328 RID: 21288 RVA: 0x00044D94 File Offset: 0x00042F94
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(CustomTextGroupVisual3D.FontFamilyProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.FontFamilyProperty, value);
			}
		}

		// Token: 0x170017B5 RID: 6069
		// (get) Token: 0x06005329 RID: 21289 RVA: 0x00044DAE File Offset: 0x00042FAE
		// (set) Token: 0x0600532A RID: 21290 RVA: 0x00044DC8 File Offset: 0x00042FC8
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(CustomTextGroupVisual3D.FontSizeProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.FontSizeProperty, value);
			}
		}

		// Token: 0x170017B6 RID: 6070
		// (get) Token: 0x0600532B RID: 21291 RVA: 0x00044DE7 File Offset: 0x00042FE7
		// (set) Token: 0x0600532C RID: 21292 RVA: 0x00044E01 File Offset: 0x00043001
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(CustomTextGroupVisual3D.FontWeightProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.FontWeightProperty, value);
			}
		}

		// Token: 0x170017B7 RID: 6071
		// (get) Token: 0x0600532D RID: 21293 RVA: 0x00044E20 File Offset: 0x00043020
		// (set) Token: 0x0600532E RID: 21294 RVA: 0x00044E3A File Offset: 0x0004303A
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(CustomTextGroupVisual3D.ForegroundProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.ForegroundProperty, value);
			}
		}

		// Token: 0x170017B8 RID: 6072
		// (get) Token: 0x0600532F RID: 21295 RVA: 0x00044E54 File Offset: 0x00043054
		// (set) Token: 0x06005330 RID: 21296 RVA: 0x00044E6E File Offset: 0x0004306E
		public double Height
		{
			get
			{
				return (double)base.GetValue(CustomTextGroupVisual3D.HeightProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.HeightProperty, value);
			}
		}

		// Token: 0x170017B9 RID: 6073
		// (get) Token: 0x06005331 RID: 21297 RVA: 0x00044E8D File Offset: 0x0004308D
		// (set) Token: 0x06005332 RID: 21298 RVA: 0x00044EA7 File Offset: 0x000430A7
		public bool IsDoubleSided
		{
			get
			{
				return (bool)base.GetValue(CustomTextGroupVisual3D.IsDoubleSidedProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.IsDoubleSidedProperty, value);
			}
		}

		// Token: 0x170017BA RID: 6074
		// (get) Token: 0x06005333 RID: 21299 RVA: 0x00044EC6 File Offset: 0x000430C6
		// (set) Token: 0x06005334 RID: 21300 RVA: 0x00044EE0 File Offset: 0x000430E0
		public bool IsFlipped
		{
			get
			{
				return (bool)base.GetValue(CustomTextGroupVisual3D.IsFlippedProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.IsFlippedProperty, value);
			}
		}

		// Token: 0x170017BB RID: 6075
		// (get) Token: 0x06005335 RID: 21301 RVA: 0x00044EFF File Offset: 0x000430FF
		// (set) Token: 0x06005336 RID: 21302 RVA: 0x00044F19 File Offset: 0x00043119
		public IList<SpatialTextItem> Items
		{
			get
			{
				return (IList<SpatialTextItem>)base.GetValue(CustomTextGroupVisual3D.ItemsProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.ItemsProperty, value);
			}
		}

		// Token: 0x170017BC RID: 6076
		// (get) Token: 0x06005337 RID: 21303 RVA: 0x00044F33 File Offset: 0x00043133
		// (set) Token: 0x06005338 RID: 21304 RVA: 0x00044F4D File Offset: 0x0004314D
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(CustomTextGroupVisual3D.PaddingProperty);
			}
			set
			{
				base.SetValue(CustomTextGroupVisual3D.PaddingProperty, value);
			}
		}

		// Token: 0x06005339 RID: 21305 RVA: 0x00163618 File Offset: 0x00161818
		internal static Material CreateTextMaterial(IEnumerable<TextItem> items, Func<string, FrameworkElement> createElement, out Dictionary<string, FrameworkElement> elementMap, out Dictionary<FrameworkElement, Rect> elementPositions)
		{
			WrapPanel wrapPanel = new WrapPanel();
			elementMap = new Dictionary<string, FrameworkElement>();
			double num = 16.0;
			foreach (TextItem textItem in items)
			{
				if (!elementMap.ContainsKey(textItem.Text))
				{
					FrameworkElement frameworkElement = createElement(textItem.Text);
					frameworkElement.Measure(new Size(2048.0, 2048.0));
					num = Math.Max(num, frameworkElement.DesiredSize.Width);
					elementMap[textItem.Text] = frameworkElement;
					wrapPanel.Children.Add(frameworkElement);
				}
			}
			int num2 = (int)CustomTextGroupVisual3D.MyOptimizeSize(wrapPanel, num, 1024.0);
			int num3 = (int)Math.Min((double)num2, wrapPanel.ActualHeight);
			elementPositions = new Dictionary<FrameworkElement, Rect>();
			foreach (object obj in wrapPanel.Children)
			{
				FrameworkElement frameworkElement2 = (FrameworkElement)obj;
				Point point = frameworkElement2.TranslatePoint(new Point(0.0, 0.0), wrapPanel);
				double num4 = (double)((int)Math.Floor(point.X));
				double num5 = (double)((int)Math.Floor(point.Y));
				double num6 = (double)((int)Math.Ceiling(point.X + frameworkElement2.RenderSize.Width));
				double num7 = (double)((int)Math.Ceiling(point.Y + frameworkElement2.RenderSize.Height));
				elementPositions[frameworkElement2] = new Rect(num4 / (double)num2, num5 / (double)num3, (num6 - num4) / (double)num2, (num7 - num5) / (double)num3);
			}
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(num2, num3, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(wrapPanel);
			renderTargetBitmap.Freeze();
			return new DiffuseMaterial(new ImageBrush(renderTargetBitmap)
			{
				Stretch = Stretch.Fill,
				ViewboxUnits = BrushMappingMode.RelativeToBoundingBox,
				Viewbox = new Rect(0.0, 0.0, 1.0, 1.0),
				ViewportUnits = BrushMappingMode.Absolute,
				Viewport = new Rect(0.0, 0.0, 1.0, 1.0),
				TileMode = TileMode.None,
				AlignmentX = AlignmentX.Left,
				AlignmentY = AlignmentY.Top
			})
			{
				Color = Colors.White
			};
		}

		// Token: 0x0600533A RID: 21306 RVA: 0x001638F4 File Offset: 0x00161AF4
		private static double MyOptimizeSize(UIElement panel, double minWidth, double maxWidth)
		{
			double num;
			for (num = minWidth; num < maxWidth; num += 50.0)
			{
				panel.Measure(new Size(num, num + 1.0));
				if (panel.DesiredSize.Height <= num)
				{
					break;
				}
			}
			panel.Arrange(new Rect(0.0, 0.0, num, num));
			return num;
		}

		// Token: 0x0600533B RID: 21307 RVA: 0x00044F6C File Offset: 0x0004316C
		private static void MyOnVisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((CustomTextGroupVisual3D)d).MyVisualChanged();
		}

		// Token: 0x0600533C RID: 21308 RVA: 0x0016396C File Offset: 0x00161B6C
		private FrameworkElement MyCreateElement(string text)
		{
			TextBlock textBlock = new TextBlock(new Run(text))
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
			if (this.BorderBrush != null)
			{
				return new Border
				{
					BorderBrush = this.BorderBrush,
					BorderThickness = this.BorderThickness,
					Child = textBlock
				};
			}
			return textBlock;
		}

		// Token: 0x0600533D RID: 21309 RVA: 0x00163A34 File Offset: 0x00161C34
		private void MyVisualChanged()
		{
			if (this.Items == null)
			{
				base.Content = null;
				return;
			}
			List<SpatialTextItem> items = (from i in this.Items
			where !string.IsNullOrEmpty(i.Text)
			select i).ToList<SpatialTextItem>();
			Model3DGroup content = this.MyCreateModelGroup(items);
			base.Content = content;
		}

		// Token: 0x0600533E RID: 21310 RVA: 0x00163A9C File Offset: 0x00161C9C
		private Model3DGroup MyCreateModelGroup(List<SpatialTextItem> items)
		{
			Model3DGroup model3DGroup = new Model3DGroup();
			while (items.Count > 0)
			{
				Dictionary<string, FrameworkElement> dictionary;
				Dictionary<FrameworkElement, Rect> dictionary2;
				Material material = CustomTextGroupVisual3D.CreateTextMaterial(items, new Func<string, FrameworkElement>(this.MyCreateElement), out dictionary, out dictionary2);
				MeshBuilder meshBuilder = new MeshBuilder(false, true);
				List<SpatialTextItem> list = new List<SpatialTextItem>();
				foreach (SpatialTextItem spatialTextItem in items)
				{
					FrameworkElement frameworkElement = dictionary[spatialTextItem.Text];
					Rect elementPositions = dictionary2[frameworkElement];
					double left = elementPositions.Left;
					double right = elementPositions.Right;
					if (elementPositions.Bottom > 1.0)
					{
						break;
					}
					if (this.IsFlipped)
					{
					}
					double xa;
					double ya;
					CustomTextGroupVisual3D.MySetAlignmentFactors(spatialTextItem, out xa, out ya);
					this.MyProcessTextItem(meshBuilder, spatialTextItem, frameworkElement, elementPositions, xa, ya);
					list.Add(spatialTextItem);
				}
				MeshGeometry3D geometry = meshBuilder.ToMesh(false);
				model3DGroup.Children.Add(new GeometryModel3D(geometry, material));
				foreach (SpatialTextItem item in list)
				{
					items.Remove(item);
				}
			}
			return model3DGroup;
		}

		// Token: 0x0600533F RID: 21311 RVA: 0x00163C1C File Offset: 0x00161E1C
		private static void MySetAlignmentFactors(SpatialTextItem item, out double xa, out double ya)
		{
			xa = -0.5;
			if (item.HorizontalAlignment == HorizontalAlignment.Left)
			{
				xa = 0.0;
			}
			if (item.HorizontalAlignment == HorizontalAlignment.Right)
			{
				xa = -1.0;
			}
			ya = -0.5;
			if (item.VerticalAlignment == VerticalAlignment.Top)
			{
				ya = -1.0;
			}
			if (item.VerticalAlignment == VerticalAlignment.Bottom)
			{
				ya = 0.0;
			}
		}

		// Token: 0x06005340 RID: 21312 RVA: 0x00163C9C File Offset: 0x00161E9C
		private void MyProcessTextItem(MeshBuilder builder, SpatialTextItem item, FrameworkElement element, Rect elementPositions, double xa, double ya)
		{
			double left = elementPositions.Left;
			double top = elementPositions.Top;
			double right = elementPositions.Right;
			double bottom = elementPositions.Bottom;
			Point3D position = item.Position;
			Vector3D textDirection = item.TextDirection;
			Vector3D upDirection = item.UpDirection;
			double height = this.Height;
			double num = this.Height / element.ActualHeight * element.ActualWidth;
			Point3D point3D = position + xa * num * textDirection + ya * height * upDirection;
			Point3D point3D2 = point3D + textDirection * num;
			Point3D point3D3 = point3D + upDirection * height + textDirection * num;
			Point3D point3D4 = point3D + upDirection * height;
			builder.AddQuad(point3D, point3D2, point3D3, point3D4, new Point(left, bottom), new Point(right, bottom), new Point(right, top), new Point(left, top));
			if (this.IsDoubleSided)
			{
				builder.AddQuad(point3D2, point3D, point3D4, point3D3, new Point(left, bottom), new Point(right, bottom), new Point(right, top), new Point(left, top));
			}
		}

		// Token: 0x04002408 RID: 9224
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(#Phc.#3hc(107363120), typeof(Brush), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04002409 RID: 9225
		public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(#Phc.#3hc(107453716), typeof(Brush), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240A RID: 9226
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107453155), typeof(Thickness), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(new Thickness(1.0), new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240B RID: 9227
		public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(#Phc.#3hc(107453134), typeof(FontFamily), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240C RID: 9228
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(#Phc.#3hc(107453149), typeof(double), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(10.0, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240D RID: 9229
		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(#Phc.#3hc(107453136), typeof(FontWeight), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240E RID: 9230
		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(#Phc.#3hc(107453119), typeof(Brush), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(Brushes.Black, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x0400240F RID: 9231
		public static readonly DependencyProperty HeightProperty = DependencyProperty.Register(#Phc.#3hc(107412672), typeof(double), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(1.0, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04002410 RID: 9232
		public static readonly DependencyProperty IsDoubleSidedProperty = DependencyProperty.Register(#Phc.#3hc(107462769), typeof(bool), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(false, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04002411 RID: 9233
		public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register(#Phc.#3hc(107462748), typeof(bool), typeof(CustomTextGroupVisual3D), new PropertyMetadata(false, new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04002412 RID: 9234
		public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(#Phc.#3hc(107453085), typeof(IList<SpatialTextItem>), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(new List<SpatialTextItem>(), new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04002413 RID: 9235
		public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(#Phc.#3hc(107453076), typeof(Thickness), typeof(CustomTextGroupVisual3D), new UIPropertyMetadata(new Thickness(0.0), new PropertyChangedCallback(CustomTextGroupVisual3D.MyOnVisualChanged)));
	}
}

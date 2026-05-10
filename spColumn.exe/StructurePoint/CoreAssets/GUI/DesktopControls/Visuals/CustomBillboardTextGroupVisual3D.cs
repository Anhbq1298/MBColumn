using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visuals
{
	// Token: 0x020008B8 RID: 2232
	[ContentProperty("Items")]
	internal sealed class CustomBillboardTextGroupVisual3D : RenderingModelVisual3D
	{
		// Token: 0x06004642 RID: 17986 RVA: 0x0003ABE4 File Offset: 0x00038DE4
		public CustomBillboardTextGroupVisual3D()
		{
			this.builder = new BillboardGeometryBuilder(this);
		}

		// Token: 0x17001492 RID: 5266
		// (get) Token: 0x06004643 RID: 17987 RVA: 0x0003AC0E File Offset: 0x00038E0E
		// (set) Token: 0x06004644 RID: 17988 RVA: 0x0003AC28 File Offset: 0x00038E28
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextGroupVisual3D.BackgroundProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.BackgroundProperty, value);
			}
		}

		// Token: 0x17001493 RID: 5267
		// (get) Token: 0x06004645 RID: 17989 RVA: 0x0003AC42 File Offset: 0x00038E42
		// (set) Token: 0x06004646 RID: 17990 RVA: 0x0003AC5C File Offset: 0x00038E5C
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextGroupVisual3D.BorderBrushProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.BorderBrushProperty, value);
			}
		}

		// Token: 0x17001494 RID: 5268
		// (get) Token: 0x06004647 RID: 17991 RVA: 0x0003AC76 File Offset: 0x00038E76
		// (set) Token: 0x06004648 RID: 17992 RVA: 0x0003AC90 File Offset: 0x00038E90
		public bool IsEnabled
		{
			get
			{
				return (bool)base.GetValue(CustomBillboardTextGroupVisual3D.IsEnabledProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.IsEnabledProperty, value);
			}
		}

		// Token: 0x17001495 RID: 5269
		// (get) Token: 0x06004649 RID: 17993 RVA: 0x0003ACAF File Offset: 0x00038EAF
		// (set) Token: 0x0600464A RID: 17994 RVA: 0x0003ACC9 File Offset: 0x00038EC9
		public Brush PinBrush
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextGroupVisual3D.PinBrushProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.PinBrushProperty, value);
			}
		}

		// Token: 0x17001496 RID: 5270
		// (get) Token: 0x0600464B RID: 17995 RVA: 0x0003ACE3 File Offset: 0x00038EE3
		// (set) Token: 0x0600464C RID: 17996 RVA: 0x0003ACFD File Offset: 0x00038EFD
		public double PinWidth
		{
			get
			{
				return (double)base.GetValue(CustomBillboardTextGroupVisual3D.PinWidthProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.PinWidthProperty, value);
			}
		}

		// Token: 0x17001497 RID: 5271
		// (get) Token: 0x0600464D RID: 17997 RVA: 0x0003AD1C File Offset: 0x00038F1C
		// (set) Token: 0x0600464E RID: 17998 RVA: 0x0003AD36 File Offset: 0x00038F36
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(CustomBillboardTextGroupVisual3D.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.BorderThicknessProperty, value);
			}
		}

		// Token: 0x17001498 RID: 5272
		// (get) Token: 0x0600464F RID: 17999 RVA: 0x0003AD55 File Offset: 0x00038F55
		// (set) Token: 0x06004650 RID: 18000 RVA: 0x0003AD6F File Offset: 0x00038F6F
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(CustomBillboardTextGroupVisual3D.FontFamilyProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.FontFamilyProperty, value);
			}
		}

		// Token: 0x17001499 RID: 5273
		// (get) Token: 0x06004651 RID: 18001 RVA: 0x0003AD89 File Offset: 0x00038F89
		// (set) Token: 0x06004652 RID: 18002 RVA: 0x0003ADA3 File Offset: 0x00038FA3
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(CustomBillboardTextGroupVisual3D.FontSizeProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.FontSizeProperty, value);
			}
		}

		// Token: 0x1700149A RID: 5274
		// (get) Token: 0x06004653 RID: 18003 RVA: 0x0003ADC2 File Offset: 0x00038FC2
		// (set) Token: 0x06004654 RID: 18004 RVA: 0x0003ADDC File Offset: 0x00038FDC
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(CustomBillboardTextGroupVisual3D.FontWeightProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.FontWeightProperty, value);
			}
		}

		// Token: 0x1700149B RID: 5275
		// (get) Token: 0x06004655 RID: 18005 RVA: 0x0003ADFB File Offset: 0x00038FFB
		// (set) Token: 0x06004656 RID: 18006 RVA: 0x0003AE15 File Offset: 0x00039015
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(CustomBillboardTextGroupVisual3D.ForegroundProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.ForegroundProperty, value);
			}
		}

		// Token: 0x1700149C RID: 5276
		// (get) Token: 0x06004657 RID: 18007 RVA: 0x0003AE2F File Offset: 0x0003902F
		// (set) Token: 0x06004658 RID: 18008 RVA: 0x0003AE49 File Offset: 0x00039049
		public double HeightFactor
		{
			get
			{
				return (double)base.GetValue(CustomBillboardTextGroupVisual3D.HeightFactorProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.HeightFactorProperty, value);
			}
		}

		// Token: 0x1700149D RID: 5277
		// (get) Token: 0x06004659 RID: 18009 RVA: 0x0003AE68 File Offset: 0x00039068
		// (set) Token: 0x0600465A RID: 18010 RVA: 0x0003AE74 File Offset: 0x00039074
		public bool IsRendering
		{
			get
			{
				return this.isRendering;
			}
			set
			{
				if (value != this.isRendering)
				{
					this.isRendering = value;
					if (this.isRendering)
					{
						base.SubscribeToRenderingEvent();
						return;
					}
					base.UnsubscribeRenderingEvent();
				}
			}
		}

		// Token: 0x1700149E RID: 5278
		// (get) Token: 0x0600465B RID: 18011 RVA: 0x0003AEA7 File Offset: 0x000390A7
		// (set) Token: 0x0600465C RID: 18012 RVA: 0x0003AEC1 File Offset: 0x000390C1
		public IList<BillboardTextItem> Items
		{
			get
			{
				return (IList<BillboardTextItem>)base.GetValue(CustomBillboardTextGroupVisual3D.ItemsProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.ItemsProperty, value);
			}
		}

		// Token: 0x1700149F RID: 5279
		// (get) Token: 0x0600465D RID: 18013 RVA: 0x0003AEDB File Offset: 0x000390DB
		// (set) Token: 0x0600465E RID: 18014 RVA: 0x0003AEF5 File Offset: 0x000390F5
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(CustomBillboardTextGroupVisual3D.PaddingProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.PaddingProperty, value);
			}
		}

		// Token: 0x170014A0 RID: 5280
		// (get) Token: 0x0600465F RID: 18015 RVA: 0x0003AF14 File Offset: 0x00039114
		// (set) Token: 0x06004660 RID: 18016 RVA: 0x0003AF2E File Offset: 0x0003912E
		public Vector Offset
		{
			get
			{
				return (Vector)base.GetValue(CustomBillboardTextGroupVisual3D.OffsetProperty);
			}
			set
			{
				base.SetValue(CustomBillboardTextGroupVisual3D.OffsetProperty, value);
			}
		}

		// Token: 0x06004661 RID: 18017 RVA: 0x0003AF4D File Offset: 0x0003914D
		protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs eventArgs)
		{
			if (this.isRendering && this.IsEnabled)
			{
				if (!this.IsAttachedToViewport3D())
				{
					return;
				}
				if (this.UpdateTransforms())
				{
					this.UpdateGeometry();
				}
			}
		}

		// Token: 0x06004662 RID: 18018 RVA: 0x0013DA50 File Offset: 0x0013BC50
		protected override void OnVisualParentChanged(DependencyObject oldParent)
		{
			base.OnVisualParentChanged(oldParent);
			DependencyObject parent = VisualTreeHelper.GetParent(this);
			this.IsRendering = (parent != null);
		}

		// Token: 0x06004663 RID: 18019 RVA: 0x0013DA84 File Offset: 0x0013BC84
		protected void UpdateGeometry()
		{
			foreach (KeyValuePair<MeshGeometry3D, IList<Billboard>> keyValuePair in this.meshes)
			{
				keyValuePair.Key.Positions = this.builder.GetPositions(keyValuePair.Value, this.Offset);
			}
			foreach (KeyValuePair<MeshGeometry3D, IList<Billboard>> keyValuePair2 in this.pinMeshes)
			{
				keyValuePair2.Key.Positions = this.builder.GetPinPositions(keyValuePair2.Value, this.Offset, this.PinWidth);
			}
		}

		// Token: 0x06004664 RID: 18020 RVA: 0x0003AF82 File Offset: 0x00039182
		protected bool UpdateTransforms()
		{
			return this.builder.UpdateTransforms();
		}

		// Token: 0x06004665 RID: 18021 RVA: 0x0013DB78 File Offset: 0x0013BD78
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

		// Token: 0x06004666 RID: 18022 RVA: 0x0013DC40 File Offset: 0x0013BE40
		private void MyHandleVisualChanged()
		{
			this.meshes.Clear();
			this.pinMeshes.Clear();
			if (this.Items == null)
			{
				base.Content = null;
				return;
			}
			DiffuseMaterial material = new DiffuseMaterial(this.PinBrush);
			List<BillboardTextItem> list = (from i in this.Items
			where !string.IsNullOrEmpty(i.Text)
			select i).ToList<BillboardTextItem>();
			Model3DGroup model3DGroup = new Model3DGroup();
			while (list.Count > 0)
			{
				Dictionary<string, FrameworkElement> dictionary;
				Dictionary<FrameworkElement, Rect> dictionary2;
				Material material2 = CustomTextGroupVisual3D.CreateTextMaterial(list, new Func<string, FrameworkElement>(this.MyCreateElement), out dictionary, out dictionary2);
				material2.Freeze();
				List<Billboard> list2 = new List<Billboard>();
				List<BillboardTextItem> list3 = new List<BillboardTextItem>();
				PointCollection pointCollection = new PointCollection();
				foreach (BillboardTextItem billboardTextItem in list)
				{
					FrameworkElement frameworkElement = dictionary[billboardTextItem.Text];
					Rect rect = dictionary2[frameworkElement];
					if (rect.Bottom > 1.0)
					{
						break;
					}
					list2.Add(new Billboard(billboardTextItem.Position, frameworkElement.ActualWidth, frameworkElement.ActualHeight, billboardTextItem.HorizontalAlignment, billboardTextItem.VerticalAlignment, billboardTextItem.DepthOffset, billboardTextItem.WorldDepthOffset));
					pointCollection.Add(new Point(rect.Left, rect.Bottom));
					pointCollection.Add(new Point(rect.Right, rect.Bottom));
					pointCollection.Add(new Point(rect.Right, rect.Top));
					pointCollection.Add(new Point(rect.Left, rect.Top));
					list3.Add(billboardTextItem);
				}
				Int32Collection int32Collection = BillboardGeometryBuilder.CreateIndices(list2.Count);
				int32Collection.Freeze();
				MeshGeometry3D meshGeometry3D = new MeshGeometry3D
				{
					TriangleIndices = int32Collection,
					TextureCoordinates = pointCollection,
					Positions = this.builder.GetPositions(list2, this.Offset)
				};
				model3DGroup.Children.Add(new GeometryModel3D(meshGeometry3D, material2));
				this.meshes.Add(meshGeometry3D, list2);
				if (this.Offset.Length > 0.0)
				{
					MeshGeometry3D meshGeometry3D2 = new MeshGeometry3D
					{
						TriangleIndices = int32Collection,
						Positions = this.builder.GetPinPositions(list2, this.Offset, this.PinWidth)
					};
					model3DGroup.Children.Add(new GeometryModel3D(meshGeometry3D2, material));
					this.pinMeshes.Add(meshGeometry3D2, list2);
				}
				foreach (BillboardTextItem item in list3)
				{
					list.Remove(item);
				}
			}
			base.Content = model3DGroup;
		}

		// Token: 0x06004667 RID: 18023 RVA: 0x0003AF97 File Offset: 0x00039197
		private static void MyOnVisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((CustomBillboardTextGroupVisual3D)d).MyHandleVisualChanged();
		}

		// Token: 0x04001FDF RID: 8159
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(#Phc.#3hc(107363120), typeof(Brush), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE0 RID: 8160
		public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(#Phc.#3hc(107453716), typeof(Brush), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE1 RID: 8161
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(#Phc.#3hc(107453155), typeof(Thickness), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(new Thickness(1.0), new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE2 RID: 8162
		public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(#Phc.#3hc(107453134), typeof(FontFamily), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE3 RID: 8163
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(#Phc.#3hc(107453149), typeof(double), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(0.0, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE4 RID: 8164
		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(#Phc.#3hc(107453136), typeof(FontWeight), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE5 RID: 8165
		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(#Phc.#3hc(107453119), typeof(Brush), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(Brushes.Black, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE6 RID: 8166
		public static readonly DependencyProperty HeightFactorProperty = DependencyProperty.Register(#Phc.#3hc(107453070), typeof(double), typeof(CustomBillboardTextGroupVisual3D), new PropertyMetadata(1.0, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE7 RID: 8167
		public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(#Phc.#3hc(107453085), typeof(IList<BillboardTextItem>), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(null, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE8 RID: 8168
		public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(#Phc.#3hc(107453076), typeof(Thickness), typeof(CustomBillboardTextGroupVisual3D), new UIPropertyMetadata(new Thickness(0.0), new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FE9 RID: 8169
		public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(#Phc.#3hc(107453031), typeof(Vector), typeof(CustomBillboardTextGroupVisual3D), new PropertyMetadata(new Vector(0.0, 0.0), new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FEA RID: 8170
		public static readonly DependencyProperty PinWidthProperty = DependencyProperty.Register(#Phc.#3hc(107453054), typeof(double), typeof(CustomBillboardTextGroupVisual3D), new PropertyMetadata(4.0));

		// Token: 0x04001FEB RID: 8171
		public static readonly DependencyProperty PinBrushProperty = DependencyProperty.Register(#Phc.#3hc(107453041), typeof(Brush), typeof(CustomBillboardTextGroupVisual3D), new PropertyMetadata(Brushes.Black, new PropertyChangedCallback(CustomBillboardTextGroupVisual3D.MyOnVisualChanged)));

		// Token: 0x04001FEC RID: 8172
		public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107408148), typeof(bool), typeof(CustomBillboardTextGroupVisual3D), new PropertyMetadata(true));

		// Token: 0x04001FED RID: 8173
		private readonly BillboardGeometryBuilder builder;

		// Token: 0x04001FEE RID: 8174
		private readonly Dictionary<MeshGeometry3D, IList<Billboard>> meshes = new Dictionary<MeshGeometry3D, IList<Billboard>>();

		// Token: 0x04001FEF RID: 8175
		private readonly Dictionary<MeshGeometry3D, IList<Billboard>> pinMeshes = new Dictionary<MeshGeometry3D, IList<Billboard>>();

		// Token: 0x04001FF0 RID: 8176
		private bool isRendering;
	}
}

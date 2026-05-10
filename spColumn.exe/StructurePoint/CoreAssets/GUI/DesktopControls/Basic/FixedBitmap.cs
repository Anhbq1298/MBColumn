using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A9B RID: 2715
	public sealed class FixedBitmap : UIElement
	{
		// Token: 0x0600589B RID: 22683 RVA: 0x0004944C File Offset: 0x0004764C
		public FixedBitmap()
		{
			this.sourceDownloaded = new EventHandler(this.OnSourceDownloaded);
			this.sourceFailed = new EventHandler<ExceptionEventArgs>(this.OnSourceFailed);
			base.LayoutUpdated += this.OnLayoutUpdated;
		}

		// Token: 0x1400015B RID: 347
		// (add) Token: 0x0600589C RID: 22684 RVA: 0x0016A640 File Offset: 0x00168840
		// (remove) Token: 0x0600589D RID: 22685 RVA: 0x0016A684 File Offset: 0x00168884
		public event EventHandler<ExceptionEventArgs> BitmapFailed;

		// Token: 0x17001931 RID: 6449
		// (get) Token: 0x0600589E RID: 22686 RVA: 0x0004948A File Offset: 0x0004768A
		// (set) Token: 0x0600589F RID: 22687 RVA: 0x000494A4 File Offset: 0x000476A4
		public BitmapSource Source
		{
			get
			{
				return (BitmapSource)base.GetValue(FixedBitmap.SourceProperty);
			}
			set
			{
				base.SetValue(FixedBitmap.SourceProperty, value);
			}
		}

		// Token: 0x060058A0 RID: 22688 RVA: 0x0016A6C8 File Offset: 0x001688C8
		protected override Size MeasureCore(Size availableSize)
		{
			Size result = default(Size);
			BitmapSource source = this.Source;
			if (source != null)
			{
				PresentationSource presentationSource = PresentationSource.FromVisual(this);
				if (presentationSource != null)
				{
					Matrix transformFromDevice = presentationSource.CompositionTarget.TransformFromDevice;
					Vector vector = new Vector((double)source.PixelWidth, (double)source.PixelHeight);
					Vector vector2 = transformFromDevice.Transform(vector);
					result = new Size(vector2.X, vector2.Y);
				}
			}
			return result;
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x0016A740 File Offset: 0x00168940
		protected override void OnRender(DrawingContext dc)
		{
			BitmapSource source = this.Source;
			if (source != null)
			{
				this.pixelOffset = this.GetPixelOffset();
				dc.DrawImage(source, new Rect(this.pixelOffset, base.DesiredSize));
			}
		}

		// Token: 0x060058A2 RID: 22690 RVA: 0x0016A788 File Offset: 0x00168988
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FixedBitmap fixedBitmap = (FixedBitmap)d;
			BitmapSource bitmapSource = (BitmapSource)e.OldValue;
			BitmapSource bitmapSource2 = (BitmapSource)e.NewValue;
			if (bitmapSource != null && fixedBitmap.sourceDownloaded != null && !bitmapSource.IsFrozen && bitmapSource != null)
			{
				bitmapSource.DownloadCompleted -= fixedBitmap.sourceDownloaded;
				bitmapSource.DownloadFailed -= fixedBitmap.sourceFailed;
			}
			if (bitmapSource2 != null && bitmapSource2 != null && !bitmapSource2.IsFrozen)
			{
				bitmapSource2.DownloadCompleted += fixedBitmap.sourceDownloaded;
				bitmapSource2.DownloadFailed += fixedBitmap.sourceFailed;
			}
		}

		// Token: 0x060058A3 RID: 22691 RVA: 0x000494BE File Offset: 0x000476BE
		private void OnSourceDownloaded(object sender, EventArgs e)
		{
			base.InvalidateMeasure();
			base.InvalidateVisual();
		}

		// Token: 0x060058A4 RID: 22692 RVA: 0x000494D8 File Offset: 0x000476D8
		private void OnSourceFailed(object sender, ExceptionEventArgs e)
		{
			this.Source = null;
			this.BitmapFailed(this, e);
		}

		// Token: 0x060058A5 RID: 22693 RVA: 0x0016A828 File Offset: 0x00168A28
		private void OnLayoutUpdated(object sender, EventArgs e)
		{
			Point point = this.GetPixelOffset();
			if (!this.AreClose(point, this.pixelOffset))
			{
				base.InvalidateVisual();
			}
		}

		// Token: 0x060058A6 RID: 22694 RVA: 0x0016A860 File Offset: 0x00168A60
		private Matrix GetVisualTransform(Visual v)
		{
			if (v != null)
			{
				Matrix matrix = Matrix.Identity;
				Transform transform = VisualTreeHelper.GetTransform(v);
				if (transform != null)
				{
					Matrix value = transform.Value;
					matrix = Matrix.Multiply(matrix, value);
				}
				Vector offset = VisualTreeHelper.GetOffset(v);
				matrix.Translate(offset.X, offset.Y);
				return matrix;
			}
			return Matrix.Identity;
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x0016A8C0 File Offset: 0x00168AC0
		private Point TryApplyVisualTransform(Point point, Visual v, bool inverse, bool throwOnError, out bool success)
		{
			success = true;
			if (v != null)
			{
				Matrix visualTransform = this.GetVisualTransform(v);
				if (inverse)
				{
					if (!throwOnError && !visualTransform.HasInverse)
					{
						success = false;
						return new Point(0.0, 0.0);
					}
					visualTransform.Invert();
				}
				point = visualTransform.Transform(point);
			}
			return point;
		}

		// Token: 0x060058A8 RID: 22696 RVA: 0x0016A928 File Offset: 0x00168B28
		private Point ApplyVisualTransform(Point point, Visual v, bool inverse)
		{
			bool flag = true;
			return this.TryApplyVisualTransform(point, v, inverse, true, out flag);
		}

		// Token: 0x060058A9 RID: 22697 RVA: 0x0016A950 File Offset: 0x00168B50
		private Point GetPixelOffset()
		{
			Point point = default(Point);
			PresentationSource presentationSource = PresentationSource.FromVisual(this);
			if (presentationSource != null)
			{
				Visual rootVisual = presentationSource.RootVisual;
				point = base.TransformToAncestor(rootVisual).Transform(point);
				point = this.ApplyVisualTransform(point, rootVisual, false);
				point = presentationSource.CompositionTarget.TransformToDevice.Transform(point);
				point.X = Math.Round(point.X);
				point.Y = Math.Round(point.Y);
				point = presentationSource.CompositionTarget.TransformFromDevice.Transform(point);
				point = this.ApplyVisualTransform(point, rootVisual, true);
				point = rootVisual.TransformToDescendant(this).Transform(point);
			}
			return point;
		}

		// Token: 0x060058AA RID: 22698 RVA: 0x000494FA File Offset: 0x000476FA
		private bool AreClose(Point point1, Point point2)
		{
			return this.AreClose(point1.X, point2.X) && this.AreClose(point1.Y, point2.Y);
		}

		// Token: 0x060058AB RID: 22699 RVA: 0x0016AA18 File Offset: 0x00168C18
		private bool AreClose(double value1, double value2)
		{
			if (value1 == value2)
			{
				return true;
			}
			double num = value1 - value2;
			return num < 1.53E-06 && num > -1.53E-06;
		}

		// Token: 0x0400250B RID: 9483
		public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(#Phc.#3hc(107426818), typeof(BitmapSource), typeof(FixedBitmap), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(FixedBitmap.OnSourceChanged)));

		// Token: 0x0400250C RID: 9484
		private readonly EventHandler sourceDownloaded;

		// Token: 0x0400250D RID: 9485
		private readonly EventHandler<ExceptionEventArgs> sourceFailed;

		// Token: 0x0400250E RID: 9486
		private Point pixelOffset;
	}
}

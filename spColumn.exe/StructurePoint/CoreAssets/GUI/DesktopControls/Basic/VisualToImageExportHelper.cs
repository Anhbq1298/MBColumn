using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABF RID: 2751
	public static class VisualToImageExportHelper
	{
		// Token: 0x060059B7 RID: 22967 RVA: 0x0016D6D0 File Offset: 0x0016B8D0
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Png")]
		public static void ExportToPng(Visual visual, Stream sink)
		{
			#X0d.#V0d(visual, #Phc.#3hc(107425784), Component.DesktopControls, #Phc.#3hc(107425743));
			#X0d.#V0d(sink, #Phc.#3hc(107367090), Component.DesktopControls, #Phc.#3hc(107425722));
			Window window = visual.ParentOfType<Window>();
			float dpiX;
			float dpiY;
			using (Graphics graphics = Graphics.FromHwnd((window != null) ? new WindowInteropHelper(window).Handle : IntPtr.Zero))
			{
				dpiX = graphics.DpiX;
				dpiY = graphics.DpiY;
			}
			Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(visual);
			DrawingVisual drawingVisual = new DrawingVisual();
			int pixelWidth = (int)Math.Ceiling(descendantBounds.Width);
			int pixelHeight = (int)Math.Ceiling(descendantBounds.Height);
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(pixelWidth, pixelHeight, (double)dpiX, (double)dpiY, PixelFormats.Pbgra32);
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				VisualBrush brush = new VisualBrush(visual);
				drawingContext.DrawRectangle(brush, null, new Rect(default(System.Windows.Point), descendantBounds.Size));
			}
			renderTargetBitmap.Render(drawingVisual);
			new PngBitmapEncoder
			{
				Interlace = PngInterlaceOption.On,
				Frames = 
				{
					BitmapFrame.Create(renderTargetBitmap)
				}
			}.Save(sink);
		}
	}
}

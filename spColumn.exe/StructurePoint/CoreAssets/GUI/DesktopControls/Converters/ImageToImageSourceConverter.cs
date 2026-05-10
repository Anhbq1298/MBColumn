using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6E RID: 2670
	public sealed class ImageToImageSourceConverter : IValueConverter
	{
		// Token: 0x0600575F RID: 22367 RVA: 0x001669DC File Offset: 0x00164BDC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			Image image = value as Image;
			if (image == null)
			{
				return null;
			}
			object result;
			using (Bitmap bitmap = new Bitmap(image))
			{
				result = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			}
			return result;
		}

		// Token: 0x06005760 RID: 22368 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

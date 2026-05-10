using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A6B RID: 2667
	public sealed class BitmapToSourceConverter : IValueConverter
	{
		// Token: 0x06005756 RID: 22358 RVA: 0x00166910 File Offset: 0x00164B10
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Bitmap bitmap = value as Bitmap;
			if (bitmap != null)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					bitmap.Save(memoryStream, bitmap.RawFormat);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = memoryStream;
					bitmapImage.EndInit();
					return bitmapImage;
				}
			}
			return null;
		}

		// Token: 0x06005757 RID: 22359 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

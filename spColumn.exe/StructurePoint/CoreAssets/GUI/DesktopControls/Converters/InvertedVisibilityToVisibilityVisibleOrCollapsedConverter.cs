using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A54 RID: 2644
	public sealed class InvertedVisibilityToVisibilityVisibleOrCollapsedConverter : IValueConverter
	{
		// Token: 0x0600570B RID: 22283 RVA: 0x00047EF1 File Offset: 0x000460F1
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((Visibility)value != Visibility.Visible) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x00003909 File Offset: 0x00001B09
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

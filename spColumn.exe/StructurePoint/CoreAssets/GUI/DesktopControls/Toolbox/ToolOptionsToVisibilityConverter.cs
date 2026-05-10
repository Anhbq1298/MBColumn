using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Toolbox
{
	// Token: 0x020008E9 RID: 2281
	public sealed class ToolOptionsToVisibilityConverter : IValueConverter
	{
		// Token: 0x06004875 RID: 18549 RVA: 0x001439D0 File Offset: 0x00141BD0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = parameter != null;
			IEditionToolData editionToolData = value as IEditionToolData;
			bool flag2 = editionToolData != null && editionToolData.ToolOptionsEditor != null;
			if (flag)
			{
				flag2 = !flag2;
			}
			return (editionToolData != null && flag2) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x06004876 RID: 18550 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

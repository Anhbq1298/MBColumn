using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Toolbox
{
	// Token: 0x020008E7 RID: 2279
	public sealed class ToolCommandsToVisibilityConverter : IValueConverter
	{
		// Token: 0x0600486C RID: 18540 RVA: 0x0014393C File Offset: 0x00141B3C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = parameter != null;
			IEditionToolData editionToolData = value as IEditionToolData;
			bool flag2 = editionToolData != null && editionToolData.ToolCommandsPanel != null;
			if (flag)
			{
				flag2 = !flag2;
			}
			return (editionToolData != null && flag2) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x0600486D RID: 18541 RVA: 0x0001233F File Offset: 0x0001053F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Converters
{
	// Token: 0x02000A57 RID: 2647
	public sealed class IsCollectionLastItemToBooleanMultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06005718 RID: 22296 RVA: 0x0016644C File Offset: 0x0016464C
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			DependencyObject dependencyObject = (values == null || values.Length == 0) ? null : ((DependencyObject)values[0]);
			if (dependencyObject == null)
			{
				return false;
			}
			ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(dependencyObject);
			return itemsControl != null && itemsControl.ItemContainerGenerator.IndexFromContainer(dependencyObject) == itemsControl.Items.Count - 1;
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}

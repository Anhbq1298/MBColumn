using System;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A7D RID: 2685
	public static class BooleanExtensions
	{
		// Token: 0x0600578F RID: 22415 RVA: 0x0004832B File Offset: 0x0004652B
		public static Visibility ToVisibility(this bool value)
		{
			if (!value)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}
	}
}

using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A9F RID: 2719
	public static class KeysHelper
	{
		// Token: 0x060058CB RID: 22731 RVA: 0x000497FE File Offset: 0x000479FE
		public static bool IsNavigationKey(Key key)
		{
			return key == Key.Right || key == Key.Down || key == Key.Left || key == Key.Up;
		}
	}
}

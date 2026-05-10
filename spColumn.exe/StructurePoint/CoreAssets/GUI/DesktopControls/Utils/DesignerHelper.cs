using System;
using System.ComponentModel;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008E2 RID: 2274
	public static class DesignerHelper
	{
		// Token: 0x1700151B RID: 5403
		// (get) Token: 0x0600482E RID: 18478 RVA: 0x0003CEFD File Offset: 0x0003B0FD
		public static bool IsInDesignMode
		{
			get
			{
				return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
			}
		}

		// Token: 0x1700151C RID: 5404
		// (get) Token: 0x0600482F RID: 18479 RVA: 0x0003CF29 File Offset: 0x0003B129
		public static bool IsInRuntime
		{
			get
			{
				return !DesignerHelper.IsInDesignMode;
			}
		}
	}
}

using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x02000905 RID: 2309
	public static class RibbonToolbarExtensions
	{
		// Token: 0x06004992 RID: 18834 RVA: 0x001450EC File Offset: 0x001432EC
		public static void SetGroupsHeaderVisibility(this IRibbonToolbarController controller, Visibility visibility)
		{
			#X0d.#V0d(controller, #Phc.#3hc(107449545), Component.DesktopControls, #Phc.#3hc(107449560));
			foreach (RibbonToolbarGroup ribbonToolbarGroup in controller.Groups)
			{
				ribbonToolbarGroup.HeaderVisibility = visibility;
			}
		}

		// Token: 0x06004993 RID: 18835 RVA: 0x00145160 File Offset: 0x00143360
		public static void SetGroupsHeaderPosition(this IRibbonToolbarController controller, ToolbarGroupHeaderPosition headerPosition)
		{
			#X0d.#V0d(controller, #Phc.#3hc(107449545), Component.DesktopControls, #Phc.#3hc(107449475));
			foreach (RibbonToolbarGroup ribbonToolbarGroup in controller.Groups)
			{
				ribbonToolbarGroup.HeaderPosition = headerPosition;
			}
		}
	}
}

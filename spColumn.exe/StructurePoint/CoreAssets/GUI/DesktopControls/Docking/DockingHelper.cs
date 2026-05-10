using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x02000999 RID: 2457
	public static class DockingHelper
	{
		// Token: 0x06004FE4 RID: 20452 RVA: 0x0015CC00 File Offset: 0x0015AE00
		public static void SetFloatingSize(RadPane pane, Size floatingSize)
		{
			if (pane == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384649));
			}
			RadDocking.SetFloatingSize(pane, floatingSize);
			RadPaneGroup radPaneGroup = pane.ParentOfType<RadPaneGroup>();
			if (radPaneGroup != null)
			{
				RadDocking.SetFloatingSize(radPaneGroup, floatingSize);
			}
			RadSplitContainer radSplitContainer = pane.ParentOfType<RadSplitContainer>();
			if (radSplitContainer != null)
			{
				RadDocking.SetFloatingSize(radSplitContainer, floatingSize);
			}
		}

		// Token: 0x06004FE5 RID: 20453 RVA: 0x0015CC58 File Offset: 0x0015AE58
		public static Point GetCenterPositionedChildTopLeft(Window window, Size childSize)
		{
			if (window == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378032));
			}
			double num = window.Left;
			double num2 = window.Top;
			if (window.WindowState == WindowState.Maximized)
			{
				NativeMethods.RECT windowRectangle = NativeMethods.GetWindowRectangle(window);
				num = (double)windowRectangle.Left;
				num2 = (double)windowRectangle.Top;
			}
			double x = num + window.ActualWidth / 2.0 - childSize.Width / 2.0;
			double y = num2 + window.ActualHeight / 2.0 - childSize.Height / 2.0;
			return new Point(x, y);
		}

		// Token: 0x06004FE6 RID: 20454 RVA: 0x0015CD14 File Offset: 0x0015AF14
		public static void PositionFloatingInCenter(Window window, RadPane pane, Size floatingSize)
		{
			if (window == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378032));
			}
			if (pane == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384649));
			}
			Point centerPositionedChildTopLeft = DockingHelper.GetCenterPositionedChildTopLeft(window, floatingSize);
			RadDocking.SetFloatingLocation(pane, centerPositionedChildTopLeft);
			RadPaneGroup radPaneGroup = pane.ParentOfType<RadPaneGroup>();
			if (radPaneGroup != null)
			{
				RadDocking.SetFloatingLocation(radPaneGroup, centerPositionedChildTopLeft);
			}
			RadSplitContainer radSplitContainer = pane.ParentOfType<RadSplitContainer>();
			if (radSplitContainer != null)
			{
				RadDocking.SetFloatingLocation(radSplitContainer, centerPositionedChildTopLeft);
			}
		}
	}
}

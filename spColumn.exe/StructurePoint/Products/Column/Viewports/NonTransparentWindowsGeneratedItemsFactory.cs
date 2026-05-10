using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.Navigation;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x020000B0 RID: 176
	internal sealed class NonTransparentWindowsGeneratedItemsFactory : DefaultGeneratedItemsFactory
	{
		// Token: 0x060005B3 RID: 1459 RVA: 0x0008ABD8 File Offset: 0x00088DD8
		public override ToolWindow CreateToolWindow()
		{
			ToolWindow toolWindow = new ToolWindow();
			toolWindow.Activated += this.WindowActivated;
			toolWindow.Unloaded += this.WindowUnloaded;
			RadWindowInteropHelper.SetClipMaskCornerRadius(toolWindow, new CornerRadius(3.0));
			RadWindowInteropHelper.SetOpaqueWindowBackground(toolWindow, Brushes.LightGray);
			toolWindow.Owner = Application.Current.MainWindow;
			return toolWindow;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000A319 File Offset: 0x00008519
		public override RadPaneGroup CreatePaneGroup()
		{
			return new CustomRadPaneGroup();
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0008AC4C File Offset: 0x00088E4C
		private void WindowUnloaded(object sender, RoutedEventArgs e)
		{
			ToolWindow toolWindow = sender as ToolWindow;
			ToolWindow toolWindow2;
			if (!false)
			{
				toolWindow2 = toolWindow;
			}
			if (toolWindow2 != null)
			{
				toolWindow2.Activated -= this.WindowActivated;
				toolWindow2.Unloaded -= this.WindowUnloaded;
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000A324 File Offset: 0x00008524
		private void WindowActivated(object sender, EventArgs e)
		{
			this.ActivatePane((ToolWindow)sender);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0008AC98 File Offset: 0x00088E98
		private void ActivatePane(ToolWindow window)
		{
			RadSplitContainer radSplitContainer = window.Content as RadSplitContainer;
			if (radSplitContainer == null)
			{
				return;
			}
			RadDocking radDocking = (RadDocking)ReflectionHelper.#E(window, #Phc.#3hc(107384729));
			List<RadPaneGroup> list = radSplitContainer.ChildrenOfType<RadPaneGroup>().ToList<RadPaneGroup>();
			foreach (RadPaneGroup radPaneGroup in list)
			{
				if (radPaneGroup.EnumeratePanes().Contains(radDocking.ActivePane))
				{
					return;
				}
			}
			RadPaneGroup radPaneGroup2 = list.FirstOrDefault<RadPaneGroup>();
			if (radPaneGroup2 == null)
			{
				return;
			}
			if (radPaneGroup2.SelectedItem != null)
			{
				radPaneGroup2.SelectedPane.IsActive = true;
				return;
			}
			RadPane radPane = radSplitContainer.EnumeratePanes().FirstOrDefault<RadPane>();
			if (radPane == null)
			{
				return;
			}
			radPane.IsActive = true;
		}
	}
}

using System;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x02000093 RID: 147
	internal sealed class CustomRadPaneGroup : RadPaneGroup
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x00088750 File Offset: 0x00086950
		public override void OnApplyTemplate()
		{
			Border border = base.GetTemplateChild(#Phc.#3hc(107384759)) as Border;
			if (border != null)
			{
				border.PreviewMouseLeftButtonDown += this.Border_PreviewMouseLeftButtonDown;
			}
			base.OnApplyTemplate();
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0008879C File Offset: 0x0008699C
		private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			PaneHeader paneHeader = base.PaneHeader;
			RadPane radPane = (paneHeader != null) ? paneHeader.SelectedPane : null;
			if (radPane != null && !radPane.IsActive)
			{
				radPane.IsActive = true;
				e.Handled = true;
			}
		}
	}
}

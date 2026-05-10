using System;
using System.Collections.Generic;
using System.Windows;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x02000959 RID: 2393
	internal sealed class ViewCubeHostControlItemsBindingProxy : Freezable
	{
		// Token: 0x06004EA1 RID: 20129 RVA: 0x00041C80 File Offset: 0x0003FE80
		protected override Freezable CreateInstanceCore()
		{
			return new ViewCubeHostControlItemsBindingProxy();
		}

		// Token: 0x170016D4 RID: 5844
		// (get) Token: 0x06004EA2 RID: 20130 RVA: 0x00041C8B File Offset: 0x0003FE8B
		// (set) Token: 0x06004EA3 RID: 20131 RVA: 0x00041CA5 File Offset: 0x0003FEA5
		public IEnumerable<IPanelItem> ViewCubeItems
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(ViewCubeHostControlItemsBindingProxy.ViewCubeItemsProperty);
			}
			set
			{
				base.SetValue(ViewCubeHostControlItemsBindingProxy.ViewCubeItemsProperty, value);
			}
		}

		// Token: 0x0400229F RID: 8863
		public static readonly DependencyProperty ViewCubeItemsProperty = DependencyProperty.Register(#Phc.#3hc(107468209), typeof(IEnumerable<IPanelItem>), typeof(ViewCubeHostControlItemsBindingProxy), null);
	}
}

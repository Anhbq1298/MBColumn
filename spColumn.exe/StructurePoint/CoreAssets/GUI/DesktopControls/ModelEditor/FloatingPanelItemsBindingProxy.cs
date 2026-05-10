using System;
using System.Collections.Generic;
using System.Windows;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000928 RID: 2344
	internal sealed class FloatingPanelItemsBindingProxy : Freezable
	{
		// Token: 0x06004C61 RID: 19553 RVA: 0x0003FFA4 File Offset: 0x0003E1A4
		protected override Freezable CreateInstanceCore()
		{
			return new FloatingPanelItemsBindingProxy();
		}

		// Token: 0x17001639 RID: 5689
		// (get) Token: 0x06004C62 RID: 19554 RVA: 0x0003FFAF File Offset: 0x0003E1AF
		// (set) Token: 0x06004C63 RID: 19555 RVA: 0x0003FFC9 File Offset: 0x0003E1C9
		public IEnumerable<IPanelItem> BuiltInItems
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(FloatingPanelItemsBindingProxy.BuiltInItemsProperty);
			}
			set
			{
				base.SetValue(FloatingPanelItemsBindingProxy.BuiltInItemsProperty, value);
			}
		}

		// Token: 0x1700163A RID: 5690
		// (get) Token: 0x06004C64 RID: 19556 RVA: 0x0003FFE3 File Offset: 0x0003E1E3
		// (set) Token: 0x06004C65 RID: 19557 RVA: 0x0003FFFD File Offset: 0x0003E1FD
		public IEnumerable<IPanelItem> AdditionalItems
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(FloatingPanelItemsBindingProxy.AdditionalItemsProperty);
			}
			set
			{
				base.SetValue(FloatingPanelItemsBindingProxy.AdditionalItemsProperty, value);
			}
		}

		// Token: 0x040021C5 RID: 8645
		public static readonly DependencyProperty BuiltInItemsProperty = DependencyProperty.Register(#Phc.#3hc(107470388), typeof(IEnumerable<IPanelItem>), typeof(FloatingPanelItemsBindingProxy), null);

		// Token: 0x040021C6 RID: 8646
		public static readonly DependencyProperty AdditionalItemsProperty = DependencyProperty.Register(#Phc.#3hc(107470339), typeof(IEnumerable<IPanelItem>), typeof(FloatingPanelItemsBindingProxy), null);
	}
}

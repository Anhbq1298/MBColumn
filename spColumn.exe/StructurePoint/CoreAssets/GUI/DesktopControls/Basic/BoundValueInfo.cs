using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A7E RID: 2686
	public static class BoundValueInfo
	{
		// Token: 0x06005790 RID: 22416 RVA: 0x00048337 File Offset: 0x00046537
		public static void SetIsBoundValueCommitted(DependencyObject element, bool value)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107429283));
			element.SetValue(BoundValueInfo.IsBoundValueCommittedProperty, value);
		}

		// Token: 0x06005791 RID: 22417 RVA: 0x00048371 File Offset: 0x00046571
		public static bool GetIsBoundValueCommitted(DependencyObject element)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107429230));
			return (bool)element.GetValue(BoundValueInfo.IsBoundValueCommittedProperty);
		}

		// Token: 0x040024B3 RID: 9395
		public static readonly DependencyProperty IsBoundValueCommittedProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107429209), typeof(bool), typeof(BoundValueInfo), new PropertyMetadata(true));
	}
}

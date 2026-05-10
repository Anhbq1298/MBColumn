using System;
using System.Windows;
using System.Windows.Automation.Peers;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A90 RID: 2704
	public sealed class CustomRadListBox : RadListBox
	{
		// Token: 0x17001923 RID: 6435
		// (get) Token: 0x0600583A RID: 22586 RVA: 0x00048E3F File Offset: 0x0004703F
		// (set) Token: 0x0600583B RID: 22587 RVA: 0x00048E59 File Offset: 0x00047059
		public bool FakeAutomationPeer
		{
			get
			{
				return (bool)base.GetValue(CustomRadListBox.FakeAutomationPeerProperty);
			}
			set
			{
				base.SetValue(CustomRadListBox.FakeAutomationPeerProperty, value);
			}
		}

		// Token: 0x0600583C RID: 22588 RVA: 0x00048E78 File Offset: 0x00047078
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			if (this.FakeAutomationPeer)
			{
				return new FakeWindowAutomationPeer(this, AutomationControlType.List);
			}
			return base.OnCreateAutomationPeer();
		}

		// Token: 0x040024EE RID: 9454
		public static readonly DependencyProperty FakeAutomationPeerProperty = DependencyProperty.Register(#Phc.#3hc(107427885), typeof(bool), typeof(CustomRadListBox), new PropertyMetadata(false));
	}
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A97 RID: 2711
	public sealed class FakeWindowAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x06005870 RID: 22640 RVA: 0x0004920B File Offset: 0x0004740B
		public FakeWindowAutomationPeer(FrameworkElement owner, AutomationControlType controlType = AutomationControlType.Window) : base(owner)
		{
			this.controlType = controlType;
		}

		// Token: 0x06005871 RID: 22641 RVA: 0x0004921B File Offset: 0x0004741B
		protected override string GetNameCore()
		{
			return #Phc.#3hc(107428246);
		}

		// Token: 0x06005872 RID: 22642 RVA: 0x0004922B File Offset: 0x0004742B
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return this.controlType;
		}

		// Token: 0x06005873 RID: 22643 RVA: 0x00049237 File Offset: 0x00047437
		protected override List<AutomationPeer> GetChildrenCore()
		{
			return new List<AutomationPeer>();
		}

		// Token: 0x04002501 RID: 9473
		private readonly AutomationControlType controlType;
	}
}

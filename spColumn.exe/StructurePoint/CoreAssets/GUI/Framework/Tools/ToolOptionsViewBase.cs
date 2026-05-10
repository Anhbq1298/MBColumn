using System;
using #ezc;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools
{
	// Token: 0x02000B76 RID: 2934
	public class ToolOptionsViewBase : ViewBase, #QBc, #SBc, #9Kc
	{
		// Token: 0x17001B2D RID: 6957
		// (get) Token: 0x06005FC9 RID: 24521 RVA: 0x0004F5E2 File Offset: 0x0004D7E2
		// (set) Token: 0x06005FCA RID: 24522 RVA: 0x0004F5EA File Offset: 0x0004D7EA
		public HelpID HelpId
		{
			get
			{
				return ContextualHelp.GetHelpIDTree(this);
			}
			set
			{
				if (this.HelpId != value && !false)
				{
					ContextualHelp.SetHelpIDTree(this, value);
				}
			}
		}

		// Token: 0x06005FCB RID: 24523 RVA: 0x0004F603 File Offset: 0x0004D803
		public void RefreshLayout()
		{
			if (2 != 0)
			{
				base.UpdateLayout();
			}
			if (5 != 0)
			{
				base.InvalidateMeasure();
			}
		}

		// Token: 0x06005FCD RID: 24525 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x06005FCE RID: 24526 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}
	}
}

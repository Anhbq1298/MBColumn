using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.GroupedToolbox
{
	// Token: 0x02000998 RID: 2456
	public sealed class GroupedToolBoxItem
	{
		// Token: 0x06004FDF RID: 20447 RVA: 0x00042ABE File Offset: 0x00040CBE
		public GroupedToolBoxItem(string groupName, IEnumerable<IEditionToolData> tools)
		{
			this.GroupName = groupName;
			this.Tools = tools;
		}

		// Token: 0x170016F9 RID: 5881
		// (get) Token: 0x06004FE0 RID: 20448 RVA: 0x00042AD4 File Offset: 0x00040CD4
		// (set) Token: 0x06004FE1 RID: 20449 RVA: 0x00042AE0 File Offset: 0x00040CE0
		public string GroupName { get; set; }

		// Token: 0x170016FA RID: 5882
		// (get) Token: 0x06004FE2 RID: 20450 RVA: 0x00042AF1 File Offset: 0x00040CF1
		// (set) Token: 0x06004FE3 RID: 20451 RVA: 0x00042AFD File Offset: 0x00040CFD
		public IEnumerable<IEditionToolData> Tools { get; set; }
	}
}

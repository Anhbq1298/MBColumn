using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #LQc
{
	// Token: 0x02000C3B RID: 3131
	internal sealed class #GRc : #DRc
	{
		// Token: 0x06006580 RID: 25984 RVA: 0x00051E20 File Offset: 0x00050020
		public #GRc()
		{
			this.GlobalContextMenuItems = new CustomObservableCollection<ITreeItemData>();
			this.LocalContextMenuItems = new CustomObservableCollection<ITreeItemData>();
		}

		// Token: 0x17001C50 RID: 7248
		// (get) Token: 0x06006581 RID: 25985 RVA: 0x00051E3E File Offset: 0x0005003E
		// (set) Token: 0x06006582 RID: 25986 RVA: 0x00051E46 File Offset: 0x00050046
		public CustomObservableCollection<ITreeItemData> GlobalContextMenuItems { get; private set; }

		// Token: 0x17001C51 RID: 7249
		// (get) Token: 0x06006583 RID: 25987 RVA: 0x00051E4F File Offset: 0x0005004F
		// (set) Token: 0x06006584 RID: 25988 RVA: 0x00051E57 File Offset: 0x00050057
		public CustomObservableCollection<ITreeItemData> LocalContextMenuItems { get; private set; }

		// Token: 0x040029AA RID: 10666
		[CompilerGenerated]
		private CustomObservableCollection<ITreeItemData> #a;

		// Token: 0x040029AB RID: 10667
		[CompilerGenerated]
		private CustomObservableCollection<ITreeItemData> #b;
	}
}

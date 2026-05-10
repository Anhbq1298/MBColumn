using System;
using System.Diagnostics.CodeAnalysis;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Tree
{
	// Token: 0x020008E3 RID: 2275
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hideable")]
	public interface IHideableTreeItemData : ITreeItemData
	{
		// Token: 0x1700151D RID: 5405
		// (get) Token: 0x06004830 RID: 18480
		// (set) Token: 0x06004831 RID: 18481
		bool IsVisible { get; set; }

		// Token: 0x1700151E RID: 5406
		// (get) Token: 0x06004832 RID: 18482
		// (set) Token: 0x06004833 RID: 18483
		bool IsEnabled { get; set; }
	}
}

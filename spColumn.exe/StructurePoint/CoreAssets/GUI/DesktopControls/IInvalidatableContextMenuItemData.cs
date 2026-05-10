using System;
using System.Diagnostics.CodeAnalysis;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200089A RID: 2202
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invalidatable")]
	public interface IInvalidatableContextMenuItemData : IContextMenuItemBase
	{
		// Token: 0x1700143C RID: 5180
		// (get) Token: 0x06004569 RID: 17769
		// (set) Token: 0x0600456A RID: 17770
		IDelegateCommand Command { get; set; }
	}
}

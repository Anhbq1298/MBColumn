using System;
using Telerik.Windows.DragDrop.Behaviors;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8B RID: 2699
	public sealed class CustomListBoxDragDropBehavior : ListBoxDragDropBehavior
	{
		// Token: 0x06005812 RID: 22546 RVA: 0x00003375 File Offset: 0x00001575
		protected override bool IsMovingItems(DragDropState state)
		{
			return true;
		}
	}
}

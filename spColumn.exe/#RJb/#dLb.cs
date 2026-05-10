using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Editor.Core;

namespace #RJb
{
	// Token: 0x0200066F RID: 1647
	internal interface #dLb
	{
		// Token: 0x0600376D RID: 14189
		void SetupContextMenu(ColumnEditor editor);

		// Token: 0x0600376E RID: 14190
		void SetupSelectScopeMenu(bool shouldShowArrange);

		// Token: 0x0600376F RID: 14191
		void EnableContextMenu();

		// Token: 0x06003770 RID: 14192
		void DisableContextMenu();

		// Token: 0x06003771 RID: 14193
		void ResetContextMenu();

		// Token: 0x06003772 RID: 14194
		void UpdateSelectCheckState(bool selectChecked);

		// Token: 0x06003773 RID: 14195
		void SetupCommand(EditorContextMenuCommands command, Action<object> action, Predicate<object> predicate);

		// Token: 0x06003774 RID: 14196
		bool MenuHasJustClosed();

		// Token: 0x06003775 RID: 14197
		void ChangeSectionType(SectionType type);
	}
}

using System;
using devDept.Eyeshot;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AEC RID: 2796
	public sealed class ActionModeChangedEventArgs : EventArgs
	{
		// Token: 0x06005B41 RID: 23361 RVA: 0x0004C646 File Offset: 0x0004A846
		public ActionModeChangedEventArgs(actionType oldActionType, actionType newActionType)
		{
			this.OldActionType = oldActionType;
			this.NewActionType = newActionType;
		}

		// Token: 0x17001A19 RID: 6681
		// (get) Token: 0x06005B42 RID: 23362 RVA: 0x0004C65C File Offset: 0x0004A85C
		public actionType OldActionType { get; }

		// Token: 0x17001A1A RID: 6682
		// (get) Token: 0x06005B43 RID: 23363 RVA: 0x0004C664 File Offset: 0x0004A864
		public actionType NewActionType { get; }
	}
}

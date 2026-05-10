using System;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x0200095E RID: 2398
	internal sealed class ViewCubeClickedEventArgs : EventArgs
	{
		// Token: 0x06004EE1 RID: 20193 RVA: 0x00041FCF File Offset: 0x000401CF
		internal ViewCubeClickedEventArgs(PredefinedPositionsOfCamera nameOfPositionOfViewCubeClicked, MouseButton mouseButton)
		{
			this.PositionOfViewCubeClicked = nameOfPositionOfViewCubeClicked;
			this.MouseButton = mouseButton;
		}

		// Token: 0x170016D5 RID: 5845
		// (get) Token: 0x06004EE2 RID: 20194 RVA: 0x00041FE5 File Offset: 0x000401E5
		// (set) Token: 0x06004EE3 RID: 20195 RVA: 0x00041FF1 File Offset: 0x000401F1
		public PredefinedPositionsOfCamera PositionOfViewCubeClicked { get; private set; }

		// Token: 0x170016D6 RID: 5846
		// (get) Token: 0x06004EE4 RID: 20196 RVA: 0x00042002 File Offset: 0x00040202
		// (set) Token: 0x06004EE5 RID: 20197 RVA: 0x0004200E File Offset: 0x0004020E
		public MouseButton MouseButton { get; private set; }
	}
}

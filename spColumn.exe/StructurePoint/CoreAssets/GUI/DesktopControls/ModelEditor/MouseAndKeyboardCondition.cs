using System;
using System.Diagnostics.CodeAnalysis;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000947 RID: 2375
	[SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "Would cause ambiguity with AB3D.")]
	[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
	[Flags]
	public enum MouseAndKeyboardCondition
	{
		// Token: 0x0400222D RID: 8749
		Disabled = 0,
		// Token: 0x0400222E RID: 8750
		LeftMouseButtonPressed = 1,
		// Token: 0x0400222F RID: 8751
		RightMouseButtonPressed = 2,
		// Token: 0x04002230 RID: 8752
		MiddleMouseButtonPressed = 4,
		// Token: 0x04002231 RID: 8753
		ShiftKey = 32,
		// Token: 0x04002232 RID: 8754
		AltKey = 64,
		// Token: 0x04002233 RID: 8755
		ControlKey = 128
	}
}

using System;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C71 RID: 3185
	[Flags]
	public enum EnabledPreciseInputSwitches
	{
		// Token: 0x04002A49 RID: 10825
		None = 0,
		// Token: 0x04002A4A RID: 10826
		XGlobalRadioButton = 1,
		// Token: 0x04002A4B RID: 10827
		YGlobalRadioButton = 2,
		// Token: 0x04002A4C RID: 10828
		XLocalRadioButton = 4,
		// Token: 0x04002A4D RID: 10829
		YLocalRadioButton = 8,
		// Token: 0x04002A4E RID: 10830
		Angle = 16,
		// Token: 0x04002A4F RID: 10831
		Radius = 32,
		// Token: 0x04002A50 RID: 10832
		All = 63
	}
}

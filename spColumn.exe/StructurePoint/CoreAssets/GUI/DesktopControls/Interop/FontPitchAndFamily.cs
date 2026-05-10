using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Interop
{
	// Token: 0x02000994 RID: 2452
	[Flags]
	public enum FontPitchAndFamily : byte
	{
		// Token: 0x04002321 RID: 8993
		DEFAULT_PITCH = 0,
		// Token: 0x04002322 RID: 8994
		FIXED_PITCH = 1,
		// Token: 0x04002323 RID: 8995
		VARIABLE_PITCH = 2,
		// Token: 0x04002324 RID: 8996
		FF_DONTCARE = 0,
		// Token: 0x04002325 RID: 8997
		FF_ROMAN = 16,
		// Token: 0x04002326 RID: 8998
		FF_SWISS = 32,
		// Token: 0x04002327 RID: 8999
		FF_MODERN = 48,
		// Token: 0x04002328 RID: 9000
		FF_SCRIPT = 64,
		// Token: 0x04002329 RID: 9001
		FF_DECORATIVE = 80
	}
}

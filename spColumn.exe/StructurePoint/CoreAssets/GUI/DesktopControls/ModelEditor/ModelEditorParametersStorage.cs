using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200090C RID: 2316
	public static class ModelEditorParametersStorage
	{
		// Token: 0x17001590 RID: 5520
		// (get) Token: 0x0600499F RID: 18847 RVA: 0x0003E1DE File Offset: 0x0003C3DE
		// (set) Token: 0x060049A0 RID: 18848 RVA: 0x0003E1E5 File Offset: 0x0003C3E5
		public static double ZoomScaleFactor { get; set; }

		// Token: 0x17001591 RID: 5521
		// (get) Token: 0x060049A1 RID: 18849 RVA: 0x0003E1F1 File Offset: 0x0003C3F1
		public static double ReferenceDistance
		{
			get
			{
				return 100.0;
			}
		}

		// Token: 0x17001592 RID: 5522
		// (get) Token: 0x060049A2 RID: 18850 RVA: 0x0003E1FC File Offset: 0x0003C3FC
		// (set) Token: 0x060049A3 RID: 18851 RVA: 0x0003E203 File Offset: 0x0003C403
		public static double OneHundredPercentDistance { get; set; }
	}
}

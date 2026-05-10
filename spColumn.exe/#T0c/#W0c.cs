using System;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Docking;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #T0c
{
	// Token: 0x02000CA4 RID: 3236
	internal interface #W0c : #QBc, IDockableView
	{
		// Token: 0x17001CFB RID: 7419
		// (get) Token: 0x060068F3 RID: 26867
		IModelEditorControl ModelVisualizationControl { get; }

		// Token: 0x17001CFC RID: 7420
		// (get) Token: 0x060068F4 RID: 26868
		object ParentControl { get; }
	}
}

using System;
using System.IO;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E8 RID: 1000
	internal interface IFailureSurfaceView : IView
	{
		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x060022BB RID: 8891
		IModelEditorControl ModelEditorControl { get; }

		// Token: 0x060022BC RID: 8892
		void ExportCurrentViewAsImage(Stream sinkStream);
	}
}

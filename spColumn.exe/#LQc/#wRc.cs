using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #LQc
{
	// Token: 0x02000C28 RID: 3112
	internal interface #wRc
	{
		// Token: 0x17001C44 RID: 7236
		// (get) Token: 0x06006519 RID: 25881
		// (set) Token: 0x0600651A RID: 25882
		Color MarkerColor { get; set; }

		// Token: 0x0600651B RID: 25883
		void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc);

		// Token: 0x0600651C RID: 25884
		void #TQc(Point3D #UQc, Point3D #VQc);

		// Token: 0x0600651D RID: 25885
		void #yl();
	}
}

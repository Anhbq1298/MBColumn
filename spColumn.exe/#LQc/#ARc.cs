using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #LQc
{
	// Token: 0x02000C31 RID: 3121
	internal interface #ARc
	{
		// Token: 0x17001C48 RID: 7240
		// (get) Token: 0x06006546 RID: 25926
		// (set) Token: 0x06006547 RID: 25927
		Color MarkerColor { get; set; }

		// Token: 0x06006548 RID: 25928
		void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc);

		// Token: 0x06006549 RID: 25929
		void #qRc(Point3D #0bb);

		// Token: 0x0600654A RID: 25930
		void #rRc(Point3D #YBb, Point3D #sRc);

		// Token: 0x0600654B RID: 25931
		void #tRc(Point3D #0bb);

		// Token: 0x0600654C RID: 25932
		void #yl();
	}
}

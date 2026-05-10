using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #LQc
{
	// Token: 0x02000C39 RID: 3129
	internal interface #zRc
	{
		// Token: 0x17001C4D RID: 7245
		// (get) Token: 0x06006577 RID: 25975
		// (set) Token: 0x06006578 RID: 25976
		Color ForegroundColor { get; set; }

		// Token: 0x06006579 RID: 25977
		void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc);

		// Token: 0x0600657A RID: 25978
		void #TQc(Point3D #0bb, string #hvb);

		// Token: 0x0600657B RID: 25979
		void #TQc(Point #Xrb, Point #Yrb, string #hvb);

		// Token: 0x0600657C RID: 25980
		void #TQc(Point3D #Xrb, Point3D #Yrb, string #hvb);

		// Token: 0x0600657D RID: 25981
		void #yl();
	}
}

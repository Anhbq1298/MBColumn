using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #LQc
{
	// Token: 0x02000C3C RID: 3132
	internal interface #IRc
	{
		// Token: 0x06006585 RID: 25989
		void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc);

		// Token: 0x06006586 RID: 25990
		void #TQc(Point3D? #HAb, double? #HS);

		// Token: 0x06006587 RID: 25991
		void #TQc(Point3D #HAb);

		// Token: 0x06006588 RID: 25992
		void #yl();

		// Token: 0x17001C52 RID: 7250
		// (get) Token: 0x06006589 RID: 25993
		// (set) Token: 0x0600658A RID: 25994
		Color MarkerColor { get; set; }

		// Token: 0x17001C53 RID: 7251
		// (get) Token: 0x0600658B RID: 25995
		// (set) Token: 0x0600658C RID: 25996
		bool Enabled { get; set; }
	}
}

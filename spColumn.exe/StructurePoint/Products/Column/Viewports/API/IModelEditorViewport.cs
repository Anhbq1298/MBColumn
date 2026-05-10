using System;
using System.Collections.Generic;
using #Wse;
using #Xc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.FailureSurface.ViewModels;

namespace StructurePoint.Products.Column.Viewports.API
{
	// Token: 0x020000AF RID: 175
	internal interface IModelEditorViewport : #Fd, IViewport
	{
		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060005AC RID: 1452
		// (set) Token: 0x060005AD RID: 1453
		#lte ReportingModel { get; set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x060005AE RID: 1454
		IDiagramPresenterViewModel DiagramPresenter { get; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x060005AF RID: 1455
		DrawingHelper DrawingHelper { get; }

		// Token: 0x060005B0 RID: 1456
		void #Pd(ActivateDiagramParameters #Qd, bool #Rd = false, IList<SelectedLoadData> #Sd = null);

		// Token: 0x060005B1 RID: 1457
		void #Td();

		// Token: 0x060005B2 RID: 1458
		void #Nd(#lte #Od);
	}
}

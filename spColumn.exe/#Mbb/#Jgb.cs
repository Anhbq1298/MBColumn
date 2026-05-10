using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using #Oze;
using #Wse;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.Products.Column.FailureSurface.Views;

namespace #Mbb
{
	// Token: 0x020003FE RID: 1022
	internal interface #Jgb : INotifyPropertyChanged, IViewModel<IDiagram2DView>, IViewModel, #Kgb
	{
		// Token: 0x14000081 RID: 129
		// (add) Token: 0x06002337 RID: 9015
		// (remove) Token: 0x06002338 RID: 9016
		event EventHandler<#Yjb> LoadPointClicked;

		// Token: 0x14000082 RID: 130
		// (add) Token: 0x06002339 RID: 9017
		// (remove) Token: 0x0600233A RID: 9018
		event EventHandler ViewControlsClosed;

		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x0600233B RID: 9019
		IReadOnlyList<LoadPointDrawingData> VisibleLoadPoints { get; }

		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x0600233C RID: 9020
		#mAe SuperImposeContext { get; }

		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x0600233D RID: 9021
		// (set) Token: 0x0600233E RID: 9022
		SolidColorBrush Background { get; set; }

		// Token: 0x0600233F RID: 9023
		void #6bb(#lte #Od, Diagram2DType #2bb, double #Sb, IList<SelectedLoadData> #Sd, bool #7bb);

		// Token: 0x06002340 RID: 9024
		Diagram2DData #4bb(bool #5bb = false);

		// Token: 0x06002341 RID: 9025
		void #Ybb(bool #Zbb, ToolsPanelPosition #0bb);

		// Token: 0x06002342 RID: 9026
		bool #Wbb();

		// Token: 0x06002343 RID: 9027
		void #Xbb();

		// Token: 0x06002344 RID: 9028
		void #Vbb();
	}
}

using System;
using System.ComponentModel;
using #Oze;
using #S9;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.FailureSurface.Views;
using Telerik.Windows.Controls;

namespace #nib
{
	// Token: 0x02000416 RID: 1046
	internal interface #sib : INotifyPropertyChanged, IViewModel<ISuperImposeView>, IViewModel
	{
		// Token: 0x140000A3 RID: 163
		// (add) Token: 0x06002576 RID: 9590
		// (remove) Token: 0x06002577 RID: 9591
		event EventHandler RequestClose;

		// Token: 0x17000CB5 RID: 3253
		// (get) Token: 0x06002578 RID: 9592
		#mAe SuperImposeContext { get; }

		// Token: 0x17000CB6 RID: 3254
		// (get) Token: 0x06002579 RID: 9593
		#tbb DiagramsContext { get; }

		// Token: 0x17000CB7 RID: 3255
		// (get) Token: 0x0600257A RID: 9594
		DelegateCommand AddNewRowCommand { get; }

		// Token: 0x17000CB8 RID: 3256
		// (get) Token: 0x0600257B RID: 9595
		DelegateCommand RemoveRowCommand { get; }

		// Token: 0x17000CB9 RID: 3257
		// (get) Token: 0x0600257C RID: 9596
		DelegateCommand RedrawDiagramCommand { get; }

		// Token: 0x17000CBA RID: 3258
		// (get) Token: 0x0600257D RID: 9597
		SuperImposeDiagram SelectedItem { get; }

		// Token: 0x0600257E RID: 9598
		void #cg();
	}
}

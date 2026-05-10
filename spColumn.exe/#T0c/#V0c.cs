using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using #ezc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #T0c
{
	// Token: 0x02000CAA RID: 3242
	internal interface #V0c : INotifyPropertyChanged, #RBc<#U0c>, IViewModel
	{
		// Token: 0x06006992 RID: 27026
		void #j0c(Point3D #k0c, BoundingBoxData #Prc);

		// Token: 0x06006993 RID: 27027
		void #l0c();

		// Token: 0x06006994 RID: 27028
		void #FZc(IEnumerable<GridLineDefinitionModel> #ooc, bool #GZc);

		// Token: 0x06006995 RID: 27029
		void #FZc(IEnumerable<GridLineDefinitionModel> #ooc, bool #GZc, bool #HZc);

		// Token: 0x06006996 RID: 27030
		void #QZc(ShapeDataModel #XDc);

		// Token: 0x06006997 RID: 27031
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		void #QZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc);

		// Token: 0x06006998 RID: 27032
		void #RZc(ShapeDataModel #XDc);

		// Token: 0x06006999 RID: 27033
		void #RZc(ShapeDataModel #XDc, bool #SZc, bool #TZc);

		// Token: 0x0600699A RID: 27034
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		void #RZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc);

		// Token: 0x0600699B RID: 27035
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		void #RZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc, bool #SZc, bool #TZc);

		// Token: 0x0600699C RID: 27036
		void #UZc(ShapeDataModel #XDc, bool #SZc, bool #TZc);

		// Token: 0x0600699D RID: 27037
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		void #UZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc, bool #SZc, bool #TZc);

		// Token: 0x0600699E RID: 27038
		void #6Zc(ShapeDataModel #XDc, Color #BR);

		// Token: 0x0600699F RID: 27039
		Color #7Zc(ShapeDataModel #XDc);

		// Token: 0x060069A0 RID: 27040
		void #8ob(ShapeDataModel #XDc);

		// Token: 0x060069A1 RID: 27041
		void #YZc(ShapeDataModel #XDc);

		// Token: 0x060069A2 RID: 27042
		void #1Zc(ShapeDataModel #XDc);

		// Token: 0x060069A3 RID: 27043
		void #1Zc(ShapeDataModel #XDc, bool #2Zc);

		// Token: 0x060069A4 RID: 27044
		void #1Zc(ShapeDataModel #XDc, Color #lYc);

		// Token: 0x060069A5 RID: 27045
		void #3Zc(ShapeDataModel #XDc, bool #SZc, bool #TZc, bool #2Zc);

		// Token: 0x060069A6 RID: 27046
		void #5Zc(ShapeDataModel #XDc);

		// Token: 0x060069A7 RID: 27047
		bool #OZc(ShapeDataModel #XDc);

		// Token: 0x060069A8 RID: 27048
		bool #PZc(ShapeDataModel #XDc);

		// Token: 0x060069A9 RID: 27049
		void #8Zc(IEnumerable<NodeModel> #6W);

		// Token: 0x060069AA RID: 27050
		void #9Zc(NodeModel #uXb);

		// Token: 0x060069AB RID: 27051
		void #a0c(NodeModel #uXb);

		// Token: 0x060069AC RID: 27052
		void #c0c(IEnumerable<NodeModel> #6W);

		// Token: 0x060069AD RID: 27053
		void #e0c(IEnumerable<LinearObject> #iEc);

		// Token: 0x060069AE RID: 27054
		void #f0c(LinearObject #NNc);

		// Token: 0x060069AF RID: 27055
		void #g0c(LinearObject #NNc);

		// Token: 0x060069B0 RID: 27056
		void #VZc(IReadOnlyList<ShapeDataModel> #6Y);

		// Token: 0x060069B1 RID: 27057
		void #XZc(IReadOnlyList<ShapeDataModel> #6Y);

		// Token: 0x060069B2 RID: 27058
		void #8ob(IEnumerable<ShapeDataModel> #6Y);

		// Token: 0x060069B3 RID: 27059
		void #ZZc(IEnumerable<ShapeDataModel> #6Y);

		// Token: 0x060069B4 RID: 27060
		void #i0c(IEnumerable<LinearObject> #iEc);

		// Token: 0x060069B5 RID: 27061
		void #0Zc(IEnumerable<ShapeDataModel> #rP);

		// Token: 0x060069B6 RID: 27062
		void #b0c(IEnumerable<NodeModel> #6W);

		// Token: 0x060069B7 RID: 27063
		void #h0c(IEnumerable<LinearObject> #iEc);

		// Token: 0x060069B8 RID: 27064
		void #4Zc(IEnumerable<ShapeDataModel> #6Y);

		// Token: 0x060069B9 RID: 27065
		void #IZc(GridLineDefinitionModel #bsc);

		// Token: 0x060069BA RID: 27066
		void #JZc(GridLineDefinitionModel #bsc);

		// Token: 0x060069BB RID: 27067
		void #KZc(IEnumerable<GridLineDefinitionModel> #ooc);

		// Token: 0x060069BC RID: 27068
		void #LZc(IEnumerable<GridLineDefinitionModel> #ooc);

		// Token: 0x060069BD RID: 27069
		Point3D? #MZc(GridLineDefinitionModel #bsc);

		// Token: 0x060069BE RID: 27070
		void #NZc();

		// Token: 0x060069BF RID: 27071
		void #d0c();

		// Token: 0x17001D1F RID: 7455
		// (get) Token: 0x060069C0 RID: 27072
		bool SuspendEvents { get; }

		// Token: 0x17001D20 RID: 7456
		// (get) Token: 0x060069C1 RID: 27073
		ObservableCollection<ICheckBoxData> VisibilityToolBarCheckBoxes { get; }

		// Token: 0x17001D21 RID: 7457
		// (get) Token: 0x060069C2 RID: 27074
		// (set) Token: 0x060069C3 RID: 27075
		Visibility VisibilityToolBarVisibility { get; set; }

		// Token: 0x17001D22 RID: 7458
		// (get) Token: 0x060069C4 RID: 27076
		// (set) Token: 0x060069C5 RID: 27077
		bool AreShapesVisible { get; set; }

		// Token: 0x17001D23 RID: 7459
		// (get) Token: 0x060069C6 RID: 27078
		// (set) Token: 0x060069C7 RID: 27079
		bool AreGridLinesVisible { get; set; }

		// Token: 0x17001D24 RID: 7460
		// (get) Token: 0x060069C8 RID: 27080
		// (set) Token: 0x060069C9 RID: 27081
		bool AreLinearObjectsVisible { get; set; }

		// Token: 0x17001D25 RID: 7461
		// (get) Token: 0x060069CA RID: 27082
		// (set) Token: 0x060069CB RID: 27083
		bool AreNodesVisible { get; set; }

		// Token: 0x17001D26 RID: 7462
		// (get) Token: 0x060069CC RID: 27084
		// (set) Token: 0x060069CD RID: 27085
		bool AreGridLineAnnotationsVisible { get; set; }

		// Token: 0x17001D27 RID: 7463
		// (get) Token: 0x060069CE RID: 27086
		double AnnotationsRadius { get; }

		// Token: 0x17001D28 RID: 7464
		// (get) Token: 0x060069CF RID: 27087
		ObservableCollection<object> ViewControlsPanelAdditionalTools { get; }

		// Token: 0x17001D29 RID: 7465
		// (get) Token: 0x060069D0 RID: 27088
		// (set) Token: 0x060069D1 RID: 27089
		Visibility ViewControlsPanelVisibility { get; set; }

		// Token: 0x17001D2A RID: 7466
		// (get) Token: 0x060069D2 RID: 27090
		// (set) Token: 0x060069D3 RID: 27091
		ToolsPanelPosition ViewControlsPanelPosition { get; set; }

		// Token: 0x17001D2B RID: 7467
		// (get) Token: 0x060069D4 RID: 27092
		// (set) Token: 0x060069D5 RID: 27093
		bool ViewControlsPanelCollapsed { get; set; }

		// Token: 0x14000199 RID: 409
		// (add) Token: 0x060069D6 RID: 27094
		// (remove) Token: 0x060069D7 RID: 27095
		event EventHandler LayerVisibilityChanged;

		// Token: 0x060069D8 RID: 27096
		void #m0c(IList<GridLineDefinitionModel> #ooc, bool #JS, bool #GZc);
	}
}

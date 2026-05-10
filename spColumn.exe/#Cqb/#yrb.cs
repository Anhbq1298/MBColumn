using System;
using System.Collections.Generic;
using System.ComponentModel;
using #Mbb;
using #S9;
using #Wse;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #Cqb
{
	// Token: 0x0200046F RID: 1135
	internal interface #yrb : INotifyPropertyChanged
	{
		// Token: 0x140000C2 RID: 194
		// (add) Token: 0x060029D9 RID: 10713
		// (remove) Token: 0x060029DA RID: 10714
		event EventHandler<#Yjb> LoadPointClickedEventArgs;

		// Token: 0x17000E5D RID: 3677
		// (get) Token: 0x060029DB RID: 10715
		IEventManager EventManager { get; }

		// Token: 0x17000E5E RID: 3678
		// (get) Token: 0x060029DC RID: 10716
		IList<IPlaneDrawingResult> PlaneMyP { get; }

		// Token: 0x17000E5F RID: 3679
		// (get) Token: 0x060029DD RID: 10717
		IList<IPlaneDrawingResult> PlanePMx { get; }

		// Token: 0x17000E60 RID: 3680
		// (get) Token: 0x060029DE RID: 10718
		// (set) Token: 0x060029DF RID: 10719
		IList<IPlaneDrawingResult> PlaneMxMy { get; set; }

		// Token: 0x17000E61 RID: 3681
		// (get) Token: 0x060029E0 RID: 10720
		// (set) Token: 0x060029E1 RID: 10721
		string LoadPointsCountMessage { get; set; }

		// Token: 0x060029E2 RID: 10722
		void #hrb(IList<SelectedLoadData> #tk);

		// Token: 0x060029E3 RID: 10723
		void #irb(#lte #Od);

		// Token: 0x060029E4 RID: 10724
		void #jrb(#cfb #krb);

		// Token: 0x060029E5 RID: 10725
		void #lrb();

		// Token: 0x060029E6 RID: 10726
		void #mrb(#cfb #krb);

		// Token: 0x060029E7 RID: 10727
		void #nrb();

		// Token: 0x060029E8 RID: 10728
		void #8fb(#lte #Od);

		// Token: 0x060029E9 RID: 10729
		void #7fb();

		// Token: 0x060029EA RID: 10730
		void #orb();

		// Token: 0x060029EB RID: 10731
		void #prb();

		// Token: 0x060029EC RID: 10732
		void #qrb();

		// Token: 0x060029ED RID: 10733
		void #rrb();

		// Token: 0x060029EE RID: 10734
		void #srb();

		// Token: 0x060029EF RID: 10735
		void #trb(#Bbb #urb);

		// Token: 0x060029F0 RID: 10736
		void #vrb(#Bbb #urb);

		// Token: 0x060029F1 RID: 10737
		void #wrb();

		// Token: 0x060029F2 RID: 10738
		void #xrb();

		// Token: 0x060029F3 RID: 10739
		void #Nfb();
	}
}

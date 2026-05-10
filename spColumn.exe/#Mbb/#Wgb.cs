using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using #S9;
using #Wse;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.FailureSurface.Views;

namespace #Mbb
{
	// Token: 0x0200040D RID: 1037
	internal interface #Wgb : INotifyPropertyChanged, IViewModel<IFailureSurfaceView>, IViewModel, #Kgb
	{
		// Token: 0x14000099 RID: 153
		// (add) Token: 0x060024CF RID: 9423
		// (remove) Token: 0x060024D0 RID: 9424
		event EventHandler<#pkb> AxialLoadChanged;

		// Token: 0x1400009A RID: 154
		// (add) Token: 0x060024D1 RID: 9425
		// (remove) Token: 0x060024D2 RID: 9426
		event EventHandler<#pkb> AngleChanged;

		// Token: 0x1400009B RID: 155
		// (add) Token: 0x060024D3 RID: 9427
		// (remove) Token: 0x060024D4 RID: 9428
		event EventHandler<#pkb> AxialLoadChanging;

		// Token: 0x1400009C RID: 156
		// (add) Token: 0x060024D5 RID: 9429
		// (remove) Token: 0x060024D6 RID: 9430
		event EventHandler<#pkb> AngleChanging;

		// Token: 0x1400009D RID: 157
		// (add) Token: 0x060024D7 RID: 9431
		// (remove) Token: 0x060024D8 RID: 9432
		event EventHandler<#Yjb> LoadPointClickedEventArgs;

		// Token: 0x1400009E RID: 158
		// (add) Token: 0x060024D9 RID: 9433
		// (remove) Token: 0x060024DA RID: 9434
		event EventHandler ViewControlsClosed;

		// Token: 0x17000C7C RID: 3196
		// (get) Token: 0x060024DB RID: 9435
		// (set) Token: 0x060024DC RID: 9436
		Visibility ViewControlsPanelVisibility { get; set; }

		// Token: 0x17000C7D RID: 3197
		// (get) Token: 0x060024DD RID: 9437
		FailureSurface FailureSurface { get; }

		// Token: 0x17000C7E RID: 3198
		// (get) Token: 0x060024DE RID: 9438
		// (set) Token: 0x060024DF RID: 9439
		#lte CurrentReportingModel { get; set; }

		// Token: 0x17000C7F RID: 3199
		// (get) Token: 0x060024E0 RID: 9440
		bool IsLoaded { get; }

		// Token: 0x060024E1 RID: 9441
		void #Cfb(#lte #Od);

		// Token: 0x060024E2 RID: 9442
		void #Dfb();

		// Token: 0x060024E3 RID: 9443
		void #yl();

		// Token: 0x060024E4 RID: 9444
		void #zfb(double #f, bool #Afb);

		// Token: 0x060024E5 RID: 9445
		void #Bfb(Diagram3DCutType #Odb);

		// Token: 0x060024E6 RID: 9446
		void #vfb();

		// Token: 0x060024E7 RID: 9447
		void #wfb(#xbb #xfb, #ybb #yfb);

		// Token: 0x060024E8 RID: 9448
		void #Efb();

		// Token: 0x060024E9 RID: 9449
		void #Mdb(IList<SelectedLoadData> #tk);

		// Token: 0x060024EA RID: 9450
		void #ufb();

		// Token: 0x060024EB RID: 9451
		bool #Wbb();

		// Token: 0x060024EC RID: 9452
		void #Vbb();

		// Token: 0x060024ED RID: 9453
		void #tfb();

		// Token: 0x060024EE RID: 9454
		void #Xbb();

		// Token: 0x060024EF RID: 9455
		void #8fb(#lte #Od = null);

		// Token: 0x060024F0 RID: 9456
		void #GVh();
	}
}

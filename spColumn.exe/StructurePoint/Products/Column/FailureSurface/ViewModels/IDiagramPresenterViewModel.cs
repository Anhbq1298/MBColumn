using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using #Wse;
using #Xc;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Menu;
using StructurePoint.Products.Column.FailureSurface.Views;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x02000405 RID: 1029
	internal interface IDiagramPresenterViewModel : IDisposable, INotifyPropertyChanged, INotifyPropertyChanging, IViewModel<IDiagramPresenterView>, IViewModel
	{
		// Token: 0x1400008B RID: 139
		// (add) Token: 0x060023EC RID: 9196
		// (remove) Token: 0x060023ED RID: 9197
		event EventHandler ButtonStatesInvalidated;

		// Token: 0x1400008C RID: 140
		// (add) Token: 0x060023EE RID: 9198
		// (remove) Token: 0x060023EF RID: 9199
		event EventHandler<#pkb> AxialLoadChanged;

		// Token: 0x1400008D RID: 141
		// (add) Token: 0x060023F0 RID: 9200
		// (remove) Token: 0x060023F1 RID: 9201
		event EventHandler<#pkb> AngleChanged;

		// Token: 0x1400008E RID: 142
		// (add) Token: 0x060023F2 RID: 9202
		// (remove) Token: 0x060023F3 RID: 9203
		event EventHandler<#pkb> AxialLoadChanging;

		// Token: 0x1400008F RID: 143
		// (add) Token: 0x060023F4 RID: 9204
		// (remove) Token: 0x060023F5 RID: 9205
		event EventHandler<#pkb> AngleChanging;

		// Token: 0x14000090 RID: 144
		// (add) Token: 0x060023F6 RID: 9206
		// (remove) Token: 0x060023F7 RID: 9207
		event EventHandler<#Yjb> LoadPointClickedEventArgs;

		// Token: 0x14000091 RID: 145
		// (add) Token: 0x060023F8 RID: 9208
		// (remove) Token: 0x060023F9 RID: 9209
		event EventHandler DiagramParameterChanged;

		// Token: 0x14000092 RID: 146
		// (add) Token: 0x060023FA RID: 9210
		// (remove) Token: 0x060023FB RID: 9211
		event EventHandler PresenterTypeChanged;

		// Token: 0x17000C42 RID: 3138
		// (get) Token: 0x060023FC RID: 9212
		RadObservableCollection<MenuItemExt> ContextMenuItems { get; }

		// Token: 0x17000C43 RID: 3139
		// (get) Token: 0x060023FD RID: 9213
		DelegateCommandAdapter OnContextMenuOpeningCommand { get; }

		// Token: 0x17000C44 RID: 3140
		// (get) Token: 0x060023FE RID: 9214
		DelegateCommandAdapter Diagram3DFlipCommand { get; }

		// Token: 0x17000C45 RID: 3141
		// (get) Token: 0x060023FF RID: 9215
		DelegateCommandAdapter ExportDiagramCommand { get; }

		// Token: 0x17000C46 RID: 3142
		// (get) Token: 0x06002400 RID: 9216
		DelegateCommandAdapter ChangeCutTypeCommand { get; }

		// Token: 0x17000C47 RID: 3143
		// (get) Token: 0x06002401 RID: 9217
		DelegateCommandAdapter ChangeDiagram2DTypeCommand { get; }

		// Token: 0x17000C48 RID: 3144
		// (get) Token: 0x06002402 RID: 9218
		DelegateCommandAdapter CutCommand { get; }

		// Token: 0x17000C49 RID: 3145
		// (get) Token: 0x06002403 RID: 9219
		DelegateCommandAdapter ChangePresenterTypeCommand { get; }

		// Token: 0x17000C4A RID: 3146
		// (get) Token: 0x06002404 RID: 9220
		DelegateCommandAdapter ShowPlaneCommand { get; }

		// Token: 0x17000C4B RID: 3147
		// (get) Token: 0x06002405 RID: 9221
		DelegateCommandAdapter ActivateDiagramCommand { get; }

		// Token: 0x17000C4C RID: 3148
		// (get) Token: 0x06002406 RID: 9222
		bool IsDiagramMMChecked { get; }

		// Token: 0x17000C4D RID: 3149
		// (get) Token: 0x06002407 RID: 9223
		bool IsDiagramPMChecked { get; }

		// Token: 0x17000C4E RID: 3150
		// (get) Token: 0x06002408 RID: 9224
		bool IsDiagramPMPlusChecked { get; }

		// Token: 0x17000C4F RID: 3151
		// (get) Token: 0x06002409 RID: 9225
		bool IsDiagramPMMinusChecked { get; }

		// Token: 0x17000C50 RID: 3152
		// (get) Token: 0x0600240A RID: 9226
		bool IsDiagramPMGroupChecked { get; }

		// Token: 0x17000C51 RID: 3153
		// (get) Token: 0x0600240B RID: 9227
		bool IsDiagram3DHorizontalChecked { get; }

		// Token: 0x17000C52 RID: 3154
		// (get) Token: 0x0600240C RID: 9228
		bool IsDiagram3DVerticalChecked { get; }

		// Token: 0x17000C53 RID: 3155
		// (get) Token: 0x0600240D RID: 9229
		// (set) Token: 0x0600240E RID: 9230
		bool IsActive { get; set; }

		// Token: 0x17000C54 RID: 3156
		// (get) Token: 0x0600240F RID: 9231
		IReadOnlyList<LoadPointDrawingData> VisibleLoadPoints { get; }

		// Token: 0x17000C55 RID: 3157
		// (get) Token: 0x06002410 RID: 9232
		#Ke PresenterHost { get; }

		// Token: 0x17000C56 RID: 3158
		// (get) Token: 0x06002411 RID: 9233
		IView ActiveView { get; }

		// Token: 0x17000C57 RID: 3159
		// (get) Token: 0x06002412 RID: 9234
		// (set) Token: 0x06002413 RID: 9235
		DiagramPresenterType PresenterType { get; set; }

		// Token: 0x17000C58 RID: 3160
		// (get) Token: 0x06002414 RID: 9236
		// (set) Token: 0x06002415 RID: 9237
		bool Diagram3DIsVerticalCutEnabled { get; set; }

		// Token: 0x17000C59 RID: 3161
		// (get) Token: 0x06002416 RID: 9238
		// (set) Token: 0x06002417 RID: 9239
		bool Diagram3DIsHorizontalCutEnabled { get; set; }

		// Token: 0x17000C5A RID: 3162
		// (get) Token: 0x06002418 RID: 9240
		Diagram3DCutType Diagram3DCutType { get; }

		// Token: 0x17000C5B RID: 3163
		// (get) Token: 0x06002419 RID: 9241
		// (set) Token: 0x0600241A RID: 9242
		Diagram3DCutType DefinedDiagram3DCutType { get; set; }

		// Token: 0x17000C5C RID: 3164
		// (get) Token: 0x0600241B RID: 9243
		// (set) Token: 0x0600241C RID: 9244
		Diagram2DType Diagram2DType { get; set; }

		// Token: 0x17000C5D RID: 3165
		// (get) Token: 0x0600241D RID: 9245
		// (set) Token: 0x0600241E RID: 9246
		bool Diagram3DEnableCutOnValueChange { get; set; }

		// Token: 0x17000C5E RID: 3166
		// (get) Token: 0x0600241F RID: 9247
		// (set) Token: 0x06002420 RID: 9248
		double Angle { get; set; }

		// Token: 0x17000C5F RID: 3167
		// (get) Token: 0x06002421 RID: 9249
		// (set) Token: 0x06002422 RID: 9250
		double AxialLoad { get; set; }

		// Token: 0x17000C60 RID: 3168
		// (get) Token: 0x06002423 RID: 9251
		// (set) Token: 0x06002424 RID: 9252
		Brush Background { get; set; }

		// Token: 0x17000C61 RID: 3169
		// (get) Token: 0x06002425 RID: 9253
		// (set) Token: 0x06002426 RID: 9254
		bool IsReportSourceValid { get; set; }

		// Token: 0x06002427 RID: 9255
		void #gab();

		// Token: 0x06002428 RID: 9256
		void #Pd(ActivateDiagramParameters #Jdb);

		// Token: 0x06002429 RID: 9257
		void #Kdb();

		// Token: 0x0600242A RID: 9258
		Diagram2DData #Ldb(bool #5bb = false);

		// Token: 0x0600242B RID: 9259
		void #Mdb(IEnumerable<SelectedLoadData> #tk);

		// Token: 0x0600242C RID: 9260
		void #Ndb(Diagram3DCutType #Odb);

		// Token: 0x0600242D RID: 9261
		void #Pdb(double #f);

		// Token: 0x0600242E RID: 9262
		void #Qdb(Diagram2DType #C);

		// Token: 0x0600242F RID: 9263
		void #Rdb(double #f);

		// Token: 0x06002430 RID: 9264
		void #Sdb(double #Tdb, double #Udb);

		// Token: 0x06002431 RID: 9265
		void #Vdb(DiagramPresenterType #C);

		// Token: 0x06002432 RID: 9266
		bool #pA(#lte #Wdb);

		// Token: 0x06002433 RID: 9267
		void #hz(#lte #Wdb);

		// Token: 0x06002434 RID: 9268
		void #Xdb();

		// Token: 0x06002435 RID: 9269
		void #6db();

		// Token: 0x06002436 RID: 9270
		void #Gdb();

		// Token: 0x06002437 RID: 9271
		void #Ybb();

		// Token: 0x06002438 RID: 9272
		void #GVh();
	}
}

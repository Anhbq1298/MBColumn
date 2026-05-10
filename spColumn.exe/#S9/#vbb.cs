using System;
using #RJb;
using #Wse;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #S9
{
	// Token: 0x020003D7 RID: 983
	internal interface #vbb
	{
		// Token: 0x17000BE3 RID: 3043
		// (get) Token: 0x0600224F RID: 8783
		#tbb Context { get; }

		// Token: 0x17000BE4 RID: 3044
		// (get) Token: 0x06002250 RID: 8784
		DelegateCommand Diagram3DFlipCommand { get; }

		// Token: 0x17000BE5 RID: 3045
		// (get) Token: 0x06002251 RID: 8785
		DelegateCommand ExportDiagramCommand { get; }

		// Token: 0x17000BE6 RID: 3046
		// (get) Token: 0x06002252 RID: 8786
		DelegateCommand ChangeCutTypeCommand { get; }

		// Token: 0x17000BE7 RID: 3047
		// (get) Token: 0x06002253 RID: 8787
		DelegateCommand ChangeDiagram2DTypeCommand { get; }

		// Token: 0x17000BE8 RID: 3048
		// (get) Token: 0x06002254 RID: 8788
		DelegateCommand CutCommand { get; }

		// Token: 0x17000BE9 RID: 3049
		// (get) Token: 0x06002255 RID: 8789
		DelegateCommand ChangePresenterTypeCommand { get; }

		// Token: 0x17000BEA RID: 3050
		// (get) Token: 0x06002256 RID: 8790
		DelegateCommand ChangeViewControlsVisibilityCommand { get; }

		// Token: 0x17000BEB RID: 3051
		// (get) Token: 0x06002257 RID: 8791
		DelegateCommand ShowPlaneCommand { get; }

		// Token: 0x17000BEC RID: 3052
		// (get) Token: 0x06002258 RID: 8792
		DelegateCommand ActivateDiagramCommand { get; }

		// Token: 0x17000BED RID: 3053
		// (get) Token: 0x06002259 RID: 8793
		// (set) Token: 0x0600225A RID: 8794
		bool Diagram3DIsVerticalCutActive { get; set; }

		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x0600225B RID: 8795
		bool Diagram3DEnableCutOnValueChange { get; }

		// Token: 0x17000BEF RID: 3055
		// (get) Token: 0x0600225C RID: 8796
		// (set) Token: 0x0600225D RID: 8797
		bool IsDiagram3DHorizontalCutActive { get; set; }

		// Token: 0x17000BF0 RID: 3056
		// (get) Token: 0x0600225E RID: 8798
		// (set) Token: 0x0600225F RID: 8799
		#BLb ScopesManager { get; set; }

		// Token: 0x06002260 RID: 8800
		bool #bab();

		// Token: 0x06002261 RID: 8801
		void #cab();

		// Token: 0x06002262 RID: 8802
		void #fab(#lte #Od, #7z #ubb);

		// Token: 0x06002263 RID: 8803
		void #gab();

		// Token: 0x06002264 RID: 8804
		void #Pd(IModelEditorViewport #fe, ActivateDiagramParameters #Pc, #7z #bA = #7z.#a);

		// Token: 0x06002265 RID: 8805
		void #dab(bool #eab = false);

		// Token: 0x06002266 RID: 8806
		void #Kc();

		// Token: 0x06002267 RID: 8807
		void #Lc();

		// Token: 0x06002268 RID: 8808
		void #Mc();

		// Token: 0x06002269 RID: 8809
		void #Nc();

		// Token: 0x0600226A RID: 8810
		void #xf();
	}
}

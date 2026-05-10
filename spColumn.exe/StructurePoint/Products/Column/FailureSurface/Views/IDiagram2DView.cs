using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using #Iub;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.Products.Column.FailureSurface.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E2 RID: 994
	internal interface IDiagram2DView : IView
	{
		// Token: 0x14000077 RID: 119
		// (add) Token: 0x0600228D RID: 8845
		// (remove) Token: 0x0600228E RID: 8846
		event MouseEventHandler DiagramMouseMove;

		// Token: 0x14000078 RID: 120
		// (add) Token: 0x0600228F RID: 8847
		// (remove) Token: 0x06002290 RID: 8848
		event MouseButtonEventHandler DiagramMouseButtonDown;

		// Token: 0x14000079 RID: 121
		// (add) Token: 0x06002291 RID: 8849
		// (remove) Token: 0x06002292 RID: 8850
		event KeyEventHandler KeyDown;

		// Token: 0x1400007A RID: 122
		// (add) Token: 0x06002293 RID: 8851
		// (remove) Token: 0x06002294 RID: 8852
		event SizeChangedEventHandler SizeChanged;

		// Token: 0x1400007B RID: 123
		// (add) Token: 0x06002295 RID: 8853
		// (remove) Token: 0x06002296 RID: 8854
		event EventHandler<SelectedValueChangedEventArgs<bool>> ShowGridChanged;

		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x06002297 RID: 8855
		IFloatingControlsPanel ViewControls { get; }

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x06002298 RID: 8856
		double ActualHeight { get; }

		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x06002299 RID: 8857
		double ActualWidth { get; }

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x0600229A RID: 8858
		double ZoomFactor { get; }

		// Token: 0x17000BFE RID: 3070
		// (get) Token: 0x0600229B RID: 8859
		bool IsPanEnabled { get; }

		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x0600229C RID: 8860
		bool IsZoomRectangleEnabled { get; }

		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x0600229D RID: 8861
		DiagramImagePostprocessor DiagramPostprocessor { get; }

		// Token: 0x17000C01 RID: 3073
		// (get) Token: 0x0600229E RID: 8862
		// (set) Token: 0x0600229F RID: 8863
		bool IsShowGridChecked { get; set; }

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x060022A0 RID: 8864
		Rect CurrentViewBox { get; }

		// Token: 0x17000C03 RID: 3075
		// (get) Token: 0x060022A1 RID: 8865
		double DiagramActualWidth { get; }

		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x060022A2 RID: 8866
		double DiagramActualHeight { get; }

		// Token: 0x060022A3 RID: 8867
		void ShowDiagram(#Gvb parameters, Diagram2DCursorType cursorType);

		// Token: 0x060022A4 RID: 8868
		IEnumerable<KeyValuePair<string, object>> GetDrawnVisuals(string prefix);

		// Token: 0x060022A5 RID: 8869
		bool CancelAllTools();

		// Token: 0x060022A6 RID: 8870
		void ResetZoomAndTranslation();
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #Iub;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.Products.Column.FailureSurface.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E1 RID: 993
	internal sealed class Diagram2DView : ColumnBaseView, IComponentConnector, IView, IDiagram2DView
	{
		// Token: 0x0600226B RID: 8811 RVA: 0x000CAEC8 File Offset: 0x000C90C8
		public Diagram2DView()
		{
			this.InitializeComponent();
			this.Diagram2DControl.DiagramMouseMove += this.Diagram2DControl_DiagramMouseMove;
			this.Diagram2DControl.DiagramMouseButtonDown += this.Diagram2DControl_DiagramMouseButtonDown;
			this.Diagram2DControl.ShowGridChanged += delegate(object s, SelectedValueChangedEventArgs<bool> e)
			{
				this.OnShowGridChanged(e);
			};
		}

		// Token: 0x14000074 RID: 116
		// (add) Token: 0x0600226C RID: 8812 RVA: 0x000CAF28 File Offset: 0x000C9128
		// (remove) Token: 0x0600226D RID: 8813 RVA: 0x000CAF6C File Offset: 0x000C916C
		public event EventHandler<SelectedValueChangedEventArgs<bool>> ShowGridChanged;

		// Token: 0x14000075 RID: 117
		// (add) Token: 0x0600226E RID: 8814 RVA: 0x000CAFB0 File Offset: 0x000C91B0
		// (remove) Token: 0x0600226F RID: 8815 RVA: 0x000CAFF4 File Offset: 0x000C91F4
		public event MouseEventHandler DiagramMouseMove;

		// Token: 0x14000076 RID: 118
		// (add) Token: 0x06002270 RID: 8816 RVA: 0x000CB038 File Offset: 0x000C9238
		// (remove) Token: 0x06002271 RID: 8817 RVA: 0x000CB07C File Offset: 0x000C927C
		public event MouseButtonEventHandler DiagramMouseButtonDown;

		// Token: 0x17000BF1 RID: 3057
		// (get) Token: 0x06002272 RID: 8818 RVA: 0x000215BF File Offset: 0x0001F7BF
		// (set) Token: 0x06002273 RID: 8819 RVA: 0x000215D4 File Offset: 0x0001F7D4
		public bool IsShowGridChecked
		{
			get
			{
				return this.Diagram2DControl.IsShowGridChecked;
			}
			set
			{
				this.Diagram2DControl.IsShowGridChecked = value;
			}
		}

		// Token: 0x17000BF2 RID: 3058
		// (get) Token: 0x06002274 RID: 8820 RVA: 0x000215EE File Offset: 0x0001F7EE
		public double DiagramActualWidth
		{
			get
			{
				return this.Diagram2DControl.ZoomPanel.ActualWidth;
			}
		}

		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x06002275 RID: 8821 RVA: 0x00021608 File Offset: 0x0001F808
		public double DiagramActualHeight
		{
			get
			{
				return this.Diagram2DControl.ZoomPanel.ActualHeight;
			}
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x06002276 RID: 8822 RVA: 0x00021622 File Offset: 0x0001F822
		public Rect CurrentViewBox
		{
			get
			{
				return this.Diagram2DControl.ZoomPanel.Viewbox;
			}
		}

		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x06002277 RID: 8823 RVA: 0x0002163C File Offset: 0x0001F83C
		public DiagramImagePostprocessor DiagramPostprocessor
		{
			get
			{
				return this.Diagram2DControl.DiagramPostprocessor;
			}
		}

		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x06002278 RID: 8824 RVA: 0x00021651 File Offset: 0x0001F851
		public IFloatingControlsPanel ViewControls
		{
			get
			{
				return this.Diagram2DControl.FloatingControlsPanel;
			}
		}

		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x06002279 RID: 8825 RVA: 0x00021662 File Offset: 0x0001F862
		public bool IsPanEnabled
		{
			get
			{
				return this.Diagram2DControl.IsPanEnabled;
			}
		}

		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x0600227A RID: 8826 RVA: 0x00021677 File Offset: 0x0001F877
		public bool IsZoomRectangleEnabled
		{
			get
			{
				return this.Diagram2DControl.IsZoomRectangleEnabled;
			}
		}

		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x0600227B RID: 8827 RVA: 0x0002168C File Offset: 0x0001F88C
		public double ZoomFactor
		{
			get
			{
				return this.Diagram2DControl.ZoomPanel.ZoomFactor;
			}
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x000216A6 File Offset: 0x0001F8A6
		public void ResetZoomAndTranslation()
		{
			this.Diagram2DControl.ResetZoomAndTranslation();
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x000216BB File Offset: 0x0001F8BB
		public bool CancelAllTools()
		{
			return this.Diagram2DControl.DisableAllTools();
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x000216D0 File Offset: 0x0001F8D0
		public void ShowDiagram(#Gvb parameters, Diagram2DCursorType cursorType)
		{
			if (cursorType == Diagram2DCursorType.Crosshair)
			{
				base.Cursor = Cursors.Cross;
			}
			else
			{
				base.Cursor = Cursors.Arrow;
			}
			this.Diagram2DControl.ShowDiagram(parameters);
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x00021705 File Offset: 0x0001F905
		public IEnumerable<KeyValuePair<string, object>> GetDrawnVisuals(string prefix)
		{
			return this.Diagram2DControl.GetDrawnVisuals(prefix);
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x000CB0C0 File Offset: 0x000C92C0
		protected void OnDiagramMouseMove(object sender, MouseEventArgs e)
		{
			MouseEventHandler diagramMouseMove = this.DiagramMouseMove;
			if (diagramMouseMove != null)
			{
				diagramMouseMove(sender, e);
			}
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x000CB0EC File Offset: 0x000C92EC
		protected void OnDiagramMouseButtonDown(object sender, MouseButtonEventArgs e)
		{
			MouseButtonEventHandler diagramMouseButtonDown = this.DiagramMouseButtonDown;
			if (diagramMouseButtonDown != null)
			{
				diagramMouseButtonDown(sender, e);
			}
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x000CB118 File Offset: 0x000C9318
		protected void OnShowGridChanged(SelectedValueChangedEventArgs<bool> e)
		{
			EventHandler<SelectedValueChangedEventArgs<bool>> showGridChanged = this.ShowGridChanged;
			if (showGridChanged != null)
			{
				showGridChanged(this, e);
			}
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x0002171F File Offset: 0x0001F91F
		private void Diagram2DControl_DiagramMouseButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnDiagramMouseButtonDown(sender, e);
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x00021735 File Offset: 0x0001F935
		private void Diagram2DControl_DiagramMouseMove(object sender, MouseEventArgs e)
		{
			this.OnDiagramMouseMove(sender, e);
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x000CB144 File Offset: 0x000C9344
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363389), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x0002174B File Offset: 0x0001F94B
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.Diagram2DControl = (Diagram2DControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x00021771 File Offset: 0x0001F971
		void IDiagram2DView.add_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged += value;
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x00021786 File Offset: 0x0001F986
		void IDiagram2DView.remove_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged -= value;
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x00008BA1 File Offset: 0x00006DA1
		double IDiagram2DView.get_ActualHeight()
		{
			return base.ActualHeight;
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x00008B91 File Offset: 0x00006D91
		double IDiagram2DView.get_ActualWidth()
		{
			return base.ActualWidth;
		}

		// Token: 0x04000DD9 RID: 3545
		internal Diagram2DControl Diagram2DControl;

		// Token: 0x04000DDA RID: 3546
		private bool _contentLoaded;
	}
}

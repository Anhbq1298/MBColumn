using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;
using #Iub;
using #NHe;
using Ab2d.Common.ReaderSvg;
using Ab2d.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D;
using Svg;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x02000486 RID: 1158
	internal sealed class Diagram2DControl : UserControl, IComponentConnector
	{
		// Token: 0x06002AD0 RID: 10960 RVA: 0x000E804C File Offset: 0x000E624C
		public Diagram2DControl()
		{
			this.<DiagramPostprocessor>k__BackingField = new DiagramImagePostprocessor();
			base..ctor();
			this.InitializeComponent();
			this.ZoomPanel.ViewboxChanged += this.ZoomPanel_ViewboxChanged;
			this.ZoomPanel.IsAnimated = false;
			this.SvgViewBox.AutoSize = true;
			this.SvgViewBox.SvgFileLoaded += this.SvgViewBox_SvgFileLoaded;
			this.SvgViewBox.AddHandler(UIElement.PreviewMouseMoveEvent, new MouseEventHandler(this.SvgViewBox_MouseMove), true);
			this.SvgViewBox.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(this.SvgViewBox_MouseDown), true);
			base.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(this.This_MouseUp), true);
			this.FloatingControlsPanel.Panel2D3DVisibilityItemsVisibility = Visibility.Collapsed;
			FloatingControlsPanel floatingControlsPanel = this.FloatingControlsPanel;
			ObservableCollection<IPanelItem> observableCollection = new ObservableCollection<IPanelItem>();
			PanelItem panelItem = new PanelItem();
			panelItem.Visibility = Visibility.Visible;
			ZoomPanelController zoomPanelController = new ZoomPanelController();
			zoomPanelController.ZoomPanel = this.ZoomPanel;
			ZoomPanelController content = zoomPanelController;
			this.zoomPanelController = zoomPanelController;
			panelItem.Content = content;
			panelItem.BorderThickness = new Thickness(0.0, 0.0, 0.0, 1.0);
			panelItem.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107357641)));
			observableCollection.Add(panelItem);
			floatingControlsPanel.BuiltInTools = observableCollection;
			this.zoomPanelController.AfterResetExecuted += this.ZoomPanelController_AfterResetExecuted;
			this.zoomPanelController.ShowGridChanged += delegate(object s, SelectedValueChangedEventArgs<bool> e)
			{
				this.OnShowGridChanged(e);
			};
			this.zoomPanelController.OnInvalidateCommandsOccurred();
		}

		// Token: 0x140000C4 RID: 196
		// (add) Token: 0x06002AD1 RID: 10961 RVA: 0x000E81E0 File Offset: 0x000E63E0
		// (remove) Token: 0x06002AD2 RID: 10962 RVA: 0x000E8224 File Offset: 0x000E6424
		public event EventHandler<SelectedValueChangedEventArgs<bool>> ShowGridChanged;

		// Token: 0x140000C5 RID: 197
		// (add) Token: 0x06002AD3 RID: 10963 RVA: 0x000E8268 File Offset: 0x000E6468
		// (remove) Token: 0x06002AD4 RID: 10964 RVA: 0x000E82AC File Offset: 0x000E64AC
		public event MouseEventHandler DiagramMouseMove;

		// Token: 0x140000C6 RID: 198
		// (add) Token: 0x06002AD5 RID: 10965 RVA: 0x000E82F0 File Offset: 0x000E64F0
		// (remove) Token: 0x06002AD6 RID: 10966 RVA: 0x000E8334 File Offset: 0x000E6534
		public event MouseButtonEventHandler DiagramMouseButtonDown;

		// Token: 0x140000C7 RID: 199
		// (add) Token: 0x06002AD7 RID: 10967 RVA: 0x000E8378 File Offset: 0x000E6578
		// (remove) Token: 0x06002AD8 RID: 10968 RVA: 0x000E83BC File Offset: 0x000E65BC
		public event EventHandler DiagramLoaded;

		// Token: 0x17000E80 RID: 3712
		// (get) Token: 0x06002AD9 RID: 10969 RVA: 0x00026B64 File Offset: 0x00024D64
		// (set) Token: 0x06002ADA RID: 10970 RVA: 0x00026B79 File Offset: 0x00024D79
		public bool IsShowGridChecked
		{
			get
			{
				return this.zoomPanelController.IsShowGridChecked;
			}
			set
			{
				this.zoomPanelController.IsShowGridChecked = value;
			}
		}

		// Token: 0x17000E81 RID: 3713
		// (get) Token: 0x06002ADB RID: 10971 RVA: 0x00026B93 File Offset: 0x00024D93
		public bool IsPanEnabled
		{
			get
			{
				return this.ZoomPanel.IsPanEnabled;
			}
		}

		// Token: 0x17000E82 RID: 3714
		// (get) Token: 0x06002ADC RID: 10972 RVA: 0x00026BA8 File Offset: 0x00024DA8
		public bool IsZoomRectangleEnabled
		{
			get
			{
				return this.ZoomPanel.ZoomMode == Ab2d.Controls.ZoomPanel.ZoomModeType.Rectangle;
			}
		}

		// Token: 0x17000E83 RID: 3715
		// (get) Token: 0x06002ADD RID: 10973 RVA: 0x00026BC0 File Offset: 0x00024DC0
		public DiagramImagePostprocessor DiagramPostprocessor { get; }

		// Token: 0x06002ADE RID: 10974 RVA: 0x000E8400 File Offset: 0x000E6600
		public bool DisableAllTools()
		{
			bool result = false;
			if (this.ZoomPanel.IsPanEnabled)
			{
				this.zoomPanelController.ActivatePanModeCommand.Execute(null);
				result = true;
			}
			if (this.zoomPanelController.IsZoomWindowEnabled)
			{
				this.zoomPanelController.ActivateZoomToWindowCommand.Execute(null);
				result = true;
			}
			return result;
		}

		// Token: 0x06002ADF RID: 10975 RVA: 0x000E845C File Offset: 0x000E665C
		public IEnumerable<KeyValuePair<string, object>> GetDrawnVisuals(string prefix)
		{
			return from item in this.SvgViewBox.NamedObjects
			where item.Key.StartsWith(prefix, StringComparison.Ordinal)
			select item;
		}

		// Token: 0x06002AE0 RID: 10976 RVA: 0x00026BCC File Offset: 0x00024DCC
		public void ResetZoomAndTranslation()
		{
			this.ZoomPanel.Reset();
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x000E84A0 File Offset: 0x000E66A0
		public void ShowDiagram(#Gvb displayParameters)
		{
			this.DiagramPostprocessor.BaseFontSize = (double)#ZIe.#Pb(displayParameters.Settings.TextSize);
			this.DiagramPostprocessor.OriginalFontSize = (double)#ZIe.#Pb(displayParameters.Settings.TextSize);
			this.DiagramPostprocessor.DrawingData = displayParameters.Graphics.Diagram.DrawingData;
			this.DiagramPostprocessor.DrawingResult = displayParameters.Graphics;
			this.lastZoomFactor = null;
			SvgDocument doc = displayParameters.Graphics.DrawingContent;
			this.SvgViewBox.Load(doc.GetXML());
			if ((this.ZoomPanel.ZoomFactor != 1.0 && !displayParameters.KeepZoomAndTranslationParameters) || displayParameters.ForceResetView)
			{
				this.ZoomPanel.Reset();
			}
		}

		// Token: 0x06002AE2 RID: 10978 RVA: 0x000E8594 File Offset: 0x000E6794
		protected void OnDiagramMouseMove(object sender, MouseEventArgs e)
		{
			MouseEventHandler diagramMouseMove = this.DiagramMouseMove;
			if (diagramMouseMove != null)
			{
				diagramMouseMove(sender, e);
			}
		}

		// Token: 0x06002AE3 RID: 10979 RVA: 0x000E85C0 File Offset: 0x000E67C0
		protected void OnDiagramMouseButtonDown(object sender, MouseButtonEventArgs e)
		{
			MouseButtonEventHandler diagramMouseButtonDown = this.DiagramMouseButtonDown;
			if (diagramMouseButtonDown != null)
			{
				diagramMouseButtonDown(sender, e);
			}
		}

		// Token: 0x06002AE4 RID: 10980 RVA: 0x000E85EC File Offset: 0x000E67EC
		protected void OnDiagramLoaded()
		{
			EventHandler diagramLoaded = this.DiagramLoaded;
			if (diagramLoaded != null)
			{
				diagramLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06002AE5 RID: 10981 RVA: 0x000E861C File Offset: 0x000E681C
		protected void OnShowGridChanged(SelectedValueChangedEventArgs<bool> e)
		{
			EventHandler<SelectedValueChangedEventArgs<bool>> showGridChanged = this.ShowGridChanged;
			if (showGridChanged != null)
			{
				showGridChanged(this, e);
			}
		}

		// Token: 0x06002AE6 RID: 10982 RVA: 0x00026BE1 File Offset: 0x00024DE1
		private void ZoomPanelController_AfterResetExecuted(object sender, EventArgs e)
		{
			this.ShakeAsync(true);
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x000E8648 File Offset: 0x000E6848
		private void This_MouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (this.ZoomPanel.ZoomMode == Ab2d.Controls.ZoomPanel.ZoomModeType.Rectangle && mouseButtonEventArgs.ChangedButton == MouseButton.Left && mouseButtonEventArgs.OriginalSource.GetType() == typeof(Grid))
			{
				this.ShakeAsync(true);
			}
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x00026BF2 File Offset: 0x00024DF2
		private void SvgViewBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.OnDiagramMouseButtonDown(sender, e);
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x00026C08 File Offset: 0x00024E08
		private void SvgViewBox_MouseMove(object sender, MouseEventArgs e)
		{
			this.OnDiagramMouseMove(sender, e);
		}

		// Token: 0x06002AEA RID: 10986 RVA: 0x000E869C File Offset: 0x000E689C
		private void SvgViewBox_SvgFileLoaded(object sender, SvgFileLoadedEventArgs e)
		{
			this.DiagramPostprocessor.#dub(e.ReadSvgFile);
			foreach (TextBlock textBlock in this.SvgViewBox.ChildrenOfType<TextBlock>())
			{
				textBlock.IsHitTestVisible = false;
			}
			foreach (Shape shape in this.SvgViewBox.ChildrenOfType<Shape>())
			{
				shape.IsHitTestVisible = false;
			}
			base.Dispatcher.BeginInvoke(new Action(this.UpdateScaling), Array.Empty<object>());
			this.OnDiagramLoaded();
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x000E8784 File Offset: 0x000E6984
		private void ZoomPanel_ViewboxChanged(object sender, ViewboxChangedRoutedEventArgs e)
		{
			if (this.lastZoomFactor == null || Math.Abs(this.lastZoomFactor.Value - this.ZoomPanel.ZoomFactor) > 0.001)
			{
				this.lastZoomFactor = new double?(this.ZoomPanel.ZoomFactor);
				this.UpdateScaling();
			}
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x000E87F0 File Offset: 0x000E69F0
		private void ShakeAsync(bool async = true)
		{
			if (async)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(delegate()
				{
					this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor + 0.01);
					this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor - 0.01);
				});
				return;
			}
			this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor + 0.01);
			this.ZoomPanel.ZoomToFactor(this.ZoomPanel.ZoomFactor - 0.01);
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x00026C1E File Offset: 0x00024E1E
		private void UpdateScaling()
		{
			this.DiagramPostprocessor.#fub(this.SvgViewBox, this.ZoomPanel.ZoomFactor);
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x000E8860 File Offset: 0x000E6A60
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107357660), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x000E88A4 File Offset: 0x000E6AA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ZoomPanel = (CustomZoomPanel)target;
				return;
			case 2:
				this.SvgViewBox = (CustomSvgViewBox)target;
				return;
			case 3:
				this.FloatingControlsPanel = (FloatingControlsPanel)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04001116 RID: 4374
		private readonly ZoomPanelController zoomPanelController;

		// Token: 0x04001117 RID: 4375
		private double? lastZoomFactor;

		// Token: 0x0400111D RID: 4381
		internal CustomZoomPanel ZoomPanel;

		// Token: 0x0400111E RID: 4382
		internal CustomSvgViewBox SvgViewBox;

		// Token: 0x0400111F RID: 4383
		internal FloatingControlsPanel FloatingControlsPanel;

		// Token: 0x04001120 RID: 4384
		private bool _contentLoaded;
	}
}

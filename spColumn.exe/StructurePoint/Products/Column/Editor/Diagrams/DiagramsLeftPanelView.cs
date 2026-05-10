using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #APb;
using #IJb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Controls;
using StructurePoint.Products.Column.FailureSurface.ViewModels;

namespace StructurePoint.Products.Column.Editor.Diagrams
{
	// Token: 0x02000643 RID: 1603
	internal sealed class DiagramsLeftPanelView : ColumnBaseView, IComponentConnector, IView, #CPb
	{
		// Token: 0x060035F3 RID: 13811 RVA: 0x0002F455 File Offset: 0x0002D655
		public DiagramsLeftPanelView()
		{
			this.InitializeComponent();
			base.Loaded += this.DiagramsLeftPanelView_Loaded;
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x001098C0 File Offset: 0x00107AC0
		private void DiagramsLeftPanelView_Loaded(object sender, RoutedEventArgs e)
		{
			#LJb #LJb = base.DataContext as #LJb;
			this.DiagramPM2DRibbonButton.Button.Command = ((#LJb != null) ? #LJb.Services.Commands.ActivateDiagramWithParameters : null);
			this.DiagramPM2DRibbonButton.Button.CommandParameter = ActivateDiagramParameters.Diagram2DPM;
			this.DiagramPM3DRibbonButton.Button.Command = ((#LJb != null) ? #LJb.Services.Commands.ActivateDiagramWithParameters : null);
			this.DiagramPM3DRibbonButton.Button.CommandParameter = ActivateDiagramParameters.Diagram3DVertical;
			this.DiagramMM3DRibbonButton.Button.Command = ((#LJb != null) ? #LJb.Services.Commands.ActivateDiagramWithParameters : null);
			this.DiagramMM3DRibbonButton.Button.CommandParameter = ActivateDiagramParameters.Diagram3DHorizontal;
		}

		// Token: 0x060035F5 RID: 13813 RVA: 0x001099A8 File Offset: 0x00107BA8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107352449), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060035F6 RID: 13814 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060035F7 RID: 13815 RVA: 0x001099EC File Offset: 0x00107BEC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.DiagramPM2DRibbonButton = (ColumnRibbonDropdownButton)target;
				return;
			case 2:
				this.DiagramPM3DRibbonButton = (ColumnRibbonDropdownButton)target;
				return;
			case 3:
				this.DiagramMM3DRibbonButton = (ColumnRibbonDropdownButton)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04001677 RID: 5751
		internal ColumnRibbonDropdownButton DiagramPM2DRibbonButton;

		// Token: 0x04001678 RID: 5752
		internal ColumnRibbonDropdownButton DiagramPM3DRibbonButton;

		// Token: 0x04001679 RID: 5753
		internal ColumnRibbonDropdownButton DiagramMM3DRibbonButton;

		// Token: 0x0400167A RID: 5754
		private bool _contentLoaded;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E3 RID: 995
	internal sealed class DiagramPresenterView : ColumnBaseView, IComponentConnector, IView, IDiagramPresenterView
	{
		// Token: 0x060022A7 RID: 8871 RVA: 0x000217B0 File Offset: 0x0001F9B0
		public DiagramPresenterView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x060022A8 RID: 8872 RVA: 0x000217BE File Offset: 0x0001F9BE
		// (set) Token: 0x060022A9 RID: 8873 RVA: 0x000217CA File Offset: 0x0001F9CA
		public string Title { get; set; }

		// Token: 0x060022AA RID: 8874 RVA: 0x000CB188 File Offset: 0x000C9388
		protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
		{
			Diagram2DView diagram2DView = this.ContentPresenter.Content as Diagram2DView;
			if (diagram2DView != null && !diagram2DView.Diagram2DControl.IsFocused)
			{
				diagram2DView.Diagram2DControl.Focus();
			}
			base.OnPreviewMouseRightButtonDown(e);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x000CB1D8 File Offset: 0x000C93D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363788), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x000217DB File Offset: 0x0001F9DB
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ContentPresenter = (ContentControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x00021771 File Offset: 0x0001F971
		void IDiagramPresenterView.add_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged += value;
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x00021786 File Offset: 0x0001F986
		void IDiagramPresenterView.remove_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged -= value;
		}

		// Token: 0x04000DDC RID: 3548
		internal ContentControl ContentPresenter;

		// Token: 0x04000DDD RID: 3549
		private bool _contentLoaded;
	}
}

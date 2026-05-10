using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003E7 RID: 999
	internal sealed class FailureSurfaceView : ColumnBaseView, IComponentConnector, IView, IFailureSurfaceView
	{
		// Token: 0x060022B6 RID: 8886 RVA: 0x0002181C File Offset: 0x0001FA1C
		public FailureSurfaceView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x060022B7 RID: 8887 RVA: 0x0002182A File Offset: 0x0001FA2A
		public IModelEditorControl ModelEditorControl
		{
			get
			{
				return this.MyModelEditorControl;
			}
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x00021836 File Offset: 0x0001FA36
		public void ExportCurrentViewAsImage(Stream sinkStream)
		{
			VisualToImageExportHelper.ExportToPng(this, sinkStream);
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x000CB260 File Offset: 0x000C9460
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363642), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x0002184B File Offset: 0x0001FA4B
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.MyModelEditorControl = (ModelEditorControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000DDF RID: 3551
		internal ModelEditorControl MyModelEditorControl;

		// Token: 0x04000DE0 RID: 3552
		private bool _contentLoaded;
	}
}

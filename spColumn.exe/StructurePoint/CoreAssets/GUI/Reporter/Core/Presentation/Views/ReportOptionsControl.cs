using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DCF RID: 3535
	public sealed class ReportOptionsControl : UserControl, IComponentConnector
	{
		// Token: 0x06007FD9 RID: 32729 RVA: 0x000682A7 File Offset: 0x000664A7
		public ReportOptionsControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06007FDA RID: 32730 RVA: 0x001BF000 File Offset: 0x001BD200
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279703), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007FDB RID: 32731 RVA: 0x000682B5 File Offset: 0x000664B5
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400346C RID: 13420
		private bool _contentLoaded;
	}
}

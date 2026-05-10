using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD3 RID: 3539
	public sealed class CsvReportPage : UserControl, IComponentConnector
	{
		// Token: 0x06008012 RID: 32786 RVA: 0x000683B9 File Offset: 0x000665B9
		public CsvReportPage()
		{
			this.InitializeComponent();
		}

		// Token: 0x06008013 RID: 32787 RVA: 0x001BF7CC File Offset: 0x001BD9CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107278928), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06008014 RID: 32788 RVA: 0x000683C7 File Offset: 0x000665C7
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400347F RID: 13439
		private bool _contentLoaded;
	}
}

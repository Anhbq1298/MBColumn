using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DD4 RID: 3540
	public sealed class ExcelReportPage : UserControl, IComponentConnector
	{
		// Token: 0x06008015 RID: 32789 RVA: 0x000683D4 File Offset: 0x000665D4
		public ExcelReportPage()
		{
			this.InitializeComponent();
			WorkbookFormatProvidersManager.RegisterFormatProvider(new XlsxFormatProvider());
		}

		// Token: 0x06008016 RID: 32790 RVA: 0x00009E6A File Offset: 0x0000806A
		public void LoadSpreadsheet(Stream stream)
		{
		}

		// Token: 0x06008017 RID: 32791 RVA: 0x00009E6A File Offset: 0x0000806A
		public void Navigate(string item)
		{
		}

		// Token: 0x06008018 RID: 32792 RVA: 0x001BF814 File Offset: 0x001BDA14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279331), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06008019 RID: 32793 RVA: 0x000683F7 File Offset: 0x000665F7
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04003480 RID: 13440
		private readonly XlsxFormatProvider provider = new XlsxFormatProvider();

		// Token: 0x04003481 RID: 13441
		private bool _contentLoaded;
	}
}

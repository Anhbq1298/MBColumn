using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #Uwb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Templates.Views
{
	// Token: 0x020004AD RID: 1197
	internal sealed class TemplateSelectorWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #Vwb
	{
		// Token: 0x06002C1B RID: 11291 RVA: 0x00027B9D File Offset: 0x00025D9D
		public TemplateSelectorWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x000EB450 File Offset: 0x000E9650
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107357121), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x00027BAB File Offset: 0x00025DAB
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040011AB RID: 4523
		private bool _contentLoaded;
	}
}

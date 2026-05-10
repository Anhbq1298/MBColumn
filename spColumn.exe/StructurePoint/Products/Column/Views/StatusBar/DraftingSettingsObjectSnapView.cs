using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #Gb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.StatusBar
{
	// Token: 0x0200003D RID: 61
	internal sealed class DraftingSettingsObjectSnapView : ColumnBaseView, IComponentConnector, IView, #Jb
	{
		// Token: 0x060003BF RID: 959 RVA: 0x00008C87 File Offset: 0x00006E87
		public DraftingSettingsObjectSnapView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00086C04 File Offset: 0x00084E04
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388818), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00008C95 File Offset: 0x00006E95
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400007B RID: 123
		private bool _contentLoaded;
	}
}

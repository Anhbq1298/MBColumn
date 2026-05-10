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
	// Token: 0x0200003B RID: 59
	internal sealed class DraftingSettingsDynamicInputView : ColumnBaseView, IComponentConnector, IView, #Ib
	{
		// Token: 0x060003BC RID: 956 RVA: 0x00008C6C File Offset: 0x00006E6C
		public DraftingSettingsDynamicInputView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00086BC0 File Offset: 0x00084DC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388919), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00008C7A File Offset: 0x00006E7A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400007A RID: 122
		private bool _contentLoaded;
	}
}

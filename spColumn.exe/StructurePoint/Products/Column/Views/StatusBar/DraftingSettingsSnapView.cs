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
	// Token: 0x0200003F RID: 63
	internal sealed class DraftingSettingsSnapView : ColumnBaseView, IComponentConnector, IView, #Kb
	{
		// Token: 0x060003C2 RID: 962 RVA: 0x00008CA2 File Offset: 0x00006EA2
		public DraftingSettingsSnapView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00086C48 File Offset: 0x00084E48
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388721), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00008CB0 File Offset: 0x00006EB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400007C RID: 124
		private bool _contentLoaded;
	}
}

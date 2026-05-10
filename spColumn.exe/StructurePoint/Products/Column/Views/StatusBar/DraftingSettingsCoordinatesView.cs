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
	// Token: 0x02000037 RID: 55
	internal sealed class DraftingSettingsCoordinatesView : ColumnBaseView, IComponentConnector, IView, #Fb
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x00008C36 File Offset: 0x00006E36
		public DraftingSettingsCoordinatesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00086B38 File Offset: 0x00084D38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388601), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00008C44 File Offset: 0x00006E44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000078 RID: 120
		private bool _contentLoaded;
	}
}

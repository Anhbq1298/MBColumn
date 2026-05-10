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
	// Token: 0x02000039 RID: 57
	internal sealed class DraftingSettingsDrawingGridView : ColumnBaseView, IComponentConnector, IView, #Hb
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x00008C51 File Offset: 0x00006E51
		public DraftingSettingsDrawingGridView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00086B7C File Offset: 0x00084D7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388504), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00008C5F File Offset: 0x00006E5F
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000079 RID: 121
		private bool _contentLoaded;
	}
}
